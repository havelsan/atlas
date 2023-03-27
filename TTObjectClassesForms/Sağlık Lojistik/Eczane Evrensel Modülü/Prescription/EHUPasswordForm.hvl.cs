
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
    /// E Reçete Şifre Giriş
    /// </summary>
    public partial class EHUPasswordForm : PrescriptionBaseForm
    {
    /// <summary>
    /// Reçete Ana Sınıfı
    /// </summary>
        protected TTObjectClasses.Prescription _Prescription
        {
            get { return (TTObjectClasses.Prescription)_ttObject; }
        }

        protected ITTButton cmdPassOK;
        protected ITTCheckBox IsRepeated;
        protected ITTTextBox ERecetePassword;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            cmdPassOK = (ITTButton)AddControl(new Guid("c14f0cbb-355c-4fc8-b85a-cc1fad467084"));
            IsRepeated = (ITTCheckBox)AddControl(new Guid("c9887208-4320-4d20-a9e4-102a0fc5e476"));
            ERecetePassword = (ITTTextBox)AddControl(new Guid("a6863b59-9166-47ca-916e-dc415479d918"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("b4d6c367-e787-46e5-8ecc-32d9076b7654"));
            base.InitializeControls();
        }

        public EHUPasswordForm() : base("PRESCRIPTION", "EHUPasswordForm")
        {
        }

        protected EHUPasswordForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}