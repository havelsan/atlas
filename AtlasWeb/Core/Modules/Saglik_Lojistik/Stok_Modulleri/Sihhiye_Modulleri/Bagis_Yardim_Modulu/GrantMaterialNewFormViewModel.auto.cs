//$72973CCF
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
    public partial class GrantMaterialServiceController : Controller
{
    [HttpGet]
    public GrantMaterialNewFormViewModel GrantMaterialNewForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return GrantMaterialNewFormLoadInternal(input);
    }

    [HttpPost]
    public GrantMaterialNewFormViewModel GrantMaterialNewFormLoad(FormLoadInput input)
    {
        return GrantMaterialNewFormLoadInternal(input);
    }

    private GrantMaterialNewFormViewModel GrantMaterialNewFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("dac77abd-d224-4488-8223-1d7e97fe1f9c");
        var objectDefID = Guid.Parse("6dfc9fd8-2488-4d88-a109-c205546f8c25");
        var viewModel = new GrantMaterialNewFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._GrantMaterial = objectContext.GetObject(id.Value, objectDefID) as GrantMaterial;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._GrantMaterial, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._GrantMaterial, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._GrantMaterial);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._GrantMaterial);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_GrantMaterialNewForm(viewModel, viewModel._GrantMaterial, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._GrantMaterial = new GrantMaterial(objectContext);
                var entryStateID = Guid.Parse("35638775-2a60-4c46-9faa-96e8ea55f3b6");
                viewModel._GrantMaterial.CurrentStateDefID = entryStateID;
                viewModel.GrantMaterialDetailsGridList = new TTObjectClasses.GrantMaterialDetail[]{};
                viewModel.StockActionSignDetailsGridList = new TTObjectClasses.StockActionSignDetail[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._GrantMaterial, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._GrantMaterial, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._GrantMaterial);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._GrantMaterial);
                PreScript_GrantMaterialNewForm(viewModel, viewModel._GrantMaterial, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel GrantMaterialNewForm(GrantMaterialNewFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("dac77abd-d224-4488-8223-1d7e97fe1f9c");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.BudgetTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.GrantMaterialDetailsGridList);
            objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
            var entryStateID = Guid.Parse("35638775-2a60-4c46-9faa-96e8ea55f3b6");
            objectContext.AddToRawObjectList(viewModel._GrantMaterial, entryStateID);
            objectContext.ProcessRawObjects(false);
            var grantMaterial = (GrantMaterial)objectContext.GetLoadedObject(viewModel._GrantMaterial.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(grantMaterial, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._GrantMaterial, formDefID);
            if (viewModel.GrantMaterialDetailsGridList != null)
            {
                foreach (var item in viewModel.GrantMaterialDetailsGridList)
                {
                    var grantMaterialDetailsImported = (GrantMaterialDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)grantMaterialDetailsImported).IsDeleted)
                        continue;
                    grantMaterialDetailsImported.StockAction = grantMaterial;
                }
            }

            if (viewModel.StockActionSignDetailsGridList != null)
            {
                foreach (var item in viewModel.StockActionSignDetailsGridList)
                {
                    var stockActionSignDetailsImported = (StockActionSignDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)stockActionSignDetailsImported).IsDeleted)
                        continue;
                    stockActionSignDetailsImported.StockAction = grantMaterial;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(grantMaterial);
            PostScript_GrantMaterialNewForm(viewModel, grantMaterial, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(grantMaterial);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(grantMaterial);
            AfterContextSaveScript_GrantMaterialNewForm(viewModel, grantMaterial, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_GrantMaterialNewForm(GrantMaterialNewFormViewModel viewModel, GrantMaterial grantMaterial, TTObjectContext objectContext);
    partial void PostScript_GrantMaterialNewForm(GrantMaterialNewFormViewModel viewModel, GrantMaterial grantMaterial, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_GrantMaterialNewForm(GrantMaterialNewFormViewModel viewModel, GrantMaterial grantMaterial, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(GrantMaterialNewFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.GrantMaterialDetailsGridList = viewModel._GrantMaterial.GrantMaterialDetails.OfType<GrantMaterialDetail>().ToArray();
        viewModel.StockActionSignDetailsGridList = viewModel._GrantMaterial.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
        viewModel.BudgetTypeDefinitions = objectContext.LocalQuery<BudgetTypeDefinition>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BugdetTypeList", viewModel.BudgetTypeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreList", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StockLevelTypeList", viewModel.StockLevelTypes);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class GrantMaterialNewFormViewModel : BaseViewModel
    {
        public TTObjectClasses.GrantMaterial _GrantMaterial { get; set; }
        public TTObjectClasses.GrantMaterialDetail[] GrantMaterialDetailsGridList { get; set; }
        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList { get; set; }
        public TTObjectClasses.BudgetTypeDefinition[] BudgetTypeDefinitions { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.StockLevelType[] StockLevelTypes { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}
