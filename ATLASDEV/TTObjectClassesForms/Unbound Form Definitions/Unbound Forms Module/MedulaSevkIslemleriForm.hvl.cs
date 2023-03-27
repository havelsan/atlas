
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
    /// Medula Sevk Işlemleri
    /// </summary>
    public partial class MedulaSevkIslemleri : TTUnboundForm
    {
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabHastayaAitSevkAramaIslemleri;
        protected ITTPanel pnlSearchResult;
        protected ITTPanel ttpanel1;
        protected ITTGrid ttgridHastaSevkListesi;
        protected ITTTextBoxColumn sevkId;
        protected ITTTextBoxColumn tcKimlikNo;
        protected ITTTextBoxColumn sevkTakipNo;
        protected ITTTextBoxColumn protokolNo;
        protected ITTTextBoxColumn sevkEdilenIl;
        protected ITTTextBoxColumn sevkTarihi;
        protected ITTTextBoxColumn sevkVasitasi;
        protected ITTTextBoxColumn sevkNedeni;
        protected ITTTextBoxColumn sevkNedeniAciklama;
        protected ITTTextBoxColumn tedaviTipi;
        protected ITTTextBoxColumn kabulEdenTesis;
        protected ITTTextBoxColumn kabulEdenTakip;
        protected ITTTextBoxColumn sevkEdenBrans;
        protected ITTTextBoxColumn sevkEdenTesis;
        protected ITTButtonColumn SevkSil;
        protected ITTGroupBox ttgroupboxListeleme;
        protected ITTButton btnMedulaSevkListele;
        protected ITTGroupBox ttgroupboxHastaBilgileri;
        protected ITTTextBox txtSex;
        protected ITTTextBox txtName;
        protected ITTTextBox txtSurname;
        protected ITTLabel lblCinsiyeti;
        protected ITTLabel lblHastaSoyadi;
        protected ITTTextBox txtTCKNo;
        protected ITTTextBox txtBirthDate;
        protected ITTLabel lblTCNumarasi;
        protected ITTLabel lblHastaAdi;
        protected ITTLabel lblDogumTarihi;
        protected ITTLabel lblHastaSearchName;
        protected ITTTextBox txtPatientName;
        protected ITTButton cmdSearchPatient;
        protected ITTTabPage tttabSaglikTesisiArama;
        protected ITTPanel ttpanelMedulaSaglikTesisiAraCevap;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelSonucMesaji;
        protected ITTLabel labelSonucKodu;
        protected ITTTextBox tttextboxSonucMesaji;
        protected ITTTextBox tttextboxSonucKodu;
        protected ITTGrid ttgridSaglikTesisleri;
        protected ITTTextBoxColumn TesisIl;
        protected ITTTextBoxColumn TesisAdi;
        protected ITTTextBoxColumn TesisKodu;
        protected ITTTextBoxColumn TesisSinifKodu;
        protected ITTTextBoxColumn TesisTuru;
        protected ITTLabel labeltesisKoduSaglikTesisiAraGirisDVO;
        protected ITTButton buttonSaglikTesisiAra;
        protected ITTLabel labeltesisIlKoduSaglikTesisiAraGirisDVO;
        protected ITTTextBox tesisIlKoduSaglikTesisiAraGirisDVO;
        protected ITTTextBox tesisAdiSaglikTesisiAraGirisDVO;
        protected ITTLabel labeltesisTuruSaglikTesisiAraGirisDVO;
        protected ITTTextBox tesisKoduSaglikTesisiAraGirisDVO;
        protected ITTTextBox tesisTuruSaglikTesisiAraGirisDVO;
        protected ITTLabel labeltesisAdiSaglikTesisiAraGirisDVO;
        protected ITTTabPage tttabTeshisleriArama;
        protected ITTGroupBox ttgroupbox2;
        protected ITTButton ttbuttonTeshisleriOku;
        protected ITTPanel ttpanelTeshisleriAra;
        protected ITTGroupBox ttgroupbox4;
        protected ITTGrid ttgridTeshisleriOku;
        protected ITTTextBoxColumn Kodu;
        protected ITTTextBoxColumn Adi;
        protected ITTGroupBox ttgroupbox3;
        protected ITTLabel ttlabel2;
        protected ITTTextBox txtboxTeshisleriOkuSonucMesaji;
        protected ITTLabel ttlabel1;
        protected ITTTextBox txtboxTeshisleriOkuSonucKodu;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("a374b8b2-4aaa-4e40-a909-23b24314fa61"));
            tttabHastayaAitSevkAramaIslemleri = (ITTTabPage)AddControl(new Guid("71bd9faf-2f2f-4247-a92d-b1b38a857897"));
            pnlSearchResult = (ITTPanel)AddControl(new Guid("4b06cc53-fb15-4d28-9e55-c3ae4b0d0e9f"));
            ttpanel1 = (ITTPanel)AddControl(new Guid("bf98ee4c-04a4-40d7-813e-5292abc11285"));
            ttgridHastaSevkListesi = (ITTGrid)AddControl(new Guid("d696c755-6801-4198-afb6-345755679366"));
            sevkId = (ITTTextBoxColumn)AddControl(new Guid("de132b8b-b0e5-488c-a138-d07839858fc4"));
            tcKimlikNo = (ITTTextBoxColumn)AddControl(new Guid("baaf76b1-724b-4657-9c29-390150356ad5"));
            sevkTakipNo = (ITTTextBoxColumn)AddControl(new Guid("0c138a55-1bba-4dd1-acb7-11a4b7433d27"));
            protokolNo = (ITTTextBoxColumn)AddControl(new Guid("a59dfdfc-5021-47ca-8a2b-390bce9d2b29"));
            sevkEdilenIl = (ITTTextBoxColumn)AddControl(new Guid("9554834a-397d-447b-b63a-924b5c2253f2"));
            sevkTarihi = (ITTTextBoxColumn)AddControl(new Guid("5f5e6603-e263-4907-91a4-85d7f0fc2741"));
            sevkVasitasi = (ITTTextBoxColumn)AddControl(new Guid("288265c1-a55e-4f50-b8c0-aaacf26d5203"));
            sevkNedeni = (ITTTextBoxColumn)AddControl(new Guid("c15fea69-5872-47e7-a467-82be6e102352"));
            sevkNedeniAciklama = (ITTTextBoxColumn)AddControl(new Guid("6fce9d8c-f05c-415c-ad77-ee8b4f570307"));
            tedaviTipi = (ITTTextBoxColumn)AddControl(new Guid("91987927-4208-458c-b6e5-a57249901482"));
            kabulEdenTesis = (ITTTextBoxColumn)AddControl(new Guid("58499d01-9639-401c-a2cc-43f870558cfc"));
            kabulEdenTakip = (ITTTextBoxColumn)AddControl(new Guid("9d0e2e00-bb92-4416-a925-e4d2d76d88f6"));
            sevkEdenBrans = (ITTTextBoxColumn)AddControl(new Guid("20373eb4-a6f7-4a36-93c3-8772c5aa2cda"));
            sevkEdenTesis = (ITTTextBoxColumn)AddControl(new Guid("51086b98-07ef-4488-a31c-1582c1b79b14"));
            SevkSil = (ITTButtonColumn)AddControl(new Guid("623e4c73-db5a-4626-81e3-a4c1e5e5c3d5"));
            ttgroupboxListeleme = (ITTGroupBox)AddControl(new Guid("419df6c1-c5c6-4991-ab52-131ed20badff"));
            btnMedulaSevkListele = (ITTButton)AddControl(new Guid("72c68593-e471-44b6-81f6-43036cebd47c"));
            ttgroupboxHastaBilgileri = (ITTGroupBox)AddControl(new Guid("f309fdd3-3447-4116-91cc-1e019aef5db2"));
            txtSex = (ITTTextBox)AddControl(new Guid("4a53b6c2-7863-4bb1-827d-8f521d79d02a"));
            txtName = (ITTTextBox)AddControl(new Guid("5bd8930e-0473-4920-9dbd-3d53d1863fb5"));
            txtSurname = (ITTTextBox)AddControl(new Guid("d6b075ce-0f29-4cd2-9cfc-73b406a92e43"));
            lblCinsiyeti = (ITTLabel)AddControl(new Guid("a60bd898-938e-45fa-bce9-f0bcda3a12db"));
            lblHastaSoyadi = (ITTLabel)AddControl(new Guid("48a0aaec-a4bb-438e-96b2-714904920a77"));
            txtTCKNo = (ITTTextBox)AddControl(new Guid("4c056ce2-70bc-454d-9c6d-11e0c9e9e646"));
            txtBirthDate = (ITTTextBox)AddControl(new Guid("c236fa1b-a631-4de8-8152-5250f135c1ac"));
            lblTCNumarasi = (ITTLabel)AddControl(new Guid("ed44ae89-1f6e-4d24-aa02-c8d9fe4f145a"));
            lblHastaAdi = (ITTLabel)AddControl(new Guid("682f3c08-31b7-476f-a7d8-30b4697af849"));
            lblDogumTarihi = (ITTLabel)AddControl(new Guid("d99ec78f-8352-4e35-b5e0-6f508da4e76d"));
            lblHastaSearchName = (ITTLabel)AddControl(new Guid("c0aee88e-e41e-4caa-8282-54692b07ce78"));
            txtPatientName = (ITTTextBox)AddControl(new Guid("33ea08df-7374-497c-8631-ef6dad164b37"));
            cmdSearchPatient = (ITTButton)AddControl(new Guid("edafd0ee-d15c-4494-ba1a-8859d99bfc91"));
            tttabSaglikTesisiArama = (ITTTabPage)AddControl(new Guid("fe1832d6-bbb3-4b0d-a088-d6a6b626c9a9"));
            ttpanelMedulaSaglikTesisiAraCevap = (ITTPanel)AddControl(new Guid("167b381d-7c89-4836-a596-06445c303a4d"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("79027618-d4e7-4a0d-8a61-a5bb90063c03"));
            labelSonucMesaji = (ITTLabel)AddControl(new Guid("c091b5f9-27cb-465f-88b5-9b0868c3f0ea"));
            labelSonucKodu = (ITTLabel)AddControl(new Guid("9262135a-4f17-4e68-8927-9b1e27f52303"));
            tttextboxSonucMesaji = (ITTTextBox)AddControl(new Guid("66241d82-15ea-475b-bba7-646ab0fd2f46"));
            tttextboxSonucKodu = (ITTTextBox)AddControl(new Guid("66e32edc-74a3-4480-98e2-c09d9c9e2cb2"));
            ttgridSaglikTesisleri = (ITTGrid)AddControl(new Guid("76c36322-c3bd-469f-93d4-27abd86ccfb2"));
            TesisIl = (ITTTextBoxColumn)AddControl(new Guid("19d728d6-9f46-4d40-8d03-51c45127e7fd"));
            TesisAdi = (ITTTextBoxColumn)AddControl(new Guid("59f82f7a-64f7-4857-ab2f-031bdf038b54"));
            TesisKodu = (ITTTextBoxColumn)AddControl(new Guid("f77b0689-b6f4-460b-b268-47f69d1b58f0"));
            TesisSinifKodu = (ITTTextBoxColumn)AddControl(new Guid("94dfb263-95d2-40d9-a96d-d2591b3f5628"));
            TesisTuru = (ITTTextBoxColumn)AddControl(new Guid("dc7038af-fb97-43c0-91c2-39b6746bc97e"));
            labeltesisKoduSaglikTesisiAraGirisDVO = (ITTLabel)AddControl(new Guid("f3923891-49f4-40d1-9357-2f2335e454b2"));
            buttonSaglikTesisiAra = (ITTButton)AddControl(new Guid("556fc8af-9ced-4c29-9e83-2ae8b9fb34d9"));
            labeltesisIlKoduSaglikTesisiAraGirisDVO = (ITTLabel)AddControl(new Guid("42b784e2-1c5e-4028-b152-b619690a1376"));
            tesisIlKoduSaglikTesisiAraGirisDVO = (ITTTextBox)AddControl(new Guid("4cab70af-2b82-45c7-8814-2bd0eae087a5"));
            tesisAdiSaglikTesisiAraGirisDVO = (ITTTextBox)AddControl(new Guid("595990fa-94f4-44d2-8b0c-6903d204367e"));
            labeltesisTuruSaglikTesisiAraGirisDVO = (ITTLabel)AddControl(new Guid("195bfd83-a459-4313-97a9-fdfa04272eb1"));
            tesisKoduSaglikTesisiAraGirisDVO = (ITTTextBox)AddControl(new Guid("2c9d5df7-e38d-4ef2-8c28-1a1ecb0cd74d"));
            tesisTuruSaglikTesisiAraGirisDVO = (ITTTextBox)AddControl(new Guid("3cb32ece-dca0-4c55-9607-f0e5a9b4380c"));
            labeltesisAdiSaglikTesisiAraGirisDVO = (ITTLabel)AddControl(new Guid("438e7029-6be0-4b66-9c53-92ade12755c9"));
            tttabTeshisleriArama = (ITTTabPage)AddControl(new Guid("91715acb-f2fc-41e0-acf1-17cda4a73c65"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("c2e55796-c4f3-4048-a0c0-e990b112a760"));
            ttbuttonTeshisleriOku = (ITTButton)AddControl(new Guid("a096deaf-dc37-4c13-a03f-cefd299ca7b8"));
            ttpanelTeshisleriAra = (ITTPanel)AddControl(new Guid("b6571eb6-64e1-4652-88d6-7748c3e1afad"));
            ttgroupbox4 = (ITTGroupBox)AddControl(new Guid("e215b42d-5bb7-441e-b530-e98e1000d5eb"));
            ttgridTeshisleriOku = (ITTGrid)AddControl(new Guid("7178d963-7fcf-438b-857c-ae37191afe7a"));
            Kodu = (ITTTextBoxColumn)AddControl(new Guid("23801fc1-d6cb-43ca-b9d5-39d18b5068cf"));
            Adi = (ITTTextBoxColumn)AddControl(new Guid("b20420e2-d4d9-4ebf-8338-ada3ea8a094c"));
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("fe7f8e29-edb3-46c1-9ffd-898046008ad7"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("484a5785-2113-490e-a6f1-b414d5f89825"));
            txtboxTeshisleriOkuSonucMesaji = (ITTTextBox)AddControl(new Guid("c68035d7-6a1e-4d8b-8530-667fd8333080"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("543d8fa8-8458-4486-bd42-21c2a2fece0d"));
            txtboxTeshisleriOkuSonucKodu = (ITTTextBox)AddControl(new Guid("b3d71b1d-8b73-43dd-bb3b-8730e0e191bc"));
            base.InitializeControls();
        }

        public MedulaSevkIslemleri() : base("MedulaSevkIslemleri")
        {
        }

        protected MedulaSevkIslemleri(string formDefName) : base(formDefName)
        {
        }
    }
}