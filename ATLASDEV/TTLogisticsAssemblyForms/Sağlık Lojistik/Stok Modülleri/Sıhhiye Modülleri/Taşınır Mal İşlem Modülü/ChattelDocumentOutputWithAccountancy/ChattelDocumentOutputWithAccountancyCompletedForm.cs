
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
    public partial class ChattelDocumentOutputWithAccountancyCompletedForm : BaseChattelDocumentOutputWithAccountancy
    {
        override protected void BindControlEvents()
        {
            SendToMKYS.Click += new TTControlEventDelegate(SendToMKYS_Click);
            cmdSendAgain.Click += new TTControlEventDelegate(cmdSendAgain_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SendToMKYS.Click -= new TTControlEventDelegate(SendToMKYS_Click);
            cmdSendAgain.Click -= new TTControlEventDelegate(cmdSendAgain_Click);
            base.UnBindControlEvents();
        }

        private void SendToMKYS_Click()
        {
            #region ChattelDocumentOutputWithAccountancyCompletedForm_SendToMKYS_Click

            if (this._ChattelDocumentOutputWithAccountancy.CurrentStateDefID == ChattelDocumentOutputWithAccountancy.States.Completed)
            {

                foreach (DocumentRecordLog log in this._ChattelDocumentOutputWithAccountancy.DocumentRecordLogs)
                {
                    if (log.ReceiptNumber == null)
                    {
                        this._BaseChattelDocument.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);
                    }
                }

            }
            if (this._ChattelDocumentOutputWithAccountancy.CurrentStateDefID == ChattelDocumentOutputWithAccountancy.States.Cancelled)
            {
                foreach (DocumentRecordLog log in this._ChattelDocumentOutputWithAccountancy.DocumentRecordLogs)
                {
                    if (log.ReceiptNumber != null)
                    {
                        this._ChattelDocumentOutputWithAccountancy.SendDeleteMessageToMkys(true, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                    }
                }

            }
            #endregion ChattelDocumentOutputWithAccountancyCompletedForm_SendToMKYS_Click
        }

        private void cmdSendAgain_Click()
        {
            #region ChattelDocumentOutputWithAccountancyCompletedForm_cmdSendAgain_Click
            bool toSend = true;

            if (_ChattelDocumentOutputWithAccountancy.Accountancy.AccountancyMilitaryUnit.IsSupported == null)
            {
                InfoBox.Show("Bu saymanlığın bağlı bulunduğu birlikte XXXXXX desteği bulunmamaktadır", MessageIconEnum.ErrorMessage);
                return;
            }

            if ((bool)_ChattelDocumentOutputWithAccountancy.Accountancy.AccountancyMilitaryUnit.IsSupported)
            {

                if (((MainStoreDefinition)_ChattelDocumentOutputWithAccountancy.Store).Accountancy.AccountancyMilitaryUnit.Site.ObjectID.Equals(_ChattelDocumentOutputWithAccountancy.Accountancy.AccountancyMilitaryUnit.Site.ObjectID))
                {
                    if (_ChattelDocumentOutputWithAccountancy.InputDocumentObjectID == null)
                    {
                        _ChattelDocumentOutputWithAccountancy.CreateInputDocumentSameSite(_ChattelDocumentOutputWithAccountancy, _ChattelDocumentOutputWithAccountancy.ObjectContext);
                        _ChattelDocumentOutputWithAccountancy.ObjectContext.Save();
                    }
                    else
                    {
                        ChattelDocumentInputWithAccountancy inputDocument = (ChattelDocumentInputWithAccountancy)_ChattelDocumentOutputWithAccountancy.ObjectContext.GetObject(((Guid)_ChattelDocumentOutputWithAccountancy.InputDocumentObjectID), typeof(ChattelDocumentInputWithAccountancy).Name);
                        InfoBox.Show("Bu belge gönderilen saymanlık da " + inputDocument.StockActionID.ToString() + " işlem numaralı Taşınır Mal Giriş işlemi ile giriş işlemi yapılmıştır.", MessageIconEnum.ErrorMessage);
                        toSend = false;
                    }
                }
                else
                {
                    TTObjectContext context = new TTObjectContext(false);
                    IList inputDocuments = _ChattelDocumentOutputWithAccountancy.GenerateInputDocumentForRemote(_ChattelDocumentOutputWithAccountancy, context);
                    if (_ChattelDocumentOutputWithAccountancy.Accountancy.AccountancyMilitaryUnit != null)
                    {
                        if (_ChattelDocumentOutputWithAccountancy.Accountancy.AccountancyMilitaryUnit.Site != null)
                        {
                            if (((MainStoreDefinition)_ChattelDocumentOutputWithAccountancy.Store).Accountancy.AccountancyMilitaryUnit.Site.ObjectID.Equals(_ChattelDocumentOutputWithAccountancy.Accountancy.AccountancyMilitaryUnit.Site.ObjectID))
                                _ChattelDocumentOutputWithAccountancy.CreateInputDocumentSameSite(_ChattelDocumentOutputWithAccountancy, _ChattelDocumentOutputWithAccountancy.ObjectContext);
                            else
                                _ChattelDocumentOutputWithAccountancy.SendGeneratedDocumentToTargetSite(inputDocuments, _ChattelDocumentOutputWithAccountancy.Accountancy, _ChattelDocumentOutputWithAccountancy.Accountancy.AccountancyMilitaryUnit.Site);
                        }
                    }
                    context.Dispose();
                }

                if (toSend)
                    InfoBox.Show("Belge yollanmıştır", MessageIconEnum.InformationMessage);
            }
            else
                InfoBox.Show("Bu saymanlığın bağlı bulunduğu birlikte XXXXXX desteği bulunmamaktadır", MessageIconEnum.ErrorMessage);
            #endregion ChattelDocumentOutputWithAccountancyCompletedForm_cmdSendAgain_Click
        }



        #region ChattelDocumentOutputWithAccountancyCompletedForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            if (transDef != null)
            {
                if (transDef.ToStateDefID == ChattelDocumentOutputWithAccountancy.States.Cancelled)
                {
                    foreach (DocumentRecordLog log in this._ChattelDocumentOutputWithAccountancy.DocumentRecordLogs)
                    {
                        if (log.ReceiptNumber != null)
                        {
                            this._ChattelDocumentOutputWithAccountancy.SendDeleteMessageToMkys(true, log.ReceiptNumber.Value, Common.CurrentResource.MkysPassword);
                        }
                    }

                }

            }
        }
        #endregion ChattelDocumentOutputWithAccountancyCompletedForm_Methods

    }
}