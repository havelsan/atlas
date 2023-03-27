
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
    /// HEK'e Ayırma
    /// </summary>
    public partial class HEKForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım
    /// </summary>
        protected TTObjectClasses.Repair _Repair
        {
            get { return (TTObjectClasses.Repair)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage3;
        protected ITTLabel labelProductionDateFixedAssetMaterialDefinition;
        protected ITTLabel labelMaterialPurchasePrice;
        protected ITTDateTimePicker ProductionDateFixedAssetMaterialDefinition;
        protected ITTLabel ttlabel13;
        protected ITTTextBox MaterialPurchasePrice;
        protected ITTLabel labelLaborTotalCost;
        protected ITTLabel labelTotalWorkLoad;
        protected ITTTextBox LaborTotalCost;
        protected ITTLabel labelUnitWorkLoadPrice;
        protected ITTTextBox TotalWorkLoad;
        protected ITTLabel labelRepairTotalCost;
        protected ITTTextBox UnitWorkLoadPrice;
        protected ITTLabel labelMaterialPrice;
        protected ITTTextBox RepairTotalCost;
        protected ITTLabel labelHEKReportNo;
        protected ITTTextBox MaterialPrice;
        protected ITTGrid NeededMaterials;
        protected ITTTextBoxColumn MaterialNameNeededMaterials;
        protected ITTTextBoxColumn PartNumberNeededMaterials;
        protected ITTTextBoxColumn MaterialAmountNeededMaterials;
        protected ITTTextBoxColumn MaterialUnitPriceNeededMaterials;
        protected ITTTextBoxColumn MaterialTotalPriceNeededMaterials;
        protected ITTListBoxColumn RepairNeededMaterials;
        protected ITTTextBox HEKReportNo;
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
        protected ITTRichTextBoxControl TTRichTextBoxUserControl;
        protected ITTTabPage tttabpage5;
        protected ITTRichTextBoxControl HEKReportRepairDetail;
        protected ITTTextBox Description;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox RequestNO;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox tttextbox1;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel8;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel labelDescription;
        protected ITTLabel ttlabel2;
        protected ITTEnumComboBox RepairPlace;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelRequestNO;
        protected ITTObjectListBox ResponsibleResource;
        protected ITTLabel labelFixedAsset;
        protected ITTObjectListBox FixedAsset;
        protected ITTLabel labelFromResource;
        protected ITTLabel labelResponsibleResource;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelToResource;
        protected ITTObjectListBox ToResource;
        protected ITTObjectListBox FromResource;
        protected ITTLabel ttlabel5;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelRequestDate;
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
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("77235229-1864-454f-a492-988ea8afd003"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("640affc1-aebe-4126-9f90-f9ecd0ee5498"));
            labelProductionDateFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("4b3778c2-8cab-4270-88cc-fc4ea3133370"));
            labelMaterialPurchasePrice = (ITTLabel)AddControl(new Guid("31a2e6b3-647a-43b8-9d88-0a31aa724ba4"));
            ProductionDateFixedAssetMaterialDefinition = (ITTDateTimePicker)AddControl(new Guid("edadbb91-faf7-4a0a-8ee4-08f7ebef2492"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("75db81c7-6c48-497b-b3bf-77f009e281f7"));
            MaterialPurchasePrice = (ITTTextBox)AddControl(new Guid("fbcf96b0-81a0-4961-b6f4-dc6bd41555c4"));
            labelLaborTotalCost = (ITTLabel)AddControl(new Guid("2867a439-6227-4f77-bc6e-c6376c853f57"));
            labelTotalWorkLoad = (ITTLabel)AddControl(new Guid("ef011af8-9199-452f-8ebf-7b8f57bc6328"));
            LaborTotalCost = (ITTTextBox)AddControl(new Guid("67cf60d8-4eb4-4feb-bd4a-00fc6a600abf"));
            labelUnitWorkLoadPrice = (ITTLabel)AddControl(new Guid("b4b2b629-924b-42bd-ab90-41fee64e6c77"));
            TotalWorkLoad = (ITTTextBox)AddControl(new Guid("3882f343-7d5a-407e-b450-175e1beb074b"));
            labelRepairTotalCost = (ITTLabel)AddControl(new Guid("88d977aa-89fc-41cc-a88e-906ca335e4f2"));
            UnitWorkLoadPrice = (ITTTextBox)AddControl(new Guid("51dc40f6-85ac-4d97-ab30-2b59006df17a"));
            labelMaterialPrice = (ITTLabel)AddControl(new Guid("b202fa05-a2a5-48de-9475-b3b01aa4bb70"));
            RepairTotalCost = (ITTTextBox)AddControl(new Guid("8611c210-3f06-4807-a202-566d5a2710b0"));
            labelHEKReportNo = (ITTLabel)AddControl(new Guid("fe212289-c282-4474-b7cf-fe0397c40d5a"));
            MaterialPrice = (ITTTextBox)AddControl(new Guid("731199eb-c0af-4618-aaf4-a1f9aae0a0f3"));
            NeededMaterials = (ITTGrid)AddControl(new Guid("628c0fdc-e650-429d-ba10-bd678cd21597"));
            MaterialNameNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("35d32ccd-294d-4a25-98af-e2dbc1a49459"));
            PartNumberNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("73e54b06-5f63-4467-92bf-86e07b0f1b68"));
            MaterialAmountNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("48cfbc19-16d5-42db-907e-8f1098d11ba0"));
            MaterialUnitPriceNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("0545960f-206e-4143-ade3-13717e050b57"));
            MaterialTotalPriceNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("8220c193-fcb7-4177-a71c-ccfcfac57a3b"));
            RepairNeededMaterials = (ITTListBoxColumn)AddControl(new Guid("356ef2b8-2efe-4ccc-a0e0-f45dca87a83c"));
            HEKReportNo = (ITTTextBox)AddControl(new Guid("29be212b-0a3c-4188-a6c9-3e58132f5c82"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("6027cb45-82a6-45dd-bc2d-fa5a8a97dd53"));
            RULHEKReasons = (ITTGrid)AddControl(new Guid("d4454ec3-a2a7-4836-9e5f-f3c96256f63d"));
            CousesOfTheHekDefinitionRULHEKReason = (ITTListBoxColumn)AddControl(new Guid("2fd5d4ae-6e35-40dd-ad22-8a54bd8866d4"));
            CheckRULHEKReason = (ITTCheckBoxColumn)AddControl(new Guid("48d785a7-261b-4661-b868-af34d1307053"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("77d38d51-d241-4b1b-aa23-fef8c7f4b794"));
            HEKCommisionGrid = (ITTGrid)AddControl(new Guid("f1b106ba-607e-47ad-885b-13a6f0b20feb"));
            OrderNo = (ITTTextBoxColumn)AddControl(new Guid("ba24a9cb-4448-43e1-baf4-196bae1a98b3"));
            Rank = (ITTListBoxColumn)AddControl(new Guid("1f632f7d-088f-4011-bdeb-f69f9007a62a"));
            Name = (ITTListBoxColumn)AddControl(new Guid("f50135f5-8087-41e6-b10b-58e3b2cdea8f"));
            Duty = (ITTEnumComboBoxColumn)AddControl(new Guid("850c6468-9837-4630-9bd6-a631876ff989"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("c00da4d6-dcb4-4810-bd74-d172de6f4993"));
            TTRichTextBoxUserControl = (ITTRichTextBoxControl)AddControl(new Guid("ea6759db-93d7-4ca8-9f37-9fa283345956"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("6e25170a-5ece-494b-a804-f0c7347a2c0f"));
            HEKReportRepairDetail = (ITTRichTextBoxControl)AddControl(new Guid("791d4e0b-1545-4953-accc-56897d4478b5"));
            Description = (ITTTextBox)AddControl(new Guid("5a9be302-6c2c-4ce0-ad0d-192e7c2ea525"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("65c8d627-9e65-4b4a-ac84-28df6cf131bc"));
            RequestNO = (ITTTextBox)AddControl(new Guid("a8e091d2-a967-4e2e-a429-52cf0146e410"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("93484a2c-989b-4ce8-b0d7-55f99edf7fdc"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("a8bcb87f-2de5-4dae-9f75-b36556188b5f"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("2b711dc7-c240-4dbd-b4f2-1921c1e072cf"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("836e2161-a39b-42fe-a6be-ec3d2523904b"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("8947f785-7db5-4c1c-b4d9-96151bd06181"));
            labelDescription = (ITTLabel)AddControl(new Guid("002fdc9b-c777-475e-9694-0a6c9bdd95b7"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("601178c1-9069-4771-8ab5-1617bfd48db6"));
            RepairPlace = (ITTEnumComboBox)AddControl(new Guid("e7ed213c-2633-429e-9408-5ef05e1e37f9"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("85ac99ef-8071-4848-9502-6aba12be263b"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("f4825e88-0a18-457c-8fdc-6b8ed6cb4aeb"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("456347c7-a0d6-4514-a4b8-6cc4e1aa8715"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("3a97f39a-3567-49e5-96b9-6d77359d70cc"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("6e033fed-3e62-4655-817a-95fb9f1d3ffa"));
            labelFromResource = (ITTLabel)AddControl(new Guid("fe22ea8c-04f6-41d7-910a-9ad24b365695"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("0d7c1326-3345-4826-8050-9b1871ea80db"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("eea13817-792e-4889-9274-abd99abf4757"));
            labelToResource = (ITTLabel)AddControl(new Guid("9a12c618-2877-4499-ba92-ac06de7d8979"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("a27150c0-e50d-4860-9834-adc58579f760"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("06e4f453-77bd-4d00-b47d-aeeb87fafdab"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("7938b4c3-70c4-4ccf-b8a5-d1d550d8bbdc"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("d4c9135b-4120-4deb-a300-e5113a950f67"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("964eedfe-6b12-4eb6-8195-f64c746beceb"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("67854647-bd3e-47ea-99c7-ffcb42812f53"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("9a708850-7964-4adc-a18b-172081f7dfc3"));
            UserMaintenanceTabPage = (ITTTabPage)AddControl(new Guid("5c263e27-48b1-4ea8-a44d-7a4f87203cc6"));
            UserMaintenances = (ITTGrid)AddControl(new Guid("1246183f-9674-43d3-b3dc-a09a5777b030"));
            UserParameter = (ITTListBoxColumn)AddControl(new Guid("ba7af472-4e8f-4a66-96e2-137ee3f62563"));
            Checked = (ITTCheckBoxColumn)AddControl(new Guid("f8ed1f3d-5477-4b32-859d-3364d8a4cb40"));
            UserDescription = (ITTTextBoxColumn)AddControl(new Guid("b226b57b-a0c6-43ed-b69e-d6eda9899ffe"));
            UnitMaintenanceTabPage = (ITTTabPage)AddControl(new Guid("dfac594c-f7f2-4659-8e1d-44ddbdc22ecf"));
            UnitMaintenances = (ITTGrid)AddControl(new Guid("92e38512-0f33-4420-9590-578393dbfc77"));
            UnitParameter = (ITTListBoxColumn)AddControl(new Guid("baaa78c3-c4ca-48d6-b32c-46f960dac9e9"));
            UnitChecked = (ITTCheckBoxColumn)AddControl(new Guid("f54d4d31-9d89-4c01-9738-edd3010047af"));
            UnitDescription = (ITTTextBoxColumn)AddControl(new Guid("fe12061a-4fcc-4d97-903e-22be697c07ed"));
            ContensTabPage = (ITTTabPage)AddControl(new Guid("6b65df23-aefa-4299-be0c-c5de63178053"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("981dd4fb-7f66-4b15-be0e-13d5c9f56ba7"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("127abb04-c3cd-4260-96a3-79e1c9a32a31"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("8cc67c02-cc5e-4371-9371-ad6f40d5ddc5"));
            DistType = (ITTListBoxColumn)AddControl(new Guid("8355d839-9e05-4287-8089-115bff4fd653"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("c2dea60d-76a5-4c98-bfe7-5fa78b8714c2"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("c65307e2-40d4-4815-b905-2c16bb3b6ecb"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("b2a094d3-d82a-40b2-9c14-fe8d0d23c51b"));
            Normal = (ITTCheckBoxColumn)AddControl(new Guid("154a903e-327b-438b-b8ea-2d712bea01d5"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("029fd2dc-dd91-4cee-939b-b71f5ed1e3f4"));
            base.InitializeControls();
        }

        public HEKForm() : base("REPAIR", "HEKForm")
        {
        }

        protected HEKForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}