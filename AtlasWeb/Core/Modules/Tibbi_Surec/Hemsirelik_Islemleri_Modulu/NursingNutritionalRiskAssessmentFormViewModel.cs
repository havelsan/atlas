//$DA172437
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class NursingNutritionalRiskAssessmentServiceController
    {
        partial void PreScript_NursingNutritionalRiskAssessmentForm(NursingNutritionalRiskAssessmentFormViewModel viewModel, NursingNutritionalRiskAssessment nursingNutritionalRiskAssessment, TTObjectContext objectContext)
        {
            if (nursingNutritionalRiskAssessment.ApplicationUser == null)
                nursingNutritionalRiskAssessment.ApplicationUser = Common.CurrentResource;

            if (!((ITTObject)nursingNutritionalRiskAssessment).IsNew && !viewModel.ReadOnly)
            {
                using (var nasc = new Core.Controllers.NursingApplicationServiceController())
                {
                    viewModel.ReadOnly = nasc.ArrangeNursingApplicationReadOnly((BaseNursingDataEntry)nursingNutritionalRiskAssessment);
                }
            }
            Guid? selectedEpisodeObjectID = viewModel.GetSelectedEpisodeID();
            if (selectedEpisodeObjectID.HasValue)
            {
                Episode episode = objectContext.GetObject<Episode>(selectedEpisodeObjectID.Value);
                if (episode.Patient.Age != null)
                    viewModel.PatientAge = episode.Patient.Age;
            }

            if (nursingNutritionalRiskAssessment.NursingApplication != null && nursingNutritionalRiskAssessment.NursingApplication.NursingNutritionalRiskAssessments != null){
                viewModel.NursingAppProgressSummaryInfoList = NursingApplicationServiceController.GetBaseNursingDataEntrySummaryInfoList(0,100,nursingNutritionalRiskAssessment.NursingApplication.NursingNutritionalRiskAssessments.ToList<BaseNursingDataEntry>());
                viewModel.writeAllReportControl = true;
            }
        }
        partial void PostScript_NursingNutritionalRiskAssessmentForm(NursingNutritionalRiskAssessmentFormViewModel viewModel, NursingNutritionalRiskAssessment nursingNutritionalRiskAssessment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            Patient patient = nursingNutritionalRiskAssessment?.NursingApplication?.Episode?.Patient;
            if (patient != null)
            {
                nursingNutritionalRiskAssessment.TotalScore = NursingNutritionalRiskAssessment.CalcNursingWoundAssessmentScaleTotalRisk(nursingNutritionalRiskAssessment, patient);
            }

            string _resID = TTObjectClasses.SystemParameter.GetParameterValue("DIETRESSECTIONGUID", "");
            ResSection dietResSection = null;

            if (_resID != "")
                dietResSection = (ResSection)objectContext.GetObject(new Guid(_resID), "ResSection");

            if (nursingNutritionalRiskAssessment.TotalScore >= 3 && dietResSection != null)
            {
                Consultation consultation = new Consultation(objectContext, nursingNutritionalRiskAssessment.NursingApplication);
                consultation.RequestDescription = "Hastanýn NSR Açýsýndan deðerlendirilmesi <br />";
                consultation.RequesterResource = nursingNutritionalRiskAssessment.NursingApplication.FromResource;
                consultation.MasterResource = dietResSection;
                if (nursingNutritionalRiskAssessment.Height != null)
                    consultation.RequestDescription += "Boy: " + nursingNutritionalRiskAssessment.Height?.ToString() + " <br />";
                if (nursingNutritionalRiskAssessment.Weight != null)
                    consultation.RequestDescription += "Kilo: " + nursingNutritionalRiskAssessment.Weight?.ToString() + " <br />";
                consultation.RequestDescription += " <br />";
                if (nursingNutritionalRiskAssessment.BMI != null || nursingNutritionalRiskAssessment.ThreeMonthWeightLoss != null || nursingNutritionalRiskAssessment.WeeklyIntakeDecrease != null || nursingNutritionalRiskAssessment.SevereDiseaseInfo != null)
                {
                    consultation.RequestDescription += "Ön Deðerlendirme <br />";
                    if (nursingNutritionalRiskAssessment.BMI == true)
                        consultation.RequestDescription += "Vücut Kitle Ýndeksi (VKÝ) < 20,5 kg/m2 mi? Evet <br />";
                    else if(nursingNutritionalRiskAssessment.BMI == false)
                        consultation.RequestDescription += "Vücut Kitle Ýndeksi (VKÝ) < 20,5 kg/m2 mi? Hayýr <br />";

                    if (nursingNutritionalRiskAssessment.ThreeMonthWeightLoss == true)
                        consultation.RequestDescription += "Hasta son 3 ayda kilo kaybetti mi? Evet <br />";
                    else if(nursingNutritionalRiskAssessment.ThreeMonthWeightLoss == false)
                        consultation.RequestDescription += "Hasta son 3 ayda kilo kaybetti mi? Hayýr <br />";

                    if (nursingNutritionalRiskAssessment.WeeklyIntakeDecrease == true)
                        consultation.RequestDescription += "Geçen Hafta Gýda Alýmýnda Azalma Oldu Mu? Evet <br />";
                    else if (nursingNutritionalRiskAssessment.WeeklyIntakeDecrease == false)
                        consultation.RequestDescription += "Geçen Hafta Gýda Alýmýnda Azalma Oldu Mu? Hayýr <br />";

                    if (nursingNutritionalRiskAssessment.SevereDiseaseInfo == true)
                        consultation.RequestDescription += "Hasta ileri derecede hasta mý? (Örneðin yoðun bakýmda mý?) Evet <br />";
                    else if (nursingNutritionalRiskAssessment.SevereDiseaseInfo == false)
                        consultation.RequestDescription += "Hasta ileri derecede hasta mý? (Örneðin yoðun bakýmda mý?) Hayýr <br />";
                    consultation.RequestDescription += " <br />";
                }

                if(nursingNutritionalRiskAssessment.NutritionIntake != null)
                {
                    consultation.RequestDescription += "Beslenme Durumundaki Bozulma <br />";
                    if (nursingNutritionalRiskAssessment.NutritionIntake == NutritionIntakeAssessmentEnum.Normal)
                        consultation.RequestDescription += "Normal Beslenme Durumu <br />";
                    else if (nursingNutritionalRiskAssessment.NutritionIntake == NutritionIntakeAssessmentEnum.ThreeMonths)
                        consultation.RequestDescription += "3 ayda > %5 kilo kaybý veya geçen haftaki besin alýmý normal gereksinimlerin %50-75'inin altýnda <br />";
                    else if (nursingNutritionalRiskAssessment.NutritionIntake == NutritionIntakeAssessmentEnum.TwoMonths)
                        consultation.RequestDescription += "2 ay içinde kilo kaybý > %5 kilo kaybý veya VKÝ 18,5-20,5 + genel durum bozukluðu veya geçen haftaki besin alýmý normal gereksinimlerin %25-50'si <br />";
                    else if (nursingNutritionalRiskAssessment.NutritionIntake == NutritionIntakeAssessmentEnum.OneMonth)
                        consultation.RequestDescription += "1 ay içinde kilo kaybý > %5 (3 ayda > %15) veya VKÝ 18,5 + genel durum bozukluðu veya geçen haftaki besin alýmý normal ihtiyacýnýn %0-25'i <br />";
                    consultation.RequestDescription += " <br />";
                }

                if(nursingNutritionalRiskAssessment.DiseaseLevelLow == true || nursingNutritionalRiskAssessment.DiseaseLevelNormal == true || nursingNutritionalRiskAssessment.DiseaseLevelMedium == true || nursingNutritionalRiskAssessment.DiseaseLevelHigh == true)
                {
                    consultation.RequestDescription += "Hastalýk Þiddeti <br />";
                    if (nursingNutritionalRiskAssessment.DiseaseLevelNormal == true)
                        consultation.RequestDescription += "Normal besin gereksinimi <br />";
                    if (nursingNutritionalRiskAssessment.DiseaseLevelLow == true)
                        consultation.RequestDescription += "Özellikle akut komplikasyonlarý olan kronik hasta <br />";
                    if (nursingNutritionalRiskAssessment.DiseaseLevelMedium == true)
                        consultation.RequestDescription += "Majör abdominal cerrahi, Ýnme, Þiddetli Pnömoni <br />";
                    if (nursingNutritionalRiskAssessment.DiseaseLevelHigh == true)
                        consultation.RequestDescription += "Kafa travmasý, kemik iliði transplantasyonu <br />";
                    consultation.RequestDescription += " <br />";
                }
            }

        }
    }
}

namespace Core.Models
{
    public partial class NursingNutritionalRiskAssessmentFormViewModel : BaseViewModel
    {
        public int? PatientAge
        {
            get;
            set;
        }
        
       public List<NursingDynamicComponent_SummaryInfo> NursingAppProgressSummaryInfoList
        {
            get;
            set;
        }

        public Boolean writeAllReportControl
        {
            get;
            set;
        }
    }
}
