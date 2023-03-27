
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
    public partial class ManipulationProcedureForm : EpisodeActionForm
    {
    /// <summary>
    /// Tıbbi/Cerrahi Uygulama İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Manipulation _Manipulation
        {
            get { return (TTObjectClasses.Manipulation)_ttObject; }
        }

        protected ITTLabel ResponsibleUserLabel;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage ManiplasyonTab;
        protected ITTGrid GridManipulations;
        protected ITTDateTimePickerColumn ManipulationActionDate;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTCheckBoxColumn Emergency;
        protected ITTListBoxColumn Department;
        protected ITTTextBoxColumn Description;
        protected ITTListBoxColumn AyniFarkliKesi;
        protected ITTListBoxColumn DrAnesteziTescilNo;
        protected ITTEnumComboBoxColumn EuroScore;
        protected ITTListBoxColumn SagSol;
        protected ITTTextBoxColumn Birim;
        protected ITTTextBoxColumn Sonuc;
        protected ITTTextBoxColumn RaporTakipNo;
        protected ITTListBoxColumn OzelDurum;
        protected ITTButtonColumn CokluOzelDurum;
        protected ITTTabPage PersonnelTab;
        protected ITTGrid GridPersonnel;
        protected ITTListBoxColumn Personnel;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid GridTreatmentMaterials;
        protected ITTDateTimePickerColumn MaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn Notes;
        protected ITTTabPage AdditionalApplicationTab;
        protected ITTGrid GridAdditionalApplications;
        protected ITTDateTimePickerColumn SDateTime;
        protected ITTListBoxColumn AProcedureObject;
        protected ITTTextBoxColumn Result;
        protected ITTTextBoxColumn NurseNotes;
        protected ITTTabPage DirectPurchase;
        protected ITTGrid DirectPurchaseGrids;
        protected ITTListBoxColumn MaterialDirectPurchaseGrid;
        protected ITTTextBoxColumn AmountDirectPurchaseGrid;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox IDEpisode;
        protected ITTTextBox IDResource;
        protected ITTTextBox ReasonOfCancel;
        protected ITTLabel labelProtocolNo;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelProcessTime;
        protected ITTRichTextBoxControl PreInFormation;
        protected ITTRichTextBoxControl ProcedureRapor;
        protected ITTObjectListBox Technician;
        protected ITTLabel lblSorumluDoktor;
        protected ITTObjectListBox SorumluDoktor;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTLabel labelResponsiblePersonnel;
        protected ITTObjectListBox ResponsiblePersonnel;
        protected ITTRichTextBoxControl DoctorRapor;
        protected ITTGrid GridReturnReasons;
        protected ITTDateTimePickerColumn ReturnDate;
        protected ITTTextBoxColumn ReturnReason;
        protected ITTLabel labelReasonOfCancel;
        override protected void InitializeControls()
        {
            ResponsibleUserLabel = (ITTLabel)AddControl(new Guid("478680af-9a37-46ca-829b-9d528624d287"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("09fff22f-6aed-4648-a700-3942752eb2d8"));
            ManiplasyonTab = (ITTTabPage)AddControl(new Guid("1c1b8767-9f3c-468b-b193-f3d1c9caa205"));
            GridManipulations = (ITTGrid)AddControl(new Guid("9e0b4d29-1604-436f-89da-49e6f1f537eb"));
            ManipulationActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("f71ec586-a1d5-4ed8-ba8c-c0702d4bdacd"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("1723b211-370d-47d7-abc8-365629cfaff1"));
            Emergency = (ITTCheckBoxColumn)AddControl(new Guid("8cf25d2a-5f74-4735-9c57-f45409eced1b"));
            Department = (ITTListBoxColumn)AddControl(new Guid("9bd1c1ba-75d6-49c2-9b03-b2ce1dfd0649"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("143aa861-66b2-4ba2-82f2-045428106542"));
            AyniFarkliKesi = (ITTListBoxColumn)AddControl(new Guid("597f0c1c-4372-4700-9f49-037d3a0d699d"));
            DrAnesteziTescilNo = (ITTListBoxColumn)AddControl(new Guid("0b53a3c9-8645-4d73-9f2d-1e29500210f8"));
            EuroScore = (ITTEnumComboBoxColumn)AddControl(new Guid("53378c11-2a02-4958-b41f-b4fb45cb225e"));
            SagSol = (ITTListBoxColumn)AddControl(new Guid("c1325d42-f113-4e4e-8c9a-3e5bd4898d62"));
            Birim = (ITTTextBoxColumn)AddControl(new Guid("3495a252-abd0-4e38-96a5-d1b71b450f17"));
            Sonuc = (ITTTextBoxColumn)AddControl(new Guid("72ecb918-255a-4538-ad23-9a78c28da8aa"));
            RaporTakipNo = (ITTTextBoxColumn)AddControl(new Guid("0ac85827-43d4-4a0b-a2b8-0a93843ea8a2"));
            OzelDurum = (ITTListBoxColumn)AddControl(new Guid("08bc2e2f-0a74-4fb7-8850-61f21632a71a"));
            CokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("e3560c6d-a338-4e01-ba7c-32e7158ef828"));
            PersonnelTab = (ITTTabPage)AddControl(new Guid("b73c4386-b7cf-4d55-aaf3-783958c76d44"));
            GridPersonnel = (ITTGrid)AddControl(new Guid("086c3c31-e267-4cf2-963e-11571b3d329f"));
            Personnel = (ITTListBoxColumn)AddControl(new Guid("cc452c8a-8507-4624-b7bd-a3534392e48b"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("3a773368-a661-462c-9199-c49731abeb82"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("1d647a62-7043-4669-b688-f14847f963a3"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("f2238744-7793-455d-a4ab-4b6cf445227f"));
            Material = (ITTListBoxColumn)AddControl(new Guid("0e12ac09-77a6-4737-be06-2e774387a899"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("3415589e-31a8-452d-ad98-5994042c78b6"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("646d7c5e-01fd-4588-b40f-518112463e94"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("6a518759-5d44-43b0-be4a-ec1ce245785f"));
            Notes = (ITTTextBoxColumn)AddControl(new Guid("cc3aa70b-e99d-4a1f-ad9a-093dac3a5f36"));
            AdditionalApplicationTab = (ITTTabPage)AddControl(new Guid("10ba616e-f0f9-4ab3-ae7f-6c0cd2744cf3"));
            GridAdditionalApplications = (ITTGrid)AddControl(new Guid("da9c5932-8602-4f16-a179-7f54a968d810"));
            SDateTime = (ITTDateTimePickerColumn)AddControl(new Guid("d56e08a3-8c75-4c7b-8c8d-8f571df2ba33"));
            AProcedureObject = (ITTListBoxColumn)AddControl(new Guid("fa291334-9f6e-483b-bae2-dd4eb65cdb76"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("d2639ce5-c09d-4d7d-a596-c884fc3efad9"));
            NurseNotes = (ITTTextBoxColumn)AddControl(new Guid("af0e71dd-855c-4304-8c1b-abe6e27a0cb3"));
            DirectPurchase = (ITTTabPage)AddControl(new Guid("9a03c6aa-bbbe-4702-be92-93e325e7be59"));
            DirectPurchaseGrids = (ITTGrid)AddControl(new Guid("677781e3-60dd-460b-9b16-6f04423ad6fe"));
            MaterialDirectPurchaseGrid = (ITTListBoxColumn)AddControl(new Guid("3ea6a19f-e028-452b-88f0-37ad6cd87076"));
            AmountDirectPurchaseGrid = (ITTTextBoxColumn)AddControl(new Guid("fecc1747-0c69-4367-a6e6-30498ba145eb"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("c46f5ad5-de87-40e6-ad31-96c5f2c08427"));
            IDEpisode = (ITTTextBox)AddControl(new Guid("1b5c7828-4ebf-4aab-a18b-7577d0a303c9"));
            IDResource = (ITTTextBox)AddControl(new Guid("343aa0dc-2f8f-424b-b4de-abbd4ebd8568"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("3022cf71-096b-4041-8e2f-5ff287ae5262"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("d3ac827e-9815-4a04-8def-be5401e9e3bc"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("eda15ed2-81be-49f8-abd4-31a5efa910e6"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("b4ee3079-9254-47a5-b545-969ccc6d91c0"));
            PreInFormation = (ITTRichTextBoxControl)AddControl(new Guid("3c80203b-d26f-4b8e-80f4-e37452a3e284"));
            ProcedureRapor = (ITTRichTextBoxControl)AddControl(new Guid("113c1868-03dd-4d32-9e63-a093bd072167"));
            Technician = (ITTObjectListBox)AddControl(new Guid("f14a6f59-3e61-44c3-87df-53908df6b0ed"));
            lblSorumluDoktor = (ITTLabel)AddControl(new Guid("fba18b2d-f954-43b0-9b46-7e2b8be07498"));
            SorumluDoktor = (ITTObjectListBox)AddControl(new Guid("2479b10d-4b69-4139-9315-61187f8d81f4"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("eed4af49-f4d1-44fc-8efa-75430bf4522f"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("319cee1c-d363-4876-b39c-61683cb232f9"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("ef76a155-4bb9-4602-89b9-21ac9fa3a0cc"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("cf977805-e227-4557-bfb7-6ad6fd1dc849"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("e27c92ea-3fbe-49ff-a06d-12ceee828914"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("4ab1e0cd-6ae2-49a1-9783-5594d5b8773d"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("1a6da87a-618f-4b36-92f1-48c089467b54"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("a5164fa1-7623-4b16-be47-ab54b9a6bc57"));
            labelResponsiblePersonnel = (ITTLabel)AddControl(new Guid("dd1a2673-1bd4-4485-b726-fe092cfdd994"));
            ResponsiblePersonnel = (ITTObjectListBox)AddControl(new Guid("5f50662c-8f08-47c5-bdcf-fce795d2d16b"));
            DoctorRapor = (ITTRichTextBoxControl)AddControl(new Guid("ea0c5d3f-c285-46a4-8d96-011bea9994c8"));
            GridReturnReasons = (ITTGrid)AddControl(new Guid("8c227826-27a1-43df-8595-dfd0bfb76034"));
            ReturnDate = (ITTDateTimePickerColumn)AddControl(new Guid("9736c1da-79a0-410e-a08f-93029bfdac1e"));
            ReturnReason = (ITTTextBoxColumn)AddControl(new Guid("cfca1f80-5662-41be-952a-5958300782dd"));
            labelReasonOfCancel = (ITTLabel)AddControl(new Guid("5d84a943-1796-4d27-b459-4cdda0697298"));
            base.InitializeControls();
        }

        public ManipulationProcedureForm() : base("MANIPULATION", "ManipulationProcedureForm")
        {
        }

        protected ManipulationProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}