
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
    /// Avans İade Dökümanı
    /// </summary>
    public  partial class AdvanceBackDocument : AccountDocument
    {
#region Methods
        public AdvanceBackDocumentGroup AddDocumentGroup(string pCode, string pDesc)
        {
            AdvanceBackDocumentGroup adg = new AdvanceBackDocumentGroup(ObjectContext);
            
            adg.GroupCode = pCode;
            adg.GroupDescription = pDesc;
            adg.AccountDocument = this;
            AdvanceBackDocumentGroups.Add(adg);
            return adg;
        }

        public AccountDocument.ReceiptInfo CreateReceiptInfoForAccounting()
        {
            AccountDocument.ReceiptInfo RI = null;
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if (CurrentStateDefID == AdvanceBackDocument.States.Paid && SendToAccounting == false)
                {
                    RI = new AccountDocument.ReceiptInfo();
                    CreateBasicReceiptInfo(ref RI);
                    RI.Type = AccountDocument.ReceiptTypeEnum.AvansIade;
                    
                    RI.Lines = new List<AccountDocument.ReceiptLine>();
                    
                    // Paid e alınan accTrx ler için bölüm gelir hesapları çalışmalı
                    double prcTrxTotal = 0;
                    double matTrxTotal = 0;
                    
                    foreach (AccountDocumentGroup adg in AccountDocumentGroups)
                    {
                        foreach (AccountDocumentDetail addet in adg.AccountDocumentDetails)
                        {
                            foreach (AccountTrxDocument accTrxDoc in addet.AccountTrxDocument)
                            {
                                if (accTrxDoc.AccountTransaction.PackageDefinition == null)
                                {
                                    if (accTrxDoc.AccountTransaction.SubActionProcedure != null)
                                        prcTrxTotal = prcTrxTotal + ((double)accTrxDoc.AccountTransaction.Amount * (double)accTrxDoc.AccountTransaction.UnitPrice);
                                    else if(accTrxDoc.AccountTransaction.SubActionMaterial != null)
                                        matTrxTotal = matTrxTotal + ((double)accTrxDoc.AccountTransaction.Amount * (double)accTrxDoc.AccountTransaction.UnitPrice);
                                }
                            }
                        }
                    }
                    
                    // Fişin toplam tutarı bu şekilde set edilmeli yoksa uyumsuzluk çıkıyor ControlReceiptInfo da.
                    RI.TotalPrice = (double)EpisodeAccountAction.TotalPrice + (double)prcTrxTotal + (double)matTrxTotal;
                    
                    if (matTrxTotal > 0 || prcTrxTotal > 0)
                    {
                        string accountCodeStart = "";
                        string accountCode = "";
                        bool addLine = true;
                        double lineTotal = 0;
                        RevenueSubAccountCodeDefinition revenueCode = null;
                        
                        if (EpisodeAccountAction.Episode.Patient.Foreign == true)
                            accountCodeStart = "601."; // + SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") + ".";
                        else
                            accountCodeStart = "600."; // + SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") + ".";
                        
                        if (matTrxTotal > 0)
                        {
                            AccountDocument.ReceiptLine rLine = new AccountDocument.ReceiptLine();
                            rLine.Description = TTUtils.CultureService.GetText("M26072", "İlaç ve Tıbbi Sarf Malzemesi Gelirleri");
                            rLine.AccountCode = accountCodeStart + "08";
                            rLine.IsDebt = false;
                            rLine.Price = (double)matTrxTotal;
                            rLine.CurrencyRate = 1;
                            RI.Lines.Add(rLine);
                        }
                        
                        if (prcTrxTotal > 0)
                        {
                            foreach (AccountDocumentGroup adg in AccountDocumentGroups)
                            {
                                foreach (AccountDocumentDetail addet in adg.AccountDocumentDetails)
                                {
                                    foreach (AccountTrxDocument accTrxDoc in addet.AccountTrxDocument)
                                    {
                                        if (accTrxDoc.AccountTransaction.SubActionProcedure != null)
                                        {
                                            if (accTrxDoc.AccountTransaction.PackageDefinition == null)
                                            {
                                                accountCode = "";
                                                addLine = true;
                                                revenueCode = null;
                                                revenueCode = accTrxDoc.AccountTransaction.SubActionProcedure.ProcedureObject.GetRevenueSubAccountCode();
                                                
                                                if (revenueCode == null)
                                                    throw new TTUtils.TTException(SystemMessage.GetMessageV3(127, new string[] { accTrxDoc.AccountTransaction.SubActionProcedure.ProcedureObject.Code , accTrxDoc.AccountTransaction.SubActionProcedure.ProcedureObject.Name }));
                                                else
                                                {
                                                    if (((double)accTrxDoc.AccountTransaction.Amount * (double)accTrxDoc.AccountTransaction.UnitPrice) > 0)
                                                    {
                                                        accountCode = accountCodeStart + revenueCode.AccountCode;
                                                        
                                                        foreach (AccountDocument.ReceiptLine rLine in RI.Lines)
                                                        {
                                                            if (rLine.AccountCode == accountCode)
                                                            {
                                                                rLine.Price = rLine.Price + ((double)accTrxDoc.AccountTransaction.Amount * (double)accTrxDoc.AccountTransaction.UnitPrice); // line larda var, fiyata ekle
                                                                addLine = false;
                                                                break;
                                                            }
                                                        }
                                                        if (addLine)  // line larda yok, yeni line ekle
                                                        {
                                                            AccountDocument.ReceiptLine rLine1 = new AccountDocument.ReceiptLine();
                                                            rLine1.Description = revenueCode.Description;
                                                            rLine1.AccountCode = accountCode;
                                                            rLine1.IsDebt = false;
                                                            rLine1.Price = ((double)accTrxDoc.AccountTransaction.Amount * (double)accTrxDoc.AccountTransaction.UnitPrice);
                                                            rLine1.CurrencyRate = 1;
                                                            RI.Lines.Add(rLine1);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    AccountDocument.ReceiptLine rLine2 = new AccountDocument.ReceiptLine();
                    
                    if(BackBankAccount == null)
                    {
                        rLine2.Description = TTUtils.CultureService.GetText("M26566", "Nakit İade");
                        rLine2.AccountCode = GetAccountCode(AccountEntegrationAccountTypeEnum.KasaHesabi);
                    }
                    else
                    {
                        rLine2.Description = TTUtils.CultureService.GetText("M25232", "Bankadan İade");
                        rLine2.AccountCode = BackBankAccount.AccountCode;
                    }
                    
                    rLine2.IsDebt = false;
                    rLine2.Price = (double)EpisodeAccountAction.TotalPrice;
                    rLine2.CurrencyRate = 1;
                    RI.Lines.Add(rLine2);
                    
                    AccountDocument.ReceiptLine rLine3 = new AccountDocument.ReceiptLine();
                    rLine3.Description = TTUtils.CultureService.GetText("M25803", "Hasta Tedavi Avans İadesi");
                    rLine3.AccountCode = GetAccountCode(AccountEntegrationAccountTypeEnum.AvansHesabi);
                    rLine3.IsDebt = true;
                    rLine3.Price = (double)EpisodeAccountAction.TotalPrice + (double)prcTrxTotal + (double)matTrxTotal;
                    rLine3.CurrencyRate = 1;
                    RI.Lines.Add(rLine3);
                    
                    CreateReceiptLineObjectIDs(RI);
                    ControlReceiptInfo(RI, TTUtils.CultureService.GetText("M11258", "Avans İade"));
                }
            }
            return RI;
        }
        
#endregion Methods

    }
}