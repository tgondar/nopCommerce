using System;
using System.Collections.Generic;
using System.Text;
using Nop.Services.Plugins;
using Nop.Data;

namespace Nop.Plugin.Appointment.Scheduler
{
    public class AppointmentSchedulerConfig : BasePlugin
    {
        private readonly IDataProvider _dataProvider;

        public AppointmentSchedulerConfig(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public override void Install()
        {
            //create the table
            _dataProvider.Query<object>("CREATE TABLE DBO.AAAAAAAAAA (Id INT, [Name] NVARCHAR(50))");

            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            _dataProvider.Query<object>("DROP TABLE DBO.AAAAAAAAAA");

            base.Uninstall();
        }
    }
}
