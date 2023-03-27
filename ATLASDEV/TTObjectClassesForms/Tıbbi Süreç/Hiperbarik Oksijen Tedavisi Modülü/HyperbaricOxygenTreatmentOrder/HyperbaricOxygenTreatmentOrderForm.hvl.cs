
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
    /// Hiperbarik Oksijen Tedavi Emiri
    /// </summary>
    public partial class HyperbaricOxygenTreatmentOrderForm : EpisodeActionForm
    {
    /// <summary>
    /// Hiperbarik Oksijen Tedavi Emirinin Verildiği Nesnedir
    /// </summary>
        protected TTObjectClasses.HyperbaricOxygenTreatmentOrder _HyperbaricOxygenTreatmentOrder
        {
            get { return (TTObjectClasses.HyperbaricOxygenTreatmentOrder)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tabVakaTanilari;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabPage tabRapor;
        protected ITTRichTextBoxControl Report;
        protected ITTTextBox Note;
        protected ITTTextBox Amount;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox Duration;
        protected ITTTextBox TreatmentProperties;
        protected ITTTextBox TreatmentDepth;
        protected ITTTextBox ReportNo;
        protected ITTLabel labelNote;
        protected ITTLabel labelTreatmentDiagnosisUnit;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelProcedureObject;
        protected ITTLabel labelAmount;
        protected ITTLabel labelDuration;
        protected ITTObjectListBox TreatmentDiagnosisUnit;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel labelTreatmentProperties;
        protected ITTGrid OrderDetails;
        protected ITTDateTimePickerColumn DWorkListDate;
        protected ITTDateTimePickerColumn DActionDate;
        protected ITTListBoxColumn DProcedureObject;
        protected ITTListBoxColumn DTreatmentEquipment;
        protected ITTListBoxColumn DProcedureDoctor;
        protected ITTListBoxColumn DProcedureSpeciality;
        protected ITTStateComboBoxColumn CState;
        protected ITTListBoxColumn AyniFarkliKesi;
        protected ITTListBoxColumn OzelDurum;
        protected ITTTextBoxColumn RaporTakipNo;
        protected ITTButtonColumn CokluOzelDurum;
        protected ITTListBoxColumn DrAnesteziTescilNo;
        protected ITTLabel labelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelActionDate;
        protected ITTRichTextBoxControl ReasonOfAbort;
        protected ITTLabel labelReasonOfAbort;
        protected ITTLabel labelTreatmentDepth;
        protected ITTLabel labelPatientFollowUpForm;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelOperator;
        protected ITTObjectListBox Physiotherapist;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureDoctor;
        protected ITTDateTimePicker ReportDate;
        protected ITTLabel ttLabelReportNo;
        protected ITTLabel ttlabelReportDate;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("3baecbba-fe40-4e22-bee4-42a85d3d3904"));
            tabVakaTanilari = (ITTTabPage)AddControl(new Guid("442674b0-640f-458d-a109-ed706c5ea210"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("31096453-45af-4d9c-9a42-8399ee899079"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("3097b0cc-40dc-4716-bdf7-e8795c618694"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("955f2fa5-c8c3-4e74-9d18-2d97714dad1a"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("eadf13fb-4f43-4314-b5da-400a86ad81d8"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("1a0a6b0e-cce0-467b-80ce-bcfe7bbaa144"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("22a1105e-38d6-462a-94f6-b90b33494566"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("dcc6be6e-59f2-4051-a11c-aa134e46cc74"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("a46ca513-c09b-4e3f-a65e-e89c958d1406"));
            tabRapor = (ITTTabPage)AddControl(new Guid("0743b5d2-70b0-4e96-bee9-e540bde74dce"));
            Report = (ITTRichTextBoxControl)AddControl(new Guid("652e4181-2a98-4132-ad52-557560b12c01"));
            Note = (ITTTextBox)AddControl(new Guid("5b4508da-62c5-4b5e-a77e-6552c6c3c662"));
            Amount = (ITTTextBox)AddControl(new Guid("3850f5fc-d481-4c33-82b8-1d8b2c3e91f8"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("b7642442-107e-4e43-a6cb-95ac487a5cfa"));
            Duration = (ITTTextBox)AddControl(new Guid("ac19d98a-6506-4f02-8246-df11c7ec9207"));
            TreatmentProperties = (ITTTextBox)AddControl(new Guid("5d5eacb0-4ad6-45bf-ab33-df27002de2d5"));
            TreatmentDepth = (ITTTextBox)AddControl(new Guid("5e075b01-2caf-444c-b212-df6af9971924"));
            ReportNo = (ITTTextBox)AddControl(new Guid("bdf32d65-252f-418b-8230-e10df006abf8"));
            labelNote = (ITTLabel)AddControl(new Guid("fb3336d8-badd-46f4-b8b5-db63a79e130f"));
            labelTreatmentDiagnosisUnit = (ITTLabel)AddControl(new Guid("4ebed6e4-2a47-4bf5-91e0-097e800ce505"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("d0bec8ae-496b-4569-afe1-16e7155a6bef"));
            labelProcedureObject = (ITTLabel)AddControl(new Guid("0a4a116e-d651-415e-9a4e-3f526e578a59"));
            labelAmount = (ITTLabel)AddControl(new Guid("311000dc-0208-4be2-b7f6-412e1d538dcb"));
            labelDuration = (ITTLabel)AddControl(new Guid("a0a200a4-1023-4e4c-8586-6e6a5e0b1945"));
            TreatmentDiagnosisUnit = (ITTObjectListBox)AddControl(new Guid("e2c536f2-7944-42fd-bd0a-c80f44f1612f"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("3d1af29a-2bf2-4104-abdb-ce7030ec1022"));
            labelTreatmentProperties = (ITTLabel)AddControl(new Guid("239d3fb6-4f9d-4de2-bd5c-cefc06cf3f15"));
            OrderDetails = (ITTGrid)AddControl(new Guid("a02a27d9-5660-4f32-a494-ebd287bd4232"));
            DWorkListDate = (ITTDateTimePickerColumn)AddControl(new Guid("3a0f4493-e2b8-4902-bbbb-c5c8e0cc396f"));
            DActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("2908fb1b-83ca-4bc0-a9e2-c694b660fb4a"));
            DProcedureObject = (ITTListBoxColumn)AddControl(new Guid("5b7098e5-5da4-4aed-9919-62096688636e"));
            DTreatmentEquipment = (ITTListBoxColumn)AddControl(new Guid("cb256e25-391e-4bca-924d-d5a1583178d9"));
            DProcedureDoctor = (ITTListBoxColumn)AddControl(new Guid("c7f9da82-4d61-481d-ac1d-f737bfa2092b"));
            DProcedureSpeciality = (ITTListBoxColumn)AddControl(new Guid("2b8ee6e2-fe60-49d6-9677-ad3be9c52663"));
            CState = (ITTStateComboBoxColumn)AddControl(new Guid("23e5487c-e167-42a9-a578-4743a23ca432"));
            AyniFarkliKesi = (ITTListBoxColumn)AddControl(new Guid("3e73c6a3-4f73-44e3-9f42-1c5d62b34efd"));
            OzelDurum = (ITTListBoxColumn)AddControl(new Guid("4d52416b-313f-444c-a429-cdd39045f20d"));
            RaporTakipNo = (ITTTextBoxColumn)AddControl(new Guid("e8c522e1-9967-496f-a87a-c28bd61cd1d2"));
            CokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("c9290bb2-f7d7-48cb-b017-bec01ffcdba8"));
            DrAnesteziTescilNo = (ITTListBoxColumn)AddControl(new Guid("28c1f09c-b86e-43ae-af5e-8c445a229fc7"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("72d9f44d-f6b0-452b-b098-bce513194212"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("54d2ae18-1e51-4381-a9ce-a12e82a38127"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("bebf61ca-1002-4b17-90c8-224255fd30d4"));
            labelActionDate = (ITTLabel)AddControl(new Guid("b6163fe5-d231-4cc9-8b5d-a60bbb873dcf"));
            ReasonOfAbort = (ITTRichTextBoxControl)AddControl(new Guid("f521fbfe-04cf-401e-b2cc-1bdd3588cee2"));
            labelReasonOfAbort = (ITTLabel)AddControl(new Guid("9892dee9-b9d9-4f68-a51d-797f91e8a0ff"));
            labelTreatmentDepth = (ITTLabel)AddControl(new Guid("b77bf6ff-40d3-4e09-adce-d0371373ae5e"));
            labelPatientFollowUpForm = (ITTLabel)AddControl(new Guid("bb5daf84-7a0d-41f4-8321-c4beb42c8caa"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("bc1f8bdd-6c9f-4ff8-9e15-34d00f2e180f"));
            labelOperator = (ITTLabel)AddControl(new Guid("8eb1ce58-0087-4a1e-8f13-983e40737a40"));
            Physiotherapist = (ITTObjectListBox)AddControl(new Guid("91a3331d-eebf-46ab-8c2e-7647bbd4694e"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("207b24ac-0c41-4852-b34e-2fa21905b466"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("b730f7ae-6742-4530-a822-2f4eaa1ddac1"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("3e0fcc15-533c-409d-b893-c463efbcf102"));
            ttLabelReportNo = (ITTLabel)AddControl(new Guid("7849cd1d-5b7c-46c2-b99a-e6a409ff9de4"));
            ttlabelReportDate = (ITTLabel)AddControl(new Guid("0e9781cd-b21d-4130-bdde-eea04428ab11"));
            base.InitializeControls();
        }

        public HyperbaricOxygenTreatmentOrderForm() : base("HYPERBARICOXYGENTREATMENTORDER", "HyperbaricOxygenTreatmentOrderForm")
        {
        }

        protected HyperbaricOxygenTreatmentOrderForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}