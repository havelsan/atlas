
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
    public partial class DialysisOrderForm : BaseDialysisOrderForm
    {
    /// <summary>
    /// Diyaliz Emrinin Verildiği Nesnedir.
    /// </summary>
        protected TTObjectClasses.DialysisOrder _DialysisOrder
        {
            get { return (TTObjectClasses.DialysisOrder)_ttObject; }
        }

        protected ITTRichTextBoxControl ReasonOfAbort;
        protected ITTLabel labelReasonOfAbort;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox Amount;
        protected ITTTextBox Duration;
        protected ITTTextBox OrderNote;
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
        protected ITTListBoxColumn AyniFarkliKesi;
        protected ITTListBoxColumn OzelDurum;
        protected ITTTextBoxColumn RaporTakipNo;
        protected ITTListBoxColumn DrAnesteziTescilNo;
        protected ITTButtonColumn CokluOzelDurum;
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
        protected ITTLabel labelNurseForm;
        protected ITTLabel labelDoctorForm;
        protected ITTRichTextBoxControl DoctorFollowUpForm;
        protected ITTRichTextBoxControl NurseFollowUpForm;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel2;
        protected ITTRichTextBoxControl AbortRequestDescription;
        protected ITTLabel labelAbortRequestDescription;
        protected ITTRichTextBoxControl DoctorReturnDescription;
        protected ITTLabel labelDoctorReturnDescription;
        protected ITTRichTextBoxControl templateRTF;
        override protected void InitializeControls()
        {
            ReasonOfAbort = (ITTRichTextBoxControl)AddControl(new Guid("d078637c-f420-4d62-a8c3-c5fb365cd83f"));
            labelReasonOfAbort = (ITTLabel)AddControl(new Guid("a6a7f2fa-8366-4ea8-a355-a3799ff203a7"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("088c1343-9bf1-41a0-aff8-70b100a317ad"));
            Amount = (ITTTextBox)AddControl(new Guid("c8e7c627-8568-47c7-9ecb-3c2bff38c65c"));
            Duration = (ITTTextBox)AddControl(new Guid("6a52c9a3-535a-452d-8651-a4e95f0aa943"));
            OrderNote = (ITTTextBox)AddControl(new Guid("68c57651-d091-474e-9e30-a61addf5f810"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("895d280a-acc2-4b3e-83ca-94fb86702966"));
            LabelProtocolNo = (ITTLabel)AddControl(new Guid("a0cf5a3c-98ff-48c4-a68e-6239b7624491"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("78b936cf-718d-4ef6-a62a-f0dbd2cfa94d"));
            labelTreatmentDiagnosisUnit = (ITTLabel)AddControl(new Guid("cb1fb77c-7e4e-4e1e-a77d-2dd6af951fd6"));
            TreatmentDiagnosisUnit = (ITTObjectListBox)AddControl(new Guid("acba7ddd-82ab-4aec-a377-2ef9a1156a20"));
            labelOrderNote = (ITTLabel)AddControl(new Guid("56a50da6-dc52-4d8e-9c39-3ce37609b626"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("25252f8b-dc51-4b94-9101-4bd8e5c0cdf4"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("b29dfc65-d0bf-47b3-84fe-59cd74f6c6e6"));
            labelProcedureObject = (ITTLabel)AddControl(new Guid("13a5ffd1-b98d-4eca-9437-617f5aa9cab5"));
            OrderDetails = (ITTGrid)AddControl(new Guid("19b888f9-0b20-43d7-985b-8c914a745e7c"));
            DWorklistdate = (ITTDateTimePickerColumn)AddControl(new Guid("69f9d892-e57d-4c0b-a868-6f8f6941ae6e"));
            DActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("9e930867-7ce3-4615-ba16-b3c7eb7902aa"));
            DProcedureObject = (ITTListBoxColumn)AddControl(new Guid("49a16f48-928c-4bd9-b65e-c6cb1e56d495"));
            DNote = (ITTTextBoxColumn)AddControl(new Guid("6ec5e50a-86fc-43e7-a5be-14eb82581a90"));
            DTreatmentEquipment = (ITTListBoxColumn)AddControl(new Guid("28489fd2-d10a-4752-9d9a-e0e375b1f96b"));
            DProcedureDoctor = (ITTListBoxColumn)AddControl(new Guid("6921cd0c-82d7-4563-90a7-d3c10a00576b"));
            CState = (ITTStateComboBoxColumn)AddControl(new Guid("5012bed7-30af-4406-9907-e58124462318"));
            AyniFarkliKesi = (ITTListBoxColumn)AddControl(new Guid("5c063eee-2314-4d6d-84d0-1cb8cb13e06e"));
            OzelDurum = (ITTListBoxColumn)AddControl(new Guid("8cf3708b-54fe-4e89-ae07-e4dee13b0524"));
            RaporTakipNo = (ITTTextBoxColumn)AddControl(new Guid("268036ec-dbc3-44b8-83e9-d14ca03dea51"));
            DrAnesteziTescilNo = (ITTListBoxColumn)AddControl(new Guid("d29f19df-5bb3-4480-8972-e2520e55fe0e"));
            CokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("63c2ba92-61fa-4de9-b3c3-3dfcf4ab4e63"));
            labelActionDate = (ITTLabel)AddControl(new Guid("43ab5dd6-dc23-49a7-96ee-acca6880caea"));
            labelDuration = (ITTLabel)AddControl(new Guid("7cf2c755-a0e0-4535-8263-dbc6b68a4e57"));
            EpisodeDiagnosis = (ITTGrid)AddControl(new Guid("f4941933-56ae-4188-9bf5-ec15c2dbc540"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("bb142686-822e-4a09-90e4-180b2c0a462a"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("fd03de73-d91d-4b27-858a-eda2d0d97af0"));
            DiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("c0bed6c3-6dac-422a-bef8-4804304e9910"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("f67c3855-67a7-4c66-a5ae-2227cd8e1ec4"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("4e6f5e93-e846-4620-afed-2eb591374000"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("a5569044-c47d-4cd7-9fc5-3adf0c60171d"));
            ActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("273db21b-753a-4bdb-83b1-745b5ce013fb"));
            labelAmount = (ITTLabel)AddControl(new Guid("a2084e2b-b0d7-40b1-adb8-f049db608440"));
            labelNurseForm = (ITTLabel)AddControl(new Guid("28545d1e-a6ea-4b7a-b16c-2574186b38e1"));
            labelDoctorForm = (ITTLabel)AddControl(new Guid("9640e133-82d3-402e-ba12-d2991c21eb95"));
            DoctorFollowUpForm = (ITTRichTextBoxControl)AddControl(new Guid("76a3a765-e99a-4e69-baaf-aa157d7081c8"));
            NurseFollowUpForm = (ITTRichTextBoxControl)AddControl(new Guid("70d53c9b-48f5-42fe-9f66-c39499b87724"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("e28aa0ec-6938-4a80-aebf-ba94aa6d9d11"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("cbd89a79-95a3-4842-af14-2171283fb195"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("cef41227-06e3-4769-afc1-d25a20312fbc"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("89c45a3c-25bc-465a-99a0-85bdb895dad8"));
            AbortRequestDescription = (ITTRichTextBoxControl)AddControl(new Guid("843b491d-3843-46fa-95cc-c4518f770637"));
            labelAbortRequestDescription = (ITTLabel)AddControl(new Guid("e7737dce-41b9-4c5b-97d4-fc38c8a7cdc2"));
            DoctorReturnDescription = (ITTRichTextBoxControl)AddControl(new Guid("2579fb85-d2a4-40dc-a052-d5e66f96dd17"));
            labelDoctorReturnDescription = (ITTLabel)AddControl(new Guid("74ec6a62-ecb5-44c3-92fc-db7e3c5c1b41"));
            templateRTF = (ITTRichTextBoxControl)AddControl(new Guid("2aa0f5cf-57c2-4ae8-9091-d6e9d5f754dd"));
            base.InitializeControls();
        }

        public DialysisOrderForm() : base("DIALYSISORDER", "DialysisOrderForm")
        {
        }

        protected DialysisOrderForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}