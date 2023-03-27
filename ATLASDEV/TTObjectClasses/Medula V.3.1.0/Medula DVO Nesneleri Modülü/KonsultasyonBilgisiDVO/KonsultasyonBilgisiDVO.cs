
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
    public  partial class KonsultasyonBilgisiDVO : BaseHizmetKayitDVO
    {
    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? islemTarihiDateTime
        {
            get
            {
                try
                {
#region islemTarihiDateTime_GetScript                    
                    if (string.IsNullOrEmpty(islemTarihi) == false && Globals.IsDate(islemTarihi))
                        return Convert.ToDateTime(islemTarihi);
                    else
                        return null;
#endregion islemTarihiDateTime_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "islemTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region islemTarihiDateTime_SetScript                    
                    if (value.HasValue)
                        islemTarihi = value.Value.ToShortDateString();
                    else
                        islemTarihi = null;
#endregion islemTarihiDateTime_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "islemTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "HIZMETKAYITGIRISDVO":
                    {
                        HizmetKayitGirisDVO value = (HizmetKayitGirisDVO)newValue;
#region HIZMETKAYITGIRISDVO_SetParentScript
                        if (value != null)
                            CreateHizmetSunucuRefNo();
#endregion HIZMETKAYITGIRISDVO_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();

            if (((ITTObject)this).IsNew && islemTarihiDateTime == null)
                islemTarihiDateTime = TTObjectDefManager.ServerTime;
        }
        
#endregion Methods

    }
}