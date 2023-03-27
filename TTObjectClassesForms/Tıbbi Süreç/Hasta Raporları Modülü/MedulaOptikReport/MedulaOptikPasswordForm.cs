
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
    /// E Reçete Şifresi Ekleme Formu
    /// </summary>
    public partial class MedulaOptikPasswordForm : TTForm
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
#region MedulaOptikPasswordForm_cmdPassOK_Click
   _MedulaOptikReport.ERecetePassword = this.ERecetePassword.Text;
            //_OutPatientPrescription.IsRepeated = (bool)this.IsRepeated.Value;
            
            try
            {
                if (this.IsRepeated.Value != null)
                {
                    if ((bool)this.IsRepeated.Value)
                    {
                        ResUser user = (ResUser)this._MedulaOptikReport.ObjectContext.GetObject(Common.CurrentResource.ObjectID, typeof(ResUser));
                        user.ErecetePassword = this.ERecetePassword.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex.ToString(), MessageIconEnum.ErrorMessage);
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
#endregion MedulaOptikPasswordForm_cmdPassOK_Click
        }

        protected override void PreScript()
        {
#region MedulaOptikPasswordForm_PreScript
    base.PreScript();
            this.IsRepeated.Value = false;
            this.cmdCancel.Visible = false;
            this.cmdOK.Visible = false;
#endregion MedulaOptikPasswordForm_PreScript

            }
                }
}