
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
    /// Geliş Sebebi Tanımlama
    /// </summary>
    public partial class AdmissionTypeForm : TTDefinitionForm
    {
    /// <summary>
    /// Geliş Sebebi Tanımları
    /// </summary>
        protected TTObjectClasses.AdmissionTypeDefinition _AdmissionTypeDefinition
        {
            get { return (TTObjectClasses.AdmissionTypeDefinition)_ttObject; }
        }

        protected ITTEnumComboBox ReasonAdmissionEnum;
        protected ITTLabel ttlabel3;
        protected ITTCheckBox ttcheckbox1;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            ReasonAdmissionEnum = (ITTEnumComboBox)AddControl(new Guid("2276e8ad-fe06-4eae-8b81-6068399780ed"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("5147a3a7-cb3a-47e9-bee4-a4facfaec7af"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("7c9f7a37-e29d-42ac-bc79-2c4c75c079ca"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("94e71fb4-9889-4522-8dd0-f200abe2b346"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("ab7d0ca6-0baf-44b6-b7ef-b7232a7f5eee"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("c3f7edfe-54d4-49a1-9629-366f4d17a7b6"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("9e605a44-7088-405e-a592-71d9f20ebea0"));
            base.InitializeControls();
        }

        public AdmissionTypeForm() : base("ADMISSIONTYPEDEFINITION", "AdmissionTypeForm")
        {
        }

        protected AdmissionTypeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}