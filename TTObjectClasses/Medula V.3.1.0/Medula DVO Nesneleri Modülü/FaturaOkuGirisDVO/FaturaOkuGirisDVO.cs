
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
    public  partial class FaturaOkuGirisDVO : BaseMedulaObject
    {
    /// <summary>
    /// Fatura Tarihi
    /// </summary>
        public DateTime? faturaTarihiDateTime
        {
            get
            {
                try
                {
#region faturaTarihiDateTime_GetScript                    
                    if (string.IsNullOrEmpty(faturaTarihi) == false && Globals.IsDate(faturaTarihi))
                    return Convert.ToDateTime(faturaTarihi);
                else
                    return null;
#endregion faturaTarihiDateTime_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "faturaTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region faturaTarihiDateTime_SetScript                    
                    if (value.HasValue)
                    faturaTarihi = value.Value.ToShortDateString();
                else
                    faturaTarihi = null;
#endregion faturaTarihiDateTime_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "faturaTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
        }

    }
}