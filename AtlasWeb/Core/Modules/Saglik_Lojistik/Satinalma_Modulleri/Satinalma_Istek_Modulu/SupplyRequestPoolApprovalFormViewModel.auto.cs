//$326AEA2A
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
    public partial class SupplyRequestPoolServiceController : Controller
{
    [HttpGet]
    public SupplyRequestPoolApprovalFormViewModel SupplyRequestPoolApprovalForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return SupplyRequestPoolApprovalFormLoadInternal(input);
    }

    [HttpPost]
    public SupplyRequestPoolApprovalFormViewModel SupplyRequestPoolApprovalFormLoad(FormLoadInput input)
    {
        return SupplyRequestPoolApprovalFormLoadInternal(input);
    }

    private SupplyRequestPoolApprovalFormViewModel SupplyRequestPoolApprovalFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("2daaf2fa-3198-438a-b2e8-13e6d1ac648a");
        var objectDefID = Guid.Parse("09808ba9-c2c3-4286-96be-7d264fd2900b");
        var viewModel = new SupplyRequestPoolApprovalFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SupplyRequestPool = objectContext.GetObject(id.Value, objectDefID) as SupplyRequestPool;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SupplyRequestPool, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SupplyRequestPool, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._SupplyRequestPool);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._SupplyRequestPool);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_SupplyRequestPoolApprovalForm(viewModel, viewModel._SupplyRequestPool, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel SupplyRequestPoolApprovalForm(SupplyRequestPoolApprovalFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("2daaf2fa-3198-438a-b2e8-13e6d1ac648a");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.SupplyRequestPoolDetailsGridList);
            objectContext.AddToRawObjectList(viewModel._SupplyRequestPool);
            objectContext.ProcessRawObjects();
            var supplyRequestPool = (SupplyRequestPool)objectContext.GetLoadedObject(viewModel._SupplyRequestPool.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(supplyRequestPool, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SupplyRequestPool, formDefID);
            if (viewModel.SupplyRequestPoolDetailsGridList != null)
            {
                foreach (var item in viewModel.SupplyRequestPoolDetailsGridList)
                {
                    var supplyRequestPoolDetailsImported = (SupplyRequestPoolDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)supplyRequestPoolDetailsImported).IsDeleted)
                        continue;
                    supplyRequestPoolDetailsImported.SupplyRequestPool = supplyRequestPool;
                }
            }

            var transDef = supplyRequestPool.TransDef;
            PostScript_SupplyRequestPoolApprovalForm(viewModel, supplyRequestPool, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(supplyRequestPool);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(supplyRequestPool);
            AfterContextSaveScript_SupplyRequestPoolApprovalForm(viewModel, supplyRequestPool, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_SupplyRequestPoolApprovalForm(SupplyRequestPoolApprovalFormViewModel viewModel, SupplyRequestPool supplyRequestPool, TTObjectContext objectContext);
    partial void PostScript_SupplyRequestPoolApprovalForm(SupplyRequestPoolApprovalFormViewModel viewModel, SupplyRequestPool supplyRequestPool, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_SupplyRequestPoolApprovalForm(SupplyRequestPoolApprovalFormViewModel viewModel, SupplyRequestPool supplyRequestPool, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(SupplyRequestPoolApprovalFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.SupplyRequestPoolDetailsGridList = viewModel._SupplyRequestPool.SupplyRequestPoolDetails.OfType<SupplyRequestPoolDetail>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DistributionTypeList", viewModel.DistributionTypeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreList", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class SupplyRequestPoolApprovalFormViewModel : BaseViewModel
    {
        public TTObjectClasses.SupplyRequestPool _SupplyRequestPool { get; set; }
        public TTObjectClasses.SupplyRequestPoolDetail[] SupplyRequestPoolDetailsGridList { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}
