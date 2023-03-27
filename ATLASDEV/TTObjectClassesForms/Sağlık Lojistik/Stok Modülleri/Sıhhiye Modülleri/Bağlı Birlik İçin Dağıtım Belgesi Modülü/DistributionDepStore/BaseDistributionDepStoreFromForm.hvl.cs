
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
    /// Bağlı Birlik İçin Dağıtım Belgesi
    /// </summary>
    public partial class BaseDistributionDepStoreFrom : StockActionBaseForm
    {
    /// <summary>
    /// Bağlı Birlik İçin Dağıtım Belgesi
    /// </summary>
        protected TTObjectClasses.DistributionDepStore _DistributionDepStore
        {
            get { return (TTObjectClasses.DistributionDepStore)_ttObject; }
        }

        protected ITTLabel labelStockActionID;
        protected ITTTextBox StockActionID;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelTransactionDate;
        protected ITTObjectListBox Store;
        protected ITTLabel labelChattelInventoryObjectID;
        protected ITTObjectListBox Accountancy;
        protected ITTLabel labelDestinationStore;
        protected ITTTabControl DistributionDocumentMaterialsTabcontrol;
        protected ITTTabPage DistributionDocumentMaterialsTabpage;
        protected ITTGrid DistributionDocumentMaterials;
        protected ITTListBoxColumn MaterialDistributionDocumentMaterial;
        protected ITTListBoxColumn StockCard;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn LotNo;
        protected ITTDateTimePickerColumn ExpirationDate;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn AcceptedAmountDistributionDocumentMaterial;
        protected ITTTextBoxColumn AmountDistributionDocumentMaterial;
        protected ITTTextBoxColumn StoreInheld;
        protected ITTTextBoxColumn DestinationStoreInheld;
        protected ITTListBoxColumn StockLevelTypeDistributionDocumentMaterial;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTextBoxColumn Price;
        protected ITTEnumComboBoxColumn StatusDistributionDocumentMaterial;
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
            labelStockActionID = (ITTLabel)AddControl(new Guid("dff9c104-620a-415e-85fd-af3b7f74f88f"));
            StockActionID = (ITTTextBox)AddControl(new Guid("fb6e6ef2-905d-4581-a29a-37c9796d0928"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("301dc98b-09d0-407c-9faf-c0c5fadb79ea"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("89f0c804-d877-4ca5-b8e5-ea9c618a19e1"));
            Store = (ITTObjectListBox)AddControl(new Guid("a0db6429-aa8e-425f-a9a4-05b0c5c11624"));
            labelChattelInventoryObjectID = (ITTLabel)AddControl(new Guid("586fc289-db2b-47ba-87a9-8e9754723d5a"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("38393a5a-4954-416d-9737-67957e2ac770"));
            labelDestinationStore = (ITTLabel)AddControl(new Guid("1373ef0f-33fc-4c5d-808e-cd6905c11836"));
            DistributionDocumentMaterialsTabcontrol = (ITTTabControl)AddControl(new Guid("3ff07364-5a5c-40ab-ba17-acda75f70e81"));
            DistributionDocumentMaterialsTabpage = (ITTTabPage)AddControl(new Guid("4f3ca402-3507-427b-aba0-66f1444aaa2a"));
            DistributionDocumentMaterials = (ITTGrid)AddControl(new Guid("1b943e71-f13f-4fec-8bc3-4df7607cda44"));
            MaterialDistributionDocumentMaterial = (ITTListBoxColumn)AddControl(new Guid("870b09e0-e13a-42db-9278-a0a40d8444dd"));
            StockCard = (ITTListBoxColumn)AddControl(new Guid("1e9421a7-d587-4c5a-a52e-d9c596ee9c15"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("e9b66833-d9fb-458a-b141-74699f577249"));
            LotNo = (ITTTextBoxColumn)AddControl(new Guid("d1dfce6a-f1f3-4b0b-bdd6-e675276e4973"));
            ExpirationDate = (ITTDateTimePickerColumn)AddControl(new Guid("63a054df-5e58-47f4-bffb-35e01593026a"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("a6b4afb7-57cc-44db-9780-5b170981d921"));
            AcceptedAmountDistributionDocumentMaterial = (ITTTextBoxColumn)AddControl(new Guid("2d36d7c8-dd78-4fb2-babe-111f9bbc5231"));
            AmountDistributionDocumentMaterial = (ITTTextBoxColumn)AddControl(new Guid("684782c4-2d89-47e3-8b1f-eefe305c84f6"));
            StoreInheld = (ITTTextBoxColumn)AddControl(new Guid("2acebd97-6354-407d-ba6b-d313b5eabc07"));
            DestinationStoreInheld = (ITTTextBoxColumn)AddControl(new Guid("c0a5fb63-a259-4318-8f33-1ef1d333295f"));
            StockLevelTypeDistributionDocumentMaterial = (ITTListBoxColumn)AddControl(new Guid("87a3d63b-e195-4436-815f-e231e55e52e1"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("74d81900-04c3-4e04-b107-d4553f02136e"));
            Price = (ITTTextBoxColumn)AddControl(new Guid("b9ec328e-48f6-4155-a523-fc1759c725e8"));
            StatusDistributionDocumentMaterial = (ITTEnumComboBoxColumn)AddControl(new Guid("f7ddfc31-d5d4-4023-9d03-58a64d75ab17"));
            DescriptionAndSignTabControl = (ITTTabControl)AddControl(new Guid("3cfae9fb-0e21-4e46-ba6b-ad96476126a8"));
            SignTabpage = (ITTTabPage)AddControl(new Guid("b8fee3c1-6737-40e3-8bd2-7fa1cfc2d542"));
            StockActionSignDetails = (ITTGrid)AddControl(new Guid("33c6a3c1-35cb-4f32-a299-ed2700e92360"));
            SignUserType = (ITTEnumComboBoxColumn)AddControl(new Guid("1f90421b-6994-489d-ae24-dcb2ebad6d81"));
            SignUser = (ITTListBoxColumn)AddControl(new Guid("78fb98b3-8328-4b3d-b7d9-04f4ffae4c58"));
            IsDeputy = (ITTCheckBoxColumn)AddControl(new Guid("e93105dc-36e2-452c-9f3e-fa1b8705ea0f"));
            DescriptionTabpage = (ITTTabPage)AddControl(new Guid("15031967-8208-4253-a820-f6283f7c06f6"));
            Description = (ITTTextBox)AddControl(new Guid("5e0a2745-2038-401f-99e4-c161b069355f"));
            base.InitializeControls();
        }

        public BaseDistributionDepStoreFrom() : base("DISTRIBUTIONDEPSTORE", "BaseDistributionDepStoreFrom")
        {
        }

        protected BaseDistributionDepStoreFrom(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}