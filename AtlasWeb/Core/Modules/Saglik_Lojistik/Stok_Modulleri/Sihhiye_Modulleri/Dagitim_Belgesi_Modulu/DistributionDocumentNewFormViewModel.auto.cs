//$DD20B751
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Helpers;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class DistributionDocumentServiceController : Controller
{
    [HttpGet]
    public DistributionDocumentNewFormViewModel DistributionDocumentNewForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return DistributionDocumentNewFormLoadInternal(input);
    }

    [HttpPost]
    public DistributionDocumentNewFormViewModel DistributionDocumentNewFormLoad(FormLoadInput input)
    {
        return DistributionDocumentNewFormLoadInternal(input);
    }

    private DistributionDocumentNewFormViewModel DistributionDocumentNewFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("30aba237-9405-4619-b90e-3d8864f12608");
        var objectDefID = Guid.Parse("a06d6465-0fe8-4fb1-a0df-a62373fef8de");
        var viewModel = new DistributionDocumentNewFormViewModel();
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
                PreScript_DistributionDocumentNewForm(viewModel, viewModel._DistributionDocument, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DistributionDocument = new DistributionDocument(objectContext);
                var entryStateID = Guid.Parse("ffe9600f-a99e-47b3-bfd7-e0982076a75d");
                viewModel._DistributionDocument.CurrentStateDefID = entryStateID;
                viewModel.DistributionDocumentMaterialsGridList = new TTObjectClasses.DistributionDocumentMaterial[]{};
                viewModel.StockActionSignDetailsGridList = new TTObjectClasses.StockActionSignDetail[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DistributionDocument, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DistributionDocument, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._DistributionDocument);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._DistributionDocument);
                PreScript_DistributionDocumentNewForm(viewModel, viewModel._DistributionDocument, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel DistributionDocumentNewForm(DistributionDocumentNewFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("30aba237-9405-4619-b90e-3d8864f12608");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.DistributionDocumentMaterialsGridList);
            objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
            var entryStateID = Guid.Parse("ffe9600f-a99e-47b3-bfd7-e0982076a75d");
            objectContext.AddToRawObjectList(viewModel._DistributionDocument, entryStateID);
            objectContext.ProcessRawObjects(false);
            var distributionDocument = (DistributionDocument)objectContext.GetLoadedObject(viewModel._DistributionDocument.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(distributionDocument, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DistributionDocument, formDefID);
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

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(distributionDocument);
            PostScript_DistributionDocumentNewForm(viewModel, distributionDocument, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(distributionDocument);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(distributionDocument);
            AfterContextSaveScript_DistributionDocumentNewForm(viewModel, distributionDocument, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_DistributionDocumentNewForm(DistributionDocumentNewFormViewModel viewModel, DistributionDocument distributionDocument, TTObjectContext objectContext);
    partial void PostScript_DistributionDocumentNewForm(DistributionDocumentNewFormViewModel viewModel, DistributionDocument distributionDocument, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_DistributionDocumentNewForm(DistributionDocumentNewFormViewModel viewModel, DistributionDocument distributionDocument, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(DistributionDocumentNewFormViewModel viewModel, TTObjectContext objectContext)
    {
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

    [HttpPost]
    public List<DistributionDocument.GetUnsuccessfulDistributionDocument_Class> GetUnsuccessfulDistributionDocuments(GetUnsuccessfulDistributionDocumentsInputModel param)
    {
        using (TTObjectContext readOnlyContext = new TTObjectContext(true))
        {
            List<DistributionDocument.GetUnsuccessfulDistributionDocument_Class> unsuccessfulDistributionDocuments = DistributionDocument.GetUnsuccessfulDistributionDocument(readOnlyContext, param.StoreId).ToList();
            return unsuccessfulDistributionDocuments;
        }
    }
}
}


namespace Core.Models
{
    public partial class DistributionDocumentNewFormViewModel : BaseViewModel
    {
        public TTObjectClasses.DistributionDocument _DistributionDocument { get; set; }
        public TTObjectClasses.DistributionDocumentMaterial[] DistributionDocumentMaterialsGridList { get; set; }
        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.StockLevelType[] StockLevelTypes { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }

    public class GetUnsuccessfulDistributionDocumentsInputModel
    {
        public Guid StoreId { get; set; }
    }

}
