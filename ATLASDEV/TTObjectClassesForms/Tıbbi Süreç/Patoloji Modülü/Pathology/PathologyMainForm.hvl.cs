
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
    public partial class PathologyMainForm : EpisodeActionForm
    {
    /// <summary>
    /// Patoloji
    /// </summary>
        protected TTObjectClasses.Pathology _Pathology
        {
            get { return (TTObjectClasses.Pathology)_ttObject; }
        }

        protected ITTLabel labelPathologyArchiveNo;
        protected ITTTextBox PathologyArchiveNo;
        protected ITTTextBox TechnicianNote;
        protected ITTTextBox AcceptionNotePathologyRequest;
        protected ITTTextBox PhoneNumberResUser;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelApproveDate;
        protected ITTDateTimePicker ApproveDate;
        protected ITTLabel labelReportDate;
        protected ITTDateTimePicker ReportDate;
        protected ITTLabel labelTechnicianNote;
        protected ITTLabel labelAcceptionNotePathologyRequest;
        protected ITTLabel labelAcceptionDatePathologyRequest;
        protected ITTDateTimePicker AcceptionDatePathologyRequest;
        protected ITTLabel labelPhysicalExaminationEpisode;
        protected ITTRichTextBoxControl PhysicalExaminationEpisode;
        protected ITTLabel labelComplaintEpisode;
        protected ITTRichTextBoxControl ComplaintEpisode;
        protected ITTLabel labelPhoneNumberResUser;
        protected ITTLabel labelRequestDoctorPathologyRequest;
        protected ITTObjectListBox RequestDoctorPathologyRequest;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage Materials;
        protected ITTGrid PathologyMaterial;
        protected ITTTextBoxColumn MaterialNumberPathologyMaterial;
        protected ITTDateTimePickerColumn DateOfSampleTakenPathologyMaterial;
        protected ITTListBoxColumn YerlesimYeriPathologyMaterial;
        protected ITTListBoxColumn AlindigiDokununTemelOzelligiPathologyMaterial;
        protected ITTListBoxColumn NumuneAlinmaSekliPathologyMaterial;
        protected ITTListBoxColumn PatolojiPreparatiDurumuPathologyMaterial;
        protected ITTListBoxColumn MorfolojiKoduPathologyMaterial;
        protected ITTTextBoxColumn ClinicalFindingsPathologyMaterial;
        protected ITTTextBoxColumn DescriptionPathologyMaterial;
        protected ITTRichTextBoxControlColumn MacroscopyPathologyMaterial;
        protected ITTRichTextBoxControlColumn MicroscopyPathologyMaterial;
        protected ITTRichTextBoxControlColumn NotePathologyMaterial;
        protected ITTTabPage Consumables;
        protected ITTGrid TreatmentMaterials;
        protected ITTDateTimePickerColumn ActionDateBaseTreatmentMaterial;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn AmountBaseTreatmentMaterial;
        protected ITTTextBoxColumn UBBCodeBaseTreatmentMaterial;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBox MatPrtNoString;
        protected ITTLabel labelAssistantDoctor;
        protected ITTObjectListBox AssistantDoctor;
        protected ITTLabel labelMatPrtNoString;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelSpecialDoctor;
        protected ITTObjectListBox SpecialDoctor;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage EpisodeDiagnosisTab;
        protected ITTGrid DiagnosisDiagnosisGrid;
        protected ITTListBoxColumn DiagnoseDiagnosisGrid;
        protected ITTEnumComboBoxColumn DiagnosisTypeDiagnosisGrid;
        override protected void InitializeControls()
        {
            labelPathologyArchiveNo = (ITTLabel)AddControl(new Guid("2bb61184-ede3-4ca8-b67d-b3efcc642f3c"));
            PathologyArchiveNo = (ITTTextBox)AddControl(new Guid("9fc95a6f-324a-4d94-a1a1-57edacd438f0"));
            TechnicianNote = (ITTTextBox)AddControl(new Guid("3818791f-0195-402c-b156-88fba9fc5c58"));
            AcceptionNotePathologyRequest = (ITTTextBox)AddControl(new Guid("d81302f7-2e06-45df-ac74-5f3d5607f438"));
            PhoneNumberResUser = (ITTTextBox)AddControl(new Guid("4747fe84-6467-4425-87b5-f93ce8b3c8eb"));
            labelActionDate = (ITTLabel)AddControl(new Guid("59c174dd-c681-4079-bf84-116215d050d2"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("ef6f9b65-62c6-4921-8683-c79c28c195e6"));
            labelApproveDate = (ITTLabel)AddControl(new Guid("895e458b-b43a-4f94-a400-4c72a86dad1a"));
            ApproveDate = (ITTDateTimePicker)AddControl(new Guid("408d2648-4888-497b-94cc-000276ee2869"));
            labelReportDate = (ITTLabel)AddControl(new Guid("5fb48e92-7264-4c39-959a-bb7d625a0da6"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("c2345994-7da0-4f36-86df-dc3f3a480750"));
            labelTechnicianNote = (ITTLabel)AddControl(new Guid("71ce2188-09d1-454e-9d92-90c88e216725"));
            labelAcceptionNotePathologyRequest = (ITTLabel)AddControl(new Guid("af14d126-35a4-4e08-b2fc-e64dc30d6a74"));
            labelAcceptionDatePathologyRequest = (ITTLabel)AddControl(new Guid("48f790e8-c4a1-4c25-afb9-691168335d87"));
            AcceptionDatePathologyRequest = (ITTDateTimePicker)AddControl(new Guid("37ca8a06-cca3-412f-acb7-2721a2fa5013"));
            labelPhysicalExaminationEpisode = (ITTLabel)AddControl(new Guid("8cb7d5be-6c71-4f49-988a-5d243970cd1b"));
            PhysicalExaminationEpisode = (ITTRichTextBoxControl)AddControl(new Guid("bff8a171-2c5b-46e2-b17d-49949b856c5c"));
            labelComplaintEpisode = (ITTLabel)AddControl(new Guid("4f71c764-fbf5-414f-af50-2363a8c95f41"));
            ComplaintEpisode = (ITTRichTextBoxControl)AddControl(new Guid("a2acbbf3-66ef-4364-95e8-4cd29cd232ee"));
            labelPhoneNumberResUser = (ITTLabel)AddControl(new Guid("7262f04b-cc38-404a-9bcc-94885f513ffe"));
            labelRequestDoctorPathologyRequest = (ITTLabel)AddControl(new Guid("9367b727-cd42-46ad-96dc-e52b7d0a4857"));
            RequestDoctorPathologyRequest = (ITTObjectListBox)AddControl(new Guid("a2f342b9-552f-4562-a980-aac1f6c6343d"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("19d1777b-03ac-41de-bf38-ed7fe1cb0231"));
            Materials = (ITTTabPage)AddControl(new Guid("14392ea8-a13f-4541-bf9a-1e3b7e18b3d3"));
            PathologyMaterial = (ITTGrid)AddControl(new Guid("85176255-eb58-4fc5-b615-e3e9617e1efb"));
            MaterialNumberPathologyMaterial = (ITTTextBoxColumn)AddControl(new Guid("975c9778-3b77-4fc6-b148-648ffb761c74"));
            DateOfSampleTakenPathologyMaterial = (ITTDateTimePickerColumn)AddControl(new Guid("3d3fd1bf-1c47-4b88-8e55-9e0054887fa0"));
            YerlesimYeriPathologyMaterial = (ITTListBoxColumn)AddControl(new Guid("e2328d80-c574-4f50-87c8-8951722ada54"));
            AlindigiDokununTemelOzelligiPathologyMaterial = (ITTListBoxColumn)AddControl(new Guid("f4b6b61f-55cc-4cbd-ae15-6d99155bbc52"));
            NumuneAlinmaSekliPathologyMaterial = (ITTListBoxColumn)AddControl(new Guid("fa2586e7-1683-4437-9d32-41643685e556"));
            PatolojiPreparatiDurumuPathologyMaterial = (ITTListBoxColumn)AddControl(new Guid("367719ea-7c44-4444-af8e-c10ff5a2b891"));
            MorfolojiKoduPathologyMaterial = (ITTListBoxColumn)AddControl(new Guid("aa5cc695-3267-494f-b915-ceb4496403b3"));
            ClinicalFindingsPathologyMaterial = (ITTTextBoxColumn)AddControl(new Guid("fe655196-df94-4b2b-a1b5-22bbd158a08f"));
            DescriptionPathologyMaterial = (ITTTextBoxColumn)AddControl(new Guid("48dc1650-b2cd-4eef-ad1c-1f251e417cf9"));
            MacroscopyPathologyMaterial = (ITTRichTextBoxControlColumn)AddControl(new Guid("b07b2f40-fe1c-49ff-9f53-fe13935ad818"));
            MicroscopyPathologyMaterial = (ITTRichTextBoxControlColumn)AddControl(new Guid("5ac7de5f-3e96-45fe-8155-986e745455e4"));
            NotePathologyMaterial = (ITTRichTextBoxControlColumn)AddControl(new Guid("b79c16f4-53e0-43f4-8ae5-e321a8910b63"));
            Consumables = (ITTTabPage)AddControl(new Guid("ab557796-b627-47c3-b4ff-34edbd8af1bc"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("fbaedf89-feaf-4079-ba77-1fa3fb14c499"));
            ActionDateBaseTreatmentMaterial = (ITTDateTimePickerColumn)AddControl(new Guid("46384661-f61d-49fd-91f3-28033a69fecd"));
            Material = (ITTListBoxColumn)AddControl(new Guid("a17500e5-b965-4442-ba23-d65cebda6b56"));
            AmountBaseTreatmentMaterial = (ITTTextBoxColumn)AddControl(new Guid("a69e5059-4996-45ae-b0ba-fa1c9d9dcb3a"));
            UBBCodeBaseTreatmentMaterial = (ITTTextBoxColumn)AddControl(new Guid("ea2496b0-9ebf-4250-9530-7e3be4e26d41"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("825fc9df-9c89-46f0-9524-c988c1636574"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("917b6f07-f4e2-446b-960d-209ba29b5ce4"));
            MatPrtNoString = (ITTTextBox)AddControl(new Guid("3d3370ad-6652-4d0b-9d55-0b3895269365"));
            labelAssistantDoctor = (ITTLabel)AddControl(new Guid("a945e891-3075-489d-91d6-8f946a3c1c02"));
            AssistantDoctor = (ITTObjectListBox)AddControl(new Guid("214e8807-c29f-4d6e-8c24-81663ad63816"));
            labelMatPrtNoString = (ITTLabel)AddControl(new Guid("13f2e296-0305-49ad-9acf-d11fc7699244"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("7e36505a-dae4-40e2-8594-1568a1d2f5fd"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("b0f1af44-1003-4b5e-ac98-58a582f193f5"));
            labelSpecialDoctor = (ITTLabel)AddControl(new Guid("91acb796-0261-4242-bdfa-2cf04edf07a1"));
            SpecialDoctor = (ITTObjectListBox)AddControl(new Guid("a8757cb6-ff7a-49ab-b145-d3e9866f0aec"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("a8ddb215-2fae-49a1-93b7-1443086f716d"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("bdd9b40c-2cd6-44a0-9ac7-a95580de042b"));
            DiagnosisDiagnosisGrid = (ITTGrid)AddControl(new Guid("12508876-4106-445b-9ba2-eb69779c7fd4"));
            DiagnoseDiagnosisGrid = (ITTListBoxColumn)AddControl(new Guid("bfddca17-bdc4-4889-9381-32d90a8df845"));
            DiagnosisTypeDiagnosisGrid = (ITTEnumComboBoxColumn)AddControl(new Guid("af05b581-6b0f-4561-a8d9-22fa0e27bbe6"));
            base.InitializeControls();
        }

        public PathologyMainForm() : base("PATHOLOGY", "PathologyMainForm")
        {
        }

        protected PathologyMainForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}