using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Appointment.Scheduler.Domain;
using Nop.Plugin.Appointment.Scheduler.Factories;
using Nop.Plugin.Appointment.Scheduler.Infrastructure.Mapper.Extensions;
using Nop.Plugin.Appointment.Scheduler.Models;
using Nop.Plugin.Appointment.Scheduler.Services;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Appointment.Scheduler.Controllers
{
    [Area(AreaNames.Admin)]
    public partial class AppointmentController : BasePluginController
    {
        private IAppointmentModelFactory _appointmentModelFactory;
        private IAppointmentService _appointmentService;
        private IPermissionService _permissionService;
        private INotificationService _notificationService;
        private ILocalizationService _localizationService;

        public AppointmentController(
            IAppointmentModelFactory appointmentModelFactory
            , IAppointmentService appointmentService
            , IPermissionService permissionService
            , INotificationService notificationService
            , ILocalizationService localizationService
            )
        {
            _appointmentModelFactory = appointmentModelFactory;
            _appointmentService = appointmentService;
            _permissionService = permissionService;
            _notificationService = notificationService;
            _localizationService = localizationService;
        }

        public virtual IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public virtual IActionResult List()
        {
            //var model = _appointmentService.GetAll(0, 20);

            //return View("~/Plugins/Appointment.Scheduler/Views/Appointment/List.cshtml", model);


            if (!_permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel))
                return AccessDeniedView();

            //prepare model
            var model = _appointmentModelFactory.PrepareQueuedEmailSearchModel(new AppointmentSearchModel());

            return View("~/Plugins/Appointment.Scheduler/Views/Appointment/List.cshtml", model);
        }


        [HttpPost]
        public virtual IActionResult AppointmentList(AppointmentSearchModel searchModel)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel))
                return AccessDeniedView();

            //prepare model
            var model = _appointmentModelFactory.PrepareAppointmentListModel(searchModel);

            return Json(model);
        }




        public virtual IActionResult Create()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel))
                return AccessDeniedView();

            //prepare model
            var model = _appointmentModelFactory.PrepareAppointmentModel(new AppointmentModel(), null);

            return View("~/Plugins/Appointment.Scheduler/Views/Appointment/Create.cshtml", model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public virtual IActionResult Create(AppointmentModel model, bool continueEditing)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel))
                return AccessDeniedView();

            if (ModelState.IsValid)
            {
                var domain = model.ToEntity<TekAppointment>();
                _appointmentService.Insert(domain);

                _notificationService.SuccessNotification(_localizationService.GetResource("Plugins.Appointment.Scheduler.Added"));

                if (!continueEditing)
                    return RedirectToAction("List");

                return RedirectToAction("Edit", new { id = domain.Id });
            }

            //prepare model
            model = _appointmentModelFactory.PrepareAppointmentModel(model, null, true);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

    }
}
