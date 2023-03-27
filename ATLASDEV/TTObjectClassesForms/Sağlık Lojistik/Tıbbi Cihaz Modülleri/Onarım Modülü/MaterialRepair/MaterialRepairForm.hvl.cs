
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
    /// Onarım [Stok Numaralı]
    /// </summary>
    public partial class MaterialRepairForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım [Stok Numaralı]
    /// </summary>
        protected TTObjectClasses.MaterialRepair _MaterialRepair
        {
            get { return (TTObjectClasses.MaterialRepair)_ttObject; }
        }

        protected ITTLabel labelFixedAssetMaterialDesc;
        protected ITTTextBox FixedAssetMaterialDesc;
        protected ITTTextBox FixedAssetMaterialAmount;
        protected ITTTextBox RequestNO;
        protected ITTToolStrip tttoolstrip2;
        protected ITTLabel labelFixedAssetMaterialAmount;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTObjectListBox ToResource;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox WorkShop;
        protected ITTLabel labelToResource;
        protected ITTLabel labelResponsibleResource;
        protected ITTLabel ttlabel6;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelRequestNO;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTObjectListBox ResponsibleResource;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTObjectListBox FromResource;
        protected ITTLabel ttlabel5;
        protected ITTLabel labelRequestDate;
        protected ITTEnumComboBox RepairPlace;
        protected ITTLabel labelFromResource;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid RepairConsumedMaterials;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn SparePartMaterialDescription;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTTextBoxColumn Desc;
        protected ITTTabPage tttabpage2;
        protected ITTGrid UsedConsumedMaterails;
        protected ITTListBoxColumn UsedMaterial;
        protected ITTTextBoxColumn UsedRequestAmount;
        protected ITTTextBoxColumn UsedSuppliedAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTabPage tttabpage3;
        protected ITTGrid NeededMaterials;
        protected ITTTextBoxColumn MaterialNameNeededMaterials;
        protected ITTTextBoxColumn PartNumberNeededMaterials;
        protected ITTTextBoxColumn MaterialAmountNeededMaterials;
        protected ITTTextBoxColumn MaterialUnitPriceNeededMaterials;
        protected ITTTextBoxColumn MaterialTotalPriceNeededMaterials;
        protected ITTListBoxColumn UsedConsumedMaterailNeededMaterials;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel1;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage UserMaintenanceTabPage;
        protected ITTGrid UserMaintenances;
        protected ITTListBoxColumn UserParameter;
        protected ITTCheckBoxColumn Checked;
        protected ITTTextBoxColumn UserDescription;
        protected ITTTabPage UnitMaintenanceTabPage;
        protected ITTGrid UnitMaintenances;
        protected ITTListBoxColumn UnitParameter;
        protected ITTCheckBoxColumn UnitChecked;
        protected ITTTextBoxColumn UnitDescription;
        protected ITTTabPage ContensTabPage;
        protected ITTGrid ItemEquipmentsGrid;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn tttextboxcolumn4;
        protected ITTListBoxColumn DistType;
        protected ITTCheckBoxColumn IsMissing;
        protected ITTCheckBoxColumn IsChanged;
        protected ITTCheckBoxColumn IsDamaged;
        protected ITTCheckBoxColumn Normal;
        protected ITTTextBoxColumn Comments;
        protected ITTTabPage DemandTabPage;
        protected ITTButton cmdForkDemand;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox PurchaseItem;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTextBox RepairNotes;
        protected ITTTextBox tttextbox5;
        protected ITTTextBox UnitWorkLoadPrice;
        protected ITTTextBox TotalWorkLoad;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel8;
        protected ITTLabel labelTotalWorkLoad;
        protected ITTLabel labelUnitWorkLoadPrice;
        override protected void InitializeControls()
        {
            labelFixedAssetMaterialDesc = (ITTLabel)AddControl(new Guid("aff72eee-3c04-4e4b-bfbb-a6a474374989"));
            FixedAssetMaterialDesc = (ITTTextBox)AddControl(new Guid("3e628e57-538f-45f4-a8d4-af54d682a7c1"));
            FixedAssetMaterialAmount = (ITTTextBox)AddControl(new Guid("cee8c92c-35fa-47e4-8d84-d71ea2f9229a"));
            RequestNO = (ITTTextBox)AddControl(new Guid("17b7f75b-05a4-4875-8eb3-1d5334b9c730"));
            tttoolstrip2 = (ITTToolStrip)AddControl(new Guid("3dbbe007-cdbd-4bf0-9fad-864ee281e517"));
            labelFixedAssetMaterialAmount = (ITTLabel)AddControl(new Guid("6a4d092b-e7fc-4d22-8c75-e39bce7e325b"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("4099c0a9-5456-4ba7-a455-e8c9b7ff8555"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("0b84dd46-f7ca-4f40-bbec-d039e8943730"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("0ee89206-e021-4d2b-a333-f4b202b941ac"));
            WorkShop = (ITTObjectListBox)AddControl(new Guid("d6d263c7-53de-4883-9ab7-ff2afd0048a4"));
            labelToResource = (ITTLabel)AddControl(new Guid("92c5f9df-fe7a-4e26-9ecb-5788bdf92c9f"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("52c866ea-8210-440b-8da4-3e9e7390b043"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("98b499dc-130f-4cec-9144-9b3550c75d77"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("aec3c5ad-b3a0-4fd1-9e78-ae47a4b98436"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("62f97e71-ef21-441b-9056-0b62a8939bec"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("19b62421-8421-49f3-ae02-9d7074ddc82f"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("b98853ce-17b0-4696-a111-c3dd735fffa5"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("5f03f2fb-b16d-4a91-91ca-d5076b254be1"));
            labelStartDate = (ITTLabel)AddControl(new Guid("fd08bbfe-1589-4768-b6ee-77b9fe6b26f5"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("4225e548-d7b0-4260-841d-93e702c21a58"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("275b447f-0688-427e-b868-7c4613e3091b"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("4d2c5be3-4f2c-4f6b-8920-66dc963d34d9"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("fbc93094-cb95-4333-8574-1b52d0821f4e"));
            RepairPlace = (ITTEnumComboBox)AddControl(new Guid("84ec8b71-dee2-4c27-842e-7c52443e1369"));
            labelFromResource = (ITTLabel)AddControl(new Guid("6e07bc66-eb3a-44ec-8102-d6ca4831d499"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("a9a10999-5a85-420f-9de8-10231b58940e"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("28efb2a0-23c4-4ff2-9c85-a1529555a23a"));
            RepairConsumedMaterials = (ITTGrid)AddControl(new Guid("f657c11b-915d-4db6-87cd-6a0d6dc90146"));
            Material = (ITTListBoxColumn)AddControl(new Guid("b46f7fc5-e9b7-4c86-a394-c530cb3cf41a"));
            SparePartMaterialDescription = (ITTTextBoxColumn)AddControl(new Guid("111f6aa3-b6aa-492f-8e62-50bc812974f8"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("6cf6bbc0-ebd3-4af1-a8e7-d8737870b666"));
            Desc = (ITTTextBoxColumn)AddControl(new Guid("b1ecca6e-882e-40aa-ae5d-b0b48c01417e"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("1422d368-c382-40de-9911-ce006cc9f476"));
            UsedConsumedMaterails = (ITTGrid)AddControl(new Guid("daf8ee4d-bcd4-441e-8579-685d6a04ec97"));
            UsedMaterial = (ITTListBoxColumn)AddControl(new Guid("bb996327-942d-452b-9069-ee55ab0e1e08"));
            UsedRequestAmount = (ITTTextBoxColumn)AddControl(new Guid("ddb66a58-cf94-4d9f-b74b-8f1aa32d9277"));
            UsedSuppliedAmount = (ITTTextBoxColumn)AddControl(new Guid("6d9c80ac-decc-472a-aeda-796662cdf40c"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("1244f74d-2b75-4d42-9cf8-59b30e1a3262"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("996449cc-ece2-449b-9d5e-c5b5b674dff1"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("dd915b0e-6ff6-4438-a6b0-6800048309b3"));
            NeededMaterials = (ITTGrid)AddControl(new Guid("8109ed28-201f-4cd6-aaac-b42319c23651"));
            MaterialNameNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("e582919b-2c02-44fe-8f78-cad9daf0f772"));
            PartNumberNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("0bb3ed75-bd89-4e78-9e3e-dca7c3608ded"));
            MaterialAmountNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("eeb9d320-9488-4571-b5fe-9ecf885f8a2d"));
            MaterialUnitPriceNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("e9add9a2-41ef-4740-88db-96e871d7bd3a"));
            MaterialTotalPriceNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("89f4ff58-7512-43dc-bdea-84462192bf13"));
            UsedConsumedMaterailNeededMaterials = (ITTListBoxColumn)AddControl(new Guid("53658e1a-7df2-4dd5-b143-b142acd4964e"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("87104952-931e-4147-b7c9-f3e3cd3dc80c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("88d4e9db-b0a0-48b1-b875-4f41640f9515"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("e2dd3ecd-7985-4dd6-a829-59efcaf9d06f"));
            UserMaintenanceTabPage = (ITTTabPage)AddControl(new Guid("eff7e25c-373c-4ce7-820f-9f3a8d30b7a3"));
            UserMaintenances = (ITTGrid)AddControl(new Guid("7fb8a8e1-cf46-48d3-8c36-4d9b9e27c62f"));
            UserParameter = (ITTListBoxColumn)AddControl(new Guid("c493e770-6d92-444d-bbf7-dc1f80b52e68"));
            Checked = (ITTCheckBoxColumn)AddControl(new Guid("38391bde-694b-4035-8cb7-443eabb12138"));
            UserDescription = (ITTTextBoxColumn)AddControl(new Guid("239dd4d0-11c4-41f6-952c-d6fd1ae8ae0d"));
            UnitMaintenanceTabPage = (ITTTabPage)AddControl(new Guid("88c904a3-2f4e-4fc5-8330-cb81c2bb97d7"));
            UnitMaintenances = (ITTGrid)AddControl(new Guid("1b1b6c97-bc97-4f1d-aaa1-3870249c0883"));
            UnitParameter = (ITTListBoxColumn)AddControl(new Guid("dd8023c8-7782-4b4f-acf8-326ee56bf282"));
            UnitChecked = (ITTCheckBoxColumn)AddControl(new Guid("67e5d559-3af7-4c55-9aef-493418a3c204"));
            UnitDescription = (ITTTextBoxColumn)AddControl(new Guid("9e2150b1-5966-4bea-8a60-3f33dd791d07"));
            ContensTabPage = (ITTTabPage)AddControl(new Guid("9bb5b4d1-337d-4667-86b3-268d5bd4397f"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("7bcc9c8f-af6d-413c-b808-eabe8c7395b4"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("687a7ff2-7a03-4830-9758-0c740ce1bed5"));
            tttextboxcolumn4 = (ITTTextBoxColumn)AddControl(new Guid("329e6f49-81e7-49e8-a764-7bc52df4d9cd"));
            DistType = (ITTListBoxColumn)AddControl(new Guid("f2defda0-6906-4f0f-829f-25a926c6b185"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("d917c9fa-03e3-42bf-8f83-7f4e7b98c8d3"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("296712f8-f221-4a55-8f7b-faf99f63965d"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("b35d49a4-11a9-4fb5-8645-c499a283bdae"));
            Normal = (ITTCheckBoxColumn)AddControl(new Guid("b9d7883c-fb4c-45d9-868d-fbbe6b2b5f97"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("96cf47e4-d81a-41a3-8a9d-b9a4d1f0ca9a"));
            DemandTabPage = (ITTTabPage)AddControl(new Guid("f3f2d61b-f3da-41e1-b23a-3fc4ed0dca8a"));
            cmdForkDemand = (ITTButton)AddControl(new Guid("6e03b94b-4e9b-48c8-a81c-6c2cfeb4c8d1"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("d3c11a0c-8a39-45f4-987d-6d9a9bb508c0"));
            PurchaseItem = (ITTObjectListBox)AddControl(new Guid("705e03ce-a0bb-4ea1-bb7b-d4e8e9ad6832"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("48e26533-e9fd-43ff-aefd-aae9b60cf391"));
            RepairNotes = (ITTTextBox)AddControl(new Guid("1154a651-81f2-46b2-9a74-2af62a88c502"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("866a8b3c-a65f-4799-b308-c3ce5b262cd5"));
            UnitWorkLoadPrice = (ITTTextBox)AddControl(new Guid("79773fd6-4e93-4c74-ba85-51c3b848b41b"));
            TotalWorkLoad = (ITTTextBox)AddControl(new Guid("bf755f56-1542-40f0-804d-f3f9b8737f88"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("cda4d5af-f8f0-46f2-a359-4e7f26350038"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("b77a9509-6902-4d4e-a83a-2917714e5466"));
            labelTotalWorkLoad = (ITTLabel)AddControl(new Guid("657e47c4-d8d9-4f0d-a2ef-63e42b85e7ee"));
            labelUnitWorkLoadPrice = (ITTLabel)AddControl(new Guid("cde5b878-6ad2-438f-b75d-03534e5939eb"));
            base.InitializeControls();
        }

        public MaterialRepairForm() : base("MATERIALREPAIR", "MaterialRepairForm")
        {
        }

        protected MaterialRepairForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}