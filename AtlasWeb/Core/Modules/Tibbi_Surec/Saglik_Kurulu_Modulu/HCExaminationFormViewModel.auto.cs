//$CA97F33D
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
    public partial class HealthCommitteeServiceController : Controller
{
    [HttpGet]
    public HCExaminationFormViewModel HCExaminationForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return HCExaminationFormLoadInternal(input);
    }

    [HttpPost]
    public HCExaminationFormViewModel HCExaminationFormLoad(FormLoadInput input)
    {
        return HCExaminationFormLoadInternal(input);
    }

    private HCExaminationFormViewModel HCExaminationFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("4d6c80d3-2db3-4906-9466-84e84aa9a5eb");
        var objectDefID = Guid.Parse("00787ad8-30b5-44a8-bb40-d1cd0414fb0a");
        var viewModel = new HCExaminationFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._HealthCommittee = objectContext.GetObject(id.Value, objectDefID) as HealthCommittee;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._HealthCommittee, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HealthCommittee, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._HealthCommittee);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._HealthCommittee);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_HCExaminationForm(viewModel, viewModel._HealthCommittee, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel HCExaminationForm(HCExaminationFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("4d6c80d3-2db3-4906-9466-84e84aa9a5eb");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.SystemForDisabledReportDefinitions);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.SpecialityDefinitions);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.MedicalInformations);
            objectContext.AddToRawObjectList(viewModel.MedicalInfoDisabledGroups);
            objectContext.AddToRawObjectList(viewModel.IntendedUseOfDisabledReports);
            objectContext.AddToRawObjectList(viewModel.HCRequestReasons);
            objectContext.AddToRawObjectList(viewModel.ReasonForExaminationDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.MembersGridList);
            objectContext.AddToRawObjectList(viewModel.ExternalDoctorsGridList);
            objectContext.AddToRawObjectList(viewModel.HospitalsUnitsGridList);
            objectContext.AddToRawObjectList(viewModel.SystemForHealthCommitteeGridGridList);
            objectContext.AddToRawObjectList(viewModel.GridEpisodeDiagnosisGridList);
            objectContext.AddToRawObjectList(viewModel.DiagnosisGridList);
            objectContext.AddToRawObjectList(viewModel._HealthCommittee);
            objectContext.ProcessRawObjects();
            var healthCommittee = (HealthCommittee)objectContext.GetLoadedObject(viewModel._HealthCommittee.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(healthCommittee, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HealthCommittee, formDefID);
            if (viewModel.MembersGridList != null)
            {
                foreach (var item in viewModel.MembersGridList)
                {
                    var membersImported = (MemberOfHealthCommiittee)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)membersImported).IsDeleted)
                        continue;
                    membersImported.HealthCommittee = healthCommittee;
                }
            }

            if (viewModel.ExternalDoctorsGridList != null)
            {
                foreach (var item in viewModel.ExternalDoctorsGridList)
                {
                    var externalDoctorsImported = (BaseHealthCommittee_ExtDoctorGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)externalDoctorsImported).IsDeleted)
                        continue;
                    externalDoctorsImported.BaseHealthCommittee = healthCommittee;
                }
            }

            if (viewModel.HospitalsUnitsGridList != null)
            {
                foreach (var item in viewModel.HospitalsUnitsGridList)
                {
                    var hospitalsUnitsImported = (BaseHealthCommittee_HospitalsUnitsGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)hospitalsUnitsImported).IsDeleted)
                        continue;
                    hospitalsUnitsImported.BaseHealthCommittee = healthCommittee;
                }
            }

            if (viewModel.SystemForHealthCommitteeGridGridList != null)
            {
                foreach (var item in viewModel.SystemForHealthCommitteeGridGridList)
                {
                    var systemForHealthCommitteeGridImported = (SystemForHealthCommitteeGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)systemForHealthCommitteeGridImported).IsDeleted)
                        continue;
                    systemForHealthCommitteeGridImported.HealthCommittee = healthCommittee;
                }
            }

            var episodeImported = healthCommittee.Episode;
            if (episodeImported != null)
            {
                if (viewModel.GridEpisodeDiagnosisGridList != null)
                {
                    foreach (var item in viewModel.GridEpisodeDiagnosisGridList)
                    {
                        var diagnosisImported = (DiagnosisGrid)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)diagnosisImported).IsDeleted)
                            continue;
                        diagnosisImported.Episode = episodeImported;
                    }
                }
            }

            if (viewModel.DiagnosisGridList != null)
            {
                foreach (var item in viewModel.DiagnosisGridList)
                {
                    var diagnosisImported = (DiagnosisGrid)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)diagnosisImported).IsDeleted)
                        continue;
                    diagnosisImported.EpisodeAction = healthCommittee;
                }
            }

            var transDef = healthCommittee.TransDef;
            PostScript_HCExaminationForm(viewModel, healthCommittee, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(healthCommittee);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(healthCommittee);
            AfterContextSaveScript_HCExaminationForm(viewModel, healthCommittee, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_HCExaminationForm(HCExaminationFormViewModel viewModel, HealthCommittee healthCommittee, TTObjectContext objectContext);
    partial void PostScript_HCExaminationForm(HCExaminationFormViewModel viewModel, HealthCommittee healthCommittee, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_HCExaminationForm(HCExaminationFormViewModel viewModel, HealthCommittee healthCommittee, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(HCExaminationFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.MembersGridList = viewModel._HealthCommittee.Members.OfType<MemberOfHealthCommiittee>().ToArray();
        viewModel.ExternalDoctorsGridList = viewModel._HealthCommittee.ExternalDoctors.OfType<BaseHealthCommittee_ExtDoctorGrid>().ToArray();
        viewModel.HospitalsUnitsGridList = viewModel._HealthCommittee.HospitalsUnits.OfType<BaseHealthCommittee_HospitalsUnitsGrid>().ToArray();
        viewModel.SystemForHealthCommitteeGridGridList = viewModel._HealthCommittee.SystemForHealthCommitteeGrid.OfType<SystemForHealthCommitteeGrid>().ToArray();
        var episode = viewModel._HealthCommittee.Episode;
        if (episode != null)
        {
            viewModel.GridEpisodeDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        }

        viewModel.DiagnosisGridList = viewModel._HealthCommittee.Diagnosis.OfType<DiagnosisGrid>().ToArray();
        viewModel.SpecialityDefinitions = objectContext.LocalQuery<SpecialityDefinition>().ToArray();
        viewModel.SystemForDisabledReportDefinitions = objectContext.LocalQuery<SystemForDisabledReportDefinition>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        viewModel.MedicalInformations = objectContext.LocalQuery<MedicalInformation>().ToArray();
        viewModel.MedicalInfoDisabledGroups = objectContext.LocalQuery<MedicalInfoDisabledGroup>().ToArray();
        viewModel.IntendedUseOfDisabledReports = objectContext.LocalQuery<IntendedUseOfDisabledReport>().ToArray();
        viewModel.HCRequestReasons = objectContext.LocalQuery<HCRequestReason>().ToArray();
        viewModel.ReasonForExaminationDefinitions = objectContext.LocalQuery<ReasonForExaminationDefinition>().ToArray();
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialityListDefinition", viewModel.SpecialityDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PoliclinicAndEmergencyListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SystemForDisabledReportListDefinition", viewModel.SystemForDisabledReportDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "HealthCommitteeExaminationReasonListDefinition", viewModel.ReasonForExaminationDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
    }
}
}


namespace Core.Models
{
    public partial class HCExaminationFormViewModel : BaseViewModel
    {
        public TTObjectClasses.HealthCommittee _HealthCommittee { get; set; }
        public TTObjectClasses.MemberOfHealthCommiittee[] MembersGridList{ get; set; }
        public TTObjectClasses.BaseHealthCommittee_ExtDoctorGrid[] ExternalDoctorsGridList { get; set; }
        public TTObjectClasses.BaseHealthCommittee_HospitalsUnitsGrid[] HospitalsUnitsGridList { get; set; }
        public TTObjectClasses.SystemForHealthCommitteeGrid[] SystemForHealthCommitteeGridGridList { get; set; }
        public TTObjectClasses.DiagnosisGrid[] GridEpisodeDiagnosisGridList { get; set; }
        public TTObjectClasses.DiagnosisGrid[] DiagnosisGridList { get; set; }
        public TTObjectClasses.SpecialityDefinition[] SpecialityDefinitions { get; set; }
        public TTObjectClasses.SystemForDisabledReportDefinition[] SystemForDisabledReportDefinitions { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
        public TTObjectClasses.MedicalInformation[] MedicalInformations { get; set; }
        public TTObjectClasses.MedicalInfoDisabledGroup[] MedicalInfoDisabledGroups { get; set; }
        public TTObjectClasses.IntendedUseOfDisabledReport[] IntendedUseOfDisabledReports { get; set; }
        public TTObjectClasses.HCRequestReason[] HCRequestReasons { get; set; }
        public TTObjectClasses.ReasonForExaminationDefinition[] ReasonForExaminationDefinitions { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
    }
}
