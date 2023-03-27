//$44AA6F39
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
    public partial class LaboratoryRequestServiceController : Controller
    {
        [HttpGet]
        public LaboratoryRequestInfoFormViewModel LaboratoryRequestInfoForm(Guid? id)
        {
            var FormDefID = Guid.Parse("60b4ad4b-bd39-4df0-9dbc-bb1ce91b8540");
            var ObjectDefID = Guid.Parse("b11e1a4e-ef2b-479b-9c6f-490f74e0b6d7");
            var viewModel = new LaboratoryRequestInfoFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._LaboratoryRequest = objectContext.GetObject(id.Value, ObjectDefID) as LaboratoryRequest;
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void LaboratoryRequestInfoForm(LaboratoryRequestInfoFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var laboratoryRequest = (LaboratoryRequest)objectContext.AddObject(viewModel._LaboratoryRequest);
                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public class LaboratoryRequestInfoFormViewModel
    {
        public TTObjectClasses.LaboratoryRequest _LaboratoryRequest
        {
            get;
            set;
        }
    }
}