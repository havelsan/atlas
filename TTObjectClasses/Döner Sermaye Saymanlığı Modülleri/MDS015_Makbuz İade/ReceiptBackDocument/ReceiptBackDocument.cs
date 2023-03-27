
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
    /// Muhasebe Yetkilisi Mutemedi Alındısı İade Dökümanı
    /// </summary>
    public partial class ReceiptBackDocument : AccountDocument
    {
        #region Methods
        public void Cancel()
        {
            if (CurrentStateDefID != ReceiptBackDocument.States.Cancelled)
            {
                //Document APR larına ters kayıt olustur
                Dictionary<string, APRTrx> dict = new Dictionary<string, APRTrx>();
                int i = 1;
                foreach (APRTrx myAPRTrx in APRTrx)
                {
                    dict.Add("myAPRTrx" + i.ToString(), myAPRTrx);
                    i++;
                }
                foreach (KeyValuePair<string, APRTrx> myAPRTrx in dict)
                {
                    APRTrx app = myAPRTrx.Value;
                    AddAPRTransaction(app.AccountPayableReceivable, (double)(app.Price * -1), APRTrxType.GetByType(ObjectContext, 10)[0]); // 10 Belge Iptali
                }

                foreach (ReceiptBackDocumentGroup recBackGroup in ReceiptBackDocumentGroups)
                {
                    foreach (ReceiptBackDocumentDetail receiptBackDocDetail in recBackGroup.ReceiptBackDocumentDetails)
                    {
                        receiptBackDocDetail.ReceiptDocumentDetail.CurrentStateDefID = ReceiptDocumentDetail.States.Paid;
                        receiptBackDocDetail.AccountTrxDocument[0].AccountTransaction.CurrentStateDefID = AccountTransaction.States.Paid;
                        receiptBackDocDetail.CurrentStateDefID = ReceiptBackDocumentDetail.States.Cancelled;
                        
                        ReceiptBack receiptBack = EpisodeAccountAction as ReceiptBack;
                        if (receiptBack != null)
                            ReceiptDocument.GetPatientPaymentDetail(receiptBackDocDetail.AccountTrxDocument[0].AccountTransaction.ObjectID, receiptBack.Receipt.ReceiptDocument).IsBack = false;
                    }
                }

                CurrentStateDefID = ReceiptBackDocument.States.Cancelled;
                CancelDate = Common.RecTime();
                //this.CreateReceiptInfoAndSendToAccounting();  // ters hareket
            }
        }

        public AccountDocument.ReceiptInfo CreateReceiptInfoForAccounting()
        {
            AccountDocument.ReceiptInfo RI = null;

            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                if (CurrentStateDefID == ReceiptBackDocument.States.Paid && SendToAccounting == false)
                {
                    RI = new AccountDocument.ReceiptInfo();
                    CreateBasicReceiptInfo(ref RI);
                    RI.Type = AccountDocument.ReceiptTypeEnum.MuhasebeYetkilisiMutemediAlindisiIade;
                    RI.TotalPrice = (double)((ReceiptBack)EpisodeAccountAction).ReturnTotalPrice;

                    RI.Lines = new List<AccountDocument.ReceiptLine>();

                    AccountDocument.ReceiptLine rLine1 = new AccountDocument.ReceiptLine();
                    rLine1.Description = TTUtils.CultureService.GetText("M26802", "Satıştan İade");
                    rLine1.AccountCode = GetAccountCode(AccountEntegrationAccountTypeEnum.SatistanIadelerHesabi);
                    rLine1.IsDebt = true;
                    rLine1.Price = (double)((ReceiptBack)EpisodeAccountAction).ReturnTotalPrice;
                    rLine1.CurrencyRate = 1;
                    RI.Lines.Add(rLine1);

                    AccountDocument.ReceiptLine rLine2 = new AccountDocument.ReceiptLine();

                    if (BackBankAccount == null)
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
                    rLine2.Price = (double)((ReceiptBack)EpisodeAccountAction).ReturnTotalPrice;
                    rLine2.CurrencyRate = 1;
                    RI.Lines.Add(rLine2);

                    CreateReceiptLineObjectIDs(RI);
                    ControlReceiptInfo(RI, TTUtils.CultureService.GetText("M26547", "Muhasebe Yetkilisi Mutemedi Alındısı İade"));
                }
            }
            return RI;
        }

        #endregion Methods 

    }
}