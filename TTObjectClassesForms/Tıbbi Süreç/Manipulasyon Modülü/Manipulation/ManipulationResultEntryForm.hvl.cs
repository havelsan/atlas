
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
    public partial class ManipulationResultEntryForm : EpisodeActionForm
    {
    /// <summary>
    /// Tıbbi/Cerrahi Uygulama İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Manipulation _Manipulation
        {
            get { return (TTObjectClasses.Manipulation)_ttObject; }
        }

        protected ITTButton btnImportFromPdf;
        protected ITTRichTextBoxControl Rapor;
        protected ITTRichTextBoxControl ProcedureReport;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage ManipulationTab;
        protected ITTGrid GridManipulations;
        protected ITTDateTimePickerColumn ManipulationActionDate;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTCheckBoxColumn Emergency;
        protected ITTListBoxColumn Department;
        protected ITTTextBoxColumn Description;
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
        protected ITTTextBoxColumn UBBCode;
        protected ITTTextBoxColumn UnitType;
        protected ITTTextBoxColumn Notes;
        protected ITTTabPage AdditionalApplicationTab;
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
        protected ITTLabel labelResponsiblePersonnel;
        protected ITTObjectListBox ResponsiblePersonnel;
        override protected void InitializeControls()
        {
            btnImportFromPdf = (ITTButton)AddControl(new Guid("265aad0e-a3fa-4a7c-bd30-67582b01db48"));
            Rapor = (ITTRichTextBoxControl)AddControl(new Guid("8b43e7c4-5dc3-420e-a5eb-fad026700fe9"));
            ProcedureReport = (ITTRichTextBoxControl)AddControl(new Guid("f8b0ae56-b35a-4d1f-b1f8-c7838d93a401"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("75b96014-9300-4e7f-9987-f53837137395"));
            ManipulationTab = (ITTTabPage)AddControl(new Guid("c0ef1bea-9180-42e1-87fd-d2399cf884e0"));
            GridManipulations = (ITTGrid)AddControl(new Guid("c4f60624-73ed-4e03-b0d0-4f351fb73bb2"));
            ManipulationActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("275e6a2b-4a81-4560-acde-751ced9b64ab"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("6bca60c3-4643-416e-b3f6-563170f2d6e5"));
            Emergency = (ITTCheckBoxColumn)AddControl(new Guid("802e091a-3713-465e-9530-b2e68663121b"));
            Department = (ITTListBoxColumn)AddControl(new Guid("b0060960-65b0-4a8a-ac7f-8dc57635f3d9"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("8dc373f1-3f9d-4b86-9c0f-cfd6e0787355"));
            PersonnelTab = (ITTTabPage)AddControl(new Guid("2918484b-6604-4f88-87ee-0daf3afb6b72"));
            GridPersonnel = (ITTGrid)AddControl(new Guid("d65a1d93-a92e-42fa-a5cc-5a48cb4bfa13"));
            Personnel = (ITTListBoxColumn)AddControl(new Guid("ad37f0d4-9af8-491f-a6fb-452601761f33"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("1cc5fb95-697c-4fa2-b484-64b20e5005b1"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("a5d80edc-9bc1-4a5c-b65f-b2488bc48919"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("7ef20989-4548-488d-9754-339adbbf0543"));
            Material = (ITTListBoxColumn)AddControl(new Guid("d152e7e5-4c44-444b-a2f8-b82ba213c507"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("80e3483d-46cb-46ce-98c2-f004bfbd98a9"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("6fde5828-47be-45cc-b434-e00078e9ccf2"));
            UseAmount = (ITTTextBoxColumn)AddControl(new Guid("9411742c-7ca5-49ab-bd4d-cba427c9155b"));
            UBBCode = (ITTTextBoxColumn)AddControl(new Guid("a21d86d5-da0d-42f6-badd-8dc30fa3be13"));
            UnitType = (ITTTextBoxColumn)AddControl(new Guid("a4ccdac5-9696-499d-8be3-73c25f444439"));
            Notes = (ITTTextBoxColumn)AddControl(new Guid("aec96f0c-aaf7-47b6-97ed-6f8c1aa37cfc"));
            AdditionalApplicationTab = (ITTTabPage)AddControl(new Guid("8a018ed5-2619-4cd8-bc93-e34f03686821"));
            GridAdditionalApplications = (ITTGrid)AddControl(new Guid("a0629744-56da-4d07-91c8-f1ac99b18710"));
            SDateTime = (ITTDateTimePickerColumn)AddControl(new Guid("cd8baa39-1f5d-4698-bcf9-64622e22e83c"));
            AProcedureObject = (ITTListBoxColumn)AddControl(new Guid("0e2bdaeb-2083-46d2-b1ad-04e32b3ff22f"));
            Result = (ITTTextBoxColumn)AddControl(new Guid("cd369ab2-d14f-4418-9cec-ae574c422e9a"));
            NurseNotes = (ITTTextBoxColumn)AddControl(new Guid("3a9252cb-08ec-4332-9b55-05af7fed8084"));
            DirectPurchase = (ITTTabPage)AddControl(new Guid("4d24a449-f64d-45eb-8d34-2069887430b2"));
            SurgeryDirectPurchaseGrids = (ITTGrid)AddControl(new Guid("b675c2dd-e913-46c4-9cbf-c13170ebbb85"));
            DPADetailFirmPriceOffer = (ITTListBoxColumn)AddControl(new Guid("06534604-0eee-4567-ae54-3cad34d41deb"));
            txtBarcode = (ITTTextBoxColumn)AddControl(new Guid("674685e1-49ad-4fb0-be30-61d059e852c8"));
            txtMiktar = (ITTTextBoxColumn)AddControl(new Guid("c5df2314-4ade-4ae5-b806-0cc5d10af960"));
            CodelessDirectPurchase = (ITTTabPage)AddControl(new Guid("0b5ea0c0-fcac-44e3-8c80-42c10a4845d8"));
            Manipulation_CodelessMaterialDirectPurchaseGrids = (ITTGrid)AddControl(new Guid("aa8b0b97-d4a0-4add-9688-1946bd940212"));
            DPADetailFirmPriceOfferCodelessMaterialDirectPurchaseGrid = (ITTListBoxColumn)AddControl(new Guid("4674b685-b0a5-4040-bedf-5b5d798558e7"));
            txtKesinMiktar = (ITTTextBoxColumn)AddControl(new Guid("44faf017-2ae0-4c0f-a76f-274a1e6e2401"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("aaf89c94-131b-459f-b2f7-a63bf701d99c"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("20991028-466d-4a6f-84ec-932a28bc85cd"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("689d4e2f-f676-4f52-bce5-9d825601ced6"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("b79900dd-95d8-4a6a-ada9-8f17b6563253"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("473e1ba1-14ee-42d4-8443-e7e1ea40fa17"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("5956d002-ecee-4666-9f16-6d8189db7ee0"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("5dab0fa9-3c63-4f3f-a712-8defb92462ce"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("a89f0197-76bd-4ad9-83a6-30550fec7337"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("189c6930-47dd-43f3-aa73-364eeea3c461"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("0919d683-4a30-4f35-b223-b32cd9c00c20"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("4f587cc2-b762-4c21-b62b-6e9c44c67572"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("65d18851-2b63-416e-84e6-22936ee53005"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("e853f34d-2215-4f47-9d92-8c0ba985f2e1"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("e05d8aa2-a9b2-462a-9618-fd107c296c35"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("70fe11e9-cb45-4b13-b082-3a61672c273e"));
            DiagnosisEntryTab = (ITTTabPage)AddControl(new Guid("4c85c8d2-2b41-440a-86c3-39518588157b"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("261d81aa-5c1f-4a9e-9879-f0acaa7f347f"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("5dd8f0eb-3080-4c48-baea-cf88dae03c5b"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("d009f88e-ada6-4739-aa01-3858fc601f20"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("1cf49a49-0ae0-4fd1-92f6-83c4eaf0d768"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("13a6625b-f7bc-4c78-b5aa-a03cdb9c45af"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("3fb74734-9c00-4150-8438-4f73f0af8359"));
            lblSorumluDoktor = (ITTLabel)AddControl(new Guid("60c8601b-84e6-455b-ba01-a91cd95327af"));
            TTListBoxSorumluDoktor = (ITTObjectListBox)AddControl(new Guid("d2ad378f-b560-41ef-bdc5-3fccd8aa1784"));
            labelResponsiblePersonnel = (ITTLabel)AddControl(new Guid("f750f179-3b4a-4e07-b38d-883330194968"));
            ResponsiblePersonnel = (ITTObjectListBox)AddControl(new Guid("aa1f5179-a2d5-49de-bbbf-67d3bcbf8ac6"));
            base.InitializeControls();
        }

        public ManipulationResultEntryForm() : base("MANIPULATION", "ManipulationResultEntryForm")
        {
        }

        protected ManipulationResultEntryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}