
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
    /// Evde Sağlık Başvuru Kaydet
    /// </summary>
    public partial class EvdeSaglikBasvuruKaydetForm : TTForm
    {
        protected TTObjectClasses.EvdeSaglikHizmetleri _EvdeSaglikHizmetleri
        {
            get { return (TTObjectClasses.EvdeSaglikHizmetleri)_ttObject; }
        }

        protected ITTLabel labelResponsibleDoctor;
        protected ITTObjectListBox ResponsibleDoctor;
        protected ITTGroupBox ttgroupbox2;
        protected ITTLabel labelHastaTC;
        protected ITTTextBox HastaTC;
        protected ITTTextBox HastaAd;
        protected ITTLabel labelHastaAd;
        protected ITTLabel labelHastaAdres;
        protected ITTTextBox HastaSoyad;
        protected ITTTextBox HastaAdres;
        protected ITTLabel labelHastaSoyad;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelBasvuranTel;
        protected ITTTextBox BasvuranTel;
        protected ITTTextBox BasvuranAd;
        protected ITTLabel labelBasvuranAd;
        protected ITTTextBox BasvuranSoyad;
        protected ITTLabel labelBasvuranSoyad;
        protected ITTTextBox BasvuranTC;
        protected ITTLabel labelBasvuranTC;
        protected ITTTextBox BasvuranAciklamasi;
        protected ITTLabel labelBasvuranAciklamasi;
        protected ITTLabel labelHizmetEmriTarihi;
        protected ITTDateTimePicker HizmetEmriTarihi;
        protected ITTLabel labelAlinanNotlar;
        protected ITTTextBox AlinanNotlar;
        override protected void InitializeControls()
        {
            labelResponsibleDoctor = (ITTLabel)AddControl(new Guid("d4cb5a34-67fe-46da-bb85-8b53d5c7ff4d"));
            ResponsibleDoctor = (ITTObjectListBox)AddControl(new Guid("43b93659-1afc-4216-9d49-aa84340b2bf0"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("97da25a7-eabc-4efb-b501-37f2ff757d06"));
            labelHastaTC = (ITTLabel)AddControl(new Guid("40e3d81c-15b7-443c-a9d7-b98d7ef54752"));
            HastaTC = (ITTTextBox)AddControl(new Guid("68b2c163-8439-4865-aa18-f19ed5ee5e69"));
            HastaAd = (ITTTextBox)AddControl(new Guid("04020299-ec2b-4c05-9448-768f250df304"));
            labelHastaAd = (ITTLabel)AddControl(new Guid("a435b94a-7e04-4353-9138-455e41bbd119"));
            labelHastaAdres = (ITTLabel)AddControl(new Guid("6ecd18c8-21c1-41e1-8896-035a1bae03d5"));
            HastaSoyad = (ITTTextBox)AddControl(new Guid("3424a70c-a0a0-4db3-aa52-cddba98e283e"));
            HastaAdres = (ITTTextBox)AddControl(new Guid("d145a914-03b5-4d95-afbb-243f7d6142e9"));
            labelHastaSoyad = (ITTLabel)AddControl(new Guid("1440438b-8700-4266-86bf-d5385beac620"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("e24bd61a-80da-46e5-9c70-e54dde332ec7"));
            labelBasvuranTel = (ITTLabel)AddControl(new Guid("c90dbbf6-1988-44b9-b204-0f2a5eea2d85"));
            BasvuranTel = (ITTTextBox)AddControl(new Guid("342ca1a0-a74a-451e-bc18-89ef0d9c10f4"));
            BasvuranAd = (ITTTextBox)AddControl(new Guid("faaa6e28-af56-459c-9c67-99475c53b5aa"));
            labelBasvuranAd = (ITTLabel)AddControl(new Guid("b68d273b-6623-4d89-a1a9-b653c982fb9b"));
            BasvuranSoyad = (ITTTextBox)AddControl(new Guid("7066e732-0bab-46c2-84c7-033e2a8abf34"));
            labelBasvuranSoyad = (ITTLabel)AddControl(new Guid("9d4b22d2-4170-4ac6-ae39-7e24f4be029d"));
            BasvuranTC = (ITTTextBox)AddControl(new Guid("61422afb-3665-495d-b492-ac0e645ff216"));
            labelBasvuranTC = (ITTLabel)AddControl(new Guid("332ffc53-9563-4655-8498-06330866203d"));
            BasvuranAciklamasi = (ITTTextBox)AddControl(new Guid("c0c03362-87b6-41bf-b4a6-100b965a6171"));
            labelBasvuranAciklamasi = (ITTLabel)AddControl(new Guid("cbad0360-d30b-4be6-bb84-0f77ffc33589"));
            labelHizmetEmriTarihi = (ITTLabel)AddControl(new Guid("0725a25d-c227-4e3a-9921-f99fad8498f6"));
            HizmetEmriTarihi = (ITTDateTimePicker)AddControl(new Guid("2428b509-49a2-4b1e-b529-200be39b9355"));
            labelAlinanNotlar = (ITTLabel)AddControl(new Guid("25c50fb1-b6b5-4b7d-b089-6c97da003ed1"));
            AlinanNotlar = (ITTTextBox)AddControl(new Guid("6f60dfc6-3023-4cf8-8a25-bb4b6ec760b9"));
            base.InitializeControls();
        }

        public EvdeSaglikBasvuruKaydetForm() : base("EVDESAGLIKHIZMETLERI", "EvdeSaglikBasvuruKaydetForm")
        {
        }

        protected EvdeSaglikBasvuruKaydetForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}