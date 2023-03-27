using App.Metrics;
using App.Metrics.AspNetCore;
using App.Metrics.AspNetCore.Health;
using App.Metrics.Formatters.Prometheus;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using System;
using System.IO;
using System.Linq;

namespace Core
{
    public class Program
    {

        public static void Main(string[] args)
        {
            IWebHost webHost = null;

            try
            {
                TTUtils.Logger.Initialize("Atlas", false);
                Log.Information("ATLAS web host starting...");

                var metrics = AppMetrics.CreateDefaultBuilder()
                        .OutputMetrics.AsPrometheusPlainText()
                        .Build();

                webHost = new WebHostBuilder()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseKestrel(opt =>
                    {
                        opt.AddServerHeader = false;
                        opt.Limits.MaxRequestBufferSize = 10485676L * 10L;
                        opt.Limits.MaxRequestHeaderCount = 200;
                        opt.Limits.MaxResponseBufferSize = 65536L * 10L;
                    })
                    .UseIISIntegration()
                    .ConfigureMetrics(metrics)
                    .UseMetrics(options =>
                    {
                        options.EndpointOptions = endpointsOptions =>
                        {
                            endpointsOptions.MetricsTextEndpointOutputFormatter = metrics.OutputMetricsFormatters.OfType<MetricsPrometheusTextOutputFormatter>().First();
                        };
                    })
                    .UseHealth()
                    .UseStartup<Startup>()
                    .UseSerilog()
                    .Build();

                webHost.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                TTUtils.Logger.WriteError(ex.ToString());
            }
            finally
            {
                Log.CloseAndFlush();
                if (webHost != null)
                {
                    webHost.Dispose();
                }
            }
        }


    }
}
