//$D2E6BC48
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using System.ComponentModel;
using RestSharp;
using System.Text;
using TTStorageManager.Security;
using Newtonsoft.Json;

namespace Core.Controllers
{
    public partial class InPatientPhysicianApplicationServiceController
    {
        partial void PreScript_InPatientPhysicianApplicationForm(InPatientPhysicianApplicationFormViewModel viewModel, InPatientPhysicianApplication inPatientPhysicianApplication, TTObjectContext objectContext)
        {
            // viewModel.GridTreatmentMaterialsGridList = new TTObjectClasses.BaseTreatmentMaterial[] { };

            //Uzmanlık için
            viewModel.SetHasSpecialityBasedObject(inPatientPhysicianApplication);

            viewModel.GrdPatientInterviewFormGridList = new TTObjectClasses.PatientInterviewForm[] { };
            viewModel.GrdExternalConsultationGridList = new TTObjectClasses.ConsultationFromExternalHospital[] { };
            if (inPatientPhysicianApplication.SubEpisode.InPatientRtfBySpecialities.Count == 0)
                inPatientPhysicianApplication.SubEpisode.CreateMyInPatientRtfBySpeciality(inPatientPhysicianApplication);
            viewModel.GrdPatientInterviewFormGridList = viewModel._InPatientPhysicianApplication.PatientInteviewForms.OfType<PatientInterviewForm>().ToArray();
            viewModel.GrdExternalConsultationGridList = viewModel._InPatientPhysicianApplication.ExternalConsultations.OfType<ConsultationFromExternalHospital>().ToArray();
            viewModel.GrdDentalExaminationGridList = viewModel._InPatientPhysicianApplication.LinkedDentalConsultations.OfType<DentalExamination>().ToArray();
            if (viewModel._InPatientPhysicianApplication.VentilatorStatus != null)       //Bu If bloğu nesnenin context içerisine yüklenmesi için yazıldı
            {
                var a = viewModel._InPatientPhysicianApplication.VentilatorStatus;
            }

            if (viewModel._InPatientPhysicianApplication.ApacheScores != null)
            {
                viewModel.ApacheScoreList = viewModel._InPatientPhysicianApplication.ApacheScores.ToList();
            }
            if (viewModel._InPatientPhysicianApplication.GlaskowScores != null)
            {
                viewModel.GlaskowScoreList = viewModel._InPatientPhysicianApplication.GlaskowScores.ToList();
            }
            if (viewModel._InPatientPhysicianApplication.SnappeScores != null)
            {
                viewModel.SnappeScoreList = viewModel._InPatientPhysicianApplication.SnappeScores.ToList();
            }
            if (viewModel._InPatientPhysicianApplication.Prisms != null)
            {
                viewModel.PrismScoreList = viewModel._InPatientPhysicianApplication.Prisms.ToList();
            }

            if (inPatientPhysicianApplication.VentilatorStatus == null &&
                (inPatientPhysicianApplication.InPatientTreatmentClinicApp == null//Acil müşahade için yazıldı
                || inPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.Bed == null//Günübirlik için yazıldı
                || inPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.Bed.IsVentilator != true))//Yatak Tanımlarında ventilatör seçili değilse
            {
                inPatientPhysicianApplication.VentilatorStatus = SKRSDurum.GetSkrsDurumObj(objectContext, "Where KODU=2").FirstOrDefault();
            }

            var b = viewModel._InPatientPhysicianApplication.IsPandemic;
            if (viewModel._InPatientPhysicianApplication.IsPandemic != null)
            {
                viewModel.PrevousPandemicValue = viewModel._InPatientPhysicianApplication.IsPandemic.Value;
            }


            DiagnosisDefinition diagnose = DiagnosisDefinition.GetDiagnosisDefinitionByCode(objectContext, "U07.3").FirstOrDefault();
            if (diagnose != null)
            {
                viewModel.CovidDiagnoseDef = diagnose;
                viewModel.CovidDiagnose = new DiagnosisGrid(objectContext);
                viewModel.CovidDiagnose.Diagnose = diagnose;
                viewModel.CovidDiagnose.EpisodeAction = inPatientPhysicianApplication;
                viewModel.CovidDiagnose.EntryActionType = inPatientPhysicianApplication.ActionType;
                viewModel.CovidDiagnose.DiagnosisType = DiagnosisTypeEnum.Seconder;

                if (inPatientPhysicianApplication.ProcedureDoctor != null)
                {
                    viewModel.CovidDiagnose.ResponsibleDoctor = inPatientPhysicianApplication.ProcedureDoctor;
                }
                if (inPatientPhysicianApplication.Episode != null)
                {
                    viewModel.CovidDiagnose.Episode = inPatientPhysicianApplication.Episode;
                }
            }

            ContextToViewModel(viewModel, objectContext);
            viewModel.IsIntensiveCare = false;
            if (inPatientPhysicianApplication.InPatientTreatmentClinicApp != null)
            {
                if (((ResWard)inPatientPhysicianApplication.InPatientTreatmentClinicApp.MasterResource).IsIntensiveCare == true)
                    viewModel.IsIntensiveCare = true;

                IntensiveCareSpecialityObj _intensiveCareSpecialityObj = new IntensiveCareSpecialityObj();
                if (inPatientPhysicianApplication.SpecialityBasedObject.Count() > 0)
                {
                    _intensiveCareSpecialityObj = inPatientPhysicianApplication.SpecialityBasedObject.FirstOrDefault() as IntensiveCareSpecialityObj;
                }
                viewModel.IntensiveCareType = _intensiveCareSpecialityObj.SetIntensiveCareType(inPatientPhysicianApplication.Episode.Patient);
                viewModel.ClinicInpatientDateAdded = Convert.ToDateTime(inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicInpatientDate).AddDays(1);

            }
            viewModel.IsPandemicRequired = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("IsPandemicRequired", "TRUE"));

            viewModel.IsNonInpatient = false;//false->Yatan hasta true->Günübirlik ya da Müşahade hastası

            viewModel.VitalSignAndNursingDefinitionList = VitalSignAndNursingDefinition.GetAllVitalSignAndNursingDefinitions(objectContext).ToArray();

            if (inPatientPhysicianApplication.InPatientTreatmentClinicApp != null)
            {
                if (inPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.HasFallingRisk != null && inPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.HasFallingRisk == true)
                    viewModel.HasFalling = true;
                else
                    viewModel.HasFalling = false;
            }

            viewModel.fallingWarningAge = -1;
            if (inPatientPhysicianApplication.InPatientTreatmentClinicApp != null)
            {
                if (inPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.HasFallingRisk != null && inPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.HasFallingRisk == true)
                {
                    if (inPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.RiskWarningLastSeenDate == null || (DateTime.Now - inPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.RiskWarningLastSeenDate.Value).TotalDays > 1)
                    {
                        viewModel.HasFalling = true;
                    }
                    else
                        viewModel.HasFalling = false;

                }
                else if (inPatientPhysicianApplication.InPatientTreatmentClinicApp.NursingApplications[0].BaseNursingFallingDownRisks.Count == 0)
                {
                    if (inPatientPhysicianApplication.Episode.Patient.Age < 7 || inPatientPhysicianApplication.Episode.Patient.Age > 65)
                        viewModel.fallingWarningAge = inPatientPhysicianApplication.Episode.Patient.Age.Value;
                    viewModel.HasFalling = false;
                }
                else
                {
                    viewModel.HasFalling = false;
                }
            }

            viewModel.showFallingRiskParameter = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("SHOWFALLINGRISKPARAMETER", "TRUE"));

            viewModel.DietDefinitionList = DietDefinition.GetAllDietDefinitions(objectContext).ToArray();


            if (inPatientPhysicianApplication.InPatientTreatmentClinicApp != null && inPatientPhysicianApplication.InPatientTreatmentClinicApp.TreatmentDischarge != null)
            {
                viewModel.myTreatmentDischarge = inPatientPhysicianApplication.InPatientTreatmentClinicApp.TreatmentDischarge;
            }

            if (viewModel._InPatientPhysicianApplication.SubEpisode != null && viewModel._InPatientPhysicianApplication.SubEpisode.PatientAdmission != null)
            {
                viewModel.IsNewBorn = viewModel._InPatientPhysicianApplication.SubEpisode.PatientAdmission.IsNewBorn.Value;
            }

            if (viewModel._InPatientPhysicianApplication.Episode != null && viewModel._InPatientPhysicianApplication.Episode.Patient != null)
            {
                viewModel._Patient = viewModel._InPatientPhysicianApplication.Episode.Patient;
            }

            #region Klinik Seyir Max Date
            DateTime maxDate = Common.RecTime();

            if ((viewModel._InPatientPhysicianApplication.CurrentStateDefID == InPatientPhysicianApplication.States.PreDischarged || viewModel._InPatientPhysicianApplication.CurrentStateDefID == InPatientPhysicianApplication.States.Discharged)
                && viewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp != null && viewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicDischargeDate.HasValue && maxDate > viewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicDischargeDate)
                maxDate = viewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicDischargeDate.Value;

            viewModel.ProgressDate = maxDate;
            #endregion

            #region fizyoterapi

            //Fizyoterapi İsteği Yapma Yetkisi Kontrolü
            viewModel.HasAuthorityForPhysiotherapyRequest = false;
            foreach (ResourceSpecialityGrid resourceSpecialityGrid in inPatientPhysicianApplication.MasterResource.ResourceSpecialities)
            {
                if (resourceSpecialityGrid.Speciality.Code == "1800" || resourceSpecialityGrid.Speciality.Code == "2600")
                {
                    viewModel.HasAuthorityForPhysiotherapyRequest = true;
                    break;
                }
            }

            viewModel.IsPhysiotherapyRequestFormUsing = TTObjectClasses.SystemParameter.GetParameterValue("USEPHYSIOTHERAPYREQUESTFORM", "") == "TRUE" ? true : false;

            //Fizyoterapi İsteği Var Mı?
            foreach (var episodeaction in inPatientPhysicianApplication.LinkedActions)
            {
                if (episodeaction is PhysiotherapyRequest)
                {
                    viewModel.StartPhysiotherapyRequest = true;
                    break;
                }
            }

            #endregion fizyoterapi

            #region Doğum

            //Doğum Başlatma Yetkisi Kontrolü --> sadece kadın doğum yatan hastasından başlatılacak
            viewModel.HasAuthorityForObstetricInformationForm = false;
            foreach (ResourceSpecialityGrid resourceSpecialityGrid in inPatientPhysicianApplication.MasterResource.ResourceSpecialities)
            {
                if (resourceSpecialityGrid.Speciality.Code == "3000")
                {
                    viewModel.HasAuthorityForObstetricInformationForm = true;
                    break;
                }
            }

            //Doğum Başlat İsteği Var Mı?
            foreach (var episodeaction in inPatientPhysicianApplication.LinkedActions)
            {
                if (episodeaction is RegularObstetric)
                {
                    viewModel.StartObstetric = true;
                    break;
                }
            }

            #endregion

            viewModel.includeDrugDefinition = false;
            if (TTObjectClasses.SystemParameter.GetParameterValue("INPATIENTPHYSICIANAPPINCLUDEDRUGS", "FALSE") == "TRUE")
                viewModel.includeDrugDefinition = true;

            if (TTObjectClasses.SystemParameter.GetParameterValue("DOKTORKARARDESTEK", "TRUE") == "TRUE" && inPatientPhysicianApplication.MasterResource.HimssRequired == true)
                viewModel.physicianSuggestionsIsActive = true;
            else
                viewModel.physicianSuggestionsIsActive = false;

