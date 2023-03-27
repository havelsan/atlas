
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
    public  partial class Ultra6 //: TTObject, TTInterfaces.I_Ultra6
    {
        public RiskEnum? AAA
        {
            get
            {
                try
                {
                    #region AAA_GetScript                    
                    return null;
#endregion AAA_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "AAA") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region AAA_SetScript                    
                    
#endregion AAA_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "AAA") + " : " + ex.Message, ex);
                }
            }
        }

    }
}