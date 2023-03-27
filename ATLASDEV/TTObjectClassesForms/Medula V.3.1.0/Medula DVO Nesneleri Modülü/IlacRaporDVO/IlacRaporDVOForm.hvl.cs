
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
    public partial class IlacRaporDVOForm : BaseMedulaObjectForm
    {
        protected TTObjectClasses.IlacRaporDVO _IlacRaporDVO
        {
            get { return (TTObjectClasses.IlacRaporDVO)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage RaporEtkinMaddeDVOTabpage;
        protected ITTGrid raporEtkinMaddelerRaporEtkinMaddeDVO;
        protected ITTListBoxColumn etkinMaddeKoduRaporEtkinMaddeDVO;
        protected ITTTextBoxColumn kullanimDoz1RaporEtkinMaddeDVO;
        protected ITTTextBoxColumn kullanimDoz2RaporEtkinMaddeDVO;
        protected ITTListDefComboBoxColumn kullanimDozBirimRaporEtkinMaddeDVO;
        protected ITTTextBoxColumn kullanimPeriyotRaporEtkinMaddeDVO;
        protected ITTListDefComboBoxColumn kullanimPeriyotBirimRaporEtkinMaddeDVO;
        protected ITTTabPage DoktorBilgisiDVOTabpage;
        protected ITTGrid doktorlarDoktorBilgisiDVO;
        protected ITTTextBoxColumn drTescilNoDoktorBilgisiDVO;
        protected ITTTextBoxColumn drAdiDoktorBilgisiDVO;
        protected ITTTextBoxColumn drSoyadiDoktorBilgisiDVO;
        protected ITTListBoxColumn drBransKoduDoktorBilgisiDVO;
        protected ITTListDefComboBoxColumn tipiDoktorBilgisiDVO;
        protected ITTTabPage IlacTeshisBilgiDVOTabpage;
        protected ITTGrid ilacTeshislerIlacTeshisBilgisiDVO;
        protected ITTDateTimePickerColumn baslangicTarihiIlacTeshisBilgisiDVO;
        protected ITTDateTimePickerColumn bitisTarihiIlacTeshisBilgisiDVO;
        protected ITTListBoxColumn teshisKoduIlacTeshisBilgisiDVO;
        protected ITTListBoxColumn ICD10KoduIlacTeshisBilgisiDVO;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labeltakipFormuNoIlacRaporDVO;
        protected ITTTextBox takipFormuNoIlacRaporDVO;
        protected ITTLabel labelnoRaporBilgisiDVO;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage aciklamaTabpage;
        protected ITTTextBox aciklamaRaporDVO;
        protected ITTTabPage klinikTaniTabpage;
        protected ITTTextBox klinikTanıRaporDVO;
        protected ITTTabPage hakSahibiBilgisiTabpage;
        protected ITTLabel labeltckimlikNoHakSahibiBilgisiDVO;
        protected ITTLabel labelsoyadiHakSahibiBilgisiDVO;
        protected ITTTextBox karneNoHakSahibiBilgisiDVO;
        protected ITTTextBox sosyalGuvenlikNoHakSahibiBilgisiDVO;
        protected ITTLabel labelprovizyonTipiHakSahibiBilgisiDVO;
        protected ITTTextBox soyadiHakSahibiBilgisiDVO;
        protected ITTLabel labelyakinlikKoduHakSahibiBilgisiDVO;
        protected ITTLabel labelsosyalGuvenlikNoHakSahibiBilgisiDVO;
        protected ITTListDefComboBox provizyonTipiHakSahibiBilgisiDVO;
        protected ITTLabel labelprovizyonTarihiDateTimeHakSahibiBilgisiDVO;
        protected ITTLabel labelkarneNoHakSahibiBilgisiDVO;
        protected ITTTextBox yakinlikKoduHakSahibiBilgisiDVO;
        protected ITTLabel labelsigortaliTuruHakSahibiBilgisiDVO;
        protected ITTDateTimePicker provizyonTarihiDateTimeHakSahibiBilgisiDVO;
        protected ITTTextBox tckimlikNoHakSahibiBilgisiDVO;
        protected ITTListDefComboBox devredilenKurumHakSahibiBilgisiDVO;
        protected ITTListDefComboBox sigortaliTuruHakSahibiBilgisiDVO;
        protected ITTLabel labeladiHakSahibiBilgisiDVO;
        protected ITTTextBox adiHakSahibiBilgisiDVO;
        protected ITTLabel labeldevredilenKurumHakSahibiBilgisiDVO;
        protected ITTListDefComboBox duzenlemeTuruRaporDVO;
        protected ITTLabel labelduzenlemeTuruRaporDVO;
        protected ITTTextBox noRaporBilgisiDVO;
        protected ITTLabel labelprotokolNoRaporDVO;
        protected ITTTextBox protokolNoRaporDVO;
        protected ITTDateTimePicker baslangicTarihiDateTimeRaporDVO;
        protected ITTLabel labelbaslangicTarihiDateTimeRaporDVO;
        protected ITTDateTimePicker bitisTarihiDateTimeRaporDVO;
        protected ITTLabel labeltarihDateTimeRaporBilgisiDVO;
        protected ITTLabel labelbitisTarihiDateTimeRaporDVO;
        protected ITTListDefComboBox turuRaporDVO;
        protected ITTDateTimePicker protokolTarihiDateTimeRaporDVO;
        protected ITTLabel labelturuRaporDVO;
        protected ITTLabel labelprotokolTarihiDateTimeRaporDVO;
        protected ITTDateTimePicker tarihDateTimeRaporBilgisiDVO;
        protected ITTValueListBox raporTesisKoduRaporBilgisiDVO;
        protected ITTLabel labelraporTesisKoduRaporBilgisiDVO;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("2013c6c8-3572-4a9a-833c-eb7ac048d822"));
            RaporEtkinMaddeDVOTabpage = (ITTTabPage)AddControl(new Guid("9cf9b6ad-26e6-4825-83ea-6dd386780996"));
            raporEtkinMaddelerRaporEtkinMaddeDVO = (ITTGrid)AddControl(new Guid("cea43da4-08a5-4f5e-9a4e-d60e30c20ec0"));
            etkinMaddeKoduRaporEtkinMaddeDVO = (ITTListBoxColumn)AddControl(new Guid("21fe0fbc-f9b5-439a-bd5b-99574ca497ce"));
            kullanimDoz1RaporEtkinMaddeDVO = (ITTTextBoxColumn)AddControl(new Guid("6e868c53-e44a-4880-b94e-c3df6cda7dc5"));
            kullanimDoz2RaporEtkinMaddeDVO = (ITTTextBoxColumn)AddControl(new Guid("77ce61db-19bc-43aa-8fb7-41ae6fc2f639"));
            kullanimDozBirimRaporEtkinMaddeDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("8755c360-2558-49eb-86be-89b549008ea3"));
            kullanimPeriyotRaporEtkinMaddeDVO = (ITTTextBoxColumn)AddControl(new Guid("9e7d7cf2-fd2e-42d0-ae43-228422f12d1b"));
            kullanimPeriyotBirimRaporEtkinMaddeDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("62da9aae-2c81-460e-9194-d4500e3c5590"));
            DoktorBilgisiDVOTabpage = (ITTTabPage)AddControl(new Guid("aea8d975-767d-45dc-a7b6-20a08ad50a04"));
            doktorlarDoktorBilgisiDVO = (ITTGrid)AddControl(new Guid("a4d17b45-ff34-49a1-8d34-8cea9f7f4de4"));
            drTescilNoDoktorBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("f0531c30-7a4e-4f5d-a74e-03dfd6897007"));
            drAdiDoktorBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("7c4cfe7b-5d24-4333-97c7-f4193e9821d6"));
            drSoyadiDoktorBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("42adfb7a-d2ca-4318-8f2d-a96945b769eb"));
            drBransKoduDoktorBilgisiDVO = (ITTListBoxColumn)AddControl(new Guid("c11d41b1-5a8a-411a-92bb-51a05a7da067"));
            tipiDoktorBilgisiDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("468fa97e-bc60-4377-a0b4-0dbfbdc4db4e"));
            IlacTeshisBilgiDVOTabpage = (ITTTabPage)AddControl(new Guid("c527c5eb-b78d-4c27-9ee9-15f019e3ed38"));
            ilacTeshislerIlacTeshisBilgisiDVO = (ITTGrid)AddControl(new Guid("4af223f6-770c-4ffd-8b7e-95ce893768ed"));
            baslangicTarihiIlacTeshisBilgisiDVO = (ITTDateTimePickerColumn)AddControl(new Guid("45bc5b80-2962-4433-a41d-ddb72a551ea0"));
            bitisTarihiIlacTeshisBilgisiDVO = (ITTDateTimePickerColumn)AddControl(new Guid("8b6b0028-e547-4f7e-9764-6442b0b43299"));
            teshisKoduIlacTeshisBilgisiDVO = (ITTListBoxColumn)AddControl(new Guid("d939edcb-1ff5-44d8-8732-4f480430a069"));
            ICD10KoduIlacTeshisBilgisiDVO = (ITTListBoxColumn)AddControl(new Guid("55ca19e4-8269-4109-9e4d-26b54af1ca26"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("3962e26d-b386-4a9c-9249-ebe76b72a71d"));
            labeltakipFormuNoIlacRaporDVO = (ITTLabel)AddControl(new Guid("3ef570d7-025d-4881-bee9-7b0711c72e6d"));
            takipFormuNoIlacRaporDVO = (ITTTextBox)AddControl(new Guid("e8730418-4616-4099-befb-1c62aef581da"));
            labelnoRaporBilgisiDVO = (ITTLabel)AddControl(new Guid("3a2f26e0-ca28-4cf5-8649-e735962ca411"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("5ce67cc2-9fea-4d1c-96ca-dfcbc5330814"));
            aciklamaTabpage = (ITTTabPage)AddControl(new Guid("4a980bd0-86fa-4675-9950-eab8937cae54"));
            aciklamaRaporDVO = (ITTTextBox)AddControl(new Guid("bbeefa8e-b18b-4f57-9e2a-85c0a82f5764"));
            klinikTaniTabpage = (ITTTabPage)AddControl(new Guid("8642ab5b-83bb-4a4c-9d7d-abfb24543474"));
            klinikTanıRaporDVO = (ITTTextBox)AddControl(new Guid("76d41924-525a-4ea9-aeeb-86adf0ebc139"));
            hakSahibiBilgisiTabpage = (ITTTabPage)AddControl(new Guid("19b31d9b-21ed-44a6-9d98-b8940b4a1e7a"));
            labeltckimlikNoHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("ebda5641-24da-4ccc-b939-d6443f9135b6"));
            labelsoyadiHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("93fb5182-81ba-4b06-b066-85300bea38f5"));
            karneNoHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("4b8c979b-73d3-47eb-a5df-d461a00d56e6"));
            sosyalGuvenlikNoHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("b67f89a9-aecb-4cc0-80e0-aef77434e871"));
            labelprovizyonTipiHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("4c1a23c2-41c6-44ff-830b-05c5cb667082"));
            soyadiHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("d76ea5f0-7f1b-4824-a48d-bb06d5aa9bdc"));
            labelyakinlikKoduHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("2b04fbc9-be47-41d7-8832-be99dcf13262"));
            labelsosyalGuvenlikNoHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("a568d479-7fe7-4b04-ab54-51ede991e049"));
            provizyonTipiHakSahibiBilgisiDVO = (ITTListDefComboBox)AddControl(new Guid("4f91bf7b-9c9b-4cbc-b7b4-c2ae09cce4ba"));
            labelprovizyonTarihiDateTimeHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("47d3007c-b965-470c-bef4-14da82b06f2e"));
            labelkarneNoHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("e5a5dd38-c388-4a85-838f-538b29cada00"));
            yakinlikKoduHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("cff7d6cd-a1c6-449d-b1f1-86eee23819f9"));
            labelsigortaliTuruHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("86731822-dda9-4e53-b75f-45f755c25a95"));
            provizyonTarihiDateTimeHakSahibiBilgisiDVO = (ITTDateTimePicker)AddControl(new Guid("6a574adb-e4aa-483d-9705-ade3c916405a"));
            tckimlikNoHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("a0ced999-9961-4f51-a407-1b4c35ad4221"));
            devredilenKurumHakSahibiBilgisiDVO = (ITTListDefComboBox)AddControl(new Guid("a92676f1-39f2-4510-b432-b1d510755996"));
            sigortaliTuruHakSahibiBilgisiDVO = (ITTListDefComboBox)AddControl(new Guid("8a7ae701-d1e3-4154-8bcb-20a4e55be83d"));
            labeladiHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("3da71005-3d57-47a6-85fc-f95057666990"));
            adiHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("8686440f-452b-4fbe-aafe-1e693caba07f"));
            labeldevredilenKurumHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("da7ece9d-3843-48fd-988b-b5610032d9f1"));
            duzenlemeTuruRaporDVO = (ITTListDefComboBox)AddControl(new Guid("9dfaa2e8-afb5-4f54-875f-f56738c8d754"));
            labelduzenlemeTuruRaporDVO = (ITTLabel)AddControl(new Guid("4cddb9e3-60eb-4081-a84b-598f73cee11b"));
            noRaporBilgisiDVO = (ITTTextBox)AddControl(new Guid("5a0b8afa-f16f-4580-8fd3-a099f8130512"));
            labelprotokolNoRaporDVO = (ITTLabel)AddControl(new Guid("123a2aff-2869-41cf-ac57-9af725aa5061"));
            protokolNoRaporDVO = (ITTTextBox)AddControl(new Guid("706dbcbb-0bf7-426a-8336-700e293e2c9b"));
            baslangicTarihiDateTimeRaporDVO = (ITTDateTimePicker)AddControl(new Guid("765f7ceb-a7a2-4e0e-b4c9-4c0709681639"));
            labelbaslangicTarihiDateTimeRaporDVO = (ITTLabel)AddControl(new Guid("66022c96-e45a-4d1e-8d12-fb32898aa56b"));
            bitisTarihiDateTimeRaporDVO = (ITTDateTimePicker)AddControl(new Guid("b59c4423-c3ad-4d19-9e02-75541930573b"));
            labeltarihDateTimeRaporBilgisiDVO = (ITTLabel)AddControl(new Guid("1a7db705-8d4d-479d-9e8c-192be0cbabd8"));
            labelbitisTarihiDateTimeRaporDVO = (ITTLabel)AddControl(new Guid("76a76082-837b-4bb5-942a-5d09f6b87039"));
            turuRaporDVO = (ITTListDefComboBox)AddControl(new Guid("5f35b075-aea3-4de3-9547-dbb9bbde5b54"));
            protokolTarihiDateTimeRaporDVO = (ITTDateTimePicker)AddControl(new Guid("c0391067-bda2-4cce-9647-68dfdaedf5ab"));
            labelturuRaporDVO = (ITTLabel)AddControl(new Guid("7e56a23d-d1d1-4052-9b43-6fbc8ad633ba"));
            labelprotokolTarihiDateTimeRaporDVO = (ITTLabel)AddControl(new Guid("18df2f06-f3a7-40eb-b5a5-ffc8679ae59d"));
            tarihDateTimeRaporBilgisiDVO = (ITTDateTimePicker)AddControl(new Guid("2c912a0d-0ac3-4e87-b1f0-d4f943ecce72"));
            raporTesisKoduRaporBilgisiDVO = (ITTValueListBox)AddControl(new Guid("958fe69e-9c5c-4900-90cd-b0c24484ca1d"));
            labelraporTesisKoduRaporBilgisiDVO = (ITTLabel)AddControl(new Guid("8b273b43-5f39-4c1d-ba4b-a232ca52ceaf"));
            base.InitializeControls();
        }

        public IlacRaporDVOForm() : base("ILACRAPORDVO", "IlacRaporDVOForm")
        {
        }

        protected IlacRaporDVOForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}