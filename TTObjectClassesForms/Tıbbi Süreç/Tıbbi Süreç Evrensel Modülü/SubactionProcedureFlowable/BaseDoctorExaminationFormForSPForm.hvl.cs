
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
    /// Doktor Muayene Formu
    /// </summary>
    public partial class BaseDoctorExaminationFormForSP : SubactionProcedureFlowableForm
    {
        protected TTObjectClasses.SubactionProcedureFlowable _SubactionProcedureFlowable
        {
            get { return (TTObjectClasses.SubactionProcedureFlowable)_ttObject; }
        }

        protected ITTGroupBox GroupBox1;
        protected ITTRichTextBoxControl ImportantPatientInfo;
        protected ITTLabel labelAge;
        protected ITTLabel labelImportantInfo;
        protected ITTTextBox Age;
        protected ITTLabel labelPatientGroup;
        protected ITTLabel labelSex;
        protected ITTPictureBoxControl ttpictureboxcontrol1;
        protected ITTEnumComboBox Sex;
        protected ITTEnumComboBox PatientGroup;
        protected ITTButton btnImportantMedicalInfo;
        protected ITTGroupBox GroupBox3;
        protected ITTTabControl AnalysisPatientTab;
        protected ITTTabPage ComplaintTab;
        protected ITTTabPage SystemQueryTab;
        protected ITTTabPage ExaminationIndicationsTab;
        protected ITTGrid OldPhysicialExaminationsGrid;
        protected ITTDateTimePickerColumn ExaminationDateTime;
        protected ITTRichTextBoxControlColumn ExaminationIndication;
        protected ITTTabPage ExaminationSummaryTab;
        protected ITTTabPage PreDiagnosisTab;
        protected ITTTabPage LaboratoryTab;
        protected ITTLabel labelTestActionType;
        protected ITTLabel labelLabEndDate;
        protected ITTDateTimePicker LabStartDate;
        protected ITTObjectListBox TestProcedure;
        protected ITTObjectListBox TestMenuDefinition;
        protected ITTDateTimePicker LabEndDate;
        protected ITTLabel labelLabStartDate;
        protected ITTButton btnLabNewRequest;
        protected ITTGrid LaboratoryResultsGrid;
        protected ITTDateTimePickerColumn ProcedureDate;
        protected ITTTextBoxColumn Procedure;
        protected ITTRichTextBoxControlColumn ProcedureResult;
        protected ITTButtonColumn Detail;
        protected ITTTextBoxColumn ObjectID;
        protected ITTLabel ttlabel2;
        protected ITTButton btnLabList;
        protected ITTTabPage ConsultationTab;
        protected ITTButton btnNewConsultationFromOtherHospRequest;
        protected ITTButton btnConsultationNewRequest;
        protected ITTGrid ConsultationGrid;
        protected ITTDateTimePickerColumn ConsultationDate;
        protected ITTTextBoxColumn RequesterHospital;
        protected ITTTextBoxColumn RequesterDepartment;
        protected ITTTextBoxColumn RequestedHospital;
        protected ITTTextBoxColumn RequestedDepartment;
        protected ITTRichTextBoxControlColumn RequestReason;
        protected ITTRichTextBoxControlColumn ConsultationResultAndOffer;
        protected ITTButton btnAnesthesiaConsultationNewRequest;
        protected ITTTabPage TreatmentDischargeTab;
        protected ITTButton btnNewTreatmentDischarge;
        protected ITTTabPage ExaminationMeasTab;
        protected ITTGrid ExaminationMeases;
        protected ITTDateTimePickerColumn MeasDateExaminationMeasGrid;
        protected ITTTextBoxColumn HeigthExaminationMeasGrid;
        protected ITTTextBoxColumn WeightExaminationMeasGrid;
        protected ITTTextBoxColumn HeadCircumferenceExaminationMeasGrid;
        protected ITTTextBoxColumn ChestCircumferenceExaminationMeasGrid;
        protected ITTGroupBox GroupBox2;
        protected ITTTabControl ContinuousInfoTab;
        protected ITTTabPage ImportantDiagnosisTab;
        protected ITTGrid DiagnosisHistory;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTListBoxColumn Diagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTEnumComboBoxColumn DiagnosisType;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTTabPage HealthCommiteeActionsTab;
        protected ITTGrid HealthCommiteeActions;
        protected ITTTextBoxColumn Hospital;
        protected ITTTextBoxColumn HealthCommiteeActionID;
        protected ITTDateTimePickerColumn HealthCommiteeActionDate;
        protected ITTTextBoxColumn HCObjectID;
        protected ITTTabPage PatientFamilyHistoryTab;
        protected ITTTabPage HabitsTab;
        protected ITTTabPage ContinuousDrugsTab;
        protected ITTTabPage EpisodeExaminationMeasTab;
        protected ITTGrid EpisodeExaminationMeasGrid;
        protected ITTDateTimePickerColumn EpiosdeMeasDate;
        protected ITTTextBoxColumn EpisodeHeigth;
        protected ITTTextBoxColumn EpisodeWeight;
        protected ITTTextBoxColumn EpisodeHeadCircumference;
        protected ITTTextBoxColumn EpisodeChestCircumference;
        protected ITTGroupBox GroupBox4;
        protected ITTTabControl ObservationAndAction;
        protected ITTTabPage ManipulationTab;
        protected ITTGrid ManipulationGrid;
        protected ITTDateTimePickerColumn ManipulationActionDate;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTCheckBoxColumn Emergency;
        protected ITTListBoxColumn Department;
        protected ITTListBoxColumn ManipulationDoctor;
        protected ITTTextBoxColumn Description;
        protected ITTButton btnManipulationNewRequest;
        protected ITTTabPage ProcedureObjectTab;
        override protected void InitializeControls()
        {
            GroupBox1 = (ITTGroupBox)AddControl(new Guid("98133f97-a77f-4e97-ab43-37b9a5861175"));
            ImportantPatientInfo = (ITTRichTextBoxControl)AddControl(new Guid("f26cd76e-1dd0-487f-b92e-6adf453f6876"));
            labelAge = (ITTLabel)AddControl(new Guid("6ae3ebce-3f45-4480-a472-5c5ecda2497b"));
            labelImportantInfo = (ITTLabel)AddControl(new Guid("58eab481-e44a-4efb-a7b0-5ab612f8e4bc"));
            Age = (ITTTextBox)AddControl(new Guid("49e857e5-699b-43ac-a5ac-c3bd53d369ec"));
            labelPatientGroup = (ITTLabel)AddControl(new Guid("37cc7077-e282-4215-a2c7-aaab72d46f76"));
            labelSex = (ITTLabel)AddControl(new Guid("fcacba25-0925-4184-ba53-009e37648b37"));
            ttpictureboxcontrol1 = (ITTPictureBoxControl)AddControl(new Guid("b02e9c26-8f35-4d80-958f-63a23c50666c"));
            Sex = (ITTEnumComboBox)AddControl(new Guid("81df2d2f-d18a-4eed-b1a9-e47209729eb3"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("ba2b6437-9056-44c8-bf5e-0a33e52b3d18"));
            btnImportantMedicalInfo = (ITTButton)AddControl(new Guid("f3d5d81d-c68b-4c41-8149-5b61738b4594"));
            GroupBox3 = (ITTGroupBox)AddControl(new Guid("e6987cc3-8b66-4d9f-89fb-c112b810d203"));
            AnalysisPatientTab = (ITTTabControl)AddControl(new Guid("f3b4bfa8-3fd1-4674-a7f0-3cca80104ff7"));
            ComplaintTab = (ITTTabPage)AddControl(new Guid("74cf4264-47ea-44ad-b1bb-c72c64c9d7ff"));
            SystemQueryTab = (ITTTabPage)AddControl(new Guid("68beb609-2895-458a-a9f3-a5eb945656b0"));
            ExaminationIndicationsTab = (ITTTabPage)AddControl(new Guid("1a0cf9cb-259f-4cbb-ba2b-55826bb4e09f"));
            OldPhysicialExaminationsGrid = (ITTGrid)AddControl(new Guid("d6482d9b-f472-4abc-9aa4-a8064ad8f6c4"));
            ExaminationDateTime = (ITTDateTimePickerColumn)AddControl(new Guid("241cd037-e693-4d3c-9cd5-38bd6c99aa8d"));
            ExaminationIndication = (ITTRichTextBoxControlColumn)AddControl(new Guid("b827f3ae-e6bf-46db-901c-8b5cf1a78325"));
            ExaminationSummaryTab = (ITTTabPage)AddControl(new Guid("cc1ef2e1-1881-483a-a7af-60c6c9018ba5"));
            PreDiagnosisTab = (ITTTabPage)AddControl(new Guid("f2a09a82-9e45-4e6c-ae08-d8de8fd5c918"));
            LaboratoryTab = (ITTTabPage)AddControl(new Guid("1c977489-54c9-4078-9624-97093b5adfcd"));
            labelTestActionType = (ITTLabel)AddControl(new Guid("693176c1-da41-4a58-b16a-30a3d372fe02"));
            labelLabEndDate = (ITTLabel)AddControl(new Guid("ec9d4639-f9dc-4a12-8f62-17a69ee15577"));
            LabStartDate = (ITTDateTimePicker)AddControl(new Guid("8653a7cd-1fd7-4c2f-808b-783688cb4c47"));
            TestProcedure = (ITTObjectListBox)AddControl(new Guid("cd44f0ca-0206-433b-978e-be78e2a9dff5"));
            TestMenuDefinition = (ITTObjectListBox)AddControl(new Guid("2fbc9a23-cf60-49ea-a1a7-294bbaca04c5"));
            LabEndDate = (ITTDateTimePicker)AddControl(new Guid("1e21beb2-f35e-4c56-9c30-fcee208e4bc8"));
            labelLabStartDate = (ITTLabel)AddControl(new Guid("a118997c-6351-4e82-a44f-9247e6ad22c8"));
            btnLabNewRequest = (ITTButton)AddControl(new Guid("8ebc2b4e-b886-4014-a753-62ae84eb5031"));
            LaboratoryResultsGrid = (ITTGrid)AddControl(new Guid("5e04b9a9-a32b-451c-b891-6aa2575b1c9b"));
            ProcedureDate = (ITTDateTimePickerColumn)AddControl(new Guid("3461112c-2513-46a9-80ab-eef0a636a760"));
            Procedure = (ITTTextBoxColumn)AddControl(new Guid("64740bd4-898b-4463-b980-a8e4c15a1240"));
            ProcedureResult = (ITTRichTextBoxControlColumn)AddControl(new Guid("e90cc98f-5818-4162-9950-470a61f2c5b7"));
            Detail = (ITTButtonColumn)AddControl(new Guid("1674de01-15d4-4366-92c6-2b7b35def446"));
            ObjectID = (ITTTextBoxColumn)AddControl(new Guid("6206ab88-c280-4ef6-8c81-8abcdb133adb"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("5b129540-3ee6-4683-b5ee-a29626eacdfb"));
            btnLabList = (ITTButton)AddControl(new Guid("c7a803e6-ab7a-4b53-964c-46bc529a6984"));
            ConsultationTab = (ITTTabPage)AddControl(new Guid("dd2f60cb-1331-4549-8a71-dd96e4a64a1d"));
            btnNewConsultationFromOtherHospRequest = (ITTButton)AddControl(new Guid("4e4078b0-c53a-44b5-b220-f0d5868b985c"));
            btnConsultationNewRequest = (ITTButton)AddControl(new Guid("b6256b9c-ac09-47c6-91fb-5cfe0c62825e"));
            ConsultationGrid = (ITTGrid)AddControl(new Guid("13dfc2ba-a8b3-46f6-b6a9-7f91a7ecf0ce"));
            ConsultationDate = (ITTDateTimePickerColumn)AddControl(new Guid("733a7aa2-14f2-4a83-9a72-a53fc1c429de"));
            RequesterHospital = (ITTTextBoxColumn)AddControl(new Guid("cc262947-e67c-4eb9-a639-80540f1cef01"));
            RequesterDepartment = (ITTTextBoxColumn)AddControl(new Guid("27d72dfb-baab-4efd-a5d2-cdaef1e28e64"));
            RequestedHospital = (ITTTextBoxColumn)AddControl(new Guid("156aa2ee-b057-4ca0-b198-b9e769af27fb"));
            RequestedDepartment = (ITTTextBoxColumn)AddControl(new Guid("cef98947-be52-4267-a35a-385ad2745b0b"));
            RequestReason = (ITTRichTextBoxControlColumn)AddControl(new Guid("7798a2c4-83ca-4063-a0c4-9dbbe2a80055"));
            ConsultationResultAndOffer = (ITTRichTextBoxControlColumn)AddControl(new Guid("9ae7d12c-90f0-4b88-a9e9-909c7b74a28a"));
            btnAnesthesiaConsultationNewRequest = (ITTButton)AddControl(new Guid("93e5707a-06fe-47d4-bf93-ef1b2f2f12c1"));
            TreatmentDischargeTab = (ITTTabPage)AddControl(new Guid("fac88e55-71ce-400c-9e56-0d4bf547a033"));
            btnNewTreatmentDischarge = (ITTButton)AddControl(new Guid("4cef9c81-ea4b-408e-9d0e-df0734797e10"));
            ExaminationMeasTab = (ITTTabPage)AddControl(new Guid("0620de6c-a8d3-49bf-a492-f044549b93c3"));
            ExaminationMeases = (ITTGrid)AddControl(new Guid("68032764-1049-4dd3-bc69-276c12856696"));
            MeasDateExaminationMeasGrid = (ITTDateTimePickerColumn)AddControl(new Guid("2f72045c-e3fd-41bb-a6cf-1b69c2e0c3d4"));
            HeigthExaminationMeasGrid = (ITTTextBoxColumn)AddControl(new Guid("5f4caba7-6aa5-4a26-a980-d04775ec6a20"));
            WeightExaminationMeasGrid = (ITTTextBoxColumn)AddControl(new Guid("51f05f7f-d4f4-47fe-bc25-4b7ad0e3aa55"));
            HeadCircumferenceExaminationMeasGrid = (ITTTextBoxColumn)AddControl(new Guid("27be9093-00b1-4136-a65b-ad9691a205e8"));
            ChestCircumferenceExaminationMeasGrid = (ITTTextBoxColumn)AddControl(new Guid("2f5b56ad-ea8e-45e6-a8ab-c21a378d0499"));
            GroupBox2 = (ITTGroupBox)AddControl(new Guid("2aeae035-2341-4d24-9ee1-d806ff4a5ddf"));
            ContinuousInfoTab = (ITTTabControl)AddControl(new Guid("475e06be-f4ab-462d-a389-ecde72ec5492"));
            ImportantDiagnosisTab = (ITTTabPage)AddControl(new Guid("353a042f-5e26-4360-8947-215af7b15088"));
            DiagnosisHistory = (ITTGrid)AddControl(new Guid("bc49ee71-1ff8-4b18-9494-ed06f5df2a32"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("735c54a3-a7b2-4f76-84be-ed203d594c00"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("bb93ed65-e00a-4049-9b79-55f58131d005"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("785e75af-3269-47f8-84fb-8e63bd17619b"));
            DiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("d532fa5b-3b39-4eaf-bc9d-ed02fe913dfd"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("1da603ce-2e84-42dd-bcc8-52a727b72741"));
            HealthCommiteeActionsTab = (ITTTabPage)AddControl(new Guid("5daf3651-4ac5-436a-a0b6-fdf6c3c1e86c"));
            HealthCommiteeActions = (ITTGrid)AddControl(new Guid("22848440-2e50-4ef5-b3be-a6a576607660"));
            Hospital = (ITTTextBoxColumn)AddControl(new Guid("5b6d0d47-c349-4cf4-afbc-30b214023637"));
            HealthCommiteeActionID = (ITTTextBoxColumn)AddControl(new Guid("0868f887-db27-4633-b4b8-036f122d0866"));
            HealthCommiteeActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("47ba8fe1-fdee-410c-899e-5a9f7b032160"));
            HCObjectID = (ITTTextBoxColumn)AddControl(new Guid("43e31e7f-550c-4f61-b304-aeed83a866e4"));
            PatientFamilyHistoryTab = (ITTTabPage)AddControl(new Guid("9bf9e4b8-775e-4f2c-be98-0edf7afca0b2"));
            HabitsTab = (ITTTabPage)AddControl(new Guid("17880a82-aebe-4002-b5bb-3678ada2c4ed"));
            ContinuousDrugsTab = (ITTTabPage)AddControl(new Guid("7abad16f-86b5-49a1-9a30-944116a46d7c"));
            EpisodeExaminationMeasTab = (ITTTabPage)AddControl(new Guid("22fd82a8-2357-4da5-8966-cbcb4e77383b"));
            EpisodeExaminationMeasGrid = (ITTGrid)AddControl(new Guid("13bb26a1-0e22-4c29-8828-b955c96e7405"));
            EpiosdeMeasDate = (ITTDateTimePickerColumn)AddControl(new Guid("c601dd21-d1c0-44d8-95ae-52b37c16e5ac"));
            EpisodeHeigth = (ITTTextBoxColumn)AddControl(new Guid("2504c9e8-c3b6-43af-91d4-7e3d57978d3a"));
            EpisodeWeight = (ITTTextBoxColumn)AddControl(new Guid("cd3fad98-f43d-4925-9205-c15b3cbb4800"));
            EpisodeHeadCircumference = (ITTTextBoxColumn)AddControl(new Guid("a47bbb97-7f14-47ee-b93d-178b1fbb7ac1"));
            EpisodeChestCircumference = (ITTTextBoxColumn)AddControl(new Guid("14f292bf-c5ec-444e-a45b-a7d1eea61bcb"));
            GroupBox4 = (ITTGroupBox)AddControl(new Guid("8d58b308-34eb-4ba7-9230-142a99f32c89"));
            ObservationAndAction = (ITTTabControl)AddControl(new Guid("6616b137-9c3e-4262-b1c4-53cc089d8d37"));
            ManipulationTab = (ITTTabPage)AddControl(new Guid("7a858c35-68b4-4810-95c3-5fc075573561"));
            ManipulationGrid = (ITTGrid)AddControl(new Guid("69283cd9-f72a-42ac-aed7-0b2237196ef1"));
            ManipulationActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("10be91f6-599b-461b-8a1c-9f98071ffbda"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("fc61d074-393a-41bb-813c-43c0a75058a2"));
            Emergency = (ITTCheckBoxColumn)AddControl(new Guid("675640cd-e790-42a6-b944-0b5af7d4580e"));
            Department = (ITTListBoxColumn)AddControl(new Guid("7ec65bd6-16a4-4667-82b6-610202b24c01"));
            ManipulationDoctor = (ITTListBoxColumn)AddControl(new Guid("7f397e22-8df4-428a-a4bb-338510f72d78"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("13889c2a-efe4-4db3-a1cb-108a4093f756"));
            btnManipulationNewRequest = (ITTButton)AddControl(new Guid("68360567-9238-447f-840d-2e4a12ca2f23"));
            ProcedureObjectTab = (ITTTabPage)AddControl(new Guid("2a09a58f-3a72-4808-af6b-be3d01498c89"));
            base.InitializeControls();
        }

        public BaseDoctorExaminationFormForSP() : base("SUBACTIONPROCEDUREFLOWABLE", "BaseDoctorExaminationFormForSP")
        {
        }

        protected BaseDoctorExaminationFormForSP(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}