
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
    /// Hasta Kabul Oku Cevap
    /// </summary>
    public partial class BaseHastaKabulOkuCevapForm : BaseMedulaActionForm
    {
        protected TTObjectClasses.BaseHastaKabulOku _BaseHastaKabulOku
        {
            get { return (TTObjectClasses.BaseHastaKabulOku)_ttObject; }
        }

        protected ITTTextBox takipNo;
        protected ITTLabel labelsaglikTesisKodu;
        protected ITTLabel labeltakipNo;
        protected ITTValueListBox saglikTesisKodu;
        protected ITTGroupBox groupboxCevapBilgileri;
        protected ITTDateTimePicker yeniDoganDogumTarihiDatetimepicker;
        protected ITTDateTimePicker kayitTarihiDatetimepicker;
        protected ITTDateTimePicker takipTarihiDatetimepicker;
        protected ITTTextBox sonucMesaji;
        protected ITTLabel labeltakipNoCevap;
        protected ITTLabel labelsonucMesaji;
        protected ITTTextBox sonucKodu;
        protected ITTTextBox takipNoCevap;
        protected ITTLabel labeltesisKodu;
        protected ITTListDefComboBox takipDurumu;
        protected ITTListDefComboBox sevkDurumu;
        protected ITTValueListBox tesisKodu;
        protected ITTValueListBox bransKodu;
        protected ITTListDefComboBox provizyonTipi;
        protected ITTListDefComboBox tedaviTuru;
        protected ITTListDefComboBox tedaviTipi;
        protected ITTListDefComboBox takipTipi;
        protected ITTLabel labelsonucKodu;
        protected ITTLabel labeltedaviTuru;
        protected ITTLabel labelyeniDoganDogumTarihi;
        protected ITTTextBox yeniDoganDogumTarihi;
        protected ITTLabel labeltedaviTipi;
        protected ITTLabel labelilkTakipNo;
        protected ITTTextBox ilkTakipNo;
        protected ITTLabel labeltakipTipi;
        protected ITTLabel labelyeniDoganCocukSiraNo;
        protected ITTTextBox yeniDoganCocukSiraNo;
        protected ITTLabel labeltakipDurumu;
        protected ITTLabel labeltakipTarihi;
        protected ITTTextBox takipTarihi;
        protected ITTLabel labelsevkDurumu;
        protected ITTLabel labelkayitTarihi;
        protected ITTTextBox kayitTarihi;
        protected ITTLabel labelprovizyonTipi;
        protected ITTLabel labeldonorTCKimlikNo;
        protected ITTTextBox donorTCKimlikNo;
        protected ITTLabel labelfaturaTeslimNo;
        protected ITTTextBox faturaTeslimNo;
        protected ITTLabel labelhastaBasvuruNo;
        protected ITTTextBox hastaBasvuruNo;
        protected ITTLabel labelbransKodu;
        protected ITTGroupBox groupboxCevapHastaBilgileri;
        protected ITTLabel labelhastaTCKimlikNoCevap;
        protected ITTTextBox dogumTarihiCevap;
        protected ITTLabel labelsoyadCevap;
        protected ITTListDefComboBox SigortaliTuruCevap;
        protected ITTDateTimePicker dogumTarihiCevapDateTimePicker;
        protected ITTListDefComboBox cinsiyetCevap;
        protected ITTLabel labeldogumTarihiCevap;
        protected ITTLabel labelcinsiyetCevap;
        protected ITTTextBox hastaTCKimlikNoCevap;
        protected ITTTextBox soyadCevap;
        protected ITTLabel labeladCevap;
        protected ITTLabel labelSigortaliTuruCevap;
        protected ITTTextBox adCevap;
        override protected void InitializeControls()
        {
            takipNo = (ITTTextBox)AddControl(new Guid("b95257d5-7cbc-438e-b914-7b14ead9bb31"));
            labelsaglikTesisKodu = (ITTLabel)AddControl(new Guid("8d617f83-f579-4880-bd40-19414984dd47"));
            labeltakipNo = (ITTLabel)AddControl(new Guid("3a0cdec0-a9ab-498a-852b-a3fdeb2aaec1"));
            saglikTesisKodu = (ITTValueListBox)AddControl(new Guid("23e2ab90-4926-443d-b4f7-d1f847326e01"));
            groupboxCevapBilgileri = (ITTGroupBox)AddControl(new Guid("3b8fa104-193e-4e3c-8944-ce6a62604d26"));
            yeniDoganDogumTarihiDatetimepicker = (ITTDateTimePicker)AddControl(new Guid("fe754c16-9116-4fba-90db-fdc2b7c9103d"));
            kayitTarihiDatetimepicker = (ITTDateTimePicker)AddControl(new Guid("1da988c6-616a-40cf-a69b-f6b0720958cf"));
            takipTarihiDatetimepicker = (ITTDateTimePicker)AddControl(new Guid("3b7710af-df99-4d89-81e8-4cd0b575d7b3"));
            sonucMesaji = (ITTTextBox)AddControl(new Guid("dda0ed82-4c00-4e24-b0da-ddf22d9f1182"));
            labeltakipNoCevap = (ITTLabel)AddControl(new Guid("876487bc-4f92-4330-b2c0-baf793fa38a1"));
            labelsonucMesaji = (ITTLabel)AddControl(new Guid("e3ce0c42-36c3-4904-952f-753c55a17690"));
            sonucKodu = (ITTTextBox)AddControl(new Guid("0460a001-599c-4f41-9f5b-4ec35caad0a8"));
            takipNoCevap = (ITTTextBox)AddControl(new Guid("46905f3b-97e0-4f07-8758-0e353cf1e45d"));
            labeltesisKodu = (ITTLabel)AddControl(new Guid("caeba044-1375-4194-8e86-2b56eb62f4fe"));
            takipDurumu = (ITTListDefComboBox)AddControl(new Guid("622f911c-4d0e-40f1-b94b-aa492c7fbdee"));
            sevkDurumu = (ITTListDefComboBox)AddControl(new Guid("a29d16c5-1162-42b6-b373-f49ab905f4d5"));
            tesisKodu = (ITTValueListBox)AddControl(new Guid("a411c45b-0cc9-432c-805f-8647b583fdb7"));
            bransKodu = (ITTValueListBox)AddControl(new Guid("ac767352-d284-4f37-a2d4-4bee55506dd1"));
            provizyonTipi = (ITTListDefComboBox)AddControl(new Guid("b5839828-962d-431d-8a81-d98aaeca37eb"));
            tedaviTuru = (ITTListDefComboBox)AddControl(new Guid("24d40555-9fde-4dd4-b518-4f4967ee28e8"));
            tedaviTipi = (ITTListDefComboBox)AddControl(new Guid("08b8a004-d256-4caf-9b03-e8e0bf1f5143"));
            takipTipi = (ITTListDefComboBox)AddControl(new Guid("28c7fd4e-c3c0-41ad-b79e-864c1b91ae2e"));
            labelsonucKodu = (ITTLabel)AddControl(new Guid("18727a39-39d1-48ed-b19a-8a23b3501d54"));
            labeltedaviTuru = (ITTLabel)AddControl(new Guid("db799785-7124-4ede-b170-faad11988323"));
            labelyeniDoganDogumTarihi = (ITTLabel)AddControl(new Guid("9a289a73-97f4-42bf-972e-3abebc4fe5e3"));
            yeniDoganDogumTarihi = (ITTTextBox)AddControl(new Guid("728f12e3-d48b-4328-8ce2-92093bd5ebb6"));
            labeltedaviTipi = (ITTLabel)AddControl(new Guid("e3e109a4-3439-422e-8fd9-1c74e7600948"));
            labelilkTakipNo = (ITTLabel)AddControl(new Guid("1acfa802-8b73-4b59-9498-c49faba08e32"));
            ilkTakipNo = (ITTTextBox)AddControl(new Guid("3c276724-7bd9-492c-b1b1-0c82a74479df"));
            labeltakipTipi = (ITTLabel)AddControl(new Guid("f6be1903-33d7-4983-aefd-c6c9e9c0e99a"));
            labelyeniDoganCocukSiraNo = (ITTLabel)AddControl(new Guid("1a03229e-8385-49b6-960d-fb8b5156762a"));
            yeniDoganCocukSiraNo = (ITTTextBox)AddControl(new Guid("f856bf84-1e34-48ca-8b51-beadebc70821"));
            labeltakipDurumu = (ITTLabel)AddControl(new Guid("ba8cb2e8-efc2-4900-8d01-bffa4fd5e1c4"));
            labeltakipTarihi = (ITTLabel)AddControl(new Guid("156d1e0b-0068-4c6e-9c0c-f35d15b18ce2"));
            takipTarihi = (ITTTextBox)AddControl(new Guid("02b4409a-abd1-4847-bb7c-954dfc8835f0"));
            labelsevkDurumu = (ITTLabel)AddControl(new Guid("92a4e41e-828b-477e-86e1-85c4cb92b7e5"));
            labelkayitTarihi = (ITTLabel)AddControl(new Guid("19433f37-d476-48c6-ad16-d81fb65a8562"));
            kayitTarihi = (ITTTextBox)AddControl(new Guid("c4c9b53d-e32d-472e-9455-cc7b04dec6eb"));
            labelprovizyonTipi = (ITTLabel)AddControl(new Guid("e4105949-4861-4203-a012-660e7d43197a"));
            labeldonorTCKimlikNo = (ITTLabel)AddControl(new Guid("42f36c26-4976-4b1a-95c2-bc39b02e1c9d"));
            donorTCKimlikNo = (ITTTextBox)AddControl(new Guid("75fd4247-3a99-4043-8652-86ed338f6196"));
            labelfaturaTeslimNo = (ITTLabel)AddControl(new Guid("6d2e3ce5-bed1-4c49-b1a3-1d22da2ab7e3"));
            faturaTeslimNo = (ITTTextBox)AddControl(new Guid("c89865f1-0139-4112-97ad-3f662391040b"));
            labelhastaBasvuruNo = (ITTLabel)AddControl(new Guid("1779172a-68e2-4e33-9f61-4aaaf6eb1f25"));
            hastaBasvuruNo = (ITTTextBox)AddControl(new Guid("e24d3142-be64-4d0e-a759-4919c23e39eb"));
            labelbransKodu = (ITTLabel)AddControl(new Guid("9cd97154-d439-4862-95b4-94b7c3dc8f86"));
            groupboxCevapHastaBilgileri = (ITTGroupBox)AddControl(new Guid("0f1a1012-b3a5-4271-9df7-47b3072b0ba0"));
            labelhastaTCKimlikNoCevap = (ITTLabel)AddControl(new Guid("3b59f2b2-ff8c-47a2-98a5-5b184e4c8c7d"));
            dogumTarihiCevap = (ITTTextBox)AddControl(new Guid("af5ec249-0309-4cb8-ac1d-55708aebf4da"));
            labelsoyadCevap = (ITTLabel)AddControl(new Guid("950c78bb-5fec-40ad-9fbc-1dc2b369d96d"));
            SigortaliTuruCevap = (ITTListDefComboBox)AddControl(new Guid("0c7a2fd6-7b04-4730-aa02-7abf498cef25"));
            dogumTarihiCevapDateTimePicker = (ITTDateTimePicker)AddControl(new Guid("547a499d-a08f-44f9-a501-7f9661e38153"));
            cinsiyetCevap = (ITTListDefComboBox)AddControl(new Guid("13464d47-5a48-4a73-a7ce-8e81ddd207af"));
            labeldogumTarihiCevap = (ITTLabel)AddControl(new Guid("77323035-0278-437d-8cd0-065be72dbc13"));
            labelcinsiyetCevap = (ITTLabel)AddControl(new Guid("3b16de75-65ca-406f-889f-611cd3a667b7"));
            hastaTCKimlikNoCevap = (ITTTextBox)AddControl(new Guid("c078d0ef-7fcd-4584-ad7b-96179e29d3c6"));
            soyadCevap = (ITTTextBox)AddControl(new Guid("03bff9be-3ab0-4917-a603-de91a75926b0"));
            labeladCevap = (ITTLabel)AddControl(new Guid("bb0658cb-5a1a-492c-bd6b-f1a98cb5a100"));
            labelSigortaliTuruCevap = (ITTLabel)AddControl(new Guid("9f36ae5e-ad63-4b32-a2b1-80666c9aeb12"));
            adCevap = (ITTTextBox)AddControl(new Guid("9a97ac6a-fa41-4f08-a480-fa9863b927b3"));
            base.InitializeControls();
        }

        public BaseHastaKabulOkuCevapForm() : base("BASEHASTAKABULOKU", "BaseHastaKabulOkuCevapForm")
        {
        }

        protected BaseHastaKabulOkuCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}