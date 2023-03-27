//$32852195
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
    public SupplyRequestPoolNewFormViewModel SupplyRequestPoolNewForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return SupplyRequestPoolNewFormLoadInternal(input);
    }

    [HttpPost]
    public SupplyRequestPoolNewFormViewModel SupplyRequestPoolNewFormLoad(FormLoadInput input)
    {
        return SupplyRequestPoolNewFormLoadInternal(input);
    }

    private SupplyRequestPoolNewFormViewModel SupplyRequestPoolNewFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("8d7a5035-e23a-4ff8-9833-b65ca29cd96d");
        var objectDefID = Guid.Parse("09808ba9-c2c3-4286-96be-7d264fd2900b");
        var viewModel = new SupplyRequestPoolNewFormViewModel();
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
                PreScript_SupplyRequestPoolNewForm(viewModel, viewModel._SupplyRequestPool, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SupplyRequestPool = new SupplyRequestPool(objectContext);
                var entryStateID = Guid.Parse("b8ef9cf8-17dc-424b-98f8-46817dda5da9");
                viewModel._SupplyRequestPool.CurrentStateDefID = entryStateID;
                viewModel.SupplyRequestPoolDetailsGridList = new TTObjectClasses.SupplyRequestPoolDetail[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SupplyRequestPool, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SupplyRequestPool, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._SupplyRequestPool);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._SupplyRequestPool);
                PreScript_SupplyRequestPoolNewForm(viewModel, viewModel._SupplyRequestPool, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel SupplyRequestPoolNewForm(SupplyRequestPoolNewFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("8d7a5035-e23a-4ff8-9833-b65ca29cd96d");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.SupplyRequestPoolDetailsGridList);
            var entryStateID = Guid.Parse("b8ef9cf8-17dc-424b-98f8-46817dda5da9");
            objectContext.AddToRawObjectList(viewModel._SupplyRequestPool, entryStateID);
            objectContext.ProcessRawObjects(false);
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

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(supplyRequestPool);
            PostScript_SupplyRequestPoolNewForm(viewModel, supplyRequestPool, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(supplyRequestPool);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(supplyRequestPool);
            AfterContextSaveScript_SupplyRequestPoolNewForm(viewModel, supplyRequestPool, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_SupplyRequestPoolNewForm(SupplyRequestPoolNewFormViewModel viewModel, SupplyRequestPool supplyRequestPool, TTObjectContext objectContext);
    partial void PostScript_SupplyRequestPoolNewForm(SupplyRequestPoolNewFormViewModel viewModel, SupplyRequestPool supplyRequestPool, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_SupplyRequestPoolNewForm(SupplyRequestPoolNewFormViewModel viewModel, SupplyRequestPool supplyRequestPool, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(SupplyRequestPoolNewFormViewModel viewModel, TTObjectContext objectContext)
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
    public partial class SupplyRequestPoolNewFormViewModel : BaseViewModel
    {
        public TTObjectClasses.SupplyRequestPool _SupplyRequestPool { get; set; }
        public TTObjectClasses.SupplyRequestPoolDetail[] SupplyRequestPoolDetailsGridList { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}
