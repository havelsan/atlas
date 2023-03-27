
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
    public partial class CensusFixedCompletedForm : BaseCensusFixedForm
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
            if (this._CensusFixed.CurrentStateDefID == CensusFixed.States.Completed)
            {
                foreach (DocumentRecordLog log in this._CensusFixed.DocumentRecordLogs.Select("", "DOCUMENTRECORDLOGNUMBER"))
                {
                    if (log.DocumentTransactionType == DocumentTransactionTypeEnum.Out)
                    {
                        if (log.ReceiptNumber == null)
                        {
                            _CensusFixed.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);
                        }
                    }
                }

                foreach (DocumentRecordLog log in this._CensusFixed.DocumentRecordLogs.Select("", "DOCUMENTRECORDLOGNUMBER"))
                {
                    if (log.DocumentTransactionType == DocumentTransactionTypeEnum.In)
                    {
                        if (log.ReceiptNumber == null)
                        {
                            _CensusFixed.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                        }
                    }
                }
            }
            #region sayým düzeltme iptali tekrar yollama
            if (this._CensusFixed.CurrentStateDefID == CensusFixed.States.Cancelled)
            {
                foreach (DocumentRecordLog log in this._CensusFixed.DocumentRecordLogs.Select("", "DOCUMENTRECORDLOGNUMBER"))
                {
                    if (log.DocumentTransactionType == DocumentTransactionTypeEnum.In)
                    {
                        if (log.ReceiptNumber != null)
                        {
                            _CensusFixed.SendDeleteMessageToMkys(false, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                        }
                    }
                }

                foreach (DocumentRecordLog log in this._CensusFixed.DocumentRecordLogs.Select("", "DOCUMENTRECORDLOGNUMBER"))
                {
                    if (log.DocumentTransactionType == DocumentTransactionTypeEnum.Out)
                    {
                        if (log.ReceiptNumber != null)
                        {
                            _CensusFixed.SendDeleteMessageToMkys(true, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                        }
                    }
                }
            }
            #endregion sayým düzeltme iptali tekrar yollama


        }


        #region Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null)
            {
                if (transDef.ToStateDefID == CensusFixed.States.Cancelled)
                {
                    foreach (DocumentRecordLog log in this._CensusFixed.DocumentRecordLogs.Select("", "DOCUMENTRECORDLOGNUMBER"))
                    {
                        if (log.DocumentTransactionType == DocumentTransactionTypeEnum.In)
                        {
                            if (log.ReceiptNumber != null)
                            {
                                _CensusFixed.SendDeleteMessageToMkys(false, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                            }
                        }
                    }

                    foreach (DocumentRecordLog log in this._CensusFixed.DocumentRecordLogs.Select("", "DOCUMENTRECORDLOGNUMBER"))
                    {
                        if (log.DocumentTransactionType == DocumentTransactionTypeEnum.Out)
                        {
                            if (log.ReceiptNumber != null)
                            {
                                _CensusFixed.SendDeleteMessageToMkys(true, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                            }
                        }
                    }

                }
            }
        }

        #endregion Methods



    }
}