using Microsoft.Extensions.DependencyInjection;
using RuleChecker.Interface;
using RuleChecker.Service.Repositories;
using System;

namespace RuleChecker.Service.Test
{
    public class UnitTestBase : IDisposable
    {
        private bool disposed = false;
        private ServiceProvider _serviceProvider;

        public IServiceProvider ServiceProvider
        {
            get
            {
                if (_serviceProvider == null)
                    _serviceProvider = BuildServiceProvider();
                return _serviceProvider;
            }
        }

        private ServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();
            var serviceHostSettings = new TestRuleCheckerServiceSettings();
            services.AddSingleton<IRuleCheckerServiceSettings>(serviceHostSettings);

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

            return services.BuildServiceProvider();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                _serviceProvider.Dispose();
            }

            disposed = true;
        }

    }
}
