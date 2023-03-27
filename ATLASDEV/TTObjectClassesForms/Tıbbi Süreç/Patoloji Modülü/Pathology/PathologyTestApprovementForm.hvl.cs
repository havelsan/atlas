
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
    public partial class PathologyTestApprovementForm : TTForm
    {
    /// <summary>
    /// Patoloji
    /// </summary>
        protected TTObjectClasses.Pathology _Pathology
        {
            get { return (TTObjectClasses.Pathology)_ttObject; }
        }

        protected ITTCheckBox ttMasterResourceUserCheck;
        protected ITTButton cmdSaveAndPrint;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel20;
        protected ITTTextBox MaterialProtocolNo;
        protected ITTLabel ttlabel10;
        protected ITTTabControl TabPathologyProcedure;
        protected ITTTabPage TabPageProcedure;
        protected ITTGrid PathologyTestProcedures;
        protected ITTListBoxColumn ProcedureObjectPathologyTestProcedure;
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
        protected ITTGrid GridConsultantDoctor;
        protected ITTListBoxColumn ConsultantDoctor;
        protected ITTLabel ttlabel12;
        protected ITTObjectListBox SpecialDoctor;
        protected ITTCheckBox INTRAOPERATIVECONSULTATION;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel14;
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
        override protected void InitializeControls()
        {
            ttMasterResourceUserCheck = (ITTCheckBox)AddControl(new Guid("a4c53caf-5610-446d-b9c2-b06fca663a5c"));
            cmdSaveAndPrint = (ITTButton)AddControl(new Guid("59f51d81-b7f6-4669-a642-be7c3fa3f0ea"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("6c9f9104-e456-4e35-8d86-3211b9c85612"));
            ttlabel20 = (ITTLabel)AddControl(new Guid("67bf20bd-6cd1-41c6-a51b-dcf72952ee72"));
            MaterialProtocolNo = (ITTTextBox)AddControl(new Guid("7ff49d27-a364-4e7e-8916-7cc487aaf573"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("2351e3b3-5836-465f-a70a-5105b587efbc"));
            TabPathologyProcedure = (ITTTabControl)AddControl(new Guid("db781a8a-21a7-4f9c-919d-410add819dd9"));
            TabPageProcedure = (ITTTabPage)AddControl(new Guid("970f7554-7b64-4cae-b2d5-5e3b6df9f4fa"));
            PathologyTestProcedures = (ITTGrid)AddControl(new Guid("355895fa-0958-4d41-984f-01dacc76b7bb"));
            ProcedureObjectPathologyTestProcedure = (ITTListBoxColumn)AddControl(new Guid("f75d0763-268d-48bf-8dfd-3ee50b920075"));
            TabPageMaterial = (ITTTabPage)AddControl(new Guid("90314f1b-35fc-49ea-a6c7-e2bf1aad2818"));
            GridPathologyMaterials = (ITTGrid)AddControl(new Guid("66cc5c53-8f73-48ab-8ca1-ba4f884dbebb"));
            MActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("938020bb-dc70-4fd4-9454-c95301f1f856"));
            Material = (ITTListBoxColumn)AddControl(new Guid("a2f2bceb-cf8e-4d0a-b8cb-887fae73ec65"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("d44c5140-2679-498c-852c-ee2ef311d7c1"));
            MAmount = (ITTTextBoxColumn)AddControl(new Guid("1da6bd17-ae7a-4c70-8466-21f07aadd8f0"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("a347657c-fc9c-40a1-966b-d52f02d618f7"));
            TabPageSpecialProcedure = (ITTTabPage)AddControl(new Guid("2b849ba2-bf68-4672-900a-886602f542c7"));
            GridProtocolNumbers = (ITTGrid)AddControl(new Guid("ded562e6-ff5c-4f60-9b60-cf0f3eae79a0"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("c2ba786d-f8a9-4cbf-a39f-85ba6fb04a4c"));
            datagridviewcolumn1 = (ITTCheckBoxColumn)AddControl(new Guid("01e43c1b-6214-4797-bcbf-a7739096d6b0"));
            ttlistboxcolumn3 = (ITTListBoxColumn)AddControl(new Guid("8ba5a7cf-e1b2-4091-942e-a9173224a460"));
            Print = (ITTButtonColumn)AddControl(new Guid("987e342d-ce42-4d08-95a5-01b5e3e63a04"));
            TABExtraInformations = (ITTTabControl)AddControl(new Guid("aae27a6f-53c2-4c19-b909-86bd63db5d26"));
            TabPagePreDiagnosis = (ITTTabPage)AddControl(new Guid("5ee90ad9-8e08-4dce-912d-ea6b6351bed8"));
            TabPageAcceptionNote = (ITTTabPage)AddControl(new Guid("2a04621a-3722-44b0-8ea2-95fed8eef219"));
            TabPageDescription = (ITTTabPage)AddControl(new Guid("98a9bed1-6c84-484a-a830-8b18da9d1948"));
            Description = (ITTTextBox)AddControl(new Guid("e24ea2cf-2914-4d51-a4da-b4adc269da71"));
            TabPageAdditionalInfo = (ITTTabPage)AddControl(new Guid("4818185e-adca-4921-8e7f-77d56db15f21"));
            AdditionalInfo = (ITTTextBox)AddControl(new Guid("c914689f-ac56-4721-8c4e-16787716157a"));
            TabPageReasonForRepetation = (ITTTabPage)AddControl(new Guid("ac865eeb-02ee-460f-8d08-724ebbb53872"));
            ReasonForRepetation = (ITTTextBox)AddControl(new Guid("9d741733-a145-45d0-bc4d-996565d62c30"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("9d7c78fb-cf63-4334-bd88-cede38e928c4"));
            TabPageSnomedDiagnose = (ITTTabPage)AddControl(new Guid("d445a0cb-1c2c-46ac-9167-8970f8033c8a"));
            GridSnomedDiagnosis = (ITTGrid)AddControl(new Guid("6693864b-dc7b-4c3a-a9ab-50f0852d4c2c"));
            PanicDiagnosisNotification = (ITTCheckBoxColumn)AddControl(new Guid("98f7fc37-85ab-4c70-b26a-c20833372a07"));
            SnomedDiagnose = (ITTListBoxColumn)AddControl(new Guid("a8046298-4cad-4e48-a52e-08b7749e9732"));
            PanicMessageStatus = (ITTEnumComboBoxColumn)AddControl(new Guid("cf4dda49-1416-4696-becf-f77628112ec1"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("76bb30cb-22c0-4d2d-b702-30e2c54975c9"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("5c59eed4-1125-4b8e-801c-722686f46fbf"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("20c1f1fc-5114-4e0b-a386-b6248002577c"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("a7157c57-7a55-4a73-967a-932044516e61"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("8126860c-1b59-41c7-a992-d6472e3816fd"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("85eba692-65a9-4cee-8fcc-b45acb4a3ec1"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("9bc518fa-bcb2-4684-b16c-b69f9217dfb8"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("a8bc69ac-0e7f-4594-8b5e-8d354cbb4935"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("ba35fd93-f60e-4237-844a-6b4b03156dd3"));
            RESPONSIBLEDOCTORPHONENO = (ITTTextBox)AddControl(new Guid("adaddf9c-88f1-4aaa-8398-ec32b7a3fc0c"));
            GridConsultantDoctor = (ITTGrid)AddControl(new Guid("8b84f5a8-7b17-4a06-8d54-03fc84590092"));
            ConsultantDoctor = (ITTListBoxColumn)AddControl(new Guid("433cbc3b-a59f-4160-83a2-08182ac6fc97"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("9941edf5-9954-4747-9495-a2ebd435fc91"));
            SpecialDoctor = (ITTObjectListBox)AddControl(new Guid("5a5a1d1e-ecb2-44cf-a790-e0b1b2caad4c"));
            INTRAOPERATIVECONSULTATION = (ITTCheckBox)AddControl(new Guid("dcfc8309-0867-4450-b6b3-b111a2fffb10"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("88cc1539-66f7-44ec-ab9f-07f437134417"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("8fcb7698-c97a-4a56-9f06-3d24ae6bff18"));
            ResposibleDoctor = (ITTObjectListBox)AddControl(new Guid("f4bf60da-166e-4f3c-8d8e-d3d903f22e14"));
            TabReports = (ITTTabControl)AddControl(new Guid("22bbc524-985c-45fb-be26-97356f8d410f"));
            TabPageMacroscopi = (ITTTabPage)AddControl(new Guid("116e6262-f642-476a-a876-32d866d2158d"));
            TabPageMicroskopi = (ITTTabPage)AddControl(new Guid("e2048ccc-9dd4-4b6d-b1a9-b6b0ecec7279"));
            TabPageTissueProcedure = (ITTTabPage)AddControl(new Guid("052ffac2-f4ed-4632-8e64-d269cc802de2"));
            TabPageAdditional = (ITTTabPage)AddControl(new Guid("800fbb42-85da-423d-812a-a64fc3d98aba"));
            TabPageDiagnosis = (ITTTabPage)AddControl(new Guid("e5b9da79-71b2-48c0-a528-f2650bf0d023"));
            TabPageImages = (ITTTabPage)AddControl(new Guid("edcac128-599b-4b32-a885-75fa7c2169f4"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("a5b34296-3d2e-4ef0-ae31-a321303829f7"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("925ca7c4-d58f-496d-b9a3-da221063051b"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("cc29fa93-bcf6-4273-8f80-63abcc400206"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("6524619a-2cfc-4846-b650-2b0b2ebad18a"));
            RESULTENTRYDATE = (ITTDateTimePicker)AddControl(new Guid("a94682e3-cb12-4028-b54f-2be991f60e1b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("efb287ee-5633-42a8-9a0d-9a607b0da724"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6ecd3fb8-fe8a-4782-81e9-22334cba0360"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("961f5e3e-e784-43a7-a714-d402314c9bcb"));
            labelActionDate = (ITTLabel)AddControl(new Guid("651d6fa3-1c84-4017-be80-1851175f980d"));
            base.InitializeControls();
        }

        public PathologyTestApprovementForm() : base("PATHOLOGY", "PathologyTestApprovementForm")
        {
        }

        protected PathologyTestApprovementForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}