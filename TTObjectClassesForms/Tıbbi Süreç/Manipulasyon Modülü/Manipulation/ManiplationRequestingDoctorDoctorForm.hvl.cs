
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
    public partial class ManiplationRequestingDoctorDoctorForm : EpisodeActionForm
    {
    /// <summary>
    /// Tıbbi/Cerrahi Uygulama İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Manipulation _Manipulation
        {
            get { return (TTObjectClasses.Manipulation)_ttObject; }
        }

        protected ITTRichTextBoxControl Rapor;
        protected ITTRichTextBoxControl ProcedureReport;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage ManipulationTab;
        protected ITTGrid GridManipulations;
        protected ITTDateTimePickerColumn ManipulationActionDate;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTCheckBoxColumn Emergency;
        protected ITTListBoxColumn Department;
        protected ITTTextBoxColumn Description;
        protected ITTTabPage AdditionalApplicationTab;
        protected ITTGrid GridAdditionalApplications;
        protected ITTDateTimePickerColumn SDateTime;
        protected ITTListBoxColumn AProcedureObject;
        protected ITTTextBoxColumn Result;
        protected ITTTextBoxColumn NurseNotes;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProtocolNo;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelProcessTime;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
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
            Rapor = (ITTRichTextBoxControl)AddControl(new Guid("d0058297-c326-4246-834c-0a017f920a2c"));
            ProcedureReport = (ITTRichTextBoxControl)AddControl(new Guid("90a3bcf9-9056-4fa1-9316-0a562fc3a405"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("b5cc798b-2628-490d-bc2c-ba2f96b01c34"));
            ManipulationTab = (ITTTabPage)AddControl(new Guid("9264da2b-4567-48f0-b45f-3e61fdf0a99a"));
            GridManipulations = (ITTGrid)AddControl(new Guid("1d457f61-8120-4bda-a3e5-760a4fd09382"));
            ManipulationActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("52b01e59-e2d9-4477-a0ac-41fe463e1d63"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("614065c7-c5b7-4d3d-9518-30af96548e79"));
            Emergency = (ITTCheckBoxColumn)AddControl(new Guid("2da571e1-0243-4e82-bf1c-cef501aed50a"));
            Department = (ITTListBoxColumn)AddControl(new Guid("3f9b0adc-6def-4bae-9524-11a9ac6de125"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("97ce9893-99a0-45e9-b227-06fc609e2e2d"));
            AdditionalApplicationTab = (ITTTabPage)AddControl(new Guid("20ecf516-dd12-48d4-bd64-3b3ffe226ce7"));
            GridAdditionalApplications = (ITTGrid)AddControl(new Guid("aec863ed-e1e0-4819-8978-f5469be535f6"));
            SDateTime = (ITTDateTimePickerColumn)AddControl(new Guid("85ba17bd-d17d-416e-8aa7-53800bb66e74"));
            AProcedureObject = (ITTListBoxColumn)AddControl(new Guid("96e3089c-69f3-4dbe-aeb7-c578c0317d08"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("b0f9fa85-119a-4511-83df-4e2e2d2ba721"));
            NurseNotes = (ITTTextBoxColumn)AddControl(new Guid("fd91049b-4416-45b1-a934-8942f671c6f0"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("1fea0857-0674-4ebd-b987-84e55a199e9c"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("eeb31139-44ae-43f2-9c4c-d4adcf58b21d"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("3956a225-ecd6-4ea5-9d36-08c5e440a49e"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("9b6f828f-e884-4dcc-a2d5-ce261e84a50d"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("3f8f0fe5-7bf6-47ff-b236-7eb3468334ce"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("3d963100-dec7-40f8-8656-656e0a80006d"));
            ReturnReason = (ITTTextBoxColumn)AddControl(new Guid("aa9b82db-85eb-41ed-8143-7782e157e41c"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("ef69c7fb-09d2-4dd0-9b43-c73f382aa9b7"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("91528555-8cc9-4ce6-8802-5beb5b7a32d1"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("1c0566db-8b92-404b-9a32-121bc213d919"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("2d06ad86-8bb0-45a0-85b2-d0365770230e"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("d4a28a76-09f7-4651-821d-81b9746523a6"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("48a2b766-3139-4f61-85bc-38ca32feb5ee"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("422330b1-3126-4010-96b3-adaf7fd97ce3"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("f4283b37-0fe6-4cb3-8e55-1b622d760398"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("b437e1e9-1d41-4118-8dc9-7cff989bb02a"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("aa107655-2896-42aa-b488-2bb736e5a087"));
            DiagnosisEntryTab = (ITTTabPage)AddControl(new Guid("9d17d5e3-f4fb-46ca-9965-429eebeac63e"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("ef98e1a1-11bf-4352-8ee5-5e6f9d6b4ab2"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("cb360f1b-4b56-4ebc-8a9c-d7f4b04bc774"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("4f579acd-9168-44d0-8033-700181b13fad"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("d459ce2a-9600-4211-b33d-d6260dd947fc"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("ef3cab64-d35a-4f1c-a49d-7acec8047e0c"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("39ff5606-22fc-4d08-a40d-5accdf287d3d"));
            lblSorumluDoktor = (ITTLabel)AddControl(new Guid("e5c1f257-197c-4838-b3c7-c0150bc65ef7"));
            TTListBoxSorumluDoktor = (ITTObjectListBox)AddControl(new Guid("67a2906d-a2d5-43a7-b60a-50c40d0c92e6"));
            base.InitializeControls();
        }

        public ManiplationRequestingDoctorDoctorForm() : base("MANIPULATION", "ManiplationRequestingDoctorDoctorForm")
        {
        }

        protected ManiplationRequestingDoctorDoctorForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}