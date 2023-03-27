//$CF3386E6
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
    public partial class SmearScreeningServiceController
    {
        partial void PreScript_SmearScreeningForm(SmearScreeningFormViewModel viewModel, SmearScreening smearScreening, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
                viewModel._SmearScreening.SubEpisode = episodeAction.SubEpisode;

            }

            if (((ITTObject)smearScreening).IsNew)
                viewModel._SmearScreening.AnamnesisInfo = new AnamnesisInfo(objectContext);

            ContextToViewModel(viewModel, objectContext);
        }


        [HttpGet]
        public string CheckSmearScreeningForm(Guid EpisodeActionId)
        {
            string result = String.Empty;
            using (var objectContext = new TTObjectContext(false))
            {

                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(EpisodeActionId);

                BindingList<SmearScreening.GetSmearScreeningBySubepisodeID_Class> forms = SmearScreening.GetSmearScreeningBySubepisodeID(episodeAction.SubEpisode.ObjectID, null);

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
    public partial class SmearScreeningFormViewModel: BaseViewModel
    {
    }
}
