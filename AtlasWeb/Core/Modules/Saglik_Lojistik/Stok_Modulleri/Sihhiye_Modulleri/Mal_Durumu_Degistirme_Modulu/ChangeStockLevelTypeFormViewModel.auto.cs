//$3EC5EA97
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
    public partial class ChangeStockLevelTypeServiceController : Controller
{
    [HttpGet]
    public ChangeStockLevelTypeFormViewModel ChangeStockLevelTypeForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ChangeStockLevelTypeFormLoadInternal(input);
    }

    [HttpPost]
    public ChangeStockLevelTypeFormViewModel ChangeStockLevelTypeFormLoad(FormLoadInput input)
    {
        return ChangeStockLevelTypeFormLoadInternal(input);
    }

    private ChangeStockLevelTypeFormViewModel ChangeStockLevelTypeFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("04ed20ff-062d-4103-8ff0-29b96063c6d5");
        var objectDefID = Guid.Parse("a8bbbf58-e46b-4826-be2d-7271ba270b81");
        var viewModel = new ChangeStockLevelTypeFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ChangeStockLevelType = objectContext.GetObject(id.Value, objectDefID) as ChangeStockLevelType;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ChangeStockLevelType, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChangeStockLevelType, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ChangeStockLevelType);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ChangeStockLevelType);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ChangeStockLevelTypeForm(viewModel, viewModel._ChangeStockLevelType, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ChangeStockLevelType = new ChangeStockLevelType(objectContext);
                var entryStateID = Guid.Parse("bec09a6c-88d8-4269-a3bc-9dc14ba215d0");
                viewModel._ChangeStockLevelType.CurrentStateDefID = entryStateID;
                viewModel.MaterialDetailsGridList = new TTObjectClasses.ChangeStockLevelTypeDetail[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ChangeStockLevelType, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChangeStockLevelType, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ChangeStockLevelType);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ChangeStockLevelType);
                PreScript_ChangeStockLevelTypeForm(viewModel, viewModel._ChangeStockLevelType, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ChangeStockLevelTypeForm(ChangeStockLevelTypeFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("04ed20ff-062d-4103-8ff0-29b96063c6d5");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
            objectContext.AddToRawObjectList(viewModel.BudgetTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.MaterialDetailsGridList);
            var entryStateID = Guid.Parse("bec09a6c-88d8-4269-a3bc-9dc14ba215d0");
            objectContext.AddToRawObjectList(viewModel._ChangeStockLevelType, entryStateID);
            objectContext.ProcessRawObjects(false);
            var changeStockLevelType = (ChangeStockLevelType)objectContext.GetLoadedObject(viewModel._ChangeStockLevelType.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(changeStockLevelType, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChangeStockLevelType, formDefID);
            if (viewModel.MaterialDetailsGridList != null)
            {
                foreach (var item in viewModel.MaterialDetailsGridList)
                {
                    var changeStockLevelTypeDetailsImported = (ChangeStockLevelTypeDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)changeStockLevelTypeDetailsImported).IsDeleted)
                        continue;
                    changeStockLevelTypeDetailsImported.ChangeStockLevelType = changeStockLevelType;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(changeStockLevelType);
            PostScript_ChangeStockLevelTypeForm(viewModel, changeStockLevelType, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(changeStockLevelType);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(changeStockLevelType);
            AfterContextSaveScript_ChangeStockLevelTypeForm(viewModel, changeStockLevelType, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_ChangeStockLevelTypeForm(ChangeStockLevelTypeFormViewModel viewModel, ChangeStockLevelType changeStockLevelType, TTObjectContext objectContext);
    partial void PostScript_ChangeStockLevelTypeForm(ChangeStockLevelTypeFormViewModel viewModel, ChangeStockLevelType changeStockLevelType, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ChangeStockLevelTypeForm(ChangeStockLevelTypeFormViewModel viewModel, ChangeStockLevelType changeStockLevelType, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ChangeStockLevelTypeFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.MaterialDetailsGridList = viewModel._ChangeStockLevelType.ChangeStockLevelTypeDetails.OfType<ChangeStockLevelTypeDetail>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
        viewModel.BudgetTypeDefinitions = objectContext.LocalQuery<BudgetTypeDefinition>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StockLevelTypeList", viewModel.StockLevelTypes);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BugdetTypeList", viewModel.BudgetTypeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreList", viewModel.Stores);
    }
}
}


namespace Core.Models
{
    public partial class ChangeStockLevelTypeFormViewModel : BaseViewModel
    {
        public TTObjectClasses.ChangeStockLevelType _ChangeStockLevelType { get; set; }
        public TTObjectClasses.ChangeStockLevelTypeDetail[] MaterialDetailsGridList { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.StockLevelType[] StockLevelTypes { get; set; }
        public TTObjectClasses.BudgetTypeDefinition[] BudgetTypeDefinitions { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
    }
}
