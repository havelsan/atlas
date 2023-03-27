//$9169B1C4
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
    public partial class ChattelDocumentInputWithAccountancyServiceController : Controller
{
    [HttpGet]
    public ChattelDocumentInputWithAccountancyCompletedFormViewModel ChattelDocumentInputWithAccountancyCompletedForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ChattelDocumentInputWithAccountancyCompletedFormLoadInternal(input);
    }

    [HttpPost]
    public ChattelDocumentInputWithAccountancyCompletedFormViewModel ChattelDocumentInputWithAccountancyCompletedFormLoad(FormLoadInput input)
    {
        return ChattelDocumentInputWithAccountancyCompletedFormLoadInternal(input);
    }

    private ChattelDocumentInputWithAccountancyCompletedFormViewModel ChattelDocumentInputWithAccountancyCompletedFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("7c4bf011-93ce-4647-af77-f4be2c68440b");
        var objectDefID = Guid.Parse("1c5c4fc6-72e8-4c58-8d6a-21e17d1eacf3");
        var viewModel = new ChattelDocumentInputWithAccountancyCompletedFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ChattelDocumentInputWithAccountancy = objectContext.GetObject(id.Value, objectDefID) as ChattelDocumentInputWithAccountancy;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ChattelDocumentInputWithAccountancy, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChattelDocumentInputWithAccountancy, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ChattelDocumentInputWithAccountancy);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ChattelDocumentInputWithAccountancy);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ChattelDocumentInputWithAccountancyCompletedForm(viewModel, viewModel._ChattelDocumentInputWithAccountancy, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ChattelDocumentInputWithAccountancyCompletedForm(ChattelDocumentInputWithAccountancyCompletedFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("7c4bf011-93ce-4647-af77-f4be2c68440b");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.BudgetTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.Accountancys);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.Suppliers);
            objectContext.AddToRawObjectList(viewModel.DocumentRecordLogsGridList);
            objectContext.AddToRawObjectList(viewModel.ChattelDocumentDetailsWithAccountancyGridList);
            objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
            objectContext.AddToRawObjectList(viewModel._ChattelDocumentInputWithAccountancy);
            objectContext.ProcessRawObjects();
            var chattelDocumentInputWithAccountancy = (ChattelDocumentInputWithAccountancy)objectContext.GetLoadedObject(viewModel._ChattelDocumentInputWithAccountancy.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(chattelDocumentInputWithAccountancy, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChattelDocumentInputWithAccountancy, formDefID);
            if (viewModel.DocumentRecordLogsGridList != null)
            {
                foreach (var item in viewModel.DocumentRecordLogsGridList)
                {
                    var documentRecordLogsImported = (DocumentRecordLog)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)documentRecordLogsImported).IsDeleted)
                        continue;
                    documentRecordLogsImported.StockAction = chattelDocumentInputWithAccountancy;
                }
            }

            if (viewModel.ChattelDocumentDetailsWithAccountancyGridList != null)
            {
                foreach (var item in viewModel.ChattelDocumentDetailsWithAccountancyGridList)
                {
                    var chattelDocumentInputDetailsWithAccountancyImported = (ChattelDocumentInputDetailWithAccountancy)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)chattelDocumentInputDetailsWithAccountancyImported).IsDeleted)
                        continue;
                    chattelDocumentInputDetailsWithAccountancyImported.StockAction = chattelDocumentInputWithAccountancy;
                }
            }

            if (viewModel.StockActionSignDetailsGridList != null)
            {
                foreach (var item in viewModel.StockActionSignDetailsGridList)
                {
                    var stockActionSignDetailsImported = (StockActionSignDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)stockActionSignDetailsImported).IsDeleted)
                        continue;
                    stockActionSignDetailsImported.StockAction = chattelDocumentInputWithAccountancy;
                }
            }

            var transDef = chattelDocumentInputWithAccountancy.TransDef;
            PostScript_ChattelDocumentInputWithAccountancyCompletedForm(viewModel, chattelDocumentInputWithAccountancy, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(chattelDocumentInputWithAccountancy);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(chattelDocumentInputWithAccountancy);
            AfterContextSaveScript_ChattelDocumentInputWithAccountancyCompletedForm(viewModel, chattelDocumentInputWithAccountancy, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_ChattelDocumentInputWithAccountancyCompletedForm(ChattelDocumentInputWithAccountancyCompletedFormViewModel viewModel, ChattelDocumentInputWithAccountancy chattelDocumentInputWithAccountancy, TTObjectContext objectContext);
    partial void PostScript_ChattelDocumentInputWithAccountancyCompletedForm(ChattelDocumentInputWithAccountancyCompletedFormViewModel viewModel, ChattelDocumentInputWithAccountancy chattelDocumentInputWithAccountancy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ChattelDocumentInputWithAccountancyCompletedForm(ChattelDocumentInputWithAccountancyCompletedFormViewModel viewModel, ChattelDocumentInputWithAccountancy chattelDocumentInputWithAccountancy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ChattelDocumentInputWithAccountancyCompletedFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.DocumentRecordLogsGridList = viewModel._ChattelDocumentInputWithAccountancy.DocumentRecordLogs.OfType<DocumentRecordLog>().ToArray();
        viewModel.ChattelDocumentDetailsWithAccountancyGridList = viewModel._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy.OfType<ChattelDocumentInputDetailWithAccountancy>().ToArray();
        viewModel.StockActionSignDetailsGridList = viewModel._ChattelDocumentInputWithAccountancy.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
        viewModel.BudgetTypeDefinitions = objectContext.LocalQuery<BudgetTypeDefinition>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        viewModel.Accountancys = objectContext.LocalQuery<Accountancy>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        WorkAroundSolutionForObjectLoad(viewModel.ChattelDocumentDetailsWithAccountancyGridList); // Work Around bir çözüm bu, lazt loading oldugu için supplier yüklenmiyor.
        viewModel.Suppliers = objectContext.LocalQuery<Supplier>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BugdetTypeList", viewModel.BudgetTypeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreDefinitionList", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AccountancyList", viewModel.Accountancys);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StockLevelTypeList", viewModel.StockLevelTypes);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SupplierListDefinition", viewModel.Suppliers);
    }
}
}


namespace Core.Models
{
    public partial class ChattelDocumentInputWithAccountancyCompletedFormViewModel : BaseViewModel
    {
        public TTObjectClasses.ChattelDocumentInputWithAccountancy _ChattelDocumentInputWithAccountancy { get; set; }
        public TTObjectClasses.DocumentRecordLog[] DocumentRecordLogsGridList { get; set; }
        public TTObjectClasses.ChattelDocumentInputDetailWithAccountancy[] ChattelDocumentDetailsWithAccountancyGridList { get; set; }
        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList { get; set; }
        public TTObjectClasses.BudgetTypeDefinition[] BudgetTypeDefinitions { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.Accountancy[] Accountancys { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.StockLevelType[] StockLevelTypes { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.Supplier[] Suppliers { get; set; }

    }
}
