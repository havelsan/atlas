//$1011B00A
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
    public partial class EarlyChildGrowthEvaluationServiceController : Controller
{
    [HttpGet]
    public EarlyChildGrowthEvalFormViewModel EarlyChildGrowthEvalForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return EarlyChildGrowthEvalFormLoadInternal(input);
    }

    [HttpPost]
    public EarlyChildGrowthEvalFormViewModel EarlyChildGrowthEvalFormLoad(FormLoadInput input)
    {
        return EarlyChildGrowthEvalFormLoadInternal(input);
    }

    private EarlyChildGrowthEvalFormViewModel EarlyChildGrowthEvalFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("84fa5396-7b7c-4550-b047-778da7aa45d8");
        var objectDefID = Guid.Parse("35f0634b-e209-4561-82f5-3fb402a7235e");
        var viewModel = new EarlyChildGrowthEvalFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._EarlyChildGrowthEvaluation = objectContext.GetObject(id.Value, objectDefID) as EarlyChildGrowthEvaluation;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._EarlyChildGrowthEvaluation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EarlyChildGrowthEvaluation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._EarlyChildGrowthEvaluation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._EarlyChildGrowthEvaluation);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_EarlyChildGrowthEvalForm(viewModel, viewModel._EarlyChildGrowthEvaluation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._EarlyChildGrowthEvaluation = new EarlyChildGrowthEvaluation(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._EarlyChildGrowthEvaluation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EarlyChildGrowthEvaluation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._EarlyChildGrowthEvaluation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._EarlyChildGrowthEvaluation);
                PreScript_EarlyChildGrowthEvalForm(viewModel, viewModel._EarlyChildGrowthEvaluation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel EarlyChildGrowthEvalForm(EarlyChildGrowthEvalFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("84fa5396-7b7c-4550-b047-778da7aa45d8");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel._EarlyChildGrowthEvaluation);
            objectContext.ProcessRawObjects();
            var earlyChildGrowthEvaluation = (EarlyChildGrowthEvaluation)objectContext.GetLoadedObject(viewModel._EarlyChildGrowthEvaluation.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(earlyChildGrowthEvaluation, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EarlyChildGrowthEvaluation, formDefID);
            var transDef = earlyChildGrowthEvaluation.TransDef;
            PostScript_EarlyChildGrowthEvalForm(viewModel, earlyChildGrowthEvaluation, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(earlyChildGrowthEvaluation);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(earlyChildGrowthEvaluation);
            AfterContextSaveScript_EarlyChildGrowthEvalForm(viewModel, earlyChildGrowthEvaluation, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_EarlyChildGrowthEvalForm(EarlyChildGrowthEvalFormViewModel viewModel, EarlyChildGrowthEvaluation earlyChildGrowthEvaluation, TTObjectContext objectContext);
    partial void PostScript_EarlyChildGrowthEvalForm(EarlyChildGrowthEvalFormViewModel viewModel, EarlyChildGrowthEvaluation earlyChildGrowthEvaluation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_EarlyChildGrowthEvalForm(EarlyChildGrowthEvalFormViewModel viewModel, EarlyChildGrowthEvaluation earlyChildGrowthEvaluation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(EarlyChildGrowthEvalFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResUserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PsychologistList", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class EarlyChildGrowthEvalFormViewModel : BaseViewModel
    {
        public TTObjectClasses.EarlyChildGrowthEvaluation _EarlyChildGrowthEvaluation { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}
