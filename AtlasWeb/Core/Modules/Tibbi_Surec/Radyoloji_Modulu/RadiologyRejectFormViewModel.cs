//$E62D1848
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
        public RadiologyRejectFormViewModel RadiologyRejectForm(Guid? id)
        {
            var FormDefID = Guid.Parse("93bcfb13-6f07-49c5-bd7e-1c2eded4c8c2");
            var ObjectDefID = Guid.Parse("93dd7c72-c959-4b27-afe1-ef5f676e3d7c");
            var viewModel = new RadiologyRejectFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._Radiology = objectContext.GetObject(id.Value, ObjectDefID) as Radiology;
                    viewModel.ttgrid2GridList = viewModel._Radiology.Materials.OfType<RadiologyMaterial>().ToArray();
                    viewModel.GridRadiologyTestsGridList = viewModel._Radiology.RadiologyTests.OfType<RadiologyTest>().ToArray();
                    viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
                    viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
                    viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
                    viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
                    viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
                    viewModel.RadiologyRejectReasonDefinitions = objectContext.LocalQuery<RadiologyRejectReasonDefinition>().ToArray();
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void RadiologyRejectForm(RadiologyRejectFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var radiology = (Radiology)objectContext.AddObject(viewModel._Radiology);
                if (viewModel.ttgrid2GridList != null)
                {
                    foreach (var item in viewModel.ttgrid2GridList)
                    {
                        var materialsImported = (RadiologyMaterial)objectContext.AddObject(item);
                        materialsImported.Radiology = radiology;
                    }
                }

                if (viewModel.GridRadiologyTestsGridList != null)
                {
                    foreach (var item in viewModel.GridRadiologyTestsGridList)
                    {
                        var radiologyTestsImported = (RadiologyTest)objectContext.AddObject(item);
                        radiologyTestsImported.Radiology = radiology;
                    }
                }

                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public class RadiologyRejectFormViewModel
    {
        public TTObjectClasses.Radiology _Radiology
        {
            get;
            set;
        }

        public TTObjectClasses.RadiologyMaterial[] ttgrid2GridList
        {
            get;
            set;
        }

        public TTObjectClasses.RadiologyTest[] GridRadiologyTestsGridList
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

        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }

        public TTObjectClasses.RadiologyRejectReasonDefinition[] RadiologyRejectReasonDefinitions
        {
            get;
            set;
        }
    }
}