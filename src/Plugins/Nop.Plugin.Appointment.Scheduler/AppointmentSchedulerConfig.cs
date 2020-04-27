using System.Text;
using Nop.Services.Plugins;
using Nop.Data;
using Nop.Core.Infrastructure;
using Nop.Services.Logging;
using Nop.Services.Localization;
using Nop.Web.Framework.Menu;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using Nop.Web.Framework;

namespace Nop.Plugin.Appointment.Scheduler
{
    public class AppointmentSchedulerConfig : BasePlugin, IAdminMenuPlugin
    {
        //private IInstallationConfigurationService _installationConfigurationService;
        private readonly IDataProvider _dataProvider;
        private readonly INopFileProvider _fileProvider;
        private readonly ILogger _logger;
        private readonly ILocalizationService _localizationService;

        public AppointmentSchedulerConfig(
            //IInstallationConfigurationService installationConfigurationService
            IDataProvider dataProvider,
            INopFileProvider fileProvider,
            ILocalizationService localizationService,
            ILogger logger
            )
        {
            //_installationConfigurationService = installationConfigurationService;
            _dataProvider = dataProvider;
            _fileProvider = fileProvider;
            _localizationService = localizationService;
            _logger = logger;
        }

        public void ManageSiteMap(SiteMapNode rootNode)
        {

            var pluginMenu = new SiteMapNode()
            {
                SystemName = "Appointment Scheduler",
                Title = "Appointment Scheduler",
                ControllerName = "",
                ActionName = "",
                Visible = true,
                RouteValues = new RouteValueDictionary() { { "area", AreaNames.Admin } },
            };

            var menuItem = new SiteMapNode()
            {
                SystemName = "Appointment Scheduler",
                Title = "o meu lindo teste",
                ControllerName = "Appointment",
                ActionName = "List",
                Visible = true,
                RouteValues = new RouteValueDictionary() { { "area", AreaNames.Admin } },
            };

            pluginMenu.ChildNodes.Add(menuItem);

            var pluginNode = rootNode.ChildNodes.FirstOrDefault(x => x.SystemName == "Third party plugins");

            if (pluginNode != null)
            {
                pluginNode.ChildNodes.Add(pluginMenu);
            }
            else
            {
                rootNode.ChildNodes.Add(pluginMenu);
            }
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

            //locales
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Appointment.Scheduler.Date", "Data");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Appointment.Scheduler.Id", "Id");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Appointment.Scheduler.Observation", "Observação");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Appointment.Scheduler.CustomerUsername", "Cliente");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Appointment.Scheduler.SpecialistUsername", "Especialista");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Appointment.Scheduler.Deleted", "Apagado");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Appointment.Scheduler.CreatedOn", "Data Criação");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Appointment.Scheduler.CreatedBy", "Utilizador Criação");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Appointment.Scheduler.UpdatedOn", "Data Alteração");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Appointment.Scheduler.UpdatedBy", "Utilizador Alteração");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Appointment.Scheduler.SaveButton", "Gravar");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Appointment.Scheduler.CreateButton", "Gravar");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Appointment.Scheduler.DeleteButton", "Apagar");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Appointment.Scheduler.SearchButton", "Pesquisar");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Appointment.Scheduler.EditButton", "Editar");

            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Appointment.Scheduler.StartDate", "Data Início");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Appointment.Scheduler.EndDateDate", "Data Fim");

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

            //locales
            _localizationService.DeletePluginLocaleResource("Plugins.Appointment.Scheduler.Date");
            _localizationService.DeletePluginLocaleResource("Plugins.Appointment.Scheduler.Id");
            _localizationService.DeletePluginLocaleResource("Plugins.Appointment.Scheduler.Observation");
            _localizationService.DeletePluginLocaleResource("Plugins.Appointment.Scheduler.CustomerUsername");
            _localizationService.DeletePluginLocaleResource("Plugins.Appointment.Scheduler.SpecialistUsername");
            _localizationService.DeletePluginLocaleResource("Plugins.Appointment.Scheduler.Deleted");
            _localizationService.DeletePluginLocaleResource("Plugins.Appointment.Scheduler.CreatedOn");
            _localizationService.DeletePluginLocaleResource("Plugins.Appointment.Scheduler.CreatedBy");
            _localizationService.DeletePluginLocaleResource("Plugins.Appointment.Scheduler.UpdatedOn");
            _localizationService.DeletePluginLocaleResource("Plugins.Appointment.Scheduler.UpdatedBy");
            _localizationService.DeletePluginLocaleResource("Plugins.Appointment.Scheduler.SaveButton");
            _localizationService.DeletePluginLocaleResource("Plugins.Appointment.Scheduler.CreateButton");
            _localizationService.DeletePluginLocaleResource("Plugins.Appointment.Scheduler.DeleteButton");
            _localizationService.DeletePluginLocaleResource("Plugins.Appointment.Scheduler.SearchButton");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Appointment.Scheduler.EditButton", "Editar");

            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Appointment.Scheduler.StartDate", "Data Início");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Appointment.Scheduler.EndDateDate", "Data Fim");

            //TODO: 

            base.Uninstall();
        }
    }
}
