//$38F8A44A
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
    public partial class InPatientPhysicianApplicationServiceController : Controller
    {
        [HttpGet]
        public InPatientPhysicianApplicationFormViewModel InPatientPhysicianApplicationForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return InPatientPhysicianApplicationFormLoadInternal(input);
        }

        [HttpPost]
        public InPatientPhysicianApplicationFormViewModel InPatientPhysicianApplicationFormLoad(FormLoadInput input)
        {
            return InPatientPhysicianApplicationFormLoadInternal(input);
        }

        private InPatientPhysicianApplicationFormViewModel InPatientPhysicianApplicationFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("b8ba8edf-bcd4-4e17-8860-b167c8c03527");
            var objectDefID = Guid.Parse("92accee7-68ce-44a6-8e02-8747e426104b");
            var viewModel = new InPatientPhysicianApplicationFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._InPatientPhysicianApplication = objectContext.GetObject(id.Value, objectDefID) as InPatientPhysicianApplication;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InPatientPhysicianApplication, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InPatientPhysicianApplication, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._InPatientPhysicianApplication);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._InPatientPhysicianApplication);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);
                    PreScript_InPatientPhysicianApplicationForm(viewModel, viewModel._InPatientPhysicianApplication, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._InPatientPhysicianApplication = new InPatientPhysicianApplication(objectContext);
                    var entryStateID = Guid.Parse("73698603-b1f2-4691-968d-fe4e0cab1d03");
                    viewModel._InPatientPhysicianApplication.CurrentStateDefID = entryStateID;
                    viewModel.DietOrdersGridList = new TTObjectClasses.DietOrder[] { };
                    viewModel.InPatientRtfBySpecialitiesGridList = new TTObjectClasses.InPatientRtfBySpeciality[] { };
                    viewModel.ProgressesGridList = new TTObjectClasses.InPatientPhysicianProgresses[] { };
                    viewModel.GrdConsultationGridList = new TTObjectClasses.Consultation[] { };
                    viewModel.GridDiagnosisGridList = new TTObjectClasses.DiagnosisGrid[] { };
                    viewModel.NursingOrderGridGridList = new TTObjectClasses.NursingOrder[] { };
                    viewModel.GridTreatmentMaterialsGridList = new TTObjectClasses.BaseTreatmentMaterial[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InPatientPhysicianApplication, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InPatientPhysicianApplication, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._InPatientPhysicianApplication);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._InPatientPhysicianApplication);
                    PreScript_InPatientPhysicianApplicationForm(viewModel, viewModel._InPatientPhysicianApplication, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public BaseViewModel InPatientPhysicianApplicationForm(InPatientPhysicianApplicationFormViewModel viewModel)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("b8ba8edf-bcd4-4e17-8860-b167c8c03527");
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddToRawObjectList(viewModel.EmergencyInterventions);
                objectContext.AddToRawObjectList(viewModel.DietDefinitions);
                objectContext.AddToRawObjectList(viewModel.MealTypess);
                objectContext.AddToRawObjectList(viewModel.SubEpisodes);
                objectContext.AddToRawObjectList(viewModel.ResUsers);
                objectContext.AddToRawObjectList(viewModel.InPatientTreatmentClinicApplications);
                objectContext.AddToRawObjectList(viewModel.BaseInpatientAdmissions);
                objectContext.AddToRawObjectList(viewModel.ResBeds);
                objectContext.AddToRawObjectList(viewModel.ResRoomGroups);
                objectContext.AddToRawObjectList(viewModel.ResRooms);
                objectContext.AddToRawObjectList(viewModel.ResSections);
                objectContext.AddToRawObjectList(viewModel.Episodes);
                objectContext.AddToRawObjectList(viewModel.DiagnosisDefinitions);
                objectContext.AddToRawObjectList(viewModel.VitalSignAndNursingDefinitions);
                objectContext.AddToRawObjectList(viewModel.Materials);
                objectContext.AddToRawObjectList(viewModel.StockCards);
                objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
                objectContext.AddToRawObjectList(viewModel.OzelDurums);
                objectContext.AddToRawObjectList(viewModel.DietOrdersGridList);
                objectContext.AddToRawObjectList(viewModel.InPatientRtfBySpecialitiesGridList);
                objectContext.AddToRawObjectList(viewModel.ProgressesGridList);
                objectContext.AddToRawObjectList(viewModel.GrdConsultationGridList);
                objectContext.AddToRawObjectList(viewModel.GridDiagnosisGridList);
                objectContext.AddToRawObjectList(viewModel.NursingOrderGridGridList);
                objectContext.AddToRawObjectList(viewModel.GridTreatmentMaterialsGridList);
                objectContext.AddToRawObjectList(viewModel.SKRSDurums);
                objectContext.AddToRawObjectList(viewModel.TedaviTipis);
                var entryStateID = Guid.Parse("73698603-b1f2-4691-968d-fe4e0cab1d03");
                objectContext.AddToRawObjectList(viewModel._InPatientPhysicianApplication, entryStateID);
                objectContext.ProcessRawObjects(false);
                var inPatientPhysicianApplication = (InPatientPhysicianApplication)objectContext.GetLoadedObject(viewModel._InPatientPhysicianApplication.ObjectID);
                TTDefinitionManagement.TTFormDef.CheckFormSecurity(inPatientPhysicianApplication, formDefID, true);
                TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InPatientPhysicianApplication, formDefID);
                if (viewModel.DietOrdersGridList != null)
                {
                    foreach (var item in viewModel.DietOrdersGridList)
                    {
                        var dietOrdersImported = (DietOrder)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)dietOrdersImported).IsDeleted)
                            continue;
                        dietOrdersImported.InpatientPhysicianApplication = inPatientPhysicianApplication;
                    }
                }

                var subEpisodeImported = inPatientPhysicianApplication.SubEpisode;
                if (subEpisodeImported != null)
                {
                    if (viewModel.InPatientRtfBySpecialitiesGridList != null)
                    {
                        foreach (var item in viewModel.InPatientRtfBySpecialitiesGridList)
                        {
                            var inPatientRtfBySpecialitiesImported = (InPatientRtfBySpeciality)objectContext.GetLoadedObject(item.ObjectID);
                            if (((ITTObject)inPatientRtfBySpecialitiesImported).IsDeleted)
                                continue;
                            inPatientRtfBySpecialitiesImported.SubEpisode = subEpisodeImported;
                        }
                    }

                    if (viewModel.ProgressesGridList != null)
                    {
                        foreach (var item in viewModel.ProgressesGridList)
                        {
                            var inPatientPhysicianProgressesImported = (InPatientPhysicianProgresses)objectContext.GetLoadedObject(item.ObjectID);
                            if (((ITTObject)inPatientPhysicianProgressesImported).IsDeleted)
                            {
                                var ozellikliIzlemList = OzellikliIzlemVeriSeti.GetOzellikliIzlemVeriSeti(objectContext, " WHERE InPatientPhysicianProgresses='" + inPatientPhysicianProgressesImported.ObjectID.ToString()+"'").ToList();
                                if (ozellikliIzlemList.Count > 0)
                                {
                                    foreach (var izlem in ozellikliIzlemList)
                                    {
                                         var ozellikliIzlem = objectContext.GetObject<OzellikliIzlemVeriSeti>((Guid)izlem.ObjectID);
                                        ozellikliIzlem.IsProgressDeleted = true;
                                    }                                    
                                }
                                continue;
                            }
                            inPatientPhysicianProgressesImported.SubEpisode = subEpisodeImported;
                        }
                    }
                }

                if (viewModel.GrdConsultationGridList != null)
                {
                    foreach (var item in viewModel.GrdConsultationGridList)
                    {
                        var consultationsImported = (Consultation)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)consultationsImported).IsDeleted)
                            continue;
                        consultationsImported.PhysicianApplication = inPatientPhysicianApplication;
                    }
                }

                var episodeImported = inPatientPhysicianApplication.Episode;
                if (episodeImported != null)
                {
                    if (viewModel.GridDiagnosisGridList != null)
                    {
                        foreach (var item in viewModel.GridDiagnosisGridList)
                        {
                            var diagnosisImported = (DiagnosisGrid)objectContext.GetLoadedObject(item.ObjectID);
                            if (((ITTObject)diagnosisImported).IsDeleted)
                                continue;
                            diagnosisImported.Episode = episodeImported;
                        }
                    }
                }

                if (viewModel.NursingOrderGridGridList != null)
                {
                    foreach (var item in viewModel.NursingOrderGridGridList)
                    {
                        var nursingOrdersImported = (NursingOrder)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)nursingOrdersImported).IsDeleted)
                            continue;
                        nursingOrdersImported.InPatientPhysicianApplication = inPatientPhysicianApplication;
                    }
                }

                if (viewModel.GridTreatmentMaterialsGridList != null)
                {
                    foreach (var item in viewModel.GridTreatmentMaterialsGridList)
                    {
                        var treatmentMaterialsImported = (BaseTreatmentMaterial)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)treatmentMaterialsImported).IsDeleted || treatmentMaterialsImported.EpisodeAction != null)
                            continue;
                        treatmentMaterialsImported.EpisodeAction = inPatientPhysicianApplication;
                    }
                }

                var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(inPatientPhysicianApplication);
                PostScript_InPatientPhysicianApplicationForm(viewModel, inPatientPhysicianApplication, transDef, objectContext);
                objectContext.AdvanceStateForNewObjects();
                retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
                objectContext.Save();
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(inPatientPhysicianApplication);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(inPatientPhysicianApplication);
                AfterContextSaveScript_InPatientPhysicianApplicationForm(viewModel, inPatientPhysicianApplication, transDef, objectContext);
                retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
                retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
                objectContext.FullPartialllyLoadedObjects();
            }

            return retViewModel;
        }

        partial void PreScript_InPatientPhysicianApplicationForm(InPatientPhysicianApplicationFormViewModel viewModel, InPatientPhysicianApplication inPatientPhysicianApplication, TTObjectContext objectContext);
        partial void PostScript_InPatientPhysicianApplicationForm(InPatientPhysicianApplicationFormViewModel viewModel, InPatientPhysicianApplication inPatientPhysicianApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_InPatientPhysicianApplicationForm(InPatientPhysicianApplicationFormViewModel viewModel, InPatientPhysicianApplication inPatientPhysicianApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(InPatientPhysicianApplicationFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.DietOrdersGridList = viewModel._InPatientPhysicianApplication.DietOrders.OfType<DietOrder>().ToArray();
            var subEpisode = viewModel._InPatientPhysicianApplication.SubEpisode;
            if (subEpisode != null)
            {
                viewModel.InPatientRtfBySpecialitiesGridList = subEpisode.InPatientRtfBySpecialities.OfType<InPatientRtfBySpeciality>().ToArray();
                viewModel.ProgressesGridList = subEpisode.InPatientPhysicianProgresses.OfType<InPatientPhysicianProgresses>().ToArray();
            }

            viewModel.GrdConsultationGridList = viewModel._InPatientPhysicianApplication.Consultations.OfType<Consultation>().ToArray();
            var episode = viewModel._InPatientPhysicianApplication.Episode;
            if (episode != null)
            {
                viewModel.GridDiagnosisGridList = episode.Diagnosis.OfType<DiagnosisGrid>().ToArray();
            }

            viewModel.NursingOrderGridGridList = viewModel._InPatientPhysicianApplication.NursingOrders.OfType<NursingOrder>().ToArray();

            if (viewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp?.IsDailyOperation == true || viewModel._InPatientPhysicianApplication.EmergencyIntervention != null)
                viewModel.GridTreatmentMaterialsGridList = viewModel._InPatientPhysicianApplication.Episode.SubActionMaterials.OfType<BaseTreatmentMaterial>().ToArray();
            else if (viewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp?.IsDailyOperation != true)
                viewModel.GridTreatmentMaterialsGridList = viewModel._InPatientPhysicianApplication.TreatmentMaterials.OfType<BaseTreatmentMaterial>().ToArray();

            viewModel.EmergencyInterventions = objectContext.LocalQuery<EmergencyIntervention>().ToArray();
            viewModel.DietDefinitions = objectContext.LocalQuery<DietDefinition>().ToArray();
            viewModel.MealTypess = objectContext.LocalQuery<MealTypes>().ToArray();
            viewModel.SubEpisodes = objectContext.LocalQuery<SubEpisode>().ToArray();
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            viewModel.InPatientTreatmentClinicApplications = objectContext.LocalQuery<InPatientTreatmentClinicApplication>().ToArray();
            viewModel.BaseInpatientAdmissions = objectContext.LocalQuery<BaseInpatientAdmission>().ToArray();
            viewModel.ResBeds = objectContext.LocalQuery<ResBed>().ToArray();
            viewModel.ResRoomGroups = objectContext.LocalQuery<ResRoomGroup>().ToArray();
            viewModel.ResRooms = objectContext.LocalQuery<ResRoom>().ToArray();
            viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
            viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
            viewModel.DiagnosisDefinitions = objectContext.LocalQuery<DiagnosisDefinition>().ToArray();
            viewModel.VitalSignAndNursingDefinitions = objectContext.LocalQuery<VitalSignAndNursingDefinition>().ToArray();
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
            viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
            viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
            viewModel.OzelDurums = objectContext.LocalQuery<OzelDurum>().ToArray();
            viewModel.SKRSDurums = objectContext.LocalQuery<SKRSDurum>().ToArray();
            viewModel.TedaviTipis = objectContext.LocalQuery<TedaviTipi>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSDurumList", viewModel.SKRSDurums);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResUserDefinitionList", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BedListDefinition", viewModel.ResBeds);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RoomGroupListDefinition", viewModel.ResRoomGroups);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "RoomListDefinition", viewModel.ResRooms);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ClinicListDefinition", viewModel.ResSections);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ClinicNurseListDefinition", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialistDoctorListDefinition", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ConsultationRequestResourceList", viewModel.ResSections);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ConsultationRequesterUserList", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiagnosisListDefinition", viewModel.DiagnosisDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "VitalSignAndNursingListDefinition", viewModel.VitalSignAndNursingDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ConsumableMaterialAndDrugList", viewModel.Materials);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "OzelDurumListDefinition", viewModel.OzelDurums);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "TedaviTipiListDefinition", viewModel.TedaviTipis);
        }
    }
}


