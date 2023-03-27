
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
    public partial class PasswordForm : PrescriptionBaseForm
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
            cmdPassOK = (ITTButton)AddControl(new Guid("12b31239-01bb-4a14-9573-143f7c11ae9d"));
            IsRepeated = (ITTCheckBox)AddControl(new Guid("7ced1f1c-7c8d-4831-a8aa-ef83abb739b8"));
            ERecetePassword = (ITTTextBox)AddControl(new Guid("1fe527a1-0aaa-4627-abeb-736fc7033666"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("69bb8402-0c09-44a0-800e-159857dce972"));
            base.InitializeControls();
        }

        public PasswordForm() : base("PRESCRIPTION", "PasswordForm")
        {
        }

        protected PasswordForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}