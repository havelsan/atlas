//$39C13DF3
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class CreatingEpicrisisServiceController : Controller
    {
        public class CheckIfExistsWithSameSpeciality_Input
        {
            public TTObjectClasses.Episode episode { get; set; }
            public TTObjectClasses.CreatingEpicrisis creatingEpicrisisParam { get; set; }

        }
        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public void CheckIfExistsWithSameSpeciality(CheckIfExistsWithSameSpeciality_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.episode != null)
                    input.episode = (TTObjectClasses.Episode)objectContext.AddObject(input.episode);
                if (input.creatingEpicrisisParam != null)
                    input.creatingEpicrisisParam = (TTObjectClasses.CreatingEpicrisis)objectContext.AddObject(input.creatingEpicrisisParam);
                CreatingEpicrisis.CheckIfExistsWithSameSpeciality(input.episode, input.creatingEpicrisisParam);
                objectContext.FullPartialllyLoadedObjects();
            }
        }


        [HttpPost]
        public CreatingEpicrisisFormViewModel FillEpicrisis(CreatingEpicrisisFormViewModel viewModel)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(viewModel._CreatingEpicrisis.ObjectID);
            SubEpisode subEpisode = episodeAction.SubEpisode;
          /*  CreatingEpicrisisFormViewModel viewModel = new CreatingEpicrisisFormViewModel();
            viewModel._CreatingEpicrisis = new CreatingEpicrisis();

            viewModel._EpisodeAction = inputEA;*/
            
            foreach (var action in subEpisode.EpisodeActions)
            {
                if(action is CreatingEpicrisis)
                {
                    //  viewModel._CreatingEpicrisis = ((CreatingEpicrisis)action);
                    viewModel.Doctor = episodeAction.ProcedureDoctor;
                    viewModel.Epicrisises.Add((CreatingEpicrisis)action);
                }
            }

            if (viewModel.Epicrisises != null)
            {
                if (viewModel.Epicrisises.Count > 0)
                {
                    viewModel._CreatingEpicrisis = viewModel.Epicrisises[viewModel.Epicrisises.Count - 1];
                }
            }

            else
            {
                viewModel.Epicrisises = new List<CreatingEpicrisis>();
            //    viewModel._CreatingEpicrisis = new CreatingEpicrisis();
           //     viewModel._CreatingEpicrisis = new CreatingEpicrisis();
            }

            return viewModel;
        }
    }
}