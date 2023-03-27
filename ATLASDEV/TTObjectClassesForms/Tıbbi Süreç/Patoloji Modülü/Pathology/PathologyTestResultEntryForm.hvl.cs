
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
    public partial class PathologyTestResultEntryForm : TTForm
    {
    /// <summary>
    /// Patoloji
    /// </summary>
        protected TTObjectClasses.Pathology _Pathology
        {
            get { return (TTObjectClasses.Pathology)_ttObject; }
        }

        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel10;
        protected ITTTabControl TabPathologyProcedure;
        protected ITTTabPage TabPageProcedure;
        protected ITTTabPage TabMedula;
        protected ITTObjectListBox TTListBoxDrAnesteziTescilNo;
        protected ITTGrid ttgridCokluOzelDurum;
        protected ITTListDefComboBoxColumn medulaCokluOzelDurum;
        protected ITTObjectListBox TTListBoxOzelDurum;
        protected ITTLabel ttlabelKesi;
        protected ITTLabel ttlabelOzelDurum;
        protected ITTObjectListBox TTListBoxKesi;
        protected ITTObjectListBox TTListBoxSagSol;
        protected ITTLabel ttlabelSagSol;
        protected ITTLabel ttlabel;
        protected ITTLabel ttlabelSonuc;
        protected ITTTextBox tttextboxBirim;
        protected ITTLabel ttlabelBirim;
        protected ITTTabPage TabPageMaterial;
        protected ITTGrid GridPathologyMaterials;
        protected ITTDateTimePickerColumn MActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn MAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTabPage TabPageSpecialProcedure;
        protected ITTButton cmdNumberIncrement;
        protected ITTGrid GridProtocolNumbers;
        protected ITTTextBoxColumn SubMatPrtNoString;
        protected ITTListBoxColumn SpecialProcedureDefinition;
        protected ITTTextBoxColumn SubMatPrtNoSuffixNo;
        protected ITTCheckBoxColumn IsApplied;
        protected ITTButtonColumn AddSpecial;
        protected ITTButtonColumn Print;
        protected ITTTabControl TABExtraInformations;
        protected ITTTabPage TabPagePreDiagnosis;
        protected ITTTabPage TabPageAcceptionNote;
        protected ITTTabPage TabPageDescription;
        protected ITTTextBox Description;
        protected ITTTabPage TabPageAdditionalInfo;
        protected ITTTextBox AdditionalInfo;
        protected ITTTabPage TabPageReasonForRepetation;
        protected ITTTextBox ReasonForRepetation;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage TabPageSnomedDiagnose;
        protected ITTGrid GridSnomedDiagnosis;
        protected ITTCheckBoxColumn PanicDiagnosisNotification;
        protected ITTListBoxColumn SnomedDiagnose;
        protected ITTEnumComboBoxColumn PanicMessageStatus;
        protected ITTTabPage EpisodeDiagnosisTab;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTextBox RESPONSIBLEDOCTORPHONENO;
        protected ITTTextBox MaterialProtocolNo;
        protected ITTGrid GridConsultantDoctor;
        protected ITTListBoxColumn ConsultantDoctor;
        protected ITTLabel ttlabel12;
        protected ITTObjectListBox SpecialDoctor;
        protected ITTCheckBox INTRAOPERATIVECONSULTATION;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel20;
        protected ITTObjectListBox ResposibleDoctor;
        protected ITTTabControl TabReports;
        protected ITTTabPage TabPageMacroscopi;
        protected ITTTabPage TabPageMicroskopi;
        protected ITTTabPage TabPageTissueProcedure;
        protected ITTTabPage TabPageAdditional;
        protected ITTTabPage TabPageDiagnosis;
        protected ITTTabPage TabPageImages;
        protected ITTGrid ttgrid1;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTLabel ttlabel15;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTDateTimePicker RESULTENTRYDATE;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelActionDate;
        protected ITTLabel ttlabeldrAnestezitescilNo;
        protected ITTCheckBox ttMasterResourceUserCheck;
        override protected void InitializeControls()
        {
            ttlabel9 = (ITTLabel)AddControl(new Guid("d990d1c5-ed31-4c38-9aa8-e87214166f24"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("c4baae5f-5a4c-44a2-85f1-b7e6f593db45"));
            TabPathologyProcedure = (ITTTabControl)AddControl(new Guid("c97ffc90-d530-49fa-b99f-64f5ec9b520c"));
            TabPageProcedure = (ITTTabPage)AddControl(new Guid("bfa2bd0c-9c00-4419-9666-cf9e4d7f9ac4"));
            TabMedula = (ITTTabPage)AddControl(new Guid("c2113cc5-62d2-42d7-89fa-389d46db13cb"));
            TTListBoxDrAnesteziTescilNo = (ITTObjectListBox)AddControl(new Guid("2d3fba49-aa72-42c5-9f44-7c2d3b8444f1"));
            ttgridCokluOzelDurum = (ITTGrid)AddControl(new Guid("5f905335-b189-4fe3-a546-e91db3d1aab6"));
            medulaCokluOzelDurum = (ITTListDefComboBoxColumn)AddControl(new Guid("b56d5c9b-eb2b-49ae-a372-4af875416041"));
            TTListBoxOzelDurum = (ITTObjectListBox)AddControl(new Guid("0dd2aba1-d8eb-4056-9a9f-bb3bc676b07f"));
            ttlabelKesi = (ITTLabel)AddControl(new Guid("af868e76-a8c9-45f1-a362-fb763c7abc59"));
            ttlabelOzelDurum = (ITTLabel)AddControl(new Guid("2eb0cf46-a1a7-4c4a-8dc1-3b1dcd12b0a7"));
            TTListBoxKesi = (ITTObjectListBox)AddControl(new Guid("105185d7-3b16-41e9-8b64-f59ce266a287"));
            TTListBoxSagSol = (ITTObjectListBox)AddControl(new Guid("fca468ec-7876-42c6-bff4-e249b6ec8228"));
            ttlabelSagSol = (ITTLabel)AddControl(new Guid("e4b062b1-225a-4205-98fa-2835bcaeaa8b"));
            ttlabel = (ITTLabel)AddControl(new Guid("46a43547-6ccf-42c8-a4ec-df563ccb60c9"));
            ttlabelSonuc = (ITTLabel)AddControl(new Guid("8bd4a950-5fcc-495c-9c5b-6664f4b8bd3d"));
            tttextboxBirim = (ITTTextBox)AddControl(new Guid("672e1a11-f0eb-4ba8-bb08-ff5d7c770efc"));
            ttlabelBirim = (ITTLabel)AddControl(new Guid("d1f60fa4-901b-42a2-91c7-296fe47b0ab2"));
            TabPageMaterial = (ITTTabPage)AddControl(new Guid("6d5bc634-88ec-4406-a70d-8623a2938dd2"));
            GridPathologyMaterials = (ITTGrid)AddControl(new Guid("7855a2ca-4f30-4e88-b8af-d1852c1382ce"));
            MActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("d4c1b723-f0c6-478e-bf0a-be0652fb23f2"));
            Material = (ITTListBoxColumn)AddControl(new Guid("054a1bc5-2f19-43e4-9596-27b87c9fa13a"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("f03e4736-5164-4f03-a50a-180bdb89da64"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("250c142b-6d6b-43f7-9357-c121017d1435"));
            MAmount = (ITTTextBoxColumn)AddControl(new Guid("961046d3-2f14-4351-84b3-6fa9bc3af7f4"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("30849c5e-cc22-4a5d-bbf0-996adde93001"));
            TabPageSpecialProcedure = (ITTTabPage)AddControl(new Guid("27cdd73b-bf07-4a71-b1de-076a4eceef7a"));
            cmdNumberIncrement = (ITTButton)AddControl(new Guid("2085028e-8928-4244-8fc6-0adf64ea870b"));
            GridProtocolNumbers = (ITTGrid)AddControl(new Guid("189b823f-0f3d-454c-8ce0-644c4e459989"));
            SubMatPrtNoString = (ITTTextBoxColumn)AddControl(new Guid("ad03998a-3218-456b-bb5c-ff0add1693fc"));
            SpecialProcedureDefinition = (ITTListBoxColumn)AddControl(new Guid("d96b16ce-72e6-4edc-905b-446fe54339f2"));
            SubMatPrtNoSuffixNo = (ITTTextBoxColumn)AddControl(new Guid("ac2224ed-3029-43e8-b7bf-d3ff2d6383ce"));
            IsApplied = (ITTCheckBoxColumn)AddControl(new Guid("e251e761-bebd-45e7-9ef9-ab59d84fdc3d"));
            AddSpecial = (ITTButtonColumn)AddControl(new Guid("34858487-aef9-4db6-97e9-44819e633be1"));
            Print = (ITTButtonColumn)AddControl(new Guid("dc1d53b6-b4b3-48af-b930-d5737fc90235"));
            TABExtraInformations = (ITTTabControl)AddControl(new Guid("f80d9ac4-fe0e-4a7d-90b0-f63ce7bd13c4"));
            TabPagePreDiagnosis = (ITTTabPage)AddControl(new Guid("170abd5a-3908-4e47-a4df-5f7b2e999f8b"));
            TabPageAcceptionNote = (ITTTabPage)AddControl(new Guid("0fb3f725-f1bf-470e-b452-cca324398056"));
            TabPageDescription = (ITTTabPage)AddControl(new Guid("a6e96b28-8955-41c4-b18c-a487f839d2f4"));
            Description = (ITTTextBox)AddControl(new Guid("bd977220-e401-4775-8efe-7d8b6111921f"));
            TabPageAdditionalInfo = (ITTTabPage)AddControl(new Guid("21bbd87b-c9d0-431e-8adb-bb3740be787b"));
            AdditionalInfo = (ITTTextBox)AddControl(new Guid("70b04893-ac4e-4ec5-9f68-e0d0af4d9278"));
            TabPageReasonForRepetation = (ITTTabPage)AddControl(new Guid("152a3cfb-f268-48e1-80e4-1465f13a59c5"));
            ReasonForRepetation = (ITTTextBox)AddControl(new Guid("05279b84-fd24-4c01-89ae-1a20429edfd8"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("87b420f5-6742-49b2-87ba-abfa4f098ecf"));
            TabPageSnomedDiagnose = (ITTTabPage)AddControl(new Guid("abb92738-5084-4d31-8059-fa0404d65271"));
            GridSnomedDiagnosis = (ITTGrid)AddControl(new Guid("e1469051-9ccf-4cc1-b21a-612d9f563cff"));
            PanicDiagnosisNotification = (ITTCheckBoxColumn)AddControl(new Guid("91fc8a61-da94-4e8a-bbd6-90ff35af5a07"));
            SnomedDiagnose = (ITTListBoxColumn)AddControl(new Guid("e6eb1fde-9bad-4da8-98a3-6a6bf3da84d0"));
            PanicMessageStatus = (ITTEnumComboBoxColumn)AddControl(new Guid("f4d7353d-d525-429b-823b-bb6bc64c607a"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("f0d257df-5a9a-4e84-b377-63c69a176feb"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("64edd0a3-88c0-4c07-b0b7-76e03ec4564a"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("aa7ea905-6219-4abe-a236-cb59e91a3956"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("39acb2e5-98b5-418e-a9b4-2ea8ec7adc7c"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("00aaee95-9faa-4c2e-93d3-ed0cd32c7c94"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("c717e825-1e93-47bf-9446-f3e0de5d9aac"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("c7fb9ac0-03c3-4596-96d7-a6d259b0f047"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("ebaa4b2b-f46d-4823-ac60-bbc63aae1b04"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("19e5e7a1-213c-4a82-88b7-31e3a9066512"));
            RESPONSIBLEDOCTORPHONENO = (ITTTextBox)AddControl(new Guid("41b87970-1541-40d8-be19-903c00c18070"));
            MaterialProtocolNo = (ITTTextBox)AddControl(new Guid("197bf939-1df3-4198-97d8-8098eed8fb2a"));
            GridConsultantDoctor = (ITTGrid)AddControl(new Guid("f55a4d0e-6206-44b6-9028-fcc5e41f5ece"));
            ConsultantDoctor = (ITTListBoxColumn)AddControl(new Guid("c08cd899-3074-4f7c-a9eb-4de9b8e5d0c3"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("9f18bc07-326e-4bd1-8ece-1b1369a34ba2"));
            SpecialDoctor = (ITTObjectListBox)AddControl(new Guid("88ca136d-6c6d-4145-bba6-44cca2e689db"));
            INTRAOPERATIVECONSULTATION = (ITTCheckBox)AddControl(new Guid("2dcbb41a-c538-45c0-9e59-44ea6779df89"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("4f768d7f-0d38-4d2a-ae08-f984df868a97"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("599e0575-c9e7-45db-b6d9-2598e575e636"));
            ttlabel20 = (ITTLabel)AddControl(new Guid("4aab09a7-92ef-4306-9bee-2f1c55af8fe3"));
            ResposibleDoctor = (ITTObjectListBox)AddControl(new Guid("0fa88e98-2323-4f51-a078-e66c1db52a29"));
            TabReports = (ITTTabControl)AddControl(new Guid("530448c6-066b-4fd0-8ddb-b92b90681390"));
            TabPageMacroscopi = (ITTTabPage)AddControl(new Guid("32dc6514-07f4-43c3-bc17-9a036452ccb1"));
            TabPageMicroskopi = (ITTTabPage)AddControl(new Guid("d3d011b8-96eb-448d-b77a-e9bc8162ebd6"));
            TabPageTissueProcedure = (ITTTabPage)AddControl(new Guid("369f023e-b8ec-4931-8ed0-d42ddaa0a7ee"));
            TabPageAdditional = (ITTTabPage)AddControl(new Guid("ec2d5326-3e58-4a7b-8272-8c45de6df0cf"));
            TabPageDiagnosis = (ITTTabPage)AddControl(new Guid("c409e7ee-7370-4c4c-afb7-243f0ca26a08"));
            TabPageImages = (ITTTabPage)AddControl(new Guid("2881c61c-0f2e-4ce3-96b0-9d30226c20f4"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("8bf146a0-5488-4a6d-b8d6-d1a1597519ba"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("1df6893a-5dac-48a4-87b5-cca603729aee"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("067f13b4-b4a0-4189-a03b-fbb1716772bf"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("f68f3422-207a-4c13-9517-e89cf1f859d5"));
            RESULTENTRYDATE = (ITTDateTimePicker)AddControl(new Guid("544bf31c-e6f4-426b-8de9-f31ab6b063f4"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("5c78c89e-7acb-4e29-8ce1-0e6832f2fe85"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6dc7e833-ed51-4043-b6c4-1cec940b1614"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("818dfe35-d228-4980-84cb-fa4fadfa0df8"));
            labelActionDate = (ITTLabel)AddControl(new Guid("c579fa9e-83ab-428b-8e35-a985bce7ccb2"));
            ttlabeldrAnestezitescilNo = (ITTLabel)AddControl(new Guid("0f8e1317-ad37-4f58-b9b0-f1272e346dfd"));
            ttMasterResourceUserCheck = (ITTCheckBox)AddControl(new Guid("f615d330-26de-4da2-9e8f-34f31b1b5b47"));
            base.InitializeControls();
        }

        public PathologyTestResultEntryForm() : base("PATHOLOGY", "PathologyTestResultEntryForm")
        {
        }

        protected PathologyTestResultEntryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}