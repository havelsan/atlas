
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
    public partial class DependentUnitDefinitionForm : TTForm
    {
        protected TTObjectClasses.ResDependentUnit _ResDependentUnit
        {
            get { return (TTObjectClasses.ResDependentUnit)_ttObject; }
        }

        protected ITTLabel labelMilitaryUnit;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTObjectListBox Accountancy;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox ttcheckbox2;
        protected ITTLabel ttlabel4;
        protected ITTEnumComboBox EnabledType;
        protected ITTLabel labelEnabledType;
        protected ITTObjectListBox Store;
        protected ITTLabel labelStore;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            labelMilitaryUnit = (ITTLabel)AddControl(new Guid("720b7454-1c10-4d7b-9ef0-d29a07e66a38"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("4fe48a1a-d388-4106-9cfc-32bb010b5887"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("f63cb22e-f635-40f8-a22a-4d4a9fb13b37"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0adcb4f9-db1b-4986-92ab-11763191deac"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("fcd14a75-ad45-4231-883d-eb93ef09e4d7"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("01a1f90c-98cb-4ff3-9135-9940e23c7248"));
            Location = (ITTTextBox)AddControl(new Guid("7381ec9f-f6e8-4c39-b38d-a8bae1e9a9f0"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("854c76d4-9235-4375-9495-c6316eae6a0b"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("693eb321-d473-4521-a9fa-458a3d282709"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("12819e88-ab12-4bcc-9232-23ce662a8a7e"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("090cc120-91c4-4561-968d-157a3df436f6"));
            EnabledType = (ITTEnumComboBox)AddControl(new Guid("89798aa7-38ea-4586-aeae-a783f2fce27d"));
            labelEnabledType = (ITTLabel)AddControl(new Guid("28e80841-a17c-473e-92e4-4db822ad6c6f"));
            Store = (ITTObjectListBox)AddControl(new Guid("e5fa9f28-78cd-43cd-afc7-731a5faa810e"));
            labelStore = (ITTLabel)AddControl(new Guid("ca398066-f759-4e31-acba-65807eef7a0d"));
            labelLocation = (ITTLabel)AddControl(new Guid("617ea123-dbc1-4171-aeeb-37b5d2174e94"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("379fee5e-7b62-4c44-b9cb-97e80efa7f3d"));
            base.InitializeControls();
        }

        public DependentUnitDefinitionForm() : base("RESDEPENDENTUNIT", "DependentUnitDefinitionForm")
        {
        }

        protected DependentUnitDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}