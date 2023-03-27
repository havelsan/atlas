//$E82E5C2D
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
    public InPatientAdmissionClinicProcedureViewModel InPatientAdmissionClinicProcedure(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return InPatientAdmissionClinicProcedureLoadInternal(input);
    }

    [HttpPost]
    public InPatientAdmissionClinicProcedureViewModel InPatientAdmissionClinicProcedureLoad(FormLoadInput input)
    {
        return InPatientAdmissionClinicProcedureLoadInternal(input);
    }

    private InPatientAdmissionClinicProcedureViewModel InPatientAdmissionClinicProcedureLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("3bea1a14-aedd-4aca-9f1a-7853f7eb4dde");
        var objectDefID = Guid.Parse("dd81c497-f6f6-4dd4-bcbe-d1c5825b0e0f");
        var viewModel = new InPatientAdmissionClinicProcedureViewModel();
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
                PreScript_InPatientAdmissionClinicProcedure(viewModel, viewModel._InpatientAdmission, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel InPatientAdmissionClinicProcedure(InPatientAdmissionClinicProcedureViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("3bea1a14-aedd-4aca-9f1a-7853f7eb4dde");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.ResRoomGroups);
            objectContext.AddToRawObjectList(viewModel.ResRooms);
            objectContext.AddToRawObjectList(viewModel.ResBeds);
            objectContext.AddToRawObjectList(viewModel.ResWards);
            objectContext.AddToRawObjectList(viewModel.TratmentClinicsGridGridList);
            objectContext.AddToRawObjectList(viewModel.BedsGridGridList);
            objectContext.AddToRawObjectList(viewModel._InpatientAdmission);
            objectContext.ProcessRawObjects();
            var inpatientAdmission = (InpatientAdmission)objectContext.GetLoadedObject(viewModel._InpatientAdmission.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(inpatientAdmission, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InpatientAdmission, formDefID);
            if (viewModel.TratmentClinicsGridGridList != null)
            {
                foreach (var item in viewModel.TratmentClinicsGridGridList)
                {
                    var inPatientTreatmentClinicApplicationsImported = (InPatientTreatmentClinicApplication)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)inPatientTreatmentClinicApplicationsImported).IsDeleted)
                        continue;
                    inPatientTreatmentClinicApplicationsImported.BaseInpatientAdmission = inpatientAdmission;
                }
            }

            var episodeImported = inpatientAdmission.Episode;
            if (episodeImported != null)
            {
                if (viewModel.BedsGridGridList != null)
                {
                    foreach (var item in viewModel.BedsGridGridList)
                    {
                        var baseBedProceduresImported = (BaseBedProcedure)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)baseBedProceduresImported).IsDeleted)
                            continue;
                        baseBedProceduresImported.Episode = episodeImported;
                    }
                }
            }

            var transDef = inpatientAdmission.TransDef;
            PostScript_InPatientAdmissionClinicProcedure(viewModel, inpatientAdmission, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(inpatientAdmission);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(inpatientAdmission);
            AfterContextSaveScript_InPatientAdmissionClinicProcedure(viewModel, inpatientAdmission, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_InPatientAdmissionClinicProcedure(InPatientAdmissionClinicProcedureViewModel viewModel, InpatientAdmission inpatientAdmission, TTObjectContext objectContext);
    partial void PostScript_InPatientAdmissionClinicProcedure(InPatientAdmissionClinicProcedureViewModel viewModel, InpatientAdmission inpatientAdmission, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_InPatientAdmissionClinicProcedure(InPatientAdmissionClinicProcedureViewModel viewModel, InpatientAdmission inpatientAdmission, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(InPatientAdmissionClinicProcedureViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.TratmentClinicsGridGridList = viewModel._InpatientAdmission.InPatientTreatmentClinicApplications.OfType<InPatientTreatmentClinicApplication>().ToArray();
        var episode = viewModel._InpatientAdmission.Episode;
        if (episode != null)
        {
            viewModel.BedsGridGridList = episode.BaseBedProcedures.OfType<BaseBedProcedure>().ToArray();
        }

        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.ResRoomGroups = objectContext.LocalQuery<ResRoomGroup>().ToArray();
        viewModel.ResRooms = objectContext.LocalQuery<ResRoom>().ToArray();
        viewModel.ResBeds = objectContext.LocalQuery<ResBed>().ToArray();
        viewModel.ResWards = objectContext.LocalQuery<ResWard>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ClinicListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RoomGroupListDefinition", viewModel.ResRoomGroups);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RoomListDefinition", viewModel.ResRooms);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BedListDefinition", viewModel.ResBeds);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "WardListDefinition", viewModel.ResWards);
    }
}
}


namespace Core.Models
{
    public partial class InPatientAdmissionClinicProcedureViewModel : BaseViewModel
    {
        public TTObjectClasses.InpatientAdmission _InpatientAdmission { get; set; }
        public TTObjectClasses.InPatientTreatmentClinicApplication[] TratmentClinicsGridGridList { get; set; }
        public TTObjectClasses.BaseBedProcedure[] BedsGridGridList { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.ResRoomGroup[] ResRoomGroups { get; set; }
        public TTObjectClasses.ResRoom[] ResRooms { get; set; }
        public TTObjectClasses.ResBed[] ResBeds { get; set; }
        public TTObjectClasses.ResWard[] ResWards { get; set; }
    }
}
