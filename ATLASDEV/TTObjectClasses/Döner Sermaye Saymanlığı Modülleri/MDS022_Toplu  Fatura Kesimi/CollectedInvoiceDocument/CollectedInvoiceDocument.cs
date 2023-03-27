
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
    /// Toplu Fatura Dökümanı
    /// </summary>
    public  partial class CollectedInvoiceDocument : AccountDocument
    {
#region Methods
        public void Cancel()
        {
            if (CurrentStateDefID != CollectedInvoiceDocument.States.Cancelled)
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

                CollectedInvoiceDocumentGroups[0].CollectedInvoiceDocumentDetails[0].CurrentStateDefID = CollectedInvoiceDocumentDetail.States.Cancelled;
                CurrentStateDefID = CollectedInvoiceDocument.States.Cancelled;
            }
        }

        public AccountDocument.InvoiceInfo CreateInvoiceInfoForAccounting()
        {
            AccountDocument.InvoiceInfo II = null;
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if ((CurrentStateDefID == CollectedInvoiceDocument.States.Send || CurrentStateDefID == CollectedInvoiceDocument.States.Paid) && SendToAccounting == false)
                {
                    II = new AccountDocument.InvoiceInfo();
                    CreateBasicInvoiceInfo(ref II);
                    II.PayerName = ((CollectedInvoice)AccountAction).Payer.Code + " " + ((CollectedInvoice)AccountAction).Payer.Name;
                    II.TotalPrice = (double)AccountAction.TotalPrice;
                    
                    II.Lines = new List<AccountDocument.InvoiceLine>();
                    
                    if (AccountAction.TotalPrice != null)
                    {
                        if (AccountAction.TotalPrice > 0)
                        {
                            AccountDocument.InvoiceLine iLine1 = new AccountDocument.InvoiceLine();
                            iLine1.Description = TTUtils.CultureService.GetText("M26362", "Kurum Hesabı");
                            iLine1.AccountCode = ((CollectedInvoice)AccountAction).Payer.GetAccountCode();
                            iLine1.IsDebt = true;
                            iLine1.Price = (double)AccountAction.TotalPrice;
                            iLine1.CurrencyRate = 1;
                            II.Lines.Add(iLine1);
                        }
                    }
                    
                    // Malzeme, hizmet ve paketler aşağıda gelir hesaplarına göre gruplanır
                    string accountCodeStart = "";
                    string accountCode = "";
                    bool addLine = true;
                    double lineTotal = 0;
                    RevenueSubAccountCodeDefinition revenueCode = null;
                    
                    foreach (CollectedPatientList patientList in ((CollectedInvoice)AccountAction).CollectedPatients)
                    {
                        // Toplu faturaya hazır a getrilmiş olanlar
                        if (((CollectedInvoice)AccountAction).LISTTYPE == true)
                        {
                            if (patientList.PayerInvoice != null)
                            {
                                if (patientList.PayerInvoice.Episode.Patient.Foreign == true)
                                    accountCodeStart = "601."; // + SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") + ".";
                                else
                                    accountCodeStart = "600."; // + SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") + ".";
                                
                                lineTotal = 0;
                                addLine = true;
                                
                                // malzemeleri ekler
                                foreach (PayerInvoiceMaterial invMat in patientList.PayerInvoice.PayerInvoiceMaterials)
                                {
                                    if (invMat.Paid == true)
                                        lineTotal = lineTotal + (double)invMat.TotalPrice;
                                }
                                
                                if ((double)lineTotal > 0) // malzeme varsa
                                {
                                    accountCode = accountCodeStart + "08";
                                    
                                    foreach (AccountDocument.InvoiceLine iLine in II.Lines)
                                    {
                                        if (iLine.AccountCode == accountCode)
                                        {
                                            iLine.Price = iLine.Price + (double)lineTotal; // line larda var, fiyata ekle
                                            addLine = false;
                                            break;
                                        }
                                    }
                                    if (addLine)  // line larda yok, yeni line ekle
                                    {
                                        AccountDocument.InvoiceLine iLine2 = new AccountDocument.InvoiceLine();
                                        iLine2.Description = TTUtils.CultureService.GetText("M26072", "İlaç ve Tıbbi Sarf Malzemesi Gelirleri");
                                        iLine2.AccountCode = accountCode;
                                        iLine2.IsDebt = false;
                                        iLine2.Price = (double)lineTotal;
                                        iLine2.CurrencyRate = 1;
                                        II.Lines.Add(iLine2);
                                    }
                                }
                                
                                // hizmetleri ekler
                                foreach (PayerInvoiceProcedure invProc in patientList.PayerInvoice.PayerInvoiceProcedures)
                                {
                                    if (invProc.Paid == true)
                                    {
                                        accountCode = "";
                                        addLine = true;
                                        revenueCode = null;
                                        revenueCode = invProc.AccountTransaction[0].SubActionProcedure.ProcedureObject.GetRevenueSubAccountCode();
                                        
                                        if (revenueCode == null)
                                            throw new TTUtils.TTException(SystemMessage.GetMessageV3(127, new string[] { invProc.ExternalCode , invProc.Description }));
                                        else
                                        {
                                            if ((double)invProc.TotalPrice > 0)
                                            {
                                                accountCode = accountCodeStart + revenueCode.AccountCode;
                                                
                                                foreach (AccountDocument.InvoiceLine iLine in II.Lines)
                                                {
                                                    if (iLine.AccountCode == accountCode)
                                                    {
                                                        iLine.Price = iLine.Price + (double)invProc.TotalPrice; // line larda var, fiyata ekle
                                                        addLine = false;
                                                        break;
                                                    }
                                                }
                                                if (addLine)  // line larda yok, yeni line ekle
                                                {
                                                    AccountDocument.InvoiceLine iLine3 = new AccountDocument.InvoiceLine();
                                                    iLine3.Description = revenueCode.Description;
                                                    iLine3.AccountCode = accountCode;
                                                    iLine3.IsDebt = false;
                                                    iLine3.Price = (double)invProc.TotalPrice;
                                                    iLine3.CurrencyRate = 1;
                                                    II.Lines.Add(iLine3);
                                                }
                                            }
                                        }
                                    }
                                }
                                
                                // paketleri ekler
                                foreach (PayerInvoicePackage invPack in patientList.PayerInvoice.PayerInvoicePackages)
                                {
                                    if (invPack.Paid == true)
                                    {
                                        accountCode = "";
                                        addLine = true;
                                        revenueCode = null;
                                        revenueCode = invPack.PackageAccountTransaction[0].SubActionProcedure.ProcedureObject.GetRevenueSubAccountCode();
                                        
                                        if (revenueCode == null)
                                            throw new TTUtils.TTException(SystemMessage.GetMessageV3(220, new string[] { invPack.PackageCode , invPack.PackageName }));
                                        else
                                        {
                                            if ((double)invPack.PackagePrice > 0)
                                            {
                                                accountCode = accountCodeStart + revenueCode.AccountCode;
                                                
                                                foreach (AccountDocument.InvoiceLine iLine in II.Lines)
                                                {
                                                    if (iLine.AccountCode == accountCode)
                                                    {
                                                        iLine.Price = iLine.Price + (double)invPack.PackagePrice; // line larda var, fiyata ekle
                                                        addLine = false;
                                                        break;
                                                    }
                                                }
                                                if (addLine && (double)invPack.PackagePrice > 0)  // line larda yok, yeni line ekle
                                                {
                                                    AccountDocument.InvoiceLine iLine4 = new AccountDocument.InvoiceLine();
                                                    iLine4.Description = revenueCode.Description;
                                                    iLine4.AccountCode = accountCode;
                                                    iLine4.IsDebt = false;
                                                    iLine4.Price = (double)invPack.PackagePrice;
                                                    iLine4.CurrencyRate = 1;
                                                    II.Lines.Add(iLine4);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else  // Toplu fatura hazır a getirilmemiş olanlar
                        {
                            if (patientList.Episode.Patient.Foreign == true)
                                accountCodeStart = "601."; // + SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") + ".";
                            else
                                accountCodeStart = "600."; // + SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") + ".";

                            foreach (AccountTransaction accTrx in patientList.AccountTransactions)
                            {
                                accountCode = "";
                                addLine = true;

                                if ((double)Math.Round((double)(accTrx.UnitPrice * accTrx.Amount),2) > 0)
                                {
                                    if (accTrx.SubActionMaterial != null) // malzeme
                                    {
                                        accountCode = accountCodeStart + "08";
                                        
                                        foreach (AccountDocument.InvoiceLine iLine in II.Lines)
                                        {
                                            if (iLine.AccountCode == accountCode)
                                            {
                                                iLine.Price = iLine.Price + (double)Math.Round((double)(accTrx.UnitPrice * accTrx.Amount),2); // line larda var, fiyata ekle
                                                addLine = false;
                                                break;
                                            }
                                        }
                                        if (addLine)  // line larda yok, yeni line ekle
                                        {
                                            AccountDocument.InvoiceLine iLine5 = new AccountDocument.InvoiceLine();
                                            iLine5.Description = TTUtils.CultureService.GetText("M26072", "İlaç ve Tıbbi Sarf Malzemesi Gelirleri");
                                            iLine5.AccountCode = accountCode;
                                            iLine5.IsDebt = false;
                                            iLine5.Price = (double)Math.Round((double)(accTrx.UnitPrice * accTrx.Amount),2);
                                            iLine5.CurrencyRate = 1;
                                            II.Lines.Add(iLine5);
                                        }
                                    }
                                    else if (accTrx.SubActionProcedure != null) // hizmet ve paket
                                    {
                                        revenueCode = null;
                                        revenueCode = accTrx.SubActionProcedure.ProcedureObject.GetRevenueSubAccountCode();
                                        
                                        if (revenueCode == null)
                                            throw new TTUtils.TTException(SystemMessage.GetMessageV3(127, new string[] { accTrx.SubActionProcedure.ProcedureObject.Code , accTrx.SubActionProcedure.ProcedureObject.Description }));
                                        else
                                        {
                                            accountCode = accountCodeStart + revenueCode.AccountCode;
                                            
                                            foreach (AccountDocument.InvoiceLine iLine in II.Lines)
                                            {
                                                if (iLine.AccountCode == accountCode)
                                                {
                                                    iLine.Price = iLine.Price + (double)Math.Round((double)(accTrx.UnitPrice * accTrx.Amount),2); // line larda var, fiyata ekle
                                                    addLine = false;
                                                    break;
                                                }
                                            }
                                            if (addLine)  // line larda yok, yeni line ekle
                                            {
                                                AccountDocument.InvoiceLine iLine6 = new AccountDocument.InvoiceLine();
                                                iLine6.Description = revenueCode.Description;
                                                iLine6.AccountCode = accountCode;
                                                iLine6.IsDebt = false;
                                                iLine6.Price = (double)Math.Round((double)(accTrx.UnitPrice * accTrx.Amount),2);
                                                iLine6.CurrencyRate = 1;
                                                II.Lines.Add(iLine6);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    CreateInvoiceLineObjectIDs(II);
                    ControlInvoiceInfo(II, TTUtils.CultureService.GetText("M27110", "Toplu Fatura"));
                }
            }
            return II;
        }
        
#endregion Methods

    }
}