
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
    /// Minör Tıbbi Uygulamaları
    /// </summary>
    public partial class MinorManipulationDoctorForm : EpisodeActionForm
    {
    /// <summary>
    /// Minör Tıbbı Uygulama İşlemlerinin Gerçekleştirildiği Nesnedir
    /// </summary>
        protected TTObjectClasses.MinorManipulation _MinorManipulation
        {
            get { return (TTObjectClasses.MinorManipulation)_ttObject; }
        }

        protected ITTLabel labelOzelDurum;
        protected ITTObjectListBox OzelDurum;
        protected ITTObjectListBox SorumluDoktor;
        protected ITTLabel labelMinorManipulationProcessTime;
        protected ITTDateTimePicker ActionDate;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel lblSorumluDoktor;
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
        protected ITTTabControl TabSubaction;
        protected ITTTabPage AdditionalApplicationsTab;
        protected ITTGrid GridAdditionalApplications;
        protected ITTDateTimePickerColumn SDateTime;
        protected ITTListBoxColumn AProcedureObject;
        protected ITTTextBoxColumn Result;
        protected ITTTextBoxColumn NurseNotes;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid GridTreatmentMaterials;
        protected ITTDateTimePickerColumn MaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn UseAmount;
        protected ITTTextBoxColumn UnitType;
        protected ITTTextBoxColumn UBBCode;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBoxColumn Notes;
        protected ITTTabPage PersonnelTab;
        protected ITTGrid GridPersonnel;
        protected ITTListBoxColumn Personnel;
        override protected void InitializeControls()
        {
            labelOzelDurum = (ITTLabel)AddControl(new Guid("580df227-698d-4d50-a9f6-af4f9a7075dc"));
            OzelDurum = (ITTObjectListBox)AddControl(new Guid("242d0f1b-04a1-4232-a5f0-aabddcba0017"));
            SorumluDoktor = (ITTObjectListBox)AddControl(new Guid("ed46f0eb-b22d-46b4-8d3b-260998248766"));
            labelMinorManipulationProcessTime = (ITTLabel)AddControl(new Guid("e786f80e-f593-4b68-a364-7a5d05ef5741"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("23422fa1-c546-4b0e-9ee5-9be35d088603"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("cf8b1e4f-f70c-47ab-b473-f8c1bdf4e30b"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("799d41bd-7394-410c-91f1-fe66075290a9"));
            lblSorumluDoktor = (ITTLabel)AddControl(new Guid("ff73f46a-5624-45a9-8ed3-5d0c5fc38287"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("aa956037-2a4f-44d6-9e04-4d4a328b3a06"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("e97fe44e-3caa-40fc-bf51-83712d4e3f7c"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("c306ab7d-a04b-4f1d-b7c4-baa31bc4595b"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("7bbb1d62-03ee-455f-981f-153cf6092373"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("cc5de196-61a4-439a-8785-c34c9848e333"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("e848e245-875c-4185-90cf-27fdfc87ad08"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("c5b2784f-81b2-4020-9ce1-00ee8a70e6c7"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("43192760-a367-4adb-9038-01ebd906b185"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("f2661963-4a94-4265-95ab-f091f6ffc496"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("f063649b-0b7a-4802-87fe-7654195561b9"));
            DiagnosisEntryTab = (ITTTabPage)AddControl(new Guid("7759ac6a-3799-4e4c-baab-6fb9bc31f04c"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("3b04baef-d36a-46bc-8e19-59a0f1b2e06b"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("3c861b35-e35a-4874-bafb-ec9c8883e2f0"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("4925b808-0cb8-48e4-ac13-5c315367cbf5"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("4b0d9fdd-1ae2-4cf4-84bf-5a51fe5ca5cb"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("b8c9d042-8900-47ae-854c-15d50f73af5a"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("90e52fd2-6d82-4054-8b7e-2183dce57e71"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("00b96000-c91e-4d8d-ac16-15d40013f6e9"));
            AdditionalApplicationsTab = (ITTTabPage)AddControl(new Guid("31e3b080-5269-47f4-a54a-ea707eec6e27"));
            GridAdditionalApplications = (ITTGrid)AddControl(new Guid("3fcd6c9f-ffaf-406d-a7f5-067384b8f238"));
            SDateTime = (ITTDateTimePickerColumn)AddControl(new Guid("f5bd78db-320a-49b7-b4cd-1903ca36e8c9"));
            AProcedureObject = (ITTListBoxColumn)AddControl(new Guid("abf82836-a3d9-4fbf-96a0-7e943a606f79"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("4aa7fd14-444b-47ab-b558-e12f3463011a"));
            NurseNotes = (ITTTextBoxColumn)AddControl(new Guid("645f661f-1d65-44a2-9b70-44d136a7b792"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("7e999cc6-2012-447a-a863-dd37c6251f29"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("4b3c9827-57a4-41c7-9b51-dbfa45ee2549"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("3602765c-3713-4c01-9dd2-e0d65005aa1c"));
            Material = (ITTListBoxColumn)AddControl(new Guid("3a4f795d-1b1e-4de1-b99c-e8e7f223671a"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("5a781bea-48b2-4935-95fa-ba8859b67587"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("34c2b14c-4cd3-470e-b4db-bb0f2d910360"));
            UseAmount = (ITTTextBoxColumn)AddControl(new Guid("ca88a602-c111-4a56-923b-66691500157f"));
            UnitType = (ITTTextBoxColumn)AddControl(new Guid("f7a6aa19-877c-4053-befa-73c1c595eefe"));
            UBBCode = (ITTTextBoxColumn)AddControl(new Guid("d6122b67-5ad0-4bf3-adce-f4b044c51f97"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("efa405ce-37fc-44f6-8cc2-36ea7f62fc0c"));
            Notes = (ITTTextBoxColumn)AddControl(new Guid("cebee2ec-89de-4c14-b3cb-f28f0ce583a3"));
            PersonnelTab = (ITTTabPage)AddControl(new Guid("0467b75c-cbac-43d6-9685-679dcf23a84c"));
            GridPersonnel = (ITTGrid)AddControl(new Guid("b72db74c-af44-423c-9350-1a8f568ba769"));
            Personnel = (ITTListBoxColumn)AddControl(new Guid("4b4114ec-965a-4d88-aae7-e697789d0293"));
            base.InitializeControls();
        }

        public MinorManipulationDoctorForm() : base("MINORMANIPULATION", "MinorManipulationDoctorForm")
        {
        }

        protected MinorManipulationDoctorForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}