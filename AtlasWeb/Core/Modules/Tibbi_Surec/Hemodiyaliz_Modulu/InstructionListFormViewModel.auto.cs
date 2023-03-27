//$A6F4A4AE
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
        public InstructionListFormViewModel InstructionListForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return InstructionListFormLoadInternal(input);
        }

        [HttpPost]
        public InstructionListFormViewModel InstructionListFormLoad(FormLoadInput input)
        {
            return InstructionListFormLoadInternal(input);
        }
        private InstructionListFormViewModel InstructionListFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("2b2df10a-2b99-472e-b91d-1bed62373a39");
            var objectDefID = Guid.Parse("c7c0466a-3499-4da4-9c52-5b899d9ef113");
            var viewModel = new InstructionListFormViewModel();
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

                    PreScript_InstructionListForm(viewModel, viewModel._HemodialysisInstruction, objectContext);
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
                    PreScript_InstructionListForm(viewModel, viewModel._HemodialysisInstruction, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel InstructionListForm(InstructionListFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return InstructionListFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel InstructionListFormInternal(InstructionListFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("2b2df10a-2b99-472e-b91d-1bed62373a39");
            objectContext.AddToRawObjectList(viewModel._HemodialysisInstruction);
            objectContext.ProcessRawObjects();

            var hemodialysisInstruction = (HemodialysisInstruction)objectContext.GetLoadedObject(viewModel._HemodialysisInstruction.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(hemodialysisInstruction, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HemodialysisInstruction, formDefID);
            var transDef = hemodialysisInstruction.TransDef;
            PostScript_InstructionListForm(viewModel, hemodialysisInstruction, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(hemodialysisInstruction);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(hemodialysisInstruction);
            AfterContextSaveScript_InstructionListForm(viewModel, hemodialysisInstruction, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_InstructionListForm(InstructionListFormViewModel viewModel, HemodialysisInstruction hemodialysisInstruction, TTObjectContext objectContext);
        partial void PostScript_InstructionListForm(InstructionListFormViewModel viewModel, HemodialysisInstruction hemodialysisInstruction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_InstructionListForm(InstructionListFormViewModel viewModel, HemodialysisInstruction hemodialysisInstruction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(InstructionListFormViewModel viewModel, TTObjectContext objectContext)
        {
        }
    }
}


namespace Core.Models
{
    public partial class InstructionListFormViewModel
    {
        public TTObjectClasses.HemodialysisInstruction _HemodialysisInstruction
        {
            get;
            set;
        }
    }
}
