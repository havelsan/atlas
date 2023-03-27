
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
    public partial class DentalTreatmentTechnicianPForm : SubactionProcedureFlowableForm
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
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTObjectListBox DentalRequestType;
        protected ITTLabel labelTechnicalDepartment;
        protected ITTCheckBox Emergency;
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
        protected ITTTextBox Amount;
        protected ITTTextBox DentalTreatmentDescription;
        protected ITTLabel labelTechnicianNote;
        protected ITTLabel ttlabel11;
        protected ITTLabel labelAmount;
        protected ITTEnumComboBox DentalPosition;
        protected ITTLabel labelDentalRequestType;
        protected ITTLabel labelDentalTreatmentDescription;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelDepartment;
        protected ITTLabel labelProcedure;
        protected ITTObjectListBox ProcedureDepartment;
        protected ITTLabel labelDentalPosition;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel labelToothNumber;
        protected ITTLabel LabelDateTime;
        protected ITTDateTimePicker RequestDate;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTButton ttbutton1;
        override protected void InitializeControls()
        {
            ToothNumber = (ITTEnumComboBox)AddControl(new Guid("e18fe3f0-bcf8-4d3a-bea5-72aac1e6ac28"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("a98d942c-2c0c-4847-9842-5f493f599982"));
            GridDiagnosisEntry = (ITTTabPage)AddControl(new Guid("c04bc585-18e0-4f81-98c1-69801d7d6bbe"));
            SecDiagnosis = (ITTGrid)AddControl(new Guid("141be085-d898-493d-ba1c-55833d341051"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("df073c16-8c1d-4fe7-86c3-1614c9cae58d"));
            SecToothNum = (ITTEnumComboBoxColumn)AddControl(new Guid("8f58401b-9bc2-4722-a2b5-4d7b0ea41955"));
            SecDentalPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("ad565e0e-e979-46ee-9dca-68b83de02b18"));
            SecToothSchema = (ITTButtonColumn)AddControl(new Guid("54d1177d-e445-4c03-9959-30105b1971f8"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("92cfd6da-5998-4e2a-a316-a0f02743e6cf"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("7d249e33-f013-458f-9f61-267cfb8a5c6d"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("c9b1a853-c969-45cf-b7f8-870714a9fc31"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("e5be5a65-26c5-4c86-8cee-0599073b534b"));
            EpisodeDiagnosisPage = (ITTTabPage)AddControl(new Guid("18b20ec8-4f55-4b8b-ac96-7a1694d8696c"));
            EpisodeDiagnosis = (ITTGrid)AddControl(new Guid("a6117c63-8e4a-4fc0-996e-250151d59fa1"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("7964157f-2fc6-4360-969f-593da077c892"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("e99b2f6f-2064-41a9-91cb-417880990505"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("0a194db0-9b91-419c-9317-5ea14f0a66bb"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("72a24a71-fca6-419b-bc56-1b194f82500b"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("d838a038-faba-4578-a239-6ba036c0c258"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("5de774aa-67cd-4c09-ae3f-437792d01c2d"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("5498e27f-6b44-4aa8-9a1f-29c44b2ac553"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("9fa62896-eb76-46ac-9890-ea2cd4547d7c"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("0afa9e9f-f3f1-4992-b0d6-96ab8da397da"));
            DiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("10c774d3-c077-4577-8e50-c28961a737d2"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("2a0e1f15-b647-49bf-80b3-cc9436b783d0"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("c34d2d7a-1416-4ceb-be36-4cd9a7a77786"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("12e5f486-f516-4a2c-b45f-7f60c1097cf4"));
            TechnicianNote = (ITTTextBox)AddControl(new Guid("3db6e1f6-bfcb-4c6f-b41c-2205a9376a29"));
            labelActionDate = (ITTLabel)AddControl(new Guid("2057729e-22e7-404d-92c6-5183454469ff"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("f211e3d4-9ecf-4fd9-9c8b-a08e139202d6"));
            DentalRequestType = (ITTObjectListBox)AddControl(new Guid("88d33c94-333a-4852-bced-05024c733598"));
            labelTechnicalDepartment = (ITTLabel)AddControl(new Guid("0b88ad8b-c32c-44b3-8f78-0abf306b7f4b"));
            Emergency = (ITTCheckBox)AddControl(new Guid("7d6a6479-b083-43ce-8960-15aa02fd73d2"));
            labelDefinitiontoTechnician = (ITTLabel)AddControl(new Guid("7ebc3889-6152-4c06-8027-1e9f6718e51d"));
            TechnicalDepartment = (ITTObjectListBox)AddControl(new Guid("271f907b-b708-4ea3-9170-20e6726fc7f0"));
            SubactionTab = (ITTTabControl)AddControl(new Guid("d1202712-9fde-4b69-8a42-4797b2913be7"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("eb6a71c0-4b2d-44f6-b737-be9e1a3fe032"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("fa620417-da48-41cf-9250-51f9af6b63be"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("b932d41d-1c0c-4200-a6c0-e27143182e91"));
            Material = (ITTListBoxColumn)AddControl(new Guid("c03f6e8c-2b7a-410e-9cdc-114b287b8412"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("8b9020aa-4d8e-4042-bd44-216401ec0024"));
            MaterialAmount = (ITTTextBoxColumn)AddControl(new Guid("ed753f13-6649-47d9-aa5d-4a9eb281dd1c"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("87453cda-affe-4ed4-86f8-514e1b38b7d8"));
            Note = (ITTTextBoxColumn)AddControl(new Guid("b9936097-960d-4dae-a777-418ee5f2030d"));
            DefinitiontoTechnician = (ITTTextBox)AddControl(new Guid("ac0186fb-eeec-4047-8dbd-8bb5d2395c42"));
            Amount = (ITTTextBox)AddControl(new Guid("067d886a-d0ec-4f51-aea4-ad39afabf14d"));
            DentalTreatmentDescription = (ITTTextBox)AddControl(new Guid("7319976d-2b38-45a4-a843-ffbff20eafa7"));
            labelTechnicianNote = (ITTLabel)AddControl(new Guid("783f6631-d37f-4b27-b9ce-62071c23e928"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("8be8aa64-ae9e-4786-a5cc-64854b661333"));
            labelAmount = (ITTLabel)AddControl(new Guid("c2d8bb70-3fbd-4eac-a9a7-65b329de6d8c"));
            DentalPosition = (ITTEnumComboBox)AddControl(new Guid("e7c7b31c-5a0b-4128-9b42-68627961a414"));
            labelDentalRequestType = (ITTLabel)AddControl(new Guid("54b443ff-112b-4284-b197-6e1b82fe2f0e"));
            labelDentalTreatmentDescription = (ITTLabel)AddControl(new Guid("0163c3d0-224f-43e5-a6d9-7eee56f1a02e"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("cb46e136-b1eb-486f-8a50-aae890418f70"));
            labelDepartment = (ITTLabel)AddControl(new Guid("2ccf0b80-9281-4f84-b2f9-d41f7bdd7c6d"));
            labelProcedure = (ITTLabel)AddControl(new Guid("5d5effa6-4b57-4dc3-b241-e307ee43d492"));
            ProcedureDepartment = (ITTObjectListBox)AddControl(new Guid("f807b5b3-9efb-4cfe-b0d6-e5e71883b168"));
            labelDentalPosition = (ITTLabel)AddControl(new Guid("f0105138-119d-4c53-b7d0-ef8a1ab3fab7"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("b2209b63-5f33-4091-9b65-f4547b751acb"));
            labelToothNumber = (ITTLabel)AddControl(new Guid("b3ab72f7-a431-436e-b6d4-fc1437f40fd9"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("d4a657ed-e7bd-42ac-b8ef-91fc168c88a9"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("830be980-12ed-4a58-89da-db71993416a1"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("01ea0732-4391-45a6-8b1f-185c019e0f85"));
            ttbutton1 = (ITTButton)AddControl(new Guid("587aa741-9ce4-42fb-affa-12d0a3c9a43f"));
            base.InitializeControls();
        }

        public DentalTreatmentTechnicianPForm() : base("DENTALTREATMENTPROCEDURE", "DentalTreatmentTechnicianPForm")
        {
        }

        protected DentalTreatmentTechnicianPForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}