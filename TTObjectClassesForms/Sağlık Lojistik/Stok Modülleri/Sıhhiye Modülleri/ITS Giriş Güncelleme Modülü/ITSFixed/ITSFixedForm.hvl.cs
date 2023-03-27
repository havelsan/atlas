
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
    /// ITS Giriş Güncelleme
    /// </summary>
    public partial class ITSFixedForm : StockActionBaseForm
    {
    /// <summary>
    /// ITS Giriş Güncelleme
    /// </summary>
        protected TTObjectClasses.ITSFixed _ITSFixed
        {
            get { return (TTObjectClasses.ITSFixed)_ttObject; }
        }

        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTGrid StockActionOutDetails;
        protected ITTListBoxColumn MaterialStockActionDetailOut;
        protected ITTTextBoxColumn AmountStockActionDetailOut;
        protected ITTEnumComboBoxColumn StatusStockActionDetailOut;
        protected ITTGrid StockActionInDetails;
        protected ITTListBoxColumn MaterialStockActionDetailIn;
        protected ITTTextBoxColumn AmountStockActionDetailIn;
        protected ITTTextBoxColumn UnitPriceStockActionDetailIn;
        protected ITTDateTimePickerColumn ExpirationDateStockActionDetailIn;
        protected ITTTextBoxColumn LotNoStockActionDetailIn;
        protected ITTTextBoxColumn SerialNoStockActionDetailIn;
        protected ITTTextBoxColumn MKYS_StokHareketIDStockActionDetailIn;
        protected ITTEnumComboBoxColumn StatusStockActionDetailIn;
        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelStockActionID;
        protected ITTTextBox StockActionID;
        protected ITTTextBox Description;
        protected ITTLabel labelDescription;
        override protected void InitializeControls()
        {
            labelStore = (ITTLabel)AddControl(new Guid("37edd5d0-9a83-4b78-b7f2-c7136de58acd"));
            Store = (ITTObjectListBox)AddControl(new Guid("0caefe4c-0dfc-439f-a2a8-ab372b985569"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("47c09f48-905a-4d91-8513-0d4551b32cd4"));
            MaterialStockActionDetailOut = (ITTListBoxColumn)AddControl(new Guid("507c4474-32f1-411a-bc99-83d5ca639c31"));
            AmountStockActionDetailOut = (ITTTextBoxColumn)AddControl(new Guid("a858cc5b-4a9c-4546-80a4-8bee97f3ff87"));
            StatusStockActionDetailOut = (ITTEnumComboBoxColumn)AddControl(new Guid("24f685ba-6d9c-4025-b937-b58985b7485e"));
            StockActionInDetails = (ITTGrid)AddControl(new Guid("8fd5f921-f09c-4b89-b2ba-7f9a5504d342"));
            MaterialStockActionDetailIn = (ITTListBoxColumn)AddControl(new Guid("ebe18a7b-4d52-43e4-a584-8d98bab0bb86"));
            AmountStockActionDetailIn = (ITTTextBoxColumn)AddControl(new Guid("dc70b1f2-df80-412a-a020-c3244e3a0acd"));
            UnitPriceStockActionDetailIn = (ITTTextBoxColumn)AddControl(new Guid("ef029acb-0103-4d3f-937a-e3cb086122ea"));
            ExpirationDateStockActionDetailIn = (ITTDateTimePickerColumn)AddControl(new Guid("3631a76b-6a65-40b8-acd9-768370c2ef3d"));
            LotNoStockActionDetailIn = (ITTTextBoxColumn)AddControl(new Guid("c270dcde-eab4-448a-a3a9-9e7829cccd1e"));
            SerialNoStockActionDetailIn = (ITTTextBoxColumn)AddControl(new Guid("b4f84237-5651-4668-9a2a-75b238e50295"));
            MKYS_StokHareketIDStockActionDetailIn = (ITTTextBoxColumn)AddControl(new Guid("e4efb568-564d-4fb6-837e-e9cffd7e6065"));
            StatusStockActionDetailIn = (ITTEnumComboBoxColumn)AddControl(new Guid("1579bb70-a34e-4d08-ae4f-f0892dddda95"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("9106e59f-7ed4-4cee-9593-96db7698fd48"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("8295458e-a454-4d12-b38e-f36685445b87"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("8440670e-d456-4c74-8356-58f045d314a2"));
            StockActionID = (ITTTextBox)AddControl(new Guid("871c5796-3aba-4147-b810-7d90085d4f3c"));
            Description = (ITTTextBox)AddControl(new Guid("e8223278-6818-4fe3-a7fd-5e1b9bdb48b4"));
            labelDescription = (ITTLabel)AddControl(new Guid("2d81d3cb-98f8-4653-a0a9-d9780e2ec279"));
            base.InitializeControls();
        }

        public ITSFixedForm() : base("ITSFIXED", "ITSFixedForm")
        {
        }

        protected ITSFixedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}