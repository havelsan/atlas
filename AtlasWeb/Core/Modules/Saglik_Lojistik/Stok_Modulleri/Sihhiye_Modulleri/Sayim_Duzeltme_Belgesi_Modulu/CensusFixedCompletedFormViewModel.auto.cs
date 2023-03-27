//$21502FD9
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
    public partial class CensusFixedServiceController : Controller
{
    [HttpGet]
    public CensusFixedCompletedFormViewModel CensusFixedCompletedForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return CensusFixedCompletedFormLoadInternal(input);
    }

    [HttpPost]
    public CensusFixedCompletedFormViewModel CensusFixedCompletedFormLoad(FormLoadInput input)
    {
        return CensusFixedCompletedFormLoadInternal(input);
    }

    private CensusFixedCompletedFormViewModel CensusFixedCompletedFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("2cf09188-5e57-48e0-8322-3d725ff6a6e5");
        var objectDefID = Guid.Parse("6fa99efd-e615-41a6-ae85-3eaa77d730d6");
        var viewModel = new CensusFixedCompletedFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._CensusFixed = objectContext.GetObject(id.Value, objectDefID) as CensusFixed;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._CensusFixed, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CensusFixed, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._CensusFixed);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._CensusFixed);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_CensusFixedCompletedForm(viewModel, viewModel._CensusFixed, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel CensusFixedCompletedForm(CensusFixedCompletedFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("2cf09188-5e57-48e0-8322-3d725ff6a6e5");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.BudgetTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.DocumentRecordLogsGridList);
            objectContext.AddToRawObjectList(viewModel.StockActionInDetailsGridList);
            objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
            objectContext.AddToRawObjectList(viewModel.StockActionOutDetailsGridList);
            objectContext.AddToRawObjectList(viewModel._CensusFixed);
            objectContext.ProcessRawObjects();
            var censusFixed = (CensusFixed)objectContext.GetLoadedObject(viewModel._CensusFixed.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(censusFixed, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CensusFixed, formDefID);
            if (viewModel.DocumentRecordLogsGridList != null)
            {
                foreach (var item in viewModel.DocumentRecordLogsGridList)
                {
                    var documentRecordLogsImported = (DocumentRecordLog)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)documentRecordLogsImported).IsDeleted)
                        continue;
                    documentRecordLogsImported.StockAction = censusFixed;
                }
            }

            if (viewModel.StockActionInDetailsGridList != null)
            {
                foreach (var item in viewModel.StockActionInDetailsGridList)
                {
                    var censusFixedInMaterialsImported = (CensusFixedMaterialIn)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)censusFixedInMaterialsImported).IsDeleted)
                        continue;
                    censusFixedInMaterialsImported.CensusFixed = censusFixed;
                }
            }

            if (viewModel.StockActionSignDetailsGridList != null)
            {
                foreach (var item in viewModel.StockActionSignDetailsGridList)
                {
                    var stockActionSignDetailsImported = (StockActionSignDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)stockActionSignDetailsImported).IsDeleted)
                        continue;
                    stockActionSignDetailsImported.StockAction = censusFixed;
                }
            }

            if (viewModel.StockActionOutDetailsGridList != null)
            {
                foreach (var item in viewModel.StockActionOutDetailsGridList)
                {
                    var censusFixedOutMaterialsImported = (CensusFixedMaterialOut)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)censusFixedOutMaterialsImported).IsDeleted)
                        continue;
                    censusFixedOutMaterialsImported.CensusFixed = censusFixed;
                }
            }

            var transDef = censusFixed.TransDef;
            PostScript_CensusFixedCompletedForm(viewModel, censusFixed, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(censusFixed);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(censusFixed);
            AfterContextSaveScript_CensusFixedCompletedForm(viewModel, censusFixed, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_CensusFixedCompletedForm(CensusFixedCompletedFormViewModel viewModel, CensusFixed censusFixed, TTObjectContext objectContext);
    partial void PostScript_CensusFixedCompletedForm(CensusFixedCompletedFormViewModel viewModel, CensusFixed censusFixed, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_CensusFixedCompletedForm(CensusFixedCompletedFormViewModel viewModel, CensusFixed censusFixed, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(CensusFixedCompletedFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.DocumentRecordLogsGridList = viewModel._CensusFixed.DocumentRecordLogs.OfType<DocumentRecordLog>().ToArray();
        viewModel.StockActionInDetailsGridList = viewModel._CensusFixed.CensusFixedInMaterials.OfType<CensusFixedMaterialIn>().ToArray();
        viewModel.StockActionSignDetailsGridList = viewModel._CensusFixed.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
        viewModel.StockActionOutDetailsGridList = viewModel._CensusFixed.CensusFixedOutMaterials.OfType<CensusFixedMaterialOut>().ToArray();
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
    public partial class CensusFixedCompletedFormViewModel : BaseViewModel
    {
        public TTObjectClasses.CensusFixed _CensusFixed { get; set; }
        public TTObjectClasses.DocumentRecordLog[] DocumentRecordLogsGridList { get; set; }
        public TTObjectClasses.CensusFixedMaterialIn[] StockActionInDetailsGridList { get; set; }
        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList { get; set; }
        public TTObjectClasses.CensusFixedMaterialOut[] StockActionOutDetailsGridList { get; set; }
        public TTObjectClasses.BudgetTypeDefinition[] BudgetTypeDefinitions { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.StockLevelType[] StockLevelTypes { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}
