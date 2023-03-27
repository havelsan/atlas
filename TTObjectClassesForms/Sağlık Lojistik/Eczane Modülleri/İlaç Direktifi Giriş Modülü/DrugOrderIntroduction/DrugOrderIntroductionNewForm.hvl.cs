
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
    /// İlaç Direktifi Giriş
    /// </summary>
    public partial class DrugOrderIntroductionNewForm : TTForm
    {
    /// <summary>
    /// İlaç Direktifi Giriş
    /// </summary>
        protected TTObjectClasses.DrugOrderIntroduction _DrugOrderIntroduction
        {
            get { return (TTObjectClasses.DrugOrderIntroduction)_ttObject; }
        }

        protected ITTTextBox DrugDescription;
        protected ITTTextBox PackageAmount;
        protected ITTTextBox txtStoreName;
        protected ITTLabel labelDrugDescriptionType;
        protected ITTLabel labelPeriodUnitType;
        protected ITTEnumComboBox PeriodUnitType;
        protected ITTEnumComboBox DrugDescriptionType;
        protected ITTLabel labelPackageAmount;
        protected ITTLabel ttlabel13;
        protected ITTObjectListBox SecondaryMasterResource;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage NewOrderTabPage;
        protected ITTCheckBox IsBarcode;
        protected ITTCheckBox IsInheldDrug;
        protected ITTCheckBox AutoSearch;
        protected ITTButton cmdSearch;
        protected ITTCheckBox PatientOwnDrugCheck;
        protected ITTGroupBox ttgroupbox3;
        protected ITTLabel labelDrugUsageType;
        protected ITTButton btnIlacBilgileri;
        protected ITTEnumComboBox DrugUsageType;
        protected ITTLabel labelDrugName;
        protected ITTLabel labelOrderDay;
        protected ITTTextBox DrugName;
        protected ITTLabel ttlabel5;
        protected ITTTextBox OrderDay;
        protected ITTLabel labelPlannedStartTime;
        protected ITTTextBox OrderDose;
        protected ITTDateTimePicker PlannedStartTime;
        protected ITTLabel labelOrderDose;
        protected ITTButton btnSUTBilgileri;
        protected ITTLabel labelOrderFrequency;
        protected ITTTextBox OrderFrequency;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelVolumeUnit;
        protected ITTTextBox Unit;
        protected ITTTextBox Dose;
        protected ITTLabel labelVolume;
        protected ITTTextBox Volume;
        protected ITTLabel labelDose;
        protected ITTTextBox MaxDose;
        protected ITTLabel labelMaxDoseDay;
        protected ITTTextBox MaxDoseDay;
        protected ITTLabel labelMaxDose;
        protected ITTGroupBox ttgroupbox2;
        protected ITTCheckBox UseRoutineValue;
        protected ITTLabel labelRoutineDay;
        protected ITTLabel ttlabel10;
        protected ITTTextBox tttextbox7;
        protected ITTTextBox tttextbox8;
        protected ITTLabel ttlabel11;
        protected ITTEnumComboBox ttenumcombobox2;
        protected ITTLabel ttlabel1;
        protected ITTButton cmdAddDrug;
        protected ITTTextBox SearchTextbox;
        protected ITTListView DrugListview;
        protected ITTTabPage OldOrderTabPage;
        protected ITTButton cmdGetTemplate;
        protected ITTButton cmdAddTemplate;
        protected ITTLabel ttlabel2;
        protected ITTListView FavoriteDrugListview;
        protected ITTGrid OldDrugOrders;
        protected ITTButtonColumn cmdRepat;
        protected ITTDateTimePickerColumn OldDrugPlanDate;
        protected ITTListBoxColumn OldDrug;
        protected ITTEnumComboBoxColumn OldDrugFrequency;
        protected ITTTextBoxColumn OldDoseAmount;
        protected ITTTextBoxColumn OldDay;
        protected ITTTextBoxColumn OldUseDescription;
        protected ITTGroupBox ttgroupbox4;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel6;
        protected ITTTextBox FavoriteDrugDay;
        protected ITTLabel ttlabel7;
        protected ITTTextBox FavoriteDrugDose;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel9;
        protected ITTButton cmdFavoriteDrug;
        protected ITTTextBox FavoriteDrugFrequency;
        protected ITTTabPage PrescriptionTabPage;
        protected ITTGrid InpatientPresDetails;
        protected ITTEnumComboBoxColumn PrescriptionType;
        protected ITTTextBoxColumn EReceteNo;
        protected ITTComboBoxColumn EReceteDescription;
        protected ITTTabPage OutPatientTabPage;
        protected ITTGrid OutpatientPresDetails;
        protected ITTEnumComboBoxColumn OutPresType;
        protected ITTTextBoxColumn OutPresEReceteNo;
        protected ITTTextBoxColumn OutPresEReceteDesc;
        protected ITTTabPage PatientInfoTabPage;
        protected ITTLabel ttlabel12;
        protected ITTGrid DiagnosisForPrescriptions;
        protected ITTTextBoxColumn CodeDiagnosisForPresc;
        protected ITTTextBoxColumn NameDiagnosisForPresc;
        protected ITTTextBox FullNamePatient;
        protected ITTTextBox ID;
        protected ITTLabel labelFullNamePatient;
        protected ITTLabel labelMasterResource;
        protected ITTObjectListBox MasterResource;
        protected ITTGrid DrugOrderIntroductionDetails;
        protected ITTCheckBoxColumn PatientOwnDrug;
        protected ITTTextBoxColumn PlannedTime;
        protected ITTListBoxColumn MaterialDrugOrderIntroductionDet;
        protected ITTTextBoxColumn VolumeUnit;
        protected ITTEnumComboBoxColumn FrequencyDrugOrderIntroductionDet;
        protected ITTTextBoxColumn DoseAmountDrugOrderIntroductionDet;
        protected ITTTextBoxColumn DayDrugOrderIntroductionDet;
        protected ITTEnumComboBoxColumn ttenumcomboboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBoxColumn UsageNoteDrugOrderIntroductionDet;
        protected ITTEnumComboBoxColumn ttenumcomboboxcolumn2;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTLabel labelID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        override protected void InitializeControls()
        {
            DrugDescription = (ITTTextBox)AddControl(new Guid("aab03f82-afa2-44b2-b801-a72451a1f935"));
            PackageAmount = (ITTTextBox)AddControl(new Guid("27f9ffbb-a24a-42ce-82dc-80b5bdb337d3"));
            txtStoreName = (ITTTextBox)AddControl(new Guid("98c61579-412e-4b57-9773-8ee2cdda1ac5"));
            labelDrugDescriptionType = (ITTLabel)AddControl(new Guid("8c0aef4c-bbbb-443b-940a-676e3fea35b7"));
            labelPeriodUnitType = (ITTLabel)AddControl(new Guid("bc719f4a-b2a7-4f5d-8f3b-954d9b8cb2df"));
            PeriodUnitType = (ITTEnumComboBox)AddControl(new Guid("2145d360-6b17-4629-b3b9-342f44e9147a"));
            DrugDescriptionType = (ITTEnumComboBox)AddControl(new Guid("7e7cd95f-de6c-4140-96a6-a55c42907d44"));
            labelPackageAmount = (ITTLabel)AddControl(new Guid("86c23fcb-fc18-4061-8159-98b4e4b5d824"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("e0b23bec-728f-4728-ac37-160ae5733d53"));
            SecondaryMasterResource = (ITTObjectListBox)AddControl(new Guid("59e769ad-3c49-4031-8cc3-c551c6ba705b"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("ed6c3aeb-e7d9-4572-9c7f-36de861d40d6"));
            NewOrderTabPage = (ITTTabPage)AddControl(new Guid("0ac862a0-9909-4e83-89ea-a2e496edea02"));
            IsBarcode = (ITTCheckBox)AddControl(new Guid("8c1f220d-f02b-4d5a-9775-543f7e834acf"));
            IsInheldDrug = (ITTCheckBox)AddControl(new Guid("f84ecb07-44c8-4006-8ae7-fb5239f0b342"));
            AutoSearch = (ITTCheckBox)AddControl(new Guid("65a12810-fc7b-4d1d-a0fd-3f4b4ccc2e22"));
            cmdSearch = (ITTButton)AddControl(new Guid("b8e174a2-65e7-44fd-af69-d8e3f3ef71ad"));
            PatientOwnDrugCheck = (ITTCheckBox)AddControl(new Guid("4289863a-00be-4988-864b-8584e3babccf"));
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("d3f5fa38-b976-44fe-a5aa-1ed7c071c300"));
            labelDrugUsageType = (ITTLabel)AddControl(new Guid("9b097550-751f-4e90-9787-1626678b7699"));
            btnIlacBilgileri = (ITTButton)AddControl(new Guid("d6f1221d-a7c1-41a9-b6ca-e15b3d8e9a5f"));
            DrugUsageType = (ITTEnumComboBox)AddControl(new Guid("c713b0d9-182d-4b9e-a1ea-2481c10e5ea9"));
            labelDrugName = (ITTLabel)AddControl(new Guid("b9b70831-a592-4251-9f36-36c366988809"));
            labelOrderDay = (ITTLabel)AddControl(new Guid("442d164a-3c1f-4cb8-9663-fd46b5cd5509"));
            DrugName = (ITTTextBox)AddControl(new Guid("6b9241db-f23b-4d59-9c50-61596cfd6e41"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("5ddc377b-8b38-4d24-8337-57b5b827b3f9"));
            OrderDay = (ITTTextBox)AddControl(new Guid("b80c4e30-ee0f-4568-8458-bb1c45f69413"));
            labelPlannedStartTime = (ITTLabel)AddControl(new Guid("62122546-e2f4-475a-89fb-eda62910044f"));
            OrderDose = (ITTTextBox)AddControl(new Guid("6eda5e01-16cc-46ad-a04b-7205dce52e29"));
            PlannedStartTime = (ITTDateTimePicker)AddControl(new Guid("1ae4e2c7-1d98-4a00-b347-7fdac417fa8c"));
            labelOrderDose = (ITTLabel)AddControl(new Guid("28eb1fcb-2188-4da7-a1c7-06631666ceb0"));
            btnSUTBilgileri = (ITTButton)AddControl(new Guid("bd25f07f-54d0-4d1f-8ed0-de37540affe2"));
            labelOrderFrequency = (ITTLabel)AddControl(new Guid("11a6e105-4007-4fe3-968c-c645e62a1ba6"));
            OrderFrequency = (ITTTextBox)AddControl(new Guid("a998a051-eabb-4ece-ba16-0be77beefec5"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("66d77290-14f1-4274-805d-edf0623a3b1a"));
            labelVolumeUnit = (ITTLabel)AddControl(new Guid("3fe9c1ae-a4d3-4253-a9e2-3e5a3442a201"));
            Unit = (ITTTextBox)AddControl(new Guid("a050e239-9061-48d1-8308-2f43b288628b"));
            Dose = (ITTTextBox)AddControl(new Guid("43b1ff67-bbbd-4596-bf41-fa331d57ad3e"));
            labelVolume = (ITTLabel)AddControl(new Guid("9b8149ed-1bbc-46b1-b4c7-1a0f85bc6df9"));
            Volume = (ITTTextBox)AddControl(new Guid("e61ca9a7-e2b2-46d4-9915-9f3312b7a56c"));
            labelDose = (ITTLabel)AddControl(new Guid("34ae8db1-8289-4918-ba9e-312974628d1c"));
            MaxDose = (ITTTextBox)AddControl(new Guid("3b475afc-1855-4575-9d01-176455800662"));
            labelMaxDoseDay = (ITTLabel)AddControl(new Guid("beba85a8-9fb0-4674-9edb-6534941461a9"));
            MaxDoseDay = (ITTTextBox)AddControl(new Guid("dd2723e1-b66c-4b2f-9019-1372f9ec0384"));
            labelMaxDose = (ITTLabel)AddControl(new Guid("e1bc19cd-eff2-42bf-b9b3-1b109aa05c5d"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("84fe5e56-b6c5-4fd7-85a3-38f1425e6caf"));
            UseRoutineValue = (ITTCheckBox)AddControl(new Guid("29f25fcd-d428-44ef-b58a-eaf0623db3d3"));
            labelRoutineDay = (ITTLabel)AddControl(new Guid("0c7ecb36-58db-4a4b-ae83-f0fb9e1b4fa7"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("d3a13264-d439-4f79-b249-088268f67df9"));
            tttextbox7 = (ITTTextBox)AddControl(new Guid("49958c35-eb8f-412d-9c3f-4e17b452433e"));
            tttextbox8 = (ITTTextBox)AddControl(new Guid("8fc27588-86d0-4da8-9cb2-da3623b78741"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("81be16c0-acf8-4ea8-9a15-ec7f30598dbc"));
            ttenumcombobox2 = (ITTEnumComboBox)AddControl(new Guid("e4c3b624-b4a6-4277-a898-5941e3f219af"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3600868f-c37e-42e6-b3a6-02d2e4198d5b"));
            cmdAddDrug = (ITTButton)AddControl(new Guid("307ae644-0cfd-4710-900e-608f3647a3c9"));
            SearchTextbox = (ITTTextBox)AddControl(new Guid("c1767a24-716e-45cc-9a66-5b6bf848ec1f"));
            DrugListview = (ITTListView)AddControl(new Guid("5fc172c5-e689-4f6e-aaa9-d66f0596a5ea"));
            OldOrderTabPage = (ITTTabPage)AddControl(new Guid("f2dfcfc7-9957-4066-b8a5-92a1803ae347"));
            cmdGetTemplate = (ITTButton)AddControl(new Guid("99e1f6a7-c5e9-43d8-aaea-5e3e4bdd115c"));
            cmdAddTemplate = (ITTButton)AddControl(new Guid("ee04cfac-a655-4d3e-8a4f-f35ff792778e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e7ea9723-4ab7-4b24-928f-3b5cca302498"));
            FavoriteDrugListview = (ITTListView)AddControl(new Guid("e5b84f47-75fa-4c65-810a-c0c53ed5ff5c"));
            OldDrugOrders = (ITTGrid)AddControl(new Guid("0ff82709-e98f-4a95-ac76-2783e0f160b9"));
            cmdRepat = (ITTButtonColumn)AddControl(new Guid("32559cc3-a0f8-4696-b60b-ebaf5e76f234"));
            OldDrugPlanDate = (ITTDateTimePickerColumn)AddControl(new Guid("66277a93-f3ab-4290-8ecf-b3b2d1e9b486"));
            OldDrug = (ITTListBoxColumn)AddControl(new Guid("ce0b7e18-a2b0-4bb5-9399-d109f0a62660"));
            OldDrugFrequency = (ITTEnumComboBoxColumn)AddControl(new Guid("b47f61fd-4600-4de1-8877-cf531f4438fa"));
            OldDoseAmount = (ITTTextBoxColumn)AddControl(new Guid("c3a60c83-43ae-4938-b351-35bbadfc4b38"));
            OldDay = (ITTTextBoxColumn)AddControl(new Guid("44003237-2139-4867-9e70-934286e58c04"));
            OldUseDescription = (ITTTextBoxColumn)AddControl(new Guid("355e75b3-d8f2-4d98-ac1a-d1b3a371c1d2"));
            ttgroupbox4 = (ITTGroupBox)AddControl(new Guid("325fcc66-2ebd-480f-a4d3-221965f5c07a"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("03b98807-d5df-4ad0-982c-72258d761ef2"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("2e99d688-7bc5-4476-9ad8-ca440dd4509e"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("61e5780c-5834-46f9-8e8b-626a53735b73"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("bfb9e913-59d4-4e96-80fb-265b4eb4981b"));
            FavoriteDrugDay = (ITTTextBox)AddControl(new Guid("3141af5b-5526-4af3-a5ca-319c705a2682"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("898c3d38-ebf6-4739-bcc1-06a5208ad602"));
            FavoriteDrugDose = (ITTTextBox)AddControl(new Guid("198c00c5-b4ca-4b89-a39a-5684fdb53948"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("d30f8e77-5ccf-4687-9839-8c4a30bca2d5"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("6c93b813-6950-4163-8b19-38e4ae20aa77"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("2c166f5b-eae2-4c1e-99f8-9bf8e9973efd"));
            cmdFavoriteDrug = (ITTButton)AddControl(new Guid("fed67caf-6638-4e3d-bb42-afb31f13bb13"));
            FavoriteDrugFrequency = (ITTTextBox)AddControl(new Guid("1c502aea-2eea-43b6-953e-5f7d39057efe"));
            PrescriptionTabPage = (ITTTabPage)AddControl(new Guid("f9802c6a-994c-46be-af86-3d97ed3fdf92"));
            InpatientPresDetails = (ITTGrid)AddControl(new Guid("6a2adfa5-0df7-4b0b-83f8-430e91926012"));
            PrescriptionType = (ITTEnumComboBoxColumn)AddControl(new Guid("e01d502a-3a40-49a3-a162-978869914086"));
            EReceteNo = (ITTTextBoxColumn)AddControl(new Guid("5181200e-5371-4b99-b338-66005e19c04f"));
            EReceteDescription = (ITTComboBoxColumn)AddControl(new Guid("a9a9c39f-48ba-482f-acbd-58c33f1745f1"));
            OutPatientTabPage = (ITTTabPage)AddControl(new Guid("4e33dfc7-c247-468b-a8c3-d1eaedcf2aae"));
            OutpatientPresDetails = (ITTGrid)AddControl(new Guid("ad40a4c9-1164-4bb3-87f0-cff3bbb72794"));
            OutPresType = (ITTEnumComboBoxColumn)AddControl(new Guid("034ddf0f-32c0-411f-9778-f2b86ea9ecf3"));
            OutPresEReceteNo = (ITTTextBoxColumn)AddControl(new Guid("8713dfa1-9a8e-4386-a149-59c1a068ac3f"));
            OutPresEReceteDesc = (ITTTextBoxColumn)AddControl(new Guid("05ae4d2e-d923-4a2d-9d65-274a307ad6c7"));
            PatientInfoTabPage = (ITTTabPage)AddControl(new Guid("c8d40d74-3eb1-48ac-a9cc-cf58cd23697d"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("aeb2d246-37f7-42e4-84f8-31a3007e59f4"));
            DiagnosisForPrescriptions = (ITTGrid)AddControl(new Guid("9f33e5d8-1139-4d57-809d-7326b2ce3792"));
            CodeDiagnosisForPresc = (ITTTextBoxColumn)AddControl(new Guid("d8864f0d-2121-400b-86d1-286a0e966c38"));
            NameDiagnosisForPresc = (ITTTextBoxColumn)AddControl(new Guid("09788f26-4875-4bd4-a26c-b5a10734e93b"));
            FullNamePatient = (ITTTextBox)AddControl(new Guid("a0b1c4cf-83f1-4ccf-bf3d-e7faaa4824c8"));
            ID = (ITTTextBox)AddControl(new Guid("534f422f-df1d-4e3e-ae1a-406b9997d4d1"));
            labelFullNamePatient = (ITTLabel)AddControl(new Guid("bfa554a2-a9d2-4502-af69-7e30ed318d75"));
            labelMasterResource = (ITTLabel)AddControl(new Guid("ac52d1e9-4cde-4d26-b768-3eac81198fce"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("f196d465-ed4d-4c96-a455-1b4e018b9823"));
            DrugOrderIntroductionDetails = (ITTGrid)AddControl(new Guid("814093e8-b4c1-40fa-84d7-2e1731a5df07"));
            PatientOwnDrug = (ITTCheckBoxColumn)AddControl(new Guid("2d0e1c7e-df90-4e0d-b8cf-ac351563686a"));
            PlannedTime = (ITTTextBoxColumn)AddControl(new Guid("703c43a8-1a66-49ae-a46a-d7240b338c2f"));
            MaterialDrugOrderIntroductionDet = (ITTListBoxColumn)AddControl(new Guid("1b70004b-d6e2-4784-affb-829cce308b52"));
            VolumeUnit = (ITTTextBoxColumn)AddControl(new Guid("e900537b-45dd-4604-9d1f-43a21cc214dd"));
            FrequencyDrugOrderIntroductionDet = (ITTEnumComboBoxColumn)AddControl(new Guid("b6e39812-a5d1-4cd8-aede-bc4eb8d20c43"));
            DoseAmountDrugOrderIntroductionDet = (ITTTextBoxColumn)AddControl(new Guid("762a8b5a-280b-4527-9b58-83d71eb450e1"));
            DayDrugOrderIntroductionDet = (ITTTextBoxColumn)AddControl(new Guid("ebd4eaa6-88b1-4356-abfa-f3a32e130d7e"));
            ttenumcomboboxcolumn1 = (ITTEnumComboBoxColumn)AddControl(new Guid("09755288-4fd3-41b9-9271-12930114ae5f"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("b0c7ca03-d348-4254-8fce-b93e09000d54"));
            UsageNoteDrugOrderIntroductionDet = (ITTTextBoxColumn)AddControl(new Guid("2350dfa6-92c3-438c-8275-7fcf8bf552c4"));
            ttenumcomboboxcolumn2 = (ITTEnumComboBoxColumn)AddControl(new Guid("1f64d094-bf75-4637-a767-15752ab51c72"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("5b70cc49-5479-4a7c-a989-2f8f2184db01"));
            labelID = (ITTLabel)AddControl(new Guid("7c4dace3-4bdb-4e67-93e2-ce5ffbcf4df2"));
            labelActionDate = (ITTLabel)AddControl(new Guid("15132722-9953-4ccf-b016-7c24c562a29b"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("e5368120-ab19-41a8-85b9-e7de1d8fe46d"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("94e57ea4-d892-4e40-9b74-910044b081a9"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("0326c96d-e666-4cb3-9731-bec6128d3a80"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("f74762c5-264d-4ea6-b361-dbed83ef47d4"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("9a44921b-8bb2-4494-8efb-b1b52dd1e4f5"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("5ed966b3-2609-4102-93a9-40d1f757d4c6"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("5dbe9f36-8d87-45a4-b1d6-fd32d968a267"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("1b646333-f857-4c48-aa82-8010b0eeebe7"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("9015633e-a4bf-41ef-87e2-7381de7b8b4a"));
            base.InitializeControls();
        }

        public DrugOrderIntroductionNewForm() : base("DRUGORDERINTRODUCTION", "DrugOrderIntroductionNewForm")
        {
        }

        protected DrugOrderIntroductionNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}