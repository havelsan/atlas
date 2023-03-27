
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
    public partial class ChattelDocumentInputWithAccountancyApproveForm : BaseChattelDocumentInputWithAccountancyForm
    {
        protected override void PreScript()
        {
            #region ChattelDocumentInputWithAccountancyApproveForm_PreScript
            base.PreScript();

            if (_ChattelDocumentInputWithAccountancy.IsConflictExist == false)
                DropCurrentStateReport(typeof(TTReportClasses.I_ChattelDocumentConflictReport));
            #endregion ChattelDocumentInputWithAccountancyApproveForm_PreScript

        }

        protected override void ClientSidePreScript()
        {
            #region ChattelDocumentInputWithAccountancyApproveForm_ClientSidePreScript
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
            #endregion ChattelDocumentInputWithAccountancyApproveForm_ClientSidePreScript

        }

        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
            #region ChattelDocumentInputWithAccountancyNewForm_ClientSidePostScript
            base.ClientSidePostScript(transDef);

            if (transDef != null)
            {
                 bool err = false;
                 string errMsg = string.Empty;
                 IList compInputs = ChattelDocumentInputWithAccountancy.GetSameBaseNumberNQL(_ChattelDocumentInputWithAccountancy.ObjectContext, _ChattelDocumentInputWithAccountancy.AccountingTerm.ObjectID, _ChattelDocumentInputWithAccountancy.StockActionID.Value.ToString(), _ChattelDocumentInputWithAccountancy.Accountancy.ObjectID);
                 foreach (ChattelDocumentInputWithAccountancy inputDocument in compInputs)
                 {
                     if (inputDocument.ObjectID.Equals(_ChattelDocumentInputWithAccountancy.ObjectID) == false)
                     {
                         err = true;
                         errMsg = "Bu Dayanak numarasý " + inputDocument.StockActionID.ToString() + " iþlem numarasý ile daha önce girilmiþtir.\r\nDevam etmek istiyormusunuz?";
                     }
                 }

                 if (err)
                 {
                     string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Devam,&Vazgeç", "D,V", "Uyarý", "Dayanak Numarasý Uyarýsý", errMsg);
                     if (result == "V")
                     {
                         throw new TTException("Dayanak numarasý deðiþtirirebilirsiniz.");
                     }
                 }
            }
            #endregion ChattelDocumentInputWithAccountancyNewForm_ClientSidePostScript

        }






        #region ChattelDocumentInputWithAccountancyApproveForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);


            if (transDef != null)
            {
                if (transDef.ToStateDefID == ChattelDocumentInputWithAccountancy.States.Completed)
                {
                    _ChattelDocumentInputWithAccountancy.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                }
            }
        }

        #endregion ChattelDocumentInputWithAccountancyApproveForm_Methods
    }
}