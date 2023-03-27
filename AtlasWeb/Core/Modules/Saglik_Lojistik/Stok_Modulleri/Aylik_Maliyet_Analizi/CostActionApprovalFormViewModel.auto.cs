//$D398FD93
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
    public CostActionApprovalFormViewModel CostActionApprovalForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return CostActionApprovalFormLoadInternal(input);
    }

    [HttpPost]
    public CostActionApprovalFormViewModel CostActionApprovalFormLoad(FormLoadInput input)
    {
        return CostActionApprovalFormLoadInternal(input);
    }

    private CostActionApprovalFormViewModel CostActionApprovalFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("e6f7ed0b-6d19-406e-941c-8a226996a201");
        var objectDefID = Guid.Parse("7ec5f9b5-fc7c-4b8a-8f60-9b24f7380090");
        var viewModel = new CostActionApprovalFormViewModel();
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
                PreScript_CostActionApprovalForm(viewModel, viewModel._CostAction, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel CostActionApprovalForm(CostActionApprovalFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("e6f7ed0b-6d19-406e-941c-8a226996a201");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.CostActionMaterialsGridList);
            objectContext.AddToRawObjectList(viewModel._CostAction);
            objectContext.ProcessRawObjects();
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
            PostScript_CostActionApprovalForm(viewModel, costAction, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(costAction);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(costAction);
            AfterContextSaveScript_CostActionApprovalForm(viewModel, costAction, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_CostActionApprovalForm(CostActionApprovalFormViewModel viewModel, CostAction costAction, TTObjectContext objectContext);
    partial void PostScript_CostActionApprovalForm(CostActionApprovalFormViewModel viewModel, CostAction costAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_CostActionApprovalForm(CostActionApprovalFormViewModel viewModel, CostAction costAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(CostActionApprovalFormViewModel viewModel, TTObjectContext objectContext)
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
    public partial class CostActionApprovalFormViewModel : BaseViewModel
    {
        public TTObjectClasses.CostAction _CostAction { get; set; }
        public TTObjectClasses.CostActionMaterial[] CostActionMaterialsGridList { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
    }
}
