
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
    /// <summary>
    /// Genel Üretim İşlemi
    /// </summary>
    public partial class GeneralProductionActionCompForm : BaseGeneralProductionActionFrom
    {
        protected override void PreScript()
        {
            #region GeneralProductionActionCompForm_PreScript
            base.PreScript();
            //tttoolstrip2.ReadOnly = false;
            #endregion GeneralProductionActionCompForm_PreScript

        }

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
            if (_GeneralProductionAction.CurrentStateDefID == GeneralProductionAction.States.Completed)
            {
                foreach (DocumentRecordLog log in this._GeneralProductionAction.DocumentRecordLogs.Select("", "DOCUMENTRECORDLOGNUMBER"))
                {
                    if (log.DocumentTransactionType == DocumentTransactionTypeEnum.Out)
                    {
                        if (log.ReceiptNumber == null)
                        {
                            _GeneralProductionAction.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);
                        }
                    }
                }

                foreach (DocumentRecordLog log in this._GeneralProductionAction.DocumentRecordLogs.Select("", "DOCUMENTRECORDLOGNUMBER"))
                {
                    if (log.DocumentTransactionType == DocumentTransactionTypeEnum.In)
                    {
                        if (log.ReceiptNumber == null)
                        {
                            _GeneralProductionAction.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                        }
                    }
                }
            }
            if (_GeneralProductionAction.CurrentStateDefID == GeneralProductionAction.States.Cancelled)
            {
                foreach (DocumentRecordLog log in this._GeneralProductionAction.DocumentRecordLogs.Select("", "DOCUMENTRECORDLOGNUMBER"))
                {
                    if (log.DocumentTransactionType == DocumentTransactionTypeEnum.In)
                    {
                        if (log.ReceiptNumber != null)
                        {
                            _GeneralProductionAction.SendDeleteMessageToMkys(false, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                        }
                    }
                }

                foreach (DocumentRecordLog log in this._GeneralProductionAction.DocumentRecordLogs.Select("", "DOCUMENTRECORDLOGNUMBER"))
                {
                    if (log.DocumentTransactionType == DocumentTransactionTypeEnum.Out)
                    {
                        if (log.ReceiptNumber != null)
                        {
                            _GeneralProductionAction.SendDeleteMessageToMkys(true, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                        }
                    }
                }
            }
        }



        #region Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null)
            {
                if (transDef.ToStateDefID == GeneralProductionAction.States.Cancelled)
                {
                    foreach (DocumentRecordLog log in this._GeneralProductionAction.DocumentRecordLogs.Select("", "DOCUMENTRECORDLOGNUMBER"))
                    {
                        if (log.DocumentTransactionType == DocumentTransactionTypeEnum.In)
                        {
                            if (log.ReceiptNumber != null)
                            {
                                _GeneralProductionAction.SendDeleteMessageToMkys(false, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                            }
                        }
                    }

                    foreach (DocumentRecordLog log in this._GeneralProductionAction.DocumentRecordLogs.Select("", "DOCUMENTRECORDLOGNUMBER"))
                    {
                        if (log.DocumentTransactionType == DocumentTransactionTypeEnum.Out)
                        {
                            if (log.ReceiptNumber != null)
                            {
                                _GeneralProductionAction.SendDeleteMessageToMkys(true, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                            }
                        }
                    }

                }
            }
        }

        #endregion Methods
    }
}