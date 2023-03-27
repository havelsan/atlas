
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
    public partial class MaddeBagimliligiVeriSetiForm : TTForm
    {
    /// <summary>
    /// Madde Bağımlılığı Bildirim Veri Seti
    /// </summary>
        protected TTObjectClasses.MaddeBagimliligiVeriSeti _MaddeBagimliligiVeriSeti
        {
            get { return (TTObjectClasses.MaddeBagimliligiVeriSeti)_ttObject; }
        }

        protected ITTLabel labelSKRSYasamBicimi;
        protected ITTObjectListBox SKRSYasamBicimi;
        protected ITTLabel labelSKRSEnjeksiyonMaddeKullanimi;
        protected ITTObjectListBox SKRSEnjeksiyonMaddeKullanimi;
        protected ITTLabel labelSKRSYasadigiBolge;
        protected ITTObjectListBox SKRSYasadigiBolge;
        protected ITTLabel labelSKRSUygulananTedaviMaddeBagim;
        protected ITTObjectListBox SKRSUygulananTedaviMaddeBagim;
        protected ITTLabel labelSKRSTedaviSonucuMaddeBagim;
        protected ITTObjectListBox SKRSTedaviSonucuMaddeBagim;
        protected ITTLabel labelSKRSTedaviMerkeziTipi;
        protected ITTObjectListBox SKRSTedaviMerkeziTipi;
        protected ITTLabel labelSKRSSigaraKullanimi;
        protected ITTObjectListBox SKRSSigaraKullanimi;
        protected ITTLabel labelSKRSOgrenimDurumu;
        protected ITTObjectListBox SKRSOgrenimDurumu;
        protected ITTLabel labelSKRSKullanilanMadde;
        protected ITTObjectListBox SKRSKullanilanMadde;
        protected ITTLabel labelSKRSIsDurumu;
        protected ITTObjectListBox SKRSIsDurumu;
        protected ITTLabel labelSKRSGonderenBirim;
        protected ITTObjectListBox SKRSGonderenBirim;
        protected ITTLabel labelSKRSEnjektorPaylasimDurumu;
        protected ITTObjectListBox SKRSEnjektorPaylasimDurumu;
        protected ITTLabel labelSKRSAlkolKullanimi;
        protected ITTObjectListBox SKRSAlkolKullanimi;
        protected ITTGrid MaddeBagimliligiKulMadde;
        protected ITTListBoxColumn SKRSKullanilanMaddeMaddeBagimliligiKulMadde;
        protected ITTListBoxColumn SKRSMaddeKullanimSikligiMaddeBagimliligiKulMadde;
        protected ITTListBoxColumn SKRSMaddeKullanimYoluMaddeBagimliligiKulMadde;
        protected ITTTextBoxColumn DuzenliMaddeKullanimSuresiMaddeBagimliligiKulMadde;
        protected ITTTextBoxColumn MaddeIlkKullanimYasiMaddeBagimliligiKulMadde;
        protected ITTGrid MaddeBagimBulasiciHastalik;
        protected ITTListBoxColumn SKRSBulasiciHastalikDurumuMaddeBagimBulasiciHastalik;
        protected ITTLabel labelSigaraAdedi;
        protected ITTTextBox SigaraAdedi;
        protected ITTTextBox HastaKodu;
        protected ITTTextBox EnjeksiyonIleIlkMaddeKulYas;
        protected ITTLabel labelHastaKodu;
        protected ITTLabel labelEnjeksiyonIleIlkMaddeKulYas;
        protected ITTLabel ttlabel17;
        protected ITTLabel ttlabel18;
        override protected void InitializeControls()
        {
            labelSKRSYasamBicimi = (ITTLabel)AddControl(new Guid("5aa2692c-295e-4807-a41c-4f1a8ceec1df"));
            SKRSYasamBicimi = (ITTObjectListBox)AddControl(new Guid("f83ced31-f9e3-4a03-a7f8-94187f79b19a"));
            labelSKRSEnjeksiyonMaddeKullanimi = (ITTLabel)AddControl(new Guid("49ce0d9f-a2d4-44c0-945b-1dc72e7f990e"));
            SKRSEnjeksiyonMaddeKullanimi = (ITTObjectListBox)AddControl(new Guid("21c21f77-f083-4c03-a4a3-7760753f126c"));
            labelSKRSYasadigiBolge = (ITTLabel)AddControl(new Guid("34271183-fd27-431f-a752-ec688e6751da"));
            SKRSYasadigiBolge = (ITTObjectListBox)AddControl(new Guid("fbd0cdbf-0e77-4307-b8ed-9969c44e26d1"));
            labelSKRSUygulananTedaviMaddeBagim = (ITTLabel)AddControl(new Guid("bc12cac8-b8db-4dec-9111-f65f63758092"));
            SKRSUygulananTedaviMaddeBagim = (ITTObjectListBox)AddControl(new Guid("61e00e82-1d85-4a52-a7d8-fc2da4c23a5d"));
            labelSKRSTedaviSonucuMaddeBagim = (ITTLabel)AddControl(new Guid("27c1b7db-69e3-45df-957a-b9581babe2c9"));
            SKRSTedaviSonucuMaddeBagim = (ITTObjectListBox)AddControl(new Guid("891485bc-1cde-49bd-b8ac-c6ac7d124dad"));
            labelSKRSTedaviMerkeziTipi = (ITTLabel)AddControl(new Guid("cc9c2862-e1af-4af3-b9dc-06e04160b8a9"));
            SKRSTedaviMerkeziTipi = (ITTObjectListBox)AddControl(new Guid("56baf7fb-c20c-4157-ac81-137fe6dd8f17"));
            labelSKRSSigaraKullanimi = (ITTLabel)AddControl(new Guid("5511e29d-98dd-4403-94b1-e35644281abd"));
            SKRSSigaraKullanimi = (ITTObjectListBox)AddControl(new Guid("b31a758b-acfd-4d90-831e-8c729578522a"));
            labelSKRSOgrenimDurumu = (ITTLabel)AddControl(new Guid("5ea5b0af-f1a5-470d-b57d-06c039de0f80"));
            SKRSOgrenimDurumu = (ITTObjectListBox)AddControl(new Guid("c1d93a18-e130-4dac-add8-88234517b5f4"));
            labelSKRSKullanilanMadde = (ITTLabel)AddControl(new Guid("b7669756-0c86-478c-9911-7688a7653139"));
            SKRSKullanilanMadde = (ITTObjectListBox)AddControl(new Guid("1af91207-66c2-4ce4-b18b-7946fb13419d"));
            labelSKRSIsDurumu = (ITTLabel)AddControl(new Guid("4b0cf719-ab9c-4d92-8ab7-a263f12b9e5b"));
            SKRSIsDurumu = (ITTObjectListBox)AddControl(new Guid("9998c0ee-d6b0-4dfe-af4f-7842028b3c62"));
            labelSKRSGonderenBirim = (ITTLabel)AddControl(new Guid("1b5771ff-709c-42ad-8a87-e002023fb038"));
            SKRSGonderenBirim = (ITTObjectListBox)AddControl(new Guid("8e5a49eb-95f4-45e0-bc6e-0658cfd594b4"));
            labelSKRSEnjektorPaylasimDurumu = (ITTLabel)AddControl(new Guid("86f27746-d8a8-4776-80d6-54fe4ff536e6"));
            SKRSEnjektorPaylasimDurumu = (ITTObjectListBox)AddControl(new Guid("f8435f07-6b7d-4f24-bafa-2644b773f48c"));
            labelSKRSAlkolKullanimi = (ITTLabel)AddControl(new Guid("3f2917aa-6d44-4df8-b44a-44ffab9727c7"));
            SKRSAlkolKullanimi = (ITTObjectListBox)AddControl(new Guid("043acd95-87cf-42b6-8bc5-4c13869af9c4"));
            MaddeBagimliligiKulMadde = (ITTGrid)AddControl(new Guid("82ac14a8-c737-4c7a-9260-69548d6c8e1c"));
            SKRSKullanilanMaddeMaddeBagimliligiKulMadde = (ITTListBoxColumn)AddControl(new Guid("e2440bc8-42b5-43cc-a841-c6a1a1f500aa"));
            SKRSMaddeKullanimSikligiMaddeBagimliligiKulMadde = (ITTListBoxColumn)AddControl(new Guid("54dc74f6-16c0-4de3-a620-ba802d0d7a03"));
            SKRSMaddeKullanimYoluMaddeBagimliligiKulMadde = (ITTListBoxColumn)AddControl(new Guid("06c1a6c5-ab45-4188-ba35-0ae418526847"));
            DuzenliMaddeKullanimSuresiMaddeBagimliligiKulMadde = (ITTTextBoxColumn)AddControl(new Guid("9d899304-c503-4af7-9f7a-30781addc68f"));
            MaddeIlkKullanimYasiMaddeBagimliligiKulMadde = (ITTTextBoxColumn)AddControl(new Guid("d25cfe96-9267-4dc1-9d4d-c377c7e2f866"));
            MaddeBagimBulasiciHastalik = (ITTGrid)AddControl(new Guid("741e24f1-2759-49f2-8ac0-b459d7d4b9de"));
            SKRSBulasiciHastalikDurumuMaddeBagimBulasiciHastalik = (ITTListBoxColumn)AddControl(new Guid("21c18cc9-8dc6-4e33-b2fe-cda3630aae76"));
            labelSigaraAdedi = (ITTLabel)AddControl(new Guid("a92752c6-94e8-4c1f-a8f1-35cf7cec7a40"));
            SigaraAdedi = (ITTTextBox)AddControl(new Guid("ae382f48-db27-42c5-9fe6-71fa4048faf2"));
            HastaKodu = (ITTTextBox)AddControl(new Guid("3ca89ec3-0e2b-4021-aba0-bfa046e31f8b"));
            EnjeksiyonIleIlkMaddeKulYas = (ITTTextBox)AddControl(new Guid("dffa2481-53e5-474e-bf21-e663faa36f89"));
            labelHastaKodu = (ITTLabel)AddControl(new Guid("ee0bf0dd-1c48-47fa-bc1c-ad59bc96170b"));
            labelEnjeksiyonIleIlkMaddeKulYas = (ITTLabel)AddControl(new Guid("6d4c3430-9a75-4def-99c4-4acb8be3d8b6"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("793577ae-49da-4149-b1ac-03b85c3a4fe4"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("035a76ee-fb16-4f0c-9e3b-96ac24d15c23"));
            base.InitializeControls();
        }

        public MaddeBagimliligiVeriSetiForm() : base("MADDEBAGIMLILIGIVERISETI", "MaddeBagimliligiVeriSetiForm")
        {
        }

        protected MaddeBagimliligiVeriSetiForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}