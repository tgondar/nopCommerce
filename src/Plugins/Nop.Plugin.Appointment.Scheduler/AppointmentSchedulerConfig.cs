using System;
using System.Collections.Generic;
using System.Text;
using Nop.Services.Plugins;
using Nop.Data;
using Nop.Plugin.Appointment.Scheduler.Services;
using Nop.Core.Infrastructure;
using Nop.Services.Logging;

namespace Nop.Plugin.Appointment.Scheduler
{
    public class AppointmentSchedulerConfig : BasePlugin
    {
        //private IInstallationConfigurationService _installationConfigurationService;
        private readonly IDataProvider _dataProvider;
        private readonly INopFileProvider _fileProvider;
        private readonly ILogger _logger;

        public AppointmentSchedulerConfig(
            //IInstallationConfigurationService installationConfigurationService
            IDataProvider dataProvider,
            INopFileProvider fileProvider,
            ILogger logger)
        {
            //_installationConfigurationService = installationConfigurationService;
            _dataProvider = dataProvider;
            _fileProvider = fileProvider;
            _logger = logger;
        }

        public override void Install()
        {
            //_installationConfigurationService.Install();
            var baseSqlScriptPath = _fileProvider.MapPath("~/Plugins/Appointment.Scheduler/SqlScripts/");

            if (_fileProvider.FileExists(baseSqlScriptPath + "InstallTablesScript.sql"))
            {
                _dataProvider.Query<object>(_fileProvider.ReadAllText(baseSqlScriptPath + "InstallTablesScript.sql", Encoding.UTF8));
            }
            else
            {
                _logger.Error("Appointment.Scheduler > Installation ERROR: Missing File 'InstallTablesScript.sql'");
            }

            if (_fileProvider.FileExists(baseSqlScriptPath + "InstallInsertScript.sql"))
            {
                _dataProvider.Query<object>(_fileProvider.ReadAllText(baseSqlScriptPath + "InstallInsertScript.sql", Encoding.UTF8));
            }
            else
            {
                _logger.Error("Appointment.Scheduler > Installation ERROR: Missing File 'InstallInsertScript.sql'");
            }

            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            var baseSqlScriptPath = _fileProvider.MapPath("~/Plugins/Appointment.Scheduler/SqlScripts/");

            if (_fileProvider.FileExists(baseSqlScriptPath + "UninstallScript.sql"))
            {
                _dataProvider.Query<object>(_fileProvider.ReadAllText(baseSqlScriptPath + "UninstallScript.sql", Encoding.UTF8));
            }
            else
            {
                _logger.Error("Appointment.Scheduler > Uninstallation ERROR: Missing File 'UninstallScript.sql'");
            }

            //TODO: 

            base.Uninstall();
        }
    }
}
