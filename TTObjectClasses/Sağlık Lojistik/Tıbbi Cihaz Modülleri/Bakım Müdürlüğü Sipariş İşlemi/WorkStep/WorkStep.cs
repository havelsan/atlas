
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
    /// Yardımcı Atölye İş İstek
    /// </summary>
    public  partial class WorkStep : CMRAction
    {
        public partial class GetWorkCardByObjectIDReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetWorkCardReportQuery_Class : TTReportNqlObject 
        {
        }

        protected void PostTransition_New2WorkshopApproval()
        {
            // From State : New   To State : WorkshopApproval
#region PostTransition_New2WorkshopApproval
            
            string txtSeq = RequestNoSeq.Value.ToString();
            if (txtSeq.Length == 1)
            {
                txtSeq = "000" + txtSeq.ToString();
            }
            if (txtSeq.Length == 2)
            {
                txtSeq = "00" + txtSeq.ToString();
            }
            if (txtSeq.Length == 3)
            {
                txtSeq = "0" + txtSeq.ToString();
            }
            RequestNo = Common.RecTime().Year.ToString() +"-"+ txtSeq.ToString();

#endregion PostTransition_New2WorkshopApproval
        }

        protected void PreTransition_WorkStepRepair2Completed()
        {
            // From State : WorkStepRepair   To State : Completed
#region PreTransition_WorkStepRepair2Completed
            
            
            
            if(Comment == null )
            {
                throw new TTUtils.TTException(SystemMessage.GetMessage(963));
            }
            if(Workload == null )
            {
                throw new TTUtils.TTException(SystemMessage.GetMessage(964));
            }
            

            foreach (UsedConsumedMaterail usedMaterial in UsedConsumedMaterails)
            {
                if (usedMaterial.SuppliedAmount == usedMaterial.Amount || usedMaterial.SuppliedAmount > usedMaterial.Amount)
                {
                    usedMaterial.CurrentStateDefID = UsedConsumedMaterail.States.Completed;
                }
                else
                {
                   throw new TTUtils.TTException(SystemMessage.GetMessageV2(965, usedMaterial.Material.Name.ToString())); 
                }
            }

#endregion PreTransition_WorkStepRepair2Completed
        }

#region Methods
        override protected void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if(ttObject.IsNew)
            {
                if (RequestNoSeq.Value == null)
                {
                    RequestNoSeq.GetNextValue(ObjectDef.ID.ToString(),Common.RecTime().Year) ;
                    if(RequestNo == null)
                        RequestNo = Common.RecTime().Year.ToString()+ "-" + "####";
                }
            }
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(WorkStep).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == WorkStep.States.WorkStepRepair && toState == WorkStep.States.Completed)
                PreTransition_WorkStepRepair2Completed();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(WorkStep).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == WorkStep.States.New && toState == WorkStep.States.WorkshopApproval)
                PostTransition_New2WorkshopApproval();
        }

    }
}