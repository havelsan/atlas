
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
    public partial class DistributionDocumentCompletedForm : BaseDistributionDocumentForm
    {
        override protected void BindControlEvents()
        {
            ttMkysSend.Click += new TTControlEventDelegate(ttMkysSend_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttMkysSend.Click -= new TTControlEventDelegate(ttMkysSend_Click);
            base.UnBindControlEvents();
        }

        private void ttMkysSend_Click()
        {

            if (this._DistributionDocument.CurrentStateDefID == DistributionDocument.States.Completed)
            {
                _DistributionDocument.SetMKYSProperties();

                foreach (DocumentRecordLog log in this._DistributionDocument.DocumentRecordLogs)
                {
                    if(log.ReceiptNumber == null)
                        this._DistributionDocument.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);
                }
            }

            if (this._DistributionDocument.CurrentStateDefID == DistributionDocument.States.Cancelled)
            {

                foreach (DocumentRecordLog log in this._DistributionDocument.DocumentRecordLogs)
                {
                    if (log.ReceiptNumber != null)
                        this._DistributionDocument.SendDeleteMessageToMkys(true, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                }

               
            }
        }




        #region DistributionDocumentCompletedForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null)
            {
                if (transDef.ToStateDefID == DistributionDocument.States.Cancelled)
                {
                    foreach (DocumentRecordLog log in this._DistributionDocument.DocumentRecordLogs)
                    {
                        if (log.ReceiptNumber != null)
                            this._DistributionDocument.SendDeleteMessageToMkys(true, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                    }
                }
            }
        }


        #endregion DistributionDocumentCompletedForm_Methods





    }
}