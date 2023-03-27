//$26A53405
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
    public partial class PostureAnalysisFormServiceController : Controller
{
    [HttpGet]
    public PostureAnalysisFormViewModel PostureAnalysisForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PostureAnalysisFormLoadInternal(input);
    }

    [HttpPost]
    public PostureAnalysisFormViewModel PostureAnalysisFormLoad(FormLoadInput input)
    {
        return PostureAnalysisFormLoadInternal(input);
    }

    private PostureAnalysisFormViewModel PostureAnalysisFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("9c38b3d0-a7d6-4622-aed3-c52522450510");
        var objectDefID = Guid.Parse("4ccc1966-ba26-4dd3-80f4-746dd2985070");
        var viewModel = new PostureAnalysisFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PostureAnalysisForm = objectContext.GetObject(id.Value, objectDefID) as PostureAnalysisForm;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PostureAnalysisForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PostureAnalysisForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PostureAnalysisForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PostureAnalysisForm);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PostureAnalysisForm(viewModel, viewModel._PostureAnalysisForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PostureAnalysisForm = new PostureAnalysisForm(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PostureAnalysisForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PostureAnalysisForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PostureAnalysisForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PostureAnalysisForm);
                PreScript_PostureAnalysisForm(viewModel, viewModel._PostureAnalysisForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PostureAnalysisForm(PostureAnalysisFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return PostureAnalysisFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel PostureAnalysisFormInternal(PostureAnalysisFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("9c38b3d0-a7d6-4622-aed3-c52522450510");
        objectContext.AddToRawObjectList(viewModel._PostureAnalysisForm);
        objectContext.ProcessRawObjects();
        var postureAnalysisForm = (PostureAnalysisForm)objectContext.GetLoadedObject(viewModel._PostureAnalysisForm.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(postureAnalysisForm, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PostureAnalysisForm, formDefID);
        var transDef = postureAnalysisForm.TransDef;
        PostScript_PostureAnalysisForm(viewModel, postureAnalysisForm, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(postureAnalysisForm);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(postureAnalysisForm);
        AfterContextSaveScript_PostureAnalysisForm(viewModel, postureAnalysisForm, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_PostureAnalysisForm(PostureAnalysisFormViewModel viewModel, PostureAnalysisForm postureAnalysisForm, TTObjectContext objectContext);
    partial void PostScript_PostureAnalysisForm(PostureAnalysisFormViewModel viewModel, PostureAnalysisForm postureAnalysisForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PostureAnalysisForm(PostureAnalysisFormViewModel viewModel, PostureAnalysisForm postureAnalysisForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PostureAnalysisFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class PostureAnalysisFormViewModel 
    {
        public TTObjectClasses.PostureAnalysisForm _PostureAnalysisForm { get; set; }
    }
}
