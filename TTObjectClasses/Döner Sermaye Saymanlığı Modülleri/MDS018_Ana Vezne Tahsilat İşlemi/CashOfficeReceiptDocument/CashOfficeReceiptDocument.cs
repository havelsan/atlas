
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
    /// Vezne Tahsilat Alındısı
    /// </summary>
    public  partial class CashOfficeReceiptDocument : AccountDocument
    {
#region Methods
        public CashOfficeReceiptDocumentGroup AddDocumentGroup(string pCode, string pDesc)
        {
            CashOfficeReceiptDocumentGroup cdg = new CashOfficeReceiptDocumentGroup(ObjectContext);
            
            cdg.GroupCode = pCode;
            cdg.GroupDescription = pDesc;
            cdg.AccountDocument = this;
            CashOfficeReceiptDocumentGroups.Add(cdg);
            return cdg;
        }
        
        public void Cancel()
        {
            if (CurrentStateDefID != CashOfficeReceiptDocument.States.Cancelled)
            {
                foreach (CashOfficeReceiptDocumentGroup recGroup in CashOfficeReceiptDocumentGroups)
                {
                    foreach (CashOfficeReceiptDocumentDetail recDetail in recGroup.CashOfficeReceiptDocumentDetails)
                    {
                        recDetail.CurrentStateDefID = CashOfficeReceiptDocumentDetail.States.Cancelled;
                    }
                }
                CurrentStateDefID = CashOfficeReceiptDocument.States.Cancelled;
                CancelDate = Common.RecTime();
                // this.CreateReceiptInfoAndSendToAccounting();  // muhasebeye ters hareket gönderir
            }
        }
        
        //public AccountDocument.ReceiptInfo CreateReceiptInfoForAccounting()
        //{
        //    AccountDocument.ReceiptInfo RI = null;
            
        //    if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
        //    {
        //        if (this.CurrentStateDefID == CashOfficeReceiptDocument.States.Paid && this.SendToAccounting == false)
        //        {
        //            if (this.MoneyReceivedType.AccountEntegration == true && this.MoneyReceivedType.IsSubCashOfficePayment != true)
        //            {
        //                string accountCode = null;
        //                string debtAccountCode = null;
                        
        //                RI = new AccountDocument.ReceiptInfo();
        //                this.CreateBasicReceiptInfo(ref RI);
                        
        //                RI.Description = this.AccountAction.Description;
        //                RI.Type = AccountDocument.ReceiptTypeEnum.VezneTahsilat;
                        
        //                accountCode = this.MoneyReceivedType.AccountCode;
        //                debtAccountCode = this.MoneyReceivedType.DebtAccountCode;
                        
        //                /*
        //                if (accountCode != null)
        //                {
        //                    if (accountCode.IndexOf(".0000") == -1)
        //                        throw new TTUtils.TTException(SystemMessage.GetMessage(184, new string[] { "Alacak Hesap Kodunda," , "(" + this.MoneyReceivedType.Name + ")" }));
        //                    else
        //                    {
        //                        if (SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") == "")
        //                            throw new TTUtils.TTException(SystemMessage.GetMessage(183));
        //                        else
        //                            accountCode = accountCode.Substring(0, accountCode.IndexOf(".")+1) + SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") + accountCode.Substring(accountCode.IndexOf(".")+5, accountCode.Length - (accountCode.IndexOf(".")+5));
        //                    }
        //                }

        //                if (debtAccountCode != null)
        //                {
        //                    if (debtAccountCode.IndexOf(".0000") == -1)
        //                        throw new TTUtils.TTException(SystemMessage.GetMessage(184, new string[] { "Borç Hesap Kodunda," , "(" + this.MoneyReceivedType.Name + ")" }));
        //                    else
        //                    {
        //                        if (SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") == "")
        //                            throw new TTUtils.TTException(SystemMessage.GetMessage(183));
        //                        else
        //                            debtAccountCode = debtAccountCode.Substring(0, debtAccountCode.IndexOf(".")+1) + SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") + debtAccountCode.Substring(debtAccountCode.IndexOf(".")+5, debtAccountCode.Length - (debtAccountCode.IndexOf(".")+5));
        //                    }
        //                }
        //                */
                       
        //                RI.TotalPrice = (double)this.AccountAction.TotalPrice;
                        
        //                RI.Lines = new List<AccountDocument.ReceiptLine>();
                        
        //                AccountDocument.ReceiptLine rLine1 = new AccountDocument.ReceiptLine();
        //                rLine1.Description = "Vezne Tahsilat (" + this.MoneyReceivedType.Name.ToString() + ")";
        //                rLine1.AccountCode = accountCode;
        //                rLine1.IsDebt = false;
        //                rLine1.Price = (double)this.AccountAction.TotalPrice;
        //                rLine1.CurrencyRate = 1;
        //                RI.Lines.Add(rLine1);
                        
        //                AccountDocument.ReceiptLine rLine2 = new AccountDocument.ReceiptLine();
        //                rLine2.Description = "Vezne Tahsilat (" + this.MoneyReceivedType.Name.ToString() + ")";
        //                rLine2.AccountCode = debtAccountCode;
        //                rLine2.IsDebt = true;
        //                rLine2.Price = (double)this.AccountAction.TotalPrice;
        //                rLine2.CurrencyRate = 1;
        //                RI.Lines.Add(rLine2);
                        
        //                this.CreateReceiptLineObjectIDs(RI);
        //                this.ControlReceiptInfo(RI, "Vezne Tahsilat");
        //            }
        //        }
        //    }
        //    return RI;
        //}
        
#endregion Methods

    }
}