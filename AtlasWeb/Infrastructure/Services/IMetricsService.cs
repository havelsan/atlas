using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{
    public interface IMetricsService
    {
        void SendToPrometheus();
    }

    public class MetricsFactory
    {
        public static IMetricsService _metricsService;

        public static void SetInstance(IMetricsService metricsService)
        {
            _metricsService = metricsService;
        }

        public static IMetricsService Instance
        {
            get
            {
                return _metricsService;
            }
        }
    }
}
