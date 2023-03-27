//$4202DD66
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class ProstateScreeningServiceController
    {
        partial void PreScript_ProstateScreeningForm(ProstateScreeningFormViewModel viewModel, ProstateScreening prostateScreening, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
                viewModel._ProstateScreening.SubEpisode = episodeAction.SubEpisode;

            }

            if (((ITTObject)prostateScreening).IsNew)
                viewModel._ProstateScreening.AnamnesisInfo = new AnamnesisInfo(objectContext);

            ContextToViewModel(viewModel, objectContext);
        }


        [HttpGet]
        public string CheckProstateScreeningForm(Guid EpisodeActionId)
        {
            string result = String.Empty;
            using (var objectContext = new TTObjectContext(false))
            {

                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(EpisodeActionId);

                BindingList<ProstateScreening.GetProstateScreeningBySubepisodeID_Class> forms = ProstateScreening.GetProstateScreeningBySubepisodeID(episodeAction.SubEpisode.ObjectID, null);

                if (forms.Count > 0)
                {
                    result = forms[0].ObjectID.ToString();
                }

                return result;
            }

        }
    }
}

namespace Core.Models
{
    public partial class ProstateScreeningFormViewModel: BaseViewModel
    {
    }
}
