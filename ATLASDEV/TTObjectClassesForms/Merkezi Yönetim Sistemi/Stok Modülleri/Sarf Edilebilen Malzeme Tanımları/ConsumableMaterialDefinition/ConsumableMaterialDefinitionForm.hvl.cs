
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
    /// Sarf Edilebilen Malzeme Tanımları
    /// </summary>
    public partial class ConsumableMaterialDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Sarf Edilebilen Malzeme Tanımları
    /// </summary>
        protected TTObjectClasses.ConsumableMaterialDefinition _ConsumableMaterialDefinition
        {
            get { return (TTObjectClasses.ConsumableMaterialDefinition)_ttObject; }
        }

        protected ITTLabel labelRelatedRevenueSubAccountRevenueSubAccountCodeDefinition;
        protected ITTObjectListBox RelatedRevenueSubAccountRevenueSubAccountCodeDefinition;
        protected ITTCheckBox NotShownOnEpicrisisForm;
        protected ITTCheckBox IsTagNoRequired;
        protected ITTCheckBox IsIndividualTrackingRequired;
        protected ITTCheckBox SendSMS;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel lblSUTAppendix;
        protected ITTLabel labelMkysMalzemeKodu;
        protected ITTTextBox MkysMalzemeKodu;
        protected ITTTextBox EstimatedTimeOfCheck;
        protected ITTTextBox StorageConditions;
        protected ITTTextBox Barcode;
        protected ITTCheckBox IsPackageExclusive;
        protected ITTLabel labelEstimatedTimeOfCheck;
        protected ITTLabel labelStorageConditions;
        protected ITTLabel labelCreationDate;
        protected ITTDateTimePicker CreationDate;
        protected ITTCheckBox IsRestrictedMaterial;
        protected ITTCheckBox IsOldMaterial;
        protected ITTGrid MaterialSpecialtys;
        protected ITTListBoxColumn MaterialSpecialtyDefinitionMaterialSpecialty;
        protected ITTLabel labelMaterialPurposeDefinition;
        protected ITTObjectListBox MaterialPurposeDefinition;
        protected ITTLabel labelMaterialPlaceOfUseDef;
        protected ITTObjectListBox MaterialPlaceOfUseDef;
        protected ITTCheckBox IsExpendableMaterial;
        protected ITTLabel labelBarcode;
        protected ITTButton cmdSendChanging;
        protected ITTButton cmdChangeTypeToFixedAsset;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage ProductionInfoTabPage;
        protected ITTCheckBox HasEstimatedTimeConsumableMaterialDefinition;
        protected ITTCheckBox CreateInMedulaDontSendState;
        protected ITTLabel lblMedulaMultiplier;
        protected ITTLabel labelAuctionDate;
        protected ITTTextBox MedulaMultiplier;
        protected ITTLabel labelRegistrationAuctionNo;
        protected ITTDateTimePicker AuctionDate;
        protected ITTCheckBox IsAllogreft;
        protected ITTTextBox RegistrationAuctionNo;
        protected ITTLabel labelPurchaseDate;
        protected ITTDateTimePicker PurchaseDate;
        protected ITTLabel labelMaterialPricingType;
        protected ITTEnumComboBox MaterialPricingType;
        protected ITTLabel labelBrans;
        protected ITTObjectListBox Brans;
        protected ITTLabel labelProducer;
        protected ITTObjectListBox Producer;
        protected ITTLabel labelGMDNCodeStockCard;
        protected ITTObjectListBox GMDNCodeStockCard;
        protected ITTLabel labelPackageAmount;
        protected ITTTextBox PackageAmount;
        protected ITTLabel labelLicencingOrganization;
        protected ITTEnumComboBox LicencingOrganization;
        protected ITTLabel labelLicenceNO;
        protected ITTTextBox LicenceNO;
        protected ITTLabel labelLicenceDate;
        protected ITTDateTimePicker LicenceDate;
        protected ITTLabel labelCurrentPrice;
        protected ITTTextBox CurrentPrice;
        protected ITTLabel labelBarcodeName;
        protected ITTTextBox BarcodeName;
        protected ITTLabel labelProductNumber;
        protected ITTTextBox ProductNumber;
        protected ITTTabPage MaterialVatRateTabPage;
        protected ITTLabel ttlabel2;
        protected ITTGrid MaterialPriceGrid;
        protected ITTTextBoxColumn PriceCode;
        protected ITTTextBoxColumn Description;
        protected ITTListBoxColumn PricingList;
        protected ITTTextBoxColumn Price;
        protected ITTListBoxColumn CurrencyType;
        protected ITTLabel ttlabel1;
        protected ITTGrid MaterialVatRates;
        protected ITTTextBoxColumn VatRate;
        protected ITTDateTimePickerColumn StartDate;
        protected ITTDateTimePickerColumn EndDate;
        protected ITTTabPage PictureTabPage;
        protected ITTPictureBoxControl MaterialPicture;
        protected ITTTabPage ProductLevelTabPage;
        protected ITTGrid MaterialProductLevels;
        protected ITTListBoxColumn ProductMaterialProductLevel;
        protected ITTTabPage ETKMDescriptionTabPage;
        protected ITTTextBox ETKMDescription;
        protected ITTTabPage MaterialProcedures;
        protected ITTGrid grdMaterialServiceMatching;
        protected ITTListBoxColumn ProcedureDefinitionMaterialProcedures;
        protected ITTTabPage EquivalentMaterials;
        protected ITTGrid ManuelEquivalentDrugsEquivalentConsMaterial;
        protected ITTListBoxColumn EquivalentMaterialEquivalentConsMaterial;
        protected ITTTextBox Code;
        protected ITTTextBox Name;
        protected ITTTextBox EnglishName;
        protected ITTObjectListBox StockCard;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelStockCard;
        protected ITTLabel labelCode;
        protected ITTCheckBox IsActive;
        protected ITTObjectListBox MaterialTree;
        protected ITTLabel labelMaterialTree;
        protected ITTLabel labelName;
        protected ITTCheckBox Chargable;
        protected ITTCheckBox AllowToGivePatient;
        protected ITTLabel ttlabel3;
        protected ITTCheckBox IsArmyDrug;
        protected ITTObjectListBox DistributionTypeStockCard;
        protected ITTLabel labelDistributionTypeStockCard;
        protected ITTCheckBox DailyStay;
        override protected void InitializeControls()
        {
            labelRelatedRevenueSubAccountRevenueSubAccountCodeDefinition = (ITTLabel)AddControl(new Guid("f42607f9-726e-49e1-ae58-7aebefd0e6c0"));
            RelatedRevenueSubAccountRevenueSubAccountCodeDefinition = (ITTObjectListBox)AddControl(new Guid("71a79e71-3f60-4f8d-a831-b76f7f026dc4"));
            NotShownOnEpicrisisForm = (ITTCheckBox)AddControl(new Guid("a0f934f7-97f8-4221-8314-9e831b249217"));
            IsTagNoRequired = (ITTCheckBox)AddControl(new Guid("a1ac13ee-56aa-4c98-8b9c-5d38ff3624c6"));
            IsIndividualTrackingRequired = (ITTCheckBox)AddControl(new Guid("09f3164e-fd46-47f9-9bcf-8a33fc77b0f6"));
            SendSMS = (ITTCheckBox)AddControl(new Guid("0ffe4923-7604-4951-aed2-74cc20c9a7de"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("546f9bf7-4c4b-4191-be32-d6ee728d71a4"));
            lblSUTAppendix = (ITTLabel)AddControl(new Guid("4b347baa-9d60-4614-b048-1b3f70284b1d"));
            labelMkysMalzemeKodu = (ITTLabel)AddControl(new Guid("64199ce0-7625-468e-a747-bdd289335f45"));
            MkysMalzemeKodu = (ITTTextBox)AddControl(new Guid("78470c6c-a715-4e9f-9d19-06021797f0c7"));
            EstimatedTimeOfCheck = (ITTTextBox)AddControl(new Guid("05c1198c-4b5a-4df6-9bdb-c93c2e0c5298"));
            StorageConditions = (ITTTextBox)AddControl(new Guid("692a3e8c-3479-4f08-81e4-e369eca4a236"));
            Barcode = (ITTTextBox)AddControl(new Guid("f89119b3-cfbe-48c0-aa78-26de3dca35fe"));
            IsPackageExclusive = (ITTCheckBox)AddControl(new Guid("e664c8dc-120b-445e-a8a9-07831efe01cf"));
            labelEstimatedTimeOfCheck = (ITTLabel)AddControl(new Guid("fd76a55c-d015-4590-b710-397b0dafacda"));
            labelStorageConditions = (ITTLabel)AddControl(new Guid("d5d9b791-75e8-4779-8304-38a669abbfda"));
            labelCreationDate = (ITTLabel)AddControl(new Guid("e89248b4-f9c4-4a69-b2fd-56cfc9c732d0"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("3b421371-454b-43b3-b21f-64fc3132b29b"));
            IsRestrictedMaterial = (ITTCheckBox)AddControl(new Guid("d91145ca-5cc6-4948-814f-d20db1586fa8"));
            IsOldMaterial = (ITTCheckBox)AddControl(new Guid("38f104c3-23cf-4317-bea1-6699b2c2c3ca"));
            MaterialSpecialtys = (ITTGrid)AddControl(new Guid("24a14e9f-a0d9-445f-b5c0-2161ba149938"));
            MaterialSpecialtyDefinitionMaterialSpecialty = (ITTListBoxColumn)AddControl(new Guid("4f1ce653-7894-456e-ad58-e94bae2c8484"));
            labelMaterialPurposeDefinition = (ITTLabel)AddControl(new Guid("3e3b6aee-250e-4ed9-abe3-3c7946e4783e"));
            MaterialPurposeDefinition = (ITTObjectListBox)AddControl(new Guid("fcfe35e5-12b9-464e-963a-4da38191790c"));
            labelMaterialPlaceOfUseDef = (ITTLabel)AddControl(new Guid("cd840e69-6c66-4135-aa57-329bde8d995f"));
            MaterialPlaceOfUseDef = (ITTObjectListBox)AddControl(new Guid("64daf5c2-4910-4040-b755-84a2614a2fdd"));
            IsExpendableMaterial = (ITTCheckBox)AddControl(new Guid("84b2de14-e173-43c3-be9e-f474f4516bad"));
            labelBarcode = (ITTLabel)AddControl(new Guid("5e72f096-727c-4247-b077-c090388eb3e6"));
            cmdSendChanging = (ITTButton)AddControl(new Guid("a1d12985-43a0-4494-ae47-0deed1b1253c"));
            cmdChangeTypeToFixedAsset = (ITTButton)AddControl(new Guid("e4697b74-5f23-4614-8028-46f31ee7fa69"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("674592cb-ac50-4b65-80c1-299194892959"));
            ProductionInfoTabPage = (ITTTabPage)AddControl(new Guid("df1e9223-131b-4174-b7c7-220773d817b1"));
            HasEstimatedTimeConsumableMaterialDefinition = (ITTCheckBox)AddControl(new Guid("7f0bfe75-1e3f-4f57-a7a7-30825f8d81d9"));
            CreateInMedulaDontSendState = (ITTCheckBox)AddControl(new Guid("2e83f37a-6390-4e5b-89e3-1ac0ed8e223c"));
            lblMedulaMultiplier = (ITTLabel)AddControl(new Guid("7428f473-9afc-4bfa-aad7-8650ba2f9bd9"));
            labelAuctionDate = (ITTLabel)AddControl(new Guid("d241f5e6-39bd-4ea5-8a66-50247460fb2a"));
            MedulaMultiplier = (ITTTextBox)AddControl(new Guid("a0e4228d-de73-4560-b48b-b7d3700f0a81"));
            labelRegistrationAuctionNo = (ITTLabel)AddControl(new Guid("7d4d78bb-6d09-44cd-a5e4-1bf51bdfe2d7"));
            AuctionDate = (ITTDateTimePicker)AddControl(new Guid("6b44db28-31f1-4d80-a653-beba7e8c3ad5"));
            IsAllogreft = (ITTCheckBox)AddControl(new Guid("9d67589d-dad3-43d1-acdc-f223dc0f1757"));
            RegistrationAuctionNo = (ITTTextBox)AddControl(new Guid("60899670-1608-4ba5-974c-dcb370d9dd6e"));
            labelPurchaseDate = (ITTLabel)AddControl(new Guid("51708fe4-3a28-4760-9427-1de565f0b2d9"));
            PurchaseDate = (ITTDateTimePicker)AddControl(new Guid("3620965e-afe8-405e-9f38-381803484349"));
            labelMaterialPricingType = (ITTLabel)AddControl(new Guid("a464e3af-8d67-42f6-a89e-d1feb0bfe133"));
            MaterialPricingType = (ITTEnumComboBox)AddControl(new Guid("9b773288-d3b7-41f3-87bd-f949236266ba"));
            labelBrans = (ITTLabel)AddControl(new Guid("24f85219-0d54-4ae5-b5ea-08e2396dc795"));
            Brans = (ITTObjectListBox)AddControl(new Guid("33e1feb8-6deb-4a0d-8bcc-87862f822fd6"));
            labelProducer = (ITTLabel)AddControl(new Guid("03a8d08c-da64-44fd-919a-a89d80997ae2"));
            Producer = (ITTObjectListBox)AddControl(new Guid("b1aecadc-6e6a-4ecd-ae51-671c0dd297dd"));
            labelGMDNCodeStockCard = (ITTLabel)AddControl(new Guid("f27bc18e-194b-4e9b-9dc5-f924a7eaa159"));
            GMDNCodeStockCard = (ITTObjectListBox)AddControl(new Guid("4eff9196-64e1-4191-9037-7a1b9002465b"));
            labelPackageAmount = (ITTLabel)AddControl(new Guid("ae338a27-1b86-42c6-be81-1bcb4f64d1bf"));
            PackageAmount = (ITTTextBox)AddControl(new Guid("96b8d012-55a0-485d-b45b-78bc49bc5f05"));
            labelLicencingOrganization = (ITTLabel)AddControl(new Guid("ba3481ce-360a-4bfb-9dd1-e2bdd8fb9032"));
            LicencingOrganization = (ITTEnumComboBox)AddControl(new Guid("a75ca30d-0d71-42cf-851b-698838f4a12d"));
            labelLicenceNO = (ITTLabel)AddControl(new Guid("0a981f53-53d2-4ae3-8fa7-e81cfbc76314"));
            LicenceNO = (ITTTextBox)AddControl(new Guid("286620e7-dc83-4a32-9883-067238af73e2"));
            labelLicenceDate = (ITTLabel)AddControl(new Guid("c9621926-7d7f-4f0d-bd0a-23907c45e752"));
            LicenceDate = (ITTDateTimePicker)AddControl(new Guid("8f1ba4ea-10f9-4da4-a90a-f6ba5d5f4f0c"));
            labelCurrentPrice = (ITTLabel)AddControl(new Guid("5efe2550-cee1-4745-9eda-e96d233107d7"));
            CurrentPrice = (ITTTextBox)AddControl(new Guid("5184bc70-8c1d-4bda-89b9-582b162a83db"));
            labelBarcodeName = (ITTLabel)AddControl(new Guid("2ae67ad6-aa58-467f-8627-a0cbb773a92b"));
            BarcodeName = (ITTTextBox)AddControl(new Guid("7eea4446-7eec-4efb-a647-92c3e7709122"));
            labelProductNumber = (ITTLabel)AddControl(new Guid("89806b93-2153-4254-b0e2-9f0e329608f0"));
            ProductNumber = (ITTTextBox)AddControl(new Guid("e1960a07-ddae-4205-9c84-ead165c8d78a"));
            MaterialVatRateTabPage = (ITTTabPage)AddControl(new Guid("51fe8873-76c5-4dc4-b9de-35c1508cfd53"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("4588a260-f711-4ba7-aa1e-98f0434cc185"));
            MaterialPriceGrid = (ITTGrid)AddControl(new Guid("3ed0cf5f-3ef0-4bcb-8497-75e70c9bc89e"));
            PriceCode = (ITTTextBoxColumn)AddControl(new Guid("20040b32-0a0f-4592-92b2-9a033766cf5a"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("4e9f9e91-9a68-4725-af88-2dcf2c7d9e66"));
            PricingList = (ITTListBoxColumn)AddControl(new Guid("48b491e5-7518-448a-98da-ffefe1a80896"));
            Price = (ITTTextBoxColumn)AddControl(new Guid("611bbd8b-943b-4454-93e5-eef3e7b2fabf"));
            CurrencyType = (ITTListBoxColumn)AddControl(new Guid("2e9ad8d0-d6c7-4e20-8253-ef900f82c251"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("5b4b19de-ea58-44b5-8120-a0e3d99a57bb"));
            MaterialVatRates = (ITTGrid)AddControl(new Guid("20da8dfe-a3e0-44b0-998e-9f2d8216490b"));
            VatRate = (ITTTextBoxColumn)AddControl(new Guid("94d853f0-77a1-4b92-a698-668906b60216"));
            StartDate = (ITTDateTimePickerColumn)AddControl(new Guid("26f2fc17-5396-4d32-bb0d-f08fac90c5da"));
            EndDate = (ITTDateTimePickerColumn)AddControl(new Guid("b8214091-c6f3-4a4c-a236-cbb598de84ad"));
            PictureTabPage = (ITTTabPage)AddControl(new Guid("061c157b-10bb-4ae7-9940-9733b29477f7"));
            MaterialPicture = (ITTPictureBoxControl)AddControl(new Guid("a598e932-11ba-4232-a40a-e7ec7715aee6"));
            ProductLevelTabPage = (ITTTabPage)AddControl(new Guid("6c1ee193-d06f-46fd-9857-97fe77edec31"));
            MaterialProductLevels = (ITTGrid)AddControl(new Guid("200a9ccc-090c-4962-b740-90dd5e69c2d8"));
            ProductMaterialProductLevel = (ITTListBoxColumn)AddControl(new Guid("5839f24e-832c-4593-84fe-5884a97b7246"));
            ETKMDescriptionTabPage = (ITTTabPage)AddControl(new Guid("b8837d0b-d1e7-46cb-9b72-ffabed451872"));
            ETKMDescription = (ITTTextBox)AddControl(new Guid("03bc3b70-3164-469c-a499-0c45e792c2aa"));
            MaterialProcedures = (ITTTabPage)AddControl(new Guid("b4a2787f-bd35-4013-9965-b11c43c0d09c"));
            grdMaterialServiceMatching = (ITTGrid)AddControl(new Guid("14f26e81-d225-46ab-9e7b-0d7b125af172"));
            ProcedureDefinitionMaterialProcedures = (ITTListBoxColumn)AddControl(new Guid("190adc48-f728-4857-b850-1b0257ae581f"));
            EquivalentMaterials = (ITTTabPage)AddControl(new Guid("bf42d8df-125e-473b-b31a-9601fd8cece3"));
            ManuelEquivalentDrugsEquivalentConsMaterial = (ITTGrid)AddControl(new Guid("55892ca1-5d17-4e40-8dd1-e93bb8c7c9f2"));
            EquivalentMaterialEquivalentConsMaterial = (ITTListBoxColumn)AddControl(new Guid("6a72ab49-0509-4766-9943-f84650ff38b5"));
            Code = (ITTTextBox)AddControl(new Guid("5f26a825-e609-4f9e-b975-69720065af2a"));
            Name = (ITTTextBox)AddControl(new Guid("0876ddd8-6175-4ec7-92a0-cd0592269414"));
            EnglishName = (ITTTextBox)AddControl(new Guid("09d9e430-0152-4a47-94b2-f995293c104e"));
            StockCard = (ITTObjectListBox)AddControl(new Guid("24bd65ac-8fc1-48b8-954b-3e8ef12da631"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("38f8a5b9-f830-41f4-9b8b-72aea83cf1df"));
            labelStockCard = (ITTLabel)AddControl(new Guid("131d9002-d335-47b1-86be-996d3fe9b4b6"));
            labelCode = (ITTLabel)AddControl(new Guid("3c931255-8597-45ee-be76-af173e36047f"));
            IsActive = (ITTCheckBox)AddControl(new Guid("7cbe3836-bf56-4ff9-9357-affbf5478842"));
            MaterialTree = (ITTObjectListBox)AddControl(new Guid("f1d44633-1736-40c5-9e4f-d6c0e63e17b3"));
            labelMaterialTree = (ITTLabel)AddControl(new Guid("f92acd0b-7c3d-43f4-a244-e486803129aa"));
            labelName = (ITTLabel)AddControl(new Guid("c06151ee-577a-473a-a4f6-e67e595687a1"));
            Chargable = (ITTCheckBox)AddControl(new Guid("a157a538-3336-466b-9db3-9143502e9ca4"));
            AllowToGivePatient = (ITTCheckBox)AddControl(new Guid("1f1eb40a-39f5-4939-9dbd-e5a78151365a"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("c5974cda-1172-4f28-863c-8287796bafd2"));
            IsArmyDrug = (ITTCheckBox)AddControl(new Guid("788e2742-43c2-4c7c-be81-71a841631e74"));
            DistributionTypeStockCard = (ITTObjectListBox)AddControl(new Guid("2a8cd5ad-b629-42ac-9b78-56cfc4ac3fc4"));
            labelDistributionTypeStockCard = (ITTLabel)AddControl(new Guid("5f34c8f8-6b06-4aa6-b120-94509d5a482a"));
            DailyStay = (ITTCheckBox)AddControl(new Guid("4e82a7ec-febc-4b80-a298-b8f55f1a3a15"));
            base.InitializeControls();
        }

        public ConsumableMaterialDefinitionForm() : base("CONSUMABLEMATERIALDEFINITION", "ConsumableMaterialDefinitionForm")
        {
        }

        protected ConsumableMaterialDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}