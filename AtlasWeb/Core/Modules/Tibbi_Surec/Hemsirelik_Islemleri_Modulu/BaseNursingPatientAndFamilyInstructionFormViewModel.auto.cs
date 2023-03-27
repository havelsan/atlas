//$A193986F
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
    public partial class BaseNursingPatientAndFamilyInstructionServiceController : Controller
{
    [HttpGet]
    public BaseNursingPatientAndFamilyInstructionFormViewModel BaseNursingPatientAndFamilyInstructionForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BaseNursingPatientAndFamilyInstructionFormLoadInternal(input);
    }

    [HttpPost]
    public BaseNursingPatientAndFamilyInstructionFormViewModel BaseNursingPatientAndFamilyInstructionFormLoad(FormLoadInput input)
    {
        return BaseNursingPatientAndFamilyInstructionFormLoadInternal(input);
    }

    private BaseNursingPatientAndFamilyInstructionFormViewModel BaseNursingPatientAndFamilyInstructionFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("1ccd1eec-e7ec-4d96-8186-f72a553ac306");
        var objectDefID = Guid.Parse("a71233f7-d10c-4467-9787-2ee0ded44f3c");
        var viewModel = new BaseNursingPatientAndFamilyInstructionFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseNursingPatientAndFamilyInstruction = objectContext.GetObject(id.Value, objectDefID) as BaseNursingPatientAndFamilyInstruction;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseNursingPatientAndFamilyInstruction, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseNursingPatientAndFamilyInstruction, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BaseNursingPatientAndFamilyInstruction);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BaseNursingPatientAndFamilyInstruction);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BaseNursingPatientAndFamilyInstructionForm(viewModel, viewModel._BaseNursingPatientAndFamilyInstruction, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseNursingPatientAndFamilyInstruction = new BaseNursingPatientAndFamilyInstruction(objectContext);
                var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
                viewModel._BaseNursingPatientAndFamilyInstruction.CurrentStateDefID = entryStateID;
                viewModel.NursingPatientAndFamilyInstructionsGridList = new TTObjectClasses.NursingPatientAndFamilyInstruction[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseNursingPatientAndFamilyInstruction, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseNursingPatientAndFamilyInstruction, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._BaseNursingPatientAndFamilyInstruction);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._BaseNursingPatientAndFamilyInstruction);
                PreScript_BaseNursingPatientAndFamilyInstructionForm(viewModel, viewModel._BaseNursingPatientAndFamilyInstruction, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BaseNursingPatientAndFamilyInstructionForm(BaseNursingPatientAndFamilyInstructionFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("1ccd1eec-e7ec-4d96-8186-f72a553ac306");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.PatientAndFamilyInstructionDefinitions);
            objectContext.AddToRawObjectList(viewModel.NursingPatientAndFamilyInstructionsGridList);
            var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
            objectContext.AddToRawObjectList(viewModel._BaseNursingPatientAndFamilyInstruction, entryStateID);
            objectContext.ProcessRawObjects(false);
            var baseNursingPatientAndFamilyInstruction = (BaseNursingPatientAndFamilyInstruction)objectContext.GetLoadedObject(viewModel._BaseNursingPatientAndFamilyInstruction.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(baseNursingPatientAndFamilyInstruction, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseNursingPatientAndFamilyInstruction, formDefID);
            if (viewModel.NursingPatientAndFamilyInstructionsGridList != null)
            {
                foreach (var item in viewModel.NursingPatientAndFamilyInstructionsGridList)
                {
                    var nursingPatientAndFamilyInstructionsImported = (NursingPatientAndFamilyInstruction)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)nursingPatientAndFamilyInstructionsImported).IsDeleted)
                        continue;
                    nursingPatientAndFamilyInstructionsImported.BasePatAndFamInstruction = baseNursingPatientAndFamilyInstruction;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(baseNursingPatientAndFamilyInstruction);
            PostScript_BaseNursingPatientAndFamilyInstructionForm(viewModel, baseNursingPatientAndFamilyInstruction, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(baseNursingPatientAndFamilyInstruction);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(baseNursingPatientAndFamilyInstruction);
            AfterContextSaveScript_BaseNursingPatientAndFamilyInstructionForm(viewModel, baseNursingPatientAndFamilyInstruction, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_BaseNursingPatientAndFamilyInstructionForm(BaseNursingPatientAndFamilyInstructionFormViewModel viewModel, BaseNursingPatientAndFamilyInstruction baseNursingPatientAndFamilyInstruction, TTObjectContext objectContext);
    partial void PostScript_BaseNursingPatientAndFamilyInstructionForm(BaseNursingPatientAndFamilyInstructionFormViewModel viewModel, BaseNursingPatientAndFamilyInstruction baseNursingPatientAndFamilyInstruction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BaseNursingPatientAndFamilyInstructionForm(BaseNursingPatientAndFamilyInstructionFormViewModel viewModel, BaseNursingPatientAndFamilyInstruction baseNursingPatientAndFamilyInstruction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BaseNursingPatientAndFamilyInstructionFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.NursingPatientAndFamilyInstructionsGridList = viewModel._BaseNursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.OfType<NursingPatientAndFamilyInstruction>().ToArray();
        viewModel.PatientAndFamilyInstructionDefinitions = objectContext.LocalQuery<PatientAndFamilyInstructionDefinition>().ToArray();
    }
}
}


namespace Core.Models
{
    public partial class BaseNursingPatientAndFamilyInstructionFormViewModel : BaseViewModel
    {
        public TTObjectClasses.BaseNursingPatientAndFamilyInstruction _BaseNursingPatientAndFamilyInstruction { get; set; }
        public TTObjectClasses.NursingPatientAndFamilyInstruction[] NursingPatientAndFamilyInstructionsGridList { get; set; }
        public TTObjectClasses.PatientAndFamilyInstructionDefinition[] PatientAndFamilyInstructionDefinitions { get; set; }
    }
}
