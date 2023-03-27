
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
    public partial class MHRSRandevuPlanSorgulamaFormu : TTUnboundForm
    {
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tabXXXXXXPlanSorgula;
        protected ITTLabel ttlabel1;
        protected ITTGrid gridSchedule;
        protected ITTTextBoxColumn txtPoliclinic;
        protected ITTTextBoxColumn txtDoktor;
        protected ITTTextBoxColumn txtBaslangicTarihi;
        protected ITTTextBoxColumn txtBitisTarihi;
        protected ITTCheckBoxColumn chkKesinlesti;
        protected ITTRichTextBoxControlColumn txtKesinlesmeHatasi;
        protected ITTButton btnExcel;
        protected ITTDateTimePicker startTime;
        protected ITTDateTimePicker endTime;
        protected ITTObjectListBox listDoctor;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox lstPoliclinic;
        protected ITTButton btnAllSchedule;
        protected ITTButton btnUncertainedSchedule;
        protected ITTLabel ttlabel3;
        protected ITTTabPage tttabpage1;
        protected ITTButton btnEntegre;
        protected ITTGrid gridMHRSPlanlari;
        protected ITTTextBoxColumn txtMHRSBaslangicTarihi;
        protected ITTTextBoxColumn txtMHRSBitisTarihi;
        protected ITTTextBoxColumn txtMHRSPoliklinik;
        protected ITTTextBoxColumn txtXXXXXXDurumu;
        protected ITTTextBoxColumn txtEntegrasyonDurumu;
        protected ITTTextBoxColumn txtTalakCetvelID;
        protected ITTTextBoxColumn txtKesinCetvelID;
        protected ITTTextBoxColumn txtKlinikKodu;
        protected ITTTextBoxColumn txtTedaviSuresi;
        protected ITTTextBoxColumn txtAksiyonKodu;
        protected ITTTextBoxColumn txtAltKlinikKodu;
        protected ITTTextBoxColumn txtTaslakID;
        protected ITTButton btnListele;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox listEntegrasyonDoktor;
        protected ITTDateTimePicker entegrasyonBitisTarihi;
        protected ITTDateTimePicker entegrasyonBaslangicTarihi;
        protected ITTTabPage tabAltKlinikSorgulama;
        protected ITTGrid gridAltKlinik;
        protected ITTTextBoxColumn txtAltKlinikKlinik;
        protected ITTTextBoxColumn txtAltKlinikAltKlinik;
        protected ITTButton btnAltKlinikAktar;
        protected ITTButton btnAltKlinikSorgula;
        protected ITTTabPage tabKlinikKodlariveHekimIslemleri;
        protected ITTGrid gridMHRSHekim;
        protected ITTTextBoxColumn txtHekimEklePoliklinik;
        protected ITTTextBoxColumn txtHekimEkleHekim;
        protected ITTTextBoxColumn txtHekimEkleBilgi;
        protected ITTButton btnHekimEkle;
        protected ITTGrid gridMHRSyeEklenenPoliklinikler;
        protected ITTTextBoxColumn txtMHRSyeEklenenPoliklinic;
        protected ITTTextBoxColumn txtMHRSyeEklendi;
        protected ITTButton btnKlinikEkle;
        protected ITTGrid gridMHRSyeEklenenAltPoliklinikler;
        protected ITTTextBoxColumn txtMHRSyeEklenenAltPoliklinic;
        protected ITTTextBoxColumn txtMHRSyeEklendiAltKlinik;
        protected ITTButton btnAltKlinikEkle;
        protected ITTGrid gridMHRSPoliklinic;
        protected ITTTextBoxColumn txtMHRSPoliklinic;
        protected ITTTextBoxColumn txtMHRSPoliklinicMHRSClinic;
        protected ITTCheckBoxColumn ckcMHRSyeGonder;
        protected ITTButton btnSetMHRSClinicCode;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("298776e1-3a66-4318-a260-693813df3fd0"));
            tabXXXXXXPlanSorgula = (ITTTabPage)AddControl(new Guid("2b20e781-2a09-42c4-bfb9-584081b6f02f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("1f5f087c-2252-455f-a2ad-c545b6ab0cff"));
            gridSchedule = (ITTGrid)AddControl(new Guid("d62ac699-0bb5-4dad-99d4-9af023f3b4b5"));
            txtPoliclinic = (ITTTextBoxColumn)AddControl(new Guid("9742674d-f4f6-4f8b-9c7d-1bc04a7b3737"));
            txtDoktor = (ITTTextBoxColumn)AddControl(new Guid("aaca3d70-04ea-4390-baf3-f0555893da3f"));
            txtBaslangicTarihi = (ITTTextBoxColumn)AddControl(new Guid("8361fa1e-72b4-46fb-b155-588717edd2d4"));
            txtBitisTarihi = (ITTTextBoxColumn)AddControl(new Guid("18c163f0-a598-4f17-af92-8424edbfa12d"));
            chkKesinlesti = (ITTCheckBoxColumn)AddControl(new Guid("1fc7b969-a108-430d-af46-813b6675999c"));
            txtKesinlesmeHatasi = (ITTRichTextBoxControlColumn)AddControl(new Guid("83946626-dd0c-4595-ab28-d3941a6a530d"));
            btnExcel = (ITTButton)AddControl(new Guid("44aefed1-0f3b-4285-9351-50063e8daea5"));
            startTime = (ITTDateTimePicker)AddControl(new Guid("5f282f8f-4e77-4b4a-ba51-932b56876971"));
            endTime = (ITTDateTimePicker)AddControl(new Guid("de9aac47-cc4e-4d1e-b0b8-75ad68d7bac5"));
            listDoctor = (ITTObjectListBox)AddControl(new Guid("b07cc87d-c9b6-4574-b892-cd40d4a15b0d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("edea7bcf-4d03-4ff6-baeb-6ca17d76383d"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("734b0116-30c6-4394-92b0-aee01e1430d1"));
            lstPoliclinic = (ITTObjectListBox)AddControl(new Guid("04af37dd-f1ab-424c-afaa-713e8f325123"));
            btnAllSchedule = (ITTButton)AddControl(new Guid("2849e829-1c07-4863-8b18-be2698a8242f"));
            btnUncertainedSchedule = (ITTButton)AddControl(new Guid("dd67159c-bfaa-4290-82b0-8e6a13b5d1ae"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("acd5cda1-11ac-4a06-a217-2c23e524c15f"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("932a1238-f172-4963-846a-4a10ddae1ba5"));
            btnEntegre = (ITTButton)AddControl(new Guid("feee613d-f972-48ef-9d5e-0622c29d901c"));
            gridMHRSPlanlari = (ITTGrid)AddControl(new Guid("54378225-36b3-406f-9786-9c994ed05d94"));
            txtMHRSBaslangicTarihi = (ITTTextBoxColumn)AddControl(new Guid("76c6ab97-0452-464a-b476-b4670bf8815d"));
            txtMHRSBitisTarihi = (ITTTextBoxColumn)AddControl(new Guid("0de5e209-41c0-4b8b-938f-b8b460f81507"));
            txtMHRSPoliklinik = (ITTTextBoxColumn)AddControl(new Guid("5823c217-4469-46d9-afe3-1be5bf1835ac"));
            txtXXXXXXDurumu = (ITTTextBoxColumn)AddControl(new Guid("7e811df2-729c-4721-a928-2d505ee82361"));
            txtEntegrasyonDurumu = (ITTTextBoxColumn)AddControl(new Guid("22942c55-96a8-48fe-ab7c-a2667a14ec57"));
            txtTalakCetvelID = (ITTTextBoxColumn)AddControl(new Guid("63de2c43-84a2-4b10-8a96-bf50b56ad0cc"));
            txtKesinCetvelID = (ITTTextBoxColumn)AddControl(new Guid("f87f7335-860b-4375-9313-43997a57a7c1"));
            txtKlinikKodu = (ITTTextBoxColumn)AddControl(new Guid("7267f827-c2bb-4c0e-a50b-34ba04381b54"));
            txtTedaviSuresi = (ITTTextBoxColumn)AddControl(new Guid("1f5b17b9-bd31-488b-9042-652550109e72"));
            txtAksiyonKodu = (ITTTextBoxColumn)AddControl(new Guid("d64adebf-a81f-4eb3-a658-435072fee37d"));
            txtAltKlinikKodu = (ITTTextBoxColumn)AddControl(new Guid("47d57ccc-ba0b-4678-978c-3787a9810a11"));
            txtTaslakID = (ITTTextBoxColumn)AddControl(new Guid("ae036925-7dc7-4185-bf70-db5abba302d7"));
            btnListele = (ITTButton)AddControl(new Guid("3aaa65d5-edaf-4d5f-8328-f441c679a9c0"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("56c7dc36-cac1-461b-a1f9-cddfeb6e4f7f"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("95a5404e-3c78-4136-a944-d0b5c7569a76"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("12642959-e100-4c23-972d-aad33b93b1c4"));
            listEntegrasyonDoktor = (ITTObjectListBox)AddControl(new Guid("7f7a8fe1-8843-4b6b-a34c-58c3930d4653"));
            entegrasyonBitisTarihi = (ITTDateTimePicker)AddControl(new Guid("2e46a360-fa19-41e9-bb16-67e50e59204b"));
            entegrasyonBaslangicTarihi = (ITTDateTimePicker)AddControl(new Guid("e6712c99-fdc4-4646-bfe7-20787349f563"));
            tabAltKlinikSorgulama = (ITTTabPage)AddControl(new Guid("4e0deffc-ca2a-4725-8cd5-6c1ce8f2e96b"));
            gridAltKlinik = (ITTGrid)AddControl(new Guid("cb18aeca-7779-4721-b985-97bb445feab2"));
            txtAltKlinikKlinik = (ITTTextBoxColumn)AddControl(new Guid("ee0d0f48-de4e-497a-a8a7-24411032631c"));
            txtAltKlinikAltKlinik = (ITTTextBoxColumn)AddControl(new Guid("5fcd12e0-6752-4ab8-8183-917ceecb4e23"));
            btnAltKlinikAktar = (ITTButton)AddControl(new Guid("ff451854-e0bc-4cb1-ac2f-c9ccd3c3592c"));
            btnAltKlinikSorgula = (ITTButton)AddControl(new Guid("f9bd2055-4fcc-481c-9c33-f4dd5e1a2870"));
            tabKlinikKodlariveHekimIslemleri = (ITTTabPage)AddControl(new Guid("5be2bab8-9dd7-413f-be1d-ff7beedc4a9d"));
            gridMHRSHekim = (ITTGrid)AddControl(new Guid("c05d0448-a00c-4706-b77c-25f005d07350"));
            txtHekimEklePoliklinik = (ITTTextBoxColumn)AddControl(new Guid("fc81f480-329b-4671-a496-3114c2b49287"));
            txtHekimEkleHekim = (ITTTextBoxColumn)AddControl(new Guid("43a82eff-5908-4f46-adca-d34b08a7d389"));
            txtHekimEkleBilgi = (ITTTextBoxColumn)AddControl(new Guid("e65d3017-1794-4d60-a057-591070a0cdc5"));
            btnHekimEkle = (ITTButton)AddControl(new Guid("f34564b8-7166-4cf1-8b9e-c1ce78b1456d"));
            gridMHRSyeEklenenPoliklinikler = (ITTGrid)AddControl(new Guid("b394fa65-6747-44e0-a6f7-5dd6ca6ebb00"));
            txtMHRSyeEklenenPoliklinic = (ITTTextBoxColumn)AddControl(new Guid("94bdab6f-78fe-40ba-87a5-aee08caa9d32"));
            txtMHRSyeEklendi = (ITTTextBoxColumn)AddControl(new Guid("c094d947-1682-4be5-b7a7-e5716cb950db"));
            btnKlinikEkle = (ITTButton)AddControl(new Guid("ee38c627-f2ec-4969-a6b6-08f3ff980d73"));
            gridMHRSyeEklenenAltPoliklinikler = (ITTGrid)AddControl(new Guid("b37ab2d2-a394-43af-86eb-41a3f10399cf"));
            txtMHRSyeEklenenAltPoliklinic = (ITTTextBoxColumn)AddControl(new Guid("cc47ad77-6bc2-46ae-958a-9d834b45fc8e"));
            txtMHRSyeEklendiAltKlinik = (ITTTextBoxColumn)AddControl(new Guid("0025df6e-54c7-4fcd-91e5-f5bcc251ad03"));
            btnAltKlinikEkle = (ITTButton)AddControl(new Guid("dcc13a03-42d0-4b71-b443-221218f184f2"));
            gridMHRSPoliklinic = (ITTGrid)AddControl(new Guid("8c4ff181-e208-43b4-8b97-d59120c06308"));
            txtMHRSPoliklinic = (ITTTextBoxColumn)AddControl(new Guid("d2ad0bae-ee4b-4606-8022-e9d143b66558"));
            txtMHRSPoliklinicMHRSClinic = (ITTTextBoxColumn)AddControl(new Guid("bdb7da7b-c644-4e31-b357-b5ea85367c6f"));
            ckcMHRSyeGonder = (ITTCheckBoxColumn)AddControl(new Guid("42908544-d14f-4352-8450-8f77dedf9b31"));
            btnSetMHRSClinicCode = (ITTButton)AddControl(new Guid("b1bae000-3df0-42fe-af37-26d656dbfdf9"));
            base.InitializeControls();
        }

        public MHRSRandevuPlanSorgulamaFormu() : base("MHRSRandevuPlanSorgulamaFormu")
        {
        }

        protected MHRSRandevuPlanSorgulamaFormu(string formDefName) : base(formDefName)
        {
        }
    }
}