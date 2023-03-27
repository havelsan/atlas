
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
    /// Avans Alındısı
    /// </summary>
    public partial class AdvanceDocument : AccountDocument
    {
        #region Methods
        public AdvanceDocumentGroup AddDocumentGroup(string pCode, string pDesc)
        {
            AdvanceDocumentGroup adg = new AdvanceDocumentGroup(ObjectContext);

            adg.GroupCode = pCode;
            adg.GroupDescription = pDesc;
            adg.AccountDocument = this;
            AdvanceDocumentGroups.Add(adg);
            return adg;
        }

        public void Cancel()
        {
            if (CurrentStateDefID != AdvanceDocument.States.Cancelled)
            {
                //Document APR larına ters kayıt olustur
                if (Used == true)
                {
                    throw new Exception(TTUtils.CultureService.GetText("M26647", "Ödeme için kullanılan avans İptal edilemez!"));
                }
                Dictionary<string, APRTrx> dict = new Dictionary<string, APRTrx>();
                foreach (APRTrx myAPRTrx in APRTrx)
                {
                    dict.Add("myAPRTrx", myAPRTrx);
                }
                foreach (KeyValuePair<string, APRTrx> myAPRTrx in dict)
                {
                    APRTrx app = myAPRTrx.Value;
                    AddAPRTransaction(app.AccountPayableReceivable, (double)(app.Price * -1), APRTrxType.GetByType(ObjectContext, 10)[0]); // 10 Belge Iptali
                }

                /*foreach (AdvanceDocumentGroup advGroup in this.AdvanceDocumentGroups)
                {
                    foreach (AdvanceDocumentDetail advDetail in advGroup.AdvanceDocumentDetails)
                    {
                        advDetail.CurrentStateDefID = AdvanceDocumentDetail.States.Cancelled;
                    }
                }*/
                foreach (PatientPaymentDetail ppDetail in PatientPaymentDetail)
                {
                    if (ppDetail.AccountTransaction != null)
                        ppDetail.IsCancel = true;
                }
                CurrentStateDefID = AdvanceDocument.States.Cancelled;
                CancelDate = Common.RecTime();
                // senetlerin state i Cancelled yapılır
                /*foreach (Debenture db in this.DebenturePayments)
                {
                    db.CurrentStateDefID = Debenture.States.Cancelled ;
                }*/
                //this.CreateReceiptInfoAndSendToAccounting(); // muhasebeye ters fiş oluşturup gönderir
            }
        }

        override protected void OnConstruct()
        {
            ITTObject ttObject = (ITTObject)this;
            if (ttObject.IsNew)
            {
                if (CurrentStateDefID == null)
                    CurrentStateDefID = AdvanceDocument.States.New;
            }

        }

        public AccountDocument.ReceiptInfo CreateReceiptInfoForAccounting()
        {
            AccountDocument.ReceiptInfo RI = null;

            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if (CurrentStateDefID == AdvanceDocument.States.Paid && SendToAccounting == false)
                {
                    RI = new AccountDocument.ReceiptInfo();
                    CreateBasicReceiptInfo(ref RI);
                    RI.Type = AccountDocument.ReceiptTypeEnum.Avans;
                    RI.TotalPrice = (double)EpisodeAccountAction.TotalPrice;
                    if (CreditCardPayments.Count > 0)
                    {
                        if (CashPayment.Count > 0)
                            RI.No = RI.No + " , " + CreditCardDocumentNo;
                        else
                            RI.No = CreditCardDocumentNo;
                    }

                    RI.Lines = new List<AccountDocument.ReceiptLine>();

                    AccountDocument.ReceiptLine rLine = new AccountDocument.ReceiptLine();
                    rLine.Description = TTUtils.CultureService.GetText("M25804", "Hasta Tedavi Avansı");
                    rLine.AccountCode = GetAccountCode(AccountEntegrationAccountTypeEnum.AvansHesabi);
                    rLine.IsDebt = false;
                    rLine.Price = (double)EpisodeAccountAction.TotalPrice;
                    rLine.CurrencyRate = 1;
                    RI.Lines.Add(rLine);

                    CreateReceiptPaymentDetailInfo(ref RI.Lines, true, ReceiptPaymentTypeEnum.All);
                    CreateReceiptLineObjectIDs(RI);
                    ControlReceiptInfo(RI, TTUtils.CultureService.GetText("M11248", "Avans"));
                }
            }
            return RI;
        }

        public AccountDocument.ReceiptInfo CreateNonCashReceiptInfoForAccounting()
        {
            AccountDocument.ReceiptInfo RI = null;

            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if (CurrentStateDefID == AdvanceDocument.States.Paid && SendToAccounting == false)
                {
                    RI = new AccountDocument.ReceiptInfo();
                    CreateBasicReceiptInfo(ref RI);
                    RI.ObjectId = RI.ObjectId + "-1";
                    RI.Type = AccountDocument.ReceiptTypeEnum.Avans;
                    RI.TotalPrice = (double)GetCalculatedNonCashPayment();

                    if (CreditCardDocumentNo != null)
                        RI.No = CreditCardDocumentNo;
                    else
                        RI.No = " ";

                    RI.Lines = new List<AccountDocument.ReceiptLine>();

                    AccountDocument.ReceiptLine rLine = new AccountDocument.ReceiptLine();
                    rLine.Description = TTUtils.CultureService.GetText("M25804", "Hasta Tedavi Avansı");
                    rLine.AccountCode = GetAccountCode(AccountEntegrationAccountTypeEnum.AvansHesabi);
                    rLine.IsDebt = false;
                    rLine.Price = (double)GetCalculatedNonCashPayment();
                    rLine.CurrencyRate = 1;
                    RI.Lines.Add(rLine);

                    CreateReceiptPaymentDetailInfo(ref RI.Lines, true, ReceiptPaymentTypeEnum.NonCash);
                    CreateReceiptLineObjectIDs(RI);
                    ControlReceiptInfo(RI, TTUtils.CultureService.GetText("M11248", "Avans"));
                }
            }
            return RI;
        }

        public AccountDocument.ReceiptInfo CreateCashReceiptInfoForAccounting()
        {
            AccountDocument.ReceiptInfo RI = null;

            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if (CurrentStateDefID == AdvanceDocument.States.Paid)
                {
                    RI = new AccountDocument.ReceiptInfo();
                    CreateBasicReceiptInfo(ref RI);
                    RI.ObjectId = RI.ObjectId + "-2";
                    RI.Type = AccountDocument.ReceiptTypeEnum.Avans;
                    RI.TotalPrice = (double)GetCalculatedCashPayment(Convert.ToDateTime(DocumentDate));

                    RI.Lines = new List<AccountDocument.ReceiptLine>();

                    AccountDocument.ReceiptLine rLine = new AccountDocument.ReceiptLine();
                    rLine.Description = TTUtils.CultureService.GetText("M25804", "Hasta Tedavi Avansı");
                    rLine.AccountCode = GetAccountCode(AccountEntegrationAccountTypeEnum.AvansHesabi);
                    rLine.IsDebt = false;
                    rLine.Price = (double)GetCalculatedCashPayment(Convert.ToDateTime(DocumentDate));
                    rLine.CurrencyRate = 1;
                    RI.Lines.Add(rLine);

                    CreateReceiptPaymentDetailInfo(ref RI.Lines, true, ReceiptPaymentTypeEnum.Cash);
                    CreateReceiptLineObjectIDs(RI);
                    ControlReceiptInfo(RI, TTUtils.CultureService.GetText("M11248", "Avans"));
                }
            }
            return RI;
        }

        #endregion Methods

    }
}