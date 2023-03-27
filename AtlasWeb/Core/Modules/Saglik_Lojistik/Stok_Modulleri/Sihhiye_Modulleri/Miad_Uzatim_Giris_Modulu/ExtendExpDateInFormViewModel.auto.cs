//$EE6DC63B
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
    public partial class ExtendExpDateInServiceController : Controller
{
    [HttpGet]
    public ExtendExpDateInFormViewModel ExtendExpDateInForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ExtendExpDateInFormLoadInternal(input);
    }

    [HttpPost]
    public ExtendExpDateInFormViewModel ExtendExpDateInFormLoad(FormLoadInput input)
    {
        return ExtendExpDateInFormLoadInternal(input);
    }

    private ExtendExpDateInFormViewModel ExtendExpDateInFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("fb7e2f2e-f3c3-4b4c-b371-e12fa2e01622");
        var objectDefID = Guid.Parse("2fbd8835-bc61-4dd1-b98a-d003a62b4a75");
        var viewModel = new ExtendExpDateInFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ExtendExpDateIn = objectContext.GetObject(id.Value, objectDefID) as ExtendExpDateIn;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ExtendExpDateIn, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ExtendExpDateIn, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ExtendExpDateIn);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ExtendExpDateIn);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ExtendExpDateInForm(viewModel, viewModel._ExtendExpDateIn, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ExtendExpDateIn = new ExtendExpDateIn(objectContext);
                var entryStateID = Guid.Parse("3cee9917-015c-4c2c-9514-ed95ebb4c87a");
                viewModel._ExtendExpDateIn.CurrentStateDefID = entryStateID;
                viewModel.ExtendExpDateInDetailsGridList = new TTObjectClasses.ExtendExpDateInDetail[]{};
                viewModel.StockActionSignDetailsGridList = new TTObjectClasses.StockActionSignDetail[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ExtendExpDateIn, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ExtendExpDateIn, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ExtendExpDateIn);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ExtendExpDateIn);
                PreScript_ExtendExpDateInForm(viewModel, viewModel._ExtendExpDateIn, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ExtendExpDateInForm(ExtendExpDateInFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return ExtendExpDateInFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel ExtendExpDateInFormInternal(ExtendExpDateInFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("fb7e2f2e-f3c3-4b4c-b371-e12fa2e01622");
        objectContext.AddToRawObjectList(viewModel.Materials);
        objectContext.AddToRawObjectList(viewModel.BudgetTypeDefinitions);
        objectContext.AddToRawObjectList(viewModel.Stores);
        objectContext.AddToRawObjectList(viewModel.Suppliers);
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.ExtendExpDateInDetailsGridList);
        objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
        var entryStateID = Guid.Parse("3cee9917-015c-4c2c-9514-ed95ebb4c87a");
        objectContext.AddToRawObjectList(viewModel._ExtendExpDateIn, entryStateID);
        objectContext.ProcessRawObjects(false);
        var extendExpDateIn = (ExtendExpDateIn)objectContext.GetLoadedObject(viewModel._ExtendExpDateIn.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(extendExpDateIn, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ExtendExpDateIn, formDefID);
        if (viewModel.ExtendExpDateInDetailsGridList != null)
        {
            foreach (var item in viewModel.ExtendExpDateInDetailsGridList)
            {
                var extendExpDateInDetailsImported = (ExtendExpDateInDetail)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)extendExpDateInDetailsImported).IsDeleted)
                    continue;
                extendExpDateInDetailsImported.StockAction = extendExpDateIn;
            }
        }

        if (viewModel.StockActionSignDetailsGridList != null)
        {
            foreach (var item in viewModel.StockActionSignDetailsGridList)
            {
                var stockActionSignDetailsImported = (StockActionSignDetail)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)stockActionSignDetailsImported).IsDeleted)
                    continue;
                stockActionSignDetailsImported.StockAction = extendExpDateIn;
            }
        }

        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(extendExpDateIn);
        PostScript_ExtendExpDateInForm(viewModel, extendExpDateIn, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(extendExpDateIn);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(extendExpDateIn);
        AfterContextSaveScript_ExtendExpDateInForm(viewModel, extendExpDateIn, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_ExtendExpDateInForm(ExtendExpDateInFormViewModel viewModel, ExtendExpDateIn extendExpDateIn, TTObjectContext objectContext);
    partial void PostScript_ExtendExpDateInForm(ExtendExpDateInFormViewModel viewModel, ExtendExpDateIn extendExpDateIn, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ExtendExpDateInForm(ExtendExpDateInFormViewModel viewModel, ExtendExpDateIn extendExpDateIn, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ExtendExpDateInFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ExtendExpDateInDetailsGridList = viewModel._ExtendExpDateIn.ExtendExpDateInDetails.OfType<ExtendExpDateInDetail>().ToArray();
        viewModel.StockActionSignDetailsGridList = viewModel._ExtendExpDateIn.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.BudgetTypeDefinitions = objectContext.LocalQuery<BudgetTypeDefinition>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        viewModel.Suppliers = objectContext.LocalQuery<Supplier>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BudgetListDef", viewModel.BudgetTypeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreList", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SupplierListDefinition", viewModel.Suppliers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class ExtendExpDateInFormViewModel
    {
        public TTObjectClasses.ExtendExpDateIn _ExtendExpDateIn
        {
            get;
            set;
        }

        public TTObjectClasses.ExtendExpDateInDetail[] ExtendExpDateInDetailsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }

        public TTObjectClasses.BudgetTypeDefinition[] BudgetTypeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.Store[] Stores
        {
            get;
            set;
        }

        public TTObjectClasses.Supplier[] Suppliers
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }
    }
}
