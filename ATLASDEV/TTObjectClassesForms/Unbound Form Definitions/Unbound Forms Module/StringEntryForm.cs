
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
    public partial class StringEntryForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            Ok.Click += new TTControlEventDelegate(Ok_Click);
            Cancel.Click += new TTControlEventDelegate(Cancel_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            Ok.Click -= new TTControlEventDelegate(Ok_Click);
            Cancel.Click -= new TTControlEventDelegate(Cancel_Click);
            base.UnBindControlEvents();
        }

        private void Ok_Click()
        {
#region StringEntryForm_Ok_Click
   if (string.IsNullOrEmpty(this.StringField.Text))
            {
                InfoBox.Show(this.Title.Text.ToString() + " Boş Geçilemez", MessageIconEnum.ErrorMessage);
                //MessageBox.Show( this.Title.Text.ToString() + " Boş Geçilemez");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
#endregion StringEntryForm_Ok_Click
        }

        private void Cancel_Click()
        {
#region StringEntryForm_Cancel_Click
   this.DialogResult = DialogResult.Ignore;
            this.Close();
#endregion StringEntryForm_Cancel_Click
        }

#region StringEntryForm_Methods
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            Button pOK = (Button)this.Ok;
            pOK.DialogResult = DialogResult.OK;
            this.AcceptButton = pOK;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnFormClosing(FormClosingEventArgs e)
        {           
            if(this.DialogResult == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
        
        public string ShowAndGetStringForm(string StringTitle)
        {
            this.Title.Text=StringTitle;
            this.Text = StringTitle;
             this.ShowDialog();
            if (this.DialogResult == DialogResult.Ignore)
                throw new Exception("İşlemden Vazgeçildi");
            return this.StringField.Text;
        }
        
        public DialogResult ShowStringDialog(IWin32Window pParent, string sTitle)
        {
            this.Text = sTitle;
            this.Title.Text = string.Empty;
            this.ShowDialog(pParent);
            if (this.DialogResult == DialogResult.Ignore)
                throw new Exception("İşlemden Vazgeçildi");
            return this.DialogResult;
        }
        
        public DialogResult ShowStringDialog(IWin32Window pParent, string sTitle, string sCaption)
        {
            this.Text = sCaption;
            this.Title.Text = sTitle;
            this.ShowDialog(pParent);
            if (this.DialogResult == DialogResult.Ignore)
                throw new Exception("İşlemden Vazgeçildi");
            return this.DialogResult;
        }
        
        public string StringContent
        {
            get{ return this.StringField.Text; }
        }
        
#endregion StringEntryForm_Methods
    }
}