
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
    public  partial class MuayeneGirisCevapDVO : BaseMedulaCevap
    {
    /// <summary>
    /// Sonuç Mesajı
    /// </summary>
        public string sonucMesaj
        {
            get
            {
                try
                {
#region sonucMesaj_GetScript                    
                    return sonucMesaji;
#endregion sonucMesaj_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "sonucMesaj") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region sonucMesaj_SetScript                    
                    sonucMesaji = value;
#endregion sonucMesaj_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "sonucMesaj") + " : " + ex.Message, ex);
                }
            }
        }

    }
}