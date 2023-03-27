
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
    /// Vezne Tahsilat İşlemi
    /// </summary>
    public partial class MainCashOfficeOperation : AccountAction, IWorkListBaseAction
    {
        public partial class CashOfficeReceiptDocumentReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class ChattelReceiptReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetCashOfficeOpsByDateAndType_Class : TTReportNqlObject
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "CASHOFFICERECEIPTDOCUMENT":
                    {
                        CashOfficeReceiptDocument value = (CashOfficeReceiptDocument)newValue;
                        #region CASHOFFICERECEIPTDOCUMENT_SetParentScript
                        if (value != null)
                            value.AccountAction = this;
                        #endregion CASHOFFICERECEIPTDOCUMENT_SetParentScript
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

            //if (CashOfficeReceiptDocument.DocumentNo == null && PaymentType != PaymentTypEnum.Bank/*CashOfficeReceiptDocument.MoneyReceivedType.IsBankOperation != true*/)
            //throw new TTUtils.TTException(SystemMessage.GetMessage(188));

            if (TotalPrice == null)
                throw new TTUtils.TTException(SystemMessage.GetMessage(114));
            CashOfficeReceiptDocument.CheckPaymentType<MainCashOfficeOperation>();
            if (CashOfficeReceiptDocument.PaymentType == PaymentTypeEnum.Bank)
            {
                if (CashOfficeReceiptDocument.BankDecount.BankAccount == null)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(189));

                if (string.IsNullOrEmpty(CashOfficeReceiptDocument.BankDecount.DecountNo))
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25234", "Bankadan Para Transferi için Dekont Numarası boş olamaz."));

                if (!CashOfficeReceiptDocument.BankDecount.DecountDate.HasValue)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25235", "Bankadan Para Transferi için Dekont Tarihi boş olamaz."));
            }

            //CashOfficeReceiptDocumentGroup rdg = CashOfficeReceiptDocument.AddDocumentGroup("T", "Vezne Tahsilat");
            //rdg.AddDocumentDetail(!string.IsNullOrEmpty(this.Description) ? this.Description : "Vezne Tahsilat", 1, (double)this.TotalPrice);
            //rdg.AccountDocumentDetails[0].CurrentStateDefID = CashOfficeReceiptDocumentDetail.States.Paid;

            CashOfficeReceiptDocument.CurrentStateDefID = CashOfficeReceiptDocument.States.Paid;
            CashOfficeReceiptDocument.TotalPrice = TotalPrice;
            CashOfficeReceiptDocument.SendToAccounting = false;

            // Tahvil ve Teminat Mektubu için Menkul Kıymetler alındısı dökülür. Bu makbuzun da numarası başka bir sıra takip eder. Bankadan Para Transferi için de numara ilerlemeyecek..
            if (CashOfficeReceiptDocument.PaymentType != PaymentTypeEnum.Bank)
            {
                ReceiptCashOfficeDefinition selectedRCODef = ReceiptCashOfficeDefinition.GetByCashOffice(ObjectContext, CashOfficeReceiptDocument.CashOffice.ObjectID.ToString()).OrderBy(x => x.OrderNo.Value).Where(x => x.IsActive == true).FirstOrDefault();

                if (selectedRCODef == null)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25347", "Bu vezne için tanımlanmış aktif bir vezne alındı numarası bulunamadı."));

                ((ITTObject)CashOfficeReceiptDocument.BankDecount).Delete();
                CashOfficeReceiptDocument.BankDecount = null;

                switch (CashOfficeReceiptDocument.PaymentType)
                {
                    case PaymentTypeEnum.Cash:
                        {
                            Cash cash = new Cash(ObjectContext) { Price = TotalPrice, CurrencyType = CurrencyTypeDefinition.GetByQref(ObjectContext, "TL")[0], AccountDocument = CashOfficeReceiptDocument };
                            CashOfficeReceiptDocument.CashPayment.Add(cash);
                            selectedRCODef = ReceiptCashOfficeDefinition.AutoActiveDeActivateReceiptCashOfficeDef(selectedRCODef);
                            CashOfficeReceiptDocument.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(selectedRCODef);
                            ReceiptCashOfficeDefinition.SetNextReceiptNumber(selectedRCODef);
                        }
                        break;
                    case PaymentTypeEnum.CreditCard:
                        {
                            CreditCard creditCard = new CreditCard(ObjectContext) { Price = TotalPrice, AccountDocument = CashOfficeReceiptDocument };
                            CashOfficeReceiptDocument.CreditCardPayments.Add(creditCard);
                            selectedRCODef = ReceiptCashOfficeDefinition.AutoActiveDeActivateReceiptCashOfficeDef(selectedRCODef);
                            CashOfficeReceiptDocument.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentCreditCardReceiptNumber(selectedRCODef);
                            ReceiptCashOfficeDefinition.SetNextCreditCardReceiptNumber(selectedRCODef);
                        }
                        break;
                    default:
                        break;
                }

                CashOfficeReceiptDocument.SpecialNo.GetNextValue(CashOfficeReceiptDocument.ResUser.ID.ToString(), Common.RecTime().Year);
            }
            else
            {
                CashOfficeReceiptDocument.BankDecount.Price = TotalPrice;
            }

            CreateAccountVoucher();

            // Bankadan Para Transferi için özel numara da ilerlemeyecek..

            // Sayman Mutemedi Teslimatı için teslim edilen CashierLog ların stateleri teslim edildi yapılıyor.
            /*if (this.CashOfficeReceiptDocument.MoneyReceivedType.IsSubCashOfficePayment == true)
            {
                ResUser user = null;
                bool multipleUserExists = false;

                foreach(SubmittedCashierLog myLogs in this.SubmittedCashierLogs)
                {
                    if((bool)myLogs.Submit)
                    {
                        myLogs.CashierLog.CurrentStateDefID = CashierLog.States.Submitted;
                        //this.CashOfficeReceiptDocument.AddAPRTransaction((AccountPayableReceivable)myLogs.CashierLog.ResUser.MyAPR(),(double)(myLogs.SubmittedTotal * -1) , (APRTrxType)APRTrxType.GetByType(this.ObjectContext, 14)[0]);
                        
                        if (user == null)
                            user = myLogs.CashierLog.ResUser;
                        else
                        {
                            if(user != myLogs.CashierLog.ResUser)
                                multipleUserExists = true;
                        }
                    }
                }
                
                if (multipleUserExists)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(190));
            }*/

            // Vezne Tahsilat işlemi hemen muhasebeleştiriliyor
            /*if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
             {
                 IList<AccountDocument.ReceiptInfo> ReceiptList = new List<AccountDocument.ReceiptInfo>();
                 AccountDocument.ReceiptInfo RI;

                 if (this.CashOfficeReceiptDocument.MoneyReceivedType.IsSubCashOfficePayment == true)
                 {
                     IList accDocs;
                     foreach (SubmittedCashierLog myLogs in this.SubmittedCashierLogs)
                     {
                         if ((bool)myLogs.Submit)
                         {
                             accDocs = null;
                             accDocs = AccountDocument.GetAllAccDocsByCashierLog(this.ObjectContext, myLogs.CashierLog.ObjectID.ToString());
                             foreach (AccountDocument accDoc in accDocs)
                             {
                                 RI = null;

                                 if (accDoc is ReceiptDocument)
                                 {
                                     ReceiptDocument receiptDocument = (ReceiptDocument)accDoc;
                                     if (receiptDocument.CurrentStateDefID == ReceiptDocument.States.Paid)
                                     {
                                         if (receiptDocument.GetCalculatedCashPayment(Convert.ToDateTime(receiptDocument.DocumentDate)) > 0 && receiptDocument.GetCalculatedNonCashPayment() == 0)
                                             RI = receiptDocument.CreateReceiptInfoForAccounting();
                                         else if (receiptDocument.GetCalculatedCashPayment(Convert.ToDateTime(receiptDocument.DocumentDate)) > 0 && receiptDocument.GetCalculatedNonCashPayment() > 0)
                                             RI = receiptDocument.CreateCashReceiptInfoForAccounting();
                                     }
                                 }
                                 else if (accDoc is AdvanceDocument)
                                 {
                                     AdvanceDocument advanceDocument = (AdvanceDocument)accDoc;
                                     if (advanceDocument.CurrentStateDefID == AdvanceDocument.States.Paid)
                                     {
                                         if (advanceDocument.GetCalculatedCashPayment(Convert.ToDateTime(advanceDocument.DocumentDate)) > 0 && advanceDocument.GetCalculatedNonCashPayment() == 0)
                                             RI = advanceDocument.CreateReceiptInfoForAccounting();
                                         else if (advanceDocument.GetCalculatedCashPayment(Convert.ToDateTime(advanceDocument.DocumentDate)) > 0 && advanceDocument.GetCalculatedNonCashPayment() > 0)
                                             RI = advanceDocument.CreateCashReceiptInfoForAccounting();
                                     }
                                 }
                                 else if (accDoc is DebenturePaymentDocument)
                                 {
                                     DebenturePaymentDocument debenturePaymentDocument = (DebenturePaymentDocument)accDoc;
                                     if (debenturePaymentDocument.CurrentStateDefID == DebenturePaymentDocument.States.Paid)
                                     {
                                         if (debenturePaymentDocument.GetCalculatedCashPayment(Convert.ToDateTime(debenturePaymentDocument.DocumentDate)) > 0 && debenturePaymentDocument.GetCalculatedNonCashPayment() == 0)
                                             RI = debenturePaymentDocument.CreateReceiptInfoForAccounting();
                                         else if (debenturePaymentDocument.GetCalculatedCashPayment(Convert.ToDateTime(debenturePaymentDocument.DocumentDate)) > 0 && debenturePaymentDocument.GetCalculatedNonCashPayment() > 0)
                                             RI = debenturePaymentDocument.CreateCashReceiptInfoForAccounting();
                                     }
                                 }
                                 else if (accDoc is SubCashOfficeReceiptDoc)
                                 {
                                     SubCashOfficeReceiptDoc receiptDoc = (SubCashOfficeReceiptDoc)accDoc;
                                     if (receiptDoc.CurrentStateDefID == SubCashOfficeReceiptDoc.States.Paid)
                                     {
                                         if (receiptDoc.GetCalculatedCashPayment(Convert.ToDateTime(receiptDoc.DocumentDate)) > 0 && receiptDoc.GetCalculatedNonCashPayment() == 0)
                                             RI = receiptDoc.CreateReceiptInfoForAccounting();
                                         else if (receiptDoc.GetCalculatedCashPayment(Convert.ToDateTime(receiptDoc.DocumentDate)) > 0 && receiptDoc.GetCalculatedNonCashPayment() > 0)
                                             RI = receiptDoc.CreateCashReceiptInfoForAccounting();
                                     }
                                 }
                                 else if (accDoc is GeneralReceiptDocument)
                                 {
                                     GeneralReceiptDocument generalReceiptDoc = (GeneralReceiptDocument)accDoc;
                                     if (generalReceiptDoc.CurrentStateDefID == GeneralReceiptDocument.States.Paid)
                                     {
                                         if (generalReceiptDoc.GetCalculatedCashPayment(Convert.ToDateTime(generalReceiptDoc.DocumentDate)) > 0 && generalReceiptDoc.GetCalculatedNonCashPayment() == 0)
                                             RI = generalReceiptDoc.CreateReceiptInfoForAccounting();
                                         else if (generalReceiptDoc.GetCalculatedCashPayment(Convert.ToDateTime(generalReceiptDoc.DocumentDate)) > 0 && generalReceiptDoc.GetCalculatedNonCashPayment() > 0)
                                             RI = generalReceiptDoc.CreateCashReceiptInfoForAccounting();
                                     }
                                 }

                                 if (RI != null)
                                 {
                                     ReceiptList.Add(RI);
                                     accDoc.SendToAccounting = true;
                                 }
                             }
                         }
                     }

                 if (ReceiptList.Count > 0)
                 {
                     TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "Invoice.Integration", "InvoiceUtils", "CreateReceipt", null, ReceiptList);
                 }
             }
                 //else
                 //{
                 RI = this.CashOfficeReceiptDocument.CreateReceiptInfoForAccounting();

                 if (RI != null)
                 {
                     ReceiptList.Add(RI);
                     this.CashOfficeReceiptDocument.SendToAccounting = true;
                 }

                 if (ReceiptList.Count > 0)
                 {
                     TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "Invoice.Integration", "InvoiceUtils", "CreateReceipt", null, ReceiptList);
                 }
                 //}
             }*/

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

            ResUser currentResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;

            //CashierLog myCashierLog = this.CashOfficeReceiptDocument.CashierLog;
            //if (myCashierLog == null)
            //throw new TTUtils.TTException(SystemMessage.GetMessage(191));
            // else
            // {
            //if (myCashierLog.ClosingDate != null)
            //throw new TTUtils.TTException(SystemMessage.GetMessage(192));
            //else
            //{
            if (CashOfficeReceiptDocument.ResUser.ObjectID == currentResUser.ObjectID)
                CashOfficeReceiptDocument.Cancel();
            else
                throw new TTUtils.TTException(SystemMessage.GetMessage(193));

            CancelAccountVoucher();

            // Sayman Mutemedi Teslimatı için teslim edilen CashierLog ların stateleri yeniden kapatılıyor.
            //if (this.CashOfficeReceiptDocument.MoneyReceivedType.IsSubCashOfficePayment == true)
            //{
            //foreach (SubmittedCashierLog myLogs in this.SubmittedCashierLogs)
            //{
            //if ((bool)myLogs.Submit)
            //{
            // myLogs.CashierLog.CurrentStateDefID = CashierLog.States.Closed;
            //this.CashOfficeReceiptDocument.AddAPRTransaction((AccountPayableReceivable)myLogs.CashierLog.ResUser.MyAPR(),(double)(myLogs.SubmittedTotal) , (APRTrxType)APRTrxType.GetByType(this.ObjectContext, 10)[0]);
            // }
            //}
            //}
            //}

            //}
            //}
        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MainCashOfficeOperation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MainCashOfficeOperation.States.New && toState == MainCashOfficeOperation.States.Completed)
                PostTransition_New2Completed();
            else if (fromState == MainCashOfficeOperation.States.Completed && toState == MainCashOfficeOperation.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MainCashOfficeOperation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MainCashOfficeOperation.States.New && toState == MainCashOfficeOperation.States.Completed)
                UndoTransition_New2Completed(transDef);
            else if (fromState == MainCashOfficeOperation.States.Completed && toState == MainCashOfficeOperation.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
        }

        //Eskiden Relation zorululuğundan kurtulmak için yazıldı. auto.cs ile gerek kalmadı.
        //protected override void OnBeforeImportFromObject(DataRow dataRow)
        //{
        //    base.OnBeforeImportFromObject(dataRow);

        //    dataRow["CASHOFFICERECEIPTDOCUMENT"] = DBNull.Value;
        //}

        public void PrepareNewMainCashOfficeOperation()
        {
            if (CurrentStateDefID == MainCashOfficeOperation.States.New)
            {
                ResUser resUser = TTUser.CurrentUser.UserObject as ResUser;
                CashOfficeDefinition selectedCashOffice = ResUser.SelectCurrentUserCashOffice(CashOfficeTypeEnum.CashOffice, resUser);

                if (selectedCashOffice == null)
                    throw new TTException(TTUtils.CultureService.GetText("M25323", "Bu kullanıcı için tanımlı bir vezne yok ya da Diğer Tahsilatları yapmaya yetikiniz bulunmamaktadır!"));

                ReceiptCashOfficeDefinition selectedRCODef = ReceiptCashOfficeDefinition.GetActiveCashOfficeDefinition(ObjectContext, selectedCashOffice.ObjectID);

                //TotalPrice = 0;
                CashOfficeName = selectedCashOffice.Name;

                if (CashOfficeReceiptDocument == null)
                {
                    CashOfficeReceiptDocument = new CashOfficeReceiptDocument(ObjectContext);
                    CashOfficeReceiptDocument.ResUser = resUser;
                    CashOfficeReceiptDocument.CashOffice = selectedCashOffice;
                    CashOfficeReceiptDocument.DocumentDate = Common.RecTime();
                    CashOfficeReceiptDocument.PaymentType = PaymentTypeEnum.Cash;
                    CashOfficeReceiptDocument.CurrentStateDefID = CashOfficeReceiptDocument.States.New;

                    if (selectedRCODef != null)
                        CashOfficeReceiptDocument.DocumentNo = ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(selectedRCODef);

                    CashOfficeReceiptDocument.BankDecount = new BankDecount(ObjectContext);
                    CashOfficeReceiptDocument.BankDecount.AccountDocument = CashOfficeReceiptDocument;

                    //ReceiptCashOfficeDefinition _myReceiptCashOfficeDefinition;
                    //IList myList = ReceiptCashOfficeDefinition.GetByCashOffice(ObjectContext, selectedCashOffice.ObjectID.ToString());

                    //_myReceiptCashOfficeDefinition = (ReceiptCashOfficeDefinition)ObjectContext.QueryObjects("ReceiptCashOfficeDefinition", "CASHOFFICE = '" + selectedCashOffice.ObjectID + "'")[0];

                }
            }
        }

        public void CreateAccountVoucher()
        {
            if (SystemParameter.GetParameterValue("CREATEACCOUNTVOUCHERFORCASHOFFICE", "TRUE") == "TRUE")
            {
                string code = CashOfficeReceiptDocument?.MoneyReceivedType?.RevenueSubAccountCode?.AccountCode;
                if (string.IsNullOrWhiteSpace(code))
                    throw new TTException("Gelir İşlemi oluşturmak için Vezne Tahsilat Türünün hesap kodu kırınımı tanımlı değil.");

                AccountPeriodDefinition accountPeriodDefinition = AccountPeriodDefinition.GetByDate(ObjectContext, CashOfficeReceiptDocument.DocumentDate.Value);
                AccountVoucherCodeDefinition accountVoucherCodeDefinition = AccountVoucherCodeDefinition.GetByCode(ObjectContext, code);
                AccountVoucher accountVoucher = AccountVoucher.GetOrCreateForCashOffice(ObjectContext, accountPeriodDefinition, accountVoucherCodeDefinition);
                accountVoucher.AddDetail(TotalPrice, CashOfficeReceiptDocument);
            }
        }

        public void CancelAccountVoucher()
        {
            foreach (AccountVoucherDetail avDetail in CashOfficeReceiptDocument.AccountVoucherDetails)
                avDetail.Cancel();
        }
    }
}