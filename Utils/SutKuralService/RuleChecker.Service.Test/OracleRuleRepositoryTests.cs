using Microsoft.Extensions.DependencyInjection;
using RuleChecker.Interface;
using System;
using Xunit;

namespace RuleChecker.Service.Test
{
    public class OracleRuleRepositoryTests : UnitTestBase
    {
        private readonly IRuleRepository _ruleRepository;

        public OracleRuleRepositoryTests()
        {
            _ruleRepository = ServiceProvider.GetRequiredService<IRuleRepository>();
        }

        [Fact]
        public void Test_Oracle_Rule_Repository_Instance()
        {
            Assert.NotNull(_ruleRepository);
        }

        [Fact]
        public void Test_Get_Rule_List()
        {
            Assert.NotNull(_ruleRepository);
            var ruleList = _ruleRepository.RuleList();
            Assert.NotNull(ruleList);
        }

        [Fact]
        public void Test_Rule_Group_List()
        {
            Assert.NotNull(_ruleRepository);
            var ruleGroupList = _ruleRepository.RuleGroupList();
            Assert.NotNull(ruleGroupList);
        }

    }
}
