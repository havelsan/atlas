
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
    /// Dış XXXXXX Sağlık Kurulu Raporları Kontrol  
    /// </summary>
    public partial class CEHHCRRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Dış XXXXXX Sağlık Kurulu Raporları Kontrol
    /// </summary>
        protected TTObjectClasses.CheckingExternalHospitalHealthCommitteeReports _CheckingExternalHospitalHealthCommitteeReports
        {
            get { return (TTObjectClasses.CheckingExternalHospitalHealthCommitteeReports)_ttObject; }
        }

        protected ITTRichTextBoxControl Decision;
        protected ITTRichTextBoxControl Report;
        protected ITTLabel ttlabel1;
        protected ITTGrid MatterSliceAnecdote;
        protected ITTTextBoxColumn Slice;
        protected ITTTextBoxColumn Anectode;
        protected ITTTextBoxColumn Matter;
        protected ITTTextBox ReasonForRequest;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox ConsignmentNote;
        protected ITTLabel labelProtocolNo;
        protected ITTObjectListBox ChairSendFrom;
        protected ITTLabel labelChairSendFrom;
        protected ITTLabel labelConsignmentNote;
        protected ITTLabel labelSendingDate;
        protected ITTLabel labelReasonForExamination;
        protected ITTLabel labelReasonForRequest;
        protected ITTObjectListBox ReasonForExamination;
        protected ITTDateTimePicker SendingDate;
        protected ITTTabControl tttabcontrolDiagnosis;
        protected ITTTabPage tttabpageEpisodeDiagnosis;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabPage tttabpagePreDiagnosis;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTListBoxColumn Diagnose;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        override protected void InitializeControls()
        {
            Decision = (ITTRichTextBoxControl)AddControl(new Guid("af361e69-96c9-4436-b47c-aa47fe58b1a1"));
            Report = (ITTRichTextBoxControl)AddControl(new Guid("9e3b5534-5d95-4f76-b22f-73e206412b43"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("42af2557-c669-40e9-b7c7-4356635d8943"));
            MatterSliceAnecdote = (ITTGrid)AddControl(new Guid("504ac251-76a6-47db-86d1-00cfdc62fccb"));
            Slice = (ITTTextBoxColumn)AddControl(new Guid("1ce4d223-9dea-4973-a7c8-21a6d0b8b376"));
            Anectode = (ITTTextBoxColumn)AddControl(new Guid("a8cd5239-24fe-4790-be77-e7fcd2c2a3f6"));
            Matter = (ITTTextBoxColumn)AddControl(new Guid("340c041d-ba55-48c6-9b10-e8ba7ea6d6da"));
            ReasonForRequest = (ITTTextBox)AddControl(new Guid("6d5b290a-3afc-42ca-81ea-4221575b710d"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("b762bfb8-251a-4aef-a504-4c5a1a7346c6"));
            ConsignmentNote = (ITTTextBox)AddControl(new Guid("ec62986d-a55f-4210-bcb2-7d9a127a04b2"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("1bea314e-99ce-4854-baad-6e474439167d"));
            ChairSendFrom = (ITTObjectListBox)AddControl(new Guid("b54a5df2-cd32-49c5-9107-832e50e5a43c"));
            labelChairSendFrom = (ITTLabel)AddControl(new Guid("cb7630f5-3bdd-4ffe-8ce8-95be6f5ab76c"));
            labelConsignmentNote = (ITTLabel)AddControl(new Guid("96b0b7b2-3916-46a5-83f7-9a33e2f1b881"));
            labelSendingDate = (ITTLabel)AddControl(new Guid("042d7fea-1c92-4554-af87-a7b1c92bcfdc"));
            labelReasonForExamination = (ITTLabel)AddControl(new Guid("6c211357-7912-4e7d-accb-adea985cef47"));
            labelReasonForRequest = (ITTLabel)AddControl(new Guid("27a6ab45-c51e-4cd2-9db9-bb75461f5dc7"));
            ReasonForExamination = (ITTObjectListBox)AddControl(new Guid("d33e58b5-dbcc-4a33-8cbb-cb97b7896670"));
            SendingDate = (ITTDateTimePicker)AddControl(new Guid("93bf48d6-6be0-4c8d-b70f-fb0bca757983"));
            tttabcontrolDiagnosis = (ITTTabControl)AddControl(new Guid("c2f61550-3070-44d4-abcb-efeb23e25af8"));
            tttabpageEpisodeDiagnosis = (ITTTabPage)AddControl(new Guid("05475744-1f7a-4632-b4cb-3e0c4b84e6d5"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("87cb2e18-cc5c-49cb-972b-7dd57a55c802"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("1f2d91ac-ca62-4d39-9deb-c02c06ae22b3"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("15da082b-31ff-4b56-af9f-0c22ea4bc48b"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("fa0f9632-101c-44a1-bbdd-b6f716edf3ce"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("ea55dd35-5072-41ee-8d2c-d9a9a3810718"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("11619426-9200-4224-89e9-73c1dbff08ae"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("cc74cb94-f58a-438f-a405-618b20b619a1"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("0ddccd33-bf42-4051-86b3-954a1ce53ee3"));
            tttabpagePreDiagnosis = (ITTTabPage)AddControl(new Guid("899586a9-6990-4537-838b-943b65789b85"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("a4bd7813-f9bc-408e-8083-e8fa215d8f6e"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("e0995584-7b26-4023-9511-befbb772e92f"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("b6e591f9-0180-4f6e-ad17-1cc9234628d1"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("61a917a9-62bc-4ade-907d-f4ea535f037c"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("e1b7e8da-e98a-48b1-a986-d0fecea042fb"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("ea256374-7704-47f0-bdf6-9ff0641a46b2"));
            base.InitializeControls();
        }

        public CEHHCRRequestForm() : base("CHECKINGEXTERNALHOSPITALHEALTHCOMMITTEEREPORTS", "CEHHCRRequestForm")
        {
        }

        protected CEHHCRRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}