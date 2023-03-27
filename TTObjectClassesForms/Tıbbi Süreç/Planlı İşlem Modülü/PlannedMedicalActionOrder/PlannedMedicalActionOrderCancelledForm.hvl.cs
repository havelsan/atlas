
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
    public partial class PlannedMedicalActionOrderCancelledForm : BasePlannedMedicalActionOrderForm
    {
    /// <summary>
    /// Planlı Tıbbi İşlem Emri
    /// </summary>
        protected TTObjectClasses.PlannedMedicalActionOrder _PlannedMedicalActionOrder
        {
            get { return (TTObjectClasses.PlannedMedicalActionOrder)_ttObject; }
        }

        protected ITTTextBox ProtocolNo;
        protected ITTTextBox Amount;
        protected ITTTextBox ApplicationArea;
        protected ITTTextBox Duration;
        protected ITTTextBox OrderNote;
        protected ITTTextBox TreatmentProperties;
        protected ITTTextBox ReasonOfCancel;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel LabelProtocolNo;
        protected ITTLabel lblEpisodeDiagnosis;
        protected ITTLabel labelOrderNote;
        protected ITTLabel labelTreatmentProperties;
        protected ITTLabel labelApplicationArea;
        protected ITTLabel ttlabel6;
        protected ITTLabel labelDuration;
        protected ITTObjectListBox ProcedureObject;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTLabel labelProcedureObject;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelTreatmentDiagnosisUnit;
        protected ITTObjectListBox TreatmentUnit;
        protected ITTRichTextBoxControl ReasonOfAbort;
        protected ITTLabel labelReasonOfAbort;
        protected ITTLabel labelOrderUser;
        protected ITTObjectListBox OrderProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureDoctor;
        protected ITTLabel ttlabelReasonOfCancel;
        protected ITTGrid OrderDetails;
        protected ITTCheckBoxColumn DEmergency;
        protected ITTDateTimePickerColumn DWorkListDate;
        protected ITTDateTimePickerColumn DActionDate;
        protected ITTListBoxColumn DProcedureObject;
        protected ITTRichTextBoxControlColumn DNote;
        protected ITTListBoxColumn DProcedureDoctor;
        protected ITTStateComboBoxColumn CState;
        override protected void InitializeControls()
        {
            ProtocolNo = (ITTTextBox)AddControl(new Guid("be281d71-8238-4111-a793-bc8588b1bd4c"));
            Amount = (ITTTextBox)AddControl(new Guid("f1c0bdd1-39cb-4377-8c86-1ec611f2a2de"));
            ApplicationArea = (ITTTextBox)AddControl(new Guid("1c9d6364-7d79-4eb9-8a8f-fd35ac6cbe0d"));
            Duration = (ITTTextBox)AddControl(new Guid("f8b6ef69-0917-485a-a9ef-05a3a81059ef"));
            OrderNote = (ITTTextBox)AddControl(new Guid("e2d93147-ddc2-476b-93e4-0d3a07f4a23b"));
            TreatmentProperties = (ITTTextBox)AddControl(new Guid("eed46242-a1ee-4738-84aa-2a2d07f65a40"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("584ccb57-03e5-474d-94e6-d184f9193be5"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("66ffb8fd-930d-4248-b9ee-20b03e743b8b"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("8c0c8975-82c1-43a6-9612-0d333ca335aa"));
            LabelProtocolNo = (ITTLabel)AddControl(new Guid("fab33b2d-8379-48d4-919d-9799a4f0ddb5"));
            lblEpisodeDiagnosis = (ITTLabel)AddControl(new Guid("bad89114-0778-4533-842a-06fd18d8760a"));
            labelOrderNote = (ITTLabel)AddControl(new Guid("616be4ab-cf8d-4ccd-88a2-3cd6d1b0af51"));
            labelTreatmentProperties = (ITTLabel)AddControl(new Guid("2ceb6262-fbc9-4ec9-90cb-9b67c1d97cd4"));
            labelApplicationArea = (ITTLabel)AddControl(new Guid("5046a4e0-3d48-4e16-addc-56d5ccf60b0b"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("08be7f32-6831-4426-a58c-2df38cd1e4dd"));
            labelDuration = (ITTLabel)AddControl(new Guid("a823ceb5-19df-402d-ac69-a22cf122236e"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("50a32c94-5686-4321-b787-7a1534aa3193"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("6ffa8e14-0e77-49c2-a958-cee275ea47d1"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("bb79e484-040b-4f16-a4be-c837e8e7534f"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("c04500bc-e779-4a32-a462-48da2a3bc563"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("7fb05c66-9238-4fe4-9c90-6d711e7ab004"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("9df08ec0-3acd-48ba-80b3-456586ad6c12"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("028d071c-3821-4e1f-a3d2-97e557a627f2"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("16d26560-6810-48f1-999c-51add40bd881"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("7be85565-3b5e-4815-8b65-55335f9537f8"));
            labelProcedureObject = (ITTLabel)AddControl(new Guid("855e52b3-b218-48fa-9c90-85c207db6d07"));
            labelActionDate = (ITTLabel)AddControl(new Guid("dfd9d226-062b-417f-82b0-085b7e748cbb"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("7b30ad4c-6454-48e8-b3dd-19f60e3e29e6"));
            labelTreatmentDiagnosisUnit = (ITTLabel)AddControl(new Guid("b742a8bb-c3ad-4e70-82ce-df8cfac1836d"));
            TreatmentUnit = (ITTObjectListBox)AddControl(new Guid("7d1796aa-8f11-485e-8491-9dce74fd9f72"));
            ReasonOfAbort = (ITTRichTextBoxControl)AddControl(new Guid("f40e9582-63ff-4652-b869-ec16b3c654d5"));
            labelReasonOfAbort = (ITTLabel)AddControl(new Guid("48274335-fd4b-4f67-813e-ee1db75cae37"));
            labelOrderUser = (ITTLabel)AddControl(new Guid("b05678c9-da51-4432-b995-6a8d198b70f3"));
            OrderProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("f2ba5852-e978-44fc-802c-2a27f01c399d"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("f79c6148-3487-4ec4-aa1c-cc53f2417254"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("3a93a086-108f-4240-a9a2-89deaa0c6fff"));
            ttlabelReasonOfCancel = (ITTLabel)AddControl(new Guid("e367e89e-bada-4e50-aa79-64f31243a9b4"));
            OrderDetails = (ITTGrid)AddControl(new Guid("922c2254-2e16-490c-8c4a-58eaa3d41757"));
            DEmergency = (ITTCheckBoxColumn)AddControl(new Guid("5587f21f-9924-4121-beed-fe83828d2dc6"));
            DWorkListDate = (ITTDateTimePickerColumn)AddControl(new Guid("e3087fbf-9cb4-475c-80af-cdce31e8bc33"));
            DActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("59115c15-470e-4e84-a792-d4d8e89c8d39"));
            DProcedureObject = (ITTListBoxColumn)AddControl(new Guid("e2f30c15-0c75-4277-9a70-6314b1e27d4a"));
            DNote = (ITTRichTextBoxControlColumn)AddControl(new Guid("61f5b736-5fd8-4498-9a35-e34022f29833"));
            DProcedureDoctor = (ITTListBoxColumn)AddControl(new Guid("c9c90fae-cd3b-48ff-a660-5f08b7ef7823"));
            CState = (ITTStateComboBoxColumn)AddControl(new Guid("98333c9d-8998-4a5a-a5c1-78f8ad25fe3e"));
            base.InitializeControls();
        }

        public PlannedMedicalActionOrderCancelledForm() : base("PLANNEDMEDICALACTIONORDER", "PlannedMedicalActionOrderCancelledForm")
        {
        }

        protected PlannedMedicalActionOrderCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}