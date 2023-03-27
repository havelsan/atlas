//$AC493233
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
    public partial class SupplyRequestServiceController : Controller
{
    [HttpGet]
    public BaseSupplyRequestViewModel BaseSupplyRequest(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BaseSupplyRequestLoadInternal(input);
    }

    [HttpPost]
    public BaseSupplyRequestViewModel BaseSupplyRequestLoad(FormLoadInput input)
    {
        return BaseSupplyRequestLoadInternal(input);
    }

    private BaseSupplyRequestViewModel BaseSupplyRequestLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("6c1fa3cb-a9ce-4389-8b5d-8b55d4c0a08c");
        var objectDefID = Guid.Parse("b78a0f38-6308-470d-8029-5c162c065e3f");
        var viewModel = new BaseSupplyRequestViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SupplyRequest = objectContext.GetObject(id.Value, objectDefID) as SupplyRequest;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SupplyRequest, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SupplyRequest, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._SupplyRequest);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._SupplyRequest);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BaseSupplyRequest(viewModel, viewModel._SupplyRequest, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BaseSupplyRequest(BaseSupplyRequestViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("6c1fa3cb-a9ce-4389-8b5d-8b55d4c0a08c");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.PurchaseGroups);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.SupplyRequestDetailsGridList);
            objectContext.AddToRawObjectList(viewModel._SupplyRequest);
            objectContext.ProcessRawObjects();
            var supplyRequest = (SupplyRequest)objectContext.GetLoadedObject(viewModel._SupplyRequest.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(supplyRequest, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SupplyRequest, formDefID);
            if (viewModel.SupplyRequestDetailsGridList != null)
            {
                foreach (var item in viewModel.SupplyRequestDetailsGridList)
                {
                    var supplyRequestDetailsImported = (SupplyRequestDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)supplyRequestDetailsImported).IsDeleted)
                        continue;
                    supplyRequestDetailsImported.SupplyRequest = supplyRequest;
                }
            }

            var transDef = supplyRequest.TransDef;
            PostScript_BaseSupplyRequest(viewModel, supplyRequest, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(supplyRequest);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(supplyRequest);
            AfterContextSaveScript_BaseSupplyRequest(viewModel, supplyRequest, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_BaseSupplyRequest(BaseSupplyRequestViewModel viewModel, SupplyRequest supplyRequest, TTObjectContext objectContext);
    partial void PostScript_BaseSupplyRequest(BaseSupplyRequestViewModel viewModel, SupplyRequest supplyRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BaseSupplyRequest(BaseSupplyRequestViewModel viewModel, SupplyRequest supplyRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BaseSupplyRequestViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.SupplyRequestDetailsGridList = viewModel._SupplyRequest.SupplyRequestDetails.OfType<SupplyRequestDetail>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.PurchaseGroups = objectContext.LocalQuery<PurchaseGroup>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreList", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PurchaseGroupList", viewModel.PurchaseGroups);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DistributionTypeList", viewModel.DistributionTypeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StoreListDefinition", viewModel.Stores);
    }
}
}


namespace Core.Models
{
    public partial class BaseSupplyRequestViewModel : BaseViewModel
    {
        public TTObjectClasses.SupplyRequest _SupplyRequest { get; set; }
        public TTObjectClasses.SupplyRequestDetail[] SupplyRequestDetailsGridList { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.PurchaseGroup[] PurchaseGroups { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
    }
}
