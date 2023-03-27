
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
    public  partial class GeneralInvoiceDocument : AccountDocument
    {
        public partial class GetGeneralInvoiceDocumentByPayer_Class : TTReportNqlObject 
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
        public GeneralInvoiceDocumentGroup AddDocumentGroup(string pCode, string pDesc)
        {
            GeneralInvoiceDocumentGroup cdg = new GeneralInvoiceDocumentGroup(ObjectContext);
            cdg.GroupCode = pCode;
            cdg.GroupDescription = pDesc;
            cdg.AccountDocument = this;
            return cdg;
        }
        
        public void Cancel()
        {
            if (CurrentStateDefID != GeneralInvoiceDocument.States.Cancelled)
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
                
                foreach (GeneralInvoiceDocumentGroup invGroup in GeneralInvoiceDocumentGroups)
                {
                    foreach (GeneralInvoiceDocumentDetail invDetail in invGroup.GeneralInvoiceDocumentDetails)
                    {
                        invDetail.CurrentStateDefID = GeneralInvoiceDocumentDetail.States.Cancelled;
                    }
                }
                CurrentStateDefID = GeneralInvoiceDocument.States.Cancelled;
            }
        }

        public AccountDocument.InvoiceInfo CreateInvoiceInfoForAccounting()
        {
            AccountDocument.InvoiceInfo II = null;
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if ((CurrentStateDefID == GeneralInvoiceDocument.States.Send || CurrentStateDefID == GeneralInvoiceDocument.States.Paid) && SendToAccounting == false)
                {
                    II = new AccountDocument.InvoiceInfo();
                    CreateBasicInvoiceInfo(ref II);
                    II.PayerName = ((GeneralInvoice)AccountAction).Payer.Code + " " + ((GeneralInvoice)AccountAction).Payer.Name;
                    II.TotalPrice = (double)AccountAction.TotalPrice;
                    
                    II.Lines = new List<AccountDocument.InvoiceLine>();
                    
                    /*  İndirim olmadığı için bu kısım kapatıldı, ilerde indirim istenirse açılması ve aşağıdaki kısmın da
                     *  indirimden sonraki net tutar kadar çalışması gerekir
                     * 
                    if (this.EpisodeAccountAction.TotalDiscountPrice != null) // indirim
                    {
                        if (this.EpisodeAccountAction.TotalDiscountPrice > 0)
                        {
                            AccountDocument.InvoiceLine iLine1 = new AccountDocument.InvoiceLine();
                            iLine1.Description = "İndirim Hesabı";
                            iLine1.AccountCode = this.GetAccountCode(AccountEntegrationAccountTypeEnum.IndirimHesabi);
                            iLine1.IsDebt = true;
                            iLine1.Price = (double)this.EpisodeAccountAction.TotalDiscountPrice;
                            iLine1.CurrencyRate = 1;
                            II.Lines.Add(iLine1);
                        }
                    }
                     */
                    
                    if (AccountAction.TotalPrice != null) // indirimden sonraki (net) fatura tutarı kadar kurum borçlandırılır
                    {
                        if (AccountAction.TotalPrice > 0)
                        {
                            AccountDocument.InvoiceLine iLine2 = new AccountDocument.InvoiceLine();
                            iLine2.Description = TTUtils.CultureService.GetText("M26362", "Kurum Hesabı");
                            iLine2.AccountCode = ((GeneralInvoice)AccountAction).Payer.GetAccountCode();
                            iLine2.IsDebt = true;
                            iLine2.Price = (double)AccountAction.TotalPrice;
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
                    
                    /* malzemeleri ekler
                     * malzeme olmadığı için bu kısım kapatılmıştır, ilerde malzeme eklenirse açılması gerekir
                    foreach (PayerInvoiceMaterial invMat in ((PayerInvoice)this.EpisodeAccountAction).PayerInvoiceMaterials)
                    {
                        if (invMat.Paid == true)
                            lineTotal = lineTotal + (double)invMat.TotalPrice;
                    }
                    
                    if (lineTotal > 0)
                    {
                        AccountDocument.InvoiceLine iLine3 = new AccountDocument.InvoiceLine();
                        iLine3.Description = "İlaç ve Tıbbi Sarf Malzemesi Gelirleri";
                        iLine3.AccountCode = accountCodeStart + "08";
                        iLine3.IsDebt = false;
                        iLine3.Price = (double)lineTotal;
                        iLine3.CurrencyRate = 1;
                        II.Lines.Add(iLine3);
                    }
                     */
                    
                    // hizmetleri ekler
                    foreach (GeneralInvoiceProcedure invProc in ((GeneralInvoice)AccountAction).GeneralInvoiceProcedures)
                    {
                        accountCode = "";
                        addLine = true;
                        revenueCode = null;
                        revenueCode = invProc.Procedure.GetRevenueSubAccountCode();
                        
                        if (revenueCode == null)
                            throw new TTUtils.TTException(SystemMessage.GetMessageV3(127, new string[] {invProc.Procedure.Code, invProc.Procedure.Name}));
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
                    
                    /* paketleri ekler
                     * paket olmadığı için bu kısım kapatılmıştır, ilerde paket eklenirse açılması gerekir
                    foreach (PayerInvoicePackage invPack in ((PayerInvoice)this.EpisodeAccountAction).PayerInvoicePackages)
                    {
                        if (invPack.Paid == true)
                        {
                            accountCode = "";
                            addLine = true;
                            revenueCode = null;
                            revenueCode = invPack.PackageAccountTransaction[0].SubActionProcedure.ProcedureObject.GetRevenueSubAccountCode();
                            
                            if (revenueCode == null)
                                throw new TTUtils.TTException(SystemMessage.GetMessage(220, new string[] {invPack.PackageCode , invPack.PackageName}));
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
                                    if (addLine)  // line larda yok, yeni line ekle
                                    {
                                        AccountDocument.InvoiceLine iLine5 = new AccountDocument.InvoiceLine();
                                        iLine5.Description = revenueCode.Description;
                                        iLine5.AccountCode = accountCode;
                                        iLine5.IsDebt = false;
                                        iLine5.Price = (double)invPack.PackagePrice;
                                        iLine5.CurrencyRate = 1;
                                        II.Lines.Add(iLine5);
                                    }
                                }
                            }
                        }
                    }
                     */
                    CreateInvoiceLineObjectIDs(II);
                    ControlInvoiceInfo(II, "Hizmet Karşılığı Kurum Faturası");
                }
            }
            return II;
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(GeneralInvoiceDocument).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == GeneralInvoiceDocument.States.Send && toState == GeneralInvoiceDocument.States.Cancelled)
                PostTransition_Send2Cancelled();
        }

    }
}