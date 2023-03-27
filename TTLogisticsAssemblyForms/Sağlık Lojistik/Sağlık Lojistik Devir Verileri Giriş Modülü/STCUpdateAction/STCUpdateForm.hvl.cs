
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
    /// Sayım Tartı Verilerinin Güncellenmesi
    /// </summary>
    public partial class STCUpdateForm : TTForm
    {
    /// <summary>
    /// Sayım Tartı Çizelgesinin Güncellenmesi
    /// </summary>
        protected TTObjectClasses.STCUpdateAction _STCUpdateAction
        {
            get { return (TTObjectClasses.STCUpdateAction)_ttObject; }
        }

        protected ITTButton cmdGetSTC;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelMaterialSTCAction;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage mcTabPage;
        protected ITTGrid MCActionsMCAction;
        protected ITTListBoxColumn StoreMCAction;
        protected ITTTextBoxColumn MuvakkatenVerilenMCAction;
        protected ITTTabPage dcTabPage;
        protected ITTGrid DCActionsDCAction;
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
        protected ITTObjectListBox MaterialSTCAction;
        protected ITTTextBox SiraNuSTCAction;
        protected ITTLabel labelSiraNuSTCAction;
        protected ITTTextBox YeniMevcutSTCAction;
        protected ITTLabel labelYeniMevcutSTCAction;
        protected ITTTextBox KullanilmisMevcutSTCAction;
        protected ITTLabel labelMainStoreDefinitionSTCAction;
        protected ITTLabel labelKullanilmisMevcutSTCAction;
        protected ITTObjectListBox MainStoreDefinitionSTCAction;
        protected ITTTextBox HEKMevcutSTCAction;
        protected ITTLabel labelResCardDrawerSTCAction;
        protected ITTLabel labelHEKMevcutSTCAction;
        protected ITTObjectListBox ResCardDrawerSTCAction;
        protected ITTTextBox MuvakkatenVerilenSTCAction;
        protected ITTLabel labelMuvakkatenVerilenSTCAction;
        protected ITTTextBox ToplamSTCAction;
        protected ITTLabel labelToplamTutarSTCAction;
        protected ITTLabel labelToplamSTCAction;
        protected ITTTextBox ToplamTutarSTCAction;
        protected ITTTextBox ID;
        protected ITTLabel labelID;
        protected ITTLabel labelMaterial;
        protected ITTObjectListBox Material;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            cmdGetSTC = (ITTButton)AddControl(new Guid("2219118d-6b24-40e1-a7d4-02a869faf728"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("e960bbd8-d4cf-4508-90c1-e03a7e276dba"));
            labelMaterialSTCAction = (ITTLabel)AddControl(new Guid("00116646-c5a0-4306-9087-7c3918529b56"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("6097d446-0356-45a3-863c-385c6d5bd4ed"));
            mcTabPage = (ITTTabPage)AddControl(new Guid("74dbbe80-f0b2-4952-b1c1-7aa55d9c910a"));
            MCActionsMCAction = (ITTGrid)AddControl(new Guid("2d65a5f4-afd7-4e0a-95da-d30fe060bef0"));
            StoreMCAction = (ITTListBoxColumn)AddControl(new Guid("bdc88ab1-25f0-498a-97e6-72270848fdac"));
            MuvakkatenVerilenMCAction = (ITTTextBoxColumn)AddControl(new Guid("a5101e7b-1455-4d07-8cbe-548ebe6f32f6"));
            dcTabPage = (ITTTabPage)AddControl(new Guid("8404d0e3-c8c2-4ad0-b626-3acf07309639"));
            DCActionsDCAction = (ITTGrid)AddControl(new Guid("f9269420-f6c4-4293-add1-7de719e6a444"));
            StoreDCAction = (ITTListBoxColumn)AddControl(new Guid("58a066db-17e7-4c4d-ae8f-ad47400c560e"));
            SeriNumarasiDCAction = (ITTTextBoxColumn)AddControl(new Guid("5cc1309b-0ce6-4507-9749-deefd764ebdc"));
            MarkaDCAction = (ITTTextBoxColumn)AddControl(new Guid("0af1d754-4a8f-4242-b95b-29e22e64ed49"));
            ModelDCAction = (ITTTextBoxColumn)AddControl(new Guid("7e7dbb46-b463-438f-a60a-4c85a790c8f1"));
            GucDCAction = (ITTTextBoxColumn)AddControl(new Guid("4beb5617-17cc-4dff-b11b-daa76d73fe79"));
            VoltajDCAction = (ITTTextBoxColumn)AddControl(new Guid("cdedfe1c-7e8b-4771-94ac-f44ac41effff"));
            FrekansDCAction = (ITTTextBoxColumn)AddControl(new Guid("def48892-33b7-46ef-9ae1-a18e8646d8b8"));
            GarantiBaslangicTarihiDCAction = (ITTDateTimePickerColumn)AddControl(new Guid("c398e649-2793-480b-9fac-a96ff645ca9e"));
            GarantiBitisTarihiDCAction = (ITTDateTimePickerColumn)AddControl(new Guid("ce24c03c-6441-45bf-9d2d-f80305cc5e03"));
            GarantiAciklamasiDCAction = (ITTTextBoxColumn)AddControl(new Guid("4db054ab-7117-4969-9e4f-962dd27c3085"));
            ImalTarihiDCAction = (ITTDateTimePickerColumn)AddControl(new Guid("367de806-9a4b-4732-b089-bb83c4421737"));
            SonBakimTarihiDCAction = (ITTDateTimePickerColumn)AddControl(new Guid("e09f9947-49fc-4213-ad1f-287451eb86c7"));
            SonKalibrasyonTarihiDCAction = (ITTDateTimePickerColumn)AddControl(new Guid("ab736d48-3490-42c8-9e6b-f3931cef71cc"));
            MaterialSTCAction = (ITTObjectListBox)AddControl(new Guid("d0d87186-f89c-4097-9ba8-f106fe1b3815"));
            SiraNuSTCAction = (ITTTextBox)AddControl(new Guid("54983ef0-47e2-484d-b7e3-7ec36e3d0658"));
            labelSiraNuSTCAction = (ITTLabel)AddControl(new Guid("cfc002a9-ac86-4cad-a71f-3e42a1c56e63"));
            YeniMevcutSTCAction = (ITTTextBox)AddControl(new Guid("5bba7001-75c3-41e4-bb6c-e2128dee4661"));
            labelYeniMevcutSTCAction = (ITTLabel)AddControl(new Guid("a6c0ef45-cd32-470b-8a19-5fbe454647ed"));
            KullanilmisMevcutSTCAction = (ITTTextBox)AddControl(new Guid("7658f52d-3630-43f0-a665-419af05580f4"));
            labelMainStoreDefinitionSTCAction = (ITTLabel)AddControl(new Guid("4138568b-4172-4b8b-993c-ddb1ee479a28"));
            labelKullanilmisMevcutSTCAction = (ITTLabel)AddControl(new Guid("0407d768-7088-4b5f-b42a-d1dd95ac3260"));
            MainStoreDefinitionSTCAction = (ITTObjectListBox)AddControl(new Guid("623caaa9-6f0c-4821-8356-3c8eccd16407"));
            HEKMevcutSTCAction = (ITTTextBox)AddControl(new Guid("7fde2c2b-861f-4f5a-962d-13166cc01079"));
            labelResCardDrawerSTCAction = (ITTLabel)AddControl(new Guid("dcb0bb05-a899-4e08-aa5a-cd1a09457fb6"));
            labelHEKMevcutSTCAction = (ITTLabel)AddControl(new Guid("1795d114-f230-4d3f-bc08-0e04b22b939e"));
            ResCardDrawerSTCAction = (ITTObjectListBox)AddControl(new Guid("27561178-22d1-4c8a-b482-9824e86fb7ca"));
            MuvakkatenVerilenSTCAction = (ITTTextBox)AddControl(new Guid("426ef7dd-a8c4-4937-8128-2415d2739ed4"));
            labelMuvakkatenVerilenSTCAction = (ITTLabel)AddControl(new Guid("bd906470-993b-403d-8aca-3f9b6abe2730"));
            ToplamSTCAction = (ITTTextBox)AddControl(new Guid("d93c9fa8-eed8-4ac9-9527-63b43a459e9f"));
            labelToplamTutarSTCAction = (ITTLabel)AddControl(new Guid("bdf1ef12-beba-4387-a1b5-dcdaf28d1e92"));
            labelToplamSTCAction = (ITTLabel)AddControl(new Guid("5cb9a929-0149-484a-895d-0be87cc0366e"));
            ToplamTutarSTCAction = (ITTTextBox)AddControl(new Guid("71ec61f2-e0a5-4bc6-8bb8-efad6e457306"));
            ID = (ITTTextBox)AddControl(new Guid("8a2b938b-18a7-467e-9def-d8ea4f419174"));
            labelID = (ITTLabel)AddControl(new Guid("9df49df6-9944-48bc-bd31-b1993cde7cd6"));
            labelMaterial = (ITTLabel)AddControl(new Guid("969832b8-6311-466d-b6a0-cc4868cfa591"));
            Material = (ITTObjectListBox)AddControl(new Guid("6d5a0d2d-5ac2-4c53-9d77-14af3d23d516"));
            labelActionDate = (ITTLabel)AddControl(new Guid("59b2f6b2-dc63-435f-9eba-43d19a4111df"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("939a2340-760b-4166-a800-f697b7c6f45b"));
            base.InitializeControls();
        }

        public STCUpdateForm() : base("STCUPDATEACTION", "STCUpdateForm")
        {
        }

        protected STCUpdateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}