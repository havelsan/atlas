
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
    public partial class NursingNutritionalRiskAssessment : BaseNursingDataEntry
    {
        #region Methods
        public static int? CalcNursingWoundAssessmentScaleTotalRisk(NursingNutritionalRiskAssessment nursingNutritionalRiskAssessment, Patient patient)
        {
            int? toplam = 0;

            if (patient.Age.Value > 70)
                toplam += 1;

            if (nursingNutritionalRiskAssessment.DiseaseLevelLow != null && (bool)nursingNutritionalRiskAssessment.DiseaseLevelLow)
                toplam += 1;
            if (nursingNutritionalRiskAssessment.DiseaseLevelMedium != null && (bool)nursingNutritionalRiskAssessment.DiseaseLevelMedium)
                toplam += 2;
            if (nursingNutritionalRiskAssessment.DiseaseLevelHigh != null && (bool)nursingNutritionalRiskAssessment.DiseaseLevelHigh)
                toplam += 3;

            if (nursingNutritionalRiskAssessment.NutritionIntake == NutritionIntakeAssessmentEnum.ThreeMonths)
                toplam += 1;
            else if (nursingNutritionalRiskAssessment.NutritionIntake == NutritionIntakeAssessmentEnum.TwoMonths)
                toplam += 2;
            else if (nursingNutritionalRiskAssessment.NutritionIntake == NutritionIntakeAssessmentEnum.OneMonth)
                toplam += 3;

            return toplam;

        }


        public override string GetApplicationSummary()
        {
            string tempString = "";
            tempString = " Toplam Risk Puanı: " + TotalScore;
            if (TotalScore < 3)
                tempString += " - Beslenme riski yoktur.";
            else
                tempString += " - Beslenme riski mevcut, beslenme planı başlatılır..";
            return tempString;
        }

        public override string GetRowColor()
        {
            return string.Empty;
        }
        #endregion Methods
    }
}
