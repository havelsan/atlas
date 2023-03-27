//$1D798E06
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
    public partial class MagistralPreparationActionServiceController : Controller
{
    [HttpGet]
    public MagistralPreparationActionCompletedFormViewModel MagistralPreparationActionCompletedForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return MagistralPreparationActionCompletedFormLoadInternal(input);
    }

    [HttpPost]
    public MagistralPreparationActionCompletedFormViewModel MagistralPreparationActionCompletedFormLoad(FormLoadInput input)
    {
        return MagistralPreparationActionCompletedFormLoadInternal(input);
    }

    private MagistralPreparationActionCompletedFormViewModel MagistralPreparationActionCompletedFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("bc9fd24b-0e24-4a27-acf9-d3ac040fc238");
        var objectDefID = Guid.Parse("8a5a2efe-170e-49a9-becb-0fa3af9969e7");
        var viewModel = new MagistralPreparationActionCompletedFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._MagistralPreparationAction = objectContext.GetObject(id.Value, objectDefID) as MagistralPreparationAction;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MagistralPreparationAction, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MagistralPreparationAction, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._MagistralPreparationAction);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._MagistralPreparationAction);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_MagistralPreparationActionCompletedForm(viewModel, viewModel._MagistralPreparationAction, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel MagistralPreparationActionCompletedForm(MagistralPreparationActionCompletedFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("bc9fd24b-0e24-4a27-acf9-d3ac040fc238");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.DrugDefinitions);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.MagistralChemicalDefinitions);
            objectContext.AddToRawObjectList(viewModel.ConsumableMaterialDefinitions);
            objectContext.AddToRawObjectList(viewModel.MagistralPreparationDefinitions);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.MagistralPackagingTypes);
            objectContext.AddToRawObjectList(viewModel.MagistralPackagingSubTypes);
            objectContext.AddToRawObjectList(viewModel.MagistralPreparationSubTypes);
            objectContext.AddToRawObjectList(viewModel.MagistralPreparationTypes);
            objectContext.AddToRawObjectList(viewModel.MagistralPreparationUsedDrugsGridList);
            objectContext.AddToRawObjectList(viewModel.MagistralPreparationUsedChemicalsGridList);
            objectContext.AddToRawObjectList(viewModel.MagistralPreparationUsedMaterialsGridList);
            objectContext.AddToRawObjectList(viewModel.MagistralPreparationDetailsGridList);
            objectContext.AddToRawObjectList(viewModel.StockActionDetailsGridList);
            objectContext.AddToRawObjectList(viewModel._MagistralPreparationAction);
            objectContext.ProcessRawObjects();
            var magistralPreparationAction = (MagistralPreparationAction)objectContext.GetLoadedObject(viewModel._MagistralPreparationAction.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(magistralPreparationAction, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MagistralPreparationAction, formDefID);
            if (viewModel.MagistralPreparationUsedDrugsGridList != null)
            {
                foreach (var item in viewModel.MagistralPreparationUsedDrugsGridList)
                {
                    var magistralPreparationUsedDrugsImported = (MagistralPreparationUsedDrug)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)magistralPreparationUsedDrugsImported).IsDeleted)
                        continue;
                    magistralPreparationUsedDrugsImported.MagistralPreparationAction = magistralPreparationAction;
                }
            }

            if (viewModel.MagistralPreparationUsedChemicalsGridList != null)
            {
                foreach (var item in viewModel.MagistralPreparationUsedChemicalsGridList)
                {
                    var magistralPreparationUsedChemicalsImported = (MagistralPreparationUsedChemical)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)magistralPreparationUsedChemicalsImported).IsDeleted)
                        continue;
                    magistralPreparationUsedChemicalsImported.MagistralPreparationAction = magistralPreparationAction;
                }
            }

            if (viewModel.MagistralPreparationUsedMaterialsGridList != null)
            {
                foreach (var item in viewModel.MagistralPreparationUsedMaterialsGridList)
                {
                    var magistralPreparationUsedMaterialsImported = (MagistralPreparationUsedMaterial)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)magistralPreparationUsedMaterialsImported).IsDeleted)
                        continue;
                    magistralPreparationUsedMaterialsImported.MagistralPreparationAction = magistralPreparationAction;
                }
            }

            if (viewModel.MagistralPreparationDetailsGridList != null)
            {
                foreach (var item in viewModel.MagistralPreparationDetailsGridList)
                {
                    var magistralPreparationDetailsImported = (MagistralPreparationDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)magistralPreparationDetailsImported).IsDeleted)
                        continue;
                    magistralPreparationDetailsImported.MagistralPreparationAction = magistralPreparationAction;
                }
            }

            if (viewModel.StockActionDetailsGridList != null)
            {
                foreach (var item in viewModel.StockActionDetailsGridList)
                {
                    var magistralPreparationUsedDetailsImported = (MagistralPreparationUsedDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)magistralPreparationUsedDetailsImported).IsDeleted)
                        continue;
                    magistralPreparationUsedDetailsImported.StockAction = magistralPreparationAction;
                }
            }

            var transDef = magistralPreparationAction.TransDef;
            PostScript_MagistralPreparationActionCompletedForm(viewModel, magistralPreparationAction, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(magistralPreparationAction);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(magistralPreparationAction);
            AfterContextSaveScript_MagistralPreparationActionCompletedForm(viewModel, magistralPreparationAction, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_MagistralPreparationActionCompletedForm(MagistralPreparationActionCompletedFormViewModel viewModel, MagistralPreparationAction magistralPreparationAction, TTObjectContext objectContext);
    partial void PostScript_MagistralPreparationActionCompletedForm(MagistralPreparationActionCompletedFormViewModel viewModel, MagistralPreparationAction magistralPreparationAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_MagistralPreparationActionCompletedForm(MagistralPreparationActionCompletedFormViewModel viewModel, MagistralPreparationAction magistralPreparationAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(MagistralPreparationActionCompletedFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.MagistralPreparationUsedDrugsGridList = viewModel._MagistralPreparationAction.MagistralPreparationUsedDrugs.OfType<MagistralPreparationUsedDrug>().ToArray();
        viewModel.MagistralPreparationUsedChemicalsGridList = viewModel._MagistralPreparationAction.MagistralPreparationUsedChemicals.OfType<MagistralPreparationUsedChemical>().ToArray();
        viewModel.MagistralPreparationUsedMaterialsGridList = viewModel._MagistralPreparationAction.MagistralPreparationUsedMaterials.OfType<MagistralPreparationUsedMaterial>().ToArray();
        viewModel.MagistralPreparationDetailsGridList = viewModel._MagistralPreparationAction.MagistralPreparationDetails.OfType<MagistralPreparationDetail>().ToArray();
        viewModel.StockActionDetailsGridList = viewModel._MagistralPreparationAction.MagistralPreparationUsedDetails.OfType<MagistralPreparationUsedDetail>().ToArray();
        viewModel.DrugDefinitions = objectContext.LocalQuery<DrugDefinition>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.MagistralChemicalDefinitions = objectContext.LocalQuery<MagistralChemicalDefinition>().ToArray();
        viewModel.ConsumableMaterialDefinitions = objectContext.LocalQuery<ConsumableMaterialDefinition>().ToArray();
        viewModel.MagistralPreparationDefinitions = objectContext.LocalQuery<MagistralPreparationDefinition>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        viewModel.MagistralPackagingTypes = objectContext.LocalQuery<MagistralPackagingType>().ToArray();
        viewModel.MagistralPackagingSubTypes = objectContext.LocalQuery<MagistralPackagingSubType>().ToArray();
        viewModel.MagistralPreparationSubTypes = objectContext.LocalQuery<MagistralPreparationSubType>().ToArray();
        viewModel.MagistralPreparationTypes = objectContext.LocalQuery<MagistralPreparationType>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DrugList", viewModel.DrugDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DistributionTypeList", viewModel.DistributionTypeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MagistralChemicalDefinitionListDefinition", viewModel.MagistralChemicalDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ConsumableMaterialList", viewModel.ConsumableMaterialDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MagistralPreparationList", viewModel.MagistralPreparationDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StoresList", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MagistralPackagingTypeListDefinition", viewModel.MagistralPackagingTypes);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MagistralPackagingSubTypeListDefinition", viewModel.MagistralPackagingSubTypes);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MagistralPreparationSubTypeListDefinition", viewModel.MagistralPreparationSubTypes);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MagistralPreparationTypeListDefinition", viewModel.MagistralPreparationTypes);
    }
}
}


