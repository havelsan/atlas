//$4FE76F8D
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class RadiologyServiceController : Controller
    {
        [HttpGet]
        public RadiologyRequestFormViewModel RadiologyRequestForm(Guid? id)
        {
            var FormDefID = Guid.Parse("e5898c30-d2db-4396-8464-5a534037ff1a");
            var ObjectDefID = Guid.Parse("93dd7c72-c959-4b27-afe1-ef5f676e3d7c");
            var viewModel = new RadiologyRequestFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._Radiology = objectContext.GetObject(id.Value, ObjectDefID) as Radiology;
                    var episode = viewModel._Radiology.Episode;
                    if (episode != null)
                    {
                        viewModel.GridEpisodeDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
                    }

                    viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
                    viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
                    viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._Radiology = new Radiology(objectContext);
                    var entryStateID = Guid.Parse("80db87ee-2193-4bc4-836b-53ea7686463e");
                    viewModel._Radiology.CurrentStateDefID = entryStateID;
                    viewModel.GridEpisodeDiagnosisGridList = new TTObjectClasses.DiagnosisGrid[]{};
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void RadiologyRequestForm(RadiologyRequestFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var radiology = (Radiology)objectContext.AddObject(viewModel._Radiology);
                var episode = viewModel._Radiology.Episode;
                if (episode != null)
                {
                    var episodeImported = (Episode)objectContext.AddObject(episode);
                    if (viewModel.GridEpisodeDiagnosisGridList != null)
                    {
                        foreach (var item in viewModel.GridEpisodeDiagnosisGridList)
                        {
                            var diagnosisImported = (DiagnosisGrid)objectContext.AddObject(item);
                            diagnosisImported.Episode = episodeImported;
                        }
                    }
                }

                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public class RadiologyRequestFormViewModel
    {
        public TTObjectClasses.Radiology _Radiology
        {
            get;
            set;
        }

        public TTObjectClasses.DiagnosisGrid[] GridEpisodeDiagnosisGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }

        public TTObjectClasses.Episode[] Episodes
        {
            get;
            set;
        }

        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions
        {
            get;
            set;
        }
    }
}