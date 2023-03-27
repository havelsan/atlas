
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
    /// Senet Tahsilat Dökümanı
    /// </summary>
    public  partial class DebenturePaymentDocument : AccountDocument
    {
#region Methods
        public DebenturePaymentDocumentGroup AddDocumentGroup(string pCode, string pDesc)
        {
            DebenturePaymentDocumentGroup ddg = new DebenturePaymentDocumentGroup(ObjectContext);
            ddg.GroupCode = pCode;
            ddg.GroupDescription = pDesc;
            ddg.AccountDocument = this ;
            DebenturePaymentDocumentGroups.Add(ddg);
            return ddg;
        }
        
        public void Cancel()
        {
            
            if (CurrentStateDefID != DebenturePaymentDocument.States.Cancelled)
            {
                foreach (DebenturePaymentDocumentGroup debPayDocGroup in DebenturePaymentDocumentGroups)
                {
                    foreach (DebenturePaymentDocumentDetail debPayDocDetail in debPayDocGroup.DebenturePaymentDocumentDetails)
                    {
                        
                        debPayDocDetail.CurrentStateDefID = DebenturePaymentDocumentDetail.States.Cancelled;
                    }
                }
                
                CurrentStateDefID = DebenturePaymentDocument.States.Cancelled;
                //this.CreateReceiptInfoAndSendToAccounting(); // muhasebeye ters hareket oluşturup gönderir
            }
        }

        public AccountDocument.ReceiptInfo CreateReceiptInfoForAccounting()
        {
            AccountDocument.ReceiptInfo RI = null;
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if (CurrentStateDefID == DebenturePaymentDocument.States.Paid && SendToAccounting == false)
                {
                    RI = new AccountDocument.ReceiptInfo();
                    CreateBasicReceiptInfo(ref RI);
                    RI.Type = AccountDocument.ReceiptTypeEnum.SenetTahsilat;
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
                    rLine.Description = TTUtils.CultureService.GetText("M26838", "Senet Hesabı");
                    rLine.AccountCode = GetAccountCode(AccountEntegrationAccountTypeEnum.SenetHesabi);
                    rLine.IsDebt = false;
                    rLine.Price = (double)EpisodeAccountAction.TotalPrice;
                    rLine.CurrencyRate = 1;
                    RI.Lines.Add(rLine);
                    
                    CreateReceiptPaymentDetailInfo(ref RI.Lines, true, ReceiptPaymentTypeEnum.All);
                    CreateReceiptLineObjectIDs(RI);
                    ControlReceiptInfo(RI, TTUtils.CultureService.GetText("M26842", "Senet Tahsilat"));
                }
            }
            return RI;
        }
        
        public AccountDocument.ReceiptInfo CreateNonCashReceiptInfoForAccounting()
        {
            AccountDocument.ReceiptInfo RI = null;
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if (CurrentStateDefID == DebenturePaymentDocument.States.Paid && SendToAccounting == false)
                {
                    RI = new AccountDocument.ReceiptInfo();
                    CreateBasicReceiptInfo(ref RI);
                    RI.ObjectId = RI.ObjectId + "-1";
                    RI.Type = AccountDocument.ReceiptTypeEnum.SenetTahsilat;
                    RI.TotalPrice = (double)GetCalculatedNonCashPayment();
                    
                    if (CreditCardDocumentNo != null)
                        RI.No = CreditCardDocumentNo;
                    else
                        RI.No = " ";
                    
                    RI.Lines = new List<AccountDocument.ReceiptLine>();
                    
                    AccountDocument.ReceiptLine rLine = new AccountDocument.ReceiptLine();
                    rLine.Description = TTUtils.CultureService.GetText("M26838", "Senet Hesabı");
                    rLine.AccountCode = GetAccountCode(AccountEntegrationAccountTypeEnum.SenetHesabi);
                    rLine.IsDebt = false;
                    rLine.Price = (double)GetCalculatedNonCashPayment();
                    rLine.CurrencyRate = 1;
                    RI.Lines.Add(rLine);
                    
                    CreateReceiptPaymentDetailInfo(ref RI.Lines, true, ReceiptPaymentTypeEnum.NonCash);
                    CreateReceiptLineObjectIDs(RI);
                    ControlReceiptInfo(RI, TTUtils.CultureService.GetText("M26842", "Senet Tahsilat"));
                }
            }
            return RI;
        }
        
        public AccountDocument.ReceiptInfo CreateCashReceiptInfoForAccounting()
        {
            AccountDocument.ReceiptInfo RI = null;
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if (CurrentStateDefID == DebenturePaymentDocument.States.Paid)
                {
                    RI = new AccountDocument.ReceiptInfo();
                    CreateBasicReceiptInfo(ref RI);
                    RI.ObjectId = RI.ObjectId + "-2";
                    RI.Type = AccountDocument.ReceiptTypeEnum.SenetTahsilat;
                    RI.TotalPrice = (double)GetCalculatedCashPayment(Convert.ToDateTime(DocumentDate));
                    
                    RI.Lines = new List<AccountDocument.ReceiptLine>();
                    
                    AccountDocument.ReceiptLine rLine = new AccountDocument.ReceiptLine();
                    rLine.Description = TTUtils.CultureService.GetText("M26838", "Senet Hesabı");
                    rLine.AccountCode = GetAccountCode(AccountEntegrationAccountTypeEnum.SenetHesabi);
                    rLine.IsDebt = false;
                    rLine.Price = (double)GetCalculatedCashPayment(Convert.ToDateTime(DocumentDate));
                    rLine.CurrencyRate = 1;
                    RI.Lines.Add(rLine);
                    
                    CreateReceiptPaymentDetailInfo(ref RI.Lines, true, ReceiptPaymentTypeEnum.Cash);
                    CreateReceiptLineObjectIDs(RI);
                    ControlReceiptInfo(RI, TTUtils.CultureService.GetText("M26842", "Senet Tahsilat"));
                }
            }
            return RI;
        }
        
#endregion Methods

    }
}