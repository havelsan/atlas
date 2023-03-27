//$F8B08B4D
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
        public LaboratoryRequestRequestFormViewModel LaboratoryRequestRequestForm(Guid? id)
        {
            var FormDefID = Guid.Parse("01353873-68f4-408e-8d1c-52b010eb075f");
            var ObjectDefID = Guid.Parse("b11e1a4e-ef2b-479b-9c6f-490f74e0b6d7");
            var viewModel = new LaboratoryRequestRequestFormViewModel();
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
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._LaboratoryRequest = new LaboratoryRequest(objectContext);
                    var entryStateID = Guid.Parse("30d50f98-3f54-4a24-8205-bf16f32e8119");
                    viewModel._LaboratoryRequest.CurrentStateDefID = entryStateID;
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void LaboratoryRequestRequestForm(LaboratoryRequestRequestFormViewModel viewModel)
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
    public class LaboratoryRequestRequestFormViewModel
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