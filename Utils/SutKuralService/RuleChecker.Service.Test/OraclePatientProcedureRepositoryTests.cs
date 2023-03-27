using Microsoft.Extensions.DependencyInjection;
using RuleChecker.Interface;
using Xunit;

namespace RuleChecker.Service.Test
{
    public class OraclePatientProcedureRepositoryTests : UnitTestBase
    {
        private readonly IPatientProcedureRepository _patientProcedureRepository;

        public OraclePatientProcedureRepositoryTests()
        {
            _patientProcedureRepository = ServiceProvider.GetRequiredService<IPatientProcedureRepository>();
        }

        [Fact]
        public void Test_Oracle_Patient_Procedure_Repositories_Instance()
        {
            Assert.NotNull(_patientProcedureRepository);
        }

        [Fact]
        public void Test_Oracle_Patient_Procedure_Repository_Instance()
        {
            Assert.NotNull(_patientProcedureRepository);
        }

        [Fact]
        public void Test_Lazy_Oracle_Patient_Procedure_Repositories_Instance()
        {
            Assert.NotNull(_patientProcedureRepository);
        }

        [Fact]
        public void Test_Lazy_Oracle_Patient_Procedure_Repository_Instance()
        {
            Assert.NotNull(_patientProcedureRepository);
        }

        [Fact]
        public void Test_Episode_Procedure_List()
        {
            Assert.NotNull(_patientProcedureRepository);

            var testEpisodeId = "29829974-ab58-4dbf-bbc6-c2982c54c650";
            var procedureList = _patientProcedureRepository.EpisodeProcedureList(testEpisodeId);
            Assert.NotNull(procedureList);
        }

        [Fact]
        public void Test_Episode_Procedure_List_With_Specific_Procedure()
        {
            Assert.NotNull(_patientProcedureRepository);

            var testEpisodeId = "29829974-ab58-4dbf-bbc6-c2982c54c650";
            var testProcedureCode = "520030";
            var procedureList = _patientProcedureRepository.EpisodeProcedureList(testEpisodeId, testProcedureCode);
            Assert.NotNull(procedureList);
        }


        [Fact]
        public void Test_Patient_Procedure_List_With_Specific_Procedure()
        {
            Assert.NotNull(_patientProcedureRepository);

            var testPatientId = "20743b9a-cda3-4c0a-8990-fa829b5ffa9f";
            var testProcedureCode = "520030";
            var procedureList = _patientProcedureRepository.PatientProcedureList(testPatientId, testProcedureCode);
            Assert.NotNull(procedureList);
        }

    }
}
