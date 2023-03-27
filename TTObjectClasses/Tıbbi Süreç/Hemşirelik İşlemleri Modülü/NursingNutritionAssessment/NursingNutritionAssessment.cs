
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
    public  partial class NursingNutritionAssessment : BaseNursingDataEntry
    {
        public override string GetApplicationSummary()
        {
            string tempString = String.Empty;

            if (Weight != null)
                tempString += TTUtils.CultureService.GetText("M26305", "Kilo:")+ Weight + ",";
            if (Height != null)
                tempString += TTUtils.CultureService.GetText("M25290", "Boy:")+ Height + ",";
            if (Panorama != null )
                tempString += TTUtils.CultureService.GetText("M25703", "Genel Görünüm:")+ Panorama.Name + ",";
            return tempString;
        }

        public override string GetRowColor()
        {
            return string.Empty;
        }
    }
}