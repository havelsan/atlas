//$EBC2B4A8
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
    public partial class GynecologyServiceController : Controller
    {
        [HttpGet]
        public GynecologyFormViewModel GynecologyForm(Guid? id)
        {
            var FormDefID = Guid.Parse("150b9c99-c8c9-46f7-8e70-3ff6eafac70e");
            var ObjectDefID = Guid.Parse("5d5f3122-74a0-4888-9cfd-06d4782f2fae");
            var viewModel = new GynecologyFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._Gynecology = objectContext.GetObject(id.Value, ObjectDefID) as Gynecology;
                    viewModel.ReproductiveAbnormalityDefinitions = objectContext.LocalQuery<ReproductiveAbnormalityDefinition>().ToArray();
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._Gynecology = new Gynecology(objectContext);
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void GynecologyForm(GynecologyFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var gynecology = (Gynecology)objectContext.AddObject(viewModel._Gynecology);
                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public class GynecologyFormViewModel
    {
        public TTObjectClasses.Gynecology _Gynecology
        {
            get;
            set;
        }

        public TTObjectClasses.ReproductiveAbnormalityDefinition[] ReproductiveAbnormalityDefinitions
        {
            get;
            set;
        }
    }
}