using System.Collections.Generic;
using System.Linq;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Data;
using Nop.Plugin.Appointment.Scheduler.Domain;
using Nop.Plugin.Appointment.Scheduler.Models;

namespace Nop.Plugin.Appointment.Scheduler.Services
{
    public partial class AppointmentService : IAppointmentService
    {
        private readonly IRepository<TekAppointment> _appointmentRepository;
        private readonly IRepository<Customer> _customerRepository;

        public AppointmentService(
            IRepository<TekAppointment> appointmentRepository,
            IRepository<Customer> customerRepository
            )
        {
            _appointmentRepository = appointmentRepository;
            _customerRepository = customerRepository;
        }

        public IPagedList<AppointmentModel> GetAll(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = from appointment in _appointmentRepository.Table
                        join customer in _customerRepository.Table on appointment.CustomerId equals customer.Id
                        join specialist in _customerRepository.Table on appointment.SpecialistId equals specialist.Id
                        orderby appointment.Date
                        select new AppointmentModel()
                        {
                            CreatedBy = appointment.CreatedBy,
                            CreatedOnUtc = appointment.CreatedOnUtc,
                            CustomerUsername = customer.Username,
                            Date = appointment.Date,
                            Deleted = appointment.Deleted,
                            Id = appointment.Id,
                            Observation = appointment.Observation,
                            SpecialistUsername = specialist.Username,
                            UpdatedBy = appointment.UpdatedBy,
                            UpdatedOnUtc = appointment.UpdatedOnUtc
                        };

            var records = new PagedList<AppointmentModel>(query, pageIndex, pageSize);

            return records;
        }
    }
}
