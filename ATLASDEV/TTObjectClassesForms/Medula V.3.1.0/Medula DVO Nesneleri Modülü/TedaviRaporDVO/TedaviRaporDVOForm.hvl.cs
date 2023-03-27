
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
    public partial class TedaviRaporDVOForm : BaseMedulaObjectForm
    {
        protected TTObjectClasses.TedaviRaporDVO _TedaviRaporDVO
        {
            get { return (TTObjectClasses.TedaviRaporDVO)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTButton tedaviRaporuYaz;
        protected ITTLabel labeltedaviRaporTuruTedaviRaporDVO;
        protected ITTLabel labelnoRaporBilgisiDVO;
        protected ITTListDefComboBox tedaviRaporTuruTedaviRaporDVO;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage aciklamaTabpage;
        protected ITTTextBox aciklamaRaporDVO;
        protected ITTTabPage klinikTaniTabpage;
        protected ITTTextBox klinikTanıRaporDVO;
        protected ITTTabPage hakSahibiBilgisiTabpage;
        protected ITTTextBox tckimlikNoHakSahibiBilgisiDVO;
        protected ITTLabel labelprovizyonTipiHakSahibiBilgisiDVO;
        protected ITTLabel labelyakinlikKoduHakSahibiBilgisiDVO;
        protected ITTLabel labelsoyadiHakSahibiBilgisiDVO;
        protected ITTTextBox soyadiHakSahibiBilgisiDVO;
        protected ITTLabel labelsosyalGuvenlikNoHakSahibiBilgisiDVO;
        protected ITTLabel labeldevredilenKurumHakSahibiBilgisiDVO;
        protected ITTListDefComboBox provizyonTipiHakSahibiBilgisiDVO;
        protected ITTLabel labeladiHakSahibiBilgisiDVO;
        protected ITTTextBox adiHakSahibiBilgisiDVO;
        protected ITTListDefComboBox sigortaliTuruHakSahibiBilgisiDVO;
        protected ITTLabel labelprovizyonTarihiDateTimeHakSahibiBilgisiDVO;
        protected ITTTextBox karneNoHakSahibiBilgisiDVO;
        protected ITTLabel labelkarneNoHakSahibiBilgisiDVO;
        protected ITTListDefComboBox devredilenKurumHakSahibiBilgisiDVO;
        protected ITTTextBox yakinlikKoduHakSahibiBilgisiDVO;
        protected ITTTextBox sosyalGuvenlikNoHakSahibiBilgisiDVO;
        protected ITTLabel labelsigortaliTuruHakSahibiBilgisiDVO;
        protected ITTDateTimePicker provizyonTarihiDateTimeHakSahibiBilgisiDVO;
        protected ITTLabel labeltckimlikNoHakSahibiBilgisiDVO;
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
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("efd455d9-5d75-4601-a757-d864f8edbdd2"));
            tedaviRaporuYaz = (ITTButton)AddControl(new Guid("355a776a-583b-4f60-a91a-8b128278c33d"));
            labeltedaviRaporTuruTedaviRaporDVO = (ITTLabel)AddControl(new Guid("b598df59-a32e-4098-b115-e6387961701a"));
            labelnoRaporBilgisiDVO = (ITTLabel)AddControl(new Guid("d88af3e7-dec5-4be5-b00f-961224c603af"));
            tedaviRaporTuruTedaviRaporDVO = (ITTListDefComboBox)AddControl(new Guid("2bdb4228-fe6e-480f-80c5-a4c4540889c9"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("600c7ee8-93e5-4d61-98bd-275db8330cd6"));
            aciklamaTabpage = (ITTTabPage)AddControl(new Guid("aa7f8b2d-220b-47d3-a324-cb3d392ea353"));
            aciklamaRaporDVO = (ITTTextBox)AddControl(new Guid("a2363108-561c-47c3-ad9f-2c68f5ba2eea"));
            klinikTaniTabpage = (ITTTabPage)AddControl(new Guid("c7a0c966-32db-407e-9ad2-d0eb71d16856"));
            klinikTanıRaporDVO = (ITTTextBox)AddControl(new Guid("203cd8a8-a6a6-49ee-99fd-4c0d6c19adf8"));
            hakSahibiBilgisiTabpage = (ITTTabPage)AddControl(new Guid("e42646b0-b86c-481e-8548-281dbcd18939"));
            tckimlikNoHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("42a4a9f7-a8bb-4c35-a61a-f1157d97bbcb"));
            labelprovizyonTipiHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("7c89ea44-d408-4207-9495-d4b9161eb246"));
            labelyakinlikKoduHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("3db0bdea-c2d7-442b-92d5-e604bb22317e"));
            labelsoyadiHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("2ca0f36d-f41f-4a56-b05a-8ad960caaec3"));
            soyadiHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("bb422aee-46c3-4dfa-8cdd-0f9139a102f1"));
            labelsosyalGuvenlikNoHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("b458f179-bd48-4953-a2f8-ad7bd31ba6f7"));
            labeldevredilenKurumHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("e19a9612-58e0-4de8-8e1a-8fd86fea15e9"));
            provizyonTipiHakSahibiBilgisiDVO = (ITTListDefComboBox)AddControl(new Guid("f6dc7671-9b79-4c9c-b258-51dce74c2fb8"));
            labeladiHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("b29b325b-4f5c-44b7-836b-552f34a6f30d"));
            adiHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("f0abc33b-284c-421a-8351-264666f1a82e"));
            sigortaliTuruHakSahibiBilgisiDVO = (ITTListDefComboBox)AddControl(new Guid("d79f8aeb-3722-49be-8850-f4d280b781bc"));
            labelprovizyonTarihiDateTimeHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("61d37bd4-388a-40a3-8360-befd952d864f"));
            karneNoHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("deb6f178-9743-4dd1-9e55-7e7346fbe62c"));
            labelkarneNoHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("098359a7-7576-4f5a-ad9e-22cf1589ee31"));
            devredilenKurumHakSahibiBilgisiDVO = (ITTListDefComboBox)AddControl(new Guid("89bc1bf3-4e30-4370-8948-b077e13bc138"));
            yakinlikKoduHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("6ae76430-9824-4426-b236-074261788b13"));
            sosyalGuvenlikNoHakSahibiBilgisiDVO = (ITTTextBox)AddControl(new Guid("047ab27e-686a-4751-b24d-d4d289926280"));
            labelsigortaliTuruHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("1cd3462e-e42e-4544-8e6a-a2e4bef8baa1"));
            provizyonTarihiDateTimeHakSahibiBilgisiDVO = (ITTDateTimePicker)AddControl(new Guid("8cc4d5e6-7360-405b-9987-ec03c177b29a"));
            labeltckimlikNoHakSahibiBilgisiDVO = (ITTLabel)AddControl(new Guid("f8807876-8c6a-44bd-802e-6dd13b287fc0"));
            duzenlemeTuruRaporDVO = (ITTListDefComboBox)AddControl(new Guid("35de33bd-d051-46d7-b1fb-129113ce71bc"));
            labelduzenlemeTuruRaporDVO = (ITTLabel)AddControl(new Guid("b2312bcf-12c6-4272-a451-ab2eb52a2b44"));
            noRaporBilgisiDVO = (ITTTextBox)AddControl(new Guid("b937686e-e847-4532-a639-316369f903a0"));
            labelprotokolNoRaporDVO = (ITTLabel)AddControl(new Guid("dfe83c5b-5c40-4bb4-b725-34a328378939"));
            protokolNoRaporDVO = (ITTTextBox)AddControl(new Guid("5c8df961-19ba-4b79-a375-3b420a39ce09"));
            baslangicTarihiDateTimeRaporDVO = (ITTDateTimePicker)AddControl(new Guid("c2588102-0c41-498b-adef-460285d55abf"));
            labelbaslangicTarihiDateTimeRaporDVO = (ITTLabel)AddControl(new Guid("85d86feb-1336-4975-9315-13e1f7cdc7e9"));
            bitisTarihiDateTimeRaporDVO = (ITTDateTimePicker)AddControl(new Guid("5bbd802c-5714-4292-9fad-35225976cd9e"));
            labeltarihDateTimeRaporBilgisiDVO = (ITTLabel)AddControl(new Guid("d5d7f9d0-476c-4c31-9c54-704f388acd12"));
            labelbitisTarihiDateTimeRaporDVO = (ITTLabel)AddControl(new Guid("f768071b-d88d-4399-a1c7-e8129bad545c"));
            turuRaporDVO = (ITTListDefComboBox)AddControl(new Guid("be2452a3-18de-4131-bffd-5e21e0cea291"));
            protokolTarihiDateTimeRaporDVO = (ITTDateTimePicker)AddControl(new Guid("f4792e55-cae2-422b-9af8-4b2cafd754de"));
            labelturuRaporDVO = (ITTLabel)AddControl(new Guid("9bd38a31-0f52-44f1-b04c-79ef64f506d5"));
            labelprotokolTarihiDateTimeRaporDVO = (ITTLabel)AddControl(new Guid("adb24405-5db7-4064-9651-7faabae7e268"));
            tarihDateTimeRaporBilgisiDVO = (ITTDateTimePicker)AddControl(new Guid("e99fa0eb-0f09-4f4d-82f1-5d92edf72a1d"));
            raporTesisKoduRaporBilgisiDVO = (ITTValueListBox)AddControl(new Guid("17ac9616-14e7-48e1-b568-60ba25cc09e5"));
            labelraporTesisKoduRaporBilgisiDVO = (ITTLabel)AddControl(new Guid("b43a086c-adf9-4662-b98e-f798c9147ee3"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("f18ec870-d3b2-4971-8516-5cede02f0e2e"));
            doktorlarTabpage = (ITTTabPage)AddControl(new Guid("c428a97a-d034-4d41-924e-841001fa0ed0"));
            doktorlarDoktorBilgisiDVO = (ITTGrid)AddControl(new Guid("db52d489-a609-45c5-996b-16484a39329c"));
            drTescilNoDoktorBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("724678d3-c602-4d5d-a544-bad5a90898d8"));
            drAdiDoktorBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("e2a9aa2e-e0e2-4da9-9304-2481ed3e03dd"));
            drSoyadiDoktorBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("f4947d3f-6242-49f8-ae11-0eb6b8cbc356"));
            drBransKoduDoktorBilgisiDVO = (ITTListBoxColumn)AddControl(new Guid("24a4ff73-b7a5-42c9-a99e-74cc2050189a"));
            tipiDoktorBilgisiDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("d8b626d3-1a94-4090-a783-5811e777e722"));
            tanilarTabpage = (ITTTabPage)AddControl(new Guid("adb0c35b-bace-44f5-b8b9-4c5c2eb847cd"));
            tanilarTaniBilgisi_RaporDVO = (ITTGrid)AddControl(new Guid("3b0b71b4-6756-477d-9206-36f8289d82a3"));
            taniKoduTaniBilgisi_RaporDVO = (ITTListBoxColumn)AddControl(new Guid("0507b3bf-cde6-4212-95ca-dd873dbc09ef"));
            teshislerTabpage = (ITTTabPage)AddControl(new Guid("4573dba5-5b5c-442a-95dd-04dbe5df33d5"));
            teshislerTeshisBilgisiDVO = (ITTGrid)AddControl(new Guid("4276cdb0-d47e-442d-bfac-30d7c894f9fd"));
            baslangicTarihiTeshisBilgisiDVO = (ITTDateTimePickerColumn)AddControl(new Guid("ec7572e3-dce7-431e-bd6c-2d15150a9450"));
            bitisTarihiTeshisBilgisiDVO = (ITTDateTimePickerColumn)AddControl(new Guid("a6e0d25c-6c04-4d65-abb9-b3941b7edaae"));
            teshisKoduTeshisBilgisiDVO = (ITTListBoxColumn)AddControl(new Guid("3d158f30-96f3-4cc9-9ae8-71263a26f85e"));
            base.InitializeControls();
        }

        public TedaviRaporDVOForm() : base("TEDAVIRAPORDVO", "TedaviRaporDVOForm")
        {
        }

        protected TedaviRaporDVOForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}