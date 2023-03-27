
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
    /// Radyoloji Onay Formu
    /// </summary>
    public partial class RadiologyTestApproveForm : RadiologyTestBaseForm
    {
    /// <summary>
    /// Radyoloji Tetkik
    /// </summary>
        protected TTObjectClasses.RadiologyTest _RadiologyTest
        {
            get { return (TTObjectClasses.RadiologyTest)_ttObject; }
        }

        protected ITTCheckBox ttMasterResourceUserCheck;
        protected ITTButton cmdReport;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox OwnerType;
        protected ITTObjectListBox cityOfBirth;
        protected ITTEnumComboBox encboSex;
        protected ITTObjectListBox ttobjectlistbox1;
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
        protected ITTButtonColumn tanCokluOzelDurum;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTObjectListBox TTListBoxDrAnesteziTescilNo;
        protected ITTObjectListBox TTListBox;
        protected ITTObjectListBox TTListBoxKesi;
        protected ITTButton cmdSaveAndPrint;
        protected ITTLabel ttlabel4;
        protected ITTTextBox Description;
        protected ITTLabel ttlabel5;
        protected ITTRichTextBoxControl rtfReport;
        protected ITTLabel ttlabel2;
        protected ITTDateTimePicker TestDate;
        protected ITTLabel ttlabel10;
        protected ITTObjectListBox Equipment;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox Deparment;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel11;
        protected ITTTextBox TestTechnicianNote;
        protected ITTLabel ttlabelKesi;
        protected ITTTextBox tttextboxBirim;
        protected ITTLabel ttlabelBirim;
        protected ITTLabel ttlabelSagSol;
        protected ITTLabel ttlabelDrAnesteziTescilNo;
        protected ITTTextBox DisTaahhutNo;
        protected ITTLabel labelDisTaahhutNo;
        protected ITTButton ttbuttonToothSchema;
        protected ITTTabPage tttabpage2;
        protected ITTLabel ttlabel3;
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
        protected ITTObjectListBox ReportedBy;
        protected ITTLabel ttlabel8;
        protected ITTObjectListBox ApprovedBy;
        protected ITTLabel ttlabel12;
        protected ITTDateTimePicker PatientBirthDate;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel17;
        protected ITTLabel ttlabel18;
        protected ITTLabel ttlabel19;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage tabAnamnez;
        protected ITTTextBox PREDIAGNOSIS;
        protected ITTTabPage tabDescription;
        protected ITTTextBox CommonDescription;
        protected ITTTabPage tabAdditionalRequest;
        protected ITTTextBox tttextbox4;
        override protected void InitializeControls()
        {
            ttMasterResourceUserCheck = (ITTCheckBox)AddControl(new Guid("685539bb-4fdf-47d0-822f-029db56f56b2"));
            cmdReport = (ITTButton)AddControl(new Guid("d6bac2d0-6432-455c-a80e-7e000ea36d7e"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("90e872f8-04a5-4074-b834-9fbcd2501730"));
            OwnerType = (ITTTextBox)AddControl(new Guid("c7a61e18-bd99-48d4-9f40-73add3e58d44"));
            cityOfBirth = (ITTObjectListBox)AddControl(new Guid("cab5da70-8f2b-49a5-adf5-269426daa189"));
            encboSex = (ITTEnumComboBox)AddControl(new Guid("f2f385b0-3242-44a7-aa7a-fd1bb72d99da"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("07f8741d-52d5-4a43-9de1-685a709c671d"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("0c29982e-61d5-4f95-ae74-d7aa10ef4b4e"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("426996f8-54bf-46e7-a027-503e3e691d46"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("5c3e656a-3a28-4106-8455-8bae950a8226"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("ceea6370-a4d6-4305-a9ae-fc5df82dfd7b"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("ce7424ca-ab06-48f8-b21f-07acb57f27f2"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("e46bb7f3-e86b-47f8-8bf3-745edb01b506"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("6a8ca189-e301-454c-b3ee-d07de66f7bd3"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("ddf0022d-98ee-4f8b-a01c-aef2e9631c19"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("4c5579c8-d5cd-4043-ad2b-284e1bf5b104"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("9c3c0cfc-ca2a-4ab0-a474-4125134fc587"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("9ae3a2de-4be6-4def-9d13-256778ca61a5"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("bf10f24c-25dc-4361-bb29-36de86b8117c"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("eb3c1d22-fe09-41ae-8e1a-4a38cdb44dda"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("ede2f3c0-230e-4107-8a01-b3f5df270b24"));
            taniOzelDurum = (ITTListBoxColumn)AddControl(new Guid("c0f4994a-efa9-46c2-b612-46977b2001f0"));
            tanCokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("8481b6a8-2c4b-49ac-8ee0-72deaefe34bf"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("9150fb04-2f2a-4f23-9a0e-524528ed7e4c"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("3d53457d-f14b-4d8b-b64b-493928a1a850"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("6a82f692-8473-4473-aeba-b911a44cd73a"));
            TTListBoxDrAnesteziTescilNo = (ITTObjectListBox)AddControl(new Guid("0a1ed580-0587-4dc9-9e4a-4dc1561a64e7"));
            TTListBox = (ITTObjectListBox)AddControl(new Guid("77dacbc6-4e69-4006-8593-9feaa301e038"));
            TTListBoxKesi = (ITTObjectListBox)AddControl(new Guid("5e03c89b-3155-405f-9f47-48de142e4eb4"));
            cmdSaveAndPrint = (ITTButton)AddControl(new Guid("829287fb-9be1-45a1-a996-e594c8764392"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("a55b9c04-6aa8-405d-9a27-ef14c35e8642"));
            Description = (ITTTextBox)AddControl(new Guid("cd8d3cde-f43f-4db3-83cf-74bda1d04f12"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("48100183-b7da-422c-9a17-255323ee87ed"));
            rtfReport = (ITTRichTextBoxControl)AddControl(new Guid("e49eeade-6570-4be5-b073-335128c622dc"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e3037f03-1af2-4e9a-9b65-3231ee442858"));
            TestDate = (ITTDateTimePicker)AddControl(new Guid("ea32c13d-3798-44a0-8bfe-e424a53dbba5"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("25904353-5da1-4774-a283-2e2a42b36806"));
            Equipment = (ITTObjectListBox)AddControl(new Guid("61c3e2b4-868c-4098-97e7-463bb296c8df"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("ff7a2bbe-db5b-4b0f-8559-be7d5122306f"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("43706092-ea5f-43fb-9fd4-3ded1a11b4b9"));
            Deparment = (ITTObjectListBox)AddControl(new Guid("1033c6be-5d03-4ae1-915a-bad8af389895"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f3a137b9-3ad3-4b00-93fb-57d66b4b9306"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("6bc964b2-a1f8-43c7-bfc4-7a54423c5951"));
            TestTechnicianNote = (ITTTextBox)AddControl(new Guid("534626ea-1938-481d-b4b5-d33ebbca0811"));
            ttlabelKesi = (ITTLabel)AddControl(new Guid("88b1ae7d-2d8a-44be-a47c-f5f90f3c0211"));
            tttextboxBirim = (ITTTextBox)AddControl(new Guid("f66d66d7-8017-42fd-8b62-72939c80c513"));
            ttlabelBirim = (ITTLabel)AddControl(new Guid("7a095872-99f1-469c-991a-fac05079950a"));
            ttlabelSagSol = (ITTLabel)AddControl(new Guid("51cbe438-3347-47bc-8c7d-56b53af83c9a"));
            ttlabelDrAnesteziTescilNo = (ITTLabel)AddControl(new Guid("70b3ba9f-068d-4fc0-b6ee-5e6503a09296"));
            DisTaahhutNo = (ITTTextBox)AddControl(new Guid("ed01c5c9-3906-436d-a0d3-0353f27b5e28"));
            labelDisTaahhutNo = (ITTLabel)AddControl(new Guid("d5fd2473-86f4-426a-92fa-5667d495177d"));
            ttbuttonToothSchema = (ITTButton)AddControl(new Guid("cdc1750e-2716-4641-9106-813c67dd073e"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("02db0626-d06e-4e62-8136-128080bbfc67"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("1d9816d5-9002-4efd-b645-31af0dcc3857"));
            Materials = (ITTGrid)AddControl(new Guid("0956af20-c8dc-4b3a-85ca-bacf460ed615"));
            Material = (ITTListBoxColumn)AddControl(new Guid("efb49cee-a6b8-479d-bd72-7be2d999c3d1"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("0a9a211c-220f-4d40-bac1-36d8dc26a16d"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("cf3d2ff8-fc68-464e-8645-2ede33fc4b9b"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("1387e712-d791-45bc-8289-88a9702af511"));
            kodsuzMalzemeFiyati = (ITTTextBoxColumn)AddControl(new Guid("229a3cd8-6577-4b6e-a11b-59fcb928cb88"));
            malzemeTuru = (ITTListBoxColumn)AddControl(new Guid("a656e3fd-99d3-434b-bf80-6a9fb839f8d0"));
            kdv = (ITTTextBoxColumn)AddControl(new Guid("7bd9bf85-8607-4017-bea0-33fea0f54049"));
            malzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("70897a08-2b3f-471d-94e2-49d08db0340b"));
            malzemeSatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("82979225-0ab0-44e7-baf4-f171d7d7449e"));
            malzemeOzelDurum = (ITTListBoxColumn)AddControl(new Guid("1f497672-f763-4333-823b-78194252beeb"));
            malzemeCokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("fc7accfc-880e-4775-b502-cc8f91c9c33b"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("07ca2b8f-f5f2-438f-a0f2-448765353462"));
            SurgeryDirectPurchaseGrids = (ITTGrid)AddControl(new Guid("3a9a063d-4a29-4367-b582-888d3bbd2994"));
            DPADetailFirmPriceOffer = (ITTListBoxColumn)AddControl(new Guid("e7fc87e7-25c7-458b-93f2-068c0bf1cf04"));
            txtBarcode = (ITTTextBoxColumn)AddControl(new Guid("4d521bc3-268a-4eec-a0d0-55de44c9e5b6"));
            txtKesinlesenMiktar = (ITTTextBoxColumn)AddControl(new Guid("3e80868b-307a-4305-a8cb-1455b2a6dfa3"));
            ReportedBy = (ITTObjectListBox)AddControl(new Guid("fe223278-c00a-4320-a040-6dd703d02bf7"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("379db71f-70a9-42c2-a62d-cf665d1799dc"));
            ApprovedBy = (ITTObjectListBox)AddControl(new Guid("7d2f15be-6875-4d0b-a301-5d0f9e4a3e55"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("254234d0-f935-4ea1-a454-e80d11b35067"));
            PatientBirthDate = (ITTDateTimePicker)AddControl(new Guid("0bb71834-5742-44a5-9f03-5a3ed516631e"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("83c65d75-0e57-4cf9-81dc-0aa03133028e"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("db9501f5-4342-4886-b65b-f59b2272c2af"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("9d7ea310-d3b9-43ff-b027-7871df54cb60"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("d5b6c1f5-f826-4c34-a142-4ab83cf558ca"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("e8a20b40-9206-4ad6-ae7e-540cf1ee86e4"));
            tabAnamnez = (ITTTabPage)AddControl(new Guid("5b8b83c4-4809-4889-9f16-54b5c8d1963a"));
            PREDIAGNOSIS = (ITTTextBox)AddControl(new Guid("c131c36f-9f53-43d5-a3ee-0388e882cade"));
            tabDescription = (ITTTabPage)AddControl(new Guid("d486128b-4171-426e-8111-c9a0d9fd12ec"));
            CommonDescription = (ITTTextBox)AddControl(new Guid("902f8f01-5d2a-4141-abd3-88a96e634ea3"));
            tabAdditionalRequest = (ITTTabPage)AddControl(new Guid("ed884f24-6de3-4027-b0f0-064d47bccf5a"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("013a10e8-6b97-444f-9c66-cab34f46c431"));
            base.InitializeControls();
        }

        public RadiologyTestApproveForm() : base("RADIOLOGYTEST", "RadiologyTestApproveForm")
        {
        }

        protected RadiologyTestApproveForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}