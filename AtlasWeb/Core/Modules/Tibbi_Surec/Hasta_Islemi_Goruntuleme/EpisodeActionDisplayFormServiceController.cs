using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using System.Collections.Generic;
using System.Collections;
using TTStorageManager.Security;
using TTUtils;
using TTDefinitionManagement;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{

    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class EpisodeActionDisplayFormServiceController : Controller
    {

       
          [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ActiveInfoDVO GetActiveInfoDVO([FromQuery] string ObjectId, [FromQuery] string ObjectDefName)
        {
            ActiveInfoDVO activeInfoDVO = new ActiveInfoDVO();
            if (String.IsNullOrEmpty(ObjectId))
            {
                activeInfoDVO.EpisodeActionObjectID = Guid.Empty;
                activeInfoDVO.EpisodeObjectID = Guid.Empty;
                activeInfoDVO.PatientObjectID = Guid.Empty;
            }
            else
            {
                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    TTObject action = objectContext.GetObject(new Guid(ObjectId), ObjectDefName);
                    if (action is EpisodeAction)
                    {
                        EpisodeAction episodeAction = (EpisodeAction)objectContext.GetObject(new Guid(ObjectId), typeof(EpisodeAction));
                        activeInfoDVO.EpisodeActionObjectID = episodeAction.ObjectID;
                        activeInfoDVO.EpisodeObjectID = episodeAction.Episode.ObjectID;
                        activeInfoDVO.PatientObjectID = episodeAction.Episode.Patient.ObjectID;
                    }

                    if (action is SubactionProcedureFlowable)
                    {
                        SubactionProcedureFlowable subactionProcedureFlowable = (SubactionProcedureFlowable)objectContext.GetObject(new Guid(ObjectId), typeof(SubactionProcedureFlowable));
                        activeInfoDVO.EpisodeActionObjectID = subactionProcedureFlowable.ObjectID;
                        activeInfoDVO.EpisodeObjectID = subactionProcedureFlowable.Episode.ObjectID;
                        activeInfoDVO.PatientObjectID = subactionProcedureFlowable.Episode.Patient.ObjectID;
                    }

                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return activeInfoDVO;
        }

    }
}