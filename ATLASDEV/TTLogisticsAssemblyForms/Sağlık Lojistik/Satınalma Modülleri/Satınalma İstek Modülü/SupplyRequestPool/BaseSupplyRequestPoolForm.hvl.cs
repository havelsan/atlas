
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
    public partial class BaseSupplyRequestPoolForm : StockActionBaseForm
    {
    /// <summary>
    /// Satınalma Talep Havuzu
    /// </summary>
        protected TTObjectClasses.SupplyRequestPool _SupplyRequestPool
        {
            get { return (TTObjectClasses.SupplyRequestPool)_ttObject; }
        }

        protected ITTLabel labelDateOfSupply;
        protected ITTDateTimePicker DateOfSupply;
        protected ITTCheckBox IsImmediate;
        protected ITTLabel labelRequestType;
        protected ITTEnumComboBox RequestType;
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid SupplyRequestPoolDetails;
        protected ITTButtonColumn SupplyRequestPoolDetailBtn;
        protected ITTListBoxColumn BaseMaterialGroupSupplyRequestPoolDetail;
        protected ITTListBoxColumn DistributionTypeSupplyRequestPoolDetail;
        protected ITTTextBoxColumn TotalRequestAmountSupplyRequestPoolDetail;
        protected ITTTextBoxColumn AmountSupplyRequestPoolDetail;
        protected ITTTextBoxColumn PurchaseAmountSupplyRequestPoolDetail;
        protected ITTTextBoxColumn ExcessAmountSupplyRequestPoolDetail;
        protected ITTButtonColumn MKYSExcessQueryBtn;
        protected ITTEnumComboBoxColumn SupplyRqstPlDetStatusSupplyRequestPoolDetail;
        protected ITTTextBoxColumn DetailDescriptionSupplyRequestPoolDetail;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelStockActionID;
        protected ITTTextBox StockActionID;
        protected ITTTextBox Description;
        protected ITTLabel labelDescription;
        protected ITTObjectListBox SignUser;
        protected ITTLabel labelSignUser;
        override protected void InitializeControls()
        {
            labelDateOfSupply = (ITTLabel)AddControl(new Guid("52d607e5-0309-4f94-9d94-671329800e31"));
            DateOfSupply = (ITTDateTimePicker)AddControl(new Guid("78b6218b-3bde-4658-8750-d4d2a7a78cc3"));
            IsImmediate = (ITTCheckBox)AddControl(new Guid("88d18140-6440-4ff9-8d08-2440a5788f63"));
            labelRequestType = (ITTLabel)AddControl(new Guid("0ad735c9-55c1-446b-8aa5-d197192c6c02"));
            RequestType = (ITTEnumComboBox)AddControl(new Guid("669c0816-50b4-4d9d-af0e-621f69461234"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("7a0649ce-2728-423e-b788-d2c302860e79"));
            SupplyRequestPoolDetails = (ITTGrid)AddControl(new Guid("467c6ac4-be95-4211-ab6f-7d29d4e779e5"));
            SupplyRequestPoolDetailBtn = (ITTButtonColumn)AddControl(new Guid("b026f3d7-a1f9-4135-bc94-2840e4ef790c"));
            BaseMaterialGroupSupplyRequestPoolDetail = (ITTListBoxColumn)AddControl(new Guid("9bcf3e71-60e7-450a-9bb5-54211db1d0f0"));
            DistributionTypeSupplyRequestPoolDetail = (ITTListBoxColumn)AddControl(new Guid("996ec596-ff33-481b-8c0e-d19d9791cd24"));
            TotalRequestAmountSupplyRequestPoolDetail = (ITTTextBoxColumn)AddControl(new Guid("847192bb-2138-47e6-ba35-ebbcfd908c8a"));
            AmountSupplyRequestPoolDetail = (ITTTextBoxColumn)AddControl(new Guid("b049d252-b892-4b3c-8e94-c617cf635ee5"));
            PurchaseAmountSupplyRequestPoolDetail = (ITTTextBoxColumn)AddControl(new Guid("814e6e40-6b78-4fc1-8ce8-3775d4006865"));
            ExcessAmountSupplyRequestPoolDetail = (ITTTextBoxColumn)AddControl(new Guid("c949d23a-26d8-400b-b44c-9ed51e5d39d4"));
            MKYSExcessQueryBtn = (ITTButtonColumn)AddControl(new Guid("9e0560fb-cd70-495d-9d29-2892b79e0461"));
            SupplyRqstPlDetStatusSupplyRequestPoolDetail = (ITTEnumComboBoxColumn)AddControl(new Guid("7c233fd0-00fa-4a5f-ab97-6f89fb35ba36"));
            DetailDescriptionSupplyRequestPoolDetail = (ITTTextBoxColumn)AddControl(new Guid("ea06dd5f-bb3a-48c8-ba43-72d5757c84e0"));
            labelStore = (ITTLabel)AddControl(new Guid("b394a501-6a37-401a-92a1-d1add54ee6a6"));
            Store = (ITTObjectListBox)AddControl(new Guid("d6801db1-ce35-487f-b6be-d07bff53077e"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("2fab57e7-90fd-4e9d-929b-91d22003ae9b"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("f4c71b96-9ba1-4030-bd4d-67dd6bcdc7c8"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("597fc50a-03fd-46b9-a884-2efa2dd06954"));
            StockActionID = (ITTTextBox)AddControl(new Guid("d3992bf7-e6dc-462b-b751-9970e680af92"));
            Description = (ITTTextBox)AddControl(new Guid("d25219f3-2bb0-42b2-bce0-e8e54327a0bd"));
            labelDescription = (ITTLabel)AddControl(new Guid("1bf339d6-1700-44c2-a5d7-aca4df960f90"));
            SignUser = (ITTObjectListBox)AddControl(new Guid("b96e5b56-94fa-4450-8997-b644fd745262"));
            labelSignUser = (ITTLabel)AddControl(new Guid("c307ca61-3455-4850-a51d-e7ee0b84e859"));
            base.InitializeControls();
        }

        public BaseSupplyRequestPoolForm() : base("SUPPLYREQUESTPOOL", "BaseSupplyRequestPoolForm")
        {
        }

        protected BaseSupplyRequestPoolForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}