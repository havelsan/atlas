
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
    public partial class WeightChart : BaseMultipleDataEntry
    {
        public override string GetSummary()
        {
            string tempString = String.Empty;
            if (HeadCircumference != null)
            {
                tempString += "Baþ Çevresi: " + HeadCircumference + ",";
            }
            if (Length != null)
            {
                tempString += "Boy: " + Length + ",";
            }
            if (Weight != null)
            {
                tempString += "Kilo: " + Weight + ",";
            }
            return tempString;
        }
    }
}