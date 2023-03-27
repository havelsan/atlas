
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
    public partial class ChattelDocumentWithPurchaseApproveForm : BaseChattelDocumentWithPurchaseForm
    {
        protected override void ClientSidePreScript()
        {
            #region ChattelDocumentWithPurchaseApproveForm_ClientSidePreScript
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
            #endregion ChattelDocumentWithPurchaseApproveForm_ClientSidePreScript

        }

        #region ChattelDocumentWithPurchaseApproveForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null)
            {
                if (transDef.ToStateDefID == ChattelDocumentWithPurchase.States.Completed)
                {
                  _ChattelDocumentWithPurchase.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                }
            }
        }

        #endregion ChattelDocumentWithPurchaseApproveForm_Methods
    }
}