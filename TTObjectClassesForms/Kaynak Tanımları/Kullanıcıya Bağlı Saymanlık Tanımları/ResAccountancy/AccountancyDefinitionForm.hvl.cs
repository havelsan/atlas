
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
    /// Saymanlık Tanımı
    /// </summary>
    public partial class AccountancyDefinitionForm : TTForm
    {
    /// <summary>
    /// Saymanlık
    /// </summary>
        protected TTObjectClasses.ResAccountancy _ResAccountancy
        {
            get { return (TTObjectClasses.ResAccountancy)_ttObject; }
        }

        protected ITTLabel labelLocation;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelDeskPhoneNumber;
        protected ITTEnumComboBox EnabledType;
        protected ITTLabel labelAccountancy;
        protected ITTObjectListBox Accountancy;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox ttcheckbox2;
        protected ITTObjectListBox Hospital;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelEnabledType;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        override protected void InitializeControls()
        {
            labelLocation = (ITTLabel)AddControl(new Guid("589de132-a9a9-4e4d-bdec-536d9ee40153"));
            Location = (ITTTextBox)AddControl(new Guid("a3b57bb7-46cf-4084-a03e-833a7d4d3012"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("1882fdeb-fc47-4f18-a166-b25f69d22de1"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("813410f9-9352-4cea-b3dc-b35682dd0eb2"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("dc547fee-a791-468a-8560-22dc13e26de4"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("8c60071f-a042-4f20-a695-0a51e6b7ea4d"));
            EnabledType = (ITTEnumComboBox)AddControl(new Guid("488d6d5c-2ee2-4029-95d5-a34ec7d265a6"));
            labelAccountancy = (ITTLabel)AddControl(new Guid("b4cc20ce-b60b-44a3-8fa9-6634a03f9dc7"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("41938564-1b45-431f-a91d-5b206c24cbba"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("167431ec-cf73-4c23-9475-a9f5ce23b7c1"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("325c8029-5088-4924-aa5d-065c6e40dd5b"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("be8414bf-50b5-4c80-9542-c8c7e59787c6"));
            Hospital = (ITTObjectListBox)AddControl(new Guid("cfe78a71-bc9b-4dac-88a0-6a105a406481"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("858768c8-8da9-4f96-8d2f-4ce2c16f2da8"));
            labelEnabledType = (ITTLabel)AddControl(new Guid("994c9598-6bdd-4d0c-9ec3-008e3370446a"));
            labelStore = (ITTLabel)AddControl(new Guid("a4936e04-13e6-4c76-a560-3cf9596ff391"));
            Store = (ITTObjectListBox)AddControl(new Guid("285648fd-b25c-4be6-9890-a787ab0a3e5f"));
            base.InitializeControls();
        }

        public AccountancyDefinitionForm() : base("RESACCOUNTANCY", "AccountancyDefinitionForm")
        {
        }

        protected AccountancyDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}