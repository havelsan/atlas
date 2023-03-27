
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
    public partial class BaseTedaviRaporuKaydetForm : BaseRaporBilgisiKaydetForm
    {
        protected TTObjectClasses.BaseTedaviRaporuKaydet _BaseTedaviRaporuKaydet
        {
            get { return (TTObjectClasses.BaseTedaviRaporuKaydet)_ttObject; }
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
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("da541dc0-5a96-4bd0-b187-4c22c855372e"));
            tedaviRaporuYaz = (ITTButton)AddControl(new Guid("4c350928-52d8-4e51-ae23-4cc803a871c6"));
            labeltedaviRaporTuruTedaviRaporDVO = (ITTLabel)AddControl(new Guid("a1b6334e-3b8e-4083-8828-7d2574492e34"));
            labelnoRaporBilgisiDVO = (ITTLabel)AddControl(new Guid("253e7483-f32f-433c-80ba-34f6168bf8ad"));
            tedaviRaporTuruTedaviRaporDVO = (ITTListDefComboBox)AddControl(new Guid("b3be1fac-192c-4f3f-b6cc-4732419e12a8"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("95b326ac-4cbe-44d7-b26b-a98e133379be"));
            aciklamaTabpage = (ITTTabPage)AddControl(new Guid("418b85d0-c94e-4a5c-8e4f-52d766da8e5b"));
            aciklamaRaporDVO = (ITTTextBox)AddControl(new Guid("529aebad-d7bf-43ef-98ca-7e0bc63a31ca"));
            klinikTaniTabpage = (ITTTabPage)AddControl(new Guid("81adec06-6265-4473-8c2b-d8af700b11eb"));
            klinikTanıRaporDVO = (ITTTextBox)AddControl(new Guid("4a626e19-917d-4105-a4e5-b1b9fa7a0778"));
            duzenlemeTuruRaporDVO = (ITTListDefComboBox)AddControl(new Guid("c2ba4cfd-b5c8-463a-b7fd-11a698fe9988"));
            labelduzenlemeTuruRaporDVO = (ITTLabel)AddControl(new Guid("f6f597b0-0721-457f-aa40-dfad9212cf27"));
            noRaporBilgisiDVO = (ITTTextBox)AddControl(new Guid("f8fbe535-1542-4bed-a86e-8dbcc2dd884c"));
            labelprotokolNoRaporDVO = (ITTLabel)AddControl(new Guid("3fb70f26-5eef-4e3d-819c-5896f6ef4a5f"));
            protokolNoRaporDVO = (ITTTextBox)AddControl(new Guid("9fb995c1-3e59-47dd-b879-5c1bc988579e"));
            baslangicTarihiDateTimeRaporDVO = (ITTDateTimePicker)AddControl(new Guid("e7af78d1-4aeb-44ce-aa4f-0a82ad3a6955"));
            labelbaslangicTarihiDateTimeRaporDVO = (ITTLabel)AddControl(new Guid("30137057-a3bb-497a-b9b8-3558fdaae702"));
            bitisTarihiDateTimeRaporDVO = (ITTDateTimePicker)AddControl(new Guid("b4479d1b-7f97-431f-9ae9-05f7c6221109"));
            labeltarihDateTimeRaporBilgisiDVO = (ITTLabel)AddControl(new Guid("699fa42b-b425-45ff-9d65-6c74613035d0"));
            labelbitisTarihiDateTimeRaporDVO = (ITTLabel)AddControl(new Guid("dd07537b-0bd1-4e16-9af6-24b0a3daebbd"));
            turuRaporDVO = (ITTListDefComboBox)AddControl(new Guid("9845c134-b768-4ff8-ba3e-5a16facd63ce"));
            protokolTarihiDateTimeRaporDVO = (ITTDateTimePicker)AddControl(new Guid("b4df49f1-561f-4496-9d3d-fcb8226e43d9"));
            labelturuRaporDVO = (ITTLabel)AddControl(new Guid("544a2747-1a6c-41ba-99e8-a2327e5c13d0"));
            labelprotokolTarihiDateTimeRaporDVO = (ITTLabel)AddControl(new Guid("4c78348b-25ac-481f-9573-e27c6a1e3b77"));
            tarihDateTimeRaporBilgisiDVO = (ITTDateTimePicker)AddControl(new Guid("417954b5-11c8-46c9-b1ce-3df30471f99d"));
            raporTesisKoduRaporBilgisiDVO = (ITTValueListBox)AddControl(new Guid("37ec78d4-6ae4-49a2-94a4-c6bc211d24a8"));
            labelraporTesisKoduRaporBilgisiDVO = (ITTLabel)AddControl(new Guid("a96eeaa3-e574-4164-9f59-15bff2c776ad"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("23492f2d-ada0-4346-850c-9cf66d667c27"));
            doktorlarTabpage = (ITTTabPage)AddControl(new Guid("cb5661a7-ced8-4f98-a73e-99bd8db7676d"));
            doktorlarDoktorBilgisiDVO = (ITTGrid)AddControl(new Guid("31a0b9de-ad86-40c8-be1d-12fcf965ad0e"));
            drTescilNoDoktorBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("c7d03823-ed57-4b31-832e-27b99ff05100"));
            drAdiDoktorBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("3af3dea8-4604-4137-a952-1431a277f284"));
            drSoyadiDoktorBilgisiDVO = (ITTTextBoxColumn)AddControl(new Guid("bd08e9da-be22-4830-8140-886c4dae6d0d"));
            drBransKoduDoktorBilgisiDVO = (ITTListBoxColumn)AddControl(new Guid("747701ed-648d-418b-b1de-f5d89038bc91"));
            tipiDoktorBilgisiDVO = (ITTListDefComboBoxColumn)AddControl(new Guid("b5680003-695b-4721-8289-f8d68d924c0c"));
            tanilarTabpage = (ITTTabPage)AddControl(new Guid("6f589b3e-ed95-4642-8359-39ad4e64e6de"));
            tanilarTaniBilgisi_RaporDVO = (ITTGrid)AddControl(new Guid("af3a28be-a411-4a0f-809f-36416277d622"));
            taniKoduTaniBilgisi_RaporDVO = (ITTListBoxColumn)AddControl(new Guid("b824293f-4b0f-4464-917d-6de3ed72362d"));
            teshislerTabpage = (ITTTabPage)AddControl(new Guid("8c04b038-379d-419e-8ed5-0ec7b09b05ea"));
            teshislerTeshisBilgisiDVO = (ITTGrid)AddControl(new Guid("ae8e2ccc-66ef-4019-8175-afcd8fbcfadd"));
            baslangicTarihiTeshisBilgisiDVO = (ITTDateTimePickerColumn)AddControl(new Guid("d4a40ce2-d226-476f-bede-e5df65202b1c"));
            bitisTarihiTeshisBilgisiDVO = (ITTDateTimePickerColumn)AddControl(new Guid("f7aeb7a7-062a-4519-a0fd-019ba85ccd96"));
            teshisKoduTeshisBilgisiDVO = (ITTListBoxColumn)AddControl(new Guid("13b1c31c-7fea-4766-8305-d3751b586f20"));
            base.InitializeControls();
        }

        public BaseTedaviRaporuKaydetForm() : base("BASETEDAVIRAPORUKAYDET", "BaseTedaviRaporuKaydetForm")
        {
        }

        protected BaseTedaviRaporuKaydetForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}