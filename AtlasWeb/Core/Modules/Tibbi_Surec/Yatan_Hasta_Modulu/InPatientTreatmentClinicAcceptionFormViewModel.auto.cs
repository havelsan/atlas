//$031B065F
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
    public partial class InPatientTreatmentClinicApplicationServiceController : Controller
{
    [HttpGet]
    public InPatientTreatmentClinicAcceptionFormViewModel InPatientTreatmentClinicAcceptionForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return InPatientTreatmentClinicAcceptionFormLoadInternal(input);
    }

    [HttpPost]
    public InPatientTreatmentClinicAcceptionFormViewModel InPatientTreatmentClinicAcceptionFormLoad(FormLoadInput input)
    {
        return InPatientTreatmentClinicAcceptionFormLoadInternal(input);
    }

    private InPatientTreatmentClinicAcceptionFormViewModel InPatientTreatmentClinicAcceptionFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("d2e555d9-4711-41c2-b58c-1495b2daabd6");
        var objectDefID = Guid.Parse("cc4f64b5-98c9-4f37-a51d-0a6bbf2897bd");
        var viewModel = new InPatientTreatmentClinicAcceptionFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._InPatientTreatmentClinicApplication = objectContext.GetObject(id.Value, objectDefID) as InPatientTreatmentClinicApplication;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InPatientTreatmentClinicApplication, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InPatientTreatmentClinicApplication, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._InPatientTreatmentClinicApplication);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._InPatientTreatmentClinicApplication);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_InPatientTreatmentClinicAcceptionForm(viewModel, viewModel._InPatientTreatmentClinicApplication, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._InPatientTreatmentClinicApplication = new InPatientTreatmentClinicApplication(objectContext);
                var entryStateID = Guid.Parse("8e6c3495-3684-4406-a2ca-78f4ca29c505");
                viewModel._InPatientTreatmentClinicApplication.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InPatientTreatmentClinicApplication, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InPatientTreatmentClinicApplication, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._InPatientTreatmentClinicApplication);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._InPatientTreatmentClinicApplication);
                PreScript_InPatientTreatmentClinicAcceptionForm(viewModel, viewModel._InPatientTreatmentClinicApplication, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel InPatientTreatmentClinicAcceptionForm(InPatientTreatmentClinicAcceptionFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("d2e555d9-4711-41c2-b58c-1495b2daabd6");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.BaseInpatientAdmissions);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.ResRooms);
            objectContext.AddToRawObjectList(viewModel.ResWards);
            objectContext.AddToRawObjectList(viewModel.ResRoomGroups);
            objectContext.AddToRawObjectList(viewModel.ResBeds);
            objectContext.AddToRawObjectList(viewModel.ResSections);
            var entryStateID = Guid.Parse("8e6c3495-3684-4406-a2ca-78f4ca29c505");
            objectContext.AddToRawObjectList(viewModel._InPatientTreatmentClinicApplication, entryStateID);
            objectContext.ProcessRawObjects(false);
            var inPatientTreatmentClinicApplication = (InPatientTreatmentClinicApplication)objectContext.GetLoadedObject(viewModel._InPatientTreatmentClinicApplication.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(inPatientTreatmentClinicApplication, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InPatientTreatmentClinicApplication, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(inPatientTreatmentClinicApplication);
            PostScript_InPatientTreatmentClinicAcceptionForm(viewModel, inPatientTreatmentClinicApplication, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(inPatientTreatmentClinicApplication);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(inPatientTreatmentClinicApplication);
            AfterContextSaveScript_InPatientTreatmentClinicAcceptionForm(viewModel, inPatientTreatmentClinicApplication, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_InPatientTreatmentClinicAcceptionForm(InPatientTreatmentClinicAcceptionFormViewModel viewModel, InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication, TTObjectContext objectContext);
    partial void PostScript_InPatientTreatmentClinicAcceptionForm(InPatientTreatmentClinicAcceptionFormViewModel viewModel, InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_InPatientTreatmentClinicAcceptionForm(InPatientTreatmentClinicAcceptionFormViewModel viewModel, InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(InPatientTreatmentClinicAcceptionFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.BaseInpatientAdmissions = objectContext.LocalQuery<BaseInpatientAdmission>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.ResRooms = objectContext.LocalQuery<ResRoom>().ToArray();
        viewModel.ResWards = objectContext.LocalQuery<ResWard>().ToArray();
        viewModel.ResRoomGroups = objectContext.LocalQuery<ResRoomGroup>().ToArray();
        viewModel.ResBeds = objectContext.LocalQuery<ResBed>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RoomListDefinition", viewModel.ResRooms);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "WardListDefinition", viewModel.ResWards);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RoomGroupListDefinition", viewModel.ResRoomGroups);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BedListDefinition", viewModel.ResBeds);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ClinicNurseListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ClinicListDefinition", viewModel.ResSections);
    }
}
}


namespace Core.Models
{
    public partial class InPatientTreatmentClinicAcceptionFormViewModel : BaseViewModel
    {
        public TTObjectClasses.InPatientTreatmentClinicApplication _InPatientTreatmentClinicApplication { get; set; }
        public TTObjectClasses.BaseInpatientAdmission[] BaseInpatientAdmissions { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.ResRoom[] ResRooms { get; set; }
        public TTObjectClasses.ResWard[] ResWards { get; set; }
        public TTObjectClasses.ResRoomGroup[] ResRoomGroups { get; set; }
        public TTObjectClasses.ResBed[] ResBeds { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }

    }
}
