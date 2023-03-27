
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
    public partial class IntiharGirisimiKrizTespitVeriSetiForm : TTForm
    {
        protected TTObjectClasses.IntiharGirisimKrizVeriSeti _IntiharGirisimKrizVeriSeti
        {
            get { return (TTObjectClasses.IntiharGirisimKrizVeriSeti)_ttObject; }
        }

        protected ITTGrid IntiharGirisimPsikiyatTani;
        protected ITTListBoxColumn PsikiyatrikTaniGecmisiIntiharGirisimPsikiyatTani;
        protected ITTGrid IntiharGirisimiYontemi;
        protected ITTListBoxColumn SKRSIntiharGirisimiYontemiICDIntiharGirisimiYontemi;
        protected ITTLabel labelSKRSPsikiyatrikTedaviGecmisi;
        protected ITTObjectListBox SKRSPsikiyatrikTedaviGecmisi;
        protected ITTLabel labelSKRSIntiharKrizVakaTuru;
        protected ITTObjectListBox SKRSIntiharKrizVakaTuru;
        protected ITTLabel labelSKRSIntiharGirisimiGecmisi;
        protected ITTObjectListBox SKRSIntiharGirisimiGecmisi;
        protected ITTLabel labelSKRSAilesindePsikiyatrikVaka;
        protected ITTObjectListBox SKRSAilesindePsikiyatrikVaka;
        protected ITTLabel labelSKRSAilesindeIntiharGirisimi;
        protected ITTObjectListBox SKRSAilesindeIntiharGirisimi;
        protected ITTGrid IntiharGirisimiVakaSonucu;
        protected ITTListBoxColumn SKRSIntiharKrizVakaSonucuIntiharGirisimiVakaSonucu;
        protected ITTGrid IntiharGirisimiKrizNedeni;
        protected ITTListBoxColumn SKRSIntiharGirisimKrizNedenIntiharGirisimiKrizNedeni;
        protected ITTLabel labelOlayZamani;
        protected ITTDateTimePicker OlayZamani;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            IntiharGirisimPsikiyatTani = (ITTGrid)AddControl(new Guid("d77a5ddf-4320-46f4-a18d-76930ebad819"));
            PsikiyatrikTaniGecmisiIntiharGirisimPsikiyatTani = (ITTListBoxColumn)AddControl(new Guid("46f9d911-14ce-49e7-a18a-e85962628b0a"));
            IntiharGirisimiYontemi = (ITTGrid)AddControl(new Guid("155778c7-2ed6-4605-af12-68af6ed036ae"));
            SKRSIntiharGirisimiYontemiICDIntiharGirisimiYontemi = (ITTListBoxColumn)AddControl(new Guid("d5ae097f-e3e5-471d-94cf-994751cd6532"));
            labelSKRSPsikiyatrikTedaviGecmisi = (ITTLabel)AddControl(new Guid("9467a77a-03e3-4b68-a9cc-3a643dadc13c"));
            SKRSPsikiyatrikTedaviGecmisi = (ITTObjectListBox)AddControl(new Guid("f0ec268e-e27d-4527-a6db-10a43b5145f1"));
            labelSKRSIntiharKrizVakaTuru = (ITTLabel)AddControl(new Guid("96cfebd3-8e77-4641-9c89-6ccfc28e71d4"));
            SKRSIntiharKrizVakaTuru = (ITTObjectListBox)AddControl(new Guid("37f57e4d-d16f-4e33-8aae-f0f03604913c"));
            labelSKRSIntiharGirisimiGecmisi = (ITTLabel)AddControl(new Guid("30557559-8674-4375-bb06-ec9067d32870"));
            SKRSIntiharGirisimiGecmisi = (ITTObjectListBox)AddControl(new Guid("003702a4-5344-40f1-87ff-f50206b55585"));
            labelSKRSAilesindePsikiyatrikVaka = (ITTLabel)AddControl(new Guid("d6cac2be-9366-4db2-a51c-1f0e43fd246b"));
            SKRSAilesindePsikiyatrikVaka = (ITTObjectListBox)AddControl(new Guid("c0d7f615-994f-471c-9253-161000c914b1"));
            labelSKRSAilesindeIntiharGirisimi = (ITTLabel)AddControl(new Guid("2a8dddab-c08c-49e0-8bdd-47746ae4c0fe"));
            SKRSAilesindeIntiharGirisimi = (ITTObjectListBox)AddControl(new Guid("56d26ef6-e941-4d90-a0a5-36659c466344"));
            IntiharGirisimiVakaSonucu = (ITTGrid)AddControl(new Guid("01ce2645-e75e-4664-afc0-d16e437d0cc7"));
            SKRSIntiharKrizVakaSonucuIntiharGirisimiVakaSonucu = (ITTListBoxColumn)AddControl(new Guid("c9f6a14a-a777-432a-b7e6-595db849dbd8"));
            IntiharGirisimiKrizNedeni = (ITTGrid)AddControl(new Guid("69cbb030-b4dc-456b-8768-d4cb5c6669f1"));
            SKRSIntiharGirisimKrizNedenIntiharGirisimiKrizNedeni = (ITTListBoxColumn)AddControl(new Guid("1d63026e-b230-4070-a015-bfa0551ad40a"));
            labelOlayZamani = (ITTLabel)AddControl(new Guid("b5fa3435-b2fe-4a7b-8b22-ab2316967a19"));
            OlayZamani = (ITTDateTimePicker)AddControl(new Guid("ed433ebc-e829-4d27-8ae6-12090668207a"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("3b100db7-92db-4f4b-8afe-fd834a7b1845"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("547ad54f-9d4b-447b-b7eb-0c2a262f1381"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("44584fa8-3694-4094-ad5a-740eff79b825"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("9a86e120-00ca-4800-a89e-94433bc8a628"));
            base.InitializeControls();
        }

        public IntiharGirisimiKrizTespitVeriSetiForm() : base("INTIHARGIRISIMKRIZVERISETI", "IntiharGirisimiKrizTespitVeriSetiForm")
        {
        }

        protected IntiharGirisimiKrizTespitVeriSetiForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}