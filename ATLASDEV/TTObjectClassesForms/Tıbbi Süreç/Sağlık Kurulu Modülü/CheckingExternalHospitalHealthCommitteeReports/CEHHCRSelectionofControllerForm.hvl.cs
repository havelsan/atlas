
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
    public partial class CEHHCRSelectionofControllerForm : EpisodeActionForm
    {
    /// <summary>
    /// Dış XXXXXX Sağlık Kurulu Raporları Kontrol
    /// </summary>
        protected TTObjectClasses.CheckingExternalHospitalHealthCommitteeReports _CheckingExternalHospitalHealthCommitteeReports
        {
            get { return (TTObjectClasses.CheckingExternalHospitalHealthCommitteeReports)_ttObject; }
        }

        protected ITTObjectListBox Result;
        protected ITTDateTimePicker SendingDate;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelSendingDate;
        protected ITTGrid MatterSliceAnecdote;
        protected ITTTextBoxColumn Slice;
        protected ITTTextBoxColumn Anectode;
        protected ITTTextBoxColumn Matter;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelResult;
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
        protected ITTTextBox ReasonForRequest;
        protected ITTTextBox ConsignmentNote;
        protected ITTObjectListBox ReasonForExamination;
        protected ITTObjectListBox ChairSendFrom;
        protected ITTLabel labelChairSendFrom;
        protected ITTLabel labelReasonForExamination;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelConsignmentNote;
        protected ITTLabel labelReasonForRequest;
        protected ITTRichTextBoxControl Decision;
        protected ITTRichTextBoxControl Report;
        override protected void InitializeControls()
        {
            Result = (ITTObjectListBox)AddControl(new Guid("04eaed6e-df1b-48c3-a826-9a8135b75477"));
            SendingDate = (ITTDateTimePicker)AddControl(new Guid("55ce4d79-777d-4ddc-95a2-a0515f8c94bc"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("cdefa55d-310f-48d4-991e-b2149ad61a85"));
            labelSendingDate = (ITTLabel)AddControl(new Guid("1793209f-5b9b-4015-8829-decf015b5aeb"));
            MatterSliceAnecdote = (ITTGrid)AddControl(new Guid("6eeca780-60a9-4090-bfea-e4d8ac31791a"));
            Slice = (ITTTextBoxColumn)AddControl(new Guid("d0f9d3b0-793f-4d5e-b66a-0391148e7188"));
            Anectode = (ITTTextBoxColumn)AddControl(new Guid("809c970e-98f0-4e68-9a26-746839179f03"));
            Matter = (ITTTextBoxColumn)AddControl(new Guid("93f0cc3f-9249-4270-9223-4fb1429ca9d5"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("1ebe09b4-56f3-4b73-a035-e84a643444ed"));
            labelResult = (ITTLabel)AddControl(new Guid("17004e07-5e27-4b62-892a-ef50cdb4681d"));
            tttabcontrolDiagnosis = (ITTTabControl)AddControl(new Guid("ab54a623-bf34-453d-ac5f-4928a7ef6fce"));
            tttabpageEpisodeDiagnosis = (ITTTabPage)AddControl(new Guid("3189ffc7-69d4-4631-91f9-3b4b6ccdd331"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("89f2c671-ce9e-4485-8207-37629fda7116"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("d1043d48-3819-4186-93c1-f187a8588c53"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("192e0ed7-feee-4d52-b7c8-e4f15e22d7e7"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("efc53f08-9ad0-47a5-aa4f-2da0f6e4bf28"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("9fbc7971-1a7c-4729-a18d-c5b144d17386"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("54833bea-96c9-4774-8ff1-2c1e82e41822"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("2e8cc4a5-d138-49e0-9218-08eed6eb0db8"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("442feb5e-dd66-4825-86be-52819e231aa8"));
            tttabpagePreDiagnosis = (ITTTabPage)AddControl(new Guid("02cc7544-842e-407a-9585-7193fff25590"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("36db5be7-c774-416d-898f-0d71c9d3469a"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("0db8307d-9143-40b9-86b7-c53a6ebb8058"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("d320f630-e09e-455f-8d9c-486380445076"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("9a3bab72-aaec-4648-8ba5-98952b59f545"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("86c28b18-0964-4d92-a7bb-2c03b909b9bd"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("18875423-db84-47f5-a611-4db19384f0f9"));
            ReasonForRequest = (ITTTextBox)AddControl(new Guid("804894ec-9fd7-4b45-993a-7fa57e95c541"));
            ConsignmentNote = (ITTTextBox)AddControl(new Guid("1e93397e-3e21-446d-adee-bbe647e8faac"));
            ReasonForExamination = (ITTObjectListBox)AddControl(new Guid("eb8aa90d-41bf-405e-94c7-248c26fa7faf"));
            ChairSendFrom = (ITTObjectListBox)AddControl(new Guid("047721a8-7586-432f-ba40-8d16af31bfdb"));
            labelChairSendFrom = (ITTLabel)AddControl(new Guid("dd6da626-79b9-4960-982d-9cfe4f51dff5"));
            labelReasonForExamination = (ITTLabel)AddControl(new Guid("1a39ec3b-a043-4c8a-9572-77244632ec7b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("96371395-6334-4103-a945-df6a48e57220"));
            labelConsignmentNote = (ITTLabel)AddControl(new Guid("39094944-8ed8-45be-a435-39ff5cb111f2"));
            labelReasonForRequest = (ITTLabel)AddControl(new Guid("07a48088-744a-4096-9d95-36c41e9ffcc2"));
            Decision = (ITTRichTextBoxControl)AddControl(new Guid("5b5d5ac4-1547-484d-88c3-7b6bf7d16878"));
            Report = (ITTRichTextBoxControl)AddControl(new Guid("cb5df105-3f28-4c67-ba8f-557247300b0f"));
            base.InitializeControls();
        }

        public CEHHCRSelectionofControllerForm() : base("CHECKINGEXTERNALHOSPITALHEALTHCOMMITTEEREPORTS", "CEHHCRSelectionofControllerForm")
        {
        }

        protected CEHHCRSelectionofControllerForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}