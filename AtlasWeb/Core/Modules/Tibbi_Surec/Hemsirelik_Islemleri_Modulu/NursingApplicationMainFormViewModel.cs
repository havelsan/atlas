//$D4729AF3
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using TTDefinitionManagement;
using TTUtils;
using TTStorageManager.Security;
using static Core.Controllers.KScheduleServiceController;
using static Core.Controllers.DrugOrderIntroductionServiceController;

namespace Core.Controllers
{
    public partial class NursingApplicationServiceController : Controller
    {
        partial void PreScript_NursingApplicationMainForm(NursingApplicationMainFormViewModel viewModel, NursingApplication nursingApplication, TTObjectContext objectContext)
        {
            if (nursingApplication.CurrentStateDefID.HasValue && (nursingApplication.CurrentStateDefID.Value == NursingApplication.States.Discharged || nursingApplication.CurrentStateDefID.Value == NursingApplication.States.Cancelled))
                viewModel.ReadOnly = true;

            int summaryLimitCount = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("NURSINGSUMMARYLIMITCOUNT", "5"));
            viewModel.NursingAppProgressSummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.Progresses.ToList<BaseNursingDataEntry>());
            viewModel.NursingGlaskowComaScaleSummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.GlaskowComaScales.ToList<BaseNursingDataEntry>());
            viewModel.NursingPupilSymptomsSummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.PupilSymptoms.ToList<BaseNursingDataEntry>());
            viewModel.NursingPainScaleSummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.PainScales.ToList<BaseNursingDataEntry>());
            viewModel.NursingSpiritualSummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.SpiritualEvaluations.ToList<BaseNursingDataEntry>());
            viewModel.NursingNutritionAssessmentSummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.NutritionAssessments.ToList<BaseNursingDataEntry>());
            viewModel.NursingFunctionalLifeActivitySummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.DailyLifeActivities.ToList<BaseNursingDataEntry>());
            viewModel.NursingPatientAndFamilyInstructionSummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.BaseNursingPatientAndFamilyInstructions.ToList<BaseNursingDataEntry>());
            viewModel.NursingCareSummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.NursingCares.ToList<BaseNursingDataEntry>());
            viewModel.NursingSystemInterrogationSummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.BaseNursingSystemInterrogations.ToList<BaseNursingDataEntry>());
            viewModel.NursingDischargingInstructionPlanSummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.BaseNursingDischargingInstructionPlans.ToList<BaseNursingDataEntry>());
            viewModel.NursingFallingDownRiskSummaryInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.BaseNursingFallingDownRisks.ToList<BaseNursingDataEntry>());
            viewModel.NursingWoundAssessmentScaleInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.WoundAssessmentScales.ToList<BaseNursingDataEntry>());
            viewModel.NursingLegMeasurementInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.LegMeasurements.ToList<BaseNursingDataEntry>());
            viewModel.NursingNutritionalRiskAssessmentInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.NursingNutritionalRiskAssessments.ToList<BaseNursingDataEntry>());
            viewModel.NursingBodyFluidAnalysisInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.NursingBodyFluidAnalysis.ToList<BaseNursingDataEntry>());
            viewModel.NursingpatientPreAssesmentInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.PatientPreAssessments.ToList<BaseNursingDataEntry>());
            viewModel.NursingWoundedAssessmentInfoList = GetBaseNursingDataEntrySummaryInfoList(0, summaryLimitCount, viewModel._NursingApplication.WoundAssesments.ToList<BaseNursingDataEntry>());

            if (viewModel.NursingpatientPreAssesmentInfoList.Count > 0)
                viewModel.PatientPreAssesmentAddVisible = false;
            else
                viewModel.PatientPreAssesmentAddVisible = true;

            if (viewModel.NursingDischargingInstructionPlanSummaryInfoList.Count > 0)
                viewModel.NursingDischargingInstructionPlanSummaryAddVisible = false;
            else
                viewModel.NursingDischargingInstructionPlanSummaryAddVisible = true;
            if (viewModel.NursingPatientAndFamilyInstructionSummaryInfoList.Count > 0)
                viewModel.NursingPatientAndFamilyInstructionAddVisible = false;
            else
                viewModel.NursingPatientAndFamilyInstructionAddVisible = true;

            viewModel.fallingWarningAge = -1;
            if (nursingApplication.InPatientTreatmentClinicApp != null && nursingApplication.Episode.PatientStatus != PatientStatusEnum.Discharge && nursingApplication.Episode.PatientStatus != PatientStatusEnum.PreDischarge)
            {
                if (nursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.HasFallingRisk != null && nursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.HasFallingRisk == true)
                {
                    if (nursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.RiskWarningLastSeenDate == null || (DateTime.Now - nursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.RiskWarningLastSeenDate.Value).TotalDays > 1)
                    {
                        viewModel.HasFalling = true;
                    }
                    else
                        viewModel.HasFalling = false;

                    //TODO

                    //bool found = false;
                    //foreach (var info in nursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.RiskWarningLastSeenInfo)
                    //{
                    //    if (info.User == Common.CurrentResource)
                    //    {
                    //        found = true;
                    //        if ((info.Date.Value - DateTime.Now).TotalDays > 7)
                    //        {
                    //            info.Date = DateTime.Now;
                    //            objectContext.Save();
                    //        }
                    //        else
                    //            viewModel.HasFalling = false;
                    //    }
                    //}
                    //if (!found)
                    //{
                    //    viewModel.HasFalling = true;
                    //    RiskWarningLastSeenInfo lastSeenInfo = new RiskWarningLastSeenInfo(objectContext);
                    //    lastSeenInfo.Date = DateTime.Now;
                    //    lastSeenInfo.User = Common.CurrentResource;
                    //    lastSeenInfo.BaseInpatientAdmission = nursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission;
                    //    objectContext.Save();
                    //}

                }
                else if (nursingApplication.BaseNursingFallingDownRisks.Count == 0 && nursingApplication.Episode.PatientStatus != PatientStatusEnum.Discharge && nursingApplication.Episode.PatientStatus != PatientStatusEnum.PreDischarge)
                {
                    if (nursingApplication.Episode.Patient.Age < 7 || nursingApplication.Episode.Patient.Age > 65)
                        viewModel.fallingWarningAge = nursingApplication.Episode.Patient.Age.Value;
                    viewModel.HasFalling = false;
                }
                else
                {
                    viewModel.HasFalling = false;
                }
            }

            NursingPainScale lastPainScale = new NursingPainScale();
            if (nursingApplication.PainScales != null && nursingApplication.Episode.PatientStatus != PatientStatusEnum.Discharge && nursingApplication.Episode.PatientStatus != PatientStatusEnum.PreDischarge)
            {
                lastPainScale = nursingApplication.PainScales.OrderByDescending(x => x.ApplicationDate).FirstOrDefault();
                if (lastPainScale != null && lastPainScale.PainFaceScale != null && lastPainScale.PainFaceScale != 0)
                {
                    if (lastPainScale.NursingAppDoneDate == null || (DateTime.Now - lastPainScale.NursingAppDoneDate.Value).TotalDays > 1)
                    {
                        viewModel.HasPainInfo = true;

                        viewModel.LastPainScaleInfo = CultureService.GetText("M30912", "{0}  tarihinde yapılan Ağrı Değerlendirmesinde, hasta ağrı durumunu "
                            + " {1} olarak bildirmiştir. Aşağıda listelenen hemşirelik girişimlerini uyguladınız mı?",
                            lastPainScale.ApplicationDate.Value.ToLocalTime().ToShortDateString(), Common.GetDisplayTextOfDataTypeEnum(lastPainScale.PainFaceScale));
                    }
                }
                else
                    viewModel.HasPainInfo = false;
            }

            NursingWoundAssessmentScale lastWoundAssessment = new NursingWoundAssessmentScale();
            if (nursingApplication.WoundAssessmentScales != null && nursingApplication.Episode.PatientStatus != PatientStatusEnum.Discharge && nursingApplication.Episode.PatientStatus != PatientStatusEnum.PreDischarge)
            {
                lastWoundAssessment = nursingApplication.WoundAssessmentScales.Where(x => x.CurrentStateDefID != NursingWoundAssessmentScale.States.Cancelled).OrderByDescending(x => x.ApplicationDate).FirstOrDefault();
                if (lastWoundAssessment != null)
                {
                    if (lastWoundAssessment.NursingAppDoneDate == null || (DateTime.Now - lastWoundAssessment.NursingAppDoneDate.Value).TotalDays > 1)
                    {
                        viewModel.woundAssessmentInfo = new WoundAssessmentInfo();
                        viewModel.woundAssessmentInfo.educationDef = new List<EducationDef>();
                        viewModel.woundAssessmentInfo.preventionDef = new List<PreventionAndMonitoringPlanDef>();
                        viewModel.woundAssessmentInfo.surfaceSupportDef = new List<SurfaceSupportSystemsDef>();
                        viewModel.woundAssessmentInfo.woundAssessmentDef = new List<WoundAssessmentDef>();
                        viewModel.HasWoundInfo = false;
                        if (lastWoundAssessment.TotalRisk > 20)
                        {
                            viewModel.HasWoundInfo = true;
                            viewModel.LastWoundAssessmentInfo = CultureService.GetText("M30909", "{0} tarihinde yapılan Bası Yarası Değerlendirmesinde hastanın Yara Risk Puanı {1} "
                                                                + " (20+ Çok Yüksek Risk) olarak hesaplanmıştır. Aşağıda listelenen hemşirelik girişimlerini uyguladınız mı?",
                                                                lastWoundAssessment.ApplicationDate.Value.ToLocalTime().ToShortDateString(), lastWoundAssessment.TotalRisk.ToString());

                            viewModel.woundAssessmentInfo.preventionDef = PreventionAndMonitoringPlanDef.GetPreventionAndMonitoringPlanDefinition(objectContext, "Where PlusTwentyRiskChecked = 1").ToList();
                            viewModel.woundAssessmentInfo.educationDef = EducationDef.GetEducationApproachDefinition(objectContext, "Where PlusTwentyRiskChecked = 1").ToList();
                            viewModel.woundAssessmentInfo.surfaceSupportDef = SurfaceSupportSystemsDef.GetSurfaceSupportSystemDefinition(objectContext, "Where PlusTwentyRiskChecked = 1").ToList();
                            viewModel.woundAssessmentInfo.woundAssessmentDef = WoundAssessmentDef.GetWoundAssessmentDefinition(objectContext, "Where PlusTwentyRiskChecked = 1").ToList();
                        }
                        else if (lastWoundAssessment.TotalRisk > 15)
                        {
                            viewModel.HasWoundInfo = true;
                            viewModel.LastWoundAssessmentInfo = CultureService.GetText("M30910", "{0} tarihinde yapılan Bası Yarası Değerlendirmesinde hastanın Yara Risk Puanı {1} "
                                                               + " (15+ Yüksek Risk) olarak hesaplanmıştır. Aşağıda listelenen hemşirelik girişimlerini uyguladınız mı?",
                                                               lastWoundAssessment.ApplicationDate.Value.ToLocalTime().ToShortDateString(), lastWoundAssessment.TotalRisk.ToString());
                            viewModel.woundAssessmentInfo.preventionDef = PreventionAndMonitoringPlanDef.GetPreventionAndMonitoringPlanDefinition(objectContext, "Where PlusFifteenRiskChecked = 1").ToList();
                            viewModel.woundAssessmentInfo.educationDef = EducationDef.GetEducationApproachDefinition(objectContext, "Where PlusFifteenRiskChecked = 1").ToList();
                            viewModel.woundAssessmentInfo.surfaceSupportDef = SurfaceSupportSystemsDef.GetSurfaceSupportSystemDefinition(objectContext, "Where PlusFifteenRiskChecked = 1").ToList();
                            viewModel.woundAssessmentInfo.woundAssessmentDef = WoundAssessmentDef.GetWoundAssessmentDefinition(objectContext, "Where PlusFifteenRiskChecked = 1").ToList();
                        }
                        else if (lastWoundAssessment.TotalRisk > 10)
                        {
                            viewModel.HasWoundInfo = true;
                            viewModel.LastWoundAssessmentInfo = CultureService.GetText("M30910", "{0} tarihinde yapılan Bası Yarası Değerlendirmesinde hastanın Yara Risk Puanı {1} "
                                                               + " (10+ Risk) olarak hesaplanmıştır. Aşağıda listelenen hemşirelik girişimlerini uyguladınız mı?",
                                                               lastWoundAssessment.ApplicationDate.Value.ToLocalTime().ToShortDateString(), lastWoundAssessment.TotalRisk.ToString());
                            viewModel.woundAssessmentInfo.preventionDef = PreventionAndMonitoringPlanDef.GetPreventionAndMonitoringPlanDefinition(objectContext, "Where PlusTenRiskChecked = 1").ToList();
                            viewModel.woundAssessmentInfo.educationDef = EducationDef.GetEducationApproachDefinition(objectContext, "Where PlusTenRiskChecked = 1").ToList();
                            viewModel.woundAssessmentInfo.surfaceSupportDef = SurfaceSupportSystemsDef.GetSurfaceSupportSystemDefinition(objectContext, "Where PlusTenRiskChecked = 1").ToList();
                            viewModel.woundAssessmentInfo.woundAssessmentDef = WoundAssessmentDef.GetWoundAssessmentDefinition(objectContext, "Where PlusTenRiskChecked = 1").ToList();
                        }
                    }
                }

            }

            viewModel.HasOutDatedForm = false;
            viewModel.OutDatedFormsInfo = "";
            if (viewModel.showFallingRiskParameter)
            {
                BaseNursingFallingDownRisk lastFalling = nursingApplication.BaseNursingFallingDownRisks.Where(x => x.CurrentStateDefID != BaseNursingFallingDownRisk.States.Cancelled).OrderByDescending(x => x.ApplicationDate).FirstOrDefault();
                if (lastFalling != null && nursingApplication.Episode.PatientStatus != PatientStatusEnum.Discharge && nursingApplication.Episode.PatientStatus != PatientStatusEnum.PreDischarge)
                {
                    if ((DateTime.Now - lastFalling.ApplicationDate.Value).TotalDays > 7)
                    {
                        viewModel.HasOutDatedFallingRiskForm = true;
                        viewModel.IsFallingRiskBiggerThanFive = false;
                        if (lastFalling.TotalScore >= 5)
                        {
                            viewModel.IsFallingRiskBiggerThanFive = true;
                            viewModel.OutDatedFallingRiskInfo += CultureService.GetText("M30906", "Hastanın Düşme Riski Değerlendirmesi en son {0} tarihinde yapılmıştır. Lütfen tekrar değerlendirme yapınız.", lastFalling.ApplicationDate.Value.ToShortDateString());
                        }
                        else
                        {
                            if (lastFalling.NursingAppDoneDate == null || (DateTime.Now - lastFalling.NursingAppDoneDate.Value).TotalDays > 7)
                                viewModel.OutDatedFallingRiskInfo += "Hastanın Düşme Riski Değerlendirmesi en son " + lastFalling.ApplicationDate.Value.ToShortDateString() + " tarihinde yapılmıştır. Tekrar değerlendirme yapmak ister misiniz?";
                            else
                                viewModel.HasOutDatedFallingRiskForm = false;
                        }
                    }
                }
            }

            if (lastPainScale != null && nursingApplication.Episode.PatientStatus != PatientStatusEnum.Discharge && nursingApplication.Episode.PatientStatus != PatientStatusEnum.PreDischarge)
            {
                if ((DateTime.Now - lastPainScale.ApplicationDate.Value).TotalDays > 7)
                {
                    viewModel.HasOutDatedForm = true;
                    viewModel.OutDatedFormsInfo += CultureService.GetText("M30907", "Hastanın Ağrı Değerlendirmesi en son {0} tarihinde yapılmıştır. Lütfen tekrar değerlendirme yapınız.", lastPainScale.ApplicationDate.Value.ToShortDateString());
                }
            }
            if (lastWoundAssessment != null && nursingApplication.Episode.PatientStatus != PatientStatusEnum.Discharge && nursingApplication.Episode.PatientStatus != PatientStatusEnum.PreDischarge)
            {
                if ((DateTime.Now - lastWoundAssessment.ApplicationDate.Value).TotalDays > 7)
                {
                    viewModel.HasOutDatedForm = true;
                    viewModel.OutDatedFormsInfo += TTUtils.CultureService.GetText("M30908", "Hastanın Bası Yarası Değerlendirmesi en son {0} tarihinde yapılmıştır. Lütfen tekrar değerlendirme yapınız.", lastWoundAssessment.ApplicationDate.Value.ToShortDateString());
                }
            }


            viewModel.includeDrugDefinition = false;
            if (TTObjectClasses.SystemParameter.GetParameterValue("INPATIENTPHYSICIANAPPINCLUDEDRUGS", "FALSE") == "TRUE")
                viewModel.includeDrugDefinition = true;

            this.ArrangeButtons(viewModel);
            ControlPastNursingOrder(nursingApplication.ObjectID);
            //InfoMessageService.Instance.ShowMessage("ismail 3");
            // SARF GRIDINDE Cancelledlar gelmemesi  için  Bu koddan sonra ContextToViewModel çalışmamalı

            if (viewModel._NursingApplication.InPatientTreatmentClinicApp?.IsDailyOperation == true || viewModel._NursingApplication.EmergencyIntervention != null)
            {
                foreach (var item in viewModel.NewTreatmentMaterialsGridList)
                {
                    var a = item.Material;
                }
                viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
                viewModel.SubEpisodeList = new List<SubEpisode>();
                viewModel.EpisodeActionList = new List<EpisodeAction>();

                viewModel.NewTreatmentMaterialsGridList = viewModel.NewTreatmentMaterialsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();
                viewModel.NewTreatmentMaterialsGridList = viewModel.NewTreatmentMaterialsGridList.Where(material => this.ControlTreatmentMaterialActions(material, viewModel) == true).ToArray();
            }
            else
                viewModel.NewTreatmentMaterialsGridList = viewModel.NewTreatmentMaterialsGridList.Where(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled).ToArray();


            //Girilmiş son vital değerler

            VitalSignValueDefinition.GetVitalSignValueDefinition_Class[] vitalSignList = VitalSignValueDefinition.GetVitalSignValueDefinition(objectContext, "").ToArray();
            viewModel.VitalSignWarningInfo = "";

            foreach (var vitalSign in vitalSignList)
            {
                if (nursingApplication.Episode.Patient.Age >= vitalSign.MinAge && nursingApplication.Episode.Patient.Age <= vitalSign.MaxAge && nursingApplication.Episode.Patient.Sex.ObjectID == vitalSign.Sex)
                {
                    if (vitalSign.VitalSignType == VitalSignType.BloodPressure_Systolic)
                    {
                        var bloodPressure = viewModel._NursingApplication.BloodPressures.Where(x => x.Sistolik != null).OrderByDescending(x => x.ExecutionDate).FirstOrDefault();
                        if (vitalSign.MaxValue != null && vitalSign.MinValue != null && bloodPressure != null)
                        {
                            if (bloodPressure.Sistolik.Value > vitalSign.MaxValue)
                            {
                                viewModel.HasVitalSignWarning = true;
                                viewModel.VitalSignWarningInfo += "" + CultureService.GetText("M26896", "Sistolik Tansiyon: ") + bloodPressure.Sistolik.Value + "" + vitalSign.MaxValueWarning;
                            }
                            else if (bloodPressure.Sistolik.Value < vitalSign.MinValue)
                            {
                                viewModel.HasVitalSignWarning = true;
                                viewModel.VitalSignWarningInfo += "" + CultureService.GetText("M26896", "Sistolik Tansiyon: ") + bloodPressure.Sistolik.Value + "" + vitalSign.MinValueWarning;
                            }
                        }
                    }
                    else if (vitalSign.VitalSignType == VitalSignType.BloodPressure_Diastolic)
                    {
                        var bloodPressure = viewModel._NursingApplication.BloodPressures.Where(x => x.Diastolik != null).OrderByDescending(x => x.ExecutionDate).FirstOrDefault();
                        if (vitalSign.MaxValue != null && vitalSign.MinValue != null && bloodPressure != null)
                        {
                            if (bloodPressure.Diastolik.Value > vitalSign.MaxValue)
                            {
                                viewModel.HasVitalSignWarning = true;
                                viewModel.VitalSignWarningInfo += "" + CultureService.GetText("M25485", "Diastolik Tansiyon: ") + bloodPressure.Diastolik.Value + "" + vitalSign.MaxValueWarning;
                            }
                            else if (bloodPressure.Diastolik.Value < vitalSign.MinValue)
                            {
                                viewModel.HasVitalSignWarning = true;
                                viewModel.VitalSignWarningInfo += "" + CultureService.GetText("M25485", "Diastolik Tansiyon: ") + bloodPressure.Diastolik.Value + "" + vitalSign.MinValueWarning;
                            }
                        }
                    }
                    else if (vitalSign.VitalSignType == VitalSignType.Pulse)
                    {
                        var pulse = viewModel._NursingApplication.Pulses.OrderByDescending(x => x.ExecutionDate).FirstOrDefault();
                        if (vitalSign.MaxValue != null && vitalSign.MinValue != null && pulse != null)
                        {
                            if (pulse.Value > vitalSign.MaxValue)
                            {
                                viewModel.HasVitalSignWarning = true;
                                viewModel.VitalSignWarningInfo += "" + CultureService.GetText("M26565", "Nabız: ") + pulse.Value + "" + vitalSign.MaxValueWarning;
                            }
                            else if (pulse.Value < vitalSign.MinValue)
                            {
                                viewModel.HasVitalSignWarning = true;
                                viewModel.VitalSignWarningInfo += "" + CultureService.GetText("M26565", "Nabız: ") + pulse.Value + "" + vitalSign.MinValueWarning;
                            }
                        }
                    }
                    else if (vitalSign.VitalSignType == VitalSignType.Respiration)
                    {
                        var respiration = viewModel._NursingApplication.Respirations.OrderByDescending(x => x.ExecutionDate).FirstOrDefault();
                        if (vitalSign.MaxValue != null && vitalSign.MinValue != null && respiration != null)
                        {
                            if (respiration.Value > vitalSign.MaxValue)
                            {
                                viewModel.HasVitalSignWarning = true;
                                viewModel.VitalSignWarningInfo += "" + CultureService.GetText("M26911", "Solunum Sayısı: ") + respiration.Value + "" + vitalSign.MaxValueWarning;
                            }
                            else if (respiration.Value < vitalSign.MinValue)
                            {
                                viewModel.HasVitalSignWarning = true;
                                viewModel.VitalSignWarningInfo += "" + CultureService.GetText("M26911", "Solunum Sayısı: ") + respiration.Value + "" + vitalSign.MinValueWarning;
                            }
                        }
                    }
                    else if (vitalSign.VitalSignType == VitalSignType.Temperature)
                    {

                        var temperature = viewModel._NursingApplication.Temperatures.OrderByDescending(x => x.ExecutionDate).FirstOrDefault();

                        if (vitalSign.MaxValue != null && vitalSign.MinValue != null && temperature != null)
                        {
                            if (temperature.Value > vitalSign.MaxValue)
                            {
                                viewModel.HasVitalSignWarning = true;
                                viewModel.VitalSignWarningInfo += "" + CultureService.GetText("M25197", "Ateş: ") + temperature.Value + "" + vitalSign.MaxValueWarning;
                            }
                            else if (temperature.Value < vitalSign.MinValue)
                            {
                                viewModel.HasVitalSignWarning = true;
                                viewModel.VitalSignWarningInfo += "" + CultureService.GetText("M25197", "Ateş: ") + temperature.Value + "" + vitalSign.MinValueWarning;
                            }
                        }

                    }
                    else if (vitalSign.VitalSignType == VitalSignType.SPO2)
                    {
                        var spo2 = viewModel._NursingApplication.SPO2s.OrderByDescending(x => x.ExecutionDate).FirstOrDefault();
                        if (vitalSign.MaxValue != null && vitalSign.MinValue != null && spo2 != null)
                        {
                            if (spo2.Value > vitalSign.MaxValue)
                            {
                                viewModel.HasVitalSignWarning = true;
                                viewModel.VitalSignWarningInfo += "" + CultureService.GetText("M26603", "O2 Saturasyonu: ") + spo2.Value + "" + vitalSign.MaxValueWarning;
                            }
                            else if (spo2.Value < vitalSign.MinValue)
                            {
                                viewModel.HasVitalSignWarning = true;
                                viewModel.VitalSignWarningInfo += "" + CultureService.GetText("M26603", "O2 Saturasyonu: ") + spo2.Value + "" + vitalSign.MinValueWarning;
                            }
                        }
                    }

                }
            }

            viewModel.hasOrthesisRequestRole = TTUser.CurrentUser.HasRole(TTRoleNames.Ortez_Protez_Istek_RUW) ? true : false;
            viewModel.PatientNameSurname = nursingApplication.Episode.Patient.Name + " " + nursingApplication.Episode.Patient.Surname;
            if (Common.CurrentResource.UserType == UserTypeEnum.Nurse || Common.CurrentResource.UserType == UserTypeEnum.HeadNurse)
                viewModel.NurseName = Common.CurrentResource.Name;
            else
                viewModel.NurseName = "";

            viewModel.showFallingRiskParameter = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("SHOWFALLINGRISKPARAMETER", "TRUE"));

            viewModel.HasYaraHemsireRole = TTUser.CurrentUser.HasRole(TTRoleNames.Yara_Hemsiresi) ? true : false;

            viewModel.ShowNewOrderTab = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("SHOWNEWORDERTAB", "FALSE"));
            viewModel._Patient = nursingApplication.Episode.Patient;
        }

        partial void PostScript_NursingApplicationMainForm(NursingApplicationMainFormViewModel viewModel, NursingApplication nursingApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
        }

        partial void AfterContextSaveScript_NursingApplicationMainForm(NursingApplicationMainFormViewModel viewModel, NursingApplication nursingApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            // this.ArrangeButtons(viewModel);
        }

        public void ArrangeButtons(NursingApplicationMainFormViewModel viewModel)
        {
            List<TTObjectStateTransitionDef> removedOutgoingTransitions = new List<TTObjectStateTransitionDef>();
            foreach (var trans in viewModel.OutgoingTransitions)
            {
                if (trans.ToStateDefID == NursingApplication.States.Cancelled)
                    removedOutgoingTransitions.Add(trans);
                else if (trans.ToStateDefID == NursingApplication.States.PreDischarged)
                    removedOutgoingTransitions.Add(trans);
                else if (trans.ToStateDefID == NursingApplication.States.Discharged && viewModel._NursingApplication.EmergencyIntervention == null)
                    removedOutgoingTransitions.Add(trans);
            }
            foreach (var removedtrans in removedOutgoingTransitions)
            {
                viewModel.OutgoingTransitions.Remove(removedtrans);
            }
        }
        // Ortak Methodlar
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hemsirelik_Hizmetleri_Ozet_Veri)]
        public NursingDynamicComponent_SummaryInfo GetSummaryInfoByObjectId(Guid ObjectId)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            var baseNursingDataEntry = objectContext.GetObject(ObjectId, typeof(BaseNursingDataEntry)) as BaseNursingDataEntry;
            if (baseNursingDataEntry != null)
                return GetMySummaryInfo(baseNursingDataEntry);
            return null;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hemsirelik_Hizmetleri_Ozet_Veri)]
        public List<NursingDynamicComponent_SummaryInfo> GetNextSummaryInfoSetAndAddToList(int count, string objectDefName, Guid nursingApplicationID)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            List<NursingDynamicComponent_SummaryInfo> summaryInfoList = null;
            int summaryLimitCount = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("NURSINGSUMMARYLIMITCOUNT", "5"));
            BindingList<BaseNursingDataEntry> baseNursingDataEntry = BaseNursingDataEntry.GetBaseNursingDataByType(objectContext, objectDefName, nursingApplicationID);
            if (baseNursingDataEntry != null)
                summaryInfoList = GetBaseNursingDataEntrySummaryInfoList(count, summaryLimitCount, baseNursingDataEntry.ToList<BaseNursingDataEntry>());
            return summaryInfoList;
        }
        public HimsDrugBarcodesContainer GetBarcode(GetBarcode input)
        {
            HimsDrugBarcodesContainer barcodesContainer = new HimsDrugBarcodesContainer();
            barcodesContainer.DrugBarcodes = new List<HimsDrugInfo>();
            BindingList<DrugOrderDetail.GetActiveDrugOrderDetail_Class> activeDrugOrderDetail = DrugOrderDetail.GetActiveDrugOrderDetail(input.startDate, input.endDate, input.NursingApplicationObjectid);
            Dictionary<DateTime, List<Guid>> distDetail = new Dictionary<DateTime, List<Guid>>();
            foreach (DrugOrderDetail.GetActiveDrugOrderDetail_Class det in activeDrugOrderDetail)
            {
                if (distDetail.ContainsKey(det.OrderPlannedDate.Value))
                {
                    distDetail[det.OrderPlannedDate.Value].Add(det.ObjectID.Value);
                }
                else
                {
                    List<Guid> objID = new List<Guid>();
                    objID.Add(det.ObjectID.Value);
                    distDetail.Add(det.OrderPlannedDate.Value, objID);
                }
            }

            foreach (KeyValuePair<DateTime, List<Guid>> dist in distDetail)
            {
                DrugOrder drugOrder = null;
                List<HimsDrugsInfo> collectedDrugsList = new List<HimsDrugsInfo>();
                foreach (Guid objID in dist.Value)
                {
                    TTObjectContext context = new TTObjectContext(true);
                    DrugOrderDetail drugOrderDetail = context.GetObject<DrugOrderDetail>(objID);
                    HimsDrugsInfo drugsInfo = new HimsDrugsInfo();
                    drugsInfo.DrugName = drugOrderDetail.Material.Name;
                    drugsInfo.EK = "";
                    drugsInfo.PlannedTime = ((DateTime)drugOrderDetail.OrderPlannedDate).ToString("dd.MM.yyyy HH:mm");

                    string orderFrequency = string.Empty;
                    drugOrder = drugOrderDetail.DrugOrder;
                    if (drugOrder != null && drugOrder.HospitalTimeSchedule != null)
                        orderFrequency = drugOrder.HospitalTimeSchedule.Name.Trim() + drugOrder.DoseAmount.ToString();

                    drugsInfo.Doz = orderFrequency.Trim();
                    drugsInfo.Mi = Math.Ceiling(drugOrderDetail.DoseAmount.Value).ToString();
                    collectedDrugsList.Add(drugsInfo);
                }
                List<HimsDrugInfo> re = ReturnMyHimsDrugInfoList(collectedDrugsList, drugOrder);
                foreach (HimsDrugInfo info in re)
                    barcodesContainer.DrugBarcodes.Add(info);
            }
            return barcodesContainer;
        }

        private List<HimsDrugInfo> ReturnMyHimsDrugInfoList(List<HimsDrugsInfo> collectedDrugsList, DrugOrder drugOrder)
        {
            List<HimsDrugInfo> list = new List<HimsDrugInfo>();

            int listCount = 1;
            int modeValue = 0;

            if (collectedDrugsList.Count >= 7)
                listCount = collectedDrugsList.Count / 7;

            if (collectedDrugsList.Count >= 7)
                modeValue = collectedDrugsList.Count % 7;

            if (modeValue != 0)
            {
                listCount = listCount + 1;
            }

            for (int f = 0; f < listCount; f++)
            {
                HimsDrugInfo info = new HimsDrugInfo();
                info.PatientFullName = drugOrder.Episode.Patient.FullName;
                info.PrintDate = DateTime.Now.ToString();
                info.ProcedureCode = "";
                info.BarcodeCode = "";
                info.ProcedureName = drugOrder.MasterResource.Name;
                list.Add(info);
            }

            int j = collectedDrugsList.Count;
            int i = 0;
            foreach (HimsDrugInfo info in list)
            {
                info.Drugs = new List<HimsDrugsInfo>();

                for (i = j; i > 0; i--)
                {
                    info.Drugs.Add(collectedDrugsList[i - 1]);
                    j = i - 1;
                    if (info.Drugs.Count == 7)
                        break;
                }

                if (info.Drugs.Count != 7)
                {
                    for (int m = info.Drugs.Count; m < 7; m++)
                    {
                        HimsDrugsInfo drugInfoForNaN = new HimsDrugsInfo();
                        drugInfoForNaN.DrugName = string.Empty;
                        drugInfoForNaN.Mi = string.Empty;
                        drugInfoForNaN.Doz = string.Empty;
                        drugInfoForNaN.PlannedTime = string.Empty;
                        drugInfoForNaN.EK = string.Empty;
                        info.Drugs.Add(drugInfoForNaN);
                    }
                }
            }

            return list;

        }


        private static NursingDynamicComponent_SummaryInfo GetMySummaryInfo(BaseNursingDataEntry baseNursingDataEntry)
        {
            NursingDynamicComponent_SummaryInfo nursingSummaryInfo = new NursingDynamicComponent_SummaryInfo();
            nursingSummaryInfo.ApplicationDate = baseNursingDataEntry.ApplicationDate;
            if (baseNursingDataEntry.ApplicationUser != null)
                nursingSummaryInfo.ApplicationUserName = baseNursingDataEntry.ApplicationUser.Name;
            nursingSummaryInfo.ApplicationSummary = baseNursingDataEntry.ApplicationSummary;
            nursingSummaryInfo.ObjectID = baseNursingDataEntry.ObjectID;
            nursingSummaryInfo.RowColor = baseNursingDataEntry.GetRowColor();
            if (baseNursingDataEntry.CurrentStateDefID == BaseNursingDataEntry.States.Cancelled)
            {
                nursingSummaryInfo.isDeleted = true;
            }
            else
            {
                nursingSummaryInfo.isDeleted = false;
            }
            return nursingSummaryInfo;
        }

        public class NursingAppDoneInfoInput
        {
            public Guid NursingApplicationID { get; set; }
        }

        [HttpPost]
        public void setFallingRiskNursingAppDoneDate(NursingAppDoneInfoInput input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                NursingApplication nursingApplication = (NursingApplication)objectContext.GetObject(input.NursingApplicationID, typeof(NursingApplication));
                nursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.RiskWarningLastSeenDate = DateTime.Now;
                objectContext.Save();
            }
        }

        public void setFallingRiskFormNursingAppDoneDate(NursingAppDoneInfoInput input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                NursingApplication nursingApplication = (NursingApplication)objectContext.GetObject(input.NursingApplicationID, typeof(NursingApplication));
                BaseNursingFallingDownRisk lastFalling = nursingApplication.BaseNursingFallingDownRisks.Where(x => x.CurrentStateDefID != BaseNursingFallingDownRisk.States.Cancelled).OrderByDescending(x => x.ApplicationDate).FirstOrDefault();
                if (lastFalling != null)
                {
                    lastFalling.NursingAppDoneDate = DateTime.Now;
                    objectContext.Save();
                }
            }
        }

        [HttpPost]
        public void setLastWoundAssessmentNursingAppDoneDate(NursingAppDoneInfoInput input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                NursingApplication nursingApplication = (NursingApplication)objectContext.GetObject(input.NursingApplicationID, typeof(NursingApplication));
                var lastWoundAssessment = nursingApplication.WoundAssessmentScales.Where(x => x.CurrentStateDefID != NursingWoundAssessmentScale.States.Cancelled).OrderByDescending(x => x.ApplicationDate).FirstOrDefault();
                lastWoundAssessment.NursingAppDoneDate = DateTime.Now;
                objectContext.Save();
            }
        }

        [HttpPost]
        public void setLastPainScaleNursingAppDoneDate(NursingAppDoneInfoInput input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                NursingApplication nursingApplication = (NursingApplication)objectContext.GetObject(input.NursingApplicationID, typeof(NursingApplication));
                var lastPainScale = nursingApplication.PainScales.OrderByDescending(x => x.ApplicationDate).FirstOrDefault();
                lastPainScale.NursingAppDoneDate = DateTime.Now;
                objectContext.Save();
            }
        }


        public static List<NursingDynamicComponent_SummaryInfo> GetBaseNursingDataEntrySummaryInfoList(int BegginnerRowIndex, int RowCount, List<BaseNursingDataEntry> BaseNursingEntryDataArray)
        {
            List<NursingDynamicComponent_SummaryInfo> NursingSummaryInfoList = new List<NursingDynamicComponent_SummaryInfo>();
            var NursingSummaryList = BaseNursingEntryDataArray.Where(dr => dr.CurrentStateDefID != BaseNursingDataEntry.States.Cancelled).OrderByDescending(dr => dr.ApplicationDate).Skip(BegginnerRowIndex).Take(RowCount);
            foreach (var nursingAppProgress in NursingSummaryList)
            {

                NursingDynamicComponent_SummaryInfo nursingSummaryInfo = GetMySummaryInfo(nursingAppProgress);
                NursingSummaryInfoList.Add(nursingSummaryInfo);
            }

            return NursingSummaryInfoList;
        }

        public bool ArrangeNursingApplicationReadOnly(BaseNursingDataEntry baseNursingDataEntry)
        {
            if (baseNursingDataEntry.NursingApplication.CurrentStateDefID.HasValue && (baseNursingDataEntry.NursingApplication.CurrentStateDefID.Value == NursingApplication.States.Discharged || baseNursingDataEntry.NursingApplication.CurrentStateDefID.Value == NursingApplication.States.Cancelled))
                return true;
            else
                return false;
        }

        //
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Hemsirelik_Hizmetleri_Ozet_Veri)]
        public List<OrderScheduleDetail> GetNursingOrdersByDate(Guid ObjectID, DateTime startDate, DateTime endDate)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            string filterExp = " AND THIS.WORKLISTDATE >= TODATE('" + Convert.ToDateTime(startDate.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss") + "') AND THIS.WORKLISTDATE <= TODATE('" + Convert.ToDateTime(endDate.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";
            NursingOrderDetail.GetNODByNursingApplication_RQ_Class[] _nodList = NursingOrderDetail.GetNODByNursingApplication_RQ(ObjectID.ToString(), filterExp).ToArray();
            List<OrderScheduleDetail> _nursingOrderScheduleDetail = new List<OrderScheduleDetail>();
            foreach (NursingOrderDetail.GetNODByNursingApplication_RQ_Class _nod in _nodList)
            {
                OrderScheduleDetail nosd = new OrderScheduleDetail();
                DateTime _tempDate = _nod.WorkListDate.Value.AddMinutes(30);
                nosd.id = _nod.ObjectID.Value;
                nosd.text = _nod.Name;
                nosd.typeId = OrderTypeEnum.NursingOrder; //Hemşire direktif
                nosd.startDate = _nod.WorkListDate.Value;
                nosd.endDate = _tempDate.Day != nosd.startDate.Day ? _nod.WorkListDate.Value.AddMinutes(30 - (_tempDate.Minute + 1)) : _tempDate;
                nosd.statusName = _nod.Statusname.ToString();
                nosd.periodStartTime = _nod.PeriodStartTime.HasValue ? _nod.PeriodStartTime.Value : _nod.WorkListDate.Value; //bu saatten öncesine detay saati değişmesi
                nosd.isChanged = false;
                nosd.doctorDescription = _nod.OrderDescription + (_nod.Notes != null ? "\nH.N =" + _nod.Notes : "");

                #region Sonuç
                string _res = string.Empty;

                VitalSignAndNursingDefinition _vitalSignDef = objectContext.GetObject(_nod.Typeid.Value, typeof(VitalSignAndNursingDefinition)) as VitalSignAndNursingDefinition;

                if (_vitalSignDef.VitalSignType == VitalSignType.ANT && _nod.Result != null)
                    _res = "Ateş: " + _nod.Result;
                else if (_nod.Result != null)
                    _res = "Sonuç: " + _nod.Result;

                _res += _nod.Result_Pulse != null ? " Nabız: " + _nod.Result_Pulse : "";
                _res += _nod.Result_SPO2 != null ? " SPo2: " + _nod.Result_SPO2 : "";
                _res += _nod.ResultBloodPressure != null ? " Tan: " + _nod.ResultBloodPressure : "";
                nosd.Result = _res;
                #endregion

                nosd.StateID = _nod.CurrentStateDefID.ToString();
                nosd.ProcedureByUser = _nod.Procedurebyuser;
                _nursingOrderScheduleDetail.Add(nosd);
            }

            DateTime sDate = Convert.ToDateTime(startDate.ToShortDateString() + " 00:00:00");
            DateTime eDate = Convert.ToDateTime(endDate.ToShortDateString() + " 00:00:00");
            BindingList<DrugOrderDetail.GetAllDrugOrderDetail_Class> activeDrugOrderDetail = DrugOrderDetail.GetAllDrugOrderDetail(eDate, ObjectID, sDate, string.Empty);
            foreach (DrugOrderDetail.GetAllDrugOrderDetail_Class detail in activeDrugOrderDetail)
            {
                OrderScheduleDetail nosd = new OrderScheduleDetail();
                DateTime orderEndDate = detail.OrderPlannedDate.Value.AddMinutes(30);
                nosd.id = detail.ObjectID.Value;
                nosd.text = detail.Material + "-" + detail.State;
                nosd.typeId = OrderTypeEnum.DrugOrder;
                nosd.startDate = detail.OrderPlannedDate.Value;
                nosd.endDate = orderEndDate.Day != nosd.startDate.Day ? detail.OrderPlannedDate.Value.AddMinutes(30 - (orderEndDate.Minute + 1)) : orderEndDate;
                nosd.StateID = detail.CurrentStateDefID.ToString();
                switch (nosd.StateID)
                {
                    case "cb22e74b-a2be-456f-8680-660d0b21dc24": // plan
                        nosd.statusName = TTUtils.CultureService.GetText("M25573", "Eczaneden İstenmedi!");
                        break;
                    case "da01e671-efb9-4d84-8122-4bae07e08c20": //İstek
                        nosd.statusName = TTUtils.CultureService.GetText("M25572", "Eczaneden İstendi Henüz Karşılanmadı!");
                        break;
                    case "94c4b7eb-b764-4ca5-add6-76e2217f7dd4": //Hastanın Üzerinde
                        nosd.statusName = TTUtils.CultureService.GetText("M25385", "Daha Önce Karşılanan Doz Kullanılacaktır !!!");
                        break;
                    case "d4f85132-8d05-4dc7-b9b2-fc04bae622b0": // Karşılandı
                        nosd.statusName = TTUtils.CultureService.GetText("M25571", "Eczaneden İstendi Eczane Tarafından Karşılandı!");
                        break;
                    case "ad54f2c0-8ebe-4fbb-a57a-b7c870fd1fb3": // Eczacılık Bilimlerinden İstendi
                        nosd.statusName = "Eczacılık Bilimlerinden İstendi";
                        break;
                    case "f1b24e44-ecb3-4b44-9b23-1d77e9901721": //Durdur
                        nosd.statusName = TTUtils.CultureService.GetText("M25549", "Durduruldu");
                        break;
                    case "14ea4626-5b27-4663-82f9-64968cb4eb63": //Hastaya Teslim
                        nosd.statusName = TTUtils.CultureService.GetText("M25771", "Hasta / Hasta Yakınına teslim edildi.");
                        break;
                    case "d39a37a6-610e-4143-aca2-691ce5818915": //Uygulandı
                        nosd.statusName = TTUtils.CultureService.GetText("M27138", "Uygulandı");
                        break;
                    case "add6e452-c007-4849-b477-17d30400abe8": //İptal
                        nosd.statusName = TTUtils.CultureService.GetText("M27135", "Uygulama İptal Edildi!");
                        break;
                    case "0586979d-523c-4800-995c-750ac3984606": //Dış Eczane Tarafından Karşılandı
                        nosd.statusName = TTUtils.CultureService.GetText("M25431", "Dış Eczane Tarafından Karşılandı");
                        break;
                    case "4223ab9b-1b9f-4f59-845f-b903adcda8a0"://Eczaneye İade
                        nosd.statusName = TTUtils.CultureService.GetText("M25574", "Eczaneye İade");
                        break;
                    default:
                        nosd.statusName = TTUtils.CultureService.GetText("M27042", "Tanımsız durum.Lütfen sistem yöneticisine başvurun!!");
                        break;
                }


                DrugOrderDetail drugOrderDetail = objectContext.GetObject<DrugOrderDetail>(detail.ObjectID.Value);
                if (drugOrderDetail.CurrentStateDef.Status == TTDefinitionManagement.StateStatusEnum.CompletedSuccessfully)
                {
                    List<TTObjectState> states = drugOrderDetail.GetStateHistory().ToList();
                    nosd.ProcedureByUser = states[states.Count - 1].User.FullName;
                }
                if (drugOrderDetail.DrugOrder.DrugOrderTransactions.Select(string.Empty).Count > 0)
                    nosd.isStoped = true;
                else
                    nosd.isStoped = false;

                nosd.periodStartTime = DateTime.Now; //bu saatten öncesine detay saati değişmesi
                nosd.isChanged = false;
                nosd.doctorDescription = detail.Note;
                nosd.Result = "";
                _nursingOrderScheduleDetail.Add(nosd);
            }

            return _nursingOrderScheduleDetail;
        }

        #region Diretif Zaman Güncelleme
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hemsirelik_Hizmetleri_Ozet_Veri)]
        public OldDrugOrderIntroductionDet GetNOsByDateForTimeUpdate(GetOldDrugOrderIntroductionDets_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                OldDrugOrderIntroductionDet oldDrugOrderIntroductionDet = new OldDrugOrderIntroductionDet();
                List<TempDrugOrder> tempDrugOrders = new List<TempDrugOrder>();
                List<Material> materials = new List<Material>();
                if (input.episode != null)
                {
                    string filterExp = "";
                    if (input.PlannedStartDate != null)
                    {
                        string firstDate = Convert.ToDateTime(input.PlannedStartDate).ToShortDateString();
                        filterExp = " AND THIS.PeriodStartTime >= '" + firstDate + "'";
                    }

                    if (input.PlannedEndDate != null)
                    {
                        string lastDate = Convert.ToDateTime(input.PlannedEndDate).ToShortDateString();
                        filterExp += " AND PeriodStartTime <= '" + lastDate + "'";
                    }


                    BindingList<NursingOrder.GetNOsByDateForTimeUpdate_Class> details = NursingOrder.GetNOsByDateForTimeUpdate(input.episode.ObjectID, filterExp);
                    foreach (NursingOrder.GetNOsByDateForTimeUpdate_Class detail in details)
                    {

                        TempDrugOrder tempdrugOrder = new TempDrugOrder();
                        tempdrugOrder.OrderID = -1;
                        tempdrugOrder.OrderObjectID = (Guid)detail.ObjectID;
                        tempdrugOrder.DrugName = detail.Name;
                        tempdrugOrder.Frequency = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(detail.Frequency).DisplayText;
                        tempdrugOrder.DoseAmount = (int)detail.AmountForPeriod;
                        tempdrugOrder.Day = (int)detail.RecurrenceDayAmount;
                        tempdrugOrder.OrderDate = ((DateTime)detail.PeriodStartTime).Date;
                        tempdrugOrder.MaterialObjectID = new Guid();
                        tempdrugOrder.NextDayOrder = false;
                        tempdrugOrder.FrequencyEnumValue = detail.Frequency.Value;
                        tempdrugOrder.UsageNote = "";
                        tempdrugOrder.OrderStatus = detail.DisplayText;
                        tempdrugOrder.OrderType = "Hemşire Direktif";

                        tempDrugOrders.Add(tempdrugOrder);

                        oldDrugOrderIntroductionDet.Materials = materials;
                        oldDrugOrderIntroductionDet.TempDrugOrders = tempDrugOrders;
                    }
                }

                objectContext.FullPartialllyLoadedObjects();
                return oldDrugOrderIntroductionDet;
            }
        }

        [HttpGet]
        public List<NursingOrderDetail> GetActiveNursingOrderDetails(Guid ObjectID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<NursingOrderDetail> details = new List<NursingOrderDetail>();
                NursingOrder order = (NursingOrder)objectContext.GetObject(ObjectID, typeof(NursingOrder));
                DateTime nowDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                foreach (NursingOrderDetail detail in order.OrderDetails)
                {
                    if (detail.WorkListDate > nowDay)
                    {
                        if (detail.CurrentStateDefID == NursingOrderDetail.States.Execution)
                        {
                            details.Add(detail);
                        }
                    }
                }
                objectContext.FullPartialllyLoadedObjects();
                return details;
            }
        }

        [HttpPost]
        public bool UpdateNursingOrderDetails(List<NursingOrderDetail> orderDetails)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                try
                {
                    objectContext.AddToRawObjectList(orderDetails);
                    objectContext.ProcessRawObjects(false);
                    //NursingOrderDetail nursingApplication = (NursingOrderDetail)objectContext.GetObject(orderDetails[0].ObjectID, typeof(NursingOrderDetail));
                    objectContext.Save();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }
        #endregion

        public void ControlPastNursingOrder(Guid ObjectID)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            string filterExp = " AND THIS.WORKLISTDATE <= TODATE('" + Convert.ToDateTime(Common.RecTime()).ToString("yyyy-MM-dd HH:mm:ss") + "') AND THIS.CURRENTSTATEDEFID = '" + NursingOrderDetail.States.Execution.ToString() + "'";
            NursingOrderDetail.GetNODByNursingApplication_RQ_Class[] _nodList = NursingOrderDetail.GetNODByNursingApplication_RQ(ObjectID.ToString(), filterExp).OrderBy(x => x.WorkListDate).ToArray();

            if (_nodList.Length > 0)
            {
                string _message = String.Empty;
                int index = 0;
                foreach (NursingOrderDetail.GetNODByNursingApplication_RQ_Class item in _nodList)
                {
                    _message += item.WorkListDate + " tarihinde " + item.Name + "\n\r";
                    index++;
                    if (index == 5)
                        break;
                }
                _message += TTUtils.CultureService.GetText("M26245", "işlemlerinin zamanı geçtiği halde uygulanmamış.");

                InfoMessageService.Instance.ShowMessage(_message);
            }
        }

        #region Hemşire Notu Raporu
        [HttpGet]
        public List<ResSection> GetResourceList()
        {
            List<ResSection> ResourceList = new List<ResSection>();
            foreach (var useResource in Common.CurrentResource.UserResources)
            {
                if (useResource.Resource is ResClinic)
                {
                    ResourceList.Add(useResource.Resource);
                }
            }

            ResourceList = ResourceList.OrderBy(x => x.Name).ToList<ResSection>();

            return ResourceList;

        }

        [HttpGet]
        public List<Patient> GetPatientList(Guid ResourceID)
        {
            List<Patient> patients = new List<Patient>();

            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                patients = Patient.GetInpatienPatientsByClinic(objectContext, ResourceID).ToList<Patient>();

                patients = patients.OrderBy(x => x.Name).ToList<Patient>();

                return patients;
            }

        }
        #endregion

        public bool ControlTreatmentMaterialActions(SubActionMaterial material, NursingApplicationMainFormViewModel viewModel)
        {
            if ((material.EpisodeAction?.ActionType != ActionTypeEnum.InPatientPhysicianApplication ||
                (material.EpisodeAction?.ActionType == ActionTypeEnum.InPatientPhysicianApplication
                && (((InPatientPhysicianApplication)material.EpisodeAction)?.InPatientTreatmentClinicApp != null
                && ((InPatientPhysicianApplication)material.EpisodeAction)?.InPatientTreatmentClinicApp?.IsDailyOperation == true))
                || ((InPatientPhysicianApplication)material.EpisodeAction)?.EmergencyIntervention != null)
                && material.EpisodeAction?.ActionType != ActionTypeEnum.TreatmentDischarge
                && material.EpisodeAction?.ActionType != ActionTypeEnum.InPatientTreatmentClinicApplication)
            {
                viewModel.SubEpisodeList.Add(material.SubEpisode);
                viewModel.EpisodeActionList.Add(material.EpisodeAction);
                return true;
            }

            else
                return false;
        }

        [HttpPost]
        public List<NewOrderDetailDTO> GetNewOrderDetail(GetNewOrderDetail_Input input)
        {
            List<NewOrderDetailDTO> output = new List<NewOrderDetailDTO>();
            using (TTObjectContext context = new TTObjectContext(false))
            {
                string filterExp = string.Empty;
                string nodFilter = string.Empty;

                string startDate = string.Empty;
                string endDate = string.Empty;

                if (input.allDate == false)
                {
                    startDate = Convert.ToDateTime((input.startDate.ToShortDateString() + " 00:00:00")).ToString("yyyy-MM-dd HH:mm:ss");
                    endDate = Convert.ToDateTime((input.endDate.ToShortDateString() + " 23:59:59")).ToString("yyyy-MM-dd HH:mm:ss");
                    filterExp += " AND ORDERPLANNEDDATE BETWEEN TODATE('" + startDate + "') AND TODATE('" + endDate + "')";
                    nodFilter = " AND THIS.WORKLISTDATE >= TODATE('" + input.startDate.ToString("yyyy-MM-dd HH:mm:ss") + "') AND THIS.WORKLISTDATE <= TODATE('" + input.endDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                }
                if (input.orderTypeId == 0 || input.orderTypeId == 1)
                {
                    if (input.drugOrderDetailStateIDs != null && input.drugOrderDetailStateIDs.Count > 0)
                    {
                        if (string.IsNullOrEmpty(filterExp))
                            filterExp = " AND " + Common.CreateFilterExpressionOfGuidList("", "CURRENTSTATEDEFID", input.drugOrderDetailStateIDs);
                        else
                            filterExp =  Common.CreateFilterExpressionOfGuidList(filterExp, "CURRENTSTATEDEFID", input.drugOrderDetailStateIDs);
                    }

                    BindingList<DrugOrderDetail.GetNewAllDrugOrderDetailRQ_Class> activeDrugOrderDetail = DrugOrderDetail.GetNewAllDrugOrderDetailRQ(input.nursingApplicationID, filterExp);
                    foreach (DrugOrderDetail.GetNewAllDrugOrderDetailRQ_Class drugDetail in activeDrugOrderDetail)
                    {
                        NewOrderDetailDTO detailDTO = new NewOrderDetailDTO();
                        detailDTO.DrugOrderDetailStatus = drugDetail.Statename;
                        detailDTO.ObjectDefID = drugDetail.ObjectDefID.Value;
                        detailDTO.ObjectID = drugDetail.ObjectID.Value;
                        detailDTO.StateID = drugDetail.CurrentStateDefID.Value.ToString();
                        detailDTO.OrderDate = drugDetail.OrderPlannedDate.Value;
                        detailDTO.OrderName = drugDetail.Material;
                        detailDTO.OrderType = "İlaç Direktifi";
                        detailDTO.typeId = OrderTypeEnum.DrugOrder;

                        if(drugDetail.CurrentStateDefID.Value == DrugOrderDetail.States.Apply)
                        {
                            DrugOrderDetail drugOrderDetail = context.GetObject<DrugOrderDetail>(drugDetail.ObjectID.Value);
                            List<TTObjectState> states = drugOrderDetail.GetStateHistory().ToList();
                            detailDTO.User = states[states.Count - 1].User.FullName;
                        }
                        output.Add(detailDTO);
                    }
                }

                if (input.orderTypeId == 0 || input.orderTypeId == 2)//tümü veya hemşirelik
                {
                    //nodFilter = " AND THIS.WORKLISTDATE >= TODATE('" + Convert.ToDateTime(startDate.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss") + "') AND THIS.WORKLISTDATE <= TODATE('" + Convert.ToDateTime(endDate.ToShortDateString() + " 00:00:00").ToString("yyyy-MM-dd HH:mm:ss") + "')";

                    if (input.nursingOrderDetailStateIDs != null && input.nursingOrderDetailStateIDs.Count > 0)
                    {
                        nodFilter += " AND " + Common.CreateFilterExpressionOfGuidList("", "CURRENTSTATEDEFID", input.nursingOrderDetailStateIDs);
                    }

                    NursingOrderDetail.GetNODByNursingApplication_RQ_Class[] _nodList = NursingOrderDetail.GetNODByNursingApplication_RQ(input.nursingApplicationID.ToString(), nodFilter).ToArray();
                    List<OrderScheduleDetail> _nursingOrderScheduleDetail = new List<OrderScheduleDetail>();
                    foreach (NursingOrderDetail.GetNODByNursingApplication_RQ_Class _nod in _nodList)
                    {
                        NewOrderDetailDTO detailDTO = new NewOrderDetailDTO();
                        detailDTO.NursingOrderStatus = _nod.Statusname.ToString();
                        detailDTO.ObjectDefID = _nod.ObjectDefID.Value;
                        detailDTO.ObjectID = _nod.ObjectID.Value;
                        detailDTO.StateID = _nod.CurrentStateDefID.Value.ToString();
                        detailDTO.OrderDate = _nod.WorkListDate.Value;
                        detailDTO.OrderName = _nod.Name;
                        detailDTO.OrderType = "Hemşirelik Direktifi";
                        detailDTO.typeId = OrderTypeEnum.NursingOrder;
                        detailDTO.User = _nod.Procedurebyuser;

                        #region Sonuç
                        string _res = string.Empty;

                        VitalSignAndNursingDefinition _vitalSignDef = context.GetObject(_nod.Typeid.Value, typeof(VitalSignAndNursingDefinition)) as VitalSignAndNursingDefinition;

                        if (_vitalSignDef.VitalSignType == VitalSignType.ANT && _nod.Result != null)
                            _res = "Ateş: " + _nod.Result;
                        else if (_nod.Result != null)
                            _res = "Sonuç: " + _nod.Result;

                        _res += _nod.Result_Pulse != null ? " Nabız: " + _nod.Result_Pulse : "";
                        _res += _nod.Result_SPO2 != null ? " SPo2: " + _nod.Result_SPO2 : "";
                        _res += _nod.ResultBloodPressure != null ? " Tan: " + _nod.ResultBloodPressure : "";

                        detailDTO.Result = _res;
                        #endregion

                        output.Add(detailDTO);

                        //OrderScheduleDetail nosd = new OrderScheduleDetail();
                        //DateTime _tempDate = _nod.WorkListDate.Value.AddMinutes(30);

                        //nosd.typeId = OrderTypeEnum.NursingOrder; //Hemşire direktif
                        //nosd.endDate = _tempDate.Day != nosd.startDate.Day ? _nod.WorkListDate.Value.AddMinutes(30 - (_tempDate.Minute + 1)) : _tempDate;
                        //nosd.statusName = _nod.Statusname.ToString();
                        //nosd.periodStartTime = _nod.PeriodStartTime.HasValue ? _nod.PeriodStartTime.Value : _nod.WorkListDate.Value; //bu saatten öncesine detay saati değişmesi
                        //nosd.isChanged = false;
                        //nosd.doctorDescription = _nod.OrderDescription + (_nod.Notes != null ? "\nH.N =" + _nod.Notes : "");


                        //_nursingOrderScheduleDetail.Add(nosd);
                    }
                }
            }

            output = output.OrderBy(x => x.OrderDate).ToList();
            return output;
        }

        [HttpPost]
        public ApplyNewOrderDetail_Output ApplyNewOrderDetail(List<NewOrderDetailDTO> input)
        {
            ApplyNewOrderDetail_Output output = new ApplyNewOrderDetail_Output();
            output.isError = false;
            output.msg = "İşlem Başarılı";
            using (TTObjectContext context = new TTObjectContext(false))
            {
                foreach (NewOrderDetailDTO item in input)
                {
                    DrugOrderDetail drugOrderDetail = (DrugOrderDetail)context.GetObject(item.ObjectID, typeof(DrugOrderDetail));
                    drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Apply;
                }

                try
                {
                    context.Save();
                }
                catch (Exception ex)
                {
                    output.isError = true;
                    output.msg = ex.Message;
                }
            }
            return output;
        }

        [HttpPost]
        public InPatientPhysicianApplication  GetActiveInPatientPhysicianApp(NursingAppDoneInfoInput input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                NursingApplication nursingApplication = (NursingApplication)objectContext.GetObject(input.NursingApplicationID, typeof(NursingApplication));
                return nursingApplication.InPatientTreatmentClinicApp.InPatientPhysicianApplication[0];
            }
        }
    }

}

