using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core;

namespace Nop.Plugin.Appointment.Scheduler.Domain
{
    public partial class TekAppointment : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Observation { get; set; }
        public int CustomerId { get; set; }
        public int SpecialistId { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public string UpdatedBy { get; set; }
    }
}
