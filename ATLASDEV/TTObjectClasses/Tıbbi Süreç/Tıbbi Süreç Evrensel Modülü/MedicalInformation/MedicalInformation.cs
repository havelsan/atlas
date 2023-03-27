
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Tıbbi Bilgiler/Uyarılar/Alarmlar
    /// </summary>
    public partial class MedicalInformation : TTObject
    {

        public string GetMedicalInformationSummary()
        {
            var summary = string.Empty;

            if (OncologicFollowUp != null)
                summary += ObjectDef.AllPropertyDefs["OncologicFollowUp"].DisplayText + ":" + OncologicFollowUp;
            if (Hemodialysis != null)
                summary += ObjectDef.AllPropertyDefs["Hemodialysis"].DisplayText + ":" + Hemodialysis + "/";
            if (Implant != null)
                summary += ObjectDef.AllPropertyDefs["Implant"].DisplayText + ":" + Implant + "/";
            if (ContagiousDisease != null)
                summary += ObjectDef.AllPropertyDefs["ContagiousDisease"].DisplayText + ":" + ContagiousDisease + "/";
            if (Transplantation != null)
                summary += ObjectDef.AllPropertyDefs["Transplantation"].DisplayText + ":" + Transplantation + "/";
            if (OtherInformation != null)
                summary += ObjectDef.AllPropertyDefs["OtherInformation"].DisplayText + ":" + OtherInformation + "/";
            if (ChronicDiseases != null)
                summary += ObjectDef.AllPropertyDefs["ChronicDiseases"].DisplayText + ":" + ChronicDiseases + "/";

            if (Broken != null && Broken == true)
                summary += ObjectDef.AllPropertyDefs["Broken"].DisplayText + "/";

            if (CardiacPacemaker != null && CardiacPacemaker == true)
                summary += ObjectDef.AllPropertyDefs["CardiacPacemaker"].DisplayText + "/";

            if (Diabetes != null && Diabetes == true)
                summary += ObjectDef.AllPropertyDefs["Diabetes"].DisplayText + "/";

            if (HeartFailure != null && HeartFailure == true)
                summary += ObjectDef.AllPropertyDefs["HeartFailure"].DisplayText + "/";

            if (Infection != null && Infection == true)
                summary += ObjectDef.AllPropertyDefs["Infection"].DisplayText + "/";

            if (Malignancy != null && Malignancy == true)
                summary += ObjectDef.AllPropertyDefs["Malignancy"].DisplayText + "/";

            if (MetalImplant != null && MetalImplant == true)
                summary += ObjectDef.AllPropertyDefs["MetalImplant"].DisplayText + "/";

            if (Other != null && Other == true)
                summary += ObjectDef.AllPropertyDefs["Other"].DisplayText + "/";

            if (Pregnancy != null && Pregnancy == true)
                summary += ObjectDef.AllPropertyDefs["Pregnancy"].DisplayText + "/";

            if (Stent != null && Stent == true)
                summary += ObjectDef.AllPropertyDefs["Stent"].DisplayText + "/";

            if (VascularDisorder != null && VascularDisorder == true)
                summary += ObjectDef.AllPropertyDefs["VascularDisorder"].DisplayText + "/";


            //ALERJI
            if (MedicalInfoAllergies != null)
            {

                var patientAllergies = MedicalInfoAllergies;
                if (patientAllergies.MedicalInfoFoodAllergies != null && patientAllergies.MedicalInfoFoodAllergies.Count > 0)
                {
                    summary += "GIDA ALERJİSİ" + ":";
                    foreach (MedicalInfoFoodAllergies foodAllergyItem in patientAllergies.MedicalInfoFoodAllergies)
                    {
                        summary += foodAllergyItem.DietMaterial.MaterialName + ",";
                    }
                }
                if (patientAllergies.MedicalInfoDrugAllergies != null && patientAllergies.MedicalInfoDrugAllergies.Count > 0)
                {
                    summary += "İLAÇ ALERJİSİ" + ":";
                    foreach (MedicalInfoDrugAllergies drugAllergyItem in patientAllergies.MedicalInfoDrugAllergies)
                    {
                        summary += drugAllergyItem.ActiveIngredient.Name + ",";
                    }
                }

                if (patientAllergies.OtherAllergies != null)
                {
                    summary += "DİĞER ALERJİLER" + ":" + patientAllergies.OtherAllergies ;
                }
            }
          

            var summaryMedicalInfoDisabledGroup = string.Empty;
            var patientDisableStatus = MedicalInfoDisabledGroup;
            if (patientDisableStatus != null)
            {

                if (patientDisableStatus.Chronic != null && patientDisableStatus.Chronic == true)
                    summaryMedicalInfoDisabledGroup += patientDisableStatus.ObjectDef.AllPropertyDefs["Chronic"].DisplayText + "/";// "Süreğen(Kronik)");

                if (patientDisableStatus.Hearing != null && patientDisableStatus.Hearing == true)
                    summaryMedicalInfoDisabledGroup += patientDisableStatus.ObjectDef.AllPropertyDefs["Hearing"].DisplayText + "/"; //"İşitme");

                if (patientDisableStatus.Mental != null && patientDisableStatus.Mental == true)
                    summaryMedicalInfoDisabledGroup += patientDisableStatus.ObjectDef.AllPropertyDefs["Mental"].DisplayText + "/"; //"Zihinsel");

                if (patientDisableStatus.Nonexistence != null && patientDisableStatus.Nonexistence == true)
                    summaryMedicalInfoDisabledGroup += patientDisableStatus.ObjectDef.AllPropertyDefs["Nonexistence"].DisplayText + "/";//"Yok");

                if (patientDisableStatus.Orthopedic != null && patientDisableStatus.Orthopedic == true)
                    summaryMedicalInfoDisabledGroup += patientDisableStatus.ObjectDef.AllPropertyDefs["Orthopedic"].DisplayText + "/"; //"Ortopedik");

                if (patientDisableStatus.PsychicAndEmotional != null && patientDisableStatus.PsychicAndEmotional == true)
                    summaryMedicalInfoDisabledGroup += patientDisableStatus.ObjectDef.AllPropertyDefs["PsychicAndEmotional"].DisplayText + "/"; //"Ruhsal ve Duygusal");

                if (patientDisableStatus.SpeechAndLanguage != null && patientDisableStatus.SpeechAndLanguage == true)
                    summaryMedicalInfoDisabledGroup += patientDisableStatus.ObjectDef.AllPropertyDefs["SpeechAndLanguage"].DisplayText + "/"; //Dil ve Konuşma");

                if (patientDisableStatus.Unclassified != null && patientDisableStatus.Unclassified == true)
                    summaryMedicalInfoDisabledGroup += patientDisableStatus.ObjectDef.AllPropertyDefs["Unclassified"].DisplayText + "/"; //"Sınıflanmayan");

                if (patientDisableStatus.Vision != null && patientDisableStatus.Vision == true)
                    summaryMedicalInfoDisabledGroup += patientDisableStatus.ObjectDef.AllPropertyDefs["Vision"].DisplayText + "/"; //"Görme");

            }

            if (!string.IsNullOrEmpty(summaryMedicalInfoDisabledGroup))
            {
                summary += "ENGEL DURUMU" + ":" + summaryMedicalInfoDisabledGroup;
            }

            var summaryMedicalInfoHabits = string.Empty;
            var patientHabits = MedicalInfoHabits;
            if (patientHabits != null)
            {
                if (patientHabits.Alcohol != null && patientHabits.Alcohol == true)
                    summaryMedicalInfoHabits += patientHabits.ObjectDef.AllPropertyDefs["Alcohol"].DisplayText + "/";
                if (patientHabits.Cigarette != null && patientHabits.Cigarette == true)
                    summaryMedicalInfoHabits += patientHabits.ObjectDef.AllPropertyDefs["Cigarette"].DisplayText + "/";
                if (patientHabits.Coffee != null && patientHabits.Coffee == true)
                    summaryMedicalInfoHabits += patientHabits.ObjectDef.AllPropertyDefs["Coffee"].DisplayText + "/";
                if (patientHabits.Tea != null && patientHabits.Tea == true)
                    summaryMedicalInfoHabits += patientHabits.ObjectDef.AllPropertyDefs["Tea"].DisplayText + "/";
                if (patientHabits.Other != null && patientHabits.Other == true)
                    summaryMedicalInfoHabits += patientHabits.ObjectDef.AllPropertyDefs["Other"].DisplayText + ":" + patientHabits.Description + "/";
            }

            if(!string.IsNullOrEmpty(summaryMedicalInfoHabits))
            {
                summary += "ALIŞKANLIK" + ":" + summaryMedicalInfoHabits;
            }


            return summary;
        }
    }
}