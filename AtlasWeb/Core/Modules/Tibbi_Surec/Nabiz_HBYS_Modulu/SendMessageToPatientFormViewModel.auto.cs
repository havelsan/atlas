//$74DEE1A5
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
    public partial class SendMessageToPatientServiceController : Controller
{
    [HttpGet]
    public SendMessageToPatientFormViewModel SendMessageToPatientForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return SendMessageToPatientFormLoadInternal(input);
    }

    [HttpPost]
    public SendMessageToPatientFormViewModel SendMessageToPatientFormLoad(FormLoadInput input)
    {
        return SendMessageToPatientFormLoadInternal(input);
    }

    private SendMessageToPatientFormViewModel SendMessageToPatientFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("dd0a312b-a192-4fa8-9364-262711573fc7");
        var objectDefID = Guid.Parse("d9226d92-7f40-4b38-b022-9c45fe7028ea");
        var viewModel = new SendMessageToPatientFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SendMessageToPatient = objectContext.GetObject(id.Value, objectDefID) as SendMessageToPatient;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SendMessageToPatient, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SendMessageToPatient, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._SendMessageToPatient);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._SendMessageToPatient);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_SendMessageToPatientForm(viewModel, viewModel._SendMessageToPatient, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SendMessageToPatient = new SendMessageToPatient(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SendMessageToPatient, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SendMessageToPatient, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._SendMessageToPatient);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._SendMessageToPatient);
                PreScript_SendMessageToPatientForm(viewModel, viewModel._SendMessageToPatient, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel SendMessageToPatientForm(SendMessageToPatientFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("dd0a312b-a192-4fa8-9364-262711573fc7");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.SKRSHastaMesajlaris);
            objectContext.AddToRawObjectList(viewModel._SendMessageToPatient);
            objectContext.ProcessRawObjects();
            var sendMessageToPatient = (SendMessageToPatient)objectContext.GetLoadedObject(viewModel._SendMessageToPatient.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(sendMessageToPatient, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SendMessageToPatient, formDefID);
            var transDef = sendMessageToPatient.TransDef;
            PostScript_SendMessageToPatientForm(viewModel, sendMessageToPatient, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(sendMessageToPatient);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(sendMessageToPatient);
            AfterContextSaveScript_SendMessageToPatientForm(viewModel, sendMessageToPatient, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_SendMessageToPatientForm(SendMessageToPatientFormViewModel viewModel, SendMessageToPatient sendMessageToPatient, TTObjectContext objectContext);
    partial void PostScript_SendMessageToPatientForm(SendMessageToPatientFormViewModel viewModel, SendMessageToPatient sendMessageToPatient, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_SendMessageToPatientForm(SendMessageToPatientFormViewModel viewModel, SendMessageToPatient sendMessageToPatient, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(SendMessageToPatientFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.SKRSHastaMesajlaris = objectContext.LocalQuery<SKRSHastaMesajlari>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSHastaMesajlariList", viewModel.SKRSHastaMesajlaris);
    }
}
}


namespace Core.Models
{
    public partial class SendMessageToPatientFormViewModel : BaseViewModel
    {
        public TTObjectClasses.SendMessageToPatient _SendMessageToPatient { get; set; }
        public TTObjectClasses.SKRSHastaMesajlari[] SKRSHastaMesajlaris { get; set; }
    }
}
