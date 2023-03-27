using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Serilog;

namespace RuleChecker.ServiceHost
{
    internal class AtlasRuleCheckerWebHostService : WebHostService
    {
        private readonly ILogger _logger;
        private readonly IWebHost _webHost;

        public AtlasRuleCheckerWebHostService(IWebHost webHost, ILogger logger) : base(webHost)
        {
            _logger = logger;
            _webHost = webHost;
            this.ServiceName = "AtlasRuleCheckerService";
        }

        protected override void OnStarting(string[] args)
        {
            _logger.Information("Atlas RuleChecker service starting...");
            base.OnStarting(args);
        }

        protected override void OnStarted()
        {
            base.OnStarted();
            _logger.Information("Atlas RuleChecker service successfully started.");
        }

        protected override void OnStopping()
        {
            _logger.Information("Atlas RuleChecker service stopping....");
            base.OnStopping();
        }

        protected override void OnStopped()
        {
            base.OnStopped();
            _logger.Information("Atlas RuleChecker service stopped.");
        }
    }
}
