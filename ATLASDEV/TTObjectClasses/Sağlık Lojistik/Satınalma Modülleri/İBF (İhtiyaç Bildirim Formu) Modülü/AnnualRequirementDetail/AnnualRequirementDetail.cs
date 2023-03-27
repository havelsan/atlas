
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
    public  abstract  partial class AnnualRequirementDetail : TTObject
    {
    /// <summary>
    /// Toplam Miktar
    /// </summary>
        public double? TOTALAMOUNT
        {
            get
            {
                try
                {
#region TOTALAMOUNT_GetScript                    
                    return (double?)ClinicStocks + (double?)AccountancyStock;
#endregion TOTALAMOUNT_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "TOTALAMOUNT") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region TOTALAMOUNT_SetScript                    
                    this["TOTALAMOUNT"] = (double?)ClinicStocks + (double?)AccountancyStock;;
#endregion TOTALAMOUNT_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "TOTALAMOUNT") + " : " + ex.Message, ex);
                }
            }
        }

    }
}