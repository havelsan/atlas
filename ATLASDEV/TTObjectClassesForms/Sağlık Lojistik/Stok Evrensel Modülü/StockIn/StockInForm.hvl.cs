
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
    /// Stok Giriş
    /// </summary>
    public partial class StockInForm : TTForm
    {
    /// <summary>
    /// Stok Girişlerinin Yapılması İçin kullanılan sınıftır
    /// </summary>
        protected TTObjectClasses.StockIn _StockIn
        {
            get { return (TTObjectClasses.StockIn)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialTabPage;
        protected ITTGrid StockActionInDetails;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTListBoxColumn StockLevelType;
        protected ITTDateTimePickerColumn ExpirationDate;
        protected ITTTextBox SequenceNumber;
        protected ITTTextBox RegistrationNumber;
        protected ITTTextBox StockActionID;
        protected ITTTextBox Description;
        protected ITTLabel labelStockActionID;
        protected ITTObjectListBox Store;
        protected ITTLabel labelDescription;
        protected ITTLabel labelStore;
        protected ITTLabel labelSequenceNumber;
        protected ITTLabel labelRegistrationNumber;
        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker TransactionDate;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("0c4599af-659b-4c79-b136-076d5beb424e"));
            MaterialTabPage = (ITTTabPage)AddControl(new Guid("ecc727dc-e98d-4a24-a4eb-dc279097b96b"));
            StockActionInDetails = (ITTGrid)AddControl(new Guid("8a63f72d-d389-413b-9368-86d4f6a87f36"));
            Material = (ITTListBoxColumn)AddControl(new Guid("73a9b285-ba6d-4473-8904-35aa6f0a03e2"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("df283b78-25bf-4b3a-bbdb-c0ff99cd95aa"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("f72b7bfa-221d-4162-abaf-a055a6434830"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("bfc69806-e96c-4f89-b0e3-41275d7fe7d9"));
            StockLevelType = (ITTListBoxColumn)AddControl(new Guid("68878e06-f476-46f9-bc8e-9fed8c006876"));
            ExpirationDate = (ITTDateTimePickerColumn)AddControl(new Guid("a55504b8-0b1a-4d0c-9f02-6801b8b1c4e1"));
            SequenceNumber = (ITTTextBox)AddControl(new Guid("f5ae36dd-ae51-4e85-a43e-09c928312e7b"));
            RegistrationNumber = (ITTTextBox)AddControl(new Guid("e0ce587f-487f-4f59-860d-be4ad21c85a6"));
            StockActionID = (ITTTextBox)AddControl(new Guid("033ed5dd-12b0-4b99-92e6-c3c01403b034"));
            Description = (ITTTextBox)AddControl(new Guid("af5acef2-9b6d-49dc-874a-f59bd3d390b9"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("baaccc6b-ac74-4cf7-9c90-17a394a39ddc"));
            Store = (ITTObjectListBox)AddControl(new Guid("3140935d-da40-4629-a772-25b08a579c9a"));
            labelDescription = (ITTLabel)AddControl(new Guid("fbf49fcb-05ba-4bbd-8fe1-2b57d652a8af"));
            labelStore = (ITTLabel)AddControl(new Guid("efb579be-98fb-4c85-bd04-35a41af4d2ce"));
            labelSequenceNumber = (ITTLabel)AddControl(new Guid("b401fe38-7234-4973-bb4e-416274c374bf"));
            labelRegistrationNumber = (ITTLabel)AddControl(new Guid("53d74d28-749c-4002-85f3-6d859546d10a"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("708cb62d-9389-4f2c-8d45-8158ef1135ac"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("dfcb8ace-d721-4287-a5c5-90dc8eaa3d30"));
            base.InitializeControls();
        }

        public StockInForm() : base("STOCKIN", "StockInForm")
        {
        }

        protected StockInForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}