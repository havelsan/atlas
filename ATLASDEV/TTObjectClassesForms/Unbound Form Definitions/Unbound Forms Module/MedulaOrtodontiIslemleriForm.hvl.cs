
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
    /// Medula Ortodonti İşlemleri
    /// </summary>
    public partial class MedulaOrtodontiIslemleri : TTUnboundForm
    {
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage ttabOrtodontiIslemleri;
        protected ITTGroupBox groupboxOrtodontiIslemTuru;
        protected ITTGroupBox groupboxOrtodontiRaporBilgileri;
        protected ITTTextBox txtFormNumarasi;
        protected ITTLabel ttlabel6;
        protected ITTTabControl tttabSearchBenchMarks;
        protected ITTTabPage OrtodontiKaydet;
        protected ITTLabel txtSonucKodu;
        protected ITTTextBox txtSonucKodu1;
        protected ITTLabel ttlabel10;
        protected ITTTextBox txtSonucMesaji;
        protected ITTButton buttonOrtodontiKaydet;
        protected ITTLabel ttlabel8;
        protected ITTDateTimePicker IslemTarihi;
        protected ITTGrid gridHastaAktifTakipleri;
        protected ITTTextBoxColumn txtTakipNo1;
        protected ITTTextBoxColumn txtBrans1;
        protected ITTTextBoxColumn txtProvizyonTarihi1;
        protected ITTTextBoxColumn txtBasvuruNumarasi1;
        protected ITTTextBoxColumn txtXXXXXXProtocolNo1;
        protected ITTTextBoxColumn txtVakaAcilisTarihi1;
        protected ITTTextBoxColumn txtBransKodu1;
        protected ITTTabPage OrtodontiOku;
        protected ITTButton butttonOrtodontiFormuSil;
        protected ITTTextBox txtTesis3;
        protected ITTLabel ttlabel23;
        protected ITTDateTimePicker IslemTarihi3;
        protected ITTLabel ttlabel22;
        protected ITTLabel ttlabel21;
        protected ITTTextBox txtProvizyonNo3;
        protected ITTTextBox txtTesis2;
        protected ITTLabel ttlabel20;
        protected ITTDateTimePicker IslemTarihi2;
        protected ITTLabel ttlabel19;
        protected ITTLabel ttlabel18;
        protected ITTTextBox txtProvizyonNo2;
        protected ITTLabel ttlabel17;
        protected ITTTextBox txtTesis1;
        protected ITTLabel ttlabel16;
        protected ITTDateTimePicker IslemTarihi1;
        protected ITTLabel ttlabel15;
        protected ITTTextBox txtProvizyonNo1;
        protected ITTLabel ttlabel14;
        protected ITTTextBox txtSonucMesaji2;
        protected ITTLabel ttlabel13;
        protected ITTTextBox txtSonucKodu2;
        protected ITTLabel ttlabel12;
        protected ITTTextBox txtIslemTuru;
        protected ITTButton butttonOrtodontiFormuOku;
        protected ITTObjectListBox lstSUTKodu;
        protected ITTLabel ttlabel7;
        protected ITTCheckBox chkTCKimlikNoIleSorgula;
        protected ITTCheckBox chkOrtodontiKaydet;
        protected ITTButton cmdSearchPatient;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel5;
        protected ITTTextBox txtSex;
        protected ITTLabel ttlabel4;
        protected ITTTextBox txtBirthDate;
        protected ITTLabel lblKimlikNo;
        protected ITTTextBox txtTCKNo;
        protected ITTLabel ttlabel2;
        protected ITTTextBox txtSurname;
        protected ITTLabel ttlabel1;
        protected ITTTextBox txtName;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("77e9c37e-d98d-479a-b009-0b9c8c7f12a4"));
            ttabOrtodontiIslemleri = (ITTTabPage)AddControl(new Guid("a0abe4b2-966f-4ed0-ba9f-b16d988aa53d"));
            groupboxOrtodontiIslemTuru = (ITTGroupBox)AddControl(new Guid("5244d3a5-794b-4e66-a1b3-d15fec8b8285"));
            groupboxOrtodontiRaporBilgileri = (ITTGroupBox)AddControl(new Guid("fd59401a-81ab-4696-8c87-d3c6d988ac8f"));
            txtFormNumarasi = (ITTTextBox)AddControl(new Guid("3275e891-be61-4115-9519-882f63fd75e4"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("4051b4c2-4be3-4727-9f9e-25e93535e837"));
            tttabSearchBenchMarks = (ITTTabControl)AddControl(new Guid("62b7a2c3-d31a-4c6f-9642-4fb451c99234"));
            OrtodontiKaydet = (ITTTabPage)AddControl(new Guid("d36b810a-60e3-47b4-8582-c556bbf36f2c"));
            txtSonucKodu = (ITTLabel)AddControl(new Guid("6d5cb291-0443-4077-879d-70336ae2105d"));
            txtSonucKodu1 = (ITTTextBox)AddControl(new Guid("9693f9bf-5771-4b26-b658-ce1516931e1a"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("af4a1393-c653-4a78-8169-caa5effc25c1"));
            txtSonucMesaji = (ITTTextBox)AddControl(new Guid("b087b233-b85e-4ac6-a4be-7dc13a65958e"));
            buttonOrtodontiKaydet = (ITTButton)AddControl(new Guid("0af9c2cd-d737-4220-b1d1-0b194d8908bf"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("da35b6ba-8950-46b1-8add-2db68e9a3e43"));
            IslemTarihi = (ITTDateTimePicker)AddControl(new Guid("7af49e70-d38c-40c9-8c06-3629e03b30ed"));
            gridHastaAktifTakipleri = (ITTGrid)AddControl(new Guid("c5bb16b6-b7b3-4b8a-aaa6-44e8b2c60ee7"));
            txtTakipNo1 = (ITTTextBoxColumn)AddControl(new Guid("3e7c0821-da9a-42df-b551-ec330ec47043"));
            txtBrans1 = (ITTTextBoxColumn)AddControl(new Guid("cac99e6f-af96-4f00-a136-22e6418351f4"));
            txtProvizyonTarihi1 = (ITTTextBoxColumn)AddControl(new Guid("0d3c93f5-4bea-49fe-ab31-3e565bef2abc"));
            txtBasvuruNumarasi1 = (ITTTextBoxColumn)AddControl(new Guid("eca7f87b-a29c-4d70-aa40-e8fdfd242897"));
            txtXXXXXXProtocolNo1 = (ITTTextBoxColumn)AddControl(new Guid("41460100-f9fe-4ff0-bf23-d0e34715d695"));
            txtVakaAcilisTarihi1 = (ITTTextBoxColumn)AddControl(new Guid("de1e751b-4d81-4674-bd13-c77d539ce2ea"));
            txtBransKodu1 = (ITTTextBoxColumn)AddControl(new Guid("81601bd9-3401-4d77-a14d-b1acd4d35b06"));
            OrtodontiOku = (ITTTabPage)AddControl(new Guid("b16f3223-006c-495f-8dcd-4a8eab4f5859"));
            butttonOrtodontiFormuSil = (ITTButton)AddControl(new Guid("4b8b5dcd-703a-41eb-86ba-c81522f4afa3"));
            txtTesis3 = (ITTTextBox)AddControl(new Guid("22a1fd80-ce5e-45cf-8799-60a742f2d786"));
            ttlabel23 = (ITTLabel)AddControl(new Guid("3bdf0852-e9ac-4214-a06b-da37faf0bfac"));
            IslemTarihi3 = (ITTDateTimePicker)AddControl(new Guid("126e9082-fcb1-4ba6-96b0-a234e6bdaa6c"));
            ttlabel22 = (ITTLabel)AddControl(new Guid("e6408963-70f9-4e9d-96ca-a0fc2e70690c"));
            ttlabel21 = (ITTLabel)AddControl(new Guid("19826993-2321-4b79-b6a4-409aa7e3cfcd"));
            txtProvizyonNo3 = (ITTTextBox)AddControl(new Guid("4d143765-08d6-4cb8-9de1-55506b1ddebf"));
            txtTesis2 = (ITTTextBox)AddControl(new Guid("7f46aa00-e0d6-48dd-968f-9b321eb83a3d"));
            ttlabel20 = (ITTLabel)AddControl(new Guid("3faf79cf-254c-47fe-91a4-2e2cb2e63d19"));
            IslemTarihi2 = (ITTDateTimePicker)AddControl(new Guid("77634525-26af-4d17-9c43-727eb4f9d66a"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("de6007c9-c051-4352-88a6-a220826acac1"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("e9d5747d-826f-4cf4-9b76-de830d843c0f"));
            txtProvizyonNo2 = (ITTTextBox)AddControl(new Guid("b3df7c5e-d1c7-4f3a-98a2-7399ebc6940f"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("10f1959a-b575-448a-bd50-e15af0580d43"));
            txtTesis1 = (ITTTextBox)AddControl(new Guid("d2cf760f-a19b-4474-9ebf-30eb6688b197"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("9e2bc3f9-3ada-421c-865a-a1a3c0beec7a"));
            IslemTarihi1 = (ITTDateTimePicker)AddControl(new Guid("4e72f306-e949-410a-a5d6-5e0104e78cef"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("5159df58-670b-43a5-91b0-9d25e72f1b1d"));
            txtProvizyonNo1 = (ITTTextBox)AddControl(new Guid("7dadee28-3989-44dd-90bc-e994cdd72625"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("c75b20e6-2cd7-47cb-a88a-a87217784a88"));
            txtSonucMesaji2 = (ITTTextBox)AddControl(new Guid("7a930aa3-3d7d-47da-9388-ec67a12c3c6b"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("ff06db32-1a10-4181-b594-1420875f39d5"));
            txtSonucKodu2 = (ITTTextBox)AddControl(new Guid("b635bc8f-f96f-4a0c-b243-2ab545cb9bac"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("5ac38686-296b-4b4f-bd86-0aefb2efffb0"));
            txtIslemTuru = (ITTTextBox)AddControl(new Guid("b85d7d66-c1e0-476d-86be-d7c400d7439f"));
            butttonOrtodontiFormuOku = (ITTButton)AddControl(new Guid("c362e021-903f-4163-89a9-43bf6b241c49"));
            lstSUTKodu = (ITTObjectListBox)AddControl(new Guid("111fda22-b50e-437b-9687-c0efed56062e"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("1e285817-857b-4569-834d-f6e4cf3ac362"));
            chkTCKimlikNoIleSorgula = (ITTCheckBox)AddControl(new Guid("97a3b2d6-62f7-483f-9795-df5767f05816"));
            chkOrtodontiKaydet = (ITTCheckBox)AddControl(new Guid("3c234def-841e-4985-9766-a01c6e4fa93c"));
            cmdSearchPatient = (ITTButton)AddControl(new Guid("7d4f1a83-2c60-4533-9247-664022b44af4"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("f40b31d0-2ffa-4e85-8c94-70972dffec04"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("9ce672f3-e55b-4c09-b2ef-d13d0e4a1147"));
            txtSex = (ITTTextBox)AddControl(new Guid("32fc0b76-9821-4f42-babc-b5cb140e2c0d"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("f6f677ad-7174-4bb7-ae51-ebbe632f6d47"));
            txtBirthDate = (ITTTextBox)AddControl(new Guid("9facf9e2-c11d-44a8-9ea7-a9c8855f3a0a"));
            lblKimlikNo = (ITTLabel)AddControl(new Guid("44238fa8-3bf5-4ad9-be02-ecb3ae4a3859"));
            txtTCKNo = (ITTTextBox)AddControl(new Guid("0fcd4d4b-2676-4a51-ad1e-7987f59ff34a"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("55193147-2ca9-4788-b8dc-24cf8f78aefa"));
            txtSurname = (ITTTextBox)AddControl(new Guid("aa40d48a-3d6a-4029-95e0-eb46ddd25ce6"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("fa240b6f-5d52-452f-9741-d4bd94aca5d7"));
            txtName = (ITTTextBox)AddControl(new Guid("65a14c5e-e67b-4982-990f-dbf953f27f33"));
            base.InitializeControls();
        }

        public MedulaOrtodontiIslemleri() : base("MedulaOrtodontiIslemleri")
        {
        }

        protected MedulaOrtodontiIslemleri(string formDefName) : base(formDefName)
        {
        }
    }
}