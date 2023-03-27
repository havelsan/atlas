
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
    public partial class DischargeTypeDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.DischargeTypeDefinition _DischargeTypeDefinition
        {
            get { return (TTObjectClasses.DischargeTypeDefinition)_ttObject; }
        }

        protected ITTLabel labelSKRSCikisSekli;
        protected ITTObjectListBox SKRSCikisSekli;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            labelSKRSCikisSekli = (ITTLabel)AddControl(new Guid("a99c659c-4b18-472d-bf81-c2afbfe8da03"));
            SKRSCikisSekli = (ITTObjectListBox)AddControl(new Guid("95f3306e-d0a3-4405-b95a-38f4dbcb0e11"));
            labelName = (ITTLabel)AddControl(new Guid("4e590672-055e-4c61-9489-e219f64e6c6f"));
            Name = (ITTTextBox)AddControl(new Guid("3b0c35b2-dcb6-4dc6-b438-8d66f63cb603"));
            IsActive = (ITTCheckBox)AddControl(new Guid("225672d2-4b64-4909-aed5-e18612cf0eb4"));
            base.InitializeControls();
        }

        public DischargeTypeDefinitionForm() : base("DISCHARGETYPEDEFINITION", "DischargeTypeDefinitionForm")
        {
        }

        protected DischargeTypeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}