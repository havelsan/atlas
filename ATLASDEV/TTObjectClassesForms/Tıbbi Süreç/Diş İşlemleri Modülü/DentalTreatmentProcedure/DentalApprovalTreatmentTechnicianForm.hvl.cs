
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
    /// Diş Tedavi İşlemi
    /// </summary>
    public partial class DentalApprovalTreatmentTechnicianForm : SubactionProcedureFlowableForm
    {
    /// <summary>
    /// Diş Tedavi Prosedür
    /// </summary>
        protected TTObjectClasses.DentalTreatmentProcedure _DentalTreatmentProcedure
        {
            get { return (TTObjectClasses.DentalTreatmentProcedure)_ttObject; }
        }

        protected ITTEnumComboBox ToothNumber;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage GridDiagnosisEntry;
        protected ITTGrid SecDiagnosis;
        protected ITTCheckBoxColumn SecAddToHistory;
        protected ITTEnumComboBoxColumn SecToothNum;
        protected ITTEnumComboBoxColumn SecDentalPosition;
        protected ITTButtonColumn SecToothSchema;
        protected ITTListBoxColumn SecDiagnose;
        protected ITTCheckBoxColumn SecIsMainDiagnose;
        protected ITTListBoxColumn SecResponsibleUser;
        protected ITTDateTimePickerColumn SecDiagnoseDate;
        protected ITTTabPage EpisodeDiagnosisPage;
        protected ITTGrid EpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTListBoxColumn Diagnose;
        protected ITTEnumComboBoxColumn DiagnosisType;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTTextBox TechnicianNote;
        protected ITTLabel labelTechnicalDepartment;
        protected ITTLabel labelDefinitiontoTechnician;
        protected ITTObjectListBox TechnicalDepartment;
        protected ITTTabControl SubactionTab;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid TreatmentMaterials;
        protected ITTDateTimePickerColumn MaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn MaterialAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn Note;
        protected ITTTextBox DefinitiontoTechnician;
        protected ITTTextBox DentalTreatmentDescription;
        protected ITTTextBox Amount;
        protected ITTLabel labelTechnicianNote;
        protected ITTLabel labelDentalTreatmentDescription;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTObjectListBox DentalRequestType;
        protected ITTCheckBox Emergency;
        protected ITTLabel ttlabel11;
        protected ITTLabel labelAmount;
        protected ITTEnumComboBox DentalPosition;
        protected ITTLabel labelDentalRequestType;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelDepartment;
        protected ITTLabel labelProcedure;
        protected ITTObjectListBox ProcedureDepartment;
        protected ITTLabel labelDentalPosition;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel labelToothNumber;
        protected ITTLabel LabelDateTime;
        protected ITTDateTimePicker RequestDate;
        protected ITTCheckBox ttcheckbox1;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTButton btnNewTreatmentDischarge;
        protected ITTButton ttbuttonToothSchema;
        override protected void InitializeControls()
        {
            ToothNumber = (ITTEnumComboBox)AddControl(new Guid("c08b49a2-7d9b-455e-a7c7-42ee05fdd153"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("cc1171c5-2961-4246-9e09-4cce0b927a58"));
            GridDiagnosisEntry = (ITTTabPage)AddControl(new Guid("a7b8056d-48a0-409f-92b3-790f84fa0b66"));
            SecDiagnosis = (ITTGrid)AddControl(new Guid("ca969baf-00e5-4d81-92d5-36be66b72fb2"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("d64fc4eb-fbcf-40be-a934-e31dcc2fb4d9"));
            SecToothNum = (ITTEnumComboBoxColumn)AddControl(new Guid("71c70540-dbb5-45dc-bd0d-fa4aa747866c"));
            SecDentalPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("5dad627a-5825-484d-8df7-01f081680829"));
            SecToothSchema = (ITTButtonColumn)AddControl(new Guid("96812a3d-feff-42a0-b740-b8ff566485bb"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("368c2c36-5edc-4a79-88a0-75e77690dcc3"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("1e49d509-205f-4732-93eb-7c79fbf8edb7"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("d0514a00-3a34-43cb-a43b-12eb1aeac1e6"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("63a04790-e4c1-4c6e-85ec-b73599ab0de5"));
            EpisodeDiagnosisPage = (ITTTabPage)AddControl(new Guid("50d33b9e-69d1-481e-868e-dc529da21f71"));
            EpisodeDiagnosis = (ITTGrid)AddControl(new Guid("8c45d5f9-f756-46e3-9904-717525972e0d"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("4580f9ec-20d9-416a-b542-4adcc063886d"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("00fee301-26b1-4533-af5d-47827b72d940"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("6313f44c-0aca-44eb-ba2c-944af138f755"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("984bbf7e-690a-45d2-9483-3dd3d947efb6"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("131abb80-085a-447d-8afc-0aa6f58ab038"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("335280cf-7f65-427d-88b5-d0a1b323949f"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("55cf2e6a-a8c5-4c11-be8d-900f43d7fec3"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("5bb07264-f31f-49ab-a42f-6b398fe72943"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("b1dd4050-563c-453e-a678-1718b0eeef12"));
            DiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("b9cab689-55e8-441d-8ad3-30363d229a85"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("24caff7c-123b-4fe8-b96e-87a60dc22429"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("6b46a64c-f689-4e8e-a942-aaa84927d181"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("07db9979-8690-4328-bb16-e47879d504cc"));
            TechnicianNote = (ITTTextBox)AddControl(new Guid("37b639a5-b55b-4b72-8157-1dae6e7abce7"));
            labelTechnicalDepartment = (ITTLabel)AddControl(new Guid("e1d7ac19-ba5d-4769-9c4e-117c64c512a4"));
            labelDefinitiontoTechnician = (ITTLabel)AddControl(new Guid("24d11225-37d7-454a-916c-b358e0711b06"));
            TechnicalDepartment = (ITTObjectListBox)AddControl(new Guid("03e7a568-0633-47ad-9768-c65ac6882538"));
            SubactionTab = (ITTTabControl)AddControl(new Guid("1767def7-6e54-4764-95fc-cf06ae1ec711"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("7e73fb79-9a4d-4c0b-9af7-123bd4cc4958"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("3269e824-be2c-4c1c-8e4f-06e88ff00d01"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("b037ab6a-1980-4f30-b46b-32b5938d5499"));
            Material = (ITTListBoxColumn)AddControl(new Guid("ef8ceb05-5f9b-438e-b063-1a392e41ca83"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("1e5c2544-f753-42a2-b5b9-396f62f45e38"));
            MaterialAmount = (ITTTextBoxColumn)AddControl(new Guid("8bfdaa55-5b73-4904-9394-5c1b67610cfa"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("379de2c3-cc30-4b50-81ea-efbec15b088e"));
            Note = (ITTTextBoxColumn)AddControl(new Guid("2ad4e3e1-1aed-4156-8b9f-96a513190e38"));
            DefinitiontoTechnician = (ITTTextBox)AddControl(new Guid("9fc49bab-ba06-41bd-b17c-ac8aec50591d"));
            DentalTreatmentDescription = (ITTTextBox)AddControl(new Guid("560f9e18-f536-41f9-b511-36ffac0a95fa"));
            Amount = (ITTTextBox)AddControl(new Guid("b23a53b1-1ada-4947-906e-48f3a2264ec0"));
            labelTechnicianNote = (ITTLabel)AddControl(new Guid("aabfa0e7-dddb-41da-83b6-8f255a2661a1"));
            labelDentalTreatmentDescription = (ITTLabel)AddControl(new Guid("f6f78e8c-b25d-48d7-99ea-2c43d440541c"));
            labelActionDate = (ITTLabel)AddControl(new Guid("a4a13fbf-3802-4444-85aa-fa5e68440ec7"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("c3edb62d-49fd-46a1-ab50-a4df40a4a822"));
            DentalRequestType = (ITTObjectListBox)AddControl(new Guid("a94ff9b0-7f36-48e7-ac90-16eb80330f43"));
            Emergency = (ITTCheckBox)AddControl(new Guid("8764d4cf-a406-4b86-8134-8f3d76b38a68"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("e744e617-90d2-4224-9dc1-5a429f0f8a3b"));
            labelAmount = (ITTLabel)AddControl(new Guid("99ef0fa2-f006-4d06-acea-24de85830121"));
            DentalPosition = (ITTEnumComboBox)AddControl(new Guid("6d8b88b8-407b-4e4a-9146-989fcecb8f33"));
            labelDentalRequestType = (ITTLabel)AddControl(new Guid("da437e83-1c13-4c31-96e8-d3434e78e507"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("33880abe-b35e-4e91-9af0-e9f6f5a0507b"));
            labelDepartment = (ITTLabel)AddControl(new Guid("8e8f879d-549d-4a6d-9a18-9be09700b458"));
            labelProcedure = (ITTLabel)AddControl(new Guid("d673e13a-aef0-4618-9251-9788e8c4dde8"));
            ProcedureDepartment = (ITTObjectListBox)AddControl(new Guid("755bb555-ae68-4f4c-a70f-ee254bd83d6a"));
            labelDentalPosition = (ITTLabel)AddControl(new Guid("2888b7a8-2ff1-433a-b0f7-7ba20d670b7d"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("90cb7a88-3f02-4ea3-914c-b1725eba9349"));
            labelToothNumber = (ITTLabel)AddControl(new Guid("2bb89839-21bc-4eb6-990d-3f97445bfcd2"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("55824f1c-8320-477a-b6d5-cf1a5cd496f0"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("2f4f5f3e-7cd4-4628-b7eb-c0dcc29f42eb"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("0c8eb745-d801-4e4e-8b52-7687010226c2"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("d3b66454-26e5-4e8f-9109-4266fc58436a"));
            btnNewTreatmentDischarge = (ITTButton)AddControl(new Guid("929f8c0c-40eb-449d-9ad4-42da36110049"));
            ttbuttonToothSchema = (ITTButton)AddControl(new Guid("77fb1b1b-0b20-4132-8e24-900c860860d5"));
            base.InitializeControls();
        }

        public DentalApprovalTreatmentTechnicianForm() : base("DENTALTREATMENTPROCEDURE", "DentalApprovalTreatmentTechnicianForm")
        {
        }

        protected DentalApprovalTreatmentTechnicianForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}