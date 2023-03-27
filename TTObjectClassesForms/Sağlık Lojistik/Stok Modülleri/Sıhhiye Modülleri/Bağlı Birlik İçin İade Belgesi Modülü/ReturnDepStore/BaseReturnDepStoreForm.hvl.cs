
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
    /// Bağlı Birlik İçin İade Belgesi
    /// </summary>
    public partial class BaseReturnDepStoreForm : StockActionBaseForm
    {
    /// <summary>
    /// Bağlı Birlik İçin İade Belgesi
    /// </summary>
        protected TTObjectClasses.ReturnDepStore _ReturnDepStore
        {
            get { return (TTObjectClasses.ReturnDepStore)_ttObject; }
        }

        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelAccountancyAccountingTerm;
        protected ITTObjectListBox AccountancyAccountingTerm;
        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelStockActionID;
        protected ITTTextBox StockActionID;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialTabPage;
        protected ITTGrid StockActionOutDetails;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
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
            labelStore = (ITTLabel)AddControl(new Guid("4290998a-70e6-4bad-bf7a-dba01666bbbb"));
            Store = (ITTObjectListBox)AddControl(new Guid("dacb0b1d-ea6f-4090-936d-c7143d3151dd"));
            labelAccountancyAccountingTerm = (ITTLabel)AddControl(new Guid("6df1c470-4be1-4b21-9733-46ddf91a50b0"));
            AccountancyAccountingTerm = (ITTObjectListBox)AddControl(new Guid("0e881374-2d23-42fc-b5bc-be0e02f69e14"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("6d86f91a-c5ac-40e9-86a8-71e86ea6f0f6"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("ed95f9f4-f830-4a77-80ca-34d1c1c3db16"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("3766cdc2-a75b-4a39-a2fc-775f83b4dd3e"));
            StockActionID = (ITTTextBox)AddControl(new Guid("b633b820-864e-43c8-ad80-5e5f4232edd9"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("dd8791bf-c07a-4311-b521-ade7ae4fd0e5"));
            MaterialTabPage = (ITTTabPage)AddControl(new Guid("48bb8e53-b877-4703-a72a-ca02c29e39c1"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("9e20d628-364a-456a-87b9-6fe1431259b1"));
            Material = (ITTListBoxColumn)AddControl(new Guid("372acfdf-3972-4295-8049-5a476a243381"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("b17b089c-d315-4ae0-948b-aa29b8bf9cf3"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("4223706c-150e-4bce-a11e-5378df5d148b"));
            Existing = (ITTTextBoxColumn)AddControl(new Guid("c5d76fe2-7e64-405c-80fc-004afe03a538"));
            RequireAmount = (ITTTextBoxColumn)AddControl(new Guid("9b0d39bf-1a65-4d87-87d5-bb90dc85671a"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("030894f6-2d21-4e27-892a-282addcdae92"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("2e310d8f-e734-4dc7-a933-da4a546b5df0"));
            DescriptionAndSignTabControl = (ITTTabControl)AddControl(new Guid("358da696-e8fc-4781-b248-48b4fedcb522"));
            SignTabpage = (ITTTabPage)AddControl(new Guid("38d92ba2-029e-4923-a8ad-b14beb19f6fe"));
            StockActionSignDetails = (ITTGrid)AddControl(new Guid("f3140405-b1da-41f4-9b2d-5b1ba99669f6"));
            SignUserType = (ITTEnumComboBoxColumn)AddControl(new Guid("5aab2731-278c-409b-8664-845f09440cca"));
            SignUser = (ITTListBoxColumn)AddControl(new Guid("8a2d41e3-ad82-4ad4-bfbe-9db362d6d315"));
            IsDeputy = (ITTCheckBoxColumn)AddControl(new Guid("d0980282-014a-4e41-b52a-304b4d7eb77a"));
            DescriptionTabpage = (ITTTabPage)AddControl(new Guid("178d933c-f4dd-4c39-a115-6fb16b3fbb17"));
            Description = (ITTTextBox)AddControl(new Guid("13ac207d-b1b7-43f6-90f7-d9b918093b8c"));
            base.InitializeControls();
        }

        public BaseReturnDepStoreForm() : base("RETURNDEPSTORE", "BaseReturnDepStoreForm")
        {
        }

        protected BaseReturnDepStoreForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}