
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
    public  partial class NursingLegMeasurement : BaseNursingDataEntry
    {
        public override string GetApplicationSummary()
        {
            string tempString = "";
            tempString = "Sağ Alt: " + LowerRightLeg + "cm - Sağ Üst: " + UpperRightLeg + "cm - Sol Alt: " + LowerLeftLeg + "cm - Sol Üst: " + UpperLeftLeg + TTUtils.CultureService.GetText("M25367", "cm");
            return tempString;
        }

        public override string GetRowColor()
        {
            return string.Empty;
        }
    }
}