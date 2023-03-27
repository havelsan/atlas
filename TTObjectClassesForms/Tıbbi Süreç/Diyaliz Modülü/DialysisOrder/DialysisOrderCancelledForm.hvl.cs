
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
    /// Diyaliz
    /// </summary>
    public partial class DialysisOrderCancelledForm : BaseDialysisOrderForm
    {
    /// <summary>
    /// Diyaliz Emrinin Verildiği Nesnedir.
    /// </summary>
        protected TTObjectClasses.DialysisOrder _DialysisOrder
        {
            get { return (TTObjectClasses.DialysisOrder)_ttObject; }
        }

        protected ITTTextBox ProtocolNo;
        protected ITTTextBox Amount;
        protected ITTTextBox Duration;
        protected ITTTextBox OrderNote;
        protected ITTTextBox ReasonOfCancel;
        protected ITTLabel labelRequestDate;
        protected ITTLabel LabelProtocolNo;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelTreatmentDiagnosisUnit;
        protected ITTObjectListBox TreatmentDiagnosisUnit;
        protected ITTLabel labelOrderNote;
        protected ITTDateTimePicker ActionDate;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel labelProcedureObject;
        protected ITTGrid OrderDetails;
        protected ITTDateTimePickerColumn DWorklistdate;
        protected ITTDateTimePickerColumn DActionDate;
        protected ITTListBoxColumn DProcedureObject;
        protected ITTTextBoxColumn DNote;
        protected ITTListBoxColumn DTreatmentEquipment;
        protected ITTListBoxColumn DProcedureDoctor;
        protected ITTStateComboBoxColumn CState;
        protected ITTLabel labelActionDate;
        protected ITTLabel labelDuration;
        protected ITTGrid EpisodeDiagnosis;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTListBoxColumn Diagnose;
        protected ITTEnumComboBoxColumn DiagnosisType;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTEnumComboBoxColumn ActionType;
        protected ITTLabel labelAmount;
        protected ITTRichTextBoxControl ReasonOfAbort;
        protected ITTLabel labelReasonOfAbort;
        protected ITTLabel ttlabelReasonOfCancel;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureDoctor;
        protected ITTLabel labelNurseForm;
        protected ITTLabel labelDoctorForm;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            ProtocolNo = (ITTTextBox)AddControl(new Guid("16256e97-53e4-4a54-9bcd-fa868485421b"));
            Amount = (ITTTextBox)AddControl(new Guid("dcfa5ea1-4ea5-485f-86f2-8b8b16ce2c27"));
            Duration = (ITTTextBox)AddControl(new Guid("c0315032-2470-4141-8102-fa70a65c1f19"));
            OrderNote = (ITTTextBox)AddControl(new Guid("0ae50969-630a-41c0-8945-9afd15abe768"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("84135ba4-3877-4b9b-8648-3df133473154"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("6d0b1ef7-577c-441e-aa0e-031b42c09db0"));
            LabelProtocolNo = (ITTLabel)AddControl(new Guid("6fb56e38-f325-4697-8cb1-d0d42d834ad8"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("7da502f3-cd9c-4739-aae3-37cfdc4f62ed"));
            labelTreatmentDiagnosisUnit = (ITTLabel)AddControl(new Guid("fe357436-2bdf-4e19-94e1-7811fbb9ac49"));
            TreatmentDiagnosisUnit = (ITTObjectListBox)AddControl(new Guid("bdc65230-0d25-4aa0-9382-b0a562de3615"));
            labelOrderNote = (ITTLabel)AddControl(new Guid("6336f4ac-070e-4e2e-af5a-e3d3e645a320"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("db00037c-872c-4aed-9933-d38cf0edbba8"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("26fdec3c-411f-48a5-9701-e744d51e9d9c"));
            labelProcedureObject = (ITTLabel)AddControl(new Guid("85d97b4f-5eb7-476a-9397-b94c5e812131"));
            OrderDetails = (ITTGrid)AddControl(new Guid("1c0e60f1-ba1d-4a32-9a13-cacd54599e32"));
            DWorklistdate = (ITTDateTimePickerColumn)AddControl(new Guid("50581691-71ba-48ed-9831-946b50e1ed49"));
            DActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("48c22a18-fca6-4de8-8b93-d6a7c4863c16"));
            DProcedureObject = (ITTListBoxColumn)AddControl(new Guid("c1ab6553-c956-48c4-807a-7312c76a7bea"));
            DNote = (ITTTextBoxColumn)AddControl(new Guid("d8e94f61-167d-4d69-8786-55e357fdba09"));
            DTreatmentEquipment = (ITTListBoxColumn)AddControl(new Guid("cbf9ef62-2f03-493c-8f9f-0cf5e28c26d8"));
            DProcedureDoctor = (ITTListBoxColumn)AddControl(new Guid("4815d106-cec9-4d7b-84a2-da2d5874f8ee"));
            CState = (ITTStateComboBoxColumn)AddControl(new Guid("254bb9d5-7e73-483a-9ad1-80d472c89e5d"));
            labelActionDate = (ITTLabel)AddControl(new Guid("0d708ca0-6602-4959-99e2-ab779202050e"));
            labelDuration = (ITTLabel)AddControl(new Guid("f6a203f2-7fe3-4781-b257-ef4ba5d3ef35"));
            EpisodeDiagnosis = (ITTGrid)AddControl(new Guid("6a9e0b41-be2e-459d-8207-15deea2ac7a9"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("62e98c2d-432f-487d-8e6b-d849d363dab7"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("7d0b1347-9250-4abf-b8fa-469a1d814fae"));
            DiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("d1efbe70-4768-4ab7-a483-a961b9a2842d"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("3fcd5c49-bb2a-428f-8ab7-7cf48ed13a75"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("ce8dd5d5-02ff-449a-a753-e88b43cd356f"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("4e715676-8399-489f-8d17-3e107095d855"));
            ActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("86f2d4fd-ff35-4716-ac87-67effe9a91c7"));
            labelAmount = (ITTLabel)AddControl(new Guid("15c47a88-5db2-40d6-856b-05a6a0424315"));
            ReasonOfAbort = (ITTRichTextBoxControl)AddControl(new Guid("b84909f9-07ab-4b29-9ad0-41dc7c802d01"));
            labelReasonOfAbort = (ITTLabel)AddControl(new Guid("b725f8e2-616e-499d-8148-bedbe0a5dbc0"));
            ttlabelReasonOfCancel = (ITTLabel)AddControl(new Guid("889e02e0-d1c3-4267-a5cb-227661e3ae3e"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("a6f1b650-5173-4d6f-969d-86ab635cc617"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("171069c4-9311-4534-b4d6-764ff9b40a4f"));
            labelNurseForm = (ITTLabel)AddControl(new Guid("3f0ce91e-d3eb-41b8-9883-57e25bf4d20c"));
            labelDoctorForm = (ITTLabel)AddControl(new Guid("523ec2ff-0aa6-4b91-8714-9cc149a8864f"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("3d5f675b-8605-4db1-af65-a027964c2603"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("8be5925f-1347-4bac-ba08-671a226190c5"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("48c44b46-5fe5-4b0a-b23b-2a4770108d89"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6206b0f8-4de1-4f2d-bd25-be3e98c0685f"));
            base.InitializeControls();
        }

        public DialysisOrderCancelledForm() : base("DIALYSISORDER", "DialysisOrderCancelledForm")
        {
        }

        protected DialysisOrderCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}