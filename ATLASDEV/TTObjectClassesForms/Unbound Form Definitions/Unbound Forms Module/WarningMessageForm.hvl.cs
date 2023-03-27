
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

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class WarningMessageForm : TTUnboundForm
    {
        protected ITTButton btnOK;
        protected ITTCheckBox chkNotShowAgain;
        protected ITTLabel lblWarning;
        protected ITTTextBox txtWarningMessage;
        override protected void InitializeControls()
        {
            btnOK = (ITTButton)AddControl(new Guid("e198b560-2e58-43ea-ab7f-e4343d0ab45f"));
            chkNotShowAgain = (ITTCheckBox)AddControl(new Guid("5271ef28-2606-405e-a7b0-9af9fdb87a9a"));
            lblWarning = (ITTLabel)AddControl(new Guid("190b95c4-8448-4fcb-ba06-c521de2fed6b"));
            txtWarningMessage = (ITTTextBox)AddControl(new Guid("13b21b22-dd69-4dfc-91e6-88d6bcb72d25"));
            base.InitializeControls();
        }

        public WarningMessageForm() : base("WarningMessageForm")
        {
        }

        protected WarningMessageForm(string formDefName) : base(formDefName)
        {
        }
    }
}