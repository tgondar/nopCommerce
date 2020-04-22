using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Core;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Plugin.Appointment.Scheduler.Domain;
using Nop.Plugin.Appointment.Scheduler.Services;

namespace Nop.Plugin.Appointment.Scheduler
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            builder.RegisterType<AppointmentService>().As<IAppointmentService>().InstancePerLifetimeScope();
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
