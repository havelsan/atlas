using Microsoft.Extensions.DependencyInjection;
using RuleChecker.Interface;
using System;
using System.Linq;
using Xunit;

namespace RuleChecker.Service.Test
{

    public class OracleBranchRepositoryTests : UnitTestBase
    {

        private readonly IBranchRepository _branchRepository;

        public OracleBranchRepositoryTests()
        {
            _branchRepository = ServiceProvider.GetRequiredService<IBranchRepository>();
        }


        [Fact]
        public void Test_Oracle_Branch_Repository_Instance()
        {
            Assert.NotNull(_branchRepository);
        }

        [Fact]
        public void Test_Get_Branch_Info()
        {
            Assert.NotNull(_branchRepository);
            const string testBranchCode = "1000";
            var info = _branchRepository.BranchInfo(testBranchCode);
            Assert.NotNull(info);
            Assert.Equal(testBranchCode, info.Code);
        }

        [Fact]
        public void Test_Get_Branch_List()
        {
            Assert.NotNull(_branchRepository);
            var testBranchCodes = new[] { "1000", "2000" };
            var result = _branchRepository.BranchList(testBranchCodes);
            Assert.NotNull(result);
            Assert.Equal(testBranchCodes, result.Select(i => i.Code).OrderBy(x=>x));
        }
    }
}
