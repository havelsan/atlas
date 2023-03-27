
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
    /// Sağlık Kurulu Zeyil/Ek Raporları
    /// </summary>
    public  partial class HealthCommitteeAdditionalReport : EpisodeAction, IWorkListHealthCommittee
    {
        public partial class GetHCAdditionalReportByDate_Class : TTReportNqlObject 
        {
        }

        public partial class GetCurrentHCAdditionalReport_Class : TTReportNqlObject 
        {
        }

        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            
            
            HealthCommitteeTypeEnum committeeType;
            if(IsOtherHospitalHC.Value == true)
            {
                committeeType = HCCommitteeType.Value;
            }
            else
            {
                committeeType = HealthCommitteeTypeEnum.NormalCommittee;
                if (HealthCommittee.HCRequestReason.ReasonForExamination != null && HealthCommittee.HCRequestReason.ReasonForExamination.HealthCommitteeType.HasValue)
                    committeeType = HealthCommittee.HCRequestReason.ReasonForExamination.HealthCommitteeType.Value;
            }
            IList<MemberOfHealthCommitteeDefinition> currentDefs = (IList<MemberOfHealthCommitteeDefinition>)MemberOfHealthCommitteeDefinition.GetMemberDefinitions(ObjectContext);
            
            if(currentDefs.Count == 0)
                throw new TTUtils.TTException(SystemMessage.GetMessageV3(483, new string[] { ((System.DateTime)ReportDate).ToShortDateString() , Common.GetEnumValueDefOfEnumValue(committeeType).DisplayText }));
            else
                MemberOfHealthCommittee = currentDefs[0];
            
            if (!ReportNo.Value.HasValue)
            {
                if (ReportType == HCAdditionalReportTypeEnum.AddendumReport)
                    ReportNo.GetNextValue("AddendumReport", Common.RecTime().Year);
                else if (ReportType == HCAdditionalReportTypeEnum.AdditionalReport)
                    ReportNo.GetNextValue("AdditionalReport", Common.RecTime().Year);
            }

#endregion PostTransition_New2Completed
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HealthCommitteeAdditionalReport).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == HealthCommitteeAdditionalReport.States.New && toState == HealthCommitteeAdditionalReport.States.Completed)
                PostTransition_New2Completed();
        }

    }
}