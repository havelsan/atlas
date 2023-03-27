
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
    /// Dış Eczane Tanımı
    /// </summary>
    public partial class ExternalPharmacyForm : TTDefinitionForm
    {
    /// <summary>
    /// Dış Eczane 
    /// </summary>
        protected TTObjectClasses.ExternalPharmacy _ExternalPharmacy
        {
            get { return (TTObjectClasses.ExternalPharmacy)_ttObject; }
        }

        protected ITTTextBox TotalBalance;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage PharmacyTabPage;
        protected ITTGrid ExternalPharmacyStatuses;
        protected ITTDateTimePickerColumn StartDate;
        protected ITTDateTimePickerColumn EndDate;
        protected ITTEnumComboBoxColumn Status2;
        protected ITTTextBoxColumn Description;
        protected ITTTextBox Name;
        protected ITTTextBox Telephone1;
        protected ITTTextBox AuthorizedPerson;
        protected ITTTextBox Address;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox Fax;
        protected ITTTextBox Telephone2;
        protected ITTTextBox EMail;
        protected ITTLabel labelTelephone2;
        protected ITTEnumComboBox Status;
        protected ITTLabel labelOpeningDate;
        protected ITTLabel labelStatus;
        protected ITTDateTimePicker OpeningDate;
        protected ITTLabel labelDescription;
        protected ITTLabel labelAddress;
        protected ITTLabel labelTelephone1;
        protected ITTLabel labelName;
        protected ITTLabel labelFax;
        protected ITTLabel labelEMail;
        protected ITTLabel labelAuthorizedPerson;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            TotalBalance = (ITTTextBox)AddControl(new Guid("edf4db13-c92b-4b29-a3d2-c6f6cac3c34c"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("c3cbe3d8-2a18-4cea-b2fd-b35abc889840"));
            PharmacyTabPage = (ITTTabPage)AddControl(new Guid("d6214053-2956-4598-93e0-fb1c587c91aa"));
            ExternalPharmacyStatuses = (ITTGrid)AddControl(new Guid("a5cc1a61-e0b0-402c-8126-60a910a15f64"));
            StartDate = (ITTDateTimePickerColumn)AddControl(new Guid("4f31f96e-c4f1-40c2-9a6b-8f357d1319b2"));
            EndDate = (ITTDateTimePickerColumn)AddControl(new Guid("24f4cde1-a42c-48c9-9d5a-30c1feb30083"));
            Status2 = (ITTEnumComboBoxColumn)AddControl(new Guid("a134ed7c-bd65-4d99-8aa8-5df88dc69943"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("dde330dd-ac8e-48e3-a46e-72799609a3aa"));
            Name = (ITTTextBox)AddControl(new Guid("c620cb8e-fd87-4d25-a835-032913f6a8fb"));
            Telephone1 = (ITTTextBox)AddControl(new Guid("59b34f9f-9760-431f-a53d-0bbeb04d0fcf"));
            AuthorizedPerson = (ITTTextBox)AddControl(new Guid("cef65de7-4a2c-4749-958d-146253a542d6"));
            Address = (ITTTextBox)AddControl(new Guid("56f9ba7a-1178-46f5-9a5d-311530319b39"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("da1d6766-3b37-4c1e-85f1-647c1399f154"));
            Fax = (ITTTextBox)AddControl(new Guid("a346850e-0756-4529-8fa4-7a4ccf0b29a0"));
            Telephone2 = (ITTTextBox)AddControl(new Guid("91f687f4-a5a4-45e0-9059-7d09c3cfc974"));
            EMail = (ITTTextBox)AddControl(new Guid("60b171ac-6128-4191-bc58-dbfb515cb366"));
            labelTelephone2 = (ITTLabel)AddControl(new Guid("f0185900-7893-4fa9-b4a0-00a06069f2a6"));
            Status = (ITTEnumComboBox)AddControl(new Guid("c842b615-5f8d-4861-8d73-0446c7691d7c"));
            labelOpeningDate = (ITTLabel)AddControl(new Guid("8cb634c2-92c2-4057-9cbc-0618d420a80d"));
            labelStatus = (ITTLabel)AddControl(new Guid("cea62959-870e-45f1-be45-1946794a7bab"));
            OpeningDate = (ITTDateTimePicker)AddControl(new Guid("7c635393-d6ef-4f0b-813f-2790003e65ef"));
            labelDescription = (ITTLabel)AddControl(new Guid("3cacd15a-043f-4de3-a932-2808e17912de"));
            labelAddress = (ITTLabel)AddControl(new Guid("e25937ef-9c79-468a-a4f3-3fbc1f6677d1"));
            labelTelephone1 = (ITTLabel)AddControl(new Guid("c823c41c-d34c-4eba-998f-6858093706b2"));
            labelName = (ITTLabel)AddControl(new Guid("69faeac4-c065-46b3-b96d-76aaa3665a6d"));
            labelFax = (ITTLabel)AddControl(new Guid("3e476205-c19e-467f-81e3-92c97a37e6ad"));
            labelEMail = (ITTLabel)AddControl(new Guid("63ae3a27-b56e-416f-b41d-c227394563c8"));
            labelAuthorizedPerson = (ITTLabel)AddControl(new Guid("1abdfcbf-149f-4cdf-9f53-f96e1fdc21a2"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("eae80dbb-7ebe-4871-9326-5746cae6f10c"));
            base.InitializeControls();
        }

        public ExternalPharmacyForm() : base("EXTERNALPHARMACY", "ExternalPharmacyForm")
        {
        }

        protected ExternalPharmacyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}