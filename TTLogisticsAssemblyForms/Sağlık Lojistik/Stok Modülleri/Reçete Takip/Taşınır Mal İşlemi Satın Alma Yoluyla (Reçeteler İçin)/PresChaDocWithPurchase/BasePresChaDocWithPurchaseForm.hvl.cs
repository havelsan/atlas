
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
    public partial class BasePresChaDocWithPurchaseForm : BaseChattelDocumentWithPurchaseForm
    {
    /// <summary>
    /// Taşınır Mal İşlemi Satın Alma Yoluyla (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresChaDocWithPurchase _PresChaDocWithPurchase
        {
            get { return (TTObjectClasses.PresChaDocWithPurchase)_ttObject; }
        }

        protected ITTTabPage PresChaDocDetailTab;
        protected ITTGrid PresChaDocDetailsWithPurchase;
        protected ITTListBoxColumn MaterialPresChaDocDetWithPurchase;
        protected ITTTextBoxColumn Barcode2;
        protected ITTTextBoxColumn PresDistributionType;
        protected ITTTextBoxColumn AmountPresChaDocDetWithPurchase;
        protected ITTTextBoxColumn UnitPricePresChaDocDetWithPurchase;
        protected ITTTextBoxColumn PresTotalPrice;
        protected ITTTextBoxColumn LotNoPresChaDocDetWithPurchase;
        protected ITTDateTimePickerColumn ExpirationDatePresChaDocDetWithPurchase;
        protected ITTListDefComboBoxColumn StockLevelTypePresChaDocDetWithPurchase;
        override protected void InitializeControls()
        {
            PresChaDocDetailTab = (ITTTabPage)AddControl(new Guid("6f2e4478-32ac-44f6-837d-d571b2d7b35d"));
            PresChaDocDetailsWithPurchase = (ITTGrid)AddControl(new Guid("6a382304-7ae2-4ab7-aed6-7f08cb714fcb"));
            MaterialPresChaDocDetWithPurchase = (ITTListBoxColumn)AddControl(new Guid("067c5d92-8116-460a-84b0-dacaeb24c8f1"));
            Barcode2 = (ITTTextBoxColumn)AddControl(new Guid("853a8db9-8415-4fe5-9c20-f9eddbc30f01"));
            PresDistributionType = (ITTTextBoxColumn)AddControl(new Guid("46497ff2-70e3-4523-87be-aaa0164d18c5"));
            AmountPresChaDocDetWithPurchase = (ITTTextBoxColumn)AddControl(new Guid("6925fb9d-f54a-4895-9c16-de6b163101f7"));
            UnitPricePresChaDocDetWithPurchase = (ITTTextBoxColumn)AddControl(new Guid("15622957-958f-4266-b549-cd40aff5629a"));
            PresTotalPrice = (ITTTextBoxColumn)AddControl(new Guid("3bfcf691-ee38-4db0-a551-e328dc21284f"));
            LotNoPresChaDocDetWithPurchase = (ITTTextBoxColumn)AddControl(new Guid("88a0901a-da30-4fb2-99f4-a02a1f50a76b"));
            ExpirationDatePresChaDocDetWithPurchase = (ITTDateTimePickerColumn)AddControl(new Guid("c0f29f48-4da4-4d14-ac44-b44a4a41b0b1"));
            StockLevelTypePresChaDocDetWithPurchase = (ITTListDefComboBoxColumn)AddControl(new Guid("00884978-c754-441d-a3e2-94156d801e9a"));
            base.InitializeControls();
        }

        public BasePresChaDocWithPurchaseForm() : base("PRESCHADOCWITHPURCHASE", "BasePresChaDocWithPurchaseForm")
        {
        }

        protected BasePresChaDocWithPurchaseForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}