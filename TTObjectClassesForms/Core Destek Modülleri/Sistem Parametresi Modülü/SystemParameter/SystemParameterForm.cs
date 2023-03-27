
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
    /// Sistem Parametre Tanımı
    /// </summary>
    public partial class SystemParameterForm : BaseParameterForm
    {
        override protected void BindControlEvents()
        {
            cmdEncrypt.Click += new TTControlEventDelegate(cmdEncrypt_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdEncrypt.Click -= new TTControlEventDelegate(cmdEncrypt_Click);
            base.UnBindControlEvents();
        }

        private void cmdEncrypt_Click()
        {
#region SystemParameterForm_cmdEncrypt_Click
   if (this.IsEncrypted.Value.HasValue && this.IsEncrypted.Value.Value == true)
            {
                InfoBox.Show("Zaten şifreli.");
                return;
            }
            
            string t = this.Value.Text;
            if (t.Length == 0)
            {
                InfoBox.Show("Değer girilmemiş.");
                return;
            }
                
            this.Value.Text = TTUtils.EncryptionBase.Encrypt(t);
            this.IsEncrypted.Value = true;
#endregion SystemParameterForm_cmdEncrypt_Click
        }

        protected override void PreScript()
        {
#region SystemParameterForm_PreScript
    base.PreScript();
            _SystemParameter.SubType = SystemParameterSubTypeEnum.System;
#endregion SystemParameterForm_PreScript

            }
                }
}