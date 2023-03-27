
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
    public partial class NursingWoundAssessmentScale : BaseNursingDataEntry
    {
        #region Methods
        public static int? CalcNursingWoundAssessmentScaleTotalRisk(NursingWoundAssessmentScale nursingWoundAssessmentScale, Patient patient)
        {
            int? toplam = 0;
            if (patient.Sex.ADI == "KADIN")
            {
                toplam += 2;
            }
            else if (patient.Sex.ADI == "ERKEK")
                toplam += 1;

            if (patient.Age.Value >= 14 && patient.Age.Value <= 49)
                toplam += 1;
            else if (patient.Age.Value >= 50 && patient.Age.Value <= 64)
                toplam += 2;
            else if (patient.Age.Value >= 65 && patient.Age.Value <= 75)
                toplam += 3;
            else if (patient.Age.Value >= 75 && patient.Age.Value <= 80)
                toplam += 4;
            else if (patient.Age.Value >= 81)
                toplam += 5;

            if (nursingWoundAssessmentScale.BodyType == BodyTypeEnum.Average)
                toplam += 0;
            else if (nursingWoundAssessmentScale.BodyType == BodyTypeEnum.AboveAverage)
                toplam += 1;
            else if (nursingWoundAssessmentScale.BodyType == BodyTypeEnum.OverWeight)
                toplam += 2;
            else if (nursingWoundAssessmentScale.BodyType == BodyTypeEnum.BelowAverage)
                toplam += 3;

            if (nursingWoundAssessmentScale.Continence == ContinenceEnum.FullContinence)
                toplam += 0;
            else if (nursingWoundAssessmentScale.Continence == ContinenceEnum.ContinenceInCatheterAndStool)
                toplam += 0;
            else if (nursingWoundAssessmentScale.Continence == ContinenceEnum.OccasionalIncontinence)
                toplam += 1;
            else if (nursingWoundAssessmentScale.Continence == ContinenceEnum.StoolIncontinence)
                toplam += 2;
            else if (nursingWoundAssessmentScale.Continence == ContinenceEnum.FullIncontinence)
                toplam += 3;

            if (nursingWoundAssessmentScale.NeurologicalDisorders == NeurologicalDisordersEnum.Medium)
                toplam += 4;
            else if (nursingWoundAssessmentScale.NeurologicalDisorders == NeurologicalDisordersEnum.MediumHeavy)
                toplam += 5;
            else if (nursingWoundAssessmentScale.NeurologicalDisorders == NeurologicalDisordersEnum.Heavy)
                toplam += 6;

            if (nursingWoundAssessmentScale.Mobility == MobilityEnum.FullMobility)
                toplam += 0;
            else if (nursingWoundAssessmentScale.Mobility == MobilityEnum.Uneasy)
                toplam += 1;
            else if (nursingWoundAssessmentScale.Mobility == MobilityEnum.Apathic)
                toplam += 2;
            else if (nursingWoundAssessmentScale.Mobility == MobilityEnum.LimitedMobility)
                toplam += 3;
            else if (nursingWoundAssessmentScale.Mobility == MobilityEnum.InTraction)
                toplam += 4;
            else if (nursingWoundAssessmentScale.Mobility == MobilityEnum.WheelchairBound)
                toplam += 5;

            if (nursingWoundAssessmentScale.SkinHealthy == true)
                toplam += 0;
            if (nursingWoundAssessmentScale.SkinThin == true)
                toplam += 1;
            if (nursingWoundAssessmentScale.SkinDry == true)
                toplam += 1;
            if (nursingWoundAssessmentScale.SkinDropsy == true)
                toplam += 1;
            if (nursingWoundAssessmentScale.SkinColdAndMoist == true)
                toplam += 1;
            if (nursingWoundAssessmentScale.SkinDiscolored == true)
                toplam += 2;
            if (nursingWoundAssessmentScale.SkinIntegrityBroken == true)
                toplam += 3;

            if (nursingWoundAssessmentScale.MedicineUsage == true)
                toplam += 4;

            if (nursingWoundAssessmentScale.AppetiteAverage == true)
                toplam += 0;
            if (nursingWoundAssessmentScale.AppetitePoor == true)
                toplam += 1;
            if (nursingWoundAssessmentScale.AppetiteNg == true)
                toplam += 2;
            if (nursingWoundAssessmentScale.AppetiteOnlyLiquid == true)
                toplam += 2;
            if (nursingWoundAssessmentScale.AppetiteAnorexia == true)
                toplam += 3;

            if (nursingWoundAssessmentScale.DMTerminalCachexia == true)
                toplam += 8;
            if (nursingWoundAssessmentScale.DMHeartFailure == true)
                toplam += 5;
            if (nursingWoundAssessmentScale.DMPeripheralVascularDisease == true)
                toplam += 5;
            if (nursingWoundAssessmentScale.DMAnemia == true)
                toplam += 2;
            if (nursingWoundAssessmentScale.DMCigaretteUsage == true)
                toplam += 1;

            if (nursingWoundAssessmentScale.SurgeryOrthopedic == true)
                toplam += 5;
            if (nursingWoundAssessmentScale.SurgeryLongerThan2Hours == true)
                toplam += 5;

            return toplam;


        }


        public override string GetApplicationSummary()
        {
            string tempString = "";
            tempString = " Toplam Risk Puanı: " + TotalRisk;
            return tempString;
        }

        public override string GetRowColor()
        {
            return string.Empty;
        }
        #endregion Methods
    }
}