
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
    /// Halk Sağlığı Tetkik
    /// </summary>
    public  partial class CommunityHealthProcedure : TTObject
    {
        public partial class GetCommunityHealthResultReportNQL_Class : TTReportNqlObject 
        {
        }

    /// <summary>
    /// Meq
    /// </summary>
        public double? Meq
        {
            get
            {
                try
                {
#region Meq_GetScript                    
                    if( ProcedureObject != null && ProcedureObject.Weight != null  && ProcedureObject.StandartValue != null && Result != null)
                {
                    return Result  * ProcedureObject.Weight / ProcedureObject.StandartValue;
                }
                return 0;
#endregion Meq_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "Meq") + " : " + ex.Message, ex);
                }
            }
        }

    /// <summary>
    /// Mval
    /// </summary>
        public double? Mval
        {
            get
            {
                try
                {
#region Mval_GetScript                    
                    return 100 * Meq / Request.ToplamMeq ;
#endregion Mval_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "Mval") + " : " + ex.Message, ex);
                }
            }
        }

    }
}