
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
    /// Depodan Sarf
    /// </summary>
    public partial class BaseSubStoreConsumptionActionForm : StockActionBaseForm
    {
    /// <summary>
    /// Depodan Sarf İşlemi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.SubStoreConsumptionAction _SubStoreConsumptionAction
        {
            get { return (TTObjectClasses.SubStoreConsumptionAction)_ttObject; }
        }

        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker TransactionDate;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialOutTabPage;
        protected ITTGrid SubStoreConsumptionActionDetails;
        protected ITTButtonColumn Detail;
        protected ITTTextBoxColumn Barcode;
        protected ITTListBoxColumn Material;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn AmountSubStoreConsumptionDetail;
        protected ITTTextBoxColumn Existing;
        protected ITTListBoxColumn StockLevelTypeSubStoreConsumptionDetail;
        protected ITTTextBox StockActionID;
        protected ITTTextBox Description;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelStockActionID;
        protected ITTLabel labelDescription;
        override protected void InitializeControls()
        {
            labelTransactionDate = (ITTLabel)AddControl(new Guid("935a2b84-5002-46cf-bd23-368bf739c6fd"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("ac36300d-a2fc-4e2a-95e8-9d3155b742e3"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("10924194-9703-4b55-a312-c1d257abbb78"));
            MaterialOutTabPage = (ITTTabPage)AddControl(new Guid("a64c9f56-9cbd-470e-aa4a-41ad5408e687"));
            SubStoreConsumptionActionDetails = (ITTGrid)AddControl(new Guid("b47fbc31-488a-40d6-8463-668da84e9edc"));
            Detail = (ITTButtonColumn)AddControl(new Guid("907fe5f7-2913-4a30-ac0d-8a44318af2d7"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("84c88a06-6b07-474b-b4b4-4f56e5bfd523"));
            Material = (ITTListBoxColumn)AddControl(new Guid("205eb8bf-8b52-4a30-b1b9-751ff5364508"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("2fda09ac-bff3-44ea-887b-19acb9543fcc"));
            AmountSubStoreConsumptionDetail = (ITTTextBoxColumn)AddControl(new Guid("82a660d8-d448-47ce-93d5-266351a8af78"));
            Existing = (ITTTextBoxColumn)AddControl(new Guid("296bc4c4-9454-4b5c-8b0b-1feaba8d8b14"));
            StockLevelTypeSubStoreConsumptionDetail = (ITTListBoxColumn)AddControl(new Guid("1b3fbd3a-8328-477c-aadc-4da3520eed49"));
            StockActionID = (ITTTextBox)AddControl(new Guid("ab648280-11f0-4a5b-b9a6-716613a10323"));
            Description = (ITTTextBox)AddControl(new Guid("393832bb-9dcc-4ca2-b88f-72280612ac9a"));
            labelStore = (ITTLabel)AddControl(new Guid("8d247eb0-0101-4207-9094-05f0f4c887ee"));
            Store = (ITTObjectListBox)AddControl(new Guid("00cc8eeb-bffc-459b-abc5-331316be96e8"));
            labelActionDate = (ITTLabel)AddControl(new Guid("8ad62400-cd6a-43fc-ae67-29a1d2f402e3"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("2b895f55-6bfc-45b4-a857-46c7919a1579"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("6aeeb33b-a1f7-4f4b-858d-78a78463ebbb"));
            labelDescription = (ITTLabel)AddControl(new Guid("c04499c9-2fa6-4ee2-88eb-822cbfb5aca8"));
            base.InitializeControls();
        }

        public BaseSubStoreConsumptionActionForm() : base("SUBSTORECONSUMPTIONACTION", "BaseSubStoreConsumptionActionForm")
        {
        }

        protected BaseSubStoreConsumptionActionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}