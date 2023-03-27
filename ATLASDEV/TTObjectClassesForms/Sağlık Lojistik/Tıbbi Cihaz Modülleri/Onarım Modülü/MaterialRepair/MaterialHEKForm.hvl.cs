
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
    /// HEK [Stok Numaralı]
    /// </summary>
    public partial class MaterialHEKForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım [Stok Numaralı]
    /// </summary>
        protected TTObjectClasses.MaterialRepair _MaterialRepair
        {
            get { return (TTObjectClasses.MaterialRepair)_ttObject; }
        }

        protected ITTDateTimePicker RequestDate;
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
        protected ITTTextBoxColumn Amount;
        protected ITTListBoxColumn DistType;
        protected ITTCheckBoxColumn IsMissing;
        protected ITTCheckBoxColumn IsChanged;
        protected ITTCheckBoxColumn IsDamaged;
        protected ITTCheckBoxColumn Normal;
        protected ITTTextBoxColumn Comments;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ToResource;
        protected ITTLabel labelToResource;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel8;
        protected ITTObjectListBox ResponsibleResource;
        protected ITTLabel labelResponsibleResource;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelFromResource;
        protected ITTEnumComboBox RepairPlace;
        protected ITTLabel ttlabel5;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage3;
        protected ITTLabel labelHEKMaterialAmount;
        protected ITTLabel labelHEKReportNo;
        protected ITTTextBox HEKMaterialAmount;
        protected ITTLabel ttlabel13;
        protected ITTTextBox HEKReportNo;
        protected ITTLabel labelRepairTotalCost;
        protected ITTTextBox RepairTotalCost;
        protected ITTLabel labelLaborTotalCost;
        protected ITTTextBox LaborTotalCost;
        protected ITTLabel labelTotalWorkLoad;
        protected ITTTextBox TotalWorkLoad;
        protected ITTLabel labelUnitWorkLoadPrice;
        protected ITTTextBox UnitWorkLoadPrice;
        protected ITTLabel labelMaterialPrice;
        protected ITTTextBox MaterialPrice;
        protected ITTGrid NeededMaterials;
        protected ITTTextBoxColumn MaterialNameNeededMaterials;
        protected ITTTextBoxColumn PartNumberNeededMaterials;
        protected ITTTextBoxColumn MaterialAmountNeededMaterials;
        protected ITTTextBoxColumn MaterialUnitPriceNeededMaterials;
        protected ITTTextBoxColumn MaterialTotalPriceNeededMaterials;
        protected ITTListBoxColumn RepairNeededMaterials;
        protected ITTTabPage tttabpage4;
        protected ITTGrid RULHEKReasons;
        protected ITTListBoxColumn CousesOfTheHekDefinitionRULHEKReason;
        protected ITTCheckBoxColumn CheckRULHEKReason;
        protected ITTTabPage tttabpage1;
        protected ITTGrid HEKCommisionGrid;
        protected ITTTextBoxColumn OrderNo;
        protected ITTListBoxColumn Rank;
        protected ITTListBoxColumn Name;
        protected ITTEnumComboBoxColumn Duty;
        protected ITTTabPage tttabpage2;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTabPage tttabpage5;
        protected ITTRichTextBoxControl HEKReportRepairDetail;
        protected ITTTextBox RequestNO;
        protected ITTTextBox FixedAssetMaterialAmount;
        protected ITTTextBox FixedAssetMaterialDesc;
        protected ITTLabel labelRequestDate;
        protected ITTLabel labelRequestNO;
        protected ITTLabel labelFixedAsset;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelFixedAssetMaterialAmount;
        protected ITTLabel labelFixedAssetMaterialDesc;
        override protected void InitializeControls()
        {
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("77d74916-fc18-4655-b15f-aab3cc437b5b"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("7b4491f8-8404-42cc-991b-8b27113d89a5"));
            UserMaintenanceTabPage = (ITTTabPage)AddControl(new Guid("dd43a58d-1e1b-41c2-9f59-41eaa17e577b"));
            UserMaintenances = (ITTGrid)AddControl(new Guid("1ac872c0-3ffa-42e2-97ea-072859bd1503"));
            UserParameter = (ITTListBoxColumn)AddControl(new Guid("b6255062-aeeb-45ed-bd7a-2e56f5b74466"));
            Checked = (ITTCheckBoxColumn)AddControl(new Guid("a2efbfa7-e51c-4ae5-adf9-c4ba7905f981"));
            UserDescription = (ITTTextBoxColumn)AddControl(new Guid("1641ca02-8826-460f-886b-1afe9f2ffd85"));
            UnitMaintenanceTabPage = (ITTTabPage)AddControl(new Guid("ad79d864-2181-4928-86ff-d2976982a3b6"));
            UnitMaintenances = (ITTGrid)AddControl(new Guid("bd8da98d-bec2-4fce-aac7-defcfa634a58"));
            UnitParameter = (ITTListBoxColumn)AddControl(new Guid("f9c748be-737d-4947-8d15-55fca296d452"));
            UnitChecked = (ITTCheckBoxColumn)AddControl(new Guid("c3bb1499-0392-4ea3-aa8c-c6becb656973"));
            UnitDescription = (ITTTextBoxColumn)AddControl(new Guid("874bf225-57ce-4a5a-8ca8-de90e4b0817c"));
            ContensTabPage = (ITTTabPage)AddControl(new Guid("1f5a5cb8-640d-43b6-b750-76ccb96b2ea1"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("ea46d7ef-5648-448a-8a8e-4072552cb869"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("b6ca3c94-6e2a-4998-be3b-e53f73ed4bd3"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("6d5e3934-5490-4290-80ce-e604573c3725"));
            DistType = (ITTListBoxColumn)AddControl(new Guid("45260db5-0a58-4249-a70a-d990967b7692"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("72678a52-169e-4978-be63-4b51789cd853"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("7d7f399b-b400-4703-8f0c-074e982a1329"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("62545bea-ca73-43d3-af8a-28a08e8a4990"));
            Normal = (ITTCheckBoxColumn)AddControl(new Guid("436c9f9a-6159-4f36-9541-5cbb486e0e14"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("e882875b-9277-4b25-9a88-1e82dc5f494d"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("e1291a0a-d353-4eb1-8776-294bd34208e8"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("ede5073d-bbc7-4817-954e-bc9bce22001c"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("1749c8bf-c71c-49b1-814b-5cf16ca2ce14"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("acec6291-23c9-4fc1-8e23-8757b9c0bf73"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("49220bf3-37d4-4332-afcb-d5372d5c31b7"));
            labelToResource = (ITTLabel)AddControl(new Guid("69dea975-4a0e-45ec-af37-d4dd832f73b6"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("78855630-a227-489e-a7f1-d93371528fbb"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("8b02ac21-8c17-487c-9b16-598b94c1aa32"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("6f403838-ffc2-4149-ad24-ec6f5fffd794"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("61a470c1-467d-4a56-b13a-fdf6ceebb907"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("38bfb0b4-4104-4610-897e-d86dd1147737"));
            labelFromResource = (ITTLabel)AddControl(new Guid("933644da-9c10-4ade-82f6-2665248da9fa"));
            RepairPlace = (ITTEnumComboBox)AddControl(new Guid("f3e6a530-cb5c-4302-b5ed-2d672853d303"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("ee922a48-a473-4cb0-bd11-5575a867918d"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("f2d37617-ff17-421a-8dd3-f4c30ddfcb26"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("17682cdc-59fb-4863-98fa-169254828a9d"));
            labelHEKMaterialAmount = (ITTLabel)AddControl(new Guid("00f72389-709e-436a-8088-2d4f9ba6c4f4"));
            labelHEKReportNo = (ITTLabel)AddControl(new Guid("e096c28d-ca17-4f28-842a-2db87068a1d3"));
            HEKMaterialAmount = (ITTTextBox)AddControl(new Guid("7632d638-8a1a-47bf-ba3e-91dfa89a526b"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("d2610648-87cd-4cb9-b327-887f226b1aab"));
            HEKReportNo = (ITTTextBox)AddControl(new Guid("f2c76eb0-f013-4526-a9ce-29adb5af3d0e"));
            labelRepairTotalCost = (ITTLabel)AddControl(new Guid("d4537405-4db4-4f9a-8d89-35e29133be7c"));
            RepairTotalCost = (ITTTextBox)AddControl(new Guid("b3683330-5d67-41f7-bdbd-8cd85676c5d0"));
            labelLaborTotalCost = (ITTLabel)AddControl(new Guid("5351ba1b-13f2-4097-839e-570028813b65"));
            LaborTotalCost = (ITTTextBox)AddControl(new Guid("f7c6cf9e-cc22-43f6-bdb9-892cb122aec4"));
            labelTotalWorkLoad = (ITTLabel)AddControl(new Guid("3fdf843c-fc8d-44ae-b7d9-e5781cf24730"));
            TotalWorkLoad = (ITTTextBox)AddControl(new Guid("69595da9-d6e9-4137-9ad0-e08d3d62e6bb"));
            labelUnitWorkLoadPrice = (ITTLabel)AddControl(new Guid("5043b65d-e6e2-4e8a-9602-2f2aba8d9bf5"));
            UnitWorkLoadPrice = (ITTTextBox)AddControl(new Guid("3c7ae824-458c-438d-9eaf-c93ee13d8179"));
            labelMaterialPrice = (ITTLabel)AddControl(new Guid("c5aa9524-0ef2-4b44-bb0e-296a1afac7c2"));
            MaterialPrice = (ITTTextBox)AddControl(new Guid("5c10e24e-1df8-4540-b0c6-1a974d8a616d"));
            NeededMaterials = (ITTGrid)AddControl(new Guid("58f08c49-9299-4849-b624-c93cc3e58176"));
            MaterialNameNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("39071eef-e098-4560-b754-31e74984c049"));
            PartNumberNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("b1721935-1225-40eb-b248-dd9c0f5c154d"));
            MaterialAmountNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("661fffaf-2127-4866-a62c-b05ae2bcfeb3"));
            MaterialUnitPriceNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("dcd0fdac-2276-437f-8a14-f923326895fe"));
            MaterialTotalPriceNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("13afdc0d-a5b6-4191-9b8d-a307599515a1"));
            RepairNeededMaterials = (ITTListBoxColumn)AddControl(new Guid("f750ebb1-1fc5-4ab6-8ed5-1a2624578984"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("f0e0bb78-4505-4ded-a11d-c99dac600127"));
            RULHEKReasons = (ITTGrid)AddControl(new Guid("76bee200-44b7-4f69-a1b0-f65d156324dc"));
            CousesOfTheHekDefinitionRULHEKReason = (ITTListBoxColumn)AddControl(new Guid("c72ab607-7b1c-4c4d-8c8f-f963aa3419a3"));
            CheckRULHEKReason = (ITTCheckBoxColumn)AddControl(new Guid("0f9a0c75-b581-4f7b-8800-d50e01bdfd98"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("929cb981-7898-4bc4-94d9-42814f11283a"));
            HEKCommisionGrid = (ITTGrid)AddControl(new Guid("a4274831-038b-4bff-8a68-4ea7b8eef5a8"));
            OrderNo = (ITTTextBoxColumn)AddControl(new Guid("04edfe54-c4e3-4410-bcf3-85a79cfa4fd8"));
            Rank = (ITTListBoxColumn)AddControl(new Guid("9cefd994-0ae6-4e7b-ae80-7bef49c05b4c"));
            Name = (ITTListBoxColumn)AddControl(new Guid("da321050-9c72-432c-92b8-a6c0604c7f94"));
            Duty = (ITTEnumComboBoxColumn)AddControl(new Guid("2589c306-e568-4f46-8124-52091288351c"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("ba59b576-2347-4ff8-b160-d5becf190af7"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("4a8f2ac5-803b-4832-a778-bb96acdb79db"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("6e177eae-e827-4a57-b9e7-13bee2226bb8"));
            HEKReportRepairDetail = (ITTRichTextBoxControl)AddControl(new Guid("feecbe1e-0210-48e6-8ea4-324a50273e4e"));
            RequestNO = (ITTTextBox)AddControl(new Guid("d4f58c45-f10c-4e95-9e06-15aadd518d42"));
            FixedAssetMaterialAmount = (ITTTextBox)AddControl(new Guid("dfe684d9-090f-4b26-9a49-894114d28230"));
            FixedAssetMaterialDesc = (ITTTextBox)AddControl(new Guid("7cd3f141-2ec5-48b5-bd05-9c8400ab9531"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("7d785e85-44d6-4f31-b996-85c94df74e03"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("7268b2cb-9cfb-45d2-8af1-2ae8791413f6"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("f2a0bac3-68ad-428a-b56a-b9f13299d303"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("ea76e67f-99b3-4ec0-bbf5-1a118b0feb6b"));
            labelFixedAssetMaterialAmount = (ITTLabel)AddControl(new Guid("199d6e5c-8ce5-4fc5-81b2-bc36cbf7c254"));
            labelFixedAssetMaterialDesc = (ITTLabel)AddControl(new Guid("d0512d61-0ebe-41f2-a324-95044cd31f77"));
            base.InitializeControls();
        }

        public MaterialHEKForm() : base("MATERIALREPAIR", "MaterialHEKForm")
        {
        }

        protected MaterialHEKForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}