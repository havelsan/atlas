
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
    /// Kurum Avans Tahsilat Dökümanı
    /// </summary>
    public  partial class PayerAdvancePaymentDocument : AccountDocument
    {
#region Methods
        public PayerAdvancePaymentDocumentGroup AddDocumentGroup(string pCode, string pDesc)
        {
            PayerAdvancePaymentDocumentGroup adg = new PayerAdvancePaymentDocumentGroup(ObjectContext);
            
            adg.GroupCode = pCode;
            adg.GroupDescription = pDesc;
            adg.AccountDocument = this;
            PayerAdvancePaymentDocumentGroups.Add(adg);
            return adg;
        }
        
        public void Cancel()
        {
            if (CurrentStateDefID != PayerAdvancePaymentDocument.States.Cancelled)
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
                CurrentStateDefID = PayerAdvancePaymentDocument.States.Cancelled;
            }
        }
        
        public AccountDocument.PaymentInfo CreatePaymentInfoForAccounting()
        {
            AccountDocument.PaymentInfo PI = null;
            
            if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
            {
                
                if (CurrentStateDefID == PayerAdvancePaymentDocument.States.Paid && SendToAccounting == false)
                {
                    PI = new AccountDocument.PaymentInfo();
                    
                    PI.ObjectId = ObjectID.ToString();
                    PI.PaymentDate = (DateTime)DocumentDate;
                    PI.PayerName = ((PayerAdvancePayment)AccountAction).Payer.Code + " " + ((PayerAdvancePayment)AccountAction).Payer.Name;;
                    PI.Description = TTUtils.CultureService.GetText("M26356", "Kurum Avans Tahsilat");
                    PI.Type = AccountDocument.PayerPaymentTypeEnum.KurumAvansTahsilat;
                    PI.TotalPrice = (double)AccountAction.TotalPrice;
                    
                    PI.Lines = new List<AccountDocument.PaymentLine>();
                    
                    AccountDocument.PaymentLine pLine = new AccountDocument.PaymentLine();
                    pLine.Description = TTUtils.CultureService.GetText("M26362", "Kurum Hesabı");
                    pLine.AccountCode = ((PayerAdvancePayment)AccountAction).Payer.GetAccountCode();
                    pLine.IsDebt = false;
                    pLine.Price = (double)AccountAction.TotalPrice;
                    pLine.CurrencyRate = 1;
                    PI.Lines.Add(pLine);
                    
                    CreatePaymentDetailInfo(ref PI.Lines, true);
                    CreatePaymentLineObjectIDs(PI);
                    ControlPaymentInfo(PI, TTUtils.CultureService.GetText("M26356", "Kurum Avans Tahsilat"));
                }
            }
            return PI;
        }
        
#endregion Methods

    }
}