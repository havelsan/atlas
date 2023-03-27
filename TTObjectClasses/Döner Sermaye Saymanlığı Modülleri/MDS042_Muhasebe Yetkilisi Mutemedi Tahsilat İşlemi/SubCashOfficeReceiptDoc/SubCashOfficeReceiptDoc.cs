
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
    /// Muhasebe Yetkilisi Mutemedi Tahsilat Dökümanı
    /// </summary>
    public  partial class SubCashOfficeReceiptDoc : AccountDocument
    {
#region Methods
        public SubCashOfficeReceiptDocGroup AddDocumentGroup(string pCode, string pDesc)
        {
            SubCashOfficeReceiptDocGroup cdg = new SubCashOfficeReceiptDocGroup(ObjectContext);
            
            cdg.GroupCode = pCode;
            cdg.GroupDescription = pDesc;
            cdg.AccountDocument = this;
            SubCashOfficeReceiptDocumentGroups.Add(cdg);
            return cdg;
        }
        
        public void Cancel()
        {
            if (CurrentStateDefID != SubCashOfficeReceiptDoc.States.Cancelled)
            {
                foreach (SubCashOfficeReceiptDocGroup recGroup in SubCashOfficeReceiptDocumentGroups)
                {
                    foreach (SubCashOfficeReceiptDocDet recDetail in recGroup.SubCashOfficeReceiptDocumentDetails)
                    {
                        recDetail.CurrentStateDefID = SubCashOfficeReceiptDocDet.States.Cancelled;
                    }
                }
                CurrentStateDefID = SubCashOfficeReceiptDoc.States.Cancelled;
            }
        }
        
        public AccountDocument.ReceiptInfo CreateReceiptInfoForAccounting()
        {
            AccountDocument.ReceiptInfo RI = null;
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if (CurrentStateDefID == SubCashOfficeReceiptDoc.States.Paid && SendToAccounting == false)
                {
                    if (MoneyReceivedType.AccountEntegration == true)
                    {
                        string accountCode = null;
                        
                        RI = new AccountDocument.ReceiptInfo();
                        CreateBasicReceiptInfo(ref RI);
                        
                        RI.Description = AccountAction.Description;
                        RI.Type = AccountDocument.ReceiptTypeEnum.MuhasebeYetkilisiMutemediAlindisi;
                        RI.TotalPrice = (double)AccountAction.TotalPrice;
                        
                        if (CreditCardPayments.Count > 0)
                        {
                            if (CashPayment.Count > 0)
                                RI.No = RI.No + " , " + CreditCardDocumentNo;
                            else
                                RI.No = CreditCardDocumentNo;
                        }
                        
                        accountCode = MoneyReceivedType.RevenueSubAccountCode.AccountCode;
                        
                        /*
                        if (accountCode != null)
                        {
                            if (accountCode.IndexOf(".0000") == -1)
                                throw new TTException(SystemMessage.GetMessage(184, new string[] { "Alacak Hesap Kodunda" , this.MoneyReceivedType.Name }));
                            else
                            {
                                if (SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") == "")
                                    throw new TTException(SystemMessage.GetMessage(183));
                                else
                                    accountCode = accountCode.Substring(0, accountCode.IndexOf(".")+1) + SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") + accountCode.Substring(accountCode.IndexOf(".")+5, accountCode.Length - (accountCode.IndexOf(".")+5));
                            }
                        }
                        */
                        RI.Lines = new List<AccountDocument.ReceiptLine>();
                        
                        AccountDocument.ReceiptLine rLine1 = new AccountDocument.ReceiptLine();
                        rLine1.Description = TTUtils.CultureService.GetText("M26549", "Muhasebe Yetkilisi Mutemedi Tahsilat (")+ MoneyReceivedType.Name.ToString() + ")";
                        rLine1.AccountCode = accountCode;
                        rLine1.IsDebt = false;
                        rLine1.Price = (double)AccountAction.TotalPrice;
                        rLine1.CurrencyRate = 1;
                        RI.Lines.Add(rLine1);
                        
                        CreateReceiptPaymentDetailInfo(ref RI.Lines, true, ReceiptPaymentTypeEnum.All);
                        CreateReceiptLineObjectIDs(RI);
                        ControlReceiptInfo(RI, TTUtils.CultureService.GetText("M26548", "Muhasebe Yetkilisi Mutemedi Tahsilat"));
                    }
                }
            }
            return RI;
        }
        
        public AccountDocument.ReceiptInfo CreateNonCashReceiptInfoForAccounting()
        {
            AccountDocument.ReceiptInfo RI = null;
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if (CurrentStateDefID == SubCashOfficeReceiptDoc.States.Paid && SendToAccounting == false)
                {
                    if (MoneyReceivedType.AccountEntegration == true)
                    {
                        string accountCode = null;
                       
                        RI = new AccountDocument.ReceiptInfo();
                        CreateBasicReceiptInfo(ref RI);
                        
                        RI.ObjectId = RI.ObjectId + "-1";
                        RI.Description = AccountAction.Description;
                        RI.Type = AccountDocument.ReceiptTypeEnum.MuhasebeYetkilisiMutemediAlindisi;
                        RI.TotalPrice = (double)GetCalculatedNonCashPayment();
                        
                        if (CreditCardDocumentNo != null)
                            RI.No = CreditCardDocumentNo;
                        else
                            RI.No = " ";
                        
                        accountCode = MoneyReceivedType.RevenueSubAccountCode.AccountCode;
                        /*
                        if (accountCode != null)
                        {
                            if (accountCode.IndexOf(".0000") == -1)
                                throw new TTException(SystemMessage.GetMessage(184, new string[] { "Alacak Hesap Kodunda" , this.MoneyReceivedType.Name }));
                            else
                            {
                                if (SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") == "")
                                    throw new TTException(SystemMessage.GetMessage(183));
                                else
                                    accountCode = accountCode.Substring(0, accountCode.IndexOf(".")+1) + SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") + accountCode.Substring(accountCode.IndexOf(".")+5, accountCode.Length - (accountCode.IndexOf(".")+5));
                            }
                        }
                        */
                        RI.Lines = new List<AccountDocument.ReceiptLine>();
                        
                        AccountDocument.ReceiptLine rLine1 = new AccountDocument.ReceiptLine();
                        rLine1.Description = TTUtils.CultureService.GetText("M26549", "Muhasebe Yetkilisi Mutemedi Tahsilat (")+ MoneyReceivedType.Name.ToString() + ")";
                        rLine1.AccountCode = accountCode;
                        rLine1.IsDebt = false;
                        rLine1.Price = (double)GetCalculatedNonCashPayment();
                        rLine1.CurrencyRate = 1;
                        RI.Lines.Add(rLine1);
                        
                        CreateReceiptPaymentDetailInfo(ref RI.Lines, true, ReceiptPaymentTypeEnum.NonCash);
                        CreateReceiptLineObjectIDs(RI);
                        ControlReceiptInfo(RI, TTUtils.CultureService.GetText("M26548", "Muhasebe Yetkilisi Mutemedi Tahsilat"));
                    }
                }
            }
            return RI;
        }
        
        public AccountDocument.ReceiptInfo CreateCashReceiptInfoForAccounting()
        {
            AccountDocument.ReceiptInfo RI = null;
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if (CurrentStateDefID == SubCashOfficeReceiptDoc.States.Paid)
                {
                    if (MoneyReceivedType.AccountEntegration == true)
                    {
                        string accountCode = null;
                        
                        RI = new AccountDocument.ReceiptInfo();
                        CreateBasicReceiptInfo(ref RI);
                        
                        RI.ObjectId = RI.ObjectId + "-2";
                        RI.Description = AccountAction.Description;
                        RI.Type = AccountDocument.ReceiptTypeEnum.MuhasebeYetkilisiMutemediAlindisi;
                        RI.TotalPrice = (double)GetCalculatedCashPayment(Convert.ToDateTime(DocumentDate));
                        
                        accountCode = MoneyReceivedType.RevenueSubAccountCode.AccountCode;
                        /*
                        if (accountCode != null)
                        {
                            if (accountCode.IndexOf(".0000") == -1)
                                throw new TTException(SystemMessage.GetMessage(184, new string[] { "Alacak Hesap Kodunda" , this.MoneyReceivedType.Name }));
                            else
                            {
                                if (SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") == "")
                                    throw new TTException(SystemMessage.GetMessage(183));
                                else
                                    accountCode = accountCode.Substring(0, accountCode.IndexOf(".")+1) + SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") + accountCode.Substring(accountCode.IndexOf(".")+5, accountCode.Length - (accountCode.IndexOf(".")+5));
                            }
                        }
                        */
                        RI.Lines = new List<AccountDocument.ReceiptLine>();
                        
                        AccountDocument.ReceiptLine rLine1 = new AccountDocument.ReceiptLine();
                        rLine1.Description = TTUtils.CultureService.GetText("M26549", "Muhasebe Yetkilisi Mutemedi Tahsilat (")+ MoneyReceivedType.Name.ToString() + ")";
                        rLine1.AccountCode = accountCode;
                        rLine1.IsDebt = false;
                        rLine1.Price = (double)GetCalculatedCashPayment(Convert.ToDateTime(DocumentDate));
                        rLine1.CurrencyRate = 1;
                        RI.Lines.Add(rLine1);
                        
                        CreateReceiptPaymentDetailInfo(ref RI.Lines, true, ReceiptPaymentTypeEnum.Cash);
                        CreateReceiptLineObjectIDs(RI);
                        ControlReceiptInfo(RI, TTUtils.CultureService.GetText("M26548", "Muhasebe Yetkilisi Mutemedi Tahsilat"));
                    }
                }
            }
            return RI;
        }
        
#endregion Methods

    }
}