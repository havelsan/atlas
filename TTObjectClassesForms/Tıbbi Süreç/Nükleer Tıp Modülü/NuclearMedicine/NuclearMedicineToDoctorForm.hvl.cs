
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
    /// Nükleer Tıp Doktorda Formu
    /// </summary>
    public partial class NuclearMedicineToDoctorForm : EpisodeActionForm
    {
    /// <summary>
    /// Nükleer Tıp
    /// </summary>
        protected TTObjectClasses.NuclearMedicine _NuclearMedicine
        {
            get { return (TTObjectClasses.NuclearMedicine)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTCheckBox ttMasterResourceUserCheck;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox RESPONSIBLEDOCTOR;
        protected ITTButton cmdReport;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox3;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage3;
        protected ITTRichTextBoxControl RTFREPORT;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox PREDIAGNOSIS;
        protected ITTTabPage tttabpage2;
        protected ITTTextBox RADIOPHARMACYDESC;
        protected ITTTabPage tttabpage4;
        protected ITTTextBox NUCMEDDOCTORNOTE;
        protected ITTTextBox nucMedSelectedTesttxt;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnoseType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTextBox tttextbox1;
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
        protected ITTObjectListBox PROCEDUREDOCTOR;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker InjectionDate;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelProcessTime;
        protected ITTTabControl TABNuclearMedicine;
        protected ITTTabPage TabPageMaterial;
        protected ITTGrid GridNuclearMedicineMaterial;
        protected ITTDateTimePickerColumn MaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Note;
        protected ITTTextBoxColumn Amount;
        protected ITTDateTimePickerColumn malzemeSatinAlisTarihi;
        protected ITTTextBoxColumn kodsuzMalzemeFiyati;
        protected ITTTextBoxColumn kdv;
        protected ITTListBoxColumn malzemeTuru;
        protected ITTTextBoxColumn malzemeBrans;
        protected ITTListBoxColumn malzemeOzelDurum;
        protected ITTTabPage RadPharmMatTab;
        protected ITTGrid ttgrid2;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn1;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTTextBoxColumn DistributionType;
        protected ITTCheckBoxColumn IsInjection;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTListBoxColumn Unit;
        protected ITTTabPage TabMedulaBilgileri;
        protected ITTLabel ttlabelDrAnesteziTescilNo;
        protected ITTObjectListBox TTListBoxDrAnesteziTescilNo;
        protected ITTObjectListBox TTListBoxOzelDurum;
        protected ITTGrid ttgridCokluOzelDurum;
        protected ITTListBoxColumn ttenumcomboboxCokluOzelDurum;
        protected ITTLabel labelOzelDurum;
        protected ITTLabel ttlabel18;
        protected ITTLabel ttlabelSagSol;
        protected ITTLabel ttlabel16;
        protected ITTObjectListBox TTListBoxSagSol;
        protected ITTTextBox tttextboxBirim;
        protected ITTObjectListBox TTListBoxKesi;
        protected ITTTextBox Description;
        protected ITTLabel ttlabelBirim;
        protected ITTTabPage tttabpage5;
        protected ITTGrid SurgeryDirectPurchaseGrids;
        protected ITTListBoxColumn DPADetailFirmPriceOffer;
        protected ITTTextBoxColumn txtBarcode;
        protected ITTTextBoxColumn txtKesinlesenMiktar;
        protected ITTTabPage tttabpage6;
        protected ITTGrid NuclearMedicine_RadyofarmasotikDirectPurchaseGrids;
        protected ITTListBoxColumn DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid;
        protected ITTTabPage tttabpage7;
        protected ITTGrid DirectPurchaseGrids;
        protected ITTListBoxColumn MaterialDirectPurchaseGrid;
        protected ITTTextBoxColumn AmountDirectPurchaseGrid;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("51ee40f8-6e99-4295-aae0-be08ca97f15b"));
            ttMasterResourceUserCheck = (ITTCheckBox)AddControl(new Guid("3f5ebb76-a54c-4543-80d3-4bc684184660"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("fc41d411-97f1-4287-acef-96991dafcdc7"));
            RESPONSIBLEDOCTOR = (ITTObjectListBox)AddControl(new Guid("dceeca80-30fc-45e3-b706-40f9b80b4e3e"));
            cmdReport = (ITTButton)AddControl(new Guid("8db0164a-ee20-4352-acc7-1dfa13143bd4"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("2547fbc0-967f-4c8b-973e-2a7761dbdda1"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b651c066-942c-49e0-bae3-9b9a731fabf1"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("08317de1-8d32-4671-a786-aaa0c6f135f7"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("e66f110c-faf6-4f12-8365-ad4711ccffeb"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("1eecc867-0779-4a22-9943-0c30f3042bd9"));
            RTFREPORT = (ITTRichTextBoxControl)AddControl(new Guid("a7c01352-ed5a-4823-94fb-8a682a36b50a"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("654acc9a-3be2-4d92-a97f-d5d2a5c83d36"));
            PREDIAGNOSIS = (ITTTextBox)AddControl(new Guid("efb35673-c447-4118-ae49-b292b2a7bba0"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("5b6dc6dd-2442-4bb5-a784-ff57fb5c232e"));
            RADIOPHARMACYDESC = (ITTTextBox)AddControl(new Guid("f581ea89-ea69-4582-8999-c2162275ee57"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("4dde3a03-5d0c-4d23-b2e5-0c952b5e00c5"));
            NUCMEDDOCTORNOTE = (ITTTextBox)AddControl(new Guid("22314dd2-1e3e-4c60-bf46-58b725c452c7"));
            nucMedSelectedTesttxt = (ITTTextBox)AddControl(new Guid("404984ec-b4b2-4e8b-a57b-8db8631dfb7b"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("ce4767b8-d14b-41dc-98fa-08309ed2b061"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("87429f3e-3818-471c-8bf6-544b4a98c8a2"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("c8d29e4b-18b5-4e48-96b9-959a8c9e25a4"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("947a6378-23a8-43ee-b428-08c3c914862b"));
            EpisodeDiagnoseType = (ITTEnumComboBoxColumn)AddControl(new Guid("3ca99bbf-4c2c-44ab-ac82-5f7774621822"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("cf012964-2c37-41e0-b7b7-857dc29173a7"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("e9470a48-8f61-42ad-b9f8-a226104b09ea"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("5f38b76b-843d-4b50-b88d-dbc7e2147914"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("9bb0121d-8784-47b4-aad3-38b6382650d6"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("02d3d901-8fce-4aad-8c41-07729a9fb3f3"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("eba10456-b287-41a2-b792-042e667da4b0"));
            PatientBirthDate = (ITTDateTimePicker)AddControl(new Guid("1859ef95-98e9-4187-9700-ef3407502c90"));
            PatientBirthPlace = (ITTTextBox)AddControl(new Guid("683c58dd-49e0-4a36-862f-64cf4b813a1f"));
            IsEmergency = (ITTCheckBox)AddControl(new Guid("908a7e65-cfe6-48d0-bbb2-db8311df0a2d"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("b0c37b52-afa0-419a-b8ce-f7283bcf5928"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("fa42f127-7832-4dcd-80b0-b1a5aa6176fc"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("5c364350-0e1e-4fe1-b197-2c462e470954"));
            REQUESTDOCTOR = (ITTObjectListBox)AddControl(new Guid("585771dc-49a4-4fdf-8384-61285599f152"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("d2e4b143-572b-43f9-a657-880a50a2766a"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("4987a33a-e84b-405c-9c20-1aa1cfae9358"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("e68a22a9-c16d-4bd2-9629-7eaf0cc8d23f"));
            REQUESTDOCTORPHONE = (ITTTextBox)AddControl(new Guid("e18375e6-0dd4-4f88-9881-f4ce7f542158"));
            ProcedureDate = (ITTDateTimePicker)AddControl(new Guid("1a3e3293-748d-4df3-8dcd-9d6d6ec35589"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("f19d8474-22d5-402f-8fb8-603d5bcbe310"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("ed087b77-bb32-4c16-9b9d-9a1d29a572eb"));
            PATIENTPHONENUMBER = (ITTTextBox)AddControl(new Guid("439aaa13-6a6f-44e5-a732-dfc880cfaf10"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("f9e46681-6d4d-4149-b932-15f089c77bae"));
            PATIENTWEIGHT = (ITTTextBox)AddControl(new Guid("0b1906dc-247e-4ba4-837e-1a830ca4a4ea"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("044f7da3-ccaa-41d2-b35e-25546acaaf30"));
            PROCEDUREDOCTOR = (ITTObjectListBox)AddControl(new Guid("99d08814-0eca-4b00-8635-b4f6c1f59a35"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("1a26e235-21c7-4afa-9067-441ac6062dd0"));
            InjectionDate = (ITTDateTimePicker)AddControl(new Guid("1ae425d7-5c99-419a-94c6-ae9fe2a0527b"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("f6a9a3d4-0d3f-446d-8fe7-b8a5058c2a1b"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("25552c9a-06b4-4c6b-b5cc-5220cd952c0b"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("aecd15f7-3b0d-4e4d-8a2e-258be3ad30db"));
            TABNuclearMedicine = (ITTTabControl)AddControl(new Guid("59275702-5d01-4736-be09-661f06c27cd1"));
            TabPageMaterial = (ITTTabPage)AddControl(new Guid("ad93eacd-0672-445f-b104-2eac6aa2fa49"));
            GridNuclearMedicineMaterial = (ITTGrid)AddControl(new Guid("130b842e-a476-4fb8-af88-14dd80c7e68a"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("b955b88b-c57a-405f-9671-5bf82c2fbbf8"));
            Material = (ITTListBoxColumn)AddControl(new Guid("bf754dc2-3f83-4421-a038-69da0c10a269"));
            Note = (ITTTextBoxColumn)AddControl(new Guid("c7787ca3-0114-4a06-b1a7-ed5c6e8041c0"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("0af102fa-2083-4e03-85d4-33744198ccc7"));
            malzemeSatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("7be716d8-5450-44d5-88fd-6ae2fad05e6a"));
            kodsuzMalzemeFiyati = (ITTTextBoxColumn)AddControl(new Guid("a0cf00e1-c93d-470c-971b-1a4e153c6ae7"));
            kdv = (ITTTextBoxColumn)AddControl(new Guid("5cc193fb-adaa-499d-a976-352632d2f938"));
            malzemeTuru = (ITTListBoxColumn)AddControl(new Guid("2589be32-b883-4e73-aec7-10231e6730b9"));
            malzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("ea57da01-ef2d-4b21-84a2-343ec8bcb1a3"));
            malzemeOzelDurum = (ITTListBoxColumn)AddControl(new Guid("8305fe59-8ac5-48ec-82f4-0bf720940136"));
            RadPharmMatTab = (ITTTabPage)AddControl(new Guid("1aaa1857-2b65-444c-bfd3-5839dbc32bfc"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("4e3bf7a6-26a4-4017-9bb1-47fb8b749940"));
            ttdatetimepickercolumn1 = (ITTDateTimePickerColumn)AddControl(new Guid("2ec7fb6c-aab2-4435-9e1c-f352d7d95e40"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("fb5978da-382a-49d9-bb61-5888b4e40f14"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("56d5efd5-8136-459c-8fcd-228103761d38"));
            IsInjection = (ITTCheckBoxColumn)AddControl(new Guid("e3a0b046-dd0f-4c15-b619-ff389419614f"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("571a53b5-22df-431e-88c0-f78936e116c1"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("eaf94061-2d54-47c1-907c-6454bf3532cf"));
            Unit = (ITTListBoxColumn)AddControl(new Guid("50cb5840-40fc-4b65-85ac-076f79c9de43"));
            TabMedulaBilgileri = (ITTTabPage)AddControl(new Guid("eaec1556-2889-41ea-bd47-f64a8f9da434"));
            ttlabelDrAnesteziTescilNo = (ITTLabel)AddControl(new Guid("116e8c2f-995c-4f5c-8673-ecd415fd18e6"));
            TTListBoxDrAnesteziTescilNo = (ITTObjectListBox)AddControl(new Guid("c6d8756b-dedd-4da0-8812-8f0f91eee947"));
            TTListBoxOzelDurum = (ITTObjectListBox)AddControl(new Guid("f54d684f-c352-4cf0-aec5-1d5aa0c54d18"));
            ttgridCokluOzelDurum = (ITTGrid)AddControl(new Guid("7fed92ef-e912-4260-a53c-12daef8c7970"));
            ttenumcomboboxCokluOzelDurum = (ITTListBoxColumn)AddControl(new Guid("f8a47c6f-ba20-4df2-b640-afdee6355e91"));
            labelOzelDurum = (ITTLabel)AddControl(new Guid("785921fb-cb29-4c64-8112-f74de68760f7"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("e74e99f1-06e2-4846-b4a4-1f67c4ebd9ca"));
            ttlabelSagSol = (ITTLabel)AddControl(new Guid("147102cb-075e-40fa-a8d8-30de73e8ace3"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("1acbf41d-4b2c-4c4a-b9d9-95cd49e4ac06"));
            TTListBoxSagSol = (ITTObjectListBox)AddControl(new Guid("05e54da1-d62c-44e8-8181-3de6a801d013"));
            tttextboxBirim = (ITTTextBox)AddControl(new Guid("d5f7c34d-1ea6-4d0b-ba67-3cfa36ce957a"));
            TTListBoxKesi = (ITTObjectListBox)AddControl(new Guid("6170eb64-19f1-4264-96ce-0c829cf61a79"));
            Description = (ITTTextBox)AddControl(new Guid("645b95c2-ea3a-4449-adab-ca69909d455b"));
            ttlabelBirim = (ITTLabel)AddControl(new Guid("549387ba-2f3a-4851-aa4e-9ef25c854b30"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("0a7f4edc-d96b-4d24-9514-c181c103482f"));
            SurgeryDirectPurchaseGrids = (ITTGrid)AddControl(new Guid("7cf6abbe-039e-4fd2-9275-10fba57f228e"));
            DPADetailFirmPriceOffer = (ITTListBoxColumn)AddControl(new Guid("bc12b544-ad58-4a55-82f4-b818150ba2c8"));
            txtBarcode = (ITTTextBoxColumn)AddControl(new Guid("5d5840da-b951-424f-adf9-22602a51d60e"));
            txtKesinlesenMiktar = (ITTTextBoxColumn)AddControl(new Guid("615ba75c-40a6-45a8-8bb4-05840f57db7e"));
            tttabpage6 = (ITTTabPage)AddControl(new Guid("2540f3a8-06ca-464a-afd2-ed3819f3795c"));
            NuclearMedicine_RadyofarmasotikDirectPurchaseGrids = (ITTGrid)AddControl(new Guid("4286a753-ccc5-440f-bd25-79b9102043ae"));
            DPADetailFirmPriceOfferRadyofarmasotikDirectPurchaseGrid = (ITTListBoxColumn)AddControl(new Guid("d4b19557-1c58-4946-bfda-667c7a66e0a8"));
            tttabpage7 = (ITTTabPage)AddControl(new Guid("f41af44d-8e08-4e13-a802-942661a664be"));
            DirectPurchaseGrids = (ITTGrid)AddControl(new Guid("969e5e97-039f-4eab-88b9-fac73a93887f"));
            MaterialDirectPurchaseGrid = (ITTListBoxColumn)AddControl(new Guid("8037a7bb-dcda-417d-a9c1-33dc78c5b76e"));
            AmountDirectPurchaseGrid = (ITTTextBoxColumn)AddControl(new Guid("f0d39739-738d-47be-9951-3b4ea6a21374"));
            base.InitializeControls();
        }

        public NuclearMedicineToDoctorForm() : base("NUCLEARMEDICINE", "NuclearMedicineToDoctorForm")
        {
        }

        protected NuclearMedicineToDoctorForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}