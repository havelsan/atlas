
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
    public  partial class BaseHealthCommitteeExamination : EpisodeActionWithDiagnosis
    {
        protected override void PostInsert()
        {
#region PostInsert
            
            base.PostInsert();
            SetHCCommitteeAcceptanceStatus();

#endregion PostInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            
            base.PostUpdate();
            SetHCCommitteeAcceptanceStatus();

#endregion PostUpdate
        }

#region Methods
        // Sağlık Kurulu işleminin Heyet Kabul Durumu güncellenir
        public void SetHCCommitteeAcceptanceStatus()
        {
            //TODO:NECMİYE
            //if(this is HealthCommitteeExamination || this is HealthCommitteeExaminationFromOtherHospitals)
            if(this is HealthCommitteeExaminationFromOtherHospitals)
            {
                HealthCommittee hc = MasterAction as HealthCommittee;
                if(hc != null)
                    hc.SetCommitteeAcceptanceStatus();
            }
        }
        
#endregion Methods

    }
}