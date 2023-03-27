//$A3B86655
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
    public partial class VerbalAndPerformanceTestsServiceController : Controller
{
    [HttpGet]
    public VerbalAndPerformanceTestsFormViewModel VerbalAndPerformanceTestsForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return VerbalAndPerformanceTestsFormLoadInternal(input);
    }

    [HttpPost]
    public VerbalAndPerformanceTestsFormViewModel VerbalAndPerformanceTestsFormLoad(FormLoadInput input)
    {
        return VerbalAndPerformanceTestsFormLoadInternal(input);
    }

    private VerbalAndPerformanceTestsFormViewModel VerbalAndPerformanceTestsFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("3bdd2144-945c-4af7-86e1-86d85941087b");
        var objectDefID = Guid.Parse("97786850-2114-4548-a638-ee5f4332f5af");
        var viewModel = new VerbalAndPerformanceTestsFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._VerbalAndPerformanceTests = objectContext.GetObject(id.Value, objectDefID) as VerbalAndPerformanceTests;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._VerbalAndPerformanceTests, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._VerbalAndPerformanceTests, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._VerbalAndPerformanceTests);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._VerbalAndPerformanceTests);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_VerbalAndPerformanceTestsForm(viewModel, viewModel._VerbalAndPerformanceTests, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._VerbalAndPerformanceTests = new VerbalAndPerformanceTests(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._VerbalAndPerformanceTests, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._VerbalAndPerformanceTests, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._VerbalAndPerformanceTests);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._VerbalAndPerformanceTests);
                PreScript_VerbalAndPerformanceTestsForm(viewModel, viewModel._VerbalAndPerformanceTests, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel VerbalAndPerformanceTestsForm(VerbalAndPerformanceTestsFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("3bdd2144-945c-4af7-86e1-86d85941087b");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel._VerbalAndPerformanceTests);
            objectContext.ProcessRawObjects();
            var verbalAndPerformanceTests = (VerbalAndPerformanceTests)objectContext.GetLoadedObject(viewModel._VerbalAndPerformanceTests.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(verbalAndPerformanceTests, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._VerbalAndPerformanceTests, formDefID);
            var transDef = verbalAndPerformanceTests.TransDef;
            PostScript_VerbalAndPerformanceTestsForm(viewModel, verbalAndPerformanceTests, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(verbalAndPerformanceTests);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(verbalAndPerformanceTests);
            AfterContextSaveScript_VerbalAndPerformanceTestsForm(viewModel, verbalAndPerformanceTests, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_VerbalAndPerformanceTestsForm(VerbalAndPerformanceTestsFormViewModel viewModel, VerbalAndPerformanceTests verbalAndPerformanceTests, TTObjectContext objectContext);
    partial void PostScript_VerbalAndPerformanceTestsForm(VerbalAndPerformanceTestsFormViewModel viewModel, VerbalAndPerformanceTests verbalAndPerformanceTests, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_VerbalAndPerformanceTestsForm(VerbalAndPerformanceTestsFormViewModel viewModel, VerbalAndPerformanceTests verbalAndPerformanceTests, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(VerbalAndPerformanceTestsFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PsychologistList", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResUserDefinitionList", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class VerbalAndPerformanceTestsFormViewModel : BaseViewModel
    {
        public TTObjectClasses.VerbalAndPerformanceTests _VerbalAndPerformanceTests { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}
