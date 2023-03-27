
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
    /// Tıbbi/Cerrahi Uygulamaları
    /// </summary>
    public partial class ManipulationDoctorForm : EpisodeActionForm
    {
    /// <summary>
    /// Tıbbi/Cerrahi Uygulama İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Manipulation _Manipulation
        {
            get { return (TTObjectClasses.Manipulation)_ttObject; }
        }

        protected ITTButton btnOpenFromPdf;
        protected ITTLabel labelResponsiblePersonnel;
        protected ITTObjectListBox ResponsiblePersonnel;
        protected ITTLabel labelOzelDurum;
        protected ITTObjectListBox ManipulationOzelDurum;
        protected ITTLabel lblSorumluDoktor;
        protected ITTObjectListBox TTListBoxSorumluDoktor;
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
        protected ITTTabControl TabSubaction;
        protected ITTTabPage ManipulationTab;
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
        protected ITTListBoxColumn ttlistboxcolumn1;
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
        protected ITTTextBoxColumn UseAmount;
        protected ITTTextBoxColumn UnitType;
        protected ITTTextBoxColumn UBBCode;
        protected ITTTextBoxColumn Notes;
        protected ITTTabPage AdditionalApplicationsTab;
        protected ITTGrid GridAdditionalApplications;
        protected ITTDateTimePickerColumn SDateTime;
        protected ITTListBoxColumn AProcedureObject;
        protected ITTTextBoxColumn Result;
        protected ITTTextBoxColumn NurseNotes;
        protected ITTTabPage DirectPurchase;
        protected ITTGrid SurgeryDirectPurchaseGrids;
        protected ITTListBoxColumn DPADetailFirmPriceOffer;
        protected ITTTextBoxColumn txtBarcode;
        protected ITTTextBoxColumn txtKesinlesenMiktar;
        protected ITTTabPage CodelessDirectPurchase;
        protected ITTGrid CodelessMaterialDirectPurchaseGrids;
        protected ITTListBoxColumn DPADetailFirmPriceOfferCodelessMaterialDirectPurchaseGrid;
        protected ITTTextBoxColumn txtKesinMiktar;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProtocolNo;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelProcessTime;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        override protected void InitializeControls()
        {
            btnOpenFromPdf = (ITTButton)AddControl(new Guid("a43ab556-4a3a-4d6d-958f-5bc602ab4115"));
            labelResponsiblePersonnel = (ITTLabel)AddControl(new Guid("64cb41c8-28e5-40c5-8646-22a077a85d16"));
            ResponsiblePersonnel = (ITTObjectListBox)AddControl(new Guid("433cab1d-3089-4683-84f2-e68922a9ffe7"));
            labelOzelDurum = (ITTLabel)AddControl(new Guid("1764e19f-3f18-4c49-b343-0d0bb29d1af2"));
            ManipulationOzelDurum = (ITTObjectListBox)AddControl(new Guid("c4a50dfd-bc43-4716-a0ca-e385baac16e6"));
            lblSorumluDoktor = (ITTLabel)AddControl(new Guid("4c4731bc-8fcd-4659-a507-ed6b22476915"));
            TTListBoxSorumluDoktor = (ITTObjectListBox)AddControl(new Guid("4999432a-67dc-4e40-ac3e-be7b25bb452b"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("1e96f25d-dfa1-4e28-9d98-a018d201b902"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("aac8b50b-a4a8-4e02-9154-e52a00f0cc69"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("556b579b-768c-4e00-a848-5603ed0537ef"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("3f5af376-5358-4329-81b7-015751c37304"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("1bac5d72-340c-4eaa-8c26-6cdec7423d2b"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("60afb963-4437-4cd8-84a2-a13024324ad5"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("1b627c76-48da-4daa-a3ab-66f4a892a496"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("faae0b1b-7c1f-4d81-a188-3f56f0901a32"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("1ad218e3-4947-4f6f-8bcb-410316662474"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("27484653-210b-4e7b-a068-8aab9726dc64"));
            DiagnosisEntryTab = (ITTTabPage)AddControl(new Guid("8ecc4a94-cf70-4031-a32c-cb697bb5dbff"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("c8090232-482b-46af-8795-0aa62abe9b74"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("41a75273-ed19-40a4-93cb-a4e582d73d4d"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("f51c0737-e028-478e-bc75-9f5f43b94368"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("a5772f95-9f00-49b4-853e-6b04acea3a7b"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("44c8b06c-88be-4d7d-b75c-23e2631769bb"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("d31bcc22-6b85-4672-803e-fb934e8e830a"));
            Rapor = (ITTRichTextBoxControl)AddControl(new Guid("81c1187a-92f7-4760-b1d9-6df11406305f"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("ec517a0c-3d54-4b9d-af69-7039771a2b4f"));
            ManipulationTab = (ITTTabPage)AddControl(new Guid("4b6a65ce-9659-4ad5-9b8d-952ee2bcfe1e"));
            GridManipulations = (ITTGrid)AddControl(new Guid("e659c498-babc-42a3-8ebc-19e8e59c3322"));
            ManipulationActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("d1a9881e-3650-4870-846f-d02334806b83"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("54534649-3dfc-41c6-948d-9ff9f4497b74"));
            Emergency = (ITTCheckBoxColumn)AddControl(new Guid("52162517-9e4c-4133-a3d8-9ecc50407cda"));
            Department = (ITTListBoxColumn)AddControl(new Guid("9078d7c0-0723-4c87-9efd-9798bd8eb845"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("1c2d5274-4b73-443c-b101-392bc65bfbd9"));
            AyniFarkliKesi = (ITTListBoxColumn)AddControl(new Guid("c88b4a2d-c89d-4388-be3e-0d7c5d2cf18f"));
            DrAnesteziTescilNo = (ITTListBoxColumn)AddControl(new Guid("4ef1bf3b-5352-4c4b-8ea4-b26d5d0ade1c"));
            EuroScore = (ITTEnumComboBoxColumn)AddControl(new Guid("98f4d34c-f9ab-4e65-b337-b0b28c309040"));
            SagSol = (ITTListBoxColumn)AddControl(new Guid("5fb0a977-6df6-4962-a87a-3a382d76e47a"));
            Birim = (ITTTextBoxColumn)AddControl(new Guid("e2f9c222-37e9-4f11-a3c1-be7900234c8b"));
            Sonuc = (ITTTextBoxColumn)AddControl(new Guid("e9443696-bb0d-43be-99c4-0099faadd9f1"));
            RaporTakipNo = (ITTTextBoxColumn)AddControl(new Guid("30f066cb-9d8e-4a5e-abab-ca2a6b08c13c"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("ed43df28-85eb-4ab1-b72c-9040e34a1268"));
            CokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("6b50270b-113a-46b0-8fdb-a6af5ccd4244"));
            PersonnelTab = (ITTTabPage)AddControl(new Guid("b2d30cb1-3810-412b-85fe-f7e8ca98cc93"));
            GridPersonnel = (ITTGrid)AddControl(new Guid("b91719c7-79a2-45f0-9d09-6085e14e0b37"));
            Personnel = (ITTListBoxColumn)AddControl(new Guid("9d45bf1a-f2c4-4325-b05c-6d681f059111"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("8d19e415-aa80-4c05-a4d4-d910fbb1ce5f"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("af558682-8a3d-445c-a5cb-8f2acaa3ad0c"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("0bec0dbf-512d-4769-b9be-de149fbfc0c0"));
            Material = (ITTListBoxColumn)AddControl(new Guid("b053f162-6a36-4788-beaf-18b57dfeff87"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("b334bd7c-b14d-4874-b464-3395946ce06b"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("de960703-1070-4a2a-93f0-dca9e1832ddc"));
            UseAmount = (ITTTextBoxColumn)AddControl(new Guid("8880c7b0-35b5-4ee3-ab40-006a7f9e58d5"));
            UnitType = (ITTTextBoxColumn)AddControl(new Guid("03bd57f2-f3ae-4e9c-be90-7612548b4576"));
            UBBCode = (ITTTextBoxColumn)AddControl(new Guid("b4465ef9-c3c3-432a-bac4-aa11d395a67a"));
            Notes = (ITTTextBoxColumn)AddControl(new Guid("d51b1f80-dde8-4a8f-b0b1-5c02c0f06b7e"));
            AdditionalApplicationsTab = (ITTTabPage)AddControl(new Guid("009261bc-4a9e-4354-aff7-973d8916336a"));
            GridAdditionalApplications = (ITTGrid)AddControl(new Guid("606f2bea-5564-43ea-826e-6873e8104a72"));
            SDateTime = (ITTDateTimePickerColumn)AddControl(new Guid("7454a030-769e-4d1c-bd8a-d4de1aa3bd41"));
            AProcedureObject = (ITTListBoxColumn)AddControl(new Guid("fdc9b51f-4c9f-48e4-bcc5-0dea667e0fdf"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("be9dd037-ea22-46ba-8c0c-9469d8451089"));
            NurseNotes = (ITTTextBoxColumn)AddControl(new Guid("e0352190-703b-4703-a152-2fa0c933d241"));
            DirectPurchase = (ITTTabPage)AddControl(new Guid("ed1618b6-049d-43f6-a466-8c4243e3c974"));
            SurgeryDirectPurchaseGrids = (ITTGrid)AddControl(new Guid("d5a28f99-6335-4d24-9f17-ca4699ed37ce"));
            DPADetailFirmPriceOffer = (ITTListBoxColumn)AddControl(new Guid("79490f68-03c7-447f-94db-7046f6a7f3c0"));
            txtBarcode = (ITTTextBoxColumn)AddControl(new Guid("7e4a080f-560d-4e4f-b5e8-e357675441ff"));
            txtKesinlesenMiktar = (ITTTextBoxColumn)AddControl(new Guid("ab3ff1ad-9db9-48be-8a04-6b5f27e74928"));
            CodelessDirectPurchase = (ITTTabPage)AddControl(new Guid("1f60f5eb-22fc-464b-9bef-93bd853e1627"));
            CodelessMaterialDirectPurchaseGrids = (ITTGrid)AddControl(new Guid("3d455462-a286-49ef-b928-9d972838264e"));
            DPADetailFirmPriceOfferCodelessMaterialDirectPurchaseGrid = (ITTListBoxColumn)AddControl(new Guid("1d179eec-a614-4864-ace6-643d1212767a"));
            txtKesinMiktar = (ITTTextBoxColumn)AddControl(new Guid("f3bf17c8-2c7a-469f-be73-3f4ddd7852b1"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("feb6ab01-1b88-4c1e-9d2c-a5fde503021f"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("bd43315d-89ef-4089-bcf1-8414bc1f7a6c"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("862ffe6f-44ca-4ee9-9206-9c9329fa370f"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("205a4f88-b55f-4377-8d36-a4dabf5530d1"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("eb2d2f47-24da-40e3-bf8e-1bd048041ef4"));
            base.InitializeControls();
        }

        public ManipulationDoctorForm() : base("MANIPULATION", "ManipulationDoctorForm")
        {
        }

        protected ManipulationDoctorForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}