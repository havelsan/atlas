
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
    /// Üç Uzman Tabip İmzalı Rapor
    /// </summary>
    public partial class HCTSApprovalForm : EpisodeActionForm
    {
    /// <summary>
    /// Üç Uzman Tabip İmzalı Rapor  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.HealthCommitteeWithThreeSpecialist _HealthCommitteeWithThreeSpecialist
        {
            get { return (TTObjectClasses.HealthCommitteeWithThreeSpecialist)_ttObject; }
        }

        protected ITTTabControl tttabcontrolMain;
        protected ITTTabPage tttabpageHCT;
        protected ITTDateTimePicker ReportDate;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel11;
        protected ITTLabel labelReasonForExamination;
        protected ITTGrid SpecialistsGrid;
        protected ITTListBoxColumn Specialist1;
        protected ITTListBoxColumn ResSectionOfSpecialist2;
        protected ITTListBoxColumn Specialist2;
        protected ITTListBoxColumn ResSectionOfSpecialist3;
        protected ITTListBoxColumn Specialist3;
        protected ITTLabel labelUnitsHospitals;
        protected ITTObjectListBox AdditionalSpecialist2;
        protected ITTObjectListBox ReasonForExamination;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox AdditionalSpecialist1;
        protected ITTTextBox tttextboxClinicReportNo;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox SecondAdditionalUnit;
        protected ITTEnumComboBox PatientGroup;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelReasonForAdmission;
        protected ITTObjectListBox FirstAdditionalUnit;
        protected ITTEnumComboBox PatientStatus;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTTextBox ProtocolNo;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage EpisodeDiagnosisTab;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTTextBoxColumn EpisodeFreeDiagnosis;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabPage DiagnosisEntryTab;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn SecAddToHistory;
        protected ITTListBoxColumn SecDiagnose;
        protected ITTTextBoxColumn SecFreeDiagnosis;
        protected ITTCheckBoxColumn SecIsMainDiagnose;
        protected ITTListBoxColumn SecResponsibleUser;
        protected ITTDateTimePickerColumn SecDiagnoseDate;
        protected ITTTabPage tttabpageReport;
        protected ITTTabControl tabReport;
        protected ITTTabPage Report;
        protected ITTLabel labelHCDecisionCategory;
        protected ITTObjectListBox HCDecisionCategory;
        protected ITTLabel labelHealthCommitteeDecision;
        protected ITTObjectListBox lstHealthCommitteeDecision;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTabPage Description;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTTabPage Material;
        protected ITTDateTimePicker ReportEndDate;
        protected ITTDateTimePicker ReportStartDate;
        protected ITTLabel lblReportEndDate;
        protected ITTLabel lblReportStartDate;
        protected ITTTabPage Rest;
        protected ITTLabel ttlabel19;
        protected ITTEnumComboBox RestReportDecision;
        protected ITTDateTimePicker DecisionDate;
        protected ITTDateTimePicker EndDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel ttlabel15;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel13;
        protected ITTTabPage InformOneDoctor;
        protected ITTTextBox NoObstacleDescription;
        protected ITTEnumComboBox SituationInformODDecision;
        protected ITTEnumComboBox SituationInformODReportType;
        protected ITTLabel ttlabel18;
        protected ITTLabel ttlabel17;
        protected ITTLabel ttlabel16;
        protected ITTGrid ttgrid1;
        protected ITTTextBoxColumn Matter;
        protected ITTEnumComboBoxColumn Slice;
        protected ITTTextBoxColumn Anectode;
        protected ITTTabPage tttabpagePI;
        protected ITTTextBox Adres;
        protected ITTGroupBox ttgroupbox2;
        protected ITTLabel ttlabel8;
        protected ITTLabel labelFatherName;
        protected ITTTextBox FatherName;
        protected ITTDateTimePicker BirthDate;
        protected ITTLabel labelBirthDate;
        protected ITTObjectListBox TownOfBirth;
        protected ITTLabel labelCityOfBirth;
        protected ITTObjectListBox CityOfBirth;
        protected ITTLabel labelBirthPlaceCountry;
        protected ITTLabel labelTownOfBirth;
        protected ITTObjectListBox CountryOfBirth;
        protected ITTTextBox tttextboxTCNo;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel labelBirlik;
        protected ITTObjectListBox MilitaryClass;
        protected ITTLabel labelMilitaryClass;
        protected ITTObjectListBox Rank;
        protected ITTLabel labelRank;
        protected ITTTextBox EmploymentRecordID;
        protected ITTLabel labelRegistryNo;
        override protected void InitializeControls()
        {
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("be086b4c-a9dd-4635-828e-65a8d0b207c6"));
            tttabpageHCT = (ITTTabPage)AddControl(new Guid("38355ae4-b8a6-427c-921d-5d68b8d6d294"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("6ea44b49-0720-42c8-af7f-6e46ee4f4e4f"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("dd353679-6762-4451-a2f5-bc13e03a69d8"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("1d756b0b-7049-4b1f-8090-018a794698c0"));
            labelReasonForExamination = (ITTLabel)AddControl(new Guid("fc366cb7-ba61-4376-a2d9-c3305b3d290d"));
            SpecialistsGrid = (ITTGrid)AddControl(new Guid("073c5806-ec34-478f-9a41-eb6687707bb7"));
            Specialist1 = (ITTListBoxColumn)AddControl(new Guid("b37dca39-77e7-4c54-91ee-721102d15558"));
            ResSectionOfSpecialist2 = (ITTListBoxColumn)AddControl(new Guid("8cd2d442-f19a-4043-8aab-6027a494f7ba"));
            Specialist2 = (ITTListBoxColumn)AddControl(new Guid("89f051e1-936c-428c-8662-add4f86382ff"));
            ResSectionOfSpecialist3 = (ITTListBoxColumn)AddControl(new Guid("f81f052e-f881-4051-bbe2-e708c5f67ed5"));
            Specialist3 = (ITTListBoxColumn)AddControl(new Guid("63c01a97-0b4b-4e7c-8983-4989cd7b13ec"));
            labelUnitsHospitals = (ITTLabel)AddControl(new Guid("2148737f-4304-4660-be75-7ea5b665bdb6"));
            AdditionalSpecialist2 = (ITTObjectListBox)AddControl(new Guid("47677608-c951-46b6-87b1-54c541ffd7ad"));
            ReasonForExamination = (ITTObjectListBox)AddControl(new Guid("40886baa-0cce-4676-87df-d3ab3c56ccbc"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("46d47ac8-d4ed-4e60-8402-747726d949f0"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("7c628bd8-f220-4bcd-b2b2-e3877b5037a1"));
            AdditionalSpecialist1 = (ITTObjectListBox)AddControl(new Guid("8d6aa9ad-b484-463d-8915-fda569a66ef0"));
            tttextboxClinicReportNo = (ITTTextBox)AddControl(new Guid("36cd82ad-5c39-4fa9-b190-f285d6e2b053"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("2be64dfb-dcc9-46ce-830a-28645bc74124"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("3890b1bc-32e6-4dea-9c7a-81d3c649bfbd"));
            SecondAdditionalUnit = (ITTObjectListBox)AddControl(new Guid("14ae338a-a47e-4e01-aa70-cb9d554ebda0"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("6bcfc830-5a5f-49d6-a8e9-19b8d28fedcf"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("b9400973-4a72-41c8-acfd-07cd9b2e9dd0"));
            labelReasonForAdmission = (ITTLabel)AddControl(new Guid("9a995c21-2ba7-44ed-9b77-fd754cc0f543"));
            FirstAdditionalUnit = (ITTObjectListBox)AddControl(new Guid("654ff1d3-4b52-4d3b-a83e-6a500e9900d4"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("fe1e7d08-65a5-4f1e-977a-c7f99ee8ad43"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0388f453-b4e8-4d97-9358-245b3b5654a3"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("5281a2c4-eab5-4767-a135-c4cce76136ef"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("2d10f13a-8006-424c-9e61-52e3af192ed7"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("357808fb-77d6-42c3-a3fd-8cab1249d762"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("ec340b6c-0f5b-4a2b-b5d4-8a87a0370081"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("8c3c941c-5011-4951-8a4d-afce4e369699"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("e9e29939-fec0-4585-95b1-d4c21807a5e0"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("da838b68-0a64-45f9-a83c-e55d5e073179"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("d73762cf-a008-42f4-8387-d76062b5784e"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("f142e775-3022-4698-ab32-36d36be79a1e"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("3440a049-6729-4656-8abb-9c7ff54800f8"));
            EpisodeFreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("b076aafa-ee0d-4369-aa00-3d6e09f7a2be"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("53a72b13-6aa1-4c88-8033-46bb9794f91f"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("2a9a663c-b2ba-4184-bad3-d1848be2dd60"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("8dc8f934-28e1-4dca-ab9c-a6924774a9e1"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("bf44d0da-1994-4184-b0c6-71bebf393b98"));
            DiagnosisEntryTab = (ITTTabPage)AddControl(new Guid("74a0d53a-3cb1-4a2f-bf91-aaa50fd8b171"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("82af639c-232e-477d-b938-faf64c251811"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("69392c0b-2476-48e2-8378-0780859a71dc"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("43d875bf-168a-47bf-a325-7b7908613571"));
            SecFreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("c51a6103-25a1-4e80-8d71-42f8e1b108a1"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("68ad5e63-1c04-4595-a197-0c827ac8facc"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("a9e79fb1-6f54-43c2-828f-c1a2ed7247b6"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("9450f195-8d52-4f04-8ff2-c67e7ce60ae3"));
            tttabpageReport = (ITTTabPage)AddControl(new Guid("79ba6e29-aa58-4f5a-ab1b-e64b6186f6cb"));
            tabReport = (ITTTabControl)AddControl(new Guid("185f99cb-0635-4c51-8ca7-6d90cb5bedb4"));
            Report = (ITTTabPage)AddControl(new Guid("80613aff-23df-4415-b506-4872e0f7f4ba"));
            labelHCDecisionCategory = (ITTLabel)AddControl(new Guid("4c570c61-39f9-49a3-836e-c1d86dbeb117"));
            HCDecisionCategory = (ITTObjectListBox)AddControl(new Guid("cf6e8cd0-075c-43c8-b32e-e392dd15f7b5"));
            labelHealthCommitteeDecision = (ITTLabel)AddControl(new Guid("e8e21c92-d9b5-46b7-aeb2-bd302c26c42c"));
            lstHealthCommitteeDecision = (ITTObjectListBox)AddControl(new Guid("7767a07c-11fc-4297-99c8-bdcb12af2a63"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("abd7e442-a8a9-43a1-a592-f056409be34e"));
            Description = (ITTTabPage)AddControl(new Guid("ffbd42bb-c6ea-410e-81a9-9fb2dd8bf215"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("53f727c7-3ed8-4635-ab31-5d74cb6a33d5"));
            Material = (ITTTabPage)AddControl(new Guid("aa9750a8-107b-44fc-b164-6054df08c1a5"));
            ReportEndDate = (ITTDateTimePicker)AddControl(new Guid("706977b1-0173-4b5b-88ef-9286f820e015"));
            ReportStartDate = (ITTDateTimePicker)AddControl(new Guid("a59e1416-b4ac-404e-b0f1-ba00a4242299"));
            lblReportEndDate = (ITTLabel)AddControl(new Guid("ce5bdcaa-1d06-4ccb-9305-7a9a0c5cfac1"));
            lblReportStartDate = (ITTLabel)AddControl(new Guid("00d988bb-c0a9-44fc-9b22-84e24705a3f8"));
            Rest = (ITTTabPage)AddControl(new Guid("ecbf62a3-e880-4ef2-b7d7-76a26b8aaee2"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("22ecd713-c6e8-4ce0-a0b5-c57a3fe2f787"));
            RestReportDecision = (ITTEnumComboBox)AddControl(new Guid("91df0a2c-2280-47b9-9863-64a048c8b10f"));
            DecisionDate = (ITTDateTimePicker)AddControl(new Guid("ffe86dad-6a69-4f68-a458-4ba5054150cd"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("33a51d72-e369-4f41-9eee-b86a60eee048"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("7be87cbf-5355-485d-864e-6da4f959f617"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("fa879cd9-4c0a-4990-ae6a-83a521533686"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("8c9dac89-1502-4c3e-a3e1-2c069e4dec44"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("e4f08754-ce94-4f77-8381-0101b3d7ed45"));
            InformOneDoctor = (ITTTabPage)AddControl(new Guid("9dbb1153-9789-4b2e-8b3b-314b36854731"));
            NoObstacleDescription = (ITTTextBox)AddControl(new Guid("bd0d9f8d-f870-489b-a2ac-294a1ff91ed7"));
            SituationInformODDecision = (ITTEnumComboBox)AddControl(new Guid("afde25bd-69fb-4bfe-9d8d-469ee8088c83"));
            SituationInformODReportType = (ITTEnumComboBox)AddControl(new Guid("678552ef-f090-43b8-a366-f1457e83a8e7"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("1227249d-24ca-409a-bc93-250f2ad3865d"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("0a72dc0a-5ea7-4f52-ae71-fda757f20f30"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("3000c7c0-ec28-446e-a5d6-b4e04578073f"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("9dde7e80-9d6b-44f8-b8fa-040a672ecfcc"));
            Matter = (ITTTextBoxColumn)AddControl(new Guid("c6d4ed06-4a71-4d7e-b4d3-52bfb3adce21"));
            Slice = (ITTEnumComboBoxColumn)AddControl(new Guid("1524cc42-3ea7-4d38-ad5c-074af6fa845c"));
            Anectode = (ITTTextBoxColumn)AddControl(new Guid("5c3dff03-32dd-4978-814d-3d63618df9a7"));
            tttabpagePI = (ITTTabPage)AddControl(new Guid("a8f67681-0cc7-4e91-b85b-ac7dd90a8a3b"));
            Adres = (ITTTextBox)AddControl(new Guid("b3b87ced-7bd5-40b7-b85d-c023aad89a82"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("44d20ba6-7e46-4b3b-bb8f-dd50d31b3b81"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("77b2d079-04ff-412b-a543-2c171eef560e"));
            labelFatherName = (ITTLabel)AddControl(new Guid("627c9829-2f3f-485b-b34f-7b6aece98e8f"));
            FatherName = (ITTTextBox)AddControl(new Guid("d40166b4-4045-4de2-be6e-3c91dc148d0b"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("e69c3445-2466-4ae0-8782-913d63a9e28c"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("4f8725c7-a3c0-48af-900c-34aa453ee392"));
            TownOfBirth = (ITTObjectListBox)AddControl(new Guid("651f40f0-a74f-45f3-a468-4a76e4c8b985"));
            labelCityOfBirth = (ITTLabel)AddControl(new Guid("46b38bc2-93c6-43af-8705-eaaaa3245934"));
            CityOfBirth = (ITTObjectListBox)AddControl(new Guid("08e371b4-24e0-4659-bfdd-d026464c3837"));
            labelBirthPlaceCountry = (ITTLabel)AddControl(new Guid("cd528f10-9dc8-4140-a8bd-047e58ba0ad7"));
            labelTownOfBirth = (ITTLabel)AddControl(new Guid("e3b4e511-6709-47b7-ad2f-9325c353847d"));
            CountryOfBirth = (ITTObjectListBox)AddControl(new Guid("4cb880a7-1cc3-4486-a41f-606ded394380"));
            tttextboxTCNo = (ITTTextBox)AddControl(new Guid("5fa3cf49-97f4-4f37-9e7c-71fd8f7f51b7"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("69893089-b9ea-426c-a8de-cb51e29be2d2"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("cecd0a17-5978-4e03-a4f8-a02d972f4a1d"));
            labelBirlik = (ITTLabel)AddControl(new Guid("eeadf4bb-8bc9-4517-a8c0-187655523ceb"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("4df107eb-01d5-4a63-a2f9-986fa9113da7"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("8510d773-6347-453e-9020-1e6dc1ba961d"));
            Rank = (ITTObjectListBox)AddControl(new Guid("5dab7785-977d-435a-bb5c-a7d3a7ec5c92"));
            labelRank = (ITTLabel)AddControl(new Guid("49ee3226-9451-452c-a6f2-57130b600d84"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("d171ccc8-6f61-426f-a026-c9bc75d14637"));
            labelRegistryNo = (ITTLabel)AddControl(new Guid("881dc437-3b54-46b3-abd8-8c8725d91d83"));
            base.InitializeControls();
        }

        public HCTSApprovalForm() : base("HEALTHCOMMITTEEWITHTHREESPECIALIST", "HCTSApprovalForm")
        {
        }

        protected HCTSApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}