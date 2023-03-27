
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
    /// Sağlık Kurulu Karar Tanımı
    /// </summary>
    public  partial class HealthCommitteeDecisionDefinition : TerminologyManagerDef
    {
        public partial class OLAP_GetHCDecisionDef_Class : TTReportNqlObject 
        {
        }

        public partial class GetHCDecisionDefinitions_Class : TTReportNqlObject 
        {
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            
            if(ShowOnlyAddDecisionOnReports == true && RequiresAdditionalDecision != true)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26758", "Raporlarda Sadece İlave Karar Görünür işaretli ise İlave Karar Gerektirir de işaretlenmelidir."));

#endregion PreInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            base.PreUpdate();
            
            if(ShowOnlyAddDecisionOnReports == true && RequiresAdditionalDecision != true)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26758", "Raporlarda Sadece İlave Karar Görünür işaretli ise İlave Karar Gerektirir de işaretlenmelidir."));

#endregion PreUpdate
        }

    }
}