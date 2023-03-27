
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
    public partial class ArgeProjectNewForm : TTForm
    {
    /// <summary>
    /// Proje Başvuru Formu
    /// </summary>
        protected TTObjectClasses.ArgeProject _ArgeProject
        {
            get { return (TTObjectClasses.ArgeProject)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox ConsumableMaterial;
        protected ITTLabel labelEthicCommisionApproveNo;
        protected ITTTextBox EthicCommisionApproveNo;
        protected ITTLabel labelProjectInternationalName;
        protected ITTTextBox ProjectInternationalName;
        protected ITTTextBox txtProjectStatus;
        protected ITTPanel ttpanel1;
        protected ITTLabel labelProjectConcumableMaterialCosts;
        protected ITTLabel labelProjectTotalCosts;
        protected ITTTextBox TotalConsumableCosts;
        protected ITTTextBox TotalCosts;
        protected ITTLabel labelProjectReagentCosts;
        protected ITTTextBox TotalReagentCosts;
        protected ITTLabel labelProjectOtherCosts;
        protected ITTTextBox TotalOtherCosts;
        protected ITTLabel labelDutyCosts;
        protected ITTTextBox TotalDutyCosts;
        protected ITTLabel labelProjectStatus;
        protected ITTEnumComboBox ProjectDurationType;
        protected ITTLabel labelProjectType;
        protected ITTObjectListBox ProjectType;
        protected ITTLabel labelProjectSpecies;
        protected ITTObjectListBox ProjectSpecies;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelProjectNo;
        protected ITTTextBox ProjectNo;
        protected ITTLabel labelProjectName;
        protected ITTTextBox ProjectName;
        protected ITTLabel labelProjectDuration;
        protected ITTTextBox ProjectDuration;
        protected ITTTabPage tttabpage2;
        protected ITTLabel labelNameMilitaryClassDefinitions;
        protected ITTTextBox NameMilitaryClassDefinitions;
        protected ITTObjectListBox OwnerDepartment;
        protected ITTLabel labelNameRankDefinitions;
        protected ITTLabel labelOwnerDepartment;
        protected ITTTextBox NameRankDefinitions;
        protected ITTLabel labelIdentificationCardNoPerson;
        protected ITTTextBox IdentificationCardNoPerson;
        protected ITTLabel labelBirthDatePerson;
        protected ITTDateTimePicker BirthDatePerson;
        protected ITTLabel labelWorkPlaceResUser;
        protected ITTTextBox WorkPlaceResUser;
        protected ITTLabel labelWorkResUser;
        protected ITTTextBox WorkResUser;
        protected ITTLabel labelPhoneNumberResUser;
        protected ITTTextBox PhoneNumberResUser;
        protected ITTLabel labelProjectOwner;
        protected ITTObjectListBox ProjectOwner;
        protected ITTLabel labelPersonalCv;
        protected ITTTextBox PersonalCv;
        protected ITTLabel labelMobilTel;
        protected ITTTextBox MobilTel;
        protected ITTLabel labelHomeTel;
        protected ITTTextBox HomeTel;
        protected ITTLabel labelEmail;
        protected ITTTextBox Email;
        protected ITTTabPage tttabpage3;
        protected ITTGrid Participiants;
        protected ITTListBoxColumn ProjectParticipiantParticipiants;
        protected ITTTextBoxColumn rank;
        protected ITTTextBoxColumn title;
        protected ITTListBoxColumn OwnerDepartmentParticipiants;
        protected ITTTextBoxColumn BiographyParticipiants;
        protected ITTTabPage tttabpage6;
        protected ITTGrid Journals;
        protected ITTTextBoxColumn JournalProjectJournal;
        protected ITTTextBoxColumn AuthorNameProjectJournal;
        protected ITTTextBoxColumn AuthorSurnameProjectJournal;
        protected ITTListBoxColumn JournalTypeProjectJournal;
        protected ITTDateTimePickerColumn JournalDateProjectJournal;
        protected ITTTextBoxColumn JournalPlaceProjectJournal;
        protected ITTTextBoxColumn JournalTextProjectJournal;
        protected ITTTabPage tttabpage10;
        protected ITTGrid Awards;
        protected ITTTextBoxColumn AwardProjectAward;
        protected ITTTextBoxColumn GivingAuthorityProjectAward;
        protected ITTTextBoxColumn PriceProjectAward;
        protected ITTTextBoxColumn WhyGivedProjectAward;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage tttabpage4;
        protected ITTTabControl tttabcontrol3;
        protected ITTTabPage tttabpage7;
        protected ITTGrid gridOtherCost;
        protected ITTTextBoxColumn OtherCostNameOtherCostDetail;
        protected ITTListBoxColumn ExchangeTypeOtherCostDetail;
        protected ITTTextBoxColumn OtherCostPriceOtherCostDetail;
        protected ITTTabPage tttabpage8;
        protected ITTGrid gridDutyCost;
        protected ITTTextBoxColumn DutyCostNameDutiesDetail;
        protected ITTListBoxColumn DutyTypeDutiesDetail;
        protected ITTListBoxColumn ExchangeTypeDutiesDetail;
        protected ITTTextBoxColumn DutyCostPriceDutiesDetail;
        protected ITTTabPage tttabpage9;
        protected ITTGrid ReagentCosts;
        protected ITTListBoxColumn ReagentTypeReagentDetail;
        protected ITTListBoxColumn ReagentSpeciesReagentDetail;
        protected ITTEnumComboBoxColumn ReagentSexReagentDetail;
        protected ITTTextBoxColumn ReagentWeightReagentDetail;
        protected ITTTextBoxColumn ReagentAmmountReagentDetail;
        protected ITTListBoxColumn datagridviewcolumn1;
        protected ITTTextBoxColumn ReagentPriceReagentDetail;
        protected ITTTabPage tttabpage5;
        protected ITTTabControl tttabcontrol4;
        protected ITTTabPage tttabpage13;
        protected ITTLabel labelPreWorkAimProjectPreAssement;
        protected ITTTextBox PreWorkAimProjectPreAssement;
        protected ITTTabPage tttabpage14;
        protected ITTLabel labelProjectAimProjectPreAssement;
        protected ITTTextBox ProjectAimProjectPreAssement;
        protected ITTTabPage tttabpage15;
        protected ITTLabel labelMaterialMethodProjectPreAssement;
        protected ITTTextBox MaterialMethodProjectPreAssement;
        protected ITTTabPage tttabpage16;
        protected ITTLabel labelProjectImportanceProjectPreAssement;
        protected ITTTextBox ProjectImportanceProjectPreAssement;
        protected ITTTabPage tttabpage17;
        protected ITTLabel labelResearcCenterDemandProjectPreAssement;
        protected ITTTextBox ResearcCenterDemandProjectPreAssement;
        protected ITTTabPage tttabpage18;
        protected ITTLabel labelSurgeryResearchCenterDemandProjectPreAssement;
        protected ITTTextBox SurgeryResearchCenterDemandProjectPreAssement;
        protected ITTTabPage tttabpage19;
        protected ITTLabel labelReagentSectionDemandProjectPreAssement;
        protected ITTTextBox ReagentSectionDemandProjectPreAssement;
        protected ITTTabPage tttabpage20;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel12;
        protected ITTLabel labelExperimentalTotalReagentCountProjectPreAssement;
        protected ITTTextBox ExperimentalTotalReagentCountProjectPreAssement;
        protected ITTLabel labelExperimentalRepeatCountProjectPreAssement;
        protected ITTTextBox ExperimentalRepeatCountProjectPreAssement;
        protected ITTLabel labelExperimantalReagentCountProjectPreAssement;
        protected ITTTextBox ExperimantalReagentCountProjectPreAssement;
        protected ITTTextBox ControllerTotalReagentCountProjectPreAssement;
        protected ITTTextBox ControllerRepeatCountProjectPreAssement;
        protected ITTTextBox ControllerReagentCountProjectPreAssement;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("bc2c1c05-5fc5-44fa-b144-aac20d16957d"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("62a2919c-b51a-4b22-b2ce-ab1fe30b2fae"));
            ConsumableMaterial = (ITTTextBox)AddControl(new Guid("d9153c1c-e132-4cd3-a1bf-ddae370a4288"));
            labelEthicCommisionApproveNo = (ITTLabel)AddControl(new Guid("6202d888-1929-4107-9814-9ae370cd5d8f"));
            EthicCommisionApproveNo = (ITTTextBox)AddControl(new Guid("93b568a2-9e01-4436-acf8-52b13484039a"));
            labelProjectInternationalName = (ITTLabel)AddControl(new Guid("723163b3-1214-487f-8ff7-033faad56db2"));
            ProjectInternationalName = (ITTTextBox)AddControl(new Guid("b33390c2-0c99-4cae-8fdb-2af32e58b479"));
            txtProjectStatus = (ITTTextBox)AddControl(new Guid("1af41e43-5da6-4035-936b-1b94d1cb4724"));
            ttpanel1 = (ITTPanel)AddControl(new Guid("74e1ce06-827b-4fa2-86ef-8922e874085a"));
            labelProjectConcumableMaterialCosts = (ITTLabel)AddControl(new Guid("ff08a1b4-641d-4c97-a1c8-d52b765eddd9"));
            labelProjectTotalCosts = (ITTLabel)AddControl(new Guid("e5d23b0c-2d8f-4e79-9ab6-10571a9cf350"));
            TotalConsumableCosts = (ITTTextBox)AddControl(new Guid("9479b0b1-656e-4629-bc08-775beeac8bcd"));
            TotalCosts = (ITTTextBox)AddControl(new Guid("52d5c46e-2e58-4778-8883-329dc4ef1010"));
            labelProjectReagentCosts = (ITTLabel)AddControl(new Guid("df3d0579-3e71-4649-a435-71552311e3e8"));
            TotalReagentCosts = (ITTTextBox)AddControl(new Guid("958e5f20-d14a-49b4-9b3b-82717d0296af"));
            labelProjectOtherCosts = (ITTLabel)AddControl(new Guid("14ad7a48-3e5e-496b-bd1e-e45f13979a04"));
            TotalOtherCosts = (ITTTextBox)AddControl(new Guid("46e01c53-a56d-464d-8a89-1907bb7b9165"));
            labelDutyCosts = (ITTLabel)AddControl(new Guid("8db51bcf-3aec-471d-96f8-a93efabb2cb3"));
            TotalDutyCosts = (ITTTextBox)AddControl(new Guid("f8cd0fa3-71ab-42a4-a076-1dec4b2a413a"));
            labelProjectStatus = (ITTLabel)AddControl(new Guid("eb933995-17ed-4e30-acb2-5bda6c3d596a"));
            ProjectDurationType = (ITTEnumComboBox)AddControl(new Guid("57eb0a9a-a38e-41c3-83f9-5166f266aad7"));
            labelProjectType = (ITTLabel)AddControl(new Guid("2e2da721-2f8b-470f-b93d-a548135c69f1"));
            ProjectType = (ITTObjectListBox)AddControl(new Guid("a273ec41-005d-4c71-b9cf-39e180400d6b"));
            labelProjectSpecies = (ITTLabel)AddControl(new Guid("64f89c35-7add-4e04-aa51-5a74a21c2e1c"));
            ProjectSpecies = (ITTObjectListBox)AddControl(new Guid("f6561407-0326-4845-ba6e-e11637776abd"));
            labelStartDate = (ITTLabel)AddControl(new Guid("efc61544-07b0-4c56-be42-086dc3229cb4"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("3e028e51-b233-4d3e-bd51-b08eab7b56e1"));
            labelProjectNo = (ITTLabel)AddControl(new Guid("a77136f3-e851-425f-845b-7c0e7c8b1ccd"));
            ProjectNo = (ITTTextBox)AddControl(new Guid("d22d0611-27c9-4173-9b67-621ebcc4c113"));
            labelProjectName = (ITTLabel)AddControl(new Guid("c0cbf7f9-f2b2-4dd5-986d-895c880de51e"));
            ProjectName = (ITTTextBox)AddControl(new Guid("0e23dbdb-610c-4c1e-b516-7c1f8b6ee5b4"));
            labelProjectDuration = (ITTLabel)AddControl(new Guid("2ba380ef-544d-43eb-a60c-469268990822"));
            ProjectDuration = (ITTTextBox)AddControl(new Guid("b404a358-b9d2-4e29-8ccb-81cff17459a3"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("71c7560d-70d5-4485-a3ce-786dabb81038"));
            labelNameMilitaryClassDefinitions = (ITTLabel)AddControl(new Guid("7bb6d79e-2f58-4a4e-b19e-5d50fbb9e8fe"));
            NameMilitaryClassDefinitions = (ITTTextBox)AddControl(new Guid("e113320c-3f2a-406e-8abf-4e9b6508c81f"));
            OwnerDepartment = (ITTObjectListBox)AddControl(new Guid("ff34078c-694f-42a4-a608-1b3bdf8e7c3d"));
            labelNameRankDefinitions = (ITTLabel)AddControl(new Guid("2751d9bc-bec9-47bc-be89-03ff9a471bc9"));
            labelOwnerDepartment = (ITTLabel)AddControl(new Guid("08bf39df-a353-4272-b00b-01f64df4e995"));
            NameRankDefinitions = (ITTTextBox)AddControl(new Guid("9d827326-3cf9-45bf-9043-c73719c3fd96"));
            labelIdentificationCardNoPerson = (ITTLabel)AddControl(new Guid("3226e13c-7f7b-4187-a296-f2220bf7cb91"));
            IdentificationCardNoPerson = (ITTTextBox)AddControl(new Guid("e9bcc778-bf70-4b65-8213-969203dc74e0"));
            labelBirthDatePerson = (ITTLabel)AddControl(new Guid("32aa6a1e-3948-4efc-9a0b-13a7bc8d2cd1"));
            BirthDatePerson = (ITTDateTimePicker)AddControl(new Guid("05522174-a174-436d-80de-18032afd4fda"));
            labelWorkPlaceResUser = (ITTLabel)AddControl(new Guid("34e10530-2de2-4cff-acdb-912510559c8f"));
            WorkPlaceResUser = (ITTTextBox)AddControl(new Guid("fa59545f-5879-4537-afe0-eff7b38f93ab"));
            labelWorkResUser = (ITTLabel)AddControl(new Guid("6dc84bcb-d420-414f-8149-978a494a49f3"));
            WorkResUser = (ITTTextBox)AddControl(new Guid("6a41c440-950a-46c5-ac29-df2edac1c42b"));
            labelPhoneNumberResUser = (ITTLabel)AddControl(new Guid("f1709307-0021-4d04-84aa-e0041f70c07e"));
            PhoneNumberResUser = (ITTTextBox)AddControl(new Guid("22cc0eb7-1129-48a9-8542-ea2c07f5e194"));
            labelProjectOwner = (ITTLabel)AddControl(new Guid("3507a772-4624-4d76-ac8a-ff8f871ae444"));
            ProjectOwner = (ITTObjectListBox)AddControl(new Guid("25e7fcc6-5291-48e9-9dc2-582248cb10b0"));
            labelPersonalCv = (ITTLabel)AddControl(new Guid("d658bfd8-0b2e-4016-98c7-b12f06752571"));
            PersonalCv = (ITTTextBox)AddControl(new Guid("1780941b-fba1-4527-83f8-7d90dc1bf665"));
            labelMobilTel = (ITTLabel)AddControl(new Guid("0c9e019a-0eac-4a08-b44e-5edb95bd347d"));
            MobilTel = (ITTTextBox)AddControl(new Guid("b4379402-dfe4-41ec-a680-53b8aa0acbce"));
            labelHomeTel = (ITTLabel)AddControl(new Guid("7196cd8b-0ca2-4deb-81a0-3d7f47163137"));
            HomeTel = (ITTTextBox)AddControl(new Guid("256d022b-278a-43b0-82e7-399905d19c43"));
            labelEmail = (ITTLabel)AddControl(new Guid("c587179b-9c60-4548-b94a-773f35537525"));
            Email = (ITTTextBox)AddControl(new Guid("9d807463-72a9-4a59-a383-8ef7c5e28099"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("736f9d62-e56c-431f-a17f-3bdcf482150c"));
            Participiants = (ITTGrid)AddControl(new Guid("c4e29291-f844-41b5-b81d-7815298664c5"));
            ProjectParticipiantParticipiants = (ITTListBoxColumn)AddControl(new Guid("38b44d13-96af-41c2-bf59-5602c131497f"));
            rank = (ITTTextBoxColumn)AddControl(new Guid("a4fa5d12-a7af-44d8-97ec-426b39516850"));
            title = (ITTTextBoxColumn)AddControl(new Guid("eca7000f-df80-4aa6-9403-5c1c1a02843b"));
            OwnerDepartmentParticipiants = (ITTListBoxColumn)AddControl(new Guid("8c87a6f7-9a4b-4b11-a8a9-6e9d7e7198c2"));
            BiographyParticipiants = (ITTTextBoxColumn)AddControl(new Guid("58089dfb-100b-4431-be69-466006b8160a"));
            tttabpage6 = (ITTTabPage)AddControl(new Guid("8eefee00-5558-4e7b-8569-ede768680729"));
            Journals = (ITTGrid)AddControl(new Guid("064f0a0f-b912-46f1-8ab5-a44c32397d64"));
            JournalProjectJournal = (ITTTextBoxColumn)AddControl(new Guid("bb234ec9-c15f-4a87-970d-7b44c50131e7"));
            AuthorNameProjectJournal = (ITTTextBoxColumn)AddControl(new Guid("0acd3394-9659-4c24-a5da-8bd3b7626c4c"));
            AuthorSurnameProjectJournal = (ITTTextBoxColumn)AddControl(new Guid("e64e241d-5ab3-4168-9d22-13b3bce41e89"));
            JournalTypeProjectJournal = (ITTListBoxColumn)AddControl(new Guid("16eb092f-9171-420a-8a7e-6e30a51d2f5f"));
            JournalDateProjectJournal = (ITTDateTimePickerColumn)AddControl(new Guid("3402dacb-9a4b-4854-87a4-36da2e8031e1"));
            JournalPlaceProjectJournal = (ITTTextBoxColumn)AddControl(new Guid("727351bd-e7a0-40c4-add8-a9b81a1d15df"));
            JournalTextProjectJournal = (ITTTextBoxColumn)AddControl(new Guid("f01d5a63-832a-4041-9799-6c0c8d7f8d9a"));
            tttabpage10 = (ITTTabPage)AddControl(new Guid("fc09511c-495a-4fbc-b6b4-ffcd30ee0b3f"));
            Awards = (ITTGrid)AddControl(new Guid("d9ffb9e8-8148-471c-acb2-434fc2b8758d"));
            AwardProjectAward = (ITTTextBoxColumn)AddControl(new Guid("ab089965-9ef3-4c28-82ac-8c227907db75"));
            GivingAuthorityProjectAward = (ITTTextBoxColumn)AddControl(new Guid("de4ca0d0-c0d6-4060-b9f2-3fd46409d8b2"));
            PriceProjectAward = (ITTTextBoxColumn)AddControl(new Guid("1ce9a9c5-9ae0-435b-bdb6-461121292d8c"));
            WhyGivedProjectAward = (ITTTextBoxColumn)AddControl(new Guid("85047f30-9037-4e61-80b7-5447920dbc97"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("351c3d4d-b01e-4522-9b43-c566edbfadab"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("14edba61-f7ab-4c69-99ec-3a399e4da028"));
            tttabcontrol3 = (ITTTabControl)AddControl(new Guid("fbaa81e9-28dd-4c3d-bb65-ad92a26417f7"));
            tttabpage7 = (ITTTabPage)AddControl(new Guid("a7e40bfc-60ea-4a0e-855a-17f31b45db7b"));
            gridOtherCost = (ITTGrid)AddControl(new Guid("c126fef8-27c0-4b75-9f81-e9796bddaac7"));
            OtherCostNameOtherCostDetail = (ITTTextBoxColumn)AddControl(new Guid("23348b03-b5f5-42ad-b166-6fc03826a307"));
            ExchangeTypeOtherCostDetail = (ITTListBoxColumn)AddControl(new Guid("effb17d8-4999-4fd0-b46d-eb53dada1007"));
            OtherCostPriceOtherCostDetail = (ITTTextBoxColumn)AddControl(new Guid("a6f2f6a5-2a73-4809-b8d6-cdc9f15263be"));
            tttabpage8 = (ITTTabPage)AddControl(new Guid("0366ad23-12c5-4c34-8504-e92e3cd3a65a"));
            gridDutyCost = (ITTGrid)AddControl(new Guid("faca2ad5-41a0-406d-acce-febdf5d82c34"));
            DutyCostNameDutiesDetail = (ITTTextBoxColumn)AddControl(new Guid("e9d29f26-ed20-44e6-bb61-2c467ed6090c"));
            DutyTypeDutiesDetail = (ITTListBoxColumn)AddControl(new Guid("41275146-10e3-443c-adef-5c436adc11af"));
            ExchangeTypeDutiesDetail = (ITTListBoxColumn)AddControl(new Guid("cc7d3722-669b-45e1-aaa5-1b71b9a3d956"));
            DutyCostPriceDutiesDetail = (ITTTextBoxColumn)AddControl(new Guid("3cbba3a7-b3aa-47e1-882b-5620c9d251e3"));
            tttabpage9 = (ITTTabPage)AddControl(new Guid("a8a82c44-9c54-4dc6-910d-ef4c07569943"));
            ReagentCosts = (ITTGrid)AddControl(new Guid("1bd50b2d-426b-487e-9afd-70bf511a4071"));
            ReagentTypeReagentDetail = (ITTListBoxColumn)AddControl(new Guid("8d090d05-9749-4c49-8dde-98765d935b36"));
            ReagentSpeciesReagentDetail = (ITTListBoxColumn)AddControl(new Guid("8e8712ab-bf64-4ca8-9dc1-37ab15a9fbf5"));
            ReagentSexReagentDetail = (ITTEnumComboBoxColumn)AddControl(new Guid("46be1fb7-ea3f-4284-83d8-e112d6b820d4"));
            ReagentWeightReagentDetail = (ITTTextBoxColumn)AddControl(new Guid("21764ff7-0050-4446-9f9d-60d2302d82bc"));
            ReagentAmmountReagentDetail = (ITTTextBoxColumn)AddControl(new Guid("cc6dcf07-5be8-467f-898f-4d6e72538de2"));
            datagridviewcolumn1 = (ITTListBoxColumn)AddControl(new Guid("83c6e684-010c-4d8d-9aa9-b5ce122031db"));
            ReagentPriceReagentDetail = (ITTTextBoxColumn)AddControl(new Guid("b54a2b37-4f80-4582-998d-da4667260fea"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("87b46b62-2f9a-4504-8679-db061c3bc3e7"));
            tttabcontrol4 = (ITTTabControl)AddControl(new Guid("0ea79367-a576-431c-ba2c-506379eb55e4"));
            tttabpage13 = (ITTTabPage)AddControl(new Guid("4ec80bf2-116d-4b24-976b-65f6d7295b7b"));
            labelPreWorkAimProjectPreAssement = (ITTLabel)AddControl(new Guid("abf4f165-6acc-47c5-bb60-91bb1a4fff2c"));
            PreWorkAimProjectPreAssement = (ITTTextBox)AddControl(new Guid("51dc3e01-47e0-4044-af5b-995b3746fc0e"));
            tttabpage14 = (ITTTabPage)AddControl(new Guid("747c08f6-8deb-4c0b-a51c-96174d68def5"));
            labelProjectAimProjectPreAssement = (ITTLabel)AddControl(new Guid("055f0b43-df38-45e2-93d9-5bf691e943f7"));
            ProjectAimProjectPreAssement = (ITTTextBox)AddControl(new Guid("d11960e2-f677-4082-a213-f6c6ff06e6f3"));
            tttabpage15 = (ITTTabPage)AddControl(new Guid("25da87c9-6b3f-48b3-9685-ec9e0a46fb9f"));
            labelMaterialMethodProjectPreAssement = (ITTLabel)AddControl(new Guid("cffda6be-76e7-44d6-81fc-f8cddd9486a1"));
            MaterialMethodProjectPreAssement = (ITTTextBox)AddControl(new Guid("00f443ff-5506-4dcc-bff1-da2b38bd9987"));
            tttabpage16 = (ITTTabPage)AddControl(new Guid("7ae942f6-a6a2-43c9-ad2e-82b8fba51e5f"));
            labelProjectImportanceProjectPreAssement = (ITTLabel)AddControl(new Guid("3d7128fc-39c7-4231-8bce-bfabe97fd4ab"));
            ProjectImportanceProjectPreAssement = (ITTTextBox)AddControl(new Guid("099a2ec3-6b3b-489a-8b1a-c0e1ed17c7d0"));
            tttabpage17 = (ITTTabPage)AddControl(new Guid("c37cc41d-af6e-4fa3-ba17-20d40b2137ac"));
            labelResearcCenterDemandProjectPreAssement = (ITTLabel)AddControl(new Guid("69c77a98-b378-4938-a59b-04aa3176fccd"));
            ResearcCenterDemandProjectPreAssement = (ITTTextBox)AddControl(new Guid("81ded117-bd1c-42a2-a446-edce21ae182d"));
            tttabpage18 = (ITTTabPage)AddControl(new Guid("80bb2214-953e-4ef4-966c-650da4b5bdef"));
            labelSurgeryResearchCenterDemandProjectPreAssement = (ITTLabel)AddControl(new Guid("bf026f7d-5249-4531-ba51-606b9dd50f0c"));
            SurgeryResearchCenterDemandProjectPreAssement = (ITTTextBox)AddControl(new Guid("a5d82210-aacc-4dfd-9911-b7a465b2d076"));
            tttabpage19 = (ITTTabPage)AddControl(new Guid("a296264b-6115-45bc-894a-cb5a46c5817b"));
            labelReagentSectionDemandProjectPreAssement = (ITTLabel)AddControl(new Guid("17372809-3a98-41f8-9a06-d8326438f2f6"));
            ReagentSectionDemandProjectPreAssement = (ITTTextBox)AddControl(new Guid("1439917a-62b5-4b5a-b2ca-4dc01c228259"));
            tttabpage20 = (ITTTabPage)AddControl(new Guid("c443f705-6c7f-4caf-a741-d99de7ba13e0"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("c514857c-10a2-483f-9a15-a677330c2dc2"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("680fbff4-c9c7-49f5-90c7-f82cd53b9794"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("d6a08a45-0947-4166-a72e-fe7b97fb3b16"));
            labelExperimentalTotalReagentCountProjectPreAssement = (ITTLabel)AddControl(new Guid("fb5764ed-a2d7-4855-83cb-c47219379dd0"));
            ExperimentalTotalReagentCountProjectPreAssement = (ITTTextBox)AddControl(new Guid("4c4d0245-f4c2-4b72-afa6-9d47cb69cbaa"));
            labelExperimentalRepeatCountProjectPreAssement = (ITTLabel)AddControl(new Guid("ac8b0b5e-f8ca-4b20-940c-71eb88c39139"));
            ExperimentalRepeatCountProjectPreAssement = (ITTTextBox)AddControl(new Guid("9a75ecc1-58ef-41c1-86f6-9d6b648d17c2"));
            labelExperimantalReagentCountProjectPreAssement = (ITTLabel)AddControl(new Guid("e0251d47-2590-4f13-9571-b307753f567c"));
            ExperimantalReagentCountProjectPreAssement = (ITTTextBox)AddControl(new Guid("32e5c269-0175-41f8-a101-f31db510ce50"));
            ControllerTotalReagentCountProjectPreAssement = (ITTTextBox)AddControl(new Guid("4f59e341-cb44-4cca-b1d9-6d53223be9f2"));
            ControllerRepeatCountProjectPreAssement = (ITTTextBox)AddControl(new Guid("d585b210-beda-489b-a5a7-cc0782b8a0a5"));
            ControllerReagentCountProjectPreAssement = (ITTTextBox)AddControl(new Guid("0bd97b95-bfb5-4561-9fd8-999e946d978c"));
            base.InitializeControls();
        }

        public ArgeProjectNewForm() : base("ARGEPROJECT", "ArgeProjectNewForm")
        {
        }

        protected ArgeProjectNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}