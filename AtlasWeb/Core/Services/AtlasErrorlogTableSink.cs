using Infrastructure.Constants;
using Infrastructure.Services;
using Serilog.Core;
using Serilog.Events;
using System;

namespace Core.Services
{
    public class AtlasErrorlogTableSink : ILogEventSink
    {
        private readonly IErrorLogWriterService _errorLogWriterService;
        private readonly IFormatProvider _formatProvider;

        public AtlasErrorlogTableSink(IErrorLogWriterService errorLogWriterService, IFormatProvider formatProvider = null)
        {
            _formatProvider = formatProvider;
            _errorLogWriterService = errorLogWriterService;
        }

        public void Emit(LogEvent logEvent)
        {
            if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));

            var formattedLog = logEvent.RenderMessage(_formatProvider);
            var userIDKey = string.Empty;
            if (logEvent.Properties.TryGetValue(PropertyNames.UserID, out LogEventPropertyValue userIdPropertyValue))
            {
                userIDKey = userIdPropertyValue.ToString().Trim('\"');
            }
            var remoteIpAddress = string.Empty;
            if (logEvent.Properties.TryGetValue(PropertyNames.RemoteIpAddress, out LogEventPropertyValue ipAddressPropertyValue))
            {
                remoteIpAddress = ipAddressPropertyValue.ToString().Trim('\"');
            }

            _errorLogWriterService.WriteErrorLog(userIDKey, remoteIpAddress, formattedLog);
        }
    }
}
