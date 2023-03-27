
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
    /// Yeni Ana TMK Tanımlama
    /// </summary>
    public partial class NewMainTOEDefinitionForm : TTForm
    {
    /// <summary>
    /// Ana TMK Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSMainTOEDefinition _MPBSMainTOEDefinition
        {
            get { return (TTObjectClasses.MPBSMainTOEDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTListDefComboBox ttlistdefcombobox1;
        protected ITTLabel labelUnitDefinition;
        protected ITTTextBox MainTOECode;
        protected ITTCheckBox Active;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("afa4e06e-3e43-46ae-81a6-02bcd14381c2"));
            ttlistdefcombobox1 = (ITTListDefComboBox)AddControl(new Guid("9095e064-5bd5-4940-8b1f-16930a80faff"));
            labelUnitDefinition = (ITTLabel)AddControl(new Guid("127c4f77-1be0-44ce-a358-3461c63ee21d"));
            MainTOECode = (ITTTextBox)AddControl(new Guid("895ac01d-da45-4304-8508-80e7693b6990"));
            Active = (ITTCheckBox)AddControl(new Guid("12a1e822-9baf-48ef-994a-6932bf4c927b"));
            base.InitializeControls();
        }

        public NewMainTOEDefinitionForm() : base("MPBSMAINTOEDEFINITION", "NewMainTOEDefinitionForm")
        {
        }

        protected NewMainTOEDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}