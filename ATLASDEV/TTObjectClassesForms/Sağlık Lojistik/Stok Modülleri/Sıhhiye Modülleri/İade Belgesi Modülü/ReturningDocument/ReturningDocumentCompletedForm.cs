
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
    public partial class ReturningDocumentCompletedForm : BaseReturningDocumentForm
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


        /* TODO : HAMDÝ NEDEN BURAYI KAPATTI ????????
         protected override void PreScript()
         {
             #region ReturningDocumentCompletedForm_PreScript
             base.PreScript();
             if (_ReturningDocument.ReturnDepStoreObjectID != null)
             {
                 this.DropStateButton(ReturningDocument.States.Cancelled);
             }
             #endregion ReturningDocumentCompletedForm_PreScript

         }
         */
        private void SendToMKYS_Click()
        {
            #region ReturningDocumentCompletedForm_SendToMKYS_Click

            if (_ReturningDocument.CurrentStateDefID == ReturningDocument.States.Completed)
            {

                _ReturningDocument.SendMYKSProperties();
                foreach (DocumentRecordLog log in this._ReturningDocument.DocumentRecordLogs)
                {
                    if (log.ReceiptNumber == null)
                        this._ReturningDocument.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                }

            }

            if (_ReturningDocument.CurrentStateDefID == ReturningDocument.States.Cancelled)
            {
                foreach (DocumentRecordLog log in this._ReturningDocument.DocumentRecordLogs)
                {
                    if (log.ReceiptNumber != null)
                        this._ReturningDocument.SendDeleteMessageToMkys(false, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                }



            }

            #endregion ReturningDocumentCompletedForm_SendToMKYS_Click
        }


        #region ReturningDocumentCompletedForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null)
            {
                if (transDef.ToStateDefID == ReturningDocument.States.Cancelled)
                {
                    foreach (DocumentRecordLog log in this._ReturningDocument.DocumentRecordLogs)
                    {
                        if (log.ReceiptNumber != null)
                            this._ReturningDocument.SendDeleteMessageToMkys(false, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                    }
                }
            }

        }

        #endregion ReturningDocumentCompletedForm_Methods



    }
}