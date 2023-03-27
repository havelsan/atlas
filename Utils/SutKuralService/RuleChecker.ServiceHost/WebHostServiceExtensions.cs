using Microsoft.AspNetCore.Hosting;
using Serilog;
using System.ServiceProcess;

namespace RuleChecker.ServiceHost
{
    public static class WebHostServiceExtensions
    {
        public static void RunAsCustomService(this IWebHost host, ILogger logger)
        {
            var webHostService = new AtlasRuleCheckerWebHostService(host, logger);
            ServiceBase.Run(webHostService);
        }
    }
}
