
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
    /// Temel Hasta Kabul Cevap
    /// </summary>
    public partial class BaseHastaKabulCevapForm : BaseHastaKabulForm
    {
    /// <summary>
    /// Hasta Kabul
    /// </summary>
        protected TTObjectClasses.BaseHastaKabul _BaseHastaKabul
        {
            get { return (TTObjectClasses.BaseHastaKabul)_ttObject; }
        }

        protected ITTTabPage tabpageCevapBilgileri;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage hastaBilgileriTabpage;
        protected ITTValueListBox devredilenKurumHastaBilgileriDVO;
        protected ITTLabel labeldevredilenKurumHastaBilgileriDVO;
        protected ITTLabel labelhastaTCKimlikNoCevap;
        protected ITTTextBox dogumTarihiCevap;
        protected ITTTextBox adCevap;
        protected ITTLabel labelsoyadCevap;
        protected ITTLabel labelSigortaliTuruCevap;
        protected ITTListDefComboBox SigortaliTuruCevap;
        protected ITTLabel labeladCevap;
        protected ITTDateTimePicker dogumTarihiCevapDateTimePicker;
        protected ITTTextBox soyadCevap;
        protected ITTListDefComboBox cinsiyetCevap;
        protected ITTTextBox hastaTCKimlikNoCevap;
        protected ITTLabel labeldogumTarihiCevap;
        protected ITTLabel labelcinsiyetCevap;
        protected ITTTabPage sigortaliAdliGecmisiTabpage;
        protected ITTGrid sigortaliAdliGecmisiSigortaliAdliGecmisDVO;
        protected ITTTextBoxColumn tckNoSigortaliAdliGecmisDVO;
        protected ITTTextBoxColumn provTipiSigortaliAdliGecmisDVO;
        protected ITTTextBoxColumn provTarihiSigortaliAdliGecmisDVO;
        protected ITTGroupBox groupboxCevapBilgileri;
        protected ITTLabel labelhastaBasvuruNo;
        protected ITTTextBox sonucMesaji;
        protected ITTTextBox hastaBasvuruNo;
        protected ITTLabel labeltakipNo;
        protected ITTLabel labelsonucMesaji;
        protected ITTTextBox sonucKodu;
        protected ITTTextBox takipNo;
        protected ITTLabel labelsonucKodu;
        protected ITTTabPage tabpageCode2D;
        protected ITTButton writeFileButton;
        protected ITTBarcodeBox Code2D;
        override protected void InitializeControls()
        {
            tabpageCevapBilgileri = (ITTTabPage)AddControl(new Guid("41224d30-d7ab-4ae3-a9d2-ca0780205cfc"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("4d91579f-77e8-47a1-ac9d-ff043a225ec5"));
            hastaBilgileriTabpage = (ITTTabPage)AddControl(new Guid("9b02c5a3-124e-461c-af98-216179d4e56a"));
            devredilenKurumHastaBilgileriDVO = (ITTValueListBox)AddControl(new Guid("bbe6036d-6d37-49f3-98ec-1eb0436fd362"));
            labeldevredilenKurumHastaBilgileriDVO = (ITTLabel)AddControl(new Guid("e7ede8dc-53ee-4aa6-a679-54c2e0a7d370"));
            labelhastaTCKimlikNoCevap = (ITTLabel)AddControl(new Guid("3740546c-7a16-49b3-aaed-3d667db55e28"));
            dogumTarihiCevap = (ITTTextBox)AddControl(new Guid("49505b90-90c4-4b4a-9843-9ef1213f34ea"));
            adCevap = (ITTTextBox)AddControl(new Guid("e9440e16-fd72-4229-9d7c-11924fe69e9c"));
            labelsoyadCevap = (ITTLabel)AddControl(new Guid("c2d6ff98-82b3-433e-9b44-75a1f9a7b301"));
            labelSigortaliTuruCevap = (ITTLabel)AddControl(new Guid("901ae774-0abd-4370-8c50-2cfac6dae105"));
            SigortaliTuruCevap = (ITTListDefComboBox)AddControl(new Guid("3c153a73-2bfa-42fd-b04d-83bf4573045b"));
            labeladCevap = (ITTLabel)AddControl(new Guid("6d83b10d-c49e-4bb9-beed-a6e71a3dd14f"));
            dogumTarihiCevapDateTimePicker = (ITTDateTimePicker)AddControl(new Guid("14d5dc4b-5839-493d-a5ad-002836ab9aff"));
            soyadCevap = (ITTTextBox)AddControl(new Guid("ada0d22f-bd2a-4af9-b139-3670265e9a11"));
            cinsiyetCevap = (ITTListDefComboBox)AddControl(new Guid("674a566d-9d71-4e4e-8307-870b37667a8d"));
            hastaTCKimlikNoCevap = (ITTTextBox)AddControl(new Guid("f1be72bc-4cd3-4250-80f3-650b2ab91cfe"));
            labeldogumTarihiCevap = (ITTLabel)AddControl(new Guid("666ecd4f-4858-4bb2-b32a-3c41449aab47"));
            labelcinsiyetCevap = (ITTLabel)AddControl(new Guid("dd11fb18-ff54-4ac4-8f0e-1a379a736993"));
            sigortaliAdliGecmisiTabpage = (ITTTabPage)AddControl(new Guid("db167595-164a-4c37-b79d-a10310ea7da6"));
            sigortaliAdliGecmisiSigortaliAdliGecmisDVO = (ITTGrid)AddControl(new Guid("5fe7f0ca-a1f1-41e8-ab42-3a60e7867427"));
            tckNoSigortaliAdliGecmisDVO = (ITTTextBoxColumn)AddControl(new Guid("51153aa2-ccdc-4ce3-ae98-c65e91cad979"));
            provTipiSigortaliAdliGecmisDVO = (ITTTextBoxColumn)AddControl(new Guid("5b4c2072-f28d-4b36-80b5-575311e0929a"));
            provTarihiSigortaliAdliGecmisDVO = (ITTTextBoxColumn)AddControl(new Guid("c6717ec8-1412-43d8-bbfc-277bc5d17770"));
            groupboxCevapBilgileri = (ITTGroupBox)AddControl(new Guid("9396994e-1a5e-4891-87b1-9800f4a8e245"));
            labelhastaBasvuruNo = (ITTLabel)AddControl(new Guid("950caece-5382-4534-af24-17840d35504b"));
            sonucMesaji = (ITTTextBox)AddControl(new Guid("74cbbda5-6055-4715-8a9c-b904edd361f0"));
            hastaBasvuruNo = (ITTTextBox)AddControl(new Guid("97ae5161-9b50-4a70-be6e-c861436d7a1b"));
            labeltakipNo = (ITTLabel)AddControl(new Guid("6579e417-23df-48a6-b4bd-3432052f4db7"));
            labelsonucMesaji = (ITTLabel)AddControl(new Guid("f851e7f9-ca89-4aa1-b871-3c76795f39cf"));
            sonucKodu = (ITTTextBox)AddControl(new Guid("838180c4-0c2a-4513-b348-1b4f14048306"));
            takipNo = (ITTTextBox)AddControl(new Guid("8a0656fc-a3a4-4c53-b63d-ed9437a9d188"));
            labelsonucKodu = (ITTLabel)AddControl(new Guid("b40b7936-e389-4a06-8e60-1315cb4b4e12"));
            tabpageCode2D = (ITTTabPage)AddControl(new Guid("a37593d0-be86-4ad8-919b-1dd44dabded9"));
            writeFileButton = (ITTButton)AddControl(new Guid("1a3231b5-c119-4d88-881f-ee78b5a315b5"));
            Code2D = (ITTBarcodeBox)AddControl(new Guid("7d5f6ac5-ca3c-4045-83ac-aeada27a1742"));
            base.InitializeControls();
        }

        public BaseHastaKabulCevapForm() : base("BASEHASTAKABUL", "BaseHastaKabulCevapForm")
        {
        }

        protected BaseHastaKabulCevapForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}