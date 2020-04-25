using System;
using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Appointment.Scheduler.Models
{
    public partial class AppointmentSearchModel : BaseSearchModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.System.QueuedEmails.List.StartDate")]
        [UIHint("DateNullable")]
        public DateTime? SearchStartDate { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.List.EndDate")]
        [UIHint("DateNullable")]
        public DateTime? SearchEndDate { get; set; }

        [DataType(DataType.EmailAddress)]
        [NopResourceDisplayName("Admin.System.QueuedEmails.List.FromEmail")]
        public string SearchCustomerEmail { get; set; }

        [DataType(DataType.EmailAddress)]
        [NopResourceDisplayName("Admin.System.QueuedEmails.List.ToEmail")]
        public string SearchSpecialistEmail { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.List.LoadNotSent")]
        public bool SearchDeleted { get; set; }

        [NopResourceDisplayName("Admin.System.QueuedEmails.List.GoDirectlyToNumber")]
        public int GoDirectlyToNumber { get; set; }

        #endregion
    }
}
