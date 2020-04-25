using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Appointment.Scheduler.Factories;
using Nop.Plugin.Appointment.Scheduler.Models;
using Nop.Plugin.Appointment.Scheduler.Services;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Appointment.Scheduler.Controllers
{
    [Area(AreaNames.Admin)]
    public partial class AppointmentController : BasePluginController
    {
        private IAppointmentModelFactory _appointmentModelFactory;

        public AppointmentController(
            IAppointmentModelFactory appointmentModelFactory
            )
        {
            _appointmentModelFactory = appointmentModelFactory;
        }

        public virtual IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public virtual IActionResult List()
        {
            //var model = _appointmentService.GetAll(0, 20);

            //return View("~/Plugins/Appointment.Scheduler/Views/Appointment/List.cshtml", model);


            //if (!_permissionService.Authorize(StandardPermissionProvider.ManageMessageQueue))
            //    return AccessDeniedView();

            //prepare model
            var model = _appointmentModelFactory.PrepareQueuedEmailSearchModel(new AppointmentSearchModel());

            return View("~/Plugins/Appointment.Scheduler/Views/Appointment/List.cshtml", model);
        }


        [HttpPost]
        public virtual IActionResult AppointmentList(AppointmentSearchModel searchModel)
        {
            //if (!_permissionService.Authorize(StandardPermissionProvider.ManageMessageQueue))
            //    return AccessDeniedDataTablesJson();

            //prepare model
            var model = _appointmentModelFactory.PrepareAppointmentListModel(searchModel);

            return Json(model);
        }
    }
}
