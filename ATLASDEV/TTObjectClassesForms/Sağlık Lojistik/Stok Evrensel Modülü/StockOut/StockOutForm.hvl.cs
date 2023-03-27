
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
    /// Stok Çıkış
    /// </summary>
    public partial class StockOutForm : TTForm
    {
    /// <summary>
    /// Stok Çıkışlarının Yapılması İçin kullanılan sınıftır
    /// </summary>
        protected TTObjectClasses.StockOut _StockOut
        {
            get { return (TTObjectClasses.StockOut)_ttObject; }
        }

        protected ITTTextBox Description;
        protected ITTTextBox StockActionID;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid StockActionOutDetails;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Amount;
        protected ITTListBoxColumn StockLevelType;
        protected ITTEnumComboBoxColumn Status;
        protected ITTLabel labelDescription;
        protected ITTLabel labelStockActionID;
        protected ITTObjectListBox Store;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelTransactionDate;
        protected ITTLabel labelStore;
        override protected void InitializeControls()
        {
            Description = (ITTTextBox)AddControl(new Guid("a299e38e-9ed4-4f09-91dd-0a4f2b3bb3fb"));
            StockActionID = (ITTTextBox)AddControl(new Guid("0bae2c5b-d0f3-4a12-a453-0ee951554c30"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("52827c5a-2bb2-485e-9bef-1f974efb2bb7"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("589ff859-c099-4104-b89a-99ad050debb1"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("ef7bfadc-9031-4018-843b-9520438248a2"));
            Material = (ITTListBoxColumn)AddControl(new Guid("cab2e5c3-bc11-4143-9676-8c8bcaf38934"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("f09b47a0-8535-4c1e-b4e3-c0f83fb72d47"));
            StockLevelType = (ITTListBoxColumn)AddControl(new Guid("4b74174f-3a9d-4e8d-be30-e805102b5491"));
            Status = (ITTEnumComboBoxColumn)AddControl(new Guid("c7be50ec-d064-4d69-8331-99026948c72e"));
            labelDescription = (ITTLabel)AddControl(new Guid("44e11ed2-4b25-4138-9f5a-20367f431bbe"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("ddb8e911-f84f-4f6d-9c26-312a4647aaa3"));
            Store = (ITTObjectListBox)AddControl(new Guid("d2dd8d33-94f0-4eb3-a1ce-34cce79adff0"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("785b4788-3f0f-492f-80ae-3acbdd8694c1"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("793e03fd-9a76-4a1b-8deb-732d6f553810"));
            labelStore = (ITTLabel)AddControl(new Guid("d3bafdf4-2ced-4311-8a9e-87aabb5c40e8"));
            base.InitializeControls();
        }

        public StockOutForm() : base("STOCKOUT", "StockOutForm")
        {
        }

        protected StockOutForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}