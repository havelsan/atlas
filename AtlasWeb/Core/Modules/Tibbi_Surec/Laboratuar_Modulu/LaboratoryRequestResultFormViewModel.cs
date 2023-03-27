//$A5E19E10
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
        public LaboratoryRequestResultFormViewModel LaboratoryRequestResultForm(Guid? id)
        {
            var FormDefID = Guid.Parse("85a99e6e-9f14-471f-abec-05938053ff17");
            var ObjectDefID = Guid.Parse("b11e1a4e-ef2b-479b-9c6f-490f74e0b6d7");
            var viewModel = new LaboratoryRequestResultFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._LaboratoryRequest = objectContext.GetObject(id.Value, ObjectDefID) as LaboratoryRequest;
                    viewModel.GridLabProceduresGridList = viewModel._LaboratoryRequest.LaboratoryProcedures.OfType<LaboratoryProcedure>().ToArray();
                    viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
                    viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void LaboratoryRequestResultForm(LaboratoryRequestResultFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var laboratoryRequest = (LaboratoryRequest)objectContext.AddObject(viewModel._LaboratoryRequest);
                if (viewModel.GridLabProceduresGridList != null)
                {
                    foreach (var item in viewModel.GridLabProceduresGridList)
                    {
                        var laboratoryProceduresImported = (LaboratoryProcedure)objectContext.AddObject(item);
                        laboratoryProceduresImported.Laboratory = laboratoryRequest;
                    }
                }

                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public class LaboratoryRequestResultFormViewModel
    {
        public TTObjectClasses.LaboratoryRequest _LaboratoryRequest
        {
            get;
            set;
        }

        public TTObjectClasses.LaboratoryProcedure[] GridLabProceduresGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions
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