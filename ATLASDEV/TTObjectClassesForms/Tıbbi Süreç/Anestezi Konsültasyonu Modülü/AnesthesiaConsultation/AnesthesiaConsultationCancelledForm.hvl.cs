
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
    /// Anestezi Konsültasyonu
    /// </summary>
    public partial class AnesthesiaConsultationCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Anestezi Konsültasyonu  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.AnesthesiaConsultation _AnesthesiaConsultation
        {
            get { return (TTObjectClasses.AnesthesiaConsultation)_ttObject; }
        }

        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureDoctor;
        protected ITTRichTextBoxControl ConsultationRequesConsultationResult;
        protected ITTRichTextBoxControl ConsultationRequestNote;
        protected ITTLabel LabelDateTime;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelProcessDate;
        protected ITTDateTimePicker ProcessDate;
        protected ITTGrid EpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTGrid AnesthesiaTechniqueGrid;
        protected ITTEnumComboBoxColumn AnesthesiaTechniqueCol;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelProtocolNo;
        override protected void InitializeControls()
        {
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("70d58196-9431-4e35-918f-ccabf9af08a6"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("cd3f2746-df18-4248-a350-ab892dc5ceec"));
            ConsultationRequesConsultationResult = (ITTRichTextBoxControl)AddControl(new Guid("437e4e57-40bd-4929-86c1-261b436a0da1"));
            ConsultationRequestNote = (ITTRichTextBoxControl)AddControl(new Guid("292071ed-963e-41d0-864a-add03122b6fd"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("b2305c0c-5a46-4ed4-8c8b-840820f95b47"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("cbe2fd1c-0a44-48a1-9ca1-2cb53e5b50c6"));
            labelProcessDate = (ITTLabel)AddControl(new Guid("a56ad0c6-e2c9-4ec7-b55e-aeaf8161cff7"));
            ProcessDate = (ITTDateTimePicker)AddControl(new Guid("faac00a4-9e0a-4df4-bfc8-ad596dfd0d5a"));
            EpisodeDiagnosis = (ITTGrid)AddControl(new Guid("cf616121-f5c6-4667-a795-d58e06e3623c"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("9955d866-49ca-431c-bd63-7887982e6358"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("2e6def4c-091d-401c-a1e8-c8e626151937"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("1621b151-6284-442e-bd68-5da877ca6304"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("475d169e-6ab9-4c82-905f-d148201e4ae0"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("22553660-9ecd-4d55-87ed-f9f790457fd9"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("4ebe6996-f5e9-48f8-85ed-fec7c0d2737e"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("4b81415d-522b-4bfd-8a70-64c1b21aa163"));
            AnesthesiaTechniqueGrid = (ITTGrid)AddControl(new Guid("d8a54830-0778-46e2-9d96-cab40b176b91"));
            AnesthesiaTechniqueCol = (ITTEnumComboBoxColumn)AddControl(new Guid("80cac075-e612-4d44-a6e5-4a2a89013491"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("35d4033c-a148-489f-b8ce-7c121fe32294"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("5dc0c9f3-81e2-4c8a-bba2-b018cbe9337b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("35dd4d13-0626-40c0-b555-3d3c8671518f"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("fd0ef28d-37c4-41e2-b241-d3ba28076e74"));
            base.InitializeControls();
        }

        public AnesthesiaConsultationCancelledForm() : base("ANESTHESIACONSULTATION", "AnesthesiaConsultationCancelledForm")
        {
        }

        protected AnesthesiaConsultationCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}