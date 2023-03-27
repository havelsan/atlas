
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
    public partial class AnesthesiaConsultationDoctorForm : BaseDoctorExaminationForm
    {
    /// <summary>
    /// Anestezi Konsültasyonu  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.AnesthesiaConsultation _AnesthesiaConsultation
        {
            get { return (TTObjectClasses.AnesthesiaConsultation)_ttObject; }
        }

        protected ITTGrid ProcedureOrderGrid;
        protected ITTButtonColumn ProcedureOrderRPT;
        protected ITTDateTimePickerColumn ProcedureOrderActionDate;
        protected ITTListBoxColumn ProcedureOrderProcedureObject;
        protected ITTDateTimePickerColumn ProcedureOrderPeriodStartTime;
        protected ITTDateTimePickerColumn ProcedureOrderDetailExecutionDate;
        protected ITTTextBoxColumn ProcedureOrderDescription;
        protected ITTTextBoxColumn ProcedureOrderDetailResult;
        protected ITTTextBoxColumn ProcedureOrderDetailNotes;
        protected ITTButton btnGroupBox4;
        protected ITTTabPage ConsultationInfo;
        protected ITTLabel labelProcessDate;
        protected ITTDateTimePicker ProcessDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel LabelDateTime;
        protected ITTEnumComboBox ASAType;
        protected ITTCheckBox ApprovalFormGiven;
        protected ITTLabel labelASAType;
        protected ITTGrid AnesthesiaTechniqueGrid;
        protected ITTEnumComboBoxColumn AnesthesiaTechniqueCol;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTRichTextBoxControl ConsultationRequestNote;
        protected ITTLabel labelProcedureDoctor;
        protected ITTRichTextBoxControl ttrichtextboxcontrol4;
        protected ITTRichTextBoxControl ttrichtextboxcontrol3;
        protected ITTRichTextBoxControl ConsultationResult;
        protected ITTRichTextBoxControl ttrichtextboxcontrol5;
        protected ITTGrid SecDiagnosisGrid;
        protected ITTCheckBoxColumn SecAddToHistory;
        protected ITTListBoxColumn SecDiagnose;
        protected ITTTextBoxColumn SecFreeDiagnosis;
        protected ITTCheckBoxColumn SecIsMainDiagnose;
        protected ITTListBoxColumn SecResponsibleUser;
        protected ITTDateTimePickerColumn SecDiagnoseDate;
        protected ITTRichTextBoxControl ttrichtextboxcontrol10;
        protected ITTButton btnGroupBox3;
        protected ITTRichTextBoxControl ttrichtextboxcontrol9;
        protected ITTRichTextBoxControl ttrichtextboxcontrol8;
        protected ITTRichTextBoxControl ttrichtextboxcontrol7;
        protected ITTRichTextBoxControl ttrichtextboxcontrol6;
        protected ITTTabPage EpisodeDiagnosis;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTButton btnGroupBox2;
        protected ITTLabel lblMasterResource;
        protected ITTObjectListBox MasterResource;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProtocolNo;
        protected ITTButton btnGroupBox1;
        override protected void InitializeControls()
        {
            ProcedureOrderGrid = (ITTGrid)AddControl(new Guid("ff7caa0b-78f5-4e80-8464-261cdd39127e"));
            ProcedureOrderRPT = (ITTButtonColumn)AddControl(new Guid("43848b1b-f7f4-4817-920b-fb019057fe3f"));
            ProcedureOrderActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("c65845e6-c91a-4eed-9435-107f21de1808"));
            ProcedureOrderProcedureObject = (ITTListBoxColumn)AddControl(new Guid("8a8f4832-4c8e-4bc3-af21-7f70fb72d719"));
            ProcedureOrderPeriodStartTime = (ITTDateTimePickerColumn)AddControl(new Guid("82017855-034a-4801-806c-978ce81bcd77"));
            ProcedureOrderDetailExecutionDate = (ITTDateTimePickerColumn)AddControl(new Guid("d596114f-c98c-4d9c-8ba4-d19318a8de4b"));
            ProcedureOrderDescription = (ITTTextBoxColumn)AddControl(new Guid("db2b8b04-14d7-4d6d-a225-d7e0d7bb84ba"));
            ProcedureOrderDetailResult = (ITTTextBoxColumn)AddControl(new Guid("fb9593ca-2b79-41fe-8203-c1e87e8a5585"));
            ProcedureOrderDetailNotes = (ITTTextBoxColumn)AddControl(new Guid("28b3a90f-ec72-4e45-9b66-d0a14a00e79d"));
            btnGroupBox4 = (ITTButton)AddControl(new Guid("f7b80da5-6061-4e56-9f0e-9939250e1455"));
            ConsultationInfo = (ITTTabPage)AddControl(new Guid("952b5e50-4016-4c61-877e-1c059bf11039"));
            labelProcessDate = (ITTLabel)AddControl(new Guid("e85c692a-29ec-438c-8acd-0567aa07c8af"));
            ProcessDate = (ITTDateTimePicker)AddControl(new Guid("a5ac6173-ddec-4ef7-85e3-42331120aacb"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("3fd0db33-91e0-4b2f-abfe-b5ef0877cf69"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("b0bf407c-594e-4d11-8666-4aa04d1c9b7d"));
            ASAType = (ITTEnumComboBox)AddControl(new Guid("95a20ea2-b536-4796-b741-16a7b45abb33"));
            ApprovalFormGiven = (ITTCheckBox)AddControl(new Guid("d67f0734-16f9-4625-b6b6-e2ff4a7948b7"));
            labelASAType = (ITTLabel)AddControl(new Guid("45e5e43b-9586-4a21-a83e-226ffe3be8ec"));
            AnesthesiaTechniqueGrid = (ITTGrid)AddControl(new Guid("3c53cadc-9db6-4fbd-98f1-ba6af3d38100"));
            AnesthesiaTechniqueCol = (ITTEnumComboBoxColumn)AddControl(new Guid("a11b96dc-65dc-4b45-9cc4-aa1eab5292fc"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("0712cbea-5274-49a7-be13-856bf33bd56c"));
            ConsultationRequestNote = (ITTRichTextBoxControl)AddControl(new Guid("67de036a-2bf8-4304-ab3a-fb8886de2317"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("9822ff6e-9a9f-47d3-b45e-c8600984058a"));
            ttrichtextboxcontrol4 = (ITTRichTextBoxControl)AddControl(new Guid("fe418cfc-7c3a-4037-b14f-893ef28f16da"));
            ttrichtextboxcontrol3 = (ITTRichTextBoxControl)AddControl(new Guid("559d80b0-ea5c-480a-80e1-a82c3e0115ad"));
            ConsultationResult = (ITTRichTextBoxControl)AddControl(new Guid("c8d45a42-fb95-4ab9-903c-3a4e92b4f73e"));
            ttrichtextboxcontrol5 = (ITTRichTextBoxControl)AddControl(new Guid("2b747ff8-ad32-4b98-b198-0ecf8d9c304d"));
            SecDiagnosisGrid = (ITTGrid)AddControl(new Guid("53be174e-a644-4943-a3f6-08a0f3a42b5d"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("bbc5ab5b-4046-4e54-9a06-fc457f26a2a2"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("d8716fcb-1d75-4525-a845-cefdf259700b"));
            SecFreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("e9b00c90-81bd-4cee-b222-362b1a7232a2"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("56ad9e06-8320-4907-b56e-a29b8c3a1df2"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("15c9cbf4-baca-468c-beab-7d990a258724"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("8ead1576-1f68-4b63-8df6-e1ee858cd6ef"));
            ttrichtextboxcontrol10 = (ITTRichTextBoxControl)AddControl(new Guid("cae591ad-1b14-487d-91af-338443166e79"));
            btnGroupBox3 = (ITTButton)AddControl(new Guid("af8c02fd-93ba-48d8-ba7f-d711c5b33aad"));
            ttrichtextboxcontrol9 = (ITTRichTextBoxControl)AddControl(new Guid("1351635c-25e3-49ea-b994-08b23039beee"));
            ttrichtextboxcontrol8 = (ITTRichTextBoxControl)AddControl(new Guid("f2bac174-ea26-4003-845d-ff2369652c3f"));
            ttrichtextboxcontrol7 = (ITTRichTextBoxControl)AddControl(new Guid("78931b0b-d329-4ad0-976b-742c04a694d1"));
            ttrichtextboxcontrol6 = (ITTRichTextBoxControl)AddControl(new Guid("ecd23f06-f779-4dda-8d02-c7c7a0c2b594"));
            EpisodeDiagnosis = (ITTTabPage)AddControl(new Guid("869274f6-57e3-45f2-950f-ef8eda06a064"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("19fb7ef9-9544-43cb-bcf6-2c28cb102a80"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("15b9b527-ed0a-42d9-a117-aedd34f07cab"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("0a0fd7c9-e333-4add-bc7e-e8fe72f608dd"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("106c6c02-614d-433b-9beb-199a36914949"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("af005a21-7a7e-4371-a7ee-97ed59c55508"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("635b6dd3-43f8-43ce-8d97-92fc5401bdfe"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("1376723e-07b9-4ede-9044-5fb7735eea7e"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("ed748257-1060-482b-bfce-0c78c5fc87d9"));
            btnGroupBox2 = (ITTButton)AddControl(new Guid("e7608b5b-c770-4b64-9374-fb5dbeac1c18"));
            lblMasterResource = (ITTLabel)AddControl(new Guid("545c0c26-670a-4a78-9d84-c15cbb57861d"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("8c43011d-3e3f-48af-a256-375948030ef0"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("aef6775a-6939-4577-921d-c4f9dcbf55ae"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("4a9e3825-b569-432b-b678-7519d74a12b7"));
            btnGroupBox1 = (ITTButton)AddControl(new Guid("a7d0c9fb-e0d4-4a81-a17c-bfaa88302d1c"));
            base.InitializeControls();
        }

        public AnesthesiaConsultationDoctorForm() : base("ANESTHESIACONSULTATION", "AnesthesiaConsultationDoctorForm")
        {
        }

        protected AnesthesiaConsultationDoctorForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}