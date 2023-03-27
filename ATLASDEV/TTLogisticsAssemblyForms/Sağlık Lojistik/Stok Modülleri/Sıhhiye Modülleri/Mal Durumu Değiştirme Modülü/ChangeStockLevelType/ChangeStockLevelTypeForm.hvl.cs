
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
    public partial class ChangeStockLevelTypeForm : StockActionBaseForm
    {
    /// <summary>
    /// İhtiyaç Fazlası İade
    /// </summary>
        protected TTObjectClasses.ChangeStockLevelType _ChangeStockLevelType
        {
            get { return (TTObjectClasses.ChangeStockLevelType)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialTabPanel;
        protected ITTGrid MaterialDetails;
        protected ITTListBoxColumn MaterialStockActionDetail;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn StoreStock;
        protected ITTTextBoxColumn AmountStockActionDetailIn;
        protected ITTListDefComboBoxColumn StockLevelTypeStockActionDetailIn;
        protected ITTTextBox Description;
        protected ITTTextBox StockActionID;
        protected ITTLabel labelBudgetTypeDefinition;
        protected ITTObjectListBox BudgetTypeDefinition;
        protected ITTLabel labelDescription;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelStockActionID;
        protected ITTLabel labelTransactionDate;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("2da6504a-6752-49ab-90b2-a45200282044"));
            MaterialTabPanel = (ITTTabPage)AddControl(new Guid("f2433c95-e309-4a59-a66f-992faa119c72"));
            MaterialDetails = (ITTGrid)AddControl(new Guid("08a21d14-cb57-442c-bd2f-99a6bbd39364"));
            MaterialStockActionDetail = (ITTListBoxColumn)AddControl(new Guid("e8d87d0b-c430-4c7e-b6ca-16b6bdcff2f4"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("62c295ed-911b-417f-bcd7-7d48d9367424"));
            StoreStock = (ITTTextBoxColumn)AddControl(new Guid("b6efbcea-73b6-4bac-81ee-3777fff3a536"));
            AmountStockActionDetailIn = (ITTTextBoxColumn)AddControl(new Guid("77992daa-7d13-4695-9ff4-9b0f90731aa5"));
            StockLevelTypeStockActionDetailIn = (ITTListDefComboBoxColumn)AddControl(new Guid("d738dc9c-66f9-4e7a-8fb0-383c0f063bd7"));
            Description = (ITTTextBox)AddControl(new Guid("d0b6a7ef-6e40-4dbc-9870-d13c7dbc26fa"));
            StockActionID = (ITTTextBox)AddControl(new Guid("75642291-c884-4dc6-94d1-1bd8afed3b49"));
            labelBudgetTypeDefinition = (ITTLabel)AddControl(new Guid("5a173617-aa10-4cc9-9813-46d262b9e77e"));
            BudgetTypeDefinition = (ITTObjectListBox)AddControl(new Guid("088f18a5-5e65-436f-9684-95092ce8ece9"));
            labelDescription = (ITTLabel)AddControl(new Guid("b46af13f-0803-45cf-ad31-897c14aa2d06"));
            labelStore = (ITTLabel)AddControl(new Guid("b6d81a84-5030-4942-af0b-3e1c800d1dbf"));
            Store = (ITTObjectListBox)AddControl(new Guid("9fbca1b6-f211-4e7b-84cf-1373a4f2c45d"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("fd7691b6-9b8d-46dd-9b3a-aef946cd6def"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("7e764ce8-c08e-431c-a99f-d172ec79aafe"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("5545f7f3-5815-41ae-bf3a-d2777a01dc37"));
            base.InitializeControls();
        }

        public ChangeStockLevelTypeForm() : base("CHANGESTOCKLEVELTYPE", "ChangeStockLevelTypeForm")
        {
        }

        protected ChangeStockLevelTypeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}