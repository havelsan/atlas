
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
    public partial class DeleteRecordDocumentDestroyableCompletedForm : BaseDeleteRecordDocumentDestroyableForm
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
            #region DeleteRecordDocumentDestroyableCompletedForm_SendToMKYS_Click
            if (this._DeleteRecordDocumentDestroyable.CurrentStateDefID == DeleteAnimalRecordDocument.States.Completed)
            {
                foreach (DocumentRecordLog log in this._DeleteRecordDocumentDestroyable.DocumentRecordLogs)
                {
                    if (log.ReceiptNumber == null)
                    {
                        this._DeleteRecordDocumentDestroyable.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);
                    }
                }
            }
            if (this._DeleteRecordDocumentDestroyable.CurrentStateDefID == DeleteAnimalRecordDocument.States.Cancelled)
            {
                foreach (DocumentRecordLog log in this._DeleteRecordDocumentDestroyable.DocumentRecordLogs)
                {
                    if (log.ReceiptNumber != null)
                    {
                        this._DeleteRecordDocumentDestroyable.SendDeleteMessageToMkys(true, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                    }
                }
            }
            #endregion DeleteRecordDocumentDestroyableCompletedForm_SendToMKYS_Click
        }


        #region DeleteRecordDocumentDestroyableCompletedForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null)
            {
                if (transDef.ToStateDefID == DeleteAnimalRecordDocument.States.Cancelled)
                {
                    foreach (DocumentRecordLog log in this._DeleteRecordDocumentDestroyable.DocumentRecordLogs)
                    {
                        if (log.ReceiptNumber != null)
                        {
                            this._DeleteRecordDocumentDestroyable.SendDeleteMessageToMkys(true, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                        }
                    }

                }

            }
        }
        #endregion DeleteRecordDocumentDestroyableCompletedForm_Methods




        protected override void PreScript()
        {
            #region DeleteRecordDocumentDestroyableCompletedForm_PreScript
            base.PreScript();

            // if(this._DeleteRecordDocumentDestroyable.StockActionInspection == null)
            //      DropCurrentStateReport(TTObjectDefManager.Instance.ReportDefs[new Guid("1c95415c-307f-41fa-a79a-b8aa82cb0df3")].ReportDefID);
            #endregion DeleteRecordDocumentDestroyableCompletedForm_PreScript

        }
    }
}