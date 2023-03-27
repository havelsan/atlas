//$A75B36C7
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
    public partial class BaseDeleteRecordDocumentServiceController : Controller
{
    [HttpGet]
    public BaseDeleteRecordDocumentFormViewModel BaseDeleteRecordDocumentForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BaseDeleteRecordDocumentFormLoadInternal(input);
    }

    [HttpPost]
    public BaseDeleteRecordDocumentFormViewModel BaseDeleteRecordDocumentFormLoad(FormLoadInput input)
    {
        return BaseDeleteRecordDocumentFormLoadInternal(input);
    }

    private BaseDeleteRecordDocumentFormViewModel BaseDeleteRecordDocumentFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("86b6d111-89b6-4810-8f62-cf913464c076");
        var objectDefID = Guid.Parse("52076c33-dde0-4981-b14f-cb1b2f7f0e34");
        var viewModel = new BaseDeleteRecordDocumentFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseDeleteRecordDocument = objectContext.GetObject(id.Value, objectDefID) as BaseDeleteRecordDocument;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseDeleteRecordDocument, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseDeleteRecordDocument, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BaseDeleteRecordDocument);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BaseDeleteRecordDocument);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BaseDeleteRecordDocumentForm(viewModel, viewModel._BaseDeleteRecordDocument, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BaseDeleteRecordDocumentForm(BaseDeleteRecordDocumentFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("86b6d111-89b6-4810-8f62-cf913464c076");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.StockActionInspections);
            objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
            objectContext.AddToRawObjectList(viewModel.StockActionInspectionDetailsStockActionInspectionDetailGridList);
            objectContext.AddToRawObjectList(viewModel._BaseDeleteRecordDocument);
            objectContext.ProcessRawObjects();
            var baseDeleteRecordDocument = (BaseDeleteRecordDocument)objectContext.GetLoadedObject(viewModel._BaseDeleteRecordDocument.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(baseDeleteRecordDocument, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseDeleteRecordDocument, formDefID);
            if (viewModel.StockActionSignDetailsGridList != null)
            {
                foreach (var item in viewModel.StockActionSignDetailsGridList)
                {
                    var stockActionSignDetailsImported = (StockActionSignDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)stockActionSignDetailsImported).IsDeleted)
                        continue;
                    stockActionSignDetailsImported.StockAction = baseDeleteRecordDocument;
                }
            }

            var stockActionInspectionImported = baseDeleteRecordDocument.StockActionInspection;
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

            var transDef = baseDeleteRecordDocument.TransDef;
            PostScript_BaseDeleteRecordDocumentForm(viewModel, baseDeleteRecordDocument, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(baseDeleteRecordDocument);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(baseDeleteRecordDocument);
            AfterContextSaveScript_BaseDeleteRecordDocumentForm(viewModel, baseDeleteRecordDocument, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_BaseDeleteRecordDocumentForm(BaseDeleteRecordDocumentFormViewModel viewModel, BaseDeleteRecordDocument baseDeleteRecordDocument, TTObjectContext objectContext);
    partial void PostScript_BaseDeleteRecordDocumentForm(BaseDeleteRecordDocumentFormViewModel viewModel, BaseDeleteRecordDocument baseDeleteRecordDocument, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BaseDeleteRecordDocumentForm(BaseDeleteRecordDocumentFormViewModel viewModel, BaseDeleteRecordDocument baseDeleteRecordDocument, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BaseDeleteRecordDocumentFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.StockActionSignDetailsGridList = viewModel._BaseDeleteRecordDocument.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
        var stockActionInspection = viewModel._BaseDeleteRecordDocument.StockActionInspection;
        if (stockActionInspection != null)
        {
            viewModel.StockActionInspectionDetailsStockActionInspectionDetailGridList = stockActionInspection.StockActionInspectionDetails.OfType<StockActionInspectionDetail>().ToArray();
        }

        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        viewModel.StockActionInspections = objectContext.LocalQuery<StockActionInspection>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreList", viewModel.Stores);
    }
}
}


namespace Core.Models
{
    public partial class BaseDeleteRecordDocumentFormViewModel : BaseViewModel
    {
        public TTObjectClasses.BaseDeleteRecordDocument _BaseDeleteRecordDocument { get; set; }
        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList { get; set; }
        public TTObjectClasses.StockActionInspectionDetail[] StockActionInspectionDetailsStockActionInspectionDetailGridList { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.StockActionInspection[] StockActionInspections { get; set; }
    }
}
