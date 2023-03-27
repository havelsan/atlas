
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
    /// Muhasebe Yetkilisi Mutemedi Tahsilat İşlemi
    /// </summary>
    public  partial class SubCashOfficeOperation : AccountAction, IWorkListBaseAction
    {
        public partial class ReceiptReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class ReceiptCreditCardReportQuery_Class : TTReportNqlObject 
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "SUBCASHOFFICERECEIPTDOCUMENT":
                    {
                        SubCashOfficeReceiptDoc value = (SubCashOfficeReceiptDoc)newValue;
#region SUBCASHOFFICERECEIPTDOCUMENT_SetParentScript
                        value.AccountAction=this;
#endregion SUBCASHOFFICERECEIPTDOCUMENT_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            if (SubCashOfficeReceiptDocument.CashPayment.Count == 0 && SubCashOfficeReceiptDocument.CreditCardPayments.Count == 0)
                throw new TTException(SystemMessage.GetMessage(114));
            
            SubCashOfficeReceiptDocGroup rdg = (SubCashOfficeReceiptDocGroup)SubCashOfficeReceiptDocument.AddDocumentGroup("T",TTUtils.CultureService.GetText("M26548", "Muhasebe Yetkilisi Mutemedi Tahsilat"));
            rdg.AddDocumentDetail(Description, 1, (double)TotalPrice);
            rdg.AccountDocumentDetails[0].CurrentStateDefID = SubCashOfficeReceiptDocDet.States.Paid;
            
            SubCashOfficeReceiptDocument.CurrentStateDefID = SubCashOfficeReceiptDoc.States.Paid;
            SubCashOfficeReceiptDocument.SendToAccounting = false;
            
            ReceiptCashOfficeDefinition myReceiptCashOffice = (ReceiptCashOfficeDefinition)ReceiptCashOfficeDefinition.GetByCashOffice(ObjectContext, SubCashOfficeReceiptDocument.CashierLog.CashOffice.ObjectID.ToString())[0];
            if (SubCashOfficeReceiptDocument.CashPayment.Count > 0)
            {
                SubCashOfficeReceiptDocument.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(myReceiptCashOffice);
                ReceiptCashOfficeDefinition.SetNextReceiptNumber(myReceiptCashOffice);
                SubCashOfficeReceiptDocument.SpecialNo.GetNextValue(SubCashOfficeReceiptDocument.CashierLog.ResUser.ID.ToString(), Common.RecTime().Year);
            }
            
            if (SubCashOfficeReceiptDocument.CreditCardPayments.Count > 0)
            {
                SubCashOfficeReceiptDocument.CreditCardDocumentNo = ReceiptCashOfficeDefinition.GetCurrentCreditCardReceiptNumber(myReceiptCashOffice);
                ReceiptCashOfficeDefinition.SetNextCreditCardReceiptNumber(myReceiptCashOffice);
                SubCashOfficeReceiptDocument.CreditCardSpecialNo.GetNextValue(SubCashOfficeReceiptDocument.CashierLog.ResUser.ID.ToString(), Common.RecTime().Year);
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
            
            CashierLog myCashierLog = SubCashOfficeReceiptDocument.CashierLog;
            if (myCashierLog == null)
                throw new TTException(SystemMessage.GetMessage(108));
            else
            {
                if (myCashierLog.ClosingDate != null)
                    throw new TTException(SystemMessage.GetMessage(110));
                else
                {
                    ResUser currentResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;

                    if (myCashierLog.ResUser.ObjectID == currentResUser.ObjectID)
                        SubCashOfficeReceiptDocument.Cancel();
                    else
                        throw new TTException(SystemMessage.GetMessageV3(113, new string[] { TTUtils.CultureService.GetText("M26546", "Muhasebe Yetkilisi Mutemedi Alındısı")}));
                }
            }
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SubCashOfficeOperation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == SubCashOfficeOperation.States.New && toState == SubCashOfficeOperation.States.Completed)
                PostTransition_New2Completed();
            else if (fromState == SubCashOfficeOperation.States.Completed && toState == SubCashOfficeOperation.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SubCashOfficeOperation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == SubCashOfficeOperation.States.New && toState == SubCashOfficeOperation.States.Completed)
                UndoTransition_New2Completed(transDef);
            else if (fromState == SubCashOfficeOperation.States.Completed && toState == SubCashOfficeOperation.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
        }

    }
}