
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
    public partial class StockFirstTransferForm : StockActionBaseForm
    {
    /// <summary>
    /// İlk Transfer işlemi için kullanılan ana sınıftır
    /// </summary>
        protected TTObjectClasses.StockFirstTransfer _StockFirstTransfer
        {
            get { return (TTObjectClasses.StockFirstTransfer)_ttObject; }
        }

        protected ITTGrid StockActionOutDetails;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Amount;
        protected ITTListBoxColumn StockLevelType;
        protected ITTEnumComboBoxColumn Status;
        protected ITTLabel labelDestinationStore;
        protected ITTObjectListBox DestinationStore;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelStockActionID;
        protected ITTTextBox StockActionID;
        protected ITTTextBox Description;
        protected ITTLabel labelDescription;
        override protected void InitializeControls()
        {
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("26401457-366e-47c7-8666-49e62fcaf413"));
            Material = (ITTListBoxColumn)AddControl(new Guid("294889ae-f817-40e0-b986-ec05784b225e"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("d3c114a4-901b-480d-8c3a-5f53e70a5157"));
            StockLevelType = (ITTListBoxColumn)AddControl(new Guid("a8424959-e93d-4113-9d43-3f7def7c7059"));
            Status = (ITTEnumComboBoxColumn)AddControl(new Guid("b17b842a-f860-417d-91fc-3f127343c22b"));
            labelDestinationStore = (ITTLabel)AddControl(new Guid("68b106f9-1e43-4104-b73f-a0afdd6f9ad1"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("7388f843-91a8-4840-b4ef-6ce311c87a25"));
            labelStore = (ITTLabel)AddControl(new Guid("6b07e585-6b6a-4335-ad5f-6ded78e8168a"));
            Store = (ITTObjectListBox)AddControl(new Guid("f02cff80-3615-41a6-bd6c-980b71c71307"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("f067021a-0d2e-40ae-965b-15e27d61869c"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("17238df6-5377-4bb0-b726-048e1038c5e7"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("a72da232-1828-41f6-9f7b-93783a93fe0e"));
            StockActionID = (ITTTextBox)AddControl(new Guid("7e9b78ae-1441-4f45-a9cd-27ce0fe90d4b"));
            Description = (ITTTextBox)AddControl(new Guid("9311f6eb-fa99-4a1a-a893-f531b8750e4a"));
            labelDescription = (ITTLabel)AddControl(new Guid("32943615-83c5-4802-b3f8-08610ed29881"));
            base.InitializeControls();
        }

        public StockFirstTransferForm() : base("STOCKFIRSTTRANSFER", "StockFirstTransferForm")
        {
        }

        protected StockFirstTransferForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}