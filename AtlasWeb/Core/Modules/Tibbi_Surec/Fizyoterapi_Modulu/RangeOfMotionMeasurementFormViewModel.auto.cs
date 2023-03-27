//$52AEF6AC
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
    public partial class RangeOfMotionMeasurementFormServiceController : Controller
{
    [HttpGet]
    public RangeOfMotionMeasurementFormViewModel RangeOfMotionMeasurementForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return RangeOfMotionMeasurementFormLoadInternal(input);
    }

    [HttpPost]
    public RangeOfMotionMeasurementFormViewModel RangeOfMotionMeasurementFormLoad(FormLoadInput input)
    {
        return RangeOfMotionMeasurementFormLoadInternal(input);
    }

    private RangeOfMotionMeasurementFormViewModel RangeOfMotionMeasurementFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("3792d9f3-c75b-40ef-afb2-0d54967148fd");
        var objectDefID = Guid.Parse("a2363438-6bc4-4c20-9f06-39ad85599ea7");
        var viewModel = new RangeOfMotionMeasurementFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._RangeOfMotionMeasurementForm = objectContext.GetObject(id.Value, objectDefID) as RangeOfMotionMeasurementForm;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._RangeOfMotionMeasurementForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._RangeOfMotionMeasurementForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._RangeOfMotionMeasurementForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._RangeOfMotionMeasurementForm);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_RangeOfMotionMeasurementForm(viewModel, viewModel._RangeOfMotionMeasurementForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._RangeOfMotionMeasurementForm = new RangeOfMotionMeasurementForm(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._RangeOfMotionMeasurementForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._RangeOfMotionMeasurementForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._RangeOfMotionMeasurementForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._RangeOfMotionMeasurementForm);
                PreScript_RangeOfMotionMeasurementForm(viewModel, viewModel._RangeOfMotionMeasurementForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel RangeOfMotionMeasurementForm(RangeOfMotionMeasurementFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return RangeOfMotionMeasurementFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel RangeOfMotionMeasurementFormInternal(RangeOfMotionMeasurementFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("3792d9f3-c75b-40ef-afb2-0d54967148fd");
        objectContext.AddToRawObjectList(viewModel._RangeOfMotionMeasurementForm);
        objectContext.ProcessRawObjects();
        var rangeOfMotionMeasurementForm = (RangeOfMotionMeasurementForm)objectContext.GetLoadedObject(viewModel._RangeOfMotionMeasurementForm.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(rangeOfMotionMeasurementForm, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._RangeOfMotionMeasurementForm, formDefID);
        var transDef = rangeOfMotionMeasurementForm.TransDef;
        PostScript_RangeOfMotionMeasurementForm(viewModel, rangeOfMotionMeasurementForm, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(rangeOfMotionMeasurementForm);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(rangeOfMotionMeasurementForm);
        AfterContextSaveScript_RangeOfMotionMeasurementForm(viewModel, rangeOfMotionMeasurementForm, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_RangeOfMotionMeasurementForm(RangeOfMotionMeasurementFormViewModel viewModel, RangeOfMotionMeasurementForm rangeOfMotionMeasurementForm, TTObjectContext objectContext);
    partial void PostScript_RangeOfMotionMeasurementForm(RangeOfMotionMeasurementFormViewModel viewModel, RangeOfMotionMeasurementForm rangeOfMotionMeasurementForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_RangeOfMotionMeasurementForm(RangeOfMotionMeasurementFormViewModel viewModel, RangeOfMotionMeasurementForm rangeOfMotionMeasurementForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(RangeOfMotionMeasurementFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class RangeOfMotionMeasurementFormViewModel
    {
        public TTObjectClasses.RangeOfMotionMeasurementForm _RangeOfMotionMeasurementForm { get; set; }
    }
}
