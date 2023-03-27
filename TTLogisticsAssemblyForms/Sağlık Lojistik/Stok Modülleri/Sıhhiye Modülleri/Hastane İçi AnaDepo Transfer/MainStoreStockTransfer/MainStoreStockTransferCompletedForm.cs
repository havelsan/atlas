
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
    public partial class MainStoreStockTransferCompletedForm : BaseMainStoreStockTransferForm
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
            #region ambarlar arasý transfer tamalanan iþlemi mkys tekrar gönder
            if (this._MainStoreStockTransfer.CurrentStateDefID == MainStoreStockTransfer.States.Completed)
            {
                foreach (DocumentRecordLog log in this._MainStoreStockTransfer.DocumentRecordLogs.Select("", "DOCUMENTRECORDLOGNUMBER"))
                {
                    if (log.DocumentTransactionType == DocumentTransactionTypeEnum.Out)
                    {
                        if (log.ReceiptNumber == null)
                        {
                            _MainStoreStockTransfer.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);
                        }
                    }
                }

                foreach (DocumentRecordLog log in this._MainStoreStockTransfer.DocumentRecordLogs.Select("", "DOCUMENTRECORDLOGNUMBER"))
                {
                    if (log.DocumentTransactionType == DocumentTransactionTypeEnum.In)
                    {
                        if (log.ReceiptNumber == null)
                        {
                            _MainStoreStockTransfer.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                        }
                    }
                }
            }
            #endregion ambarlar arasý transfer tamalanan iþlemi mkys tekrar gönder

            #region ambarlar arasý tranfer iptali tekrar yollama
            if (this._MainStoreStockTransfer.CurrentStateDefID == MainStoreStockTransfer.States.Cancelled)
            {

                foreach (DocumentRecordLog log in this._MainStoreStockTransfer.DocumentRecordLogs.Select("", "DOCUMENTRECORDLOGNUMBER"))
                {
                    if (log.DocumentTransactionType == DocumentTransactionTypeEnum.In)
                    {
                        if (log.ReceiptNumber != null)
                        {
                            _MainStoreStockTransfer.SendDeleteMessageToMkys(false, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                        }
                    }
                }

                foreach (DocumentRecordLog log in this._MainStoreStockTransfer.DocumentRecordLogs.Select("", "DOCUMENTRECORDLOGNUMBER"))
                {
                    if (log.DocumentTransactionType == DocumentTransactionTypeEnum.Out)
                    {
                        if (log.ReceiptNumber != null)
                        {
                            _MainStoreStockTransfer.SendDeleteMessageToMkys(true, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                        }
                    }
                }

            }
            #endregion ambarlar arasý tranfer iptali tekrar yollama
        }




        #region MainStoreStockTransferCompletedForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null)
            {
                if (transDef.ToStateDefID == MainStoreStockTransfer.States.Cancelled)
                {
                    foreach (DocumentRecordLog log in this._MainStoreStockTransfer.DocumentRecordLogs.Select("", "DOCUMENTRECORDLOGNUMBER"))
                    {
                        if (log.DocumentTransactionType == DocumentTransactionTypeEnum.In)
                        {
                            if (log.ReceiptNumber != null)
                            {
                                _MainStoreStockTransfer.SendDeleteMessageToMkys(false, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                            }
                        }
                    }

                    foreach (DocumentRecordLog log in this._MainStoreStockTransfer.DocumentRecordLogs.Select("", "DOCUMENTRECORDLOGNUMBER"))
                    {
                        if (log.DocumentTransactionType == DocumentTransactionTypeEnum.Out)
                        {
                            if (log.ReceiptNumber != null)
                            {
                                _MainStoreStockTransfer.SendDeleteMessageToMkys(true, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                            }
                        }
                    }
                }

            }
        }
        #endregion MainStoreStockTransferCompletedForm_Methods
    }
}