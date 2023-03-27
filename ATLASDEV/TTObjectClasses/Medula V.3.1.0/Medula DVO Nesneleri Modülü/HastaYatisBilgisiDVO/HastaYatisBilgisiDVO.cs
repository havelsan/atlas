
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
    public  partial class HastaYatisBilgisiDVO : BaseHizmetKayitDVO
    {
    /// <summary>
    /// Yatış Bitiş Tarihi
    /// </summary>
        public DateTime? yatisBitisTarihiDateTime
        {
            get
            {
                try
                {
#region yatisBitisTarihiDateTime_GetScript                    
                    if (string.IsNullOrEmpty(yatisBitisTarihi) == false && Globals.IsDate(yatisBitisTarihi))
                        return Convert.ToDateTime(yatisBitisTarihi);
                    else
                        return null;
#endregion yatisBitisTarihiDateTime_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "yatisBitisTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region yatisBitisTarihiDateTime_SetScript                    
                    if (value.HasValue)
                        yatisBitisTarihi = value.Value.ToShortDateString();
                    else
                        yatisBitisTarihi = null;
#endregion yatisBitisTarihiDateTime_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "yatisBitisTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
        }

        public DateTime? yatisBaslangicTarihiDateTime
        {
            get
            {
                try
                {
#region yatisBaslangicTarihiDateTime_GetScript                    
                    if (string.IsNullOrEmpty(yatisBaslangicTarihi) == false && Globals.IsDate(yatisBaslangicTarihi))
                        return Convert.ToDateTime(yatisBaslangicTarihi);
                    else
                        return null;
#endregion yatisBaslangicTarihiDateTime_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "yatisBaslangicTarihiDateTime") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region yatisBaslangicTarihiDateTime_SetScript                    
                    if (value.HasValue)
                        yatisBaslangicTarihi = value.Value.ToShortDateString();
                    else
                        yatisBaslangicTarihi = null;
#endregion yatisBaslangicTarihiDateTime_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "yatisBaslangicTarihiDateTime") + " : " + ex.Message, ex);
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

            if (((ITTObject)this).IsNew)
            {
                if (yatisBaslangicTarihiDateTime == null)
                    yatisBaslangicTarihiDateTime = TTObjectDefManager.ServerTime;
                if (yatisBitisTarihiDateTime == null)
                    yatisBitisTarihiDateTime = TTObjectDefManager.ServerTime;
            }
        }
        
#endregion Methods

    }
}