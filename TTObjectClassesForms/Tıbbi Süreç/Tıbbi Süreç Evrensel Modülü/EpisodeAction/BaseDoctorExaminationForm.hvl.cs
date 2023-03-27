
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
    /// TPG nin istediği detaylı ayaktan-yatan hasta muayene formudur.
    /// </summary>
    public partial class BaseDoctorExaminationForm : EpisodeActionForm
    {
    /// <summary>
    /// Vakaya Bağlı Hasta İşlemlerinini Ana Nesnesi
    /// </summary>
        protected TTObjectClasses.EpisodeAction _EpisodeAction
        {
            get { return (TTObjectClasses.EpisodeAction)_ttObject; }
        }

        protected ITTGroupBox GroupBox4;
        protected ITTTabControl ObservationAndAction;
        protected ITTTabPage tttabpage1;
        protected ITTTabPage GenealogialTreeTab;
        protected ITTPictureBoxControl GenealogicalTreePicture;
        protected ITTTabPage ManipulationTab;
        protected ITTGrid ManipulationGrid;
        protected ITTDateTimePickerColumn ManipulationActionDate;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTCheckBoxColumn Emergency;
        protected ITTListBoxColumn Department;
        protected ITTListBoxColumn ManipulationDoctor;
        protected ITTTextBoxColumn Description;
        protected ITTButton btnManipulationNewRequest;
        protected ITTTabPage Reports;
        protected ITTButton btnNewHealthCommitee;
        protected ITTButton btnNewParticipatnFreeDrugReport;
        protected ITTButton btnNewHealthCommiteewithThreeSpecialist;
        protected ITTButton btnNewHCExaminationFromOtherDepartments;
        protected ITTButton btnNewProfHealthCommitee;
        protected ITTGroupBox GroupBox3;
        protected ITTTabControl AnalysisPatientTab;
        protected ITTTabPage ExaminationIndicationsTab;
        protected ITTGrid OldPhysicialExaminationsGrid;
        protected ITTDateTimePickerColumn ExaminationDateTime;
        protected ITTRichTextBoxControlColumn ExaminationIndication;
        protected ITTTabPage ExaminationSummaryTab;
        protected ITTTabPage LaboratoryTab;
        protected ITTObjectListBox TestMenuDefinition;
        protected ITTButton btnLabNewRequest;
        protected ITTLabel labelTestActionType;
        protected ITTButton btnLabList;
        protected ITTLabel labelLabEndDate;
        protected ITTButton ttbutton1;
        protected ITTLabel labelLabStartDate;
        protected ITTObjectListBox TestProcedure;
        protected ITTDateTimePicker LabStartDate;
        protected ITTDateTimePicker LabEndDate;
        protected ITTLabel ttlabel2;
        protected ITTGrid LaboratoryResultsGrid;
        protected ITTDateTimePickerColumn ProcedureDate;
        protected ITTTextBoxColumn Procedure;
        protected ITTRichTextBoxControlColumn ProcedureResult;
        protected ITTButtonColumn Detail;
        protected ITTTextBoxColumn ObjectID;
        protected ITTTabPage ConsultationTab;
        protected ITTButton btnConsultationNewRequest;
        protected ITTGrid ConsultationGrid;
        protected ITTDateTimePickerColumn ConsultationDate;
        protected ITTTextBoxColumn RequesterHospital;
        protected ITTTextBoxColumn RequesterDepartment;
        protected ITTTextBoxColumn RequestedHospital;
        protected ITTTextBoxColumn RequestedDepartment;
        protected ITTRichTextBoxControlColumn RequestReason;
        protected ITTRichTextBoxControlColumn ConsultationResultAndOffer;
        protected ITTButton btnNewConsultationFromOtherHospRequest;
        protected ITTButton btnAnesthesiaConsultationNewRequest;
        protected ITTTabPage PreDiagnosisTab;
        protected ITTTabPage TreatmentDischargeTab;
        protected ITTButton btnCreateNewEpicrisis;
        protected ITTButton btnNewForensicMedicalReport;
        protected ITTButton btnNewInpatientAdmission;
        protected ITTButton btnNewTreatmentDischarge;
        protected ITTButton btnNewUnavailableToWorkReport;
        protected ITTTabPage Prescription;
        protected ITTButton btnNewOutPatientPrescription;
        protected ITTTabPage ComplaintTab;
        protected ITTTabPage SystemQueryTab;
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
        protected ITTTabPage EpisodeExaminationMeas;
        protected ITTGrid EpisodeExaminationMeasGrid;
        protected ITTDateTimePickerColumn EpisodeMeasDate;
        protected ITTTextBoxColumn EpisodeHeigth;
        protected ITTTextBoxColumn EpisodeWeigth;
        protected ITTTextBoxColumn EpisodeHeadCircumference;
        protected ITTTextBoxColumn EpisodeChestCircumference;
        protected ITTGroupBox GroupBox1;
        protected ITTButton btnImportantMedicalInfo;
        protected ITTEnumComboBox PatientGroup;
        protected ITTPictureBoxControl PatientPhoto;
        protected ITTRichTextBoxControl ImportantPatientInfo;
        protected ITTLabel labelPatientGroup;
        protected ITTLabel labelSex;
        protected ITTEnumComboBox Sex;
        protected ITTLabel labelAge;
        protected ITTTextBox Age;
        protected ITTLabel labelImportantInfo;
        override protected void InitializeControls()
        {
            GroupBox4 = (ITTGroupBox)AddControl(new Guid("5cac7791-75a6-4576-89f7-93c995b16874"));
            ObservationAndAction = (ITTTabControl)AddControl(new Guid("59235ca0-7c4f-4488-955c-6149c004da5d"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("8a35fd52-f21d-4c52-9e33-8fe659a61c53"));
            GenealogialTreeTab = (ITTTabPage)AddControl(new Guid("c5423437-aed0-4ff1-aa21-06d76c706db2"));
            GenealogicalTreePicture = (ITTPictureBoxControl)AddControl(new Guid("8193f2ae-ed07-4914-a029-2c9f1357e2b9"));
            ManipulationTab = (ITTTabPage)AddControl(new Guid("0f0672fe-3b5e-4f51-b5ac-b7bc41b76279"));
            ManipulationGrid = (ITTGrid)AddControl(new Guid("48465a11-d762-401d-b3b4-a0449c2f1b0e"));
            ManipulationActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("114a3e6b-ca89-442c-8b91-d042b7342e49"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("f7ec8ca4-7473-40e5-a894-277bb0d6103e"));
            Emergency = (ITTCheckBoxColumn)AddControl(new Guid("7b327ce1-12cb-4952-9a51-3fe73e39034f"));
            Department = (ITTListBoxColumn)AddControl(new Guid("6c8ba862-1546-49e9-8443-7f788e90e736"));
            ManipulationDoctor = (ITTListBoxColumn)AddControl(new Guid("14046fcd-448c-47a2-99f1-802a998293c3"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("5bf45a38-af57-4ed6-9965-590507d04653"));
            btnManipulationNewRequest = (ITTButton)AddControl(new Guid("29e5df7c-95ee-43c8-9fce-6741fdc2e7b2"));
            Reports = (ITTTabPage)AddControl(new Guid("13a86f41-885a-4de9-815e-557eb1a4049f"));
            btnNewHealthCommitee = (ITTButton)AddControl(new Guid("fec99b7f-7646-44e6-b899-92a090982f48"));
            btnNewParticipatnFreeDrugReport = (ITTButton)AddControl(new Guid("86850fd4-2596-4675-bf89-9a93ec503418"));
            btnNewHealthCommiteewithThreeSpecialist = (ITTButton)AddControl(new Guid("458db493-42b7-4aa3-83cf-67bb068eed48"));
            btnNewHCExaminationFromOtherDepartments = (ITTButton)AddControl(new Guid("6b744534-ef6b-4a32-b63e-ed504a30fcf0"));
            btnNewProfHealthCommitee = (ITTButton)AddControl(new Guid("4055b43f-3017-4efe-84ad-08ecd876038c"));
            GroupBox3 = (ITTGroupBox)AddControl(new Guid("6cd76ee5-20f4-4b3b-9b77-83efaf8f44dc"));
            AnalysisPatientTab = (ITTTabControl)AddControl(new Guid("90fbb25c-2cc1-45cf-aeee-0bdfe61337a5"));
            ExaminationIndicationsTab = (ITTTabPage)AddControl(new Guid("726d2538-583b-46cb-9778-6229aadeb7a8"));
            OldPhysicialExaminationsGrid = (ITTGrid)AddControl(new Guid("f3df52ef-7439-4c78-b443-0c36fde3bd07"));
            ExaminationDateTime = (ITTDateTimePickerColumn)AddControl(new Guid("8a524d30-e271-4eb3-8859-1350d64fe8a0"));
            ExaminationIndication = (ITTRichTextBoxControlColumn)AddControl(new Guid("734345aa-94ce-4055-8cd8-97edc5599904"));
            ExaminationSummaryTab = (ITTTabPage)AddControl(new Guid("d12d9591-aace-425e-aa0c-953d218e4add"));
            LaboratoryTab = (ITTTabPage)AddControl(new Guid("ab70751d-89e4-4420-968d-fdd525f77f4a"));
            TestMenuDefinition = (ITTObjectListBox)AddControl(new Guid("b6af0cf3-8ce8-4421-ad2a-3decc3cd3b5a"));
            btnLabNewRequest = (ITTButton)AddControl(new Guid("e7439898-27df-46ee-9409-7faf50ddb166"));
            labelTestActionType = (ITTLabel)AddControl(new Guid("cc10da54-08ec-4a48-8850-7985b875e87f"));
            btnLabList = (ITTButton)AddControl(new Guid("2a233aaf-efde-46b9-979a-1d8aa135b891"));
            labelLabEndDate = (ITTLabel)AddControl(new Guid("24e43f48-667a-497c-8307-98f02c60f3d3"));
            ttbutton1 = (ITTButton)AddControl(new Guid("7e21a67c-1e1b-4007-bdcc-8f15af8d2f0e"));
            labelLabStartDate = (ITTLabel)AddControl(new Guid("5a765e17-cb34-4e2a-9740-ed14dce992af"));
            TestProcedure = (ITTObjectListBox)AddControl(new Guid("ff280f82-8f67-48ed-9327-348cf31c2a6a"));
            LabStartDate = (ITTDateTimePicker)AddControl(new Guid("31561602-3bb8-4203-a730-b17e1735abf8"));
            LabEndDate = (ITTDateTimePicker)AddControl(new Guid("4f3a2ab0-0328-4396-af5f-b446a02ca2b1"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("045b008d-84e7-4353-91de-ac115062275e"));
            LaboratoryResultsGrid = (ITTGrid)AddControl(new Guid("1c050727-77c5-49ff-9b93-0d68079dd687"));
            ProcedureDate = (ITTDateTimePickerColumn)AddControl(new Guid("6e31740b-d000-4bff-9742-aba6237f6d2a"));
            Procedure = (ITTTextBoxColumn)AddControl(new Guid("e1e53ccd-00a5-4385-84a4-c770d3210734"));
            ProcedureResult = (ITTRichTextBoxControlColumn)AddControl(new Guid("3796c9f3-7041-4b26-8a0e-736702688e90"));
            Detail = (ITTButtonColumn)AddControl(new Guid("6baffa44-42c0-4473-96bf-cf93934a914a"));
            ObjectID = (ITTTextBoxColumn)AddControl(new Guid("f198675b-8818-4acc-b369-a3d70d01c81e"));
            ConsultationTab = (ITTTabPage)AddControl(new Guid("deb8ecf6-a68e-4297-b5a8-a9317ec72515"));
            btnConsultationNewRequest = (ITTButton)AddControl(new Guid("507ac439-d19c-44b7-8ea6-ef4f19420154"));
            ConsultationGrid = (ITTGrid)AddControl(new Guid("622eca6b-1a72-4713-8076-1cedeb09034a"));
            ConsultationDate = (ITTDateTimePickerColumn)AddControl(new Guid("29e10ece-67de-4a0a-bac0-eb9d26d0ccab"));
            RequesterHospital = (ITTTextBoxColumn)AddControl(new Guid("494c98aa-222e-4fcb-8a6b-7b2322f115c1"));
            RequesterDepartment = (ITTTextBoxColumn)AddControl(new Guid("aeb87867-56e6-4a1a-a752-c74395f5a276"));
            RequestedHospital = (ITTTextBoxColumn)AddControl(new Guid("84f9ff9f-183f-4295-b331-c71a54f55316"));
            RequestedDepartment = (ITTTextBoxColumn)AddControl(new Guid("a564346a-c9ff-4a84-af61-d153a3170b85"));
            RequestReason = (ITTRichTextBoxControlColumn)AddControl(new Guid("be9331d3-de2f-47b3-9fe4-4c77de4d8e52"));
            ConsultationResultAndOffer = (ITTRichTextBoxControlColumn)AddControl(new Guid("2cd36fba-84ad-4fa8-858b-0a512445ba38"));
            btnNewConsultationFromOtherHospRequest = (ITTButton)AddControl(new Guid("c8c1a71f-64c4-4dde-a676-f5192519cfd7"));
            btnAnesthesiaConsultationNewRequest = (ITTButton)AddControl(new Guid("9f730117-e20b-41da-b5a3-1af0aa5bba1c"));
            PreDiagnosisTab = (ITTTabPage)AddControl(new Guid("a242521b-ba48-4ba2-baae-4dfff62e6a49"));
            TreatmentDischargeTab = (ITTTabPage)AddControl(new Guid("bbc3973e-6f7e-46ae-8a5b-7fb360e490f2"));
            btnCreateNewEpicrisis = (ITTButton)AddControl(new Guid("39014356-1251-4c4a-a186-6b6ad9ce3ede"));
            btnNewForensicMedicalReport = (ITTButton)AddControl(new Guid("c0d556d0-ffd4-48b6-8a35-1bf0f1b86984"));
            btnNewInpatientAdmission = (ITTButton)AddControl(new Guid("2b23b7ca-96d7-48bd-b06f-7e132bfb3cc3"));
            btnNewTreatmentDischarge = (ITTButton)AddControl(new Guid("b4f4df30-7096-4bb3-8a04-86c71774baf0"));
            btnNewUnavailableToWorkReport = (ITTButton)AddControl(new Guid("e8b25b15-0c73-4024-9f74-e94fcba51625"));
            Prescription = (ITTTabPage)AddControl(new Guid("c86dd8d1-d545-451f-9589-9fb3299788fa"));
            btnNewOutPatientPrescription = (ITTButton)AddControl(new Guid("e1160100-26d4-4c76-9ebc-5d44f8816435"));
            ComplaintTab = (ITTTabPage)AddControl(new Guid("5528540a-025b-4d7a-ba2f-da4cec6b5ad4"));
            SystemQueryTab = (ITTTabPage)AddControl(new Guid("8a5c7acf-225c-4f4a-a5c6-3db36ebb401b"));
            ExaminationMeasTab = (ITTTabPage)AddControl(new Guid("a5a54384-9fd2-4b0c-8286-45fbd7199b62"));
            ExaminationMeases = (ITTGrid)AddControl(new Guid("fa3f0772-3b5e-4632-b791-cdedf8fcd347"));
            MeasDateExaminationMeasGrid = (ITTDateTimePickerColumn)AddControl(new Guid("00e19ddc-f8e1-4f41-a26b-d6793f13b216"));
            HeigthExaminationMeasGrid = (ITTTextBoxColumn)AddControl(new Guid("4a8a3bce-d828-4c01-a4cd-49bfb3d02bc1"));
            WeightExaminationMeasGrid = (ITTTextBoxColumn)AddControl(new Guid("a03357c4-298d-4f85-858c-03a31f32fa78"));
            HeadCircumferenceExaminationMeasGrid = (ITTTextBoxColumn)AddControl(new Guid("f0c21492-49fb-4218-9340-b58bc6688f87"));
            ChestCircumferenceExaminationMeasGrid = (ITTTextBoxColumn)AddControl(new Guid("ccbe245f-3676-4567-84e8-8e62a490275a"));
            GroupBox2 = (ITTGroupBox)AddControl(new Guid("febd30a7-fcea-4f41-a3dc-c82504da99cc"));
            ContinuousInfoTab = (ITTTabControl)AddControl(new Guid("ae6bf7c0-2fa7-4300-84ad-e79a70a6d6fd"));
            ImportantDiagnosisTab = (ITTTabPage)AddControl(new Guid("103aca8f-2e50-4873-9c0c-9bce1bc9c534"));
            DiagnosisHistory = (ITTGrid)AddControl(new Guid("784afaec-3472-49f1-8f69-02545fdcd229"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("6feac7b3-2630-4afe-801c-99dfd65be94a"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("30bd9646-33ae-4105-86eb-6ea86f61a4d5"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("c09577c1-87d8-4046-b768-d7b9be68fa39"));
            DiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("70c4d073-4a90-4888-b288-87a4758d4175"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("bf912901-58bb-4f36-ae8b-c9c081f3b896"));
            HealthCommiteeActionsTab = (ITTTabPage)AddControl(new Guid("c3dcfac2-81b7-43e2-97a1-a6b6ab7c88d8"));
            HealthCommiteeActions = (ITTGrid)AddControl(new Guid("41523ff9-5470-47ca-9e57-cecaa6a626ed"));
            Hospital = (ITTTextBoxColumn)AddControl(new Guid("58edd41e-f60f-4a9e-b14a-89da0429811a"));
            HealthCommiteeActionID = (ITTTextBoxColumn)AddControl(new Guid("75decb75-e4c6-4f8e-a522-73c70f01808a"));
            HealthCommiteeActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("0ea69fc7-7610-4d43-9a9a-9bd6bad6d962"));
            HCObjectID = (ITTTextBoxColumn)AddControl(new Guid("2c878261-d322-463f-8416-4354979c5a8c"));
            PatientFamilyHistoryTab = (ITTTabPage)AddControl(new Guid("618a3078-bd06-4ee5-8328-5cbe57fd1124"));
            HabitsTab = (ITTTabPage)AddControl(new Guid("7b7609db-1535-4cfc-8c72-94984af571be"));
            ContinuousDrugsTab = (ITTTabPage)AddControl(new Guid("93713737-aeab-4d5b-89f4-8ffe3c5285fe"));
            EpisodeExaminationMeas = (ITTTabPage)AddControl(new Guid("e749ff53-caa5-4820-bec4-289e6ac8e5bf"));
            EpisodeExaminationMeasGrid = (ITTGrid)AddControl(new Guid("2b9576e0-a160-44cd-9bdd-6e6a2b9caddc"));
            EpisodeMeasDate = (ITTDateTimePickerColumn)AddControl(new Guid("c9d4c54a-65fa-49d7-bae9-11a01a777e61"));
            EpisodeHeigth = (ITTTextBoxColumn)AddControl(new Guid("7c9e3323-eab1-4084-99d8-3a8a347dd5c5"));
            EpisodeWeigth = (ITTTextBoxColumn)AddControl(new Guid("5fad1566-2ca9-43e9-8eaf-e3abcf83d827"));
            EpisodeHeadCircumference = (ITTTextBoxColumn)AddControl(new Guid("d085af24-eab2-41da-b07e-841a2e824b1e"));
            EpisodeChestCircumference = (ITTTextBoxColumn)AddControl(new Guid("71b6db22-de6f-4c42-bff1-99e667bf7310"));
            GroupBox1 = (ITTGroupBox)AddControl(new Guid("199e338d-d540-49a0-8e1f-93d4306da77d"));
            btnImportantMedicalInfo = (ITTButton)AddControl(new Guid("86ab2b39-69bf-4221-bc0d-ae223afb6806"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("f113c612-b80b-47ab-baa1-43dcde4f90ae"));
            PatientPhoto = (ITTPictureBoxControl)AddControl(new Guid("a023cbc1-f92f-4792-be91-157407f5137f"));
            ImportantPatientInfo = (ITTRichTextBoxControl)AddControl(new Guid("1ce4aa06-22ef-439b-a5f2-09a2f5326495"));
            labelPatientGroup = (ITTLabel)AddControl(new Guid("1edadcb6-327b-4823-8f9c-6045676c3949"));
            labelSex = (ITTLabel)AddControl(new Guid("ec68373f-ca6c-4778-bade-94254d43def0"));
            Sex = (ITTEnumComboBox)AddControl(new Guid("f446108f-b77f-4248-bb77-f607bf0266b1"));
            labelAge = (ITTLabel)AddControl(new Guid("55e9b1be-4a82-4627-bcb5-44149757ed81"));
            Age = (ITTTextBox)AddControl(new Guid("e8c0124a-e7e1-4e50-917f-20242b9523da"));
            labelImportantInfo = (ITTLabel)AddControl(new Guid("2831355f-7daf-4faa-b22e-947357ea6f1f"));
            base.InitializeControls();
        }

        public BaseDoctorExaminationForm() : base("EPISODEACTION", "BaseDoctorExaminationForm")
        {
        }

        protected BaseDoctorExaminationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}