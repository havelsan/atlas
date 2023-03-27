
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
    public  partial class MuayeneGirisDVO : BaseMedulaObject
    {
        public long? tcKimlikNo
        {
            get
            {
                try
                {
#region tcKimlikNo_GetScript                    
                    long? retValue = null;
                    if (string.IsNullOrEmpty(hastaTCKimlikNo) == false)
                        retValue = Convert.ToInt64(hastaTCKimlikNo);
                    return retValue;
#endregion tcKimlikNo_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "tcKimlikNo") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region tcKimlikNo_SetScript                    
                    if (value.HasValue)
                        hastaTCKimlikNo = value.Value.ToString();
                    else
                        hastaTCKimlikNo = string.Empty;
#endregion tcKimlikNo_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "tcKimlikNo") + " : " + ex.Message, ex);
                }
            }
        }

    /// <summary>
    /// Tesis Kodu
    /// </summary>
        public int? tesisKodu
        {
            get
            {
                try
                {
#region tesisKodu_GetScript                    
                    return saglikTesisKodu.Value;
#endregion tesisKodu_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "tesisKodu") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region tesisKodu_SetScript                    
                    saglikTesisKodu = value;
#endregion tesisKodu_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "tesisKodu") + " : " + ex.Message, ex);
                }
            }
        }

    /// <summary>
    /// Muayene Tarihi
    /// </summary>
        public DateTime? muayeneTarihiDateTime
        {
            get
            {
                try
                {
#region muayeneTarihiDateTime_GetScript                    
                    if (string.IsNullOrEmpty(muayeneTarihi) == false && Globals.IsDate(muayeneTarihi))
                        return Convert.ToDateTime(muayeneTarihi);
                    else
                        return null;
#endregion muayeneTarihiDateTime_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "muayeneTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region muayeneTarihiDateTime_SetScript                    
                    if (value.HasValue)
                        muayeneTarihi = value.Value.ToShortDateString();
                    else
                        muayeneTarihi = null;
#endregion muayeneTarihiDateTime_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "muayeneTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
        }

    /// <summary>
    /// Gizlilik
    /// </summary>
        public string gizli
        {
            get
            {
                try
                {
#region gizli_GetScript                    
                    string retValue = "H";
                    if (gizliTutulsunmu.HasValue)
                        if (gizliTutulsunmu.Value)
                            retValue = "E";

                    return retValue;
#endregion gizli_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", TTUtils.CultureService.GetText("M25729", "gizli")) + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region gizli_SetScript                    
                    bool? setValue = null;
                    if (string.IsNullOrEmpty(value) == false)
                    {
                        if (value.Equals("E"))
                            setValue = true;
                        else
                            setValue = false;
                    }

                    gizliTutulsunmu = setValue;
#endregion gizli_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", TTUtils.CultureService.GetText("M25729", "gizli")) + " : " + ex.Message, ex);
                }
            }
        }

    }
}