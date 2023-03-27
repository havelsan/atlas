//$897B4C94
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
    public partial class ExtendExpDateOutServiceController : Controller
{
    [HttpGet]
    public ExtendExpDateOutCompFomViewModel ExtendExpDateOutCompFom(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ExtendExpDateOutCompFomLoadInternal(input);
    }

    [HttpPost]
    public ExtendExpDateOutCompFomViewModel ExtendExpDateOutCompFomLoad(FormLoadInput input)
    {
        return ExtendExpDateOutCompFomLoadInternal(input);
    }

    private ExtendExpDateOutCompFomViewModel ExtendExpDateOutCompFomLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("5af35a8f-4f1d-4d70-9b14-4d6950cecff9");
        var objectDefID = Guid.Parse("d29c4c64-3159-4e5d-bcfc-6fc0f0e84f43");
        var viewModel = new ExtendExpDateOutCompFomViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ExtendExpDateOut = objectContext.GetObject(id.Value, objectDefID) as ExtendExpDateOut;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ExtendExpDateOut, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ExtendExpDateOut, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ExtendExpDateOut);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ExtendExpDateOut);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ExtendExpDateOutCompFom(viewModel, viewModel._ExtendExpDateOut, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ExtendExpDateOutCompFom(ExtendExpDateOutCompFomViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return ExtendExpDateOutCompFomInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel ExtendExpDateOutCompFomInternal(ExtendExpDateOutCompFomViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("5af35a8f-4f1d-4d70-9b14-4d6950cecff9");
        objectContext.AddToRawObjectList(viewModel.Stores);
        objectContext.AddToRawObjectList(viewModel.Suppliers);
        objectContext.AddToRawObjectList(viewModel.Materials);
        objectContext.AddToRawObjectList(viewModel.ResUsers);
        objectContext.AddToRawObjectList(viewModel.ExtendExpDateOutDetailsGridList);
        objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
        objectContext.AddToRawObjectList(viewModel._ExtendExpDateOut);
        objectContext.ProcessRawObjects();
        var extendExpDateOut = (ExtendExpDateOut)objectContext.GetLoadedObject(viewModel._ExtendExpDateOut.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(extendExpDateOut, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ExtendExpDateOut, formDefID);
        if (viewModel.ExtendExpDateOutDetailsGridList != null)
        {
            foreach (var item in viewModel.ExtendExpDateOutDetailsGridList)
            {
                var extendExpDateOutDetailsImported = (ExtendExpDateOutDetail)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)extendExpDateOutDetailsImported).IsDeleted)
                    continue;
                extendExpDateOutDetailsImported.StockAction = extendExpDateOut;
            }
        }

        if (viewModel.StockActionSignDetailsGridList != null)
        {
            foreach (var item in viewModel.StockActionSignDetailsGridList)
            {
                var stockActionSignDetailsImported = (StockActionSignDetail)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)stockActionSignDetailsImported).IsDeleted)
                    continue;
                stockActionSignDetailsImported.StockAction = extendExpDateOut;
            }
        }

        var transDef = extendExpDateOut.TransDef;
        PostScript_ExtendExpDateOutCompFom(viewModel, extendExpDateOut, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(extendExpDateOut);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(extendExpDateOut);
        AfterContextSaveScript_ExtendExpDateOutCompFom(viewModel, extendExpDateOut, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_ExtendExpDateOutCompFom(ExtendExpDateOutCompFomViewModel viewModel, ExtendExpDateOut extendExpDateOut, TTObjectContext objectContext);
    partial void PostScript_ExtendExpDateOutCompFom(ExtendExpDateOutCompFomViewModel viewModel, ExtendExpDateOut extendExpDateOut, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ExtendExpDateOutCompFom(ExtendExpDateOutCompFomViewModel viewModel, ExtendExpDateOut extendExpDateOut, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ExtendExpDateOutCompFomViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.DocumentRecordLogsGridList = viewModel._ExtendExpDateOut.DocumentRecordLogs.OfType<DocumentRecordLog>().ToArray();
        viewModel.ExtendExpDateOutDetailsGridList = viewModel._ExtendExpDateOut.ExtendExpDateOutDetails.OfType<ExtendExpDateOutDetail>().ToArray();
        viewModel.StockActionSignDetailsGridList = viewModel._ExtendExpDateOut.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        viewModel.Suppliers = objectContext.LocalQuery<Supplier>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreList", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SupplierListDefinition", viewModel.Suppliers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class ExtendExpDateOutCompFomViewModel
    {
        public TTObjectClasses.ExtendExpDateOut _ExtendExpDateOut
        {
            get;
            set;
        }

        public TTObjectClasses.ExtendExpDateOutDetail[] ExtendExpDateOutDetailsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList
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

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }

        public TTObjectClasses.ResUser[] ResUsers
        {
            get;
            set;
        }
        public TTObjectClasses.DocumentRecordLog[] DocumentRecordLogsGridList
        {
            get;
            set;
        }
    }
}
