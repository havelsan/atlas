//$2A3FDE22
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class KvcRiskScoreServiceController
    {
        partial void PreScript_KvcRiskScoreForm(KvcRiskScoreFormViewModel viewModel, KvcRiskScore kvcRiskScore, TTObjectContext objectContext)
        {

            kvcRiskScore.EntryDate = Common.RecTime();
            kvcRiskScore.EntryUser = Common.CurrentResource;

            Guid? selectedEpisodeObjectID = viewModel.GetSelectedEpisodeID();
            if (selectedEpisodeObjectID.HasValue)
            {
                Episode episode = objectContext.GetObject<Episode>(selectedEpisodeObjectID.Value);

                kvcRiskScore.AgePoint = episode.Patient.Age;
                kvcRiskScore.IsWoman = episode.Patient.Sex.KODU == "2" ? true : false;
            }

        }
        partial void PostScript_KvcRiskScoreForm(KvcRiskScoreFormViewModel viewModel, KvcRiskScore kvcRiskScore, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            kvcRiskScore.Surgery = viewModel._Surgery;
        }

    }
}

namespace Core.Models
{
    public partial class KvcRiskScoreFormViewModel : BaseViewModel
    {
        public Surgery _Surgery { get; set; }
    }
}
