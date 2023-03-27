
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
    /// Aylık Miktar Kuralı
    /// </summary>
    public  partial class MonthlyAmountRule : AmountRuleBase
    {
        public partial class GetMonthlyAmountRuleDefinitionQuery_Class : TTReportNqlObject 
        {
        }

#region Methods
        public override List<RuleBase.RuleResult> RunRule(DateTime actionDate, ISUTInstance currentInstance)
        {
            List<RuleBase.RuleResult> retvalue = base.RunRule(actionDate, currentInstance);

            DateTime startDate;
            DateTime endDate;
            GetSuitableDates(actionDate, out startDate, out endDate);

            if (currentInstance.GetSUTRulableObject() is ISUTRulableMaterial)
            {
                ISUTMaterialTotalAmount materialTotalAmount = currentInstance.GetSUTEpisodeAction().SUTEpisode.SUTPatient.SUTMaterialTotalAmount(currentInstance.GetSUTEpisodeAction(), currentInstance.GetSUTRulableObject().GetObjectID(), startDate, endDate);
                if (materialTotalAmount.GetTotalAmount() > Amount)
                    retvalue.Add(new RuleBase.RuleResult(currentInstance.GetSUTRulableObject(), this, "Toplam miktar : " + materialTotalAmount.GetTotalAmount().ToString()));
            }
            else if (currentInstance.GetSUTRulableObject() is ISUTRulableProcedure)
            {
                ISUTProcedureTotalAmount procedureTotalAmount = currentInstance.GetSUTEpisodeAction().SUTEpisode.SUTPatient.SUTProcedureTotalAmount(currentInstance.GetSUTEpisodeAction(), currentInstance.GetSUTRulableObject().GetObjectID(), startDate, endDate);
                if (procedureTotalAmount.GetTotalAmount() > Amount)
                    retvalue.Add(new RuleBase.RuleResult(currentInstance.GetSUTRulableObject(), this, "Toplam miktar : " + procedureTotalAmount.GetTotalAmount().ToString()));
            }
            else
            {
                throw new TTException(SystemMessage.GetMessageV2(576,currentInstance.GetSUTRulableObject().ToString())); 
            }
            return retvalue;
        }


        public override List<ISUTInstance> SubactionProcedures(DateTime actionDate, ISUTInstance currentInstance)
        {
            DateTime startDate;
            DateTime endDate;
            GetSuitableDates(actionDate, out startDate, out endDate);

            return currentInstance.GetSUTEpisodeAction().SUTEpisode.SUTPatient.SUTSubactionProcedures(currentInstance.GetSUTRulableObject().GetObjectID(), startDate, endDate);

        }

        private void GetSuitableDates(DateTime actionDate, out DateTime startDate, out DateTime endDate)
        {
            DateTime d = actionDate.AddMonths(-1 * MonthCount.Value);
            startDate = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
            endDate = new DateTime(actionDate.Year, actionDate.Month, actionDate.Day, 23, 59, 59);
        }
        
#endregion Methods

    }
}