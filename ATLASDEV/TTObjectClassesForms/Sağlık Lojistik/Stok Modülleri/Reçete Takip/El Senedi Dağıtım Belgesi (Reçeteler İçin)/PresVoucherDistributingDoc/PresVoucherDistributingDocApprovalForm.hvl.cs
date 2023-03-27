
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
    /// El Senedi Dağıtım Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class PresVoucherDistributingDocApprovalForm : BasePresVoucherDistributingDocForm
    {
    /// <summary>
    /// El Senedi Dağıtım Belgesi (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresVoucherDistributingDoc _PresVoucherDistributingDoc
        {
            get { return (TTObjectClasses.PresVoucherDistributingDoc)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialTabPage;
        protected ITTGrid PresVoucherDistDocMaterials;
        protected ITTListBoxColumn MaterialPresVoucherDistDocMaterial;
        protected ITTTextBoxColumn Barcode;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn RequireAmountPresVoucherDistDocMaterial;
        protected ITTTextBoxColumn AmountPresVoucherDistDocMaterial;
        protected ITTTextBoxColumn StoreStock;
        protected ITTTextBoxColumn DestinationStoreStock;
        protected ITTListBoxColumn StockLevelTypePresVoucherDistDocMaterial;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("510b6e45-f156-4111-98fd-8c0fa9173f87"));
            MaterialTabPage = (ITTTabPage)AddControl(new Guid("0e928b66-e64b-49b5-a9e0-11c741e6b5d5"));
            PresVoucherDistDocMaterials = (ITTGrid)AddControl(new Guid("2cb38874-d8bf-45a7-ae82-7d1e999d1ac2"));
            MaterialPresVoucherDistDocMaterial = (ITTListBoxColumn)AddControl(new Guid("95cfc0ff-5844-4cc0-8f43-ff0d142f4491"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("4a5e703e-1ba8-49e5-bf41-8ec725b4c98c"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("6be9f42a-8ba0-4fd1-b37b-2c609df7e8fb"));
            RequireAmountPresVoucherDistDocMaterial = (ITTTextBoxColumn)AddControl(new Guid("a903a88d-3311-450c-b333-eb6662963afc"));
            AmountPresVoucherDistDocMaterial = (ITTTextBoxColumn)AddControl(new Guid("baea6c7a-4fef-4cca-9383-1fffad90babd"));
            StoreStock = (ITTTextBoxColumn)AddControl(new Guid("0afa15ca-2a97-43dc-a304-464e43445960"));
            DestinationStoreStock = (ITTTextBoxColumn)AddControl(new Guid("a418f395-2c33-4c1f-9af2-edec6846cd9c"));
            StockLevelTypePresVoucherDistDocMaterial = (ITTListBoxColumn)AddControl(new Guid("c286ea26-c397-486a-9a00-fc6d6dcc8e99"));
            base.InitializeControls();
        }

        public PresVoucherDistributingDocApprovalForm() : base("PRESVOUCHERDISTRIBUTINGDOC", "PresVoucherDistributingDocApprovalForm")
        {
        }

        protected PresVoucherDistributingDocApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}