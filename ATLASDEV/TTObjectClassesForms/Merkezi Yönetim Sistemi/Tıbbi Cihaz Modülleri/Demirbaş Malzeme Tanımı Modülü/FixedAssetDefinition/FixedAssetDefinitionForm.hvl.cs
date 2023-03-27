
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
    /// Demirbaş Malzeme Tanımı
    /// </summary>
    public partial class FixedAssetDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Demirbaş Malzeme Bilgileri
    /// </summary>
        protected TTObjectClasses.FixedAssetDefinition _FixedAssetDefinition
        {
            get { return (TTObjectClasses.FixedAssetDefinition)_ttObject; }
        }

        protected ITTLabel labelCreationDate;
        protected ITTDateTimePicker CreationDate;
        protected ITTCheckBox IsOldMaterial;
        protected ITTCheckBox NeedMaintenance;
        protected ITTLabel labelBarcode;
        protected ITTTextBox Barcode;
        protected ITTTextBox EnglishName;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage UserLevelParametersTabPage;
        protected ITTGrid UserLevelMaintParameters;
        protected ITTListBoxColumn UserParameter;
        protected ITTTabPage UnitLevelParametersTabPage;
        protected ITTGrid UnitLevelMaintParameters;
        protected ITTListBoxColumn UnitParameter;
        protected ITTTabPage CalibrationTestTabPage;
        protected ITTGrid CalibrationProcedures;
        protected ITTListBoxColumn CalibrationTestDefinition;
        protected ITTTabPage VatRateTabPage;
        protected ITTGrid MaterialVatRates;
        protected ITTTextBoxColumn VatRate;
        protected ITTDateTimePickerColumn StartDate;
        protected ITTDateTimePickerColumn EndDate;
        protected ITTTabPage ProductionDetailsTabPage;
        protected ITTLabel labelBrans;
        protected ITTObjectListBox Brans;
        protected ITTLabel labelMaterialPricingType;
        protected ITTEnumComboBox MaterialPricingType;
        protected ITTLabel labelProductNumber;
        protected ITTTextBox ProductNumber;
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
        protected ITTTabPage ProductLevelTabPage;
        protected ITTGrid MaterialProductLevels;
        protected ITTListBoxColumn ProductMaterialProductLevel;
        protected ITTTabPage PictureTabPage;
        protected ITTPictureBoxControl MaterialPicture;
        protected ITTTabPage ETKMDescriptionTabPage;
        protected ITTTextBox ETKMDescription;
        protected ITTTextBox Description;
        protected ITTTextBox Code;
        protected ITTTextBox Name;
        protected ITTCheckBox isCalibrator;
        protected ITTCheckBox NeedCalibration;
        protected ITTLabel labelMaterialTree;
        protected ITTObjectListBox StockCard;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        protected ITTTextBox tttextbox2;
        protected ITTObjectListBox MaterialTree;
        protected ITTLabel labelEnglishName;
        protected ITTLabel labelDescription;
        protected ITTLabel labelStockCard;
        protected ITTGroupBox ttgroupbox2;
        protected ITTTextBox CalibrationTime;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel5;
        protected ITTTextBox CalibrationPeriod;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel6;
        protected ITTLabel labelCode;
        protected ITTLabel labelName;
        protected ITTButton cmdChangeTypeToConsumable;
        protected ITTCheckBox isAnimal;
        protected ITTButton cmdSendChanging;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            labelCreationDate = (ITTLabel)AddControl(new Guid("b4ae5861-2132-4276-9ddc-e7105bb95f34"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("e439e595-f677-46af-bec3-01187d9e1e94"));
            IsOldMaterial = (ITTCheckBox)AddControl(new Guid("c6c2b63b-fe87-48a6-a38a-1360ab2f9017"));
            NeedMaintenance = (ITTCheckBox)AddControl(new Guid("8ad96d6a-5afa-45d2-89e2-426fdbcff274"));
            labelBarcode = (ITTLabel)AddControl(new Guid("94d87089-4760-4265-a1a3-fbe1dbd5ce0f"));
            Barcode = (ITTTextBox)AddControl(new Guid("b9b9928e-9fe0-4f60-9412-191e3d27211f"));
            EnglishName = (ITTTextBox)AddControl(new Guid("23fb1476-0a72-4389-91d6-ecb08a050712"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("460f0789-52c3-46bb-a6e7-5678c6339c70"));
            UserLevelParametersTabPage = (ITTTabPage)AddControl(new Guid("f4c4d5d2-a3a5-459b-8b80-5acc9aac42cb"));
            UserLevelMaintParameters = (ITTGrid)AddControl(new Guid("4e9f7c8a-f1e4-4e37-9365-bef60f004aec"));
            UserParameter = (ITTListBoxColumn)AddControl(new Guid("d3596669-5834-4890-9ff8-62a549fe37cb"));
            UnitLevelParametersTabPage = (ITTTabPage)AddControl(new Guid("f3575004-b1ab-4f8e-a7c9-4ce84660a4b4"));
            UnitLevelMaintParameters = (ITTGrid)AddControl(new Guid("6d421556-e429-4e39-b3b8-9be06d02ec96"));
            UnitParameter = (ITTListBoxColumn)AddControl(new Guid("e1217006-98ef-4877-8b2c-2bd09ddc54e4"));
            CalibrationTestTabPage = (ITTTabPage)AddControl(new Guid("a338efcb-b2dd-4376-8093-1f3eadba0de3"));
            CalibrationProcedures = (ITTGrid)AddControl(new Guid("2fd29cb3-2189-41a3-9311-19d34eab00e9"));
            CalibrationTestDefinition = (ITTListBoxColumn)AddControl(new Guid("d193e003-acf8-478f-b675-649142fcb3ee"));
            VatRateTabPage = (ITTTabPage)AddControl(new Guid("f07e200e-68bd-456c-a643-585f684b6d87"));
            MaterialVatRates = (ITTGrid)AddControl(new Guid("15006d8b-17a9-455a-b6ac-5f9650714d10"));
            VatRate = (ITTTextBoxColumn)AddControl(new Guid("801ef160-3e6b-4a44-b768-5656b3507501"));
            StartDate = (ITTDateTimePickerColumn)AddControl(new Guid("35e57b7e-fb2e-4078-9ca7-4cd6ad19f0ef"));
            EndDate = (ITTDateTimePickerColumn)AddControl(new Guid("2929a96c-79f7-446d-91ac-04ce21bea148"));
            ProductionDetailsTabPage = (ITTTabPage)AddControl(new Guid("290b82ce-815f-4bee-b2f8-044c7e5b5a5c"));
            labelBrans = (ITTLabel)AddControl(new Guid("91c6adf6-c3b7-4755-a384-592205bac66b"));
            Brans = (ITTObjectListBox)AddControl(new Guid("3d0fefae-3a43-4746-88b5-cfabb150e594"));
            labelMaterialPricingType = (ITTLabel)AddControl(new Guid("3887e144-da4d-4493-bfd7-eeaf4d84c6b9"));
            MaterialPricingType = (ITTEnumComboBox)AddControl(new Guid("1bcbcae1-eeec-491b-83ca-a7519250e7b4"));
            labelProductNumber = (ITTLabel)AddControl(new Guid("d78d2b19-4434-4463-813f-e06eb4f13bdb"));
            ProductNumber = (ITTTextBox)AddControl(new Guid("a174079d-551d-4e20-8074-66a361f17527"));
            labelProducer = (ITTLabel)AddControl(new Guid("8fecef83-4368-45d6-8442-454de06761cc"));
            Producer = (ITTObjectListBox)AddControl(new Guid("5eb542e1-1922-4059-93ff-05a4d52ddc3d"));
            labelGMDNCodeStockCard = (ITTLabel)AddControl(new Guid("6d50576d-37dd-48eb-9898-720f43450f4c"));
            GMDNCodeStockCard = (ITTObjectListBox)AddControl(new Guid("858c8abc-9931-46f1-898e-fd878275ca0b"));
            labelPackageAmount = (ITTLabel)AddControl(new Guid("d571036a-092f-4401-8cd8-3acde6e7ae34"));
            PackageAmount = (ITTTextBox)AddControl(new Guid("133f9916-c27b-49e6-a0ab-09556cc52d29"));
            labelLicencingOrganization = (ITTLabel)AddControl(new Guid("4e7eb166-dd90-4663-9294-9084ae0f09da"));
            LicencingOrganization = (ITTEnumComboBox)AddControl(new Guid("7092c552-cd55-45a2-be38-2d08d29b84cd"));
            labelLicenceNO = (ITTLabel)AddControl(new Guid("598f5c88-d1af-4bd8-93ad-c37273e7bff3"));
            LicenceNO = (ITTTextBox)AddControl(new Guid("f1f1ce28-218b-498d-a4fb-653c77afe7d1"));
            labelLicenceDate = (ITTLabel)AddControl(new Guid("6453bc43-4706-46a8-9137-e25dcf69146d"));
            LicenceDate = (ITTDateTimePicker)AddControl(new Guid("dd14afc6-da44-4e98-8a88-24f58e60fb38"));
            labelCurrentPrice = (ITTLabel)AddControl(new Guid("486a57b1-8ab8-4bc4-aedf-f1969ce30277"));
            CurrentPrice = (ITTTextBox)AddControl(new Guid("9f4c2f78-c275-4d2c-8d55-eb5f74defddd"));
            labelBarcodeName = (ITTLabel)AddControl(new Guid("8cbb6e4b-245c-4fd3-bb2a-2a4b3eb659dd"));
            BarcodeName = (ITTTextBox)AddControl(new Guid("9d03291d-0f1a-4b4f-964b-cf9eae85fe93"));
            ProductLevelTabPage = (ITTTabPage)AddControl(new Guid("a962ee93-42e6-43d7-967e-a7bbaf9167c1"));
            MaterialProductLevels = (ITTGrid)AddControl(new Guid("2633a249-1158-4c89-bc47-f0443b5c270a"));
            ProductMaterialProductLevel = (ITTListBoxColumn)AddControl(new Guid("2a96a16c-aa96-4fff-8712-02dd826442e4"));
            PictureTabPage = (ITTTabPage)AddControl(new Guid("3e1d357a-da20-4042-800c-570379754fde"));
            MaterialPicture = (ITTPictureBoxControl)AddControl(new Guid("1181d02f-4896-471c-b8ef-3add7da34c55"));
            ETKMDescriptionTabPage = (ITTTabPage)AddControl(new Guid("2ccafb2a-8b0c-4734-976a-f0c7785cda15"));
            ETKMDescription = (ITTTextBox)AddControl(new Guid("44b1e836-b914-4450-9252-3a08da2ea01e"));
            Description = (ITTTextBox)AddControl(new Guid("64922475-c264-4742-b6ed-174a7fd9ebcd"));
            Code = (ITTTextBox)AddControl(new Guid("a570d288-2b73-44af-a529-adcad9a200b9"));
            Name = (ITTTextBox)AddControl(new Guid("19f2aadf-9706-4367-9145-c598194890dd"));
            isCalibrator = (ITTCheckBox)AddControl(new Guid("c82d6821-39b1-41ec-bfdb-ef66b4c36107"));
            NeedCalibration = (ITTCheckBox)AddControl(new Guid("cfa99b13-c3d9-4b7b-b7f1-49972682839d"));
            labelMaterialTree = (ITTLabel)AddControl(new Guid("1c30c305-702a-4930-a81b-0024c8ffb08b"));
            StockCard = (ITTObjectListBox)AddControl(new Guid("9ad75c13-ccf5-474c-96b0-0810214fa14c"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("1afd1b58-3fae-42c0-90dc-095c45539077"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("49b19378-301e-4763-ab2d-35b5097aaa4a"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ac8bf69d-b49d-43e7-bc9d-7f41ded611c8"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8f531394-21fd-42c2-bd98-975076850760"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("94839cf1-8896-4499-bbc6-e58041e306d7"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("33d3c55b-6a0a-4a81-8876-e6c7e56e7af6"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("8f55b581-3b3f-4c5a-89f5-045ac6bd6278"));
            MaterialTree = (ITTObjectListBox)AddControl(new Guid("0ce9d17f-3ed7-46c1-a626-2a965c4712fc"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("4cb8e417-8c40-48ae-bc3c-471776e64c25"));
            labelDescription = (ITTLabel)AddControl(new Guid("50507ba7-9f28-4edc-a18a-4cddd91315f2"));
            labelStockCard = (ITTLabel)AddControl(new Guid("4879b614-ba80-4780-86cd-80c43d3b780d"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("61f66306-5017-44ad-ba23-9ff3e0da3b47"));
            CalibrationTime = (ITTTextBox)AddControl(new Guid("407a8bc2-38dd-49a6-90f4-b72341a5147d"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("0b384d18-6120-4912-9e1b-36e3efbe296b"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("a814c311-1334-4ed1-af9d-45cf4120915a"));
            CalibrationPeriod = (ITTTextBox)AddControl(new Guid("b378556b-e632-45d2-81fc-4671ae90d262"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("a61611e2-f748-4d75-8bd2-971dee8590c9"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("3a0e86c1-2fea-45d0-ac82-995d46cc0fc4"));
            labelCode = (ITTLabel)AddControl(new Guid("43495801-fb52-43a6-8ebc-a36ab1de08f2"));
            labelName = (ITTLabel)AddControl(new Guid("a3dd2c50-173b-4a68-a440-caa858d0c3e2"));
            cmdChangeTypeToConsumable = (ITTButton)AddControl(new Guid("eb70b73b-385c-47a0-b09a-420599797d9d"));
            isAnimal = (ITTCheckBox)AddControl(new Guid("d3ec0f4b-ebf0-455d-b423-2f74f30f6707"));
            cmdSendChanging = (ITTButton)AddControl(new Guid("32774563-777d-4a04-9379-79ba98ef1c95"));
            IsActive = (ITTCheckBox)AddControl(new Guid("802b2c0d-cbb9-4134-bc6a-3553a48c0dc6"));
            base.InitializeControls();
        }

        public FixedAssetDefinitionForm() : base("FIXEDASSETDEFINITION", "FixedAssetDefinitionForm")
        {
        }

        protected FixedAssetDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}