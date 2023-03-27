
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
    public  partial class NursingPainScale : BaseNursingDataEntry
    {
        public override string GetApplicationSummary()
        {
            string tempString = String.Empty;

            if (PainPlaces != null)
                tempString += TTUtils.CultureService.GetText("M25138", "Ağrı yeri:")+ PainPlaces.Name + ",";
            if (PainDetail != null && PainDetail != String.Empty)
                tempString += TTUtils.CultureService.GetText("M25133", "Ağrı detay:")+ PainDetail + ",";
            if (DurationofPain != null)
                tempString +=  DurationofPain + " dan bu zamana ağrısı mevcut,";
            if (PainTime != null)
                tempString += TTUtils.CultureService.GetText("M25137", "Ağrı süresi:")+ PainTime + ",";
            if (AchingSide != null)
                tempString += TTUtils.CultureService.GetText("M25140", "Ağrıyan taraf:")+ AchingSide + ",";
            if (PainFrequency != null)
                tempString += TTUtils.CultureService.GetText("M25136", "Ağrı sıklığı:")+ PainFrequency.Name + ",";
            if (PainQuality != null)
                tempString += TTUtils.CultureService.GetText("M25135", "Ağrı niteliği:")+ PainQuality.Name + ",";
            if (PainQualityDescription != null)
                tempString += TTUtils.CultureService.GetText("M25134", "Ağrı niteliği açıklama:")+ PainQualityDescription + ",";
            //if (PainPlaces != null)
            //    tempString += "Ağrı yeri:" + PainPlaces.Name + ",";

            return tempString;
        }

        public override string GetRowColor()
        {
            return string.Empty;
        }
    }
}