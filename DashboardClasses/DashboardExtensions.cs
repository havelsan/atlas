using DashboardClasses.Modules.Core_Destek_Modulleri.Dinamik_Rapor_Modulu;
using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardWeb;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardClasses
{
    public static class DashboardExtensions
    {
        static AtlasDashboardStorage dashboardStorage = new AtlasDashboardStorage();
        public static IMvcBuilder AddDefaultDashboardControllerDashboard(this IMvcBuilder mvcBuilder)
        {

            Action<DashboardConfigurator> configure = (configurator) =>
           {
               configurator.SetDashboardStorage(dashboardStorage);
               configurator.SetDataSourceStorage(new AtlasDataSourceStorage());

           };

            return mvcBuilder.AddDefaultDashboardController(configure);
        }

        public static void MapDashboardRoute2(this IRouteBuilder routeBuilder, string path)
        {
            routeBuilder.MapDashboardRoute(path);
        }
    }
}
