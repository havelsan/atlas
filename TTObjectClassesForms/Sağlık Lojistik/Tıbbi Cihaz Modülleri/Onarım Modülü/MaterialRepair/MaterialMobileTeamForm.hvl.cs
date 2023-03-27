
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
    /// Seyyar Ekip[Stok Numaralı]
    /// </summary>
    public partial class MaterialMobileTeam : RepairBaseForm
    {
    /// <summary>
    /// Onarım [Stok Numaralı]
    /// </summary>
        protected TTObjectClasses.MaterialRepair _MaterialRepair
        {
            get { return (TTObjectClasses.MaterialRepair)_ttObject; }
        }

        protected ITTEnumComboBox RepairPlace;
        protected ITTLabel ttlabel2;
        protected ITTTextBox tttextbox5;
        protected ITTLabel ttlabel8;
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
        protected ITTTextBox Description;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelDescription;
        protected ITTLabel ttlabel1;
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
        protected ITTTextBox RulStatus;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox RequestNO;
        protected ITTTextBox RepairNotes;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelStartDate;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTLabel labelFromMilitaryUnit;
        protected ITTObjectListBox UpperStage;
        protected ITTLabel ttlabel11;
        protected ITTObjectListBox ttobjectlistbox3;
        protected ITTLabel ttlabel12;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelRequestNO;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox ToResource;
        protected ITTLabel labelToResource;
        protected ITTObjectListBox WorkShop;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelFromResource;
        protected ITTObjectListBox FixedAssetDefinition;
        override protected void InitializeControls()
        {
            RepairPlace = (ITTEnumComboBox)AddControl(new Guid("2e16dfde-dc4a-46a6-8979-661ab66d46f3"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("63c8b02a-00b0-4f57-b1d7-6394992526e5"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("cff27163-abb1-4bd7-8fcf-a9578ba5e8cb"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("fd40691a-8787-4e06-99b7-71f6bbebe2c4"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("e37ba792-a0b4-4a6d-b979-47c7cad9de0a"));
            UserMaintenanceTabPage = (ITTTabPage)AddControl(new Guid("126229d3-03bc-436e-b301-d0f35a5cbb3c"));
            UserMaintenances = (ITTGrid)AddControl(new Guid("d8c182e7-a50a-46c6-86cf-612e861ebf48"));
            UserParameter = (ITTListBoxColumn)AddControl(new Guid("0d922e4d-b49b-488c-9492-471e11b6b152"));
            Checked = (ITTCheckBoxColumn)AddControl(new Guid("e67cf57a-6a84-49d4-b465-2f443ef8c4a4"));
            UserDescription = (ITTTextBoxColumn)AddControl(new Guid("c5454b89-10e9-40f5-aa4b-d8b5e1102bc9"));
            UnitMaintenanceTabPage = (ITTTabPage)AddControl(new Guid("6446e014-315e-4f88-bdc6-e2f161103979"));
            UnitMaintenances = (ITTGrid)AddControl(new Guid("13c9f668-13fa-4d1e-b1e2-600cc14a79b4"));
            UnitParameter = (ITTListBoxColumn)AddControl(new Guid("0296ebb7-516d-4386-a120-f670b30305bd"));
            UnitChecked = (ITTCheckBoxColumn)AddControl(new Guid("a9ed90d8-0c7d-49dc-ae6b-4088325f1acb"));
            UnitDescription = (ITTTextBoxColumn)AddControl(new Guid("193cf252-1eee-417a-afc4-626708992ec2"));
            ContensTabPage = (ITTTabPage)AddControl(new Guid("233ac258-8e87-4df0-8afd-76127e32f189"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("737e6b65-af9d-4181-b74b-879b48ced29c"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("4f00efe7-3e43-4273-b27e-5c07bae883e3"));
            tttextboxcolumn4 = (ITTTextBoxColumn)AddControl(new Guid("3acd0319-cae3-49d3-a25a-ecd8657446cb"));
            DistType = (ITTListBoxColumn)AddControl(new Guid("e6bbb0fa-9087-49c9-9abb-c3896fe9c7a9"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("d290b089-1956-4115-b0e3-18de2b4d34a0"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("849d45cd-171b-424b-bbad-8199df43bb73"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("8d009b6b-ec84-444f-874e-8825246b9068"));
            Normal = (ITTCheckBoxColumn)AddControl(new Guid("5152ce2e-a8f1-4778-81e7-eed3351df45c"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("0dac34c8-8a5c-425b-9dcc-3f19e1d093d9"));
            Description = (ITTTextBox)AddControl(new Guid("82e98c64-9b77-42f9-a684-2516310f2661"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("638fcaf9-8633-452d-a2c6-55cdc29401cc"));
            labelDescription = (ITTLabel)AddControl(new Guid("694d3af8-016e-434c-b832-e09a08ea0e6d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("1136db0d-2186-4f24-a91e-5d2957edcf31"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("38a1e9f1-5e99-4303-a3c7-8291e2050de5"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("13c7de54-e4e5-4289-9b56-052e6aeabc81"));
            RepairConsumedMaterials = (ITTGrid)AddControl(new Guid("ec16532e-af81-4788-a93b-6f7b1ac2eced"));
            Material = (ITTListBoxColumn)AddControl(new Guid("2c937c02-6141-45d9-a46f-ee20efc2cc89"));
            SparePartMaterialDescription = (ITTTextBoxColumn)AddControl(new Guid("deff6f9e-cf45-4769-adb0-3c31d20ba549"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("2a5f3246-89b3-4d68-9379-1ca8536090d1"));
            Desc = (ITTTextBoxColumn)AddControl(new Guid("ab0138f8-0c4c-4efc-bea8-68876627e971"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("73aa7cf0-0b28-46c2-898b-33228f04ab59"));
            UsedConsumedMaterails = (ITTGrid)AddControl(new Guid("4a8d4ab7-d35b-4535-aa80-5ff6cecd5a1b"));
            UsedMaterial = (ITTListBoxColumn)AddControl(new Guid("90cc07b1-20bb-4227-962e-4afe4fb1364e"));
            UsedRequestAmount = (ITTTextBoxColumn)AddControl(new Guid("3847a57e-8cd2-447b-bac0-d6fe84328554"));
            UsedSuppliedAmount = (ITTTextBoxColumn)AddControl(new Guid("8ce1947a-0805-425e-87ea-693e4e872e7b"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("4ac9e7a8-0d07-430e-9f40-d4ae76926840"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("2715d211-1a2c-4dd3-8baf-f10bebbcce65"));
            RulStatus = (ITTTextBox)AddControl(new Guid("f652d25b-2b01-4a92-b577-786e7da2d3ff"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("58b098e9-b95f-4c12-bf91-414d5d3741ed"));
            RequestNO = (ITTTextBox)AddControl(new Guid("6eb5fd40-b976-4421-8adf-61b11da47115"));
            RepairNotes = (ITTTextBox)AddControl(new Guid("0db365df-3ba2-4f5b-93c4-4dd1e9a2f0e9"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("bafdbff5-d682-4292-bdf4-99aee8250242"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("f65e42e3-14cd-4235-9cfd-6680da0251df"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("3891ad29-952c-48b7-bd1a-512a15ca9301"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("ad74a772-c3b7-4261-95e3-665eae8aa86a"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("de2ab5eb-1840-4693-bcaa-555e9a51a391"));
            labelStartDate = (ITTLabel)AddControl(new Guid("cd4ffebc-b96f-4ae3-a8c3-771690c0d041"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("4fb4ac31-2037-499b-9b0d-1bda4aacfd93"));
            labelFromMilitaryUnit = (ITTLabel)AddControl(new Guid("44a448af-bc63-4994-af43-73dccf350b94"));
            UpperStage = (ITTObjectListBox)AddControl(new Guid("950d5a06-a73e-4996-aaf2-f0a12cf2120d"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("58c4a05e-1501-44ae-b291-b1cf2daff877"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("5739ba38-26ab-4bc3-8919-7806f3bce724"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("31af2fd0-1548-478d-b85b-3149e07994e3"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("89772cf7-ec0a-44d1-8a49-75ee3092d3c8"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("542ddfa6-2ec8-4c1e-97ab-272acbb280c3"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("850e9cb8-4cbf-4fc6-9727-c8e633e5ded9"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("c5444557-12e6-408a-9ae5-823f9c181a97"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("74d52fb2-ef15-47fc-b286-c1996a4fee7c"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("24ad732a-8046-4a2a-8ad1-0b8ec4ac7660"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("7f81339a-50cd-4d25-baf7-a991baa19fb0"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("3aa328b5-379c-4957-a97d-13d883d3e998"));
            labelToResource = (ITTLabel)AddControl(new Guid("0ac477a7-d8be-4abc-bc19-c266357600c2"));
            WorkShop = (ITTObjectListBox)AddControl(new Guid("64478829-bb23-4f77-8959-a18182112716"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("14d9b4ed-b412-4c32-8d7d-106d123ce20d"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("3c425501-50a3-4714-9ab5-e90efbd5503e"));
            labelFromResource = (ITTLabel)AddControl(new Guid("129ba1b2-72a4-46a9-9c04-9078199a4d62"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("5de998da-8323-4397-b54d-f7ccee569220"));
            base.InitializeControls();
        }

        public MaterialMobileTeam() : base("MATERIALREPAIR", "MaterialMobileTeam")
        {
        }

        protected MaterialMobileTeam(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}