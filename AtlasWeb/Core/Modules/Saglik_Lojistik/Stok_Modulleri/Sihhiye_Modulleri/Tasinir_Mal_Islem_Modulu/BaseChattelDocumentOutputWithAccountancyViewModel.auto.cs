//$28E5779A
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
    public partial class ChattelDocumentOutputWithAccountancyServiceController : Controller
{
    [HttpGet]
    public BaseChattelDocumentOutputWithAccountancyViewModel BaseChattelDocumentOutputWithAccountancy(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BaseChattelDocumentOutputWithAccountancyLoadInternal(input);
    }

    [HttpPost]
    public BaseChattelDocumentOutputWithAccountancyViewModel BaseChattelDocumentOutputWithAccountancyLoad(FormLoadInput input)
    {
        return BaseChattelDocumentOutputWithAccountancyLoadInternal(input);
    }

    private BaseChattelDocumentOutputWithAccountancyViewModel BaseChattelDocumentOutputWithAccountancyLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("59d03608-d3d0-48e4-a781-59a199ca1ac8");
        var objectDefID = Guid.Parse("a7a40ea6-57ac-4181-a185-99f9f81e630f");
        var viewModel = new BaseChattelDocumentOutputWithAccountancyViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ChattelDocumentOutputWithAccountancy = objectContext.GetObject(id.Value, objectDefID) as ChattelDocumentOutputWithAccountancy;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ChattelDocumentOutputWithAccountancy, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChattelDocumentOutputWithAccountancy, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ChattelDocumentOutputWithAccountancy);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ChattelDocumentOutputWithAccountancy);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BaseChattelDocumentOutputWithAccountancy(viewModel, viewModel._ChattelDocumentOutputWithAccountancy, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BaseChattelDocumentOutputWithAccountancy(BaseChattelDocumentOutputWithAccountancyViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("59d03608-d3d0-48e4-a781-59a199ca1ac8");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
            objectContext.AddToRawObjectList(viewModel.Accountancys);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.ChattelDocumentDetailsWithAccountancyGridList);
            objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
            objectContext.AddToRawObjectList(viewModel._ChattelDocumentOutputWithAccountancy);
            objectContext.ProcessRawObjects();
            var chattelDocumentOutputWithAccountancy = (ChattelDocumentOutputWithAccountancy)objectContext.GetLoadedObject(viewModel._ChattelDocumentOutputWithAccountancy.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(chattelDocumentOutputWithAccountancy, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChattelDocumentOutputWithAccountancy, formDefID);
            if (viewModel.ChattelDocumentDetailsWithAccountancyGridList != null)
            {
                foreach (var item in viewModel.ChattelDocumentDetailsWithAccountancyGridList)
                {
                    var chattelDocumentOutputDetailsWithAccountancyImported = (ChattelDocumentOutputDetailWithAccountancy)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)chattelDocumentOutputDetailsWithAccountancyImported).IsDeleted)
                        continue;
                    chattelDocumentOutputDetailsWithAccountancyImported.StockAction = chattelDocumentOutputWithAccountancy;
                }
            }

            if (viewModel.StockActionSignDetailsGridList != null)
            {
                foreach (var item in viewModel.StockActionSignDetailsGridList)
                {
                    var stockActionSignDetailsImported = (StockActionSignDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)stockActionSignDetailsImported).IsDeleted)
                        continue;
                    stockActionSignDetailsImported.StockAction = chattelDocumentOutputWithAccountancy;
                }
            }

            var transDef = chattelDocumentOutputWithAccountancy.TransDef;
            PostScript_BaseChattelDocumentOutputWithAccountancy(viewModel, chattelDocumentOutputWithAccountancy, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(chattelDocumentOutputWithAccountancy);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(chattelDocumentOutputWithAccountancy);
            AfterContextSaveScript_BaseChattelDocumentOutputWithAccountancy(viewModel, chattelDocumentOutputWithAccountancy, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_BaseChattelDocumentOutputWithAccountancy(BaseChattelDocumentOutputWithAccountancyViewModel viewModel, ChattelDocumentOutputWithAccountancy chattelDocumentOutputWithAccountancy, TTObjectContext objectContext);
    partial void PostScript_BaseChattelDocumentOutputWithAccountancy(BaseChattelDocumentOutputWithAccountancyViewModel viewModel, ChattelDocumentOutputWithAccountancy chattelDocumentOutputWithAccountancy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BaseChattelDocumentOutputWithAccountancy(BaseChattelDocumentOutputWithAccountancyViewModel viewModel, ChattelDocumentOutputWithAccountancy chattelDocumentOutputWithAccountancy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BaseChattelDocumentOutputWithAccountancyViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ChattelDocumentDetailsWithAccountancyGridList = viewModel._ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputDetailsWithAccountancy.OfType<ChattelDocumentOutputDetailWithAccountancy>().ToArray();
        viewModel.StockActionSignDetailsGridList = viewModel._ChattelDocumentOutputWithAccountancy.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
        viewModel.Accountancys = objectContext.LocalQuery<Accountancy>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreList", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StockLevelTypeList", viewModel.StockLevelTypes);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AccountancyList", viewModel.Accountancys);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class BaseChattelDocumentOutputWithAccountancyViewModel : BaseViewModel
    {
        public TTObjectClasses.ChattelDocumentOutputWithAccountancy _ChattelDocumentOutputWithAccountancy { get; set; }
        public TTObjectClasses.ChattelDocumentOutputDetailWithAccountancy[] ChattelDocumentDetailsWithAccountancyGridList { get; set; }
        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.StockLevelType[] StockLevelTypes { get; set; }
        public TTObjectClasses.Accountancy[] Accountancys { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}
