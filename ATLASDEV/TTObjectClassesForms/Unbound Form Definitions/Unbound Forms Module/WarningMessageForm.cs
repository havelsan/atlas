
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
    public partial class WarningMessageForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            btnOK.Click += new TTControlEventDelegate(btnOK_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnOK.Click -= new TTControlEventDelegate(btnOK_Click);
            base.UnBindControlEvents();
        }

        private void btnOK_Click()
        {
#region WarningMessageForm_btnOK_Click
   if(((TTVisual.TTCheckBox)this.chkNotShowAgain).Checked == true)
            {
                Common.CurrentResource.PrivacyPatientNotShownList.Add(this.CurrentPatient.ObjectID);
            }
            this.Close();
#endregion WarningMessageForm_btnOK_Click
        }

#region WarningMessageForm_Methods
        private Patient _currentPatient;
        public Patient CurrentPatient
        {
            get
            {return this._currentPatient;}
            set
            {_currentPatient = value;}
        }
        
        private string _warningMessage;
        public string WarningMessage
        {
            get
            {return this._warningMessage;}
            set
            {_warningMessage = value;}
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            FillWarningMessage(_warningMessage);
        }
        
        private void FillWarningMessage(string message)
        {
            this.txtWarningMessage.Text = message;
        }
        
#endregion WarningMessageForm_Methods
    }
}