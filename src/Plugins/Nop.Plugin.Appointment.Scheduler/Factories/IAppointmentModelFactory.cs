using Nop.Plugin.Appointment.Scheduler.Domain;
using Nop.Plugin.Appointment.Scheduler.Models;

namespace Nop.Plugin.Appointment.Scheduler.Factories
{
    public partial interface IAppointmentModelFactory
    {
        AppointmentSearchModel PrepareQueuedEmailSearchModel(AppointmentSearchModel searchModel);

        AppointmentListModel PrepareAppointmentListModel(AppointmentSearchModel searchModel);

        AppointmentModel PrepareAppointmentModel(AppointmentModel model, TekAppointment queuedAppointment, bool excludeProperties = false);
    }
}
