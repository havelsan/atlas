//$6BA70B71
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
    public partial class DeleteRecordDocumentDestroyableServiceController : Controller
{
    [HttpGet]
    public DeleteRecordDocumentDestroyableFormViewModel DeleteRecordDocumentDestroyableForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return DeleteRecordDocumentDestroyableFormLoadInternal(input);
    }

    [HttpPost]
    public DeleteRecordDocumentDestroyableFormViewModel DeleteRecordDocumentDestroyableFormLoad(FormLoadInput input)
    {
        return DeleteRecordDocumentDestroyableFormLoadInternal(input);
    }

    private DeleteRecordDocumentDestroyableFormViewModel DeleteRecordDocumentDestroyableFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("482f966d-6582-424b-a00c-4f96780e6044");
        var objectDefID = Guid.Parse("655c24fc-729d-4fe7-aae4-d6f6add7263d");
        var viewModel = new DeleteRecordDocumentDestroyableFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DeleteRecordDocumentDestroyable = objectContext.GetObject(id.Value, objectDefID) as DeleteRecordDocumentDestroyable;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DeleteRecordDocumentDestroyable, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DeleteRecordDocumentDestroyable, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DeleteRecordDocumentDestroyable);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DeleteRecordDocumentDestroyable);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_DeleteRecordDocumentDestroyableForm(viewModel, viewModel._DeleteRecordDocumentDestroyable, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DeleteRecordDocumentDestroyable = new DeleteRecordDocumentDestroyable(objectContext);
                var entryStateID = Guid.Parse("95d10948-9c0c-452c-a15f-fbe41d68c29b");
                viewModel._DeleteRecordDocumentDestroyable.CurrentStateDefID = entryStateID;
                viewModel.StockActionOutDetailsGridList = new TTObjectClasses.DeleteRecordDocumentDestroyableMaterialOut[]{};
                viewModel.StockActionSignDetailsGridList = new TTObjectClasses.StockActionSignDetail[]{};
                viewModel.StockActionInspectionDetailsStockActionInspectionDetailGridList = new TTObjectClasses.StockActionInspectionDetail[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DeleteRecordDocumentDestroyable, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DeleteRecordDocumentDestroyable, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._DeleteRecordDocumentDestroyable);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._DeleteRecordDocumentDestroyable);
                PreScript_DeleteRecordDocumentDestroyableForm(viewModel, viewModel._DeleteRecordDocumentDestroyable, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel DeleteRecordDocumentDestroyableForm(DeleteRecordDocumentDestroyableFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("482f966d-6582-424b-a00c-4f96780e6044");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.StockActionInspections);
            objectContext.AddToRawObjectList(viewModel.StockActionOutDetailsGridList);
            objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
            objectContext.AddToRawObjectList(viewModel.StockActionInspectionDetailsStockActionInspectionDetailGridList);
            var entryStateID = Guid.Parse("95d10948-9c0c-452c-a15f-fbe41d68c29b");
            objectContext.AddToRawObjectList(viewModel._DeleteRecordDocumentDestroyable, entryStateID);
            objectContext.ProcessRawObjects(false);
            var deleteRecordDocumentDestroyable = (DeleteRecordDocumentDestroyable)objectContext.GetLoadedObject(viewModel._DeleteRecordDocumentDestroyable.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(deleteRecordDocumentDestroyable, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DeleteRecordDocumentDestroyable, formDefID);
            if (viewModel.StockActionOutDetailsGridList != null)
            {
                foreach (var item in viewModel.StockActionOutDetailsGridList)
                {
                    var deleteRecordDocumentDestroyableOutMaterialsImported = (DeleteRecordDocumentDestroyableMaterialOut)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)deleteRecordDocumentDestroyableOutMaterialsImported).IsDeleted)
                        continue;
                    deleteRecordDocumentDestroyableOutMaterialsImported.StockAction = deleteRecordDocumentDestroyable;
                }
            }

            if (viewModel.StockActionSignDetailsGridList != null)
            {
                foreach (var item in viewModel.StockActionSignDetailsGridList)
                {
                    var stockActionSignDetailsImported = (StockActionSignDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)stockActionSignDetailsImported).IsDeleted)
                        continue;
                    stockActionSignDetailsImported.StockAction = deleteRecordDocumentDestroyable;
                }
            }

            var stockActionInspectionImported = deleteRecordDocumentDestroyable.StockActionInspection;
            if (stockActionInspectionImported != null)
            {
                if (viewModel.StockActionInspectionDetailsStockActionInspectionDetailGridList != null)
                {
                    foreach (var item in viewModel.StockActionInspectionDetailsStockActionInspectionDetailGridList)
                    {
                        var stockActionInspectionDetailsImported = (StockActionInspectionDetail)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)stockActionInspectionDetailsImported).IsDeleted)
                            continue;
                        stockActionInspectionDetailsImported.StockActionInspection = stockActionInspectionImported;
                    }
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(deleteRecordDocumentDestroyable);
            PostScript_DeleteRecordDocumentDestroyableForm(viewModel, deleteRecordDocumentDestroyable, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(deleteRecordDocumentDestroyable);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(deleteRecordDocumentDestroyable);
            AfterContextSaveScript_DeleteRecordDocumentDestroyableForm(viewModel, deleteRecordDocumentDestroyable, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_DeleteRecordDocumentDestroyableForm(DeleteRecordDocumentDestroyableFormViewModel viewModel, DeleteRecordDocumentDestroyable deleteRecordDocumentDestroyable, TTObjectContext objectContext);
    partial void PostScript_DeleteRecordDocumentDestroyableForm(DeleteRecordDocumentDestroyableFormViewModel viewModel, DeleteRecordDocumentDestroyable deleteRecordDocumentDestroyable, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_DeleteRecordDocumentDestroyableForm(DeleteRecordDocumentDestroyableFormViewModel viewModel, DeleteRecordDocumentDestroyable deleteRecordDocumentDestroyable, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(DeleteRecordDocumentDestroyableFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.StockActionOutDetailsGridList = viewModel._DeleteRecordDocumentDestroyable.DeleteRecordDocumentDestroyableOutMaterials.OfType<DeleteRecordDocumentDestroyableMaterialOut>().ToArray();
        viewModel.StockActionSignDetailsGridList = viewModel._DeleteRecordDocumentDestroyable.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
        var stockActionInspection = viewModel._DeleteRecordDocumentDestroyable.StockActionInspection;
        if (stockActionInspection != null)
        {
            viewModel.StockActionInspectionDetailsStockActionInspectionDetailGridList = stockActionInspection.StockActionInspectionDetails.OfType<StockActionInspectionDetail>().ToArray();
        }

        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        viewModel.StockActionInspections = objectContext.LocalQuery<StockActionInspection>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DistributionTypeList", viewModel.DistributionTypeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StockLevelTypeList", viewModel.StockLevelTypes);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreList", viewModel.Stores);
    }
}
}


namespace Core.Models
{
    public partial class DeleteRecordDocumentDestroyableFormViewModel : BaseViewModel
    {
        public TTObjectClasses.DeleteRecordDocumentDestroyable _DeleteRecordDocumentDestroyable { get; set; }
        public TTObjectClasses.DeleteRecordDocumentDestroyableMaterialOut[] StockActionOutDetailsGridList { get; set; }
        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList { get; set; }
        public TTObjectClasses.StockActionInspectionDetail[] StockActionInspectionDetailsStockActionInspectionDetailGridList { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.StockLevelType[] StockLevelTypes { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.StockActionInspection[] StockActionInspections { get; set; }
    }
}
