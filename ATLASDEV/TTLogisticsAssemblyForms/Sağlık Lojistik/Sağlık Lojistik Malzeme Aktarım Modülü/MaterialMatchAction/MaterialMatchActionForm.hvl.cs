
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
    public partial class MaterialMatchActionForm : TTForm
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
            labelMainStoreDefinition = (ITTLabel)AddControl(new Guid("e98b7a6b-0a68-4a20-854f-9490aeba83a2"));
            MainStoreDefinition = (ITTObjectListBox)AddControl(new Guid("59be9417-fb18-4599-892d-6b5f00dec39d"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("c1ebd316-b2b0-44a3-a0ab-e19a0d9aa59b"));
            MatchMaterial = (ITTObjectListBox)AddControl(new Guid("b292c7dc-dfd6-4e9a-ba08-63ca1012ecb0"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("69b971f7-e89b-4017-bd67-dd1bf137061a"));
            MStocks = (ITTGrid)AddControl(new Guid("d307604f-b262-47da-a7f0-aa4708cbb9e7"));
            StoreStock = (ITTTextBoxColumn)AddControl(new Guid("3c39f40b-4507-468b-b785-52e704ab629c"));
            InheldStock = (ITTTextBoxColumn)AddControl(new Guid("947a9f4f-f619-475a-801b-a925ae317a4e"));
            ConsignedStock = (ITTTextBoxColumn)AddControl(new Guid("7d4b68bc-51b8-4b71-8d71-35b5f6653607"));
            TotalInStock = (ITTTextBoxColumn)AddControl(new Guid("2167f427-91cd-4216-9262-4aefa04e2057"));
            TotalOutStock = (ITTTextBoxColumn)AddControl(new Guid("d885bff7-de38-49c7-a0dd-ae5d33c88232"));
            labelMatchMaterial = (ITTLabel)AddControl(new Guid("358e6495-d6f2-4773-996d-ba1caf3d164a"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("9c9e546e-0248-419c-a2fd-7da0cf3ba609"));
            WrongMaterial = (ITTObjectListBox)AddControl(new Guid("43423d7f-be9a-4b2e-ac2e-7dcf7cbfce3e"));
            labelWrongMaterial = (ITTLabel)AddControl(new Guid("557e559f-e190-4f25-b27e-1fb40bb0353b"));
            WStocks = (ITTGrid)AddControl(new Guid("b35d3e22-a9fe-468a-9abd-395dcbd55f95"));
            WStoreStock = (ITTTextBoxColumn)AddControl(new Guid("5e8cd0d2-5101-4061-92b7-f1fa62dc2d19"));
            WInheldStock = (ITTTextBoxColumn)AddControl(new Guid("4c916d6a-7235-4653-a4bd-4b09142fda0a"));
            WConsignedStock = (ITTTextBoxColumn)AddControl(new Guid("75412cd0-6fc2-407f-9252-d03d7bcf5a65"));
            WTotalInStock = (ITTTextBoxColumn)AddControl(new Guid("9da4dc5f-f122-451a-93fd-e53181d57536"));
            WTotalOutStock = (ITTTextBoxColumn)AddControl(new Guid("ae3c3339-d5c1-4154-b9f1-28b3a2c0dafe"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("06b9c6ba-9e8f-4c0d-8a80-13bc3cf657d5"));
            labelStockCard = (ITTLabel)AddControl(new Guid("e28fff3d-0034-44bd-bef6-828409d8bd2a"));
            StockCard = (ITTObjectListBox)AddControl(new Guid("e8ecb7ba-3224-4700-9b8f-cd6c864657fa"));
            labelID = (ITTLabel)AddControl(new Guid("e8773e28-ad85-48ec-86cd-5a1b04a123fa"));
            ID = (ITTTextBox)AddControl(new Guid("57f4c30c-2405-41df-8735-0d8c75167e7b"));
            labelActionDate = (ITTLabel)AddControl(new Guid("37e271bc-0f14-409c-b303-d17be95e4f80"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("c1c0c805-5fd0-417a-b102-103b35dff0a6"));
            base.InitializeControls();
        }

        public MaterialMatchActionForm() : base("MATERIALMATCHACTION", "MaterialMatchActionForm")
        {
        }

        protected MaterialMatchActionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}