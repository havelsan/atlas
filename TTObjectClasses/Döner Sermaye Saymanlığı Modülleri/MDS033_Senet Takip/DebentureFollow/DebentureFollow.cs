
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
    /// Senet Takip İşlemi
    /// </summary>
    public  partial class DebentureFollow : AccountAction, IWorkListBaseAction
    {
        public partial class DebentureFollowPaymentOrderReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class DebentureFollowExecutionReportQuery_Class : TTReportNqlObject 
        {
        }

        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            foreach(DebentureFollowPaymentOrderList dPayList in PaymentOrderList)
            {
                if (dPayList.Reported == true)
                {
                    Debenture debenture ;
                    debenture = dPayList.Debenture ;
                    debenture.CurrentStateDefID = Debenture.States.PaymentOder;
                    debenture.PaymentOrderDate = dPayList.PaymentOrderDate;
                    
                    int executionPeriod = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("EXECUTIONORDERPERIOD","20"));
                    DateTime paymentOrderDate = (DateTime)debenture.PaymentOrderDate;
                    debenture.ExecutionDate = paymentOrderDate.Date.AddDays(executionPeriod);
                }
            }
            foreach(DebentureFollowExecutionList eList in ExecutionList)
            {
                if(eList.Reported == true)
                {
                    Debenture debenture;
                    debenture = eList.Debenture ;
                    debenture.CurrentStateDefID = Debenture.States.ExecutionOrder;
                    debenture.ExecutionDate = eList.ExecutionDate ;
                }
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
            Cancel();
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
        public override void Cancel()
        {
            base.Cancel();
            foreach(DebentureFollowPaymentOrderList dPayList in PaymentOrderList)
            {
                if (dPayList.Reported == true)
                {
                    Debenture debenture ;
                    debenture = dPayList.Debenture ;
                    debenture.CurrentStateDefID = Debenture.States.New ;
                    int paymentOrderPeriod = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("PAYMENTORDERPERIOD","20"));
                    DateTime dueDate = (DateTime)debenture.DueDate;
                    debenture.PaymentOrderDate = dueDate.Date.AddDays(paymentOrderPeriod);
                    int executionPeriod = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("EXECUTIONORDERPERIOD","20"));
                    DateTime paymentOrderDate = (DateTime)debenture.PaymentOrderDate;
                    debenture.ExecutionDate = paymentOrderDate.Date.AddDays(executionPeriod);
                }
            }
            foreach(DebentureFollowExecutionList eList in ExecutionList)
            {
                if(eList.Reported == true)
                {
                    Debenture debenture;
                    debenture = eList.Debenture ;
                    debenture.CurrentStateDefID = Debenture.States.PaymentOder;
                    int executionPeriod = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("EXECUTIONORDERPERIOD","20"));
                    DateTime paymentOrderDate = (DateTime)debenture.PaymentOrderDate;
                    debenture.ExecutionDate = paymentOrderDate.Date.AddDays(executionPeriod);
                }
            }
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DebentureFollow).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DebentureFollow.States.New && toState == DebentureFollow.States.Completed)
                PostTransition_New2Completed();
            else if (fromState == DebentureFollow.States.Completed && toState == DebentureFollow.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DebentureFollow).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DebentureFollow.States.New && toState == DebentureFollow.States.Completed)
                UndoTransition_New2Completed(transDef);
            else if (fromState == DebentureFollow.States.Completed && toState == DebentureFollow.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
        }

    }
}