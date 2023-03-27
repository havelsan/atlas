//$B58B4D57
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
        public LaboratoryFormViewModel LaboratoryForm(Guid? id)
        {
            var FormDefID = Guid.Parse("db9aeab1-aa4f-4b08-b9fa-1f042eb36c81");
            var ObjectDefID = Guid.Parse("b11e1a4e-ef2b-479b-9c6f-490f74e0b6d7");
            var viewModel = new LaboratoryFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._LaboratoryRequest = objectContext.GetObject(id.Value, ObjectDefID) as LaboratoryRequest;
                    viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void LaboratoryForm(LaboratoryFormViewModel viewModel)
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
    public class LaboratoryFormViewModel
    {
        public TTObjectClasses.LaboratoryRequest _LaboratoryRequest
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }
    }
}