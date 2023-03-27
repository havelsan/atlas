
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
    public partial class BaseDogumRaporuKaydetForm : BaseRaporBilgisiKaydetForm
    {
        protected TTObjectClasses.BaseDogumRaporuKaydet _BaseDogumRaporuKaydet
        {
            get { return (TTObjectClasses.BaseDogumRaporuKaydet)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelnoRaporBilgisiDVO;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage aciklamaTabpage;
        protected ITTTextBox aciklamaRaporDVO;
        protected ITTTabPage klinikTaniTabpage;
        protected ITTTextBox klinikTanıRaporDVO;
        protected ITTTabPage dogumBilgileriTabpage;
        protected ITTLabel labelbebekDogumTarihiDateTimeDogumRaporDVO;
        protected ITTLabel labeldogumTipiDogumRaporDVO;
        protected ITTDateTimePicker bebekDogumTarihiDateTimeDogumRaporDVO;
        protected ITTLabel labelcocukSayisiDogumRaporDVO;
        protected ITTListDefComboBox dogumTipiDogumRaporDVO;
        protected ITTLabel labelcanliCocukSayisiDogumRaporDVO;
        protected ITTLabel labelepizyotemiDogumRaporDVO;
        protected ITTTextBox cocukSayisiDogumRaporDVO;
        protected ITTListDefComboBox epizyotemiDogumRaporDVO;
        protected ITTTextBox canliCocukSayisiDogumRaporDVO;
        protected ITTLabel labelanesteziTipiDogumRaporDVO;
        protected ITTListDefComboBox anesteziTipiDogumRaporDVO;
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
        protected ITTTabPage doktorlarTabpage;
        protected ITTGrid doktorlarDoktorBilgisiDVO;
        protected ITTTextBoxColumn drTescilNoDoktorBilgisiDVO;
        protected ITTTextBoxColumn drAdiDoktorBilgisiDVO;
        protected ITTTextBoxColumn drSoyadiDoktorBilgisiDVO;
        protected ITTListBoxColumn drBransKoduDoktorBilgisiDVO;
        protected ITTListDefComboBoxColumn tipiDoktorBilgisiDVO;
        protected ITTTabPage tanilarTabpage;
        protected ITTGrid tanilarTaniBilgisi_RaporDVO;
        protected ITTListBoxColumn taniKoduTaniBilgisi_RaporDVO;
        protected ITTTabPage teshislerTabpage;
        protected ITTGrid teshislerTeshisBilgisiDVO;
        protected ITTDateTimePickerColumn baslangicTarihiTeshisBilgisiDVO;
        protected ITTDateTimePickerColumn bitisTarihiTeshisBilgisiDVO;
        protected ITTListBoxColumn teshisKoduTeshisBilgisiDVO;
        protected ITTTabPage cocuklarTabpage;
        protected ITTGrid cocuklarCocukBilgisiDVO;
        protected ITTListDefComboBoxColumn cinsiyetCocukBilgisiDVO;
        protected ITTTextBoxColumn dogumSaatiCocukBilgisiDVO;
        protected ITTTextBoxColumn kiloCocukBilgisiDVO;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("ecbcd840-2432-480e-90d5-5caef1ab279c"));
            labelnoRaporBilgisiDVO = (ITTLabel)AddControl(new Guid("25908d94-686e-4541-a67b-7e6f5613d326"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("3e0e5926-f624-4aea-abf8-f93e7e46a0e3"));
            aciklamaTabpage = (ITTTabPage)AddControl(new Guid("e252727d-8518-4eda-814f-a939e0a6c210"));
            aciklamaRaporDVO = (ITTTextBox)AddControl(new Guid("a3bdd946-c509-4ac2-ab4d-f4db8dbcfa96"));
            klinikTaniTabpage = (ITTTabPage)AddControl(new Guid("4155749a-e585-4fb3-9dbc-571b3826271d"));
            klinikTanıRaporDVO = (ITTTextBox)AddControl(new Guid("f71ee456-610d-4385-a309-5dee182ae293"));
            dogumBilgileriTabpage = (ITTTabPage)AddControl(new Guid("388eae2b-8078-42f6-9ca3-680a5de74feb"));
            labelbebekDogumTarihiDateTimeDogumRaporDVO = (ITTLabel)AddControl(new Guid("21b45a40-11c5-4bd2-85bf-5e724dba1e3b"));
            labeldogumTipiDogumRaporDVO = (ITTLabel)AddControl(new Guid("0d1941d2-2a7e-45ad-874a-aa34fd74078d"));
            bebekDogumTarihiDateTimeDogumRaporDVO = (ITTDateTimePicker)AddControl(new Guid("5b10a08b-f8e7-4945-9410-904343379fff"));
            labelcocukSayisiDogumRaporDVO = (ITTLabel)AddControl(new Guid("9ef8f191-72ff-483f-b8fc-6b49fad62a4b"));
            dogumTipiDogumRaporDVO = (ITTListDefComboBox)AddControl(new Guid("ba05ad7b-5e36-4960-8de8-3a1a139892a1"));
            labelcanliCocukSayisiDogumRaporDVO = (ITTLabel)AddControl(new Guid("40fea466-86d6-432c-8ac2-37f266d699b0"));
            labelepizyotemiDogumRaporDVO = (ITTLabel)AddControl(new Guid("9affa6f8-ff3c-4875-9fb4-a1ff205c6097"));
            cocukSayisiDogumRaporDVO = (ITTTextBox)AddControl(new Guid("c9689dbc-5b8d-48e3-9345-63ca0f17e1f6"));
            epizyotemiDogumRaporDVO = (ITTListDefComboBox)AddControl(new Guid("d1bf5a5e-4460-4cbf-a3ba-b34ea4a7787c"));
            canliCocukSayisiDogumRaporDVO = (ITTTextBox)AddControl(new Guid("a8fab65c-7d96-4967-be63-ab355d79e8b8"));
            labelanesteziTipiDogumRaporDVO = (ITTLabel)AddControl(new Guid("de14d617-df02-4393-bbf7-0917811a3360"));
            anesteziTipiDogumRaporDVO = (ITTListDefComboBox)AddControl(new Guid("06ca624b-1988-4cb3-8d9c-455fb269e47a"));
            duzenlemeTuruRaporDVO = (ITTListDefComboBox)AddControl(new Guid("54e3f15d-aa3f-40ff-8843-a76c519f9a4d"));
            labelduzenlemeTuruRaporDVO = (ITTLabel)AddControl(new Guid("5474c92a-2209-4959-9628-71ce1f518f7d"));
            noRaporBilgisiDVO = (ITTTextBox)AddControl(new Guid("46b7efcd-8b72-4520-a7a2-524287131fe1"));
            labelprotokolNoRaporDVO = (ITTLabel)AddControl(new Guid("652ee0ca-243c-4b2d-ac21-f7749fd93829"));
            protokolNoRaporDVO = (ITTTextBox)AddControl(new Guid("3b8aee77-6db3-4c6b-a68a-5c79dd4c4344"));
            baslangicTarihiDateTimeRaporDVO = (ITTDateTimePicker)AddControl(new Guid("a6eda876-5858-48b3-851c-ddc365439323"));
            labelbaslangicTarihiDateTimeRaporDVO = (ITTLabel)AddControl(new Guid("bf564c92-6e39-4268-a856-43faf01fbf14"));
            bitisTarihiDateTimeRaporDVO = (ITTDateTimePicker)AddControl(new Guid("51214616-d69b-4c42-ab17-0f7145154157"));
            labeltarihDateTimeRaporBilgisiDVO = (ITTLabel)AddControl(new Guid("cabdc1d9-8566-4d29-8ea7-abbdc1e1e546"));
            labelbitisTarihiDateTimeRaporDVO = (ITTLabel)AddControl(new Guid("9323623d-eb64-4bff-863c-99a17ef11e13"));
            turuRaporDVO = (ITTListDefComboBox)AddControl(new Guid("1a8504a2-d479-4aa9-bb68-18a5e5cec943"));
            protokolTarihiDateTimeRaporDVO = (ITTDateTimePicker)AddControl(new Guid("a6c64b94-a39f-4657-a8f5-a825c2791489"));
            labelturuRaporDVO = (ITTLabel)AddControl(new Guid("53ed10e1-d8d3-44c8-9a8b-f60bd3085818"));
            labelprotokolTarihiDateTimeRaporDVO = (ITTLabel)AddControl(new Guid("1d31fb03-2e63-43f7-b07e-80433ae51fec"));
            tarihDateTimeRaporBilgisiDVO = (ITTDateTimePicker)AddControl(new Guid("28faf822-3004-4180-9194-3a7cbb20eb91"));
            raporTesisKoduRaporBilgisiDVO = (ITTValueListBox)AddControl(new Guid("a7ac19c0-d20d-401a-ad0f-71a3422cd833"));
            labelraporTesisKoduRaporBilgisiDVO = (ITTLabel)AddControl(new Guid("e6a4a129-eb93-4333-94f7-fd3fab5546b2"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("10a44d45-3a68-4a24-9421-fd31b02d7570"));
            doktorlarTabpage = (ITTTabPage)AddControl(new Guid("6a38b4f8-0750-45ef-a3df-41940c018330"));
            doktorlarDoktorBilgisiDVO = (ITTGrid)AddControl(new Guid("ffb482e3-f989-45c8-95e5-f512ef441ea1"));
            drTescilNoDoktorBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("9c9f27d0-f350-4e53-8846-1dae5adcd356"));
            drAdiDoktorBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("6ac20e34-32e7-48f6-93a8-8ce0f54c96d0"));
            drSoyadiDoktorBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("4eb54d8b-3247-4e84-adaf-fdd350475f54"));
            drBransKoduDoktorBilgisiDVO = (ITTListBoxColumn)AddControl(new Guid("cf02baf2-aeb2-4b10-9503-c04404af97d1"));
            tipiDoktorBilgisiDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("196f4cd7-a524-4cf9-93a1-7bb3149a0ee4"));
            tanilarTabpage = (ITTTabPage)AddControl(new Guid("c6749e35-0e31-4d20-8826-3dc5b7d3fbd7"));
            tanilarTaniBilgisi_RaporDVO = (ITTGrid)AddControl(new Guid("297e9aca-2e04-416a-8247-3db018eb9bae"));
            taniKoduTaniBilgisi_RaporDVO = (ITTListBoxColumn)AddControl(new Guid("d4e4e8d4-a0b9-4fb6-9b01-79587971b149"));
            teshislerTabpage = (ITTTabPage)AddControl(new Guid("bdaa9cd3-b7d9-47e5-9cc3-85e82229ed58"));
            teshislerTeshisBilgisiDVO = (ITTGrid)AddControl(new Guid("0e686255-2c06-4d0a-ba03-0fdfffcebd65"));
            baslangicTarihiTeshisBilgisiDVO = (ITTDateTimePickerColumn)AddControl(new Guid("bc7ef5af-9b67-48af-887a-ab3e92752d3f"));
            bitisTarihiTeshisBilgisiDVO = (ITTDateTimePickerColumn)AddControl(new Guid("b778dde8-e6c6-4531-9627-4ca77bae7ed2"));
            teshisKoduTeshisBilgisiDVO = (ITTListBoxColumn)AddControl(new Guid("6917d7f4-c3d6-471f-905c-c896192dfd26"));
            cocuklarTabpage = (ITTTabPage)AddControl(new Guid("50a25df9-f380-4a09-9882-9c320606726e"));
            cocuklarCocukBilgisiDVO = (ITTGrid)AddControl(new Guid("cb40a50e-4bdf-4c33-8615-ce7c24c1e809"));
            cinsiyetCocukBilgisiDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("8f7e9c3d-613a-455f-ae03-d8aae742ecc2"));
            dogumSaatiCocukBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("48e0d90a-d286-49cf-b617-2c4bd29cc329"));
            kiloCocukBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("0abac7c5-1335-44e9-8944-77269d1d5ac8"));
            base.InitializeControls();
        }

        public BaseDogumRaporuKaydetForm() : base("BASEDOGUMRAPORUKAYDET", "BaseDogumRaporuKaydetForm")
        {
        }

        protected BaseDogumRaporuKaydetForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}