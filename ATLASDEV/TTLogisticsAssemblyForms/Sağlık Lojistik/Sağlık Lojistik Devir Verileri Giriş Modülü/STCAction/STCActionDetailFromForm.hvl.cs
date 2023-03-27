
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
    /// Sayım Tartı Cizelgesi Detayları
    /// </summary>
    public partial class STCActionDetailFrom : TTForm
    {
    /// <summary>
    /// Sayım Tarti Çizelgesi
    /// </summary>
        protected TTObjectClasses.STCAction _STCAction
        {
            get { return (TTObjectClasses.STCAction)_ttObject; }
        }

        protected ITTValueListBox DistListBox;
        protected ITTTextBox RestConsigned;
        protected ITTTextBox MuvakkatenVerilen;
        protected ITTLabel labelMuvakkatenVerilen;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MCTabpage;
        protected ITTGrid MCActions;
        protected ITTListBoxColumn StoreMCAction;
        protected ITTTextBoxColumn MuvakkatenVerilenMCAction;
        protected ITTTabPage DCTabpage;
        protected ITTGrid DCActions;
        protected ITTListBoxColumn StoreDCAction;
        protected ITTTextBoxColumn SeriNumarasiDCAction;
        protected ITTTextBoxColumn MarkaDCAction;
        protected ITTTextBoxColumn ModelDCAction;
        protected ITTTextBoxColumn GucDCAction;
        protected ITTTextBoxColumn VoltajDCAction;
        protected ITTTextBoxColumn FrekansDCAction;
        protected ITTDateTimePickerColumn GarantiBaslangicTarihiDCAction;
        protected ITTDateTimePickerColumn GarantiBitisTarihiDCAction;
        protected ITTTextBoxColumn GarantiAciklamasiDCAction;
        protected ITTDateTimePickerColumn ImalTarihiDCAction;
        protected ITTDateTimePickerColumn SonBakimTarihiDCAction;
        protected ITTDateTimePickerColumn SonKalibrasyonTarihiDCAction;
        protected ITTTextBox YeniMevcut;
        protected ITTTextBox ToplamTutar;
        protected ITTTextBox Toplam;
        protected ITTTextBox KullanilmisMevcut;
        protected ITTTextBox HEKMevcut;
        protected ITTLabel labelResCardDrawer;
        protected ITTObjectListBox ResCardDrawer;
        protected ITTLabel labelMaterial;
        protected ITTObjectListBox Material;
        protected ITTLabel labelYeniMevcut;
        protected ITTLabel labelToplamTutar;
        protected ITTLabel labelToplam;
        protected ITTLabel labelKullanilmisMevcut;
        protected ITTLabel labelHEKMevcut;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            DistListBox = (ITTValueListBox)AddControl(new Guid("4c2229bf-c5fd-49f0-bf5b-7064ea1c0d11"));
            RestConsigned = (ITTTextBox)AddControl(new Guid("2926564d-a8ff-4edd-9fb8-a3a3987c3a5e"));
            MuvakkatenVerilen = (ITTTextBox)AddControl(new Guid("2803378b-5d8c-4281-9cb4-1c6c33cca48f"));
            labelMuvakkatenVerilen = (ITTLabel)AddControl(new Guid("d9af34bd-ad05-4a4f-97fc-32d2e5ec216e"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("c66ae17f-b19e-43ba-9b5b-9d54aab500a5"));
            MCTabpage = (ITTTabPage)AddControl(new Guid("88c35894-045d-4c56-8568-6138d2fe7aad"));
            MCActions = (ITTGrid)AddControl(new Guid("f2dcf622-7b70-4a78-b541-611f4fd5b0fc"));
            StoreMCAction = (ITTListBoxColumn)AddControl(new Guid("fea95758-6dac-44b0-96bb-0a952a831fa9"));
            MuvakkatenVerilenMCAction = (ITTTextBoxColumn)AddControl(new Guid("906b84fb-a1b6-48b9-8d2e-704960d366aa"));
            DCTabpage = (ITTTabPage)AddControl(new Guid("f51c4c6f-f9de-4160-81bd-36c579102315"));
            DCActions = (ITTGrid)AddControl(new Guid("3447ba1b-fc77-4d97-aca9-4d6d452316f5"));
            StoreDCAction = (ITTListBoxColumn)AddControl(new Guid("ed92ee08-e16e-4253-950c-fd8b4b37d2cc"));
            SeriNumarasiDCAction = (ITTTextBoxColumn)AddControl(new Guid("9cd63c4d-764d-4edf-ac99-37e17e75817a"));
            MarkaDCAction = (ITTTextBoxColumn)AddControl(new Guid("d9d05ec4-cdd2-4884-a142-9f45deab708c"));
            ModelDCAction = (ITTTextBoxColumn)AddControl(new Guid("b223bfea-bfa2-4b75-b0da-8097d6a409d1"));
            GucDCAction = (ITTTextBoxColumn)AddControl(new Guid("d3912830-b6e3-4d87-ac5d-83aafcdc0325"));
            VoltajDCAction = (ITTTextBoxColumn)AddControl(new Guid("099477e4-86a1-4ba3-8fbc-c126cbf97bd6"));
            FrekansDCAction = (ITTTextBoxColumn)AddControl(new Guid("a29d19fd-46cc-4ded-ba64-a0eefe020576"));
            GarantiBaslangicTarihiDCAction = (ITTDateTimePickerColumn)AddControl(new Guid("c01941d5-8e13-476b-8078-331c09f990d0"));
            GarantiBitisTarihiDCAction = (ITTDateTimePickerColumn)AddControl(new Guid("810b2ef9-7b57-478e-9899-483062128b1f"));
            GarantiAciklamasiDCAction = (ITTTextBoxColumn)AddControl(new Guid("7f245b8d-7b93-489b-9874-e2153e6b197f"));
            ImalTarihiDCAction = (ITTDateTimePickerColumn)AddControl(new Guid("76b5cb0c-ea90-4fdc-8ca1-acbcd33247db"));
            SonBakimTarihiDCAction = (ITTDateTimePickerColumn)AddControl(new Guid("a8850115-8c92-42b9-813e-0cc7e135786c"));
            SonKalibrasyonTarihiDCAction = (ITTDateTimePickerColumn)AddControl(new Guid("5e37228e-1485-4f2b-bd0a-ffa8d86e5d2d"));
            YeniMevcut = (ITTTextBox)AddControl(new Guid("7dac82d1-116d-48df-a34b-c100a0ad34ed"));
            ToplamTutar = (ITTTextBox)AddControl(new Guid("09bd1429-250b-45ff-a418-217c05ae1586"));
            Toplam = (ITTTextBox)AddControl(new Guid("bf327faf-e5c3-414a-bda1-b6f78d509f06"));
            KullanilmisMevcut = (ITTTextBox)AddControl(new Guid("fa1ba8ce-f685-4172-9e9c-9736848777a7"));
            HEKMevcut = (ITTTextBox)AddControl(new Guid("c915a17f-b36f-489f-ab95-8d845737c177"));
            labelResCardDrawer = (ITTLabel)AddControl(new Guid("02db15e6-2866-4d6e-b327-ea7bf4ce867b"));
            ResCardDrawer = (ITTObjectListBox)AddControl(new Guid("73acb621-add1-4622-a5df-97d90fe2a580"));
            labelMaterial = (ITTLabel)AddControl(new Guid("47925417-73d2-40fd-b5d3-1e51172b2cb7"));
            Material = (ITTObjectListBox)AddControl(new Guid("192b70dd-dbde-42fb-82d8-fcfaab367e6e"));
            labelYeniMevcut = (ITTLabel)AddControl(new Guid("be28a679-216f-4b21-800a-5c94f6f113e7"));
            labelToplamTutar = (ITTLabel)AddControl(new Guid("59e655e1-215c-4af1-970f-1ad001bf692e"));
            labelToplam = (ITTLabel)AddControl(new Guid("adebe039-b09c-40fb-8829-51955bae16b4"));
            labelKullanilmisMevcut = (ITTLabel)AddControl(new Guid("b89a94c2-9155-4a94-8411-c758a79eeea0"));
            labelHEKMevcut = (ITTLabel)AddControl(new Guid("cf62ac05-5f9a-4d62-bb2b-3f3205629eed"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("fbe06a2a-8593-44a5-9888-59dbfb77eee2"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("29d53940-a5dd-445d-8dfa-dbf23fe43468"));
            base.InitializeControls();
        }

        public STCActionDetailFrom() : base("STCACTION", "STCActionDetailFrom")
        {
        }

        protected STCActionDetailFrom(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}