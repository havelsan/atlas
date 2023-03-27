using RuleChecker.Interface;
using TTConnectionManager;

namespace Core.Services
{
    public class RuleCheckerServiceSettings : IRuleCheckerServiceSettings
    {
        public string StoreConnectionString
        {
            get
            {
                var connectionString = DBProvider.GetProviderConnectionString(TTConnectionManager.ConnectionManager.ConnectionString, TTConnectionManager.ConnectionManager.ExtraConnectionProperties);
                return connectionString;
            }
        }
    }
}
