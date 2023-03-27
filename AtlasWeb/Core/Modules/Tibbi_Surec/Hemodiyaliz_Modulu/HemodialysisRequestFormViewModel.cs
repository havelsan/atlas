//$DA67B2FA
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

namespace Core.Controllers
{
    public partial class HemodialysisRequestServiceController
    {
        partial void PreScript_HemodialysisRequestForm(HemodialysisRequestFormViewModel viewModel, HemodialysisRequest hemodialysisRequest, TTObjectContext objectContext)
        {
            Guid? activeEpisodeObjectID = viewModel.GetSelectedEpisodeActionID();
            if (activeEpisodeObjectID.HasValue && hemodialysisRequest.IsOldAction != true)
            {
                EpisodeAction activeEpisodeAction = objectContext.GetObject<EpisodeAction>(activeEpisodeObjectID.Value);

                hemodialysisRequest.SetMandatoryEpisodeActionProperties(activeEpisodeAction, activeEpisodeAction.MasterResource, true);

                hemodialysisRequest.MasterAction = activeEpisodeAction;//?????????????????
                hemodialysisRequest.CurrentStateDefID = HemodialysisRequest.States.Request;
                if (activeEpisodeAction.SubEpisode.StarterEpisodeAction != null && activeEpisodeAction.SubEpisode.StarterEpisodeAction.ProcedureDoctor != null)
                    hemodialysisRequest.ProcedureDoctor = activeEpisodeAction.SubEpisode.StarterEpisodeAction.ProcedureDoctor;
                else if (activeEpisodeAction.ProcedureDoctor != null)
                    hemodialysisRequest.ProcedureDoctor = activeEpisodeAction.ProcedureDoctor;
            }
            if (hemodialysisRequest.HemodialysisRequestDate == null)
            {
                hemodialysisRequest.HemodialysisRequestDate = Common.RecTime();
            }
        }


        //Hemodiyaliz Eðitim Bilgileri ekraný baþlatma
        [HttpGet]
        public HemodialysisInstruction OpenHemodialysisInstruction(Guid episodeActionId)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                EpisodeAction _masterEpisodeAction = objectContext.GetObject<EpisodeAction>(episodeActionId);

                HemodialysisInstruction hemodialysisInstruction = new HemodialysisInstruction(objectContext);
                hemodialysisInstruction.EpisodeAction = _masterEpisodeAction;
                return hemodialysisInstruction;

            }

        }

    }
}

namespace Core.Models
{
    public partial class HemodialysisRequestFormViewModel : BaseViewModel
    {
    }
}
