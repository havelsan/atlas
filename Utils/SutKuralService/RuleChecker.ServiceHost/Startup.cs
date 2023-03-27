using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using RuleChecker.Interface;
using RuleChecker.Service;
using RuleChecker.Service.Repositories;
using RuleChecker.ServiceHost.Middlewares;
using RuleChecker.ServiceHost.Models;
using System;
using System.Text;

namespace RuleChecker.ServiceHost
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy(JwtBearerDefaults.AuthenticationScheme‌​, new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            var jwtSettings = Configuration.GetSection(nameof(JWTSettings));
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings[RuleCheckerConstants.SecretKey]));
            var jwtIssuer = jwtSettings[nameof(JWTSettings.Issuer)];
            var jwtAudience = jwtSettings[nameof(JWTSettings.Audience)];
            var clockSkew = jwtSettings[nameof(JWTSettings.ClockSkew)];

            TimeSpan clockSkewTimeSpan = TimeSpan.FromSeconds(RuleCheckerConstants.DefaultClockSkew);
            TimeSpan.TryParse(clockSkew, out clockSkewTimeSpan);

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
                        ValidIssuer = jwtIssuer,
                        ValidAudience = jwtAudience,
                        IssuerSigningKey = signingKey,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ClockSkew = clockSkewTimeSpan,
                    };
                });

            ConfigureRuleEngineServices(services);

            // Add framework services.
            services.AddMvc();

        }

        private void ConfigureRuleEngineServices(IServiceCollection services)
        {

            services.Configure<IRuleCheckerServiceSettings>(Configuration.GetSection("ConnectionStrings"));


            services.AddSingleton<IBranchRepository, OracleBranchRepository>();
            services.AddSingleton<IEpisodeRepository, OracleEpisodeRepository>();
            services.AddSingleton<IIcd10Repository, OracleIcd10Repository>();
            services.AddSingleton<IPatientRepository, OraclePatientRepository>();
            services.AddSingleton<IProcedureRepository, OracleProcedureRepository>();
            services.AddSingleton<IPatientProcedureRepository, OraclePatientProcedureRepository>();
            services.AddSingleton<IInvoicePatientProcedureRepository, OracleInvoicePatientProcedureRepository>();
            
            services.AddSingleton<IRuleRepository, OracleRuleRepository>();
            services.AddSingleton<IRuleSetLoader, Engine.RuleSetLoader>();
            services.AddSingleton<TTUtils.IRuleCheckEngine, Engine.RuleCheckEngine>();          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseMiddleware(typeof(ServiceHostErrorHandlingMiddleware));

            app.UseCors(
                         options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials()
                         );

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
