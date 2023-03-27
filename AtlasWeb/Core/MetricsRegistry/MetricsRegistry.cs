using App.Metrics;
using App.Metrics.Counter;
using App.Metrics.Meter;
using App.Metrics.Timer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.MetricsRegistry
{
    public class MetricsRegistry
    {
        public static CounterOptions ApiDbAccessCount => new CounterOptions
        {
            Name = "AtlasApiDbAccessCount",
            MeasurementUnit = Unit.Calls
        };

       
    }


}
