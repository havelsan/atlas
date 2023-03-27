
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
    public  partial class ImportTestClass : ImportTestClassBase, ImportTestInterface
    {
        public partial class ImportTestReportQuery_Class : TTReportNqlObject 
        {
        }

        #region ImportTestInterface Members
        public string GetDescription()
        {
            return Description;
        }
        public void SetDescription(string value)
        {
            Description = value;
        }
        #endregion

        public int? DenemeCoded
        {
            get
            {
                try
                {
#region DenemeCoded_GetScript                    
                    return (int?)this["DenemeCoded"];
#endregion DenemeCoded_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "DenemeCoded") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region DenemeCoded_SetScript                    
                    this["DenemeCoded"] = value;
#endregion DenemeCoded_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "DenemeCoded") + " : " + ex.Message, ex);
                }
            }
        }

    }
}