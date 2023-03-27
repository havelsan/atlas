
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
    /// Radyoloji Sonuç Giriş Formu
    /// </summary>
    public partial class RadiologyTestResultEntryForm : RadiologyTestBaseForm
    {
    /// <summary>
    /// Radyoloji Tetkik
    /// </summary>
        protected TTObjectClasses.RadiologyTest _RadiologyTest
        {
            get { return (TTObjectClasses.RadiologyTest)_ttObject; }
        }

        protected ITTLabel labelComparisonInfo;
        protected ITTRichTextBoxControl ComparisonInfo;
        protected ITTLabel labelRadiographyTechnique;
        protected ITTRichTextBoxControl RadiographyTechnique;
        protected ITTLabel labelResults;
        protected ITTRichTextBoxControl Results;
        protected ITTLabel labelImageQualityAssesment;
        protected ITTEnumComboBox ImageQualityAssesment;
        protected ITTCheckBox ttMasterResourceUserCheck;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage tabAnamnez;
        protected ITTTextBox PREDIAGNOSIS;
        protected ITTTabPage tabDescription;
        protected ITTTextBox CommonDescription;
        protected ITTTabPage tabAdditionalRequest;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox OwnerType;
        protected ITTObjectListBox Requester;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelProcessTime;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel15;
        protected ITTEnumComboBox PATIENTGROUPENUM;
        protected ITTLabel ttlabel16;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTListBoxColumn taniOzelDurum;
        protected ITTButtonColumn taniCokluOzelDurum;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTLabel labelRequestReasonAssesment;
        protected ITTEnumComboBox RequestReasonAssesment;
        protected ITTObjectListBox TTListBoxDrAnesteziTescilNo;
        protected ITTLabel ttlabelDrAnesteziTescilNo;
        protected ITTObjectListBox TTListBoxSagSol;
        protected ITTObjectListBox TTListBoxKesi;
        protected ITTLabel ttlabelSagSol;
        protected ITTLabel ttlabelKesi;
        protected ITTLabel ttlabel4;
        protected ITTTextBox Description;
        protected ITTLabel ttlabel5;
        protected ITTRichTextBoxControl rtfReport;
        protected ITTLabel ttlabel10;
        protected ITTObjectListBox Equipment;
        protected ITTObjectListBox ProcedureObject;
        protected ITTTextBox tttextboxBirim;
        protected ITTLabel ttlabelBirim;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox ApprovedBy;
        protected ITTTextBox DisTaahhutNo;
        protected ITTLabel ttlabel12;
        protected ITTObjectListBox Deparment;
        protected ITTButton ttbuttonToothSchema;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelDisTaahhutNo;
        protected ITTLabel ttlabel11;
        protected ITTTextBox TestTechnicianNote;
        protected ITTTabPage tttabpage2;
        protected ITTGrid Materials;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UBBCode;
        protected ITTTextBoxColumn kodsuzMalzemeFiyati;
        protected ITTListBoxColumn malzemeTuru;
        protected ITTTextBoxColumn kdv;
        protected ITTTextBoxColumn malzemeBrans;
        protected ITTDateTimePickerColumn malzemeSatinAlisTarihi;
        protected ITTListBoxColumn malzemeOzelDurum;
        protected ITTButtonColumn malzemeCokluOzelDurum;
        protected ITTTabPage tttabpage3;
        protected ITTGrid SurgeryDirectPurchaseGrids;
        protected ITTListBoxColumn DPADetailFirmPriceOffer;
        protected ITTTextBoxColumn txtBarcode;
        protected ITTTextBoxColumn txtKesinlesenMiktar;
        protected ITTObjectListBox ReportedBy;
        protected ITTLabel ttlabel8;
        protected ITTButton cmdImage;
        override protected void InitializeControls()
        {
            labelComparisonInfo = (ITTLabel)AddControl(new Guid("69e9fb98-a7a1-4510-8f98-9c4853a50e4e"));
            ComparisonInfo = (ITTRichTextBoxControl)AddControl(new Guid("3bb810f0-7adb-4c67-8435-bb55336d8faf"));
            labelRadiographyTechnique = (ITTLabel)AddControl(new Guid("9b425484-e571-4226-8653-16297fb8b0be"));
            RadiographyTechnique = (ITTRichTextBoxControl)AddControl(new Guid("d8548e0f-965b-4081-9560-7e1ae02646f3"));
            labelResults = (ITTLabel)AddControl(new Guid("5ee60f44-d9b4-43d8-86b4-7b3970f77695"));
            Results = (ITTRichTextBoxControl)AddControl(new Guid("590b8c20-0efb-4041-8e48-5885a979d0f4"));
            labelImageQualityAssesment = (ITTLabel)AddControl(new Guid("2a7cd6a5-c6c0-48b9-bb07-789ebdf30200"));
            ImageQualityAssesment = (ITTEnumComboBox)AddControl(new Guid("5a9c4cd3-4185-4fe3-9b20-3f7bc0a13ba7"));
            ttMasterResourceUserCheck = (ITTCheckBox)AddControl(new Guid("d3e29392-d4eb-4814-85d7-fa0027ad29f8"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("e99d4510-9596-47bd-924d-e2ad5e43c4b1"));
            tabAnamnez = (ITTTabPage)AddControl(new Guid("fb20357f-1705-4bca-81c1-fe6d74cbbc01"));
            PREDIAGNOSIS = (ITTTextBox)AddControl(new Guid("ab2e07cb-ff87-45eb-a0e7-37bbe0afd09d"));
            tabDescription = (ITTTabPage)AddControl(new Guid("8e597910-e72b-4dc8-8c5d-eeee71978fb5"));
            CommonDescription = (ITTTextBox)AddControl(new Guid("94651f5d-afa3-4911-8ca5-658711e93879"));
            tabAdditionalRequest = (ITTTabPage)AddControl(new Guid("346e8075-994d-4527-b429-cfdc3e9eae3d"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("cc640862-675a-4c31-b60e-290a29f9dc14"));
            OwnerType = (ITTTextBox)AddControl(new Guid("61dcaa62-12b6-47c9-9711-e39c748d0e72"));
            Requester = (ITTObjectListBox)AddControl(new Guid("81e40b2c-e4f2-45bc-98f9-a1646e221c0e"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("41f9d2a0-152d-446e-8212-b078258579ad"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("417cc8d7-855f-431d-8b9c-fdcdf3b1751b"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("dd5e5b13-3e58-4972-8b64-85ee24d11317"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("14aea5f3-be54-4aef-b934-2dbc076c541c"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("9484ff5a-f0db-4827-91c8-e19476c2aa9c"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("35474b40-12ac-4464-be3c-ae292e5806a1"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("e6a20b18-2d42-4ee5-80d6-33448599294e"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("31b86570-26b3-4f1d-ba4a-885ab9748b2d"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("faf64bfe-30b1-455a-8d49-8e285aa0e09a"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("e8d6c02f-c2ad-4963-a89a-e84289bcc16d"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("c7fef1d4-c699-42eb-8063-485fc666cbb1"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("9b6144a9-a08f-47f2-a2eb-14b78230529d"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("5c59fc09-f2e6-423a-96f5-5ce3008290b4"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("0175e033-da04-402e-8769-fbe750022100"));
            taniOzelDurum = (ITTListBoxColumn)AddControl(new Guid("145a4a69-edeb-412e-aacd-bbfb9d13a661"));
            taniCokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("77277736-d21c-4d30-924d-b8dec64521b6"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("24041644-7476-4828-bb77-65bacca491eb"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("ef2efaa2-f32d-450c-8ddb-d975bd443bef"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("0b668220-95d8-4b85-b3ca-6ca750382b75"));
            labelRequestReasonAssesment = (ITTLabel)AddControl(new Guid("3ccac6d2-f1b2-4982-83d3-da7e4bc02f5e"));
            RequestReasonAssesment = (ITTEnumComboBox)AddControl(new Guid("52726714-c990-469f-9d3f-b594979a0bce"));
            TTListBoxDrAnesteziTescilNo = (ITTObjectListBox)AddControl(new Guid("9d450973-9000-48e9-9b51-fa988ad22a24"));
            ttlabelDrAnesteziTescilNo = (ITTLabel)AddControl(new Guid("8baf3f6d-42e9-4190-83d5-3000220bf5e3"));
            TTListBoxSagSol = (ITTObjectListBox)AddControl(new Guid("3c151396-b9d1-4445-ab16-d5fc12165caa"));
            TTListBoxKesi = (ITTObjectListBox)AddControl(new Guid("8a60dac9-6122-44f5-b472-1eb0ba5b7b83"));
            ttlabelSagSol = (ITTLabel)AddControl(new Guid("5e8dd1db-4b3b-4895-ab80-1ea3c0109b0f"));
            ttlabelKesi = (ITTLabel)AddControl(new Guid("a3e42c27-da56-4f47-97d4-0cf0f6ab1a23"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("c5818914-f6f7-4e7c-a12c-399f57516177"));
            Description = (ITTTextBox)AddControl(new Guid("2c9c50b6-c1a7-4e59-a428-45ece1d6eba0"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("0f5bf9a3-e4a0-4e57-9c32-daaff746815f"));
            rtfReport = (ITTRichTextBoxControl)AddControl(new Guid("5746761d-121f-4359-aa73-bcd566548706"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("55f60562-5d66-4f36-a5ed-96a3e3c38111"));
            Equipment = (ITTObjectListBox)AddControl(new Guid("bdceedfb-897c-452c-b182-2742b1ab2add"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("87956984-a224-4f78-9fc4-7db6fb1e0ec8"));
            tttextboxBirim = (ITTTextBox)AddControl(new Guid("e9c13af7-7309-4cd5-a652-1549b8ce5d3b"));
            ttlabelBirim = (ITTLabel)AddControl(new Guid("53f10565-3ea2-4f64-aa5a-a724973751fd"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("3a1be4e8-12a0-4043-84c9-68ae77c901a0"));
            ApprovedBy = (ITTObjectListBox)AddControl(new Guid("d3c6aee9-9cde-4bfe-9d36-c0c0e2350ead"));
            DisTaahhutNo = (ITTTextBox)AddControl(new Guid("14fdb986-32d2-4ee6-9c88-f4e52808168d"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("d66845f8-44bc-4fa5-ad07-d8b19ae63c99"));
            Deparment = (ITTObjectListBox)AddControl(new Guid("82bd636c-22e1-4900-903e-bf44d0bf2fd4"));
            ttbuttonToothSchema = (ITTButton)AddControl(new Guid("62337b0a-05ef-4ef7-8509-0feb75a8d465"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("eccfa979-9d8b-4494-9fcb-d93a785ad20a"));
            labelDisTaahhutNo = (ITTLabel)AddControl(new Guid("f7a5e69f-afb0-4eaa-b122-918793966453"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("f496c8ae-1df2-44e4-9d16-d8f7be7d9f8e"));
            TestTechnicianNote = (ITTTextBox)AddControl(new Guid("17dbc8ed-0a59-4315-adb6-5bad6e8412fc"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("e051fe78-cfd3-44d9-8211-57505d38fe5a"));
            Materials = (ITTGrid)AddControl(new Guid("0772f688-09f1-4e74-8346-fe522e224204"));
            Material = (ITTListBoxColumn)AddControl(new Guid("6aee9951-08a6-40e6-876b-e1d950e9970b"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("1f15cee4-4add-44a5-b725-a9e17a953aa6"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("931bf21a-83e0-4588-a6c4-fc7e703a641b"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("3a4b6fce-3bb1-4ebc-a7b7-bdd6f6900571"));
            UBBCode = (ITTTextBoxColumn)AddControl(new Guid("3871a9fd-95b0-4ad9-86e1-8dbda2d23490"));
            kodsuzMalzemeFiyati = (ITTTextBoxColumn)AddControl(new Guid("18e1682f-a03d-4e73-849b-919fffe8636b"));
            malzemeTuru = (ITTListBoxColumn)AddControl(new Guid("c1909776-6359-4469-a26d-baab99725dd2"));
            kdv = (ITTTextBoxColumn)AddControl(new Guid("40346d17-06d8-4dad-a99b-48dd85fe442f"));
            malzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("d19c4a18-43d2-4715-baab-b1b45548e9b3"));
            malzemeSatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("654b8977-765a-4e6e-b64b-fbe9ebd7d230"));
            malzemeOzelDurum = (ITTListBoxColumn)AddControl(new Guid("9ba189ca-b5ba-4ca3-8b71-37930915ed99"));
            malzemeCokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("3ded14e7-5e6c-4571-8bea-edba62bebd00"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("df978e78-19ea-48ee-8467-b5c28a273c8e"));
            SurgeryDirectPurchaseGrids = (ITTGrid)AddControl(new Guid("6cad3309-9032-43ed-be57-b988f1676c15"));
            DPADetailFirmPriceOffer = (ITTListBoxColumn)AddControl(new Guid("3d791cec-642b-4c9b-aa43-a3aeaa23c87a"));
            txtBarcode = (ITTTextBoxColumn)AddControl(new Guid("fb2e7b64-e85d-44f6-bec8-1e029dd635fe"));
            txtKesinlesenMiktar = (ITTTextBoxColumn)AddControl(new Guid("de100d3e-35f9-49cb-8fb1-1b5a1714a3b6"));
            ReportedBy = (ITTObjectListBox)AddControl(new Guid("a81ee296-6399-47f4-9d6f-819fe0fd1a66"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("177e7e28-aaf7-4a65-9758-f5dfab8b31b6"));
            cmdImage = (ITTButton)AddControl(new Guid("923bf278-d6be-4565-b5fb-0bcec09d7736"));
            base.InitializeControls();
        }

        public RadiologyTestResultEntryForm() : base("RADIOLOGYTEST", "RadiologyTestResultEntryForm")
        {
        }

        protected RadiologyTestResultEntryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}