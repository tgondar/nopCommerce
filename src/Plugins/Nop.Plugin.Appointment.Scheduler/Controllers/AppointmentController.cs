using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Appointment.Scheduler.Services;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Appointment.Scheduler.Controllers
{
    [Area(AreaNames.Admin)]
    public class AppointmentController : BasePluginController
    {
        private IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public virtual IActionResult List()
        {
            var model = _appointmentService.GetAll(0, 20);

            return View("~/Plugins/Appointment.Scheduler/Views/Appointment/List.cshtml", model);
        }
    }
}
