//$0BE76DBB
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
    public partial class SpecialityBasedObjectServiceController : Controller
    {
        [HttpGet]
        public SpecialityBasedObjectFormViewModel SpecialityBasedObjectForm(Guid? id)
        {
            var FormDefID = Guid.Parse("557ab2fb-3c17-4ece-b6c3-425cc721ee1f");
            var ObjectDefID = Guid.Parse("97787b99-a57a-4afc-af31-975d48d94d2a");
            var viewModel = new SpecialityBasedObjectFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._SpecialityBasedObject = objectContext.GetObject(id.Value, ObjectDefID) as SpecialityBasedObject;
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._SpecialityBasedObject = new SpecialityBasedObject(objectContext);
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void SpecialityBasedObjectForm(SpecialityBasedObjectFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var specialityBasedObject = (SpecialityBasedObject)objectContext.AddObject(viewModel._SpecialityBasedObject);
                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public class SpecialityBasedObjectFormViewModel
    {
        public TTObjectClasses.SpecialityBasedObject _SpecialityBasedObject
        {
            get;
            set;
        }
    }
}