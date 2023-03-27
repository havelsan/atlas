
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
    /// Tıbbi/Cerrahi Uygulamaları
    /// </summary>
    public partial class ManiplationRequestingDoctorAcception : EpisodeActionForm
    {
    /// <summary>
    /// Tıbbi/Cerrahi Uygulama İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Manipulation _Manipulation
        {
            get { return (TTObjectClasses.Manipulation)_ttObject; }
        }

        protected ITTTabControl TabSubaction;
        protected ITTTabPage ManipulationTab;
        protected ITTGrid GridManipulations;
        protected ITTDateTimePickerColumn ManipulationActionDate;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTCheckBoxColumn Emergency;
        protected ITTListBoxColumn Department;
        protected ITTTextBoxColumn Description;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProtocolNo;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelProcessTime;
        protected ITTRichTextBoxControl PreInformation;
        protected ITTGrid ttgrid2;
        protected ITTTextBoxColumn ReturnReason;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage EpisodeDiagnosisTab;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabPage DiagnosisEntryTab;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn SecAddToHistory;
        protected ITTListBoxColumn SecDiagnose;
        protected ITTCheckBoxColumn SecIsMainDiagnose;
        protected ITTListBoxColumn SecResponsibleUser;
        protected ITTDateTimePickerColumn SecDiagnoseDate;
        protected ITTLabel lblSorumluDoktor;
        protected ITTObjectListBox TTListBoxSorumluDoktor;
        override protected void InitializeControls()
        {
            TabSubaction = (ITTTabControl)AddControl(new Guid("790d1bcd-2c54-4030-881c-297cbd91ed47"));
            ManipulationTab = (ITTTabPage)AddControl(new Guid("3e4e8a7c-a20a-4c15-a466-3c32621a5ee5"));
            GridManipulations = (ITTGrid)AddControl(new Guid("0921f057-e6dd-405c-858e-44168e1c186f"));
            ManipulationActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("87c592d7-6afb-453c-a4f7-cec28c6b0fcb"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("3b5bae9d-c0a6-4a96-bd6a-089316798304"));
            Emergency = (ITTCheckBoxColumn)AddControl(new Guid("bdba93e0-1d0c-4351-ad46-4671555cafb3"));
            Department = (ITTListBoxColumn)AddControl(new Guid("1facd469-9b3b-4288-b27c-ebe84edced99"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("9a0e282c-0de9-4aae-8ac6-739a8d9c90ce"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("c7fdbfd2-6252-4001-ba61-9820e3821086"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("9779b4de-3dd6-4956-8970-36f949b15edc"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("058333c9-14ad-4630-8f3f-35d768e0536d"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("0887c9ee-d5fa-42eb-b535-c5f52506e156"));
            PreInformation = (ITTRichTextBoxControl)AddControl(new Guid("7564d64f-0183-4cf3-bb97-16acbdc7697d"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("8587776b-465f-4f77-bda0-607bf5832bc9"));
            ReturnReason = (ITTTextBoxColumn)AddControl(new Guid("967079d7-77eb-4cf4-8c59-b29be23308cc"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("6f4f89af-8dc1-48e1-8267-382e26c9bf63"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("8ba74cdb-9f8a-4853-9fc5-85e0402ed4a6"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("70bd52de-9b58-45da-93ac-eb12afa3962f"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("9cf545bc-8e76-4b66-95d7-6c3106af7f44"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("faeb4c76-d08c-4202-be82-2869a0e84fbc"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("5be81c2f-7c3c-49b3-bf02-c8382c695ae7"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("0c746201-4754-4776-af9e-921b57f790df"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("d6d6a09f-4fc2-42ed-ba6e-3c97be6902fe"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("1ba5af50-c602-4ee0-a905-80e4e22929a5"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("01c26ed2-cd2d-4f21-8faf-43be6b412702"));
            DiagnosisEntryTab = (ITTTabPage)AddControl(new Guid("209fcbbc-c7ef-49a4-aecb-13f211b87c33"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("4ceba9e2-7c71-4b56-a903-39674b49d230"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("3cfbc8bd-5255-4c8a-b0f6-593f1c878276"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("33db399e-d097-48a8-a44a-154a4a095769"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("6230a2eb-1029-4a0e-91c0-6f19920f5522"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("6ac985dc-f277-4618-81b5-488473c4c790"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("35393230-de85-4948-99ae-5558c268fb01"));
            lblSorumluDoktor = (ITTLabel)AddControl(new Guid("dac75f23-c1a9-4be1-8264-a53f101e079d"));
            TTListBoxSorumluDoktor = (ITTObjectListBox)AddControl(new Guid("88be0e03-b511-4fa1-a945-a48e147e4638"));
            base.InitializeControls();
        }

        public ManiplationRequestingDoctorAcception() : base("MANIPULATION", "ManiplationRequestingDoctorAcception")
        {
        }

        protected ManiplationRequestingDoctorAcception(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}