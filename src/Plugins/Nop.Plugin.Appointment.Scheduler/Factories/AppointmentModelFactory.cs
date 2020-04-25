using System;
using System.Linq;
using Nop.Plugin.Appointment.Scheduler.Domain;
using Nop.Plugin.Appointment.Scheduler.Infrastructure.Mapper.Extensions;
using Nop.Plugin.Appointment.Scheduler.Models;
using Nop.Plugin.Appointment.Scheduler.Services;
using Nop.Services.Customers;
using Nop.Services.Helpers;
using Nop.Services.Localization;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Plugin.Appointment.Scheduler.Factories
{
    public partial class AppointmentModelFactory : IAppointmentModelFactory
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly IAppointmentService _appointmentService;
        private readonly ICustomerService _customerService;
        private readonly IDateTimeHelper _dateTimeHelper;

        #endregion

        #region Ctor

        public AppointmentModelFactory(
            ILocalizationService localizationService,
            IDateTimeHelper dateTimeHelper,
            IAppointmentService appointmentService,
            ICustomerService customerService)
        {
            _localizationService = localizationService;
            _appointmentService = appointmentService;
            _dateTimeHelper = dateTimeHelper;
            _customerService = customerService;
        }

        #endregion

        #region Methods

        public virtual AppointmentSearchModel PrepareQueuedEmailSearchModel(AppointmentSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        public virtual AppointmentListModel PrepareAppointmentListModel(AppointmentSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get parameters to filter emails
            var startDateValue = !searchModel.SearchStartDate.HasValue ? null
                : (DateTime?)_dateTimeHelper.ConvertToUtcTime(searchModel.SearchStartDate.Value, _dateTimeHelper.CurrentTimeZone);
            var endDateValue = !searchModel.SearchEndDate.HasValue ? null
                : (DateTime?)_dateTimeHelper.ConvertToUtcTime(searchModel.SearchEndDate.Value, _dateTimeHelper.CurrentTimeZone).AddDays(1);

            //get queued
            var queued = _appointmentService.GetAll(
                startDateValue,
                endDateValue,
                pageIndex: searchModel.Page - 1,
                pageSize: searchModel.PageSize);

            //prepare list model
            var model = new AppointmentListModel().PrepareToGrid(searchModel, queued, () =>
            {
                return queued.Select(queuedField =>
                {
                    //fill in model values from the entity
                    var appointmentModel = queuedField.ToModel<AppointmentModel>();

                    //little performance
                    appointmentModel.CreatedBy = string.Empty;
                    appointmentModel.CreatedOn = null;

                    //convert dates to the user time
                    appointmentModel.UpdatedOn = _dateTimeHelper.ConvertToUserTime(queuedField.UpdatedOnUtc, DateTimeKind.Utc);

                    //fill in additional values (not existing in the entity)
                    appointmentModel.CustomerUsername = _customerService.GetCustomerById(queuedField.CustomerId)?.Username ?? string.Empty;
                    appointmentModel.SpecialistUsername = _customerService.GetCustomerById(queuedField.SpecialistId)?.Username ?? string.Empty;

                    return appointmentModel;
                });
            });

            return model;
        }

        public virtual AppointmentModel PrepareAppointmentModel(AppointmentModel model, TekAppointment queuedAppointment, bool excludeProperties = false)
        {
            if (queuedAppointment == null)
                return model;

            //fill in model values from the entity
            model = model ?? queuedAppointment.ToModel<AppointmentModel>();

            model.CustomerUsername = _customerService.GetCustomerById(queuedAppointment.CustomerId)?.Username ?? string.Empty;
            model.SpecialistUsername = _customerService.GetCustomerById(queuedAppointment.SpecialistId)?.Username ?? string.Empty;
            model.CreatedOn = _dateTimeHelper.ConvertToUserTime(queuedAppointment.CreatedOnUtc, DateTimeKind.Utc);
            model.UpdatedOn = _dateTimeHelper.ConvertToUserTime(queuedAppointment.CreatedOnUtc, DateTimeKind.Utc);

            return model;
        }

        #endregion
    }
}
