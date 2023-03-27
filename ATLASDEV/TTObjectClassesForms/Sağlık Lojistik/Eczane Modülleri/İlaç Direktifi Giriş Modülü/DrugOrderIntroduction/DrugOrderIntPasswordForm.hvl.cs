
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
    /// E Reçete Şifre
    /// </summary>
    public partial class DrugOrderIntPasswordForm : TTForm
    {
    /// <summary>
    /// İlaç Direktifi Giriş
    /// </summary>
        protected TTObjectClasses.DrugOrderIntroduction _DrugOrderIntroduction
        {
            get { return (TTObjectClasses.DrugOrderIntroduction)_ttObject; }
        }

        protected ITTTextBox ERecetePassword;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox IsRepeated;
        protected ITTButton cmdPassOK;
        override protected void InitializeControls()
        {
            ERecetePassword = (ITTTextBox)AddControl(new Guid("4c55b6da-529b-44f2-bcd8-2263f8ab56bc"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("d358692d-75e4-4801-8b3d-f1b988697cdd"));
            IsRepeated = (ITTCheckBox)AddControl(new Guid("26254a43-5785-45ed-910e-bf4024ce5628"));
            cmdPassOK = (ITTButton)AddControl(new Guid("dc4ab01d-549f-4785-a13b-2b54b7374bfe"));
            base.InitializeControls();
        }

        public DrugOrderIntPasswordForm() : base("DRUGORDERINTRODUCTION", "DrugOrderIntPasswordForm")
        {
        }

        protected DrugOrderIntPasswordForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}