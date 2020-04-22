using Nop.Core;
using Nop.Plugin.Appointment.Scheduler.Models;

namespace Nop.Plugin.Appointment.Scheduler.Services
{
    public interface IAppointmentService
    {
        IPagedList<AppointmentModel> GetAll(int pageIndex = 0, int pageSize = int.MaxValue);
    }
}
