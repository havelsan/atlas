//$71FEF09F
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
    public CensusFixedFormStockCardRegistryFormViewModel CensusFixedFormStockCardRegistryForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return CensusFixedFormStockCardRegistryFormLoadInternal(input);
    }

    [HttpPost]
    public CensusFixedFormStockCardRegistryFormViewModel CensusFixedFormStockCardRegistryFormLoad(FormLoadInput input)
    {
        return CensusFixedFormStockCardRegistryFormLoadInternal(input);
    }

    private CensusFixedFormStockCardRegistryFormViewModel CensusFixedFormStockCardRegistryFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("90a060d9-8c23-44b3-b367-26236db126c0");
        var objectDefID = Guid.Parse("6fa99efd-e615-41a6-ae85-3eaa77d730d6");
        var viewModel = new CensusFixedFormStockCardRegistryFormViewModel();
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
                PreScript_CensusFixedFormStockCardRegistryForm(viewModel, viewModel._CensusFixed, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel CensusFixedFormStockCardRegistryForm(CensusFixedFormStockCardRegistryFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("90a060d9-8c23-44b3-b367-26236db126c0");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.BudgetTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.StockActionInDetailsGridList);
            objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
            objectContext.AddToRawObjectList(viewModel.StockActionOutDetailsGridList);
            objectContext.AddToRawObjectList(viewModel._CensusFixed);
            objectContext.ProcessRawObjects();
            var censusFixed = (CensusFixed)objectContext.GetLoadedObject(viewModel._CensusFixed.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(censusFixed, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CensusFixed, formDefID);
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
            PostScript_CensusFixedFormStockCardRegistryForm(viewModel, censusFixed, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(censusFixed);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(censusFixed);
            AfterContextSaveScript_CensusFixedFormStockCardRegistryForm(viewModel, censusFixed, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_CensusFixedFormStockCardRegistryForm(CensusFixedFormStockCardRegistryFormViewModel viewModel, CensusFixed censusFixed, TTObjectContext objectContext);
    partial void PostScript_CensusFixedFormStockCardRegistryForm(CensusFixedFormStockCardRegistryFormViewModel viewModel, CensusFixed censusFixed, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_CensusFixedFormStockCardRegistryForm(CensusFixedFormStockCardRegistryFormViewModel viewModel, CensusFixed censusFixed, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(CensusFixedFormStockCardRegistryFormViewModel viewModel, TTObjectContext objectContext)
    {
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
    public partial class CensusFixedFormStockCardRegistryFormViewModel : BaseViewModel
    {
        public TTObjectClasses.CensusFixed _CensusFixed { get; set; }
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
