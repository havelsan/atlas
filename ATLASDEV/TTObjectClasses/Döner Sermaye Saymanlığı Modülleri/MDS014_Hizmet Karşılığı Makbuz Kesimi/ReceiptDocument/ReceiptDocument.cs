
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
    /// Muhasebe Yetkilisi Mutemedi Alındısı Dökümanı
    /// </summary>
    public partial class ReceiptDocument : AccountDocument
    {
        public partial class OLAP_GetCancelledReceiptDocument_Class : TTReportNqlObject
        {
        }

        public partial class GetReceiptDocument_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetReceiptDocument_Class : TTReportNqlObject
        {
        }

        #region Methods
        public void Cancel()
        {
            if (CurrentStateDefID != ReceiptDocument.States.Cancelled)
            {
                //Document APR larına ters kayıt olustur
                Dictionary<string, APRTrx> dict = new Dictionary<string, APRTrx>();
                int i = 1;
                foreach (APRTrx myAPRTrx in APRTrx)
                {
                    dict.Add("myAPRTrx" + i.ToString(), myAPRTrx);
                    i++;
                }
                foreach (KeyValuePair<string, APRTrx> myAPRTrx in dict)
                {
                    APRTrx app = myAPRTrx.Value;
                    AddAPRTransaction(app.AccountPayableReceivable, (double)(app.Price * -1), APRTrxType.GetByType(ObjectContext, 10)[0]); // 10 Belge Iptali
                }

                AccountPayableReceivable myAPR = (AccountPayableReceivable)APRTrx[0].AccountPayableReceivable;

                foreach (ReceiptDocumentGroup recGroup in ReceiptDocumentGroups)
                {
                    foreach (ReceiptDocumentDetail receiptDetail in recGroup.ReceiptDocumentDetails)
                    {
                        if (receiptDetail.AccountTrxDocument[0].AccountTransaction.CurrentStateDefID == AccountTransaction.States.Invoiced)
                        {
                            String message = SystemMessage.GetMessage(124);
                            throw new TTUtils.TTException(message);
                        }

                        receiptDetail.AccountTrxDocument[0].AccountTransaction.CurrentStateDefID = AccountTransaction.States.New;
                        //receiptDetail.AccountTrxDocument[0].AccountTransaction.TotalDiscountPrice = 0; //İndirim uygulaması başlar ise açılacak
                        receiptDetail.CurrentStateDefID = ReceiptDocumentDetail.States.Cancelled;

                        foreach (PatientPaymentDetail ppDetail in receiptDetail.AccountTrxDocument[0].AccountTransaction.PatientPaymentDetail.Where(x => x.AccountDocument == this))
                        {
                            ppDetail.IsCancel = true;
                        }

                        /*
                        if (receiptDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure != null)
                        {
                            // Paketin içindeki AccTrx leri de Yeni durumuna almak için (Paket Tanımı olan durumda)
                            if (receiptDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.PackageDefinition != null)
                            {
                                foreach (AccountTransaction accTrx in receiptDetail.AccountTrxDocument[0].AccountTransaction.SubEpisodeProtocol.GetTransactionsInsidePackage(receiptDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.PackageDefinition, myAPR))
                                {
                                    if (accTrx.CurrentStateDefID == AccountTransaction.States.Paid)
                                        accTrx.CurrentStateDefID = AccountTransaction.States.New;
                                }
                            } // Paket hizmet ise : SUbEpisodeProtocol deki InvoiceInclusion ı false ve Ödendi durumundaki hizmetler Paket içi olduğu düşünülüp tekrar Yeni durumuna alınır
                            else if (receiptDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.ProcedureObject is PackageProcedureDefinition)
                            {
                                foreach (AccountTransaction accTrx in receiptDetail.AccountTrxDocument[0].AccountTransaction.SubEpisodeProtocol.GetNotInvoiceIncludedTransactions(myAPR))
                                {
                                    if (accTrx.CurrentStateDefID == AccountTransaction.States.Paid)
                                        accTrx.CurrentStateDefID = AccountTransaction.States.New;
                                }
                            }
                        }
                        */
                    }
                }
                CurrentStateDefID = ReceiptDocument.States.Cancelled;

                foreach (AdvanceDocument advanceDoc in AdvanceDocuments)
                {
                    advanceDoc.Used = false;
                    foreach (PatientPaymentDetail ppDetail in advanceDoc.PatientPaymentDetail.Where(x => x.AccountTransaction != null))
                    {
                        ppDetail.IsCancel = true;
                    }
                }
                CancelDate = Common.RecTime();
                // senetlerin state i Cancelled yapılır
                /*foreach (Debenture db in this.DebenturePayments)
                {
                    db.CurrentStateDefID = Debenture.States.Cancelled ;
                }*/
            }
        }

        public AccountDocument.ReceiptInfo CreateReceiptInfoForAccounting()
        {
            AccountDocument.ReceiptInfo RI = null;

            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if (CurrentStateDefID == ReceiptDocument.States.Paid && SendToAccounting == false)
                {
                    RI = new AccountDocument.ReceiptInfo();
                    CreateBasicReceiptInfo(ref RI);
                    RI.Type = AccountDocument.ReceiptTypeEnum.MuhasebeYetkilisiMutemediAlindisi;
                    RI.TotalPrice = (double)EpisodeAccountAction.TotalPrice;
                    if (CreditCardPayments.Count > 0)
                    {
                        if (CashPayment.Count > 0)
                            RI.No = RI.No + " , " + CreditCardDocumentNo;
                        else
                            RI.No = CreditCardDocumentNo;
                    }

                    RI.Lines = new List<AccountDocument.ReceiptLine>();

                    if (EpisodeAccountAction.TotalDiscountPrice != null) // indirim
                    {
                        if (EpisodeAccountAction.TotalDiscountPrice > 0)
                        {
                            AccountDocument.ReceiptLine rLine1 = new AccountDocument.ReceiptLine();
                            rLine1.Description = TTUtils.CultureService.GetText("M26081", "İndirim Hesabı");
                            rLine1.AccountCode = GetAccountCode(AccountEntegrationAccountTypeEnum.IndirimHesabi);
                            rLine1.IsDebt = true;
                            rLine1.Price = (double)EpisodeAccountAction.TotalDiscountPrice;
                            rLine1.CurrencyRate = 1;
                            RI.Lines.Add(rLine1);
                        }
                    }

                    double advanceTotal = 0;
                    if (((Receipt)EpisodeAccountAction).AdvanceTaken != null)
                        advanceTotal = advanceTotal + (double)(((Receipt)EpisodeAccountAction).AdvanceTaken);
                    if (((Receipt)EpisodeAccountAction).DebentureTaken != null)
                        advanceTotal = advanceTotal + (double)(((Receipt)EpisodeAccountAction).DebentureTaken);

                    if (advanceTotal > 0)   // makbuzda avans kullanılmışsa
                    {
                        AccountDocument.ReceiptLine rLine2 = new AccountDocument.ReceiptLine();
                        rLine2.Description = TTUtils.CultureService.GetText("M25802", "Hasta Tedavi Avans Hesabı");
                        rLine2.AccountCode = GetAccountCode(AccountEntegrationAccountTypeEnum.AvansHesabi);
                        rLine2.IsDebt = true;
                        rLine2.Price = advanceTotal;
                        rLine2.CurrencyRate = 1;
                        RI.Lines.Add(rLine2);
                    }

                    CreateReceiptPaymentDetailInfo(ref RI.Lines, true, ReceiptPaymentTypeEnum.All);

                    // hizmet ve malzemeler gelir hesaplarına göre gruplanır

                    string accountCodeStart = "";
                    string accountCode = "";
                    bool addLine = true;
                    double lineTotal = 0;
                    RevenueSubAccountCodeDefinition revenueCode = null;

                    if (EpisodeAccountAction.Episode.Patient.Foreign == true)
                        accountCodeStart = "601."; // + SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") + ".";
                    else
                        accountCodeStart = "600."; // + SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") + ".";

                    // malzemeleri ekler
                    foreach (ReceiptMaterial recMat in ((Receipt)EpisodeAccountAction).ReceiptMaterials)
                    {
                        if (recMat.Paid == true)
                            lineTotal = lineTotal + (double)recMat.TotalPrice;
                    }

                    if (lineTotal > 0)
                    {
                        AccountDocument.ReceiptLine rLine3 = new AccountDocument.ReceiptLine();
                        rLine3.Description = TTUtils.CultureService.GetText("M26072", "İlaç ve Tıbbi Sarf Malzemesi Gelirleri");
                        rLine3.AccountCode = accountCodeStart + "08";
                        rLine3.IsDebt = false;
                        rLine3.Price = (double)lineTotal;
                        rLine3.CurrencyRate = 1;
                        RI.Lines.Add(rLine3);
                    }

                    // hizmetleri ekler
                    foreach (ReceiptProcedure recProc in ((Receipt)EpisodeAccountAction).ReceiptProcedures)
                    {
                        if (recProc.Paid == true)
                        {
                            accountCode = "";
                            addLine = true;
                            revenueCode = null;
                            revenueCode = recProc.AccountTransaction[0].SubActionProcedure.ProcedureObject.GetRevenueSubAccountCode();

                            if (revenueCode == null)
                            {
                                string[] parameters = new string[] { recProc.ExternalCode.ToString(), recProc.Description.ToString() };
                                String message = SystemMessage.GetMessageV3(127, parameters);
                                throw new TTUtils.TTException(message);

                            }
                            //throw new TTException("Hizmetin muhasebe gelir hesap kırınımına ulaşılamadı! (" + recProc.ExternalCode + " " + recProc.Description + ")");
                            else
                            {
                                if ((double)recProc.TotalPrice > 0)
                                {
                                    accountCode = accountCodeStart + revenueCode.AccountCode;

                                    foreach (AccountDocument.ReceiptLine rLine in RI.Lines)
                                    {
                                        if (rLine.AccountCode == accountCode)
                                        {
                                            rLine.Price = rLine.Price + (double)recProc.TotalPrice; // line larda var, fiyata ekle
                                            addLine = false;
                                            break;
                                        }
                                    }
                                    if (addLine)  // line larda yok, yeni line ekle
                                    {
                                        AccountDocument.ReceiptLine rLine = new AccountDocument.ReceiptLine();
                                        rLine.Description = revenueCode.Description;
                                        rLine.AccountCode = accountCode;
                                        rLine.IsDebt = false;
                                        rLine.Price = (double)recProc.TotalPrice;
                                        rLine.CurrencyRate = 1;
                                        RI.Lines.Add(rLine);
                                    }
                                }
                            }
                        }
                    }
                    CreateReceiptLineObjectIDs(RI);
                    ControlReceiptInfo(RI, TTUtils.CultureService.GetText("M26546", "Muhasebe Yetkilisi Mutemedi Alındısı"));
                }
            }
            return RI;
        }

        public AccountDocument.ReceiptInfo CreateNonCashReceiptInfoForAccounting()
        {
            AccountDocument.ReceiptInfo RI = null;

            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if (CurrentStateDefID == ReceiptDocument.States.Paid && SendToAccounting == false)
                {
                    AccountDocument.ReceiptInfo RIOriginal;
                    RIOriginal = CreateReceiptInfoForAccounting();

                    RI = new AccountDocument.ReceiptInfo();
                    CreateBasicReceiptInfo(ref RI);
                    RI.ObjectId = RI.ObjectId + "-1";
                    RI.Type = AccountDocument.ReceiptTypeEnum.MuhasebeYetkilisiMutemediAlindisi;
                    RI.TotalPrice = (double)GetCalculatedNonCashPayment();

                    if (CreditCardDocumentNo != null)
                        RI.No = CreditCardDocumentNo;
                    else
                        RI.No = " ";

                    RI.Lines = new List<AccountDocument.ReceiptLine>();

                    double cashPayment = (double)GetCalculatedCashPayment(Convert.ToDateTime(DocumentDate));
                    double linePrice = 0;

                    foreach (AccountDocument.ReceiptLine rLine in RIOriginal.Lines)
                    {
                        if (rLine.IsDebt == false && (rLine.AccountCode.Substring(0, 3) == "600" || rLine.AccountCode.Substring(0, 3) == "601"))
                        {
                            if (cashPayment > 0)
                            {
                                linePrice = rLine.Price;

                                if (cashPayment >= rLine.Price)
                                {
                                    AddAccountingLineForCash(rLine.AccountCode, rLine.Description, rLine.Price);
                                }
                                else if (cashPayment < rLine.Price)
                                {
                                    rLine.Price = rLine.Price - cashPayment;
                                    RI.Lines.Add(rLine);

                                    AddAccountingLineForCash(rLine.AccountCode, rLine.Description, cashPayment);
                                }
                                cashPayment = cashPayment - linePrice;
                            }
                            else
                                RI.Lines.Add(rLine);
                        }
                        else
                        {
                            if (rLine.AccountCode != GetAccountCode(AccountEntegrationAccountTypeEnum.KasaHesabi) && rLine.AccountCode != GetAccountCode(AccountEntegrationAccountTypeEnum.KasaDovizHesabi))
                                RI.Lines.Add(rLine);
                        }
                    }

                    CreateReceiptLineObjectIDs(RI);
                    ControlReceiptInfo(RI, TTUtils.CultureService.GetText("M26546", "Muhasebe Yetkilisi Mutemedi Alındısı"));
                }
            }
            return RI;
        }
        public static PatientPaymentDetail GetPatientPaymentDetail(Guid accTrxGuid, ReceiptDocument receiptDoc)
        {
            return receiptDoc.PatientPaymentDetail.FirstOrDefault(x => x.AccountTransaction.ObjectID == accTrxGuid && x.IsCancel == false && x.PaymentType != TTObjectClasses.PaymentTypeEnum.Advance);
        }
        public AccountDocument.ReceiptInfo CreateCashReceiptInfoForAccounting()
        {
            AccountDocument.ReceiptInfo RI = null;

            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if (CurrentStateDefID == ReceiptDocument.States.Paid)
                {
                    RI = new AccountDocument.ReceiptInfo();
                    CreateBasicReceiptInfo(ref RI);
                    RI.ObjectId = RI.ObjectId + "-2";
                    RI.Type = AccountDocument.ReceiptTypeEnum.MuhasebeYetkilisiMutemediAlindisi;
                    RI.TotalPrice = (double)GetCalculatedCashPayment(Convert.ToDateTime(DocumentDate));

                    RI.Lines = new List<AccountDocument.ReceiptLine>();

                    foreach (AccountingLinesForCash line in AccountingLinesForCash)
                    {
                        AccountDocument.ReceiptLine rLine = new AccountDocument.ReceiptLine();
                        rLine.Description = line.Description;
                        rLine.AccountCode = line.AccountCode;
                        rLine.IsDebt = false;
                        rLine.Price = (double)line.Price;
                        rLine.CurrencyRate = 1;
                        RI.Lines.Add(rLine);
                    }

                    CreateReceiptPaymentDetailInfo(ref RI.Lines, true, ReceiptPaymentTypeEnum.Cash);
                    CreateReceiptLineObjectIDs(RI);
                    ControlReceiptInfo(RI, TTUtils.CultureService.GetText("M26546", "Muhasebe Yetkilisi Mutemedi Alındısı"));
                }
            }
            return RI;
        }

        public void AddAccountingLineForCash(string code, string description, double price)
        {
            AccountingLinesForCash alfc = new AccountingLinesForCash(ObjectContext);

            alfc.AccountCode = code;
            alfc.Description = description;
            alfc.Price = price;
            alfc.ReceiptDocument = this;
            AccountingLinesForCash.Add(alfc);
        }

        #endregion Methods

    }
}