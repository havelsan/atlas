//$A74103E5
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
    public partial class ProcedureResultInfoServiceController : Controller
    {

        [HttpGet]
        public ProcedureResultInfoFormViewModel ProcedureResultInfoForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return ProcedureResultInfoFormLoadInternal(input);
        }

        [HttpPost]
        public ProcedureResultInfoFormViewModel ProcedureResultInfoFormLoad(FormLoadInput input)
        {
            return ProcedureResultInfoFormLoadInternal(input);
        }

        [HttpGet]
        public ProcedureResultInfoFormViewModel ProcedureResultInfoFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("6a74e572-179b-401f-9e77-defe78670723");
            var objectDefID = Guid.Parse("59120658-0624-47e9-ad57-fffe6a35ae5c");
            var viewModel = new ProcedureResultInfoFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ProcedureResultInfo = objectContext.GetObject(id.Value, objectDefID) as ProcedureResultInfo;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ProcedureResultInfo, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ProcedureResultInfo, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ProcedureResultInfo);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ProcedureResultInfo);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_ProcedureResultInfoForm(viewModel, viewModel._ProcedureResultInfo, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ProcedureResultInfo = new ProcedureResultInfo(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ProcedureResultInfo, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ProcedureResultInfo, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ProcedureResultInfo);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ProcedureResultInfo);
                    PreScript_ProcedureResultInfoForm(viewModel, viewModel._ProcedureResultInfo, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel ProcedureResultInfoForm(ProcedureResultInfoFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return ProcedureResultInfoFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel ProcedureResultInfoFormInternal(ProcedureResultInfoFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("6a74e572-179b-401f-9e77-defe78670723");
            objectContext.AddToRawObjectList(viewModel._ProcedureResultInfo);
            objectContext.ProcessRawObjects();

            var procedureResultInfo = (ProcedureResultInfo)objectContext.GetLoadedObject(viewModel._ProcedureResultInfo.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(procedureResultInfo, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ProcedureResultInfo, formDefID);
            var transDef = procedureResultInfo.TransDef;
            PostScript_ProcedureResultInfoForm(viewModel, procedureResultInfo, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(procedureResultInfo);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(procedureResultInfo);
            AfterContextSaveScript_ProcedureResultInfoForm(viewModel, procedureResultInfo, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_ProcedureResultInfoForm(ProcedureResultInfoFormViewModel viewModel, ProcedureResultInfo procedureResultInfo, TTObjectContext objectContext);
        partial void PostScript_ProcedureResultInfoForm(ProcedureResultInfoFormViewModel viewModel, ProcedureResultInfo procedureResultInfo, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_ProcedureResultInfoForm(ProcedureResultInfoFormViewModel viewModel, ProcedureResultInfo procedureResultInfo, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(ProcedureResultInfoFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}


namespace Core.Models
{
    public partial class ProcedureResultInfoFormViewModel
    {
        public TTObjectClasses.ProcedureResultInfo _ProcedureResultInfo
        {
            get;
            set;
        }
    }
}
