
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
    public  partial class NursingSpiritualEvaluation : BaseNursingDataEntry
    {
        public override string GetApplicationSummary()
        {
            string tempString = String.Empty;

            if (Normal != null && Normal.Value)
            {
                tempString +=  TTUtils.CultureService.GetText("M26583", "Normal ,");
            }
            if (Furious != null && Furious.Value)
            {
                tempString += TTUtils.CultureService.GetText("M26657", "Öfkeli ,");
            }
            if (Indifferent != null && Indifferent.Value)
            {
                tempString += TTUtils.CultureService.GetText("M26285", "Kayıtsız ,");
            }
            if (Nervous != null && Nervous.Value)
            {
                tempString += TTUtils.CultureService.GetText("M25586", "Endişeli ,");
            }
            if (Sad != null && Sad.Value)
            {
                tempString += TTUtils.CultureService.GetText("M27168", "Üzüntülü ,");
            }

            if (Other != null && Other.Value)
            {
                tempString += Explanation + ",";
            }


            if (tempString != String.Empty)
                tempString = " Ruhsal Durum: " + tempString;

            return tempString;
        }

        public override string GetRowColor()
        {
            return string.Empty;
        }
    }
}