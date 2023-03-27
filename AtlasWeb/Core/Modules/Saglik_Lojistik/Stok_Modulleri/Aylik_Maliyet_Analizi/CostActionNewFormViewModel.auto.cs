//$E65D1190
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
    public partial class CostActionServiceController : Controller
{
    [HttpGet]
    public CostActionNewFormViewModel CostActionNewForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return CostActionNewFormLoadInternal(input);
    }

    [HttpPost]
    public CostActionNewFormViewModel CostActionNewFormLoad(FormLoadInput input)
    {
        return CostActionNewFormLoadInternal(input);
    }

    private CostActionNewFormViewModel CostActionNewFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("cf1d467b-d314-4a10-bd35-bb266bcc3cd8");
        var objectDefID = Guid.Parse("7ec5f9b5-fc7c-4b8a-8f60-9b24f7380090");
        var viewModel = new CostActionNewFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._CostAction = objectContext.GetObject(id.Value, objectDefID) as CostAction;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._CostAction, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CostAction, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._CostAction);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._CostAction);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_CostActionNewForm(viewModel, viewModel._CostAction, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._CostAction = new CostAction(objectContext);
                var entryStateID = Guid.Parse("f3200bf2-65d5-4df9-a2a6-27e95b1b7d3e");
                viewModel._CostAction.CurrentStateDefID = entryStateID;
                viewModel.CostActionMaterialsGridList = new TTObjectClasses.CostActionMaterial[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._CostAction, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CostAction, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._CostAction);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._CostAction);
                PreScript_CostActionNewForm(viewModel, viewModel._CostAction, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel CostActionNewForm(CostActionNewFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("cf1d467b-d314-4a10-bd35-bb266bcc3cd8");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.CostActionMaterialsGridList);
            var entryStateID = Guid.Parse("f3200bf2-65d5-4df9-a2a6-27e95b1b7d3e");
            objectContext.AddToRawObjectList(viewModel._CostAction, entryStateID);
            objectContext.ProcessRawObjects(false);
            var costAction = (CostAction)objectContext.GetLoadedObject(viewModel._CostAction.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(costAction, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CostAction, formDefID);
            if (viewModel.CostActionMaterialsGridList != null)
            {
                foreach (var item in viewModel.CostActionMaterialsGridList)
                {
                    var costActionMaterialsImported = (CostActionMaterial)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)costActionMaterialsImported).IsDeleted)
                        continue;
                    costActionMaterialsImported.CostAction = costAction;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(costAction);
            PostScript_CostActionNewForm(viewModel, costAction, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(costAction);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(costAction);
            AfterContextSaveScript_CostActionNewForm(viewModel, costAction, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_CostActionNewForm(CostActionNewFormViewModel viewModel, CostAction costAction, TTObjectContext objectContext);
    partial void PostScript_CostActionNewForm(CostActionNewFormViewModel viewModel, CostAction costAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_CostActionNewForm(CostActionNewFormViewModel viewModel, CostAction costAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(CostActionNewFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.CostActionMaterialsGridList = viewModel._CostAction.CostActionMaterials.OfType<CostActionMaterial>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreList", viewModel.Stores);
    }
}
}


namespace Core.Models
{
    public partial class CostActionNewFormViewModel : BaseViewModel
    {
        public TTObjectClasses.CostAction _CostAction { get; set; }
        public TTObjectClasses.CostActionMaterial[] CostActionMaterialsGridList { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
    }
}
