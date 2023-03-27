//$61C7E008
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
    public partial class NewBornIntensiveCareServiceController
    {
        partial void PreScript_NewBornIntensiveCareForm(NewBornIntensiveCareFormViewModel viewModel, NewBornIntensiveCare newBornIntensiveCare, TTObjectContext objectContext)
        {
            //EpisodeAction episodeAction = newBornIntensiveCare.IntensiveCareSpecialityObj.PhysicianApplication as EpisodeAction;

            if (newBornIntensiveCare.IntensiveCareSpecialityObj == null)
            {
                Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
                if (selectedEpisodeActionObjectID.HasValue)
                {
                    EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                    newBornIntensiveCare.IntensiveCareSpecialityObj = (episodeAction as PhysicianApplication).GetMyIntensiveCareSpecialityObj();
                    if (newBornIntensiveCare.Patient == null)
                    {
                        newBornIntensiveCare.Patient = episodeAction.Episode.Patient;
                    }
                }
            }

            ContextToViewModel(viewModel, objectContext);
        }
        partial void PostScript_NewBornIntensiveCareForm(NewBornIntensiveCareFormViewModel viewModel, NewBornIntensiveCare newBornIntensiveCare, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (newBornIntensiveCare.Patient != null && newBornIntensiveCare.Patient.BirthDate != null && newBornIntensiveCare.BirthTime != null)
            {
                DateTime birthTimeAndDate = newBornIntensiveCare.Patient.BirthDate.Value.Date + newBornIntensiveCare.BirthTime.Value.TimeOfDay;
                newBornIntensiveCare.BirthTime = birthTimeAndDate;
            }
        }
    }
}

namespace Core.Models
{
    public partial class NewBornIntensiveCareFormViewModel : BaseViewModel
    {
        public string intensiveCareSpecialityObjId { get; set; }
    }
}