namespace Core.Models
{
    public partial class NursingApplicationMainFormViewModel
    {
        public List<NursingDynamicComponent_SummaryInfo> NursingAppProgressSummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingGlaskowComaScaleSummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingPupilSymptomsSummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingPainScaleSummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingSpiritualSummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingNutritionAssessmentSummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingFunctionalLifeActivitySummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingPatientAndFamilyInstructionSummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingCareSummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingSystemInterrogationSummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingDischargingInstructionPlanSummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingFallingDownRiskSummaryInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingWoundAssessmentScaleInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingLegMeasurementInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingNutritionalRiskAssessmentInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingBodyFluidAnalysisInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingpatientPreAssesmentInfoList
        {
            get;
            set;
        }

        public List<NursingDynamicComponent_SummaryInfo> NursingWoundedAssessmentInfoList
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

        public bool HasPainInfo
        {
            get;
            set;
        }
        public string LastPainScaleInfo
        {
            get;
            set;
        }
        public bool HasWoundInfo
        {
            get;
            set;
        }
        public bool PatientPreAssesmentAddVisible
        {
            get;
            set;
        }

        public bool NursingPatientAndFamilyInstructionAddVisible
        {
            get;
            set;
        }

