
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
    /// Kontrol Muayenesi
    /// </summary>
    public partial class FollowUpExaminationForm : EpisodeActionForm
    {
    /// <summary>
    /// Hasta Kontrol Muayenesi İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.FollowUpExamination _FollowUpExamination
        {
            get { return (TTObjectClasses.FollowUpExamination)_ttObject; }
        }

        protected ITTObjectListBox ResUser;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProtocolNo;
        protected ITTDateTimePicker ProcessDate;
        protected ITTLabel labelProcessTime;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTTabControl TabPatientInfo;
        protected ITTTabPage PatientInfo;
        protected ITTRichTextBoxControl PatientHistory;
        protected ITTRichTextBoxControl PatientFolder;
        protected ITTRichTextBoxControl PhysicalExamination;
        protected ITTRichTextBoxControl Complaint;
        protected ITTTabPage AdditionalApplications;
        protected ITTGrid GridAdditionalApplications;
        protected ITTDateTimePickerColumn aProcessDate;
        protected ITTListBoxColumn AProcedureObject;
        protected ITTTextBoxColumn Result;
        protected ITTTextBoxColumn NurseNotes;
        protected ITTTabPage PatientImage;
        protected ITTPictureBoxControl ttpictureboxcontrol1;
        protected ITTTabPage TreatmentMaterials;
        protected ITTGrid GridTreatmentMaterials;
        protected ITTDateTimePickerColumn mActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn mAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn mNotes;
        protected ITTTabPage NursingOrders;
        protected ITTGrid GridNursingOrders;
        protected ITTDateTimePickerColumn OrderActionDate;
        protected ITTListBoxColumn OrderProcedureObject;
        protected ITTTextBoxColumn PeriodStartTime;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage DiagnosisEntry;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTListBoxColumn Diagnose;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTTabPage EpisodeDiagnosis;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTCheckBox IsTreatmentMaterialEmpty;
        protected ITTLabel labelMasterResource;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTObjectListBox MasterResource;
        protected ITTLabel labelProcedureSpeciality;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel LabelDateTime;
        protected ITTLabel ttlabeldrAnestezitescilNo;
        override protected void InitializeControls()
        {
            ResUser = (ITTObjectListBox)AddControl(new Guid("d9367e40-7f16-4d06-bcb2-e0221c91719d"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("ce69ba33-d4cb-4ccf-ab03-f89f36c2e060"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("78e1c0e3-91e0-4f9b-ba68-342b48a61c2e"));
            ProcessDate = (ITTDateTimePicker)AddControl(new Guid("3477d04a-78a1-4444-b34a-85927f3697db"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("2cc1bda5-68f8-4be4-8e77-082180251b35"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("049f9e50-da98-4db0-b297-151366b4f987"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("1e54713b-6ae3-400f-b20f-de24ab193850"));
            TabPatientInfo = (ITTTabControl)AddControl(new Guid("40e0fead-f6ef-4c07-a3b2-2532aecd6dda"));
            PatientInfo = (ITTTabPage)AddControl(new Guid("5cd47a86-0c10-42a6-9333-11ca9bd5db8e"));
            PatientHistory = (ITTRichTextBoxControl)AddControl(new Guid("44326029-26f6-4f79-96e7-8ba6c9846af1"));
            PatientFolder = (ITTRichTextBoxControl)AddControl(new Guid("64df47d0-6117-4519-9d26-887a17a85d2d"));
            PhysicalExamination = (ITTRichTextBoxControl)AddControl(new Guid("8e0969fe-9f26-475b-90cf-1d7c16593d39"));
            Complaint = (ITTRichTextBoxControl)AddControl(new Guid("791e3c11-4d80-4d82-96b9-58b0782d93fe"));
            AdditionalApplications = (ITTTabPage)AddControl(new Guid("5f6cc6dd-a987-4aff-a0ed-d3eed49a8f51"));
            GridAdditionalApplications = (ITTGrid)AddControl(new Guid("0b100af5-d5b7-4be9-8225-7ddf4e121d6d"));
            aProcessDate = (ITTDateTimePickerColumn)AddControl(new Guid("b22dc261-fa9e-4087-b39a-ff43a6a9928a"));
            AProcedureObject = (ITTListBoxColumn)AddControl(new Guid("c6bd2d0e-ccad-4918-b715-59527cfffd00"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("8f1481fe-c6c1-40c0-a602-1c1b02fc3181"));
            NurseNotes = (ITTTextBoxColumn)AddControl(new Guid("0869ac7f-9556-4591-afaa-1e0dd1786268"));
            PatientImage = (ITTTabPage)AddControl(new Guid("aaaad9ec-b696-48e4-bdef-fb9218afe239"));
            ttpictureboxcontrol1 = (ITTPictureBoxControl)AddControl(new Guid("27d205fa-c8cb-4093-9037-b4cc742fe25f"));
            TreatmentMaterials = (ITTTabPage)AddControl(new Guid("3159ea6c-c774-4070-952a-0737b7e7730d"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("7cd473d3-8327-4238-b6ce-b39fbd362e49"));
            mActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("29ada78e-35ab-40c5-a5cf-ceb1081bbc76"));
            Material = (ITTListBoxColumn)AddControl(new Guid("5b7f0881-ff24-4422-a90a-c14e14df7fcd"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("b3615050-fded-49c2-8547-d7edaf9f9bff"));
            mAmount = (ITTTextBoxColumn)AddControl(new Guid("5c840c4e-1f37-435d-84c8-5d9efd138ad8"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("758d565a-1106-4e1e-a3a1-9fcbacb1cc05"));
            mNotes = (ITTTextBoxColumn)AddControl(new Guid("8f199edd-4956-4ab6-b2ed-435222b6831f"));
            NursingOrders = (ITTTabPage)AddControl(new Guid("ed6c7f0f-65e0-40c0-8e08-2fdb7127ea71"));
            GridNursingOrders = (ITTGrid)AddControl(new Guid("dbb1a6ed-d541-494e-b207-0d6b8ccf1eb6"));
            OrderActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("b2df8365-7419-4b9a-868c-70fb60cc1bae"));
            OrderProcedureObject = (ITTListBoxColumn)AddControl(new Guid("8dcd4fe6-a3ea-488e-838c-59e793274c2b"));
            PeriodStartTime = (ITTTextBoxColumn)AddControl(new Guid("dda945fb-1153-4860-bb26-c9a6a5e14d09"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("859d01aa-df13-4334-8f5b-fe524a96feda"));
            DiagnosisEntry = (ITTTabPage)AddControl(new Guid("f4acfa48-10ed-4376-af5e-3f1a1a2da6b6"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("a617097d-5c93-4910-89d8-dc5f18856784"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("54c61521-896f-4370-aac0-245b379520ca"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("3679aafa-2d3e-46ce-b10c-cb5f67d866de"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("97a1d5e2-2b9e-478c-b167-5d8d652f797d"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("8fbe31f9-0e36-4b0a-bb9d-faa1cb73e023"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("f7cf85a2-d4af-4669-ad1e-fb773c0003ae"));
            EpisodeDiagnosis = (ITTTabPage)AddControl(new Guid("ba272026-0805-439f-878c-90aa74e43f97"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("91235e0e-1e0c-4b77-9c37-23c1e2fde04a"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("4d38cea4-a432-4341-9b57-c93a17a9057b"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("7478dc8c-1cf8-4b25-ba39-2a52e49b7deb"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("b368123d-375f-4930-990d-397ff7814069"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("d6729ea1-04c9-440c-a019-c547aabf4cf5"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("f7895d76-f90c-45ba-8f12-3260baa99311"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("49e995a1-49a5-4439-8a8e-24b5d36b4fc9"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("f40412d9-6595-48e3-a5bc-44599df29ed0"));
            IsTreatmentMaterialEmpty = (ITTCheckBox)AddControl(new Guid("8a89b382-6e95-4e44-8603-72afd248a7df"));
            labelMasterResource = (ITTLabel)AddControl(new Guid("3cd391bc-1c57-4ea6-8a93-088fc1135863"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("8fc8314d-f592-4f61-80e1-917106bae322"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("bb9c5e9a-93d5-4b78-84a5-a834569853ad"));
            labelProcedureSpeciality = (ITTLabel)AddControl(new Guid("f1899b2e-8d9a-400f-809c-0df512db2332"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("9a313b51-0bff-4772-a461-11da4a914c68"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("bc3a2ea0-5149-4cda-8fc7-c6f3e13860fc"));
            ttlabeldrAnestezitescilNo = (ITTLabel)AddControl(new Guid("1312e138-2a55-4b58-9d53-b6d719d6439f"));
            base.InitializeControls();
        }

        public FollowUpExaminationForm() : base("FOLLOWUPEXAMINATION", "FollowUpExaminationForm")
        {
        }

        protected FollowUpExaminationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}