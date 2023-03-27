
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
    public partial class BaseChattelDocumentOutputWithAccountancy : BaseChattelDocumentForm
    {
    /// <summary>
    /// Taşınır Mal İşlemi Çıkış
    /// </summary>
        protected TTObjectClasses.ChattelDocumentOutputWithAccountancy _ChattelDocumentOutputWithAccountancy
        {
            get { return (TTObjectClasses.ChattelDocumentOutputWithAccountancy)_ttObject; }
        }

        protected ITTTextBox Waybill;
        protected ITTLabel labelWaybillDate;
        protected ITTDateTimePicker WaybillDate;
        protected ITTLabel labelWaybill;
        protected ITTLabel labeloutputStockMovementType;
        protected ITTEnumComboBox outputStockMovementType;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTTabControl ChattelDocumentTabcontrol;
        protected ITTTabPage ChattelDocumentTabpage;
        protected ITTGrid ChattelDocumentDetailsWithAccountancy;
        protected ITTButtonColumn Detail;
        protected ITTListBoxColumn MaterialChattelDocumentDetailWithAccountancy;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn StoreStock;
        protected ITTTextBoxColumn AmountChattelDocumentDetailWithAccountancy;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTextBoxColumn Price;
        protected ITTListBoxColumn StockLevelTypeChattelDocumentDetailWithAccountancy;
        protected ITTEnumComboBoxColumn StatusChattelDocumentDetailWithAccountancy;
        protected ITTLabel labelAccountancy;
        protected ITTObjectListBox Accountancy;
        protected ITTEnumComboBox MKYS_CikisStokHareketTuru;
        protected ITTLabel lblMKYS_CikisIslemTuru;
        protected ITTEnumComboBox MKYS_CikisIslemTuru;
        protected ITTLabel lblMKYS_CikisStokHareketTuru;
        override protected void InitializeControls()
        {
            Waybill = (ITTTextBox)AddControl(new Guid("dd5d0c50-c47d-4664-a5bd-96ce674b306f"));
            labelWaybillDate = (ITTLabel)AddControl(new Guid("9eef7f3f-7979-42f0-ab8d-9ba7c5b96d7a"));
            WaybillDate = (ITTDateTimePicker)AddControl(new Guid("87a68a71-ba86-410b-9280-c6c3de04751c"));
            labelWaybill = (ITTLabel)AddControl(new Guid("4468ca9c-dd3c-4bc8-bb83-256988c6185c"));
            labeloutputStockMovementType = (ITTLabel)AddControl(new Guid("042903b4-3dd5-4666-9a44-9564971064af"));
            outputStockMovementType = (ITTEnumComboBox)AddControl(new Guid("883aaf18-443f-46c1-9bda-c85ffb390b3d"));
            labelStore = (ITTLabel)AddControl(new Guid("d7849f12-c5e9-4b4a-8ba3-e4eb480f9424"));
            Store = (ITTObjectListBox)AddControl(new Guid("409ddd9e-4264-4e43-bf9f-dc097f0ba8d5"));
            ChattelDocumentTabcontrol = (ITTTabControl)AddControl(new Guid("a71413ca-7ca5-4e8a-8758-f9c690c5b08d"));
            ChattelDocumentTabpage = (ITTTabPage)AddControl(new Guid("6f1778d6-845d-4c8e-bed3-474f831004a5"));
            ChattelDocumentDetailsWithAccountancy = (ITTGrid)AddControl(new Guid("fa4aea94-8bdb-46e5-a0ff-407d700df564"));
            Detail = (ITTButtonColumn)AddControl(new Guid("e31b1c92-6dab-49fa-a347-84fe91b78dbf"));
            MaterialChattelDocumentDetailWithAccountancy = (ITTListBoxColumn)AddControl(new Guid("71794d91-8fce-4242-85a2-2e9c6e73d9d0"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("0b2e6121-36e7-49a1-8d1c-9fe7469d6a8f"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("2db435ee-8c90-4784-8269-403b436c9a70"));
            StoreStock = (ITTTextBoxColumn)AddControl(new Guid("12527602-e4dc-4e44-8be2-2fb76dfb0941"));
            AmountChattelDocumentDetailWithAccountancy = (ITTTextBoxColumn)AddControl(new Guid("fd066246-6450-4fdd-b31a-5b9477ab5860"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("225bd935-bbda-49e7-9ba8-2e8d9768ad85"));
            Price = (ITTTextBoxColumn)AddControl(new Guid("3e407231-c665-4d13-ad97-53aa8f2ad975"));
            StockLevelTypeChattelDocumentDetailWithAccountancy = (ITTListBoxColumn)AddControl(new Guid("cbbce391-092c-416f-aabb-3f544e2bf71a"));
            StatusChattelDocumentDetailWithAccountancy = (ITTEnumComboBoxColumn)AddControl(new Guid("891e0341-6097-4055-b846-08b7407dad81"));
            labelAccountancy = (ITTLabel)AddControl(new Guid("37f498a6-95e5-4110-986f-36cc982da90d"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("80f50e0e-c896-48af-9700-cfab32825313"));
            MKYS_CikisStokHareketTuru = (ITTEnumComboBox)AddControl(new Guid("fc56b0cb-a4bf-44b8-9c40-e833b3291407"));
            lblMKYS_CikisIslemTuru = (ITTLabel)AddControl(new Guid("912348fd-409e-47da-810f-4d302e1bc1ef"));
            MKYS_CikisIslemTuru = (ITTEnumComboBox)AddControl(new Guid("0e191e2c-f79b-4d4b-8dac-c9d95c3d3f6e"));
            lblMKYS_CikisStokHareketTuru = (ITTLabel)AddControl(new Guid("d3bc2859-e326-47d9-a8f1-0108f650437d"));
            base.InitializeControls();
        }

        public BaseChattelDocumentOutputWithAccountancy() : base("CHATTELDOCUMENTOUTPUTWITHACCOUNTANCY", "BaseChattelDocumentOutputWithAccountancy")
        {
        }

        protected BaseChattelDocumentOutputWithAccountancy(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}