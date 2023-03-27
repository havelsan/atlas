
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
    public partial class ChattelDocumentInputWithAccountancyCompletedForm : BaseChattelDocumentInputWithAccountancyForm
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
            #region ChattelDocumentInputWithAccountancyCompletedForm_SendToMKYS_Click

            if (this._ChattelDocumentInputWithAccountancy.CurrentStateDefID == ChattelDocumentInputWithAccountancy.States.Completed)
            {
                foreach (DocumentRecordLog log in this._ChattelDocumentInputWithAccountancy.DocumentRecordLogs)
                {
                    if (log.ReceiptNumber == null)
                    {
                        this._BaseChattelDocument.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                    }
                }
            }
            if (this._ChattelDocumentInputWithAccountancy.CurrentStateDefID == ChattelDocumentInputWithAccountancy.States.Cancelled)
            {

                foreach (DocumentRecordLog log in this._ChattelDocumentInputWithAccountancy.DocumentRecordLogs)
                {
                    if (log.ReceiptNumber != null)
                    {
                        this._ChattelDocumentInputWithAccountancy.SendDeleteMessageToMkys(false,log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                    }
                }


            }

            #endregion ChattelDocumentInputWithAccountancyCompletedForm_SendToMKYS_Click
        }

        protected override void ClientSidePreScript()
        {
            #region ChattelDocumentInputWithAccountancyCompletedForm_ClientSidePreScript
            base.ClientSidePreScript();

            List<double> priceCalc = new List<double>();
            double total = 0, salesTotal = 0, totalPrice = 0;
            priceCalc.Add(total);
            priceCalc.Add(salesTotal);
            priceCalc.Add(totalPrice);

            priceCalc = CalcFinalPrice(priceCalc);

            txtTotalNotDiscount.Text = priceCalc[0].ToString();
            txtSalesTotal.Text = priceCalc[1].ToString();
            txtTotalPrice.Text = priceCalc[2].ToString();
            #endregion ChattelDocumentInputWithAccountancyCompletedForm_ClientSidePreScript

        }

        #region ChattelDocumentInputWithAccountancyApproveForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);


            if (transDef != null)
            {
                if (transDef.ToStateDefID == ChattelDocumentInputWithAccountancy.States.Cancelled)
                {
                    foreach (DocumentRecordLog log in this._ChattelDocumentInputWithAccountancy.DocumentRecordLogs)
                    {
                        if (log.ReceiptNumber != null)
                        {
                            this._ChattelDocumentInputWithAccountancy.SendDeleteMessageToMkys(false, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                        }
                    }
                }
            }
        }

        #endregion ChattelDocumentInputWithAccountancyApproveForm_Methods
    }
}