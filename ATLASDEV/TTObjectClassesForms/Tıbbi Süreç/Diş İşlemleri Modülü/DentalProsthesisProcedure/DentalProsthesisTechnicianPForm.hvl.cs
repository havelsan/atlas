
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
    /// Diş Protez İşlemleri
    /// </summary>
    public partial class DentalProsthesisTechnicianPForm : SubactionProcedureFlowableForm
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
        protected ITTButton ttbutton1;
        override protected void InitializeControls()
        {
            ToothNumber = (ITTEnumComboBox)AddControl(new Guid("644a4a60-5f75-401f-8551-97e7c353b5ca"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("0a43edb5-d954-4434-b0b8-59635f197849"));
            GridDiagnosisEntry = (ITTTabPage)AddControl(new Guid("814a5374-cecb-4584-bc22-72c0de6a2c24"));
            SecDiagnosis = (ITTGrid)AddControl(new Guid("9ec33dc1-64de-48c3-b339-e7748f338a29"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("691cbbf9-c120-499f-bc98-d2ce87a6302b"));
            SecToothNum = (ITTEnumComboBoxColumn)AddControl(new Guid("27f452a7-71cb-4fc0-8e4d-24fa20e2774f"));
            SecDentalPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("0846e8aa-ff94-473f-8cda-8f2c4ae41b22"));
            SecToothSchema = (ITTButtonColumn)AddControl(new Guid("2faa8d5e-92bd-4db5-9da0-3e182634f760"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("62d4df30-b7da-491e-9337-16ca2a9fb027"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("b9bb2952-019b-4f48-acf6-240c566ff566"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("de6bd9ef-06f4-4353-9ff9-a70385f72688"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("b83a2e74-d4b2-4897-8e72-96b9e699b000"));
            EpisodeDiagnosisPage = (ITTTabPage)AddControl(new Guid("ecdbcde2-c80b-4798-a778-558ba042ea9f"));
            EpisodeDiagnosis = (ITTGrid)AddControl(new Guid("e93b9a03-b446-44df-b34e-047945929c25"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("57068360-1651-49a6-8287-1a3917dec6f6"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("ae50404b-dea7-4c74-8364-cd143681cdd4"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("dbc3a91e-5030-489b-9c2d-23e810bea6a3"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("28fc08b6-5b73-4823-ab6b-bbac0487459c"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("0af65b58-5ef9-4b11-aab6-65b8333af913"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("1aee2333-6e19-4232-8cbe-fdc6864be115"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("53fcb6fb-f618-4659-be51-e8d0e1088d2e"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("23608edb-edc8-4cee-8a73-7b02751322d4"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("78e3572a-97b2-4a94-a8b7-a1d6fb82d98d"));
            DiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("eb4791bd-75c0-42da-95ec-9481a8337a72"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("06d5d1b2-0284-45c0-b28a-d0e0d458fb94"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("bf8b3bed-4c3b-4b2e-bacc-aef1211ab6c7"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("bf3b628c-d3d8-4392-a898-40cb00c4b612"));
            ToothColor = (ITTTextBox)AddControl(new Guid("5380376c-4370-4903-a519-132e313c5ab5"));
            DentalProsthesisDescription = (ITTTextBox)AddControl(new Guid("b426fb07-6dcb-4041-ad35-1548ce4f976c"));
            Decision = (ITTTextBox)AddControl(new Guid("aab4645a-e854-4c83-8fde-363f8efb2936"));
            ProsthesisMeasurement = (ITTTextBox)AddControl(new Guid("4f6dd295-fe51-4490-8363-3fed97119e51"));
            labelDentalProsthesisDescription = (ITTLabel)AddControl(new Guid("5088aff8-4b6f-493a-ac08-0733c6571708"));
            labelProcessEndDate = (ITTLabel)AddControl(new Guid("d42369f7-a69b-4875-8c07-0de1b17e433b"));
            DentalPosition = (ITTEnumComboBox)AddControl(new Guid("4e4b7ca7-d5c9-4ea5-9355-15b7f0af445a"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("38c067a4-44b3-4b39-aadc-1fe26a470d05"));
            labelToothNumber = (ITTLabel)AddControl(new Guid("7b5eabc3-ab6b-4612-b682-28ac2395d804"));
            labelTechnicalDepartment = (ITTLabel)AddControl(new Guid("739a72f8-67b7-42f5-8323-28ae05c28f6e"));
            Doctor = (ITTObjectListBox)AddControl(new Guid("4304c3a3-973b-4239-9931-30965009bd26"));
            labelDefinitionToTechnician = (ITTLabel)AddControl(new Guid("63589a2e-e618-4267-9917-6e84a739a5d0"));
            SubactionTab = (ITTTabControl)AddControl(new Guid("0da344d2-950b-4eb6-b665-6eaa300cbab4"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("6ea71bf2-cbe6-4513-85c0-991de686026c"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("325b2afd-abda-486e-8fa6-319b59033cf3"));
            ActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("f37fd7ba-55f8-44b1-a058-d6c560584135"));
            Material = (ITTListBoxColumn)AddControl(new Guid("86e4afe8-dc06-4321-a918-750bed5310a3"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("c5039718-97c7-4ea9-8f58-b74d7f0fab93"));
            MaterialAmount = (ITTTextBoxColumn)AddControl(new Guid("fbb3bde7-08c8-4503-bed6-c47a6a946c53"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("7c1cad0d-633d-47cd-a946-c7f9f221bca9"));
            Note = (ITTTextBoxColumn)AddControl(new Guid("468ba9ff-c195-405d-ab8e-059b5a1b7356"));
            UsedSets = (ITTTabPage)AddControl(new Guid("4e19d343-e9f9-49a2-958d-c8e78bad9c93"));
            UsedSet = (ITTGrid)AddControl(new Guid("72fe41fa-fb7d-471e-af50-ccdc539f430a"));
            ProsthesisUsedSet = (ITTListBoxColumn)AddControl(new Guid("ac127d03-7888-4f37-a96a-214f0e2fb5c2"));
            Definition = (ITTTextBoxColumn)AddControl(new Guid("816ee90c-3f8c-448a-87e0-3b73d313e58e"));
            RowMaterial = (ITTTabPage)AddControl(new Guid("95dec3a2-b717-4906-a3ae-e02a416e3f51"));
            RowMaterials = (ITTGrid)AddControl(new Guid("80dca7e8-1d5a-4396-bd48-15860de058b8"));
            TakenRowMaterial = (ITTTextBoxColumn)AddControl(new Guid("6bf741c5-8095-46b8-880c-491e7e81f196"));
            ExpendRowMaterial = (ITTTextBoxColumn)AddControl(new Guid("de7bb9b3-417b-4b89-97ea-298aeb7b0434"));
            LossRowMaterial = (ITTTextBoxColumn)AddControl(new Guid("332b6c9d-86d9-4af7-ac32-01b39c90a34b"));
            ReturnedRowMaterial = (ITTTextBoxColumn)AddControl(new Guid("71b005d0-38b0-4fd7-871c-51795819d68a"));
            MaterialDefinition = (ITTTextBoxColumn)AddControl(new Guid("130081eb-d2f4-405d-94a6-e8a094f70bce"));
            DefinitionToTechnician = (ITTTextBox)AddControl(new Guid("2a95687f-c705-4408-be4d-8a33f326abf5"));
            Amount = (ITTTextBox)AddControl(new Guid("74661828-0022-4f54-9289-a8df88f70213"));
            TechnicianNote = (ITTTextBox)AddControl(new Guid("7c67130d-4a06-4dbf-801f-d2a7cf885b38"));
            labelAmount = (ITTLabel)AddControl(new Guid("73a56ad0-d953-4c1c-9596-7010c0f918f6"));
            Department = (ITTObjectListBox)AddControl(new Guid("585a477c-6038-4c04-bbc5-7203b433b03e"));
            TechnicalDepartment = (ITTObjectListBox)AddControl(new Guid("a59a4ce2-cd8d-4300-894d-7a11d4876b8c"));
            labelDoctor = (ITTLabel)AddControl(new Guid("2275d0b4-af65-4b66-8976-84c4af15407a"));
            labelTechnicianNote = (ITTLabel)AddControl(new Guid("564405ce-a3ff-4dcb-bca5-8b508d3ee0b1"));
            Emergency = (ITTCheckBox)AddControl(new Guid("04481366-5565-438f-866d-968f0cbcae10"));
            labelToothColor = (ITTLabel)AddControl(new Guid("361b84c9-ce39-451b-b75a-9ea7f9bdcf26"));
            labelDecision = (ITTLabel)AddControl(new Guid("98e31ee9-7c00-4062-94ee-b2aee26c9ef7"));
            ProcessEndDate = (ITTDateTimePicker)AddControl(new Guid("ee8f7c8e-13ae-483e-9ade-c9477d1f8d7b"));
            labelProcedure = (ITTLabel)AddControl(new Guid("44d03d89-1ae3-44b3-843a-df7e8ea48c8a"));
            labelProsthesisMeasurement = (ITTLabel)AddControl(new Guid("38d13b0a-9c6a-48e7-a365-e97274c4d132"));
            labelDepartment = (ITTLabel)AddControl(new Guid("7c80b63c-5e97-4a05-b96e-f914af4cbf4d"));
            labelDentalPosition = (ITTLabel)AddControl(new Guid("dbf90755-fdb0-4cfd-9292-fc000fb45010"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("94a02ca6-c596-4115-ab6e-6190bb318c5d"));
            ttbutton1 = (ITTButton)AddControl(new Guid("d82f8a64-c77c-4647-8978-c7007d65ceed"));
            base.InitializeControls();
        }

        public DentalProsthesisTechnicianPForm() : base("DENTALPROSTHESISPROCEDURE", "DentalProsthesisTechnicianPForm")
        {
        }

        protected DentalProsthesisTechnicianPForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}