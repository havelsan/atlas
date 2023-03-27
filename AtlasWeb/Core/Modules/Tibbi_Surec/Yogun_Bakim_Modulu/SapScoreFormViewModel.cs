//$9A78683D
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
    public partial class SapsScoreServiceController
    {

        partial void PreScript_SapScoreForm(SapScoreFormViewModel viewModel, SapsScore sapsScore, TTObjectContext objectContext)
        {
            EpisodeAction episodeAction = sapsScore.EpisodeAction;
            if (episodeAction == null)
            {
                Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
                if (selectedEpisodeActionObjectID.HasValue)
                {
                    episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                }
            }

            var patient = episodeAction.Episode.Patient;

            if (sapsScore.PatientAge == null)
                sapsScore.PatientAge = patient.Age;
            if (sapsScore.PatientSex == null && patient.Sex != null)
            {
                if (patient.Sex.KODU == "1") //Erkek
                    sapsScore.PatientSex = SexEnum.Male;
                else if (patient.Sex.KODU == "2") //Kadýn
                    sapsScore.PatientSex = SexEnum.Female;
            }
            if (sapsScore.EntryUser == null)
                sapsScore.EntryUser = Common.CurrentResource;
        }
    }
}

namespace Core.Models
{
    public partial class SapScoreFormViewModel
    {
    }
}