        public bool NursingDischargingInstructionPlanSummaryAddVisible
        {
            get;
            set;
        }

        public WoundAssessmentInfo woundAssessmentInfo
        {
            get;
            set;
        }
        public string LastWoundAssessmentInfo
        {
            get;
            set;
        }
        public string VitalSignWarningInfo = "";

        public bool HasVitalSignWarning = false;

        public bool HasOutDatedForm
        {
            get;
            set;
        }

        public string OutDatedFormsInfo
        {
            get;
            set;
        }
        public bool HasOutDatedFallingRiskForm
        {
            get;
            set;
        }
        public string OutDatedFallingRiskInfo
        {
            get;
            set;
        }
        public bool IsFallingRiskBiggerThanFive
        {
            get;
            set;
        }

        public string PatientNameSurname
        {
            get;
            set;
        }
        public string NurseName
        {
            get;
            set;
        }

        public bool hasOrthesisRequestRole { get; set; }

        public bool showFallingRiskParameter { get; set; }
        public TTObjectClasses.BaseTreatmentMaterial[] NewTreatmentMaterialsGridList { get; set; }

        public List<SubEpisode> SubEpisodeList
        {
            get; set;
        }

        public List<EpisodeAction> EpisodeActionList
        {
            get; set;
        }

        public bool HasYaraHemsireRole { get; set; }

