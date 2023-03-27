
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
    /// Hiperbarik Oksijen Tedavi Emri
    /// </summary>
    public partial class HyperbaricOxygenTreatmentCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Hiperbarik Oksijen Tedavi Emirinin Verildiği Nesnedir
    /// </summary>
        protected TTObjectClasses.HyperbaricOxygenTreatmentOrder _HyperbaricOxygenTreatmentOrder
        {
            get { return (TTObjectClasses.HyperbaricOxygenTreatmentOrder)_ttObject; }
        }

        protected ITTDateTimePicker RequestDate;
        protected ITTLabel ttlabel2;
        protected ITTLabel lblEpisodeDiagnosis;
        protected ITTLabel labelNote;
        protected ITTTextBox Note;
        protected ITTTextBox Amount;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox Duration;
        protected ITTTextBox TreatmentProperties;
        protected ITTTextBox ReasonOfCancel;
        protected ITTTextBox TreatmentDepth;
        protected ITTLabel labelTreatmentDiagnosisUnit;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelProcedureObject;
        protected ITTLabel labelAmount;
        protected ITTLabel labelDuration;
        protected ITTObjectListBox TreatmentDiagnosisUnit;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel labelTreatmentProperties;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTGrid OrderDetails;
        protected ITTDateTimePickerColumn DWorkListDate;
        protected ITTDateTimePickerColumn DActionDate;
        protected ITTListBoxColumn DProcedureObject;
        protected ITTListBoxColumn DTreatmentEquipment;
        protected ITTListBoxColumn DProcedureDoctor;
        protected ITTListBoxColumn DProcedureSpeciality;
        protected ITTStateComboBoxColumn CState;
        protected ITTLabel labelRequestDate;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelActionDate;
        protected ITTRichTextBoxControl ReasonOfAbort;
        protected ITTLabel labelReasonOfAbort;
        protected ITTLabel ttlabelReasonOfCancel;
        protected ITTLabel labelTreatmentDepth;
        protected ITTLabel labelPatientFollowUpForm;
        protected ITTRichTextBoxControl PatientFollowUpForm;
        protected ITTLabel labelOperator;
        protected ITTObjectListBox Physiotherapist;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureDoctor;
        override protected void InitializeControls()
        {
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("1bf621c7-04ef-4a89-b43b-9e9ef928bc55"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("cd213500-c534-40c8-b1b8-fd141deedbfa"));
            lblEpisodeDiagnosis = (ITTLabel)AddControl(new Guid("e19e2a04-7126-4cfa-8bd3-f5658d42c885"));
            labelNote = (ITTLabel)AddControl(new Guid("10b6fd5e-5314-4f19-9fe0-bf1c592109ad"));
            Note = (ITTTextBox)AddControl(new Guid("58ab9c8a-3460-405d-b6ef-7f6763b420d7"));
            Amount = (ITTTextBox)AddControl(new Guid("477360e8-0cd2-407e-97f1-22b2de44a457"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("bfd470c9-b126-48e1-8a37-e8c49abe56a0"));
            Duration = (ITTTextBox)AddControl(new Guid("8c4e2149-b4bc-44cf-b8e3-4506490a03a3"));
            TreatmentProperties = (ITTTextBox)AddControl(new Guid("03950f98-b5f5-4165-9f2c-5205f468c40b"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("e45ad265-c893-4fd3-82cd-844f966ff1a8"));
            TreatmentDepth = (ITTTextBox)AddControl(new Guid("0b6a4349-8ad6-495a-8a83-8a83b567b7b6"));
            labelTreatmentDiagnosisUnit = (ITTLabel)AddControl(new Guid("c3c181b2-08ab-4289-b030-8e14d6be6c43"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("c21f01ce-88ed-4197-b2cc-83ecbedb190e"));
            labelProcedureObject = (ITTLabel)AddControl(new Guid("381db861-4aa8-4347-80aa-f0b4f98ad5c9"));
            labelAmount = (ITTLabel)AddControl(new Guid("5946b183-a02d-4a6c-a06a-f1362eb59ba7"));
            labelDuration = (ITTLabel)AddControl(new Guid("37189115-2762-4e9b-9a84-5458b976ac05"));
            TreatmentDiagnosisUnit = (ITTObjectListBox)AddControl(new Guid("96050132-1f12-4643-a300-3ba74606e9de"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("82c2cb4d-12bb-4c58-940f-246dab907be7"));
            labelTreatmentProperties = (ITTLabel)AddControl(new Guid("190ec2f2-f8ec-41d0-a549-d1b677ed5673"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("5da8874c-a097-4415-b0f4-f389a69956c9"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("8351dcd1-7201-4ceb-ad47-375184ccae6a"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("a708e08d-6323-46b4-a7f5-1661d2ffac4e"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("9ca65efa-3dbc-4c56-ad22-63b096319ac2"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("d17c117a-e2d4-443c-84b2-b8cb10de7c3b"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("798ae323-cd31-4961-a2a6-c0adfaaab67d"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("7fe0a7ed-4cc7-4211-a39d-17fdb597ef29"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("2a389ff1-5edc-49d4-8850-ab6d847d882f"));
            OrderDetails = (ITTGrid)AddControl(new Guid("4314b287-03bf-4465-a1bd-90bf466c9bb2"));
            DWorkListDate = (ITTDateTimePickerColumn)AddControl(new Guid("61cb7d6d-149b-4892-90a0-5861b4b11fd1"));
            DActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("eb477a98-de28-4c9a-a70f-35b0803bdb9c"));
            DProcedureObject = (ITTListBoxColumn)AddControl(new Guid("0a45cee3-7f11-4387-a5de-96b38834482d"));
            DTreatmentEquipment = (ITTListBoxColumn)AddControl(new Guid("93db94a5-6868-4de7-b643-4125d6b8fc48"));
            DProcedureDoctor = (ITTListBoxColumn)AddControl(new Guid("ef57dc0a-6d5a-4078-9c1c-ca27dee5272c"));
            DProcedureSpeciality = (ITTListBoxColumn)AddControl(new Guid("6414e859-bc58-4974-bc5f-b89a00abac7f"));
            CState = (ITTStateComboBoxColumn)AddControl(new Guid("a3c967f3-1241-4da0-b5d2-d78969cea146"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("4496ae96-6b70-4a4a-8257-14cd68efe995"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("6a167aa0-07a3-4881-87f6-1d295ef1ab94"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("c1e31a5a-b24e-4744-9857-890f43df2619"));
            labelActionDate = (ITTLabel)AddControl(new Guid("365048d8-83dc-4274-b2e0-7c94a8730ad2"));
            ReasonOfAbort = (ITTRichTextBoxControl)AddControl(new Guid("e4147742-081b-42f9-b573-8b2891ac67b2"));
            labelReasonOfAbort = (ITTLabel)AddControl(new Guid("2b31f6ed-cdf3-472d-bc56-a83b717b7fb1"));
            ttlabelReasonOfCancel = (ITTLabel)AddControl(new Guid("64dc8015-8ccf-4053-80ac-412a365ef1ed"));
            labelTreatmentDepth = (ITTLabel)AddControl(new Guid("af122815-d64c-463b-a100-eb022ba4bf7b"));
            labelPatientFollowUpForm = (ITTLabel)AddControl(new Guid("7b3732d2-92a3-41ab-8ca8-9d416738913e"));
            PatientFollowUpForm = (ITTRichTextBoxControl)AddControl(new Guid("6f0cdea5-f1fe-4205-8c5d-a62c3625e65e"));
            labelOperator = (ITTLabel)AddControl(new Guid("327c7081-0c63-4fc5-a3f8-51b8e62dcdcb"));
            Physiotherapist = (ITTObjectListBox)AddControl(new Guid("0ce9c023-918e-468b-a9c1-35d2c04df347"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("88ad6782-d441-48d0-9a04-8e6290fb343d"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("00cf3a96-c6eb-4e4a-b6ef-d0c0507acbe4"));
            base.InitializeControls();
        }

        public HyperbaricOxygenTreatmentCancelledForm() : base("HYPERBARICOXYGENTREATMENTORDER", "HyperbaricOxygenTreatmentCancelledForm")
        {
        }

        protected HyperbaricOxygenTreatmentCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}