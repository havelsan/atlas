//$E2B3E1A1
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
    public partial class SupplyRequestPoolDetailServiceController : Controller
{
    [HttpGet]
    public SupplyRqstPlDetailFormViewModel SupplyRqstPlDetailForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return SupplyRqstPlDetailFormLoadInternal(input);
    }

    [HttpPost]
    public SupplyRqstPlDetailFormViewModel SupplyRqstPlDetailFormLoad(FormLoadInput input)
    {
        return SupplyRqstPlDetailFormLoadInternal(input);
    }

    private SupplyRqstPlDetailFormViewModel SupplyRqstPlDetailFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("3bca45db-688d-4de2-ae72-0ccec51d8c42");
        var objectDefID = Guid.Parse("6112708e-2d3d-4de7-9667-6ec115e65bc0");
        var viewModel = new SupplyRqstPlDetailFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SupplyRequestPoolDetail = objectContext.GetObject(id.Value, objectDefID) as SupplyRequestPoolDetail;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SupplyRequestPoolDetail, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SupplyRequestPoolDetail, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._SupplyRequestPoolDetail);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._SupplyRequestPoolDetail);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_SupplyRqstPlDetailForm(viewModel, viewModel._SupplyRequestPoolDetail, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SupplyRequestPoolDetail = new SupplyRequestPoolDetail(objectContext);
                viewModel.SupplyRequestDetailsGridList = new TTObjectClasses.SupplyRequestDetail[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SupplyRequestPoolDetail, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SupplyRequestPoolDetail, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._SupplyRequestPoolDetail);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._SupplyRequestPoolDetail);
                PreScript_SupplyRqstPlDetailForm(viewModel, viewModel._SupplyRequestPoolDetail, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel SupplyRqstPlDetailForm(SupplyRqstPlDetailFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("3bca45db-688d-4de2-ae72-0ccec51d8c42");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.PurchaseGroups);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.SupplyRequests);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.SupplyRequestDetailsGridList);
            objectContext.AddToRawObjectList(viewModel._SupplyRequestPoolDetail);
            objectContext.ProcessRawObjects();
            var supplyRequestPoolDetail = (SupplyRequestPoolDetail)objectContext.GetLoadedObject(viewModel._SupplyRequestPoolDetail.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(supplyRequestPoolDetail, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SupplyRequestPoolDetail, formDefID);
            if (viewModel.SupplyRequestDetailsGridList != null)
            {
                foreach (var item in viewModel.SupplyRequestDetailsGridList)
                {
                    var supplyRequestDetailsImported = (SupplyRequestDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)supplyRequestDetailsImported).IsDeleted)
                        continue;
                    supplyRequestDetailsImported.SupplyRequestPoolDetail = supplyRequestPoolDetail;
                }
            }

            var transDef = supplyRequestPoolDetail.TransDef;
            PostScript_SupplyRqstPlDetailForm(viewModel, supplyRequestPoolDetail, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(supplyRequestPoolDetail);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(supplyRequestPoolDetail);
            AfterContextSaveScript_SupplyRqstPlDetailForm(viewModel, supplyRequestPoolDetail, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_SupplyRqstPlDetailForm(SupplyRqstPlDetailFormViewModel viewModel, SupplyRequestPoolDetail supplyRequestPoolDetail, TTObjectContext objectContext);
    partial void PostScript_SupplyRqstPlDetailForm(SupplyRqstPlDetailFormViewModel viewModel, SupplyRequestPoolDetail supplyRequestPoolDetail, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_SupplyRqstPlDetailForm(SupplyRqstPlDetailFormViewModel viewModel, SupplyRequestPoolDetail supplyRequestPoolDetail, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(SupplyRqstPlDetailFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.SupplyRequestDetailsGridList = viewModel._SupplyRequestPoolDetail.SupplyRequestDetails.OfType<SupplyRequestDetail>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.PurchaseGroups = objectContext.LocalQuery<PurchaseGroup>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.SupplyRequests = objectContext.LocalQuery<SupplyRequest>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PurchaseGroupList", viewModel.PurchaseGroups);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DistributionTypeList", viewModel.DistributionTypeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StoresList", viewModel.Stores);
    }
}
}


namespace Core.Models
{
    public partial class SupplyRqstPlDetailFormViewModel : BaseViewModel
    {
        public TTObjectClasses.SupplyRequestPoolDetail _SupplyRequestPoolDetail { get; set; }
        public TTObjectClasses.SupplyRequestDetail[] SupplyRequestDetailsGridList { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.PurchaseGroup[] PurchaseGroups { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.SupplyRequest[] SupplyRequests { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
    }
}
