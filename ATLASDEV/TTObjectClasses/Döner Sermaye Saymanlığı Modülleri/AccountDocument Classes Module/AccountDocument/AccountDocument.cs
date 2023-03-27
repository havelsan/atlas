
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
    /// Finansal Döküman türlerinin ana sınıfıdır
    /// </summary>
    public partial class AccountDocument : TTObject
    {
        public partial class GetUnpaidAccDocs_Class : TTReportNqlObject
        {
        }

        public partial class GetAccDocsByCasLogAndCash_Class : TTReportNqlObject
        {
        }

        public partial class GetCancelledInvoices_Class : TTReportNqlObject
        {
        }

        public partial class GetCancelledReceipts_Class : TTReportNqlObject
        {
        }

        public partial class DenemeUnıion_Class : TTReportNqlObject
        {
        }

        public partial class GetMainCashOfficeDocsByCasLog_Class : TTReportNqlObject
        {
        }

        public partial class GetAccDocsByCasLogAndCrdCard_Class : TTReportNqlObject
        {
        }

        public partial class GetSubCashOfficeAccDocsByDate_Class : TTReportNqlObject
        {
        }

        public partial class Deneme2GroupBy_Class : TTReportNqlObject
        {
        }

        public partial class GetBackDocumentByDate_Class : TTReportNqlObject
        {
        }

        #region Methods

        public void CheckPaymentType<T>() where T : class
        {
            if (!PaymentType.HasValue)
                throw new TTException(TTUtils.CultureService.GetText("M26649", "Ödeme tipi boş geçilemez!"));
            switch (typeof(T).Name)
            {
                case "Advance":
                case "Receipt":
                    if (PaymentType.Value != PaymentTypeEnum.Cash && PaymentType.Value != PaymentTypeEnum.CreditCard)
                        throw new TTException(TTUtils.CultureService.GetText("M25689", "Geçersiz bir ödeme tipi seçtiniz!"));
                    break;
                case "MainCashOfficeOperation":
                case "BondPayment":
                    if (PaymentType.Value != PaymentTypeEnum.Cash && PaymentType.Value != PaymentTypeEnum.CreditCard && PaymentType.Value != PaymentTypeEnum.Bank)
                        throw new TTException(TTUtils.CultureService.GetText("M25689", "Geçersiz bir ödeme tipi seçtiniz!"));
                    break;
                default:
                    throw new TTException(TTUtils.CultureService.GetText("M25692", "Geçersiz nesne adı!"));
            }
        }

        public AccountDocumentGroup AddDocumentGroup(string pCode, string pDesc)
        {
            AccountDocumentGroup adg = new AccountDocumentGroup(ObjectContext);

            adg.GroupCode = pCode;
            adg.GroupDescription = pDesc;
            adg.AccountDocument = this;
            AccountDocumentGroups.Add(adg);
            return adg;
        }

        public void AddAPRTransaction(AccountPayableReceivable pAPR, Currency? pPrice, APRTrxType pAPRTrxType)
        {

            APRTrx aprTrx = new APRTrx(ObjectContext);
            aprTrx.AccountDocument = this;
            aprTrx.Price = pPrice;
            aprTrx.APRTrxType = pAPRTrxType;
            aprTrx.AccountPayableReceivable = pAPR;
            aprTrx.AccountPayableReceivable.UpdateBalance(pPrice);
            APRTrx.Add(aprTrx);
        }

        public double GetTotalPayment()
        {
            double totalPayment = 0;
            bool isDefaultCurrency = true;
            CurrencyTypeDefinition defaultCurrency = null;

            IList defaultCurrenyList = CurrencyTypeDefinition.GetByQref(ObjectContext, "TL");

            if (defaultCurrenyList.Count != 0)
            {
                foreach (CurrencyTypeDefinition curType in defaultCurrenyList)
                {
                    defaultCurrency = curType;
                    break;
                }
            }

            foreach (CreditCard creditPay in CreditCardPayments)
            {
                if (creditPay.Price != null)
                    totalPayment = totalPayment + (double)creditPay.Price;
            }
            foreach (BankDecount bankPay in BankDecountPayments)
            {
                if (bankPay.Price != null)
                    totalPayment = totalPayment + (double)bankPay.Price;
            }
            foreach (Debenture debenturePay in DebenturePayments)
            {
                if (debenturePay.Price != null)
                    totalPayment = totalPayment + (double)debenturePay.Price;
            }
            foreach (Cheque chequePay in ChequePayments)
            {
                if (chequePay.Price != null)
                    totalPayment = totalPayment + (double)chequePay.Price;
            }
            foreach (ValuablePaper valuablePaperPay in ValuablePaperPayments)
            {
                if (valuablePaperPay.Price != null)
                    totalPayment = totalPayment + (double)valuablePaperPay.Price;
            }
            foreach (Cash cashPay in CashPayment)
            {
                if (cashPay.Price != null)
                {
                    if (defaultCurrency != (CurrencyTypeDefinition)cashPay.CurrencyType)
                    {
                        string sDate = Common.RecTime().ToString("yyyy-MM-dd 00:00:00");
                        string eDate = Common.RecTime().ToString("yyyy-MM-dd 23:59:59");
                        string curRateType = TTObjectClasses.SystemParameter.GetParameterValue("FOREIGNCURRENCYPAYMENTRATETYPE", "");

                        IList curRateList = DailyRateDefinition.GetDailyRateByDateAndCurrType(ObjectContext, cashPay.CurrencyType.ObjectID.ToString(), Convert.ToDateTime(sDate), Convert.ToDateTime(eDate), curRateType.ToString());
                        if (curRateList.Count == 0)
                        {
                            String message = SystemMessage.GetMessage(471);
                            throw new TTUtils.TTException(message);
                        }
                        else
                        {
                            foreach (DailyRateDefinition myRate in curRateList)
                            {
                                totalPayment = totalPayment + (double)cashPay.Price * (double)myRate.DailyRate;
                                break;
                            }
                        }
                    }
                    else
                        totalPayment = totalPayment + (double)cashPay.Price;
                }
            }
            return totalPayment;
        }

        public double GetCalculatedNonCashPayment()
        {
            double totalPayment = 0;

            foreach (CreditCard creditPay in CreditCardPayments)
                totalPayment = totalPayment + (double)creditPay.Price;

            foreach (BankDecount bankPay in BankDecountPayments)
                totalPayment = totalPayment + (double)bankPay.Price;

            foreach (Debenture debenturePay in DebenturePayments)
                totalPayment = totalPayment + (double)debenturePay.Price;

            foreach (Cheque chequePay in ChequePayments)
                totalPayment = totalPayment + (double)chequePay.Price;

            foreach (ValuablePaper valuablePaperPay in ValuablePaperPayments)
                totalPayment = totalPayment + (double)valuablePaperPay.Price;

            return totalPayment;
        }

        public double GetCalculatedCreditCardPayment()
        {
            double totalCreditCardPayment = 0;

            foreach (CreditCard creditPay in CreditCardPayments)
                totalCreditCardPayment += (double)creditPay.Price;

            return totalCreditCardPayment;
        }

        public double GetCalculatedCashPayment(DateTime currencyDate)
        {
            double totalCashPayment = 0;
            bool isDefaultCurrency = true;
            CurrencyTypeDefinition defaultCurrency = null;


            IList defaultCurrenyList = CurrencyTypeDefinition.GetByQref(ObjectContext, "TL");

            if (defaultCurrenyList.Count != 0)
            {
                foreach (CurrencyTypeDefinition curType in defaultCurrenyList)
                {
                    defaultCurrency = curType;
                    break;
                }
            }

            foreach (Cash cashPay in CashPayment)
            {

                if (defaultCurrency != (CurrencyTypeDefinition)cashPay.CurrencyType)
                {
                    string sDate = currencyDate.ToString("yyyy-MM-dd 00:00:00");
                    string eDate = currencyDate.ToString("yyyy-MM-dd 23:59:59");
                    string curRateType = TTObjectClasses.SystemParameter.GetParameterValue("FOREIGNCURRENCYPAYMENTRATETYPE", "");

                    IList curRateList = DailyRateDefinition.GetDailyRateByDateAndCurrType(ObjectContext, cashPay.CurrencyType.ObjectID.ToString(), Convert.ToDateTime(sDate), Convert.ToDateTime(eDate), curRateType.ToString());
                    if (curRateList.Count == 0)
                    {
                        String message = SystemMessage.GetMessage(484);
                        throw new TTUtils.TTException(message);
                    }
                    else
                    {
                        foreach (DailyRateDefinition myRate in curRateList)
                        {
                            totalCashPayment = totalCashPayment + (double)cashPay.Price * (double)myRate.DailyRate;
                            break;
                        }
                    }
                }
                else
                    totalCashPayment = totalCashPayment + (double)cashPay.Price;
            }
            return totalCashPayment;
        }

        public virtual void Cancel()
        {

            //Document APR larına ters kayıt olustur
            IList listAPRTrx = APRTrx;
            foreach (APRTrx myAPRTrx in listAPRTrx)
            {
                AddAPRTransaction(myAPRTrx.AccountPayableReceivable, (double)(myAPRTrx.Price * -1), APRTrxType.GetByType(ObjectContext, 10)[0]); // 10 Belge Iptali
            }

            foreach (AccountDocumentGroup accGroup in AccountDocumentGroups)
            {
                foreach (AccountDocumentDetail accDetail in accGroup.AccountDocumentDetails)
                {
                    if (accDetail.AccountTrxDocument[0] != null)
                    {
                        accDetail.AccountTrxDocument[0].AccountTransaction.CurrentStateDefID = AccountTransaction.States.New;
                    }
                    accDetail.CurrentStateDefID = ReceiptDocumentDetail.States.Cancelled;
                }
            }
        }

        [LooselyTypeAttribute]
        [Serializable]
        public class InvoiceInfo
        {
            public string ObjectId;
            public DateTime invoiceDate;
            public string No;
            public string PayerName;
            public string Description;
            public InvoiceTypeEnum Type;
            public double TotalPrice;
            public List<AccountDocument.InvoiceLine> Lines;
        }

        [LooselyTypeAttribute]
        [Serializable]
        public class InvoiceLine
        {
            public string ObjectId;
            public string InvoiceId;
            public string Description;
            public string AccountCode;
            public bool IsDebt;
            public double Price;
            public double CurrencyRate;
        }

        [LooselyTypeAttribute]
        [Serializable]
        public class ReceiptInfo
        {
            public string ObjectId;
            public DateTime receiptDate;
            public string No;
            public string CashOfficeName;
            public string Description;
            public ReceiptTypeEnum Type;
            public double TotalPrice;
            public List<AccountDocument.ReceiptLine> Lines;
        }

        [LooselyTypeAttribute]
        [Serializable]
        public class ReceiptLine
        {
            public string ObjectId;
            public string ReceiptId;
            public string Description;
            public string AccountCode;
            public bool IsDebt;
            public double Price;
            public double CurrencyRate;
        }

        [LooselyTypeAttribute]
        [Serializable]
        public class PaymentInfo
        {
            public string ObjectId;
            public DateTime PaymentDate;
            public string PayerName;
            public string Description;
            public PayerPaymentTypeEnum Type;
            public double TotalPrice;
            public List<AccountDocument.PaymentLine> Lines;
        }

        [LooselyTypeAttribute]
        [Serializable]
        public class PaymentLine
        {
            public string ObjectId;
            public string PaymentId;
            public string Description;
            public string AccountCode;
            public bool IsDebt;
            public double Price;
            public double CurrencyRate;
        }

        [LooselyTypeAttribute]
        [Serializable]
        public class BankDelivery
        {
            public string ObjectId;
            public DateTime DeliveryDate;
            public string Description;
            public double Price;
            public string AccountCode;
            public string SerialNo;
            public string CashierName;
        }

        public enum ReceiptTypeEnum
        {
            Avans = 0,
            AvansIade = 1,
            MuhasebeYetkilisiMutemediAlindisi = 2,
            MuhasebeYetkilisiMutemediAlindisiIade = 3,
            SenetTahsilat = 4,
            VezneTahsilat = 5,
            VezneIade = 6,
            HastaYatisFinansalKontrol = 7
        }

        public enum InvoiceTypeEnum
        {
            SatisFaturasi = 0,
            AlisFaturasi = 1
        }

        public enum PayerPaymentTypeEnum
        {
            KurumFaturaTahsilat = 0,
            KurumAvansTahsilat = 1
        }

        public void CreateBasicInvoiceInfo(ref AccountDocument.InvoiceInfo i)
        {
            i.ObjectId = ObjectID.ToString();
            i.invoiceDate = (DateTime)DocumentDate;
            i.No = DocumentNo;
            if (i.No == null)
                i.No = " ";
            i.Type = AccountDocument.InvoiceTypeEnum.SatisFaturasi;

            if (EpisodeAccountAction != null)
                i.Description = "Hasta: " + EpisodeAccountAction.Episode.Patient.ID.ToString() + " " + EpisodeAccountAction.Episode.Patient.FullName.ToString() + " / H.Protokol No: " + EpisodeAccountAction.Episode.HospitalProtocolNo + " / İşlem No: " + EpisodeAccountAction.ID;
            else if (AccountAction != null)
                i.Description = "İşlem No: " + AccountAction.ID;
        }

        public void ControlInvoiceInfo(AccountDocument.InvoiceInfo invInfo, string invoiceName)
        {
            string actionId = "";
            if (EpisodeAccountAction != null)
                actionId = EpisodeAccountAction.ID.ToString();
            else if (AccountAction != null)
                actionId = AccountAction.ID.ToString();

            if (actionId != "")
                actionId = "(İşlem No : " + actionId + ")";

            string[] hataParamList = new string[] { "'Dönüş Tarih Saati'", "'Çıkış Tarih Saati'" };


            if (invInfo.Lines.Count == 0)
                throw new TTException(SystemMessage.GetMessageV3(493, new string[] { invoiceName.ToString(), actionId.ToString() }));

            // throw new TTException("Muhasebeye gönderilecek " + invoiceName + " bilgisinde hiç detay yok! " + actionId);

            double debtTotal = 0;
            double creditTotal = 0;

            foreach (AccountDocument.InvoiceLine iLine in invInfo.Lines)
            {
                if (iLine.AccountCode == null)
                    throw new TTException(SystemMessage.GetMessageV3(487, new string[] { invoiceName.ToString(), actionId.ToString() }));
                else
                {
                    if (iLine.AccountCode.Trim() == "")
                        throw new TTException(SystemMessage.GetMessageV3(487, new string[] { invoiceName.ToString(), actionId.ToString() }));
                }

                if (iLine.IsDebt == true)
                    debtTotal = debtTotal + (double)Math.Round((iLine.Price * iLine.CurrencyRate), 2);
                else
                    creditTotal = creditTotal + (double)Math.Round((iLine.Price * iLine.CurrencyRate), 2);
            }

            if (Math.Round(debtTotal, 2) != Math.Round(creditTotal, 2))
                throw new TTException(SystemMessage.GetMessageV3(489, new string[] { invoiceName.ToString(), actionId.ToString() }));
            //throw new TTException("Muhasebeye gönderilecek " + invoiceName + " bilgisinde borç/alacak tutarsızlığı var! " + actionId);
            else if (Math.Round(invInfo.TotalPrice, 2) != Math.Round(debtTotal, 2))
                throw new TTException(SystemMessage.GetMessageV3(491, new string[] { invoiceName.ToString(), actionId.ToString() }));
            //throw new TTException("Muhasebeye gönderilecek " + invoiceName + " tutarı ile borç tipindeki detayların toplamı eşit değil! " + actionId);
            else if (Math.Round(invInfo.TotalPrice, 2) != Math.Round(creditTotal, 2))
                throw new TTException(SystemMessage.GetMessageV3(491, new string[] { invoiceName.ToString(), actionId.ToString() }));
            //throw new TTException("Muhasebeye gönderilecek " + invoiceName + " tutarı ile alacak tipindeki detayların toplamı eşit değil! " + actionId);
        }

        public void CreateInvoiceLineObjectIDs(AccountDocument.InvoiceInfo invInfo)
        {
            int counter = 1;
            foreach (AccountDocument.InvoiceLine iLine in invInfo.Lines)
            {
                iLine.ObjectId = invInfo.ObjectId + "-" + counter.ToString();
                counter++;
            }
        }

        public void CreateBasicReceiptInfo(ref AccountDocument.ReceiptInfo r)
        {
            r.ObjectId = ObjectID.ToString();
            r.receiptDate = (DateTime)DocumentDate;
            r.No = DocumentNo;
            if (r.No == null)
                r.No = "";
            r.CashOfficeName = CashierLog.CashOffice.Name;

            if (EpisodeAccountAction != null)
                r.Description = "Hasta: " + EpisodeAccountAction.Episode.Patient.ID.ToString() + " " + EpisodeAccountAction.Episode.Patient.FullName.ToString() + " / H.Protokol No: " + EpisodeAccountAction.Episode.HospitalProtocolNo + " / İşlem No: " + EpisodeAccountAction.ID;
            else if (AccountAction != null)
                r.Description = "İşlem No: " + AccountAction.ID;
        }

        public void ControlReceiptInfo(AccountDocument.ReceiptInfo recInfo, string receiptName)
        {
            string actionId = "";
            if (EpisodeAccountAction != null)
                actionId = EpisodeAccountAction.ID.ToString();
            else if (AccountAction != null)
                actionId = AccountAction.ID.ToString();

            if (actionId != "")
                actionId = "(İşlem No : " + actionId + ")";

            if (recInfo.Lines.Count == 0)
                throw new TTException(SystemMessage.GetMessageV3(493, new string[] { receiptName.ToString(), actionId.ToString() }));
            //throw new TTException("Muhasebeye gönderilecek " + receiptName + " bilgisinde hiç detay yok! " + actionId) ;

            double debtTotal = 0;
            double creditTotal = 0;

            foreach (AccountDocument.ReceiptLine rLine in recInfo.Lines)
            {
                if (rLine.AccountCode == null)
                    throw new TTException(SystemMessage.GetMessageV3(487, new string[] { receiptName.ToString(), actionId.ToString() }));
                //  throw new TTException("Muhasebeye gönderilecek " + receiptName + " bilgisinde hesap kodu boş olan detay var! " + actionId);
                else
                {
                    if (rLine.AccountCode.Trim() == "")
                        throw new TTException(SystemMessage.GetMessageV3(487, new string[] { receiptName.ToString(), actionId.ToString() }));
                    //  throw new TTException("Muhasebeye gönderilecek " + receiptName + " bilgisinde hesap kodu boş olan detay var! " + actionId);
                }

                if (rLine.IsDebt == true)
                    debtTotal = debtTotal + (double)Math.Round((rLine.Price * rLine.CurrencyRate), 2);
                else
                    creditTotal = creditTotal + (double)Math.Round((rLine.Price * rLine.CurrencyRate), 2);
            }

            if (Math.Round(debtTotal, 2) != Math.Round(creditTotal, 2))
                throw new TTException(SystemMessage.GetMessageV3(489, new string[] { receiptName.ToString(), actionId.ToString() }));
            //  throw new TTException("Muhasebeye gönderilecek " + receiptName + " bilgisinde borç/alacak tutarsızlığı var! " + actionId);
            else if (Math.Round(recInfo.TotalPrice, 2) != Math.Round(debtTotal, 2))
                throw new TTException(SystemMessage.GetMessageV3(491, new string[] { receiptName.ToString(), actionId.ToString() }));
            //  throw new TTException("Muhasebeye gönderilecek " + receiptName + " tutarı ile borç tipindeki detayların toplamı eşit değil! " + actionId);
            else if (Math.Round(recInfo.TotalPrice, 2) != Math.Round(creditTotal, 2))
                throw new TTException(SystemMessage.GetMessageV3(491, new string[] { receiptName.ToString(), actionId.ToString() }));
            //  throw new TTException("Muhasebeye gönderilecek " + receiptName + " tutarı ile alacak tipindeki detayların toplamı eşit değil! " + actionId);
        }

        public void CreateReceiptLineObjectIDs(AccountDocument.ReceiptInfo recInfo)
        {
            int counter = 1;
            foreach (AccountDocument.ReceiptLine rLine in recInfo.Lines)
            {
                rLine.ObjectId = recInfo.ObjectId + "-" + counter.ToString();
                counter++;
            }
        }

        public void ControlPaymentInfo(AccountDocument.PaymentInfo payInfo, string paymentName)
        {

            if (payInfo.Lines.Count == 0)
                throw new TTException(SystemMessage.GetMessageV3(493, new string[] { paymentName.ToString(), "''" }));
            //  throw new TTException("Muhasebeye gönderilecek " + paymentName + " bilgisinde hiç detay yok!") ;

            double debtTotal = 0;
            double creditTotal = 0;

            foreach (AccountDocument.PaymentLine pLine in payInfo.Lines)
            {
                if (pLine.AccountCode == null)
                    throw new TTException(SystemMessage.GetMessageV3(487, new string[] { paymentName.ToString(), "''" }));
                //  throw new TTException("Muhasebeye gönderilecek " + paymentName + " bilgisinde hesap kodu boş olan detay var!");
                else
                {
                    if (pLine.AccountCode.Trim() == "")
                        throw new TTException(SystemMessage.GetMessageV3(487, new string[] { paymentName.ToString(), "''" }));
                    //  throw new TTException("Muhasebeye gönderilecek " + paymentName + " bilgisinde hesap kodu boş olan detay var!");
                }

                if (pLine.IsDebt == true)
                    debtTotal = debtTotal + (double)Math.Round((pLine.Price * pLine.CurrencyRate), 2);
                else
                    creditTotal = creditTotal + (double)Math.Round((pLine.Price * pLine.CurrencyRate), 2);
            }

            if (Math.Round(debtTotal, 2) != Math.Round(creditTotal, 2))
                throw new TTException(SystemMessage.GetMessageV3(489, new string[] { paymentName.ToString(), "''" }));
            //  throw new TTException("Muhasebeye gönderilecek " + paymentName + " bilgisinde borç/alacak tutarsızlığı var!");
            else if (Math.Round(payInfo.TotalPrice, 2) != Math.Round(debtTotal, 2))
                throw new TTException(SystemMessage.GetMessageV3(491, new string[] { paymentName.ToString(), "''" }));
            //  throw new TTException("Muhasebeye gönderilecek " + paymentName + " tutarı ile borç tipindeki detayların toplamı eşit değil!");
            else if (Math.Round(payInfo.TotalPrice, 2) != Math.Round(creditTotal, 2))
                throw new TTException(SystemMessage.GetMessageV3(491, new string[] { paymentName.ToString(), "''" }));
            // throw new TTException("Muhasebeye gönderilecek " + paymentName + " tutarı ile alacak tipindeki detayların toplamı eşit değil!");
        }

        public void CreatePaymentLineObjectIDs(AccountDocument.PaymentInfo payInfo)
        {
            int counter = 1;
            foreach (AccountDocument.PaymentLine pLine in payInfo.Lines)
            {
                pLine.ObjectId = payInfo.ObjectId + "-" + counter.ToString();
                counter++;
            }
        }

        public void CreateReceiptPaymentDetailInfo(ref List<AccountDocument.ReceiptLine> listRecLines, bool debtOrCredit, ReceiptPaymentTypeEnum paymentType)
        {
            bool isDefaultCurrency = true;
            CurrencyTypeDefinition defaultCurrency = null;

            IList defaultCurrenyList = CurrencyTypeDefinition.GetByQref(ObjectContext, "TL");

            if (defaultCurrenyList.Count != 0)
            {
                foreach (CurrencyTypeDefinition curType in defaultCurrenyList)
                {
                    defaultCurrency = curType;
                    break;
                }
            }

            if (paymentType == ReceiptPaymentTypeEnum.NonCash || paymentType == ReceiptPaymentTypeEnum.All)
            {
                foreach (CreditCard creditPay in CreditCardPayments)
                {
                    AccountDocument.ReceiptLine rLine = new AccountDocument.ReceiptLine();
                    rLine.Description = TTUtils.CultureService.GetText("M26342", "Kredi Kartı Ödemesi");
                    rLine.AccountCode = GetAccountCode(AccountEntegrationAccountTypeEnum.KrediKartiHesabi);
                    rLine.IsDebt = debtOrCredit;
                    rLine.Price = (double)creditPay.Price;
                    rLine.CurrencyRate = 1;
                    listRecLines.Add(rLine);
                }
                foreach (BankDecount bankPay in BankDecountPayments)
                {
                    AccountDocument.ReceiptLine rLine = new AccountDocument.ReceiptLine();    // Banka Hesabı bazında ayrılır
                    rLine.Description = TTUtils.CultureService.GetText("M25229", "Banka Ödemesi");
                    rLine.AccountCode = bankPay.BankAccount.AccountCode;  // Banka Hesap Tanım ekranındaki muhasebe kodu kullanılır
                    rLine.IsDebt = debtOrCredit;
                    rLine.Price = (double)bankPay.Price;
                    rLine.CurrencyRate = 1;
                    listRecLines.Add(rLine);
                }
                foreach (Debenture debenturePay in DebenturePayments)
                {
                    AccountDocument.ReceiptLine rLine = new AccountDocument.ReceiptLine();
                    rLine.Description = TTUtils.CultureService.GetText("M26839", "Senet İle Ödeme");
                    rLine.AccountCode = GetAccountCode(AccountEntegrationAccountTypeEnum.SenetHesabi);
                    rLine.IsDebt = debtOrCredit;
                    rLine.Price = (double)debenturePay.Price;
                    rLine.CurrencyRate = 1;
                    listRecLines.Add(rLine);
                }
                foreach (Cheque chequePay in ChequePayments)
                {
                    AccountDocument.ReceiptLine rLine = new AccountDocument.ReceiptLine();
                    rLine.Description = TTUtils.CultureService.GetText("M25377", "Çek İle Ödeme");
                    rLine.AccountCode = GetAccountCode(AccountEntegrationAccountTypeEnum.CekHesabi);
                    rLine.IsDebt = debtOrCredit;
                    rLine.Price = (double)chequePay.Price;
                    rLine.CurrencyRate = 1;
                    listRecLines.Add(rLine);
                }
            }

            if (paymentType == ReceiptPaymentTypeEnum.Cash || paymentType == ReceiptPaymentTypeEnum.All)
            {
                foreach (Cash cashPay in CashPayment)
                {
                    if (defaultCurrency != (CurrencyTypeDefinition)cashPay.CurrencyType)
                    {
                        string sDate = Convert.ToDateTime(DocumentDate).ToString("yyyy-MM-dd 00:00:00");
                        string eDate = Convert.ToDateTime(DocumentDate).ToString("yyyy-MM-dd 23:59:59");
                        string curRateType = TTObjectClasses.SystemParameter.GetParameterValue("FOREIGNCURRENCYPAYMENTRATETYPE", "");

                        IList curRateList = DailyRateDefinition.GetDailyRateByDateAndCurrType(ObjectContext, cashPay.CurrencyType.ObjectID.ToString(), Convert.ToDateTime(sDate), Convert.ToDateTime(eDate), curRateType.ToString());
                        if (curRateList.Count == 0)
                            throw new TTException(SystemMessage.GetMessageV3(495, new string[] { DocumentDate.ToString() }));
                        //  throw new TTException("Ödeme yapılmak istenen döviz için Günlük Kur Tanımı yapılmamış! (Kur Tarihi: " + this.DocumentDate.ToString() + ")");
                        else
                        {
                            AccountDocument.ReceiptLine rLine = new AccountDocument.ReceiptLine();
                            rLine.Description = TTUtils.CultureService.GetText("M25547", "Döviz İle Ödeme (")+ cashPay.CurrencyType.Qref + ")";
                            rLine.AccountCode = GetAccountCode(AccountEntegrationAccountTypeEnum.KasaDovizHesabi);
                            rLine.IsDebt = debtOrCredit;
                            rLine.Price = (double)cashPay.Price;

                            foreach (DailyRateDefinition myRate in curRateList)
                            {
                                rLine.CurrencyRate = (double)myRate.DailyRate;
                                break;
                            }
                            listRecLines.Add(rLine);
                        }
                    }
                    else
                    {
                        AccountDocument.ReceiptLine rLine = new AccountDocument.ReceiptLine();
                        rLine.Description = TTUtils.CultureService.GetText("M26567", "Nakit Ödeme");
                        rLine.AccountCode = GetAccountCode(AccountEntegrationAccountTypeEnum.KasaHesabi);
                        rLine.IsDebt = debtOrCredit;
                        rLine.Price = (double)cashPay.Price;
                        rLine.CurrencyRate = 1;
                        listRecLines.Add(rLine);
                    }
                }
            }
        }

        public void CreatePaymentDetailInfo(ref List<AccountDocument.PaymentLine> listPayLines, bool debtOrCredit)
        {
            bool isDefaultCurrency = true;
            CurrencyTypeDefinition defaultCurrency = null;

            IList defaultCurrenyList = CurrencyTypeDefinition.GetByQref(ObjectContext, "TL");

            if (defaultCurrenyList.Count != 0)
            {
                foreach (CurrencyTypeDefinition curType in defaultCurrenyList)
                {
                    defaultCurrency = curType;
                    break;
                }
            }

            foreach (CreditCard creditPay in CreditCardPayments)
            {
                AccountDocument.PaymentLine pLine = new AccountDocument.PaymentLine();
                pLine.Description = TTUtils.CultureService.GetText("M26342", "Kredi Kartı Ödemesi");
                pLine.AccountCode = GetAccountCode(AccountEntegrationAccountTypeEnum.KrediKartiHesabi);
                pLine.IsDebt = debtOrCredit;
                pLine.Price = (double)creditPay.Price;
                pLine.CurrencyRate = 1;
                listPayLines.Add(pLine);
            }
            foreach (BankDecount bankPay in BankDecountPayments)
            {
                AccountDocument.PaymentLine pLine = new AccountDocument.PaymentLine();    // Banka Hesabı bazında ayrılır
                pLine.Description = TTUtils.CultureService.GetText("M25229", "Banka Ödemesi");
                pLine.AccountCode = bankPay.BankAccount.AccountCode;  // Banka Hesap Tanım ekranındaki muhasebe kodu kullanılır
                pLine.IsDebt = debtOrCredit;
                pLine.Price = (double)bankPay.Price;
                pLine.CurrencyRate = 1;
                listPayLines.Add(pLine);
            }
            foreach (Debenture debenturePay in DebenturePayments)
            {
                AccountDocument.PaymentLine pLine = new AccountDocument.PaymentLine();
                pLine.Description = TTUtils.CultureService.GetText("M26839", "Senet İle Ödeme");
                pLine.AccountCode = GetAccountCode(AccountEntegrationAccountTypeEnum.SenetHesabi);
                pLine.IsDebt = debtOrCredit;
                pLine.Price = (double)debenturePay.Price;
                pLine.CurrencyRate = 1;
                listPayLines.Add(pLine);
            }
            foreach (Cheque chequePay in ChequePayments)
            {
                AccountDocument.PaymentLine pLine = new AccountDocument.PaymentLine();
                pLine.Description = TTUtils.CultureService.GetText("M25377", "Çek İle Ödeme");
                pLine.AccountCode = GetAccountCode(AccountEntegrationAccountTypeEnum.CekHesabi);
                pLine.IsDebt = debtOrCredit;
                pLine.Price = (double)chequePay.Price;
                pLine.CurrencyRate = 1;
                listPayLines.Add(pLine);
            }
            foreach (Cash cashPay in CashPayment)
            {
                if (defaultCurrency != (CurrencyTypeDefinition)cashPay.CurrencyType)
                {
                    string sDate = Convert.ToDateTime(DocumentDate).ToString("yyyy-MM-dd 00:00:00");
                    string eDate = Convert.ToDateTime(DocumentDate).ToString("yyyy-MM-dd 23:59:59");
                    string curRateType = TTObjectClasses.SystemParameter.GetParameterValue("FOREIGNCURRENCYPAYMENTRATETYPE", "");

                    IList curRateList = DailyRateDefinition.GetDailyRateByDateAndCurrType(ObjectContext, cashPay.CurrencyType.ObjectID.ToString(), Convert.ToDateTime(sDate), Convert.ToDateTime(eDate), curRateType.ToString());
                    if (curRateList.Count == 0)
                        throw new TTException(SystemMessage.GetMessageV3(495, new string[] { DocumentDate.ToString() }));
                    //  throw new TTException("Ödeme yapılmak istenen döviz için Günlük Kur Tanımı yapılmamış! (Kur Tarihi: " + this.DocumentDate.ToString() + ")");
                    else
                    {
                        AccountDocument.PaymentLine pLine = new AccountDocument.PaymentLine();
                        pLine.Description = TTUtils.CultureService.GetText("M25547", "Döviz İle Ödeme (")+ cashPay.CurrencyType.Qref + ")";
                        pLine.AccountCode = GetAccountCode(AccountEntegrationAccountTypeEnum.KasaDovizHesabi);
                        pLine.IsDebt = debtOrCredit;
                        pLine.Price = (double)cashPay.Price;

                        foreach (DailyRateDefinition myRate in curRateList)
                        {
                            pLine.CurrencyRate = (double)myRate.DailyRate;
                            break;
                        }
                        listPayLines.Add(pLine);
                    }
                }
                else
                {
                    AccountDocument.PaymentLine pLine = new AccountDocument.PaymentLine();
                    pLine.Description = TTUtils.CultureService.GetText("M26567", "Nakit Ödeme");
                    pLine.AccountCode = GetAccountCode(AccountEntegrationAccountTypeEnum.KasaHesabi);
                    pLine.IsDebt = debtOrCredit;
                    pLine.Price = (double)cashPay.Price;
                    pLine.CurrencyRate = 1;
                    listPayLines.Add(pLine);
                }
            }
        }

        public string GetAccountCode(AccountEntegrationAccountTypeEnum pType)
        {
            IList codeList = null;
            codeList = AccountCodeDefinition.GetByAccountType(ObjectContext, pType);

            if (codeList.Count == 0)
                throw new TTException(SystemMessage.GetMessageV3(496, new string[] { pType.ToString() }));
            //  throw new TTException("Muhasebe Hesap Kodu Tanımı bulunamadı! (" + pType.ToString() + ")");
            else if (codeList.Count > 1)
                throw new TTException(SystemMessage.GetMessageV3(497, new string[] { pType.ToString() }));
            //  throw new TTException("Muhasebe Hesap Kodu Tanımı birden çok yapılmış! (" + pType.ToString() + ")");
            else
            {
                foreach (AccountCodeDefinition codeDef in codeList)
                {
                    string code = codeDef.AccountCode.ToString().Trim();
                    return code;
                    /*
                    if (code.IndexOf(".0000") == -1)
                        throw new TTException(SystemMessage.GetMessage(498, new string[] { pType.ToString() }));
                    //  throw new TTException("Muhasebe Hesap Kodunda XXXXXX kodu ile değiştirilecek kısım (0000) bulunamadı! (" + pType.ToString() + ")");
                    else
                    {
                        if (SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") == "")
                            throw new TTUtils.TTException(SystemMessage.GetMessage(499));
                        //    throw new TTException("XXXXXX muhasebe kodu sistem parametresi bulunamadı!");
                        else
                        {
                            code = code.Substring(0, code.IndexOf(".")+1) + SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") + code.Substring(code.IndexOf(".")+5, code.Length - (code.IndexOf(".")+5));
                            return code;
                        }
                    }
                     */
                }
            }
            return null;
        }

        public static string ReceiptDocumentNo(string documentNo)
        {
            if (!string.IsNullOrEmpty(documentNo))
            {
                int numberPartIndex = documentNo.IndexOfAny("0123456789".ToCharArray());
                if (numberPartIndex != -1)
                {
                    string seriesPart = documentNo.Substring(0, numberPartIndex);
                    string numberPart = documentNo.Substring(numberPartIndex);

                    if (numberPart.Length < 7)
                    {
                        int numberPartLength = numberPart.Length;
                        for (int i = 0; i < 7 - numberPartLength; i++)
                            numberPart = "0" + numberPart;

                        return seriesPart + numberPart;
                    }
                }
            }

            return documentNo;
        }

        #endregion Methods

    }
}