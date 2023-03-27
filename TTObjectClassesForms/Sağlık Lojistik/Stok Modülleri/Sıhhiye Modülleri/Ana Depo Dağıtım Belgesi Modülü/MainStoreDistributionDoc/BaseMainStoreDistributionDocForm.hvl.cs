
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
    public partial class BaseMainStoreDistributionDocForm : StockActionBaseForm
    {
    /// <summary>
    /// Ana Depo Dağıtım Belgesi
    /// </summary>
        protected TTObjectClasses.MainStoreDistributionDoc _MainStoreDistributionDoc
        {
            get { return (TTObjectClasses.MainStoreDistributionDoc)_ttObject; }
        }

        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox StockActionID;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelDestinationStore;
        protected ITTObjectListBox DestinationStore;
        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelStockActionID;
        protected ITTTabControl DistributionDocumentMaterialsTabcontrol;
        protected ITTTabPage DistributionDocumentMaterialsTabpage;
        protected ITTGrid MainStoreDistDocDetails;
        protected ITTButtonColumn Detail;
        protected ITTListBoxColumn MaterialDistributionDocumentMaterial;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn SendedAmountDistributionDocumentMaterial;
        protected ITTTextBoxColumn AmountDistributionDocumentMaterial;
        protected ITTTextBoxColumn StoreInheld;
        protected ITTListBoxColumn StockLevelTypeDistributionDocumentMaterial;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTextBoxColumn Price;
        protected ITTEnumComboBoxColumn StatusDistributionDocumentMaterial;
        protected ITTLabel ttlabel2;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox3;
        protected ITTLabel ttlabel3;
        protected ITTButton TTTeslimAlanButon;
        protected ITTButton TTTeslimEdenButon;
        override protected void InitializeControls()
        {
            labelDescription = (ITTLabel)AddControl(new Guid("37edd828-9567-411d-80a1-7f0fcdbcf2f5"));
            Description = (ITTTextBox)AddControl(new Guid("f72ce1e5-212d-43a7-99d9-7def78b05666"));
            StockActionID = (ITTTextBox)AddControl(new Guid("8e3b284f-f764-4522-9426-44aee116ac81"));
            labelStore = (ITTLabel)AddControl(new Guid("e5155108-11bc-4598-af81-36c9e16eb826"));
            Store = (ITTObjectListBox)AddControl(new Guid("08c98035-65d8-4d86-899a-d8e9b9f05e34"));
            labelDestinationStore = (ITTLabel)AddControl(new Guid("7eb8ca91-dfc9-430e-ae1f-147ce33b7d36"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("90b491eb-a5f8-433b-8c82-c02fd609fe93"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("36f0aa09-4bfd-41c4-92ff-02ad27e129a4"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("f4c54459-116c-4072-944b-f879ea7475e6"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("07b63c37-d886-40d4-bcce-bd159bedb6c1"));
            DistributionDocumentMaterialsTabcontrol = (ITTTabControl)AddControl(new Guid("0c428df5-180d-4e8d-a5d4-d3e280550102"));
            DistributionDocumentMaterialsTabpage = (ITTTabPage)AddControl(new Guid("6d3ab42b-201a-45bf-99a2-a9bcab0e837e"));
            MainStoreDistDocDetails = (ITTGrid)AddControl(new Guid("4fdf641c-b3fb-4975-9aa7-1c193ba474e6"));
            Detail = (ITTButtonColumn)AddControl(new Guid("24915c14-0fff-4a58-b867-52ac6274b12b"));
            MaterialDistributionDocumentMaterial = (ITTListBoxColumn)AddControl(new Guid("3cef514c-5120-48c9-8249-984a149d735c"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("d113c94e-1eff-4a2b-acf3-cee15c94365d"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("8f072703-22c8-4641-b7bd-33d60c43b51c"));
            SendedAmountDistributionDocumentMaterial = (ITTTextBoxColumn)AddControl(new Guid("9e91f7ed-167a-430d-b1dc-f208fe2f03a3"));
            AmountDistributionDocumentMaterial = (ITTTextBoxColumn)AddControl(new Guid("972153ce-1915-4f03-ade1-5c19814dd575"));
            StoreInheld = (ITTTextBoxColumn)AddControl(new Guid("01277231-7df5-475a-9fed-a6bdba61c428"));
            StockLevelTypeDistributionDocumentMaterial = (ITTListBoxColumn)AddControl(new Guid("d49f4fa6-87d8-43ee-b48a-148a8ecf72ca"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("8c587157-1929-485d-9beb-d3e065b8c293"));
            Price = (ITTTextBoxColumn)AddControl(new Guid("d998224e-7fac-4261-be59-b584601c79d0"));
            StatusDistributionDocumentMaterial = (ITTEnumComboBoxColumn)AddControl(new Guid("c8dec8c8-ddaa-44af-ae3f-ddafd02afb8c"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("caf946a9-3740-4d07-9d65-5c4a0e3bbcf3"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("6f335336-52e7-415a-a3c7-464890703102"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("ea4081f1-78c0-4db8-9152-4e7f60d227af"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("0c28184a-18db-4e56-8512-65fe138b44e8"));
            TTTeslimAlanButon = (ITTButton)AddControl(new Guid("0d465d7c-bc51-4922-9a9c-49d77e207972"));
            TTTeslimEdenButon = (ITTButton)AddControl(new Guid("29684a08-5421-4165-a91a-fb574b05444b"));
            base.InitializeControls();
        }

        public BaseMainStoreDistributionDocForm() : base("MAINSTOREDISTRIBUTIONDOC", "BaseMainStoreDistributionDocForm")
        {
        }

        protected BaseMainStoreDistributionDocForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}