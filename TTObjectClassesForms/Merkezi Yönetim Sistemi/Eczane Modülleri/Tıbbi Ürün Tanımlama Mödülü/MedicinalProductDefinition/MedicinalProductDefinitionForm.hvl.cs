
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
    /// Tibbi Ürün Tanımı
    /// </summary>
    public partial class MedicinalProductDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Tıbbi Ürün Tanımı
    /// </summary>
        protected TTObjectClasses.MedicinalProductDefinition _MedicinalProductDefinition
        {
            get { return (TTObjectClasses.MedicinalProductDefinition)_ttObject; }
        }

        protected ITTTextBox Name;
        protected ITTTextBox OriginalName;
        protected ITTTextBox Code;
        protected ITTTextBox Barcode;
        protected ITTLabel labelBarcode;
        protected ITTLabel labelName;
        protected ITTLabel labelEnglishName;
        protected ITTLabel labelCode;
        protected ITTObjectListBox MaterialTree;
        protected ITTLabel labelMaterialTree;
        protected ITTObjectListBox StockCard;
        protected ITTLabel labelStockCard;
        protected ITTCheckBox IsActive;
        protected ITTCheckBox Chargable;
        protected ITTCheckBox AllowToGivePatient;
        protected ITTCheckBox IsExpendableMaterial;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage ProductionTabPage;
        protected ITTLabel labelPurchaseDate;
        protected ITTEnumComboBox PrescriptionType;
        protected ITTLabel labelPrescriptionType;
        protected ITTLabel labelVolumeUnit;
        protected ITTDateTimePicker PurchaseDate;
        protected ITTLabel labelBrans;
        protected ITTTextBox Volume;
        protected ITTObjectListBox Brans;
        protected ITTLabel labelMaterialPricingType;
        protected ITTEnumComboBox MaterialPricingType;
        protected ITTLabel labelProducer;
        protected ITTLabel labelVolume;
        protected ITTObjectListBox Producer;
        protected ITTLabel labelProductNumber;
        protected ITTTextBox ProductNumber;
        protected ITTLabel labelGMDNCodeStockCard;
        protected ITTObjectListBox GMDNCodeStockCard;
        protected ITTTextBox Dose;
        protected ITTLabel labelPackageAmount;
        protected ITTTextBox PackageAmount;
        protected ITTLabel labelLicencingOrganization;
        protected ITTLabel labelDose;
        protected ITTObjectListBox VolumeUnit;
        protected ITTEnumComboBox LicencingOrganization;
        protected ITTLabel labelLicenceNO;
        protected ITTTextBox LicenceNO;
        protected ITTLabel labelLicenceDate;
        protected ITTDateTimePicker LicenceDate;
        protected ITTLabel labelCurrentPrice;
        protected ITTTextBox CurrentPrice;
        protected ITTLabel labelBarcodeName;
        protected ITTTextBox BarcodeName;
        protected ITTTabPage DescriptionTabPage;
        protected ITTTextBox Description;
        override protected void InitializeControls()
        {
            Name = (ITTTextBox)AddControl(new Guid("02f61523-e595-449c-869e-5400b678b6ef"));
            OriginalName = (ITTTextBox)AddControl(new Guid("0d958f3e-0335-4869-abc2-96c986e1f1b9"));
            Code = (ITTTextBox)AddControl(new Guid("a8e9a627-8461-4a24-925d-7851c686d0aa"));
            Barcode = (ITTTextBox)AddControl(new Guid("e7e2b49d-288f-4f59-b20a-32b59cf70027"));
            labelBarcode = (ITTLabel)AddControl(new Guid("2ac85863-eb1f-4a72-88e7-4ab203ee423a"));
            labelName = (ITTLabel)AddControl(new Guid("7548082e-ba35-4640-b5e6-e0505a1528a0"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("51ee0ef1-dcb3-4e33-bdbd-d4402205ba7a"));
            labelCode = (ITTLabel)AddControl(new Guid("24920a10-a73a-4271-a2fd-a3fefc355f43"));
            MaterialTree = (ITTObjectListBox)AddControl(new Guid("ba333130-bda7-4eb3-b742-239b812939bf"));
            labelMaterialTree = (ITTLabel)AddControl(new Guid("962a0a43-2995-4e98-83c8-677472ae6695"));
            StockCard = (ITTObjectListBox)AddControl(new Guid("c8413aa6-295e-4106-a57a-48d6ce069d2e"));
            labelStockCard = (ITTLabel)AddControl(new Guid("e96f2166-2f22-403e-8613-3f2b5b0f53dd"));
            IsActive = (ITTCheckBox)AddControl(new Guid("bf9b7775-fbc6-4ed4-993a-8aef93ae29c2"));
            Chargable = (ITTCheckBox)AddControl(new Guid("d3bbb32c-d9cd-4ba7-9093-d67d89c14bbf"));
            AllowToGivePatient = (ITTCheckBox)AddControl(new Guid("7bb6353f-8bac-4533-b297-3aefdcb4e56e"));
            IsExpendableMaterial = (ITTCheckBox)AddControl(new Guid("e70e66c7-5773-49d4-97c1-b72c54ec046d"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("1d8582ab-bfdf-4afb-9b6c-14d76ee039f6"));
            ProductionTabPage = (ITTTabPage)AddControl(new Guid("f2ba953b-2426-47e9-9a3d-e69ea6b3125c"));
            labelPurchaseDate = (ITTLabel)AddControl(new Guid("4f36f9ad-df34-4639-8d51-d3b2bd5516b2"));
            PrescriptionType = (ITTEnumComboBox)AddControl(new Guid("361c0971-3b54-463f-b844-7475bc25dc7c"));
            labelPrescriptionType = (ITTLabel)AddControl(new Guid("1bb1115d-a944-4598-9cfd-c6e69a855706"));
            labelVolumeUnit = (ITTLabel)AddControl(new Guid("439ab27d-c945-42c8-ba89-5405a42a9dcd"));
            PurchaseDate = (ITTDateTimePicker)AddControl(new Guid("c50189da-d3fa-44e3-8cc3-f3e92bcfecc4"));
            labelBrans = (ITTLabel)AddControl(new Guid("a84d1cbe-693e-457a-b39c-31afab5da93a"));
            Volume = (ITTTextBox)AddControl(new Guid("a5c8c66e-5254-40ce-add3-ed74445b9e89"));
            Brans = (ITTObjectListBox)AddControl(new Guid("772407e3-e7e8-411b-af6e-f842492ff505"));
            labelMaterialPricingType = (ITTLabel)AddControl(new Guid("73caf84d-34d1-40f9-bdb8-2997d2a9fc0a"));
            MaterialPricingType = (ITTEnumComboBox)AddControl(new Guid("0cdbd7e4-c7d3-4b89-b4e9-ac5882768603"));
            labelProducer = (ITTLabel)AddControl(new Guid("f11322b0-08aa-4a48-b608-692196655c0b"));
            labelVolume = (ITTLabel)AddControl(new Guid("a8269f84-bb6f-4a44-9086-654f72d856ea"));
            Producer = (ITTObjectListBox)AddControl(new Guid("1d233050-5e78-415a-a557-e44d50d17f62"));
            labelProductNumber = (ITTLabel)AddControl(new Guid("3fb9864f-c79f-4d0c-8f34-040f402ff3a5"));
            ProductNumber = (ITTTextBox)AddControl(new Guid("db78d847-4391-40a6-b8dd-60fe61b7d598"));
            labelGMDNCodeStockCard = (ITTLabel)AddControl(new Guid("e7192024-85e0-40b5-ad59-68eeaaf94e32"));
            GMDNCodeStockCard = (ITTObjectListBox)AddControl(new Guid("e640206e-426f-4103-a2f0-d15cfdf0d058"));
            Dose = (ITTTextBox)AddControl(new Guid("87697a5f-9f9b-4510-bf15-53f20a0f69d9"));
            labelPackageAmount = (ITTLabel)AddControl(new Guid("62c2a0c8-42d8-4fad-a1ac-3df1dd683c6f"));
            PackageAmount = (ITTTextBox)AddControl(new Guid("a9d78de8-6b90-4274-a1e7-b1ea1911703a"));
            labelLicencingOrganization = (ITTLabel)AddControl(new Guid("381141a0-7924-412b-9029-712619d86f8b"));
            labelDose = (ITTLabel)AddControl(new Guid("b41c06e7-ac2c-456b-9887-42f22dcc6d13"));
            VolumeUnit = (ITTObjectListBox)AddControl(new Guid("f77d917a-a347-44e3-8f0e-9074417c3383"));
            LicencingOrganization = (ITTEnumComboBox)AddControl(new Guid("bf28c6a8-75ef-43f5-a677-0c18ba53996e"));
            labelLicenceNO = (ITTLabel)AddControl(new Guid("8e37e74e-409c-4ab5-8672-8432cf545af4"));
            LicenceNO = (ITTTextBox)AddControl(new Guid("38f797de-854e-49ea-a4de-895b3c225782"));
            labelLicenceDate = (ITTLabel)AddControl(new Guid("c7a65fe9-3aec-4cdf-8b6d-6dd302e26e2f"));
            LicenceDate = (ITTDateTimePicker)AddControl(new Guid("b175ec2d-4d6e-4e26-9b23-75de4035757b"));
            labelCurrentPrice = (ITTLabel)AddControl(new Guid("84c5e3c3-dc57-42b5-a0c7-8776457b1b95"));
            CurrentPrice = (ITTTextBox)AddControl(new Guid("7948f938-34de-4d50-8649-365701b0542a"));
            labelBarcodeName = (ITTLabel)AddControl(new Guid("04a4ae5a-c150-4a0a-ae22-a8137036497e"));
            BarcodeName = (ITTTextBox)AddControl(new Guid("affa8a44-f805-4d73-ae83-0d23ee597262"));
            DescriptionTabPage = (ITTTabPage)AddControl(new Guid("44aa6773-c1d4-4e7c-924e-431a6f27a81c"));
            Description = (ITTTextBox)AddControl(new Guid("6ab9d2cb-d89e-4a26-b2b5-f2ab1e3ac7ef"));
            base.InitializeControls();
        }

        public MedicinalProductDefinitionForm() : base("MEDICINALPRODUCTDEFINITION", "MedicinalProductDefinitionForm")
        {
        }

        protected MedicinalProductDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}