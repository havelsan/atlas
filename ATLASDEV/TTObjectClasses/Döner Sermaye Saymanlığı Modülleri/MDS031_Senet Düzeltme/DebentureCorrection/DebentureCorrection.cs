
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
    /// Senet Düzeltme İşlemi
    /// </summary>
    public  partial class DebentureCorrection : EpisodeAccountAction, IWorkListEpisodeAction
    {
        public partial class GetNewDebentures_Class : TTReportNqlObject 
        {
        }

        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            Debenture myDebenture = null ;
            AccountDocument  myAccDoc = null ;
            
            foreach (DebentureCorrectionCancellableDebentures cancelList in CancellableDebentures)
                
            {
                if (cancelList.Cancelled == true )
                {
                    myDebenture = (Debenture)Debenture.GetByObjectID(ObjectContext,cancelList.DebentureObjectID.ToString())[0];
                    myDebenture.CurrentStateDefID = Debenture.States.Cancelled ;
                }
            }
            if (CancelledDebDocObjectId == null)
                throw new TTException(SystemMessage.GetMessage(377));
            
            myAccDoc  = (AccountDocument)AccountDocument.GetByObjectID(ObjectContext,CancelledDebDocObjectId.ToString())[0];
            
            foreach (Debenture db in Debentures)
            {
                Debenture debenture ;
                debenture = db;
                debenture.AccountDocument = myAccDoc ;
                
                int paymentOrderPeriod = Convert.ToInt16(SystemParameter.GetParameterValue("PAYMENTORDERPERIOD","20"));
                DateTime dueDate = (DateTime)debenture.DueDate;
                debenture.PaymentOrderDate = dueDate.Date.AddDays(paymentOrderPeriod);

                int executionPeriod = Convert.ToInt16(SystemParameter.GetParameterValue("EXECUTIONORDERPERIOD","20"));
                DateTime paymentOrderDate = (DateTime)debenture.PaymentOrderDate;
                debenture.ExecutionDate = paymentOrderDate.Date.AddDays(executionPeriod);
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

#region Methods
        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.EpisodeAccountAction;
            }
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DebentureCorrection).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DebentureCorrection.States.New && toState == DebentureCorrection.States.Completed)
                PostTransition_New2Completed();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DebentureCorrection).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DebentureCorrection.States.New && toState == DebentureCorrection.States.Completed)
                UndoTransition_New2Completed(transDef);
        }

    }
}