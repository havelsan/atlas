//$44A0D38D
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
    public partial class MuscleTestFormServiceController : Controller
{
    [HttpGet]
    public MuscleTestFormViewModel MuscleTestForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return MuscleTestFormLoadInternal(input);
    }

    [HttpPost]
    public MuscleTestFormViewModel MuscleTestFormLoad(FormLoadInput input)
    {
        return MuscleTestFormLoadInternal(input);
    }

    private MuscleTestFormViewModel MuscleTestFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("abce9cd8-67a5-4778-ae3e-cc8e6070ccf7");
        var objectDefID = Guid.Parse("d1e6fa97-05e3-4603-9d05-3e7c21bf9a5d");
        var viewModel = new MuscleTestFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._MuscleTestForm = objectContext.GetObject(id.Value, objectDefID) as MuscleTestForm;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MuscleTestForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MuscleTestForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._MuscleTestForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._MuscleTestForm);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_MuscleTestForm(viewModel, viewModel._MuscleTestForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._MuscleTestForm = new MuscleTestForm(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MuscleTestForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MuscleTestForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._MuscleTestForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._MuscleTestForm);
                PreScript_MuscleTestForm(viewModel, viewModel._MuscleTestForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel MuscleTestForm(MuscleTestFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return MuscleTestFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel MuscleTestFormInternal(MuscleTestFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("abce9cd8-67a5-4778-ae3e-cc8e6070ccf7");
        objectContext.AddToRawObjectList(viewModel._MuscleTestForm);
        objectContext.ProcessRawObjects();
        var muscleTestForm = (MuscleTestForm)objectContext.GetLoadedObject(viewModel._MuscleTestForm.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(muscleTestForm, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MuscleTestForm, formDefID);
        var transDef = muscleTestForm.TransDef;
        PostScript_MuscleTestForm(viewModel, muscleTestForm, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(muscleTestForm);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(muscleTestForm);
        AfterContextSaveScript_MuscleTestForm(viewModel, muscleTestForm, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_MuscleTestForm(MuscleTestFormViewModel viewModel, MuscleTestForm muscleTestForm, TTObjectContext objectContext);
    partial void PostScript_MuscleTestForm(MuscleTestFormViewModel viewModel, MuscleTestForm muscleTestForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_MuscleTestForm(MuscleTestFormViewModel viewModel, MuscleTestForm muscleTestForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(MuscleTestFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class MuscleTestFormViewModel 
    {
        public TTObjectClasses.MuscleTestForm _MuscleTestForm { get; set; }
    }
}
