//$9C89E2D8
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
    public partial class ChildGrowthStandardsServiceController : Controller
{
    [HttpGet]
    public ChildGrowthStandardsFormViewModel ChildGrowthStandardsForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ChildGrowthStandardsFormLoadInternal(input);
    }

    [HttpPost]
    public ChildGrowthStandardsFormViewModel ChildGrowthStandardsFormLoad(FormLoadInput input)
    {
        return ChildGrowthStandardsFormLoadInternal(input);
    }

    private ChildGrowthStandardsFormViewModel ChildGrowthStandardsFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("2ac19837-3e87-414c-bc0b-4b54ca2a8332");
        var objectDefID = Guid.Parse("ce56cd5a-3ec0-4400-b68e-6452882dbbe5");
        var viewModel = new ChildGrowthStandardsFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ChildGrowthStandards = objectContext.GetObject(id.Value, objectDefID) as ChildGrowthStandards;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ChildGrowthStandards, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChildGrowthStandards, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ChildGrowthStandards);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ChildGrowthStandards);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ChildGrowthStandardsForm(viewModel, viewModel._ChildGrowthStandards, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ChildGrowthStandards = new ChildGrowthStandards(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ChildGrowthStandards, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChildGrowthStandards, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ChildGrowthStandards);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ChildGrowthStandards);
                PreScript_ChildGrowthStandardsForm(viewModel, viewModel._ChildGrowthStandards, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ChildGrowthStandardsForm(ChildGrowthStandardsFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("2ac19837-3e87-414c-bc0b-4b54ca2a8332");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._ChildGrowthStandards);
            objectContext.ProcessRawObjects();
            var childGrowthStandards = (ChildGrowthStandards)objectContext.GetLoadedObject(viewModel._ChildGrowthStandards.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(childGrowthStandards, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChildGrowthStandards, formDefID);
            var transDef = childGrowthStandards.TransDef;
            PostScript_ChildGrowthStandardsForm(viewModel, childGrowthStandards, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(childGrowthStandards);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(childGrowthStandards);
            AfterContextSaveScript_ChildGrowthStandardsForm(viewModel, childGrowthStandards, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_ChildGrowthStandardsForm(ChildGrowthStandardsFormViewModel viewModel, ChildGrowthStandards childGrowthStandards, TTObjectContext objectContext);
    partial void PostScript_ChildGrowthStandardsForm(ChildGrowthStandardsFormViewModel viewModel, ChildGrowthStandards childGrowthStandards, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ChildGrowthStandardsForm(ChildGrowthStandardsFormViewModel viewModel, ChildGrowthStandards childGrowthStandards, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ChildGrowthStandardsFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class ChildGrowthStandardsFormViewModel : BaseViewModel
    {
        public TTObjectClasses.ChildGrowthStandards _ChildGrowthStandards { get; set; }
    }
}
