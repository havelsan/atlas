//$B1E4B7CD
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
    public partial class DistributionDocumentServiceController : Controller
{
    [HttpGet]
    public DistributionDocumentCompletedFormViewModel DistributionDocumentCompletedForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return DistributionDocumentCompletedFormLoadInternal(input);
    }

    [HttpPost]
    public DistributionDocumentCompletedFormViewModel DistributionDocumentCompletedFormLoad(FormLoadInput input)
    {
        return DistributionDocumentCompletedFormLoadInternal(input);
    }

    private DistributionDocumentCompletedFormViewModel DistributionDocumentCompletedFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("26bbeab0-7206-4728-b0e1-24ba2239a9a4");
        var objectDefID = Guid.Parse("a06d6465-0fe8-4fb1-a0df-a62373fef8de");
        var viewModel = new DistributionDocumentCompletedFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DistributionDocument = objectContext.GetObject(id.Value, objectDefID) as DistributionDocument;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DistributionDocument, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DistributionDocument, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DistributionDocument);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DistributionDocument);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_DistributionDocumentCompletedForm(viewModel, viewModel._DistributionDocument, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel DistributionDocumentCompletedForm(DistributionDocumentCompletedFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("26bbeab0-7206-4728-b0e1-24ba2239a9a4");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.DocumentRecordLogsGridList);
            objectContext.AddToRawObjectList(viewModel.DistributionDocumentMaterialsGridList);
            objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
            objectContext.AddToRawObjectList(viewModel._DistributionDocument);
            objectContext.ProcessRawObjects();
            var distributionDocument = (DistributionDocument)objectContext.GetLoadedObject(viewModel._DistributionDocument.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(distributionDocument, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DistributionDocument, formDefID);
            if (viewModel.DocumentRecordLogsGridList != null)
            {
                foreach (var item in viewModel.DocumentRecordLogsGridList)
                {
                    var documentRecordLogsImported = (DocumentRecordLog)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)documentRecordLogsImported).IsDeleted)
                        continue;
                    documentRecordLogsImported.StockAction = distributionDocument;
                }
            }

            if (viewModel.DistributionDocumentMaterialsGridList != null)
            {
                foreach (var item in viewModel.DistributionDocumentMaterialsGridList)
                {
                    var distributionDocumentMaterialsImported = (DistributionDocumentMaterial)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)distributionDocumentMaterialsImported).IsDeleted)
                        continue;
                    distributionDocumentMaterialsImported.DistributionDocument = distributionDocument;
                }
            }

            if (viewModel.StockActionSignDetailsGridList != null)
            {
                foreach (var item in viewModel.StockActionSignDetailsGridList)
                {
                    var stockActionSignDetailsImported = (StockActionSignDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)stockActionSignDetailsImported).IsDeleted)
                        continue;
                    stockActionSignDetailsImported.StockAction = distributionDocument;
                }
            }

            var transDef = distributionDocument.TransDef;
            PostScript_DistributionDocumentCompletedForm(viewModel, distributionDocument, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(distributionDocument);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(distributionDocument);
            AfterContextSaveScript_DistributionDocumentCompletedForm(viewModel, distributionDocument, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_DistributionDocumentCompletedForm(DistributionDocumentCompletedFormViewModel viewModel, DistributionDocument distributionDocument, TTObjectContext objectContext);
    partial void PostScript_DistributionDocumentCompletedForm(DistributionDocumentCompletedFormViewModel viewModel, DistributionDocument distributionDocument, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_DistributionDocumentCompletedForm(DistributionDocumentCompletedFormViewModel viewModel, DistributionDocument distributionDocument, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(DistributionDocumentCompletedFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.DocumentRecordLogsGridList = viewModel._DistributionDocument.DocumentRecordLogs.OfType<DocumentRecordLog>().ToArray();
        viewModel.DistributionDocumentMaterialsGridList = viewModel._DistributionDocument.DistributionDocumentMaterials.OfType<DistributionDocumentMaterial>().ToArray();
        viewModel.StockActionSignDetailsGridList = viewModel._DistributionDocument.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreList", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SubStoreList", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StockLevelTypeList", viewModel.StockLevelTypes);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class DistributionDocumentCompletedFormViewModel : BaseViewModel
    {
        public TTObjectClasses.DistributionDocument _DistributionDocument { get; set; }
        public TTObjectClasses.DocumentRecordLog[] DocumentRecordLogsGridList { get; set; }
        public TTObjectClasses.DistributionDocumentMaterial[] DistributionDocumentMaterialsGridList { get; set; }
        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.StockLevelType[] StockLevelTypes { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}
