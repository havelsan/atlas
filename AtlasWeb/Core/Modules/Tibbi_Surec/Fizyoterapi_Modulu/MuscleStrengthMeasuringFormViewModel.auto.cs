//$B58BE68A
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
    public partial class MuscleStrengthMeasuringFormServiceController : Controller
{
    [HttpGet]
    public MuscleStrengthMeasuringFormViewModel MuscleStrengthMeasuringForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return MuscleStrengthMeasuringFormLoadInternal(input);
    }

    [HttpPost]
    public MuscleStrengthMeasuringFormViewModel MuscleStrengthMeasuringFormLoad(FormLoadInput input)
    {
        return MuscleStrengthMeasuringFormLoadInternal(input);
    }

    private MuscleStrengthMeasuringFormViewModel MuscleStrengthMeasuringFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("8da3b9d4-e100-4f3a-8762-9e537f49c2dd");
        var objectDefID = Guid.Parse("92b54900-741c-4be4-ab1f-d4b2e265b2bc");
        var viewModel = new MuscleStrengthMeasuringFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._MuscleStrengthMeasuringForm = objectContext.GetObject(id.Value, objectDefID) as MuscleStrengthMeasuringForm;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MuscleStrengthMeasuringForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MuscleStrengthMeasuringForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._MuscleStrengthMeasuringForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._MuscleStrengthMeasuringForm);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_MuscleStrengthMeasuringForm(viewModel, viewModel._MuscleStrengthMeasuringForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._MuscleStrengthMeasuringForm = new MuscleStrengthMeasuringForm(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MuscleStrengthMeasuringForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MuscleStrengthMeasuringForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._MuscleStrengthMeasuringForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._MuscleStrengthMeasuringForm);
                PreScript_MuscleStrengthMeasuringForm(viewModel, viewModel._MuscleStrengthMeasuringForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel MuscleStrengthMeasuringForm(MuscleStrengthMeasuringFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return MuscleStrengthMeasuringFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel MuscleStrengthMeasuringFormInternal(MuscleStrengthMeasuringFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("8da3b9d4-e100-4f3a-8762-9e537f49c2dd");
        objectContext.AddToRawObjectList(viewModel._MuscleStrengthMeasuringForm);
        objectContext.ProcessRawObjects();
        var muscleStrengthMeasuringForm = (MuscleStrengthMeasuringForm)objectContext.GetLoadedObject(viewModel._MuscleStrengthMeasuringForm.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(muscleStrengthMeasuringForm, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MuscleStrengthMeasuringForm, formDefID);
        var transDef = muscleStrengthMeasuringForm.TransDef;
        PostScript_MuscleStrengthMeasuringForm(viewModel, muscleStrengthMeasuringForm, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(muscleStrengthMeasuringForm);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(muscleStrengthMeasuringForm);
        AfterContextSaveScript_MuscleStrengthMeasuringForm(viewModel, muscleStrengthMeasuringForm, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_MuscleStrengthMeasuringForm(MuscleStrengthMeasuringFormViewModel viewModel, MuscleStrengthMeasuringForm muscleStrengthMeasuringForm, TTObjectContext objectContext);
    partial void PostScript_MuscleStrengthMeasuringForm(MuscleStrengthMeasuringFormViewModel viewModel, MuscleStrengthMeasuringForm muscleStrengthMeasuringForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_MuscleStrengthMeasuringForm(MuscleStrengthMeasuringFormViewModel viewModel, MuscleStrengthMeasuringForm muscleStrengthMeasuringForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(MuscleStrengthMeasuringFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class MuscleStrengthMeasuringFormViewModel
    { 
        public TTObjectClasses.MuscleStrengthMeasuringForm _MuscleStrengthMeasuringForm { get; set; }
    }
}
