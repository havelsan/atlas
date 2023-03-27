//$B6AFBB86
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
    public partial class InpatientAdmissionServiceController : Controller
{
    [HttpGet]
    public InpatientAdmissionRequestFormViewModel InpatientAdmissionRequestForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return InpatientAdmissionRequestFormLoadInternal(input);
    }

    [HttpPost]
    public InpatientAdmissionRequestFormViewModel InpatientAdmissionRequestFormLoad(FormLoadInput input)
    {
        return InpatientAdmissionRequestFormLoadInternal(input);
    }

    private InpatientAdmissionRequestFormViewModel InpatientAdmissionRequestFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("27f78de2-6cc4-4101-a582-b25442ee2cf4");
        var objectDefID = Guid.Parse("dd81c497-f6f6-4dd4-bcbe-d1c5825b0e0f");
        var viewModel = new InpatientAdmissionRequestFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._InpatientAdmission = objectContext.GetObject(id.Value, objectDefID) as InpatientAdmission;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InpatientAdmission, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InpatientAdmission, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._InpatientAdmission);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._InpatientAdmission);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_InpatientAdmissionRequestForm(viewModel, viewModel._InpatientAdmission, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._InpatientAdmission = new InpatientAdmission(objectContext);
                var entryStateID = Guid.Parse("2109ec1e-3448-4ae7-a6a2-08c45f4bcfb4");
                viewModel._InpatientAdmission.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InpatientAdmission, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InpatientAdmission, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._InpatientAdmission);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._InpatientAdmission);
                PreScript_InpatientAdmissionRequestForm(viewModel, viewModel._InpatientAdmission, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel InpatientAdmissionRequestForm(InpatientAdmissionRequestFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("27f78de2-6cc4-4101-a582-b25442ee2cf4");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.ResClinics);
            objectContext.AddToRawObjectList(viewModel.ResBeds);
            objectContext.AddToRawObjectList(viewModel.ResRoomGroups);
            objectContext.AddToRawObjectList(viewModel.ResRooms);
            objectContext.AddToRawObjectList(viewModel.ResWards);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.InpatientReasonDefinitions);
            var entryStateID = Guid.Parse("2109ec1e-3448-4ae7-a6a2-08c45f4bcfb4");
            objectContext.AddToRawObjectList(viewModel._InpatientAdmission, entryStateID);
            objectContext.ProcessRawObjects(false);
            var inpatientAdmission = (InpatientAdmission)objectContext.GetLoadedObject(viewModel._InpatientAdmission.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(inpatientAdmission, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InpatientAdmission, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(inpatientAdmission);
            PostScript_InpatientAdmissionRequestForm(viewModel, inpatientAdmission, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(inpatientAdmission);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(inpatientAdmission);
            AfterContextSaveScript_InpatientAdmissionRequestForm(viewModel, inpatientAdmission, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_InpatientAdmissionRequestForm(InpatientAdmissionRequestFormViewModel viewModel, InpatientAdmission inpatientAdmission, TTObjectContext objectContext);
    partial void PostScript_InpatientAdmissionRequestForm(InpatientAdmissionRequestFormViewModel viewModel, InpatientAdmission inpatientAdmission, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_InpatientAdmissionRequestForm(InpatientAdmissionRequestFormViewModel viewModel, InpatientAdmission inpatientAdmission, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(InpatientAdmissionRequestFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        viewModel.ResClinics = objectContext.LocalQuery<ResClinic>().ToArray();
        viewModel.ResBeds = objectContext.LocalQuery<ResBed>().ToArray();
        viewModel.ResRoomGroups = objectContext.LocalQuery<ResRoomGroup>().ToArray();
        viewModel.ResRooms = objectContext.LocalQuery<ResRoom>().ToArray();
        viewModel.ResWards = objectContext.LocalQuery<ResWard>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.InpatientReasonDefinitions = objectContext.LocalQuery<InpatientReasonDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ClinicExceptIntensiveCareListDefinition", viewModel.ResClinics);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BedListDefinition", viewModel.ResBeds);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RoomGroupListDefinition", viewModel.ResRoomGroups);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RoomListDefinition", viewModel.ResRooms);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "WardExceptIntensiveCareListDefinition", viewModel.ResWards);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "InpatientReasonListDefinition", viewModel.InpatientReasonDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class InpatientAdmissionRequestFormViewModel : BaseViewModel
    {
        public TTObjectClasses.InpatientAdmission _InpatientAdmission { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
        public TTObjectClasses.ResClinic[] ResClinics { get; set; }
        public TTObjectClasses.ResBed[] ResBeds { get; set; }
        public TTObjectClasses.ResRoomGroup[] ResRoomGroups { get; set; }
        public TTObjectClasses.ResRoom[] ResRooms { get; set; }
        public TTObjectClasses.ResWard[] ResWards { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.InpatientReasonDefinition[] InpatientReasonDefinitions { get; set; }
    }
}
