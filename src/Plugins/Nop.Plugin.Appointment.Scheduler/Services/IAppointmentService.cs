using System;
using Nop.Core;
using Nop.Plugin.Appointment.Scheduler.Domain;

namespace Nop.Plugin.Appointment.Scheduler.Services
{
    public interface IAppointmentService
    {
        IPagedList<TekAppointment> GetAll(DateTime? startDate, DateTime? endDate, int pageIndex = 0, int pageSize = int.MaxValue);
    }
}
