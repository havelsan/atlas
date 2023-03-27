
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
    /// Bağlı Birlik Giriş İşlemi
    /// </summary>
    public partial class DepStoreFirstInForm : StockActionBaseForm
    {
    /// <summary>
    /// Bağlı Birlik İlk Giriş İşlemi
    /// </summary>
        protected TTObjectClasses.DepStoreFirstIn _DepStoreFirstIn
        {
            get { return (TTObjectClasses.DepStoreFirstIn)_ttObject; }
        }

        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTGrid DepStoreFirstInDetails;
        protected ITTTextBoxColumn Barcode;
        protected ITTListBoxColumn MaterialDepStoreFirstInDetail;
        protected ITTDateTimePickerColumn ExpirationDateDepStoreFirstInDetail;
        protected ITTTextBoxColumn UnitPriceDepStoreFirstInDetail;
        protected ITTTextBoxColumn AmountDepStoreFirstInDetail;
        protected ITTListBoxColumn StockLevelTypeDepStoreFirstInDetail;
        protected ITTEnumComboBoxColumn StatusDepStoreFirstInDetail;
        protected ITTLabel labelStockActionID;
        protected ITTTextBox StockActionID;
        protected ITTTextBox Description;
        protected ITTLabel labelDescription;
        override protected void InitializeControls()
        {
            labelTransactionDate = (ITTLabel)AddControl(new Guid("694332b6-0650-42c4-8845-3f60e3773973"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("fa0f0e59-cd00-4620-bda8-c6c2b3c89b19"));
            labelStore = (ITTLabel)AddControl(new Guid("4420f388-7f90-4330-afe0-87a7b8c95ea1"));
            Store = (ITTObjectListBox)AddControl(new Guid("8513e9bc-0a5f-4c75-8ed0-ac61f0dde2b9"));
            DepStoreFirstInDetails = (ITTGrid)AddControl(new Guid("b1b43995-9fa7-4ba9-a4ba-ed1001ffb829"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("330725b0-7678-455b-91dc-92a2697a3eb3"));
            MaterialDepStoreFirstInDetail = (ITTListBoxColumn)AddControl(new Guid("9c5d4331-b0fa-4f01-a919-1787b40ad4ea"));
            ExpirationDateDepStoreFirstInDetail = (ITTDateTimePickerColumn)AddControl(new Guid("dbdcca7c-965a-4a6e-b6cf-abfd11216249"));
            UnitPriceDepStoreFirstInDetail = (ITTTextBoxColumn)AddControl(new Guid("bb11ccac-3881-492c-8bd1-f50f8d330425"));
            AmountDepStoreFirstInDetail = (ITTTextBoxColumn)AddControl(new Guid("4e241a06-cd33-4872-aa52-279c168f62f7"));
            StockLevelTypeDepStoreFirstInDetail = (ITTListBoxColumn)AddControl(new Guid("4fb7948a-4eb4-46a4-b055-6b3306ff9f46"));
            StatusDepStoreFirstInDetail = (ITTEnumComboBoxColumn)AddControl(new Guid("80e4a34c-852f-434e-89b4-7958a093f006"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("3c524e84-7eab-47a3-8d86-01903af08dc5"));
            StockActionID = (ITTTextBox)AddControl(new Guid("bcdae769-6cdc-4f22-b5d4-b6eede50dc7a"));
            Description = (ITTTextBox)AddControl(new Guid("0fb216e5-a208-4f3e-980c-29360c63faa9"));
            labelDescription = (ITTLabel)AddControl(new Guid("ac1c53a4-477e-43a2-9c25-c96416dfab6b"));
            base.InitializeControls();
        }

        public DepStoreFirstInForm() : base("DEPSTOREFIRSTIN", "DepStoreFirstInForm")
        {
        }

        protected DepStoreFirstInForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}