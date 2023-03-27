
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
    public  partial class RaporOkuDVO : BaseMedulaObject
    {
    /// <summary>
    /// Rapor Tarihi
    /// </summary>
        public DateTime? tarihDateTime
        {
            get
            {
                try
                {
#region tarihDateTime_GetScript                    
                    if (string.IsNullOrEmpty(tarih) == false && Globals.IsDate(tarih))
                    return Convert.ToDateTime(tarih);
                else
                    return null;
#endregion tarihDateTime_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "tarihDateTime") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region tarihDateTime_SetScript                    
                    if (value.HasValue)
                    tarih = value.Value.ToShortDateString();
                else
                    tarih = null;
#endregion tarihDateTime_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "tarihDateTime") + " : " + ex.Message, ex);
                }
            }
        }

    }
}