//$67074A62
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
    public partial class ExtendExpirationDateServiceController : Controller
{
    [HttpGet]
    public ExtendExpDateCancelFormViewModel ExtendExpDateCancelForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ExtendExpDateCancelFormLoadInternal(input);
    }

    [HttpPost]
    public ExtendExpDateCancelFormViewModel ExtendExpDateCancelFormLoad(FormLoadInput input)
    {
        return ExtendExpDateCancelFormLoadInternal(input);
    }

    private ExtendExpDateCancelFormViewModel ExtendExpDateCancelFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("a488e248-29f3-499a-93fe-8f8b2792a4e9");
        var objectDefID = Guid.Parse("8d36aad0-1bbc-41d8-b3b8-aff0351fbc7a");
        var viewModel = new ExtendExpDateCancelFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ExtendExpirationDate = objectContext.GetObject(id.Value, objectDefID) as ExtendExpirationDate;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ExtendExpirationDate, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ExtendExpirationDate, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ExtendExpirationDate);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ExtendExpirationDate);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ExtendExpDateCancelForm(viewModel, viewModel._ExtendExpirationDate, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ExtendExpDateCancelForm(ExtendExpDateCancelFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("a488e248-29f3-499a-93fe-8f8b2792a4e9");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.DocumentRecordLogsGridList);
            objectContext.AddToRawObjectList(viewModel.ExtendExpirationDateDetailsGridList);
            objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
            objectContext.AddToRawObjectList(viewModel._ExtendExpirationDate);
            objectContext.ProcessRawObjects();
            var extendExpirationDate = (ExtendExpirationDate)objectContext.GetLoadedObject(viewModel._ExtendExpirationDate.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(extendExpirationDate, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ExtendExpirationDate, formDefID);
            if (viewModel.DocumentRecordLogsGridList != null)
            {
                foreach (var item in viewModel.DocumentRecordLogsGridList)
                {
                    var documentRecordLogsImported = (DocumentRecordLog)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)documentRecordLogsImported).IsDeleted)
                        continue;
                    documentRecordLogsImported.StockAction = extendExpirationDate;
                }
            }

            if (viewModel.ExtendExpirationDateDetailsGridList != null)
            {
                foreach (var item in viewModel.ExtendExpirationDateDetailsGridList)
                {
                    var extendExpirationDateDetailsImported = (ExtendExpirationDateDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)extendExpirationDateDetailsImported).IsDeleted)
                        continue;
                    extendExpirationDateDetailsImported.StockAction = extendExpirationDate;
                }
            }

            if (viewModel.StockActionSignDetailsGridList != null)
            {
                foreach (var item in viewModel.StockActionSignDetailsGridList)
                {
                    var stockActionSignDetailsImported = (StockActionSignDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)stockActionSignDetailsImported).IsDeleted)
                        continue;
                    stockActionSignDetailsImported.StockAction = extendExpirationDate;
                }
            }

            var transDef = extendExpirationDate.TransDef;
            PostScript_ExtendExpDateCancelForm(viewModel, extendExpirationDate, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(extendExpirationDate);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(extendExpirationDate);
            AfterContextSaveScript_ExtendExpDateCancelForm(viewModel, extendExpirationDate, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_ExtendExpDateCancelForm(ExtendExpDateCancelFormViewModel viewModel, ExtendExpirationDate extendExpirationDate, TTObjectContext objectContext);
    partial void PostScript_ExtendExpDateCancelForm(ExtendExpDateCancelFormViewModel viewModel, ExtendExpirationDate extendExpirationDate, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ExtendExpDateCancelForm(ExtendExpDateCancelFormViewModel viewModel, ExtendExpirationDate extendExpirationDate, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ExtendExpDateCancelFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.DocumentRecordLogsGridList = viewModel._ExtendExpirationDate.DocumentRecordLogs.OfType<DocumentRecordLog>().ToArray();
        viewModel.ExtendExpirationDateDetailsGridList = viewModel._ExtendExpirationDate.ExtendExpirationDateDetails.OfType<ExtendExpirationDateDetail>().ToArray();
        viewModel.StockActionSignDetailsGridList = viewModel._ExtendExpirationDate.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreList", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StockLevelTypeList", viewModel.StockLevelTypes);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class ExtendExpDateCancelFormViewModel : BaseViewModel
    {
        public TTObjectClasses.ExtendExpirationDate _ExtendExpirationDate { get; set; }
        public TTObjectClasses.DocumentRecordLog[] DocumentRecordLogsGridList { get; set; }
        public TTObjectClasses.ExtendExpirationDateDetail[] ExtendExpirationDateDetailsGridList { get; set; }
        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockLevelType[] StockLevelTypes { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}
