//$85B5A58A
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
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class CancerScreeningServiceController
    {
        partial void PreScript_CancerScreeningForm(CancerScreeningFormViewModel viewModel, CancerScreening cancerScreening, TTObjectContext objectContext)
        {

            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
                viewModel._CancerScreening.SubEpisode = episodeAction.SubEpisode;

                if (episodeAction.Episode.Patient.Sex.KODU == "1")
                    viewModel.IsMale = true;
                else
                    viewModel.IsMale = false;

            }

            ContextToViewModel(viewModel, objectContext);
        }

        [HttpGet]
        public string CheckCancerScreeningForm(Guid EpisodeActionId)
        {
            string result = String.Empty;
            using (var objectContext = new TTObjectContext(false))
            {

                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(EpisodeActionId);

                BindingList<CancerScreening.GetCancerScreeningBySubepisodeID_Class> forms = CancerScreening.GetCancerScreeningBySubepisodeID(episodeAction.SubEpisode.ObjectID, null);

                if (forms.Count > 0)
                {
                    result = forms[0].ObjectID.ToString();
                }

                return result;
            }

        }

        partial void PostScript_CancerScreeningForm(CancerScreeningFormViewModel viewModel, CancerScreening cancerScreening, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
       
            new SendToENabiz(objectContext, cancerScreening.SubEpisode, cancerScreening.ObjectID, cancerScreening.ObjectDef.Name, "247", Common.RecTime());
        }


    }
}

namespace Core.Models
{
    public partial class CancerScreeningFormViewModel: BaseViewModel
    {
        public bool IsMale;
    }
}
