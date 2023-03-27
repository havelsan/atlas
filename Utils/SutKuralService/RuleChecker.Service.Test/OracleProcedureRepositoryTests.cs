using Microsoft.Extensions.DependencyInjection;
using RuleChecker.Interface;
using System.Linq;
using Xunit;

namespace RuleChecker.Service.Test
{
    public class OracleProcedureRepositoryTests : UnitTestBase
    {
        private readonly IProcedureRepository _procedureRepository;

        public OracleProcedureRepositoryTests()
        {
            _procedureRepository = ServiceProvider.GetRequiredService<IProcedureRepository>();
        }

        [Fact]
        public void Test_Oracle_Procedure_Repository_Instance()
        {
            Assert.NotNull(_procedureRepository);
        }

        [Fact]
        public void Test_Get_Procedure_List()
        {
            Assert.NotNull(_procedureRepository);
            var testProcedureCodes = new[] { "900690" };
            var result = _procedureRepository.ProcedureList(testProcedureCodes);
            Assert.NotNull(result);
            //SUT kodları hizmet çoğaltılmasından dolayı birden fazla gelebildiği için Distinct eklendi.
            Assert.Equal(testProcedureCodes, result.Select(p => p.SutCode).Distinct());
        }

    }
}
