using RuleChecker.Interface;
using System;

namespace RuleChecker.ServiceHost
{
    public class ServiceHostSettings : IRuleCheckerServiceSettings
    {
        public string StoreConnectionString { get; set; }
    }
}
