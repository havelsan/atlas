
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
    /// Sayım Emri Belgesi
    /// </summary>
    public partial class BaseCensusOrderForm : StockActionBaseForm
    {
    /// <summary>
    /// Sayım Emri için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.CensusOrder _CensusOrder
        {
            get { return (TTObjectClasses.CensusOrder)_ttObject; }
        }

        protected ITTDateTimePicker TransactionDate;
        protected ITTEnumComboBox CensusOrderType;
        protected ITTLabel labelCensusOrderType;
        protected ITTLabel labelTransactionDate;
        protected ITTLabel labelStore;
        protected ITTLabel labelStockActionID;
        protected ITTTextBox StockActionID;
        protected ITTObjectListBox Store;
        protected ITTObjectListBox CardDrawer;
        protected ITTLabel labelCardDrawer;
        protected ITTTabControl DescriptionAndSignTabControl;
        protected ITTTabPage StockCardClassTabpage;
        protected ITTGrid CensusOrderMainClasses;
        protected ITTListBoxColumn StockCardClass;
        protected ITTTextBoxColumn CardCount;
        protected ITTLabel labelTotalCardCount;
        protected ITTTextBox TotalCardCount;
        protected ITTTabPage SignTabpage;
        protected ITTGrid StockActionSignDetails;
        protected ITTEnumComboBoxColumn SignUserType;
        protected ITTListBoxColumn SignUser;
        protected ITTTabPage DescriptionTabpage;
        protected ITTTextBox Description;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage MaterialTabPage;
        protected ITTGrid CensusOrderDetails;
        protected ITTTextBoxColumn OrderSequenceNumber;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTListBoxColumn StockCard;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn NewInheld;
        protected ITTTextBoxColumn UsedInheld;
        protected ITTTextBoxColumn Consigned;
        protected ITTTextBoxColumn CensusNewInheld;
        protected ITTTextBoxColumn CensusUsedInheld;
        protected ITTTextBoxColumn DescriptionCensusOrderDetail;
        override protected void InitializeControls()
        {
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("409f87b7-fb26-4bfc-a1a6-0d8c52e070cc"));
            CensusOrderType = (ITTEnumComboBox)AddControl(new Guid("79a43511-1ddd-4e73-b1bb-142ab172ca71"));
            labelCensusOrderType = (ITTLabel)AddControl(new Guid("7866e073-1e94-45e9-82ce-3012c3e09fe0"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("4775cb5c-e17e-4efb-9309-7bb27970e028"));
            labelStore = (ITTLabel)AddControl(new Guid("c214e622-cc2c-474c-a388-afc0f48ce8ff"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("d8787cd5-1499-4fdd-9bf0-851dc0ad5f11"));
            StockActionID = (ITTTextBox)AddControl(new Guid("175090a4-e61b-4677-8de5-6d5837497d88"));
            Store = (ITTObjectListBox)AddControl(new Guid("ffba4a03-e616-447c-9c29-6846f254ebe5"));
            CardDrawer = (ITTObjectListBox)AddControl(new Guid("5e2dac72-d8e5-40f5-af97-7b34a1204496"));
            labelCardDrawer = (ITTLabel)AddControl(new Guid("c8d9dd40-d7bd-4828-9bd4-954451ce79d9"));
            DescriptionAndSignTabControl = (ITTTabControl)AddControl(new Guid("868de343-603d-490b-b894-0aad2dd498ed"));
            StockCardClassTabpage = (ITTTabPage)AddControl(new Guid("f5df7991-9edd-4f50-b198-ce8b8b6ff943"));
            CensusOrderMainClasses = (ITTGrid)AddControl(new Guid("8d8c1f58-5143-4c8e-97a4-13e8b16325d7"));
            StockCardClass = (ITTListBoxColumn)AddControl(new Guid("58fc7480-c69f-4434-a854-16eb2a2bcb53"));
            CardCount = (ITTTextBoxColumn)AddControl(new Guid("9cc3bd39-7bcb-43a7-acc7-a8fb98ee6af7"));
            labelTotalCardCount = (ITTLabel)AddControl(new Guid("e7f8d2ab-a755-4ba8-a873-4789c1d1e99b"));
            TotalCardCount = (ITTTextBox)AddControl(new Guid("0df20737-3438-4d8e-9456-96cb6c3ff24f"));
            SignTabpage = (ITTTabPage)AddControl(new Guid("6bf6f77a-0c75-424b-b97c-e7ced5f1708c"));
            StockActionSignDetails = (ITTGrid)AddControl(new Guid("5de986ae-1d8b-429d-967a-fa369abdcccf"));
            SignUserType = (ITTEnumComboBoxColumn)AddControl(new Guid("1f53697e-2007-433a-a4ba-fcf644f8a064"));
            SignUser = (ITTListBoxColumn)AddControl(new Guid("ae2007a9-4513-4928-bf69-74d1adebfdb2"));
            DescriptionTabpage = (ITTTabPage)AddControl(new Guid("fd0e663b-1593-49f2-a8b7-d3e20e9f7def"));
            Description = (ITTTextBox)AddControl(new Guid("ccf75657-ce89-451f-aeff-9f333a28c3c2"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("b909337d-77b8-41a3-8e8a-8b3a7f59317c"));
            MaterialTabPage = (ITTTabPage)AddControl(new Guid("6aa4e718-0aab-48bd-8b56-40825a6bbe81"));
            CensusOrderDetails = (ITTGrid)AddControl(new Guid("51d4cafe-d6ee-4431-a67f-3bf4b99f96a4"));
            OrderSequenceNumber = (ITTTextBoxColumn)AddControl(new Guid("2a3d9611-561a-4baf-8a80-5f23e08e5f12"));
            Material = (ITTListBoxColumn)AddControl(new Guid("99d90e05-b853-456f-9278-b8d903f40d40"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("46b65337-a639-4cc0-a326-6877802a687c"));
            StockCard = (ITTListBoxColumn)AddControl(new Guid("21c56426-d7e5-4b64-85af-c229a259cbc2"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("7a033b29-5134-4025-8fdd-bb30f84e9cd4"));
            NewInheld = (ITTTextBoxColumn)AddControl(new Guid("0bbd3a16-baba-4f0c-8d58-4837101a86d1"));
            UsedInheld = (ITTTextBoxColumn)AddControl(new Guid("dcf3b695-d463-4834-9136-380664f24067"));
            Consigned = (ITTTextBoxColumn)AddControl(new Guid("9c118ec8-0110-4fbd-a288-cc2fce603fc2"));
            CensusNewInheld = (ITTTextBoxColumn)AddControl(new Guid("8b470151-a59d-4fe4-bb8b-729b115e658d"));
            CensusUsedInheld = (ITTTextBoxColumn)AddControl(new Guid("bb2c7357-ba75-410e-8d32-408427659f90"));
            DescriptionCensusOrderDetail = (ITTTextBoxColumn)AddControl(new Guid("8e9767b5-32cc-4dac-9dcc-6e8bfb6087ff"));
            base.InitializeControls();
        }

        public BaseCensusOrderForm() : base("CENSUSORDER", "BaseCensusOrderForm")
        {
        }

        protected BaseCensusOrderForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}