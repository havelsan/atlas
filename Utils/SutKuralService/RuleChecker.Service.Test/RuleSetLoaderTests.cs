using Microsoft.Extensions.DependencyInjection;
using RuleChecker.Interface;
using Xunit;

namespace RuleChecker.Service.Test
{
    public class RuleSetLoaderTests : UnitTestBase
    {
        private readonly IRuleSetLoader _ruleSetLoader;

        public RuleSetLoaderTests()
        {
            _ruleSetLoader = ServiceProvider.GetRequiredService<IRuleSetLoader>();
        }

        [Fact]
        public void Test_RuleSet_Loader_Instance()
        {
            Assert.NotNull(_ruleSetLoader);
        }

        [Fact]
        public void Test_Load_Rules()
        {
            Assert.NotNull(_ruleSetLoader);
            var ruleSet = _ruleSetLoader.RuleSet;
            Assert.NotNull(ruleSet);
        }

    }
}
