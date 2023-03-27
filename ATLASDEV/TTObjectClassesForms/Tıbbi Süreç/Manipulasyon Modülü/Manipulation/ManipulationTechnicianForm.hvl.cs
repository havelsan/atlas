
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
    public partial class ManipulationTechnicianForm : EpisodeActionForm
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
        protected ITTTextBoxColumn UBBCode;
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
        protected ITTLabel labelProtocolNo;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelProcessTime;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTRichTextBoxControl ttrichtextboxcontrol3;
        protected ITTGrid ttgrid2;
        protected ITTTextBoxColumn ReturnReason;
        protected ITTObjectListBox Technician;
        protected ITTLabel lblSorumluDoktor;
        protected ITTObjectListBox TTListBoxSorumluDoktor;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        override protected void InitializeControls()
        {
            ResponsibleUserLabel = (ITTLabel)AddControl(new Guid("a38b7fa3-4b13-4986-ace5-fb5ed1ec5926"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("9babc637-ae58-4ac2-b602-0291aafa92a8"));
            ManiplasyonTab = (ITTTabPage)AddControl(new Guid("0ced5712-73d4-4df4-ad3b-279119176835"));
            GridManipulations = (ITTGrid)AddControl(new Guid("30398e7c-ff89-4bd3-bf4b-2de6204f7afc"));
            ManipulationActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("7178b38a-c96e-4c42-82cc-106eefe96f85"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("9d25a65e-6269-456a-9d56-cc3ff7232d3f"));
            Emergency = (ITTCheckBoxColumn)AddControl(new Guid("b6692530-9b90-47b9-902a-c3c6a4ac1cb8"));
            Department = (ITTListBoxColumn)AddControl(new Guid("638cc4bb-3c7b-46ba-9ee3-a1ad64f543e1"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("56032dcc-de6c-4591-b525-5abcf7a023d4"));
            AyniFarkliKesi = (ITTListBoxColumn)AddControl(new Guid("f4ab7736-7414-4c3b-9b24-f71d3cde2f6a"));
            DrAnesteziTescilNo = (ITTListBoxColumn)AddControl(new Guid("2010cd91-4d37-4e11-aaed-007884163116"));
            EuroScore = (ITTEnumComboBoxColumn)AddControl(new Guid("aae9a05a-7898-4d0e-9e97-dfdf98746fd1"));
            SagSol = (ITTListBoxColumn)AddControl(new Guid("916cefa6-3ad3-4094-bd4b-ae037882b52f"));
            Birim = (ITTTextBoxColumn)AddControl(new Guid("62f0420b-d4c8-426e-9b50-fe698b4b4cd4"));
            Sonuc = (ITTTextBoxColumn)AddControl(new Guid("b71fe115-f304-448d-bfef-342bfe5a6754"));
            RaporTakipNo = (ITTTextBoxColumn)AddControl(new Guid("553ded60-f606-43d4-b5b7-b3d7030ab0a2"));
            OzelDurum = (ITTListBoxColumn)AddControl(new Guid("02571a2e-ed61-43c1-9be9-93f731fdd350"));
            CokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("c9d5eb47-ac97-48f5-9d9d-d83c6dfd9dd7"));
            PersonnelTab = (ITTTabPage)AddControl(new Guid("c5f0cc88-b43c-42f3-99f3-e9edf3167581"));
            GridPersonnel = (ITTGrid)AddControl(new Guid("ab57a994-9ba0-4ce2-abf7-1f103bd86879"));
            Personnel = (ITTListBoxColumn)AddControl(new Guid("0e78c699-ac71-4c30-b971-4086ba190461"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("6fbd1362-16ff-4170-add8-3c5efb92fdd8"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("18ac7d83-bf68-4a99-b9a6-a65c79d5009b"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("b86bc19c-00cb-45f0-92c5-3f3668687d39"));
            Material = (ITTListBoxColumn)AddControl(new Guid("96809763-7e37-4342-bb63-7e487045bfa1"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("0af6244b-5a11-4ff4-97c6-4ad4502d53d0"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("e5a5bdbc-00f6-4f17-86fb-e93b43a01b43"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("817ffe38-2d7a-4171-9bbd-ec7624c3eed1"));
            UBBCode = (ITTTextBoxColumn)AddControl(new Guid("7766cced-28f8-4cdd-8be2-ecb622086ab9"));
            Notes = (ITTTextBoxColumn)AddControl(new Guid("bd38ff69-fcdf-4455-9edd-5e1de41f481e"));
            AdditionalApplicationTab = (ITTTabPage)AddControl(new Guid("9278464e-a015-4086-a8c9-d9fea67224e1"));
            GridAdditionalApplications = (ITTGrid)AddControl(new Guid("a769d465-891e-4fe1-bc16-92e3c52831c0"));
            SDateTime = (ITTDateTimePickerColumn)AddControl(new Guid("173eed07-702e-45c4-b697-69002def09f0"));
            AProcedureObject = (ITTListBoxColumn)AddControl(new Guid("0eb48999-ee26-40d2-bccf-48cfc6b6507e"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("d73c7903-6ee3-4303-aee0-293caddbe7a6"));
            NurseNotes = (ITTTextBoxColumn)AddControl(new Guid("cc14e182-b3d0-4f40-af36-1d03741ee79b"));
            DirectPurchase = (ITTTabPage)AddControl(new Guid("3fa3b139-1594-401a-9d40-ff140a7d9126"));
            DirectPurchaseGrids = (ITTGrid)AddControl(new Guid("f54f7904-ab18-4a33-800e-6f807f291dbc"));
            MaterialDirectPurchaseGrid = (ITTListBoxColumn)AddControl(new Guid("29ddb19f-0bd6-46b2-94e9-204419ad4237"));
            AmountDirectPurchaseGrid = (ITTTextBoxColumn)AddControl(new Guid("04e6a094-d015-495b-9a39-850741b24c9b"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("20263d64-05c5-4df1-9a3e-1104ce751f00"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("9c37f840-3d61-476b-ba4a-ccaaec1a234f"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("eb1bb6e3-c1d3-4d75-8349-4ba380b33d85"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("ed84eb26-614b-4db1-95c7-c7a51b836482"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("bb60a461-6c51-4400-9a72-07a7e684b7ac"));
            ttrichtextboxcontrol3 = (ITTRichTextBoxControl)AddControl(new Guid("6ce4e77f-8b6d-423a-8a33-09dac9f84446"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("9c47b62d-9ac1-4086-bf66-308bcc0a479f"));
            ReturnReason = (ITTTextBoxColumn)AddControl(new Guid("6ff9e25b-6517-43c0-909a-e08713a42e1b"));
            Technician = (ITTObjectListBox)AddControl(new Guid("5112f07b-f3c5-4e32-b0e2-89588b07c1aa"));
            lblSorumluDoktor = (ITTLabel)AddControl(new Guid("1c4c1667-1170-4e39-99e4-a5ea80a04f1a"));
            TTListBoxSorumluDoktor = (ITTObjectListBox)AddControl(new Guid("acd80be0-78cc-4430-8b60-a005b6792a38"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("a0896dd8-7862-47e3-a01d-6fc191d3a454"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("33af354a-6317-419c-ab78-f8a4da0acc79"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("1138e48b-3439-400e-8e28-a6fa47aa6d89"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("60711c60-04ed-4194-98c3-049e6eaaf1ae"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("df812c02-7796-4af1-b9b9-5b80ff2b74dd"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("baf63d13-abe2-4995-a303-5bfe523089ff"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("39eaafac-6c7d-4215-a2d4-c303a903ca80"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("2ace7228-d6af-4ed1-a05c-719aa1436867"));
            base.InitializeControls();
        }

        public ManipulationTechnicianForm() : base("MANIPULATION", "ManipulationTechnicianForm")
        {
        }

        protected ManipulationTechnicianForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}