
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
    /// Glaskow Skorlama
    /// </summary>
    public partial class GlaskowScore : BaseMultipleDataEntry
    {
        public override string GetSummary()
        {
            string tempString = String.Empty;

            if (Eyes != null && Eyes.ObjectID != null)
            {
                tempString += " Gözler: " + Eyes.Name_Shadow + ",";
            }

            if (OralAnswer != null && OralAnswer.ObjectID != null)
            {
                tempString += " Sözel Cevap: " + OralAnswer.Name_Shadow + ",";
            }

            if (MotorAnswer != null && MotorAnswer.ObjectID != null)
            {
                tempString += " Motor Cevap: " + MotorAnswer.Name_Shadow;
            }
            if (tempString != String.Empty)
                tempString = " Toplam Skor: " + Total + " - " + Common.GetDisplayTextOfDataTypeEnum(TotalScore.Value) + "," + tempString;

            return tempString;
        }
    }
}