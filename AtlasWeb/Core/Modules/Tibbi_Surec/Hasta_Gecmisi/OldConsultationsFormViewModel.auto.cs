//$FA1843AB
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
    public partial class ConsultationServiceController : Controller
{
    [HttpGet]
    public OldConsultationsFormViewModel OldConsultationsForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OldConsultationsFormLoadInternal(input);
    }

    [HttpPost]
    public OldConsultationsFormViewModel OldConsultationsFormLoad(FormLoadInput input)
    {
        return OldConsultationsFormLoadInternal(input);
    }

    private OldConsultationsFormViewModel OldConsultationsFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("66986b55-231c-4c64-ab24-742c241c67fb");
        var objectDefID = Guid.Parse("7a58decc-e858-41eb-87f8-61f97512f3ab");
        var viewModel = new OldConsultationsFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Consultation = objectContext.GetObject(id.Value, objectDefID) as Consultation;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Consultation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Consultation, formDefID);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Consultation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Consultation);
                PreScript_OldConsultationsForm(viewModel, viewModel._Consultation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public void OldConsultationsForm(OldConsultationsFormViewModel viewModel)
    {
        var formDefID = Guid.Parse("66986b55-231c-4c64-ab24-742c241c67fb");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._Consultation);
            objectContext.ProcessRawObjects();
            var consultation = (Consultation)objectContext.GetLoadedObject(viewModel._Consultation.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(consultation, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Consultation, formDefID);
            var transDef = consultation.TransDef;
            PostScript_OldConsultationsForm(viewModel, consultation, transDef, objectContext);
            objectContext.Save();
            AfterContextSaveScript_OldConsultationsForm(viewModel, consultation, transDef, objectContext);
        }
    }

    partial void PreScript_OldConsultationsForm(OldConsultationsFormViewModel viewModel, Consultation consultation, TTObjectContext objectContext);
    partial void PostScript_OldConsultationsForm(OldConsultationsFormViewModel viewModel, Consultation consultation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OldConsultationsForm(OldConsultationsFormViewModel viewModel, Consultation consultation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OldConsultationsFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}

namespace Core.Models
{
    public partial class OldConsultationsFormViewModel : BaseViewModel
    {
        public TTObjectClasses.Consultation _Consultation
        {
            get;
            set;
        }
    }
}