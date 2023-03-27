
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
    public partial class BaseAnalikIsgoremezlikRaporuKaydetForm : BaseRaporBilgisiKaydetForm
    {
        protected TTObjectClasses.BaseAnalikIsgoremezlikRaporuKaydet _BaseAnalikIsgoremezlikRaporuKaydet
        {
            get { return (TTObjectClasses.BaseAnalikIsgoremezlikRaporuKaydet)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelcocukSayisiAnalikIsgoremezlikRaporDVO;
        protected ITTLabel labelbebekDogumTarihiDateTimeAnalikIsgoremezlikRaporDVO;
        protected ITTTextBox cocukSayisiAnalikIsgoremezlikRaporDVO;
        protected ITTLabel labelnoRaporBilgisiDVO;
        protected ITTDateTimePicker bebekDogumTarihiDateTimeAnalikIsgoremezlikRaporDVO;
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
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("a6856601-4f86-4927-b822-f41f82906c94"));
            labelcocukSayisiAnalikIsgoremezlikRaporDVO = (ITTLabel)AddControl(new Guid("62b00575-aa77-4862-aeda-6831b64a461b"));
            labelbebekDogumTarihiDateTimeAnalikIsgoremezlikRaporDVO = (ITTLabel)AddControl(new Guid("ee8abaed-7c4e-4f7b-93fb-81da952b866c"));
            cocukSayisiAnalikIsgoremezlikRaporDVO = (ITTTextBox)AddControl(new Guid("9a88bf78-37cc-4047-80bc-3139cdf74aba"));
            labelnoRaporBilgisiDVO = (ITTLabel)AddControl(new Guid("1a480822-b629-4022-9ded-bdc727689f7d"));
            bebekDogumTarihiDateTimeAnalikIsgoremezlikRaporDVO = (ITTDateTimePicker)AddControl(new Guid("f0b3c804-98c7-4e8f-9f4b-f00266cf3ac9"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("6f314ee4-a82a-4a5a-b4ca-ce3c4ddbba1a"));
            aciklamaTabpage = (ITTTabPage)AddControl(new Guid("bd18bd90-ff72-486c-9486-10a3b4631059"));
            aciklamaRaporDVO = (ITTTextBox)AddControl(new Guid("b01d29ce-1baf-4a62-822a-d8ab5a55240c"));
            klinikTaniTabpage = (ITTTabPage)AddControl(new Guid("d174fcce-4479-4537-90dd-1ed47e6aeeca"));
            klinikTanıRaporDVO = (ITTTextBox)AddControl(new Guid("25bf6ae6-67ab-47c0-9868-f86f43df852e"));
            duzenlemeTuruRaporDVO = (ITTListDefComboBox)AddControl(new Guid("cc2e869f-1806-414d-b3f5-b8956d200a23"));
            labelduzenlemeTuruRaporDVO = (ITTLabel)AddControl(new Guid("13c29025-9117-4a52-bcb6-1d3c72aaa75c"));
            noRaporBilgisiDVO = (ITTTextBox)AddControl(new Guid("8ebc285e-98fb-4ccd-9a15-355ab5eea9c8"));
            labelprotokolNoRaporDVO = (ITTLabel)AddControl(new Guid("eb281fb3-d890-497b-948c-8edb2573c34d"));
            protokolNoRaporDVO = (ITTTextBox)AddControl(new Guid("c2f2056c-059a-4967-a8e9-362475ca60d3"));
            baslangicTarihiDateTimeRaporDVO = (ITTDateTimePicker)AddControl(new Guid("0c173856-6551-4d52-8a99-1bf8ec63edc5"));
            labelbaslangicTarihiDateTimeRaporDVO = (ITTLabel)AddControl(new Guid("62f137cd-dc90-492c-a039-0257bc9abd17"));
            bitisTarihiDateTimeRaporDVO = (ITTDateTimePicker)AddControl(new Guid("a5dc989b-ecb3-42e2-b001-a2959b397ceb"));
            labeltarihDateTimeRaporBilgisiDVO = (ITTLabel)AddControl(new Guid("7ce75896-2320-44d0-a310-c7286ff4b8f3"));
            labelbitisTarihiDateTimeRaporDVO = (ITTLabel)AddControl(new Guid("28f18a42-2110-4a9e-814f-6bea68be3766"));
            turuRaporDVO = (ITTListDefComboBox)AddControl(new Guid("cc166b5a-4989-4d61-8339-e28d91ee7e49"));
            protokolTarihiDateTimeRaporDVO = (ITTDateTimePicker)AddControl(new Guid("89087f62-bf40-4ce8-abce-b5e5c7fe5501"));
            labelturuRaporDVO = (ITTLabel)AddControl(new Guid("f7a0878b-474f-433d-812b-331c7cd4e7eb"));
            labelprotokolTarihiDateTimeRaporDVO = (ITTLabel)AddControl(new Guid("20db807d-b137-4b6a-ac37-9ce83c88a658"));
            tarihDateTimeRaporBilgisiDVO = (ITTDateTimePicker)AddControl(new Guid("4cac468f-8c84-4fe3-bd4e-f40a97b971ab"));
            raporTesisKoduRaporBilgisiDVO = (ITTValueListBox)AddControl(new Guid("88311c87-1c4f-4330-97c8-9a22f6a3cfb6"));
            labelraporTesisKoduRaporBilgisiDVO = (ITTLabel)AddControl(new Guid("e458d9eb-296a-4231-82ce-61cacbd88095"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("fe376e01-36de-427b-8b9b-c1bad4393008"));
            doktorlarTabpage = (ITTTabPage)AddControl(new Guid("b4352351-b128-4a67-aa9a-85b55e401f3a"));
            doktorlarDoktorBilgisiDVO = (ITTGrid)AddControl(new Guid("5154c7a7-c5ba-4282-89ab-01cb06ca0172"));
            drTescilNoDoktorBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("ab130b62-a6e1-4586-8659-54a6e062d633"));
            drAdiDoktorBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("572f45f9-b8df-4e57-b18c-92278f753caf"));
            drSoyadiDoktorBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("732121c3-0cd1-497f-9f87-29892c2e7561"));
            drBransKoduDoktorBilgisiDVO = (ITTListBoxColumn)AddControl(new Guid("bb93bede-5938-4d34-8ef6-9d1454d17186"));
            tipiDoktorBilgisiDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("a41e2e17-5275-4012-ae59-e0f19cc1a92d"));
            tanilarTabpage = (ITTTabPage)AddControl(new Guid("2b013975-db58-4d2f-9ee5-0ae02998d9dd"));
            tanilarTaniBilgisi_RaporDVO = (ITTGrid)AddControl(new Guid("e14c922a-6b13-4c94-96ba-dcebe25ea438"));
            taniKoduTaniBilgisi_RaporDVO = (ITTListBoxColumn)AddControl(new Guid("4af0993e-edf4-4b26-8622-1a3d2d0a06ee"));
            teshislerTabpage = (ITTTabPage)AddControl(new Guid("7721f7fd-e66e-46fe-996e-74df892a6c18"));
            teshislerTeshisBilgisiDVO = (ITTGrid)AddControl(new Guid("e327e7ef-f422-4a57-9847-76dc2a97977d"));
            baslangicTarihiTeshisBilgisiDVO = (ITTDateTimePickerColumn)AddControl(new Guid("ef8475d2-1a00-4ac2-be98-8d8d3d2afd7b"));
            bitisTarihiTeshisBilgisiDVO = (ITTDateTimePickerColumn)AddControl(new Guid("bac675d4-a2f7-4515-aa63-0a5f4303c344"));
            teshisKoduTeshisBilgisiDVO = (ITTListBoxColumn)AddControl(new Guid("f4833155-f3d3-41a7-a298-04fdfcd07069"));
            base.InitializeControls();
        }

        public BaseAnalikIsgoremezlikRaporuKaydetForm() : base("BASEANALIKISGOREMEZLIKRAPORUKAYDET", "BaseAnalikIsgoremezlikRaporuKaydetForm")
        {
        }

        protected BaseAnalikIsgoremezlikRaporuKaydetForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}