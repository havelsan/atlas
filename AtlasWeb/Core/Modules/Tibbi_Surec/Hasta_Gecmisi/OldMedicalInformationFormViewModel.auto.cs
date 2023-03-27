//$F6993C00
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
    public partial class MedicalInformationServiceController : Controller
{
    [HttpGet]
    public OldMedicalInformationFormViewModel OldMedicalInformationForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OldMedicalInformationFormLoadInternal(input);
    }

    [HttpPost]
    public OldMedicalInformationFormViewModel OldMedicalInformationFormLoad(FormLoadInput input)
    {
        return OldMedicalInformationFormLoadInternal(input);
    }

    private OldMedicalInformationFormViewModel OldMedicalInformationFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("cddfbf67-a83f-4de8-8fb2-366d3aba2512");
        var objectDefID = Guid.Parse("4c1a03ca-db04-4414-90f7-4e353a44cbf2");
        var viewModel = new OldMedicalInformationFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._MedicalInformation = objectContext.GetObject(id.Value, objectDefID) as MedicalInformation;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MedicalInformation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedicalInformation, formDefID);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._MedicalInformation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._MedicalInformation);
                PreScript_OldMedicalInformationForm(viewModel, viewModel._MedicalInformation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._MedicalInformation = new MedicalInformation(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MedicalInformation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedicalInformation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._MedicalInformation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._MedicalInformation);
                PreScript_OldMedicalInformationForm(viewModel, viewModel._MedicalInformation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public void OldMedicalInformationForm(OldMedicalInformationFormViewModel viewModel)
    {
        var formDefID = Guid.Parse("cddfbf67-a83f-4de8-8fb2-366d3aba2512");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._MedicalInformation);
            objectContext.ProcessRawObjects();
            var medicalInformation = (MedicalInformation)objectContext.GetLoadedObject(viewModel._MedicalInformation.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(medicalInformation, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MedicalInformation, formDefID);
            var transDef = medicalInformation.TransDef;
            PostScript_OldMedicalInformationForm(viewModel, medicalInformation, transDef, objectContext);
            objectContext.Save();
            AfterContextSaveScript_OldMedicalInformationForm(viewModel, medicalInformation, transDef, objectContext);
        }
    }

    partial void PreScript_OldMedicalInformationForm(OldMedicalInformationFormViewModel viewModel, MedicalInformation medicalInformation, TTObjectContext objectContext);
    partial void PostScript_OldMedicalInformationForm(OldMedicalInformationFormViewModel viewModel, MedicalInformation medicalInformation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OldMedicalInformationForm(OldMedicalInformationFormViewModel viewModel, MedicalInformation medicalInformation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OldMedicalInformationFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}

namespace Core.Models
{
    public partial class OldMedicalInformationFormViewModel : BaseViewModel
    {
        public TTObjectClasses.MedicalInformation _MedicalInformation
        {
            get;
            set;
        }
    }
}