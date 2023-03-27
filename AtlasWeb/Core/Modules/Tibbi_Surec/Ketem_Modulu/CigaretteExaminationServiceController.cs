//$F1449136
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class CigaretteExaminationServiceController : Controller
    {
        [HttpGet]
        public string CheckCigaretteExamination(Guid EpisodeActionId)
        {
            string result = String.Empty;
            using (var objectContext = new TTObjectContext(false))
            {

                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(EpisodeActionId);

                BindingList<CigaretteExamination.GetCigaretteExaminationBySubepisodeID_Class> forms = CigaretteExamination.GetCigaretteExaminationBySubepisodeID(episodeAction.SubEpisode.ObjectID, null);

                if (forms.Count > 0)
                {
                    result = forms[0].ObjectID.ToString();
                }

                return result;
            }

        }
    }
}