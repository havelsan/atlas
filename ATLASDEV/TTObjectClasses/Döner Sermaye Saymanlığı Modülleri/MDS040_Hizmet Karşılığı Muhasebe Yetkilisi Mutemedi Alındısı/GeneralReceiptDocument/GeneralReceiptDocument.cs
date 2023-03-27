
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
    /// Hizmet Karşılığı Muhasebe Yetkilisi Mutemedi Alındısı Dökümanı
    /// </summary>
    public  partial class GeneralReceiptDocument : AccountDocument
    {
        protected void PostTransition_Paid2Cancelled()
        {
            // From State : Paid   To State : Cancelled
#region PostTransition_Paid2Cancelled
            Cancel();
#endregion PostTransition_Paid2Cancelled
        }

#region Methods
        public GeneralReceiptDocumentGroup AddDocumentGroup(string pCode, string pDesc)
        {
            GeneralReceiptDocumentGroup cdg = new GeneralReceiptDocumentGroup(ObjectContext);
            cdg.GroupCode = pCode;
            cdg.GroupDescription = pDesc;
            cdg.AccountDocument = this;
            return cdg;
        }
        
        public void Cancel()
        {
            if (CurrentStateDefID != GeneralReceiptDocument.States.Cancelled)
            {
                foreach (GeneralReceiptDocumentGroup recGroup in GeneralReceiptDocumentGroups)
                {
                    foreach (GeneralReceiptDocumentDetail recDetail in recGroup.GeneralReceiptDocumentDetails)
                    {
                        recDetail.CurrentStateDefID = GeneralReceiptDocumentDetail.States.Cancelled;
                    }
                }
                CurrentStateDefID = GeneralReceiptDocument.States.Cancelled;
            }
        }
        
        public AccountDocument.ReceiptInfo CreateReceiptInfoForAccounting()
        {
            AccountDocument.ReceiptInfo RI = null;
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if (CurrentStateDefID == GeneralReceiptDocument.States.Paid && SendToAccounting == false)
                {
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
                    
                    RI.Lines = new List<AccountDocument.ReceiptLine>();
                    
                    CreateReceiptPaymentDetailInfo(ref RI.Lines, true, ReceiptPaymentTypeEnum.All);
                    
                    // hizmet ve malzemeler gelir hesaplarına göre gruplanır
                    
                    string accountCodeStart = "";
                    string accountCode = "";
                    bool addLine = true;
                    double lineTotal = 0;
                    RevenueSubAccountCodeDefinition revenueCode = null;
                    
                    accountCodeStart = "600."; // + SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") + ".";
                    
                    /* Malzeme gridi olmadığı için kapatılmıştır, ileride eklenirse açılması gerekir
                    // malzemeleri ekler
                    foreach (GeneralReceiptMaterial recMat in ((GeneralReceipt)this.AccountAction).GeneralReceiptMaterials)
                    {
                        lineTotal = lineTotal + (double)recMat.TotalPrice;
                    }
                    
                    if (lineTotal > 0)
                    {
                        AccountDocument.ReceiptLine rLine3 = new AccountDocument.ReceiptLine();
                        rLine3.Description = "İlaç ve Tıbbi Sarf Malzemesi Gelirleri";
                        rLine3.AccountCode = accountCodeStart + "08";
                        rLine3.IsDebt = false;
                        rLine3.Price = (double)lineTotal;
                        rLine3.CurrencyRate = 1;
                        RI.Lines.Add(rLine3);
                    }
                     */
                    
                    // hizmetleri ekler
                    foreach (GeneralReceiptProcedure recProc in ((GeneralReceipt)AccountAction).GeneralReceiptProcedures)
                    {
                        accountCode = "";
                        addLine = true;
                        revenueCode = null;
                        revenueCode = recProc.Procedure.GetRevenueSubAccountCode();
                        
                        if (revenueCode == null)
                            throw new TTException(SystemMessage.GetMessageV3(127, new string[] { recProc.Procedure.Code , recProc.Procedure.Name }));
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
                    
                    CreateReceiptLineObjectIDs(RI);
                    ControlReceiptInfo(RI, "Hizmet Karşılığı Muhasebe Yetkilisi Mutemedi Alındısı");
                }
            }
            return RI;
        }
        
        public AccountDocument.ReceiptInfo CreateNonCashReceiptInfoForAccounting()
        {
            AccountDocument.ReceiptInfo RI = null;
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if (CurrentStateDefID == GeneralReceiptDocument.States.Paid && SendToAccounting == false)
                {
                    AccountDocument.ReceiptInfo RIOriginal;
                    RIOriginal = CreateReceiptInfoForAccounting();
                    
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
                    
                    RI.Lines = new List<AccountDocument.ReceiptLine>();
                    
                    double cashPayment = (double)GetCalculatedCashPayment(Convert.ToDateTime(DocumentDate));
                    double linePrice = 0;

                    foreach (AccountDocument.ReceiptLine rLine in RIOriginal.Lines)
                    {
                        if (rLine.IsDebt == false && (rLine.AccountCode.Substring(0,3) == "600"))
                        {
                            if(cashPayment > 0)
                            {
                                linePrice = rLine.Price;
                                
                                if(cashPayment >= rLine.Price)
                                {
                                    AddAccountingLineForCash(rLine.AccountCode, rLine.Description, rLine.Price);
                                }
                                else if(cashPayment < rLine.Price)
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
                    ControlReceiptInfo(RI, "Hizmet Karşılığı Muhasebe Yetkilisi Mutemedi Alındısı");
                }
            }
            return RI;
        }
        
        public AccountDocument.ReceiptInfo CreateCashReceiptInfoForAccounting()
        {
            AccountDocument.ReceiptInfo RI = null;
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if (CurrentStateDefID == GeneralReceiptDocument.States.Paid)
                {
                    RI = new AccountDocument.ReceiptInfo();
                    CreateBasicReceiptInfo(ref RI);
                    
                    RI.ObjectId = RI.ObjectId + "-2";
                    RI.Description = AccountAction.Description;
                    RI.Type = AccountDocument.ReceiptTypeEnum.MuhasebeYetkilisiMutemediAlindisi;
                    RI.TotalPrice = (double)GetCalculatedCashPayment(Convert.ToDateTime(DocumentDate));
                    
                    RI.Lines = new List<AccountDocument.ReceiptLine>();
                    
                    foreach(AccountingLinesForCash line in AccountingLinesForCash)
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
                    ControlReceiptInfo(RI, "Hizmet Karşılığı Muhasebe Yetkilisi Mutemedi Alındısı");
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
            alfc.GeneralReceiptDocument = this;
            AccountingLinesForCash.Add(alfc);
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(GeneralReceiptDocument).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == GeneralReceiptDocument.States.Paid && toState == GeneralReceiptDocument.States.Cancelled)
                PostTransition_Paid2Cancelled();
        }

    }
}