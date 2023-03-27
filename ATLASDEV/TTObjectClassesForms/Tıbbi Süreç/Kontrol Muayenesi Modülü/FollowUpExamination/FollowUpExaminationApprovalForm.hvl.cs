
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
    public partial class FollowUpExaminationApprovalForm : EpisodeActionForm
    {
    /// <summary>
    /// Hasta Kontrol Muayenesi İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.FollowUpExamination _FollowUpExamination
        {
            get { return (TTObjectClasses.FollowUpExamination)_ttObject; }
        }

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
        protected ITTPictureBoxControl Image;
        protected ITTTabPage TreatmentMaterials;
        protected ITTGrid GridTreatmentMaterials;
        protected ITTDateTimePickerColumn mActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn kodsuzMalzemeFiyati;
        protected ITTTextBoxColumn mAmount;
        protected ITTListBoxColumn malzemeTuru;
        protected ITTListBoxColumn malzemeOzelDurum;
        protected ITTButtonColumn malzemeCokluOzelDurum;
        protected ITTTextBoxColumn kdv;
        protected ITTTextBoxColumn malzemeBrans;
        protected ITTDateTimePickerColumn malzemeSatinAlisTarihi;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn mNotes;
        protected ITTTabPage NursingOrders;
        protected ITTGrid GridNursingOrders;
        protected ITTDateTimePickerColumn OrderActionDate;
        protected ITTListBoxColumn OrderProcedureObject;
        protected ITTTextBoxColumn PeriodStartTime;
        protected ITTTabPage NursingOrderDetails;
        protected ITTGrid GridNursingOrderDetails;
        protected ITTDateTimePickerColumn OrderDetailActionDate;
        protected ITTListBoxColumn OrderDetailProcedureObject;
        protected ITTTextBoxColumn NursingApplicationNurseNotes;
        protected ITTTextBoxColumn NursingApplicationResult;
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
        protected ITTListDefComboBoxColumn taniOzelDurum;
        protected ITTButtonColumn taniCokluOzelDurum;
        protected ITTTextBox ProtocolNo;
        protected ITTCheckBox IsTreatmentMaterialEmpty;
        protected ITTLabel labelMasterResource;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTObjectListBox MasterResource;
        protected ITTLabel labelProcedureSpeciality;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ProcessDate;
        protected ITTLabel ttlabel2;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel LabelDateTime;
        override protected void InitializeControls()
        {
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("3ccbc9ad-72c8-4dcd-8d89-bd0ecb2312db"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("9135d394-d3f2-4a46-a927-77de725d4cfe"));
            TabPatientInfo = (ITTTabControl)AddControl(new Guid("19d43b11-fcae-4102-ba13-0733ccbb6bbe"));
            PatientInfo = (ITTTabPage)AddControl(new Guid("e1cc02ab-f8c1-485e-b8df-1b2e54b39da2"));
            PatientHistory = (ITTRichTextBoxControl)AddControl(new Guid("ef41686d-af80-4b99-bf9d-90398bd45163"));
            PatientFolder = (ITTRichTextBoxControl)AddControl(new Guid("54a65554-7433-481c-9e85-f917e6949cec"));
            PhysicalExamination = (ITTRichTextBoxControl)AddControl(new Guid("7821f1e2-5008-4489-a2a3-53a4bc5591a9"));
            Complaint = (ITTRichTextBoxControl)AddControl(new Guid("693de4ee-0e1d-4fc7-ae05-63e9747b0bb9"));
            AdditionalApplications = (ITTTabPage)AddControl(new Guid("ae1023ca-baa7-4a91-a784-fee4f17becd1"));
            GridAdditionalApplications = (ITTGrid)AddControl(new Guid("6ae73c1e-c683-4365-ba72-1bae54006f9a"));
            aProcessDate = (ITTDateTimePickerColumn)AddControl(new Guid("86cdb73a-36da-4e2d-a172-1287b4cecffb"));
            AProcedureObject = (ITTListBoxColumn)AddControl(new Guid("ffa6e060-ad1d-4713-aec0-55c8f49cb228"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("b03b786c-832c-4400-b5d1-c97de253f98d"));
            NurseNotes = (ITTTextBoxColumn)AddControl(new Guid("f660bfec-042e-4cc3-b736-c95a0a5c9c6d"));
            PatientImage = (ITTTabPage)AddControl(new Guid("93501316-e6a0-4e83-a4f9-0be0e17ec2e4"));
            Image = (ITTPictureBoxControl)AddControl(new Guid("620abad1-11c1-4864-903b-e53fc026dbe0"));
            TreatmentMaterials = (ITTTabPage)AddControl(new Guid("86709ae0-bea5-473f-a37b-b45b3d950d3c"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("35e0029d-7be4-4d31-ac6e-7045a144b00c"));
            mActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("1bbfb248-0f0a-4a04-a93e-d05aecd3d183"));
            Material = (ITTListBoxColumn)AddControl(new Guid("041ab3e9-0657-4b95-b8c2-a9ea951dd575"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("b09b8885-e6fb-4aa5-bbf6-e7bd97fcf275"));
            kodsuzMalzemeFiyati = (ITTTextBoxColumn)AddControl(new Guid("8fcc6b70-8573-4598-8bd5-91cc45d30409"));
            mAmount = (ITTTextBoxColumn)AddControl(new Guid("41479bd8-f114-4bbb-bcba-2679901c4e74"));
            malzemeTuru = (ITTListBoxColumn)AddControl(new Guid("b3f79884-3b2f-4e4a-b558-ec53ac50bc43"));
            malzemeOzelDurum = (ITTListBoxColumn)AddControl(new Guid("ef242c00-8610-416b-a41e-4a10631b1e10"));
            malzemeCokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("13734e4b-d3e8-4637-8fd5-07fdb0897180"));
            kdv = (ITTTextBoxColumn)AddControl(new Guid("b40787cc-6448-491d-989a-1841528df94f"));
            malzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("28dd9ea8-bd0a-4acf-88e0-6979ddcbc68f"));
            malzemeSatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("b2440305-2bff-4087-88b2-8241049e8ea9"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("0d34e158-e944-4368-a0b1-2db1a4ebc0d0"));
            mNotes = (ITTTextBoxColumn)AddControl(new Guid("36327dcd-0726-44ff-bc81-0066c8cda9e7"));
            NursingOrders = (ITTTabPage)AddControl(new Guid("38d24be2-daa9-49e3-9b0b-b949db5ff93a"));
            GridNursingOrders = (ITTGrid)AddControl(new Guid("8531b692-3793-4424-85b5-7042195f6624"));
            OrderActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("5446f75a-f0e0-4ac7-8cdf-d9985d0bf46a"));
            OrderProcedureObject = (ITTListBoxColumn)AddControl(new Guid("5c33c4d7-ac2c-4ab1-9a2c-85812cf29efd"));
            PeriodStartTime = (ITTTextBoxColumn)AddControl(new Guid("a49e4cea-2b7e-48bf-aed4-7179cf21d849"));
            NursingOrderDetails = (ITTTabPage)AddControl(new Guid("8c71948c-515c-40c5-83bd-e163b8dc13e8"));
            GridNursingOrderDetails = (ITTGrid)AddControl(new Guid("bfe3c6cb-57c5-4c83-8ebc-25007527bfd5"));
            OrderDetailActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("f634a296-b854-42b3-b6e9-a6cf47d0be24"));
            OrderDetailProcedureObject = (ITTListBoxColumn)AddControl(new Guid("468229cc-5231-4730-9d30-bb3169ebdaa7"));
            NursingApplicationNurseNotes = (ITTTextBoxColumn)AddControl(new Guid("15f787f9-4b42-4a4c-a3e1-ee6f377d0e2f"));
            NursingApplicationResult = (ITTTextBoxColumn)AddControl(new Guid("b58768f6-c174-466d-bd3b-f6decc7adf01"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("f7ad421b-7a9b-4a9f-9577-7a331aa2e001"));
            DiagnosisEntry = (ITTTabPage)AddControl(new Guid("578c27e1-478d-4340-ad9c-ef64119c4b3a"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("737bbc11-139d-4e61-ab1e-ce4f3bdd168e"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("5d0d928e-9d3f-4b8c-b414-fbaffaac7862"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("9ddbf4b5-bfbe-4aec-9004-83f5f7f7620e"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("998fdc14-8950-4bc2-8239-fc302370caaa"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("63c208f1-fc26-462b-b9e6-e20002a4dc25"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("587fd272-9f5d-470d-a199-e5ecd5ff6a7d"));
            EpisodeDiagnosis = (ITTTabPage)AddControl(new Guid("f992e076-4e04-404f-b28c-7cec4edcb292"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("72ea95fe-0be7-4862-a999-2927d86625f7"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("4d5914d0-8dc6-47d9-9c4f-7071a2a5d330"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("3bd0a5ab-ee83-4928-bd06-1470712e29dd"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("2f387a05-0e1f-4b2c-81c0-573e404b3695"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("489f5db9-a5ce-48fd-afca-526949c3b911"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("a113ad9a-9b00-4a0e-b2b8-fb3ad87382dc"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("f15c5597-154a-466b-b9b7-243747cb9ce7"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("b8f815a1-e4ce-44e4-931e-0d6289ea9be3"));
            taniOzelDurum = (ITTListDefComboBoxColumn)AddControl(new Guid("e679f321-63e4-4568-91d4-aeab96a6e1c8"));
            taniCokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("49f4d4d9-4970-4779-a89c-036aa9db2f77"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("c5f32dc1-3244-4cf4-954d-e5df11f26f83"));
            IsTreatmentMaterialEmpty = (ITTCheckBox)AddControl(new Guid("56d35910-459b-42f7-9714-c146078f2c5f"));
            labelMasterResource = (ITTLabel)AddControl(new Guid("da7f629d-2c97-4246-92bc-25c6dcab094f"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("ec7a4b7c-4a95-40d3-8c28-3cf0075addad"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("7c748b70-68ee-427c-b93d-741e2d5760c5"));
            labelProcedureSpeciality = (ITTLabel)AddControl(new Guid("bfaa78c7-b1b5-4e27-b9fa-12050f9dab7c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("44e0a174-d8c7-43fe-a453-33026397e4e2"));
            ProcessDate = (ITTDateTimePicker)AddControl(new Guid("95287122-3950-41be-91e8-72641f8d4928"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("cb5c16a6-8867-415c-bbdc-51e036034f35"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("1be5f929-a027-4a62-a696-3f2daf54ba25"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("11cf2ff3-603b-4e76-9ae0-c2952d5b4ff3"));
            base.InitializeControls();
        }

        public FollowUpExaminationApprovalForm() : base("FOLLOWUPEXAMINATION", "FollowUpExaminationApprovalForm")
        {
        }

        protected FollowUpExaminationApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}