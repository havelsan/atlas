using Microsoft.Extensions.DependencyInjection;
using RuleChecker.Interface;
using System;
using Xunit;

namespace RuleChecker.Service.Test
{
    public class OracleEpisodeRepositoryTests : UnitTestBase
    {
        private readonly IEpisodeRepository _episodeRepository;

        public OracleEpisodeRepositoryTests()
        {
            _episodeRepository = ServiceProvider.GetRequiredService<IEpisodeRepository>();
        }


        [Fact]
        public void Test_Oracle_Episode_Repository_Instance()
        {
            Assert.NotNull(_episodeRepository);
        }

        [Fact]
        public void Test_Get_Episode_Info()
        {
            Assert.NotNull(_episodeRepository);
            var testEpisodeId = @"c9448af0-53d7-4a04-9f0a-f01869368440";
            var episodeInfo = _episodeRepository.GetEpisodeInfo(testEpisodeId);
            Assert.NotNull(episodeInfo);
            Assert.Equal(testEpisodeId, episodeInfo.EpisodeId);
        }

        [Fact]
        public void Test_Get_Episode_Icd10_Diagnosis_List()
        {
            Assert.NotNull(_episodeRepository);
            var testEpisodeId = @"29829974-ab58-4dbf-bbc6-c2982c54c650";
            var icd10DiagnosisList = _episodeRepository.GetEpisodeIcd10DiagnosisList(testEpisodeId);
            Assert.NotNull(icd10DiagnosisList);
            Assert.Equal(new[] { "I00" }, icd10DiagnosisList);
        }
    }
}
