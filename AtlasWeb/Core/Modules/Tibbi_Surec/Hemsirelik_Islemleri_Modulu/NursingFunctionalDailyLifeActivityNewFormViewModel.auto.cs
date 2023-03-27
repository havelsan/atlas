//$618DB11B
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
    public partial class NursingDailyLifeActivityServiceController : Controller
{
    [HttpGet]
    public NursingFunctionalDailyLifeActivityNewFormViewModel NursingFunctionalDailyLifeActivityNewForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NursingFunctionalDailyLifeActivityNewFormLoadInternal(input);
    }

    [HttpPost]
    public NursingFunctionalDailyLifeActivityNewFormViewModel NursingFunctionalDailyLifeActivityNewFormLoad(FormLoadInput input)
    {
        return NursingFunctionalDailyLifeActivityNewFormLoadInternal(input);
    }

    private NursingFunctionalDailyLifeActivityNewFormViewModel NursingFunctionalDailyLifeActivityNewFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("101415a0-3599-4b7f-a240-ba7031eeaee2");
        var objectDefID = Guid.Parse("265219b7-e5f2-49f1-a9dc-6b1173112aca");
        var viewModel = new NursingFunctionalDailyLifeActivityNewFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingDailyLifeActivity = objectContext.GetObject(id.Value, objectDefID) as NursingDailyLifeActivity;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingDailyLifeActivity, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingDailyLifeActivity, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NursingDailyLifeActivity);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NursingDailyLifeActivity);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_NursingFunctionalDailyLifeActivityNewForm(viewModel, viewModel._NursingDailyLifeActivity, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingDailyLifeActivity = new NursingDailyLifeActivity(objectContext);
                var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
                viewModel._NursingDailyLifeActivity.CurrentStateDefID = entryStateID;
                viewModel.NursingFunctionalDailyLifeActivityGridList = new TTObjectClasses.NursingFunctionalDailyLifeActivity[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingDailyLifeActivity, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingDailyLifeActivity, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._NursingDailyLifeActivity);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._NursingDailyLifeActivity);
                PreScript_NursingFunctionalDailyLifeActivityNewForm(viewModel, viewModel._NursingDailyLifeActivity, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NursingFunctionalDailyLifeActivityNewForm(NursingFunctionalDailyLifeActivityNewFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("101415a0-3599-4b7f-a240-ba7031eeaee2");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.DailyLifeActivityDefinitions);
            objectContext.AddToRawObjectList(viewModel.NursingFunctionalDailyLifeActivityGridList);
            var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
            objectContext.AddToRawObjectList(viewModel._NursingDailyLifeActivity, entryStateID);
            objectContext.ProcessRawObjects(false);
            var nursingDailyLifeActivity = (NursingDailyLifeActivity)objectContext.GetLoadedObject(viewModel._NursingDailyLifeActivity.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(nursingDailyLifeActivity, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingDailyLifeActivity, formDefID);
            if (viewModel.NursingFunctionalDailyLifeActivityGridList != null)
            {
                foreach (var item in viewModel.NursingFunctionalDailyLifeActivityGridList)
                {
                    var nursingFunctionalDailyLifeActivitiesImported = (NursingFunctionalDailyLifeActivity)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)nursingFunctionalDailyLifeActivitiesImported).IsDeleted)
                        continue;
                    nursingFunctionalDailyLifeActivitiesImported.NursingDailyLifeActivity = nursingDailyLifeActivity;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(nursingDailyLifeActivity);
            PostScript_NursingFunctionalDailyLifeActivityNewForm(viewModel, nursingDailyLifeActivity, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nursingDailyLifeActivity);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nursingDailyLifeActivity);
            AfterContextSaveScript_NursingFunctionalDailyLifeActivityNewForm(viewModel, nursingDailyLifeActivity, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_NursingFunctionalDailyLifeActivityNewForm(NursingFunctionalDailyLifeActivityNewFormViewModel viewModel, NursingDailyLifeActivity nursingDailyLifeActivity, TTObjectContext objectContext);
    partial void PostScript_NursingFunctionalDailyLifeActivityNewForm(NursingFunctionalDailyLifeActivityNewFormViewModel viewModel, NursingDailyLifeActivity nursingDailyLifeActivity, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NursingFunctionalDailyLifeActivityNewForm(NursingFunctionalDailyLifeActivityNewFormViewModel viewModel, NursingDailyLifeActivity nursingDailyLifeActivity, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NursingFunctionalDailyLifeActivityNewFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.NursingFunctionalDailyLifeActivityGridList = viewModel._NursingDailyLifeActivity.NursingFunctionalDailyLifeActivities.OfType<NursingFunctionalDailyLifeActivity>().ToArray();
        viewModel.DailyLifeActivityDefinitions = objectContext.LocalQuery<DailyLifeActivityDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "FunctionalDailyLifeActivityListDefinition", viewModel.DailyLifeActivityDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class NursingFunctionalDailyLifeActivityNewFormViewModel : BaseViewModel
    {
        public TTObjectClasses.NursingDailyLifeActivity _NursingDailyLifeActivity { get; set; }
        public TTObjectClasses.NursingFunctionalDailyLifeActivity[] NursingFunctionalDailyLifeActivityGridList { get; set; }
        public TTObjectClasses.DailyLifeActivityDefinition[] DailyLifeActivityDefinitions { get; set; }
    }
}
