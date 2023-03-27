
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
    /// Ameliyat Konsültasyon
    /// </summary>
    public partial class AnesthesiaConsultationForm : EpisodeActionForm
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
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProtocolNo;
        override protected void InitializeControls()
        {
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("e27ecaef-023f-432c-b1de-22c2297e4c7f"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("557adfa4-5056-496d-bb07-65d54f95ecf5"));
            ConsultationRequesConsultationResult = (ITTRichTextBoxControl)AddControl(new Guid("c97abd71-50a8-46b9-9f8e-e59d88ffb849"));
            ConsultationRequestNote = (ITTRichTextBoxControl)AddControl(new Guid("61664838-57ed-410d-a0db-f296e5497920"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("cdbfa06d-16e1-4a1d-be31-490ef75dc6c8"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("29ffe02d-79e0-490b-84b8-1a83949784a7"));
            labelProcessDate = (ITTLabel)AddControl(new Guid("6d1155ac-b71f-40b2-883a-065ad4e6b4c9"));
            ProcessDate = (ITTDateTimePicker)AddControl(new Guid("55db874f-24aa-43c1-b2be-4fad2f6dfe14"));
            EpisodeDiagnosis = (ITTGrid)AddControl(new Guid("465f3db7-d62a-40eb-9e5b-a46c5c7f02b0"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("08defe4d-cdc1-456d-a55d-6f7aa4e0674f"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("d0285b29-a558-43d8-8e0a-eb7ef6f48d5d"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("205034b5-722c-4e2d-a1e2-0ccede352166"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("bc6b502f-746a-4264-aae7-2ed35852ed72"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("794f4559-330f-4831-9fd3-24953398dcdc"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("e5986b25-c01c-4ede-880d-7457ca8362ce"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("d792aa6b-2e14-4dea-86fc-0fee27a9876b"));
            AnesthesiaTechniqueGrid = (ITTGrid)AddControl(new Guid("e42bfdfc-3e43-44e6-b51c-6342584a097d"));
            AnesthesiaTechniqueCol = (ITTEnumComboBoxColumn)AddControl(new Guid("5917234a-ae52-4eda-993a-69cbadb50113"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("6f5b4fba-b745-4c2e-aa76-81520c381877"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("6708467b-07b3-45d0-9aed-48f6cd58e7b3"));
            base.InitializeControls();
        }

        public AnesthesiaConsultationForm() : base("ANESTHESIACONSULTATION", "AnesthesiaConsultationForm")
        {
        }

        protected AnesthesiaConsultationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}