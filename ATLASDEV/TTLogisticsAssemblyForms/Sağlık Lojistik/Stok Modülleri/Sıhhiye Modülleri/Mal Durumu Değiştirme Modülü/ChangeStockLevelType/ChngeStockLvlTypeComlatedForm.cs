
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
    public partial class ChngeStockLvlTypeComlatedForm : ChangeStockLevelTypeForm
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
            #region ChngeStockLvlTypeComlatedForm_SendToMKYS_Click
            if (this._ChangeStockLevelType.CurrentStateDefID == ChangeStockLevelType.States.Completed)
            {
                foreach (DocumentRecordLog log in this._ChangeStockLevelType.DocumentRecordLogs)
                {
                    if(log.ReceiptNumber == null)
                        this._ChangeStockLevelType.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);

                }
             
            }
            #endregion ChngeStockLvlTypeComlatedForm_SendToMKYS_Click

            #region ChngeStockLvlTypeCancelForm_SendToMKYS_Click
            if (this._ChangeStockLevelType.CurrentStateDefID == ChangeStockLevelType.States.Cancel)
            {
                foreach (DocumentRecordLog log in this._ChangeStockLevelType.DocumentRecordLogs)
                {
                    if (log.ReceiptNumber != null)
                        this._ChangeStockLevelType.SendDeleteMessageToMkys(true, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);

                }
                    
            }
            #endregion ChngeStockLvlTypeCancelForm_SendToMKYS_Click


        }


        #region ChngeStockLvlTypeComlatedForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null)
            {
                if (transDef.ToStateDefID == ChangeStockLevelType.States.Cancel)
                {
                    foreach (DocumentRecordLog log in this._ChangeStockLevelType.DocumentRecordLogs)
                    {
                        if (log.ReceiptNumber != null)
                            this._ChangeStockLevelType.SendDeleteMessageToMkys(true, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);

                    }

                }
            }
        }


        #endregion ChngeStockLvlTypeComlatedForm_Methods


    }
}