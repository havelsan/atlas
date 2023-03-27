//$296A87A1
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
        public RadiologyCompletedFormViewModel RadiologyCompletedForm(Guid? id)
        {
            var FormDefID = Guid.Parse("cc72a1b3-7ec0-474d-a6b9-9cb8067b71a7");
            var ObjectDefID = Guid.Parse("93dd7c72-c959-4b27-afe1-ef5f676e3d7c");
            var viewModel = new RadiologyCompletedFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._Radiology = objectContext.GetObject(id.Value, ObjectDefID) as Radiology;
                    viewModel.ttgrid1GridList = viewModel._Radiology.RadiologyTests.OfType<RadiologyTest>().ToArray();
                    viewModel.GridRadiologyTestsGridList = viewModel._Radiology.TreatmentMaterials.OfType<BaseTreatmentMaterial>().ToArray();
                    var episode = viewModel._Radiology.Episode;
                    if (episode != null)
                    {
                        viewModel.GridEpisodeDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
                    }

                    viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
                    viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
                    viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
                    viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
                    viewModel.RadiologyRejectReasonDefinitions = objectContext.LocalQuery<RadiologyRejectReasonDefinition>().ToArray();
                    viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
                    viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
                    viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void RadiologyCompletedForm(RadiologyCompletedFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var radiology = (Radiology)objectContext.AddObject(viewModel._Radiology);
                if (viewModel.ttgrid1GridList != null)
                {
                    foreach (var item in viewModel.ttgrid1GridList)
                    {
                        var radiologyTestsImported = (RadiologyTest)objectContext.AddObject(item);
                        radiologyTestsImported.Radiology = radiology;
                    }
                }

                if (viewModel.GridRadiologyTestsGridList != null)
                {
                    foreach (var item in viewModel.GridRadiologyTestsGridList)
                    {
                        var treatmentMaterialsImported = (BaseTreatmentMaterial)objectContext.AddObject(item);
                        treatmentMaterialsImported.EpisodeAction = radiology;
                    }
                }

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
    public class RadiologyCompletedFormViewModel
    {
        public TTObjectClasses.Radiology _Radiology
        {
            get;
            set;
        }

        public TTObjectClasses.RadiologyTest[] ttgrid1GridList
        {
            get;
            set;
        }

        public TTObjectClasses.BaseTreatmentMaterial[] GridRadiologyTestsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.DiagnosisGrid[] GridEpisodeDiagnosisGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }

        public TTObjectClasses.StockCard[] StockCards
        {
            get;
            set;
        }

        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.RadiologyRejectReasonDefinition[] RadiologyRejectReasonDefinitions
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