            //Hastanın var olan Raporları
            BindingList<EpisodeAction> reportList = EpisodeAction.GetAllReportsOfPatient(objectContext, inPatientPhysicianApplication.Episode.Patient.ObjectID.ToString());
            if (reportList.Count > 0)
            {
                List<PatientReportInfo> patientReportInfoList = new List<PatientReportInfo>();
                foreach (EpisodeAction report in reportList)
                {
                    PatientReportInfo patientReportInfo = new PatientReportInfo();
                    patientReportInfo.ObjectID = report.ObjectID;
                    patientReportInfo.ObjectDefName = report.ObjectDef.Name;
                    patientReportInfo.ID = report.ID.ToString();
                    patientReportInfo.MasterResource = report.MasterResource.Name;
                    patientReportInfo.ProcedureByUser = report.ProcedureByUser == null ? "" : report.ProcedureByUser.Name;

                    if (report.SubEpisode.PatientStatus == SubEpisodeStatusEnum.Inpatient)
                    {
                        if (report.SubEpisode.InpatientAdmission != null)
                            patientReportInfo.AdmissionDate = report.SubEpisode.InpatientAdmission.HospitalInPatientDate.Value.ToShortDateString();
                        else
                            patientReportInfo.AdmissionDate = report.SubEpisode.OpeningDate.Value.ToShortDateString();
                    }
                    else if (report.SubEpisode.PatientStatus == SubEpisodeStatusEnum.Outpatient)
                    {
                        patientReportInfo.AdmissionDate = report.SubEpisode.PatientAdmission.ActionDate.Value.ToShortDateString();
                    }

                    if (report is ParticipatnFreeDrugReport)
                    {
                        if (((ParticipatnFreeDrugReport)report).ReportStartDate.HasValue)
                            patientReportInfo.StartDate = ((ParticipatnFreeDrugReport)report).ReportStartDate.Value.ToShortDateString();
                        else
                            patientReportInfo.StartDate = null;
                        if (((ParticipatnFreeDrugReport)report).ReportEndDate.HasValue)
                            patientReportInfo.EndDate = ((ParticipatnFreeDrugReport)report).ReportEndDate.Value.ToShortDateString();
                        else
                            patientReportInfo.EndDate = null;
                        patientReportInfo.ReportName = ((ParticipatnFreeDrugReport)report).ObjectDef.ApplicationName;
                        patientReportInfo.CancelledReport = (((ParticipatnFreeDrugReport)report).CurrentStateDefID == ParticipatnFreeDrugReport.States.Cancelled) ? true : false;
                        patientReportInfo.RequestReason = "İlaç Raporu";
                    }

                    if (report is StatusNotificationReport)
                    {
                        if (((StatusNotificationReport)report).StartDate.HasValue)
                            patientReportInfo.StartDate = ((StatusNotificationReport)report).StartDate.Value.ToShortDateString();
                        else
                            patientReportInfo.StartDate = ((StatusNotificationReport)report).StartDate.Value.ToShortDateString();
                        if (((StatusNotificationReport)report).EndDate.HasValue)
                            patientReportInfo.EndDate = ((StatusNotificationReport)report).EndDate.Value.ToShortDateString();
                        else
                            patientReportInfo.EndDate = null;
                        patientReportInfo.ReportName = ((StatusNotificationReport)report).ObjectDef.ApplicationName;
                        patientReportInfo.CancelledReport = (((StatusNotificationReport)report).CurrentStateDefID == StatusNotificationReport.States.Cancelled) ? true : false;
                        patientReportInfo.RequestReason = ((StatusNotificationReport)report).HCRequestReason.ReasonName;
                    }
                    if (report is MedulaTreatmentReport)
                    {
                        if (((MedulaTreatmentReport)report).StartDate.HasValue)
                            patientReportInfo.StartDate = ((MedulaTreatmentReport)report).StartDate.Value.ToShortDateString();
                        else
                            patientReportInfo.StartDate = null;
                        if (((MedulaTreatmentReport)report).EndDate.HasValue)
                            patientReportInfo.EndDate = ((MedulaTreatmentReport)report).EndDate.Value.ToShortDateString();
                        else
                            patientReportInfo.EndDate = null;
                        patientReportInfo.ReportName = ((MedulaTreatmentReport)report).ObjectDef.ApplicationName;
                        patientReportInfo.CancelledReport = (((MedulaTreatmentReport)report).CurrentStateDefID == MedulaTreatmentReport.States.Cancelled) ? true : false;
                        patientReportInfo.RequestReason = Common.GetDisplayTextOfDataTypeEnum(((MedulaTreatmentReport)report).TedaviRaporTuru);
                    }
                    if (report is MedicalStuffReport)
                    {
                        if (((MedicalStuffReport)report).StartDate.HasValue)
                            patientReportInfo.StartDate = ((MedicalStuffReport)report).StartDate.Value.ToShortDateString();
                        else
                            patientReportInfo.StartDate = null;
                        if (((MedicalStuffReport)report).EndDate.HasValue)
                            patientReportInfo.EndDate = ((MedicalStuffReport)report).EndDate.Value.ToShortDateString();
                        else
                            patientReportInfo.EndDate = null;
                        patientReportInfo.ReportName = ((MedicalStuffReport)report).ObjectDef.ApplicationName;
                        patientReportInfo.CancelledReport = (((MedicalStuffReport)report).CurrentStateDefID == MedulaTreatmentReport.States.Cancelled) ? true : false;
                        patientReportInfo.RequestReason = "Tıbbi Malzeme Raporu";
                    }

                    if (patientReportInfo.CancelledReport)
                        patientReportInfo.ReportName += patientReportInfo.ReportName + " ( İPTAL EDİLDİ )";

                    patientReportInfoList.Add(patientReportInfo);
                }

                viewModel.PatientReportInfoList = patientReportInfoList;
            }


            // NursingApplicationOrderInfoReport Raporu basarken lazım daha sonra silinebilir 
            if (viewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp != null)
            {
                foreach (var nurisngApp in viewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.NursingApplications)
                {
                    viewModel.NursingApplicationObjectID = nurisngApp.ObjectID.ToString();
                    viewModel._nursingApplication = nurisngApp;
                    break;
                }

                viewModel.HasPaidPayerTypeSEPExists = viewModel._InPatientPhysicianApplication.SubEpisode.HasPaidPayerTypeSEPExists;

                if (viewModel.HasPaidPayerTypeSEPExists == true)
                {
                    if (viewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.TreatmentDischarge != null && viewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.TreatmentDischarge.CurrentStateDefID == TreatmentDischarge.States.Discharged)
                        viewModel.IsDischarged = true;
                    else
                        viewModel.IsDischarged = false;
                }
            }
            else if (viewModel._InPatientPhysicianApplication.EmergencyIntervention != null)
            {
                foreach (var nurisngApp in viewModel._InPatientPhysicianApplication.EmergencyIntervention.NursingApplications)
                {
                    viewModel.NursingApplicationObjectID = nurisngApp.ObjectID.ToString();
                    viewModel._nursingApplication = nurisngApp;
                    break;
                }
            }


            #region Sağlık Kurulu
            viewModel.HCDoctorList = ResUser.DoctorListObjectNQL(objectContext, " AND ISACTIVE =1 ").ToArray(); ;
            viewModel.HCResPoliclinic = ResPoliclinic.GetAllActivePoliclinic(objectContext).ToArray();

            if (inPatientPhysicianApplication.InPatientTreatmentClinicApp != null)
            {
                //Hastanın var olan Raporları
                //BindingList<HealthCommittee> hcList 
                viewModel.healthCommittees = HealthCommittee.GetByWLFilterExpression(objectContext, " AND MasterAction='" + inPatientPhysicianApplication.InPatientTreatmentClinicApp.ObjectID + "'").ToList<HealthCommittee>();
                //viewModel.healthCommittees[0].HCRequestReason.ReasonName
            }
            #endregion

            //TODO NIDA  NursingApplicationOrderInfoReport Raporu basarken lazım daha sonra silinebilir  tegini de içerir
            // #region Hemşire işlemlerinden girilen sarfların, Doktor işlemlerini sarf gridinde gözükmesi için 

            // NursingApplication nursingApplication = null;
            // viewModel.MergedTreatmentMaterialGridList = viewModel._InPatientPhysicianApplication.TreatmentMaterials.ToArray<BaseTreatmentMaterial>();
            // var mergedTreatmentMaterialGridList = new List<BaseTreatmentMaterial>();
            // if (viewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp != null)
            // {
            //     foreach (var nurisngApp in viewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.NursingApplications)
            //     {
            //         viewModel.NursingApplicationObjectID = nurisngApp.ObjectID.ToString();// NursingApplicationOrderInfoReport Raporu basarken lazım daha sonra silinebilir 
            //         nursingApplication = nurisngApp;
            //         break;
            //     }
            // }
            // else if (viewModel._InPatientPhysicianApplication.EmergencyIntervention != null)
            // {

            //     foreach (var nurisngApp in viewModel._InPatientPhysicianApplication.EmergencyIntervention.NursingApplications)
            //     {
            //         viewModel.NursingApplicationObjectID = nurisngApp.ObjectID.ToString(); // NursingApplicationOrderInfoReport Raporu basarken lazım daha sonra silinebilir 
            //         nursingApplication = nurisngApp;
            //         break;
            //     }
            // }
            //if(nursingApplication!= null)
            // {
            //     viewModel.MergedTreatmentMaterialGridList.Concat(nursingApplication.TreatmentMaterials.ToArray<BaseTreatmentMaterial>());
            // }

            // #endregion Hemşire işlemlerinden girilen sarfların sarf gridinde gözükmesi için 

            this.ArrangeButtons(viewModel);

            //this.DropStateButton(InPatientPhysicianApplication.InPatientPhysicianApplicationStates.Cancelled);
            //this.DropStateButton(InPatientPhysicianApplication.InPatientPhysicianApplicationStates.PreDischarged);
            //if (this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.EmergencyIntervention == null)
            //    this.DropStateButton(InPatientPhysicianApplication.InPatientPhysicianApplicationStates.Discharged);

            // SARF GRIDINDE Cancelledlar gelmemesi  için  Bu koddan sonra ContextToViewModel çalışmamalı

            if (viewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp?.IsDailyOperation == true
|| viewModel._InPatientPhysicianApplication.EmergencyIntervention != null)
            {
                viewModel.IsNonInpatient = true;//false->Yatan hasta true->Günübirlik ya da Müşahade hastası
                foreach (var item in viewModel.GridTreatmentMaterialsGridList)
                {
                    var a = item.Material;
                }
                viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
                viewModel.SubEpisodeList = new List<SubEpisode>();
                viewModel.EpisodeActionList = new List<EpisodeAction>();

                viewModel.GridTreatmentMaterialsGridList = viewModel.GridTreatmentMaterialsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();
                viewModel.GridTreatmentMaterialsGridList = viewModel.GridTreatmentMaterialsGridList.Where(material => viewModel.ControlTreatmentMaterialActions(material) == true).ToArray();

            }
            else if (viewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp?.IsDailyOperation != true)
                viewModel.GridTreatmentMaterialsGridList = viewModel.GridTreatmentMaterialsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();

            if (inPatientPhysicianApplication.ProcedureSpeciality != null)
                viewModel.IsAuthorizedToWriteTreatmentReport = EpisodeAction.IsAuthorizedToWriteTreatmentReport(inPatientPhysicianApplication.ProcedureSpeciality);
            else
                viewModel.IsAuthorizedToWriteTreatmentReport = false;

