
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class ChattelDocumentWithPurchaseCompletedForm : BaseChattelDocumentWithPurchaseForm
    {
        override protected void BindControlEvents()
        {
            SendToMKYS.Click += new TTControlEventDelegate(SendToMKYS_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SendToMKYS.Click -= new TTControlEventDelegate(SendToMKYS_Click);
            base.UnBindControlEvents();
        }

        private void SendToMKYS_Click()
        {
            #region ChattelDocumentWithPurchaseCompletedForm_SendToMKYS_Click
            if (this._ChattelDocumentWithPurchase.CurrentStateDefID == ChattelDocumentWithPurchase.States.Completed)
            {
                foreach (DocumentRecordLog log in this._ChattelDocumentWithPurchase.DocumentRecordLogs)
                {
                    if (log.ReceiptNumber == null)
                    {
                        this._BaseChattelDocument.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                    }
                }
            }
            if (this._ChattelDocumentWithPurchase.CurrentStateDefID == ChattelDocumentWithPurchase.States.Cancelled)
            {
                foreach (DocumentRecordLog log in this._ChattelDocumentWithPurchase.DocumentRecordLogs)
                {
                    if (log.ReceiptNumber != null)
                    {
                        this._ChattelDocumentWithPurchase.SendDeleteMessageToMkys(false, log.ReceiptNumber.Value,Common.CurrentResource.MkysPassword);
                    }
                }


            }
            #endregion ChattelDocumentWithPurchaseCompletedForm_SendToMKYS_Click
        }

        protected override void PreScript()
        {
            #region ChattelDocumentWithPurchaseCompletedForm_PreScript
            base.PreScript();

            //            ChattelDocumentDetailWithPurchase chattelDocumentDetailWithPurchase = (ChattelDocumentDetailWithPurchase)ChattelDocumentDetailsWithPurchase.CurrentCell.OwningRow.TTObject;
            //            if(_ChattelDocumentWithPurchase.CurrentStateDefID == ChattelDocumentWithPurchase.States.Completed)
            //            {
            //                if (chattelDocumentDetailWithPurchase.UnitPriceWithInVat == null ||
            //                    chattelDocumentDetailWithPurchase.UnitPriceWithOutVat == null ||
            //                    chattelDocumentDetailWithPurchase.UnitPrice == null)
            //                {
            //                    chattelDocumentDetailWithPurchase.UnitPriceWithInVat = chattelDocumentDetailWithPurchase.UnitPrice;
            //                    chattelDocumentDetailWithPurchase.UnitPriceWithOutVat = chattelDocumentDetailWithPurchase.UnitPriceWithInVat ;
            //                    chattelDocumentDetailWithPurchase.VatRate = 0;
            //                    chattelDocumentDetailWithPurchase.UnitPrice = (BigCurrency)chattelDocumentDetailWithPurchase.Amount * 
            //                        (BigCurrency)chattelDocumentDetailWithPurchase.UnitPriceWithInVat;
            //                    
            //                    txtTotalPrice.Text = CalculateTotalPrice().ToString();
            //                    
            //                }
            //            }
            #endregion ChattelDocumentWithPurchaseCompletedForm_PreScript

        }

        protected override void ClientSidePreScript()
        {
            #region ChattelDocumentWithPurchaseCompletedForm_ClientSidePreScript
            base.ClientSidePreScript();


            List<double> priceCalc = new List<double>();
            double totalWithoutKDV = 0, totalWithKDV = 0, salesTotal = 0, totalPrice = 0;
            priceCalc.Add(totalWithoutKDV);
            priceCalc.Add(totalWithKDV);
            priceCalc.Add(salesTotal);
            priceCalc.Add(totalPrice);

            priceCalc = CalcFinalPriceWithKDV(priceCalc);

            txtNotKDV.Text = priceCalc[0].ToString("#.00");
            txtWithKDV.Text = priceCalc[1].ToString("#.00");
            txtDiscount.Text = priceCalc[2].ToString("#.00");
            txtTotalPrice.Text = priceCalc[3].ToString("#.00");
            #endregion ChattelDocumentWithPurchaseCompletedForm_ClientSidePreScript

        }


        #region ChattelDocumentWithPurchaseCompleted_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);


            if (transDef != null)
            {
                if (transDef.ToStateDefID == ChattelDocumentWithPurchase.States.Cancelled)
                {
                    foreach (DocumentRecordLog log in this._ChattelDocumentWithPurchase.DocumentRecordLogs)
                    {
                        if (log.ReceiptNumber != null)
                        {
                            this._ChattelDocumentWithPurchase.SendDeleteMessageToMkys(false, log.ReceiptNumber.Value,Common.CurrentResource.MkysPassword);
                        }
                    }
                }
            }
        }

        #endregion ChattelDocumentWithPurchaseCompleted_Methods





    }
}