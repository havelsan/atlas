
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
    public partial class BaseSubStoreStockTransferForm : StockActionBaseForm
    {
    /// <summary>
    /// Depolar Arası Transfer
    /// </summary>
        protected TTObjectClasses.SubStoreStockTransfer _SubStoreStockTransfer
        {
            get { return (TTObjectClasses.SubStoreStockTransfer)_ttObject; }
        }

        protected ITTTextBox Description;
        protected ITTTextBox StockActionID;
        protected ITTLabel labelDestinationStore;
        protected ITTObjectListBox DestinationStore;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelStockActionID;
        protected ITTTabControl DescriptionAndSignTabControl;
        protected ITTTabPage SignTabpage;
        protected ITTGrid StockActionSignDetails;
        protected ITTEnumComboBoxColumn SignUserType;
        protected ITTListBoxColumn SignUser;
        protected ITTCheckBoxColumn IsDeputy;
        protected ITTTabPage DescriptionTabpage;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialTabPage;
        protected ITTGrid SubStoreStockTransferMaterials;
        protected ITTButtonColumn Detail;
        protected ITTListBoxColumn MaterialSubStoreStockTransferMat;
        protected ITTTextBoxColumn MaterialBarcode;
        protected ITTTextBoxColumn Distrubitontype;
        protected ITTTextBoxColumn RequestAmountSubStoreStockTransferMat;
        protected ITTTextBoxColumn AmountSubStoreStockTransferMat;
        protected ITTListBoxColumn StockLevelType;
        protected ITTTextBox MKYS_TeslimAlan;
        protected ITTTextBox MKYS_TeslimEden;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelMKYS_TeslimEden;
        protected ITTLabel labelMKYS_TeslimAlan;
        protected ITTButton TTTeslimAlanButon;
        protected ITTButton TTTeslimEdenButon;
        override protected void InitializeControls()
        {
            Description = (ITTTextBox)AddControl(new Guid("6f0d0b43-b2f0-422d-b38e-d0d662068600"));
            StockActionID = (ITTTextBox)AddControl(new Guid("92486409-5ebd-4872-934c-d2fa9705bd07"));
            labelDestinationStore = (ITTLabel)AddControl(new Guid("c78d6d0c-fc0f-4731-bac5-b04ffd895d2a"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("cef0a76e-8a6a-4652-9d0d-4d5b52d3bbfd"));
            labelStore = (ITTLabel)AddControl(new Guid("96683b39-e14d-4694-b0cc-6b027611b0c3"));
            Store = (ITTObjectListBox)AddControl(new Guid("a1db2f01-7d93-45dd-9db2-6df735be636f"));
            labelActionDate = (ITTLabel)AddControl(new Guid("a90c9f36-5213-4d38-9869-559817ab8858"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("382827e4-f9eb-4c4a-bb2e-d874523dadb5"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("5d4e31f3-6bac-409f-ba4d-4f55c0fe2070"));
            DescriptionAndSignTabControl = (ITTTabControl)AddControl(new Guid("ac4e4583-f1b5-40bb-be8a-672af4ff15a7"));
            SignTabpage = (ITTTabPage)AddControl(new Guid("90bd46a0-c158-4919-9c08-d1de0fb602ae"));
            StockActionSignDetails = (ITTGrid)AddControl(new Guid("b06ba0ce-a8ec-4eb2-a93a-6e5542815cbe"));
            SignUserType = (ITTEnumComboBoxColumn)AddControl(new Guid("0a81a7e6-a553-4fa3-aad1-e6cd4ff77a07"));
            SignUser = (ITTListBoxColumn)AddControl(new Guid("79da306b-af74-479f-a69f-16fb492ace7d"));
            IsDeputy = (ITTCheckBoxColumn)AddControl(new Guid("816d5991-be51-4e2a-be4c-479d4ee42b80"));
            DescriptionTabpage = (ITTTabPage)AddControl(new Guid("1a0d0e48-6447-40ce-a44c-a813d2af738c"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("f20b1d4f-907b-477e-8874-4eeb0b6c3e52"));
            MaterialTabPage = (ITTTabPage)AddControl(new Guid("8386683b-6a00-4ac7-9fab-7f3eaf2adf6d"));
            SubStoreStockTransferMaterials = (ITTGrid)AddControl(new Guid("1fa0e3d9-8694-48fb-abda-d8f2611af28d"));
            Detail = (ITTButtonColumn)AddControl(new Guid("318ee6ee-c7ef-46d4-820e-cee12b233fbc"));
            MaterialSubStoreStockTransferMat = (ITTListBoxColumn)AddControl(new Guid("efc963db-257d-4ffc-8bb5-7e330278c06d"));
            MaterialBarcode = (ITTTextBoxColumn)AddControl(new Guid("da51ebcc-a282-4214-b0ef-bc2842f988d6"));
            Distrubitontype = (ITTTextBoxColumn)AddControl(new Guid("826a9714-7cb3-475c-9a23-1544dd2f491e"));
            RequestAmountSubStoreStockTransferMat = (ITTTextBoxColumn)AddControl(new Guid("92524071-7062-4ca9-86dc-a3b5ff651384"));
            AmountSubStoreStockTransferMat = (ITTTextBoxColumn)AddControl(new Guid("fb802036-fd7e-4b37-a88f-637e64812791"));
            StockLevelType = (ITTListBoxColumn)AddControl(new Guid("b750e7dc-8c96-40b5-86fe-3f79adc3c7cf"));
            MKYS_TeslimAlan = (ITTTextBox)AddControl(new Guid("1b57989b-485a-4581-a798-02e613746f3f"));
            MKYS_TeslimEden = (ITTTextBox)AddControl(new Guid("b8edbcc4-ec5f-4c2d-a2c8-d01cc67dc76c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("93c9646f-440e-498f-9b84-3eb6a7385308"));
            labelMKYS_TeslimEden = (ITTLabel)AddControl(new Guid("9aaf559a-7d96-4f51-811f-9c2459925527"));
            labelMKYS_TeslimAlan = (ITTLabel)AddControl(new Guid("ab928b04-9c05-49ed-bcb6-cdf2953a1592"));
            TTTeslimAlanButon = (ITTButton)AddControl(new Guid("ed899136-40e9-48ac-9b74-8179dbaa835f"));
            TTTeslimEdenButon = (ITTButton)AddControl(new Guid("3de77492-3c12-4279-86f3-ba2ed2de46b1"));
            base.InitializeControls();
        }

        public BaseSubStoreStockTransferForm() : base("SUBSTORESTOCKTRANSFER", "BaseSubStoreStockTransferForm")
        {
        }

        protected BaseSubStoreStockTransferForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}