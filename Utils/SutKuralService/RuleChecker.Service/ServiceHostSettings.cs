using RuleChecker.Interface;

namespace RuleChecker.Service
{
    public class ServiceHostSettings : IRuleCheckerServiceSettings
    {
        public string StoreConnectionString { get; set; }
    }
}
