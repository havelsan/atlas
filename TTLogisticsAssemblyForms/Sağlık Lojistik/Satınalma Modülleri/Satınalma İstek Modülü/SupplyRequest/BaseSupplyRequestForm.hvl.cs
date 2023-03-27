
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
    /// Tedarik Talep Form
    /// </summary>
    public partial class BaseSupplyRequest : StockActionBaseForm
    {
    /// <summary>
    /// Satınalma Talebi
    /// </summary>
        protected TTObjectClasses.SupplyRequest _SupplyRequest
        {
            get { return (TTObjectClasses.SupplyRequest)_ttObject; }
        }

        protected ITTCheckBox IsImmediate;
        protected ITTLabel labelSignUser;
        protected ITTObjectListBox SignUser;
        protected ITTEnumComboBox RequestType;
        protected ITTLabel labelDestinationStore;
        protected ITTObjectListBox DestinationStore;
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid SupplyRequestDetails;
        protected ITTListBoxColumn MaterialSupplyRequestDetail;
        protected ITTListBoxColumn PurchaseGroupSupplyRequestDetail;
        protected ITTListBoxColumn DistributionTypeSupplyRequestDetail;
        protected ITTTextBoxColumn RequestAmountSupplyRequestDetail;
        protected ITTTextBoxColumn PurchaseAmountSupplyRequestDetail;
        protected ITTEnumComboBoxColumn SupplyRequestStatusSupplyRequestDetail;
        protected ITTTextBoxColumn DetailDescriptionSupplyRequestDetail;
        protected ITTButtonColumn MKYSExcessQueryBtn;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelStockActionID;
        protected ITTTextBox StockActionID;
        protected ITTTextBox Description;
        protected ITTLabel labelDescription;
        protected ITTLabel labelRequestType;
        override protected void InitializeControls()
        {
            IsImmediate = (ITTCheckBox)AddControl(new Guid("dea4735c-b678-4411-8cab-8a10ef1e150b"));
            labelSignUser = (ITTLabel)AddControl(new Guid("4f800b28-c700-485f-9286-b3fad8c7ce8f"));
            SignUser = (ITTObjectListBox)AddControl(new Guid("9bdeeb78-b12f-448f-8e47-6180f526bb39"));
            RequestType = (ITTEnumComboBox)AddControl(new Guid("0a598d2a-a151-493e-819c-31593bb51260"));
            labelDestinationStore = (ITTLabel)AddControl(new Guid("d9e15500-de22-41bf-a906-1b701de88c84"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("3e410de9-e779-4f40-9e1d-9dbbc1df1766"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("545b3f9e-a420-4f4f-8967-1832e61861f6"));
            SupplyRequestDetails = (ITTGrid)AddControl(new Guid("29023ddc-e4bf-48b6-bdff-b148d610ebb1"));
            MaterialSupplyRequestDetail = (ITTListBoxColumn)AddControl(new Guid("4478cc8f-db19-4118-945b-7489bc1b36a3"));
            PurchaseGroupSupplyRequestDetail = (ITTListBoxColumn)AddControl(new Guid("2f322697-e2d1-455b-a5aa-5cb53837379d"));
            DistributionTypeSupplyRequestDetail = (ITTListBoxColumn)AddControl(new Guid("dd507bc9-51a6-41b2-a046-e1e0bad6bc63"));
            RequestAmountSupplyRequestDetail = (ITTTextBoxColumn)AddControl(new Guid("1ff658e9-e445-4415-a028-e2922b179e8c"));
            PurchaseAmountSupplyRequestDetail = (ITTTextBoxColumn)AddControl(new Guid("f976ed06-7aaf-4453-b8cb-e113aa82cd3d"));
            SupplyRequestStatusSupplyRequestDetail = (ITTEnumComboBoxColumn)AddControl(new Guid("4eea9185-8b07-4ce3-917d-cee0e506c0d9"));
            DetailDescriptionSupplyRequestDetail = (ITTTextBoxColumn)AddControl(new Guid("37065a6a-ded2-4fea-b92c-0a0411288d71"));
            MKYSExcessQueryBtn = (ITTButtonColumn)AddControl(new Guid("4ec0576e-7a38-4562-9de6-26864bc9559c"));
            labelStore = (ITTLabel)AddControl(new Guid("a0a3c88c-1f21-488a-88ca-417ea86aed73"));
            Store = (ITTObjectListBox)AddControl(new Guid("4aa535bc-45d3-4078-a324-058acb2865a8"));
            labelActionDate = (ITTLabel)AddControl(new Guid("a2030a68-cbbc-4ce5-bc42-7b4b49afad0f"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("e3219840-3d1b-4318-8e14-733f78653496"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("173009d4-e5e4-413b-a2e9-629ba1a4df89"));
            StockActionID = (ITTTextBox)AddControl(new Guid("94de9a97-0c42-4f52-a548-34bf0622753f"));
            Description = (ITTTextBox)AddControl(new Guid("22a5198a-359e-4acf-9b63-299970042929"));
            labelDescription = (ITTLabel)AddControl(new Guid("dd69d9fb-402e-426c-ae79-43d81ff47988"));
            labelRequestType = (ITTLabel)AddControl(new Guid("273e6a25-271c-409c-a164-2476cfdd073d"));
            base.InitializeControls();
        }

        public BaseSupplyRequest() : base("SUPPLYREQUEST", "BaseSupplyRequest")
        {
        }

        protected BaseSupplyRequest(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}