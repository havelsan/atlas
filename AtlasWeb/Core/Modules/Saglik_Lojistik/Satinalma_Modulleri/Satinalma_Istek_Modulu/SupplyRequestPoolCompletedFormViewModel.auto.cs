//$C17DCC8C
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
    public SupplyRequestPoolCompletedFormViewModel SupplyRequestPoolCompletedForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return SupplyRequestPoolCompletedFormLoadInternal(input);
    }

    [HttpPost]
    public SupplyRequestPoolCompletedFormViewModel SupplyRequestPoolCompletedFormLoad(FormLoadInput input)
    {
        return SupplyRequestPoolCompletedFormLoadInternal(input);
    }

    private SupplyRequestPoolCompletedFormViewModel SupplyRequestPoolCompletedFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("060f8425-1e04-495e-92f4-406ddec1147a");
        var objectDefID = Guid.Parse("09808ba9-c2c3-4286-96be-7d264fd2900b");
        var viewModel = new SupplyRequestPoolCompletedFormViewModel();
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
                PreScript_SupplyRequestPoolCompletedForm(viewModel, viewModel._SupplyRequestPool, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel SupplyRequestPoolCompletedForm(SupplyRequestPoolCompletedFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("060f8425-1e04-495e-92f4-406ddec1147a");
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
            PostScript_SupplyRequestPoolCompletedForm(viewModel, supplyRequestPool, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(supplyRequestPool);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(supplyRequestPool);
            AfterContextSaveScript_SupplyRequestPoolCompletedForm(viewModel, supplyRequestPool, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_SupplyRequestPoolCompletedForm(SupplyRequestPoolCompletedFormViewModel viewModel, SupplyRequestPool supplyRequestPool, TTObjectContext objectContext);
    partial void PostScript_SupplyRequestPoolCompletedForm(SupplyRequestPoolCompletedFormViewModel viewModel, SupplyRequestPool supplyRequestPool, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_SupplyRequestPoolCompletedForm(SupplyRequestPoolCompletedFormViewModel viewModel, SupplyRequestPool supplyRequestPool, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(SupplyRequestPoolCompletedFormViewModel viewModel, TTObjectContext objectContext)
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
    public partial class SupplyRequestPoolCompletedFormViewModel : BaseViewModel
    {
        public TTObjectClasses.SupplyRequestPool _SupplyRequestPool { get; set; }
        public TTObjectClasses.SupplyRequestPoolDetail[] SupplyRequestPoolDetailsGridList { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}
