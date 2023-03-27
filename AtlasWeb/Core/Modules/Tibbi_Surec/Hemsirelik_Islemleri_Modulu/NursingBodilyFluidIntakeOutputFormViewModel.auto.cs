//$75642FDA
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
    public partial class NursingBodilyFluidIntakeOutputServiceController : Controller
{
    [HttpGet]
    public NursingBodilyFluidIntakeOutputFormViewModel NursingBodilyFluidIntakeOutputForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NursingBodilyFluidIntakeOutputFormLoadInternal(input);
    }

    [HttpPost]
    public NursingBodilyFluidIntakeOutputFormViewModel NursingBodilyFluidIntakeOutputFormLoad(FormLoadInput input)
    {
        return NursingBodilyFluidIntakeOutputFormLoadInternal(input);
    }

    private NursingBodilyFluidIntakeOutputFormViewModel NursingBodilyFluidIntakeOutputFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("aadfe87a-047b-4816-a14f-87a8acebc351");
        var objectDefID = Guid.Parse("d737662d-2e99-4139-b3b0-d1967233e91d");
        var viewModel = new NursingBodilyFluidIntakeOutputFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingBodilyFluidIntakeOutput = objectContext.GetObject(id.Value, objectDefID) as NursingBodilyFluidIntakeOutput;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingBodilyFluidIntakeOutput, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingBodilyFluidIntakeOutput, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NursingBodilyFluidIntakeOutput);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NursingBodilyFluidIntakeOutput);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_NursingBodilyFluidIntakeOutputForm(viewModel, viewModel._NursingBodilyFluidIntakeOutput, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingBodilyFluidIntakeOutput = new NursingBodilyFluidIntakeOutput(objectContext);
                var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
                viewModel._NursingBodilyFluidIntakeOutput.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingBodilyFluidIntakeOutput, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingBodilyFluidIntakeOutput, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._NursingBodilyFluidIntakeOutput);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._NursingBodilyFluidIntakeOutput);
                PreScript_NursingBodilyFluidIntakeOutputForm(viewModel, viewModel._NursingBodilyFluidIntakeOutput, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NursingBodilyFluidIntakeOutputForm(NursingBodilyFluidIntakeOutputFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return NursingBodilyFluidIntakeOutputFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel NursingBodilyFluidIntakeOutputFormInternal(NursingBodilyFluidIntakeOutputFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("aadfe87a-047b-4816-a14f-87a8acebc351");
        var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
        objectContext.AddToRawObjectList(viewModel._NursingBodilyFluidIntakeOutput, entryStateID);
        objectContext.ProcessRawObjects(false);
        var nursingBodilyFluidIntakeOutput = (NursingBodilyFluidIntakeOutput)objectContext.GetLoadedObject(viewModel._NursingBodilyFluidIntakeOutput.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(nursingBodilyFluidIntakeOutput, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingBodilyFluidIntakeOutput, formDefID);
        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(nursingBodilyFluidIntakeOutput);
        PostScript_NursingBodilyFluidIntakeOutputForm(viewModel, nursingBodilyFluidIntakeOutput, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nursingBodilyFluidIntakeOutput);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nursingBodilyFluidIntakeOutput);
        AfterContextSaveScript_NursingBodilyFluidIntakeOutputForm(viewModel, nursingBodilyFluidIntakeOutput, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_NursingBodilyFluidIntakeOutputForm(NursingBodilyFluidIntakeOutputFormViewModel viewModel, NursingBodilyFluidIntakeOutput nursingBodilyFluidIntakeOutput, TTObjectContext objectContext);
    partial void PostScript_NursingBodilyFluidIntakeOutputForm(NursingBodilyFluidIntakeOutputFormViewModel viewModel, NursingBodilyFluidIntakeOutput nursingBodilyFluidIntakeOutput, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NursingBodilyFluidIntakeOutputForm(NursingBodilyFluidIntakeOutputFormViewModel viewModel, NursingBodilyFluidIntakeOutput nursingBodilyFluidIntakeOutput, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NursingBodilyFluidIntakeOutputFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class NursingBodilyFluidIntakeOutputFormViewModel
    {
        public TTObjectClasses.NursingBodilyFluidIntakeOutput _NursingBodilyFluidIntakeOutput
        {
            get;
            set;
        }
    }
}
