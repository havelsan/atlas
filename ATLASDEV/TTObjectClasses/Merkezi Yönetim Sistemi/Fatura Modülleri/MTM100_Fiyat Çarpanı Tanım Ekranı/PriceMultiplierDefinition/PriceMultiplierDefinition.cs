
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
    /// Fiyat Çarpanı Tanım Ekranı
    /// </summary>
    public  partial class PriceMultiplierDefinition : TerminologyManagerDef
    {
        public partial class GetPriceMultiplierDefinitions_Class : TTReportNqlObject 
        {
        }

    /// <summary>
    /// Çarpan
    /// </summary>
        public double? Multiplier
        {
            get
            {
                try
                {
#region Multiplier_GetScript                    
                    return (double)(NewMultiplier / OldMultiplier);
#endregion Multiplier_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "Multiplier") + " : " + ex.Message, ex);
                }
            }
        }

    }
}