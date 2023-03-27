
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
    public  partial class MuayeneBilgisiDVO : BaseHizmetKayitDVO
    {
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

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();

            if (((ITTObject)this).IsNew && muayeneTarihiDateTime == null)
                muayeneTarihiDateTime = TTObjectDefManager.ServerTime;
        }
        
#endregion Methods

    }
}