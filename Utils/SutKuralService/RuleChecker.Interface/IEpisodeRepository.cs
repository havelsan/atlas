using RuleChecker.Interface.Entities;
using System.Collections.Generic;

namespace RuleChecker.Interface
{
    public interface IEpisodeRepository
    {
        EpisodeInfoDto GetEpisodeInfo(object episodeId);
        IList<string> GetEpisodeIcd10DiagnosisList(object episodeId);
    }
}
