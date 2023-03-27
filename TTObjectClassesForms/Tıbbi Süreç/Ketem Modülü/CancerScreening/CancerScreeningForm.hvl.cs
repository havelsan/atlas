
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
    public partial class CancerScreeningForm : TTForm
    {
    /// <summary>
    /// Toplum Tabanlı Kanser Tarama - NBZ247
    /// </summary>
        protected TTObjectClasses.CancerScreening _CancerScreening
        {
            get { return (TTObjectClasses.CancerScreening)_ttObject; }
        }

        protected ITTLabel labelSKRSTARAMATIPI;
        protected ITTObjectListBox SKRSTARAMATIPI;
        protected ITTLabel labelTaramaSonuclanmaTarihi;
        protected ITTDateTimePicker TaramaSonuclanmaTarihi;
        protected ITTLabel labelTaramaTarihi;
        protected ITTDateTimePicker TaramaTarihi;
        protected ITTGrid BreastBiopsy;
        protected ITTListBoxColumn SKRSMemedenBiyopsiAlimiBreastBiopsy;
        protected ITTListBoxColumn SKRSMemeBiyopsiSonucuBreastBiopsy;
        protected ITTGrid CervicalCytologyResults;
        protected ITTListBoxColumn SKRSServikalSitolojiSonucuCervicalCytologyResults;
        protected ITTGrid CervicalBiopsyResults;
        protected ITTListBoxColumn SKRSServikalBiyopsiSonucuCervicalBiopsyResults;
        protected ITTGrid ColorectalBiopsyResults;
        protected ITTListBoxColumn SKRSKolorektalBiyopsiSonucuColorectalBiopsyResults;
        protected ITTGrid ColonoscopyQualityCriteria;
        protected ITTListBoxColumn KolonoskopiKaliteKriterleriColonoscopyQualityCriteria;
        protected ITTLabel labelSKRSSigmoidoskopi;
        protected ITTObjectListBox SKRSSigmoidoskopi;
        protected ITTLabel labelSKRSPapSmearTesti;
        protected ITTObjectListBox SKRSPapSmearTesti;
        protected ITTLabel labelSKRSMamografiSonucu;
        protected ITTObjectListBox SKRSMamografiSonucu;
        protected ITTLabel labelSKRSMamografi;
        protected ITTObjectListBox SKRSMamografi;
        protected ITTLabel labelSKRSKolposkopi;
        protected ITTObjectListBox SKRSKolposkopi;
        protected ITTLabel labelSKRSKolonoskopininSuresi;
        protected ITTObjectListBox SKRSKolonoskopininSuresi;
        protected ITTLabel labelSKRSKlinikMemeMuayenesi;
        protected ITTObjectListBox SKRSKlinikMemeMuayenesi;
        protected ITTLabel labelSKRSKendiKendineMemeMuayenesi;
        protected ITTObjectListBox SKRSKendiKendineMemeMuayenesi;
        protected ITTLabel labelSKRSHPVTaramaTesti;
        protected ITTObjectListBox SKRSHPVTaramaTesti;
        protected ITTLabel labelSKRSKolonoskopi;
        protected ITTObjectListBox SKRSKolonoskopi;
        protected ITTLabel labelSKRSKolonGoruntulemeYontemi;
        protected ITTObjectListBox SKRSKolonGoruntulemeYontemi;
        protected ITTLabel labelSKRSGaitadaGizliKanTesti;
        protected ITTObjectListBox SKRSGaitadaGizliKanTesti;
        protected ITTGrid HPVTypeInfo;
        protected ITTListBoxColumn SKRSHpvTipiHPVTypeInfo;
        override protected void InitializeControls()
        {
            labelSKRSTARAMATIPI = (ITTLabel)AddControl(new Guid("e8ee44ce-b1ee-429c-b400-cb0dfa5fcbbe"));
            SKRSTARAMATIPI = (ITTObjectListBox)AddControl(new Guid("3c335f4d-7ed9-4483-8eab-abc1594c6578"));
            labelTaramaSonuclanmaTarihi = (ITTLabel)AddControl(new Guid("bab40d39-fcc2-4911-a5a1-14ceaf363aea"));
            TaramaSonuclanmaTarihi = (ITTDateTimePicker)AddControl(new Guid("c330c3e7-9948-46d6-b8f7-903ffd1f9a99"));
            labelTaramaTarihi = (ITTLabel)AddControl(new Guid("e9d6ae75-3a10-4738-8863-c76e0cf4edab"));
            TaramaTarihi = (ITTDateTimePicker)AddControl(new Guid("74a2f8fb-192a-4cfa-9530-7e77bd4dd6ad"));
            BreastBiopsy = (ITTGrid)AddControl(new Guid("5815143d-5bcb-4b32-8f77-d3eec9a9daed"));
            SKRSMemedenBiyopsiAlimiBreastBiopsy = (ITTListBoxColumn)AddControl(new Guid("9c8e6a43-456c-4ecd-a212-8a8fae4e5fc7"));
            SKRSMemeBiyopsiSonucuBreastBiopsy = (ITTListBoxColumn)AddControl(new Guid("92f87aa5-3330-476e-835a-b1131063a913"));
            CervicalCytologyResults = (ITTGrid)AddControl(new Guid("9e9b2f62-4e3a-48b3-9145-d97b8d2fb2b8"));
            SKRSServikalSitolojiSonucuCervicalCytologyResults = (ITTListBoxColumn)AddControl(new Guid("1e8d5936-81a6-49cc-bd4a-7a18de113c06"));
            CervicalBiopsyResults = (ITTGrid)AddControl(new Guid("87755794-c2ee-43c9-92b5-165aaef71067"));
            SKRSServikalBiyopsiSonucuCervicalBiopsyResults = (ITTListBoxColumn)AddControl(new Guid("71ff13bd-2064-4df1-aa59-201c7a742f6a"));
            ColorectalBiopsyResults = (ITTGrid)AddControl(new Guid("8eeab75c-a57c-405b-8c32-3140566ebccb"));
            SKRSKolorektalBiyopsiSonucuColorectalBiopsyResults = (ITTListBoxColumn)AddControl(new Guid("e8471a61-e1cf-44e6-9600-ea505c8514f0"));
            ColonoscopyQualityCriteria = (ITTGrid)AddControl(new Guid("4ce9ed2c-7a73-49de-8cd9-2a29fbc6b38a"));
            KolonoskopiKaliteKriterleriColonoscopyQualityCriteria = (ITTListBoxColumn)AddControl(new Guid("75b32f01-d162-4013-9f68-9fe2b1e9bbcf"));
            labelSKRSSigmoidoskopi = (ITTLabel)AddControl(new Guid("9aae0176-1de8-4dc4-b398-61a053622e12"));
            SKRSSigmoidoskopi = (ITTObjectListBox)AddControl(new Guid("02c59db3-29c3-4f73-aa94-bd8b0cb0af8f"));
            labelSKRSPapSmearTesti = (ITTLabel)AddControl(new Guid("aff03f7c-e695-42d0-b178-46781c5665c2"));
            SKRSPapSmearTesti = (ITTObjectListBox)AddControl(new Guid("b918d41b-e00e-4d0a-9105-0468b63ed564"));
            labelSKRSMamografiSonucu = (ITTLabel)AddControl(new Guid("a50b253f-3422-406b-a56d-8b6f82190bda"));
            SKRSMamografiSonucu = (ITTObjectListBox)AddControl(new Guid("2f99c3d5-cb81-4da0-b04c-df5b17e7aaef"));
            labelSKRSMamografi = (ITTLabel)AddControl(new Guid("2bd9bec6-3d37-4f7f-b0fa-07fcf783a4be"));
            SKRSMamografi = (ITTObjectListBox)AddControl(new Guid("d2b9cd09-e2a6-4463-abe6-6abe36da8a17"));
            labelSKRSKolposkopi = (ITTLabel)AddControl(new Guid("d26348d6-2e9b-4837-8899-6648bf3866a0"));
            SKRSKolposkopi = (ITTObjectListBox)AddControl(new Guid("97bbce07-63a1-4d2b-acc1-05cf5f716cb6"));
            labelSKRSKolonoskopininSuresi = (ITTLabel)AddControl(new Guid("479f78cd-5f04-4d4f-8c2f-4e2d7359227f"));
            SKRSKolonoskopininSuresi = (ITTObjectListBox)AddControl(new Guid("f9c5f903-3407-4a0c-a151-e156951c1b5d"));
            labelSKRSKlinikMemeMuayenesi = (ITTLabel)AddControl(new Guid("e1cb86c6-65b3-4187-a703-1627fd69c704"));
            SKRSKlinikMemeMuayenesi = (ITTObjectListBox)AddControl(new Guid("6c4773ea-5498-4ee8-8d03-bf8b9dba0a21"));
            labelSKRSKendiKendineMemeMuayenesi = (ITTLabel)AddControl(new Guid("8a5f40b8-700c-4496-9d39-7d32747cdd36"));
            SKRSKendiKendineMemeMuayenesi = (ITTObjectListBox)AddControl(new Guid("d731328b-d11f-4cf6-8200-2bb5e4cf2fcd"));
            labelSKRSHPVTaramaTesti = (ITTLabel)AddControl(new Guid("439fc886-6b80-46c1-ada8-7ae22fd60d64"));
            SKRSHPVTaramaTesti = (ITTObjectListBox)AddControl(new Guid("f30e615f-aa9a-4566-b28f-c0ab90b978d0"));
            labelSKRSKolonoskopi = (ITTLabel)AddControl(new Guid("9028baab-2466-4915-acae-7ed2f131bbe9"));
            SKRSKolonoskopi = (ITTObjectListBox)AddControl(new Guid("b4dd8669-a7de-477f-b31c-e494eb207911"));
            labelSKRSKolonGoruntulemeYontemi = (ITTLabel)AddControl(new Guid("924a7e2b-583f-4776-b063-5f64ccb19e2d"));
            SKRSKolonGoruntulemeYontemi = (ITTObjectListBox)AddControl(new Guid("99f3bacf-d1e8-4a26-bed8-c8c34f661378"));
            labelSKRSGaitadaGizliKanTesti = (ITTLabel)AddControl(new Guid("621d9ec8-c28e-4b79-93d0-12ba56f3fd91"));
            SKRSGaitadaGizliKanTesti = (ITTObjectListBox)AddControl(new Guid("b0545813-f0d3-4f72-8992-7353515d46a0"));
            HPVTypeInfo = (ITTGrid)AddControl(new Guid("740eccfd-189b-4da4-a98b-9343e642b2c6"));
            SKRSHpvTipiHPVTypeInfo = (ITTListBoxColumn)AddControl(new Guid("b8a97168-c278-404a-8836-f847eaa12503"));
            base.InitializeControls();
        }

        public CancerScreeningForm() : base("CANCERSCREENING", "CancerScreeningForm")
        {
        }

        protected CancerScreeningForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}