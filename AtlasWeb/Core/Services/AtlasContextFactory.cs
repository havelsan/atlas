using AtlasDataModel;
using Microsoft.EntityFrameworkCore;
using TTConnectionManager;

namespace Core.Services
{
    public sealed class AtlasContextFactory : IAtlasDbContextFactory
    {
        private AtlasContextFactory()
        {
        }

        private static DbContextOptions<AtlasContext> GetContextOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AtlasContext>();
            var connectionString = DBProvider.GetProviderConnectionString(TTConnectionManager.ConnectionManager.ConnectionString, TTConnectionManager.ConnectionManager.ExtraConnectionProperties);
            optionsBuilder.UseLazyLoadingProxies().UseOracle(connectionString, opt => opt.UseOracleSQLCompatibility("11"));
            return optionsBuilder.Options;
        }

        public AtlasContext CreateContext()
        {
            return new AtlasContext(GetContextOptions());
        }

        public AtlasContext CreateDbContext()
        {
            return new AtlasContext(GetContextOptions());
        }

        public static AtlasContextFactory Instance { get { return Nested.instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly AtlasContextFactory instance = new AtlasContextFactory();
        }
    }
}
