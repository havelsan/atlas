
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
    public  partial class ManualInvoiceDocument : AccountDocument
    {
        public partial class GetManualInvoiceDocumentByPayer_Class : TTReportNqlObject 
        {
        }

        protected void PostTransition_Send2Cancelled()
        {
            // From State : Send   To State : Cancelled
#region PostTransition_Send2Cancelled
            Cancel();
#endregion PostTransition_Send2Cancelled
        }

#region Methods
        public void Cancel()
        {
            if (CurrentStateDefID != ManualInvoiceDocument.States.Cancelled)
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
               
                CurrentStateDefID = ManualInvoiceDocument.States.Cancelled;
            }
        }
/*
        public AccountDocument.InvoiceInfo CreateInvoiceInfoForAccounting()
        {
            AccountDocument.InvoiceInfo II = null;
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if ((this.CurrentStateDefID == ManualInvoiceDocument.States.Send || this.CurrentStateDefID == ManualInvoiceDocument.States.Paid) && this.SendToAccounting == false)
                {
                    II = new AccountDocument.InvoiceInfo();
                    this.CreateBasicInvoiceInfo(ref II);
                    II.PayerName = ((GeneralInvoice)this.AccountAction).Payer.Code + " " + ((ManualInvoice)this.AccountAction).Payer.Name;
                    II.TotalPrice = (double)this.AccountAction.TotalPrice;
                    
                    II.Lines = new List<AccountDocument.InvoiceLine>();
                    
                    
                    
                    if (this.AccountAction.TotalPrice != null) // indirimden sonraki (net) fatura tutarı kadar kurum borçlandırılır
                    {
                        if (this.AccountAction.TotalPrice > 0)
                        {
                            AccountDocument.InvoiceLine iLine2 = new AccountDocument.InvoiceLine();
                            iLine2.Description = "Kurum Hesabı";
                            iLine2.AccountCode = ((ManualInvoice)this.AccountAction).Payer.GetAccountCode();
                            iLine2.IsDebt = true;
                            iLine2.Price = (double)this.AccountAction.TotalPrice;
                            iLine2.CurrencyRate = 1;
                            II.Lines.Add(iLine2);
                        }
                    }
                    
                    // hizmet ve malzemeler gelir hesaplarına göre gruplanır
                    
                    string accountCodeStart = "600."; // + SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") + ".";
                    string accountCode = "";
                    bool addLine = true;
                    double lineTotal = 0;
                    RevenueSubAccountCodeDefinition revenueCode = null;
                    
                   
                    
                    // hizmetleri ekler
                    foreach (ManualInvoiceProcedure invProc in ((ManualInvoice)this.AccountAction).ManualInvoiceProcedures)
                    {
                        accountCode = "";
                        addLine = true;
                        revenueCode = null;
                        revenueCode = invProc.Procedure.GetRevenueSubAccountCode();
                        
                        if (revenueCode == null)
                            throw new TTUtils.TTException(SystemMessage.GetMessage(127, new string[] { , invProc.Procedure}));
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
                                    AccountDocument.InvoiceLine iLine4 = new AccountDocument.InvoiceLine();
                                    iLine4.Description = revenueCode.Description;
                                    iLine4.AccountCode = accountCode;
                                    iLine4.IsDebt = false;
                                    iLine4.Price = (double)invProc.TotalPrice;
                                    iLine4.CurrencyRate = 1;
                                    II.Lines.Add(iLine4);
                                }
                            }
                        }
                    }
                    this.CreateInvoiceLineObjectIDs(II);
                    this.ControlInvoiceInfo(II, "Hizmet Karşılığı Kurum Faturası");
                }
            }
            return II;
        }
 */
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ManualInvoiceDocument).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ManualInvoiceDocument.States.Send && toState == ManualInvoiceDocument.States.Cancelled)
                PostTransition_Send2Cancelled();
        }

    }
}