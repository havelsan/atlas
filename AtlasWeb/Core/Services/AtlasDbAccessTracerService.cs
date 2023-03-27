using App.Metrics;
using App.Metrics.Counter;
using Microsoft.AspNetCore.Http;
using System.Collections.Concurrent;
using System.Threading;
using TTUtils;

namespace Core.Services
{
    public class DbAccessInfo
    {
        private int _accessCount = 0;

        public int AccessCount
        {
            get
            {
                return _accessCount;
            }
        }

        public DbAccessInfo()
        {
            _accessCount = 1;
        }

        public void IncrementAccessCount()
        {
            Interlocked.Increment(ref _accessCount);
        }
    }

    public class AtlasDbAccessTracerService : IAtlasDbAccessTracer
    {
        private readonly ConcurrentDictionary<string, DbAccessInfo> _traces = new ConcurrentDictionary<string, DbAccessInfo>();
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AtlasDbAccessTracerService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void AddAccessCount()
        {
            var traceIdentifier = _httpContextAccessor?.HttpContext?.TraceIdentifier;
            if (string.IsNullOrWhiteSpace(traceIdentifier) == false)
            {
                if (_traces.TryGetValue(traceIdentifier, out DbAccessInfo accessInfo))
                {
                    accessInfo.IncrementAccessCount();
                }
                else
                {
                    var dbAccessInfo = new DbAccessInfo();
                    _traces.TryAdd(traceIdentifier, dbAccessInfo);
                }
            }
        }

        public int GetAccessCount()
        {
            var traceIdentifier = _httpContextAccessor?.HttpContext?.TraceIdentifier;
            if (string.IsNullOrWhiteSpace(traceIdentifier) == false)
            {
                if (_traces.TryGetValue(traceIdentifier, out DbAccessInfo accessInfo))
                {
                    return accessInfo.AccessCount;
                }
            }
            return 0;
        }
    }
}