            //ContextToViewModel den sonra çağırılmalı //TANI için
            viewModel.GridDiagnosisGridList = inPatientPhysicianApplication.DiagnosisGrid_PreScript();
            viewModel.HasCovidDiagnosisOnPatient = viewModel.GridDiagnosisGridList.Where(t => t.Diagnose.Code == "U07.3").FirstOrDefault() != null ? true : false;
            viewModel.HasTodayCovidProgress = OzellikliIzlemVeriSeti.GetOzellikliIzlemVeriSeti(objectContext, " WHERE EPISODEACTION='" + inPatientPhysicianApplication.ObjectID + "'").ToList()
                .Where(t => t.IsProgressDeleted != true && t.ProgressDate.Value.Date == Common.RecTime().Date).FirstOrDefault() == null ? false : true;
            //ContextToViewModel den sonra çağırılmalı //KLİNİK SEYİR  için // tüm klinik seyir birden yüklenmesin performansı etkiliyor diye         
            var lastLoadedProgressesInfoDate = Common.RecTime().Date.AddDays(1);
            var progressesInfo = GetInPatientPhysicianProgressesInfoViewModelByDate(lastLoadedProgressesInfoDate.ToString(), inPatientPhysicianApplication.ObjectID);
            if (progressesInfo.ResUsers != null && progressesInfo.ResUsers.Count() > 0)
            {
                var viewModelResUsers = viewModel.ResUsers.ToList();
                foreach (var resuser in progressesInfo.ResUsers)
                {
                    if (viewModelResUsers.FirstOrDefault(dr => dr.ObjectID == resuser.ObjectID) == null)
                    {
                        viewModelResUsers.Add(resuser);
                    }
                }
                viewModel.ResUsers = viewModelResUsers.ToArray();
            }
            viewModel.ProgressesGridList = progressesInfo.ProgressesGridList;
            viewModel.lastLoadedProgressesInfoDate = progressesInfo.lastLoadedProgressesInfoDate;
            if (inPatientPhysicianApplication.InPatientTreatmentClinicApp != null)
            {
                BaseInpatientAdmission baseInpatientAdmission = inPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission;
                foreach (InPatientTreatmentClinicApplication clinicApplication in baseInpatientAdmission.InPatientTreatmentClinicApplications.OrderBy(t => t.ClinicInpatientDate))
                {
                    foreach (InPatientPhysicianApplication physicianApplication in clinicApplication.InPatientPhysicianApplication.Where(t => t.CurrentStateDefID != InPatientPhysicianApplication.States.Cancelled))
                    {
                        InpatientPhysicianAppWithResource patientInpatient = new InpatientPhysicianAppWithResource();
                        patientInpatient.ObjectID = physicianApplication.ObjectID;
                        patientInpatient.MasterResource = physicianApplication.MasterResource.Name + "(" + clinicApplication.ClinicInpatientDate.Value.ToShortDateString();
                        if (clinicApplication.ClinicDischargeDate != null)
                        {
                            patientInpatient.MasterResource += " - " + clinicApplication.ClinicDischargeDate.Value.ToShortDateString() + ")";

                        }
                        else
                        {
                            patientInpatient.MasterResource += " - Halen)";

                        }
                        viewModel.PatientOldInpatients.Add(patientInpatient);
                    }

                }
            }
            viewModel.ShowNewDrugOrderForm = TTObjectClasses.SystemParameter.GetParameterValue("SHOWNEWDRUGORDERFORM", "FALSE");

            viewModel.hasOrthesisRequestRole = TTUser.CurrentUser.HasRole(TTRoleNames.Ortez_Protez_Istek_RUW) ? true : false;
            viewModel.hasOpenEpisodeRole = TTUser.CurrentUser.HasRole(TTRoleNames.Kapali_Acik_Ek_Islemler) ? true : false;
            viewModel.hasCloseEpisodeRole = TTUser.CurrentUser.HasRole(TTRoleNames.Acik_Kapali_Ek_Islemler) ? true : false;

            #region Medula Provizyon İşlemleri

            viewModel.SubEpisodeProtocol = inPatientPhysicianApplication.SubEpisode.SGKSEP;
            viewModel.bagliTakipNo = inPatientPhysicianApplication.SubEpisode.LastSubEpisodeProtocol.SubEpisode.ProtocolNo;//TODO Merve -> Kendi protocolNo mu verir?

            #endregion Medula Provizyon İşlemleri

