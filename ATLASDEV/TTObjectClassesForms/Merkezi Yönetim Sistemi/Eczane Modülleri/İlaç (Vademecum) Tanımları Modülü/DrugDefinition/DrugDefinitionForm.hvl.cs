
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
    /// İlaç Tanımı
    /// </summary>
    public partial class DrugDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// İlaç Tanımı
    /// </summary>
        protected TTObjectClasses.DrugDefinition _DrugDefinition
        {
            get { return (TTObjectClasses.DrugDefinition)_ttObject; }
        }

        protected ITTLabel labelRelatedRevenueSubAccountRevenueSubAccountCodeDefinition;
        protected ITTObjectListBox RelatedRevenueSubAccountRevenueSubAccountCodeDefinition;
        protected ITTCheckBox IsITSDrug;
        protected ITTCheckBox SendSMS;
        protected ITTLabel labelColor;
        protected ITTEnumComboBox Color;
        protected ITTLabel labelDrugNutrientInteraction;
        protected ITTTextBox DrugNutrientInteraction;
        protected ITTTextBox MkysMalzemeKodu;
        protected ITTTextBox EstimatedTimeOfCheck;
        protected ITTTextBox StorageConditions;
        protected ITTTextBox Barcode;
        protected ITTTextBox Name;
        protected ITTTextBox OriginalName;
        protected ITTCheckBox SgkReturnPay;
        protected ITTCheckBox IsNarcotic;
        protected ITTCheckBox IsPsychotropic;
        protected ITTLabel labelMkysMalzemeKodu;
        protected ITTLabel labelEstimatedTimeOfCheck;
        protected ITTLabel labelStorageConditions;
        protected ITTCheckBox SosFarmaCheckBox;
        protected ITTLabel labelDistributionTypeStockCard;
        protected ITTObjectListBox DistributionTypeStockCard;
        protected ITTLabel labelCreationDate;
        protected ITTDateTimePicker CreationDate;
        protected ITTCheckBox PatientSafetyFrom;
        protected ITTButton cmdChangeTypeToConsumableButton;
        protected ITTCheckBox IsOldMaterial;
        protected ITTLabel labelEtkinMadde;
        protected ITTObjectListBox EtkinMadde;
        protected ITTCheckBox IsExpendableMaterial;
        protected ITTLabel labelBarcode;
        protected ITTCheckBox WithOutStockInheld;
        protected ITTLabel labelMaterialTree;
        protected ITTLabel labelStockCard;
        protected ITTLabel labelCode;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelEnglishName;
        protected ITTLabel labelName;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage PropertyTabPage;
        protected ITTLabel labelOrderRPTDay;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTTextBox OrderRPTDay;
        protected ITTGroupBox ttgroupbox1;
        protected ITTCheckBox SpecialistApproval;
        protected ITTCheckBox SpecialistDoctorApproval;
        protected ITTLabel labelGenericDrug;
        protected ITTEnumComboBox PrescriptionType;
        protected ITTLabel labelPrescriptionType;
        protected ITTLabel labelVolumeUnit;
        protected ITTTextBox Volume;
        protected ITTLabel labelNFC;
        protected ITTGroupBox ttgroupbox2;
        protected ITTLabel labelRoutineDay;
        protected ITTLabel labelFrequency;
        protected ITTTextBox RoutineDay;
        protected ITTTextBox RoutineDose;
        protected ITTLabel labelRoutineDose;
        protected ITTEnumComboBox Frequency;
        protected ITTGrid DrugATCs;
        protected ITTListBoxColumn ATC;
        protected ITTTextBox MaxDoseDay;
        protected ITTLabel labelMaxDoseDay;
        protected ITTLabel labelVolume;
        protected ITTTextBox Dose;
        protected ITTObjectListBox VolumeUnit;
        protected ITTObjectListBox RouteOfAdmin;
        protected ITTLabel labelRouteOfAdmin;
        protected ITTLabel labelDose;
        protected ITTObjectListBox GenericDrug;
        protected ITTObjectListBox NFC;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel3;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTTabPage FormuleTabPage;
        protected ITTGrid DrugActiveIngredients;
        protected ITTListBoxColumn ActiveIngredient;
        protected ITTListBoxColumn Unit;
        protected ITTTextBoxColumn Value;
        protected ITTTextBoxColumn FormulaMaxDose;
        protected ITTListBoxColumn MaxDoseUnit;
        protected ITTCheckBoxColumn IsParentIngredient;
        protected ITTTabPage ProductionTabPage;
        protected ITTLabel labelOutpatientReportType;
        protected ITTEnumComboBox OutpatientReportType;
        protected ITTLabel labelInpatientReportType;
        protected ITTEnumComboBox InpatientReportType;
        protected ITTGroupBox gbxAmountPrice;
        protected ITTTextBox txtTestAmount;
        protected ITTButton btnCalculate;
        protected ITTTextBox txtAmountMultiplier;
        protected ITTTextBox txtUnitPriceDivider;
        protected ITTLabel lblTestAmount;
        protected ITTLabel lblAmountMultiplier;
        protected ITTLabel lblUnitPriceDivider;
        protected ITTCheckBox SetMedulaInfoByMultiplier;
        protected ITTCheckBox CreateInMedulaDontSendState;
        protected ITTCheckBox DividePriceToVolume;
        protected ITTLabel lblMedulaMultiplier;
        protected ITTButton searchMedicineFromMedula;
        protected ITTTextBox MedulaMultiplier;
        protected ITTLabel labelPurchaseDate;
        protected ITTDateTimePicker PurchaseDate;
        protected ITTLabel labelBrans;
        protected ITTCheckBox ReimbursementUnder;
        protected ITTObjectListBox Brans;
        protected ITTLabel labelMaterialPricingType;
        protected ITTEnumComboBox MaterialPricingType;
        protected ITTLabel labelProducer;
        protected ITTObjectListBox Producer;
        protected ITTLabel labelProductNumber;
        protected ITTTextBox ProductNumber;
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
        protected ITTTabPage KDVTabPage;
        protected ITTLabel labelInstitutionDiscountRate;
        protected ITTTextBox InstitutionDiscountRate;
        protected ITTLabel labelPharmacistDiscountRate;
        protected ITTTextBox PharmacistDiscountRate;
        protected ITTGrid MaterialVatRates;
        protected ITTTextBoxColumn VatRate;
        protected ITTDateTimePickerColumn StartDate;
        protected ITTDateTimePickerColumn EndDate;
        protected ITTGrid MaterialPriceGrid;
        protected ITTTextBoxColumn PriceCode;
        protected ITTTextBoxColumn PriceDesc;
        protected ITTListBoxColumn PricingList;
        protected ITTTextBoxColumn Price;
        protected ITTListBoxColumn CurrencyType;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTTabPage DescriptionTabPage;
        protected ITTTextBox Description;
        protected ITTTabPage EquivalentTabPage;
        protected ITTGrid EquivalentsGrid;
        protected ITTTextBoxColumn EquivalentDrugName;
        protected ITTTabPage Ek2EquivalentTabPage;
        protected ITTGrid DrugRelations;
        protected ITTListBoxColumn RelationDrugDrugRelation;
        protected ITTTabPage ManuelEquivalentTabPage;
        protected ITTButton cmdAddEquiv;
        protected ITTGrid ManuelEquivalentDrugs;
        protected ITTListBoxColumn EquivalentDrugManuelEquivDrug;
        protected ITTTabPage ETKMDescriptionTabPage;
        protected ITTTextBox ETKMDescription;
        protected ITTTabPage DrugLabIntTabPage;
        protected ITTGrid DrugLabProcInteractions;
        protected ITTListBoxColumn LaboratoryTestDefinitionDrugLabProcInteraction;
        protected ITTTextBoxColumn MinValueDrugLabProcInteraction;
        protected ITTTextBoxColumn MaxValueDrugLabProcInteraction;
        protected ITTTextBoxColumn MessageDrugLabProcInteraction;
        protected ITTTabPage DrugSpecifications;
        protected ITTGrid grdDrugSpecification;
        protected ITTEnumComboBoxColumn DrugSpecification;
        protected ITTTabPage MaterialProcedure;
        protected ITTGrid grdMaterialProcedures;
        protected ITTListBoxColumn ProcedureDefinitionMaterialProcedures;
        protected ITTTextBox Code;
        protected ITTObjectListBox StockCard;
        protected ITTObjectListBox MaterialTree;
        protected ITTCheckBox Chargable;
        protected ITTCheckBox AllowToGivePatient;
        protected ITTCheckBox IsArmyDrug;
        protected ITTCheckBox IsPackageExclusive;
        protected ITTCheckBox ttcheckbox1;
        protected ITTCheckBox ttcheckbox2;
        protected ITTEnumComboBox ttenumcombobox2;
        protected ITTLabel ttlabel6;
        protected ITTEnumComboBox AntibioticType;
        protected ITTLabel ttlabel7;
        protected ITTCheckBox DailyStay;
        override protected void InitializeControls()
        {
            labelRelatedRevenueSubAccountRevenueSubAccountCodeDefinition = (ITTLabel)AddControl(new Guid("72d3d38f-97a7-43dc-9d28-8139cd2c7aae"));
            RelatedRevenueSubAccountRevenueSubAccountCodeDefinition = (ITTObjectListBox)AddControl(new Guid("0684eae1-5a94-493b-9772-8b01064192ec"));
            IsITSDrug = (ITTCheckBox)AddControl(new Guid("263a8f1e-98fe-4c64-91fa-bc236a4a61e6"));
            SendSMS = (ITTCheckBox)AddControl(new Guid("01f6d822-9c9f-4be3-8757-530aea8f7823"));
            labelColor = (ITTLabel)AddControl(new Guid("e2f46a81-91b0-48b9-8f7c-7fc03cd775a9"));
            Color = (ITTEnumComboBox)AddControl(new Guid("d2a47c35-bfe4-4c2a-8220-8aead0c92541"));
            labelDrugNutrientInteraction = (ITTLabel)AddControl(new Guid("8b648abe-0dd4-4632-b8b0-a181e3ea37d9"));
            DrugNutrientInteraction = (ITTTextBox)AddControl(new Guid("4062c320-0424-46fc-b1a9-2733219c3ac3"));
            MkysMalzemeKodu = (ITTTextBox)AddControl(new Guid("7d9e975c-8e8b-4e05-a254-3eb6153769c6"));
            EstimatedTimeOfCheck = (ITTTextBox)AddControl(new Guid("506b0c46-2028-4377-9cef-fe2323e1ea11"));
            StorageConditions = (ITTTextBox)AddControl(new Guid("ebbcfeb9-f9a0-48c8-a193-684f414bc05b"));
            Barcode = (ITTTextBox)AddControl(new Guid("3452d063-48b6-41eb-ada8-41f5f802639b"));
            Name = (ITTTextBox)AddControl(new Guid("497c982b-88d4-4fbe-ac3c-55d006917781"));
            OriginalName = (ITTTextBox)AddControl(new Guid("3103a569-d017-43c3-bedd-6207d2aa6b7d"));
            SgkReturnPay = (ITTCheckBox)AddControl(new Guid("e89e6e74-10f9-4e05-8d6a-99df39cadf6c"));
            IsNarcotic = (ITTCheckBox)AddControl(new Guid("abdfd5de-b3a2-488e-8082-5e062098dea9"));
            IsPsychotropic = (ITTCheckBox)AddControl(new Guid("fda55773-6408-49c4-86c5-2e7817f1c696"));
            labelMkysMalzemeKodu = (ITTLabel)AddControl(new Guid("a4737561-7a28-4407-ad8a-427ad9e1a9f0"));
            labelEstimatedTimeOfCheck = (ITTLabel)AddControl(new Guid("4fcbc313-be0b-4edf-8ca6-e2463fb615bf"));
            labelStorageConditions = (ITTLabel)AddControl(new Guid("1714e8ed-2953-49a4-8c3e-6cc0656ed577"));
            SosFarmaCheckBox = (ITTCheckBox)AddControl(new Guid("25fdc2ed-5c3e-468e-9254-ff039d8b599c"));
            labelDistributionTypeStockCard = (ITTLabel)AddControl(new Guid("609ab22a-a50b-4f20-bf11-64c9a4470d61"));
            DistributionTypeStockCard = (ITTObjectListBox)AddControl(new Guid("46616d5f-6e82-4353-91c2-9b73f0454aee"));
            labelCreationDate = (ITTLabel)AddControl(new Guid("d3600bd3-48bc-4283-bcbd-7c030e0009e9"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("82aeef1f-00a6-4ec6-b8a0-8108dbcbd1b2"));
            PatientSafetyFrom = (ITTCheckBox)AddControl(new Guid("768492ea-b8c4-4388-ac5e-cf9d3a18fa4c"));
            cmdChangeTypeToConsumableButton = (ITTButton)AddControl(new Guid("88fed14e-2c88-4937-ac74-b96477eb5029"));
            IsOldMaterial = (ITTCheckBox)AddControl(new Guid("632329da-f076-43eb-a152-e49872b97540"));
            labelEtkinMadde = (ITTLabel)AddControl(new Guid("d88a5f16-0cb3-4ab3-97d7-99730d35e666"));
            EtkinMadde = (ITTObjectListBox)AddControl(new Guid("f6bc827b-8a17-47a8-9fd0-24310a0827e4"));
            IsExpendableMaterial = (ITTCheckBox)AddControl(new Guid("49e5424d-4aa4-4105-b39e-7c5127b0b996"));
            labelBarcode = (ITTLabel)AddControl(new Guid("64df5a7f-d206-4773-953e-4a90e1dc8bcb"));
            WithOutStockInheld = (ITTCheckBox)AddControl(new Guid("a3304366-d6e8-456d-89a6-9a1de7fe8003"));
            labelMaterialTree = (ITTLabel)AddControl(new Guid("1f65258a-78ee-4114-b975-01fb16f19cb0"));
            labelStockCard = (ITTLabel)AddControl(new Guid("46e6b8d3-c119-4a2f-8daa-2b8d8d3666fe"));
            labelCode = (ITTLabel)AddControl(new Guid("3f152a28-633a-4e80-8949-6a2c3862d3db"));
            IsActive = (ITTCheckBox)AddControl(new Guid("67e3c855-a717-44e2-99b7-7c63b9dad833"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("b3f9b81f-da60-41ae-a549-88ecdd66f093"));
            labelName = (ITTLabel)AddControl(new Guid("f890bfce-6324-430b-9c70-99870c6ee858"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("fe90c5e7-eb60-4621-af5d-9db10f67a86d"));
            PropertyTabPage = (ITTTabPage)AddControl(new Guid("8e224765-e9c0-45b6-8fa0-00c8d4874755"));
            labelOrderRPTDay = (ITTLabel)AddControl(new Guid("7a5dfa75-3407-4cf4-8da9-3ed0e4b17b16"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("a95c0f8a-2f8e-4cf4-983f-89d6a1b1388a"));
            OrderRPTDay = (ITTTextBox)AddControl(new Guid("4bd8ce2f-4ffa-45fa-a3c1-fd1b62d9c4e1"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("bcb8cae5-9c2d-490f-a029-719d605851f4"));
            SpecialistApproval = (ITTCheckBox)AddControl(new Guid("ff045013-4ccd-46a7-a8dc-1bd7efca6cee"));
            SpecialistDoctorApproval = (ITTCheckBox)AddControl(new Guid("8dddc1d6-702f-4337-9ad3-aa209f1485bc"));
            labelGenericDrug = (ITTLabel)AddControl(new Guid("12acabff-ea5d-4929-9cd3-0904312b7859"));
            PrescriptionType = (ITTEnumComboBox)AddControl(new Guid("c49d4f21-364c-48cb-8c62-097a1779e0c3"));
            labelPrescriptionType = (ITTLabel)AddControl(new Guid("39e4b5d3-88ca-41ef-aa35-280219a412da"));
            labelVolumeUnit = (ITTLabel)AddControl(new Guid("e06b2a63-9c0c-4556-ae33-284351aab750"));
            Volume = (ITTTextBox)AddControl(new Guid("e539014f-1837-4a91-9edd-40920d39baa2"));
            labelNFC = (ITTLabel)AddControl(new Guid("8be65e23-8d02-4771-8b98-592ff992ae87"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("e18f4c41-b14b-424e-9c14-6005e074894f"));
            labelRoutineDay = (ITTLabel)AddControl(new Guid("ce9ee12d-d32a-42dd-bf12-77f42555e095"));
            labelFrequency = (ITTLabel)AddControl(new Guid("6dbc0731-f62a-44bf-bdb5-a6adbf179ad1"));
            RoutineDay = (ITTTextBox)AddControl(new Guid("2dda25d7-3aa5-472e-a2f5-cb6d44185d7a"));
            RoutineDose = (ITTTextBox)AddControl(new Guid("d6242a40-29e2-4620-b68e-da96f3ddd5dc"));
            labelRoutineDose = (ITTLabel)AddControl(new Guid("c83af2d4-2742-4b5d-88ff-0807e01198e6"));
            Frequency = (ITTEnumComboBox)AddControl(new Guid("fa1fe8bc-08eb-418b-940d-0dc1a9d88b88"));
            DrugATCs = (ITTGrid)AddControl(new Guid("06d98a84-a416-4763-88b3-67e0ef8d790d"));
            ATC = (ITTListBoxColumn)AddControl(new Guid("2e8c01f6-9644-4812-886d-886dcb4f3b38"));
            MaxDoseDay = (ITTTextBox)AddControl(new Guid("d124d9c0-fb1a-438a-a2c3-76d7af412442"));
            labelMaxDoseDay = (ITTLabel)AddControl(new Guid("ef149b65-42f2-4ceb-b94c-79d150d46da8"));
            labelVolume = (ITTLabel)AddControl(new Guid("df58ee89-5cb1-44cf-a0fe-8d012f2ebf98"));
            Dose = (ITTTextBox)AddControl(new Guid("458dc362-3fe8-431d-af08-b0ac0cbceb38"));
            VolumeUnit = (ITTObjectListBox)AddControl(new Guid("e6887440-4d4d-46b4-bd44-c78fa1f1543e"));
            RouteOfAdmin = (ITTObjectListBox)AddControl(new Guid("b8c66fe1-5679-4e98-a754-c8d480e17d35"));
            labelRouteOfAdmin = (ITTLabel)AddControl(new Guid("22480a6a-cce5-43fc-bb34-d5d57676b6ac"));
            labelDose = (ITTLabel)AddControl(new Guid("efc228b5-746f-44af-bcd4-d821f8480c13"));
            GenericDrug = (ITTObjectListBox)AddControl(new Guid("1800fdec-8e1a-4692-b950-dc31412488d1"));
            NFC = (ITTObjectListBox)AddControl(new Guid("5b60280e-0372-47af-9546-ee71b3f2f386"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("ad3357ec-d656-4661-8ce4-83ce2eee3318"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("acacbc3d-1f20-4830-ace2-116555ee30d3"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("f78f7835-a725-4555-8d62-1035232c0274"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("4d8bcacd-57c6-462f-95e0-bbafe6bf8855"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("e240e0f6-ec82-481c-8a6e-816e6be2fa3b"));
            FormuleTabPage = (ITTTabPage)AddControl(new Guid("046f8fe2-e0b3-472e-9bd3-55d6d383f292"));
            DrugActiveIngredients = (ITTGrid)AddControl(new Guid("a5c532dc-525a-4b6b-aaf0-9947e762e805"));
            ActiveIngredient = (ITTListBoxColumn)AddControl(new Guid("79e35843-3d33-4cb9-a619-c3c0d375e908"));
            Unit = (ITTListBoxColumn)AddControl(new Guid("7985a940-0d2d-4bcb-9f66-3ae0fae50cb5"));
            Value = (ITTTextBoxColumn)AddControl(new Guid("5e8d2200-e61d-4866-8b68-d5198a7e397d"));
            FormulaMaxDose = (ITTTextBoxColumn)AddControl(new Guid("69ea2d61-57ee-42ed-87cd-08ae6dc1373d"));
            MaxDoseUnit = (ITTListBoxColumn)AddControl(new Guid("4eff42cb-89b4-4824-82f2-f40a9ebbff8c"));
            IsParentIngredient = (ITTCheckBoxColumn)AddControl(new Guid("abd48e21-9bed-493b-93e9-7490840b0fee"));
            ProductionTabPage = (ITTTabPage)AddControl(new Guid("9fc3409d-5b58-430a-8daa-84fa0be28f27"));
            labelOutpatientReportType = (ITTLabel)AddControl(new Guid("efc0e655-680d-4c05-825f-7a5ff5e312a9"));
            OutpatientReportType = (ITTEnumComboBox)AddControl(new Guid("d2dfebe6-1966-46ac-bb34-725fd44887c7"));
            labelInpatientReportType = (ITTLabel)AddControl(new Guid("4ab3295b-9b2a-4b9b-80ee-3e4ef41114d2"));
            InpatientReportType = (ITTEnumComboBox)AddControl(new Guid("e0f444cb-e728-48de-8cd6-fa8e74fa9136"));
            gbxAmountPrice = (ITTGroupBox)AddControl(new Guid("56cec462-6ec8-4fa2-9d36-613548f52012"));
            txtTestAmount = (ITTTextBox)AddControl(new Guid("5f7ca945-672d-4eb3-89c6-849dff9d4ef4"));
            btnCalculate = (ITTButton)AddControl(new Guid("dff0d169-e6cc-461c-8c61-b6c31be688ed"));
            txtAmountMultiplier = (ITTTextBox)AddControl(new Guid("f548faf4-7b10-46e2-9bdb-4874023c6d4d"));
            txtUnitPriceDivider = (ITTTextBox)AddControl(new Guid("523ccf1d-ac7a-45f4-bb75-3fef1533383c"));
            lblTestAmount = (ITTLabel)AddControl(new Guid("05aece0c-9277-4c71-be3f-e86c64062ffc"));
            lblAmountMultiplier = (ITTLabel)AddControl(new Guid("4613d295-b9c6-4205-9c1a-27c6dbe83f28"));
            lblUnitPriceDivider = (ITTLabel)AddControl(new Guid("be1fa4f5-8ea2-4757-844c-a73576c5c2de"));
            SetMedulaInfoByMultiplier = (ITTCheckBox)AddControl(new Guid("edb45163-a948-4474-982f-9bb4256848b3"));
            CreateInMedulaDontSendState = (ITTCheckBox)AddControl(new Guid("c2249142-f786-4825-b9c7-f0f40670aed0"));
            DividePriceToVolume = (ITTCheckBox)AddControl(new Guid("db56a656-28b7-4d8c-a74e-3400603f0b26"));
            lblMedulaMultiplier = (ITTLabel)AddControl(new Guid("d3f34950-3663-402b-908d-d52322114925"));
            searchMedicineFromMedula = (ITTButton)AddControl(new Guid("bf3a2127-b942-46d4-bffa-d1fcb47ba87e"));
            MedulaMultiplier = (ITTTextBox)AddControl(new Guid("1798240d-1284-47b1-bbf9-52cf6fa0e59f"));
            labelPurchaseDate = (ITTLabel)AddControl(new Guid("b460e482-8dcd-45d7-9082-6b3c4942ed82"));
            PurchaseDate = (ITTDateTimePicker)AddControl(new Guid("55f0a540-7cd3-4196-bd99-99ef8a23dd5b"));
            labelBrans = (ITTLabel)AddControl(new Guid("ca80e6a0-62e6-4e07-ba52-dc4c14a5432a"));
            ReimbursementUnder = (ITTCheckBox)AddControl(new Guid("0be3227b-408f-4164-bc43-5800aaa0651e"));
            Brans = (ITTObjectListBox)AddControl(new Guid("91e42298-66ad-4ebd-b35d-bfda73066b28"));
            labelMaterialPricingType = (ITTLabel)AddControl(new Guid("6bb058e6-7219-43c2-b516-a482400957e5"));
            MaterialPricingType = (ITTEnumComboBox)AddControl(new Guid("acf7067d-e5a7-4b9a-ae8e-5c5f49b42308"));
            labelProducer = (ITTLabel)AddControl(new Guid("2b512105-58e2-4e2c-b12a-44d3dd4e1424"));
            Producer = (ITTObjectListBox)AddControl(new Guid("cec731f0-31d6-40d8-9f6f-7dc906caa887"));
            labelProductNumber = (ITTLabel)AddControl(new Guid("bd3a5cc5-aea1-4a5e-8b48-825f076dbcfb"));
            ProductNumber = (ITTTextBox)AddControl(new Guid("4815315e-3a74-4812-90aa-d9f18e46c986"));
            labelGMDNCodeStockCard = (ITTLabel)AddControl(new Guid("d0772873-b288-49d0-a817-c9a39a729973"));
            GMDNCodeStockCard = (ITTObjectListBox)AddControl(new Guid("c041791f-be24-4758-980c-bafc597b244a"));
            labelPackageAmount = (ITTLabel)AddControl(new Guid("e7c6f6f1-43bb-49a2-ac04-f7faf31b1d9d"));
            PackageAmount = (ITTTextBox)AddControl(new Guid("5bd0b96c-829e-408e-b46c-aeb31b70dc34"));
            labelLicencingOrganization = (ITTLabel)AddControl(new Guid("a338692d-84db-4eea-b786-b094a26590f2"));
            LicencingOrganization = (ITTEnumComboBox)AddControl(new Guid("4e36acb9-1837-4c98-9834-5921f8e5bfb5"));
            labelLicenceNO = (ITTLabel)AddControl(new Guid("66e3a03b-ea09-4366-87cb-1465d058b206"));
            LicenceNO = (ITTTextBox)AddControl(new Guid("d1aea29e-c1a1-4c90-ae17-cc2448601299"));
            labelLicenceDate = (ITTLabel)AddControl(new Guid("12841e7c-27fd-45b8-bef9-9e280abb0d0b"));
            LicenceDate = (ITTDateTimePicker)AddControl(new Guid("f00059a0-f5c0-45f0-a31a-e10be7f43486"));
            labelCurrentPrice = (ITTLabel)AddControl(new Guid("bb3b055e-3bd4-44b4-a926-6a31dc8f7330"));
            CurrentPrice = (ITTTextBox)AddControl(new Guid("dbcb5a88-5b4d-482f-a09f-8bc15fa75316"));
            labelBarcodeName = (ITTLabel)AddControl(new Guid("dd052a55-b389-4bff-9de1-52bd3aeac003"));
            BarcodeName = (ITTTextBox)AddControl(new Guid("36172177-c56a-45c4-a3aa-7c188ec886a5"));
            KDVTabPage = (ITTTabPage)AddControl(new Guid("e4b18a6a-e53e-4796-9ba7-8396d83d698e"));
            labelInstitutionDiscountRate = (ITTLabel)AddControl(new Guid("0948fb21-c9ee-4db8-8fa3-f2dc93718c03"));
            InstitutionDiscountRate = (ITTTextBox)AddControl(new Guid("93ba027f-b14f-478e-9568-a56ab6382108"));
            labelPharmacistDiscountRate = (ITTLabel)AddControl(new Guid("ed3d5624-201c-4e3b-b932-340f011a40fb"));
            PharmacistDiscountRate = (ITTTextBox)AddControl(new Guid("25c8c2a0-2e6d-428a-8bea-add5f7bd06bd"));
            MaterialVatRates = (ITTGrid)AddControl(new Guid("85ef6446-5c34-43ae-b2cc-4c23fcb47eb1"));
            VatRate = (ITTTextBoxColumn)AddControl(new Guid("58d5493f-8542-4145-bb31-53a645e4cbed"));
            StartDate = (ITTDateTimePickerColumn)AddControl(new Guid("6c8f3e0d-d884-45eb-8e43-200359333aa6"));
            EndDate = (ITTDateTimePickerColumn)AddControl(new Guid("1bd907aa-e104-4892-a58f-5ebd4f7bdb08"));
            MaterialPriceGrid = (ITTGrid)AddControl(new Guid("a1b28d2c-cc91-493b-a1da-31d0519e2f00"));
            PriceCode = (ITTTextBoxColumn)AddControl(new Guid("e09d4e51-45b1-4fbc-bc2d-e538526f1e00"));
            PriceDesc = (ITTTextBoxColumn)AddControl(new Guid("43495e2a-29cd-41c0-b7e0-7e2ed6c97bd7"));
            PricingList = (ITTListBoxColumn)AddControl(new Guid("9579dd4f-2d4b-41ba-be08-97ca6fda9235"));
            Price = (ITTTextBoxColumn)AddControl(new Guid("1b2415e0-98f3-484d-99ac-d37ab5dc2bdd"));
            CurrencyType = (ITTListBoxColumn)AddControl(new Guid("d643fbca-1595-4a72-91d9-ad9262727a0b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("337db95d-a5ef-4261-a919-b226c08c9d5a"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("733a2a47-026a-4c10-8443-fa64cac8327b"));
            DescriptionTabPage = (ITTTabPage)AddControl(new Guid("8736bcef-b03a-47e0-a87f-40de9e0754f6"));
            Description = (ITTTextBox)AddControl(new Guid("1d78cc04-220d-42ac-a77d-615b70c28062"));
            EquivalentTabPage = (ITTTabPage)AddControl(new Guid("dfb162d6-efa2-4ecd-b1bb-9bb1f72e60a1"));
            EquivalentsGrid = (ITTGrid)AddControl(new Guid("d8135147-7328-4209-932e-9a302c6bf8e6"));
            EquivalentDrugName = (ITTTextBoxColumn)AddControl(new Guid("4f3a7029-2195-4b13-abdf-6256eff1e6c2"));
            Ek2EquivalentTabPage = (ITTTabPage)AddControl(new Guid("4b27a536-9f39-4130-a4ae-0515d2c40855"));
            DrugRelations = (ITTGrid)AddControl(new Guid("fb6a207c-5fa2-42ea-b815-14f1b7578548"));
            RelationDrugDrugRelation = (ITTListBoxColumn)AddControl(new Guid("5744e728-424d-4d77-80ae-5f789b7809cc"));
            ManuelEquivalentTabPage = (ITTTabPage)AddControl(new Guid("5a937091-73d7-4bd3-8d30-e3511c710669"));
            cmdAddEquiv = (ITTButton)AddControl(new Guid("390f6743-3c82-4fdf-aa44-4a646fd7ba88"));
            ManuelEquivalentDrugs = (ITTGrid)AddControl(new Guid("d443b0bb-d268-4793-b6d4-95d03baa7db2"));
            EquivalentDrugManuelEquivDrug = (ITTListBoxColumn)AddControl(new Guid("5c41687f-851a-4a5a-a453-226754f40d33"));
            ETKMDescriptionTabPage = (ITTTabPage)AddControl(new Guid("53874dbc-f773-4827-9caa-8e3c403d885e"));
            ETKMDescription = (ITTTextBox)AddControl(new Guid("c9b95fb8-0654-40e3-8f9b-75f18ed77af4"));
            DrugLabIntTabPage = (ITTTabPage)AddControl(new Guid("8ce83eaf-7cbd-4cf5-bc0d-c469c6320668"));
            DrugLabProcInteractions = (ITTGrid)AddControl(new Guid("8633e255-f4ab-4bdd-8196-722e8de45305"));
            LaboratoryTestDefinitionDrugLabProcInteraction = (ITTListBoxColumn)AddControl(new Guid("b8ecd380-6395-4f47-90e3-7f0228d7d67b"));
            MinValueDrugLabProcInteraction = (ITTTextBoxColumn)AddControl(new Guid("b834f7ac-98ec-437c-81b4-4ba0f58f1d67"));
            MaxValueDrugLabProcInteraction = (ITTTextBoxColumn)AddControl(new Guid("2dc2ce0f-d1a3-4582-a6ed-e6a9cdf5192c"));
            MessageDrugLabProcInteraction = (ITTTextBoxColumn)AddControl(new Guid("31b8450f-8502-4a9d-abec-38dbbb6e1715"));
            DrugSpecifications = (ITTTabPage)AddControl(new Guid("28c179eb-33de-4ba3-b2ed-15c33b281577"));
            grdDrugSpecification = (ITTGrid)AddControl(new Guid("587e1ffa-5e5e-473f-a836-5b40fe575b6a"));
            DrugSpecification = (ITTEnumComboBoxColumn)AddControl(new Guid("1c4402cd-5227-4144-9412-09179db46859"));
            MaterialProcedure = (ITTTabPage)AddControl(new Guid("5adb4e19-0c96-4e84-adfe-1a7fb3c276f8"));
            grdMaterialProcedures = (ITTGrid)AddControl(new Guid("043da52a-39d5-42fc-ae56-a62b14ccfd5c"));
            ProcedureDefinitionMaterialProcedures = (ITTListBoxColumn)AddControl(new Guid("66391151-6401-4a0a-962f-af7ddcbe287c"));
            Code = (ITTTextBox)AddControl(new Guid("a53b8211-5513-4d6d-a105-eae94bf8936a"));
            StockCard = (ITTObjectListBox)AddControl(new Guid("455dc56b-073d-4e94-8a73-b6d1c5296b80"));
            MaterialTree = (ITTObjectListBox)AddControl(new Guid("4dfb72fe-c48e-4e12-b609-e32c9e31dee6"));
            Chargable = (ITTCheckBox)AddControl(new Guid("09a50119-2d37-4b09-8dee-ff40fe2572d6"));
            AllowToGivePatient = (ITTCheckBox)AddControl(new Guid("7cb6c612-4c82-4b0e-9742-5e23a9c0a11e"));
            IsArmyDrug = (ITTCheckBox)AddControl(new Guid("3cb69806-28e7-4546-8e6b-d2ff24e8b1ea"));
            IsPackageExclusive = (ITTCheckBox)AddControl(new Guid("9e8e5684-2918-423f-9267-50213bd1abba"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("12dbc3da-4a4b-47b4-9501-a0553d354a22"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("4caad753-2825-43e7-94d4-56d6e2505a29"));
            ttenumcombobox2 = (ITTEnumComboBox)AddControl(new Guid("f35856a5-771e-4c91-a2b1-4e512e3c05f5"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("c581cc4d-c1c6-499d-8324-f32e1aa0ab99"));
            AntibioticType = (ITTEnumComboBox)AddControl(new Guid("216d6bc5-a82e-436e-8ffe-52973597c9c5"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("1b5a6707-ddab-4507-b63a-edd9d68205fd"));
            DailyStay = (ITTCheckBox)AddControl(new Guid("f651614e-b3c6-4302-b234-f1d44726aa34"));
            base.InitializeControls();
        }

        public DrugDefinitionForm() : base("DRUGDEFINITION", "DrugDefinitionForm")
        {
        }

        protected DrugDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}