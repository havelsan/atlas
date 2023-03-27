
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
    /// Fatura Tahsilat Dökümanı
    /// </summary>
    public  partial class PayerPaymentDocument : AccountDocument
    {
        public partial class OLAP_GetPayerPaymentDocument_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetCancelledPayerPaymentDocument_Class : TTReportNqlObject 
        {
        }

#region Methods
        public PayerPaymentDocumentGroup AddDocumentGroup(string pCode, string pDesc)
        {
            PayerPaymentDocumentGroup adg = new PayerPaymentDocumentGroup(ObjectContext);
            
            adg.GroupCode = pCode;
            adg.GroupDescription = pDesc;
            adg.AccountDocument = this;
            PayerPaymentDocumentGroups.Add(adg);
            return adg;
        }

        public void Cancel()
        {
            if (CurrentStateDefID != PayerPaymentDocument.States.Cancelled)
            {
                //Document APR larına ters kayıt olustur
                Dictionary<string, APRTrx> dict = new Dictionary<string, APRTrx>();
                int i = 1;
                foreach(APRTrx myAPRTrx in APRTrx)
                {
                    dict.Add("myAPRTrx" + i.ToString(), myAPRTrx);
                    i ++;
                }
                foreach(KeyValuePair<string, APRTrx> myAPRTrx in dict)
                {
                    APRTrx app = myAPRTrx.Value;
                    AddAPRTransaction(app.AccountPayableReceivable, (double)(app.Price * -1),APRTrxType.GetByType(ObjectContext, 10)[0]); // 10 Belge Iptali
                }
                CurrentStateDefID = PayerPaymentDocument.States.Cancelled;
            }
        }

        public AccountDocument.PaymentInfo CreatePaymentInfoForAccounting()
        {
            AccountDocument.PaymentInfo PI = null;
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                
                if (CurrentStateDefID == PayerPaymentDocument.States.Paid && SendToAccounting == false)
                {
                    double UsedAdvanceTotal = 0;
                    
                    if (((InvoicePayment)AccountAction).UseAdvance == true)
                    {
                        foreach (PayerPaymentAdvanceList adv in ((InvoicePayment)AccountAction).PayerPaymentAdvances)
                        {
                            if (adv.Used == true)
                                UsedAdvanceTotal = UsedAdvanceTotal + (double)adv.UsedPrice;
                        }
                    }
                    
                    // ödemenin hepsi avans kullanılarak yapılmışsa hareket göndermeye gerek yok
                    if ((double)(((InvoicePayment)AccountAction).PaymentPrice) == (double)UsedAdvanceTotal)
                        return PI;
                    
                    PI = new AccountDocument.PaymentInfo();
                    
                    PI.ObjectId = ObjectID.ToString();
                    PI.PaymentDate = (DateTime)DocumentDate;
                    PI.PayerName = ((InvoicePayment)AccountAction).Payer.Code + " " + ((InvoicePayment)AccountAction).Payer.Name;
                    PI.Description = TTUtils.CultureService.GetText("M26361", "Kurum Fatura Tahsilat");
                    PI.Type = AccountDocument.PayerPaymentTypeEnum.KurumFaturaTahsilat;
                    PI.TotalPrice = (double)AccountAction.TotalPrice - (double)UsedAdvanceTotal;  // düzelt
                    
                    PI.Lines = new List<AccountDocument.PaymentLine>();
                    
                    AccountDocument.PaymentLine pLine = new AccountDocument.PaymentLine();
                    pLine.Description = TTUtils.CultureService.GetText("M26362", "Kurum Hesabı");
                    pLine.AccountCode = ((InvoicePayment)AccountAction).Payer.GetAccountCode();
                    pLine.IsDebt = false;
                    pLine.Price = (double)AccountAction.TotalPrice - (double)UsedAdvanceTotal; // düzelt
                    pLine.CurrencyRate = 1;
                    PI.Lines.Add(pLine);
                    
                    // Kesinti yapılmışsa kurum kesintileri hesabı çalışacak
                    if (((InvoicePayment)AccountAction).CutOffPrice != null)
                    {
                        if ((double)((InvoicePayment)AccountAction).CutOffPrice > 0)
                        {
                            AccountDocument.PaymentLine pLine1 = new AccountDocument.PaymentLine();
                            pLine1.Description = TTUtils.CultureService.GetText("M26364", "Kurum Kesintileri Hesabı");
                            pLine1.AccountCode = GetAccountCode(AccountEntegrationAccountTypeEnum.KurumKesintileriHesabi);
                            pLine1.IsDebt = true;
                            pLine1.Price = (double)((InvoicePayment)AccountAction).CutOffPrice;
                            pLine1.CurrencyRate = 1;
                            PI.Lines.Add(pLine1);
                        }
                    }

                    CreatePaymentDetailInfo(ref PI.Lines, true);
                    CreatePaymentLineObjectIDs(PI);
                    ControlPaymentInfo(PI, TTUtils.CultureService.GetText("M25646", "Fatura Tahsilat"));
                }
            }
            return PI;
        }
        
#endregion Methods

    }
}