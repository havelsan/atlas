
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
    public  partial class IlacRaporDuzeltDVO : BaseMedulaRaporObject
    {
    /// <summary>
    /// Düzeltmenin Yapıldığı Tarih
    /// </summary>
        public DateTime? duzeltmeTarihiDateTime
        {
            get
            {
                try
                {
#region duzeltmeTarihiDateTime_GetScript                    
                    if (string.IsNullOrEmpty(duzeltmeTarihi) == false && Globals.IsDate(duzeltmeTarihi))
                    return Convert.ToDateTime(duzeltmeTarihi);
                else
                    return null;
#endregion duzeltmeTarihiDateTime_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "duzeltmeTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region duzeltmeTarihiDateTime_SetScript                    
                    if (value.HasValue)
                    duzeltmeTarihi = value.Value.ToShortDateString();
                else
                    duzeltmeTarihi = null;
#endregion duzeltmeTarihiDateTime_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "duzeltmeTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
        }

    /// <summary>
    /// Rapor Tarihi
    /// </summary>
        public DateTime? raporTarihiDateTime
        {
            get
            {
                try
                {
#region raporTarihiDateTime_GetScript                    
                    if (string.IsNullOrEmpty(raporTarihi) == false && Globals.IsDate(raporTarihi))
                    return Convert.ToDateTime(raporTarihi);
                else
                    return null;
#endregion raporTarihiDateTime_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "raporTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region raporTarihiDateTime_SetScript                    
                    if (value.HasValue)
                    raporTarihi = value.Value.ToShortDateString();
                else
                    raporTarihi = null;
#endregion raporTarihiDateTime_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "raporTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
        }

    }
}