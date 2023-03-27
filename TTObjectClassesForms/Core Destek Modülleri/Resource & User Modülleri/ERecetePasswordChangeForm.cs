
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
    /// E Reçete Şifresi Güncelleme
    /// </summary>
    public partial class ERecetePasswordChangeForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            cmdExit.Click += new TTControlEventDelegate(cmdExit_Click);
            cmdChange.Click += new TTControlEventDelegate(cmdChange_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdExit.Click -= new TTControlEventDelegate(cmdExit_Click);
            cmdChange.Click -= new TTControlEventDelegate(cmdChange_Click);
            base.UnBindControlEvents();
        }

        private void cmdExit_Click()
        {
#region ERecetePasswordChangeForm_cmdExit_Click
   this.Close();
#endregion ERecetePasswordChangeForm_cmdExit_Click
        }

        private void cmdChange_Click()
        {
#region ERecetePasswordChangeForm_cmdChange_Click
   if(newPassText.Text.Equals(newPassRepeatText.Text))
            {
                TTObjectContext context = new TTObjectContext(false);
                ResUser resUser = (ResUser) context.GetObject(((ResUser)Common.CurrentUser.UserObject).ObjectID,typeof(ResUser));
                resUser.ErecetePassword = newPassText.Text ;
                context.Save();
                context.Dispose();
                this.Close();
            }
            else
                InfoBox.Show( "Şifreyi tekrar yazınız",MessageIconEnum.ErrorMessage);
#endregion ERecetePasswordChangeForm_cmdChange_Click
        }

#region ERecetePasswordChangeForm_Methods
        protected override void OnLoad(EventArgs e)
        {
            this.CenterToScreen();
            GetUserPassword();

        }

        public void GetUserPassword()
        {
            ResUser currentUser = ((ResUser)Common.CurrentUser.UserObject);
            userFullNameLabel.Text = currentUser.Name ;
            oldPassText.Text = currentUser.ErecetePassword ;
        }
        
#endregion ERecetePasswordChangeForm_Methods
    }
}