
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
    public partial class PathologyTestReportForm : TTForm
    {
    /// <summary>
    /// Patoloji
    /// </summary>
        protected TTObjectClasses.Pathology _Pathology
        {
            get { return (TTObjectClasses.Pathology)_ttObject; }
        }

        protected ITTLabel labelRemoteSpecialDoctor;
        protected ITTRichTextBoxControl RemoteSpecialDoctor;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel10;
        protected ITTTabControl TabPathologyProcedure;
        protected ITTTabPage TabPageProcedure;
        protected ITTTabPage TabPageMaterial;
        protected ITTGrid GridPathologyMaterials;
        protected ITTDateTimePickerColumn MActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn MAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTabPage TabPageSpecialProcedure;
        protected ITTGrid GridProtocolNumbers;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTCheckBoxColumn datagridviewcolumn1;
        protected ITTListBoxColumn ttlistboxcolumn3;
        protected ITTButtonColumn Print;
        protected ITTTabPage TabPageHidden;
        protected ITTDateTimePicker RESULTENTRYDATE;
        protected ITTLabel ttlabel1;
        protected ITTGrid GridConsultantDoctor;
        protected ITTListBoxColumn ConsultantDoctor;
        protected ITTLabel ttlabel12;
        protected ITTCheckBox INTRAOPERATIVECONSULTATION;
        protected ITTObjectListBox SpecialDoctor;
        protected ITTLabel ttlabel15;
        protected ITTDateTimePicker ReportDate;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel18;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel14;
        protected ITTTextBox RESPONSIBLEDOCTORPHONENO;
        protected ITTObjectListBox ResposibleDoctor;
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
        protected ITTTabControl TabReports;
        protected ITTTabPage TabPageMacroscopi;
        protected ITTTabPage TabPageMicroskopi;
        protected ITTTabPage TabPageTissueProcedure;
        protected ITTTabPage TabPageAdditional;
        protected ITTTabPage TabPageDiagnosis;
        protected ITTTabPage TabPageImages;
        protected ITTGrid ttgrid1;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTTextBox REQUESTDOCTORPHONENUMBER;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelActionDate;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel11;
        protected ITTObjectListBox REQUESTDOCTOR;
        override protected void InitializeControls()
        {
            labelRemoteSpecialDoctor = (ITTLabel)AddControl(new Guid("1fe8294c-2026-446b-8981-7346dce16610"));
            RemoteSpecialDoctor = (ITTRichTextBoxControl)AddControl(new Guid("ff76e25d-ad24-42ee-8045-23786014ea93"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("30ea7992-ba93-4108-915a-3c4b0ef90a15"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("838b6b65-c24d-4bbf-993a-fe8498c828c4"));
            TabPathologyProcedure = (ITTTabControl)AddControl(new Guid("877e88bc-a3f5-4f47-94c7-b036e1a96af5"));
            TabPageProcedure = (ITTTabPage)AddControl(new Guid("9adfd58b-86fc-4a0c-b0ac-7f27325fdbd5"));
            TabPageMaterial = (ITTTabPage)AddControl(new Guid("82829d83-6d21-4427-9301-269ce5051e23"));
            GridPathologyMaterials = (ITTGrid)AddControl(new Guid("c7207761-6d09-4c02-93c0-9e6293b14cbc"));
            MActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("44499910-846f-4760-aaaa-5cc0ece9c4c6"));
            Material = (ITTListBoxColumn)AddControl(new Guid("9ca57577-1094-48a4-8bd9-74d459613a7c"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("be90a7f6-f6f8-44ab-9d57-e18350932feb"));
            MAmount = (ITTTextBoxColumn)AddControl(new Guid("816a91e7-664e-477e-85d7-f824550be3b3"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("7985fa18-7605-4192-8341-79b03753d42b"));
            TabPageSpecialProcedure = (ITTTabPage)AddControl(new Guid("14b49dc8-7464-4d86-9f15-537c7b268405"));
            GridProtocolNumbers = (ITTGrid)AddControl(new Guid("80bc35a1-8267-4f83-935b-e48ea6893acc"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("41b9a658-3856-4306-859e-8e486987eea1"));
            datagridviewcolumn1 = (ITTCheckBoxColumn)AddControl(new Guid("dc8bfc41-81ab-4889-9e8a-6ac3e7959f6a"));
            ttlistboxcolumn3 = (ITTListBoxColumn)AddControl(new Guid("105392ed-f2de-4cf5-8021-9b75aa18eae3"));
            Print = (ITTButtonColumn)AddControl(new Guid("f3c1f4c4-31e8-4d14-9001-9ae291c016ca"));
            TabPageHidden = (ITTTabPage)AddControl(new Guid("c2f21585-9ec2-41f3-9513-9fc0a5cfb1cd"));
            RESULTENTRYDATE = (ITTDateTimePicker)AddControl(new Guid("c1a4c351-8499-4fff-857c-5036e0be1021"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3be7ec1f-7f4a-4129-8ee1-3c1129d6bc8f"));
            GridConsultantDoctor = (ITTGrid)AddControl(new Guid("71fb0392-40ad-4a85-a380-bf75499dbe53"));
            ConsultantDoctor = (ITTListBoxColumn)AddControl(new Guid("ed243820-9ec2-451f-a0a1-32f034637752"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("9077be50-a058-4314-96a2-cd3b74e254fd"));
            INTRAOPERATIVECONSULTATION = (ITTCheckBox)AddControl(new Guid("f624f1c4-6ccc-47c7-8378-357346019a43"));
            SpecialDoctor = (ITTObjectListBox)AddControl(new Guid("550988fc-d21e-4408-b88b-5f97f80d4a79"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("e9ebf7c7-e25f-4fd2-9962-d98c5ecff50f"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("a352b6ee-ea8e-47c4-9a97-86e5960915ca"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("92ca7b0f-3d35-495f-a4f5-a7bd8748c5a8"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("d6eb199f-322b-44f1-8f08-5cf100d49cf9"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("df8b2e0b-3b28-421e-b0e9-041700aec507"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("3ac2a91d-6f9f-4627-a525-2dfe1e12f5a0"));
            RESPONSIBLEDOCTORPHONENO = (ITTTextBox)AddControl(new Guid("cf5a89a7-db45-4208-9cde-eb4da90b4f6c"));
            ResposibleDoctor = (ITTObjectListBox)AddControl(new Guid("8c5c61fc-6509-4074-9257-39d716242ea0"));
            TABExtraInformations = (ITTTabControl)AddControl(new Guid("72dbce45-07ae-4862-a247-6b043b63dc3f"));
            TabPagePreDiagnosis = (ITTTabPage)AddControl(new Guid("7ec66316-39c0-4cf0-ace3-d13d01f335ba"));
            TabPageAcceptionNote = (ITTTabPage)AddControl(new Guid("ccd6b0a6-0089-4953-9572-fcf8d753c6d4"));
            TabPageDescription = (ITTTabPage)AddControl(new Guid("db7fd7fd-1974-404e-bbdd-526c98eceed8"));
            Description = (ITTTextBox)AddControl(new Guid("c787800b-5f03-40c5-93c1-a8344e158bdc"));
            TabPageAdditionalInfo = (ITTTabPage)AddControl(new Guid("6a146dea-95d8-4562-aa66-12b59db917fe"));
            AdditionalInfo = (ITTTextBox)AddControl(new Guid("0388dd65-bcbf-4ec2-a0a0-a7856b616a54"));
            TabPageReasonForRepetation = (ITTTabPage)AddControl(new Guid("70c8ebb1-16d2-416e-8f4d-a783d08d7499"));
            ReasonForRepetation = (ITTTextBox)AddControl(new Guid("6b554c3e-2fb4-48e0-ae88-c4a2a0df071b"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("9e7b40d2-6ab3-464f-9d1e-b7284c304943"));
            TabPageSnomedDiagnose = (ITTTabPage)AddControl(new Guid("8884ac49-5493-4f02-a090-be530c4ec97d"));
            GridSnomedDiagnosis = (ITTGrid)AddControl(new Guid("b4f6f673-2284-4c4c-baa0-57cc46e81a3e"));
            PanicDiagnosisNotification = (ITTCheckBoxColumn)AddControl(new Guid("58baa1f5-09c2-415a-a577-db7ed57e9e2c"));
            SnomedDiagnose = (ITTListBoxColumn)AddControl(new Guid("5edf742c-9158-48bf-a33c-7b39cf4e5be4"));
            PanicMessageStatus = (ITTEnumComboBoxColumn)AddControl(new Guid("58215df8-c8a1-42cb-b562-cc1d543be427"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("bf3be9e5-402f-4479-afb8-b52958314a53"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("e32c7edc-ce2e-4b4e-961d-c4898284b545"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("fd544952-4c0d-45c3-8bc6-032f92f22e51"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("43068cd5-e49b-4238-8cd3-6e028c313621"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("1198e3b8-0507-4fe5-9ee8-3d5f4a14621f"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("31dffbe4-0f09-4df0-bd8a-6f130f9c1d16"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("07ac02f9-4338-4646-b8b6-f627670c8e5c"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("9504a370-31b5-42c2-8b10-8bda9f7b921b"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("6b118b22-8e50-4395-8f93-962f9e7e642b"));
            TabReports = (ITTTabControl)AddControl(new Guid("2cbbe2e1-492d-4c57-9060-580203765bfa"));
            TabPageMacroscopi = (ITTTabPage)AddControl(new Guid("6463b8b3-84a7-4e0f-a911-acb73016710f"));
            TabPageMicroskopi = (ITTTabPage)AddControl(new Guid("557e0742-52d9-4ad4-bed8-e40628d64089"));
            TabPageTissueProcedure = (ITTTabPage)AddControl(new Guid("c772d4db-965d-4bd7-a28e-0ca79f405d1b"));
            TabPageAdditional = (ITTTabPage)AddControl(new Guid("a6bf84c0-6814-4ba7-8a67-3012b54a7f85"));
            TabPageDiagnosis = (ITTTabPage)AddControl(new Guid("e1a556ff-d50f-483a-8f1c-0c9cdf303bb0"));
            TabPageImages = (ITTTabPage)AddControl(new Guid("0808da28-500f-465d-8f52-1e3aef3b290c"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("ef8274c9-7260-43d5-bd65-ee6904709074"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("7ea13795-a8e4-4ff7-b806-429d93b03626"));
            REQUESTDOCTORPHONENUMBER = (ITTTextBox)AddControl(new Guid("8ecb6c82-1f00-44dd-bd31-af71b4686e4b"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("b6680f07-1be4-4101-9ea1-860ebe1e62c9"));
            labelActionDate = (ITTLabel)AddControl(new Guid("e3180e4a-d5cc-446c-a367-e9c3810d693a"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("2de889b8-e861-4db6-947e-119e87823059"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("193e8e7b-ef8d-4407-8bcb-ea27971254b6"));
            REQUESTDOCTOR = (ITTObjectListBox)AddControl(new Guid("ef11b009-4359-4be8-ae6e-e3fd60d09cb1"));
            base.InitializeControls();
        }

        public PathologyTestReportForm() : base("PATHOLOGY", "PathologyTestReportForm")
        {
        }

        protected PathologyTestReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}