        public bool ShowNewOrderTab { get; set; }
        public Patient _Patient { get; set; }

    }

    public class WoundAssessmentInfo
    {
        public List<PreventionAndMonitoringPlanDef> preventionDef
        {
            get;
            set;
        }

        public List<SurfaceSupportSystemsDef> surfaceSupportDef
        {
            get;
            set;
        }
        public List<EducationDef> educationDef
        {
            get;
            set;
        }
        public List<WoundAssessmentDef> woundAssessmentDef
        {
            get;
            set;
        }

    }

    public class NursingDynamicComponent_SummaryInfo
    {
        public Guid ObjectID;
        public DateTime? ApplicationDate;
        public string ApplicationUserName;
        public string ApplicationSummary;
        public string RowColor;
        public bool isDeleted;
    }
    public class GetBarcode
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public Guid NursingApplicationObjectid { get; set; }
    }

    public class NewOrderDetailDTO
    {
        public Guid ObjectID { get; set; }
        public Guid ObjectDefID { get; set; }
        public string StateID { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderName { get; set; }
        public string Result { get; set; }
        public string DrugOrderDetailStatus { get; set; }
        public string NursingOrderStatus { get; set; }
        public string OrderType { get; set; }
        public string User { get; set; }
        public OrderTypeEnum typeId { get; set; }
    }

    public class GetNewOrderDetail_Input
    {
        public Guid nursingApplicationID { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool allDate { get; set; }
        public int orderTypeId { get; set; }
        public List<Guid> drugOrderDetailStateIDs = new List<Guid>();
        public List<Guid> nursingOrderDetailStateIDs = new List<Guid>();
    }
    public class ApplyNewOrderDetail_Output
    {
        public bool isError { get; set; }
        public string msg { get; set; }
    }
}