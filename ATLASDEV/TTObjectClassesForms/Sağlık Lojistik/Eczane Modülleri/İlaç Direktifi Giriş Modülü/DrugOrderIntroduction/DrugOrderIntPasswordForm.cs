
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
    /// E Reçete Şifre
    /// </summary>
    public partial class DrugOrderIntPasswordForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdPassOK.Click += new TTControlEventDelegate(cmdPassOK_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdPassOK.Click -= new TTControlEventDelegate(cmdPassOK_Click);
            base.UnBindControlEvents();
        }

        private void cmdPassOK_Click()
        {
#region DrugOrderIntPasswordForm_cmdPassOK_Click
   _DrugOrderIntroduction.ERecetePassword = this.ERecetePassword.Text;
            _DrugOrderIntroduction.IsRepeated = (bool)this.IsRepeated.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
#endregion DrugOrderIntPasswordForm_cmdPassOK_Click
        }

        protected override void PreScript()
        {
#region DrugOrderIntPasswordForm_PreScript
    base.PreScript();

            this.IsRepeated.Value = false;
            this.DropCurrentStateReport(typeof(TTReportClasses.I_PrescriptionReport));
            this.cmdCancel.Visible = false;
            this.cmdOK.Visible = false;
#endregion DrugOrderIntPasswordForm_PreScript

            }
                }
}