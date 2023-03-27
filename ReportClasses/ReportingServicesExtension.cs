using DevExpress.AspNetCore;
using DevExpress.AspNetCore.Reporting;
using DevExpress.XtraReports.Web.ClientControls;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ReportClasses.ReportUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportClasses
{
    public static class ReportingServicesExtension
    {
        public static void ConfigureReportingServicesReporting(this IServiceCollection services)
        {

            services.ConfigureReportingServices(configurator => {

                configurator.ConfigureReportDesigner(designerConfigurator => {
                    designerConfigurator.RegisterDataSourceWizardConfigFileConnectionStringsProvider();
                });
                services.AddSingleton<ISecureDataConverter, AtlasSecureDataConverter>();

            });
        }

        public static IMvcBuilder AddDefaultReportingControllersReporting(this IMvcBuilder mvcBuilder)
        {
            return mvcBuilder.AddDefaultReportingControllers();
        }

        public static IServiceCollection AddDevExpressControlsReporting(this IServiceCollection services)
        {
            Action<ApplicationOptions> setupAction = settings => settings.Resources = ResourcesType.ThirdParty | ResourcesType.DevExtreme;
            return services.AddDevExpressControls(setupAction);
        }

        public static IApplicationBuilder UseDevExpressControls2(this IApplicationBuilder app)
        {
            return app.UseDevExpressControls();
        }


    }
}
