//$64F532A6
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
    public partial class BaseChattelDocumentServiceController : Controller
{
    [HttpGet]
    public BaseChattelDocumentFormViewModel BaseChattelDocumentForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BaseChattelDocumentFormLoadInternal(input);
    }

    [HttpPost]
    public BaseChattelDocumentFormViewModel BaseChattelDocumentFormLoad(FormLoadInput input)
    {
        return BaseChattelDocumentFormLoadInternal(input);
    }

    private BaseChattelDocumentFormViewModel BaseChattelDocumentFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("8f386d35-8233-45a6-9e07-9b1c291e2542");
        var objectDefID = Guid.Parse("6aa611da-d3a2-4520-89ca-5508b4bfdaed");
        var viewModel = new BaseChattelDocumentFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseChattelDocument = objectContext.GetObject(id.Value, objectDefID) as BaseChattelDocument;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseChattelDocument, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseChattelDocument, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BaseChattelDocument);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BaseChattelDocument);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BaseChattelDocumentForm(viewModel, viewModel._BaseChattelDocument, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BaseChattelDocumentForm(BaseChattelDocumentFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("8f386d35-8233-45a6-9e07-9b1c291e2542");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
            objectContext.AddToRawObjectList(viewModel._BaseChattelDocument);
            objectContext.ProcessRawObjects();
            var baseChattelDocument = (BaseChattelDocument)objectContext.GetLoadedObject(viewModel._BaseChattelDocument.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(baseChattelDocument, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseChattelDocument, formDefID);
            if (viewModel.StockActionSignDetailsGridList != null)
            {
                foreach (var item in viewModel.StockActionSignDetailsGridList)
                {
                    var stockActionSignDetailsImported = (StockActionSignDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)stockActionSignDetailsImported).IsDeleted)
                        continue;
                    stockActionSignDetailsImported.StockAction = baseChattelDocument;
                }
            }

            var transDef = baseChattelDocument.TransDef;
            PostScript_BaseChattelDocumentForm(viewModel, baseChattelDocument, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(baseChattelDocument);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(baseChattelDocument);
            AfterContextSaveScript_BaseChattelDocumentForm(viewModel, baseChattelDocument, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_BaseChattelDocumentForm(BaseChattelDocumentFormViewModel viewModel, BaseChattelDocument baseChattelDocument, TTObjectContext objectContext);
    partial void PostScript_BaseChattelDocumentForm(BaseChattelDocumentFormViewModel viewModel, BaseChattelDocument baseChattelDocument, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BaseChattelDocumentForm(BaseChattelDocumentFormViewModel viewModel, BaseChattelDocument baseChattelDocument, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BaseChattelDocumentFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.StockActionSignDetailsGridList = viewModel._BaseChattelDocument.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class BaseChattelDocumentFormViewModel : BaseViewModel
    {
        public TTObjectClasses.BaseChattelDocument _BaseChattelDocument { get; set; }
        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}
