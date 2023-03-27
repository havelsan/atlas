
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
    /// Diğer XXXXXXlerden Sağlık Kurulu Muayenesi
    /// </summary>
    public partial class HCOHDecisionRegistrationForm : EpisodeActionForm
    {
    /// <summary>
    /// Diğer XXXXXX(ler)den Sağlık Kurulu Muayenesi
    /// </summary>
        protected TTObjectClasses.HealthCommitteeExaminationFromOtherHospitals _HealthCommitteeExaminationFromOtherHospitals
        {
            get { return (TTObjectClasses.HealthCommitteeExaminationFromOtherHospitals)_ttObject; }
        }

        protected ITTTabControl tttabcontrolMain;
        protected ITTTabPage tttabpageHC;
        protected ITTCheckBox IsHealthy;
        protected ITTObjectListBox RequesterHospital;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel5;
        protected ITTLabel labelReportNo;
        protected ITTGrid HCTSMatterSliceAnectode;
        protected ITTTextBoxColumn Matter12;
        protected ITTEnumComboBoxColumn Slice12;
        protected ITTTextBoxColumn Anectode12;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker HealthCommitteeStartDate;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage DiagnosisEntryTab;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn SecAddToHistory;
        protected ITTListBoxColumn SecDiagnose;
        protected ITTTextBoxColumn SecFreeDiagnose;
        protected ITTCheckBoxColumn SecIsMainDiagnose;
        protected ITTListBoxColumn SecResponsibleUser;
        protected ITTDateTimePickerColumn SecDiagnoseDate;
        protected ITTTabPage EpisodeDiagnosisTab;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTTextBoxColumn EpisodeFreeDiagnose;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabPage TreatmentMaterials;
        protected ITTGrid TreatmentMaterialsGrid;
        protected ITTDateTimePickerColumn TreatmentMaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn UBBCode;
        protected ITTTextBoxColumn Amount;
        protected ITTLabel ttlabel3;
        protected ITTTextBox OfferofDecision;
        protected ITTEnumComboBox PatientGroup;
        protected ITTObjectListBox Unit;
        protected ITTEnumComboBox PatientStatus;
        protected ITTLabel labelReasonForAdmission;
        protected ITTTextBox NumberOfProcess;
        protected ITTLabel labelExplanationOfRequest;
        protected ITTTextBox ReportNo;
        protected ITTTextBox ExplanationOfRequest;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelOfferofDecision;
        protected ITTLabel labelUnit;
        protected ITTObjectListBox Doctor;
        protected ITTObjectListBox Hospital;
        protected ITTLabel labelReportDate;
        protected ITTLabel ttlabel7;
        protected ITTLabel labelHospital;
        protected ITTLabel labelNumberOfProcedure;
        protected ITTObjectListBox Speciality;
        protected ITTLabel ttlabel19;
        protected ITTDateTimePicker ReportDate;
        protected ITTLabel labelDoctor;
        protected ITTObjectListBox ReasonForExamination;
        protected ITTTabPage tttabpageReport;
        protected ITTRichTextBoxControl Report;
        override protected void InitializeControls()
        {
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("c0ccc01e-e911-4cf5-b48b-ef055c9ece8c"));
            tttabpageHC = (ITTTabPage)AddControl(new Guid("e198a349-d0d1-4351-b8fc-3a929601fec5"));
            IsHealthy = (ITTCheckBox)AddControl(new Guid("b314f229-e812-466d-94d8-3b80201d1866"));
            RequesterHospital = (ITTObjectListBox)AddControl(new Guid("ba4525e3-596e-46a5-9803-9c2455ba791a"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("9a6e8e11-0f07-49a0-a63f-1102affb4ca7"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("84fc3fc7-7424-41cb-8afa-1ac4f9419041"));
            labelReportNo = (ITTLabel)AddControl(new Guid("22844165-6fd0-46bc-a26f-600b1bac3a5e"));
            HCTSMatterSliceAnectode = (ITTGrid)AddControl(new Guid("e2b32fc4-4567-4080-aee5-ba18122db22d"));
            Matter12 = (ITTTextBoxColumn)AddControl(new Guid("810db1e8-1dc1-4b01-9037-46acee6ef16f"));
            Slice12 = (ITTEnumComboBoxColumn)AddControl(new Guid("88732e0d-98f3-4d73-b05f-6d5c96d52ef3"));
            Anectode12 = (ITTTextBoxColumn)AddControl(new Guid("199a5475-9d0a-4219-bee8-447b5e1a4573"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("3094e3da-c671-44a7-b99e-2a8061d13e78"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("b90d7f97-b470-4bb8-85c2-ff70a4eb0c35"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("7d9aa7cc-0801-40dd-a9ec-078080631f45"));
            HealthCommitteeStartDate = (ITTDateTimePicker)AddControl(new Guid("179feaaa-aa4a-4406-baf8-064e4e314387"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("33a582de-6439-45ec-8e15-a0175cb5dcd1"));
            DiagnosisEntryTab = (ITTTabPage)AddControl(new Guid("a6465ad3-c924-4a48-81d6-0f11559acf4e"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("fed0df6f-6738-481f-b1ad-9c72bc0a9ef2"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("9780f8bd-36d2-4125-a0d4-eb45126d0c99"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("3d43b437-17f3-401d-8a18-6b053198fd48"));
            SecFreeDiagnose = (ITTTextBoxColumn)AddControl(new Guid("9153255e-4469-48d8-a8b4-ce95f2314ac8"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("f95e8d89-418f-4ee3-9ba3-d0d079373a8d"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("7e622fe9-a17f-4365-a093-151cbd25c486"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("c5fe8e4a-a75a-490b-a7d7-16dd9990f400"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("903b76f8-7dbf-4df0-8d77-a178db23fb52"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("48b41e03-6d0b-4894-9fb3-9b73f8f706a9"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("575c53ce-4cb8-4221-ac29-a0aea4676ddb"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("eb24ac70-44e4-4b80-9bfc-3fca8d748d4d"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("01060550-5fbb-4fab-80a5-bb94e460fd9c"));
            EpisodeFreeDiagnose = (ITTTextBoxColumn)AddControl(new Guid("5b96daa8-e775-4c5b-a4c8-b7bba3404fe5"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("42018b78-deeb-4540-b155-0dabbff6be9f"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("36121cea-180a-44d0-87fd-4495f0f3097e"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("540bd4aa-7b22-4d63-9ed3-0663bd6ccab3"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("2d010c58-808c-4456-9632-3ed9b99e623d"));
            TreatmentMaterials = (ITTTabPage)AddControl(new Guid("39ef452b-d8c4-4c04-a63e-ca23d8e7a3d9"));
            TreatmentMaterialsGrid = (ITTGrid)AddControl(new Guid("79dd0b70-029c-4c55-8d07-dd520dc203c2"));
            TreatmentMaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("9c9903a6-f927-4917-afca-2f79b4bb9af7"));
            Material = (ITTListBoxColumn)AddControl(new Guid("bc3d700c-1c2b-4ee4-b1f1-cded74a5696e"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("1a3f6264-baf4-4027-900c-0b4d48056fc1"));
            UBBCode = (ITTTextBoxColumn)AddControl(new Guid("4fee839c-7a28-40ff-a602-3b869f0432dd"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("4f5b1499-464c-4fd4-a99c-6d37f4a73f5e"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("117a423f-f1a2-46cc-a52f-d6d31719ed75"));
            OfferofDecision = (ITTTextBox)AddControl(new Guid("37d7d3d4-edf1-45c1-9335-07638fb8410e"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("83d39e33-c3df-48c6-9463-d34f10ec2a28"));
            Unit = (ITTObjectListBox)AddControl(new Guid("127c6f65-47b8-4027-ad47-0cb4753e975f"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("b8556258-6b39-45ca-b80d-cfb14bce74af"));
            labelReasonForAdmission = (ITTLabel)AddControl(new Guid("434af68c-6632-4dd9-a8f7-1776b20cbd28"));
            NumberOfProcess = (ITTTextBox)AddControl(new Guid("4c56a7b3-03a3-49d1-852f-ce4661902e03"));
            labelExplanationOfRequest = (ITTLabel)AddControl(new Guid("da17aa6b-e0b0-4d90-996c-2138a4676537"));
            ReportNo = (ITTTextBox)AddControl(new Guid("e42433b8-2e0a-4044-b4d1-bfd0795c42e7"));
            ExplanationOfRequest = (ITTTextBox)AddControl(new Guid("f4dc6ee5-2342-4b14-8fe0-2f0dcdfc77a4"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("48784b45-4591-4715-8ad4-be3679514450"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("b38a6024-7911-4ca0-a858-3d8ad8cd8374"));
            labelOfferofDecision = (ITTLabel)AddControl(new Guid("197d7bba-f5d9-4b43-be20-bcf57a23cf78"));
            labelUnit = (ITTLabel)AddControl(new Guid("4bdf4221-c5a6-442d-af41-420f2cba7f9a"));
            Doctor = (ITTObjectListBox)AddControl(new Guid("7e04458b-fdb1-4650-98ab-af18ea5c44c5"));
            Hospital = (ITTObjectListBox)AddControl(new Guid("cec46ef0-70eb-43d3-acfb-53ed4f9033ae"));
            labelReportDate = (ITTLabel)AddControl(new Guid("24ba7c5c-ec1a-48db-a736-610a1dd79325"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("fc5d7b55-ec1e-4632-98e4-a12563895c54"));
            labelHospital = (ITTLabel)AddControl(new Guid("b610b5f2-f082-46ba-813c-6c3e94fd069a"));
            labelNumberOfProcedure = (ITTLabel)AddControl(new Guid("7e153a7a-af1d-4e8b-9f93-70fe0e5155c0"));
            Speciality = (ITTObjectListBox)AddControl(new Guid("cd1fe88e-c787-46aa-84d8-91c2f0be9ad4"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("ac09870a-8f8d-4ae5-8712-7289502e8d34"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("35819395-949b-44d2-ad86-8aec7fd9bb2f"));
            labelDoctor = (ITTLabel)AddControl(new Guid("6e232deb-5d76-4596-9883-778e2acec6e6"));
            ReasonForExamination = (ITTObjectListBox)AddControl(new Guid("bf8cea49-085d-49e4-982c-88b0134d93ee"));
            tttabpageReport = (ITTTabPage)AddControl(new Guid("b0dd526a-d7a8-40cd-8ea9-8835c69e4a76"));
            Report = (ITTRichTextBoxControl)AddControl(new Guid("e8946825-2255-489a-8e37-aa947e6b5c11"));
            base.InitializeControls();
        }

        public HCOHDecisionRegistrationForm() : base("HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS", "HCOHDecisionRegistrationForm")
        {
        }

        protected HCOHDecisionRegistrationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}