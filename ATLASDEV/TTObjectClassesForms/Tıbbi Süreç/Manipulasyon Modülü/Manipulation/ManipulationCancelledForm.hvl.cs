
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
    /// Tıbbi/Cerrahi Uygulamalar
    /// </summary>
    public partial class ManipulationCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Tıbbi/Cerrahi Uygulama İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Manipulation _Manipulation
        {
            get { return (TTObjectClasses.Manipulation)_ttObject; }
        }

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
        protected ITTTabPage PersonnelTab;
        protected ITTGrid GridPersonnel;
        protected ITTListBoxColumn Personnel;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid GridTreatmentMaterials;
        protected ITTDateTimePickerColumn MaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn UseAmount;
        protected ITTTextBoxColumn UnitType;
        protected ITTTextBoxColumn UBBCode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Notes;
        protected ITTTabPage AdditionalApplicationTab;
        protected ITTGrid GridAdditionalApplications;
        protected ITTDateTimePickerColumn SDateTime;
        protected ITTListBoxColumn AProcedureObject;
        protected ITTTextBoxColumn Result;
        protected ITTTextBoxColumn NurseNotes;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox ReasonOfCancel;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelProcessTime;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelReasonOfCancel;
        protected ITTLabel lblSorumluDoktor;
        protected ITTObjectListBox TTListBoxSorumluDoktor;
        override protected void InitializeControls()
        {
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("9b27f089-b7f1-43a2-aa20-19c156be7747"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("3742e97c-f878-4c74-b869-f9ebc9de4d85"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("cca13f79-75a2-498d-a55f-a33776e2caae"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("f911ba3d-ae2d-49ee-8492-719febe21d1d"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("1f2cf12c-a5bb-44c5-90a2-d7463c9e5cb7"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("0526cbd5-3cb4-4e77-adf1-d346b85a7ecd"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("33d93066-23dc-4039-b04b-79c1ec135284"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("b20e6110-7865-4f4e-8a3d-65095ed4c287"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("c0c832d7-19d6-41f4-a446-11af30986760"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("012328e3-9968-415b-ac01-9193f22e15f7"));
            DiagnosisEntryTab = (ITTTabPage)AddControl(new Guid("361bd42d-fc5d-4e52-9685-209e69fffe6f"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("a385d932-8668-48db-9b90-7a8345f5069b"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("1043d63f-300d-4472-a283-b58c996a781a"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("1f8eefa3-7792-42a3-897e-350bc4d253ba"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("45f13891-3b6b-4ca4-90d8-1393b9619de4"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("d226a5ca-33f3-49d7-aeef-a6d0b9d504ae"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("85cf27ed-9587-427f-85e6-9bb9a0c319e4"));
            Rapor = (ITTRichTextBoxControl)AddControl(new Guid("6aea904b-fb9f-4471-9acf-31f182c4f404"));
            ProcedureReport = (ITTRichTextBoxControl)AddControl(new Guid("84ef7fa8-f2ab-4ec9-a87b-862fe7b68bf6"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("a8f1bbcc-3828-46e7-b33e-bfbeeb91c77f"));
            ManipulationTab = (ITTTabPage)AddControl(new Guid("495de958-b2c6-45a5-997c-2b908ff42f82"));
            GridManipulations = (ITTGrid)AddControl(new Guid("fef8c36c-99a0-44ee-84fa-aca5232fb5f3"));
            ManipulationActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("336d231b-b51a-4c1b-a6fe-8ed9b573a13b"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("50bfe596-1818-4bfa-b786-396c50cdae53"));
            Emergency = (ITTCheckBoxColumn)AddControl(new Guid("6cfc6eac-3f59-4b74-ac18-817ce75bb832"));
            Department = (ITTListBoxColumn)AddControl(new Guid("c4905ac1-8df9-4e17-ae1a-674cc70b3b0d"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("92251c5c-87fc-4480-96b1-f37c3b3e70d1"));
            PersonnelTab = (ITTTabPage)AddControl(new Guid("1ab051e1-522c-459a-99f3-06d57441782b"));
            GridPersonnel = (ITTGrid)AddControl(new Guid("bc2d7ede-6758-41f1-98e2-cfe4990fffeb"));
            Personnel = (ITTListBoxColumn)AddControl(new Guid("faf53d4b-feed-454f-8ed8-37e861ebffef"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("866910f1-bcce-41b0-88b6-930021d6e248"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("8680336d-6b78-4bab-8f81-746997a6630b"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("211ba9fb-48ca-4da4-aee8-64923a3d8bbc"));
            Material = (ITTListBoxColumn)AddControl(new Guid("c4ed514e-c85a-463c-ac0c-016f13605649"));
            UseAmount = (ITTTextBoxColumn)AddControl(new Guid("e71d739c-44a5-4ea2-93fd-59a5b5bb413a"));
            UnitType = (ITTTextBoxColumn)AddControl(new Guid("cffaf775-f244-48b5-a529-3a9ec3773680"));
            UBBCode = (ITTTextBoxColumn)AddControl(new Guid("36ac74d8-d745-4590-91bb-34dd8ff99fc0"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("4405c110-dfc0-4dd5-a658-cfb3f80db18c"));
            Notes = (ITTTextBoxColumn)AddControl(new Guid("dc360d3a-a8cb-4eec-954f-52d0f2ece84a"));
            AdditionalApplicationTab = (ITTTabPage)AddControl(new Guid("6a59737f-e1da-479d-acd1-23a1979f05d2"));
            GridAdditionalApplications = (ITTGrid)AddControl(new Guid("c61b96cd-27d6-4e4d-b7f6-fbdb4da0d1fe"));
            SDateTime = (ITTDateTimePickerColumn)AddControl(new Guid("33a43678-16fb-41fe-b153-564e35cd532f"));
            AProcedureObject = (ITTListBoxColumn)AddControl(new Guid("0463069d-0774-4322-bd96-68e93c05e17c"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("2182cd42-6c64-4c37-8551-560425158d4a"));
            NurseNotes = (ITTTextBoxColumn)AddControl(new Guid("ac94cf4a-56c1-44a4-8888-dac0d41eefc7"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("35b9b8f3-57a7-46af-b009-85eedec83dfd"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("fe7b9da8-c939-456c-a3c1-d61610fa3120"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("8b448c2a-8abe-4fca-9b46-ae0b81fb974c"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("1983db38-7ea2-4934-a93a-d655d9f42c2b"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("580e53fe-bf4b-4def-b06b-10a0ca992e84"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("9cd92f28-f7fe-4c35-823f-8a5aa239ba84"));
            labelReasonOfCancel = (ITTLabel)AddControl(new Guid("1474a7fb-3221-4c19-9ff6-075204e7f926"));
            lblSorumluDoktor = (ITTLabel)AddControl(new Guid("edef30b4-03a2-4bdd-94da-6d8d54b42754"));
            TTListBoxSorumluDoktor = (ITTObjectListBox)AddControl(new Guid("342e3de3-2134-431d-8586-fbd5a6470277"));
            base.InitializeControls();
        }

        public ManipulationCancelledForm() : base("MANIPULATION", "ManipulationCancelledForm")
        {
        }

        protected ManipulationCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}