
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
    public partial class UpdateSourceDocumentRecordLogForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdSave.Click += new TTControlEventDelegate(cmdSave_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdSave.Click -= new TTControlEventDelegate(cmdSave_Click);
            base.UnBindControlEvents();
        }

        private void cmdSave_Click()
        {
#region UpdateSourceDocumentRecordLogForm_cmdSave_Click
   if (string.IsNullOrEmpty(txtSourceDocumentRecordLogNo.Text))
                throw new TTUtils.TTException("Belge numarası girmediniz");

            TTObjectContext context = new TTObjectContext(false);
            ChattelDocumentOutputWithAccountancy chat = (ChattelDocumentOutputWithAccountancy)context.GetObject(_ChattelDocumentOutputWithAccountancy.ObjectID, typeof(ChattelDocumentOutputWithAccountancy).Name);
            chat.TargetDocumentRecordLogNo = txtSourceDocumentRecordLogNo.Text;
            context.Save();
            context.Dispose();
            this.Close();
#endregion UpdateSourceDocumentRecordLogForm_cmdSave_Click
        }

        protected override void PreScript()
        {
#region UpdateSourceDocumentRecordLogForm_PreScript
    base.PreScript();

            this.DropStateButton(ChattelDocumentOutputWithAccountancy.States.Cancelled);
            this.cmdOK.Visible = false;
            txtSourceDocumentRecordLogNo.ReadOnly = false;
            txtSourceDocumentRecordLogNo.Enabled = true;
#endregion UpdateSourceDocumentRecordLogForm_PreScript

            }
                }
}