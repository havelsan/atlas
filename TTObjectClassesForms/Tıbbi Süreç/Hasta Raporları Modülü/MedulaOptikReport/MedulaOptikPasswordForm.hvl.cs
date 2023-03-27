
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
    /// <summary>
    /// E Reçete Şifresi Ekleme Formu
    /// </summary>
    public partial class MedulaOptikPasswordForm : TTForm
    {
        protected TTObjectClasses.MedulaOptikReport _MedulaOptikReport
        {
            get { return (TTObjectClasses.MedulaOptikReport)_ttObject; }
        }

        protected ITTCheckBox IsRepeated;
        protected ITTTextBox ERecetePassword;
        protected ITTLabel ttlabel2;
        protected ITTButton cmdPassOK;
        override protected void InitializeControls()
        {
            IsRepeated = (ITTCheckBox)AddControl(new Guid("9a036316-3af8-4630-9694-ccd0a67ef24d"));
            ERecetePassword = (ITTTextBox)AddControl(new Guid("d0a60bac-4cae-49fa-80aa-a3cafa4b182e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("eeb8e989-b973-4b4b-afda-66dfe8d64dc6"));
            cmdPassOK = (ITTButton)AddControl(new Guid("30f6f9d4-0816-4c76-81de-67ac99ced412"));
            base.InitializeControls();
        }

        public MedulaOptikPasswordForm() : base("MEDULAOPTIKREPORT", "MedulaOptikPasswordForm")
        {
        }

        protected MedulaOptikPasswordForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}