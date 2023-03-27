//$9596C0F3
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
    public partial class ConsultationServiceController : Controller
{
    [HttpGet]
    public AppointmentFormConsultationViewModel AppointmentFormConsultation(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return AppointmentFormConsultationLoadInternal(input);
    }

    [HttpPost]
    public AppointmentFormConsultationViewModel AppointmentFormConsultationLoad(FormLoadInput input)
    {
        return AppointmentFormConsultationLoadInternal(input);
    }

    private AppointmentFormConsultationViewModel AppointmentFormConsultationLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("5d3bfc97-90c0-4b93-81aa-582edd9857e6");
        var objectDefID = Guid.Parse("7a58decc-e858-41eb-87f8-61f97512f3ab");
        var viewModel = new AppointmentFormConsultationViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Consultation = objectContext.GetObject(id.Value, objectDefID) as Consultation;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Consultation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Consultation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._Consultation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._Consultation);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_AppointmentFormConsultation(viewModel, viewModel._Consultation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel AppointmentFormConsultation(AppointmentFormConsultationViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("5d3bfc97-90c0-4b93-81aa-582edd9857e6");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._Consultation);
            objectContext.ProcessRawObjects();
            var consultation = (Consultation)objectContext.GetLoadedObject(viewModel._Consultation.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(consultation, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Consultation, formDefID);
            var transDef = consultation.TransDef;
            PostScript_AppointmentFormConsultation(viewModel, consultation, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(consultation);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(consultation);
            AfterContextSaveScript_AppointmentFormConsultation(viewModel, consultation, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_AppointmentFormConsultation(AppointmentFormConsultationViewModel viewModel, Consultation consultation, TTObjectContext objectContext);
    partial void PostScript_AppointmentFormConsultation(AppointmentFormConsultationViewModel viewModel, Consultation consultation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_AppointmentFormConsultation(AppointmentFormConsultationViewModel viewModel, Consultation consultation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(AppointmentFormConsultationViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class AppointmentFormConsultationViewModel : BaseViewModel
    {
        public TTObjectClasses.Consultation _Consultation { get; set; }
    }
}
