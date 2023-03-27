//$39340A22
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
    public ChngeStockLvlTypeComlatedFormViewModel ChngeStockLvlTypeComlatedForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ChngeStockLvlTypeComlatedFormLoadInternal(input);
    }

    [HttpPost]
    public ChngeStockLvlTypeComlatedFormViewModel ChngeStockLvlTypeComlatedFormLoad(FormLoadInput input)
    {
        return ChngeStockLvlTypeComlatedFormLoadInternal(input);
    }

    private ChngeStockLvlTypeComlatedFormViewModel ChngeStockLvlTypeComlatedFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("73ab899b-c252-473d-ba8f-30ed79c03ae2");
        var objectDefID = Guid.Parse("a8bbbf58-e46b-4826-be2d-7271ba270b81");
        var viewModel = new ChngeStockLvlTypeComlatedFormViewModel();
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
                PreScript_ChngeStockLvlTypeComlatedForm(viewModel, viewModel._ChangeStockLevelType, objectContext);
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
                viewModel.DocumentRecordLogsGridList = new TTObjectClasses.DocumentRecordLog[]{};
                viewModel.MaterialDetailsGridList = new TTObjectClasses.ChangeStockLevelTypeDetail[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ChangeStockLevelType, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChangeStockLevelType, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ChangeStockLevelType);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ChangeStockLevelType);
                PreScript_ChngeStockLvlTypeComlatedForm(viewModel, viewModel._ChangeStockLevelType, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ChngeStockLvlTypeComlatedForm(ChngeStockLvlTypeComlatedFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("73ab899b-c252-473d-ba8f-30ed79c03ae2");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
            objectContext.AddToRawObjectList(viewModel.BudgetTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.DocumentRecordLogsGridList);
            objectContext.AddToRawObjectList(viewModel.MaterialDetailsGridList);
            var entryStateID = Guid.Parse("bec09a6c-88d8-4269-a3bc-9dc14ba215d0");
            objectContext.AddToRawObjectList(viewModel._ChangeStockLevelType, entryStateID);
            objectContext.ProcessRawObjects(false);
            var changeStockLevelType = (ChangeStockLevelType)objectContext.GetLoadedObject(viewModel._ChangeStockLevelType.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(changeStockLevelType, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChangeStockLevelType, formDefID);
            if (viewModel.DocumentRecordLogsGridList != null)
            {
                foreach (var item in viewModel.DocumentRecordLogsGridList)
                {
                    var documentRecordLogsImported = (DocumentRecordLog)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)documentRecordLogsImported).IsDeleted)
                        continue;
                    documentRecordLogsImported.StockAction = changeStockLevelType;
                }
            }

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
            PostScript_ChngeStockLvlTypeComlatedForm(viewModel, changeStockLevelType, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(changeStockLevelType);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(changeStockLevelType);
            AfterContextSaveScript_ChngeStockLvlTypeComlatedForm(viewModel, changeStockLevelType, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_ChngeStockLvlTypeComlatedForm(ChngeStockLvlTypeComlatedFormViewModel viewModel, ChangeStockLevelType changeStockLevelType, TTObjectContext objectContext);
    partial void PostScript_ChngeStockLvlTypeComlatedForm(ChngeStockLvlTypeComlatedFormViewModel viewModel, ChangeStockLevelType changeStockLevelType, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ChngeStockLvlTypeComlatedForm(ChngeStockLvlTypeComlatedFormViewModel viewModel, ChangeStockLevelType changeStockLevelType, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ChngeStockLvlTypeComlatedFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.DocumentRecordLogsGridList = viewModel._ChangeStockLevelType.DocumentRecordLogs.OfType<DocumentRecordLog>().ToArray();
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
    public partial class ChngeStockLvlTypeComlatedFormViewModel : BaseViewModel
    {
        public TTObjectClasses.ChangeStockLevelType _ChangeStockLevelType { get; set; }
        public TTObjectClasses.DocumentRecordLog[] DocumentRecordLogsGridList { get; set; }
        public TTObjectClasses.ChangeStockLevelTypeDetail[] MaterialDetailsGridList { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.StockLevelType[] StockLevelTypes { get; set; }
        public TTObjectClasses.BudgetTypeDefinition[] BudgetTypeDefinitions { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
    }
}
