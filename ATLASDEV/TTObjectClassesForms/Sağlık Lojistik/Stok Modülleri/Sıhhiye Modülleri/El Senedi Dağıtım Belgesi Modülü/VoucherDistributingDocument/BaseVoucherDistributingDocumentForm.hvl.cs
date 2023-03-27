
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
    /// El Senedi Dağıtım Belgesi
    /// </summary>
    public partial class BaseVoucherDistributingDocumentForm : StockActionBaseForm
    {
    /// <summary>
    /// El Senedi Dağıtım Belgesi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.VoucherDistributingDocument _VoucherDistributingDocument
        {
            get { return (TTObjectClasses.VoucherDistributingDocument)_ttObject; }
        }

        protected ITTObjectListBox Store;
        protected ITTTextBox StockActionID;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelTransactionDate;
        protected ITTObjectListBox DestinationStore;
        protected ITTLabel labelStore;
        protected ITTLabel labelStockActionID;
        protected ITTLabel labelDestinationStore;
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
            Store = (ITTObjectListBox)AddControl(new Guid("fb348544-041a-43f6-aa5c-84f1d0f53636"));
            StockActionID = (ITTTextBox)AddControl(new Guid("fd915ff6-2f3c-4acb-8dae-c7cdce840cb8"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("71cb6cc8-e5ac-4857-8d38-3a4b3915860d"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("b6d4144b-0d23-444e-9256-831e89bc169d"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("5777e451-06e1-4369-9380-ff52dcf3ede2"));
            labelStore = (ITTLabel)AddControl(new Guid("928c020f-b0ce-4ec9-aaf5-f1f8e152ee21"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("d6dc8ec1-d825-4402-8490-e54b3d133998"));
            labelDestinationStore = (ITTLabel)AddControl(new Guid("5404b768-efe1-4fff-8845-a2854c34ffd0"));
            DescriptionAndSignTabControl = (ITTTabControl)AddControl(new Guid("7bb55530-e0a6-4487-88a0-85fd62bb267b"));
            SignTabpage = (ITTTabPage)AddControl(new Guid("7dfe87f1-a9d4-4da9-af82-7130abfcb6ff"));
            StockActionSignDetails = (ITTGrid)AddControl(new Guid("af1a72cb-38f4-4711-8655-c8dba978a69c"));
            SignUserType = (ITTEnumComboBoxColumn)AddControl(new Guid("eb6a12f0-75cb-4833-9c68-9bd7ba02d20d"));
            SignUser = (ITTListBoxColumn)AddControl(new Guid("be4f222d-d19f-4aeb-a102-716df2c0ed05"));
            IsDeputy = (ITTCheckBoxColumn)AddControl(new Guid("a4770a12-85de-4511-b00d-1dcc66dda5bb"));
            DescriptionTabpage = (ITTTabPage)AddControl(new Guid("2a25c7fe-70c9-4f72-9dcf-31e9fd8a82a4"));
            Description = (ITTTextBox)AddControl(new Guid("1c362844-8652-404d-8634-8e98b6bb3ee4"));
            base.InitializeControls();
        }

        public BaseVoucherDistributingDocumentForm() : base("VOUCHERDISTRIBUTINGDOCUMENT", "BaseVoucherDistributingDocumentForm")
        {
        }

        protected BaseVoucherDistributingDocumentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}