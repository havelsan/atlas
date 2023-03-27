
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
    public  partial class TeshisBilgisiDVO : BaseMedulaObject
    {
    /// <summary>
    /// Rapor Bitiş Tarihi
    /// </summary>
        public DateTime? bitisTarihiDateTime
        {
            get
            {
                try
                {
#region bitisTarihiDateTime_GetScript                    
                    if (string.IsNullOrEmpty(bitisTarihi) == false && Globals.IsDate(bitisTarihi))
                    return Convert.ToDateTime(bitisTarihi);
                else
                    return null;
#endregion bitisTarihiDateTime_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "bitisTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region bitisTarihiDateTime_SetScript                    
                    if (value.HasValue)
                    bitisTarihi = value.Value.ToShortDateString();
                else
                    bitisTarihi = null;
#endregion bitisTarihiDateTime_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "bitisTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
        }

    /// <summary>
    /// Rapor Başlangıç Tarihi
    /// </summary>
        public DateTime? baslangicTarihiDateTime
        {
            get
            {
                try
                {
#region baslangicTarihiDateTime_GetScript                    
                    if (string.IsNullOrEmpty(baslangicTarihi) == false && Globals.IsDate(baslangicTarihi))
                    return Convert.ToDateTime(baslangicTarihi);
                else
                    return null;
#endregion baslangicTarihiDateTime_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "baslangicTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region baslangicTarihiDateTime_SetScript                    
                    if (value.HasValue)
                    baslangicTarihi = value.Value.ToShortDateString();
                else
                    baslangicTarihi = null;
#endregion baslangicTarihiDateTime_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "baslangicTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
        }

    }
}