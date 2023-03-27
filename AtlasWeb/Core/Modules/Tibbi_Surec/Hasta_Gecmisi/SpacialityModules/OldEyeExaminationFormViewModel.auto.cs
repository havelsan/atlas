//$C990CB45
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;

namespace Core.Controllers
{
    public partial class EyeExaminationServiceController : Controller
{
    [HttpGet]
    public OldEyeExaminationFormViewModel OldEyeExaminationForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OldEyeExaminationFormLoadInternal(input);
    }

    [HttpPost]
    public OldEyeExaminationFormViewModel OldEyeExaminationFormLoad(FormLoadInput input)
    {
        return OldEyeExaminationFormLoadInternal(input);
    }

    private OldEyeExaminationFormViewModel OldEyeExaminationFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("e328a030-669c-42ac-918e-7ff158e31db8");
        var objectDefID = Guid.Parse("6f2c7971-c123-4a39-8589-c5494590699b");
        var viewModel = new OldEyeExaminationFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._EyeExamination = objectContext.GetObject(id.Value, objectDefID) as EyeExamination;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._EyeExamination, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EyeExamination, formDefID);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._EyeExamination);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._EyeExamination);
                PreScript_OldEyeExaminationForm(viewModel, viewModel._EyeExamination, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._EyeExamination = new EyeExamination(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._EyeExamination, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EyeExamination, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._EyeExamination);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._EyeExamination);
                PreScript_OldEyeExaminationForm(viewModel, viewModel._EyeExamination, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public void OldEyeExaminationForm(OldEyeExaminationFormViewModel viewModel)
    {
        var formDefID = Guid.Parse("e328a030-669c-42ac-918e-7ff158e31db8");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._EyeExamination);
            objectContext.ProcessRawObjects();
            var eyeExamination = (EyeExamination)objectContext.GetLoadedObject(viewModel._EyeExamination.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(eyeExamination, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EyeExamination, formDefID);
            var transDef = eyeExamination.TransDef;
            PostScript_OldEyeExaminationForm(viewModel, eyeExamination, transDef, objectContext);
            objectContext.Save();
            AfterContextSaveScript_OldEyeExaminationForm(viewModel, eyeExamination, transDef, objectContext);
        }
    }

    partial void PreScript_OldEyeExaminationForm(OldEyeExaminationFormViewModel viewModel, EyeExamination eyeExamination, TTObjectContext objectContext);
    partial void PostScript_OldEyeExaminationForm(OldEyeExaminationFormViewModel viewModel, EyeExamination eyeExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OldEyeExaminationForm(OldEyeExaminationFormViewModel viewModel, EyeExamination eyeExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OldEyeExaminationFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}

namespace Core.Models
{
    public partial class OldEyeExaminationFormViewModel : BaseViewModel
    {
        public TTObjectClasses.EyeExamination _EyeExamination
        {
            get;
            set;
        }
    }
}