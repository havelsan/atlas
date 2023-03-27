
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
    /// Malzeme Aktarım
    /// </summary>
    public partial class MaterialMatchCompleted : TTForm
    {
    /// <summary>
    /// Malzeme Aktarım
    /// </summary>
        protected TTObjectClasses.MaterialMatchAction _MaterialMatchAction
        {
            get { return (TTObjectClasses.MaterialMatchAction)_ttObject; }
        }

        protected ITTLabel labelMainStoreDefinition;
        protected ITTObjectListBox MainStoreDefinition;
        protected ITTGroupBox ttgroupbox2;
        protected ITTObjectListBox MatchMaterial;
        protected ITTLabel ttlabel7;
        protected ITTGrid MStocks;
        protected ITTTextBoxColumn StoreStock;
        protected ITTTextBoxColumn InheldStock;
        protected ITTTextBoxColumn ConsignedStock;
        protected ITTTextBoxColumn TotalInStock;
        protected ITTTextBoxColumn TotalOutStock;
        protected ITTLabel labelMatchMaterial;
        protected ITTGroupBox ttgroupbox1;
        protected ITTObjectListBox WrongMaterial;
        protected ITTLabel labelWrongMaterial;
        protected ITTGrid WStocks;
        protected ITTTextBoxColumn WStoreStock;
        protected ITTTextBoxColumn WInheldStock;
        protected ITTTextBoxColumn WConsignedStock;
        protected ITTTextBoxColumn WTotalInStock;
        protected ITTTextBoxColumn WTotalOutStock;
        protected ITTLabel ttlabel6;
        protected ITTLabel labelStockCard;
        protected ITTObjectListBox StockCard;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            labelMainStoreDefinition = (ITTLabel)AddControl(new Guid("3720f464-b5ae-4db1-9acd-9d978839ffba"));
            MainStoreDefinition = (ITTObjectListBox)AddControl(new Guid("6daf52b8-dade-4813-8c83-8bedfa9fa1fa"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("2eb07718-9870-4e40-99d5-dbc8ea6a7d42"));
            MatchMaterial = (ITTObjectListBox)AddControl(new Guid("cc1783a6-fe53-4c80-8eba-80c5a2cfbec8"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("d01d65cf-9096-47cc-9b75-ab39c98c5f47"));
            MStocks = (ITTGrid)AddControl(new Guid("1c201789-2b68-414d-afac-95dc61329bff"));
            StoreStock = (ITTTextBoxColumn)AddControl(new Guid("0dec6a8a-3aa3-48b0-b39c-444d55a850b3"));
            InheldStock = (ITTTextBoxColumn)AddControl(new Guid("89ee8691-f287-44de-8d1a-c8b2d17728a7"));
            ConsignedStock = (ITTTextBoxColumn)AddControl(new Guid("d3f11970-84e0-421d-849a-8adcbd34c6ff"));
            TotalInStock = (ITTTextBoxColumn)AddControl(new Guid("ed7cba74-8171-48af-a7ab-8344c22c6db8"));
            TotalOutStock = (ITTTextBoxColumn)AddControl(new Guid("43ff16f6-9823-45c1-acf7-8c8dea6f0c07"));
            labelMatchMaterial = (ITTLabel)AddControl(new Guid("6ca9faec-4ea9-423b-be51-17c5f7163612"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("de4e735c-5076-4f69-b949-67c7b146f2a6"));
            WrongMaterial = (ITTObjectListBox)AddControl(new Guid("4c2bb77c-462d-4f7f-b884-4a8326347bc0"));
            labelWrongMaterial = (ITTLabel)AddControl(new Guid("a68e324e-6504-445a-9709-a96b0e1ce069"));
            WStocks = (ITTGrid)AddControl(new Guid("4735a0e8-9e32-4f36-af8e-fc28f46911a5"));
            WStoreStock = (ITTTextBoxColumn)AddControl(new Guid("94c4fc5b-9f83-4e0e-8a38-5383c1191244"));
            WInheldStock = (ITTTextBoxColumn)AddControl(new Guid("37f38866-16d0-465c-b4d5-68e2c1ffa43e"));
            WConsignedStock = (ITTTextBoxColumn)AddControl(new Guid("0726a473-2fb8-408b-b93a-52dc9a055b96"));
            WTotalInStock = (ITTTextBoxColumn)AddControl(new Guid("523edb8c-f47c-47b1-95cb-1b8eb3d901c5"));
            WTotalOutStock = (ITTTextBoxColumn)AddControl(new Guid("47a74f17-ad39-4699-8a51-05e02e5d1147"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("08498c50-6b6d-444f-a42d-da0686240fa2"));
            labelStockCard = (ITTLabel)AddControl(new Guid("971fd794-b287-4513-8801-8fb82d57e602"));
            StockCard = (ITTObjectListBox)AddControl(new Guid("529e40b1-e7e0-4673-9ad8-76df202a48f9"));
            labelID = (ITTLabel)AddControl(new Guid("aefa743f-2305-45ee-9ffc-91952b5ebf5d"));
            ID = (ITTTextBox)AddControl(new Guid("4ff99d8c-1766-4683-9b74-aca1d46d1338"));
            labelActionDate = (ITTLabel)AddControl(new Guid("6275754a-ebf1-4f11-9ea4-b760aef213be"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("5fa28d73-18f2-4502-8912-b46d93c8c798"));
            base.InitializeControls();
        }

        public MaterialMatchCompleted() : base("MATERIALMATCHACTION", "MaterialMatchCompleted")
        {
        }

        protected MaterialMatchCompleted(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}