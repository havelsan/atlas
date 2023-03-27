
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
    /// Dağıtım Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class BasePresDistributionDocumentForm : BaseDistributionDocumentForm
    {
    /// <summary>
    /// Dağıtım Belgesi (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresDistributionDocument _PresDistributionDocument
        {
            get { return (TTObjectClasses.PresDistributionDocument)_ttObject; }
        }

        protected ITTTabPage PresDetailTabPage;
        protected ITTGrid PresDistributionDocumentMaterials;
        protected ITTListBoxColumn MaterialPresDistributionDocMaterial;
        protected ITTListBoxColumn PresStockCard;
        protected ITTTextBoxColumn PresBarcode;
        protected ITTTextBoxColumn PresDistributionType;
        protected ITTTextBoxColumn AcceptedAmountPresDistributionDocMaterial;
        protected ITTTextBoxColumn AmountPresDistributionDocMaterial;
        protected ITTTextBoxColumn PresStoreStock;
        protected ITTTextBoxColumn PresDestinationStoreStock;
        protected ITTListBoxColumn StockLevelTypePresDistributionDocMaterial;
        protected ITTTextBoxColumn PresUnitPrice;
        protected ITTTextBoxColumn PresPrice;
        protected ITTEnumComboBoxColumn StatusPresDistributionDocMaterial;
        override protected void InitializeControls()
        {
            PresDetailTabPage = (ITTTabPage)AddControl(new Guid("608755d3-e7ce-4ed9-984f-7a045c155629"));
            PresDistributionDocumentMaterials = (ITTGrid)AddControl(new Guid("9ea784d2-e31f-47b8-9243-6a163a1234c4"));
            MaterialPresDistributionDocMaterial = (ITTListBoxColumn)AddControl(new Guid("7b49e797-1359-4d38-8d09-864de57683c1"));
            PresStockCard = (ITTListBoxColumn)AddControl(new Guid("90ca6ca7-1493-48d6-b828-ffcf4763b888"));
            PresBarcode = (ITTTextBoxColumn)AddControl(new Guid("340832b2-e3c3-47b2-bfbd-4dc1cb72ce84"));
            PresDistributionType = (ITTTextBoxColumn)AddControl(new Guid("c8df5961-2630-4b5e-a921-df1fa640b58c"));
            AcceptedAmountPresDistributionDocMaterial = (ITTTextBoxColumn)AddControl(new Guid("1c5435eb-d9d8-45c0-9aee-409d2b24132a"));
            AmountPresDistributionDocMaterial = (ITTTextBoxColumn)AddControl(new Guid("47e000e9-14a1-4351-995f-872e60235f91"));
            PresStoreStock = (ITTTextBoxColumn)AddControl(new Guid("bd1f6b07-8211-460d-a5f3-2760879ad8a7"));
            PresDestinationStoreStock = (ITTTextBoxColumn)AddControl(new Guid("5eaddf08-e7a7-426d-afee-9778413dc2e5"));
            StockLevelTypePresDistributionDocMaterial = (ITTListBoxColumn)AddControl(new Guid("10432529-f3c4-4f0a-8652-b7fd7be12322"));
            PresUnitPrice = (ITTTextBoxColumn)AddControl(new Guid("465d3886-1ab7-4115-93f5-fa6d8d10abd0"));
            PresPrice = (ITTTextBoxColumn)AddControl(new Guid("4c3e701f-09eb-4196-8b0d-2722b650f49e"));
            StatusPresDistributionDocMaterial = (ITTEnumComboBoxColumn)AddControl(new Guid("9c7dad8d-01dd-471a-a5c6-c99afc45a44b"));
            base.InitializeControls();
        }

        public BasePresDistributionDocumentForm() : base("PRESDISTRIBUTIONDOCUMENT", "BasePresDistributionDocumentForm")
        {
        }

        protected BasePresDistributionDocumentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}