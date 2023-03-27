
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
    /// Reçete Dağıtım Dönem Açma
    /// </summary>
    public  partial class DistributionTermAction : BaseAction
    {
        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PreTransition_New2Completed
            
            
            
            if (((DateTime)StartDate).Date == Common.RecTime().Date)
            {
                if (CloseTerm != null)
                {
                    CloseTerm.Status = AccountingTermStatusEnum.Close;
                }
                ExternalPharmacyDistributionTerm distributionTerm = new ExternalPharmacyDistributionTerm(ObjectContext);
                distributionTerm.StartDate = StartDate;
                distributionTerm.EndDate = EndDate;
                distributionTerm.Status = AccountingTermStatusEnum.Open;
            }
            else
            {
                throw new TTException (SystemMessage.GetMessage(1017));
            }

#endregion PreTransition_New2Completed
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DistributionTermAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DistributionTermAction.States.New && toState == DistributionTermAction.States.Completed)
                PreTransition_New2Completed();
        }

    }
}