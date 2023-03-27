
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
    /// Stok Kontrol Kısım Tanımı
    /// </summary>
    public partial class StockControlSectionDefinitionForm : TTForm
    {
        protected TTObjectClasses.ResStockControlSection _ResStockControlSection
        {
            get { return (TTObjectClasses.ResStockControlSection)_ttObject; }
        }

        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox ttcheckbox2;
        protected ITTObjectListBox Accountancy;
        protected ITTLabel ttlabel4;
        protected ITTEnumComboBox EnabledType;
        protected ITTLabel labelEnabledType;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            tttextbox2 = (ITTTextBox)AddControl(new Guid("0cd288b8-04c5-41a5-a908-b8920a5af862"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("841b9e6b-e3ad-479f-a410-23063986e021"));
            Location = (ITTTextBox)AddControl(new Guid("1fb7cc92-e444-4819-84a8-4a65968c0d40"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("51a9ebe5-c553-44ad-99e3-91a3c1173a1c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("838c0d61-4cff-4523-bcd8-4edf3ddd5aca"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("d4caef47-8b94-4ea3-9b5f-2f2b933b4d51"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("417d8771-9d8f-4adc-b0cd-9a0f15a0af7a"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("330676f3-14fa-447b-a206-9050dd3250ba"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("39e5514e-011d-4c9c-a3e6-3396a1023279"));
            EnabledType = (ITTEnumComboBox)AddControl(new Guid("d924a16e-de2a-457b-aee2-f067aa4a0a5f"));
            labelEnabledType = (ITTLabel)AddControl(new Guid("98b7b16c-70f3-4469-b47e-ba360f459c24"));
            labelStore = (ITTLabel)AddControl(new Guid("2b10e042-8ab4-4f93-8ff1-689ae47f74c1"));
            Store = (ITTObjectListBox)AddControl(new Guid("52d24b7a-5676-4408-b432-a571b8b2e8da"));
            labelLocation = (ITTLabel)AddControl(new Guid("db20050d-548d-4e89-9c0b-ac9a2a34ba88"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("d17b96e5-7146-4496-89b0-3fc6ec0ac430"));
            base.InitializeControls();
        }

        public StockControlSectionDefinitionForm() : base("RESSTOCKCONTROLSECTION", "StockControlSectionDefinitionForm")
        {
        }

        protected StockControlSectionDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}