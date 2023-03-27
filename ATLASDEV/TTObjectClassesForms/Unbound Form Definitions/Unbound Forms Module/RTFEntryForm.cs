
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
    public partial class RTFEntryForm : TTUnboundForm
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
#region RTFEntryForm_Ok_Click
   if (this.RTFField.Text=="")
            {
                MessageBox.Show( this.Title.Text.ToString() + " Boş Geçilemez");
                //throw new Exception(RTFTitle + "Boş Geçilemez");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
#endregion RTFEntryForm_Ok_Click
        }

        private void Cancel_Click()
        {
#region RTFEntryForm_Cancel_Click
   this.DialogResult = DialogResult.Ignore;
                this.Close();
#endregion RTFEntryForm_Cancel_Click
        }

#region RTFEntryForm_Methods
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
        
        public string ShowAndGetRTF(string RTFTitle)
        {
            this.RTFField.DisplayText=RTFTitle;
            this.Title.Text=RTFTitle;
            this.ShowDialog();
            if(this.DialogResult == DialogResult.Ignore)
                throw new Exception("İşlemden Vazgeçildi");
            return this.RTFField.Rtf;
        }
        
        public bool PrintWithTemplateGroupName(string RTFTitle,string templateGroupName)
        {
            this.RTFField.DisplayText=RTFTitle;
            this.RTFField.TemplateGroupName=templateGroupName;
            this.Title.Text=RTFTitle;
            this.Ok.Text="Yazdır";
            this.ShowDialog();
            if(this.DialogResult != DialogResult.OK)
                throw new Exception("İşlemden Vazgeçildi");
            else
            {
                (((TTRichTextBoxControl)this.RTFField).richTextControlTextBox).PrintDocument.Print();
                return true;
            }
            //return false;  
        }
        
#endregion RTFEntryForm_Methods
    }
}