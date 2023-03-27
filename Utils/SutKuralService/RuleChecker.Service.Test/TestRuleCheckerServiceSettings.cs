using RuleChecker.Interface;

namespace RuleChecker.Service.Test
{
    public class TestRuleCheckerServiceSettings : IRuleCheckerServiceSettings
    {
        public string StoreConnectionString
        {
            get
            {
                return "Data Source=X.X.X.X:1521/atlas.atlas.net;user id=ATLASDEV;password=test";
            }
        }
    }
}
