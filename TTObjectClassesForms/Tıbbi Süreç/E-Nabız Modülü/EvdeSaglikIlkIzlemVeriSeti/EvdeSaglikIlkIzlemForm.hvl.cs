
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
    /// 219 Evde Sağlık İlk İzlem Veri Seti
    /// </summary>
    public partial class EvdeSaglikIlkIzlemForm : TTForm
    {
    /// <summary>
    /// Evde Sağlık İlk İzlem Veri Seti
    /// </summary>
        protected TTObjectClasses.EvdeSaglikIlkIzlemVeriSeti _EvdeSaglikIlkIzlemVeriSeti
        {
            get { return (TTObjectClasses.EvdeSaglikIlkIzlemVeriSeti)_ttObject; }
        }

        protected ITTGrid VerilenEgitimler;
        protected ITTListBoxColumn SKRSVerilenEgitimlerVerilenEgitimler;
        protected ITTGrid PsikolojikDurum;
        protected ITTListBoxColumn SKRSPsikolojikDurumPsikolojikDurum;
        protected ITTGrid KullandigiYardimciAraclar;
        protected ITTListBoxColumn SKRSKullandigiYardimciAraclarKullandigiYardimciAraclar;
        protected ITTLabel labelSKRSYatagaBagimlilik;
        protected ITTObjectListBox SKRSYatagaBagimlilik;
        protected ITTLabel labelSKRSKullanilanHelaTipi;
        protected ITTObjectListBox SKRSKullanilanHelaTipi;
        protected ITTLabel labelSKRSKonutTipi;
        protected ITTObjectListBox SKRSKonutTipi;
        protected ITTLabel labelSKRSKisiselHijyen;
        protected ITTObjectListBox SKRSKisiselHijyen;
        protected ITTLabel labelSKRSKisiselBakim;
        protected ITTObjectListBox SKRSKisiselBakim;
        protected ITTLabel labelSKRSIsinma;
        protected ITTObjectListBox SKRSIsinma;
        protected ITTLabel labelSKRSGuvenlik;
        protected ITTObjectListBox SKRSGuvenlik;
        protected ITTLabel labelSKRSEvHijyeni;
        protected ITTObjectListBox SKRSEvHijyeni;
        protected ITTLabel labelSKRSICD;
        protected ITTObjectListBox SKRSICD;
        protected ITTLabel labelSKRSBirSonrakiHizmetIhtiyaci;
        protected ITTObjectListBox SKRSBirSonrakiHizmetIhtiyaci;
        protected ITTLabel labelSKRSBeslenme;
        protected ITTObjectListBox SKRSBeslenme;
        protected ITTLabel labelSKRSBasvuruTuru;
        protected ITTObjectListBox SKRSBasvuruTuru;
        protected ITTLabel labelSKRSBasiDegerlendirmesi;
        protected ITTObjectListBox SKRSBasiDegerlendirmesi;
        protected ITTLabel labelSKRSBakimveDestekIhtiyaci;
        protected ITTObjectListBox SKRSBakimveDestekIhtiyaci;
        protected ITTLabel labelSKRSAydinlatma;
        protected ITTObjectListBox SKRSAydinlatma;
        protected ITTLabel labelSKRSAgri;
        protected ITTObjectListBox SKRSAgri;
        override protected void InitializeControls()
        {
            VerilenEgitimler = (ITTGrid)AddControl(new Guid("7f7b3791-6eba-4918-8f62-3b3a9db41b22"));
            SKRSVerilenEgitimlerVerilenEgitimler = (ITTListBoxColumn)AddControl(new Guid("439a23e5-d155-4e3a-ae9a-37d5e2d9f64c"));
            PsikolojikDurum = (ITTGrid)AddControl(new Guid("6e6e5d35-bde0-430f-bb5f-7a463157fad1"));
            SKRSPsikolojikDurumPsikolojikDurum = (ITTListBoxColumn)AddControl(new Guid("42fe14f7-78e0-424e-9f3b-bef61b677427"));
            KullandigiYardimciAraclar = (ITTGrid)AddControl(new Guid("f7e383a0-ba35-47cd-a71a-223f73d0480b"));
            SKRSKullandigiYardimciAraclarKullandigiYardimciAraclar = (ITTListBoxColumn)AddControl(new Guid("9ad3167f-7040-487b-9013-62f2d7a26459"));
            labelSKRSYatagaBagimlilik = (ITTLabel)AddControl(new Guid("2088f909-c4a2-49e2-ae66-157132304797"));
            SKRSYatagaBagimlilik = (ITTObjectListBox)AddControl(new Guid("9564ad6b-7317-4ca7-b9c5-94e99429b874"));
            labelSKRSKullanilanHelaTipi = (ITTLabel)AddControl(new Guid("42493736-b4b6-446b-8eb3-4ab9d39cbb88"));
            SKRSKullanilanHelaTipi = (ITTObjectListBox)AddControl(new Guid("fc929ac3-4d89-4a1a-a96c-dbdfe77fa084"));
            labelSKRSKonutTipi = (ITTLabel)AddControl(new Guid("04a1fc77-6b87-477d-84b5-b8c7e7488883"));
            SKRSKonutTipi = (ITTObjectListBox)AddControl(new Guid("f7174484-1fee-4c75-a776-1a4018e4e718"));
            labelSKRSKisiselHijyen = (ITTLabel)AddControl(new Guid("cabff56b-13da-46f0-97b6-4b5a07e5589e"));
            SKRSKisiselHijyen = (ITTObjectListBox)AddControl(new Guid("a344f4dd-498c-4171-bab9-cf047781cc73"));
            labelSKRSKisiselBakim = (ITTLabel)AddControl(new Guid("947eabde-042e-41ac-aed2-e494839a303f"));
            SKRSKisiselBakim = (ITTObjectListBox)AddControl(new Guid("1caa929b-b96a-4a90-a3d8-2bfecefcddb5"));
            labelSKRSIsinma = (ITTLabel)AddControl(new Guid("4fa4f553-aa6c-4cff-bbbc-c8c7995f56fd"));
            SKRSIsinma = (ITTObjectListBox)AddControl(new Guid("02d95715-c67f-4b96-a4d4-ae97e8e5c992"));
            labelSKRSGuvenlik = (ITTLabel)AddControl(new Guid("645e8118-e7f7-4a9b-88ab-875612f351de"));
            SKRSGuvenlik = (ITTObjectListBox)AddControl(new Guid("f0d79dea-d691-45ed-8b69-eb776474e924"));
            labelSKRSEvHijyeni = (ITTLabel)AddControl(new Guid("a0f6a1d3-38dc-463c-aa70-dffd314c603b"));
            SKRSEvHijyeni = (ITTObjectListBox)AddControl(new Guid("4096dc94-57f0-4bb4-938c-9d572527ef3e"));
            labelSKRSICD = (ITTLabel)AddControl(new Guid("75b9393a-3276-4c5a-b33d-046a31e818fc"));
            SKRSICD = (ITTObjectListBox)AddControl(new Guid("cdb8b8e9-6a86-4243-a462-d25132060393"));
            labelSKRSBirSonrakiHizmetIhtiyaci = (ITTLabel)AddControl(new Guid("158a9526-b7e7-44e5-acf4-b3d5c2da49cf"));
            SKRSBirSonrakiHizmetIhtiyaci = (ITTObjectListBox)AddControl(new Guid("335d0b73-f171-41f3-9962-25f99e36234e"));
            labelSKRSBeslenme = (ITTLabel)AddControl(new Guid("482f68f2-b0b9-4dbe-91cc-eed24312db4c"));
            SKRSBeslenme = (ITTObjectListBox)AddControl(new Guid("0bd0cbaf-1564-4eda-9aa1-05173258e6dc"));
            labelSKRSBasvuruTuru = (ITTLabel)AddControl(new Guid("9fe1380f-a3c2-4a46-ac57-7c7fcf2ffda6"));
            SKRSBasvuruTuru = (ITTObjectListBox)AddControl(new Guid("ef89fd12-3da0-4469-9203-7f4910146cc1"));
            labelSKRSBasiDegerlendirmesi = (ITTLabel)AddControl(new Guid("0a0ac110-91f3-4341-bf37-e5752b08ea3d"));
            SKRSBasiDegerlendirmesi = (ITTObjectListBox)AddControl(new Guid("fe821a25-3009-45cf-8e9c-a2dd799f3389"));
            labelSKRSBakimveDestekIhtiyaci = (ITTLabel)AddControl(new Guid("ef2462c5-c72b-4505-97b1-acb2a3cf5c78"));
            SKRSBakimveDestekIhtiyaci = (ITTObjectListBox)AddControl(new Guid("0522c8e3-4c73-41d4-9d94-b6930ccbe189"));
            labelSKRSAydinlatma = (ITTLabel)AddControl(new Guid("5ee4b6d9-9cfb-4c4e-826b-4d00e08a8607"));
            SKRSAydinlatma = (ITTObjectListBox)AddControl(new Guid("453fe3c7-be29-421b-b601-03ed4e3d628e"));
            labelSKRSAgri = (ITTLabel)AddControl(new Guid("1577d321-0fb0-413d-a334-c343e487b414"));
            SKRSAgri = (ITTObjectListBox)AddControl(new Guid("9d366735-b5b8-4451-bc4b-c2e45b5042a8"));
            base.InitializeControls();
        }

        public EvdeSaglikIlkIzlemForm() : base("EVDESAGLIKILKIZLEMVERISETI", "EvdeSaglikIlkIzlemForm")
        {
        }

        protected EvdeSaglikIlkIzlemForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}