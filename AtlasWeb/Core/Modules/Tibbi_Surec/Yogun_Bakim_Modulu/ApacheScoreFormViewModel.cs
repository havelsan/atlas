//$B35AC17D
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;

namespace Core.Controllers
{
    public partial class ApacheScoreServiceController
    {
        partial void PreScript_ApacheScoreForm(ApacheScoreFormViewModel viewModel, ApacheScore apacheScore, TTObjectContext objectContext)
        {
            EpisodeAction episodeAction = apacheScore.EpisodeAction;
            if (episodeAction == null)
            {
                Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
                if (selectedEpisodeActionObjectID.HasValue)
                {
                    episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                }
            }

            if (apacheScore.Age == null && episodeAction != null && episodeAction.Episode.Patient != null && episodeAction.Episode.Patient.Age != null)
            {
                int _age = episodeAction.Episode.Patient.Age.Value;
                if (_age < 44)
                {
                    apacheScore.Age = ApacheAgeEnum.Under44;
                }
                else if (_age < 54)
                {
                    apacheScore.Age = ApacheAgeEnum._45to54;
                }
                else if (_age < 64)
                {
                    apacheScore.Age = ApacheAgeEnum._55to64;
                }
                else if (_age < 74)
                {
                    apacheScore.Age = ApacheAgeEnum._65to74;
                }
                else
                {
                    apacheScore.Age = ApacheAgeEnum.Over75;
                }

                apacheScore.EntryUser = Common.CurrentResource;
            }


            var glaskowScoreList = GlaskowScore.GetGlaskowByEpisodeAction(objectContext, episodeAction.ObjectID);

            if (glaskowScoreList.Count() == 0)
            {
                if (Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("IsGlaskowRequired", "TRUE")) == true)
                {
                    throw new Exception("Öncelikle Glaskow Skoru Girmelisiniz!");
                }
            }
            else
            {
                viewModel.glaskowScore = glaskowScoreList.OrderByDescending(c => c.EntryDate).FirstOrDefault().Total != null ? glaskowScoreList.OrderByDescending(c => c.EntryDate).FirstOrDefault().Total.Value : 0;
            }


        }
    }
}

namespace Core.Models
{
    public partial class ApacheScoreFormViewModel : BaseViewModel
    {
        public int glaskowScore { get; set; }
        public double O2GradientmmHg { get; set; }
        public double O2GradientKPa { get; set; }
    }
}
