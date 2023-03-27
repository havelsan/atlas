//$5B5E15D5
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
    public HemodialysisRequestFormViewModel HemodialysisRequestForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return HemodialysisRequestFormLoadInternal(input);
    }

    [HttpPost]
    public HemodialysisRequestFormViewModel HemodialysisRequestFormLoad(FormLoadInput input)
    {
        return HemodialysisRequestFormLoadInternal(input);
    }

    private HemodialysisRequestFormViewModel HemodialysisRequestFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("c8bd21a6-1933-4ed2-a0f6-a9b7e27e18bb");
        var objectDefID = Guid.Parse("002e4716-4b62-44aa-9350-1e15f0231eb5");
        var viewModel = new HemodialysisRequestFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
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
                PreScript_HemodialysisRequestForm(viewModel, viewModel._HemodialysisRequest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._HemodialysisRequest = new HemodialysisRequest(objectContext);
                var entryStateID = Guid.Parse("7806db6a-ec28-483a-b090-a4adaa70d3cd");
                viewModel._HemodialysisRequest.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._HemodialysisRequest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HemodialysisRequest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._HemodialysisRequest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._HemodialysisRequest);
                PreScript_HemodialysisRequestForm(viewModel, viewModel._HemodialysisRequest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel HemodialysisRequestForm(HemodialysisRequestFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return HemodialysisRequestFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel HemodialysisRequestFormInternal(HemodialysisRequestFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("c8bd21a6-1933-4ed2-a0f6-a9b7e27e18bb");
        var entryStateID = Guid.Parse("7806db6a-ec28-483a-b090-a4adaa70d3cd");
        objectContext.AddToRawObjectList(viewModel._HemodialysisRequest, entryStateID);
        objectContext.ProcessRawObjects(false);
        var hemodialysisRequest = (HemodialysisRequest)objectContext.GetLoadedObject(viewModel._HemodialysisRequest.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(hemodialysisRequest, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HemodialysisRequest, formDefID);
        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(hemodialysisRequest);
        PostScript_HemodialysisRequestForm(viewModel, hemodialysisRequest, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(hemodialysisRequest);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(hemodialysisRequest);
        AfterContextSaveScript_HemodialysisRequestForm(viewModel, hemodialysisRequest, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_HemodialysisRequestForm(HemodialysisRequestFormViewModel viewModel, HemodialysisRequest hemodialysisRequest, TTObjectContext objectContext);
    partial void PostScript_HemodialysisRequestForm(HemodialysisRequestFormViewModel viewModel, HemodialysisRequest hemodialysisRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_HemodialysisRequestForm(HemodialysisRequestFormViewModel viewModel, HemodialysisRequest hemodialysisRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(HemodialysisRequestFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class HemodialysisRequestFormViewModel
    {
        public TTObjectClasses.HemodialysisRequest _HemodialysisRequest
        {
            get;
            set;
        }
    }
}
