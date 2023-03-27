
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
    /// Ayıklama İşlemi
    /// </summary>
    public partial class BaseShellingProcedureForm : StockActionBaseForm
    {
    /// <summary>
    /// Ayıklama İşlemi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.ShellingProcedure _ShellingProcedure
        {
            get { return (TTObjectClasses.ShellingProcedure)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage OutMaterialTabpage;
        protected ITTGrid ShellingProcedureOutMaterials;
        protected ITTButtonColumn Detail;
        protected ITTListBoxColumn Material;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn Amount;
        protected ITTListDefComboBoxColumn StockLevelType;
        protected ITTTabPage InMaterialTabpage;
        protected ITTGrid ShellingProcedureInMaterials;
        protected ITTListBoxColumn InMaterial;
        protected ITTListBoxColumn InDistributionType;
        protected ITTTextBoxColumn InAmount;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTListDefComboBoxColumn InStockLevelType;
        protected ITTTextBoxColumn OutMaterial;
        protected ITTEnumComboBoxColumn HEKResult;
        protected ITTTextBox StockActionID;
        protected ITTTextBox Description;
        protected ITTLabel labelStore;
        protected ITTLabel labelStockActionID;
        protected ITTObjectListBox Store;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelTransactionDate;
        protected ITTLabel labelDescription;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("ff6f1852-d34d-45d5-aaca-e1e97a017db0"));
            OutMaterialTabpage = (ITTTabPage)AddControl(new Guid("cc8ba090-635e-43be-bcb3-077170d138e5"));
            ShellingProcedureOutMaterials = (ITTGrid)AddControl(new Guid("256e9c0c-61a7-4169-9e78-c3d2cc838411"));
            Detail = (ITTButtonColumn)AddControl(new Guid("52cca01e-2574-4684-9ba7-559cc062b45d"));
            Material = (ITTListBoxColumn)AddControl(new Guid("d2f0d6a0-f32e-4c0b-8d28-4893a37de7d2"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("6d92fee2-505b-4f53-959b-4288f5afb169"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("e7585209-81c3-4cf6-aff4-e0ff8e75c56c"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("0b671c3f-e19c-435d-95e9-a3f0a2f66113"));
            InMaterialTabpage = (ITTTabPage)AddControl(new Guid("26e93872-c625-468a-80f2-8d796543c889"));
            ShellingProcedureInMaterials = (ITTGrid)AddControl(new Guid("4d1b0f3f-9eb8-42e0-b0df-ad161268b49e"));
            InMaterial = (ITTListBoxColumn)AddControl(new Guid("a195fa41-1fa3-40f6-99f9-b4b74fba024a"));
            InDistributionType = (ITTListBoxColumn)AddControl(new Guid("9745f6eb-73c9-478d-8ec9-f18d329b573b"));
            InAmount = (ITTTextBoxColumn)AddControl(new Guid("b5cf2409-3feb-423d-b870-3c413e8947b3"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("5d888bf7-6e8b-4f79-9eaa-8d591488cbd6"));
            InStockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("9c643f07-8d63-48c2-9161-bbbc6a24e6a8"));
            OutMaterial = (ITTTextBoxColumn)AddControl(new Guid("317aab1c-fd4d-471f-8176-addf592357b2"));
            HEKResult = (ITTEnumComboBoxColumn)AddControl(new Guid("9403c713-9388-466e-b2f2-b90f388ddc9c"));
            StockActionID = (ITTTextBox)AddControl(new Guid("a2f163ae-7fcb-476e-8bd9-394906191d49"));
            Description = (ITTTextBox)AddControl(new Guid("e38e42fb-64e2-4453-92b7-0d3a9a641dde"));
            labelStore = (ITTLabel)AddControl(new Guid("3b86aa04-006d-4b5e-b3ab-9e55a7156d2d"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("d300ea99-2d7a-4314-b8cc-3346048a7e3c"));
            Store = (ITTObjectListBox)AddControl(new Guid("9c6f2804-30b7-49e9-8eac-593bab8d1aef"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("96498de8-7793-4089-8645-362cb4960395"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("e5057e26-756c-4515-b9ef-a6060b790bb2"));
            labelDescription = (ITTLabel)AddControl(new Guid("b05a32fd-ac1e-41ac-8b5c-298e49a156d1"));
            base.InitializeControls();
        }

        public BaseShellingProcedureForm() : base("SHELLINGPROCEDURE", "BaseShellingProcedureForm")
        {
        }

        protected BaseShellingProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}