            #region Uzun/Kısa Yatış
if (inPatientPhysicianApplication.InPatientTreatmentClinicApp != null && inPatientPhysicianApplication.InPatientTreatmentClinicApp.CurrentStateDefID == InPatientTreatmentClinicApplication.States.Procedure && ((ResWard)inPatientPhysicianApplication.InPatientTreatmentClinicApp.MasterResource).IsIntensiveCare == true)
            {
                if (inPatientPhysicianApplication.InPatientTreatmentClinicApp.LongInpatientReason == null)
                {
                    int LongInpatientDayLimit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("LongInpatientDayLimit", "20"));
                    if (inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicInpatientDate != null)
                    {
                        int dayDifference = (Common.RecTime().Date - inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicInpatientDate.Value.Date).Days;
                        if (inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicDischargeDate != null)
                        {
                            dayDifference = (inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicDischargeDate.Value.Date - inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicInpatientDate.Value.Date).Days;
                        }
                        if (dayDifference >= LongInpatientDayLimit)//Uzun gün yatış parametresinden fazla yatış gün sayısı var ise sebep girilecek
                        {
                            viewModel.IsLongInpatient = true;
                        }
                        else
                        {
                            viewModel.IsLongInpatient = false;
                        }

                    }
                }
                if (inPatientPhysicianApplication.InPatientTreatmentClinicApp.ShotInpatientReason == null)
                {
                    int ShortInpatientDayLimit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("ShortInpatientDayLimit", "5"));
                    if (inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicInpatientDate != null)
                    {
                        int dayDifference = (Common.RecTime().Date - inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicInpatientDate.Value.Date).Days;
                        if (inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicDischargeDate != null)
                        {
                            dayDifference = (inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicDischargeDate.Value.Date - inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicInpatientDate.Value.Date).Days;
                        }
                        if (dayDifference < ShortInpatientDayLimit)//Kısa gün yatış parametresinden az yatış gün sayısı var ise ve taburcu oluyorsa sebep girilecek
                        {
                            viewModel.IsShortInpatient = true;
                        }
                        else
                        {
                            viewModel.IsShortInpatient = false;
                        }

                    }
                }
            }
            #endregion

            //Hastada başlatılmış morg işlemi olup olmadığını tutmak için eklendi
            foreach (BaseAction action in viewModel._InPatientPhysicianApplication.LinkedActions)
            {
                if (action is Morgue && !action.IsCancelled)
                {
                    viewModel.HasMorgue = true;
                    break;
                }
            }
            SKRSCikisSekli[] CikisSekli = SKRSCikisSekli.GetSKRSCikisSekliByCode(objectContext).ToArray();
            if (CikisSekli.Length > 0)
                viewModel.DeathDefinition = CikisSekli[0];



        }

        partial void PostScript_InPatientPhysicianApplicationForm(InPatientPhysicianApplicationFormViewModel viewModel, InPatientPhysicianApplication inPatientPhysicianApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            objectContext.AddToRawObjectList(viewModel.GrdPatientInterviewFormGridList);
            if (viewModel.GrdPatientInterviewFormGridList != null)
            {
                foreach (var item in viewModel.GrdPatientInterviewFormGridList)
                {
                    var patientInterviewsImported = (PatientInterviewForm)objectContext.AddObject(item);
                    patientInterviewsImported.PhysicianApplication = inPatientPhysicianApplication;
                }
            }

            objectContext.AddToRawObjectList(viewModel.GrdExternalConsultationGridList);
            if (viewModel.GrdExternalConsultationGridList != null)
            {
                foreach (var item in viewModel.GrdExternalConsultationGridList)
                {
                    var externalConsultationsImported = (ConsultationFromExternalHospital)objectContext.AddObject(item);
                    externalConsultationsImported.PhysicianApplication = inPatientPhysicianApplication;
                }
            }

            objectContext.AddToRawObjectList(viewModel.GrdDentalExaminationGridList);
            if (viewModel.GrdDentalExaminationGridList != null)
            {
                foreach (var item in viewModel.GrdDentalExaminationGridList)
                {
                    var dentalExaminationsImported = (DentalExamination)objectContext.AddObject(item);
                    dentalExaminationsImported.MasterPhysicianApplication = inPatientPhysicianApplication;
                }
            }


            if ((viewModel.PrevousPandemicValue == null || viewModel.PrevousPandemicValue == YesNoEnum.No) && inPatientPhysicianApplication.IsPandemic == YesNoEnum.Yes)
            {
                inPatientPhysicianApplication.PandemicChangeDate = Common.RecTime();
            }
            //TODO NIDA 
            //objectContext.AddToRawObjectList(viewModel.MergedTreatmentMaterialGridList);
            //if (viewModel.MergedTreatmentMaterialGridList != null)
            //{
            //    foreach (var item in viewModel.MergedTreatmentMaterialGridList)
            //    {
            //        var treatmentMaterialsImported = (BaseTreatmentMaterial)objectContext.GetLoadedObject(item.ObjectID);
            //        if (((ITTObject)treatmentMaterialsImported).IsDeleted)
            //            continue;
            //        if (treatmentMaterialsImported.EpisodeAction == null)
            //            treatmentMaterialsImported.EpisodeAction = inPatientPhysicianApplication;
            //    }
            //}

            //viewModel._InPatientPhysicianApplication.NursingOrders.Where(x => x._isNew)


            if (inPatientPhysicianApplication.VentilatorStatus == null)//Ventilatör Kullanım Durumu girişi zorunlu olmalı
            {
                throw new Exception("Ventilatör Kullanım Durumu Girilmesi Zorunludur!");
            }
            else
            {
                if (inPatientPhysicianApplication.VentilatorStatus == null)
                {
                    throw new Exception("Ventilatör kullanım durumunu boş kayıt edemezsiniz!");
                }

                if ((inPatientPhysicianApplication.InPatientTreatmentClinicApp == null //acil müşahade işlemi
                    || inPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.Bed == null)//Günübirlik işlem
                    && inPatientPhysicianApplication.VentilatorStatus.KODU == "1")//Acil veya günübirlik işlemi iken ventilatorStatus var seçildiyse hata vermeli
                {
                    throw new Exception("Bu işlemde tanımlı bir ventilatör bulunmamaktadır. Ventilatör kullanım durumunu Evet olarak seçemezsiniz!");
                }

                if (inPatientPhysicianApplication.InPatientTreatmentClinicApp != null //acil müşahade değil
                    && inPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.Bed != null//Günübirlik değil
                    && inPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.Bed.IsVentilator != true
                    && inPatientPhysicianApplication.VentilatorStatus.KODU == "1")//Yatak Tanımlarında ventilatör seçili değil ve ventilatorStatus var seçildiyse hata vermeli
                {
                    throw new Exception("Yatakta tanımlı bir ventilatör bulunmamaktadır. Ventilatör kullanım durumunu Evet olarak seçemezsiniz!");
                }


            }

            #region SET ORDER DETAİL
            //order detayları clientta oluşturuluyorsa
            foreach (var no in inPatientPhysicianApplication.NursingOrders)
            {
                if (((ITTObject)no).IsNew)
                {
                    NewNursingOrderDetail nnodList = viewModel.newNursingOrderDetailList.Find(x => x.NursingOrderID == no.ProcedureObject.ObjectID);
                    if (nnodList != null && nnodList.newNursingOrderDetail != null)
                    {
                        foreach (NursingOrderDetail nnod in nnodList.newNursingOrderDetail)
                        {

                            NursingOrderDetail nod = new NursingOrderDetail(objectContext, no, nnod);
                            //NursingOrderDetail nod = (NursingOrderDetail)objectContext.AddObject(nnod);
                            nod.PeriodicOrder = no;
                            //no.OrderDetails.Add(nnod);
                        }
                    }

                }
            }
            //objectContext.AddToRawObjectList(viewModel.NursingOrderGridGridList);
            #endregion

            #region Değiştirilen Dietler için
            foreach (DietOrder item in inPatientPhysicianApplication.DietOrders.Where(x => x.CurrentStateDefID != DietOrder.States.Cancelled && x.ReasonOfReject != null && x.ReasonOfReject.ToString() == "Diyet Değiştirildi"))
            {
                ChangeDietOrder(item, objectContext);
            }
            #endregion

            //TANI için
            inPatientPhysicianApplication.DiagnosisGrid_PostScript(viewModel.GridDiagnosisGridList);

            if (viewModel.ProgressDescription != null)
            {
                InPatientPhysicianProgresses inPatientPhysicianProgresses = new InPatientPhysicianProgresses(viewModel.ProgressDescription, viewModel.ProgressDate, inPatientPhysicianApplication);
            }

            if (viewModel._nursingOrderScheduleDetail != null && viewModel._nursingOrderScheduleDetail.Count > 0)
            {
                foreach (OrderScheduleDetail nosd in viewModel._nursingOrderScheduleDetail)
                {
                    if (nosd.isChanged.HasValue && nosd.isChanged.Value)
                    {
                        var nursingOrderScheduleDetailImported = objectContext.GetObject<NursingOrderDetail>(nosd.id);
                        nursingOrderScheduleDetailImported.WorkListDate = nosd.startDate;
                        nursingOrderScheduleDetailImported.AppointmentWithoutResources[0].AppDateTime = nosd.startDate;
                    }
                }
            }

            //viewModel._InPatientPhysicianApplication.NursingOrders.Where(x=>x.)

            //Uzmanlığa taşındı
            //if (viewModel.newBornIntensiveCareFormViewModel != null)
            //{
            //    var newBornIntensiveCare = viewModel.newBornIntensiveCareFormViewModel.AddViewModelToContext(objectContext);
            //    inPatientPhysicianApplication.NewBornIntensiveCare = newBornIntensiveCare;
            //}

            //ENabız Kaydetmek için
            if (viewModel.ENabizViewModels != null)
            {
                foreach (var enabizViewModel in viewModel.ENabizViewModels)
                {
                    enabizViewModel.AddENabizObjectViewModelToContext(objectContext);
                }
            }

            //Fizyoterapi İsteği Başlatmak için
            if (viewModel.StartPhysiotherapyRequest == true && viewModel.HasAuthorityForPhysiotherapyRequest == true)
            {
                bool isPhysiotherapyRequest = false;
                foreach (var episodeaction in inPatientPhysicianApplication.LinkedActions)
                {
                    if (episodeaction is PhysiotherapyRequest)
                    {
                        isPhysiotherapyRequest = true;
                        break;
                    }
                }

                if (isPhysiotherapyRequest != true)
                {
                    try
                    {
                        PhysiotherapyRequest physiotherapyRequest = new PhysiotherapyRequest(objectContext, inPatientPhysicianApplication);
                        physiotherapyRequest.PhysiotherapyRequestDate = DateTime.Now;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            //Yoğun Bakım Hastaları için
            // ASLI: İşlemler bu aşamaya gelmeden kaydedildiği için postscriptte exception fırlatıldığında obje kaydolmamış ama işlemler kaydedilmiş oluyor kullanıcı tekrar kaydete bastığında işlemler çoklanıyor. Bu yüzden kontrol kapatıldı clienta taşındı.
            //if (inPatientPhysicianApplication.InPatientTreatmentClinicApp != null && ((ResWard)inPatientPhysicianApplication.InPatientTreatmentClinicApp.MasterResource).IsIntensiveCare == true)
            //{

            //    IntensiveCareSpecialityObj _intensiveCareSpecialityObj = new IntensiveCareSpecialityObj();
            //    if (inPatientPhysicianApplication.SpecialityBasedObject.Count() > 0)
            //    {
            //        _intensiveCareSpecialityObj = inPatientPhysicianApplication.SpecialityBasedObject.FirstOrDefault() as IntensiveCareSpecialityObj;
            //    }

            //    //Yoğun Bakım Hastaları için -> Yatış tarihinin üzerinden 24 saat geçmiş ise skor girişinin zorunlu olması gerekmektedir.
            //    if (Common.RecTime() > inPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicInpatientDate.Value.AddDays(1))
            //    {
            //        IntensiveCareTypeEnum IntensiveCareType = _intensiveCareSpecialityObj.SetIntensiveCareType(inPatientPhysicianApplication.Episode.Patient);
            //        if (IntensiveCareType == IntensiveCareTypeEnum.AdultIntensiveCare)
            //        {
            //            if (inPatientPhysicianApplication.ApacheScores != null && inPatientPhysicianApplication.ApacheScores.Count == 0)
            //            {
            //                throw new Exception("Yoğun Bakım Hastaları için Apache Skoru Girilmesi Zorunludur!");
            //            }
            //            if (inPatientPhysicianApplication.GlaskowScores != null && inPatientPhysicianApplication.GlaskowScores.Count == 0)
            //            {
            //                throw new Exception("Yoğun Bakım Hastaları için Glaskow Skoru Girilmesi Zorunludur!");
            //            }
            //        }
            //        else if (IntensiveCareType == IntensiveCareTypeEnum.NewBornIntensiveCare)
            //        {
            //            if (inPatientPhysicianApplication.SnappeScores != null && inPatientPhysicianApplication.SnappeScores.Count == 0)
            //            {
            //                throw new Exception("Yenidoğan Yoğun Bakım Hastaları için Snappe II Skoru Girilmesi Zorunludur!");
            //            }
            //        }
            //        else if (IntensiveCareType == IntensiveCareTypeEnum.ChildIntensiveCare)
            //        {
            //            if (inPatientPhysicianApplication.Prisms != null && inPatientPhysicianApplication.Prisms.Count == 0)
            //            {
            //                throw new Exception("Yoğun Bakım Hastaları için Prism Skoru Girilmesi Zorunludur!");
            //            }
            //            if (inPatientPhysicianApplication.GlaskowScores != null && inPatientPhysicianApplication.GlaskowScores.Count == 0)
            //            {
            //                throw new Exception("Yoğun Bakım Hastaları için Glaskow Skoru Girilmesi Zorunludur!");
            //            }
            //        }
            //    }
            //}


            //Uzmanlık Kaydetmek için
            if (viewModel.SpecialityBasedObjectViewModels != null)
            {
                foreach (var specialityBasedObjectViewModel in viewModel.SpecialityBasedObjectViewModels)
                {
                    if (specialityBasedObjectViewModel is ISpecialityBasedObjectViewModel)
                    {
                        ((ISpecialityBasedObjectViewModel)specialityBasedObjectViewModel).AddSpecialityBasedObjectViewModelToContext(objectContext);
                    }
                }
            }
            if (inPatientPhysicianApplication.TransDef != null)
            {
                if (inPatientPhysicianApplication.TransDef.FromStateDefID == InPatientPhysicianApplication.States.Application && inPatientPhysicianApplication.TransDef.ToStateDefID == InPatientPhysicianApplication.States.Discharged)
                {
                    EpisodeAction examinationAction = inPatientPhysicianApplication.SubEpisode.EpisodeActions.Where(action => (action is PatientExamination) && (((PatientExamination)action).EmergencyIntervention != null && ((PatientExamination)action).EmergencyIntervention.ObjectID == inPatientPhysicianApplication.EmergencyIntervention.ObjectID)).First();
                    ((PatientExamination)examinationAction).TreatmentResult = viewModel.TreatmentResult;

                    //Çıkış şekli değiştirildiyse morg işlemi iptal ediliyor. Methodun içinde dischargetype kontrol edildiği için tekrar eklenmedi
                    if (viewModel._MorgueViewModel != null && viewModel._MorgueViewModel._Morgue != null)
                    {
                        viewModel._MorgueViewModel.AddMorgueViewModelToContext(objectContext, inPatientPhysicianApplication);
                    }

                    if (viewModel.HasMorgue)
                    {
                        inPatientPhysicianApplication.CheckAndCancelMorgue(viewModel.TreatmentResult);
                    }
                }
            }
        }


        public void ArrangeButtons(InPatientPhysicianApplicationFormViewModel viewModel)
        {

            List<TTObjectStateTransitionDef> removedOutgoingTransitions = new List<TTObjectStateTransitionDef>();
            foreach (var trans in viewModel.OutgoingTransitions)
            {
                if (trans.ToStateDefID == InPatientPhysicianApplication.States.Cancelled)
                    removedOutgoingTransitions.Add(trans);
                else if (trans.ToStateDefID == InPatientPhysicianApplication.States.PreDischarged)
                    removedOutgoingTransitions.Add(trans);
                else if (trans.ToStateDefID == InPatientPhysicianApplication.States.Discharged && viewModel._InPatientPhysicianApplication.EmergencyIntervention == null)
                    removedOutgoingTransitions.Add(trans);
            }
            foreach (var removedtrans in removedOutgoingTransitions)
            {
                viewModel.OutgoingTransitions.Remove(removedtrans);
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Klinik_Doktor_Islemleri_Genel_Ekran)]
        public MealTypes CreateNewMealType()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return new MealTypes(objectContext);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Klinik_Doktor_Islemleri_Genel_Ekran)]
        public List<PeriodicOrderDetail> GetEmptyOrderDetail(NursingOrder nursingOrder)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                NursingOrder order = (NursingOrder)objectContext.AddObject(nursingOrder);
                return PeriodicOrder.CreateOrderDetails(order);
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Klinik_Doktor_Islemleri_Genel_Ekran)]
        public List<NursingOrderDetail> GetOrderDetailByNUrsingORder(string OrderID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return NursingOrderDetail.GetNODByPeriodicOrder(objectContext, OrderID).ToList<NursingOrderDetail>();
                //return order.OrderDetails.ToList<NursingOrderDetail>();
            }
        }

        private string createDODSummary(DietOrderDetail.GetDODByPhysicianApplicationAndDate_Class dod)
        {
            string _returnValue = TTUtils.CultureService.GetText("M27189", "Verilecek Öğünler :");
            if (dod.Breakfast.HasValue && dod.Breakfast.Value)
                _returnValue += " Sabah";
            if (dod.Lunch.HasValue && dod.Lunch.Value)
                _returnValue += " ,Öğlen";
            if (dod.Dinner.HasValue && dod.Dinner.Value)
                _returnValue += " ,Akşam";
            if (dod.NightBreakfast.HasValue && dod.NightBreakfast.Value)
                _returnValue += " ,Gece Kahvaltısı";
            if (dod.Snack1.HasValue && dod.Snack1.Value)
                _returnValue += " ,1.Ara Öğün";
            if (dod.Snack2.HasValue && dod.Snack2.Value)
                _returnValue += " ,2.Ara Öğün";
            if (dod.Snack3.HasValue && dod.Snack3.Value)
                _returnValue += " ,3.Ara Öğün";
            return _returnValue;
        }


        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Klinik_Doktor_Islemleri_Genel_Ekran)]
        public List<OrderScheduleDetail> GetNursingOrderDetailsByDate(string StartDate, string EndDate, Guid inPatientPhysicianApplicationObjectID)
        {
            var orderScheduleDetailList = new List<OrderScheduleDetail>();
            using (var objectContext = new TTObjectContext(true))
            {
                var startdate = Convert.ToDateTime(StartDate).Date;
                var enddate = Convert.ToDateTime(EndDate).Date.AddDays(1).AddMinutes(-1);
                NursingOrderDetail.GetNODByPhysicianApplicationAndDate_Class[] _nodList = NursingOrderDetail.GetNODByPhysicianApplicationAndDate(objectContext, inPatientPhysicianApplicationObjectID.ToString(), startdate, enddate).ToArray();

                foreach (NursingOrderDetail.GetNODByPhysicianApplicationAndDate_Class _nod in _nodList)
                {
                    OrderScheduleDetail nosd = new OrderScheduleDetail();
                    DateTime _tempDate = _nod.WorkListDate.Value.AddMinutes(30);
                    nosd.id = _nod.ObjectID.Value;
                    nosd.text = _nod.Name;
                    nosd.typeId = OrderTypeEnum.NursingOrder; //Direktif
                    nosd.startDate = _nod.WorkListDate.Value;
                    nosd.endDate = _tempDate.Day != nosd.startDate.Day ? _nod.WorkListDate.Value.AddMinutes(30 - (_tempDate.Minute + 1)) : _tempDate;
                    nosd.statusName = _nod.Statusname.ToString();
                    nosd.periodStartTime = _nod.PeriodStartTime.Value; //bu saatten öncesine detay saati değişmesi
                    nosd.isChanged = false;

                    #region Sonuç
                    string _res = _nod.Result;
                    _res += _nod.Result_Pulse != null ? " Nabız: " + _nod.Result_Pulse : "";
                    _res += _nod.ResultBloodPressure != null ? " Tan: " + _nod.ResultBloodPressure : "";
                    nosd.Result = _res;
                    #endregion

                    nosd.StateID = _nod.CurrentStateDefID.ToString();
                    orderScheduleDetailList.Add(nosd);
                }
            }
            return orderScheduleDetailList;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Klinik_Doktor_Islemleri_Genel_Ekran)]
        public List<OrderScheduleDetail> GetDietOrderDetailsByDate(string StartDate, string EndDate, Guid inPatientPhysicianApplicationObjectID)
        {
            var orderScheduleDetailList = new List<OrderScheduleDetail>();
            using (var objectContext = new TTObjectContext(true))
            {
                var startdate = Convert.ToDateTime(StartDate).Date;
                var enddate = Convert.ToDateTime(EndDate).Date.AddDays(1).AddMinutes(-1);
                var _dodList = DietOrderDetail.GetDODByPhysicianApplicationAndDate(objectContext, inPatientPhysicianApplicationObjectID.ToString(), startdate, enddate).ToArray();

                foreach (var _dod in _dodList)
                {
                    OrderScheduleDetail osd = new OrderScheduleDetail();
                    osd.id = _dod.ObjectID.Value;
                    osd.text = _dod.Name + " - " + createDODSummary(_dod);
                    osd.typeId = OrderTypeEnum.DietOrder; //Direktif
                    osd.startDate = _dod.WorkListDate.Value.Date;
                    osd.endDate = _dod.WorkListDate.Value.Date;
                    osd.statusName = _dod.Statusname.ToString();
                    osd.periodStartTime = _dod.PeriodStartTime.Value; //bu saatten öncesine detay saati değişmesi
                    osd.isChanged = false;
                    osd.allDay = true;
                    osd.Result = String.Empty; ;
                    osd.StateID = _dod.CurrentStateDefID.ToString();
                    orderScheduleDetailList.Add(osd);
                }
            }
            return orderScheduleDetailList;

        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Klinik_Doktor_Islemleri_Genel_Ekran)]
        public void CancelNursingOrder(Guid ObjectID, string ReasonOfCancel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var _nOrder = objectContext.GetObject<NursingOrder>(ObjectID);
                _nOrder.ReasonOfCancel = ReasonOfCancel;
                ((ITTObject)_nOrder).Cancel();
                objectContext.Save(); //cancel nedenini kaydetmek için
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Klinik_Doktor_Islemleri_Genel_Ekran)]
        public void CancelDietOrder(Guid ObjectID, string ReasonOfCancel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var _dOrder = objectContext.GetObject<DietOrder>(ObjectID);
                _dOrder.ReasonOfCancel = ReasonOfCancel;

                foreach (DietOrderDetail dietOrderDetail in _dOrder.OrderDetails)
                {
                    if (dietOrderDetail.CurrentStateDefID == DietOrderDetail.States.Execution)
                    {
                        dietOrderDetail.ReasonOfCancel = ReasonOfCancel;
                        ((ITTObject)dietOrderDetail).Cancel();
                    }

                }

                if (_dOrder.CurrentStateDefID != DietOrder.States.Cancelled)
                {
                    if (_dOrder.OrderDetails.Select("").Where(x => x.IsCancelled == false).Count() <= 0)
                    {
                        _dOrder.CurrentStateDefID = DietOrder.States.Cancelled;
                    }
                }

                //((ITTObject)_dOrder).Cancel();
                objectContext.Save(); //cancel nedenini kaydetmek için


            }
        }

        private void ChangeDietOrder(DietOrder order, TTObjectContext objectContext)
        {
            MealTypeTimeDefinition.GetMealTypeTimeDefinitionList_Class timeList = MealTypeTimeDefinition.GetMealTypeTimeDefinitionList(" WHERE ISACTIVE = 1 ORDER BY LASTUPDATE DESC").FirstOrDefault();
            bool dietDetailChange = false;

            foreach (DietOrderDetail dietOrderDetail in order.OrderDetails)
            {
                dietDetailChange = false;
                if (timeList != null)//diyet öğün tanımlar yapıldı ise
                {
                    if (dietOrderDetail.WorkListDate.Value.Date == DateTime.Now.Date)//bugunki detail
                    {
                        //bugunki detay için diyetin iptal edildiği saat öğün tanım saatinden küçük ise o öğün verilmeyecek gibi check-i kaldır
                        if (timeList.Breakfast.Value.Hour > DateTime.Now.Hour)
                        {
                            dietOrderDetail.MealType.Breakfast = false;
                            dietDetailChange = true;
                        }
                        if (timeList.Lunch.Value.Hour > DateTime.Now.Hour)
                        {
                            dietOrderDetail.MealType.Lunch = false;
                            dietDetailChange = true;
                        }
                        if (timeList.Dinner.Value.Hour > DateTime.Now.Hour)
                        {
                            dietOrderDetail.MealType.Dinner = false;
                            dietDetailChange = true;
                        }
                        if (timeList.NightBreakfast.Value.Hour > DateTime.Now.Hour)//eğer gece 12 den sonra verilecek diye tanımlanır ise bir üstteki if içine alınabilir
                        {
                            dietOrderDetail.MealType.NightBreakfast = false;
                            dietDetailChange = true;
                        }
                        if (timeList.Snack1.Value.Hour > DateTime.Now.Hour)
                        {
                            dietOrderDetail.MealType.Snack1 = false;
                            dietDetailChange = true;
                        }
                        if (timeList.Snack2.Value.Hour > DateTime.Now.Hour)
                        {
                            dietOrderDetail.MealType.Snack2 = false;
                            dietDetailChange = true;
                        }
                        if (timeList.Snack3.Value.Hour > DateTime.Now.Hour)
                        {
                            dietOrderDetail.MealType.Snack3 = false;
                            dietDetailChange = true;
                        }

                        if (dietDetailChange == false)//eğer hiç bir öğünün verilme saati geçmedi ise bugunü de iptal edebilir
                        {
                            dietOrderDetail.ReasonOfCancel = order.ReasonOfCancel;
                            ((ITTObject)dietOrderDetail).Cancel();
                        }
                    }
                    else//diğer günleri iptal et
                    {
                        dietOrderDetail.ReasonOfCancel = order.ReasonOfCancel;
                        ((ITTObject)dietOrderDetail).Cancel();
                    }
                }
                else
                {
                    throw new Exception("Öğün zaman tanımları yapılmadığı için işleme devam edilemiyor");
                }


            }

            if (order.CurrentStateDefID != DietOrder.States.Cancelled)
            {
                if (order.OrderDetails.Select("").Where(x => x.IsCancelled == false).Count() <= 0)
                {
                    order.CurrentStateDefID = DietOrder.States.Cancelled;
                }
            }

            order.ReasonOfReject = "";//clientdan kontrol edilen veri

            objectContext.Update();

        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Klinik_Doktor_Islemleri_Genel_Ekran)]
        public void SaveNursingOrderTemplate(SaveNursingOrderTemplateViewModel NursingOrderTemplateViewModel)
        {
            TTObjectContext objContext = new TTObjectContext(false);
            Resource ownerResource = (Resource)objContext.GetObject(Common.CurrentResource.ObjectID, "Resource");

            //NursingOrderTemplate newPackTemplateDef = new NursingOrderTemplate(objContext);
            objContext.AddObject(NursingOrderTemplateViewModel.PackageTemplateDef);
            objContext.AddToRawObjectList(NursingOrderTemplateViewModel.OrderTemplateDetails);
            objContext.ProcessRawObjects();
            NursingOrderTemplate newPackTemplateDef = (NursingOrderTemplate)objContext.GetLoadedObject(NursingOrderTemplateViewModel.PackageTemplateDef.ObjectID);
            foreach (var item in objContext.LocalQuery<NursingOrderTemplateDetail>())
            {
                item.NursingOrderTemplate = newPackTemplateDef;
            }

            newPackTemplateDef.OwnerResource = ownerResource;

            //foreach (Guid reqId in PackageTemplateDef.PackageRequestedProcedures)
            //{

            //    IBindingList procReqFormDet = ProcedureRequestFormDetailDefinition.GetProcedureRequestFormDetailByObjectId(objContext, reqId);
            //    if (procReqFormDet.Count > 0)
            //    {
            //        PackageTemplateProcReqFormDetailDefinition packTempProcReqFormDet = new PackageTemplateProcReqFormDetailDefinition(objContext);
            //        packTempProcReqFormDet.ProcedureReqFormDetailDef = (ProcedureRequestFormDetailDefinition)procReqFormDet[0];
            //        newPackTemplateDef.ProcedureRequestFormDetailDefinitions.Add(packTempProcReqFormDet);
            //    }
            //    else
            //    {
            //        PackageTemplateProcedureDefinition packTempProcDef = new PackageTemplateProcedureDefinition(objContext);
            //        ProcedureDefinition procedureDef = (ProcedureDefinition)objContext.GetObject(reqId, "ProcedureDefinition");
            //        packTempProcDef.ProcedureDefinition = procedureDef;
            //        newPackTemplateDef.ProcedureDefinitions.Add(packTempProcDef);
            //    }

            //}

            objContext.Save();
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Klinik_Doktor_Islemleri_Genel_Ekran)]
        public NursingOrderTemplate[] GetNursingOrderTemplate()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                Resource ownerResource = (Resource)objectContext.GetObject(Common.CurrentResource.ObjectID, "Resource");
                int index = 0;

                System.ComponentModel.BindingList<NursingOrderTemplate> list = NursingOrderTemplate.GetNursingOrderTemplateByResource(objectContext, ownerResource.ObjectID);

                NursingOrderTemplate[] not = new NursingOrderTemplate[list.Count];

                foreach (var item in list)
                {
                    not[index] = new NursingOrderTemplate();

                    not[index] = item;

                    index++;

                }

                return not;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Klinik_Doktor_Islemleri_Genel_Ekran)]
        public NursingOrderTemplateDetail[] GetNursingOrderTempDetail(Guid TempID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                int index = 0;

                System.ComponentModel.BindingList<NursingOrderTemplateDetail.GetNursingOrderTemplateDetailByTemplateID_Class> list = NursingOrderTemplateDetail.GetNursingOrderTemplateDetailByTemplateID(objectContext, TempID);

                NursingOrderTemplateDetail[] not = new NursingOrderTemplateDetail[list.Count];

                foreach (var item in list)
                {
                    not[index] = new NursingOrderTemplateDetail(objectContext);
                    ProcedureDefinition pd = (ProcedureDefinition)objectContext.GetObject(item.Procedureid.Value, "ProcedureDefinition");

                    not[index].RecurrenceDayAmount = item.RecurrenceDayAmount;
                    not[index].AmountForPeriod = item.AmountForPeriod;
                    not[index].Frequency = item.Frequency;
                    not[index].NursingOrderObject = pd;

                    index++;

                }

                return not;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Klinik_Doktor_Islemleri_Genel_Ekran)]
        public InPatientPhysicianProgressesInfoViewModel GetInPatientPhysicianProgressesInfoViewModelByDate(string lastLoadedProgressesInfoDate, Guid inPatientPhysicianApplicationObjectID)
        {
            var inPatientPhysicianProgressesInfoViewModel = new InPatientPhysicianProgressesInfoViewModel();
            using (var objectContext = new TTObjectContext(true))
            {
                var DAYDURATIONFORLOADING = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("DAYDURATIONFORLOADING", "10"));
                var endDate = Convert.ToDateTime(lastLoadedProgressesInfoDate).Date;
                var startDate = endDate.AddDays(-1 * DAYDURATIONFORLOADING);


                inPatientPhysicianProgressesInfoViewModel.ProgressesGridList = InPatientPhysicianProgresses.GetByInpatientPhysicianAndDate(objectContext, inPatientPhysicianApplicationObjectID.ToString(), startDate, endDate).ToArray();

                if (inPatientPhysicianProgressesInfoViewModel.ProgressesGridList.Length < 1)
                {
                    var maxEndDate = InPatientPhysicianProgresses.GetMaxProgressDateByDate(objectContext, inPatientPhysicianApplicationObjectID.ToString(), startDate);

                    if (maxEndDate.Count > 0)
                    {
                        if (maxEndDate[0].Maxprogressdate != null)
                        {
                            endDate = Convert.ToDateTime(maxEndDate[0].Maxprogressdate).Date.AddDays(1);
                            startDate = endDate.AddDays(-1 * DAYDURATIONFORLOADING);
                            inPatientPhysicianProgressesInfoViewModel.ProgressesGridList = InPatientPhysicianProgresses.GetByInpatientPhysicianAndDate(objectContext, inPatientPhysicianApplicationObjectID.ToString(), startDate, endDate).ToArray();
                        }
                    }
                }
                inPatientPhysicianProgressesInfoViewModel.lastLoadedProgressesInfoDate = startDate;

                var userList = new List<ResUser>();
                foreach (var pG in inPatientPhysicianProgressesInfoViewModel.ProgressesGridList)
                {
                    if (pG.ProcedureDoctor != null && !userList.Contains(pG.ProcedureDoctor))
                        userList.Add(pG.ProcedureDoctor);
                }
                inPatientPhysicianProgressesInfoViewModel.ResUsers = userList.ToArray();
            }
            return inPatientPhysicianProgressesInfoViewModel;
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Taburcu_Islemleri_Problem_Sorgulama, TTRoleNames.Klinik_Doktor_Islemleri_Genel_Ekran)]
        public string GetOrdersToCancel(OrdersToCancelParameterViewModel ordersToCancelParameterViewModel)// #TABURCULUK Taburcu tarihinden sonra Girilmiş Hizmet ve Orderları iptal etmek için uyarı veren kod
        {
            using (var objectContext = new TTObjectContext(false))
            {
                string warning = string.Empty;
                string warningPharmacy = string.Empty;
                string preString = " ";
                string ftrString = "";
                InPatientPhysicianApplication inPatientPhysicianApp = null;
                if (ordersToCancelParameterViewModel.InPatientPhysicianAppObjectID != null)
                {
                    inPatientPhysicianApp = (InPatientPhysicianApplication)objectContext.GetObject(new Guid(ordersToCancelParameterViewModel.InPatientPhysicianAppObjectID), "InPatientPhysicianApplication");
                }
                else if (ordersToCancelParameterViewModel.InPatientTreatmentClinicAppObjectID != null)
                {
                    InPatientTreatmentClinicApplication inPatientTreatmentClinicApp = (InPatientTreatmentClinicApplication)objectContext.GetObject(new Guid(ordersToCancelParameterViewModel.InPatientTreatmentClinicAppObjectID), "InPatientTreatmentClinicApplication");
                    foreach (var treatmentClinicApp in inPatientTreatmentClinicApp.InPatientPhysicianApplication)
                    {
                        inPatientPhysicianApp = treatmentClinicApp;
                        break;
                    }
                }
                if (inPatientPhysicianApp != null)
                {
                    List<DrugOrder> drugOrderList = new List<DrugOrder>();
                    List<string> nursingOrderList = new List<string>();
                    List<string> dietOrderList = new List<string>();


                    //Queryler değişirse InpatientPhysitionApplication CancelOrders da değişmeli
                    if (ordersToCancelParameterViewModel.IsPreDischarge == true && ordersToCancelParameterViewModel.DischargeDate != null)
                    {
                        preString = "İleri Tarihli ";
                        drugOrderList = inPatientPhysicianApp.DrugOrders.Where(dr => dr.DrugOrderDetails.FirstOrDefault(drd => drd.OrderPlannedDate.Value.Date > ordersToCancelParameterViewModel.DischargeDate.Date
                                                                        && drd.CurrentStateDef.Status == StateStatusEnum.Uncompleted) != null).ToList();

                        nursingOrderList = inPatientPhysicianApp.NursingOrders.Where(dr => dr.OrderDetails.FirstOrDefault(drd => drd.WorkListDate.Value.Date > ordersToCancelParameterViewModel.DischargeDate.Date
                                                                        && (drd.CurrentStateDefID == NursingOrderDetail.States.Execution)) != null).Select(dr => dr.ProcedureObject.Name).Distinct().ToList();

                        dietOrderList = inPatientPhysicianApp.DietOrders.Where(dr => dr.OrderDetails.FirstOrDefault(drd => drd.WorkListDate.Value.Date > ordersToCancelParameterViewModel.DischargeDate.Date
                                                                 && (drd.CurrentStateDefID == DietOrderDetail.States.Execution || drd.CurrentStateDefID == DietOrderDetail.States.Approval)) != null).Select(dr => dr.ProcedureObject.Name).Distinct().ToList();
                    }
                    else
                    {
                        drugOrderList = inPatientPhysicianApp.DrugOrders.Where(dr => dr.IsTransfered != true && dr.DrugOrderDetails.FirstOrDefault(drd => drd.CurrentStateDef.Status == StateStatusEnum.Uncompleted) != null).ToList();

                        nursingOrderList = inPatientPhysicianApp.NursingOrders.Where(dr => dr.OrderDetails.FirstOrDefault(drd => (drd.CurrentStateDefID == NursingOrderDetail.States.Execution)) != null).Select(dr => dr.ProcedureObject.Name).Distinct().ToList();
                        dietOrderList = inPatientPhysicianApp.DietOrders.Where(dr => dr.OrderDetails.FirstOrDefault(drd => (drd.CurrentStateDefID == DietOrderDetail.States.Execution || drd.CurrentStateDefID == DietOrderDetail.States.Approval)) != null).Select(dr => dr.ProcedureObject.Name).Distinct().ToList();
                    }

                    foreach (var drugOrder in drugOrderList)
                    {
                        warning = warning + "\n" + drugOrder.Material.Name + " / ";
                    }
                    foreach (var nursingOrder in nursingOrderList)
                    {
                        warning = warning + "\n" + nursingOrder + " / ";
                    }

                    foreach (var dietOrder in dietOrderList)
                    {
                        warning = warning + "\n" + dietOrder + " / ";
                    }



                    var uncompletedRequest = inPatientPhysicianApp.Episode.PhysiotherapyRequests.Where(c => c.MasterAction == inPatientPhysicianApp && c.CurrentStateDef.Status == StateStatusEnum.Uncompleted);
                    if (uncompletedRequest.Count() > 0)
                    {
                        //var uncompletedOldPhysiotherapyRequest = uncompletedRequest.FirstOrDefault().PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution && c.PlannedDate.Value.Date <= ordersToCancelParameterViewModel.DischargeDate.Date);
                        //if (uncompletedOldPhysiotherapyRequest.Count() > 0)
                        //{
                        ftrString = "\n" + "Uygulanmayan ileri tarihli F.T.R. işlemleri iptal edilecek; F.T.R. seansı tamamlanacaktır. " + "\n";
                        //}
                    }

                    IBindingList waitingKscheduleList = objectContext.QueryObjects("KSCHEDULE", " INPATIENTPHYSICIANAPPLICATION = " + TTConnectionManager.ConnectionManager.GuidToString(inPatientPhysicianApp.ObjectID) + " AND CURRENTSTATEDEFID = STATES.REQUESTPREPARATION");
                    foreach (var item in waitingKscheduleList)
                    {
                        warningPharmacy += ((KSchedule)item).StockActionID.ToString() + ",";
                    }
                }

                if (!string.IsNullOrEmpty(warning))
                {
                    warning = "Hastaya Uygulanmayan " + preString + "Orderlar İptal Edilecektir." + ftrString + " Devam etmek istiyor musunuz? " + warning;
                }
                else if (!string.IsNullOrEmpty(ftrString))
                {
                    warning = ftrString + " Devam etmek istiyor musunuz? ";
                }
                else if (!string.IsNullOrEmpty(warningPharmacy))
                {
                    warning = "Hastanın Eczanede Bekleyen İşlemleri Bulunmaktadır. İşlem Numaraları : " + warningPharmacy.Substring(0, warningPharmacy.Length - 1) + " Devam etmek istiyor musunuz? ";
                }
                return warning;
            }
        }


        //Anne-Bebek Bilgileri ekranı başlatma
        [HttpGet]
        public RegularObstetric StartBirthResult(Guid episodeActionId)
        {
            //using (var objectContext = new TTObjectContext(false))
            //{
            //    EpisodeAction _masterEpisodeAction = objectContext.GetObject<EpisodeAction>(episodeActionId);
            //    RegularObstetric regularObstetric = new RegularObstetric(objectContext);

            //    regularObstetric.Patient = _masterEpisodeAction.Episode.Patient;

            //    if (regularObstetric.Patient.ActivePregnancy != null)
            //    {
            //        regularObstetric.Pregnancy = regularObstetric.Patient.ActivePregnancy;
            //    }
            //    else
            //    {
            //        regularObstetric.Pregnancy = new Pregnancy(objectContext);
            //        //?????????????????????? yeni pregnancy oluşturulacak
            //    }

            //    ////StarterSubEpisode ya da Starter Episode eklenmeli mi?
            //    return regularObstetric;
            //}
            //Yukarısı eski kod aşağısı test edilmeli


            using (var objectContext = new TTObjectContext(false))
            {
                //Fizyoterapi İsteği Başlatmak için  viewModel.StartPhysiotherapyRequest == true && 

                bool isBirthResult = false;

                EpisodeAction _masterEpisodeAction = objectContext.GetObject<EpisodeAction>(episodeActionId);

                if (_masterEpisodeAction.SubEpisode.IsInvoicedCompletely)
                {
                    throw new Exception(TTUtils.CultureService.GetText("M25838", "Hastanın faturası kesilmiş olduğu için Doğum İşlemi başlatamazsınız!"));
                }

                if (!_masterEpisodeAction.SubEpisode.IsDiagnosisExists())
                {
                    string[] hataParamList = new string[] { "'Doğum İsteği'" };
                    throw new TTUtils.TTException(SystemMessage.GetMessageV3(1128, hataParamList));
                }

                foreach (var item in _masterEpisodeAction.Episode.RegularObstetrics)
                {
                    if (item.CurrentStateDefID != RegularObstetric.States.Cancelled)
                    {
                        isBirthResult = true;
                        RegularObstetric _regularObstetric = objectContext.GetObject<RegularObstetric>(item.ObjectID);
                        objectContext.FullPartialllyLoadedObjects();
                        return _regularObstetric;
                    }
                }


                RegularObstetric regularObstetric = new RegularObstetric(objectContext, _masterEpisodeAction);
                return regularObstetric;

            }

        }


        //Hemodiyaliz Kabul ekranı başlatma
        [HttpGet]
        public HemodialysisRequest StartHemodialysisRequest(Guid episodeActionId)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                //Hemodiyaliz İsteği Başlatmak için  viewModel.StartPhysiotherapyRequest == true && 

                EpisodeAction _masterEpisodeAction = objectContext.GetObject<EpisodeAction>(episodeActionId);

                if (_masterEpisodeAction.SubEpisode.IsInvoicedCompletely)
                {
                    throw new Exception(TTUtils.CultureService.GetText("M25838", "Hastanın faturası kesilmiş olduğu için Hemodiyaliz İşlemi başlatamazsınız!"));
                }

                if (!_masterEpisodeAction.SubEpisode.IsDiagnosisExists())
                {
                    string[] hataParamList = new string[] { "'Hemodiyaliz İsteği'" };
                    throw new TTUtils.TTException(SystemMessage.GetMessageV3(1128, hataParamList));
                }

                BindingList<HemodialysisRequest> patientHemodialysis = HemodialysisRequest.GetHemodialysisRequestByPatient(objectContext, _masterEpisodeAction.Episode.Patient.ObjectID);
                if (patientHemodialysis.Count() > 0)//hastanın devam eden tedavisi varsa onun üzerinden işlem devam edecek.
                {
                    //return patientHemodialysis.FirstOrDefault();
                    throw new Exception("Devam eden Hemodiyaliz olduğu için yenisini başlatamazsınız!");
                }
                else//devam eden tedavi yoksa yeni hemodiyaliz oluşturulur.
                {
                    try
                    {
                        HemodialysisRequest _hemodialysisRequest = new HemodialysisRequest(objectContext, _masterEpisodeAction);
                        _hemodialysisRequest.HemodialysisRequestDate = DateTime.Now;
                        _hemodialysisRequest.CurrentStateDefID = HemodialysisRequest.States.Request;
                        objectContext.Save();
                        return _hemodialysisRequest;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

        }


        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.E_Dogum_Raporu_Listeleme)]
        public string OpenEDogumReportIndex()
        {
            string url = string.Empty;

            string UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            string ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "");
            string IdentityNumber = Common.CurrentResource.UniqueNo;
            string role = "";
            TTUser user = Common.CurrentUser;
            if (user.HasRole(TTRoleNames.Sekreter))
            {
                role = "5DDEB487-A0C2-47D6";
                url = "http://xxxxxx.com/DogumWeb/Dogum/SecIndex";
            }
            if (user.HasRole(TTRoleNames.Tabip))
            {
                role = "6AAB18C7-B16B-4A04";
                url = "http://xxxxxx.com/DogumWeb/Dogum/DoctorIndex";
            }
            if (user.HasRole(TTRoleNames.Bastabip))
            {
                role = "417A9319-6430-490C";
                url = "http://xxxxxx.com/DogumWeb/Dogum/HeadDoc";
            }
            if (role == "")
            {
                role = "7AE271CC-5C57-4A77";    //HBYS
                url = "http://xxxxxx.com/DogumWeb/Dogum/Index";
            }
            var uri = new Uri("http://xxxxxx.com/AuthApi/connect/token?username=" + UserName + "&password=" + Password +
                "&applicationCode=" + ApplicationCode + "&identityNumber=" + IdentityNumber + "&role=" + role);
            var client = new RestClient(uri);

            var request = new RestSharp.RestRequest();
            request.Method = Method.POST;
            var result = client.Execute(request);
            if (result.StatusCode.ToString() == "OK")
            {
                var token = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(result.Content)["data"]["access_token"];

                url += "?Authorization=" + token;
            }
            else
            {
                throw new Exception("Token Alınırken bir hata ile karşılaşıldı.");
            }
            return url;
        }


        public bool UpdateSEPTedaviTipi(Guid sepObjectID, string tedaviTipiKodu)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (!String.IsNullOrEmpty(tedaviTipiKodu))
                {
                    SubEpisodeProtocol sep = objectContext.GetObject(sepObjectID, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                    TedaviTipi tedaviTipi = TedaviTipi.GetTedaviTipiByTedaviTipiKodu(objectContext, tedaviTipiKodu).FirstOrDefault();
                    InvoiceLog.AddInfo(string.Format("Tedavi tipi bilgisi değiştirildi. E.D: {0} Y.D: {1}", sep.MedulaTedaviTipi.tedaviTipiAdi, tedaviTipi.tedaviTipiAdi), sep.ObjectID, InvoiceOperationTypeEnum.UpdateSEPProperties, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                    if (sep.InvoiceStatus == MedulaSubEpisodeStatusEnum.ProvisionNoNotExists)//provizyonsuz hasta
                    {
                        if (!String.IsNullOrEmpty(tedaviTipiKodu))
                        {
                            sep.MedulaTedaviTipi = tedaviTipi;
                        }
                    }
                    else if (!sep.IsInvoiced)//provizyonu olan ama faturalanmamış hasta
                    {
                        if (!String.IsNullOrEmpty(tedaviTipiKodu))
                        {
                            sep.UpdateTedaviTipiFromMedula(Convert.ToInt32(tedaviTipi.tedaviTipiKodu));
                        }
                    }
                    else//faturalanmış hasta
                    {
                        throw new Exception("Faturalanmış hastanın tedavi tipini değiştiremezsiniz!");
                    }
                }

                objectContext.Save();
            }

            return true;
        }


        public string GetPatientLastActiveVacation(string patient)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<string> followerlist = new List<string>();
                string _filter = " AND CURRENTSTATEDEFID <> '" + PatientOnVacation.States.Cancelled + "'";
                List<PatientOnVacation> patients = PatientOnVacation.GetVacationInfoByPatient(objectContext, patient, _filter).ToList();

                if (patients != null && patients.Count > 0)
                {
                    PatientOnVacation fPatient = patients.OrderByDescending(x => x.StartDate.Value).FirstOrDefault();

                    if (fPatient != null)
                    {
                        return fPatient.ObjectID.ToString();
                    }
                }

                return "";

            }
        }

        #region BESİN İLAÇ ETKİLEŞİMİ
        [HttpGet]
        public DrugOrderIntroductionServiceController.PrepareInteraction_Output ShowFoodDrugInteraction(Guid DietOrderID, Guid Episode)
        {
            DrugOrderIntroductionServiceController.PrepareInteraction_Output output = new DrugOrderIntroductionServiceController.PrepareInteraction_Output();

            if (DietOrderID != null && Episode != null)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    List<DrugDrugInteraction> drugDrugInteractions = new List<DrugDrugInteraction>();
                    List<DrugFoodInteraction> drugFoodInteractions = new List<DrugFoodInteraction>();
                    output.drugDrugInteractions = new List<DrugOrderIntroductionServiceController.InteractionDTO>();
                    output.drugFoodInteractions = new List<DrugOrderIntroductionServiceController.InteractionDTO>();
                    DateTime startDate = new DateTime(Common.RecTime().Year, Common.RecTime().Month, Common.RecTime().Day, 0, 0, 0);
                    DateTime endDate = new DateTime(Common.RecTime().Year, Common.RecTime().Month, Common.RecTime().Day, 23, 59, 59);
                    BindingList<DietDefinition.GetDietMaterialsByDefID_Class> foodList = DietDefinition.GetDietMaterialsByDefID(DietOrderID);

                    //foodList = foodList.Select(x => x.ObjectID == DietOrderID).ToList();

                    //DietOrder dietOrder = (DietOrder)objectContext.GetObject(DietOrderID, typeof(DietOrder));

                    //List<Guid> foodList = dietOrder.ProcedureObject.cou

                    BindingList<DrugOrder.GetActiveDrugOrderForFoodInt_Class> drugList = DrugOrder.GetActiveDrugOrderForFoodInt(Episode);

                    for (int i = 0; i < drugList.Count; i++)
                    {
                        DrugDefinition drugDefinition = (DrugDefinition)objectContext.GetObject(drugList[i].Material.Value, typeof(DrugDefinition));

                        foreach (DrugFoodInteraction drugFoodInteraction in drugDefinition.DrugFoodInteractions.Select(string.Empty))
                        {
                            if (foodList.Where(x => x.ObjectID == drugFoodInteraction.DietMaterialDefinition.ObjectID).Any())
                                drugFoodInteractions.Add(drugFoodInteraction);
                        }
                    }


                    foreach (DrugFoodInteraction dfi in drugFoodInteractions)
                    {
                        DrugOrderIntroductionServiceController.InteractionDTO interactionDTO = new DrugOrderIntroductionServiceController.InteractionDTO();
                        interactionDTO.Header = dfi.DrugDefinition.Name + " - " + dfi.DietMaterialDefinition.MaterialName;
                        if (dfi.InteractionLevelType == InteractionLevelTypeEnum.High)
                            interactionDTO.Color = "red";
                        else if (dfi.InteractionLevelType == InteractionLevelTypeEnum.Medium)
                            interactionDTO.Color = "blue";
                        else
                            interactionDTO.Color = "green";
                        interactionDTO.Message = dfi.Message;
                        output.drugFoodInteractions.Add(interactionDTO);
                    }
                }
            }

            return output;
        }
        #endregion

        [HttpGet]

        public Guid? GetOzellikliIzlemVeriSetiByProgress(Guid ObjectId)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                var progress = objectContext.GetObject<InPatientPhysicianProgresses>(ObjectId);
                if (progress.OzellikliIzlemVeriSeti.Count > 0)
                    return progress.OzellikliIzlemVeriSeti[0].ObjectID;
                else
                    return null;
            }
        }
        [HttpGet]
        public ArchiveRequestModel GetPatientEpisodeFolders(Guid EpisodeActionID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                ArchiveRequestModel requestResult = new ArchiveRequestModel();
                EpisodeAction ea = objectContext.GetObject<EpisodeAction>(EpisodeActionID);
                Guid PatientObjectID = ea.Episode.Patient.ObjectID;
                PatientIdentityAndAddress address = ea.Episode.PatientAdmissions[0].PA_Address;

                string result = "";
                if (address != null)
                {
                    if (address.HomeAddress != null)
                    {
                        result += address.HomeAddress;
                    }

                    if (address.SKRSMahalleKodlari != null)
                    {
                        result += " " + address.SKRSMahalleKodlari.ADI;
                    }

                    if (address.BuildingBlockName != null)
                    {
                        result += " " + address.BuildingBlockName;
                    }
                    if (address.DisKapi != null)
                    {
                        result += " BLOK NO:" + address.DisKapi;
                    }
                    if (address.IcKapi != null)
                    {
                        result += " İÇ KAPI NO:" + address.IcKapi;
                    }
                    if (address.HomePostcode != null)
                    {
                        result += " " + address.HomePostcode;
                    }
                    if (address.HomePhone != null)
                    {
                        result += " " + address.HomePhone;
                    }

                    if (address.SKRSKoyKodlari != null)
                    {
                        result += " " + address.SKRSKoyKodlari.ADI;
                    }

                    if (address.SKRSIlceKodlari != null)
                    {
                        result += " " + address.SKRSIlceKodlari.ADI;
                    }

                    if (address.SKRSILKodlari != null)
                    {
                        result += " /" + address.SKRSILKodlari.ADI;
                    }


                }

                string PatientMobilePhone = ea.Episode.PatientAdmissions[0].PA_Address.MobilePhone;
                List<EpisodeFolderModel> folders = new List<EpisodeFolderModel>();
                string filter = " AND this.MyEpisode.Patient = '" + PatientObjectID + "'";
                List<Guid> episodeLocationList = new List<Guid>();
                List<EpisodeFolder.GetFolderDetailByPatientID_Class> episodeFolderList = EpisodeFolder.GetFolderDetailByPatientID(PatientObjectID).ToList();
                var parameter = TTObjectClasses.SystemParameter.GetParameterValue("MANUELARSIVNUMARASIKULLAN", "FALSE");
                foreach (EpisodeFolder.GetFolderDetailByPatientID_Class item in episodeFolderList)
                {
                    EpisodeFolderModel model = new EpisodeFolderModel();
                    if (parameter == "FALSE")
                        model.ArchiveNo = item.EpisodeFolderID;
                    else
                        model.ArchiveNo = item.ManuelArchiveNo;
                    model.ClinicName = item.Name;
                    model.InpatientDate = item.HospitalInPatientDate;
                    model.DischargeDate = item.HospitalDischargeDate;
                    model.ProtocolNo = item.ProtocolNo;
                    model.Location = item.Location;
                    model.ObjectID = item.ObjectID;
                    model.FileCreationAndAnalysis = item.FileCreationAndAnalysis;
                    model.Status = item.DisplayText;

                    folders.Add(model);
                }
                requestResult.PatientEpisodeFolders = folders;
                requestResult.PatientAddress = result;
                requestResult.PatientMobilePhone = PatientMobilePhone;

                return requestResult;
            }
        }

        public Guid CreateArchiveRequest(string inputList, string description, Guid requesterSectionId)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                ArchiveRequest request = new ArchiveRequest(objectContext);
                request.ArchiveRequestDate = Common.RecTime();
                request.Requester = Common.CurrentResource;
                request.RequestCompleted = false;
                request.RequesterSection = objectContext.GetObject<ResSection>(requesterSectionId);
                request.ArchiveRequestDescription = description;
                dynamic folders = null;

                if (!String.IsNullOrEmpty(inputList))
                    folders = JsonConvert.DeserializeObject(inputList);

                if (inputList != null)
                {
                    foreach (var folderId in folders)
                    {
                        EpisodeFolder ef = objectContext.GetObject<EpisodeFolder>((Guid)folderId);
                        FileCreationAndAnalysis fcaa = ef.FileCreationAndAnalysis;
                        EpisodeFolderRequest episodeFolderRequest = new EpisodeFolderRequest(objectContext);
                        episodeFolderRequest.EpisodeFolder = ef;
                        episodeFolderRequest.ArchiveRequest = request;
                        fcaa.CurrentStateDefID = FileCreationAndAnalysis.States.Request;
                        objectContext.Save();
                    }

                }

                return request.ObjectID;
            }

        }
    }
}

