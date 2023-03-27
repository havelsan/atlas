//$D24FC600
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
    public partial class SterilizationRequestServiceController : Controller
{
    [HttpGet]
    public SterilizationRequestFormViewModel SterilizationRequestForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return SterilizationRequestFormLoadInternal(input);
    }

    [HttpPost]
    public SterilizationRequestFormViewModel SterilizationRequestFormLoad(FormLoadInput input)
    {
        return SterilizationRequestFormLoadInternal(input);
    }

    private SterilizationRequestFormViewModel SterilizationRequestFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("203c97f1-8921-445f-91c1-efb4e52b242e");
        var objectDefID = Guid.Parse("04745158-3399-4040-a6ff-402b01c33948");
        var viewModel = new SterilizationRequestFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SterilizationRequest = objectContext.GetObject(id.Value, objectDefID) as SterilizationRequest;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SterilizationRequest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SterilizationRequest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._SterilizationRequest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._SterilizationRequest);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_SterilizationRequestForm(viewModel, viewModel._SterilizationRequest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SterilizationRequest = new SterilizationRequest(objectContext);
                var entryStateID = Guid.Parse("9a9d0d72-e1e9-4613-92ed-309300aa9b01");
                viewModel._SterilizationRequest.CurrentStateDefID = entryStateID;
                viewModel.SterilizationHistoriesGridList = new TTObjectClasses.SterilizationHistory[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SterilizationRequest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SterilizationRequest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._SterilizationRequest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._SterilizationRequest);
                PreScript_SterilizationRequestForm(viewModel, viewModel._SterilizationRequest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel SterilizationRequestForm(SterilizationRequestFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return SterilizationRequestFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel SterilizationRequestFormInternal(SterilizationRequestFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("203c97f1-8921-445f-91c1-efb4e52b242e");
        objectContext.AddToRawObjectList(viewModel.ResSections);
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.ResReusableMaterials);
        objectContext.AddToRawObjectList(viewModel.SterilizationHistoriesGridList);
        var entryStateID = Guid.Parse("9a9d0d72-e1e9-4613-92ed-309300aa9b01");
        objectContext.AddToRawObjectList(viewModel._SterilizationRequest, entryStateID);
        objectContext.ProcessRawObjects(false);
        var sterilizationRequest = (SterilizationRequest)objectContext.GetLoadedObject(viewModel._SterilizationRequest.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(sterilizationRequest, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SterilizationRequest, formDefID);
        if (viewModel.SterilizationHistoriesGridList != null)
        {
            foreach (var item in viewModel.SterilizationHistoriesGridList)
            {
                var sterilizationHistoriesImported = (SterilizationHistory)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)sterilizationHistoriesImported).IsDeleted)
                    continue;
                sterilizationHistoriesImported.SterilizationRequest = sterilizationRequest;
            }
        }

        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(sterilizationRequest);
        PostScript_SterilizationRequestForm(viewModel, sterilizationRequest, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(sterilizationRequest);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(sterilizationRequest);
        AfterContextSaveScript_SterilizationRequestForm(viewModel, sterilizationRequest, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_SterilizationRequestForm(SterilizationRequestFormViewModel viewModel, SterilizationRequest sterilizationRequest, TTObjectContext objectContext);
    partial void PostScript_SterilizationRequestForm(SterilizationRequestFormViewModel viewModel, SterilizationRequest sterilizationRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_SterilizationRequestForm(SterilizationRequestFormViewModel viewModel, SterilizationRequest sterilizationRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(SterilizationRequestFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.SterilizationHistoriesGridList = viewModel._SterilizationRequest.SterilizationHistories.OfType<SterilizationHistory>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.ResReusableMaterials = objectContext.LocalQuery<ResReusableMaterial>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResSterilizationUnitListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResUserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResUsableMaterialWithoutPackageAndClearList", viewModel.ResReusableMaterials);
    }
}
}


namespace Core.Models
{
    public partial class SterilizationRequestFormViewModel
    {
        public TTObjectClasses.SterilizationRequest _SterilizationRequest
        {
            get;
            set;
        }

        public TTObjectClasses.SterilizationHistory[] SterilizationHistoriesGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ResSection[] ResSections
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }

        public TTObjectClasses.ResReusableMaterial[] ResReusableMaterials
        {
            get;
            set;
        }
    }
}
