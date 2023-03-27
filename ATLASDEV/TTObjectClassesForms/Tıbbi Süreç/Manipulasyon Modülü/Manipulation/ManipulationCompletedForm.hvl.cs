
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
    public partial class ManipulationCompletedForm : EpisodeActionForm
    {
    /// <summary>
    /// Tıbbi/Cerrahi Uygulama İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Manipulation _Manipulation
        {
            get { return (TTObjectClasses.Manipulation)_ttObject; }
        }

        protected ITTRichTextBoxControl ProcedureReport;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage ManiplasyonTab;
        protected ITTGrid GridManipulations;
        protected ITTDateTimePickerColumn ManipulationActionDate;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTCheckBoxColumn Emergency;
        protected ITTListBoxColumn Department;
        protected ITTTextBoxColumn Description;
        protected ITTTabPage TreatmentMaterialTab;
        protected ITTGrid GridTreatmentMaterials;
        protected ITTDateTimePickerColumn MaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn UseAmount;
        protected ITTTextBoxColumn UnitType;
        protected ITTTextBoxColumn UBBCode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Notes;
        protected ITTTabPage AdditionalApplication;
        protected ITTGrid GridAdditionalApplications;
        protected ITTDateTimePickerColumn SDateTime;
        protected ITTListBoxColumn AProcedureObject;
        protected ITTTextBoxColumn Result;
        protected ITTTextBoxColumn NurseNotes;
        protected ITTTabPage DirectPurchase;
        protected ITTGrid SurgeryDirectPurchaseGrids;
        protected ITTListBoxColumn DPADetailFirmPriceOffer;
        protected ITTTextBoxColumn txtBarcode;
        protected ITTTextBoxColumn txtMiktar;
        protected ITTTabPage CodelessDirectPurchase;
        protected ITTGrid Manipulation_CodelessMaterialDirectPurchaseGrids;
        protected ITTListBoxColumn DPADetailFirmPriceOfferCodelessMaterialDirectPurchaseGrid;
        protected ITTTextBoxColumn txtKesinMiktar;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProtocolNo;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelProcessTime;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTGrid ReturnReasonsGrid;
        protected ITTTextBoxColumn ReturnReason;
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
        protected ITTLabel lblSorumluDoktor;
        protected ITTObjectListBox TTListBoxSorumluDoktor;
        override protected void InitializeControls()
        {
            ProcedureReport = (ITTRichTextBoxControl)AddControl(new Guid("a92cb664-a40a-4391-b803-96269cafe406"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("2593d81d-6b12-4b72-90e8-0fe53eab0498"));
            ManiplasyonTab = (ITTTabPage)AddControl(new Guid("c64268b5-dcae-4e11-89f7-98349415fb5c"));
            GridManipulations = (ITTGrid)AddControl(new Guid("ac7c4b3f-8cb7-4a2e-8212-faa762574f72"));
            ManipulationActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("df17b5af-4e20-430f-ad24-b5ab23d8ae9d"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("11952b13-776e-49c8-881b-6d25d5467fab"));
            Emergency = (ITTCheckBoxColumn)AddControl(new Guid("e3871403-81ae-42cb-9d8d-1eba68ddd604"));
            Department = (ITTListBoxColumn)AddControl(new Guid("92cd8e2d-dd45-4d2c-bfe8-2ec62d794c0b"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("22aedb83-fdc3-4c77-90dd-615ed605145f"));
            TreatmentMaterialTab = (ITTTabPage)AddControl(new Guid("d5a80141-a82e-45f3-bac7-243f14d0584c"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("ed5bcd31-dc2b-4568-ba98-d5e9180d02ba"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("c9e5812b-a0a8-4673-850d-0e26231c010c"));
            Material = (ITTListBoxColumn)AddControl(new Guid("4a94f4fd-8824-4081-adb3-685122e3d8a0"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("c0550651-5ed1-41f6-a792-74230d72f5ec"));
            UseAmount = (ITTTextBoxColumn)AddControl(new Guid("2b04837c-0898-43dd-8027-70ddd4442d8b"));
            UnitType = (ITTTextBoxColumn)AddControl(new Guid("c4aa74ad-87ba-47b2-9474-47d51631d4f1"));
            UBBCode = (ITTTextBoxColumn)AddControl(new Guid("35c41e8d-ef33-4637-b9fb-21f7922d2c12"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("a48f9bff-e273-4cb0-8431-2806d017db84"));
            Notes = (ITTTextBoxColumn)AddControl(new Guid("835df5e6-34a8-43a4-93bb-800d0df60636"));
            AdditionalApplication = (ITTTabPage)AddControl(new Guid("121a62cc-1797-4261-ac92-a6362509f26e"));
            GridAdditionalApplications = (ITTGrid)AddControl(new Guid("0dc63ae4-58e3-46d9-875a-c4dc8356effe"));
            SDateTime = (ITTDateTimePickerColumn)AddControl(new Guid("84bf322b-459f-417b-971b-2e1019505821"));
            AProcedureObject = (ITTListBoxColumn)AddControl(new Guid("e4c28f20-4cd4-4892-9472-f3e5bc9ee3de"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("2c2f45bb-6bd3-4b15-92bf-c73d41cd56d5"));
            NurseNotes = (ITTTextBoxColumn)AddControl(new Guid("37bea0a6-a276-4d42-9abc-f3f25ee9deee"));
            DirectPurchase = (ITTTabPage)AddControl(new Guid("d7b473e3-d457-4ea9-8261-833b6ba7baee"));
            SurgeryDirectPurchaseGrids = (ITTGrid)AddControl(new Guid("845aed46-374c-453e-84e1-e2bdf34b8247"));
            DPADetailFirmPriceOffer = (ITTListBoxColumn)AddControl(new Guid("87ddd63a-275a-4c7b-9c4e-ed88f46cf6d8"));
            txtBarcode = (ITTTextBoxColumn)AddControl(new Guid("4cc21b5f-5308-4848-8d90-a228a2454a39"));
            txtMiktar = (ITTTextBoxColumn)AddControl(new Guid("9513d41c-71c4-4135-a1e3-6d2ba954d99d"));
            CodelessDirectPurchase = (ITTTabPage)AddControl(new Guid("858873d4-e80c-46d3-8460-6a7ecee71d86"));
            Manipulation_CodelessMaterialDirectPurchaseGrids = (ITTGrid)AddControl(new Guid("f8a56d0e-80b2-453e-880d-16cdc0ce9e5b"));
            DPADetailFirmPriceOfferCodelessMaterialDirectPurchaseGrid = (ITTListBoxColumn)AddControl(new Guid("1155f589-4ab6-407b-9505-3b178b3b1a99"));
            txtKesinMiktar = (ITTTextBoxColumn)AddControl(new Guid("306674ff-534c-462f-a157-afd5a9229bbc"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("fcae3a60-4083-418b-90cc-3d0d2dd5fbcd"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("7fac5e7f-7d59-4784-970b-edf12c1c7bbf"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("312b895b-f2a9-4bba-8376-86873d8312d5"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("e0d6f000-7d9c-49d5-b4fe-9767add9d6fc"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("75bc6df1-5177-42ca-8557-a4762049da48"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("2ffbc8a2-d4bd-4b04-add0-d30f4cfa7edf"));
            ReturnReasonsGrid = (ITTGrid)AddControl(new Guid("de37cb05-4172-4c41-8b90-f58f9226c8d4"));
            ReturnReason = (ITTTextBoxColumn)AddControl(new Guid("626c3079-24e8-49cc-88b0-3d0159f5e709"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("a603db41-9a32-4835-a178-ef685a91f978"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("6c3faa3e-2fe1-40da-8077-6740f9b03ccf"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("d8ac1a41-eedf-4628-8c4f-1ff2e1f9164b"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("f8170476-e56c-45a6-b14e-c575d7634c68"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("94bc2111-7763-4d0e-83b2-dd65548d6e36"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("70ed5194-8d7d-49d9-aa39-6ca1b44d9a92"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("e271ee5e-893f-496e-b04a-19f2d9ad7a64"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("33c44aa8-b408-4d88-bc0a-35be1bcb4e61"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("d6205a1f-4806-45b3-8d1c-616502910ed0"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("eef0df74-cf67-4e67-b9ef-64ab6d0725c7"));
            DiagnosisEntryTab = (ITTTabPage)AddControl(new Guid("6267e0c6-1560-4724-a1f9-d941e03233a0"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("9b023b15-f3aa-46e8-9e3b-a43fcd5c8705"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("ca655ac4-edbf-4ac3-82ec-f1e1c007fb46"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("47bc4ea0-894f-4344-91ee-170f0e37a96b"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("2f4224ff-97d1-436d-ab20-3d537bcdd95d"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("139711fa-4e90-483c-9948-78cd34c10587"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("0fbba523-9a80-4304-a97b-fce140ad8fbe"));
            lblSorumluDoktor = (ITTLabel)AddControl(new Guid("22ec84dc-277f-4b72-a71d-48ac3d1ae574"));
            TTListBoxSorumluDoktor = (ITTObjectListBox)AddControl(new Guid("a0704aa5-cb2a-486a-9bfd-639e1beb6401"));
            base.InitializeControls();
        }

        public ManipulationCompletedForm() : base("MANIPULATION", "ManipulationCompletedForm")
        {
        }

        protected ManipulationCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}