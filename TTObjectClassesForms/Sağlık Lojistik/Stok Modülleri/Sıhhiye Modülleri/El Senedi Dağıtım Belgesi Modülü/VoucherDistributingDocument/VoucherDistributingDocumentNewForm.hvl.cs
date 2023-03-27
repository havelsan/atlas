
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
    public partial class VoucherDistributingDocumentNewForm : BaseVoucherDistributingDocumentForm
    {
    /// <summary>
    /// El Senedi Dağıtım Belgesi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.VoucherDistributingDocument _VoucherDistributingDocument
        {
            get { return (TTObjectClasses.VoucherDistributingDocument)_ttObject; }
        }

        protected ITTTextBox StoreCodeUnitStoreGetData;
        protected ITTTextBox NameStore;
        protected ITTGrid StocksStockGrid;
        protected ITTListBoxColumn StoreStock;
        protected ITTListBoxColumn MaterialStock;
        protected ITTTextBoxColumn ConsignedStock;
        protected ITTDateTimePickerColumn CreationDateStock;
        protected ITTCheckBoxColumn ExpendableStock;
        protected ITTTextBoxColumn InheldStock;
        protected ITTTextBoxColumn MaximumLevelStock;
        protected ITTTextBoxColumn MinimumLevelStock;
        protected ITTTextBoxColumn SafetyLevelStock;
        protected ITTTextBoxColumn TotalInStock;
        protected ITTTextBoxColumn TotalInPriceStock;
        protected ITTTextBoxColumn TotalOutStock;
        protected ITTTextBoxColumn TotalOutPriceStock;
        protected ITTGrid StocksStock;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTListBoxColumn ttlistboxcolumn2;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn1;
        protected ITTCheckBoxColumn ttcheckboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTTextBoxColumn tttextboxcolumn3;
        protected ITTTextBoxColumn tttextboxcolumn4;
        protected ITTTextBoxColumn tttextboxcolumn5;
        protected ITTTextBoxColumn tttextboxcolumn6;
        protected ITTTextBoxColumn tttextboxcolumn7;
        protected ITTTextBoxColumn tttextboxcolumn8;
        protected ITTTextBoxColumn tttextboxcolumn9;
        protected ITTLabel labelStoreCodeUnitStoreGetData;
        protected ITTLabel labelNameStore;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialTabPage;
        protected ITTGrid StockActionOutDetails;
        protected ITTButtonColumn Detail;
        protected ITTListBoxColumn Material;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn RequireMaterial;
        protected ITTListDefComboBoxColumn StockLevelType;
        override protected void InitializeControls()
        {
            StoreCodeUnitStoreGetData = (ITTTextBox)AddControl(new Guid("bcd42fdf-6323-4aba-819c-94b565873798"));
            NameStore = (ITTTextBox)AddControl(new Guid("22dda4c9-d313-4d29-b226-8afe1180d477"));
            StocksStockGrid = (ITTGrid)AddControl(new Guid("4cbfef7d-dd7b-43e8-b78f-79f3f2ff724d"));
            StoreStock = (ITTListBoxColumn)AddControl(new Guid("599b6997-b9d6-474a-a06a-bd34fc284a30"));
            MaterialStock = (ITTListBoxColumn)AddControl(new Guid("f0b5b8c1-c68d-44fc-87d2-08d2da1001bb"));
            ConsignedStock = (ITTTextBoxColumn)AddControl(new Guid("46fd5ad0-0b18-4192-a5cd-303861c6b025"));
            CreationDateStock = (ITTDateTimePickerColumn)AddControl(new Guid("65f3389e-01dd-4340-883c-d00a064796d6"));
            ExpendableStock = (ITTCheckBoxColumn)AddControl(new Guid("8c89a8bb-7832-47af-a6dd-21090f9801ae"));
            InheldStock = (ITTTextBoxColumn)AddControl(new Guid("fd899674-2eba-4b03-adab-2b16c6787fcc"));
            MaximumLevelStock = (ITTTextBoxColumn)AddControl(new Guid("e1fd85b5-9a7e-4949-ac72-32fe0e1d57d5"));
            MinimumLevelStock = (ITTTextBoxColumn)AddControl(new Guid("edc2fd38-c29d-4385-b1c2-5e5a64680c34"));
            SafetyLevelStock = (ITTTextBoxColumn)AddControl(new Guid("b11c39a7-05c8-4b61-9d71-cbc3b4406aac"));
            TotalInStock = (ITTTextBoxColumn)AddControl(new Guid("ce148712-e81e-4897-b394-dd93ed5b9ed1"));
            TotalInPriceStock = (ITTTextBoxColumn)AddControl(new Guid("c09e3284-b024-4114-bc91-d37079fc24c3"));
            TotalOutStock = (ITTTextBoxColumn)AddControl(new Guid("a9f6bd24-77ed-4320-9c36-e67be3353a3c"));
            TotalOutPriceStock = (ITTTextBoxColumn)AddControl(new Guid("eb6f13aa-ecce-4a75-bb10-2eb1c713a8f9"));
            StocksStock = (ITTGrid)AddControl(new Guid("d2a36db6-ad44-4364-a02e-cdd804361c92"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("fd4384ce-d998-44b1-b5e2-b882254b2a90"));
            ttlistboxcolumn2 = (ITTListBoxColumn)AddControl(new Guid("5a9054c2-c2d3-45f0-9d32-326a652008c6"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("8e2b8de4-6db8-467b-9394-87483ffa6977"));
            ttdatetimepickercolumn1 = (ITTDateTimePickerColumn)AddControl(new Guid("722e8e12-4412-4396-a4e2-f9e7dd8e2857"));
            ttcheckboxcolumn1 = (ITTCheckBoxColumn)AddControl(new Guid("5ae6ce57-fbb1-46d8-875e-ab5cc631df83"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("9030b065-6efa-4c52-82d1-5e51d06e862c"));
            tttextboxcolumn3 = (ITTTextBoxColumn)AddControl(new Guid("5dd76435-e411-440a-8e37-4fb5f978e273"));
            tttextboxcolumn4 = (ITTTextBoxColumn)AddControl(new Guid("f9085b2d-f1c5-4243-9b23-f419ef4f83e1"));
            tttextboxcolumn5 = (ITTTextBoxColumn)AddControl(new Guid("b5e4d193-a158-4568-acb4-df8ef76ba9ef"));
            tttextboxcolumn6 = (ITTTextBoxColumn)AddControl(new Guid("1bd47161-df3e-4557-8389-df19b80a3269"));
            tttextboxcolumn7 = (ITTTextBoxColumn)AddControl(new Guid("464e15b8-6926-43e4-9363-26741af0cbfd"));
            tttextboxcolumn8 = (ITTTextBoxColumn)AddControl(new Guid("90f7ebe1-fdc1-4677-850c-c165c40357a5"));
            tttextboxcolumn9 = (ITTTextBoxColumn)AddControl(new Guid("16e909a8-01fd-40e3-a713-77f1599e0c3f"));
            labelStoreCodeUnitStoreGetData = (ITTLabel)AddControl(new Guid("8b263dcf-7ab2-4bc0-b8cd-f5512a7e46f7"));
            labelNameStore = (ITTLabel)AddControl(new Guid("32c3c1ba-39d1-429f-875f-47281e1dc121"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("1add705b-3e79-4c3b-84e0-0e8389f55d6d"));
            MaterialTabPage = (ITTTabPage)AddControl(new Guid("95c9c8ea-06fe-4b0b-8af1-ee48085585bc"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("6592d84e-2716-4094-be14-11cc0ddd1b3b"));
            Detail = (ITTButtonColumn)AddControl(new Guid("8edc40b8-b90c-454f-b627-843554ada678"));
            Material = (ITTListBoxColumn)AddControl(new Guid("8d36f428-5735-4145-9a90-e61fd304fd80"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("8dd70915-6cb5-4e7f-a8bd-ccc233d21517"));
            RequireMaterial = (ITTTextBoxColumn)AddControl(new Guid("f0298506-9d45-4bf1-9003-8fd8a164261c"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("4119697f-06c6-4dde-a697-cd30340d5011"));
            base.InitializeControls();
        }

        public VoucherDistributingDocumentNewForm() : base("VOUCHERDISTRIBUTINGDOCUMENT", "VoucherDistributingDocumentNewForm")
        {
        }

        protected VoucherDistributingDocumentNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}