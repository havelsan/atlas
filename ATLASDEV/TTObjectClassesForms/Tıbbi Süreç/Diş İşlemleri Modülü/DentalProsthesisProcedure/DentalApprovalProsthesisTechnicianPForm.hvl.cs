
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
    /// Diş Protez İşlem Onayı
    /// </summary>
    public partial class DentalApprovalProsthesisTechnicianPForm : SubactionProcedureFlowableForm
    {
    /// <summary>
    /// Diş Protez Prosedür
    /// </summary>
        protected TTObjectClasses.DentalProsthesisProcedure _DentalProsthesisProcedure
        {
            get { return (TTObjectClasses.DentalProsthesisProcedure)_ttObject; }
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
        protected ITTTextBox ToothColor;
        protected ITTTextBox DentalProsthesisDescription;
        protected ITTTextBox Decision;
        protected ITTTextBox ProsthesisMeasurement;
        protected ITTLabel labelDentalProsthesisDescription;
        protected ITTLabel labelProcessEndDate;
        protected ITTLabel labelReasonOfReturn;
        protected ITTEnumComboBox DentalPosition;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel labelToothNumber;
        protected ITTLabel labelTechnicalDepartment;
        protected ITTObjectListBox Doctor;
        protected ITTLabel labelDefinitionToTechnician;
        protected ITTTabControl SubactionTab;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid TreatmentMaterials;
        protected ITTDateTimePickerColumn ActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn MaterialAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn Note;
        protected ITTTabPage UsedSets;
        protected ITTGrid UsedSet;
        protected ITTListBoxColumn ProsthesisUsedSet;
        protected ITTTextBoxColumn Definition;
        protected ITTTabPage RowMaterial;
        protected ITTGrid RowMaterials;
        protected ITTTextBoxColumn TakenRowMaterial;
        protected ITTTextBoxColumn ExpendRowMaterial;
        protected ITTTextBoxColumn LossRowMaterial;
        protected ITTTextBoxColumn ReturnedRowMaterial;
        protected ITTTextBoxColumn MaterialDefinition;
        protected ITTTextBox ReasonOfReturn;
        protected ITTTextBox DefinitionToTechnician;
        protected ITTTextBox Amount;
        protected ITTTextBox TechnicianNote;
        protected ITTLabel labelAmount;
        protected ITTObjectListBox Department;
        protected ITTObjectListBox TechnicalDepartment;
        protected ITTLabel labelDoctor;
        protected ITTLabel labelTechnicianNote;
        protected ITTCheckBox Emergency;
        protected ITTLabel labelToothColor;
        protected ITTLabel labelDecision;
        protected ITTDateTimePicker ProcessEndDate;
        protected ITTLabel labelProcedure;
        protected ITTLabel labelProsthesisMeasurement;
        protected ITTLabel labelDepartment;
        protected ITTLabel labelDentalPosition;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTButton btnNewTreatmentDischarge;
        protected ITTButton ttbutton1;
        override protected void InitializeControls()
        {
            ToothNumber = (ITTEnumComboBox)AddControl(new Guid("214f36aa-76ed-4e02-a496-7714d9d95e26"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("aac68c13-0ee4-46bc-8681-801ba85695f7"));
            GridDiagnosisEntry = (ITTTabPage)AddControl(new Guid("0bcfc9a1-465e-4677-b0a1-ffd0ea7bd717"));
            SecDiagnosis = (ITTGrid)AddControl(new Guid("a05449fc-89c2-401d-8213-2c1d0d690829"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("b1e67598-0a27-4f1e-b1ca-30a25c0c2211"));
            SecToothNum = (ITTEnumComboBoxColumn)AddControl(new Guid("137e86c4-2eb9-46e7-a4b0-a25129e2515d"));
            SecDentalPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("daf7459c-37be-4fe9-b390-59dad54c4f02"));
            SecToothSchema = (ITTButtonColumn)AddControl(new Guid("43c88fea-7c89-4782-bfc3-26b1f3d6bb8b"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("45380a65-bde7-4b05-867e-a7c1be38438d"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("109cdb5b-2f4b-4dae-b086-8237ee38abe2"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("f45bf036-6db1-4cb9-8c41-cb22a7b0ee5e"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("472ee2ce-f64f-429d-966f-86f273ad91c2"));
            EpisodeDiagnosisPage = (ITTTabPage)AddControl(new Guid("5941f70e-aaf9-4c0f-b7fb-3ca66c4ef9af"));
            EpisodeDiagnosis = (ITTGrid)AddControl(new Guid("41eeb997-44c0-4c59-9dcf-549caf0be922"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("07c09eb0-3ee3-4124-854f-1ab121a500fd"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("e622c630-eb6b-47c0-82aa-9beda9e8e5bb"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("4d01ac4d-b345-4658-b622-030ed90fc2a1"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("74f68ba2-4241-49da-adda-406cfd83e41b"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("38bc3bea-131e-469f-b2b7-c2127502a4c7"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("7b28d2f7-94fa-494c-92c4-ed372d8ca1b3"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("beb2c41d-4823-43f4-9a82-1e13ff6404dd"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("17b34f2a-cb06-4944-a7ad-97721d625771"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("58ac8be1-7b87-496a-9cbd-55614b445013"));
            DiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("88bc6511-77be-466b-ad81-bcd36e469373"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("d39468bd-2d4f-4527-8fd3-f3930007b487"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("58d99fe5-6a80-4a18-a0f4-cee14e99af9f"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("425575d5-b162-46dd-a5c9-41aa7ffcff8d"));
            ToothColor = (ITTTextBox)AddControl(new Guid("62ae0c65-abf5-454f-8b0a-968cf24e648d"));
            DentalProsthesisDescription = (ITTTextBox)AddControl(new Guid("c353b838-b76c-4646-94ce-d7ee158aa8fd"));
            Decision = (ITTTextBox)AddControl(new Guid("0ba9afde-ea36-4785-91f0-986e3346bb19"));
            ProsthesisMeasurement = (ITTTextBox)AddControl(new Guid("0060ccd8-c479-4462-9281-0ce179087a33"));
            labelDentalProsthesisDescription = (ITTLabel)AddControl(new Guid("c95fdbe5-2b72-4866-b572-cbef7b124c60"));
            labelProcessEndDate = (ITTLabel)AddControl(new Guid("b21d7c69-464a-4084-8ef7-84704289065d"));
            labelReasonOfReturn = (ITTLabel)AddControl(new Guid("167ca126-a803-4a66-9c0e-839e214152b1"));
            DentalPosition = (ITTEnumComboBox)AddControl(new Guid("cd0562a4-2b58-4ec3-8926-600f827964b2"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("c339a25f-e981-4f61-a864-88cb1bb9fcc2"));
            labelToothNumber = (ITTLabel)AddControl(new Guid("1c0ca028-b418-4324-89ef-afb625491f6c"));
            labelTechnicalDepartment = (ITTLabel)AddControl(new Guid("677e013c-284d-4e3a-bacd-6e8fd49fa7d7"));
            Doctor = (ITTObjectListBox)AddControl(new Guid("9fad520d-9a3b-4cd2-b63d-def38c04edbb"));
            labelDefinitionToTechnician = (ITTLabel)AddControl(new Guid("3a5e78ae-1bff-4623-83ec-30258f95c2c9"));
            SubactionTab = (ITTTabControl)AddControl(new Guid("08287231-5dc5-4eef-9530-4c2614e34675"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("8b63bbb6-e242-48c4-b47e-bd98b23ecb77"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("82ada745-da7b-482f-a7ca-13a0dfeb497d"));
            ActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("bbc8955a-5f26-4485-a83d-9342f07f64c0"));
            Material = (ITTListBoxColumn)AddControl(new Guid("ed475640-0ea0-4651-a4a1-3315d5a3d11a"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("7526e76f-3ee5-470d-88ce-33fcc574d1f3"));
            MaterialAmount = (ITTTextBoxColumn)AddControl(new Guid("0b205f3c-4a85-423e-b49b-1d31b0c32b84"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("e2fee825-cd27-4dbd-abe2-9427f75137d1"));
            Note = (ITTTextBoxColumn)AddControl(new Guid("f164ac61-6a85-462f-916a-bc1b2b6d9652"));
            UsedSets = (ITTTabPage)AddControl(new Guid("a76937be-7fac-4a9f-83ba-d34d4f1f8e46"));
            UsedSet = (ITTGrid)AddControl(new Guid("16cb27c1-699f-4c51-a6f9-1300ea4b978d"));
            ProsthesisUsedSet = (ITTListBoxColumn)AddControl(new Guid("38692b7a-f47a-4d8c-b8da-5446115e48aa"));
            Definition = (ITTTextBoxColumn)AddControl(new Guid("da17ea4c-5daa-4bcf-8c07-459e8ee93c0f"));
            RowMaterial = (ITTTabPage)AddControl(new Guid("dd75ee04-c6e1-49b7-8afc-c9b32f041172"));
            RowMaterials = (ITTGrid)AddControl(new Guid("c2e03fe2-c840-4476-b883-9d7e23e450c3"));
            TakenRowMaterial = (ITTTextBoxColumn)AddControl(new Guid("432aa5d4-bcdf-4ea5-bb39-f6b4b54b2983"));
            ExpendRowMaterial = (ITTTextBoxColumn)AddControl(new Guid("c0bda6ac-7fa1-48de-89c8-9d2d7c59db63"));
            LossRowMaterial = (ITTTextBoxColumn)AddControl(new Guid("550fbbec-b766-4442-bb07-9084c232c7d6"));
            ReturnedRowMaterial = (ITTTextBoxColumn)AddControl(new Guid("2ad20900-6cf6-45dc-bb2d-bfa5b2096997"));
            MaterialDefinition = (ITTTextBoxColumn)AddControl(new Guid("676b2601-0f4e-4b27-8b8c-14e274ccbe65"));
            ReasonOfReturn = (ITTTextBox)AddControl(new Guid("ed293b84-430a-4a7c-b54e-7ddc25002cc5"));
            DefinitionToTechnician = (ITTTextBox)AddControl(new Guid("516b059f-070a-462d-bb6b-63702245b820"));
            Amount = (ITTTextBox)AddControl(new Guid("6661d632-1f63-41f2-8800-85da1c7501d4"));
            TechnicianNote = (ITTTextBox)AddControl(new Guid("2780d4b3-6fc9-4b35-a1b3-325e0d4b0d69"));
            labelAmount = (ITTLabel)AddControl(new Guid("93e22ffd-3d6a-41f0-a57c-eac6d9fbf2e7"));
            Department = (ITTObjectListBox)AddControl(new Guid("d1fe5be7-5531-4c20-aab5-b86c0ef38c31"));
            TechnicalDepartment = (ITTObjectListBox)AddControl(new Guid("d2426234-135a-441c-8c25-1522f76e9fb6"));
            labelDoctor = (ITTLabel)AddControl(new Guid("ac4471fd-70d1-4b18-900c-935ac5262cfe"));
            labelTechnicianNote = (ITTLabel)AddControl(new Guid("afa99eee-2be9-4663-b6a7-fd07fcaf47ad"));
            Emergency = (ITTCheckBox)AddControl(new Guid("9fe7c432-76d7-48bd-87b1-fe1544a63e0b"));
            labelToothColor = (ITTLabel)AddControl(new Guid("2b55f6e9-e119-40a3-b219-64cffb5fb78d"));
            labelDecision = (ITTLabel)AddControl(new Guid("12b2681f-375b-4f48-865d-18f357fe98e9"));
            ProcessEndDate = (ITTDateTimePicker)AddControl(new Guid("fa4dc52d-9864-4df5-9150-43befc7dd940"));
            labelProcedure = (ITTLabel)AddControl(new Guid("ab2945b4-d6bd-458e-878e-298e7df3203e"));
            labelProsthesisMeasurement = (ITTLabel)AddControl(new Guid("05296ff3-56a8-4e1c-9ea9-febc56f099d5"));
            labelDepartment = (ITTLabel)AddControl(new Guid("d6d52ded-73bc-485a-ab7b-fe6e4f95bfb5"));
            labelDentalPosition = (ITTLabel)AddControl(new Guid("b0e94382-f802-4530-9683-c93c39df600c"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("4b35f99d-6db7-4826-8aec-fdf8ed6ac148"));
            btnNewTreatmentDischarge = (ITTButton)AddControl(new Guid("86993216-af19-4a98-88d8-b3f1b03dbbce"));
            ttbutton1 = (ITTButton)AddControl(new Guid("a650f1ea-7e93-46a6-950d-b8cc381cc7dc"));
            base.InitializeControls();
        }

        public DentalApprovalProsthesisTechnicianPForm() : base("DENTALPROSTHESISPROCEDURE", "DentalApprovalProsthesisTechnicianPForm")
        {
        }

        protected DentalApprovalProsthesisTechnicianPForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}