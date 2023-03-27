//$B684B4BC
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
    public partial class PatientExaminationServiceController : Controller
{
    [HttpGet]
    public OldExaminationFormViewModel OldExaminationForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OldExaminationFormLoadInternal(input);
    }

    [HttpPost]
    public OldExaminationFormViewModel OldExaminationFormLoad(FormLoadInput input)
    {
        return OldExaminationFormLoadInternal(input);
    }

    private OldExaminationFormViewModel OldExaminationFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("140c18ea-1392-459e-9b9b-3c0d8f7d0580");
        var objectDefID = Guid.Parse("2a112388-5c95-40c2-b074-d40eab3c6a1b");
        var viewModel = new OldExaminationFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PatientExamination = objectContext.GetObject(id.Value, objectDefID) as PatientExamination;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PatientExamination, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientExamination, formDefID);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PatientExamination);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PatientExamination);
                PreScript_OldExaminationForm(viewModel, viewModel._PatientExamination, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public void OldExaminationForm(OldExaminationFormViewModel viewModel)
    {
        var formDefID = Guid.Parse("140c18ea-1392-459e-9b9b-3c0d8f7d0580");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._PatientExamination);
            objectContext.ProcessRawObjects();
            var patientExamination = (PatientExamination)objectContext.GetLoadedObject(viewModel._PatientExamination.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(patientExamination, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientExamination, formDefID);
            var transDef = patientExamination.TransDef;
            PostScript_OldExaminationForm(viewModel, patientExamination, transDef, objectContext);
            objectContext.Save();
            AfterContextSaveScript_OldExaminationForm(viewModel, patientExamination, transDef, objectContext);
        }
    }

    partial void PreScript_OldExaminationForm(OldExaminationFormViewModel viewModel, PatientExamination patientExamination, TTObjectContext objectContext);
    partial void PostScript_OldExaminationForm(OldExaminationFormViewModel viewModel, PatientExamination patientExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OldExaminationForm(OldExaminationFormViewModel viewModel, PatientExamination patientExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OldExaminationFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}

namespace Core.Models
{
    public partial class OldExaminationFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PatientExamination _PatientExamination
        {
            get;
            set;
        }
    }
}