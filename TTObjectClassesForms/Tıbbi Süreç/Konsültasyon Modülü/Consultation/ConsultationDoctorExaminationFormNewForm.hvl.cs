
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
    public partial class ConsultationDoctorExaminationFormNew : BaseNewDoctorExaminationForm
    {
        protected TTObjectClasses.Consultation _Consultation
        {
            get { return (TTObjectClasses.Consultation)_ttObject; }
        }

        protected ITTTabControl tabMedicalInformation;
        protected ITTTabPage tttabpageMedicalInformation;
        protected ITTLabel labelChronicDiseases;
        protected ITTLabel labelHemodialysis;
        protected ITTLabel labelImplant;
        protected ITTLabel labelOncologicFollowUp;
        protected ITTLabel labelOtherInformation;
        protected ITTCheckBox Pregnancy;
        protected ITTTextBox ChronicDiseases;
        protected ITTLabel labelTransplantation;
        protected ITTGroupBox ttgroupboxHabits;
        protected ITTCheckBox CigaretteMedicalInfoHabits;
        protected ITTObjectListBox CigaretteUsageFrequencyMedicalInfoHabits;
        protected ITTLabel labelDescriptionMedicalInfoHabits;
        protected ITTCheckBox OtherMedicalInfoHabits;
        protected ITTTextBox DescriptionMedicalInfoHabits;
        protected ITTCheckBox TeaMedicalInfoHabits;
        protected ITTLabel labelAlcoholUsageFrequencyMedicalInfoHabits;
        protected ITTCheckBox AlcoholMedicalInfoHabits;
        protected ITTObjectListBox AlcoholUsageFrequencyMedicalInfoHabits;
        protected ITTLabel labelCigaretteUsageFrequencyMedicalInfoHabits;
        protected ITTCheckBox CoffeeMedicalInfoHabits;
        protected ITTGroupBox ttgroupboxDisability;
        protected ITTCheckBox ChronicMedicalInfoDisabledGroup;
        protected ITTCheckBox NonexistenceMedicalInfoDisabledGroup;
        protected ITTCheckBox HearingMedicalInfoDisabledGroup;
        protected ITTCheckBox MentalMedicalInfoDisabledGroup;
        protected ITTCheckBox OrthopedicMedicalInfoDisabledGroup;
        protected ITTCheckBox PsychicAndEmotionalMedicalInfoDisabledGroup;
        protected ITTCheckBox SpeechAndLanguageMedicalInfoDisabledGroup;
        protected ITTCheckBox VisionMedicalInfoDisabledGroup;
        protected ITTCheckBox UnclassifiedMedicalInfoDisabledGroup;
        protected ITTGroupBox ttgroupboxAllergies;
        protected ITTGrid MedicalInfoFoodAllergiesMedicalInfoFoodAllergies;
        protected ITTListBoxColumn DietMaterialMedicalInfoFoodAllergies;
        protected ITTGrid MedicalInfoDrugAllergiesMedicalInfoDrugAllergies;
        protected ITTListBoxColumn ActiveIngredientMedicalInfoDrugAllergies;
        protected ITTTextBox OtherAllergiesMedicalInfoAllergies;
        protected ITTLabel labelOtherAllergiesMedicalInfoAllergies;
        protected ITTTextBox Hemodialysis;
        protected ITTTextBox Transplantation;
        protected ITTTextBox Implant;
        protected ITTTextBox OtherInformation;
        protected ITTTextBox OncologicFollowUp;
        protected ITTPanel ttpanelPoliclinic;
        protected ITTRichTextBoxControl ttrichtextboxcontrol4;
        protected ITTCheckBox InPatientBed;
        protected ITTLabel lblProcessEndDate;
        protected ITTObjectListBox ProceduerDoctor;
        protected ITTLabel lblProcessDate;
        protected ITTGrid GridDiagnosis;
        protected ITTListBoxColumn SecDiagnose;
        protected ITTTextBoxColumn SecFreeDiagnosis;
        protected ITTCheckBoxColumn SecIsMainDiagnose;
        protected ITTListBoxColumn SecResponsibleUser;
        protected ITTDateTimePickerColumn SecDiagnoseDate;
        protected ITTObjectListBox RequesterDepatment;
        protected ITTDateTimePicker dtpProcessEndDate;
        protected ITTLabel ttlabel8;
        protected ITTPictureBoxControl ttpictureboxcontrol1;
        protected ITTCheckBox ttcheckbox2;
        protected ITTDateTimePicker ProcessDate;
        protected ITTLabel labelProcedureDoctor;
        protected ITTLabel lblPatientAdmissionGeneralInfo;
        protected ITTObjectListBox RequestedDoctor;
        protected ITTLabel labelRequesterDepatment;
        protected ITTObjectListBox MasterResource;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel10;
        protected ITTTabControl tttabcontrolPoliclinic;
        protected ITTTabPage tttabpageKonsultasyon;
        protected ITTRichTextBoxControl ttrichtextboxcontrol7;
        protected ITTRichTextBoxControl rtfHistory;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage EkUygulamalarTab;
        protected ITTGrid GridAdditionalApplications;
        protected ITTDateTimePickerColumn SDateTime;
        protected ITTListBoxColumn AProcedureObject;
        protected ITTListBoxColumn AdditionalProcedureDoctor;
        protected ITTTextBoxColumn Result;
        protected ITTTextBoxColumn NurseNotes;
        protected ITTListBoxColumn AdditionalMasterResource;
        protected ITTTabPage MlzSarfTab;
        protected ITTGrid GridTreatmentMaterials;
        protected ITTDateTimePickerColumn TreatmentMaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn UBBCode;
        protected ITTTextBoxColumn Amount;
        protected ITTListBoxColumn OzelDurum;
        protected ITTTextBoxColumn Notes;
        protected ITTButtonColumn CokluOzelDurum;
        protected ITTTextBoxColumn KodsuzMalzemeFiyatı;
        protected ITTListBoxColumn MalzemeTuru;
        protected ITTTextBoxColumn Kdv;
        protected ITTTextBoxColumn MalzemeBrans;
        protected ITTDateTimePickerColumn SatinAlisTarihi;
        protected ITTTabPage tttabpage4;
        protected ITTGrid ConsultationGrid;
        protected ITTDateTimePickerColumn ConsultationDate;
        protected ITTTextBoxColumn RequesterHospital;
        protected ITTTextBoxColumn RequesterDepartment;
        protected ITTTextBoxColumn RequestedHospital;
        protected ITTTextBoxColumn RequestedDepartment;
        protected ITTRichTextBoxControlColumn RequestReason;
        protected ITTRichTextBoxControlColumn ConsultationResultAndOffer;
        protected ITTButton btnConsultationRequest;
        protected ITTCheckBox chkConsultationInPatientBed;
        protected ITTCheckBox chkConsultationEmergency;
        protected ITTRichTextBoxControl ttrichtextboxcontrol17;
        protected ITTLabel lblConsultationRequestedUser;
        protected ITTObjectListBox ConsultationRequestedUser;
        protected ITTLabel lblConsultationRequestedResource;
        protected ITTObjectListBox ConsultationRequestedResource;
        protected ITTGrid GrdConsultation;
        protected ITTListBoxColumn RequestedResource;
        protected ITTListBoxColumn ttlistboxcolumn8;
        protected ITTRichTextBoxControlColumn RequestDescription;
        protected ITTCheckBoxColumn chkEmergency;
        protected ITTCheckBoxColumn chkInPatientBed;
        protected ITTTabPage tttabpage5;
        protected ITTPanel pnlRightBottom;
        protected ITTRichTextBoxControl ttrichtextboxcontrol11;
        protected ITTCheckBox IsTreatmentMaterialEmpty;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTRichTextBoxControl ttrichtextboxcontrol3;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTabPage tttabpageIstemPaneli;
        protected ITTTabPage tttabpageEOrder;
        protected ITTGrid GridNursingOrders;
        protected ITTButtonColumn RPT;
        protected ITTDateTimePickerColumn OrderActionDate;
        protected ITTListBoxColumn OrderProcedureObject;
        protected ITTDateTimePickerColumn PeriodStartTime;
        protected ITTDateTimePickerColumn ExecutionDate;
        protected ITTTextBoxColumn NursingApplicationResult;
        protected ITTTextBoxColumn NursingApplicationNurseNote;
        protected ITTButtonColumn CreateOrderDetailBeforeSave;
        protected ITTTabPage tttabpageSagRapor;
        protected ITTButton btnReports;
        protected ITTTabPage tttabpageHastaGeçmişi;
        protected ITTTabControl tttabcontrol3;
        protected ITTTabPage HealthCommiteeActionsTab;
        protected ITTGrid HealthCommiteeActions;
        protected ITTTextBoxColumn Hospital;
        protected ITTTextBoxColumn HealthCommiteeActionID;
        protected ITTDateTimePickerColumn HealthCommiteeActionDate;
        protected ITTTextBoxColumn HCObjectID;
        protected ITTTabPage tttabpage15;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTTextBoxColumn EpisodeFreeDiagnosis;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTGrid DiagnosisHistory;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTListBoxColumn Diagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTEnumComboBoxColumn DiagnosisType;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTLabel lblOldDiagnosis;
        protected ITTLabel lblEpisodeDiagnosis;
        protected ITTTabPage tttabpage16;
        protected ITTGrid ManipulationGrid;
        protected ITTDateTimePickerColumn ManipulationActionDate;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTCheckBoxColumn Emergency;
        protected ITTListBoxColumn Department;
        protected ITTListBoxColumn ManipulationDoctor;
        protected ITTTextBoxColumn Description;
        protected ITTTabPage tttabpage17;
        protected ITTGrid OldPhysicialExaminationsGrid;
        protected ITTDateTimePickerColumn ExaminationDateTime;
        protected ITTRichTextBoxControlColumn ExaminationIndication;
        protected ITTTabPage tttabpage18;
        protected ITTRichTextBoxControl ttrichtextboxcontrol10;
        override protected void InitializeControls()
        {
            tabMedicalInformation = (ITTTabControl)AddControl(new Guid("a9f9f7de-f8b4-434a-9526-ff5767c71502"));
            tttabpageMedicalInformation = (ITTTabPage)AddControl(new Guid("9b511fbd-7e58-40f4-8f1c-a940ac5ccb45"));
            labelChronicDiseases = (ITTLabel)AddControl(new Guid("77336ec9-6996-4655-8e37-c3dd0a41ff54"));
            labelHemodialysis = (ITTLabel)AddControl(new Guid("176d62b1-fbb8-415a-8d65-9fac8a74a127"));
            labelImplant = (ITTLabel)AddControl(new Guid("9120488d-7759-48c8-94ec-ba54b1da8795"));
            labelOncologicFollowUp = (ITTLabel)AddControl(new Guid("d56827ab-35cf-4079-b03d-7a5eb6116b08"));
            labelOtherInformation = (ITTLabel)AddControl(new Guid("9ea5ef61-b44f-41bf-8041-562d49f18059"));
            Pregnancy = (ITTCheckBox)AddControl(new Guid("9ccf4ab5-13aa-4bda-a601-ad462dba1ccf"));
            ChronicDiseases = (ITTTextBox)AddControl(new Guid("15f4f593-b36f-49da-9759-7651a2aa5dd4"));
            labelTransplantation = (ITTLabel)AddControl(new Guid("9483bc67-9861-4c36-92b2-009e17658fec"));
            ttgroupboxHabits = (ITTGroupBox)AddControl(new Guid("a504b0dc-161f-43ec-81c1-0e2ee8477e38"));
            CigaretteMedicalInfoHabits = (ITTCheckBox)AddControl(new Guid("c5d59516-b7e3-473b-820c-b46dc95e4dd2"));
            CigaretteUsageFrequencyMedicalInfoHabits = (ITTObjectListBox)AddControl(new Guid("57ad44a4-ddff-46b0-9961-c3e020a9e709"));
            labelDescriptionMedicalInfoHabits = (ITTLabel)AddControl(new Guid("e163f39a-0e28-46e3-8c6c-29c8210e186e"));
            OtherMedicalInfoHabits = (ITTCheckBox)AddControl(new Guid("ad262843-a66a-4aa0-b9a1-f0296ff49818"));
            DescriptionMedicalInfoHabits = (ITTTextBox)AddControl(new Guid("a35eec3a-a5db-4ef2-b184-65761b645557"));
            TeaMedicalInfoHabits = (ITTCheckBox)AddControl(new Guid("0faa9297-3a43-40c7-b40a-066bc535f38f"));
            labelAlcoholUsageFrequencyMedicalInfoHabits = (ITTLabel)AddControl(new Guid("efd74e6f-a508-440d-ba1d-aedd9d430bab"));
            AlcoholMedicalInfoHabits = (ITTCheckBox)AddControl(new Guid("bb2b463a-dc18-4040-bb93-da6006802670"));
            AlcoholUsageFrequencyMedicalInfoHabits = (ITTObjectListBox)AddControl(new Guid("94b4e816-f726-4276-a0a6-4b012225ebdf"));
            labelCigaretteUsageFrequencyMedicalInfoHabits = (ITTLabel)AddControl(new Guid("a51b6696-5243-4512-bec3-326f50a0c577"));
            CoffeeMedicalInfoHabits = (ITTCheckBox)AddControl(new Guid("60bfd79c-22ba-4368-83dd-785e50140251"));
            ttgroupboxDisability = (ITTGroupBox)AddControl(new Guid("e33eb5a0-dfc1-40f7-9c01-800d5d451945"));
            ChronicMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("8232659a-4aca-4796-9e32-60caa84a9ad3"));
            NonexistenceMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("b909a649-c6e9-4a81-87ca-7562666849ac"));
            HearingMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("e3bf55fa-dc66-403e-ada8-3c7c4fc83e60"));
            MentalMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("ea39d1aa-8e29-4eea-bf04-3baa7b394091"));
            OrthopedicMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("790ad237-6cde-4fba-a409-6abeec076288"));
            PsychicAndEmotionalMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("aba2e6ae-dfb4-4df8-8388-a6bcd82da140"));
            SpeechAndLanguageMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("ddc48464-8ecd-4483-8599-38e7c6f3b4fc"));
            VisionMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("8b326653-7ddf-418a-9249-8413b0a887a0"));
            UnclassifiedMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("3496751c-1efd-42cd-b07d-24b7d5ceaaa1"));
            ttgroupboxAllergies = (ITTGroupBox)AddControl(new Guid("2ce50f13-0b56-46cb-adb8-1af852c2834c"));
            MedicalInfoFoodAllergiesMedicalInfoFoodAllergies = (ITTGrid)AddControl(new Guid("03910c54-a624-4207-a183-e3802684ad5c"));
            DietMaterialMedicalInfoFoodAllergies = (ITTListBoxColumn)AddControl(new Guid("665cb848-f722-49b1-885e-fa116f3925ca"));
            MedicalInfoDrugAllergiesMedicalInfoDrugAllergies = (ITTGrid)AddControl(new Guid("dcaadcd7-acf7-4687-9d04-1666d4b7494f"));
            ActiveIngredientMedicalInfoDrugAllergies = (ITTListBoxColumn)AddControl(new Guid("2dfb836d-ed38-475b-89ab-e9659f14610a"));
            OtherAllergiesMedicalInfoAllergies = (ITTTextBox)AddControl(new Guid("611cfa3a-3ea3-4bf4-930a-1dbbe172c6d5"));
            labelOtherAllergiesMedicalInfoAllergies = (ITTLabel)AddControl(new Guid("9b7ea78a-5838-492e-a28e-b27d0a49fd2d"));
            Hemodialysis = (ITTTextBox)AddControl(new Guid("46261c4c-eb7c-46ea-9a7f-dd031bfadee2"));
            Transplantation = (ITTTextBox)AddControl(new Guid("eaed1504-4efd-4474-8eaa-e69489f2342b"));
            Implant = (ITTTextBox)AddControl(new Guid("58c5909b-1ee3-499e-8248-c380468fba57"));
            OtherInformation = (ITTTextBox)AddControl(new Guid("a55e27b0-0275-42e5-a5a9-9582f02c87a6"));
            OncologicFollowUp = (ITTTextBox)AddControl(new Guid("e6465b99-adc5-42f9-8009-efa7ed02aa3b"));
            ttpanelPoliclinic = (ITTPanel)AddControl(new Guid("73b65109-9722-4938-bff0-9cad80f9c8ec"));
            ttrichtextboxcontrol4 = (ITTRichTextBoxControl)AddControl(new Guid("dbd7e5d2-3188-45c2-a13b-a435fe01d99f"));
            InPatientBed = (ITTCheckBox)AddControl(new Guid("b844f866-a966-4e70-9caf-629791f514ca"));
            lblProcessEndDate = (ITTLabel)AddControl(new Guid("d39e008a-ae55-44c7-a45f-e5b5314f3913"));
            ProceduerDoctor = (ITTObjectListBox)AddControl(new Guid("305a2a62-12a9-4983-9cc0-4854ea8e3218"));
            lblProcessDate = (ITTLabel)AddControl(new Guid("a8486930-8f8d-4cb6-80d8-1265bb6a16fe"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("1ebdc304-43cd-4e61-a1ad-14c90cdb5cf9"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("0615318c-32b1-4201-99af-9e90a05cc390"));
            SecFreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("d993cb84-e6e1-4a67-8093-ac2d1def402f"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("ed8cdc9f-89fb-4dcf-bbd3-15c1a8b99bb1"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("a40e0953-8a24-4e9e-ba7b-45caf7f7e703"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("a3006a6a-d939-4abe-a7c1-f2394b1414ca"));
            RequesterDepatment = (ITTObjectListBox)AddControl(new Guid("9c83962f-88af-44f7-a92b-18b28ca8dc67"));
            dtpProcessEndDate = (ITTDateTimePicker)AddControl(new Guid("2fb2458a-1915-46cd-917a-123613c77374"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("58067021-ea20-4960-8de5-466e9dd975a1"));
            ttpictureboxcontrol1 = (ITTPictureBoxControl)AddControl(new Guid("50354d25-3264-45a7-a22d-b666b0c495be"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("7fd794a6-b870-47c2-b14d-eefec05e74ca"));
            ProcessDate = (ITTDateTimePicker)AddControl(new Guid("e893be47-921f-4515-95bb-518c8b4b154e"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("6efac523-4844-46e2-b175-f6666e022bdf"));
            lblPatientAdmissionGeneralInfo = (ITTLabel)AddControl(new Guid("994d14e2-dd5e-4936-94b6-cf26fdb6e0a2"));
            RequestedDoctor = (ITTObjectListBox)AddControl(new Guid("091be51c-0a05-4edf-aef4-5c28d56d959c"));
            labelRequesterDepatment = (ITTLabel)AddControl(new Guid("71f3a686-e346-4613-aed1-0def639267f6"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("c25707a1-992d-4bac-b2ba-9f4b08dcebe1"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("9fccd575-4790-4bd2-9478-737aa663f4b4"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("1a1ef865-64f2-4515-9d48-961db8774b2e"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("b4a9c43f-d1df-473d-aec5-fca5e1d811c8"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("6c8ab20f-9624-4f88-a17d-38d7be424082"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("5c463eeb-0a37-4124-8807-e9b47389cb8e"));
            tttabcontrolPoliclinic = (ITTTabControl)AddControl(new Guid("c86f6932-6c5b-4877-a09f-d27d40d10a6d"));
            tttabpageKonsultasyon = (ITTTabPage)AddControl(new Guid("c8aba5f4-77cc-4361-a24c-302a290bd090"));
            ttrichtextboxcontrol7 = (ITTRichTextBoxControl)AddControl(new Guid("8b9988d5-269d-4e83-a0d9-4adcda0db6d1"));
            rtfHistory = (ITTRichTextBoxControl)AddControl(new Guid("e8e91ec6-26e2-4d43-82e3-d2b665e37e76"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("f03a247d-4b29-4bdb-8422-8b0a28d25980"));
            EkUygulamalarTab = (ITTTabPage)AddControl(new Guid("4841768c-1157-4330-9381-78d7d8f2d736"));
            GridAdditionalApplications = (ITTGrid)AddControl(new Guid("d0761e60-d8b7-4e0e-94d6-1b847a31bfdd"));
            SDateTime = (ITTDateTimePickerColumn)AddControl(new Guid("53e57702-82ab-4a4f-9cea-3e8f033554c2"));
            AProcedureObject = (ITTListBoxColumn)AddControl(new Guid("263e70d6-9d5a-426c-8fae-77613b34e58e"));
            AdditionalProcedureDoctor = (ITTListBoxColumn)AddControl(new Guid("104c9229-8788-4c18-8174-750931331434"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("816aec64-9843-4780-8803-5dc7ae06d93d"));
            NurseNotes = (ITTTextBoxColumn)AddControl(new Guid("b9aa950c-edf0-4ecc-ba4a-c2826d668bcf"));
            AdditionalMasterResource = (ITTListBoxColumn)AddControl(new Guid("937e5b17-9fb4-41d3-bf9f-1f476819dc7d"));
            MlzSarfTab = (ITTTabPage)AddControl(new Guid("d4c3ebb5-fe5b-4d40-9f74-07a45233ae91"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("0cf069f5-9c27-463a-b643-5e5387cce6a7"));
            TreatmentMaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("0730e6d1-e52f-48a5-88ed-7f70e18b8c13"));
            Material = (ITTListBoxColumn)AddControl(new Guid("fda524e8-7721-459a-80f4-9a3eadf32d40"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("cb17078d-f91e-4c7a-b8b1-7ff18a23c0be"));
            UBBCode = (ITTTextBoxColumn)AddControl(new Guid("e9db0cd9-4cc3-46d4-a754-5f36539b9d31"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("6bc6fe2a-d515-4bbe-a960-1f5688a5bc49"));
            OzelDurum = (ITTListBoxColumn)AddControl(new Guid("3422e169-2da9-4031-95cd-72a1803151a5"));
            Notes = (ITTTextBoxColumn)AddControl(new Guid("fc2b1c63-5284-4440-8e82-bfe0b3fe55e1"));
            CokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("7be69759-bb79-4075-8cb0-c2bac62de4cd"));
            KodsuzMalzemeFiyatı = (ITTTextBoxColumn)AddControl(new Guid("23f2430f-6eed-4675-8097-a3a0e32cabee"));
            MalzemeTuru = (ITTListBoxColumn)AddControl(new Guid("537693ad-b799-4722-b4bf-b45deeac334f"));
            Kdv = (ITTTextBoxColumn)AddControl(new Guid("de442814-6555-42ae-afcd-8ce706bcf0a8"));
            MalzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("a2994213-662f-4ac2-b554-b751291a4fb5"));
            SatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("438ea9c3-94ef-4930-8663-442740ebce96"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("1c4046e8-c313-47a4-8860-ae7c400d0975"));
            ConsultationGrid = (ITTGrid)AddControl(new Guid("57e3efd9-0dd9-4ae1-a621-ec08d968f55d"));
            ConsultationDate = (ITTDateTimePickerColumn)AddControl(new Guid("bd3bc147-defd-4760-8d50-565d28e7c0bc"));
            RequesterHospital = (ITTTextBoxColumn)AddControl(new Guid("011c14b1-ccfe-4dc7-85dc-b1707844fe08"));
            RequesterDepartment = (ITTTextBoxColumn)AddControl(new Guid("2291c080-aea8-434f-a275-0f3f38ad925b"));
            RequestedHospital = (ITTTextBoxColumn)AddControl(new Guid("ace7592e-5396-49df-bca2-23e9cc787552"));
            RequestedDepartment = (ITTTextBoxColumn)AddControl(new Guid("e24f88d9-a52b-4db1-a43d-15197f703b4b"));
            RequestReason = (ITTRichTextBoxControlColumn)AddControl(new Guid("4f7e9438-a517-4dd4-a796-18e315eecf1e"));
            ConsultationResultAndOffer = (ITTRichTextBoxControlColumn)AddControl(new Guid("a8a4c807-d0c5-4286-8b6f-e4d7c25776ca"));
            btnConsultationRequest = (ITTButton)AddControl(new Guid("395cb4bc-84cf-4bdd-8e17-2aa81d64995e"));
            chkConsultationInPatientBed = (ITTCheckBox)AddControl(new Guid("f8afab0d-5dc8-402c-ba69-bdb499a91b1e"));
            chkConsultationEmergency = (ITTCheckBox)AddControl(new Guid("5526e9a8-bca5-4449-bd81-2936df33080a"));
            ttrichtextboxcontrol17 = (ITTRichTextBoxControl)AddControl(new Guid("de96b708-73d4-42de-a4aa-374c0675ebe6"));
            lblConsultationRequestedUser = (ITTLabel)AddControl(new Guid("19d850a9-68fb-433d-99e3-e8f5e032051e"));
            ConsultationRequestedUser = (ITTObjectListBox)AddControl(new Guid("15599840-83d2-4281-8588-db254107092e"));
            lblConsultationRequestedResource = (ITTLabel)AddControl(new Guid("5ba27261-13f3-4464-bed7-8a758d7b6cdd"));
            ConsultationRequestedResource = (ITTObjectListBox)AddControl(new Guid("0516d801-ceed-482c-b214-a2601fe77dde"));
            GrdConsultation = (ITTGrid)AddControl(new Guid("6b19dc6a-4a39-46c0-aef4-3027fdec7a39"));
            RequestedResource = (ITTListBoxColumn)AddControl(new Guid("094f57d7-abcc-471d-9203-7e4598e4a3b7"));
            ttlistboxcolumn8 = (ITTListBoxColumn)AddControl(new Guid("3681ada2-e7a2-49c3-a9de-a7bcf168ef9b"));
            RequestDescription = (ITTRichTextBoxControlColumn)AddControl(new Guid("a624827e-87a4-4b77-8802-4605a2e6c650"));
            chkEmergency = (ITTCheckBoxColumn)AddControl(new Guid("e1d20985-c882-4afa-aead-ed0454e4a24d"));
            chkInPatientBed = (ITTCheckBoxColumn)AddControl(new Guid("3111406d-f9f0-4949-a1ba-1ac9c3c70233"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("d7913b22-551f-4a0b-8ae2-4699acae3b13"));
            pnlRightBottom = (ITTPanel)AddControl(new Guid("b9a41c25-8493-4820-822a-7fb9070c62ab"));
            ttrichtextboxcontrol11 = (ITTRichTextBoxControl)AddControl(new Guid("a785b69f-3f40-4cb5-83f3-63db602d6074"));
            IsTreatmentMaterialEmpty = (ITTCheckBox)AddControl(new Guid("7bb433cb-7727-4282-879a-d20210823d92"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("9a5f7d9d-e50f-4338-a49c-2f8322b9502a"));
            ttrichtextboxcontrol3 = (ITTRichTextBoxControl)AddControl(new Guid("d8b3ca77-e1d4-4458-8eee-3106fd7d3b47"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("e9655325-bde0-4917-baf8-ad5d5eebc536"));
            tttabpageIstemPaneli = (ITTTabPage)AddControl(new Guid("2bd83c72-db67-4eea-8f39-1fcbb3769e0c"));
            tttabpageEOrder = (ITTTabPage)AddControl(new Guid("ac4e1fb3-6d16-4c48-a690-9e01e91b1e33"));
            GridNursingOrders = (ITTGrid)AddControl(new Guid("606622be-346d-4f39-8616-b65f7ff4d4b6"));
            RPT = (ITTButtonColumn)AddControl(new Guid("1aea9239-79c0-46f3-ab39-9a929ef4b45b"));
            OrderActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("51c1201d-a3a1-4d07-a034-bacdabb54da0"));
            OrderProcedureObject = (ITTListBoxColumn)AddControl(new Guid("346ec2ae-0fc3-424e-834e-5c5d0c2fed6d"));
            PeriodStartTime = (ITTDateTimePickerColumn)AddControl(new Guid("566bd21d-7b01-4830-aba8-7188da216fd8"));
            ExecutionDate = (ITTDateTimePickerColumn)AddControl(new Guid("6bfe6a08-20b9-4ee4-933f-4eee24758a1e"));
            NursingApplicationResult = (ITTTextBoxColumn)AddControl(new Guid("759d9e21-8fdc-4039-bed2-0e7da88dce8e"));
            NursingApplicationNurseNote = (ITTTextBoxColumn)AddControl(new Guid("18e89f70-9354-43d1-8b16-7dd3325c4768"));
            CreateOrderDetailBeforeSave = (ITTButtonColumn)AddControl(new Guid("1f99d4e3-3d71-41cb-b2a3-62c8c736b20e"));
            tttabpageSagRapor = (ITTTabPage)AddControl(new Guid("6d7c6274-22d2-431a-9def-3e0c679f0360"));
            btnReports = (ITTButton)AddControl(new Guid("9a047551-0b2b-4e9a-8ee3-41f0a140a1bc"));
            tttabpageHastaGeçmişi = (ITTTabPage)AddControl(new Guid("a0821ade-3356-4f08-9ae4-db2653fa18b3"));
            tttabcontrol3 = (ITTTabControl)AddControl(new Guid("a2d5e339-b50f-4007-bdf0-f5d381a169ba"));
            HealthCommiteeActionsTab = (ITTTabPage)AddControl(new Guid("78c5d15d-4dd9-4bac-8539-bdefff4d5271"));
            HealthCommiteeActions = (ITTGrid)AddControl(new Guid("6638ba25-90d3-457e-b8e5-c4054bedcb2e"));
            Hospital = (ITTTextBoxColumn)AddControl(new Guid("50a4b901-a1fd-47ec-b369-93d18d5cfe81"));
            HealthCommiteeActionID = (ITTTextBoxColumn)AddControl(new Guid("df250c04-5a2a-48f5-af1d-626d78fb0eb9"));
            HealthCommiteeActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("35657c19-5007-4729-a903-d865fe65b56e"));
            HCObjectID = (ITTTextBoxColumn)AddControl(new Guid("2027120e-ce7a-4b7d-9541-9be105f54d17"));
            tttabpage15 = (ITTTabPage)AddControl(new Guid("76eb0cc1-447d-4bec-9d39-8d7d10540e6f"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("fb268ff1-10b4-4ecf-a447-8182f587cbaf"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("38882c9a-05c7-49f5-8f98-bb90bac289f0"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("c9eab93b-054e-41e5-883a-982911d797a4"));
            EpisodeFreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("e0dce614-41f9-45cb-bf00-84f61bee2724"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("b0c6878f-87c5-425f-8f69-7b0d10d692b0"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("ba30444d-cc92-4258-958c-89a3fc951d42"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("e2563cdc-a6d2-4b5a-8dba-5b7c6b684b68"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("16a10d4f-73e4-42ba-8dd6-3554ee5497b0"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("0d83a537-79bd-4411-bd5a-d665a091359b"));
            DiagnosisHistory = (ITTGrid)AddControl(new Guid("a66ffa35-ab4f-4c1e-9e4a-f04bf26a2c39"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("a306d983-8c05-45d5-9391-3bf80cb7ecc8"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("20b4802f-afa8-49a8-bfc3-fc2c056c7956"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("df6c8921-8d7d-4d07-8209-200340d1183b"));
            DiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("f27c55c4-fc11-4728-9f87-81139991f1ff"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("5c45301e-7847-47e1-83a9-ffa47e62c9fa"));
            lblOldDiagnosis = (ITTLabel)AddControl(new Guid("58c1ad6e-73c2-4528-b95e-8f821bfede93"));
            lblEpisodeDiagnosis = (ITTLabel)AddControl(new Guid("c7322bb2-38c9-4f7b-847d-5dd57e6ebbb8"));
            tttabpage16 = (ITTTabPage)AddControl(new Guid("3a183038-5541-4097-bb62-50a6a1c8c717"));
            ManipulationGrid = (ITTGrid)AddControl(new Guid("b40d7e1b-d84f-4633-8c81-8bb16c3f7a4e"));
            ManipulationActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("239848f0-8637-490c-8fc2-dd6beb97a63a"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("e0d140e7-58ac-4844-a4b0-55012933cbc4"));
            Emergency = (ITTCheckBoxColumn)AddControl(new Guid("30983d8c-efea-45f4-8970-ed1b35e8b05e"));
            Department = (ITTListBoxColumn)AddControl(new Guid("ed1ea86a-2f19-4959-bc3d-dc4b9db515af"));
            ManipulationDoctor = (ITTListBoxColumn)AddControl(new Guid("b2c38920-f019-43d9-9780-ba2abeee6983"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("785020ee-3d7f-450b-ad3b-42d0f1c6babd"));
            tttabpage17 = (ITTTabPage)AddControl(new Guid("29b1b15b-a552-4569-a7ce-cb09bfde27c8"));
            OldPhysicialExaminationsGrid = (ITTGrid)AddControl(new Guid("5c15f610-bb5e-4057-b35d-1cb082429681"));
            ExaminationDateTime = (ITTDateTimePickerColumn)AddControl(new Guid("2bbcbe71-c7a7-4719-84ad-4b8e2275efb2"));
            ExaminationIndication = (ITTRichTextBoxControlColumn)AddControl(new Guid("7c5ec191-5ecf-46cf-ac83-fb2aad05cb88"));
            tttabpage18 = (ITTTabPage)AddControl(new Guid("2fb28d26-e59c-45dc-b83e-13e535775dd6"));
            ttrichtextboxcontrol10 = (ITTRichTextBoxControl)AddControl(new Guid("893ac821-3180-4079-95da-c9be559a1007"));
            base.InitializeControls();
        }

        public ConsultationDoctorExaminationFormNew() : base("CONSULTATION", "ConsultationDoctorExaminationFormNew")
        {
        }

        protected ConsultationDoctorExaminationFormNew(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}