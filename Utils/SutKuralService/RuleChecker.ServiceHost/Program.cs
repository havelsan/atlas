
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RuleChecker.ServiceHost.Helpers;
using RuleChecker.ServiceHost.Models;
using Serilog;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace RuleChecker.ServiceHost
{
    partial class Program
    {

        public static void Main(string[] args)
        {
            bool isService = true;
            if (System.Diagnostics.Debugger.IsAttached || args.Contains("--console"))
            {
                isService = false;
            }

            var pathToContentRoot = Directory.GetCurrentDirectory();
            if (isService)
            {
                var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                pathToContentRoot = Path.GetDirectoryName(pathToExe);
            }

            var builder = new ConfigurationBuilder()
            .SetBasePath(pathToContentRoot)
            .AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();
            var ruleCheckerServiceSettings = configuration.GetSection(nameof(AtlasRuleCheckerServiceSettings));
            var servicePort = ruleCheckerServiceSettings.GetSettingsAsInteger(nameof(AtlasRuleCheckerServiceSettings.ServicePort), 5400);
            var serviceUrl = $"http://*:{servicePort}";

            var loggerConfig = new LoggerConfiguration()
                        .ReadFrom.Configuration(configuration)
                        .Enrich.FromLogContext();

            if (isService == false)
            {
                loggerConfig.WriteTo.Console();
            }
            else
            {
                loggerConfig.WriteTo.RollingFile(Path.Combine(pathToContentRoot, "log-{Date}.txt"));
            }


            Log.Logger = loggerConfig.CreateLogger();

            Log.Information("Starting web host for Atlas RuleChecker Service");

            try
            {
                var host = WebHost.CreateDefaultBuilder(args)
                    .UseContentRoot(pathToContentRoot)
                    .ConfigureServices((hostContext, services) =>
                    {
                        services.AddSingleton<ILogger>(Log.Logger);
                    })
                    .UseStartup<Startup>()
                    .UseUrls(serviceUrl)
                    .ConfigureLogging((hostContext, loggingBuilder) =>
                    {
                        loggingBuilder.AddSerilog(
                            loggingBuilder.Services.BuildServiceProvider().GetRequiredService<ILogger>(),
                            dispose: true);
                    })
                    .Build();

                if (isService)
                {
                    host.RunAsCustomService(Log.Logger);
                }
                else
                {
                    host.Run();
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Atlas RuleChecker service host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

    }
}
