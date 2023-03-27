
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
    /// Kalibrasyon/Bakım/Onarım
    /// </summary>
    public partial class CMRActionStatusForm : CMRActionBaseForm
    {
    /// <summary>
    /// Kalibrasyon/Bakım/Onarım İstek
    /// </summary>
        protected TTObjectClasses.CMRActionRequest _CMRActionRequest
        {
            get { return (TTObjectClasses.CMRActionRequest)_ttObject; }
        }

        protected ITTGrid ItemEquipmentsGrid;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount;
        protected ITTListBoxColumn DistType;
        protected ITTCheckBoxColumn IsMissing;
        protected ITTCheckBoxColumn IsChanged;
        protected ITTCheckBoxColumn IsDamaged;
        protected ITTCheckBoxColumn IsNormal;
        protected ITTTextBoxColumn Comments;
        protected ITTLabel labelSenderSection;
        protected ITTObjectListBox SenderSection;
        protected ITTLabel labelSection;
        protected ITTObjectListBox Section;
        protected ITTLabel labelWorkShop;
        protected ITTObjectListBox WorkShop;
        protected ITTLabel labelResponsibleWorkShopUser;
        protected ITTObjectListBox ResponsibleWorkShopUser;
        protected ITTObjectListBox Stage;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox RequestNo;
        protected ITTLabel labelRequestType;
        protected ITTEnumComboBox RequestType;
        protected ITTLabel labelRequestNo;
        protected ITTLabel labelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRepairPlace;
        protected ITTEnumComboBox RepairPlace;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel Statuslabel;
        protected ITTTabControl fixedAssetTypeTab;
        protected ITTTabPage SerialTab;
        protected ITTObjectListBox FixedAssetMaterialDefinition;
        protected ITTLabel labelFixedAssetMaterialDefinition;
        protected ITTLabel ttlabel3;
        protected ITTTextBox FaultDescription;
        protected ITTTextBox UserTel;
        protected ITTLabel labelUserTel;
        protected ITTObjectListBox DeviceUser;
        protected ITTLabel labelDeviceUser;
        protected ITTTabPage StockTab;
        protected ITTLabel labelFixedAssetMaterialDesc;
        protected ITTLabel labelFixedAssetMaterialAmount;
        protected ITTTextBox FixedAssetMaterialDesc;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTTextBox FixedAssetMaterialAmount;
        protected ITTLabel labelFixedAssetDefinition;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        protected ITTEnumComboBox FixedAssetType;
        protected ITTLabel labelFixedAssetType;
        override protected void InitializeControls()
        {
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("954e9f8f-ab00-4ffd-a9a4-f3b9185bc981"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("c1e34ddc-1338-4bc2-83f3-ceb88eb9391f"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("391049cb-c14b-42db-a949-ecf49dca0d46"));
            DistType = (ITTListBoxColumn)AddControl(new Guid("a77cd087-22c0-4e36-a2a4-b222e90847ae"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("848a22c7-6472-4eea-b1e4-1f551fa134c7"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("9ea7c0a6-80be-4ae1-b6b8-5e8618552504"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("c9700fd5-317f-4b68-97b7-744a85bfd148"));
            IsNormal = (ITTCheckBoxColumn)AddControl(new Guid("86c0ab90-8dfa-4139-816d-81fb6107bedd"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("196dec00-dce2-47f9-87fc-11208b56be12"));
            labelSenderSection = (ITTLabel)AddControl(new Guid("dd31ff88-e35c-4292-a9ed-7a970b43958f"));
            SenderSection = (ITTObjectListBox)AddControl(new Guid("658df6ce-6909-4d3a-a3b7-e3d211f3928a"));
            labelSection = (ITTLabel)AddControl(new Guid("d9394705-3e31-4dce-bf96-0c9aba7dd0fe"));
            Section = (ITTObjectListBox)AddControl(new Guid("92a3b853-1bec-4f94-94fc-499a718531aa"));
            labelWorkShop = (ITTLabel)AddControl(new Guid("3602914b-20e4-4704-9364-d1ca9585e0a5"));
            WorkShop = (ITTObjectListBox)AddControl(new Guid("301fd5a8-234c-43e8-9951-dd43b546f621"));
            labelResponsibleWorkShopUser = (ITTLabel)AddControl(new Guid("a31cc178-d7d6-47a3-a02a-7a7bf5a4b6af"));
            ResponsibleWorkShopUser = (ITTObjectListBox)AddControl(new Guid("1ae762ad-2512-4cdc-9825-0f5e01389a2e"));
            Stage = (ITTObjectListBox)AddControl(new Guid("cce7ac57-c56e-44b3-a492-6870175ba662"));
            labelDescription = (ITTLabel)AddControl(new Guid("cc051830-2492-4034-bee8-bc6e5d0bdb8c"));
            Description = (ITTTextBox)AddControl(new Guid("b2fd8d7f-d10b-443f-bf1f-923c328c082c"));
            RequestNo = (ITTTextBox)AddControl(new Guid("971f9aab-c207-493b-bdf0-ded19a5d1cd3"));
            labelRequestType = (ITTLabel)AddControl(new Guid("c46b8a7c-c813-41ec-a8d1-3b7ae8f05490"));
            RequestType = (ITTEnumComboBox)AddControl(new Guid("e6f936d2-6ac4-4302-a6c8-ffaa50398c50"));
            labelRequestNo = (ITTLabel)AddControl(new Guid("bea1746d-ef0c-4a52-ae88-601a1da1dc83"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("7b30b846-b021-4bba-837a-7ecddbb1c14d"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("0838ef3a-00fd-4b4e-871d-1dfbda6ec175"));
            labelRepairPlace = (ITTLabel)AddControl(new Guid("6efc2326-f575-4273-a285-20d6ef536f30"));
            RepairPlace = (ITTEnumComboBox)AddControl(new Guid("113a0724-c0fd-48ba-a39b-99fbb420fffa"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("18b8147b-3ad7-48b4-a937-4c84e92131be"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("d4e6a6ee-bd9a-49b8-bfe1-1ec484271174"));
            Statuslabel = (ITTLabel)AddControl(new Guid("21144e84-91ba-411a-93b6-619d82f39849"));
            fixedAssetTypeTab = (ITTTabControl)AddControl(new Guid("5a610610-1bdc-4c76-8e39-b439437b1ae6"));
            SerialTab = (ITTTabPage)AddControl(new Guid("475b2ce6-129a-4fd9-ae46-0fe0efdb4108"));
            FixedAssetMaterialDefinition = (ITTObjectListBox)AddControl(new Guid("50cac92e-997a-4861-aa36-fe76f0d5193e"));
            labelFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("be9727dc-933e-4a30-a2e4-5f5a8fa901c6"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("b7c60ed5-c028-4c5d-97ef-b1396012cc60"));
            FaultDescription = (ITTTextBox)AddControl(new Guid("0f796f9d-b5cf-4f64-a610-c87d95684247"));
            UserTel = (ITTTextBox)AddControl(new Guid("e9e7c2cc-8684-4c0e-8274-0ea0e835b77d"));
            labelUserTel = (ITTLabel)AddControl(new Guid("312f5806-eebd-4204-a094-ae475aa2bb37"));
            DeviceUser = (ITTObjectListBox)AddControl(new Guid("3bc3acda-42fd-4379-a344-c03360490165"));
            labelDeviceUser = (ITTLabel)AddControl(new Guid("638efed0-2c22-4fd5-9567-087fe4d08f4b"));
            StockTab = (ITTTabPage)AddControl(new Guid("729e177c-4505-4ce9-b4a8-36348e3e80fd"));
            labelFixedAssetMaterialDesc = (ITTLabel)AddControl(new Guid("c9d1f475-ba5a-47f8-b890-8f3a969db23c"));
            labelFixedAssetMaterialAmount = (ITTLabel)AddControl(new Guid("09e35876-64c9-4b41-bcd4-4857c5942107"));
            FixedAssetMaterialDesc = (ITTTextBox)AddControl(new Guid("3a6de646-0096-4732-bbc7-3273ab736d61"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("4a0bd7f6-f588-44e0-ae00-af92ecee3044"));
            FixedAssetMaterialAmount = (ITTTextBox)AddControl(new Guid("44d6d964-9d98-4054-9250-1640ec7f5694"));
            labelFixedAssetDefinition = (ITTLabel)AddControl(new Guid("f03be6ec-8f7f-4e79-99cb-690e0eb31091"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("2ae6f2b2-17ff-486c-bfa7-c317617f0a6c"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("535ec407-1bd7-4316-a441-ff6620a112e7"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f6d2d53d-0830-4c14-95da-8f0a3df40fcb"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("e068251b-7a15-4b1d-86b8-5920be511dd7"));
            FixedAssetType = (ITTEnumComboBox)AddControl(new Guid("cd65b51d-281b-4b49-b5fe-5bbae8196e15"));
            labelFixedAssetType = (ITTLabel)AddControl(new Guid("f8e0732f-956d-4c3c-8b8d-c1447543fdee"));
            base.InitializeControls();
        }

        public CMRActionStatusForm() : base("CMRACTIONREQUEST", "CMRActionStatusForm")
        {
        }

        protected CMRActionStatusForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}