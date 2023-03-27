
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
    public  partial class HakSahibiBilgisiDVO : BaseMedulaObject
    {
    /// <summary>
    /// Provizyon Tarihi
    /// </summary>
        public DateTime? provizyonTarihiDateTime
        {
            get
            {
                try
                {
#region provizyonTarihiDateTime_GetScript                    
                    if (string.IsNullOrEmpty(provizyonTarihi) == false && Globals.IsDate(provizyonTarihi))
                    return Convert.ToDateTime(provizyonTarihi);
                else
                    return null;
#endregion provizyonTarihiDateTime_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "provizyonTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region provizyonTarihiDateTime_SetScript                    
                    if (value.HasValue)
                    provizyonTarihi = value.Value.ToShortDateString();
                else
                    provizyonTarihi = null;
#endregion provizyonTarihiDateTime_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "provizyonTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            base.PreUpdate();
            
            bool isEmpty = true;
            if(string.IsNullOrEmpty(karneNo) == false && string.IsNullOrEmpty(karneNo.Trim()) == false)
                isEmpty = false;
            
            if(string.IsNullOrEmpty(tckimlikNo) == false && string.IsNullOrEmpty(tckimlikNo.Trim()) == false)
                isEmpty = false;
            
            if(string.IsNullOrEmpty(sosyalGuvenlikNo) == false && string.IsNullOrEmpty(sosyalGuvenlikNo.Trim()) == false)
                isEmpty = false;
            
            if(isEmpty)
            {
                string error = TTUtils.CultureService.GetText("M25798", "Hasta T.C. Kimlik Numarası, Karne No ya da Sosyal Güvenlik Numarası bilgilerinden mutlaka biri dolu olmalıdır!");
                error += "\r\n\r\nT.C. Kimlik Numarası : " + tckimlikNo;
                error += "\r\nKarne No : " + karneNo;
                error += "\r\nSosyal Güvenlik Numarası : " + sosyalGuvenlikNo;
                throw new TTException(error);
            }

#endregion PreUpdate
        }

    }
}