using App.Metrics;
using App.Metrics.Extensions.Configuration;
using AtlasDataModel;
using AtlasDataSource;
using Core.AtlasWebSocketManager;
using Core.Controllers;
using Core.MetricsRegistry;
using Core.Services;
using DashboardClasses;
using Hangfire;
using Hangfire.Oracle.Core;
using Infrastructure.Converters;
using Infrastructure.Filters;
using Infrastructure.Formatters;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Infrastructure.Services;
using Infrastructure.TokenProvider;
using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ObjectPool;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ReportClasses;
using RuleChecker.Engine;
using RuleChecker.Interface;
using RuleChecker.Service.Repositories;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TTStorageManager.Security;
using TTUtils;

namespace Core
{
    public class Startup
    {
        private readonly static CurrencyConverter CustomCurrencyConverter = new CurrencyConverter();
        private readonly static BigCurrencyConverter CustomBigCurrencyConverter = new BigCurrencyConverter();
        private readonly static JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings()
        {
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
            TypeNameHandling = TypeNameHandling.All,
            MetadataPropertyHandling = MetadataPropertyHandling.Default,
            Converters = new JsonConverter[] { CustomCurrencyConverter, CustomBigCurrencyConverter },
        };

        public Startup(ILoggerFactory loggerFactory, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true).AddEnvironmentVariables();

            Configuration = builder.Build();

            var logEventSink = new AtlasErrorlogTableSink(new AtlasErrorLogWriterService());
            var logFilePath = Path.Combine(env.WebRootPath, "log", "log-{Date}.txt");

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext()
                .WriteTo.RollingFile(logFilePath)
                .WriteTo.Sink(logEventSink, Serilog.Events.LogEventLevel.Error)
                .CreateLogger();

            LoggerFactory = loggerFactory;
            HostingEnvironment = env;

            var defaultDatabase = TTServerConfiguration.ServerConfiguration.DefaultDatabase;
            string databaseName = "ATLASDEV";
            if (defaultDatabase != null)
            {
                databaseName = defaultDatabase.DatabaseName;
            }

#if DEBUG
            string EMUserName = SettingsHelper.GetUserSetting(nameof(TTUtils.Entities.AtlasSettings.EMUserName), string.Empty);
            TTDefinitionManagement.TTCompiledAssembly.Initialize(databaseName, EMUserName);
#else
            TTDefinitionManagement.TTCompiledAssembly.Initialize(databaseName, string.Empty);
#endif

            PerfRuleEngineServiceFactory.SetRuleEngineInstance(new PerfRuleEngineService());

            AtlasDbContextFactory.SetFactoryInstance(AtlasContextFactory.Instance);
        }

        public IWebHostEnvironment HostingEnvironment
        {
            get;
        }


        public IConfigurationRoot Configuration
        {
            get;
        }

