
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
    /// Tamam
    /// </summary>
    public partial class DemandCompleted : TTForm
    {
    /// <summary>
    /// Malzeme/Hizmet İstek modülü için ana sınıftır
    /// </summary>
        protected TTObjectClasses.Demand _Demand
        {
            get { return (TTObjectClasses.Demand)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid ItemsGrid;
        protected ITTListBoxColumn PurchaseItem;
        protected ITTTextBoxColumn GMDNNo;
        protected ITTTextBoxColumn NSN;
        protected ITTTextBoxColumn PurchaseItemUnitType;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn ApprovedAmount;
        protected ITTTextBoxColumn StoreStocks;
        protected ITTTextBoxColumn AccountancyAmount;
        protected ITTTextBoxColumn TransferAmount;
        protected ITTTextBoxColumn Description2;
        protected ITTButtonColumn StockDetails;
        protected ITTRichTextBoxControlColumn SpRefToAdMatters;
        protected ITTRichTextBoxControlColumn FeasibilityEtude;
        protected ITTListBoxColumn Patient;
        protected ITTTextBoxColumn TechnicalSpecificationNo;
        protected ITTTabPage tttabpage2;
        protected ITTGrid TransfersGrid;
        protected ITTListBoxColumn ReturnStore;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTGroupBox ttgroupbox2;
        protected ITTButton cmdApproveAll;
        protected ITTLabel labelDescription;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelActionDate;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTTextBox RequestNO;
        protected ITTLabel labelID;
        protected ITTTextBox Description;
        protected ITTLabel labelDemandType;
        protected ITTDateTimePicker ActionDate;
        protected ITTEnumComboBox DemandType;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("6c510d2f-88e4-4e73-8ce6-1b70d86749fb"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("82fb652f-9ae6-423d-9af0-5f15672e2533"));
            ItemsGrid = (ITTGrid)AddControl(new Guid("49461c44-172c-4814-9ccf-ea6c54b0ba79"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("60c5e746-eeda-46ef-92fb-40fea180034d"));
            GMDNNo = (ITTTextBoxColumn)AddControl(new Guid("462c5a34-2246-4070-929c-771108c30462"));
            NSN = (ITTTextBoxColumn)AddControl(new Guid("caa0515e-10f6-4229-a10b-129a3956f8bc"));
            PurchaseItemUnitType = (ITTTextBoxColumn)AddControl(new Guid("3d03b675-1747-405d-b1f8-e2341326821c"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("9fd150d0-a997-4795-84fc-1f3d35683886"));
            ApprovedAmount = (ITTTextBoxColumn)AddControl(new Guid("34042972-14da-4124-9b81-fedc8d74b2d9"));
            StoreStocks = (ITTTextBoxColumn)AddControl(new Guid("849156fe-5333-4c7c-a351-659e9150cb53"));
            AccountancyAmount = (ITTTextBoxColumn)AddControl(new Guid("a2721ed2-c691-40ec-a90c-87d08f20ac28"));
            TransferAmount = (ITTTextBoxColumn)AddControl(new Guid("395df2eb-f889-42f4-b04c-55eccbe8dc4b"));
            Description2 = (ITTTextBoxColumn)AddControl(new Guid("c1770ffb-e098-4111-8af5-b33247f3be35"));
            StockDetails = (ITTButtonColumn)AddControl(new Guid("cba19228-4cf7-4458-a1ac-718b0126d12c"));
            SpRefToAdMatters = (ITTRichTextBoxControlColumn)AddControl(new Guid("a04a521b-ad26-4479-8f50-143a440ef6de"));
            FeasibilityEtude = (ITTRichTextBoxControlColumn)AddControl(new Guid("2e36626b-ec77-4cd3-b4c3-1b52e56b3daa"));
            Patient = (ITTListBoxColumn)AddControl(new Guid("16200a0f-8389-4bdd-a836-80d01980bab3"));
            TechnicalSpecificationNo = (ITTTextBoxColumn)AddControl(new Guid("d7d8cb44-ddc5-4647-b55b-da1d46f769eb"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("35e43985-b390-48a2-bec0-3bf30df76ce2"));
            TransfersGrid = (ITTGrid)AddControl(new Guid("0079a95e-de26-4466-97ff-c9f04455f7e5"));
            ReturnStore = (ITTListBoxColumn)AddControl(new Guid("a2bfda86-5082-41eb-be81-3348d23aee6d"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("89ee999b-516a-4fc9-ba8d-5f972e3f0773"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("0e3f5241-1d89-428a-bd04-0134135d7f74"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("63d9ff0b-c05a-4f6d-986a-f958cbb4792a"));
            cmdApproveAll = (ITTButton)AddControl(new Guid("47b19881-6fba-4cd5-a624-06f3d5e7ea6c"));
            labelDescription = (ITTLabel)AddControl(new Guid("d47ac6cc-091f-4885-afda-f3028516a092"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b7761c14-9bdf-4c49-be01-4c7c07b92bf3"));
            labelActionDate = (ITTLabel)AddControl(new Guid("0792e05d-5bbb-4040-9747-9104bb2e26b9"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("50280264-476d-4895-aadc-7a6a8938ef7e"));
            RequestNO = (ITTTextBox)AddControl(new Guid("33efe770-a656-4c71-857f-dae967b590c5"));
            labelID = (ITTLabel)AddControl(new Guid("a4577191-875f-40e5-bba1-e6870fa559f4"));
            Description = (ITTTextBox)AddControl(new Guid("51a68424-33b3-4d98-8833-7490da1a3791"));
            labelDemandType = (ITTLabel)AddControl(new Guid("144ae114-3643-455a-885b-b2bf66204531"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("22eb33ba-5459-41ff-b13c-c94e21f14846"));
            DemandType = (ITTEnumComboBox)AddControl(new Guid("91053297-9bd2-4e1a-b598-71b844380f25"));
            base.InitializeControls();
        }

        public DemandCompleted() : base("DEMAND", "DemandCompleted")
        {
        }

        protected DemandCompleted(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}