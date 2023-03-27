
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
    public  partial class IsgoremezlikRaporEkDVO : BaseMedulaRaporObject
    {
    /// <summary>
    /// Kontrol Tarihi
    /// </summary>
        public DateTime? kontrolTarihiDateTime
        {
            get
            {
                try
                {
#region kontrolTarihiDateTime_GetScript                    
                    if (string.IsNullOrEmpty(kontrolTarihi) == false && Globals.IsDate(kontrolTarihi))
                    return Convert.ToDateTime(kontrolTarihi);
                else
                    return null;
#endregion kontrolTarihiDateTime_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "kontrolTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region kontrolTarihiDateTime_SetScript                    
                    if (value.HasValue)
                    kontrolTarihi = value.Value.ToShortDateString();
                else
                    kontrolTarihi = null;
#endregion kontrolTarihiDateTime_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "kontrolTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
        }

    /// <summary>
    /// Protokol Tarihi
    /// </summary>
        public DateTime? protokolTarihiDateTime
        {
            get
            {
                try
                {
#region protokolTarihiDateTime_GetScript                    
                    if (string.IsNullOrEmpty(protokolTarihi) == false && Globals.IsDate(protokolTarihi))
                    return Convert.ToDateTime(protokolTarihi);
                else
                    return null;
#endregion protokolTarihiDateTime_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "protokolTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region protokolTarihiDateTime_SetScript                    
                    if (value.HasValue)
                    protokolTarihi = value.Value.ToShortDateString();
                else
                    protokolTarihi = null;
#endregion protokolTarihiDateTime_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "protokolTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
        }

    /// <summary>
    /// Bitiş Tarihi
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

    }
}