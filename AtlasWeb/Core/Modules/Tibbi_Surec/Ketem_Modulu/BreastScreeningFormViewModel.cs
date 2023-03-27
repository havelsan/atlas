//$BC9E51CA
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
    public partial class BreastScreeningServiceController
    {
        partial void PreScript_BreastScreeningForm(BreastScreeningFormViewModel viewModel, BreastScreening breastScreening, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
                viewModel._BreastScreening.SubEpisode = episodeAction.SubEpisode;

            }
            if (((ITTObject)breastScreening).IsNew)
                viewModel._BreastScreening.AnamnesisInfo = new AnamnesisInfo(objectContext);
            //viewModel._BreastScreening.AnamnesisInfo.SKRSAlkolKullanimi = new SKRSAlkolKullanimi(objectContext); 
            ContextToViewModel(viewModel, objectContext);
        }


        [HttpGet]
        public string CheckBreastScreeningForm(Guid EpisodeActionId)
        {
            string result = String.Empty;
            using (var objectContext = new TTObjectContext(false))
            {

                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(EpisodeActionId);

                BindingList<BreastScreening.GetBreastScreeningBySubepisodeID_Class> forms = BreastScreening.GetBreastScreeningBySubepisodeID(episodeAction.SubEpisode.ObjectID, null);
               
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
    public partial class BreastScreeningFormViewModel: BaseViewModel
    {
    }
}
