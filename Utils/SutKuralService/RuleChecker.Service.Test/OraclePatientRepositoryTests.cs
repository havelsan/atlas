using Microsoft.Extensions.DependencyInjection;
using RuleChecker.Interface;
using System;
using Xunit;

namespace RuleChecker.Service.Test
{
    public class OraclePatientRepositoryTests : UnitTestBase
    {
        private readonly IPatientRepository _patientRepository;

        public OraclePatientRepositoryTests()
        {
            _patientRepository = ServiceProvider.GetRequiredService<IPatientRepository>();
        }

        [Fact]
        public void Test_Oracle_Patient_Repository_Instance()
        {
            Assert.NotNull(_patientRepository);
        }

        [Fact]
        public void Test_Get_Patient_Info()
        {
            Assert.NotNull(_patientRepository);
            const string testPatientId = "ecc6e313-a91e-468e-87ed-2a9c20d3d5aa";
            var patientInfo = _patientRepository.GetPatientInfo(testPatientId);
            Assert.NotNull(patientInfo);
            Assert.Equal(testPatientId, patientInfo.PatientId);
        }
    }
}
