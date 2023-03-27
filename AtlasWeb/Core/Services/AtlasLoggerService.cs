using System;

namespace Core.Services
{
    public class AtlasLoggerService : TTUtils.ILogger
    {
        private readonly Serilog.ILogger _logger;

        public AtlasLoggerService(Serilog.ILogger logger)
        {
            _logger = logger;
        }

        public void WriteError(string message)
        {
            _logger.Error(message);
        }

        public void WriteException(Exception ex)
        {
            _logger.Error(ex.Message);
        }

        public void WriteException(string header, Exception ex)
        {
            _logger.Error(ex, header);
        }

        public void WriteInfo(string message)
        {
            _logger.Information(message);
        }

        public void WriteWarning(string message)
        {
            _logger.Warning(message);
        }
    }
}
