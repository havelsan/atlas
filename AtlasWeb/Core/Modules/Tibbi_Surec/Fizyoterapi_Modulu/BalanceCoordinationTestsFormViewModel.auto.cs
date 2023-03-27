//$91B69D83
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
    public partial class BalanceCoordinationTestsFormServiceController : Controller
{
    [HttpGet]
    public BalanceCoordinationTestsFormViewModel BalanceCoordinationTestsForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BalanceCoordinationTestsFormLoadInternal(input);
    }

    [HttpPost]
    public BalanceCoordinationTestsFormViewModel BalanceCoordinationTestsFormLoad(FormLoadInput input)
    {
        return BalanceCoordinationTestsFormLoadInternal(input);
    }

    private BalanceCoordinationTestsFormViewModel BalanceCoordinationTestsFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("eefedb53-2fcf-487e-9963-a97514e0c894");
        var objectDefID = Guid.Parse("d41c88e5-fbc9-4555-b2c7-ae6456a69cbd");
        var viewModel = new BalanceCoordinationTestsFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BalanceCoordinationTestsForm = objectContext.GetObject(id.Value, objectDefID) as BalanceCoordinationTestsForm;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BalanceCoordinationTestsForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BalanceCoordinationTestsForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BalanceCoordinationTestsForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BalanceCoordinationTestsForm);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BalanceCoordinationTestsForm(viewModel, viewModel._BalanceCoordinationTestsForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BalanceCoordinationTestsForm = new BalanceCoordinationTestsForm(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BalanceCoordinationTestsForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BalanceCoordinationTestsForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._BalanceCoordinationTestsForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._BalanceCoordinationTestsForm);
                PreScript_BalanceCoordinationTestsForm(viewModel, viewModel._BalanceCoordinationTestsForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BalanceCoordinationTestsForm(BalanceCoordinationTestsFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return BalanceCoordinationTestsFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel BalanceCoordinationTestsFormInternal(BalanceCoordinationTestsFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("eefedb53-2fcf-487e-9963-a97514e0c894");
        objectContext.AddToRawObjectList(viewModel._BalanceCoordinationTestsForm);
        objectContext.ProcessRawObjects();
        var balanceCoordinationTestsForm = (BalanceCoordinationTestsForm)objectContext.GetLoadedObject(viewModel._BalanceCoordinationTestsForm.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(balanceCoordinationTestsForm, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BalanceCoordinationTestsForm, formDefID);
        var transDef = balanceCoordinationTestsForm.TransDef;
        PostScript_BalanceCoordinationTestsForm(viewModel, balanceCoordinationTestsForm, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(balanceCoordinationTestsForm);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(balanceCoordinationTestsForm);
        AfterContextSaveScript_BalanceCoordinationTestsForm(viewModel, balanceCoordinationTestsForm, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_BalanceCoordinationTestsForm(BalanceCoordinationTestsFormViewModel viewModel, BalanceCoordinationTestsForm balanceCoordinationTestsForm, TTObjectContext objectContext);
    partial void PostScript_BalanceCoordinationTestsForm(BalanceCoordinationTestsFormViewModel viewModel, BalanceCoordinationTestsForm balanceCoordinationTestsForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BalanceCoordinationTestsForm(BalanceCoordinationTestsFormViewModel viewModel, BalanceCoordinationTestsForm balanceCoordinationTestsForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BalanceCoordinationTestsFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class BalanceCoordinationTestsFormViewModel
    {
        public TTObjectClasses.BalanceCoordinationTestsForm _BalanceCoordinationTestsForm { get; set; }
    }
}
