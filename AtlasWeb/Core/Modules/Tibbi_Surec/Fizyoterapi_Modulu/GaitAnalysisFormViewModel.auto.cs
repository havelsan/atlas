//$037FF842
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
    public partial class GaitAnalysisFormServiceController : Controller
{
    [HttpGet]
    public GaitAnalysisFormViewModel GaitAnalysisForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return GaitAnalysisFormLoadInternal(input);
    }

    [HttpPost]
    public GaitAnalysisFormViewModel GaitAnalysisFormLoad(FormLoadInput input)
    {
        return GaitAnalysisFormLoadInternal(input);
    }

    private GaitAnalysisFormViewModel GaitAnalysisFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("84f5867b-6e73-42f0-ab79-17a7d810a998");
        var objectDefID = Guid.Parse("e84ee834-780e-4547-9ac0-a37c467d489b");
        var viewModel = new GaitAnalysisFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._GaitAnalysisForm = objectContext.GetObject(id.Value, objectDefID) as GaitAnalysisForm;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._GaitAnalysisForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._GaitAnalysisForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._GaitAnalysisForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._GaitAnalysisForm);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_GaitAnalysisForm(viewModel, viewModel._GaitAnalysisForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._GaitAnalysisForm = new GaitAnalysisForm(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._GaitAnalysisForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._GaitAnalysisForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._GaitAnalysisForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._GaitAnalysisForm);
                PreScript_GaitAnalysisForm(viewModel, viewModel._GaitAnalysisForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel GaitAnalysisForm(GaitAnalysisFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return GaitAnalysisFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel GaitAnalysisFormInternal(GaitAnalysisFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("84f5867b-6e73-42f0-ab79-17a7d810a998");
        objectContext.AddToRawObjectList(viewModel._GaitAnalysisForm);
        objectContext.ProcessRawObjects();
        var gaitAnalysisForm = (GaitAnalysisForm)objectContext.GetLoadedObject(viewModel._GaitAnalysisForm.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(gaitAnalysisForm, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._GaitAnalysisForm, formDefID);
        var transDef = gaitAnalysisForm.TransDef;
        PostScript_GaitAnalysisForm(viewModel, gaitAnalysisForm, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(gaitAnalysisForm);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(gaitAnalysisForm);
        AfterContextSaveScript_GaitAnalysisForm(viewModel, gaitAnalysisForm, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_GaitAnalysisForm(GaitAnalysisFormViewModel viewModel, GaitAnalysisForm gaitAnalysisForm, TTObjectContext objectContext);
    partial void PostScript_GaitAnalysisForm(GaitAnalysisFormViewModel viewModel, GaitAnalysisForm gaitAnalysisForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_GaitAnalysisForm(GaitAnalysisFormViewModel viewModel, GaitAnalysisForm gaitAnalysisForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(GaitAnalysisFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class GaitAnalysisFormViewModel 
    {
        public TTObjectClasses.GaitAnalysisForm _GaitAnalysisForm { get; set; }
    }
}
