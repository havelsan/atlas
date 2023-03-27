
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
    public partial class VaccineApplicationForm : TTForm
    {
        protected TTObjectClasses.VaccineDetails _VaccineDetails
        {
            get { return (TTObjectClasses.VaccineDetails)_ttObject; }
        }

        protected ITTLabel labelSKRSAsininSaglandigiKaynak;
        protected ITTObjectListBox SKRSAsininSaglandigiKaynak;
        protected ITTObjectListBox SKRSKurumlar;
        protected ITTGroupBox ttgroupbox3;
        protected ITTLabel labelSKRSAsiSonrasiIstenmeyenEtki;
        protected ITTObjectListBox SKRSAsiSonrasiIstenmeyenEtki;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelSKRSASIISLEMTURU;
        protected ITTObjectListBox SKRSASIISLEMTURU;
        protected ITTLabel labelSKRSAsiOzelDurumNedeni;
        protected ITTObjectListBox SKRSAsiOzelDurumNedeni;
        protected ITTGroupBox ttgroupbox2;
        protected ITTObjectListBox SKRSAsiKodu;
        protected ITTLabel labelSKRSAsiKodu;
        protected ITTTextBox BildirimDurumu;
        protected ITTTextBox SorguSonucu;
        protected ITTButton ATS_Bildirim;
        protected ITTLabel labelBildirimDurumu;
        protected ITTLabel labelSKRSAsininDozu;
        protected ITTTextBox SorguNumarasi;
        protected ITTObjectListBox SKRSAsininDozu;
        protected ITTLabel labelSorguSonucu;
        protected ITTCheckBox GeziciHizmetMi;
        protected ITTLabel labelAsiKarekodu;
        protected ITTTextBox SeriNumarasi;
        protected ITTLabel labelSorguNumarasi;
        protected ITTTextBox AsiKarekodu;
        protected ITTTextBox KirilimBilgisi;
        protected ITTTextBox PartiNumarasi;
        protected ITTButton ATS_Sorgula;
        protected ITTLabel labelAsininSonKullanmaTarihi;
        protected ITTDateTimePicker AsininSonKullanmaTarihi;
        protected ITTTextBox Barkod;
        protected ITTLabel labelSeriNumarasi;
        protected ITTLabel labelKirilimBilgisi;
        protected ITTLabel labelBarkod;
        protected ITTLabel labelPartiNumarasi;
        protected ITTDateTimePicker ApplicationDate;
        protected ITTLabel labelVaccineState;
        protected ITTLabel labelApplicationDate;
        protected ITTEnumComboBox VaccineState;
        protected ITTLabel labelDate;
        protected ITTLabel labelDisMerkez;
        protected ITTDateTimePicker Date;
        protected ITTLabel labelResUser;
        protected ITTTextBox DisMerkez;
        protected ITTLabel labelResUser1;
        protected ITTObjectListBox ResUser;
        protected ITTObjectListBox ResUser1;
        protected ITTTextBox Notes;
        protected ITTLabel labelAsiAntiSerumuKarekodu;
        protected ITTLabel labelAsiSulandiriciKarekodu;
        protected ITTObjectListBox SKRSAsininUygulamaSekli;
        protected ITTLabel labelSKRSAsininUygulamaSekli;
        protected ITTCheckBox DisMerkezMi;
        protected ITTLabel labelNotes;
        protected ITTObjectListBox SKRSAsiUygulamaYeri;
        protected ITTTextBox AsiSulandiriciKarekodu;
        protected ITTLabel labelSKRSAsiUygulamaYeri;
        protected ITTTextBox AsiAntiSerumuKarekodu;
        protected ITTGroupBox GroupSeperator1;
        protected ITTLabel labelSKRSAsiYapilmamaNedeni;
        protected ITTObjectListBox SKRSAsiYapilmamaNedeni;
        protected ITTLabel labelSKRSAsiYapilmamaDurumu;
        protected ITTObjectListBox SKRSAsiYapilmamaDurumu;
        protected ITTLabel labelVaccinePostponeTime;
        protected ITTTextBox VaccinePostponeTime;
        override protected void InitializeControls()
        {
            labelSKRSAsininSaglandigiKaynak = (ITTLabel)AddControl(new Guid("4a9d173a-5796-48ae-a2d4-7ed2d0a60357"));
            SKRSAsininSaglandigiKaynak = (ITTObjectListBox)AddControl(new Guid("b49b14c8-0cdc-4814-9ab5-57bb78fc7b69"));
            SKRSKurumlar = (ITTObjectListBox)AddControl(new Guid("6b5aad08-8dec-4821-b74b-7cba5d7cee35"));
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("89bdbbf1-89ba-4e4b-80c7-51215d8ab0fb"));
            labelSKRSAsiSonrasiIstenmeyenEtki = (ITTLabel)AddControl(new Guid("ca353d23-b3d6-49d4-8edd-c7eda0582799"));
            SKRSAsiSonrasiIstenmeyenEtki = (ITTObjectListBox)AddControl(new Guid("41c9129e-f9b0-4e7d-9377-e51a5e938738"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("7e3f3d37-4aeb-447a-b5f3-bceb02142b4d"));
            labelSKRSASIISLEMTURU = (ITTLabel)AddControl(new Guid("ed709e59-b8fc-4aa1-a7aa-edb6d2d82aa8"));
            SKRSASIISLEMTURU = (ITTObjectListBox)AddControl(new Guid("3afb327b-ecff-46e0-83d4-c8314e073bfa"));
            labelSKRSAsiOzelDurumNedeni = (ITTLabel)AddControl(new Guid("e2ff83c2-14ee-4720-82d6-313ec8654a7c"));
            SKRSAsiOzelDurumNedeni = (ITTObjectListBox)AddControl(new Guid("391ccfda-f7e2-454a-a8b0-766fcdacdd14"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("1047098c-1528-4b65-9e6d-31d43cc3d790"));
            SKRSAsiKodu = (ITTObjectListBox)AddControl(new Guid("674d5b7e-fc34-496b-909c-9ded59bfb35f"));
            labelSKRSAsiKodu = (ITTLabel)AddControl(new Guid("164d624a-f871-4558-906e-688123c7e268"));
            BildirimDurumu = (ITTTextBox)AddControl(new Guid("80b6e87a-af42-4562-a315-427e20e7fa03"));
            SorguSonucu = (ITTTextBox)AddControl(new Guid("9b1be4a1-5f35-4c04-b80c-74380c5cc5ae"));
            ATS_Bildirim = (ITTButton)AddControl(new Guid("d0418fab-66b3-49a4-b3e1-b482c7ffedc0"));
            labelBildirimDurumu = (ITTLabel)AddControl(new Guid("b0d17659-2515-4e39-af89-15cc7fc2479b"));
            labelSKRSAsininDozu = (ITTLabel)AddControl(new Guid("32cadd61-4e8e-4f1c-94e9-ef20af3b252d"));
            SorguNumarasi = (ITTTextBox)AddControl(new Guid("309cd5f9-c7e8-4810-b34b-4284d1d8760f"));
            SKRSAsininDozu = (ITTObjectListBox)AddControl(new Guid("a011aefe-5e8f-46d7-8522-0085e804a8f2"));
            labelSorguSonucu = (ITTLabel)AddControl(new Guid("e69220b0-fe23-40f8-b62a-3114cc2fc59e"));
            GeziciHizmetMi = (ITTCheckBox)AddControl(new Guid("f8cbebda-a22b-4b18-91b6-86c6c4ba9f06"));
            labelAsiKarekodu = (ITTLabel)AddControl(new Guid("100bd579-cf0a-44a3-beba-ccc3b8eddf98"));
            SeriNumarasi = (ITTTextBox)AddControl(new Guid("2a076d2e-8660-41e8-957a-04dbc94ebc7e"));
            labelSorguNumarasi = (ITTLabel)AddControl(new Guid("98491903-05de-41c5-b98b-9b2649ed51e9"));
            AsiKarekodu = (ITTTextBox)AddControl(new Guid("77b4875b-2810-4b76-bde1-2193a235cfbc"));
            KirilimBilgisi = (ITTTextBox)AddControl(new Guid("04d30c25-61aa-4878-88aa-9d55be54bf70"));
            PartiNumarasi = (ITTTextBox)AddControl(new Guid("92f7487e-9e47-4c40-90eb-849ed41acf48"));
            ATS_Sorgula = (ITTButton)AddControl(new Guid("f84dfa8f-b065-482f-8587-5461e22b497e"));
            labelAsininSonKullanmaTarihi = (ITTLabel)AddControl(new Guid("fc3b193a-6290-43ac-b231-749594b190c8"));
            AsininSonKullanmaTarihi = (ITTDateTimePicker)AddControl(new Guid("6c8b5c59-c3b4-41d2-9030-96efb34be9bf"));
            Barkod = (ITTTextBox)AddControl(new Guid("7f7612a9-c99f-45c3-82a3-9ac60fe2be22"));
            labelSeriNumarasi = (ITTLabel)AddControl(new Guid("6991b541-a1f1-4bb5-adfb-97f00c115c7f"));
            labelKirilimBilgisi = (ITTLabel)AddControl(new Guid("efc71160-74fe-4122-bd3b-411a383f54c0"));
            labelBarkod = (ITTLabel)AddControl(new Guid("5c204d97-2ec7-4faf-ace1-f2750b003135"));
            labelPartiNumarasi = (ITTLabel)AddControl(new Guid("6f4fccd7-3546-439a-a1ac-9003e69de8e8"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("953877d7-4c0a-46f9-908d-52a8725505ad"));
            labelVaccineState = (ITTLabel)AddControl(new Guid("6aa9f125-94c6-426a-a7ae-a7b433480a64"));
            labelApplicationDate = (ITTLabel)AddControl(new Guid("ab339b7f-7dd7-49e8-9527-3d0c0a9a50d0"));
            VaccineState = (ITTEnumComboBox)AddControl(new Guid("2428c19b-2411-446c-8983-5322c6cd2ea2"));
            labelDate = (ITTLabel)AddControl(new Guid("86018b26-588f-4d16-8d0e-df9fc33eb219"));
            labelDisMerkez = (ITTLabel)AddControl(new Guid("56d4882f-2f30-47e1-9dbc-7bc9944e02bd"));
            Date = (ITTDateTimePicker)AddControl(new Guid("d9cd4865-a750-4b4b-9dbb-eb56dc2375aa"));
            labelResUser = (ITTLabel)AddControl(new Guid("294366ce-4638-42b6-8ee5-ea2ba038f00c"));
            DisMerkez = (ITTTextBox)AddControl(new Guid("b778c375-de64-4f2f-8dee-5006edee8c74"));
            labelResUser1 = (ITTLabel)AddControl(new Guid("2c74732d-c030-4025-8cf9-1d1c87ddfce6"));
            ResUser = (ITTObjectListBox)AddControl(new Guid("5693d409-c602-4eab-bfdd-abfe8c246e59"));
            ResUser1 = (ITTObjectListBox)AddControl(new Guid("04f35076-770c-404f-8edf-6045a37321b4"));
            Notes = (ITTTextBox)AddControl(new Guid("6693ad44-a68c-44ed-a2e9-626f5b517ed2"));
            labelAsiAntiSerumuKarekodu = (ITTLabel)AddControl(new Guid("27c17d27-6bb1-497a-8745-8beb0f09dbe6"));
            labelAsiSulandiriciKarekodu = (ITTLabel)AddControl(new Guid("db6573bb-d6b3-48ce-815c-dc7b49782e53"));
            SKRSAsininUygulamaSekli = (ITTObjectListBox)AddControl(new Guid("39c73d97-95cc-4803-9e97-58d6b154252a"));
            labelSKRSAsininUygulamaSekli = (ITTLabel)AddControl(new Guid("221ddebc-ef04-4ddb-a962-555e36cb0578"));
            DisMerkezMi = (ITTCheckBox)AddControl(new Guid("54fafe56-e38b-45b2-b2b2-e07d80d2f335"));
            labelNotes = (ITTLabel)AddControl(new Guid("a3725569-c506-499c-9b45-ae198aae4eba"));
            SKRSAsiUygulamaYeri = (ITTObjectListBox)AddControl(new Guid("25cc5e0f-d3af-41d7-b6de-dcd10841a2c6"));
            AsiSulandiriciKarekodu = (ITTTextBox)AddControl(new Guid("d3d28bd5-fb99-4d0e-8493-84ee8f953713"));
            labelSKRSAsiUygulamaYeri = (ITTLabel)AddControl(new Guid("bf9756df-643f-4315-b2c2-c837ca04f7ba"));
            AsiAntiSerumuKarekodu = (ITTTextBox)AddControl(new Guid("629446bb-f8c0-45ab-bcbf-ff78f77522a0"));
            GroupSeperator1 = (ITTGroupBox)AddControl(new Guid("fc2966bc-e77b-485c-94c2-939d5b77285c"));
            labelSKRSAsiYapilmamaNedeni = (ITTLabel)AddControl(new Guid("6cfce6da-2915-4f94-bf05-7b29b8cca0e8"));
            SKRSAsiYapilmamaNedeni = (ITTObjectListBox)AddControl(new Guid("4ec5a317-a05b-438f-a10f-aaad940a621d"));
            labelSKRSAsiYapilmamaDurumu = (ITTLabel)AddControl(new Guid("fbbc1acc-a0dd-4bb4-8800-33b7230b6165"));
            SKRSAsiYapilmamaDurumu = (ITTObjectListBox)AddControl(new Guid("cf2b1cfe-684b-4ea1-a5b6-70788146793f"));
            labelVaccinePostponeTime = (ITTLabel)AddControl(new Guid("df990e12-e864-4f72-93b4-12af2d2e4877"));
            VaccinePostponeTime = (ITTTextBox)AddControl(new Guid("bc1c7388-4864-4864-a93d-9bb80c16c4c3"));
            base.InitializeControls();
        }

        public VaccineApplicationForm() : base("VACCINEDETAILS", "VaccineApplicationForm")
        {
        }

        protected VaccineApplicationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}