//$FC6D3CDE
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
    public partial class HemodialysisInstructionServiceController : Controller
    {
        [HttpGet]
        public HemodialysisInstructionFormViewModel HemodialysisInstructionForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return HemodialysisInstructionFormLoadInternal(input);
        }

        [HttpPost]
        public HemodialysisInstructionFormViewModel HemodialysisInstructionFormLoad(FormLoadInput input)
        {
            return HemodialysisInstructionFormLoadInternal(input);
        }

        private HemodialysisInstructionFormViewModel HemodialysisInstructionFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("eb90060e-2fd7-410a-b9f9-721ecf448010");
            var objectDefID = Guid.Parse("c7c0466a-3499-4da4-9c52-5b899d9ef113");
            var viewModel = new HemodialysisInstructionFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._HemodialysisInstruction = objectContext.GetObject(id.Value, objectDefID) as HemodialysisInstruction;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._HemodialysisInstruction, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HemodialysisInstruction, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._HemodialysisInstruction);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._HemodialysisInstruction);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_HemodialysisInstructionForm(viewModel, viewModel._HemodialysisInstruction, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._HemodialysisInstruction = new HemodialysisInstruction(objectContext);
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._HemodialysisInstruction, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HemodialysisInstruction, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._HemodialysisInstruction);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._HemodialysisInstruction);
                    PreScript_HemodialysisInstructionForm(viewModel, viewModel._HemodialysisInstruction, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel HemodialysisInstructionForm(HemodialysisInstructionFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return HemodialysisInstructionFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel HemodialysisInstructionFormInternal(HemodialysisInstructionFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("eb90060e-2fd7-410a-b9f9-721ecf448010");
            objectContext.AddToRawObjectList(viewModel._HemodialysisInstruction);
            objectContext.ProcessRawObjects();

            var hemodialysisInstruction = (HemodialysisInstruction)objectContext.GetLoadedObject(viewModel._HemodialysisInstruction.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(hemodialysisInstruction, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HemodialysisInstruction, formDefID);
            var transDef = hemodialysisInstruction.TransDef;
            PostScript_HemodialysisInstructionForm(viewModel, hemodialysisInstruction, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(hemodialysisInstruction);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(hemodialysisInstruction);
            AfterContextSaveScript_HemodialysisInstructionForm(viewModel, hemodialysisInstruction, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_HemodialysisInstructionForm(HemodialysisInstructionFormViewModel viewModel, HemodialysisInstruction hemodialysisInstruction, TTObjectContext objectContext);
        partial void PostScript_HemodialysisInstructionForm(HemodialysisInstructionFormViewModel viewModel, HemodialysisInstruction hemodialysisInstruction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_HemodialysisInstructionForm(HemodialysisInstructionFormViewModel viewModel, HemodialysisInstruction hemodialysisInstruction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(HemodialysisInstructionFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}


namespace Core.Models
{
    public partial class HemodialysisInstructionFormViewModel
    {
        public TTObjectClasses.HemodialysisInstruction _HemodialysisInstruction
        {
            get;
            set;
        }
    }
}