namespace Core.Models
{
    public partial class InPatientPhysicianApplicationFormViewModel : BaseNewDoctorExaminationFormViewModel
    {
        public TTObjectClasses.SubEpisodeProtocol SubEpisodeProtocol { get; set; }
        public string bagliTakipNo { get; set; }
        //Anne-Bebek Bilgileri
        public Boolean IsMotherInformationFormOpen { get; set; } //Anne-Bebek Bilgileri Ekranı açılacak mı? true ise açılacak, değilse görünmeyecek

        // Fizyoterapi İşlemleri
        public Boolean StartPhysiotherapyRequest { get; set; }//F.T.R. daha önce başlatıldıysa var olan üzerinden işlem yapılacak
        public bool IsPhysiotherapyRequestFormUsing { get; set; }
        public bool SavePhysiotherapyRequest { get; set; }
        public Boolean HasAuthorityForPhysiotherapyRequest { get; set; } //Fizyoterapi İstek Yapma Yetkisi
                                                                         // .\ Fizyoterapi İşlemleri

        // Doğum İşlemleri
        public Boolean HasAuthorityForObstetricInformationForm { get; set; } //Doğum Başlatma Yetkisi
        public Boolean StartObstetric { get; set; }//Doğum daha önce başlatıldıysa var olan üzerinden işlem yapılacak
                                                   // .\ Doğum İşlemleri

