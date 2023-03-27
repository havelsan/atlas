//$A30C355E
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
        public RadiologyTestDentalToothSchemaViewModel RadiologyTestDentalToothSchema(Guid? id)
        {
            var FormDefID = Guid.Parse("6d6c4030-3467-4f74-97ed-bba82e564eb1");
            var ObjectDefID = Guid.Parse("2cf639c4-5819-4cf4-b295-2594a294c6a0");
            var viewModel = new RadiologyTestDentalToothSchemaViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._RadiologyTest = objectContext.GetObject(id.Value, ObjectDefID) as RadiologyTest;
                    viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void RadiologyTestDentalToothSchema(RadiologyTestDentalToothSchemaViewModel viewModel)
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
    public class RadiologyTestDentalToothSchemaViewModel
    {
        public TTObjectClasses.RadiologyTest _RadiologyTest
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions
        {
            get;
            set;
        }
    }
}