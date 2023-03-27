
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
    /// Nükleer Tıp Onayda Formu
    /// </summary>
    public partial class NuclearMedicineApproveForm : EpisodeActionForm
    {
    /// <summary>
    /// Nükleer Tıp
    /// </summary>
        protected TTObjectClasses.NuclearMedicine _NuclearMedicine
        {
            get { return (TTObjectClasses.NuclearMedicine)_ttObject; }
        }

        protected ITTTabControl TABNuclearMedicine;
        protected ITTTabPage TabPageMaterial;
        protected ITTGrid GridNuclearMedicineMaterial;
        protected ITTDateTimePickerColumn MaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn Note;
        protected ITTDateTimePickerColumn malzemeSatinAlisTarihi;
        protected ITTTextBoxColumn kodsuzMalzemeFiyatı;
        protected ITTListBoxColumn malzemeTuru;
        protected ITTTextBoxColumn kdv;
        protected ITTTextBoxColumn malzemeBrans;
        protected ITTListBoxColumn malzemeOzelDurum;
        protected ITTButtonColumn malzemeCokluOzelDurum;
        protected ITTTextBoxColumn barkod;
        protected ITTTabPage RadPharmMatTab;
        protected ITTGrid ttgrid2;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn1;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTCheckBoxColumn IsInjection;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTListBoxColumn Unit;
        protected ITTTabPage tttabpage4;
        protected ITTGrid SurgeryDirectPurchaseGrids;
        protected ITTListBoxColumn DPADetailFirmPriceOffer;
        protected ITTTextBoxColumn txtBarcode;
        protected ITTTextBoxColumn txtKesinlesenMiktar;
        protected ITTTabPage tttabpage6;
        protected ITTGrid NuclearMedicine_RadyofarmasotikDirectPurchaseGrids;
        protected ITTListBoxColumn DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid;
        protected ITTTabPage tttabpage5;
        protected ITTGrid DirectPurchaseGrids;
        protected ITTListBoxColumn MaterialDirectPurchaseGrid;
        protected ITTTextBoxColumn AmountDirectPurchaseGrid;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel17;
        protected ITTObjectListBox TTListBox;
        protected ITTButton cmdReport;
        protected ITTLabel ttlabel16;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTTextBox tttextbox3;
        protected ITTLabel ttlabel5;
        protected ITTTextBox nucMedSelectedTesttxt;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnoseType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTListBoxColumn taniOzelDurum;
        protected ITTButtonColumn taniCokluOzelDurum;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox PREDIAGNOSIS;
        protected ITTTabPage tttabpage2;
        protected ITTTextBox RADIOPHARMACYDESC;
        protected ITTTabPage NUCMEDDOCTORNOTE;
        protected ITTTextBox tttextbox1;
        protected ITTTabPage tttabpage3;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel15;
        protected ITTDateTimePicker PatientBirthDate;
        protected ITTTextBox PatientBirthPlace;
        protected ITTCheckBox IsEmergency;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel13;
        protected ITTEnumComboBox PATIENTGROUPENUM;
        protected ITTObjectListBox REQUESTDOCTOR;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel8;
        protected ITTDateTimePicker ActionDate;
        protected ITTTextBox REQUESTDOCTORPHONE;
        protected ITTDateTimePicker ProcedureDate;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel12;
        protected ITTTextBox PATIENTPHONENUMBER;
        protected ITTLabel ttlabel11;
        protected ITTTextBox PATIENTWEIGHT;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox RESPONSIBLEDOCTOR;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker InjectionDate;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelProcessTime;
        override protected void InitializeControls()
        {
            TABNuclearMedicine = (ITTTabControl)AddControl(new Guid("a2f40ce3-67b9-4336-992f-070bf2b29ad5"));
            TabPageMaterial = (ITTTabPage)AddControl(new Guid("ba04db91-590d-4492-b624-293ac84f78fc"));
            GridNuclearMedicineMaterial = (ITTGrid)AddControl(new Guid("0705f842-2395-4366-83fd-ec2fd7963583"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("70eb525c-3523-4985-9fe6-1d98593e33fb"));
            Material = (ITTListBoxColumn)AddControl(new Guid("29c6e1c0-fe96-4487-8b08-148f221211b7"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("44cf3df7-6e6a-43b1-8062-bf79c2399df6"));
            Note = (ITTTextBoxColumn)AddControl(new Guid("2ff270a7-d049-4334-85dc-f32941cdb829"));
            malzemeSatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("234251b7-2c39-47bb-8bf2-87a3d9f32960"));
            kodsuzMalzemeFiyatı = (ITTTextBoxColumn)AddControl(new Guid("cc944647-4013-422b-a9e3-343052c71cf1"));
            malzemeTuru = (ITTListBoxColumn)AddControl(new Guid("67c647a0-572b-49f3-9a69-3a04017534dc"));
            kdv = (ITTTextBoxColumn)AddControl(new Guid("b28e1546-cb19-4dc9-92cd-a9f89a11905e"));
            malzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("db14ae0d-c7d0-42e8-89b6-7ba31a7b5db4"));
            malzemeOzelDurum = (ITTListBoxColumn)AddControl(new Guid("8cb74c3a-71fc-4d50-9d48-1eb368710ad3"));
            malzemeCokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("84e069cc-0c68-47de-9f3f-bf48d6cdbd1b"));
            barkod = (ITTTextBoxColumn)AddControl(new Guid("01cc25e8-4caf-44ae-b9a6-a9b7e1cb9982"));
            RadPharmMatTab = (ITTTabPage)AddControl(new Guid("145d08d6-ffad-4b8c-aa9a-517466414581"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("06a5d953-ca71-49e5-a77e-8d7896705b6f"));
            ttdatetimepickercolumn1 = (ITTDateTimePickerColumn)AddControl(new Guid("dc2c7eab-7416-4a23-98f6-fcc15880c7c0"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("34eb3ecc-10d0-4a55-a088-248b2daf7a56"));
            IsInjection = (ITTCheckBoxColumn)AddControl(new Guid("d0015a5d-a117-45e7-8d1c-72b0e6089b3b"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("c4f1433f-f720-4a27-bd3e-a7e5811da9ed"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("169871a6-906c-45e2-81f4-fc3ac734295d"));
            Unit = (ITTListBoxColumn)AddControl(new Guid("8ab69c46-4b1d-49d8-868d-60ee5dafc698"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("97cb4abf-d7e8-47d7-bff4-913d4e8cc1a8"));
            SurgeryDirectPurchaseGrids = (ITTGrid)AddControl(new Guid("28c8ecf2-f314-45ff-9b8a-a68b850b027f"));
            DPADetailFirmPriceOffer = (ITTListBoxColumn)AddControl(new Guid("84013cd9-2152-4f94-9ab0-da8d79faad73"));
            txtBarcode = (ITTTextBoxColumn)AddControl(new Guid("ed096df4-740b-4497-9c6a-fe4fa7a4a65a"));
            txtKesinlesenMiktar = (ITTTextBoxColumn)AddControl(new Guid("bc64a6a6-5ddb-425d-a138-fef4aa9ba1e1"));
            tttabpage6 = (ITTTabPage)AddControl(new Guid("392eb1d5-99e6-45d7-a5c3-7b6244e4a1fd"));
            NuclearMedicine_RadyofarmasotikDirectPurchaseGrids = (ITTGrid)AddControl(new Guid("00ea4d61-a815-4719-98f5-66154d2555e9"));
            DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid = (ITTListBoxColumn)AddControl(new Guid("2af5c7ab-e505-4a5f-b983-664a200e1efe"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("22a86f42-01c2-4c18-b6c7-0b273b1e9401"));
            DirectPurchaseGrids = (ITTGrid)AddControl(new Guid("68074aa8-9f79-4935-a582-8a6df23eabb4"));
            MaterialDirectPurchaseGrid = (ITTListBoxColumn)AddControl(new Guid("a6c0d9d7-94c6-472f-a4cf-73a5cef35ded"));
            AmountDirectPurchaseGrid = (ITTTextBoxColumn)AddControl(new Guid("d2439488-de9e-444c-8f4d-e81483c83564"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("a8bb2809-5bb8-4607-9470-e8fb11a4a675"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("3ad97320-d3fd-4c48-90d6-14e7d6ef4cad"));
            TTListBox = (ITTObjectListBox)AddControl(new Guid("5b4cd86c-9f96-4555-a6eb-69fb333a26d2"));
            cmdReport = (ITTButton)AddControl(new Guid("68d97ab0-33de-471f-8961-cf1311e5b00d"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("8a696e37-a518-40bf-bbc5-94d16d9792dc"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("0ccbb787-9e39-4935-a468-8ded39b4419a"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("1ff4c84f-d087-4c40-8fd9-99f377e5ad72"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("c549d957-46b7-4582-98b9-6477a161b221"));
            nucMedSelectedTesttxt = (ITTTextBox)AddControl(new Guid("54fa76b4-73f0-44b0-84a7-fc54e25fc229"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("cfc57128-bc99-4d60-883f-f5e4e9911a64"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("b5e4dfe9-3e65-49fd-95f2-050483fcfdd2"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("a11588d8-396a-4ac2-99c7-131e24659385"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("b99119e5-1f32-451d-afc4-e427ddf3cf5b"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("e5169f7c-a29f-497b-9967-a2362babd855"));
            EpisodeDiagnoseType = (ITTEnumComboBoxColumn)AddControl(new Guid("0c9ef10a-b301-4bdf-a0f4-6a405dd259d2"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("bfc53141-60ee-45bd-a06d-4d453457087e"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("2b3435c0-a073-4d6b-88af-c071a366670b"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("cc15b587-925b-458d-a80d-d7a44f895042"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("9b32760e-eb40-4b5a-a9eb-422be06a50ff"));
            taniOzelDurum = (ITTListBoxColumn)AddControl(new Guid("a6162823-a730-4b13-8fda-e4f976b799c6"));
            taniCokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("551327ac-20c6-4b38-8b97-480d3845bb14"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("b608cbd5-9b86-4ad1-b298-9554eb249e8f"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("96175dc5-4387-41b2-8b97-523c24375ad0"));
            PREDIAGNOSIS = (ITTTextBox)AddControl(new Guid("86c49522-cb5c-49e7-9e2f-26d090d4dd0e"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("a6720946-0bd5-4645-b49d-8b1d947e4261"));
            RADIOPHARMACYDESC = (ITTTextBox)AddControl(new Guid("30bf118c-9d59-4b81-9d72-d55ec021feaa"));
            NUCMEDDOCTORNOTE = (ITTTabPage)AddControl(new Guid("9d5eeaee-2fde-4a0d-a79e-dd5e244572e7"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("3a4b2c05-af8e-4da2-8989-b133eae598f2"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("83902a55-c699-43dc-856c-c6c48168575c"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("11ec106e-7688-4332-b08c-e2470b731d07"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("9a681358-b061-49e2-8abd-8f3dc7b2bf5d"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("3f911406-de36-47a2-a8ee-0d806797a442"));
            PatientBirthDate = (ITTDateTimePicker)AddControl(new Guid("473044e3-8e39-4e2b-8883-e980201ad370"));
            PatientBirthPlace = (ITTTextBox)AddControl(new Guid("db70f9c1-0f0d-4a9b-9a09-af5bbfc15574"));
            IsEmergency = (ITTCheckBox)AddControl(new Guid("0ab835ce-1c2c-49f1-bb2f-0c17cb8ce25e"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("e81fc252-82f5-4d3c-aa57-1645f981e682"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("7809945a-8c92-4e82-af89-f2463cee5d3d"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("1671ea74-eb54-41fc-9ebd-821fb953c5f0"));
            REQUESTDOCTOR = (ITTObjectListBox)AddControl(new Guid("8637ab70-2fdc-4a53-bcc0-cc95f1f4803c"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("071e3c20-e1f8-4e0b-8c37-111f0133a132"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("a375b502-ed56-47ef-bda6-c80752ea40c1"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("2028894c-ece5-4a70-86d5-d404cf370aef"));
            REQUESTDOCTORPHONE = (ITTTextBox)AddControl(new Guid("ac9ab205-928a-40be-90fa-695a9a58f4d7"));
            ProcedureDate = (ITTDateTimePicker)AddControl(new Guid("d767c5e1-14ca-40fb-bf15-17768bd10488"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("af2d8d15-f552-4838-93c0-5086474f631c"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("d02760fa-3909-40c9-bdbb-3560bca1852f"));
            PATIENTPHONENUMBER = (ITTTextBox)AddControl(new Guid("96efe1ad-2a6d-486a-9005-557cc850c7a9"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("9289b436-1e20-49f5-a776-95d606d497ea"));
            PATIENTWEIGHT = (ITTTextBox)AddControl(new Guid("f1bec7cf-a4bd-427e-8bd5-79e3c38afabd"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("5756b02d-b165-4eab-bc47-b336961ef690"));
            RESPONSIBLEDOCTOR = (ITTObjectListBox)AddControl(new Guid("b2f860fd-8551-4840-9b75-919731ffef46"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("dd5fcf29-d847-4221-a9c2-53980dc843ac"));
            InjectionDate = (ITTDateTimePicker)AddControl(new Guid("03474dfb-7946-4cc6-9044-b539f0b80e1c"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("12644ded-5c2d-4139-b2ae-c6a1a37cc3dc"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("4edb7aef-2c49-4100-b373-0e3d639f028a"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("148fffaf-eeb7-43e1-9b93-0e09ae73dd35"));
            base.InitializeControls();
        }

        public NuclearMedicineApproveForm() : base("NUCLEARMEDICINE", "NuclearMedicineApproveForm")
        {
        }

        protected NuclearMedicineApproveForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}