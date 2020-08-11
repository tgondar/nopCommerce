using System;
using System.Linq;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Data;
using Nop.Plugin.Appointment.Scheduler.Domain;
using Nop.Services.Events;

namespace Nop.Plugin.Appointment.Scheduler.Services
{
    sealed partial class AppointmentService : IAppointmentService
    {
        private readonly IRepository<TekAppointment> _appointmentRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IEventPublisher _eventPublisher;

        public AppointmentService(
            IRepository<TekAppointment> appointmentRepository
            , IRepository<Customer> customerRepository
            , IEventPublisher eventPublisher
            )
        {
            _appointmentRepository = appointmentRepository;
            _customerRepository = customerRepository;
            _eventPublisher = eventPublisher;
        }

        public IPagedList<TekAppointment> GetAll(DateTime? startDate, DateTime? endDate, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            //var query = from appointment in _appointmentRepository.Table
            //            join customer in _customerRepository.Table on appointment.CustomerId equals customer.Id
            //            join specialist in _customerRepository.Table on appointment.SpecialistId equals specialist.Id
            //            orderby appointment.Date
            //            select new AppointmentModel()
            //            {
            //                CreatedBy = appointment.CreatedBy,
            //                CreatedOnUtc = appointment.CreatedOnUtc,
            //                CustomerUsername = customer.Username,
            //                Date = appointment.Date,
            //                Deleted = appointment.Deleted,
            //                Id = appointment.Id,
            //                Observation = appointment.Observation,
            //                SpecialistUsername = specialist.Username,
            //                UpdatedBy = appointment.UpdatedBy,
            //                UpdatedOnUtc = appointment.UpdatedOnUtc
            //            };

            var query = from appointment in _appointmentRepository.Table
                        select appointment;

            if (startDate.HasValue)
            {
                query = query.Where(x => x.Date >= startDate);
            }

            if (endDate.HasValue)
            {
                query = query.Where(x => x.Date <= endDate);
            }

            query = query.OrderByDescending(x => x.Date);

            var records = new PagedList<TekAppointment>(query, pageIndex, pageSize);

            return records;
        }

        public void Insert(TekAppointment appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment));

            _appointmentRepository.Insert(appointment);

            //event notification
            _eventPublisher.EntityInserted(appointment);
        }

    }
}