        #region Pandemi olgusu
public DiagnosisGrid CovidDiagnose { get; set; }//Tanı Gridi
        public DiagnosisDefinition CovidDiagnoseDef { get; set; }//Tanı
        public YesNoEnum PrevousPandemicValue { get; set; }//önceki değer
        public bool IsPandemicRequired { get; set; }//pandemi olgusu zorunluluk durumu
        public bool IsIntensiveCare { get; set; }//Yoğun bakım hastası mı?
        public bool IsNonInpatient { get; set; }//false->Yatan hasta true->Günübirlik ya da Müşahade hastası
        #endregion Pandemi olgusu

public Boolean IsAuthorizedToWriteTreatmentReport { get; set; }
        public ReportTypeEnum reportType
        {
            get;
            set;
        }

        public string ProgressDescription
        {
            get;
            set;
        }
        public List<PatientReportInfo> PatientReportInfoList = new List<PatientReportInfo>();
        public DateTime ProgressDate { get; set; }

        public VitalSignAndNursingDefinition[] VitalSignAndNursingDefinitionList
        {
            get;
            set;
        }

        public List<OrderScheduleDetail> _nursingOrderScheduleDetail
        {
            get;
            set;
        }

        public TreatmentDischarge myTreatmentDischarge
        {
            get;
            set;
        }

