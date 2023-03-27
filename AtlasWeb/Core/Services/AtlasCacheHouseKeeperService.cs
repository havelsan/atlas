using Infrastructure.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace Core.Services
{
    public class AtlasCacheHouseKeeperService : AtlasBackgroundService
    {
        private readonly ILogger<AtlasCacheHouseKeeperService> _logger;

        public AtlasCacheHouseKeeperService(ILogger<AtlasCacheHouseKeeperService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug($"GracePeriodManagerService is starting.");

            stoppingToken.Register(() =>
                    _logger.LogDebug($" GracePeriod background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug($"GracePeriod task doing background work.");

              //  TTFlatDataSet.ClearExpiredCacheItems();

                await Task.Delay(300000, stoppingToken);
            }

            _logger.LogDebug($"GracePeriod background task is stopping.");
        }

        public override Task StopAsync(CancellationToken stoppingToken)
        {
            // Run your graceful clean-up actions
            return Task.CompletedTask;
        }
    }
}
