
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
    /// Senet Tahsilat
    /// </summary>
    public  partial class DebenturePayment : EpisodeAccountAction, IWorkListEpisodeAction
    {
        public partial class DebPaymentReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class DebPaymentReportDetQuery_Class : TTReportNqlObject 
        {
        }

        public partial class DebPaymentCrCardReportQuery_Class : TTReportNqlObject 
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "DEBENTUREPAYMENTDOCUMENT":
                    {
                        DebenturePaymentDocument value = (DebenturePaymentDocument)newValue;
#region DEBENTUREPAYMENTDOCUMENT_SetParentScript
                        value.EpisodeAccountAction=this;
#endregion DEBENTUREPAYMENTDOCUMENT_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected void PostTransition_Paid2Cancelled()
        {
            // From State : Paid   To State : Cancelled
#region PostTransition_Paid2Cancelled
            Cancel();
#endregion PostTransition_Paid2Cancelled
        }

        protected void UndoTransition_Paid2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Paid   To State : Cancelled
#region UndoTransition_Paid2Cancelled
            NoBackStateBack();
#endregion UndoTransition_Paid2Cancelled
        }

        protected void PostTransition_New2Paid()
        {
            // From State : New   To State : Paid
#region PostTransition_New2Paid
            bool paidFound = false;
            
            if (PatientDebentures.Count == 0)
                throw new TTException(SystemMessage.GetMessage(388));
            else
            {
                foreach (DebenturePaymentPatientDebentures dList in PatientDebentures)
                {
                    if (dList.Paid == true)
                    {  paidFound = true;
                        break;
                    }
                }
                if (paidFound == false)
                    throw new TTException(SystemMessage.GetMessage(389));
                
                if (DebenturePaymentDocument.CashPayment.Count == 0 &&  DebenturePaymentDocument.CreditCardPayments.Count == 0)
                    throw new TTException(SystemMessage.GetMessage(114));
                
                
                DebenturePaymentDocument.TotalPrice = TotalPrice;
                GeneralTotalPrice = TotalPrice;
                DebenturePaymentDocumentGroup docGroup = (DebenturePaymentDocumentGroup)DebenturePaymentDocument.AddDocumentGroup("TAHSİLAT",TTUtils.CultureService.GetText("M26840", "Senet Ödemeleri"));
                docGroup.AddDocumentDetail(TTUtils.CultureService.GetText("M25796", "Hasta senet ödemesi"), 1, (double)DebenturePaymentDocument.TotalPrice);

                //Hasta Makbuzu ödediği anda APRTrx ler oluşturuluyor.Makbuzu Senetle ödemiş olsa bile ödemiş gibi hasta
                //borçlu sayılmıyor.XXXXXXnin isteğine göre ileride değiştirilebilir.
                
                DebenturePaymentDocument.CurrentStateDefID = DebenturePaymentDocument.States.Paid;
                DebenturePaymentDocument.SendToAccounting = false;
                Debenture myDebenture = null ;
                foreach (DebenturePaymentPatientDebentures debList in PatientDebentures)
                {
                    if (debList.Paid == true )
                    {
                        debList.Debenture.CurrentStateDefID = Debenture.States.Paid ;
                    }
                }
                
                ReceiptCashOfficeDefinition myReceiptCashOffice = (ReceiptCashOfficeDefinition)ReceiptCashOfficeDefinition.GetByCashOffice(ObjectContext, DebenturePaymentDocument.CashierLog.CashOffice.ObjectID.ToString())[0];
                if (DebenturePaymentDocument.CashPayment.Count > 0)
                {
                    DebenturePaymentDocument.DocumentNo = (string)ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(myReceiptCashOffice);
                    ReceiptCashOfficeDefinition.SetNextReceiptNumber(myReceiptCashOffice);
                    DebenturePaymentDocument.SpecialNo.GetNextValue(DebenturePaymentDocument.CashierLog.ResUser.ID.ToString(), Common.RecTime().Year);
                }
                
                if (DebenturePaymentDocument.CreditCardPayments.Count > 0)
                {
                    DebenturePaymentDocument.CreditCardDocumentNo = ReceiptCashOfficeDefinition.GetCurrentCreditCardReceiptNumber(myReceiptCashOffice);
                    ReceiptCashOfficeDefinition.SetNextCreditCardReceiptNumber(myReceiptCashOffice);
                    DebenturePaymentDocument.CreditCardSpecialNo.GetNextValue(DebenturePaymentDocument.CashierLog.ResUser.ID.ToString(), Common.RecTime().Year);
                }
            }
#endregion PostTransition_New2Paid
        }

        protected void UndoTransition_New2Paid(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Paid
#region UndoTransition_New2Paid
            NoBackStateBack();
#endregion UndoTransition_New2Paid
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
            base.Cancel();
            
            CashierLog myCashierLog = DebenturePaymentDocument.CashierLog;
            if (myCashierLog == null)
                throw new TTException(SystemMessage.GetMessage(191));
            else
            {
                if (myCashierLog.ClosingDate != null)
                    throw new TTException(SystemMessage.GetMessage(192));
                else
                {
                    ResUser currentResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
                    if (myCashierLog.ResUser.ObjectID == currentResUser.ObjectID)
                    {
                        foreach (DebenturePaymentPatientDebentures patientDbs in PatientDebentures)
                        {
                            patientDbs.Debenture.CurrentStateDefID = Debenture.States.New ;
                        }
                        DebenturePaymentDocument.Cancel();
                    }
                    else
                        throw new TTException(SystemMessage.GetMessage(385));
                }
            }
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DebenturePayment).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DebenturePayment.States.Paid && toState == DebenturePayment.States.Cancelled)
                PostTransition_Paid2Cancelled();
            else if (fromState == DebenturePayment.States.New && toState == DebenturePayment.States.Paid)
                PostTransition_New2Paid();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DebenturePayment).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DebenturePayment.States.Paid && toState == DebenturePayment.States.Cancelled)
                UndoTransition_Paid2Cancelled(transDef);
            else if (fromState == DebenturePayment.States.New && toState == DebenturePayment.States.Paid)
                UndoTransition_New2Paid(transDef);
        }

    }
}