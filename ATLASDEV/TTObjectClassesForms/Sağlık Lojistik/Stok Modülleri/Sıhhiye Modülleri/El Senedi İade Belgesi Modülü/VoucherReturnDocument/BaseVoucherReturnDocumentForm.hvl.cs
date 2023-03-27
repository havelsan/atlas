
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
    /// El Senedi İade Belgesi
    /// </summary>
    public partial class BaseVoucherReturnDocumentForm : StockActionBaseForm
    {
    /// <summary>
    /// El Senedi İade Belgesi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.VoucherReturnDocument _VoucherReturnDocument
        {
            get { return (TTObjectClasses.VoucherReturnDocument)_ttObject; }
        }

        protected ITTObjectListBox Store;
        protected ITTLabel labelStockActionID;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelTransactionDate;
        protected ITTTextBox StockActionID;
        protected ITTLabel labelStore;
        protected ITTObjectListBox DestinationStore;
        protected ITTLabel labelDestinationStore;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialTabPage;
        protected ITTGrid StockActionOutDetails;
        protected ITTButtonColumn Detail;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn Existing;
        protected ITTTextBoxColumn RequireAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTListDefComboBoxColumn StockLevelType;
        protected ITTTabControl DescriptionAndSignTabControl;
        protected ITTTabPage SignTabpage;
        protected ITTGrid StockActionSignDetails;
        protected ITTEnumComboBoxColumn SignUserType;
        protected ITTListBoxColumn SignUser;
        protected ITTCheckBoxColumn IsDeputy;
        protected ITTTabPage DescriptionTabpage;
        protected ITTTextBox Description;
        override protected void InitializeControls()
        {
            Store = (ITTObjectListBox)AddControl(new Guid("3ae6c4ea-6a9a-418d-b3ab-b6489dbcfaa3"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("dd9f8c4c-fe65-4dd1-9115-8994aa8335ce"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("1c7d2252-f38d-4fec-9127-92c5983a7cdb"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("7e45f66a-2732-404d-9782-fbdb0492424b"));
            StockActionID = (ITTTextBox)AddControl(new Guid("731ab78b-1505-4271-a9a9-64a9db2fc2b1"));
            labelStore = (ITTLabel)AddControl(new Guid("4d9b70c8-48b4-46c3-8316-f484d6b49a81"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("26d7b8fb-e43f-4141-8061-cd8d0be3df90"));
            labelDestinationStore = (ITTLabel)AddControl(new Guid("5f572ee1-89cf-4077-90be-defdf4841c67"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("04ac9e19-1931-4c86-85a4-1e7f614a435d"));
            MaterialTabPage = (ITTTabPage)AddControl(new Guid("e7da02c9-d67f-4a05-bf76-d54b9328d63b"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("f58cc309-fffe-4361-9374-7d14986fac89"));
            Detail = (ITTButtonColumn)AddControl(new Guid("d38ad49b-dc2b-470b-9637-63e6fc514117"));
            Material = (ITTListBoxColumn)AddControl(new Guid("bc7931b2-8436-4754-a82b-a3b14a08cb17"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("060f313c-750e-4359-92eb-10b1f421e4ab"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("e293e28d-122a-4801-b363-53fbf2476f34"));
            Existing = (ITTTextBoxColumn)AddControl(new Guid("00888857-4559-4156-bcd3-027ad7b7f28e"));
            RequireAmount = (ITTTextBoxColumn)AddControl(new Guid("47b20641-ec76-4e07-ae9c-a32e2f9f6e92"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("47a21f68-e669-46cb-9048-7ce109befcc7"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("7118678f-a5db-4d1a-8de8-ac9120b97512"));
            DescriptionAndSignTabControl = (ITTTabControl)AddControl(new Guid("ef949e3f-97f6-47df-9ecf-b0ca7d0d48e8"));
            SignTabpage = (ITTTabPage)AddControl(new Guid("60dc91f5-408e-437c-9da4-148366f25d4a"));
            StockActionSignDetails = (ITTGrid)AddControl(new Guid("9a813843-c14e-44e2-9601-89e6655dba10"));
            SignUserType = (ITTEnumComboBoxColumn)AddControl(new Guid("50e2c486-4a84-459f-b9cc-ae2dc3e870c8"));
            SignUser = (ITTListBoxColumn)AddControl(new Guid("b2040a26-f1fc-4de3-b8f5-fe587f4c7389"));
            IsDeputy = (ITTCheckBoxColumn)AddControl(new Guid("de84d1de-651b-43ff-8331-d5054a29e82a"));
            DescriptionTabpage = (ITTTabPage)AddControl(new Guid("03a3deb0-ebb7-4ce4-b945-ee314301c603"));
            Description = (ITTTextBox)AddControl(new Guid("0884c6d4-4179-4422-ae91-58c20fc2ef52"));
            base.InitializeControls();
        }

        public BaseVoucherReturnDocumentForm() : base("VOUCHERRETURNDOCUMENT", "BaseVoucherReturnDocumentForm")
        {
        }

        protected BaseVoucherReturnDocumentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}