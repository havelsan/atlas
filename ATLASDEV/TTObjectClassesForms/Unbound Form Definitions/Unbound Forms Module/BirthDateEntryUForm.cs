
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
    /// Doğum Tarihi Giriniz
    /// </summary>
    public partial class BirthDateEntryUForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            Ok.Click += new TTControlEventDelegate(Ok_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            Ok.Click -= new TTControlEventDelegate(Ok_Click);
            base.UnBindControlEvents();
        }

        private void Ok_Click()
        {
#region BirthDateEntryUForm_Ok_Click
   if ((this.BirthDate.Text.Trim()).Length < 8)
            {
                MessageBox.Show( "Yeni Doğan kabulü için gg/aa/yyyy formatında doldurmak zorunludur. ");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
#endregion BirthDateEntryUForm_Ok_Click
        }

#region BirthDateEntryUForm_Methods
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
//            if(this.DialogResult != DialogResult.OK)
//            {
//                e.Cancel = true;
//                this.DialogResult = DialogResult.Cancel;
//                throw new Exception("İşlemden Vazgeçildi");
//            }
        }
        
        public string ShowAndGetBirthDateForm()
        {
            InfoBox.Show("this.ShowDialog();");
            return  Convert.ToString(this.BirthDate) ;
        }
        
#endregion BirthDateEntryUForm_Methods
    }
}