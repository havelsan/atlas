
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
    public partial class PsychologyBasedObjectForm : SpecialityBasedObjectForm
    {
        protected TTObjectClasses.PsychologyBasedObject _PsychologyBasedObject
        {
            get { return (TTObjectClasses.PsychologyBasedObject)_ttObject; }
        }

        protected ITTRichTextBoxControl TherapyReport;
        protected ITTLabel labelTherapyReport;
        protected ITTCheckBox VisibleForSelectedUsers;
        protected ITTCheckBox VisibleForPsychologyUnit;
        protected ITTCheckBox VisibleForProcAndRequestDoc;
        protected ITTCheckBox VisibleForProcedureDoctor;
        protected ITTGrid PsychologyAuthorizedUsers;
        protected ITTListBoxColumn ResUserPsychologyAuthorizedUser;
        protected ITTRichTextBoxControl DoctorStatement;
        protected ITTLabel labelDoctorStatement;
        protected ITTLabel labelRequestDoctor;
        protected ITTObjectListBox RequestDoctor;
        protected ITTLabel AppliedTestsHeader;
        protected ITTLabel labelIQTestObjectiveResultIQLevel;
        protected ITTEnumComboBox IQTestObjectiveResultIQLevel;
        protected ITTRichTextBoxControl InformationTakenFromParent;
        protected ITTLabel labelInformationTakenFromParent;
        protected ITTLabel labelImportantNoteAboutApplication;
        protected ITTEnumComboBox ImportantNoteAboutApplication;
        protected ITTCheckBox WISCR;
        protected ITTCheckBox ProteusMazeTest;
        protected ITTCheckBox PeabodyPictureVocabularyTest;
        protected ITTCheckBox LearnDifficultyDetermination;
        protected ITTCheckBox KentEGYTest;
        protected ITTCheckBox GoodEnoughHarrisDrawingTest;
        protected ITTCheckBox CattelIntelligenceTest;
        protected ITTCheckBox BinetTermanTest;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage EarlyChildGrowthEvalTab;
        protected ITTGrid EarlyChildGrowthEvaluation;
        protected ITTListBoxColumn AddedUserEarlyChildGrowthEvaluation;
        protected ITTListBoxColumn ProcedureDoctorEarlyChildGrowthEvaluation;
        protected ITTListBoxColumn RequestDoctorEarlyChildGrowthEvaluation;
        protected ITTDateTimePickerColumn AddedDateEarlyChildGrowthEvaluation;
        protected ITTTextBoxColumn CognitiveEvolutionEarlyChildGrowthEvaluation;
        protected ITTTextBoxColumn GeneralEvolutionLevelEarlyChildGrowthEvaluation;
        protected ITTTextBoxColumn MajorMotorEvolutionEarlyChildGrowthEvaluation;
        protected ITTTextBoxColumn PsychomotorEvolutionEarlyChildGrowthEvaluation;
        protected ITTTextBoxColumn ResultEarlyChildGrowthEvaluation;
        protected ITTTextBoxColumn SocialSkillSelfCareEvolLevelEarlyChildGrowthEvaluation;
        protected ITTTextBoxColumn ThinMotorEvolutionEarlyChildGrowthEvaluation;
        protected ITTTextBoxColumn TongueCognitiveEvolutionLevelEarlyChildGrowthEvaluation;
        protected ITTTabPage IQIntelligenceTestTab;
        protected ITTGrid IQIntelligenceTestReport;
        protected ITTListBoxColumn AddedUserIQIntelligenceTestReport;
        protected ITTListBoxColumn ProcedureDoctorIQIntelligenceTestReport;
        protected ITTListBoxColumn RequestDoctorIQIntelligenceTestReport;
        protected ITTListBoxColumn EducationStatusIQIntelligenceTestReport;
        protected ITTListBoxColumn PatientJobIQIntelligenceTestReport;
        protected ITTListBoxColumn PsychologyBasedObjectIQIntelligenceTestReport;
        protected ITTDateTimePickerColumn AddedDateIQIntelligenceTestReport;
        protected ITTTextBoxColumn CommentIQIntelligenceTestReport;
        protected ITTTextBoxColumn CriticalLifeEventIQIntelligenceTestReport;
        protected ITTTextBoxColumn PerformanceIntelligenceIQIntelligenceTestReport;
        protected ITTTextBoxColumn TestXXXXXXIQIntelligenceTestReport;
        protected ITTTextBoxColumn TestPurposeIQIntelligenceTestReport;
        protected ITTTextBoxColumn TotalIntelligenceIQIntelligenceTestReport;
        protected ITTTextBoxColumn VerbalIntelligenceIQIntelligenceTestReport;
        protected ITTTabPage VerbalAndPerformanceTestTab;
        protected ITTGrid VerbalAndPerformanceTests;
        protected ITTListBoxColumn PsychologyBasedObjectVerbalAndPerformanceTests;
        protected ITTTextBoxColumn ArithmeticVerbalAndPerformanceTests;
        protected ITTTextBoxColumn GeneralInformationVerbalAndPerformanceTests;
        protected ITTTextBoxColumn ImageCompletionVerbalAndPerformanceTests;
        protected ITTTextBoxColumn ImageEditingVerbalAndPerformanceTests;
        protected ITTTextBoxColumn MazesVerbalAndPerformanceTests;
        protected ITTTextBoxColumn PasswordVerbalAndPerformanceTests;
        protected ITTTextBoxColumn PatternWithCubesVerbalAndPerformanceTests;
        protected ITTTextBoxColumn PieceAssemblyVerbalAndPerformanceTests;
        protected ITTTextBoxColumn SimilaritiesVerbalAndPerformanceTests;
        protected ITTTextBoxColumn TrialVerbalAndPerformanceTests;
        protected ITTTextBoxColumn VocabularyVerbalAndPerformanceTests;
        protected ITTTabPage CognitiveEvaluation;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn AddedUserCognitiveEvaluation;
        protected ITTListBoxColumn ProcedureDoctorCognitiveEvaluation;
        protected ITTListBoxColumn RequestDoctorCognitiveEvaluation;
        protected ITTListBoxColumn EducationStatusCognitiveEvaluation;
        protected ITTListBoxColumn PatientJobCognitiveEvaluation;
        protected ITTListBoxColumn PsychologyBasedObjectCognitiveEvaluation;
        protected ITTDateTimePickerColumn AddedDateCognitiveEvaluation;
        protected ITTTextBoxColumn AttentionAndCalculationCognitiveEvaluation;
        protected ITTTextBoxColumn DetectionFunctionCognitiveEvaluation;
        protected ITTTextBoxColumn IQIntelligenceLevelCognitiveEvaluation;
        protected ITTTextBoxColumn JudgmentFunctionCognitiveEvaluation;
        protected ITTTextBoxColumn LanguageCognitiveEvaluation;
        protected ITTTextBoxColumn LongTermMemoryFunctionCognitiveEvaluation;
        protected ITTTextBoxColumn ObservationDiscussionEvalNoteCognitiveEvaluation;
        protected ITTTextBoxColumn OrientationCognitiveEvaluation;
        protected ITTTextBoxColumn OtherCognitiveEvaluation;
        protected ITTTextBoxColumn ReasoningFunctionCognitiveEvaluation;
        protected ITTTextBoxColumn RecordingMemory;
        protected ITTTextBoxColumn RemembranceCognitiveEvaluation;
        protected ITTTextBoxColumn ResultCognitiveEvaluation;
        protected ITTTextBoxColumn ShortTermMemoryFunctionCognitiveEvaluation;
        protected ITTTextBoxColumn SocialEducationRetardationSitCognitiveEvaluation;
        protected ITTTabPage PsychologicEvaluationTab;
        protected ITTGrid PsychologicEvaluation;
        protected ITTListBoxColumn AddedUserPsychologicEvaluation;
        protected ITTListBoxColumn ProcedureDoctorPsychologicEvaluation;
        protected ITTListBoxColumn RequestDoctorPsychologicEvaluation;
        protected ITTListBoxColumn PatientJobPsychologicEvaluation;
        protected ITTListBoxColumn EducationStatusPsychologicEvaluation;
        protected ITTListBoxColumn PsychologyBasedObjectPsychologicEvaluation;
        protected ITTDateTimePickerColumn AddedDatePsychologicEvaluation;
        protected ITTTextBoxColumn IQIntelligenceLevelPsychologicEvaluation;
        protected ITTTextBoxColumn LongTermMemoryFunctionPsychologicEvaluation;
        protected ITTTextBoxColumn MoodDisorderPsychologicEvaluation;
        protected ITTTextBoxColumn ObservationDiscussionEvalNotePsychologicEvaluation;
        protected ITTTextBoxColumn PersonalPathologyOrDeviationPsychologicEvaluation;
        protected ITTTextBoxColumn PsychopathologicalDeviationPsychologicEvaluation;
        protected ITTTextBoxColumn PsychopathologicalDisorderPsychologicEvaluation;
        protected ITTTextBoxColumn ResultPsychologicEvaluation;
        protected ITTTextBoxColumn ShortTermMemoryFunctionPsychologicEvaluation;
        protected ITTTextBoxColumn SocialEducationRetardationSitPsychologicEvaluation;
        override protected void InitializeControls()
        {
            TherapyReport = (ITTRichTextBoxControl)AddControl(new Guid("118be2c8-f954-4b6d-9942-c87c38e5cf8e"));
            labelTherapyReport = (ITTLabel)AddControl(new Guid("ea1f4c1a-b9c9-4c06-b552-898bf367f912"));
            VisibleForSelectedUsers = (ITTCheckBox)AddControl(new Guid("307afa1c-623b-4abb-9b3a-802c669b8705"));
            VisibleForPsychologyUnit = (ITTCheckBox)AddControl(new Guid("cf9f1cca-56ae-4d68-96a2-955cfb34207b"));
            VisibleForProcAndRequestDoc = (ITTCheckBox)AddControl(new Guid("6421d199-4a22-42c1-b275-c8ec942ef846"));
            VisibleForProcedureDoctor = (ITTCheckBox)AddControl(new Guid("6e980099-7f54-46f1-9ccc-662a33b6bf72"));
            PsychologyAuthorizedUsers = (ITTGrid)AddControl(new Guid("3310ea56-1c34-4055-9d29-8a1b63b8fed1"));
            ResUserPsychologyAuthorizedUser = (ITTListBoxColumn)AddControl(new Guid("7ea0d999-e316-42ef-8529-8225de2148ae"));
            DoctorStatement = (ITTRichTextBoxControl)AddControl(new Guid("bbe070c1-1280-488d-b551-72c6c439f237"));
            labelDoctorStatement = (ITTLabel)AddControl(new Guid("1aa7c5f2-161c-41ce-956f-0c73dd62929e"));
            labelRequestDoctor = (ITTLabel)AddControl(new Guid("aee35955-e11b-4fd7-91bc-3b957710fefa"));
            RequestDoctor = (ITTObjectListBox)AddControl(new Guid("3697292e-f45b-4133-97f0-60cac969925a"));
            AppliedTestsHeader = (ITTLabel)AddControl(new Guid("0365558d-969d-43ee-a46f-620cd9867009"));
            labelIQTestObjectiveResultIQLevel = (ITTLabel)AddControl(new Guid("fcedb769-d413-4707-aa1e-052169b9681e"));
            IQTestObjectiveResultIQLevel = (ITTEnumComboBox)AddControl(new Guid("af4d5fc4-a098-4e20-ba6b-8a3f8952487c"));
            InformationTakenFromParent = (ITTRichTextBoxControl)AddControl(new Guid("c145e1f8-f38d-4bc5-abf3-af28490ac2d3"));
            labelInformationTakenFromParent = (ITTLabel)AddControl(new Guid("5610d047-0bc6-4361-9c5c-6cf55d731d54"));
            labelImportantNoteAboutApplication = (ITTLabel)AddControl(new Guid("bd53fdf6-f99e-47a5-b733-7599e2f41bfe"));
            ImportantNoteAboutApplication = (ITTEnumComboBox)AddControl(new Guid("2940d588-5038-45a6-9b57-759dc7f30a19"));
            WISCR = (ITTCheckBox)AddControl(new Guid("06be131b-7e5a-4334-84b3-df611540b767"));
            ProteusMazeTest = (ITTCheckBox)AddControl(new Guid("7b5bab7c-081a-4867-9d34-b7d71adaf8a4"));
            PeabodyPictureVocabularyTest = (ITTCheckBox)AddControl(new Guid("d6de3288-dffb-4509-b299-ded5b3c48750"));
            LearnDifficultyDetermination = (ITTCheckBox)AddControl(new Guid("15f82d18-4e64-4c2d-ac7a-0677cb25ac0d"));
            KentEGYTest = (ITTCheckBox)AddControl(new Guid("02bfe830-22b4-4cd2-9009-4d7520459eb6"));
            GoodEnoughHarrisDrawingTest = (ITTCheckBox)AddControl(new Guid("60df6346-b1f8-4457-a3d2-09449a224da8"));
            CattelIntelligenceTest = (ITTCheckBox)AddControl(new Guid("44c17814-f770-444b-8358-f8bcef162c53"));
            BinetTermanTest = (ITTCheckBox)AddControl(new Guid("5d098f7e-2905-40be-a149-7d014d55ba20"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("f14bd53b-bea2-43bb-b14b-2fe0f16d3a63"));
            EarlyChildGrowthEvalTab = (ITTTabPage)AddControl(new Guid("4b54d7bd-a29c-4b00-b514-4e039c536e2a"));
            EarlyChildGrowthEvaluation = (ITTGrid)AddControl(new Guid("f7af3e88-1321-48ad-ab39-7fea30a1fe19"));
            AddedUserEarlyChildGrowthEvaluation = (ITTListBoxColumn)AddControl(new Guid("b6498fd1-219d-4cf0-b560-435906a741c7"));
            ProcedureDoctorEarlyChildGrowthEvaluation = (ITTListBoxColumn)AddControl(new Guid("6aca99af-fc7c-410c-b2e4-05d3310462a7"));
            RequestDoctorEarlyChildGrowthEvaluation = (ITTListBoxColumn)AddControl(new Guid("7fc93da0-d24e-4f01-8653-3ea0e49cfe4e"));
            AddedDateEarlyChildGrowthEvaluation = (ITTDateTimePickerColumn)AddControl(new Guid("3c5282f9-56af-4602-a0ff-69ca2e1970fa"));
            CognitiveEvolutionEarlyChildGrowthEvaluation = (ITTTextBoxColumn)AddControl(new Guid("c089187a-966f-4a85-a04c-985ef5c374e4"));
            GeneralEvolutionLevelEarlyChildGrowthEvaluation = (ITTTextBoxColumn)AddControl(new Guid("517d7970-9d0b-494a-af2c-399d91b678c2"));
            MajorMotorEvolutionEarlyChildGrowthEvaluation = (ITTTextBoxColumn)AddControl(new Guid("a6c050ad-3fd1-4501-9434-fc5fa50617ea"));
            PsychomotorEvolutionEarlyChildGrowthEvaluation = (ITTTextBoxColumn)AddControl(new Guid("11477c67-a98f-42e2-8429-6bb0a81003c5"));
            ResultEarlyChildGrowthEvaluation = (ITTTextBoxColumn)AddControl(new Guid("840400ac-0c25-4c27-be4e-9915c8d7c86c"));
            SocialSkillSelfCareEvolLevelEarlyChildGrowthEvaluation = (ITTTextBoxColumn)AddControl(new Guid("c9ce0955-26b2-4e9f-9cbe-b691e812dab9"));
            ThinMotorEvolutionEarlyChildGrowthEvaluation = (ITTTextBoxColumn)AddControl(new Guid("09ddbdc7-1c95-4b64-bf73-06b3238bf24c"));
            TongueCognitiveEvolutionLevelEarlyChildGrowthEvaluation = (ITTTextBoxColumn)AddControl(new Guid("7bacfcb2-f91f-44bf-b6a1-4a54fb54cd12"));
            IQIntelligenceTestTab = (ITTTabPage)AddControl(new Guid("934f8be4-d387-4c1a-bcaf-52eccb2e8336"));
            IQIntelligenceTestReport = (ITTGrid)AddControl(new Guid("336d8b2b-d231-4f72-9d0e-38ca1ba11969"));
            AddedUserIQIntelligenceTestReport = (ITTListBoxColumn)AddControl(new Guid("d67cb87d-da62-4c4a-8433-75af32ff49c8"));
            ProcedureDoctorIQIntelligenceTestReport = (ITTListBoxColumn)AddControl(new Guid("89bbf899-c258-4980-8441-9f382c17e8ed"));
            RequestDoctorIQIntelligenceTestReport = (ITTListBoxColumn)AddControl(new Guid("8d960b21-fff8-41ea-a088-e81b3869c69b"));
            EducationStatusIQIntelligenceTestReport = (ITTListBoxColumn)AddControl(new Guid("d5274d84-2f87-4729-9497-8c8ea237962f"));
            PatientJobIQIntelligenceTestReport = (ITTListBoxColumn)AddControl(new Guid("427ed4b0-9f73-4ee7-bc9c-16b6a1350981"));
            PsychologyBasedObjectIQIntelligenceTestReport = (ITTListBoxColumn)AddControl(new Guid("441dbd0e-479b-4af1-ae73-4d6f54d28a96"));
            AddedDateIQIntelligenceTestReport = (ITTDateTimePickerColumn)AddControl(new Guid("3b75a70c-0320-485b-9d62-782208bc1444"));
            CommentIQIntelligenceTestReport = (ITTTextBoxColumn)AddControl(new Guid("c45283b5-9323-4e3f-8fec-41d9a75880ad"));
            CriticalLifeEventIQIntelligenceTestReport = (ITTTextBoxColumn)AddControl(new Guid("326dfff8-c6d4-4b55-819f-29663f19b31c"));
            PerformanceIntelligenceIQIntelligenceTestReport = (ITTTextBoxColumn)AddControl(new Guid("03e1326b-7757-4fce-8109-888f2455cc64"));
            TestXXXXXXIQIntelligenceTestReport = (ITTTextBoxColumn)AddControl(new Guid("5a594828-4aa8-456c-a48f-821e42df45f8"));
            TestPurposeIQIntelligenceTestReport = (ITTTextBoxColumn)AddControl(new Guid("f54a6dd0-aac2-4a5c-8700-129bbd4a598b"));
            TotalIntelligenceIQIntelligenceTestReport = (ITTTextBoxColumn)AddControl(new Guid("6b12ba94-05a5-4f15-9820-ecc7e03d83ca"));
            VerbalIntelligenceIQIntelligenceTestReport = (ITTTextBoxColumn)AddControl(new Guid("96e0ab03-13ae-4f4d-bcfe-81093f6966e2"));
            VerbalAndPerformanceTestTab = (ITTTabPage)AddControl(new Guid("ea12ed04-e244-46a3-a76e-39510a20331f"));
            VerbalAndPerformanceTests = (ITTGrid)AddControl(new Guid("a78da24c-4d1b-4b71-ad82-9d443aa8137d"));
            PsychologyBasedObjectVerbalAndPerformanceTests = (ITTListBoxColumn)AddControl(new Guid("ffdbff3b-6911-4e1f-a89e-eabbe93e0526"));
            ArithmeticVerbalAndPerformanceTests = (ITTTextBoxColumn)AddControl(new Guid("8b3c50c4-2c95-4999-90fd-92e0a80f091e"));
            GeneralInformationVerbalAndPerformanceTests = (ITTTextBoxColumn)AddControl(new Guid("67b5987e-8b10-4329-8b19-677a4d25a867"));
            ImageCompletionVerbalAndPerformanceTests = (ITTTextBoxColumn)AddControl(new Guid("6ceea884-1bdd-44ec-9b78-a1843e35974d"));
            ImageEditingVerbalAndPerformanceTests = (ITTTextBoxColumn)AddControl(new Guid("6e388457-d941-4bc1-ba2a-6037f6f5c405"));
            MazesVerbalAndPerformanceTests = (ITTTextBoxColumn)AddControl(new Guid("72f01621-c43d-4706-8540-faf0d1c6bdfd"));
            PasswordVerbalAndPerformanceTests = (ITTTextBoxColumn)AddControl(new Guid("c1f86ff0-d2ea-4e85-99e1-7a761e025840"));
            PatternWithCubesVerbalAndPerformanceTests = (ITTTextBoxColumn)AddControl(new Guid("b82dc9df-8628-4ba7-8e2b-f87a43929d4c"));
            PieceAssemblyVerbalAndPerformanceTests = (ITTTextBoxColumn)AddControl(new Guid("fe543f8c-3172-4cd6-8405-c93c6237d438"));
            SimilaritiesVerbalAndPerformanceTests = (ITTTextBoxColumn)AddControl(new Guid("b4d374c1-5077-4fac-b218-a0ac6970f04c"));
            TrialVerbalAndPerformanceTests = (ITTTextBoxColumn)AddControl(new Guid("443502fd-7e80-4ff3-a486-a52d2bb24ab8"));
            VocabularyVerbalAndPerformanceTests = (ITTTextBoxColumn)AddControl(new Guid("01a1fdd0-1578-4b62-aeed-d8adcd42cbfc"));
            CognitiveEvaluation = (ITTTabPage)AddControl(new Guid("562f68ea-f17a-4d4e-87ec-ba7d62407548"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("d75605c0-87ec-4452-b61b-10d75aa1f062"));
            AddedUserCognitiveEvaluation = (ITTListBoxColumn)AddControl(new Guid("6cbc2ea1-d2ec-434a-bb9b-299e7c465600"));
            ProcedureDoctorCognitiveEvaluation = (ITTListBoxColumn)AddControl(new Guid("13044777-9c31-4f4d-9d9c-a0d05e6e7871"));
            RequestDoctorCognitiveEvaluation = (ITTListBoxColumn)AddControl(new Guid("83738b9a-7077-409a-8a0e-95be35d34b9c"));
            EducationStatusCognitiveEvaluation = (ITTListBoxColumn)AddControl(new Guid("1d93c1aa-6e06-4fe2-9687-f8886108ba55"));
            PatientJobCognitiveEvaluation = (ITTListBoxColumn)AddControl(new Guid("7d11c4a8-b7bd-4748-8fe7-ab72bb0d07aa"));
            PsychologyBasedObjectCognitiveEvaluation = (ITTListBoxColumn)AddControl(new Guid("72490e39-c677-4895-bfab-1251e6ba97fe"));
            AddedDateCognitiveEvaluation = (ITTDateTimePickerColumn)AddControl(new Guid("e67ec8c3-02b6-4c5e-9227-a925b2ccfc9a"));
            AttentionAndCalculationCognitiveEvaluation = (ITTTextBoxColumn)AddControl(new Guid("24bd95a0-87ef-4575-985c-cf1a1af0b847"));
            DetectionFunctionCognitiveEvaluation = (ITTTextBoxColumn)AddControl(new Guid("6298e8cb-d09e-4dd3-bd4d-8dd1f53952b4"));
            IQIntelligenceLevelCognitiveEvaluation = (ITTTextBoxColumn)AddControl(new Guid("3331d64a-5065-4a23-8ea7-88b4c75c693a"));
            JudgmentFunctionCognitiveEvaluation = (ITTTextBoxColumn)AddControl(new Guid("aec862b4-aba0-4a84-87f9-c4ef096982e6"));
            LanguageCognitiveEvaluation = (ITTTextBoxColumn)AddControl(new Guid("b27c5ae2-a1d3-42e8-bf2c-055f7d7c34a5"));
            LongTermMemoryFunctionCognitiveEvaluation = (ITTTextBoxColumn)AddControl(new Guid("b5e58e6b-4119-498d-8b52-cda64958cee5"));
            ObservationDiscussionEvalNoteCognitiveEvaluation = (ITTTextBoxColumn)AddControl(new Guid("cd9f29c6-e908-4a4e-b5ee-10a871cb3938"));
            OrientationCognitiveEvaluation = (ITTTextBoxColumn)AddControl(new Guid("f5983c8e-f500-40e9-b23c-14145b1023f1"));
            OtherCognitiveEvaluation = (ITTTextBoxColumn)AddControl(new Guid("eddd2062-4c3a-4659-b575-ad4865f95fd8"));
            ReasoningFunctionCognitiveEvaluation = (ITTTextBoxColumn)AddControl(new Guid("9161f84a-673f-45a3-9845-0e22390364aa"));
            RecordingMemory = (ITTTextBoxColumn)AddControl(new Guid("7a3c1005-98d2-49c5-88e8-8b28111e09a2"));
            RemembranceCognitiveEvaluation = (ITTTextBoxColumn)AddControl(new Guid("65bd5860-8073-41dd-a936-2841c016ddca"));
            ResultCognitiveEvaluation = (ITTTextBoxColumn)AddControl(new Guid("dceac2f2-3409-41e7-95d3-fee5f269d350"));
            ShortTermMemoryFunctionCognitiveEvaluation = (ITTTextBoxColumn)AddControl(new Guid("c890f938-9f28-4818-8533-723f5462da1a"));
            SocialEducationRetardationSitCognitiveEvaluation = (ITTTextBoxColumn)AddControl(new Guid("d86c646d-9fbb-4c94-a8e8-277ef1b53d2c"));
            PsychologicEvaluationTab = (ITTTabPage)AddControl(new Guid("710e07e2-849b-47e5-b41c-ba1793f19e43"));
            PsychologicEvaluation = (ITTGrid)AddControl(new Guid("0ecf3f57-733e-4289-931c-b964dcc84fe4"));
            AddedUserPsychologicEvaluation = (ITTListBoxColumn)AddControl(new Guid("2704c9e2-1ca9-4f5d-b15f-0f5275e3ac66"));
            ProcedureDoctorPsychologicEvaluation = (ITTListBoxColumn)AddControl(new Guid("865c8381-49d9-4f2a-885d-ac88d96e5e9c"));
            RequestDoctorPsychologicEvaluation = (ITTListBoxColumn)AddControl(new Guid("dd4b74fd-1cb8-4b41-a0e5-79586b971dc5"));
            PatientJobPsychologicEvaluation = (ITTListBoxColumn)AddControl(new Guid("2b3ad515-b97f-460d-8108-b9404e172567"));
            EducationStatusPsychologicEvaluation = (ITTListBoxColumn)AddControl(new Guid("de7bb900-819d-4054-9f27-ce248e93fc18"));
            PsychologyBasedObjectPsychologicEvaluation = (ITTListBoxColumn)AddControl(new Guid("290e2313-1f79-4ac2-8f26-f7c5f8b935d2"));
            AddedDatePsychologicEvaluation = (ITTDateTimePickerColumn)AddControl(new Guid("a8a16e80-0462-4886-8730-8367b51402c3"));
            IQIntelligenceLevelPsychologicEvaluation = (ITTTextBoxColumn)AddControl(new Guid("ff43e9df-6ac6-4fe5-93a0-a4e79ca9dabb"));
            LongTermMemoryFunctionPsychologicEvaluation = (ITTTextBoxColumn)AddControl(new Guid("0f739d5d-1728-481e-9c3b-1bb8a5cb7533"));
            MoodDisorderPsychologicEvaluation = (ITTTextBoxColumn)AddControl(new Guid("d2f00ae9-f50a-4315-8872-2f1b6c1f7a7e"));
            ObservationDiscussionEvalNotePsychologicEvaluation = (ITTTextBoxColumn)AddControl(new Guid("ae192380-bd03-43bb-840f-be9b3fe39e2d"));
            PersonalPathologyOrDeviationPsychologicEvaluation = (ITTTextBoxColumn)AddControl(new Guid("b7634fbe-b989-436b-b4bb-c44634e25896"));
            PsychopathologicalDeviationPsychologicEvaluation = (ITTTextBoxColumn)AddControl(new Guid("b46e225a-983a-44fd-84cd-3988231b6f39"));
            PsychopathologicalDisorderPsychologicEvaluation = (ITTTextBoxColumn)AddControl(new Guid("4c1ade74-ce61-49b5-9c6e-f96f736608f9"));
            ResultPsychologicEvaluation = (ITTTextBoxColumn)AddControl(new Guid("f836ba67-252c-4516-ac9e-815496ae5509"));
            ShortTermMemoryFunctionPsychologicEvaluation = (ITTTextBoxColumn)AddControl(new Guid("206d697d-7af8-4f5f-891c-f76f3d391147"));
            SocialEducationRetardationSitPsychologicEvaluation = (ITTTextBoxColumn)AddControl(new Guid("7ae981e6-0af1-4262-9dfc-ee4937390bf6"));
            base.InitializeControls();
        }

        public PsychologyBasedObjectForm() : base("PSYCHOLOGYBASEDOBJECT", "PsychologyBasedObjectForm")
        {
        }

        protected PsychologyBasedObjectForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}