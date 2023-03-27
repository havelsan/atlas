//$FD6A3596
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
    public partial class NursingBodyFluidAnalysisServiceController : Controller
{
    [HttpGet]
    public NursingBodilyFluidAnalysisFormViewModel NursingBodilyFluidAnalysisForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NursingBodilyFluidAnalysisFormLoadInternal(input);
    }

    [HttpPost]
    public NursingBodilyFluidAnalysisFormViewModel NursingBodilyFluidAnalysisFormLoad(FormLoadInput input)
    {
        return NursingBodilyFluidAnalysisFormLoadInternal(input);
    }

    private NursingBodilyFluidAnalysisFormViewModel NursingBodilyFluidAnalysisFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("2906ff16-625a-4eab-8728-1a761fc313d8");
        var objectDefID = Guid.Parse("479dbb17-9578-4540-ad04-009b308a7267");
        var viewModel = new NursingBodilyFluidAnalysisFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingBodyFluidAnalysis = objectContext.GetObject(id.Value, objectDefID) as NursingBodyFluidAnalysis;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingBodyFluidAnalysis, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingBodyFluidAnalysis, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NursingBodyFluidAnalysis);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NursingBodyFluidAnalysis);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_NursingBodilyFluidAnalysisForm(viewModel, viewModel._NursingBodyFluidAnalysis, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingBodyFluidAnalysis = new NursingBodyFluidAnalysis(objectContext);
                var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
                viewModel._NursingBodyFluidAnalysis.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingBodyFluidAnalysis, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingBodyFluidAnalysis, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._NursingBodyFluidAnalysis);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._NursingBodyFluidAnalysis);
                PreScript_NursingBodilyFluidAnalysisForm(viewModel, viewModel._NursingBodyFluidAnalysis, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NursingBodilyFluidAnalysisForm(NursingBodilyFluidAnalysisFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return NursingBodilyFluidAnalysisFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel NursingBodilyFluidAnalysisFormInternal(NursingBodilyFluidAnalysisFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("2906ff16-625a-4eab-8728-1a761fc313d8");
        var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
        objectContext.AddToRawObjectList(viewModel._NursingBodyFluidAnalysis, entryStateID);
        objectContext.ProcessRawObjects(false);
        var nursingBodyFluidAnalysis = (NursingBodyFluidAnalysis)objectContext.GetLoadedObject(viewModel._NursingBodyFluidAnalysis.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(nursingBodyFluidAnalysis, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingBodyFluidAnalysis, formDefID);
        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(nursingBodyFluidAnalysis);
        PostScript_NursingBodilyFluidAnalysisForm(viewModel, nursingBodyFluidAnalysis, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nursingBodyFluidAnalysis);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nursingBodyFluidAnalysis);
        AfterContextSaveScript_NursingBodilyFluidAnalysisForm(viewModel, nursingBodyFluidAnalysis, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_NursingBodilyFluidAnalysisForm(NursingBodilyFluidAnalysisFormViewModel viewModel, NursingBodyFluidAnalysis nursingBodyFluidAnalysis, TTObjectContext objectContext);
    partial void PostScript_NursingBodilyFluidAnalysisForm(NursingBodilyFluidAnalysisFormViewModel viewModel, NursingBodyFluidAnalysis nursingBodyFluidAnalysis, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NursingBodilyFluidAnalysisForm(NursingBodilyFluidAnalysisFormViewModel viewModel, NursingBodyFluidAnalysis nursingBodyFluidAnalysis, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NursingBodilyFluidAnalysisFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class NursingBodilyFluidAnalysisFormViewModel
    {
        public TTObjectClasses.NursingBodyFluidAnalysis _NursingBodyFluidAnalysis
        {
            get;
            set;
        }
    }
}
