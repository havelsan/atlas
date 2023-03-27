
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
    /// Paket Hizmet Giriş
    /// </summary>
    public partial class PackageAddingForm : EpisodeActionForm
    {
    /// <summary>
    /// Paket Hizmet Girişi
    /// </summary>
        protected TTObjectClasses.PackageAdding _PackageAdding
        {
            get { return (TTObjectClasses.PackageAdding)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid GridPackageProcedure;
        protected ITTDateTimePickerColumn PActionDate;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTTextBoxColumn PAmount;
        protected ITTListBoxColumn PSubEpisode;
        protected ITTDateTimePickerColumn PStartDate;
        protected ITTDateTimePickerColumn PEndDate;
        protected ITTTextBoxColumn DiscountPercent;
        protected ITTListBoxColumn PBrans;
        protected ITTListBoxColumn PDoktor;
        protected ITTListBoxColumn PAyniFarkliKesi;
        protected ITTListBoxColumn PSagSol;
        protected ITTEnumComboBoxColumn PEuroScore;
        protected ITTTextBoxColumn PRaporTakipNo;
        protected ITTTextBoxColumn PRefakatciGunSayisi;
        protected ITTTextBoxColumn PBirim;
        protected ITTTextBoxColumn PSonuc;
        protected ITTTextBoxColumn PAciklama;
        protected ITTListBoxColumn POzelDurum;
        protected ITTListBoxColumn PAnesteziDoktor;
        protected ITTTabPage tttabpage2;
        protected ITTObjectListBox PackageSubEpisode;
        protected ITTLabel ttlabel16;
        protected ITTButton btnAddSPP;
        protected ITTGroupBox MedulaInfo;
        protected ITTEnumComboBox MedulaEuroScore;
        protected ITTLabel ttlabel15;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel1;
        protected ITTTextBox RefakatciGunSayisi;
        protected ITTTextBox Sonuc;
        protected ITTTextBox RaporTakipNo;
        protected ITTTextBox Birim;
        protected ITTTextBox Aciklama;
        protected ITTObjectListBox AnesteziDoktor;
        protected ITTObjectListBox OzelDurum;
        protected ITTObjectListBox SagSol;
        protected ITTObjectListBox AyniFarkliKesi;
        protected ITTObjectListBox Doktor;
        protected ITTObjectListBox Brans;
        protected ITTLabel AnesteziDoktorLbl;
        protected ITTLabel OzelDurumLbl;
        protected ITTLabel RefakatciGunSayısıLbl;
        protected ITTLabel SonucLbl;
        protected ITTLabel RaporTakipNoLbl;
        protected ITTLabel BirimLbl;
        protected ITTLabel AciklamaLbl;
        protected ITTLabel SagSolLbl;
        protected ITTLabel EuroScoreLbl;
        protected ITTLabel AyniFarkliKesiLbl;
        protected ITTLabel DoktorLbl;
        protected ITTLabel BransLbl;
        protected ITTTextBox DISCOUNTPRCNT;
        protected ITTDateTimePicker ENDDATE;
        protected ITTDateTimePicker STARTDATE;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox ProcedureDefinition;
        protected ITTLabel labelProcedureDefinition;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("d940b6f0-72fd-4714-99ca-188137eff59e"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("4d63bb9f-8c3c-430f-bcdf-0c8dd727b552"));
            GridPackageProcedure = (ITTGrid)AddControl(new Guid("c480a811-7073-47e9-8841-6d9e0469ed23"));
            PActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("72c88a60-e284-4b49-a8a5-70901dd04078"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("ba04c859-9d63-4801-9608-98011b847e39"));
            PAmount = (ITTTextBoxColumn)AddControl(new Guid("7874ac57-31b3-434d-878a-1728f320bc9a"));
            PSubEpisode = (ITTListBoxColumn)AddControl(new Guid("0ed44df1-5d86-4321-b0cc-9e1befd14148"));
            PStartDate = (ITTDateTimePickerColumn)AddControl(new Guid("b964c490-beed-4185-8b11-55167af0a4fa"));
            PEndDate = (ITTDateTimePickerColumn)AddControl(new Guid("09ea70d4-bddd-437f-ac51-a988779314bf"));
            DiscountPercent = (ITTTextBoxColumn)AddControl(new Guid("31da312d-a954-4719-944d-687b48c579a4"));
            PBrans = (ITTListBoxColumn)AddControl(new Guid("559fd043-89d1-428e-83ab-02c5b0f82868"));
            PDoktor = (ITTListBoxColumn)AddControl(new Guid("a545159e-a0ca-46a8-a922-921560a4709a"));
            PAyniFarkliKesi = (ITTListBoxColumn)AddControl(new Guid("e73f1f41-da5d-427c-b6ef-086f2c1ba56f"));
            PSagSol = (ITTListBoxColumn)AddControl(new Guid("5fad91f2-b026-4dac-ae82-672e1423bed1"));
            PEuroScore = (ITTEnumComboBoxColumn)AddControl(new Guid("c367f9df-9dc1-4382-90c0-b30968cdb34d"));
            PRaporTakipNo = (ITTTextBoxColumn)AddControl(new Guid("7feda840-4ac0-4256-a27a-1c413aac3ed5"));
            PRefakatciGunSayisi = (ITTTextBoxColumn)AddControl(new Guid("96ec7594-b529-4ff4-8651-78dbf8f7d2fe"));
            PBirim = (ITTTextBoxColumn)AddControl(new Guid("9a358b48-3be1-4d2c-a4e3-3b61e86c41b1"));
            PSonuc = (ITTTextBoxColumn)AddControl(new Guid("38ac2727-9f48-4ac5-a753-261712c12ede"));
            PAciklama = (ITTTextBoxColumn)AddControl(new Guid("cfeff5f8-843c-4d56-9494-8b19481fddc6"));
            POzelDurum = (ITTListBoxColumn)AddControl(new Guid("bbd9e9b3-373a-41f0-a4b2-0f1c17f62a4b"));
            PAnesteziDoktor = (ITTListBoxColumn)AddControl(new Guid("363c5c94-38ed-47f3-b7e5-a415719bb32c"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("3ceaa9be-b605-41e8-9dc0-6e7c6fff057f"));
            PackageSubEpisode = (ITTObjectListBox)AddControl(new Guid("808bff42-2124-485b-a122-bf77e0171980"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("439b33be-5aa8-401a-95cb-19a5cb69683e"));
            btnAddSPP = (ITTButton)AddControl(new Guid("1e155752-cb86-4603-941b-6dd7eceea403"));
            MedulaInfo = (ITTGroupBox)AddControl(new Guid("1d3a3605-843a-49cd-ba36-a3e0df60f367"));
            MedulaEuroScore = (ITTEnumComboBox)AddControl(new Guid("064a0f5f-ae35-458d-8ca7-f191ffd4edd8"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("4dec9379-99bc-4c8e-959f-fce0f43edc83"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("5b60fb61-079b-44c1-9eda-a7f62027b8aa"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("717e2eb9-0a86-464e-9b9f-d14b2fffd7fe"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("ef861a1e-01f6-429c-8a5e-d339c0f67c0b"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("2d767b3a-75fe-4274-9d31-4f79cdfa5462"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("6b488aef-7f37-49c4-be45-34365e6cd56d"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("4f0c1919-70bb-44cf-a35f-4ab51aa75953"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("ae7bd408-9030-4e08-a1de-653dbbe7fba2"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("97bd17c7-4cf8-48bf-bbfb-50104693bdf9"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("f1ac922e-ec34-4255-a25c-0f34b6929f6c"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("4b1560e0-364f-4e1e-a4ac-786cfe2ba8ad"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d2144720-1ef7-438f-8afa-932b6b931988"));
            RefakatciGunSayisi = (ITTTextBox)AddControl(new Guid("25ac0fcc-817f-48ac-bb58-1b837cab1c38"));
            Sonuc = (ITTTextBox)AddControl(new Guid("3ac3d79d-5cbf-4127-9335-af710211394d"));
            RaporTakipNo = (ITTTextBox)AddControl(new Guid("37d379b8-08bd-40eb-9efa-9573f01c4a60"));
            Birim = (ITTTextBox)AddControl(new Guid("7e8850dd-8871-464c-95cd-2859c3d58937"));
            Aciklama = (ITTTextBox)AddControl(new Guid("3141544e-ea2d-44e3-9c4e-553e20c72c75"));
            AnesteziDoktor = (ITTObjectListBox)AddControl(new Guid("053536e8-7348-4fbf-a066-ca2ab088dff9"));
            OzelDurum = (ITTObjectListBox)AddControl(new Guid("c76c95a2-7cdf-4c13-9485-7552d56b07f0"));
            SagSol = (ITTObjectListBox)AddControl(new Guid("f664b414-ba45-4417-917a-d3016f8f4d25"));
            AyniFarkliKesi = (ITTObjectListBox)AddControl(new Guid("807da687-381e-45c6-8243-e4f12a75dc33"));
            Doktor = (ITTObjectListBox)AddControl(new Guid("4de9d776-4507-4156-b87d-29d2d13b2d34"));
            Brans = (ITTObjectListBox)AddControl(new Guid("2c9120a2-7c55-4fce-b80e-9ea04e2ebc0e"));
            AnesteziDoktorLbl = (ITTLabel)AddControl(new Guid("fa753a13-1d0f-42b7-b60a-e728c7d328ba"));
            OzelDurumLbl = (ITTLabel)AddControl(new Guid("9497f373-f44c-4f13-8d34-88fbc1b99ff0"));
            RefakatciGunSayısıLbl = (ITTLabel)AddControl(new Guid("c1dc0412-277f-4c12-8af3-1127d21b286d"));
            SonucLbl = (ITTLabel)AddControl(new Guid("2c4bd979-5265-419e-a68f-d45b0d0a57ae"));
            RaporTakipNoLbl = (ITTLabel)AddControl(new Guid("b16f6820-dd2a-46bc-b8f1-e2137ab40549"));
            BirimLbl = (ITTLabel)AddControl(new Guid("fe31cb97-f7ec-4c68-8ad0-cd93edefe950"));
            AciklamaLbl = (ITTLabel)AddControl(new Guid("31798e09-2888-4e9a-b2c9-4f692015a269"));
            SagSolLbl = (ITTLabel)AddControl(new Guid("515c93c0-0ab7-43de-8ebe-01d885061ab9"));
            EuroScoreLbl = (ITTLabel)AddControl(new Guid("805ff8b7-8aca-4dde-9bc8-528ef9b4f8ad"));
            AyniFarkliKesiLbl = (ITTLabel)AddControl(new Guid("da21fdc0-39dc-4815-8657-5ed6b69648bd"));
            DoktorLbl = (ITTLabel)AddControl(new Guid("08436afe-a6b7-44c9-81cd-884b7309dc78"));
            BransLbl = (ITTLabel)AddControl(new Guid("96075f85-491b-4c83-a250-1aab3bb4b3da"));
            DISCOUNTPRCNT = (ITTTextBox)AddControl(new Guid("858e693f-692a-4dc3-a47c-2a3bc280e62e"));
            ENDDATE = (ITTDateTimePicker)AddControl(new Guid("8200e752-bcfb-4c2b-ad72-3dd1e81ff087"));
            STARTDATE = (ITTDateTimePicker)AddControl(new Guid("1a80ab10-3ab6-4504-ab7a-777b2a97fd73"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("7bc82fcc-60ca-4976-a9ee-8ee806bc6703"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("cae781df-fa1c-4c04-b6fe-c80ee1d4efad"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("b7bcf967-16a1-4d1e-85d9-5cc3926c9cc0"));
            ProcedureDefinition = (ITTObjectListBox)AddControl(new Guid("1e7f3a19-f49f-424e-b0d3-8df33353a2e9"));
            labelProcedureDefinition = (ITTLabel)AddControl(new Guid("2ff71e82-58fe-44be-a601-768712abdd9f"));
            base.InitializeControls();
        }

        public PackageAddingForm() : base("PACKAGEADDING", "PackageAddingForm")
        {
        }

        protected PackageAddingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}