namespace Core.Models
{
    public partial class InPatientPhysicianApplicationFormViewModel
    {
        public TTObjectClasses.InPatientPhysicianApplication _InPatientPhysicianApplication { get; set; }
        public TTObjectClasses.DietOrder[] DietOrdersGridList { get; set; }
        public TTObjectClasses.InPatientRtfBySpeciality[] InPatientRtfBySpecialitiesGridList { get; set; }
        public TTObjectClasses.InPatientPhysicianProgresses[] ProgressesGridList { get; set; }
        public TTObjectClasses.Consultation[] GrdConsultationGridList { get; set; }
        public TTObjectClasses.DiagnosisGrid[] GridDiagnosisGridList { get; set; }
        public TTObjectClasses.NursingOrder[] NursingOrderGridGridList { get; set; }
        public TTObjectClasses.BaseTreatmentMaterial[] GridTreatmentMaterialsGridList { get; set; }
        public TTObjectClasses.EmergencyIntervention[] EmergencyInterventions { get; set; }
        public TTObjectClasses.DietDefinition[] DietDefinitions { get; set; }
        public TTObjectClasses.MealTypes[] MealTypess { get; set; }
        public TTObjectClasses.SubEpisode[] SubEpisodes { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.InPatientTreatmentClinicApplication[] InPatientTreatmentClinicApplications { get; set; }
        public TTObjectClasses.BaseInpatientAdmission[] BaseInpatientAdmissions { get; set; }
        public TTObjectClasses.ResBed[] ResBeds { get; set; }
        public TTObjectClasses.ResRoomGroup[] ResRoomGroups { get; set; }
        public TTObjectClasses.ResRoom[] ResRooms { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.DiagnosisDefinition[] DiagnosisDefinitions { get; set; }
        public TTObjectClasses.VitalSignAndNursingDefinition[] VitalSignAndNursingDefinitions { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.OzelDurum[] OzelDurums { get; set; }
        public TTObjectClasses.SKRSDurum[] SKRSDurums { get; set; }
        public TTObjectClasses.TedaviTipi[] TedaviTipis { get; set; }
    }
}
