using Microsoft.Extensions.DependencyInjection;
using RuleChecker.Interface;
using System;
using Xunit;

namespace RuleChecker.Service.Test
{
    public class OracleIcd10RepositoryTests : UnitTestBase
    {
        private readonly IIcd10Repository _icd10Repository;

        public OracleIcd10RepositoryTests()
        {
            _icd10Repository = ServiceProvider.GetRequiredService<IIcd10Repository>();
        }


        [Fact]
        public void Test_Oracle_ICD10_Repository_Instance()
        {
            Assert.NotNull(_icd10Repository);
        }

        [Fact]
        public void Test_Get_Icd10_List()
        {
            Assert.NotNull(_icd10Repository);

            var icd10List = _icd10Repository.Icd10List();
            Assert.NotNull(icd10List);

        }
    }
}
