//$C9DA1D75
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
    public partial class BaseNursingDischargingInstructionPlanServiceController : Controller
{
    [HttpGet]
    public BaseNursingDischargingInstructionPlanFormViewModel BaseNursingDischargingInstructionPlanForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BaseNursingDischargingInstructionPlanFormLoadInternal(input);
    }

    [HttpPost]
    public BaseNursingDischargingInstructionPlanFormViewModel BaseNursingDischargingInstructionPlanFormLoad(FormLoadInput input)
    {
        return BaseNursingDischargingInstructionPlanFormLoadInternal(input);
    }

    private BaseNursingDischargingInstructionPlanFormViewModel BaseNursingDischargingInstructionPlanFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("5e99cdf9-e286-49e8-a272-8b4a7eac7da3");
        var objectDefID = Guid.Parse("3e76751f-a6c9-418b-ba94-2af5167c5398");
        var viewModel = new BaseNursingDischargingInstructionPlanFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseNursingDischargingInstructionPlan = objectContext.GetObject(id.Value, objectDefID) as BaseNursingDischargingInstructionPlan;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseNursingDischargingInstructionPlan, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseNursingDischargingInstructionPlan, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BaseNursingDischargingInstructionPlan);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BaseNursingDischargingInstructionPlan);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BaseNursingDischargingInstructionPlanForm(viewModel, viewModel._BaseNursingDischargingInstructionPlan, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseNursingDischargingInstructionPlan = new BaseNursingDischargingInstructionPlan(objectContext);
                var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
                viewModel._BaseNursingDischargingInstructionPlan.CurrentStateDefID = entryStateID;
                viewModel.NursingDischargingInstructionPlansGridList = new TTObjectClasses.NursingDischargingInstructionPlan[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseNursingDischargingInstructionPlan, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseNursingDischargingInstructionPlan, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._BaseNursingDischargingInstructionPlan);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._BaseNursingDischargingInstructionPlan);
                PreScript_BaseNursingDischargingInstructionPlanForm(viewModel, viewModel._BaseNursingDischargingInstructionPlan, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BaseNursingDischargingInstructionPlanForm(BaseNursingDischargingInstructionPlanFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("5e99cdf9-e286-49e8-a272-8b4a7eac7da3");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.DischargingInstructionPlanDefinitions);
            objectContext.AddToRawObjectList(viewModel.NursingDischargingInstructionPlansGridList);
            var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
            objectContext.AddToRawObjectList(viewModel._BaseNursingDischargingInstructionPlan, entryStateID);
            objectContext.ProcessRawObjects(false);
            var baseNursingDischargingInstructionPlan = (BaseNursingDischargingInstructionPlan)objectContext.GetLoadedObject(viewModel._BaseNursingDischargingInstructionPlan.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(baseNursingDischargingInstructionPlan, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseNursingDischargingInstructionPlan, formDefID);
            if (viewModel.NursingDischargingInstructionPlansGridList != null)
            {
                foreach (var item in viewModel.NursingDischargingInstructionPlansGridList)
                {
                    var nursingDischargingInstructionPlansImported = (NursingDischargingInstructionPlan)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)nursingDischargingInstructionPlansImported).IsDeleted)
                        continue;
                    nursingDischargingInstructionPlansImported.BaseDischargingPlan = baseNursingDischargingInstructionPlan;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(baseNursingDischargingInstructionPlan);
            PostScript_BaseNursingDischargingInstructionPlanForm(viewModel, baseNursingDischargingInstructionPlan, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(baseNursingDischargingInstructionPlan);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(baseNursingDischargingInstructionPlan);
            AfterContextSaveScript_BaseNursingDischargingInstructionPlanForm(viewModel, baseNursingDischargingInstructionPlan, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_BaseNursingDischargingInstructionPlanForm(BaseNursingDischargingInstructionPlanFormViewModel viewModel, BaseNursingDischargingInstructionPlan baseNursingDischargingInstructionPlan, TTObjectContext objectContext);
    partial void PostScript_BaseNursingDischargingInstructionPlanForm(BaseNursingDischargingInstructionPlanFormViewModel viewModel, BaseNursingDischargingInstructionPlan baseNursingDischargingInstructionPlan, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BaseNursingDischargingInstructionPlanForm(BaseNursingDischargingInstructionPlanFormViewModel viewModel, BaseNursingDischargingInstructionPlan baseNursingDischargingInstructionPlan, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BaseNursingDischargingInstructionPlanFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.NursingDischargingInstructionPlansGridList = viewModel._BaseNursingDischargingInstructionPlan.NursingDischargingInstructionPlans.OfType<NursingDischargingInstructionPlan>().ToArray();
        viewModel.DischargingInstructionPlanDefinitions = objectContext.LocalQuery<DischargingInstructionPlanDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DischargingInstructionPlanListDefinition", viewModel.DischargingInstructionPlanDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class BaseNursingDischargingInstructionPlanFormViewModel : BaseViewModel
    {
        public TTObjectClasses.BaseNursingDischargingInstructionPlan _BaseNursingDischargingInstructionPlan { get; set; }
        public TTObjectClasses.NursingDischargingInstructionPlan[] NursingDischargingInstructionPlansGridList { get; set; }
        public TTObjectClasses.DischargingInstructionPlanDefinition[] DischargingInstructionPlanDefinitions { get; set; }
    }
}
