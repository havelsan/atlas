
//using System;
//using System.Xml;
//using System.Data;
//using System.Text;
//using System.Drawing;
//using System.Reflection;
//using System.Collections;
//using System.Linq;
//using System.ComponentModel;
//using System.Collections.Generic;
//using System.Runtime.Serialization;
//using System.Collections.ObjectModel;
//using System.Runtime.InteropServices;

//using TTUtils;
//using TTObjectClasses;
//using TTDataDictionary;
//using TTCoreDefinitions;
//using TTConnectionManager;
//using TTInstanceManagement;
//using TTDefinitionManagement;
//using TTStorageManager.Security;

//using SmartCardWrapper;

//using TTStorageManager;
//using System.Runtime.Versioning;


//namespace TTObjectClasses
//{
//    /// <summary>
//    /// Kurum Avans Tahsilat
//    /// </summary>
//    public  partial class PayerAdvancePayment : AccountAction, IWorkListBaseAction, TTInterfaces.I_PayerAdvancePayment
//    {
//        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
//        override protected void RunSetMemberValueScript(string memberName, object newValue)
//        {
//            switch (memberName)
//            {
//                case "PAYERADVANCEPAYMENTDOCUMENT":
//                    {
//                        PayerAdvancePaymentDocument value = (PayerAdvancePaymentDocument)newValue;
//#region PAYERADVANCEPAYMENTDOCUMENT_SetParentScript
//                        value.AccountAction=this;
//#endregion PAYERADVANCEPAYMENTDOCUMENT_SetParentScript
//                    }
//                    break;

//                default:
//                    base.RunSetMemberValueScript(memberName, newValue);
//                    break;

//            }
//        }

//        protected void PostTransition_Paid2Cancelled()
//        {
//            // From State : Paid   To State : Cancelled
//#region PostTransition_Paid2Cancelled
//            this.Cancel();
//#endregion PostTransition_Paid2Cancelled
//        }

//        protected void UndoTransition_Paid2Cancelled(TTObjectStateTransitionDef transitionDef)
//        {
//            // From State : Paid   To State : Cancelled
//#region UndoTransition_Paid2Cancelled
//            this.NoBackStateBack();
//#endregion UndoTransition_Paid2Cancelled
//        }

//        protected void PostTransition_New2Paid()
//        {
//            // From State : New   To State : Paid
//#region PostTransition_New2Paid
//            if (this.PayerAdvancePaymentDocument.ChequePayments.Count == 0 && this.PayerAdvancePaymentDocument.CashPayment.Count == 0 && this.PayerAdvancePaymentDocument.BankDecountPayments.Count == 0)
//                throw new TTException(SystemMessage.GetMessage(114));

//            this.RemainingPrice = this.TotalPrice;
//            this.PayerAdvancePaymentDocument.TotalPrice = this.TotalPrice;

//            PayerAdvancePaymentDocumentGroup docGroup = (PayerAdvancePaymentDocumentGroup)this.PayerAdvancePaymentDocument.AddDocumentGroup("TAHSİLAT","Kurum Avans Ödemeleri");
//            docGroup.AddDocumentDetail("Kurum avans ödemesi", 1, (double)this.TotalPrice);

//            this.Payer.ControlAndCreateAPR();
//            this.PayerAdvancePaymentDocument.AddAPRTransaction((AccountPayableReceivable)this.Payer.MyAPR(), (double)this.TotalPrice, (APRTrxType)APRTrxType.GetByType(this.ObjectContext, 9)[0]);
//            this.PayerAdvancePaymentDocument.CurrentStateDefID = PayerAdvancePaymentDocument.States.Paid;
//            this.PayerAdvancePaymentDocument.SendToAccounting = false;

//            /* Kurum Avans Tahsilat işlemi için muhasebe entegrasyonunda olmaması istendiğinden aşağıdaki kısım kapatıldı.

//            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
//            {
//                IList<AccountDocument.PaymentInfo> PaymentList = new List<AccountDocument.PaymentInfo>();
//                AccountDocument.PaymentInfo PI = null;
//                PI = this.PayerAdvancePaymentDocument.CreatePaymentInfoForAccounting();

//                if (PI != null)
//                {
//                    PaymentList.Add(PI);
//                    this.PayerAdvancePaymentDocument.SendToAccounting = true;
//                }

//                if (PaymentList.Count > 0)
//                {
//                    TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "Invoice.Integration", "InvoiceUtils", "CreatePayment", PaymentList);
//                    //TTMessageFactory.SyncCall(Sites.SiteLocalHost, "Invoice.Integration", "InvoiceUtils", "CreatePayment", PaymentList);
//                }
//            }
//             */
//#endregion PostTransition_New2Paid
//        }

//        protected void UndoTransition_New2Paid(TTObjectStateTransitionDef transitionDef)
//        {
//            // From State : New   To State : Paid
//#region UndoTransition_New2Paid
//            this.NoBackStateBack();
//#endregion UndoTransition_New2Paid
//        }

//#region Methods
//        public override void Cancel()
//        {
//            if (this.RemainingPrice < this.TotalPrice)
//            {
//                string msg = "";

//                foreach (PayerPaymentAdvanceList ppAL in this.PayerPaymentAdvanceList)
//                {
//                    if (ppAL.Used == true && ppAL.InvoicePayment.CurrentStateDefID == InvoicePayment.States.Paid)
//                    {
//                        msg = msg + ppAL.InvoicePayment.ActionDate + "\n";
//                    }
//                }
//                throw new TTException(SystemMessage.GetMessage(463, new string[] { msg }));
//            }
//            else
//            {
//                base.Cancel();
//                this.PayerAdvancePaymentDocument.Cancel();
//            }
//        }

//#endregion Methods

//        protected void PostTransition(TTObjectStateTransitionDef transDef)
//        {
//            if (transDef.ObjectDef.CodeName != typeof(PayerAdvancePayment).Name)
//                return;

//            var fromState = transDef.FromStateDefID;
//            var toState = transDef.ToStateDefID;

//            if (fromState == States.Paid && toState == States.Cancelled)
//                PostTransition_Paid2Cancelled();
//            else if (fromState == States.New && toState == States.Paid)
//                PostTransition_New2Paid();
//        }

//        protected void UndoTransition(TTObjectStateTransitionDef transDef)
//        {
//            if (transDef.ObjectDef.CodeName != typeof(PayerAdvancePayment).Name)
//                return;

//            var fromState = transDef.FromStateDefID;
//            var toState = transDef.ToStateDefID;

//            if (fromState == States.Paid && toState == States.Cancelled)
//                UndoTransition_Paid2Cancelled(transDef);
//            else if (fromState == States.New && toState == States.Paid)
//                UndoTransition_New2Paid(transDef);
//        }

//    }
//}