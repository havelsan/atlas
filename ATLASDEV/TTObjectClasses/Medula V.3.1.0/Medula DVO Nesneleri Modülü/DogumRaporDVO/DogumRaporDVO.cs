
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
    public  partial class DogumRaporDVO : BaseMedulaObject
    {
    /// <summary>
    /// Bebek Doğum Tarihi
    /// </summary>
        public DateTime? bebekDogumTarihiDateTime
        {
            get
            {
                try
                {
#region bebekDogumTarihiDateTime_GetScript                    
                    if (string.IsNullOrEmpty(bebekDogumTarihi) == false && Globals.IsDate(bebekDogumTarihi))
                        return Convert.ToDateTime(bebekDogumTarihi);
                    else
                        return null;
#endregion bebekDogumTarihiDateTime_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "bebekDogumTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region bebekDogumTarihiDateTime_SetScript                    
                    if (value.HasValue)
                        bebekDogumTarihi = value.Value.ToShortDateString();
                    else
                        bebekDogumTarihi = null;
#endregion bebekDogumTarihiDateTime_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "bebekDogumTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
        }

    }
}