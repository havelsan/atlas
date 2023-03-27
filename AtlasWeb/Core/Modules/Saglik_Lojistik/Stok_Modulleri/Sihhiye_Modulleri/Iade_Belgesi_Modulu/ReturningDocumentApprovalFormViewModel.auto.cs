﻿//$4FDDDE81
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
    public partial class ReturningDocumentServiceController : Controller
{
    [HttpGet]
    public ReturningDocumentApprovalFormViewModel ReturningDocumentApprovalForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ReturningDocumentApprovalFormLoadInternal(input);
    }

    [HttpPost]
    public ReturningDocumentApprovalFormViewModel ReturningDocumentApprovalFormLoad(FormLoadInput input)
    {
        return ReturningDocumentApprovalFormLoadInternal(input);
    }

    private ReturningDocumentApprovalFormViewModel ReturningDocumentApprovalFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("ea46989a-8caf-4fcd-86d9-02c75c70d806");
        var objectDefID = Guid.Parse("ca3f49f3-f0ed-449c-a31a-32534effc1d0");
        var viewModel = new ReturningDocumentApprovalFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ReturningDocument = objectContext.GetObject(id.Value, objectDefID) as ReturningDocument;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ReturningDocument, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ReturningDocument, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ReturningDocument);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ReturningDocument);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ReturningDocumentApprovalForm(viewModel, viewModel._ReturningDocument, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ReturningDocumentApprovalForm(ReturningDocumentApprovalFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("ea46989a-8caf-4fcd-86d9-02c75c70d806");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
            objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
            objectContext.AddToRawObjectList(viewModel.StockActionOutDetailsGridList);
            objectContext.AddToRawObjectList(viewModel._ReturningDocument);
            objectContext.ProcessRawObjects();
            var returningDocument = (ReturningDocument)objectContext.GetLoadedObject(viewModel._ReturningDocument.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(returningDocument, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ReturningDocument, formDefID);
            if (viewModel.StockActionSignDetailsGridList != null)
            {
                foreach (var item in viewModel.StockActionSignDetailsGridList)
                {
                    var stockActionSignDetailsImported = (StockActionSignDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)stockActionSignDetailsImported).IsDeleted)
                        continue;
                    stockActionSignDetailsImported.StockAction = returningDocument;
                }
            }

            if (viewModel.StockActionOutDetailsGridList != null)
            {
                foreach (var item in viewModel.StockActionOutDetailsGridList)
                {
                    var returningDocumentMaterialsImported = (ReturningDocumentMaterial)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)returningDocumentMaterialsImported).IsDeleted)
                        continue;
                    returningDocumentMaterialsImported.StockAction = returningDocument;
                }
            }

            var transDef = returningDocument.TransDef;
            PostScript_ReturningDocumentApprovalForm(viewModel, returningDocument, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(returningDocument);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(returningDocument);
            AfterContextSaveScript_ReturningDocumentApprovalForm(viewModel, returningDocument, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_ReturningDocumentApprovalForm(ReturningDocumentApprovalFormViewModel viewModel, ReturningDocument returningDocument, TTObjectContext objectContext);
    partial void PostScript_ReturningDocumentApprovalForm(ReturningDocumentApprovalFormViewModel viewModel, ReturningDocument returningDocument, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ReturningDocumentApprovalForm(ReturningDocumentApprovalFormViewModel viewModel, ReturningDocument returningDocument, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ReturningDocumentApprovalFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.StockActionSignDetailsGridList = viewModel._ReturningDocument.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
        viewModel.StockActionOutDetailsGridList = viewModel._ReturningDocument.ReturningDocumentMaterials.OfType<ReturningDocumentMaterial>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SubStoreList", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreList", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StockLevelTypeList", viewModel.StockLevelTypes);
    }
}
}


namespace Core.Models
{
    public partial class ReturningDocumentApprovalFormViewModel : BaseViewModel
    {
        public TTObjectClasses.ReturningDocument _ReturningDocument { get; set; }
        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList { get; set; }
        public TTObjectClasses.ReturningDocumentMaterial[] StockActionOutDetailsGridList { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.StockLevelType[] StockLevelTypes { get; set; }
    }
}