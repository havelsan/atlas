
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
    /// Hiperbarik Oksijen Tedavisi İstek
    /// </summary>
    public partial class HyperbarikOxygenTreatmentCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Hiperbarik Oksijen Tedavisi İstek
    /// </summary>
        protected TTObjectClasses.HyperbarikOxygenTreatmentRequest _HyperbarikOxygenTreatmentRequest
        {
            get { return (TTObjectClasses.HyperbarikOxygenTreatmentRequest)_ttObject; }
        }

        protected ITTLabel labelTreatment;
        protected ITTGrid HyperbaricOxygenTreatmentOrders;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTListBoxColumn TreatmentDiagnosisUnit;
        protected ITTTextBoxColumn Duration;
        protected ITTTextBoxColumn TreatmentDepth;
        protected ITTTextBoxColumn ProcedureAmount;
        protected ITTTextBoxColumn TreatmentProperties;
        protected ITTLabel lblEpisodeDiagnosis;
        protected ITTCheckBox Emergency;
        protected ITTLabel labelNote;
        protected ITTTextBox Note;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox ReasonOfCancel;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelRequestDate;
        protected ITTLabel labelReasonOfCancel;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureDoctor;
        override protected void InitializeControls()
        {
            labelTreatment = (ITTLabel)AddControl(new Guid("4bdad6e4-81e5-4492-9aea-dc6174b2a388"));
            HyperbaricOxygenTreatmentOrders = (ITTGrid)AddControl(new Guid("f937267e-9a4b-4101-a66c-d58eb281c046"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("ae0ef876-d65c-45a5-8f37-ee0b756efb91"));
            TreatmentDiagnosisUnit = (ITTListBoxColumn)AddControl(new Guid("b85a7703-16c5-4e65-8afd-1c40da66733c"));
            Duration = (ITTTextBoxColumn)AddControl(new Guid("71fe04f5-ec46-43c1-b9aa-ebce58d31565"));
            TreatmentDepth = (ITTTextBoxColumn)AddControl(new Guid("1adbdd88-6879-4c3b-ba02-3945261393b1"));
            ProcedureAmount = (ITTTextBoxColumn)AddControl(new Guid("b323085f-3930-44a6-b368-50dfaf1dc199"));
            TreatmentProperties = (ITTTextBoxColumn)AddControl(new Guid("0bdafbcd-9862-4c6a-a225-7625119ccc7b"));
            lblEpisodeDiagnosis = (ITTLabel)AddControl(new Guid("36185d6a-9dd7-49f9-8182-f9af38211f1b"));
            Emergency = (ITTCheckBox)AddControl(new Guid("47776cde-65c5-45a5-a39a-d240aacb5256"));
            labelNote = (ITTLabel)AddControl(new Guid("cbcb92e4-2419-4b54-83a3-849080306d4d"));
            Note = (ITTTextBox)AddControl(new Guid("cc918046-3314-4c08-87c7-60c7c689f768"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("bd264877-6063-4926-bc73-201306a3b912"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("b8fdeeb9-640a-43ca-946b-accbe8181bfb"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("749cfba7-b501-4a4e-bcb7-6adac3341626"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("046f60df-af6a-4856-ac23-6cc0136354aa"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("c3c28cbf-c796-46c4-89b6-d73ff7b1fdcb"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("e580dc4e-50ac-4471-9486-621c58b8d6c2"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("c16afe81-d5ca-4bb8-bc73-0aa385f2ed31"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("9b71560c-1be9-4656-b61d-bf5a8aa14b4e"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("9da09eeb-1d5f-4c2b-8f32-9d9070a496e1"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("535cbbce-e990-4665-9d9c-3f8f91636a5a"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("477440f5-1986-4282-9a32-b3377e97a50b"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("5b740449-4ed7-48ab-8279-147171c52671"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("e39c729b-ba38-446c-8cf9-406d45744bdc"));
            labelReasonOfCancel = (ITTLabel)AddControl(new Guid("0092c8af-c3ee-45f3-a452-27062a9b2c1b"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("f0e50455-b091-4b9a-ae57-b5b351009145"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("f45212e0-3f67-4fa2-b959-d8d81f85b60c"));
            base.InitializeControls();
        }

        public HyperbarikOxygenTreatmentCancelledForm() : base("HYPERBARIKOXYGENTREATMENTREQUEST", "HyperbarikOxygenTreatmentCancelledForm")
        {
        }

        protected HyperbarikOxygenTreatmentCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}