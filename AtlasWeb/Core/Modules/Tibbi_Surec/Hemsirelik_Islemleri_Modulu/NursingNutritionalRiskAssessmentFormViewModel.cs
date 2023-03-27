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
                consultation.RequestDescription = "Hastan�n NSR A��s�ndan de�erlendirilmesi <br />";
                consultation.RequesterResource = nursingNutritionalRiskAssessment.NursingApplication.FromResource;
                consultation.MasterResource = dietResSection;
                if (nursingNutritionalRiskAssessment.Height != null)
                    consultation.RequestDescription += "Boy: " + nursingNutritionalRiskAssessment.Height?.ToString() + " <br />";
                if (nursingNutritionalRiskAssessment.Weight != null)
                    consultation.RequestDescription += "Kilo: " + nursingNutritionalRiskAssessment.Weight?.ToString() + " <br />";
                consultation.RequestDescription += " <br />";
                if (nursingNutritionalRiskAssessment.BMI != null || nursingNutritionalRiskAssessment.ThreeMonthWeightLoss != null || nursingNutritionalRiskAssessment.WeeklyIntakeDecrease != null || nursingNutritionalRiskAssessment.SevereDiseaseInfo != null)
                {
                    consultation.RequestDescription += "�n De�erlendirme <br />";
                    if (nursingNutritionalRiskAssessment.BMI == true)
                        consultation.RequestDescription += "V�cut Kitle �ndeksi (VK�) < 20,5 kg/m2 mi? Evet <br />";
                    else if(nursingNutritionalRiskAssessment.BMI == false)
                        consultation.RequestDescription += "V�cut Kitle �ndeksi (VK�) < 20,5 kg/m2 mi? Hay�r <br />";

                    if (nursingNutritionalRiskAssessment.ThreeMonthWeightLoss == true)
                        consultation.RequestDescription += "Hasta son 3 ayda kilo kaybetti mi? Evet <br />";
                    else if(nursingNutritionalRiskAssessment.ThreeMonthWeightLoss == false)
                        consultation.RequestDescription += "Hasta son 3 ayda kilo kaybetti mi? Hay�r <br />";

                    if (nursingNutritionalRiskAssessment.WeeklyIntakeDecrease == true)
                        consultation.RequestDescription += "Ge�en Hafta G�da Al�m�nda Azalma Oldu Mu? Evet <br />";
                    else if (nursingNutritionalRiskAssessment.WeeklyIntakeDecrease == false)
                        consultation.RequestDescription += "Ge�en Hafta G�da Al�m�nda Azalma Oldu Mu? Hay�r <br />";

                    if (nursingNutritionalRiskAssessment.SevereDiseaseInfo == true)
                        consultation.RequestDescription += "Hasta ileri derecede hasta m�? (�rne�in yo�un bak�mda m�?) Evet <br />";
                    else if (nursingNutritionalRiskAssessment.SevereDiseaseInfo == false)
                        consultation.RequestDescription += "Hasta ileri derecede hasta m�? (�rne�in yo�un bak�mda m�?) Hay�r <br />";
                    consultation.RequestDescription += " <br />";
                }

                if(nursingNutritionalRiskAssessment.NutritionIntake != null)
                {
                    consultation.RequestDescription += "Beslenme Durumundaki Bozulma <br />";
                    if (nursingNutritionalRiskAssessment.NutritionIntake == NutritionIntakeAssessmentEnum.Normal)
                        consultation.RequestDescription += "Normal Beslenme Durumu <br />";
                    else if (nursingNutritionalRiskAssessment.NutritionIntake == NutritionIntakeAssessmentEnum.ThreeMonths)
                        consultation.RequestDescription += "3 ayda > %5 kilo kayb� veya ge�en haftaki besin al�m� normal gereksinimlerin %50-75'inin alt�nda <br />";
                    else if (nursingNutritionalRiskAssessment.NutritionIntake == NutritionIntakeAssessmentEnum.TwoMonths)
                        consultation.RequestDescription += "2 ay i�inde kilo kayb� > %5 kilo kayb� veya VK� 18,5-20,5 + genel durum bozuklu�u veya ge�en haftaki besin al�m� normal gereksinimlerin %25-50'si <br />";
                    else if (nursingNutritionalRiskAssessment.NutritionIntake == NutritionIntakeAssessmentEnum.OneMonth)
                        consultation.RequestDescription += "1 ay i�inde kilo kayb� > %5 (3 ayda > %15) veya VK� 18,5 + genel durum bozuklu�u veya ge�en haftaki besin al�m� normal ihtiyac�n�n %0-25'i <br />";
                    consultation.RequestDescription += " <br />";
                }

                if(nursingNutritionalRiskAssessment.DiseaseLevelLow == true || nursingNutritionalRiskAssessment.DiseaseLevelNormal == true || nursingNutritionalRiskAssessment.DiseaseLevelMedium == true || nursingNutritionalRiskAssessment.DiseaseLevelHigh == true)
                {
                    consultation.RequestDescription += "Hastal�k �iddeti <br />";
                    if (nursingNutritionalRiskAssessment.DiseaseLevelNormal == true)
                        consultation.RequestDescription += "Normal besin gereksinimi <br />";
                    if (nursingNutritionalRiskAssessment.DiseaseLevelLow == true)
                        consultation.RequestDescription += "�zellikle akut komplikasyonlar� olan kronik hasta <br />";
                    if (nursingNutritionalRiskAssessment.DiseaseLevelMedium == true)
                        consultation.RequestDescription += "Maj�r abdominal cerrahi, �nme, �iddetli Pn�moni <br />";
                    if (nursingNutritionalRiskAssessment.DiseaseLevelHigh == true)
                        consultation.RequestDescription += "Kafa travmas�, kemik ili�i transplantasyonu <br />";
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
