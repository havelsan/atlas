
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
    /// Fatura Tahsilat
    /// </summary>
    public  partial class InvoicePayment : AccountAction, IWorkListBaseAction
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "PAYERPAYMENTDOCUMENT":
                    {
                        PayerPaymentDocument value = (PayerPaymentDocument)newValue;
#region PAYERPAYMENTDOCUMENT_SetParentScript
                        value.AccountAction=this;
#endregion PAYERPAYMENTDOCUMENT_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected void PostTransition_New2Paid()
        {
            // From State : New   To State : Paid
#region PostTransition_New2Paid
            bool paidFound = false;
            IList accTrxInsidePackageList = null;

            if (InvoicePaymentPatients.Count == 0)
                throw new TTUtils.TTException(SystemMessage.GetMessage(226));
            
            foreach (InvoicePaymentPatientList pList in InvoicePaymentPatients)
            {
                if (pList.Paid == true)
                {
                    paidFound = true;
                    break;
                }
            }
            
            if (paidFound == false)
                throw new TTUtils.TTException(SystemMessage.GetMessage(227));
            
            if (TotalPayment == null || TotalPayment == 0)
                throw new TTUtils.TTException(SystemMessage.GetMessage(114));
            
            if (PaymentPrice < TotalPayment)
                throw new TTUtils.TTException(SystemMessage.GetMessage(228));
            
            PayerPaymentDocument.TotalPrice = PaymentPrice;
            PayerPaymentDocument.TotalCutOffPrice = CutOffPrice;
            PayerPaymentDocumentGroup docGroup = (PayerPaymentDocumentGroup)PayerPaymentDocument.AddDocumentGroup("TAHSİLAT",TTUtils.CultureService.GetText("M25645", "Fatura Ödemeleri"));
            docGroup.AddDocumentDetail(TTUtils.CultureService.GetText("M26360", "Kurum fatura ödemesi"), 1, (double)PayerPaymentDocument.TotalPrice);
            //Kesinti olsa da toplam tutar kurum hesabindan dusuluyor. Borc kapatiliyor.
            PayerPaymentDocument.AddAPRTransaction((AccountPayableReceivable)Payer.MyAPR(), (double)TotalPrice - (double)GetTotalUsedAdvancePayment(), (APRTrxType)APRTrxType.GetByType(ObjectContext, 5)[0]);
            PayerPaymentDocument.CurrentStateDefID = PayerPaymentDocument.States.Paid;
            PayerPaymentDocument.SendToAccounting = false;

            foreach (InvoicePaymentPatientList invPL in InvoicePaymentPatients)
            {
                //faturalarin, detayların ve AccTrx lerin durumu ödendi yapiliyor.
                if (invPL.Paid == true)
                {
                    if (invPL.CollectedInvoiceDocument != null)
                    {
                        foreach (CollectedInvoiceDocumentGroup invGroup in invPL.CollectedInvoiceDocument.CollectedInvoiceDocumentGroups)
                        {
                            foreach (CollectedInvoiceDocumentDetail invDetail in invGroup.CollectedInvoiceDocumentDetails)
                            {
                                invDetail.CurrentStateDefID = CollectedInvoiceDocumentDetail.States.Paid;
                                
                                foreach (AccountTrxDocument AccTrxDoc in invDetail.AccountTrxDocument)
                                {
                                    AccountTransaction accTrx = AccTrxDoc.AccountTransaction;
                                    if(accTrx.CurrentStateDefID != AccountTransaction.States.Cancelled)
                                    {
                                        accTrx.CurrentStateDefID = AccountTransaction.States.Paid;
                                    }
                                    // Paket ise paket içindeki AccTrx ler de Paid durumuna alınır
                                    /*
                                    if (accTrx.SubActionProcedure != null)
                                    {
                                        if (accTrx.SubActionProcedure.PackageDefinition != null)
                                        {
                                            accTrxInsidePackageList = AccountTransaction.GetTransactionsInsidePackage(this.ObjectContext, accTrx.SubActionProcedure.PackageDefinition.ObjectID.ToString(), accTrx.EpisodeProtocol.ObjectID.ToString(), accTrx.AccountPayableReceivable.ObjectID.ToString());
                                            foreach (AccountTransaction accTrxInPack in accTrxInsidePackageList)
                                            {
                                                accTrxInPack.CurrentStateDefID = AccountTransaction.States.Paid;
                                            }
                                        }
                                    }
                                    */
                                }
                            }
                        }
                        invPL.CollectedInvoiceDocument.CurrentStateDefID = CollectedInvoiceDocument.States.Paid;
                    }
                    else if (invPL.PayerInvoiceDocument != null)
                    {
                        foreach (PayerInvoiceDocumentGroup invGroup in invPL.PayerInvoiceDocument.PayerInvoiceDocumentGroups)
                        {
                            foreach (PayerInvoiceDocumentDetail invDetail in invGroup.PayerInvoiceDocumentDetails)
                            {
                                //invDetail.CurrentStateDefID = PayerInvoiceDocumentDetail.States.Paid;
                                
                                AccountTransaction accTrx = invDetail.AccountTrxDocument[0].AccountTransaction;
                                if(accTrx.CurrentStateDefID != AccountTransaction.States.Cancelled)
                                {
                                    accTrx.CurrentStateDefID = AccountTransaction.States.Paid;
                                }
                                // Paket ise paket içindeki AccTrx ler de Send durumuna alınır
                                /*
                                if (accTrx.SubActionProcedure != null)
                                {
                                    if (accTrx.SubActionProcedure.PackageDefinition != null)
                                    {
                                        accTrxInsidePackageList = AccountTransaction.GetTransactionsInsidePackage(this.ObjectContext, accTrx.SubActionProcedure.PackageDefinition.ObjectID.ToString(), accTrx.EpisodeProtocol.ObjectID.ToString(), accTrx.AccountPayableReceivable.ObjectID.ToString());
                                        foreach (AccountTransaction accTrxInPack in accTrxInsidePackageList)
                                        {
                                            accTrxInPack.CurrentStateDefID = AccountTransaction.States.Paid;
                                        }
                                    }
                                }
                                */
                            }
                        }
                        //invPL.PayerInvoiceDocument.CurrentStateDefID = PayerInvoiceDocument.States.Paid;
                    }
                    else if (invPL.GeneralInvoiceDocument != null)
                    {
                        foreach (GeneralInvoiceDocumentGroup invGroup in invPL.GeneralInvoiceDocument.GeneralInvoiceDocumentGroups)
                        {
                            foreach (GeneralInvoiceDocumentDetail invDetail in invGroup.GeneralInvoiceDocumentDetails)
                            {
                                invDetail.CurrentStateDefID = GeneralInvoiceDocumentDetail.States.Paid;
                            }
                        }
                        invPL.GeneralInvoiceDocument.CurrentStateDefID = GeneralInvoiceDocument.States.Paid;
                    }
                    
                    else if (invPL.ManualInvoiceDocument != null)
                    {
                        invPL.ManualInvoiceDocument.CurrentStateDefID = ManualInvoiceDocument.States.Paid;
                    }
                }
            }
            
            // Kullanılan avansların kalan tutarları azaltılır
            if (UseAdvance == true)
            {
                foreach (PayerPaymentAdvanceList adv in PayerPaymentAdvances)
                {
                    if (adv.Used == true)
                        adv.PayerAdvancePayment.RemainingPrice = adv.PayerAdvancePayment.RemainingPrice - adv.UsedPrice;
                    else
                        adv.UsedPrice = 0;
                }
            }
            
            /* Fatura Tahsilat işlemi için muhasebe entegrasyonunda olmaması istendiğinden aşağıdaki kısım kapatıldı.
              
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                IList<AccountDocument.PaymentInfo> PaymentList = new List<AccountDocument.PaymentInfo>();
                AccountDocument.PaymentInfo PI = null;
                PI = this.PayerPaymentDocument.CreatePaymentInfoForAccounting();

                if (PI != null)
                {
                    PaymentList.Add(PI);
                    this.PayerPaymentDocument.SendToAccounting = true;
                }
                
                if (PaymentList.Count > 0)
                {
                    TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "Invoice.Integration", "InvoiceUtils", "CreatePayment", PaymentList);
                    //TTMessageFactory.SyncCall(Sites.SiteLocalHost, "Invoice.Integration", "InvoiceUtils", "CreatePayment", PaymentList);
                }
            }
             */
#endregion PostTransition_New2Paid
        }

        protected void UndoTransition_New2Paid(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Paid
#region UndoTransition_New2Paid
            NoBackStateBack();
#endregion UndoTransition_New2Paid
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

#region Methods
        public override void Cancel()
        {
            IList accTrxInsidePackageList = null;
            
            base.Cancel();
            PayerPaymentDocument.Cancel();
            
            foreach (InvoicePaymentPatientList invPL in InvoicePaymentPatients)
            {
                //faturalarin durumu Gönderildi ye donduruluyor.
                if (invPL.Paid == true)
                {
                    if (invPL.CollectedInvoiceDocument != null)
                    {
                        foreach (CollectedInvoiceDocumentGroup invGroup in invPL.CollectedInvoiceDocument.CollectedInvoiceDocumentGroups)
                        {
                            foreach (CollectedInvoiceDocumentDetail invDetail in invGroup.CollectedInvoiceDocumentDetails)
                            {
                                invDetail.CurrentStateDefID = CollectedInvoiceDocumentDetail.States.Send;
                                
                                foreach (AccountTrxDocument AccTrxDoc in invDetail.AccountTrxDocument)
                                {
                                    AccountTransaction accTrx = AccTrxDoc.AccountTransaction;
                                    accTrx.CurrentStateDefID = AccountTransaction.States.Send;
                                    
                                    // Paket ise paket içindeki AccTrx ler de Paid durumuna alınır
                                    /*
                                    if (accTrx.SubActionProcedure != null)
                                    {
                                        if (accTrx.SubActionProcedure.PackageDefinition != null)
                                        {
                                            accTrxInsidePackageList = AccountTransaction.GetTransactionsInsidePackage(this.ObjectContext, accTrx.SubActionProcedure.PackageDefinition.ObjectID.ToString(), accTrx.EpisodeProtocol.ObjectID.ToString(), accTrx.AccountPayableReceivable.ObjectID.ToString());
                                            foreach (AccountTransaction accTrxInPack in accTrxInsidePackageList)
                                            {
                                                accTrxInPack.CurrentStateDefID = AccountTransaction.States.Send;
                                            }
                                        }
                                    }
                                    */
                                }
                            }
                        }
                        invPL.CollectedInvoiceDocument.CurrentStateDefID = CollectedInvoiceDocument.States.Send;
                    }
                    else if (invPL.PayerInvoiceDocument != null)
                    {
                        foreach (PayerInvoiceDocumentGroup invGroup in invPL.PayerInvoiceDocument.PayerInvoiceDocumentGroups)
                        {
                            foreach (PayerInvoiceDocumentDetail invDetail in invGroup.PayerInvoiceDocumentDetails)
                            {
                                //invDetail.CurrentStateDefID = PayerInvoiceDocumentDetail.States.Send;
                                
                                AccountTransaction accTrx = invDetail.AccountTrxDocument[0].AccountTransaction;
                                accTrx.CurrentStateDefID = AccountTransaction.States.Send;
                                
                                // Paket ise paket içindeki AccTrx ler de Send durumuna alınır
                                /*
                                if (accTrx.SubActionProcedure != null)
                                {
                                    if (accTrx.SubActionProcedure.PackageDefinition != null)
                                    {
                                        accTrxInsidePackageList = AccountTransaction.GetTransactionsInsidePackage(this.ObjectContext, accTrx.SubActionProcedure.PackageDefinition.ObjectID.ToString(), accTrx.EpisodeProtocol.ObjectID.ToString(), accTrx.AccountPayableReceivable.ObjectID.ToString());
                                        foreach (AccountTransaction accTrxInPack in accTrxInsidePackageList)
                                        {
                                            accTrxInPack.CurrentStateDefID = AccountTransaction.States.Send;
                                        }
                                    }
                                }
                                */
                            }
                        }
                        //invPL.PayerInvoiceDocument.CurrentStateDefID = PayerInvoiceDocument.States.Send;
                    }
                    else if (invPL.GeneralInvoiceDocument != null)
                    {
                        foreach (GeneralInvoiceDocumentGroup invGroup in invPL.GeneralInvoiceDocument.GeneralInvoiceDocumentGroups)
                        {
                            foreach (GeneralInvoiceDocumentDetail invDetail in invGroup.GeneralInvoiceDocumentDetails)
                            {
                                invDetail.CurrentStateDefID = GeneralInvoiceDocumentDetail.States.Send;
                            }
                        }
                        invPL.GeneralInvoiceDocument.CurrentStateDefID = GeneralInvoiceDocument.States.Send;
                    }
                    else if (invPL.ManualInvoiceDocument != null)
                    {
                        invPL.ManualInvoiceDocument.CurrentStateDefID = ManualInvoiceDocument.States.Send;
                    }
                }
            }
            
            // Kullanılan avansların kalan tutarları artırılır
            if (UseAdvance == true)
            {
                foreach (PayerPaymentAdvanceList adv in PayerPaymentAdvances)
                {
                    if (adv.Used == true)
                    {
                        adv.PayerAdvancePayment.RemainingPrice = adv.PayerAdvancePayment.RemainingPrice + adv.UsedPrice;
                    }
                }
            }
        }
        
        public double GetTotalUsedAdvancePayment()
        {
            double totalUsedAdvance = 0;
            
            foreach (PayerPaymentAdvanceList adv in PayerPaymentAdvances)
            {
                if (adv.UsedPrice == null)
                    adv.UsedPrice = 0;
                
                if (adv.UsedPrice > adv.PayerAdvancePayment.RemainingPrice)
                    adv.UsedPrice = adv.PayerAdvancePayment.RemainingPrice;

                if (adv.Used == true)
                    totalUsedAdvance = totalUsedAdvance + (double)adv.UsedPrice;
            }

            return totalUsedAdvance;
        }
        
        public void UpdateBankAccountOrCashFields()
        {
            double priceTotal = 0;
            double cutOff = 0;
            foreach (InvoicePaymentPatientList paymentList in InvoicePaymentPatients)
            {
                if (paymentList.Paid == true)
                {
                    if (paymentList.InvoiceCutOffPrice != null && !string.IsNullOrEmpty(paymentList.InvoiceCutOffPrice.ToString()))
                        cutOff = Convert.ToDouble(paymentList.InvoiceCutOffPrice);
                    priceTotal += Convert.ToDouble(paymentList.InvoiceTotalPrice) - cutOff;
                }
            }
            if (PayerPaymentDocument.BankDecountPayments.Count > 0)
                PayerPaymentDocument.BankDecountPayments[0].Price = priceTotal;
            else if (PayerPaymentDocument.CashPayment.Count > 0)
                PayerPaymentDocument.CashPayment[0].Price = priceTotal;
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InvoicePayment).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == InvoicePayment.States.New && toState == InvoicePayment.States.Paid)
                PostTransition_New2Paid();
            else if (fromState == InvoicePayment.States.Paid && toState == InvoicePayment.States.Cancelled)
                PostTransition_Paid2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(InvoicePayment).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == InvoicePayment.States.New && toState == InvoicePayment.States.Paid)
                UndoTransition_New2Paid(transDef);
            else if (fromState == InvoicePayment.States.Paid && toState == InvoicePayment.States.Cancelled)
                UndoTransition_Paid2Cancelled(transDef);
        }

    }
}