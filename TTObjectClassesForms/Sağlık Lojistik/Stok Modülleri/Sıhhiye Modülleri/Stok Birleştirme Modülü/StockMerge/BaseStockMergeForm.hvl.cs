
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
    public partial class BaseStockMergeForm : StockActionBaseForm
    {
        protected TTObjectClasses.StockMerge _StockMerge
        {
            get { return (TTObjectClasses.StockMerge)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox2;
        protected ITTGrid StockMergeInMaterials;
        protected ITTListBoxColumn MaterialStockMergeMaterialIn;
        protected ITTTextBoxColumn BarcodeY;
        protected ITTTextBoxColumn DistributionTypeStockMergeMaterialIn;
        protected ITTTextBoxColumn AmountStockMergeMaterialIn;
        protected ITTTextBoxColumn UnitPriceStockMergeMaterialIn;
        protected ITTTextBoxColumn LotNo;
        protected ITTDateTimePickerColumn ExpirationDateStockMergeMaterialIn;
        protected ITTTextBoxColumn VatRateStockMergeMaterialIn;
        protected ITTListBoxColumn StockLevelTypeStockMergeMaterialIn;
        protected ITTEnumComboBoxColumn StatusStockMergeMaterialIn;
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid StockMergeOutMaterials;
        protected ITTListBoxColumn MaterialStockMergeMaterialOut;
        protected ITTTextBoxColumn BarcodeD;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn AmountStockMergeMaterialOut;
        protected ITTListBoxColumn StockLevelTypeStockMergeMaterialOut;
        protected ITTEnumComboBoxColumn StatusStockMergeMaterialOut;
        protected ITTLabel labelChattelInventoryObjectID;
        protected ITTObjectListBox ChattelInventoryObjectID;
        protected ITTLabel labelDestinationStore;
        protected ITTObjectListBox DestinationStore;
        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelStockActionID;
        protected ITTTextBox StockActionID;
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
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("4eda83c0-6866-458f-a806-25beddc8d75f"));
            StockMergeInMaterials = (ITTGrid)AddControl(new Guid("69d125ce-7378-49af-b8a4-73a218a02350"));
            MaterialStockMergeMaterialIn = (ITTListBoxColumn)AddControl(new Guid("c0092f57-0819-4e52-943f-adfca5d648b4"));
            BarcodeY = (ITTTextBoxColumn)AddControl(new Guid("6d469501-6125-4a26-9a59-0025f19868d2"));
            DistributionTypeStockMergeMaterialIn = (ITTTextBoxColumn)AddControl(new Guid("abb4ed14-a089-4de6-9fbe-9b58584eab21"));
            AmountStockMergeMaterialIn = (ITTTextBoxColumn)AddControl(new Guid("09fe565f-80f1-48e3-bb69-cf2b288aa60e"));
            UnitPriceStockMergeMaterialIn = (ITTTextBoxColumn)AddControl(new Guid("010cab5b-f205-40e7-841c-b1a484ccd752"));
            LotNo = (ITTTextBoxColumn)AddControl(new Guid("99f5d70c-c9c1-476c-99be-f63185de6d50"));
            ExpirationDateStockMergeMaterialIn = (ITTDateTimePickerColumn)AddControl(new Guid("3d118c04-e544-49e4-9201-670615d295d6"));
            VatRateStockMergeMaterialIn = (ITTTextBoxColumn)AddControl(new Guid("76e537f7-a85c-4fa9-be6a-5c92aa7507cd"));
            StockLevelTypeStockMergeMaterialIn = (ITTListBoxColumn)AddControl(new Guid("ddc89b00-46d5-44e4-8b88-b34f146542b0"));
            StatusStockMergeMaterialIn = (ITTEnumComboBoxColumn)AddControl(new Guid("71feda80-b114-4207-9c10-140f82351cef"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("c47c7972-db12-4cf5-a6b6-dfafffe4f430"));
            StockMergeOutMaterials = (ITTGrid)AddControl(new Guid("56cdff13-6016-4165-bc35-087a37de257c"));
            MaterialStockMergeMaterialOut = (ITTListBoxColumn)AddControl(new Guid("e6108b02-cc2e-4486-979a-a6bc47cd61bf"));
            BarcodeD = (ITTTextBoxColumn)AddControl(new Guid("0452476f-3455-4285-abe9-12c601370499"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("a595d78e-32a2-44bc-835f-16b24d0b9bf5"));
            AmountStockMergeMaterialOut = (ITTTextBoxColumn)AddControl(new Guid("99af8b99-1cda-488c-a9ab-10fff5d6862f"));
            StockLevelTypeStockMergeMaterialOut = (ITTListBoxColumn)AddControl(new Guid("9c62168c-1052-4461-8d58-e4c573875ec3"));
            StatusStockMergeMaterialOut = (ITTEnumComboBoxColumn)AddControl(new Guid("d6db1cc4-0a20-4392-be34-770e611a770b"));
            labelChattelInventoryObjectID = (ITTLabel)AddControl(new Guid("afa2832a-c003-4282-a534-545b5aeb991c"));
            ChattelInventoryObjectID = (ITTObjectListBox)AddControl(new Guid("89be5a1a-2eab-4dd7-b246-8c0aedfb2156"));
            labelDestinationStore = (ITTLabel)AddControl(new Guid("384e2357-e4de-4171-b5ef-20baac33e6ab"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("f233aa76-afe0-4bf3-a28d-c986a6f2218f"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("4209d801-2088-47b4-9e80-7b25c8ff69f6"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("af96183e-9655-4b29-8de7-708a2b1d6721"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("4e416546-e60d-4714-8822-4b8011abc0e8"));
            StockActionID = (ITTTextBox)AddControl(new Guid("3d30979f-7a10-4be2-9991-1c4f6cb5f8cc"));
            DescriptionAndSignTabControl = (ITTTabControl)AddControl(new Guid("92a08401-e430-4989-8eea-8749a1a6015b"));
            SignTabpage = (ITTTabPage)AddControl(new Guid("d1b227cf-6a6b-4ccf-a4fc-65eaf7858413"));
            StockActionSignDetails = (ITTGrid)AddControl(new Guid("09c192a7-0bde-4def-82bf-b8303047f2d7"));
            SignUserType = (ITTEnumComboBoxColumn)AddControl(new Guid("d755ae31-7306-4c81-b127-e3e1faaa5e81"));
            SignUser = (ITTListBoxColumn)AddControl(new Guid("f9674d99-bb9b-4e6f-9d2a-9b3984a5c71a"));
            IsDeputy = (ITTCheckBoxColumn)AddControl(new Guid("05e62b7c-a91b-4183-bc9f-1837d834f6c4"));
            DescriptionTabpage = (ITTTabPage)AddControl(new Guid("4fe691cb-85b1-4806-874d-999bc3b55f7b"));
            Description = (ITTTextBox)AddControl(new Guid("6890a21d-b001-4c49-94a0-8343019b1a49"));
            base.InitializeControls();
        }

        public BaseStockMergeForm() : base("STOCKMERGE", "BaseStockMergeForm")
        {
        }

        protected BaseStockMergeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}