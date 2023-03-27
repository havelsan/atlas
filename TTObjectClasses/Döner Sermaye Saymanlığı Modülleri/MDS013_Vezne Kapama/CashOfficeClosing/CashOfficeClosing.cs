
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
    /// Muh.Yet. Mutemetliği/Vezne/Fatura Servisi Kapama
    /// </summary>
    public  partial class CashOfficeClosing : BaseAction, IWorkListBaseAction
    {
        public partial class CashOfficeClosingCashReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class CashOfficeClosingCrdCardReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetSubCashOfficeClosingsByDate_Class : TTReportNqlObject 
        {
        }

        public partial class BankDeliveryReportQuery_Class : TTReportNqlObject 
        {
        }

        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            
            ResUser _myResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
            CashOfficeClosingDocumentGroup cocdg;
            
            ResUser resUser = (ResUser)ObjectContext.GetObject(_myResUser.ObjectID, "ResUser");
            
            if (CashOfficeClosingDocument.CashierLog.CashOffice.Type == CashOfficeTypeEnum.CashOffice)
            {
                cocdg = (CashOfficeClosingDocumentGroup)CashOfficeClosingDocument.AddDocumentGroup("VT",TTUtils.CultureService.GetText("M27197", "Vezne Teslim"));
                CashOfficeClosingDocument.TotalPrice = (double)CashRevenueTotal - (double)TreatmentPriceBackTotal - (double)OtherPriceBackTotal;
                cocdg.AddDocumentDetail(TTUtils.CultureService.GetText("M27198", "Vezne Teslimat"), 1, (double)CashOfficeClosingDocument.TotalPrice);
                
                //  15 = Vezne Tahsilat
                if ((double)CashOfficeClosingDocument.TotalPrice != 0)
                    CashOfficeClosingDocument.AddAPRTransaction((AccountPayableReceivable)resUser.MyAPR(), (double)CashOfficeClosingDocument.TotalPrice, (APRTrxType)APRTrxType.GetByType(ObjectContext, 15)[0]);

                if (SubmittedTotal != null)
                {
                    if ((double)SubmittedTotal != 0)
                    {
                        // 16 = Vezne Teslimat
                        CashOfficeClosingDocument.AddAPRTransaction((AccountPayableReceivable)resUser.MyAPR(),(double)(SubmittedTotal * -1) , (APRTrxType)APRTrxType.GetByType(ObjectContext, 16)[0]);
                        
                        if (CashOfficeClosingDocument.DocumentNo == null)
                            throw new TTUtils.TTException(SystemMessage.GetMessageV3(132, new string[] {TTUtils.CultureService.GetText("M27095", "Teslimat Müzekkeresi Numarası")}));
                        
                        if (CashOfficeClosingDocument.BankAccount == null)
                            throw new TTUtils.TTException(SystemMessage.GetMessageV3(132, new string[] {TTUtils.CultureService.GetText("M11507", "Banka Hesap Numarası")}));
                        
//                        ReceiptCashOfficeDefinition myReceiptCashOffice = (ReceiptCashOfficeDefinition)ReceiptCashOfficeDefinition.GetByCashOffice(this.ObjectContext, this.CashOfficeClosingDocument.CashierLog.CashOffice.ObjectID.ToString())[0];
//                        myReceiptCashOffice.SetNextBankDeliveryNumber();
                        CashOfficeClosingDocument.SpecialNo.GetNextValue(CashOfficeClosingDocument.CashierLog.ResUser.ID.ToString(), Common.RecTime().Year);
                    }
                }
                
                CashOfficeClosingDocument.CurrentStateDefID = CashOfficeClosingDocument.States.Submitted;
            }
            else if(CashOfficeClosingDocument.CashierLog.CashOffice.Type == CashOfficeTypeEnum.CashOffice)
            {
                cocdg = (CashOfficeClosingDocumentGroup)CashOfficeClosingDocument.AddDocumentGroup("MYMT",TTUtils.CultureService.GetText("M26550", "Muhasebe Yetkilisi Mutemedi Teslim"));
                CashOfficeClosingDocument.TotalPrice = (double)CashRevenueTotal - (double)TreatmentPriceBackTotal ;
                cocdg.AddDocumentDetail(TTUtils.CultureService.GetText("M26551", "Muhasebe Yetkilisi Mutemedi Teslimat"), 1, (double)CashOfficeClosingDocument.TotalPrice);

                //MUTEMETLER ELLERİNDEKİ TÃœM PARAYI TESLİM ETTİKLERİ İÇİN BALANSLARI HEP 0 OLUYOR. BU YÃœZDEN APRTRX OLUŞTURMAYA GEREK YOK
                //this.CashOfficeClosingDocument.AddAPRTransaction((AccountPayableReceivable)resUser.MyAPR(),(double)this.CashRevenueTotal - (double)this.TreatmentPriceBackTotal , (APRTrxType)APRTrxType.GetByType(this.ObjectContext, 13)[0]);
                //this.CashOfficeClosingDocument.AddAPRTransaction((AccountPayableReceivable)resUser.MyAPR(),(double)(this.SubmittedTotal * -1) , (APRTrxType)APRTrxType.GetByType(this.ObjectContext, 14)[0]);

                CashOfficeClosingDocument.CurrentStateDefID = CashOfficeClosingDocument.States.Submitted;
            }
            
            CashierLog.ClosingDate = Common.RecTime();
            CashierLog.CurrentStateDefID = CashierLog.States.Closed;
            CashOfficeClosingDocument.SendToAccounting = false;
            
            //   muhasebe entegrasyon kodları
            IList accDocs;
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if(CashOfficeClosingDocument.CashierLog.CashOffice.Type == CashOfficeTypeEnum.CashOffice)
                {
                    if(CashOfficeClosingDocument.BankAccount != null) // Banka seçilmişse
                    {
                        if (CashOfficeClosingDocument.BankAccount.AccountCode == null)
                            throw new TTUtils.TTException(SystemMessage.GetMessageV3(133, new string[] {CashOfficeClosingDocument.BankAccount.BankBranch.Bank.Name + " " + CashOfficeClosingDocument.BankAccount.BankBranch.Name + " " + CashOfficeClosingDocument.BankAccount.AccountNo}));
                        else
                        {
                            if (CashOfficeClosingDocument.BankAccount.AccountCode.Trim() == "")
                                throw new TTUtils.TTException(SystemMessage.GetMessageV3(133, new string[] {CashOfficeClosingDocument.BankAccount.BankBranch.Bank.Name + " " + CashOfficeClosingDocument.BankAccount.BankBranch.Name + " " + CashOfficeClosingDocument.BankAccount.AccountNo}));
                        }
                        
                        IList<AccountDocument.ReceiptInfo> ReceiptList = new List<AccountDocument.ReceiptInfo>();
                        AccountDocument.ReceiptInfo RI;
                        
                        accDocs = AccountDocument.GetAllAccDocsByCashierLog(ObjectContext,CashOfficeClosingDocument.CashierLog.ObjectID.ToString());
                        foreach(AccountDocument accDoc in accDocs)
                        {
                            RI = null;
                            
                            if(accDoc is ReceiptDocument)
                            {
                                ReceiptDocument receiptDocument = (ReceiptDocument)accDoc;
                                if(receiptDocument.CurrentStateDefID == ReceiptDocument.States.Paid)
                                    RI = receiptDocument.CreateReceiptInfoForAccounting();
                            }
                            else if(accDoc is AdvanceDocument)
                            {
                                AdvanceDocument advanceDocument  = (AdvanceDocument)accDoc;
                                if(advanceDocument.CurrentStateDefID == AdvanceDocument.States.Paid)
                                    RI = advanceDocument.CreateReceiptInfoForAccounting();
                            }
                            else if(accDoc is DebenturePaymentDocument)
                            {
                                DebenturePaymentDocument debenturePaymentDocument = (DebenturePaymentDocument)accDoc;
                                if(debenturePaymentDocument.CurrentStateDefID == DebenturePaymentDocument.States.Paid)
                                    RI = debenturePaymentDocument.CreateReceiptInfoForAccounting();
                            }
                            else if(accDoc is SubCashOfficeReceiptDoc)
                            {
                                SubCashOfficeReceiptDoc receiptDoc = (SubCashOfficeReceiptDoc)accDoc;
                                if(receiptDoc.CurrentStateDefID == SubCashOfficeReceiptDoc.States.Paid)
                                    RI = receiptDoc.CreateReceiptInfoForAccounting();
                            }
                            else if(accDoc is GeneralReceiptDocument)
                            {
                                GeneralReceiptDocument generalReceiptDoc = (GeneralReceiptDocument)accDoc;
                                if(generalReceiptDoc.CurrentStateDefID == GeneralReceiptDocument.States.Paid)
                                    RI = generalReceiptDoc.CreateReceiptInfoForAccounting();
                            }
                            else if(accDoc is ReceiptBackDocument)
                            {
                                ReceiptBackDocument receiptBackDocument = (ReceiptBackDocument)accDoc;
                                if(receiptBackDocument.CurrentStateDefID == ReceiptBackDocument.States.Paid)
                                    RI = receiptBackDocument.CreateReceiptInfoForAccounting();
                            }
                            else if(accDoc is AdvanceBackDocument)
                            {
                                AdvanceBackDocument advanceBackDocument = (AdvanceBackDocument)accDoc;
                                if(advanceBackDocument.CurrentStateDefID == AdvanceBackDocument.States.Paid)
                                    RI = advanceBackDocument.CreateReceiptInfoForAccounting();
                            }
                            
                            if (RI != null)
                            {
                                // Muhasebe Yetkilisi Mutemetliği kapatılırken, nakit tutar Vezneye teslim edilmeyip bankaya yatırılmışsa,
                                // fişlerdeki nakit muhasebe hesap numaraları, bankanın muhasebe hesap numarası ile değiştirilir.
                                /*
                                foreach(AccountDocument.ReceiptLine rLine in RI.Lines)
                                {
                                    if(rLine.AccountCode == accDoc.GetAccountCode(AccountEntegrationAccountTypeEnum.KasaHesabi))
                                    {
                                        rLine.AccountCode = this.CashOfficeClosingDocument.BankAccount.AccountCode;
                                        rLine.Description = "Banka Teslimatı";
                                    }
                                }
                                 */
                                ReceiptList.Add(RI);
                                accDoc.SendToAccounting = true;
                            }
                        }
                        
                        if (ReceiptList.Count > 0)
                        {
                            //TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "Invoice.Integration", "InvoiceUtils", "CreateReceipt", null, ReceiptList);
                        }
                    }
                    else  // Banka seçilmemişse
                    {
                        IList<AccountDocument.ReceiptInfo> ReceiptList = new List<AccountDocument.ReceiptInfo>();
                        AccountDocument.ReceiptInfo RI;
                        
                        accDocs = AccountDocument.GetAllAccDocsByCashierLog(ObjectContext,CashOfficeClosingDocument.CashierLog.ObjectID.ToString());
                        foreach(AccountDocument accDoc in accDocs)
                        {
                            RI = null;
                            
                            if(accDoc is ReceiptDocument)
                            {
                                ReceiptDocument receiptDocument = (ReceiptDocument)accDoc;
                                if(receiptDocument.CurrentStateDefID == ReceiptDocument.States.Paid)
                                {
                                    if(receiptDocument.GetCalculatedNonCashPayment() > 0 && receiptDocument.GetCalculatedCashPayment(Convert.ToDateTime(receiptDocument.DocumentDate)) == 0)
                                        RI = receiptDocument.CreateReceiptInfoForAccounting();
                                    else if(receiptDocument.GetCalculatedNonCashPayment() > 0 && receiptDocument.GetCalculatedCashPayment(Convert.ToDateTime(receiptDocument.DocumentDate)) > 0)
                                        RI = receiptDocument.CreateNonCashReceiptInfoForAccounting();
                                }
                            }
                            else if(accDoc is AdvanceDocument)
                            {
                                AdvanceDocument advanceDocument  = (AdvanceDocument)accDoc;
                                if(advanceDocument.CurrentStateDefID == AdvanceDocument.States.Paid)
                                {
                                    if(advanceDocument.GetCalculatedNonCashPayment() > 0 && advanceDocument.GetCalculatedCashPayment(Convert.ToDateTime(advanceDocument.DocumentDate)) == 0)
                                        RI = advanceDocument.CreateReceiptInfoForAccounting();
                                    else if(advanceDocument.GetCalculatedNonCashPayment() > 0 && advanceDocument.GetCalculatedCashPayment(Convert.ToDateTime(advanceDocument.DocumentDate)) > 0)
                                        RI = advanceDocument.CreateNonCashReceiptInfoForAccounting();
                                }
                            }
                            else if(accDoc is DebenturePaymentDocument)
                            {
                                DebenturePaymentDocument debenturePaymentDocument = (DebenturePaymentDocument)accDoc;
                                if(debenturePaymentDocument.CurrentStateDefID == DebenturePaymentDocument.States.Paid)
                                {
                                    if(debenturePaymentDocument.GetCalculatedNonCashPayment() > 0 && debenturePaymentDocument.GetCalculatedCashPayment(Convert.ToDateTime(debenturePaymentDocument.DocumentDate)) == 0)
                                        RI = debenturePaymentDocument.CreateReceiptInfoForAccounting();
                                    else if(debenturePaymentDocument.GetCalculatedNonCashPayment() > 0 && debenturePaymentDocument.GetCalculatedCashPayment(Convert.ToDateTime(debenturePaymentDocument.DocumentDate)) > 0)
                                        RI = debenturePaymentDocument.CreateNonCashReceiptInfoForAccounting();
                                }
                            }
                            else if(accDoc is SubCashOfficeReceiptDoc)
                            {
                                SubCashOfficeReceiptDoc receiptDoc = (SubCashOfficeReceiptDoc)accDoc;
                                if(receiptDoc.CurrentStateDefID == SubCashOfficeReceiptDoc.States.Paid)
                                {
                                    if(receiptDoc.GetCalculatedNonCashPayment() > 0 && receiptDoc.GetCalculatedCashPayment(Convert.ToDateTime(receiptDoc.DocumentDate)) == 0)
                                        RI = receiptDoc.CreateReceiptInfoForAccounting();
                                    else if(receiptDoc.GetCalculatedNonCashPayment() > 0 && receiptDoc.GetCalculatedCashPayment(Convert.ToDateTime(receiptDoc.DocumentDate)) > 0)
                                        RI = receiptDoc.CreateNonCashReceiptInfoForAccounting();
                                }
                            }
                            else if(accDoc is GeneralReceiptDocument)
                            {
                                GeneralReceiptDocument generalReceiptDoc = (GeneralReceiptDocument)accDoc;
                                if(generalReceiptDoc.CurrentStateDefID == GeneralReceiptDocument.States.Paid)
                                {
                                    if(generalReceiptDoc.GetCalculatedNonCashPayment() > 0 && generalReceiptDoc.GetCalculatedCashPayment(Convert.ToDateTime(generalReceiptDoc.DocumentDate)) == 0)
                                        RI = generalReceiptDoc.CreateReceiptInfoForAccounting();
                                    else if(generalReceiptDoc.GetCalculatedNonCashPayment() > 0 && generalReceiptDoc.GetCalculatedCashPayment(Convert.ToDateTime(generalReceiptDoc.DocumentDate)) > 0)
                                        RI = generalReceiptDoc.CreateNonCashReceiptInfoForAccounting();
                                }
                            }
                            else if(accDoc is ReceiptBackDocument)
                            {
                                ReceiptBackDocument receiptBackDocument = (ReceiptBackDocument)accDoc;
                                if(receiptBackDocument.CurrentStateDefID == ReceiptBackDocument.States.Paid)
                                    RI = receiptBackDocument.CreateReceiptInfoForAccounting();
                            }
                            else if(accDoc is AdvanceBackDocument)
                            {
                                AdvanceBackDocument advanceBackDocument = (AdvanceBackDocument)accDoc;
                                if(advanceBackDocument.CurrentStateDefID == AdvanceBackDocument.States.Paid)
                                    RI = advanceBackDocument.CreateReceiptInfoForAccounting();
                            }
                            
                            if (RI != null)
                            {
                                ReceiptList.Add(RI);
                                accDoc.SendToAccounting = true;
                            }
                        }
                        
                        if (ReceiptList.Count > 0)
                        {
                            //TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "Invoice.Integration", "InvoiceUtils", "CreateReceipt", null, ReceiptList);
                        }

                    }
                }
                
                // Muhasebe Yetkilisi Mutemetliği veya Vezne Kapama işleminde,
                // Bankaya Teslim Edilen tutarın muhasebe hareketi oluşturulur
                if(CashOfficeClosingDocument.BankAccount != null)
                {
                    IList<AccountDocument.BankDelivery> BankDeliveryList = new List<AccountDocument.BankDelivery>();
                    AccountDocument.BankDelivery BD = null;
                    
                    BD = CashOfficeClosingDocument.CreateBankDeliveryForAccounting((double)SubmittedTotal);
                    
                    if (BD != null)
                    {
                        BankDeliveryList.Add(BD);
                        CashOfficeClosingDocument.SendToAccounting = true;
                    }
                    
                    if (BankDeliveryList.Count > 0)
                    {
                        //TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "Invoice.Integration", "InvoiceUtils", "CreateBankDelivery", null, BankDeliveryList);
                    }
                }
                
            }
            // XXXXXX başlayınca aşağıdaki hata mesajı açılacak, muhasebe işlemleri yapılmadan kasa kapatılamayacak
            //else
            //    throw new TTUtils.TTException(SystemMessage.GetMessage(134));
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
        private IList _accDocs ;
        private IList _cashOfficeClosings;
        private IList _accBackDocs;
        public IList GetAccountDocumentsForCashOffice(string clog, CashOfficeTypeEnum cashOfficeType)
        {
            if (cashOfficeType == CashOfficeTypeEnum.CashOffice)
            {
                _accDocs = AccountDocument.GetMainCashierDocsByCashierLog(ObjectContext,clog);
            }
            else if (cashOfficeType == CashOfficeTypeEnum.CashOffice)
            {
                _accDocs = AccountDocument.GetSubCashierDocsByCashierLog (ObjectContext,clog);
            }
            else if (cashOfficeType == CashOfficeTypeEnum.InvoicingService)
            {
                _accDocs = AccountDocument.GetInvSrvCashierDocsByCashierLog(ObjectContext,clog);
            }
            return _accDocs;
        }
        
        public IList GetBackTypeDocsForCashOffice(string clog)
        {
         _accBackDocs = AccountDocument.GetBackDocsByCashierLog(ObjectContext,clog);
         return _accBackDocs;
        }
        
        public IList GetAnnualCashOfficeClosings(DateTime sDate,DateTime eDate,string cashOffice)
        {
            _cashOfficeClosings = CashOfficeClosing.GetCashOfficeClosingsByDate (ObjectContext, sDate , eDate, cashOffice );
            return _cashOfficeClosings;
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(CashOfficeClosing).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == CashOfficeClosing.States.New && toState == CashOfficeClosing.States.Completed)
                PostTransition_New2Completed();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(CashOfficeClosing).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == CashOfficeClosing.States.New && toState == CashOfficeClosing.States.Completed)
                UndoTransition_New2Completed(transDef);
        }

    }
}