        public ILoggerFactory LoggerFactory
        {
            get;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                options.RequireHeaderSymmetry = false;
                options.ForwardLimit = 2;

            });

            services.AddDevExpressControlsReporting();

            services.ConfigureReportingServicesReporting();

            services.AddCors(options =>
            {

                options.AddPolicy("SetPreflightExpiration",
                builder =>
                {
                    builder.WithOrigins("http://localhost:8000").WithOrigins("http://localhost:7000")
                           .SetPreflightMaxAge(TimeSpan.FromSeconds(2520));
                });
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            // Add framework services.
            // services.AddApplicationInsightsTelemetry(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            //services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression();
            services.AddSingleton<DefinitionService>();
            services.AddSingleton<EditorTemplateService>();
            services.AddSingleton<IInfoMessageService, AtlasInfoMessageService>();
            services.AddSingleton<IActiveUserService, AtlasActiveUserService>();

            services.AddSingleton<IAtlasDbAccessTracer, AtlasDbAccessTracerService>();
            services.AddSingleton<IMetricsService, MetricsService>();

            services.AddSingleton<IInvoicePaymentService, Core.Services.InvoicePaymentService>();
            services.AddSingleton<IErrorLogWriterService, AtlasErrorLogWriterService>();
            services.AddSingleton<IServiceLogWriterService, AtlasServiceLogWriterService>();
            services.AddSingleton<ITokenStoreService, AtlasTokenStoreService>();
            services.AddSingleton<IAccountService, AtlasAccountService>();
            services.AddSingleton<ITokenValidatorService, AtlasTokenValidatorService>();
            services.AddSingleton<ListService>();
            services.AddSingleton<LookupService>();
            services.AddSingleton<ProcedureService>();
            services.AddSingleton<EpisodeService>();
            services.AddSingleton<ResourceService>();
            services.AddSingleton<ObjectMapperService>();
            services.AddSingleton<WebMethodCallerService>();
            services.AddSingleton<ILanguageService, AtlasLanguageService>();
            services.AddSingleton<TTUtils.ILogger>(new AtlasLoggerService(Log.Logger));
            services.AddSingleton<ICacheManager, AtlasCacheManager>();
            services.AddSingleton<IHtmlRendererService, HtmlRendererService>();


            // Needed for jwt auth.
            services
                .AddAuthentication(options =>
                {
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["JWTSettings:Issuer"],
                        ValidAudience = Configuration["JWTSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWTSettings:SecretKey"])),
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                    cfg.Events = new JwtBearerEvents
                    {

                        OnAuthenticationFailed = context =>
                        {
                            var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
                            logger.LogError("Authentication failed.", context.Exception);
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            var tokenValidatorService = context.HttpContext.RequestServices.GetRequiredService<ITokenValidatorService>();
                            return tokenValidatorService.ValidateAsync(context);
                        },
                        OnMessageReceived = context =>
                        {
                            return Task.CompletedTask;
                        },
                        OnChallenge = context =>
                        {
                            var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
                            logger.LogError("OnChallenge error", context.Error, context.ErrorDescription);
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddMemoryCache();

            var mvcBuilder = services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new MetricsResourceFilter(new MvcRouteTemplateResolver()));
                options.Conventions.Add(new ComplexTypeConvention());
                options.InputFormatters.RemoveType<SystemTextJsonInputFormatter>();
                var inputFormatter = new AtlasJsonInputFormatter(this.LoggerFactory.CreateLogger<AtlasJsonInputFormatter>(), JsonSerializerSettings, options);
                options.InputFormatters.Add(inputFormatter);

                options.ModelMetadataDetailsProviders.Add(new SuppressChildValidationMetadataProvider(typeof(Object)));

                // Authorization kapalı
                // Angular Http servisi kullanıldığı için JWT http headere eklenemiyor
                // Tüm http çağrıları NeHttpService ile değiştirilecek
                // HTTP Request Interceptor Angular 4.3.0 ile gelecek

                var policy = new AuthorizationPolicyBuilder()
                 .RequireAuthenticatedUser()
                 .Build();
                options.Filters.Add(new AtlasAuthorizeFilter(policy));


            }).AddNewtonsoftJson(opt =>
            {
                EventHandler<Newtonsoft.Json.Serialization.ErrorEventArgs> errorHandler = (sender, eventArgs) =>
                {
                    var exception = eventArgs.ErrorContext.Error;
                    var formattedError = $"JsonInputException: {eventArgs.ErrorContext.Error.ToString()}";
                    Log.Error(formattedError);
                    eventArgs.ErrorContext.Handled = false;
                };

                opt.SerializerSettings.Error = errorHandler;
                var resolver = opt.SerializerSettings.ContractResolver;
                if (resolver != null)
                {
                    if (resolver is DefaultContractResolver res)
                    {
                        res.NamingStrategy = null;
                    }
                }
            })
            .AddDefaultReportingControllersReporting()
            .AddDefaultDashboardControllerDashboard()
            .AddApplicationPart(Assembly.Load(new AssemblyName("AtlasDataSource")))
            .AddApplicationPart(Assembly.Load(new AssemblyName("ReportClasses")))
            .AddApplicationPart(Assembly.Load(new AssemblyName("DashboardClasses")))
            .AddApplicationPart(Assembly.Load(new AssemblyName("DynamicForms")))
            .AddApplicationPart(Assembly.Load(new AssemblyName("HealthInsurance")))
            ;

            //mvcBuilder.AddMvcOptions(o => o.Conventions.Add(new GenericControllerRouteConvention()));
            mvcBuilder.ConfigureApplicationPartManager(c =>
            {
                c.FeatureProviders.Add(new GenericTypeControllerFeatureProvider());
            });
            var metrics = new MetricsBuilder()
                 .Configuration.ReadFrom(Configuration)
                 .OutputMetrics.AsPrometheusPlainText()
                 .Build();

            services.AddMetrics(metrics);
            services.AddAtlasODataExtensions();
            services.AddMvcCore(opts => opts.Filters.Add(new MetricsResourceFilter(new MvcRouteTemplateResolver())));
            services.Configure<JWTSettings>(Configuration.GetSection("JWTSettings"));
            services.Configure<AtlasSettings>(Configuration.GetSection("AtlasSettings"));

            ConfigureRuleEngineServices(services);

            DependencyResolver.Current.Services = services;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var infoMessageService = serviceProvider.GetRequiredService<IInfoMessageService>();
                InfoMessageService.SetServiceInstance(infoMessageService);

                var activeUserService = serviceProvider.GetRequiredService<IActiveUserService>();
                ActiveUserService.SetActiveUserServiceInstance(activeUserService);


                var dbAccessTracer = serviceProvider.GetRequiredService<IAtlasDbAccessTracer>();
                AtlasDbAccessTracerFactory.SetInstance(dbAccessTracer);

                var metricsService = serviceProvider.GetRequiredService<IMetricsService>();
                MetricsFactory.SetInstance(metricsService);

                var languageService = serviceProvider.GetRequiredService<ILanguageService>();
                ActiveUserService.SetLanguageServiceInstance(languageService);

                SutRuleServiceFactory.SetServiceInstance(new SutRuleEngineRestCallerService());
                var cacheManager = serviceProvider.GetRequiredService<ICacheManager>();
                CacheManager.SetManagerInstance(cacheManager);

                HL7EngineManagerFactory.SetManagerInstance(new HL7EngineService());

                SutRuleServiceFactory.SetServiceInstance(serviceProvider.GetService<IRuleCheckEngine>());

                var htmlRendererService = serviceProvider.GetRequiredService<IHtmlRendererService>();
                HtmlRendererServiceFactory.SetServiceInstance(htmlRendererService);
                services.AddSignalR()
                        .AddNewtonsoftJsonProtocol(options =>
                        {
                            // TODO: newtonsoft json serializer nesne ve özellik isimlerine müdahale etmiyordu aşağıdaki ayar ile
                            options.PayloadSerializerSettings.ContractResolver = new DefaultContractResolver();
                        });

            }
        }

        private void ConfigureRuleEngineServices(IServiceCollection services)
        {
            var serviceHostSettings = new RuleCheckerServiceSettings();
            services.AddSingleton<IRuleCheckerServiceSettings>(serviceHostSettings);

            services.AddSingleton<IBranchRepository, OracleBranchRepository>();
            services.AddSingleton<IEpisodeRepository, OracleEpisodeRepository>();
            services.AddSingleton<IIcd10Repository, OracleIcd10Repository>();
            services.AddSingleton<IPatientRepository, OraclePatientRepository>();
            services.AddSingleton<IProcedureRepository, OracleProcedureRepository>();
            services.AddSingleton<IPatientProcedureRepository, OraclePatientProcedureRepository>();
            services.AddSingleton<IInvoicePatientProcedureRepository, OracleInvoicePatientProcedureRepository>();
            services.AddSingleton<IRuleRepository, OracleRuleRepository>();
            services.AddSingleton<IRuleSetLoader, RuleSetLoader>();
            services.AddSingleton<IRuleCheckEngine, RuleCheckEngine>();
        }

        private void SetupStaticFolder(IApplicationBuilder app, string physicalFolder, string uri)
        {
            if (Directory.Exists(physicalFolder))
            {
                app.UseStaticFiles(new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(physicalFolder),
                    RequestPath = new PathString(uri)
                });
            }
        }

        private void ConfigureWebPackBundle(IApplicationBuilder app, string currentFolder)
        {
            var bundlesFolder = Path.Combine(currentFolder, "wwwroot", "dist", "bundles");
            SetupStaticFolder(app, bundlesFolder, "/bundles");
            var assetsFolder = Path.Combine(currentFolder, "wwwroot", "dist", "assets");
            SetupStaticFolder(app, assetsFolder, "/assets");
            var i18nFolder = Path.Combine(currentFolder, "wwwroot", "dist", "i18n");
            SetupStaticFolder(app, i18nFolder, "/i18n");
        }

        private void ConfigureStaticFileFoldersForDevelopment(IApplicationBuilder app)
        {
            var currentFolder = Directory.GetCurrentDirectory();
            var rootFolder = Path.GetDirectoryName(currentFolder);
            var nodeModulesFolder = Path.Combine(currentFolder, @"node_modules");
            var appFolder = Path.Combine(rootFolder, "dist", "wwwroot", "app");
            var modulesFolder = Path.Combine(rootFolder, "dist", "Modules");

            SetupStaticFolder(app, nodeModulesFolder, "/node_modules");
            SetupStaticFolder(app, currentFolder, "/core");
            SetupStaticFolder(app, appFolder, "/app");
            SetupStaticFolder(app, modulesFolder, "/modules");

            ConfigureWebPackBundle(app, currentFolder);
        }

        private void ConfigureStaticFileFoldersForRuntime(IApplicationBuilder app)
        {
            var currentFolder = Directory.GetCurrentDirectory();
            Console.WriteLine($"ConfigureStaticFileFoldersForRuntime for folder: {currentFolder}");

            bool webPackDeployment = false;
            if (webPackDeployment)
            {
                Console.WriteLine($"{currentFolder} :  Webpack deployment active");

                var bundlesFolder = Path.Combine(currentFolder, "bundles");
                SetupStaticFolder(app, bundlesFolder, "/bundles");
                var assetsFolder = Path.Combine(currentFolder, "assets");
                SetupStaticFolder(app, assetsFolder, "/assets");
                var i18nFolder = Path.Combine(currentFolder, "i18n");
                SetupStaticFolder(app, i18nFolder, "/i18n");
            }
            else
            {
                var nodeModulesFolder = Path.Combine(currentFolder, @"node_modules");
                var appFolder = Path.Combine(currentFolder, "app");
                var modulesFolder = Path.Combine(currentFolder, "Modules");
                var sourcesFolder = Path.Combine(currentFolder, "Core");

                SetupStaticFolder(app, nodeModulesFolder, "/node_modules");
                SetupStaticFolder(app, appFolder, "/app");
                SetupStaticFolder(app, modulesFolder, "/modules");
                SetupStaticFolder(app, sourcesFolder, "/core");
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app
            , IWebHostEnvironment env
            , ILoggerFactory loggerFactory
            , IHostApplicationLifetime appLifetime
            , IHubContext<AtlasHub> hubContext)
        {
            loggerFactory.AddSerilog();
            _ = appLifetime.ApplicationStopped.Register(Log.CloseAndFlush);

            app.UseMetricsAllMiddleware();

            app.UseResponseCompression();

            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            DependencyResolver.Current.SetHttpContextAccessor(httpContextAccessor);

            // TODO: production için bu kod kontrol edilecek
            if (env.IsDevelopment())
            {
                //app.UseMiddleware<StackifyMiddleware.RequestTracerMiddleware>();

                app.UseCors(options => options.WithOrigins("http://localhost:8000").WithOrigins("http://localhost:7000")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .SetPreflightMaxAge(TimeSpan.FromSeconds(2520)));
            }

            app.UseAuthentication();
            // ConfigureAuth(app);
            app.UseDevExpressControls2();
            //app.UseMiddleware<SerilogMiddleware>();

            // Set up custom content types - associating file extension to MIME type
            var provider = new FileExtensionContentTypeProvider();
            // Add new mappings
            provider.Mappings[".xlf"] = "application/x-xliff+xml";

            if (env.IsDevelopment() || TTServerConfiguration.ServerConfiguration.DevelopmentServerName?.ToUpperInvariant() == "INTERNET-PC1863")
            {

                app.Use(async (context, next) =>
                {
                    await next();
                    if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                    {
                        context.Request.Path = "/index.html";
                        await next();
                    }
                });

                app.UseRouting();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "api/{controller=Account}/{action=Authenticate}/{id?}"
                        );
                    endpoints.MapDefaultControllerRoute();

                    // EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "api/dashboards");
                    endpoints.Expand().Select().Count().OrderBy().Filter().MaxTop(null).SkipToken();
                    endpoints.MapODataRoute(routeName: "odata", routePrefix: "odata", model: AtlasDataSourceExtensions.RegisterEntities());
                    endpoints.EnableDependencyInjection();

                    endpoints.MapHub<AtlasHub>("/AtlasHub");

                });

                app.UseDefaultFiles(new DefaultFilesOptions { DefaultFileNames = new List<string> { "index.html" } });
                app.UseStaticFiles(new StaticFileOptions
                {
                    ContentTypeProvider = provider,
                });
                ConfigureStaticFileFoldersForDevelopment(app);

            }
            else
            {
                app.Use(async (context, next) =>
                {
                    await next();
                    if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                    {
                        context.Request.Path = "/index.html";
                        await next();
                    }
                });

                app.UseRouting();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "api/{controller=Account}/{action=Authenticate}/{id?}"
                        );
                    endpoints.MapDefaultControllerRoute();
                    // EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "api/dashboards");
                    endpoints.Expand().Select().Count().OrderBy().Filter().MaxTop(null).SkipToken();
                    endpoints.MapODataRoute(routeName: "odata", routePrefix: "odata", model: AtlasDataSourceExtensions.RegisterEntities());
                    endpoints.EnableDependencyInjection();

                    endpoints.MapHub<AtlasHub>("/AtlasHub");

                });


                var contentRootPath = Path.Combine(env.WebRootPath, "dist");
                app.UseDefaultFiles(new DefaultFilesOptions { DefaultFileNames = new List<string> { "index.html" } });
                app.UseStaticFiles(new StaticFileOptions()
                {
                    ServeUnknownFileTypes = false,
                    FileProvider = new PhysicalFileProvider(env.WebRootPath),
                });
                SetupStaticFolder(app, Path.Combine(contentRootPath, "bundles"), "/bundles");
            }

            var hubContainer = new AtlasHubContainer(hubContext);
            AtlasSignalRHubFactory.SetAtlasHubContainerInstance(hubContainer);

            Log.Information($"Atlas Server Configure Completed");
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
        }

        private void ConfigureAuth(IApplicationBuilder app)
        {
            var secretKey = Configuration.GetSection("JWTSettings:SecretKey").Value;
            var issuer = Configuration.GetSection("JWTSettings:Issuer").Value;
            var audience = Configuration.GetSection("JWTSettings:Audience").Value;
            var expireTimeSpanString = Configuration.GetSection("JWTSettings:Expiration").Value;
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            var jwtSettings = new JWTSettings()
            {
                Audience = audience,
                Issuer = issuer,
                SecretKey = secretKey,
                Expiration = TimeSpan.FromMinutes(30),
            };

            if (TimeSpan.TryParse(expireTimeSpanString, out TimeSpan expireTimeSpan))
            {
                jwtSettings.Expiration = expireTimeSpan;
            }

            app.UseSimpleTokenProvider(new TokenProviderOptions
            {
                Path = "/api/authenticate",
                Audience = audience,
                Issuer = issuer,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                IdentityResolver = (username, password) => GetIdentity(username, password),
                Expiration = jwtSettings.Expiration,
            });

        }

        private Task<ClaimsIdentity> GetIdentity(string userName, string password)
        {
            var result = TTUser.CheckAuthenticate(userName, password);
            if (result.Item1 == AuthenticationResultEnum.PasswordOK)
            {
                var user = result.Item2;
                var atlasUser = new AtlasUser(new GenericIdentity(user.UserID.ToString(), "Custom"), new Claim[] { });
                return Task.FromResult(atlasUser as ClaimsIdentity);
            }

            // Credentials are invalid, or account doesn't exist
            return Task.FromResult<ClaimsIdentity>(null);
        }
    }

}