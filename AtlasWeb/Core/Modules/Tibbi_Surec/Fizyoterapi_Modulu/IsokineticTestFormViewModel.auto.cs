//$74088902
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
    public partial class IsokineticTestFormServiceController : Controller
{
    [HttpGet]
    public IsokineticTestFormViewModel IsokineticTestForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return IsokineticTestFormLoadInternal(input);
    }

    [HttpPost]
    public IsokineticTestFormViewModel IsokineticTestFormLoad(FormLoadInput input)
    {
        return IsokineticTestFormLoadInternal(input);
    }

    private IsokineticTestFormViewModel IsokineticTestFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("2e7202cc-2ec0-4622-8964-7d83bfb6b217");
        var objectDefID = Guid.Parse("0f2d64fd-26c1-4802-8552-cac1ac52dcfc");
        var viewModel = new IsokineticTestFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._IsokineticTestForm = objectContext.GetObject(id.Value, objectDefID) as IsokineticTestForm;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._IsokineticTestForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._IsokineticTestForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._IsokineticTestForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._IsokineticTestForm);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_IsokineticTestForm(viewModel, viewModel._IsokineticTestForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._IsokineticTestForm = new IsokineticTestForm(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._IsokineticTestForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._IsokineticTestForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._IsokineticTestForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._IsokineticTestForm);
                PreScript_IsokineticTestForm(viewModel, viewModel._IsokineticTestForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel IsokineticTestForm(IsokineticTestFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return IsokineticTestFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel IsokineticTestFormInternal(IsokineticTestFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("2e7202cc-2ec0-4622-8964-7d83bfb6b217");
        objectContext.AddToRawObjectList(viewModel._IsokineticTestForm);
        objectContext.ProcessRawObjects();
        var isokineticTestForm = (IsokineticTestForm)objectContext.GetLoadedObject(viewModel._IsokineticTestForm.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(isokineticTestForm, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._IsokineticTestForm, formDefID);
        var transDef = isokineticTestForm.TransDef;
        PostScript_IsokineticTestForm(viewModel, isokineticTestForm, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(isokineticTestForm);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(isokineticTestForm);
        AfterContextSaveScript_IsokineticTestForm(viewModel, isokineticTestForm, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_IsokineticTestForm(IsokineticTestFormViewModel viewModel, IsokineticTestForm isokineticTestForm, TTObjectContext objectContext);
    partial void PostScript_IsokineticTestForm(IsokineticTestFormViewModel viewModel, IsokineticTestForm isokineticTestForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_IsokineticTestForm(IsokineticTestFormViewModel viewModel, IsokineticTestForm isokineticTestForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(IsokineticTestFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class IsokineticTestFormViewModel 
    {
        public TTObjectClasses.IsokineticTestForm _IsokineticTestForm { get; set; }
    }
}
