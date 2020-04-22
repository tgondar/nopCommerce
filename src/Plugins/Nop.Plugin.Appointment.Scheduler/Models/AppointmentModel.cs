using System;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Appointment.Scheduler.Models
{
    public class AppointmentModel : BaseNopEntityModel
    {
        [NopResourceDisplayName("Plugins.Appointment.Scheduler.Date")]
        public DateTime Date { get; set; }

        [NopResourceDisplayName("Plugins.Appointment.Scheduler.Observation")]
        public string Observation { get; set; }

        [NopResourceDisplayName("Plugins.Appointment.Scheduler.CustomerUsername")]
        public string CustomerUsername { get; set; }

        [NopResourceDisplayName("Plugins.Appointment.Scheduler.SpecialistUsername")]
        public string SpecialistUsername { get; set; }

        [NopResourceDisplayName("Plugins.Appointment.Scheduler.Deleted")]
        public bool Deleted { get; set; }

        [NopResourceDisplayName("Plugins.Appointment.Scheduler.CreatedOnUtc")]
        public DateTime CreatedOnUtc { get; set; }

        [NopResourceDisplayName("Plugins.Appointment.Scheduler.CreatedBy")]
        public string CreatedBy { get; set; }

        [NopResourceDisplayName("Plugins.Appointment.Scheduler.UpdatedOnUtc")]
        public DateTime UpdatedOnUtc { get; set; }

        [NopResourceDisplayName("Plugins.Appointment.Scheduler.UpdatedBy")]
        public string UpdatedBy { get; set; }
    }
}
