
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
    /// <summary>
    /// Nöbetçi Personel
    /// </summary>
    public  partial class EmergencyWatchDef : TTDefinitionSet
    {
        public partial class GetEmergencyWatchPersonelList_Class : TTReportNqlObject 
        {
        }

        public partial class GetEmergencyWatchDefs_Class : TTReportNqlObject 
        {
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
              if(Tarih != null)
                Tarih = Convert.ToDateTime(((DateTime)Tarih).ToShortDateString() + " " + "00:00:00");

#endregion PreInsert
        }

    }
}