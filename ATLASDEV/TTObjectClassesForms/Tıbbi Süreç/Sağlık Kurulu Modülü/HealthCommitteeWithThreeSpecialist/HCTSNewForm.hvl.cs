
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
    public partial class HCTSNewForm : EpisodeActionForm
    {
    /// <summary>
    /// Üç Uzman Tabip İmzalı Rapor  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.HealthCommitteeWithThreeSpecialist _HealthCommitteeWithThreeSpecialist
        {
            get { return (TTObjectClasses.HealthCommitteeWithThreeSpecialist)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpageHTC;
        protected ITTLabel ttlblMedulaRaporTakipNo;
        protected ITTTextBox tttxtboxMedulaRaporTakipNo;
        protected ITTDateTimePicker ReportDate;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox AdditionalSpecialist2;
        protected ITTLabel ttlabel10;
        protected ITTObjectListBox AdditionalSpecialist1;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox SecondAdditionalUnit;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox FirstAdditionalUnit;
        protected ITTLabel ttlabel2;
        protected ITTGrid ReturnDescriptionsGrid;
        protected ITTDateTimePickerColumn EntryDate;
        protected ITTTextBoxColumn ReturnDescription;
        protected ITTTextBoxColumn UserOwner;
        protected ITTObjectListBox ttobjectlistboxDepartment;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextboxReturnDescription;
        protected ITTLabel ttlabelReturnDescription;
        protected ITTGrid SpecialistsGrid;
        protected ITTListBoxColumn Specialist1;
        protected ITTListBoxColumn ResSectionOfSpecialist2;
        protected ITTListBoxColumn Specialist2;
        protected ITTListBoxColumn ResSectionOfSpecialist3;
        protected ITTListBoxColumn Specialist3;
        protected ITTLabel ttlabel3;
        protected ITTEnumComboBox PatientGroup;
        protected ITTLabel labelReasonForAdmission;
        protected ITTTextBox NumberOfProcess;
        protected ITTLabel ttlabel5;
        protected ITTEnumComboBox PatientStatus;
        protected ITTLabel ttlabel12;
        protected ITTLabel labelReasonForExamination;
        protected ITTObjectListBox ReasonForExamination;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTLabel labelUnitsHospitals;
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
        protected ITTLabel lblReportEndDate;
        protected ITTLabel lblReportStartDate;
        protected ITTDateTimePicker ReportEndDate;
        protected ITTDateTimePicker ReportStartDate;
        protected ITTTabPage Rest;
        protected ITTLabel ttlabel13;
        protected ITTEnumComboBox RestReportDecision;
        protected ITTLabel lblRestReport3;
        protected ITTDateTimePicker DecisionDate;
        protected ITTDateTimePicker EndDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel lblRestReport2;
        protected ITTLabel lblRestReport1;
        protected ITTTabPage InformOneDoctor;
        protected ITTTextBox NoObstacleDescription;
        protected ITTLabel lblNoObstacleDescription;
        protected ITTEnumComboBox SituationInformODDecision;
        protected ITTLabel ttlabel11;
        protected ITTEnumComboBox SituationInformODReportType;
        protected ITTLabel lblReason;
        protected ITTGrid ttgrid1;
        protected ITTTextBoxColumn Matter;
        protected ITTEnumComboBoxColumn Slice;
        protected ITTTextBoxColumn Anectode;
        protected ITTTabPage tttabpagePI;
        protected ITTTextBox Adres;
        protected ITTLabel ttlabel8;
        protected ITTGroupBox ttgroupbox2;
        protected ITTLabel ttlabel15;
        protected ITTLabel ttlabel16;
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
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("ae34bc22-4023-47d0-bb29-b6383e6128e0"));
            tttabpageHTC = (ITTTabPage)AddControl(new Guid("df9fa753-98f2-4209-9744-5ef6a6a3fe1e"));
            ttlblMedulaRaporTakipNo = (ITTLabel)AddControl(new Guid("e84ffe87-20eb-4526-85db-e1251576923c"));
            tttxtboxMedulaRaporTakipNo = (ITTTextBox)AddControl(new Guid("705446c3-7a31-406e-aa48-cffa5e546a73"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("094c1694-a3c6-4824-aac6-c257a885694e"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("af58ae18-8238-46d0-98e3-2d80806ab00d"));
            AdditionalSpecialist2 = (ITTObjectListBox)AddControl(new Guid("c5bf90cb-3c35-435b-b16c-0ddbb596861b"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("395f0dd0-e49b-43e5-928e-9eb27b5e251c"));
            AdditionalSpecialist1 = (ITTObjectListBox)AddControl(new Guid("c31d9ba9-7354-41ca-8720-6087627959c9"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("fa90f6d2-9da7-43d2-b5f5-56abda4a6c82"));
            SecondAdditionalUnit = (ITTObjectListBox)AddControl(new Guid("55f7f732-8078-4ef4-a587-ec4b77901340"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("c2e535e3-13fd-4400-af1e-312b46c43a04"));
            FirstAdditionalUnit = (ITTObjectListBox)AddControl(new Guid("eeaa9249-afad-4ac2-9599-62ee9012e359"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("84b9cafd-1852-4f28-a8c2-a4cb48765343"));
            ReturnDescriptionsGrid = (ITTGrid)AddControl(new Guid("b55ef1cb-ff7a-4669-8591-b9f9dd9add27"));
            EntryDate = (ITTDateTimePickerColumn)AddControl(new Guid("884b518e-c1bf-4175-bd37-897c7c4c7b2f"));
            ReturnDescription = (ITTTextBoxColumn)AddControl(new Guid("22eca544-dc99-4f35-b908-878a50051d4f"));
            UserOwner = (ITTTextBoxColumn)AddControl(new Guid("ebb2e5a1-aed2-4943-a753-50ce3f88c679"));
            ttobjectlistboxDepartment = (ITTObjectListBox)AddControl(new Guid("ea949047-0ff2-47d9-afea-33be37a71720"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b25c7444-9a26-4320-960a-73c8dc437368"));
            tttextboxReturnDescription = (ITTTextBox)AddControl(new Guid("c534ac0d-7c9e-447b-a01f-6776046c3af9"));
            ttlabelReturnDescription = (ITTLabel)AddControl(new Guid("90b0ff4f-3e18-4483-b9f1-cc323adb53f6"));
            SpecialistsGrid = (ITTGrid)AddControl(new Guid("34a16bf4-8743-4802-b5d5-9ab8387c514d"));
            Specialist1 = (ITTListBoxColumn)AddControl(new Guid("1dae8f2e-91e9-4373-acfa-62b655ed439c"));
            ResSectionOfSpecialist2 = (ITTListBoxColumn)AddControl(new Guid("919ecef5-511a-4a05-80a2-51abb8263d69"));
            Specialist2 = (ITTListBoxColumn)AddControl(new Guid("068b7a4b-52d6-4560-9d8a-acdda00a1d57"));
            ResSectionOfSpecialist3 = (ITTListBoxColumn)AddControl(new Guid("f7ec8aca-d3ba-4fda-a82e-9191064531e2"));
            Specialist3 = (ITTListBoxColumn)AddControl(new Guid("d34409ef-bf48-4a50-aa29-8c4ebb3b12fa"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("d4f37262-ab79-4c09-87fb-99ec79fe7126"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("f48f9f83-a4bb-4d12-b4c4-fe3dcb9c9dc2"));
            labelReasonForAdmission = (ITTLabel)AddControl(new Guid("c1029a4e-7d36-4e0b-af7c-18b8a2e9149a"));
            NumberOfProcess = (ITTTextBox)AddControl(new Guid("e2646a43-93ce-41ea-9b5c-4264e7a549ab"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("14574286-95e0-452b-a509-6bd207196458"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("a2497f6e-0ec3-4b43-803d-aac4fc8916ba"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("74304b12-eec4-46e7-9852-6ffeb260731e"));
            labelReasonForExamination = (ITTLabel)AddControl(new Guid("b88bcc99-c41d-47ad-a203-94e1b93ea7e7"));
            ReasonForExamination = (ITTObjectListBox)AddControl(new Guid("25d0bb07-df36-44c8-8d73-93b1858854ad"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("fc3d9d55-94ab-48cd-b4da-7ca17dfa4cc1"));
            labelUnitsHospitals = (ITTLabel)AddControl(new Guid("1acb9167-73b2-4716-8676-898ce8346a0b"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("d0170681-f08e-47c3-8ac8-cd6f048cd7f4"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("51980154-1f1e-4111-b9e4-7d23169e59d2"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("2c8bad84-4017-45fd-b25a-7061bc0ff60c"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("eb6bf5a1-de04-4896-b403-a6fd53c31422"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("1c9d7933-c2ab-4ce7-b6c5-beb2967fa686"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("3d9fdf55-c985-4dc9-9408-0a363e45c4e7"));
            EpisodeFreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("a2c160c0-dba1-4446-85f7-d17847bc3402"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("3d529dda-023a-4b9c-900d-be6be5594eef"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("dd9fce00-a6cf-4ac2-afaf-be8853222f23"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("95aead98-78f0-4a92-8133-9c4edce524f2"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("b7a29e50-1e91-4470-a420-a8033a4fe360"));
            DiagnosisEntryTab = (ITTTabPage)AddControl(new Guid("3aa9f632-2076-44d0-ac83-337829f858f9"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("de3c279c-e373-4231-bc88-52cd71008427"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("6b4b6644-2f40-4f95-bd48-07496b0f704a"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("8bd038a1-55b7-40ed-9a36-8cca005e16e0"));
            SecFreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("8730c4c4-150e-4e91-984f-b4bed3721c7d"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("1cbf9498-4367-40e2-abd2-37ae0a3e8ff8"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("72ec453a-d98b-444f-8e86-056b91f2c463"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("2fea45f3-fb16-4fa0-892f-60e4134219bc"));
            tttabpageReport = (ITTTabPage)AddControl(new Guid("fae3764c-d926-46e8-8747-7bde64bd4ab9"));
            tabReport = (ITTTabControl)AddControl(new Guid("b86a24d4-e979-4432-945d-3348a0213af9"));
            Report = (ITTTabPage)AddControl(new Guid("1fd69cd6-1b25-4f7b-b713-b960bf5777d7"));
            labelHCDecisionCategory = (ITTLabel)AddControl(new Guid("c1682d66-00c1-4520-b842-e6b3b34ab85d"));
            HCDecisionCategory = (ITTObjectListBox)AddControl(new Guid("000b2535-96f8-4569-b219-e01c977959cf"));
            labelHealthCommitteeDecision = (ITTLabel)AddControl(new Guid("521b3963-07ce-47ce-84cc-7e319361499c"));
            lstHealthCommitteeDecision = (ITTObjectListBox)AddControl(new Guid("00cecfbe-0811-4bd5-8f1f-75619bf50cdd"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("aad812db-bc0d-4ab5-9531-e9e4ad7ac62b"));
            Description = (ITTTabPage)AddControl(new Guid("2f204c65-e8ad-40cb-8d41-c06d5e64a514"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("6c0c0150-fe45-4d59-b9f1-8be02a4e4e38"));
            Material = (ITTTabPage)AddControl(new Guid("6496f63a-bb52-49f0-9371-ffee060473b2"));
            lblReportEndDate = (ITTLabel)AddControl(new Guid("45e5da56-2ed7-48bd-b05a-01e45fb1f366"));
            lblReportStartDate = (ITTLabel)AddControl(new Guid("c31e4c37-98aa-4db6-b44f-f1efc20596d1"));
            ReportEndDate = (ITTDateTimePicker)AddControl(new Guid("6d96e14a-248b-4490-a082-a89c640203eb"));
            ReportStartDate = (ITTDateTimePicker)AddControl(new Guid("983d2fa0-99fb-406e-8f95-038b25ec5488"));
            Rest = (ITTTabPage)AddControl(new Guid("ae5c499e-9f08-440f-bd32-30be968a2a12"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("1b11af4d-8085-4d27-ae7a-57697b9fcb13"));
            RestReportDecision = (ITTEnumComboBox)AddControl(new Guid("78cfb405-f471-44ba-8bbf-a84a779b3e5b"));
            lblRestReport3 = (ITTLabel)AddControl(new Guid("b9c8108b-bc57-4e3f-aeb0-c7e82f2f2e96"));
            DecisionDate = (ITTDateTimePicker)AddControl(new Guid("89ed43d2-d21c-4cff-b1b4-a7d6e5858d77"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("d9a801de-46a0-43c9-9123-94b1fa66d04c"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("e64ad0e1-342f-4d9f-96f9-f25d49689fe5"));
            lblRestReport2 = (ITTLabel)AddControl(new Guid("03537336-54a2-43b8-a914-5716f988aa0b"));
            lblRestReport1 = (ITTLabel)AddControl(new Guid("5651108a-f04c-4986-a172-1489f9d72923"));
            InformOneDoctor = (ITTTabPage)AddControl(new Guid("8b3cef1c-fb9f-4175-b877-3f6ebb649c4e"));
            NoObstacleDescription = (ITTTextBox)AddControl(new Guid("b0b0ad3d-8bf6-4a12-8d22-76214ded5f0f"));
            lblNoObstacleDescription = (ITTLabel)AddControl(new Guid("a7c37ec7-df05-45dc-80ca-fb2baa38c32d"));
            SituationInformODDecision = (ITTEnumComboBox)AddControl(new Guid("063fbc68-a06b-496a-86f0-1c7fa8eb9e11"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("aff1bfc0-6361-48d1-aeb5-3f766e4c330a"));
            SituationInformODReportType = (ITTEnumComboBox)AddControl(new Guid("a5473e6b-498d-4c2d-959d-5166c226aaa9"));
            lblReason = (ITTLabel)AddControl(new Guid("cc2f399e-e262-4800-87a4-5a6c8187ed53"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("94926bbe-0e9e-4e2f-806e-64fa1e23112c"));
            Matter = (ITTTextBoxColumn)AddControl(new Guid("75acf5ab-968b-4d81-a64e-262f1cd32b17"));
            Slice = (ITTEnumComboBoxColumn)AddControl(new Guid("c50df65b-7859-417a-9ba9-406cce68c850"));
            Anectode = (ITTTextBoxColumn)AddControl(new Guid("2d35f159-dd42-4a7b-8c0c-14fd43b05992"));
            tttabpagePI = (ITTTabPage)AddControl(new Guid("a669407c-0f30-41c7-aef0-e9acbfc50c85"));
            Adres = (ITTTextBox)AddControl(new Guid("a63cf924-2de9-46ad-bbb5-57ff66c1b17c"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("3d1bd975-7a4f-41d5-b532-91d3ce422fb3"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("8982a349-cfc2-41ce-afd8-ef1e24063d1e"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("e023c5b8-1e84-449e-8e30-702335a8f7ef"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("52f54555-bf06-49fb-bc5f-a06cdba98456"));
            labelFatherName = (ITTLabel)AddControl(new Guid("b17ceb9f-b655-49de-ab46-7ef1a6378b97"));
            FatherName = (ITTTextBox)AddControl(new Guid("a31fedf6-8cd7-41e0-a5a3-67bf4091ea42"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("bd3ee9b5-1f25-40e9-b81f-f3e6cdfa83c4"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("2827c703-4cc8-4831-9142-158a4a3d3754"));
            TownOfBirth = (ITTObjectListBox)AddControl(new Guid("dc0850c9-6e03-483b-b22a-8b3843dc19ae"));
            labelCityOfBirth = (ITTLabel)AddControl(new Guid("e49d0578-c6e0-44b0-aeff-d276c5fbc50a"));
            CityOfBirth = (ITTObjectListBox)AddControl(new Guid("999edc5c-fe64-445d-b3d0-6538d901572a"));
            labelBirthPlaceCountry = (ITTLabel)AddControl(new Guid("cff8ba79-d0fd-4128-8d0c-016f2c26dfb8"));
            labelTownOfBirth = (ITTLabel)AddControl(new Guid("96e902cc-5196-4f8f-8397-3dfb802d2ec0"));
            CountryOfBirth = (ITTObjectListBox)AddControl(new Guid("20b7f9e8-a7c5-4b02-8cd8-9780e4735b70"));
            tttextboxTCNo = (ITTTextBox)AddControl(new Guid("b73223ee-8669-40b6-b8f0-90c4839a5dbf"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("e1cbc6cd-c351-47c7-abb8-c283b4115c80"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("e0e5071b-74cb-40a4-9791-f558661ba397"));
            labelBirlik = (ITTLabel)AddControl(new Guid("a46f1f9b-6417-4a87-8982-b9cb69ba1860"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("a732d202-00dc-4ecb-86d6-98b3d783119f"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("cf99fe3e-623e-4120-aa32-833a1e352a44"));
            Rank = (ITTObjectListBox)AddControl(new Guid("397105d2-5b50-47f0-b672-f13914cd26ba"));
            labelRank = (ITTLabel)AddControl(new Guid("da56775c-ce86-48c4-a7c6-bd7505a1ff6c"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("5531672e-81c1-4f72-98c9-e7cbdf3dea3b"));
            labelRegistryNo = (ITTLabel)AddControl(new Guid("5dd57e8f-1138-44d0-ac79-bd3d739fe2dc"));
            base.InitializeControls();
        }

        public HCTSNewForm() : base("HEALTHCOMMITTEEWITHTHREESPECIALIST", "HCTSNewForm")
        {
        }

        protected HCTSNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}