        public DietDefinition[] DietDefinitionList
        {
            get;
            set;
        }

        public List<OrderScheduleDetail> _dietOrderScheduleDetail
        {
            get;
            set;
        }

        public bool IsNewBorn
        {
            get;
            set;
        }

        public NewBornIntensiveCareFormViewModel newBornIntensiveCareFormViewModel
        {
            get;
            set;
        }

        public Patient _Patient
        {
            get;
            set;
        }


        // BaseNewDoctorExaminationFormViewModel deki kullanılıyor
        //public IENabizViewModel[] ENabizViewModels
        //{
        //    get; set;
        //}


        /**/

        public TTObjectClasses.PatientInterviewForm[] GrdPatientInterviewFormGridList
        {
            get;
            set;
        }

        public TTObjectClasses.DentalExamination[] GrdDentalExaminationGridList
        {
            get;
            set;
        }

        public TTObjectClasses.ConsultationFromExternalHospital[] GrdExternalConsultationGridList
        {
            get;
            set;
        }

        public string NursingApplicationObjectID
        {
            get;
            set;
        }

        public bool includeDrugDefinition
        {
            get;
            set;
        }


        public bool HasFalling
        {
            get;
            set;
        }

        public int fallingWarningAge
        {
            get;
            set;
        }

        public bool physicianSuggestionsIsActive
        {
            get;
            set;
        }

