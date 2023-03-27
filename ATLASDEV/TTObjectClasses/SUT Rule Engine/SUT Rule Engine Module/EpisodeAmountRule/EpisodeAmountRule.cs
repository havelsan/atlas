
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
    /// Epizotta Miktar Kuralı
    /// </summary>
    public  partial class EpisodeAmountRule : AmountRuleBase
    {
        public partial class GetEpisodeAmountRuleDefinitionQuery_Class : TTReportNqlObject 
        {
        }

#region Methods
        public override List<RuleBase.RuleResult> RunRule(DateTime actionDate, ISUTInstance currentInstance)
        {
            List<RuleBase.RuleResult> retvalue = base.RunRule(actionDate, currentInstance);


            if (currentInstance.GetSUTRulableObject() is ISUTRulableMaterial)
            {
                ISUTMaterialTotalAmount materialTotalAmount = currentInstance.GetSUTEpisodeAction().SUTEpisode.SUTMaterialTotalAmount(currentInstance.GetSUTEpisodeAction(), currentInstance.GetSUTRulableObject().GetObjectID());
                if (materialTotalAmount.GetTotalAmount() > Amount)
                    retvalue.Add(new RuleBase.RuleResult(currentInstance.GetSUTRulableObject(), this, "Toplam miktar : " + materialTotalAmount.GetTotalAmount().ToString()));
            }
            else if (currentInstance.GetSUTRulableObject() is ISUTRulableProcedure)
            {
                ISUTProcedureTotalAmount procedureTotalAmount = currentInstance.GetSUTEpisodeAction().SUTEpisode.SUTProcedureTotalAmount(currentInstance.GetSUTEpisodeAction(), currentInstance.GetSUTRulableObject().GetObjectID());
                if (procedureTotalAmount.GetTotalAmount() > Amount)
                    retvalue.Add(new RuleBase.RuleResult(currentInstance.GetSUTRulableObject(), this, "Toplam miktar : " + procedureTotalAmount.GetTotalAmount().ToString()));
            }
            else
            {
                throw new TTException(SystemMessage.GetMessageV2(576, currentInstance.GetSUTRulableObject().ToString() )); 
            }
            return retvalue;
        }

        public override List<ISUTInstance> SubactionProcedures(DateTime actionDate, ISUTInstance currentInstance)
        {
            return currentInstance.GetSUTEpisodeAction().SUTEpisode.SUTSubactionProcedures(currentInstance.GetSUTRulableObject().GetObjectID());
        }
        
#endregion Methods

    }
}