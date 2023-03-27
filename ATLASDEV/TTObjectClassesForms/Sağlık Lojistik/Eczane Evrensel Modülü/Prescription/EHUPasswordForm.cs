
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
    /// E Reçete Şifre Giriş
    /// </summary>
    public partial class EHUPasswordForm : PrescriptionBaseForm
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
#region EHUPasswordForm_cmdPassOK_Click
   _Prescription.EHURecetePassword =this.ERecetePassword.Text;
            _Prescription.IsRepeated = (bool)this.IsRepeated.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
#endregion EHUPasswordForm_cmdPassOK_Click
        }

        protected override void PreScript()
        {
#region EHUPasswordForm_PreScript
    base.PreScript();
            this.cmdOK.Visible = false ;
            this.cmdCancel.Visible = false ;
            this.IsRepeated.Value = false;
#endregion EHUPasswordForm_PreScript

            }
                }
}