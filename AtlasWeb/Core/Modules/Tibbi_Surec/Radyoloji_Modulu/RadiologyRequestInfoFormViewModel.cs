//$4D2DA2BE
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
        public RadiologyRequestInfoFormViewModel RadiologyRequestInfoForm(Guid? id)
        {
            var FormDefID = Guid.Parse("34241156-7818-49cb-8906-4d7c80e1eeb5");
            var ObjectDefID = Guid.Parse("93dd7c72-c959-4b27-afe1-ef5f676e3d7c");
            var viewModel = new RadiologyRequestInfoFormViewModel();
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
        public void RadiologyRequestInfoForm(RadiologyRequestInfoFormViewModel viewModel)
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
    public class RadiologyRequestInfoFormViewModel
    {
        public TTObjectClasses.Radiology _Radiology
        {
            get;
            set;
        }

        public Guid subActionObjectId
        {
            get;
            set;
        }

        public vmRequiredInfoFormProcedure requestedProcedure
        {
            get;
            set;
        }
    }
//public class vmRequiredInfoFormProcedure
//{
//    public Guid SubActionProcedureObjectId { get; set; }
//    public string ProcedureCode { get; set; }
//    public string ProcedureName { get; set; }
//}
}