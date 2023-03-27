
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
    /// Sipariş
    /// </summary>
    public partial class PurchaseOrderNewForm : TTForm
    {
    /// <summary>
    /// Firmaya verilen sipariş bilgilerinin tutuldufu sınıftır
    /// </summary>
        protected TTObjectClasses.PurchaseOrder _PurchaseOrder
        {
            get { return (TTObjectClasses.PurchaseOrder)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox2;
        protected ITTGrid ContractsGrid;
        protected ITTTextBoxColumn clmContractNo;
        protected ITTListBoxColumn clmSupplier;
        protected ITTButton cmdAddAll;
        protected ITTTextBox txtProjectNO;
        protected ITTTextBox OrderNO;
        protected ITTTextBox txtConfirmNO;
        protected ITTLabel ttlabel1;
        protected ITTButton cmdList;
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid PurchaseOrderDetailsGrid;
        protected ITTButtonColumn Release;
        protected ITTListBoxColumn PurchaseItem;
        protected ITTListBoxColumn StockCard;
        protected ITTTextBoxColumn NSN;
        protected ITTDateTimePickerColumn DeliveryDate;
        protected ITTTextBoxColumn ProjectDetailAmount;
        protected ITTTextBoxColumn RestAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTextBoxColumn OrderPrice;
        protected ITTTextBoxColumn Description;
        protected ITTButton cmdOldOrders;
        protected ITTDateTimePicker OrderDate;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox txtSupplier;
        protected ITTLabel labelOrderNO;
        protected ITTLabel labelOrderDate;
        protected ITTLabel ttlabel3;
        protected ITTGroupBox ttgroupbox3;
        protected ITTGrid ContractDetailsGrid;
        protected ITTButtonColumn clmAdd;
        protected ITTListBoxColumn clmPurchaseItem;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn1;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("bd43921a-5840-4d52-936b-f8b77d4a6016"));
            ContractsGrid = (ITTGrid)AddControl(new Guid("0b10a254-0a52-45c7-b920-2b0687a31f48"));
            clmContractNo = (ITTTextBoxColumn)AddControl(new Guid("1a7e3d43-fca5-4cc2-bb14-32e45c5e0d01"));
            clmSupplier = (ITTListBoxColumn)AddControl(new Guid("ad67cfcf-d068-4586-996b-d05a7ac42fc8"));
            cmdAddAll = (ITTButton)AddControl(new Guid("34a35128-416e-4007-a51a-8b4ad1427da9"));
            txtProjectNO = (ITTTextBox)AddControl(new Guid("691aec62-7baa-4fe6-82d1-232fa5a33bb0"));
            OrderNO = (ITTTextBox)AddControl(new Guid("b8c6a4e0-2f85-4e57-88ce-ad04d290d9b5"));
            txtConfirmNO = (ITTTextBox)AddControl(new Guid("60d457d8-6134-4083-af8e-f8dfc9e19727"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e236eb85-1bfc-4a1f-830c-2c63e84bde46"));
            cmdList = (ITTButton)AddControl(new Guid("4011ba77-ba5b-4fc4-a165-4779aae42cec"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("fdfb1174-220f-4f36-bdf6-73525110fef7"));
            PurchaseOrderDetailsGrid = (ITTGrid)AddControl(new Guid("92becc45-308c-4870-a4ab-b25c92c1a111"));
            Release = (ITTButtonColumn)AddControl(new Guid("b6ca5c90-0033-4e4f-b436-c111c6fd9551"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("24d38d44-5dd3-4dd0-b199-7166a5cb547f"));
            StockCard = (ITTListBoxColumn)AddControl(new Guid("473bc75a-6b2e-4826-8ba5-682cf8d99530"));
            NSN = (ITTTextBoxColumn)AddControl(new Guid("d9f472ae-c09b-4741-a7b6-322d7a3dfe75"));
            DeliveryDate = (ITTDateTimePickerColumn)AddControl(new Guid("7d8a67cd-d834-4cf9-9fa5-5765daf04bd4"));
            ProjectDetailAmount = (ITTTextBoxColumn)AddControl(new Guid("a5f4d397-a269-4414-9a2f-8722aff8831e"));
            RestAmount = (ITTTextBoxColumn)AddControl(new Guid("7752b19e-b25f-4082-be1f-3d5e90a85900"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("e3f5ef94-b913-47e0-bf33-a3ebeda0a979"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("d0454b3a-b4eb-4840-88a1-003e40984e82"));
            OrderPrice = (ITTTextBoxColumn)AddControl(new Guid("45fc5789-c718-44a9-92a2-3fef4cce5d32"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("a3a7f74c-97a1-4174-9c0c-5555b807b0f1"));
            cmdOldOrders = (ITTButton)AddControl(new Guid("b16a58ad-ddc7-4d6b-953e-7ac1186d4bd8"));
            OrderDate = (ITTDateTimePicker)AddControl(new Guid("86ef5d93-62ac-48b0-887c-7f5bb667c221"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("7148bbc4-da67-4b90-bd33-8f56d7fd0b26"));
            txtSupplier = (ITTObjectListBox)AddControl(new Guid("ca745077-14dc-4d97-adfc-98d066d7af3c"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("c3ff3375-ff68-4240-bcd7-cba5d421eb2d"));
            labelOrderDate = (ITTLabel)AddControl(new Guid("a8382fcc-4dc6-43a3-9563-e46acfe0654f"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("6e19058b-1e07-4a7d-bfcf-c27ba1358f01"));
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("8708d80d-5460-450a-8646-006860065a00"));
            ContractDetailsGrid = (ITTGrid)AddControl(new Guid("e5ea1746-6451-4f34-8615-97e8e19c7fd2"));
            clmAdd = (ITTButtonColumn)AddControl(new Guid("3b335c7c-f30b-4812-b13f-84a0c27f3e6c"));
            clmPurchaseItem = (ITTListBoxColumn)AddControl(new Guid("e3d6a2fc-8a48-455f-8e91-e3666a76b85f"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("94fce372-eb32-40ca-9926-286a4997cc88"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("ff5c35df-83cf-4ab2-96a4-4c4e2a6f2ddb"));
            base.InitializeControls();
        }

        public PurchaseOrderNewForm() : base("PURCHASEORDER", "PurchaseOrderNewForm")
        {
        }

        protected PurchaseOrderNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}