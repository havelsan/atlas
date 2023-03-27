
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
    /// Muvakkaten Sayım Düzeltme Belgesi
    /// </summary>
    public partial class BaseConsignedCensusFixed : StockActionBaseForm
    {
    /// <summary>
    /// Muvakkaten Sayım Düzeltme Belgesi  için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.ConsignedCensusFixed _ConsignedCensusFixed
        {
            get { return (TTObjectClasses.ConsignedCensusFixed)_ttObject; }
        }

        protected ITTTextBox StockActionID;
        protected ITTLabel labelStore;
        protected ITTLabel labelStockActionID;
        protected ITTDateTimePicker TransactionDate;
        protected ITTObjectListBox Store;
        protected ITTLabel labelTransactionDate;
        protected ITTTabControl DescriptionAndSignTabControl;
        protected ITTTabPage SignTabpage;
        protected ITTGrid StockActionSignDetails;
        protected ITTEnumComboBoxColumn SignUserType;
        protected ITTListBoxColumn SignUser;
        protected ITTCheckBoxColumn IsDeputy;
        protected ITTTabPage DescriptionTabpage;
        protected ITTTextBox Description;
        protected ITTGroupBox InMaterialsGroupBox;
        protected ITTGrid StockActionInDetails;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn BarcodeA;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn StoreStock;
        protected ITTTextBoxColumn OrderSequenceNumber;
        protected ITTTextBoxColumn CardAmount;
        protected ITTTextBoxColumn CensusAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn Unitprice;
        protected ITTDateTimePickerColumn ExpirationDate;
        protected ITTListDefComboBoxColumn StockLevelType;
        protected ITTGroupBox OutMaterialsGroupBox;
        protected ITTGrid StockActionOutDetails;
        protected ITTListBoxColumn MaterialOut;
        protected ITTTextBoxColumn BarcodeE;
        protected ITTListBoxColumn DistributionTypeOut;
        protected ITTTextBoxColumn StoreStockOut;
        protected ITTTextBoxColumn OrderSequenceNumberOut;
        protected ITTTextBoxColumn CardAmountOut;
        protected ITTTextBoxColumn CensusAmountOut;
        protected ITTTextBoxColumn AmountOut;
        protected ITTListDefComboBoxColumn StockLevelTypeOut;
        protected ITTLabel labelChattelInventoryObjectID;
        protected ITTObjectListBox ChattelInventoryObjectID;
        override protected void InitializeControls()
        {
            StockActionID = (ITTTextBox)AddControl(new Guid("662dad6f-1874-490d-b551-e9abc2f1f673"));
            labelStore = (ITTLabel)AddControl(new Guid("4cac81af-058b-40c6-98c7-a1491300dc61"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("3787195f-55ea-48a2-8339-e76fec7fc4a3"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("32d2a3c6-32db-4323-903d-973328248ff3"));
            Store = (ITTObjectListBox)AddControl(new Guid("0edfec4f-ddea-4fd2-aeb6-66c92d5db42d"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("815f265c-9c71-45ca-b5f1-79dcf35eb2ac"));
            DescriptionAndSignTabControl = (ITTTabControl)AddControl(new Guid("b7fdd213-b1de-4c58-a29d-4214643925f8"));
            SignTabpage = (ITTTabPage)AddControl(new Guid("04637d4e-ef15-48ad-9e5c-1b439c3111ea"));
            StockActionSignDetails = (ITTGrid)AddControl(new Guid("60d8b2bf-ec85-45b5-98c9-a2ee23308014"));
            SignUserType = (ITTEnumComboBoxColumn)AddControl(new Guid("0972b96a-ccce-40c9-825e-64ed2a5a6e87"));
            SignUser = (ITTListBoxColumn)AddControl(new Guid("c5c7ffd2-2e44-4e33-a490-039e9c29ccb0"));
            IsDeputy = (ITTCheckBoxColumn)AddControl(new Guid("597a6bf4-7177-4a0d-93ad-7dda935c6b2e"));
            DescriptionTabpage = (ITTTabPage)AddControl(new Guid("c09f306e-190a-4ff1-8edc-32fe1c894439"));
            Description = (ITTTextBox)AddControl(new Guid("395f1321-8385-488b-9371-e1d26c055014"));
            InMaterialsGroupBox = (ITTGroupBox)AddControl(new Guid("bb5866b3-885d-4aa3-b664-cdee4fe6d52a"));
            StockActionInDetails = (ITTGrid)AddControl(new Guid("df14be96-bfdb-4976-8892-be911644b519"));
            Material = (ITTListBoxColumn)AddControl(new Guid("105ca3ec-c765-44be-a702-ab75a686b283"));
            BarcodeA = (ITTTextBoxColumn)AddControl(new Guid("3cecd3b8-497d-4bbe-9856-8f78ceecbc62"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("bb375102-d900-40c8-ab44-6bcc782d1439"));
            StoreStock = (ITTTextBoxColumn)AddControl(new Guid("518819e3-456b-4534-b5cc-918e16a1853a"));
            OrderSequenceNumber = (ITTTextBoxColumn)AddControl(new Guid("5991adc5-365b-42f5-98ed-f18e72d5e477"));
            CardAmount = (ITTTextBoxColumn)AddControl(new Guid("78e7ea8f-ccbc-4311-86c0-e8b4befd51cf"));
            CensusAmount = (ITTTextBoxColumn)AddControl(new Guid("268802d2-75ba-4e39-967d-84c82ef210ec"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("6d5afe0b-45b2-4206-b0f9-9a87aa95b9f5"));
            Unitprice = (ITTTextBoxColumn)AddControl(new Guid("f6fddcf0-487b-4a6e-987f-3cc8e509c4c3"));
            ExpirationDate = (ITTDateTimePickerColumn)AddControl(new Guid("cfd27862-bbc2-46bd-a827-f8fc3faeed0f"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("a260c979-ada5-44fa-9ad1-535afc6731c9"));
            OutMaterialsGroupBox = (ITTGroupBox)AddControl(new Guid("f8cc9e4f-5654-4937-b971-534f3c927b58"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("e36d87b9-287b-439a-a183-f24be079c5e6"));
            MaterialOut = (ITTListBoxColumn)AddControl(new Guid("9bcd3e81-e86f-4855-b919-2bce63ba09f5"));
            BarcodeE = (ITTTextBoxColumn)AddControl(new Guid("8294af0e-c1fd-4f91-9630-f39e4ae33870"));
            DistributionTypeOut = (ITTListBoxColumn)AddControl(new Guid("2d6bddc1-9d5e-4063-82c6-781672951c77"));
            StoreStockOut = (ITTTextBoxColumn)AddControl(new Guid("48299169-a44b-4e6a-a7ae-0b609dae34c8"));
            OrderSequenceNumberOut = (ITTTextBoxColumn)AddControl(new Guid("3064f358-9e4d-45c0-8bce-c27ba6d70f84"));
            CardAmountOut = (ITTTextBoxColumn)AddControl(new Guid("2b10cc62-498d-41d3-a4e5-38b01ab2a3ea"));
            CensusAmountOut = (ITTTextBoxColumn)AddControl(new Guid("e07dba30-1af1-4131-9feb-26693b3f2c7e"));
            AmountOut = (ITTTextBoxColumn)AddControl(new Guid("ef4a0673-34d3-454e-a82b-34ba79b73f38"));
            StockLevelTypeOut = (ITTListDefComboBoxColumn)AddControl(new Guid("fadd8169-5f3b-49b8-b680-c564ad263db6"));
            labelChattelInventoryObjectID = (ITTLabel)AddControl(new Guid("0c77b31f-8ba7-4e46-9de3-4a7587fc9b60"));
            ChattelInventoryObjectID = (ITTObjectListBox)AddControl(new Guid("9f06a232-b135-4da6-affa-62f748029bb4"));
            base.InitializeControls();
        }

        public BaseConsignedCensusFixed() : base("CONSIGNEDCENSUSFIXED", "BaseConsignedCensusFixed")
        {
        }

        protected BaseConsignedCensusFixed(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}