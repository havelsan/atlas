
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
    public partial class HCTSReportForm : EpisodeActionForm
    {
    /// <summary>
    /// Üç Uzman Tabip İmzalı Rapor  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.HealthCommitteeWithThreeSpecialist _HealthCommitteeWithThreeSpecialist
        {
            get { return (TTObjectClasses.HealthCommitteeWithThreeSpecialist)_ttObject; }
        }

        protected ITTTabControl tttabcontrolMain;
        protected ITTTabPage tttabpageHTC;
        protected ITTDateTimePicker ReportDate;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelReasonForExamination;
        protected ITTObjectListBox ReasonForExamination;
        protected ITTTextBox tttextboxClinicReportNo;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTEnumComboBox PatientGroup;
        protected ITTTextBox ReportNo;
        protected ITTLabel labelReasonForAdmission;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel5;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel ttlabel4;
        protected ITTEnumComboBox PatientStatus;
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
        protected ITTLabel labelHCDecisionCategory;
        protected ITTObjectListBox HCDecisionCategory;
        protected ITTLabel labelHealthCommitteeDecision;
        protected ITTObjectListBox lstHealthCommitteeDecision;
        protected ITTTabControl tabReport;
        protected ITTTabPage Report;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTabPage Description;
        protected ITTRichTextBoxControl Desc;
        protected ITTTabPage Material;
        protected ITTDateTimePicker ReportEndDate;
        protected ITTDateTimePicker ReportStartDate;
        protected ITTLabel lblReportEndDate;
        protected ITTLabel lblReportStartDate;
        protected ITTTabPage Rest;
        protected ITTLabel ttlabel16;
        protected ITTEnumComboBox RestReportDecision;
        protected ITTDateTimePicker DecisionDate;
        protected ITTDateTimePicker EndDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel10;
        protected ITTTabPage InformOneDoctor;
        protected ITTTextBox NoObstacleDescription;
        protected ITTEnumComboBox SituationInformODDecision;
        protected ITTEnumComboBox SituationInformODReportType;
        protected ITTLabel ttlabel15;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel13;
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
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("ce7101bc-81a6-4e3d-b704-10b0120bb4e6"));
            tttabpageHTC = (ITTTabPage)AddControl(new Guid("fcf2384f-5e10-41b2-a3e0-a3b501886194"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("7b31fc81-abec-41ba-b628-bbe9d648d2ce"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("28ea3fbd-6c4e-447c-b48a-17ca4e4e2d73"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("876bf66e-644b-4a0d-a163-9c1aa9cd9b30"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("ce625465-7a9f-4361-a44a-f461ff21e14c"));
            labelReasonForExamination = (ITTLabel)AddControl(new Guid("c2cd56a8-f55e-41d8-8161-3c0811fbb473"));
            ReasonForExamination = (ITTObjectListBox)AddControl(new Guid("309867d7-804b-49cb-8833-eed7d6c902db"));
            tttextboxClinicReportNo = (ITTTextBox)AddControl(new Guid("bb95416b-89e5-4419-842a-451cb48195ec"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("68261280-8d0f-4ebf-9c45-8e7934cb592c"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("a4563039-6484-4117-9a56-def83f77e2c5"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("78d8406a-81e0-4f7b-a2a5-db73e32493d5"));
            ReportNo = (ITTTextBox)AddControl(new Guid("d90ec510-7f0c-44a3-b47a-da0198eefe16"));
            labelReasonForAdmission = (ITTLabel)AddControl(new Guid("8da4aa26-6f6c-4dd1-8f75-36ed61438220"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("d2de3fde-a0c9-45b0-a946-d8e94ce480e7"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("f5de36e8-1165-4915-b9ad-c1d2ce346665"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("be322b21-4475-4cad-b8ef-3e0d3b4aff6b"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("5ad53eb3-cf6a-4c31-b538-61a8504ad410"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("4cb328e8-3cb1-4e46-80f4-977dc8ff8da4"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("56ba4d15-6809-46ee-a2b1-5f11d1ea1f6d"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("0c2151be-26fc-4ccd-81db-9c10283dca12"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("6969558e-22eb-44d4-9776-3a8dbdb602d5"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("0fe39da8-9869-4b9b-ba8c-6652a32020dc"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("8a152993-3472-4e71-9255-b8efc453a6fe"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("5f4ef9bc-ad97-4b3c-b8a6-6c6ee776920d"));
            EpisodeFreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("5d3cf57c-fbe5-490e-847d-67c7a180cd22"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("912702f2-b173-4345-b4f5-ac4d0389ec31"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("cc3f5787-6615-4c3d-bffb-a2a1109d71f4"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("d99f29e8-b954-4801-b057-cd1bb23b814d"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("a4ef136c-a5f6-48dd-a76e-c94d0c87f372"));
            DiagnosisEntryTab = (ITTTabPage)AddControl(new Guid("320a7f27-7ebc-4501-89d8-08a275934575"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("7ddbefb5-13c4-4f7b-a2b2-06eb3cbbb811"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("e3bda89b-506a-438b-b7b2-a447f7cf2d0c"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("a2fa0708-6cc7-4398-8efa-39022dab5a9b"));
            SecFreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("d44ba3cd-db0b-4508-86d0-ed989b12b3cb"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("f0c8aa73-2ff6-459e-abff-18de87186f0b"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("f6e4d110-3880-4d99-a26e-6fd5965503b7"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("76729bbc-0939-4583-aacb-6af74c72541c"));
            tttabpageReport = (ITTTabPage)AddControl(new Guid("ce7bd4f6-e7eb-440c-a757-cccfaf45b5ce"));
            labelHCDecisionCategory = (ITTLabel)AddControl(new Guid("93add32b-2f21-46fe-b6a4-ff2fff2015ce"));
            HCDecisionCategory = (ITTObjectListBox)AddControl(new Guid("7209c2dd-0f7e-4f8e-b1d3-dce012be31ba"));
            labelHealthCommitteeDecision = (ITTLabel)AddControl(new Guid("5122e75e-fc3e-4e6a-b5da-7fe33c46d3a4"));
            lstHealthCommitteeDecision = (ITTObjectListBox)AddControl(new Guid("29822ae7-20af-4a3d-be54-fa7f4c1785f7"));
            tabReport = (ITTTabControl)AddControl(new Guid("50738abe-313a-4600-b5af-e37df952b22c"));
            Report = (ITTTabPage)AddControl(new Guid("344a8ff4-6cb2-4d00-a163-bc1b000cb2f7"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("33863b96-c06c-4161-a131-665f47797098"));
            Description = (ITTTabPage)AddControl(new Guid("4496eb6c-02d8-4425-b001-221a972990a1"));
            Desc = (ITTRichTextBoxControl)AddControl(new Guid("07931a54-2ea2-46b4-8707-340a7146ad00"));
            Material = (ITTTabPage)AddControl(new Guid("e9f25afb-2b53-483f-be80-84ebbd087ce9"));
            ReportEndDate = (ITTDateTimePicker)AddControl(new Guid("cd0f9713-7c6b-46d1-90a5-75d559372105"));
            ReportStartDate = (ITTDateTimePicker)AddControl(new Guid("f6aa632c-afe2-4b41-a5f3-972dff19c781"));
            lblReportEndDate = (ITTLabel)AddControl(new Guid("cf62d4fc-5388-4069-bcc4-69d75197d272"));
            lblReportStartDate = (ITTLabel)AddControl(new Guid("1315ef1d-910d-45ef-9dd3-af52df5f3aec"));
            Rest = (ITTTabPage)AddControl(new Guid("05142511-5311-401e-8338-dbe9f4d40bb3"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("95f7feed-e8a5-4708-99b1-f702f575913d"));
            RestReportDecision = (ITTEnumComboBox)AddControl(new Guid("43100113-fb8c-41af-b1aa-62b1e7efded3"));
            DecisionDate = (ITTDateTimePicker)AddControl(new Guid("c89e2a1d-c2fd-47ff-b4b5-f82e6ed80c72"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("daf811ba-8409-4694-9415-a007d5a36464"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("6805a7c8-9786-4b0b-aa1a-67ae4b40a913"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("2d4057e1-8197-47aa-b082-730bcd5d09cd"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("ea639e59-4ffb-4f82-8a7f-1679d65827b1"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("110aaa2b-e835-4d47-95cb-b06c7b1b868f"));
            InformOneDoctor = (ITTTabPage)AddControl(new Guid("a4c06840-3712-4b20-9241-82acb2b1d204"));
            NoObstacleDescription = (ITTTextBox)AddControl(new Guid("72c0affe-de50-46b4-9859-ae788bf0ac81"));
            SituationInformODDecision = (ITTEnumComboBox)AddControl(new Guid("2bf98d6b-b08f-46c5-ac0a-7cb9d21e0f7f"));
            SituationInformODReportType = (ITTEnumComboBox)AddControl(new Guid("3bb2a825-26f9-44a3-95ec-045aad6961de"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("cef8fd1f-d54a-4d73-acd1-e13241548ce6"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("2f04ec19-7249-402b-af36-d4ce37095609"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("c9d59ba8-6332-4091-8121-1af9ac9e3031"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("663ece27-cb1b-4eba-99d4-2d2d133ba9bf"));
            Matter = (ITTTextBoxColumn)AddControl(new Guid("2634ce20-9e38-4fec-b3d6-8a4aefd41763"));
            Slice = (ITTEnumComboBoxColumn)AddControl(new Guid("25128b4b-a093-461b-9513-a836110c4a83"));
            Anectode = (ITTTextBoxColumn)AddControl(new Guid("9046546e-8d7e-4333-a7a8-e1c045596fae"));
            tttabpagePI = (ITTTabPage)AddControl(new Guid("3c348301-1c17-4c22-973d-e1b7dcb64f72"));
            Adres = (ITTTextBox)AddControl(new Guid("7f4d73b9-8756-4add-bce3-13b1c1e6fa90"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("4d7d0bfe-edc9-48f5-98be-97f7eb492cb4"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("28108418-327c-4565-8941-1504a7d9125a"));
            labelFatherName = (ITTLabel)AddControl(new Guid("3bc2f3b0-d606-4f3f-b809-809dff140870"));
            FatherName = (ITTTextBox)AddControl(new Guid("20d840ed-0a22-417e-8a4d-9d91d1db0779"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("44c8626f-b771-42af-9f54-5889f3f320e3"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("dc1ec250-88cb-4905-802e-042d459db20b"));
            TownOfBirth = (ITTObjectListBox)AddControl(new Guid("ad0e693c-6db9-4e6b-86a5-9cf0a4dad890"));
            labelCityOfBirth = (ITTLabel)AddControl(new Guid("297ff259-3b75-4f8b-85df-0b7601ba8d77"));
            CityOfBirth = (ITTObjectListBox)AddControl(new Guid("e53c547d-4195-45cf-a826-0eb6cf42754b"));
            labelBirthPlaceCountry = (ITTLabel)AddControl(new Guid("d351c548-56ed-4bb5-bd2d-91f0a1f0ec5c"));
            labelTownOfBirth = (ITTLabel)AddControl(new Guid("533f9f66-2816-4f7d-b3b5-aa9df405ace9"));
            CountryOfBirth = (ITTObjectListBox)AddControl(new Guid("3621b92f-b6f4-4d32-8226-1a8bfc034806"));
            tttextboxTCNo = (ITTTextBox)AddControl(new Guid("fe9dd8f9-5b7b-4f92-9bf2-ada064478f3b"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("45d39208-242d-4965-abf3-25040ad3ec16"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("66dd5768-bff8-46d6-bb7b-e533e26940d2"));
            labelBirlik = (ITTLabel)AddControl(new Guid("8b93528c-0356-4835-ab31-917701416b39"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("1c97e03a-dd27-4f43-9ce9-795db9b565ce"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("edc4b67c-48ac-4976-ba8c-805d829d2e10"));
            Rank = (ITTObjectListBox)AddControl(new Guid("41bf4d30-42f7-467f-bd5b-3e655433dabb"));
            labelRank = (ITTLabel)AddControl(new Guid("c02114d9-c0df-4d10-9b93-92ce42042297"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("2a5a8e4b-9c0b-4d14-9752-d4aa40c10710"));
            labelRegistryNo = (ITTLabel)AddControl(new Guid("a2dcea74-5fed-4da5-b06c-bfcb9bd21180"));
            base.InitializeControls();
        }

        public HCTSReportForm() : base("HEALTHCOMMITTEEWITHTHREESPECIALIST", "HCTSReportForm")
        {
        }

        protected HCTSReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}