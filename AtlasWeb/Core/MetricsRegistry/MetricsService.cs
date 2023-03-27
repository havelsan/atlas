using App.Metrics;
using App.Metrics.Timer;
using DevExpress.CodeParser.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTUtils;
using Infrastructure.Services;

namespace Core.MetricsRegistry
{
    public class MetricsService : IMetricsService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMetrics _metrics;

        public MetricsService(IHttpContextAccessor httpContextAccessor, IMetrics metrics)
        {
            _httpContextAccessor = httpContextAccessor;
            _metrics = metrics;
        }

        public void SendToPrometheus()
        {
            var traceIdentifier = _httpContextAccessor?.HttpContext?.TraceIdentifier;
            var accessCount = TTUtils.AtlasDbAccessTracerFactory.Instance?.GetAccessCount() ?? 0;
            var apiName = _httpContextAccessor?.HttpContext?.GetMetricsCurrentRouteName();

            var keys = new string[] { "TraceID", "AccessCount", "Api", "Date" };
            var values = new string[] { traceIdentifier.ToString(), accessCount.ToString(), apiName, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") };

            long accessCountLong = Convert.ToInt64(accessCount);
            _metrics.Measure.Counter.Increment(MetricsRegistry.ApiDbAccessCount, new MetricTags(keys, values), accessCountLong);
           
        }


             
    }
}
