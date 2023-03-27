//$75C39B94
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Helpers;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class HemodialysisRequestServiceController : Controller
    {
        [HttpGet]
        public HemodialysisProcedureFormViewModel HemodialysisProcedureForm(Guid? id)
        {
            var formDefID = Guid.Parse("db6f8976-3edc-4dcb-9293-fd1afdb56b05");
            var objectDefID = Guid.Parse("002e4716-4b62-44aa-9350-1e15f0231eb5");
            var viewModel = new HemodialysisProcedureFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._HemodialysisRequest = objectContext.GetObject(id.Value, objectDefID) as HemodialysisRequest;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._HemodialysisRequest, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HemodialysisRequest, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._HemodialysisRequest);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._HemodialysisRequest);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_HemodialysisProcedureForm(viewModel, viewModel._HemodialysisRequest, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel HemodialysisProcedureForm(HemodialysisProcedureFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return HemodialysisProcedureFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel HemodialysisProcedureFormInternal(HemodialysisProcedureFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("db6f8976-3edc-4dcb-9293-fd1afdb56b05");
            objectContext.AddToRawObjectList(viewModel._HemodialysisRequest);
            objectContext.ProcessRawObjects();

            var hemodialysisRequest = (HemodialysisRequest)objectContext.GetLoadedObject(viewModel._HemodialysisRequest.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(hemodialysisRequest, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HemodialysisRequest, formDefID);
            var transDef = hemodialysisRequest.TransDef;
            PostScript_HemodialysisProcedureForm(viewModel, hemodialysisRequest, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(hemodialysisRequest);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(hemodialysisRequest);
            AfterContextSaveScript_HemodialysisProcedureForm(viewModel, hemodialysisRequest, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_HemodialysisProcedureForm(HemodialysisProcedureFormViewModel viewModel, HemodialysisRequest hemodialysisRequest, TTObjectContext objectContext);
        partial void PostScript_HemodialysisProcedureForm(HemodialysisProcedureFormViewModel viewModel, HemodialysisRequest hemodialysisRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_HemodialysisProcedureForm(HemodialysisProcedureFormViewModel viewModel, HemodialysisRequest hemodialysisRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(HemodialysisProcedureFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}


namespace Core.Models
{
    public partial class HemodialysisProcedureFormViewModel
    {
        public TTObjectClasses.HemodialysisRequest _HemodialysisRequest
        {
            get;
            set;
        }
    }
}
