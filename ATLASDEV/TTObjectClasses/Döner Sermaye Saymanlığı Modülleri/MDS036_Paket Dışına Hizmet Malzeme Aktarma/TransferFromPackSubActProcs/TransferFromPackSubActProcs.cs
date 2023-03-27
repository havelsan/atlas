
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
    /// Paket Dışına Hizmet/Malzeme Aktarma Hizmet Detayı
    /// </summary>
    public  partial class TransferFromPackSubActProcs : TTObject
    {
    /// <summary>
    /// Hizmet Kodu
    /// </summary>
        public string ProcedureCode
        {
            get
            {
                try
                {
#region ProcedureCode_GetScript                    
                    if(SubActionProcedure != null)
                {
                    if(SubActionProcedure.ProcedureObject != null)
                        return SubActionProcedure.ProcedureObject.Code;
                }

                return null;
#endregion ProcedureCode_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "ProcedureCode") + " : " + ex.Message, ex);
                }
            }
        }

    /// <summary>
    /// Hizmet Adı
    /// </summary>
        public string ProcedureName
        {
            get
            {
                try
                {
#region ProcedureName_GetScript                    
                    if(SubActionProcedure != null)
                {
                    if(SubActionProcedure.ProcedureObject != null)
                        return SubActionProcedure.ProcedureObject.Name;
                }

                return null;
#endregion ProcedureName_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "ProcedureName") + " : " + ex.Message, ex);
                }
            }
        }

    /// <summary>
    /// İşlem Tarih
    /// </summary>
        public DateTime? PricingDate
        {
            get
            {
                try
                {
#region PricingDate_GetScript                    
                    if (SubActionProcedure != null)
                    return SubActionProcedure.PricingDate;

                return null;
#endregion PricingDate_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "PricingDate") + " : " + ex.Message, ex);
                }
            }
        }

    }
}