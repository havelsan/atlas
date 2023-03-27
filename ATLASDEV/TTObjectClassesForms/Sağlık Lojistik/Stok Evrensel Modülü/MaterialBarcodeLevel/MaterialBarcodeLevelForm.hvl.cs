
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
    public partial class MaterialBarcodeLevelForm : TTForm
    {
    /// <summary>
    /// Malzemenin barkod seviyesi bilgilerini tutan sınıftır
    /// </summary>
        protected TTObjectClasses.MaterialBarcodeLevel _MaterialBarcodeLevel
        {
            get { return (TTObjectClasses.MaterialBarcodeLevel)_ttObject; }
        }

        protected ITTLabel labelGMDNDefinition;
        protected ITTObjectListBox GMDNDefinition;
        protected ITTLabel labelProducer;
        protected ITTObjectListBox Producer;
        protected ITTLabel labelProductNumber;
        protected ITTTextBox ProductNumber;
        protected ITTLabel labelSPTSLicencingOrganizationID;
        protected ITTTextBox SPTSLicencingOrganizationID;
        protected ITTLabel labelSPTSDrugID;
        protected ITTTextBox SPTSDrugID;
        protected ITTLabel labelPackageAmount;
        protected ITTTextBox PackageAmount;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelLicencingOrganization;
        protected ITTEnumComboBox LicencingOrganization;
        protected ITTLabel labelLicenceNO;
        protected ITTTextBox LicenceNO;
        protected ITTLabel labelLicenceDate;
        protected ITTDateTimePicker LicenceDate;
        protected ITTLabel labelCurrentPrice;
        protected ITTTextBox CurrentPrice;
        protected ITTLabel labelBarcode;
        protected ITTTextBox Barcode;
        override protected void InitializeControls()
        {
            labelGMDNDefinition = (ITTLabel)AddControl(new Guid("7365b30e-16b6-428a-bc42-44e84923036f"));
            GMDNDefinition = (ITTObjectListBox)AddControl(new Guid("5cb9902a-2b0e-4390-8f77-83d35c09657c"));
            labelProducer = (ITTLabel)AddControl(new Guid("62d17d8a-a513-4e58-a9e7-b2b3417dfe33"));
            Producer = (ITTObjectListBox)AddControl(new Guid("187bda7c-2ac5-4aeb-810f-a45092af5cf7"));
            labelProductNumber = (ITTLabel)AddControl(new Guid("dd66e33b-0f58-4f58-ab84-29b939e2ecaa"));
            ProductNumber = (ITTTextBox)AddControl(new Guid("916c7166-4a3d-41ac-b8be-77f9791d49b9"));
            labelSPTSLicencingOrganizationID = (ITTLabel)AddControl(new Guid("58537ee0-12df-4e31-ab52-a7c18a8e368b"));
            SPTSLicencingOrganizationID = (ITTTextBox)AddControl(new Guid("d3e54e1e-4405-497b-a955-88ee484a1dbe"));
            labelSPTSDrugID = (ITTLabel)AddControl(new Guid("d7c76637-87e8-4379-b2e0-c61ed550bca1"));
            SPTSDrugID = (ITTTextBox)AddControl(new Guid("428fca3c-fee7-4188-8389-430e01495ede"));
            labelPackageAmount = (ITTLabel)AddControl(new Guid("7f4f30fc-e555-4f54-b0ed-b8dd2fff44b3"));
            PackageAmount = (ITTTextBox)AddControl(new Guid("9c288031-907c-4b9e-bc91-3281367b4e08"));
            labelName = (ITTLabel)AddControl(new Guid("24d0b9c0-694c-4350-a083-a653f55490ec"));
            Name = (ITTTextBox)AddControl(new Guid("eab18112-0c09-4741-8447-ba8a02e90ba2"));
            labelLicencingOrganization = (ITTLabel)AddControl(new Guid("e5f98b77-6e7c-4479-8046-1f619bf727e3"));
            LicencingOrganization = (ITTEnumComboBox)AddControl(new Guid("fe540d1b-ae7c-4faf-b137-17244eb7d74b"));
            labelLicenceNO = (ITTLabel)AddControl(new Guid("5fdf8f7f-b4ca-44ac-b768-75f3932b3812"));
            LicenceNO = (ITTTextBox)AddControl(new Guid("d1f6bdd8-77c6-422b-a789-c83e772b5b6d"));
            labelLicenceDate = (ITTLabel)AddControl(new Guid("6f68c876-e567-48e3-96e0-679ea614ae0a"));
            LicenceDate = (ITTDateTimePicker)AddControl(new Guid("38277ab3-ee98-4356-86bd-93fb06eda613"));
            labelCurrentPrice = (ITTLabel)AddControl(new Guid("cadb4803-9ff0-41d6-9287-cee510222ad0"));
            CurrentPrice = (ITTTextBox)AddControl(new Guid("0edcfec0-0202-4b9e-a2a7-dc40228b3fc7"));
            labelBarcode = (ITTLabel)AddControl(new Guid("ff7875af-a3ed-4971-9bce-56537270c896"));
            Barcode = (ITTTextBox)AddControl(new Guid("c3e52698-66e4-466a-aac3-f6b0bdbc7853"));
            base.InitializeControls();
        }

        public MaterialBarcodeLevelForm() : base("MATERIALBARCODELEVEL", "MaterialBarcodeLevelForm")
        {
        }

        protected MaterialBarcodeLevelForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}