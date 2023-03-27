//$F4C8F621
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
    public partial class NuclearMedicineServiceController : Controller
    {
        [HttpGet]
        public NuclearMedicineTestRequestInfoFormViewModel NuclearMedicineTestRequestInfoForm(Guid? id)
        {
            var FormDefID = Guid.Parse("7c029d5d-e9d0-49bf-9037-9d49aa917a60");
            var ObjectDefID = Guid.Parse("2cf639c4-5819-4cf4-b295-2594a294c6a0");
            var viewModel = new NuclearMedicineTestRequestInfoFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._NuclearMedicineTest = objectContext.GetObject(id.Value, ObjectDefID) as NuclearMedicineTest;
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void NuclearMedicineTestRequestInfoForm(NuclearMedicineTestRequestInfoFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var nuclearMedicineTest = (NuclearMedicineTest)objectContext.AddObject(viewModel._NuclearMedicineTest);
                objectContext.Save();
            }
        } 
    }
}

namespace Core.Models
{
    public class NuclearMedicineTestRequestInfoFormViewModel
    {
        public TTObjectClasses.NuclearMedicineTest _NuclearMedicineTest
        {
            get;
            set;
        }

        public string ProcedureName
        {
            get;
            set;
        }

        public string ProcedureCode
        {
            get;
            set;
        }

        public string textDescription
        {
            get;
            set;
        }
    }
}