namespace Core.Models
{
    public partial class MagistralPreparationActionCompletedFormViewModel : BaseViewModel
    {
        public TTObjectClasses.MagistralPreparationAction _MagistralPreparationAction { get; set; }
        public TTObjectClasses.MagistralPreparationUsedDrug[] MagistralPreparationUsedDrugsGridList { get; set; }
        public TTObjectClasses.MagistralPreparationUsedChemical[] MagistralPreparationUsedChemicalsGridList { get; set; }
        public TTObjectClasses.MagistralPreparationUsedMaterial[] MagistralPreparationUsedMaterialsGridList { get; set; }
        public TTObjectClasses.MagistralPreparationDetail[] MagistralPreparationDetailsGridList { get; set; }
        public TTObjectClasses.MagistralPreparationUsedDetail[] StockActionDetailsGridList { get; set; }
        public TTObjectClasses.DrugDefinition[] DrugDefinitions { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.MagistralChemicalDefinition[] MagistralChemicalDefinitions { get; set; }
        public TTObjectClasses.ConsumableMaterialDefinition[] ConsumableMaterialDefinitions { get; set; }
        public TTObjectClasses.MagistralPreparationDefinition[] MagistralPreparationDefinitions { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.MagistralPackagingType[] MagistralPackagingTypes { get; set; }
        public TTObjectClasses.MagistralPackagingSubType[] MagistralPackagingSubTypes { get; set; }
        public TTObjectClasses.MagistralPreparationSubType[] MagistralPreparationSubTypes { get; set; }
        public TTObjectClasses.MagistralPreparationType[] MagistralPreparationTypes { get; set; }
    }
}
