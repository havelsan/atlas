
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
    public  partial class NursingWoundedAssesment : BaseNursingDataEntry
    {
        public override string GetApplicationSummary()
        {
            string tempString = String.Empty;

            if (WoundedType != null && WoundedType.HasValue == true)
            {
                tempString += " Yara Türü: " + Common.GetDisplayTextOfDataTypeEnum(WoundedType.Value) + ",";
            }

            if (OperationDate != null)
            {
                tempString += " Operasyon Tarihi: " + OperationDate + ",";
            }

            if (Width != null )
            {
                tempString += " En: " + Width;
            }

            if (Height != null)
            {
                tempString += " Boy: " + Height;
            }

            if (Depth != null)
            {
                tempString += " Derinlik: " + Depth;
            }

            if (WoundStage != null && WoundStage.ObjectID != null)
            {
                tempString += " Evre: " + WoundStage.Name;
            }

            return tempString;
        }
    }
}