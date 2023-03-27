//$70F3DA1A
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
    public partial class StockOutServiceController : Controller
{
    [HttpGet]
    public StockOutFormViewModel StockOutForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return StockOutFormLoadInternal(input);
    }

    [HttpPost]
    public StockOutFormViewModel StockOutFormLoad(FormLoadInput input)
    {
        return StockOutFormLoadInternal(input);
    }

    private StockOutFormViewModel StockOutFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("7e973222-6f9b-494e-83e5-4f9d82895c33");
        var objectDefID = Guid.Parse("feb21778-8d8c-4af9-ae2f-a09ae2c6ed3a");
        var viewModel = new StockOutFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._StockOut = objectContext.GetObject(id.Value, objectDefID) as StockOut;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._StockOut, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._StockOut, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._StockOut);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._StockOut);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_StockOutForm(viewModel, viewModel._StockOut, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._StockOut = new StockOut(objectContext);
                var entryStateID = Guid.Parse("c50d4cfb-c8e6-4384-a295-34915fac03d0");
                viewModel._StockOut.CurrentStateDefID = entryStateID;
                viewModel.StockActionOutDetailsGridList = new TTObjectClasses.StockOutMaterial[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._StockOut, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._StockOut, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._StockOut);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._StockOut);
                PreScript_StockOutForm(viewModel, viewModel._StockOut, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel StockOutForm(StockOutFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return StockOutFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel StockOutFormInternal(StockOutFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("7e973222-6f9b-494e-83e5-4f9d82895c33");
        objectContext.AddToRawObjectList(viewModel.Materials);
        objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
        objectContext.AddToRawObjectList(viewModel.Stores);
        objectContext.AddToRawObjectList(viewModel.StockActionOutDetailsGridList);
        var entryStateID = Guid.Parse("c50d4cfb-c8e6-4384-a295-34915fac03d0");
        objectContext.AddToRawObjectList(viewModel._StockOut, entryStateID);
        objectContext.ProcessRawObjects(false);
        var stockOut = (StockOut)objectContext.GetLoadedObject(viewModel._StockOut.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(stockOut, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._StockOut, formDefID);
        if (viewModel.StockActionOutDetailsGridList != null)
        {
            foreach (var item in viewModel.StockActionOutDetailsGridList)
            {
                var stockOutMaterialsImported = (StockOutMaterial)objectContext.GetLoadedObject(item.ObjectID);
                if (((ITTObject)stockOutMaterialsImported).IsDeleted)
                    continue;
                stockOutMaterialsImported.StockAction = stockOut;
            }
        }

        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(stockOut);
        PostScript_StockOutForm(viewModel, stockOut, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(stockOut);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(stockOut);
        AfterContextSaveScript_StockOutForm(viewModel, stockOut, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_StockOutForm(StockOutFormViewModel viewModel, StockOut stockOut, TTObjectContext objectContext);
    partial void PostScript_StockOutForm(StockOutFormViewModel viewModel, StockOut stockOut, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_StockOutForm(StockOutFormViewModel viewModel, StockOut stockOut, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(StockOutFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.StockActionOutDetailsGridList = viewModel._StockOut.StockOutMaterials.OfType<StockOutMaterial>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StockLevelTypeList", viewModel.StockLevelTypes);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StoreListDefinition", viewModel.Stores);
    }
}
}


namespace Core.Models
{
    public partial class StockOutFormViewModel
    {
        public TTObjectClasses.StockOut _StockOut
        {
            get;
            set;
        }

        public TTObjectClasses.StockOutMaterial[] StockActionOutDetailsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.Material[] Materials
        {
            get;
            set;
        }

        public TTObjectClasses.StockLevelType[] StockLevelTypes
        {
            get;
            set;
        }

        public TTObjectClasses.Store[] Stores
        {
            get;
            set;
        }
    }
}
