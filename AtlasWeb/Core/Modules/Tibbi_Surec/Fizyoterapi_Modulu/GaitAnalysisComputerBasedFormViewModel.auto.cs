//$44A33C6C
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
    public partial class GaitAnalysisComputerBasedFormServiceController : Controller
{
    [HttpGet]
    public GaitAnalysisComputerBasedFormViewModel GaitAnalysisComputerBasedForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return GaitAnalysisComputerBasedFormLoadInternal(input);
    }

    [HttpPost]
    public GaitAnalysisComputerBasedFormViewModel GaitAnalysisComputerBasedFormLoad(FormLoadInput input)
    {
        return GaitAnalysisComputerBasedFormLoadInternal(input);
    }

    private GaitAnalysisComputerBasedFormViewModel GaitAnalysisComputerBasedFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("441bc446-5d70-4f53-85d3-2c4c83b92fb8");
        var objectDefID = Guid.Parse("6f97b8b6-f7c2-4b8f-849d-4b67609b3cfa");
        var viewModel = new GaitAnalysisComputerBasedFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._GaitAnalysisComputerBasedForm = objectContext.GetObject(id.Value, objectDefID) as GaitAnalysisComputerBasedForm;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._GaitAnalysisComputerBasedForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._GaitAnalysisComputerBasedForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._GaitAnalysisComputerBasedForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._GaitAnalysisComputerBasedForm);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_GaitAnalysisComputerBasedForm(viewModel, viewModel._GaitAnalysisComputerBasedForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._GaitAnalysisComputerBasedForm = new GaitAnalysisComputerBasedForm(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._GaitAnalysisComputerBasedForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._GaitAnalysisComputerBasedForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._GaitAnalysisComputerBasedForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._GaitAnalysisComputerBasedForm);
                PreScript_GaitAnalysisComputerBasedForm(viewModel, viewModel._GaitAnalysisComputerBasedForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel GaitAnalysisComputerBasedForm(GaitAnalysisComputerBasedFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return GaitAnalysisComputerBasedFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel GaitAnalysisComputerBasedFormInternal(GaitAnalysisComputerBasedFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("441bc446-5d70-4f53-85d3-2c4c83b92fb8");
        objectContext.AddToRawObjectList(viewModel._GaitAnalysisComputerBasedForm);
        objectContext.ProcessRawObjects();
        var gaitAnalysisComputerBasedForm = (GaitAnalysisComputerBasedForm)objectContext.GetLoadedObject(viewModel._GaitAnalysisComputerBasedForm.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(gaitAnalysisComputerBasedForm, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._GaitAnalysisComputerBasedForm, formDefID);
        var transDef = gaitAnalysisComputerBasedForm.TransDef;
        PostScript_GaitAnalysisComputerBasedForm(viewModel, gaitAnalysisComputerBasedForm, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(gaitAnalysisComputerBasedForm);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(gaitAnalysisComputerBasedForm);
        AfterContextSaveScript_GaitAnalysisComputerBasedForm(viewModel, gaitAnalysisComputerBasedForm, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_GaitAnalysisComputerBasedForm(GaitAnalysisComputerBasedFormViewModel viewModel, GaitAnalysisComputerBasedForm gaitAnalysisComputerBasedForm, TTObjectContext objectContext);
    partial void PostScript_GaitAnalysisComputerBasedForm(GaitAnalysisComputerBasedFormViewModel viewModel, GaitAnalysisComputerBasedForm gaitAnalysisComputerBasedForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_GaitAnalysisComputerBasedForm(GaitAnalysisComputerBasedFormViewModel viewModel, GaitAnalysisComputerBasedForm gaitAnalysisComputerBasedForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(GaitAnalysisComputerBasedFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class GaitAnalysisComputerBasedFormViewModel 
    {
        public TTObjectClasses.GaitAnalysisComputerBasedForm _GaitAnalysisComputerBasedForm { get; set; }
    }
}
