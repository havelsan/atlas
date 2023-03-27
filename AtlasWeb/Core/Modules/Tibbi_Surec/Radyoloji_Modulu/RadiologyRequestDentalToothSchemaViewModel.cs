//$88CF21CB
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
        public RadiologyRequestDentalToothSchemaViewModel RadiologyRequestDentalToothSchema(Guid? id)
        {
            var FormDefID = Guid.Parse("c31b533d-a41c-4c01-9346-7603e11624f5");
            var ObjectDefID = Guid.Parse("93dd7c72-c959-4b27-afe1-ef5f676e3d7c");
            var viewModel = new RadiologyRequestDentalToothSchemaViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._Radiology = objectContext.GetObject(id.Value, ObjectDefID) as Radiology;
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void RadiologyRequestDentalToothSchema(RadiologyRequestDentalToothSchemaViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var radiology = (Radiology)objectContext.AddObject(viewModel._Radiology);
                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public class RadiologyRequestDentalToothSchemaViewModel
    {
        public TTObjectClasses.Radiology _Radiology
        {
            get;
            set;
        }
    }
}