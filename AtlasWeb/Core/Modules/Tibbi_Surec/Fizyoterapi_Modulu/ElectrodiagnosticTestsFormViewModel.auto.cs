//$0654B462
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
    public partial class ElectrodiagnosticTestsServiceController : Controller
{
    [HttpGet]
    public ElectrodiagnosticTestsFormViewModel ElectrodiagnosticTestsForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ElectrodiagnosticTestsFormLoadInternal(input);
    }

    [HttpPost]
    public ElectrodiagnosticTestsFormViewModel ElectrodiagnosticTestsFormLoad(FormLoadInput input)
    {
        return ElectrodiagnosticTestsFormLoadInternal(input);
    }

    private ElectrodiagnosticTestsFormViewModel ElectrodiagnosticTestsFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("06e9392f-b214-4d7c-8abd-81b5984a8105");
        var objectDefID = Guid.Parse("ec4615ce-b945-48d5-9bfa-f62f506616dd");
        var viewModel = new ElectrodiagnosticTestsFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ElectrodiagnosticTests = objectContext.GetObject(id.Value, objectDefID) as ElectrodiagnosticTests;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ElectrodiagnosticTests, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ElectrodiagnosticTests, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ElectrodiagnosticTests);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ElectrodiagnosticTests);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ElectrodiagnosticTestsForm(viewModel, viewModel._ElectrodiagnosticTests, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ElectrodiagnosticTests = new ElectrodiagnosticTests(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ElectrodiagnosticTests, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ElectrodiagnosticTests, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ElectrodiagnosticTests);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ElectrodiagnosticTests);
                PreScript_ElectrodiagnosticTestsForm(viewModel, viewModel._ElectrodiagnosticTests, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ElectrodiagnosticTestsForm(ElectrodiagnosticTestsFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return ElectrodiagnosticTestsFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel ElectrodiagnosticTestsFormInternal(ElectrodiagnosticTestsFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("06e9392f-b214-4d7c-8abd-81b5984a8105");
        objectContext.AddToRawObjectList(viewModel._ElectrodiagnosticTests);
        objectContext.ProcessRawObjects();
        var electrodiagnosticTests = (ElectrodiagnosticTests)objectContext.GetLoadedObject(viewModel._ElectrodiagnosticTests.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(electrodiagnosticTests, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ElectrodiagnosticTests, formDefID);
        var transDef = electrodiagnosticTests.TransDef;
        PostScript_ElectrodiagnosticTestsForm(viewModel, electrodiagnosticTests, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(electrodiagnosticTests);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(electrodiagnosticTests);
        AfterContextSaveScript_ElectrodiagnosticTestsForm(viewModel, electrodiagnosticTests, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_ElectrodiagnosticTestsForm(ElectrodiagnosticTestsFormViewModel viewModel, ElectrodiagnosticTests electrodiagnosticTests, TTObjectContext objectContext);
    partial void PostScript_ElectrodiagnosticTestsForm(ElectrodiagnosticTestsFormViewModel viewModel, ElectrodiagnosticTests electrodiagnosticTests, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ElectrodiagnosticTestsForm(ElectrodiagnosticTestsFormViewModel viewModel, ElectrodiagnosticTests electrodiagnosticTests, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ElectrodiagnosticTestsFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class ElectrodiagnosticTestsFormViewModel 
    {
        public TTObjectClasses.ElectrodiagnosticTests _ElectrodiagnosticTests { get; set; }
    }
}
