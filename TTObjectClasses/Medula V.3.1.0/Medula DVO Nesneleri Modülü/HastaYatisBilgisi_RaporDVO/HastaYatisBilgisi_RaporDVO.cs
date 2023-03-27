
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
    public  partial class HastaYatisBilgisi_RaporDVO : BaseMedulaObject
    {
    /// <summary>
    /// XXXXXXden Çıkış Tarihi
    /// </summary>
        public DateTime? cikisTarihiDateTime
        {
            get
            {
                try
                {
#region cikisTarihiDateTime_GetScript                    
                    if (string.IsNullOrEmpty(cikisTarihi) == false && Globals.IsDate(cikisTarihi))
                    return Convert.ToDateTime(cikisTarihi);
                else
                    return null;
#endregion cikisTarihiDateTime_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "cikisTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region cikisTarihiDateTime_SetScript                    
                    if (value.HasValue)
                    cikisTarihi = value.Value.ToShortDateString();
                else
                    cikisTarihi = null;
#endregion cikisTarihiDateTime_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "cikisTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
        }

    /// <summary>
    /// XXXXXX Yatış Tarihi
    /// </summary>
        public DateTime? yatisTarihiDateTime
        {
            get
            {
                try
                {
#region yatisTarihiDateTime_GetScript                    
                    if (string.IsNullOrEmpty(yatisTarihi) == false && Globals.IsDate(yatisTarihi))
                    return Convert.ToDateTime(yatisTarihi);
                else
                    return null;
#endregion yatisTarihiDateTime_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "yatisTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region yatisTarihiDateTime_SetScript                    
                    if (value.HasValue)
                    yatisTarihi = value.Value.ToShortDateString();
                else
                    yatisTarihi = null;
#endregion yatisTarihiDateTime_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "yatisTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
        }

    }
}