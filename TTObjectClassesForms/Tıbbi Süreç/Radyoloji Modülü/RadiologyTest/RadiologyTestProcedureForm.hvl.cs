
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
    /// Prosedür
    /// </summary>
    public partial class RadiologyTestProcedureForm : RadiologyTestBaseForm
    {
    /// <summary>
    /// Radyoloji Tetkik
    /// </summary>
        protected TTObjectClasses.RadiologyTest _RadiologyTest
        {
            get { return (TTObjectClasses.RadiologyTest)_ttObject; }
        }

        protected ITTButton cmdPrntRequestNo;
        protected ITTButton cmdSendPACS;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTButton buttonOpenTeleTipResults;
        protected ITTObjectListBox TTListBoxDrAnesteziTescilNo;
        protected ITTObjectListBox TTListBoxSagSol;
        protected ITTObjectListBox TTListBoxKesi;
        protected ITTLabel ttlabel4;
        protected ITTTextBox Description;
        protected ITTLabel ttlabel5;
        protected ITTTextBox DisTaahhutNo;
        protected ITTLabel ttlabel10;
        protected ITTObjectListBox Equipment;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox Deparment;
        protected ITTLabel ttlabel1;
        protected ITTTextBox TestTechnicianNote;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox RepeatReason;
        protected ITTLabel ttlabelSagSol;
        protected ITTTextBox tttextboxBirim;
        protected ITTLabel ttlabelBirim;
        protected ITTLabel ttlabel8;
        protected ITTLabel lblToothNumber;
        protected ITTLabel ttlabelDrAnesteziTescilNo;
        protected ITTEnumComboBox cmbToothNumber;
        protected ITTEnumComboBox cmbDentalPosition;
        protected ITTLabel labelDisTaahhutNo;
        protected ITTLabel ttlabel12;
        protected ITTButton ttbuttonToothSchema;
        protected ITTTabPage tttabpage2;
        protected ITTGrid Materials;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Amount;
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
        protected ITTTextBox OwnerType;
        protected ITTTextBox CommonDescription;
        protected ITTTextBox PREDIAGNOSIS;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelProcessTime;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel7;
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
        protected ITTLabel ttlabel3;
        protected ITTButton ttPrintRequestBarcode;
        protected ITTCheckBox ttBarcodePreviewCheck;
        protected ITTCheckBox Acil;
        override protected void InitializeControls()
        {
            cmdPrntRequestNo = (ITTButton)AddControl(new Guid("4a345bea-ae4f-4ce4-bb3a-312a430c4234"));
            cmdSendPACS = (ITTButton)AddControl(new Guid("42ded83e-26b9-4d3c-8aac-ba6a956a3081"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("97ca5847-793a-47bf-a865-43de573346d4"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("435b44f1-0338-4865-85ec-fc62375fb756"));
            buttonOpenTeleTipResults = (ITTButton)AddControl(new Guid("8f4e28cd-29b7-495e-8426-807c38026735"));
            TTListBoxDrAnesteziTescilNo = (ITTObjectListBox)AddControl(new Guid("0012ebf9-a0cd-4d1d-901f-8e1e953dab5d"));
            TTListBoxSagSol = (ITTObjectListBox)AddControl(new Guid("fcf13d4d-0558-4b13-b53c-05f591eee0f3"));
            TTListBoxKesi = (ITTObjectListBox)AddControl(new Guid("0bc5bec5-5895-4ce1-a8cf-308c695bdc11"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("5e9934db-bff9-4e3f-92c4-83dfb0624d9a"));
            Description = (ITTTextBox)AddControl(new Guid("1a084d18-01b9-4c4f-8237-ae02eb86ffa7"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("f8d9be2f-5875-4bc1-89ab-6df8d3829176"));
            DisTaahhutNo = (ITTTextBox)AddControl(new Guid("5224fe59-15fa-47d8-8336-9bb7be0f27cd"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("b33230eb-a2d4-4880-b449-546e5331d35c"));
            Equipment = (ITTObjectListBox)AddControl(new Guid("cd690c0c-5ceb-4cc5-9a37-f6f7a2bf3a8d"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("ca22d47f-c6ef-4554-9618-ccfa29bb0db7"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("b0628903-d3ba-4f22-936d-ddd4a4037d24"));
            Deparment = (ITTObjectListBox)AddControl(new Guid("a787f2f5-d9c9-43b0-a041-9797558df5c5"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("580eaa37-f1df-4f24-b0a3-4ca770d3da4e"));
            TestTechnicianNote = (ITTTextBox)AddControl(new Guid("65ca4b1e-ea66-4023-9533-b56371b6c057"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("d7464510-3b02-4ab2-98e1-361a40ada433"));
            RepeatReason = (ITTObjectListBox)AddControl(new Guid("8e1e6071-ed86-4b3f-98cc-e11190817341"));
            ttlabelSagSol = (ITTLabel)AddControl(new Guid("7b9295ae-93fe-4d38-871c-cf9eebe4c16e"));
            tttextboxBirim = (ITTTextBox)AddControl(new Guid("22c5f6a5-676a-4411-9815-95113430c400"));
            ttlabelBirim = (ITTLabel)AddControl(new Guid("269f9f28-2070-499d-b1cd-aa2c2e19cf42"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("01723002-049b-4838-bb6a-b0da083ec324"));
            lblToothNumber = (ITTLabel)AddControl(new Guid("6fe0d672-111d-4c35-b14c-1cc3db0bc3f5"));
            ttlabelDrAnesteziTescilNo = (ITTLabel)AddControl(new Guid("80972ad1-53e6-4f53-9c25-726009c2de04"));
            cmbToothNumber = (ITTEnumComboBox)AddControl(new Guid("f674638d-4367-49f9-967d-c08d9299a661"));
            cmbDentalPosition = (ITTEnumComboBox)AddControl(new Guid("565fea0e-05b4-4b13-aa66-3faf33cb1e27"));
            labelDisTaahhutNo = (ITTLabel)AddControl(new Guid("2c80353f-1f8d-4432-948c-8401220455f1"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("c3dbc4b0-1dd1-4f05-b87b-992adba30c7f"));
            ttbuttonToothSchema = (ITTButton)AddControl(new Guid("97902002-a047-4790-b4d9-8cd930458c25"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("aa6e1ce9-13b6-455e-976f-347cefacd847"));
            Materials = (ITTGrid)AddControl(new Guid("df052021-cb76-4012-8ce1-ed6538111aed"));
            Material = (ITTListBoxColumn)AddControl(new Guid("f391df0c-1a2c-48d4-bf03-a6898fa8a4b0"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("4ba1a5c9-ef8e-4c6f-87a6-55896789e7e9"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("be8df27a-72fa-45d1-aa42-67e6518f6ae3"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("6f20a0f8-be6d-493e-8cf7-47ffd2741d33"));
            kodsuzMalzemeFiyati = (ITTTextBoxColumn)AddControl(new Guid("1a898ba5-a444-48aa-82d3-73639dc1bc65"));
            malzemeTuru = (ITTListBoxColumn)AddControl(new Guid("ee7dadc3-f5c2-4d91-8c90-e16c8bc8b790"));
            kdv = (ITTTextBoxColumn)AddControl(new Guid("aef1f12b-c384-40db-bf06-227b3a29a54c"));
            malzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("f22deffe-0bb0-4f6a-a3ec-516818cf9d62"));
            malzemeSatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("a50b4d27-0815-4d8d-8134-94267949b787"));
            malzemeOzelDurum = (ITTListBoxColumn)AddControl(new Guid("187d8c1d-518b-4ec6-b4c7-f9d16951b3ca"));
            malzemeCokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("e0327aaa-299b-483f-96f2-ed640443c202"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("b5f0c723-eccc-474a-9ad9-2eda192b1860"));
            SurgeryDirectPurchaseGrids = (ITTGrid)AddControl(new Guid("b8217121-0645-4c01-ab2f-4e5c8b90502a"));
            DPADetailFirmPriceOffer = (ITTListBoxColumn)AddControl(new Guid("a04d6a17-4b4c-4fdb-b37c-4798b78b1114"));
            txtBarcode = (ITTTextBoxColumn)AddControl(new Guid("79b6369e-0b1b-40f9-94c1-95ec1d05853f"));
            txtKesinlesenMiktar = (ITTTextBoxColumn)AddControl(new Guid("f6118649-a380-44ff-bdba-b9e27298d74b"));
            OwnerType = (ITTTextBox)AddControl(new Guid("4d7c1b61-d1f1-448f-b33e-db02b9d157ff"));
            CommonDescription = (ITTTextBox)AddControl(new Guid("add8055e-66db-4d60-be4c-881552a1346e"));
            PREDIAGNOSIS = (ITTTextBox)AddControl(new Guid("9226e4c2-65e2-4602-9198-e7d62002c83e"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("d8034a12-1280-443d-ba24-ac218ff120f8"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("af06112f-623c-4923-aed9-2a43a5db9190"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("809564ec-a66f-49f6-94e1-e5f43adc72d6"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("fbc4bd67-9505-43c1-9adb-9e5330aeff69"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("f2709176-df0c-4578-85ac-172fc2ac053d"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("6ea2292f-6951-4525-a202-d1758d2770d0"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("941ea7ac-8f75-4a4c-b7cd-bd5eb79a4554"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("e742780b-6ec0-45d3-8689-34dce242ec92"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("61c4deaf-623e-4a16-bf1a-9e412e2f3a0a"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("eccc7abf-5c67-42f2-a9b4-703af9bb0392"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("302aab16-c20a-44b4-a4ae-3c20ee8a2f58"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("87db6e6e-d6fa-415c-af65-6101da4e8640"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("ac8a6ad5-6e91-48d2-850a-72be4cc52b04"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("664204f1-59f2-4dc4-9269-18a25667340f"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("cd6d941a-5f58-4189-927a-078219004abd"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("d40cfd68-4d92-471b-8a3d-bece0467f0d8"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("dfd87593-a024-4dd5-bdb8-7b2db774973e"));
            taniOzelDurum = (ITTListBoxColumn)AddControl(new Guid("d84b2834-464e-417b-a7a3-d73cd9a4b503"));
            taniCokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("ae4b39ee-8024-4645-8668-132de5b18f4b"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("3ee1d4a0-9e59-47b8-8522-1fe2140a9dd7"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("d819b151-45e3-4f7e-be71-9d31dc24ef60"));
            ttPrintRequestBarcode = (ITTButton)AddControl(new Guid("a149b382-7549-4253-93c6-4c0f56262c1f"));
            ttBarcodePreviewCheck = (ITTCheckBox)AddControl(new Guid("31b3512c-a118-4058-8da3-976c7808a491"));
            Acil = (ITTCheckBox)AddControl(new Guid("1ac6e9d8-bc26-42f7-8188-30d5477dca2d"));
            base.InitializeControls();
        }

        public RadiologyTestProcedureForm() : base("RADIOLOGYTEST", "RadiologyTestProcedureForm")
        {
        }

        protected RadiologyTestProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}