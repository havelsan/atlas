
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
    /// Düşme Riski
    /// </summary>
    public  partial class BaseNursingFallingDownRisk : BaseNursingDataEntry
    {
        public override string GetApplicationSummary()
        {
            string tempString = String.Empty;

            if (TotalScore != null)
                tempString += " Toplam Skor: " + TotalScore;

            if (FallingDownRiskReason.HasValue)
                tempString += " Risk Nedeni: " + Common.GetEnumValueDefOfEnumValue(FallingDownRiskReason.Value) + " , ";

            tempString += " Seçilen Değerler: ";

            foreach (var nursingFallingDownRisk in NursingFallingDownRisks)
            {
                if (nursingFallingDownRisk.RiskFactor != null)
                    tempString += nursingFallingDownRisk.RiskFactor.Name + ", ";
            }

            return tempString;
        }
    }
}