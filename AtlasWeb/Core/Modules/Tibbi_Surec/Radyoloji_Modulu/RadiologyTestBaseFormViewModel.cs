//$EE52CE67
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
    public partial class RadiologyTestServiceController : Controller
    {
        [HttpGet]
        public RadiologyTestBaseFormViewModel RadiologyTestBaseForm(Guid? id)
        {
            var FormDefID = Guid.Parse("d6a0ae20-eb0d-4fcd-8496-90bd0686ff38");
            var ObjectDefID = Guid.Parse("2cf639c4-5819-4cf4-b295-2594a294c6a0");
            var viewModel = new RadiologyTestBaseFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._RadiologyTest = objectContext.GetObject(id.Value, ObjectDefID) as RadiologyTest;
      
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }



        [HttpPost]
        public void RadiologyTestBaseForm(RadiologyTestBaseFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var radiologyTest = (RadiologyTest)objectContext.AddObject(viewModel._RadiologyTest);
                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public class RadiologyTestBaseFormViewModel
    {
        public TTObjectClasses.RadiologyTest _RadiologyTest
        {
            get;
            set;
        }

    }



}
