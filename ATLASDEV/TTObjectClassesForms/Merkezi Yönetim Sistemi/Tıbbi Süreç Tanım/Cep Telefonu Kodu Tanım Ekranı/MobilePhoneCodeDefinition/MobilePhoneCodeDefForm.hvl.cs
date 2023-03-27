
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
    /// Cep Telefonu Kodu Tanım Ekranı
    /// </summary>
    public partial class MobilePhoneCodeDefForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Cep Telefonu Kodu Tanımı
    /// </summary>
        protected TTObjectClasses.MobilePhoneCodeDefinition _MobilePhoneCodeDefinition
        {
            get { return (TTObjectClasses.MobilePhoneCodeDefinition)_ttObject; }
        }

        protected ITTCheckBox IsActive;
        protected ITTLabel labelOperatorName;
        protected ITTTextBox OperatorName;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            IsActive = (ITTCheckBox)AddControl(new Guid("9e5340cc-dc35-4bff-af21-6ba6ff978898"));
            labelOperatorName = (ITTLabel)AddControl(new Guid("e4be5586-02bd-42f0-ab6a-e2c370d24c93"));
            OperatorName = (ITTTextBox)AddControl(new Guid("428a575d-7891-4e1d-8ffc-6aa39a9f4270"));
            Code = (ITTTextBox)AddControl(new Guid("1d22ea31-2122-4f09-b063-ebfc80266aad"));
            labelCode = (ITTLabel)AddControl(new Guid("2f1496f5-8057-44b9-9c62-da34b13a1fbd"));
            base.InitializeControls();
        }

        public MobilePhoneCodeDefForm() : base("MOBILEPHONECODEDEFINITION", "MobilePhoneCodeDefForm")
        {
        }

        protected MobilePhoneCodeDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}