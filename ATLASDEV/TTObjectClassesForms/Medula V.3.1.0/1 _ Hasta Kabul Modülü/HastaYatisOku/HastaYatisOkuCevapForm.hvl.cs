
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
    /// Hasta Yatış Oku Cevap
    /// </summary>
    public partial class HastaYatisOkuCevapForm : BaseHastaYatisOkuForm
    {
    /// <summary>
    /// Hasta Yatış Oku
    /// </summary>
        protected TTObjectClasses.HastaYatisOku _HastaYatisOku
        {
            get { return (TTObjectClasses.HastaYatisOku)_ttObject; }
        }

        protected ITTGroupBox groupboxCevapBilgileri;
        protected ITTLabel labelsaglikTesisiKoduCevap;
        protected ITTTextBox sonucMesaji;
        protected ITTValueListBox saglikTesisiKoduCevap;
        protected ITTLabel labelsonucMesaji;
        protected ITTGrid basvuruYatisBilgileri;
        protected ITTTextBoxColumn baslangicTarihi;
        protected ITTTextBoxColumn bitisTarihi;
        protected ITTTextBoxColumn durum;
        protected ITTLabel labelyeniDoganCocukSiraNo;
        protected ITTLabel labelyeniDoganDogumTarihi;
        protected ITTTextBox yeniDoganCocukSiraNo;
        protected ITTTextBox sonucKodu;
        protected ITTTextBox yeniDoganDogumTarihi;
        protected ITTLabel labelsonucKodu;
        protected ITTLabel labelhastaBasvuruNoCevap;
        protected ITTTextBox hastaBasvuruNoCevap;
        protected ITTLabel labeldonorTck;
        protected ITTTextBox donorTck;
        override protected void InitializeControls()
        {
            groupboxCevapBilgileri = (ITTGroupBox)AddControl(new Guid("4c96bfc2-fd72-49c1-a6a3-35a9d2c8cf52"));
            labelsaglikTesisiKoduCevap = (ITTLabel)AddControl(new Guid("6ef183f9-33e2-440a-8708-b1e2c6fec963"));
            sonucMesaji = (ITTTextBox)AddControl(new Guid("74063cb5-73e0-49f1-981f-701e379a326b"));
            saglikTesisiKoduCevap = (ITTValueListBox)AddControl(new Guid("e2c88322-17e6-416c-93fe-6a4f3563772f"));
            labelsonucMesaji = (ITTLabel)AddControl(new Guid("546a6dc2-f2ad-4242-8006-d668df61c73d"));
            basvuruYatisBilgileri = (ITTGrid)AddControl(new Guid("711e0a47-a62e-49c3-9b0b-c303a0418161"));
            baslangicTarihi = (ITTTextBoxColumn)AddControl(new Guid("175ed64f-c92e-4312-a5b2-08be3d63ef39"));
            bitisTarihi = (ITTTextBoxColumn)AddControl(new Guid("e8b65aac-a035-4d0e-ac0f-fde3cbea4617"));
            durum = (ITTTextBoxColumn)AddControl(new Guid("3dea8ef7-46a5-4cf6-9169-3a483481c401"));
            labelyeniDoganCocukSiraNo = (ITTLabel)AddControl(new Guid("4c7233d1-b535-47a3-b64c-6898cf0ceebf"));
            labelyeniDoganDogumTarihi = (ITTLabel)AddControl(new Guid("b62c79bc-73c2-43e2-a413-4bfeccdcd1cd"));
            yeniDoganCocukSiraNo = (ITTTextBox)AddControl(new Guid("7a20f6b2-c22b-44d0-874f-b0f893767d21"));
            sonucKodu = (ITTTextBox)AddControl(new Guid("193d4b6c-a7c3-468a-a532-9c5e2e9cb806"));
            yeniDoganDogumTarihi = (ITTTextBox)AddControl(new Guid("da6cc79e-8a58-4b23-a6dd-6a8fe4d8905b"));
            labelsonucKodu = (ITTLabel)AddControl(new Guid("6bbb1e04-ab2b-4424-8185-92f55a8aab7c"));
            labelhastaBasvuruNoCevap = (ITTLabel)AddControl(new Guid("cfe21ec9-cf01-47a7-b207-e4434d2cf931"));
            hastaBasvuruNoCevap = (ITTTextBox)AddControl(new Guid("7f140db5-ec36-4fd3-8a41-d59c8c629a59"));
            labeldonorTck = (ITTLabel)AddControl(new Guid("78f4512d-bed2-4d00-87a1-dfd712c23642"));
            donorTck = (ITTTextBox)AddControl(new Guid("906dae95-6296-43cf-beaf-3462648bf758"));
            base.InitializeControls();
        }

        public HastaYatisOkuCevapForm() : base("HASTAYATISOKU", "HastaYatisOkuCevapForm")
        {
        }

        protected HastaYatisOkuCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}