        public NursingApplication _nursingApplication { get; set; }

        public DateTime lastLoadedProgressesInfoDate
        {
            get;
            set;
        }

        public ResPoliclinic[] HCResPoliclinic
        {
            get;
            set;
        }

        public ResUser[] HCDoctorList
        {
            get;
            set;
        }

        public WhoPaysEnum HCModeOfPayment
        {
            get;
            set;
        }

        public string ShowNewDrugOrderForm { get; set; }
        //TODO NIDA 
        //public TTObjectClasses.BaseTreatmentMaterial[] MergedTreatmentMaterialGridList
        //{
        //    get;
        //    set;
        //}

        /**/
        public bool hasOrthesisRequestRole { get; set; }


        public List<InpatientPhysicianAppWithResource> PatientOldInpatients = new List<InpatientPhysicianAppWithResource>();

        public List<NewNursingOrderDetail> newNursingOrderDetailList = new List<NewNursingOrderDetail>();

        public bool showFallingRiskParameter { get; set; }

        public List<HealthCommittee> healthCommittees = new List<HealthCommittee>();
        public bool IsLongInpatient { get; set; }//uzun yatış-> sebep girilecek
        public bool IsShortInpatient { get; set; }//kısa yatış->sebep girilecek
        public SKRSCikisSekli TreatmentResult { get; set; }
        public bool HasMorgue = false;
        public MorgueExDischargeFormViewModel _MorgueViewModel = new MorgueExDischargeFormViewModel();
        public SKRSCikisSekli DeathDefinition = new SKRSCikisSekli();
        public bool HasCovidDiagnosisOnPatient = false;
        public bool HasTodayCovidProgress = false;

        public IntensiveCareTypeEnum IntensiveCareType {get;set;}
        public DateTime ClinicInpatientDateAdded { get; set; }//ClinicInpatientDate'in bir gün sonrası. Yoğun bakım skor kontrolleri için eklendi

        public List<ApacheScore> ApacheScoreList = new List<ApacheScore>();
        public List<GlaskowScore> GlaskowScoreList = new List<GlaskowScore>();
        public List<Snappe> SnappeScoreList = new List<Snappe>();
        public List<Prism> PrismScoreList = new List<Prism>();
    }

    public class OrderScheduleDetail
    {
        public Guid id
        {
            get;
            set;
        }

        public string text
        {
            get;
            set;
        }

        public OrderTypeEnum typeId
        {
            get;
            set;
        }

        public DateTime startDate
        {
            get;
            set;
        }

        public DateTime endDate
        {
            get;
            set;
        }

        public string statusName
        {
            get;
            set;
        }

        public DateTime periodStartTime
        {
            get;
            set;
        } //ana orderin başlama zamanı

        public bool? isChanged
        {
            get;
            set;
        } //takvim üzerinden değişiklik yapıldı mı

        public string doctorDescription
        {
            get;
            set;
        }

        public bool allDay
        {
            get;
            set;
        }

        public string Result
        {
            get;
            set;
        }

        public string StateID
        {
            get;
            set;
        }

        public string ProcedureByUser { get; set; }

        public bool? isStoped
        {
            get;
            set;
        } //Ecz karşılanmadan durduruldu
    }

    public class Token
    {
        public string token_type { get; set; }
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }

    public class SaveNursingOrderTemplateViewModel
    {
        public NursingOrderTemplate PackageTemplateDef { get; set; }
        public NursingOrderTemplateDetail[] OrderTemplateDetails = new NursingOrderTemplateDetail[0];
    }

    public partial class OrdersToCancelParameterViewModel
    {
        public bool IsPreDischarge;
        public DateTime DischargeDate;
        public string InPatientTreatmentClinicAppObjectID;
        public string InPatientPhysicianAppObjectID;
    }

    public class InPatientPhysicianProgressesInfoViewModel
    {
        public TTObjectClasses.InPatientPhysicianProgresses[] ProgressesGridList { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public DateTime lastLoadedProgressesInfoDate
        {
            get;
            set;
        }
    }

    public class InpatientPhysicianAppWithResource
    {
        public Guid ObjectID { get; set; }  //InpatientPhysicianApplication objectdId 
        public string MasterResource { get; set; }  //Yattığı Klinik
    }

    public class NewNursingOrderDetail
    {
        public List<NursingOrderDetail> newNursingOrderDetail { get; set; }
        public Guid NursingOrderID { get; set; }
    }

    public class OldHealthCommitte
    {
        public Guid ObjectID { get; set; }
        public Guid HCStateID { get; set; }
        public string HCReasonID { get; set; }
        public ReasonForExaminationDefinition ReasonForExamination { get; set; }
        public WhoPaysEnum HCModeOfPayment { get; set; }
        public List<HCHospitalUnit> HospitalsUnits { get; set; }
        public EDisabledReport EDisabledReport { get; set; }
        public EStatusNotRepCommitteeObj eStatusNotfReportObj { get; set; }

    }

    public class EpisodeFolderModel
    {
        public Guid? ObjectID
        {
            get;
            set;
        }
        public string ArchiveNo
        {
            get;
            set;
        }
        public string ProtocolNo
        {
            get;
            set;
        }
        public DateTime? InpatientDate
        {
            get;
            set;
        }
        public DateTime? DischargeDate
        {
            get;
            set;
        }
        public string ClinicName
        {
            get;
            set;
        }
        public string Location
        {
            get;
            set;
        }
        public Guid? FileCreationAndAnalysis
        {
            get; set;
        }
        public string Status
        {
            get; set;
        }
    }

    public class ArchiveRequestModel
    {
        public List<EpisodeFolderModel> PatientEpisodeFolders { get; set; }
        public string PatientAddress { get; set; }
        public string PatientMobilePhone { get; set; }
    }

    public class ArchiveRequestInputModel
    {
        public Guid EpisodeFolder { get; set; }
        public Guid FileCreationAndAnalysis { get; set; }
    }

}