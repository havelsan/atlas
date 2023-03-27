
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
    /// Vezne Kapama Dökümanı 
    /// </summary>
    public partial class CashOfficeClosingDocument : AccountDocument
    {
        #region Methods
        public CashOfficeClosingDocumentGroup AddDocumentGroup(string pCode, string pDesc)
        {
            CashOfficeClosingDocumentGroup cocdg = new CashOfficeClosingDocumentGroup(ObjectContext);
            cocdg.GroupCode = pCode;
            cocdg.GroupDescription = pDesc;
            cocdg.AccountDocument = this;
            CashOfficeClosingDocumentGroups.Add(cocdg);
            return cocdg;
        }

        /*
        public AccountDocument.ReceiptInfo CreateReceiptInfoForAccounting(double TotalPrice)
        {
            AccountDocument.ReceiptInfo RI = null;
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if (this.CurrentStateDefID == CashOfficeClosingDocument.States.Submitted && this.SendToAccounting == false)
                {
                    string accountCode = null;
                    
                    RI = new AccountDocument.ReceiptInfo();
                    this.CreateBasicReceiptInfo(ref RI);
                    RI.TotalPrice = TotalPrice;
                    RI.Description = "Vezne Kapama";
                    RI.Type = AccountDocument.ReceiptTypeEnum.BankayaParaTransferi;
                    
                    RI.Lines = new List<AccountDocument.ReceiptLine>();
                    
                    AccountDocument.ReceiptLine rLine1 = new AccountDocument.ReceiptLine();
                    rLine1.Description = "Vezne Kapama (Bankaya Para Transferi)";
                    rLine1.AccountCode = this.BankAccount.AccountCode;
                    rLine1.IsDebt = true;
                    rLine1.Price = TotalPrice;
                    rLine1.CurrencyRate = 1;
                    RI.Lines.Add(rLine1);
                    
                    AccountDocument.ReceiptLine rLine2 = new AccountDocument.ReceiptLine();
                    rLine2.Description = "Nakit Ödeme";
                    rLine2.AccountCode = this.GetAccountCode(AccountEntegrationAccountTypeEnum.KasaHesabi);
                    rLine2.IsDebt = false;
                    rLine2.Price = TotalPrice;
                    rLine2.CurrencyRate = 1;
                    RI.Lines.Add(rLine2);
                    
                    this.CreateReceiptLineObjectIDs(RI);
                    this.ControlReceiptInfo(RI, "Vezne Kapama");
                }
            }
            return RI;
        }
         */

        public AccountDocument.BankDelivery CreateBankDeliveryForAccounting(double TotalPrice)
        {
            AccountDocument.BankDelivery BD = null;

            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if (CurrentStateDefID == CashOfficeClosingDocument.States.Submitted && SendToAccounting == false)
                {
                    if (BankAccount.AccountCode == null)
                        throw new TTException(SystemMessage.GetMessageV3(1189, new string[] { BankAccount.BankBranch.Bank.Name.ToString(), BankAccount.BankBranch.Name.ToString(), BankAccount.AccountNo.ToString() }));
                    else
                    {
                        if (BankAccount.AccountCode.Trim() == "")
                            throw new TTException(SystemMessage.GetMessageV3(1189, new string[] { BankAccount.BankBranch.Bank.Name.ToString(), BankAccount.BankBranch.Name.ToString(), BankAccount.AccountNo.ToString() }));
                    }

                    BD = new AccountDocument.BankDelivery();

                    BD.ObjectId = ObjectID.ToString();
                    BD.DeliveryDate = (DateTime)DocumentDate;

                    //if(this.CashierLog.CashOffice.Type == CashOfficeTypeEnum.CashOffice)
                    //  BD.Description = "Muhasebe Yetkilisi Mutemetliği Kapama. (Açılış İz Sürme No: " + this.CashierLog.LogID + ")";
                    /*else*/
                    if (CashierLog.CashOffice.Type == CashOfficeTypeEnum.CashOffice)
                        BD.Description = "Vezne Kapama. (Açılış İz Sürme No: " + CashierLog.LogID + ")";

                    if (BD.Description == null)
                        BD.Description = " ";

                    BD.Price = TotalPrice;
                    BD.AccountCode = BankAccount.AccountCode;

                    BD.SerialNo = DocumentNo;
                    if (BD.SerialNo == null)
                        BD.SerialNo = "-";

                    BD.CashierName = CashierLog.ResUser.Person.FullName;
                }
            }
            return BD;
        }

        #endregion Methods

    }
}