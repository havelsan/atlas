
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
    public partial class BaseIlacRaporuKaydetForm : BaseRaporBilgisiKaydetForm
    {
        protected TTObjectClasses.BaseIlacRaporuKaydet _BaseIlacRaporuKaydet
        {
            get { return (TTObjectClasses.BaseIlacRaporuKaydet)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labeltakipFormuNoIlacRaporDVO;
        protected ITTTextBox takipFormuNoIlacRaporDVO;
        protected ITTLabel labelnoRaporBilgisiDVO;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage aciklamaTabpage;
        protected ITTTextBox aciklamaRaporDVO;
        protected ITTTabPage klinikTaniTabpage;
        protected ITTTextBox klinikTanıRaporDVO;
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
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("8ac16af7-f4a3-43f8-95cf-9ff7f9d9bfa0"));
            labeltakipFormuNoIlacRaporDVO = (ITTLabel)AddControl(new Guid("2b5ffead-46d3-4f1b-8366-55357215c0cd"));
            takipFormuNoIlacRaporDVO = (ITTTextBox)AddControl(new Guid("20a664ad-5bd3-417a-b0f6-9cf6e70e755c"));
            labelnoRaporBilgisiDVO = (ITTLabel)AddControl(new Guid("336868ba-6138-459d-b588-94f34f23de49"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("78c56bdb-94e1-4c65-8334-11cb86291cab"));
            aciklamaTabpage = (ITTTabPage)AddControl(new Guid("61a3506f-d5cf-4f01-94fd-3da58ff99cb0"));
            aciklamaRaporDVO = (ITTTextBox)AddControl(new Guid("d638f925-d45c-4b87-81c7-8471cc4a36c7"));
            klinikTaniTabpage = (ITTTabPage)AddControl(new Guid("8b733602-1374-4f51-b76d-bee9a3a08bb2"));
            klinikTanıRaporDVO = (ITTTextBox)AddControl(new Guid("57a3471d-f4b4-4c16-bcb0-efe7ccd9a62f"));
            duzenlemeTuruRaporDVO = (ITTListDefComboBox)AddControl(new Guid("9cc679ac-8ba1-4ae3-bdc5-44e876e2e2c1"));
            labelduzenlemeTuruRaporDVO = (ITTLabel)AddControl(new Guid("4c642449-f9e2-42bb-aed3-b2f193f54803"));
            noRaporBilgisiDVO = (ITTTextBox)AddControl(new Guid("ea441fe5-4deb-44d4-87a9-84fd7d178a1d"));
            labelprotokolNoRaporDVO = (ITTLabel)AddControl(new Guid("d8ee2940-d534-4d61-90c8-f8c99e1ee9eb"));
            protokolNoRaporDVO = (ITTTextBox)AddControl(new Guid("4f29160f-a661-46db-abe3-eeafb5cb336a"));
            baslangicTarihiDateTimeRaporDVO = (ITTDateTimePicker)AddControl(new Guid("36417f83-9d99-45ca-94e0-070418270eea"));
            labelbaslangicTarihiDateTimeRaporDVO = (ITTLabel)AddControl(new Guid("6792dce1-e14f-4f71-ad20-bc728504686d"));
            bitisTarihiDateTimeRaporDVO = (ITTDateTimePicker)AddControl(new Guid("e0d29c16-9b8a-477c-86ab-1050817b44cf"));
            labeltarihDateTimeRaporBilgisiDVO = (ITTLabel)AddControl(new Guid("f5c1ec6f-63a7-42f4-88e4-cb219227ae1e"));
            labelbitisTarihiDateTimeRaporDVO = (ITTLabel)AddControl(new Guid("418e0c12-91ec-4505-8d99-6f336cd67f92"));
            turuRaporDVO = (ITTListDefComboBox)AddControl(new Guid("468bf32b-b8ca-4aed-89e1-fff6902e0573"));
            protokolTarihiDateTimeRaporDVO = (ITTDateTimePicker)AddControl(new Guid("0eae0c84-6ed7-46a9-b38e-28208b9ca813"));
            labelturuRaporDVO = (ITTLabel)AddControl(new Guid("56418825-b407-48b0-98ae-fb3e24ebcac9"));
            labelprotokolTarihiDateTimeRaporDVO = (ITTLabel)AddControl(new Guid("8df5d638-43b1-4865-910f-d04cee9cb97f"));
            tarihDateTimeRaporBilgisiDVO = (ITTDateTimePicker)AddControl(new Guid("37043e70-cd8c-4dd7-b1d0-0152fb2f9556"));
            raporTesisKoduRaporBilgisiDVO = (ITTValueListBox)AddControl(new Guid("e642e430-ba5c-4a73-9cc8-21125959d599"));
            labelraporTesisKoduRaporBilgisiDVO = (ITTLabel)AddControl(new Guid("1ae2931f-d5b6-4bcb-bd62-2a4b9e5568fc"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("44165431-ad38-4ad1-9973-45791a1a75ea"));
            RaporEtkinMaddeDVOTabpage = (ITTTabPage)AddControl(new Guid("98c91b46-9a2d-4517-8519-de22c4e1f675"));
            raporEtkinMaddelerRaporEtkinMaddeDVO = (ITTGrid)AddControl(new Guid("d6860a49-adff-461d-b99f-e62703341e8e"));
            etkinMaddeKoduRaporEtkinMaddeDVO = (ITTListBoxColumn)AddControl(new Guid("94dd6eb8-05f2-4f85-ac74-bb0a23aaec26"));
            kullanimDoz1RaporEtkinMaddeDVO = (ITTTextBoxColumn)AddControl(new Guid("64cbfe4a-2fcf-424f-9bbf-b955ab6fdcb4"));
            kullanimDoz2RaporEtkinMaddeDVO = (ITTTextBoxColumn)AddControl(new Guid("362ae25e-7061-4cc1-92e0-a3c38dd7b08f"));
            kullanimDozBirimRaporEtkinMaddeDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("b284646e-3b94-44ed-b625-c562081ac30a"));
            kullanimPeriyotRaporEtkinMaddeDVO = (ITTTextBoxColumn)AddControl(new Guid("6a5ea230-d932-4a10-9152-db08167c737c"));
            kullanimPeriyotBirimRaporEtkinMaddeDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("ce2eed1f-2183-45fe-bacf-107f534a38db"));
            DoktorBilgisiDVOTabpage = (ITTTabPage)AddControl(new Guid("40ec46a1-661b-481f-9cba-d1847ad61e7a"));
            doktorlarDoktorBilgisiDVO = (ITTGrid)AddControl(new Guid("fb107890-3bb1-4b81-9a6c-6813b0648db2"));
            drTescilNoDoktorBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("36cbf003-9300-4517-863e-d4633a50a2e7"));
            drAdiDoktorBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("c637a579-e7a5-4bba-933e-ce9c439fd66d"));
            drSoyadiDoktorBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("51e66b3e-db87-4629-b771-fd1136976a44"));
            drBransKoduDoktorBilgisiDVO = (ITTListBoxColumn)AddControl(new Guid("74fd7aad-667c-4ee7-9657-e878f5a74eae"));
            tipiDoktorBilgisiDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("959b976c-d028-4492-b2ed-cd109a184470"));
            IlacTeshisBilgiDVOTabpage = (ITTTabPage)AddControl(new Guid("2f1a3931-1d92-43a4-b86a-0bec8705d117"));
            ilacTeshislerIlacTeshisBilgisiDVO = (ITTGrid)AddControl(new Guid("ae0b4b4e-61d4-4f30-8b28-d4ede6209400"));
            baslangicTarihiIlacTeshisBilgisiDVO = (ITTDateTimePickerColumn)AddControl(new Guid("8813d4a2-7c5d-443f-a8dd-b86f3e58c36d"));
            bitisTarihiIlacTeshisBilgisiDVO = (ITTDateTimePickerColumn)AddControl(new Guid("72beef28-03c1-439e-9360-f47add66a7b2"));
            teshisKoduIlacTeshisBilgisiDVO = (ITTListBoxColumn)AddControl(new Guid("643314a0-1f1b-43cd-b008-09948df43840"));
            ICD10KoduIlacTeshisBilgisiDVO = (ITTListBoxColumn)AddControl(new Guid("866e8e45-b6b3-4561-92d6-962d2b361e3c"));
            base.InitializeControls();
        }

        public BaseIlacRaporuKaydetForm() : base("BASEILACRAPORUKAYDET", "BaseIlacRaporuKaydetForm")
        {
        }

        protected BaseIlacRaporuKaydetForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}