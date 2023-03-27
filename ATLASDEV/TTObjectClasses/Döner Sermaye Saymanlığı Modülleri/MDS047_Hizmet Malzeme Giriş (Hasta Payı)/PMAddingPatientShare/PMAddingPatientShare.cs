
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
    /// Hizmet Malzeme Giriş (Hasta Payı)
    /// </summary>
    public  partial class PMAddingPatientShare : EpisodeAction
    {
        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            
            AccountTransaction deleteAccTrx;
            
            foreach(PMAddingPSProcedure psProcedure in PMAddingPSProcedures)
            {
                psProcedure.CurrentStateDefID = PMAddingPSProcedure.States.Completed;
                psProcedure.AccountOperation(AccountOperationTimeEnum.PREPOST);
                deleteAccTrx = null;
                // Kurum payı oluşan AccountTransaction varsa silinir edilir veya hasta payına çevrilir
                int accTrxCount = psProcedure.AccountTransactions.Count;
                foreach(AccountTransaction accTrx in psProcedure.AccountTransactions)
                {
                    if(accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                    {
                        if(accTrxCount == 1)
                            accTrx.TurnToPatientShare();
                        else if(accTrxCount > 1)
                            deleteAccTrx = accTrx;
                    }
                }
                
                if(deleteAccTrx != null)
                    ((ITTObject)deleteAccTrx).Delete();
            }
            
            foreach(PMAddingPSMaterial psMaterial in PMAddingPSMaterials)
            {
                psMaterial.CurrentStateDefID = PMAddingPSMaterial.States.Completed;
                psMaterial.AccountOperation(AccountOperationTimeEnum.PREPOST);
                deleteAccTrx = null;
                // Kurum payı oluşan AccountTransaction varsa iptal edilir veya hasta payına çevrilir
                int accTrxCount = psMaterial.AccountTransactions.Count;
                foreach(AccountTransaction accTrx in psMaterial.AccountTransactions)
                {
                    if(accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                    {
                        if(accTrxCount == 1)
                            accTrx.TurnToPatientShare();
                        else if(accTrxCount > 1)
                            deleteAccTrx = accTrx;
                    }
                }
                
                if(deleteAccTrx != null)
                    ((ITTObject)deleteAccTrx).Delete();
            }

#endregion PostTransition_New2Completed
        }

        protected void UndoTransition_New2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Completed
#region UndoTransition_New2Completed
            
            NoBackStateBack();

#endregion UndoTransition_New2Completed
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PostTransition_Completed2Cancelled
            
            base.Cancel();

#endregion PostTransition_Completed2Cancelled
        }

        protected void UndoTransition_Completed2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Completed   To State : Cancelled
#region UndoTransition_Completed2Cancelled
            
            NoBackStateBack();

#endregion UndoTransition_Completed2Cancelled
        }

#region Methods
        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.EpisodeAccountAction;
            }
        }
        
        public override void Cancel()
        {
            NoCancel();
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PMAddingPatientShare).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PMAddingPatientShare.States.New && toState == PMAddingPatientShare.States.Completed)
                PostTransition_New2Completed();
            else if (fromState == PMAddingPatientShare.States.Completed && toState == PMAddingPatientShare.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PMAddingPatientShare).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PMAddingPatientShare.States.New && toState == PMAddingPatientShare.States.Completed)
                UndoTransition_New2Completed(transDef);
            else if (fromState == PMAddingPatientShare.States.Completed && toState == PMAddingPatientShare.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
        }

    }
}