
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
    /// Vezne İade Dökümanı
    /// </summary>
    public  partial class MainCashOfficeBackDocument : AccountDocument
    {
#region Methods
        public MainCashOfficeBackDocumentGroup AddDocumentGroup(string pCode, string pDesc)
        {
            MainCashOfficeBackDocumentGroup cdg = new MainCashOfficeBackDocumentGroup(ObjectContext);
            
            cdg.GroupCode = pCode;
            cdg.GroupDescription = pDesc;
            cdg.AccountDocument = this;
            MainCashOfficeBackDocumentGroups.Add(cdg);
            return cdg;
        }
        
        public void Cancel()
        {
            if (CurrentStateDefID != MainCashOfficeBackDocument.States.Cancelled)
            {
                foreach (MainCashOfficeBackDocumentGroup recGroup in MainCashOfficeBackDocumentGroups)
                {
                    foreach (MainCashOfficeBackDocumentDetail recDetail in recGroup.MainCashOfficeBackDocumentDetails)
                    {
                        recDetail.CurrentStateDefID = MainCashOfficeBackDocumentDetail.States.Cancelled;
                    }
                }
                CurrentStateDefID = MainCashOfficeBackDocument.States.Cancelled;
                // this.CreateReceiptInfoAndSendToAccounting();   // muhasebeye ters hareket gönderir
            }
        }
        
        public AccountDocument.ReceiptInfo CreateReceiptInfoForAccounting()
        {
            AccountDocument.ReceiptInfo RI = null;
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if (MoneyBackType.IsBankOperation == true)
                    return RI;

                if (CurrentStateDefID == MainCashOfficeBackDocument.States.Paid && SendToAccounting == false)
                {
                    if (MoneyBackType.AccountEntegration == true)
                    {
                        string accountCode = null;
                        string debtAccountCode = null;
                        
                        RI = new AccountDocument.ReceiptInfo();
                        CreateBasicReceiptInfo(ref RI);
                        
                        RI.Description = AccountAction.Description;
                        RI.Type = AccountDocument.ReceiptTypeEnum.VezneIade;
                        
                        accountCode = MoneyBackType.AccountCode;
                        debtAccountCode = MoneyBackType.DebtAccountCode;
                        
                        RI.TotalPrice = (double)AccountAction.TotalPrice;
                        
                        RI.Lines = new List<AccountDocument.ReceiptLine>();
                        
                        AccountDocument.ReceiptLine rLine1 = new AccountDocument.ReceiptLine();
                        
                        if(BackBankAccount == null)
                        {
                            rLine1.Description = TTUtils.CultureService.GetText("M27193", "Vezne İade (")+ MoneyBackType.Name.ToString() + ")";
                            rLine1.AccountCode = accountCode;
                        }
                        else
                        {
                            rLine1.Description = TTUtils.CultureService.GetText("M25233", "Bankadan İade (")+ MoneyBackType.Name.ToString() + ")";
                            rLine1.AccountCode = BackBankAccount.AccountCode;
                        }
                        
                        rLine1.IsDebt = false;
                        rLine1.Price = (double)AccountAction.TotalPrice;
                        rLine1.CurrencyRate = 1;
                        RI.Lines.Add(rLine1);
                        
                        AccountDocument.ReceiptLine rLine2 = new AccountDocument.ReceiptLine();
                        rLine2.Description = TTUtils.CultureService.GetText("M27193", "Vezne İade (")+ MoneyBackType.Name.ToString() + ")";
                        rLine2.AccountCode = debtAccountCode;
                        rLine2.IsDebt = true;
                        rLine2.Price = (double)AccountAction.TotalPrice;
                        rLine2.CurrencyRate = 1;
                        RI.Lines.Add(rLine2);
                        
                        CreateReceiptLineObjectIDs(RI);
                        ControlReceiptInfo(RI, TTUtils.CultureService.GetText("M27192", "Vezne İade"));
                    }
                }
            }
            return RI;
        }

        public AccountDocument.BankDelivery CreateBankDeliveryForAccounting()
        {
            AccountDocument.BankDelivery BD = null;
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if (CurrentStateDefID == MainCashOfficeBackDocument.States.Paid && SendToAccounting == false)
                {
                    if (MoneyBackType.IsBankOperation == true && MoneyBackType.AccountEntegration == true)
                    {
                        if (BankAccount.AccountCode == null)
                            throw new TTUtils.TTException(SystemMessage.GetMessageV3(133, new string[] { "(" + BankAccount.BankBranch.Bank.Name + " " + BankAccount.BankBranch.Name + " " + BankAccount.AccountNo + ")" }));
                        else
                        {
                            if (BankAccount.AccountCode.Trim() == "")
                                throw new TTUtils.TTException(SystemMessage.GetMessageV3(133, new string[] { "(" + BankAccount.BankBranch.Bank.Name + " " + BankAccount.BankBranch.Name + " " + BankAccount.AccountNo + ")" }));
                        }
                        
                        BD = new AccountDocument.BankDelivery();
                        
                        BD.ObjectId = ObjectID.ToString();
                        BD.DeliveryDate = (DateTime)DocumentDate;
                        
                        BD.Description = "Teslimat Müzekkeresi. " + AccountAction.Description;
                        if (BD.Description == null)
                            BD.Description = " ";
                        
                        BD.Price = (double)AccountAction.TotalPrice;
                        BD.AccountCode = BankAccount.AccountCode;
                        
                        BD.SerialNo = DocumentNo;
                        if (BD.SerialNo == null)
                            BD.SerialNo = "-";
                        
                        BD.CashierName = CashierLog.ResUser.Person.FullName;
                    }
                }
            }
            return BD;
        }
        
#endregion Methods

    }
}