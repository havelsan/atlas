
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
    /// Son Kontrol[Stok Numaralı]
    /// </summary>
    public partial class MaterialLastControlForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım [Stok Numaralı]
    /// </summary>
        protected TTObjectClasses.MaterialRepair _MaterialRepair
        {
            get { return (TTObjectClasses.MaterialRepair)_ttObject; }
        }

        protected ITTTextBox RequestNO;
        protected ITTLabel labelRequestNO;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel6;
        protected ITTEnumComboBox RepairPlace;
        protected ITTLabel ttlabel5;
        protected ITTLabel labelFixedAsset;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelFromResource;
        protected ITTObjectListBox ResponsibleResource;
        protected ITTLabel labelResponsibleResource;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelEndDate;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox ToResource;
        protected ITTLabel labelToResource;
        protected ITTButton cmdSIIB;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox tttextbox5;
        protected ITTTextBox tttextbox4;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox FixedAssetMaterialDesc;
        protected ITTLabel labelFixedAssetMaterialDesc;
        protected ITTTabPage tttabpage2;
        protected ITTGrid UsedConsumedMaterails;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTTextBoxColumn SuppliedAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTabPage tttabpage3;
        protected ITTGrid ItemEquipmentsGrid;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount2;
        protected ITTCheckBoxColumn IsMissing;
        protected ITTCheckBoxColumn IsChanged;
        protected ITTCheckBoxColumn IsDamaged;
        protected ITTCheckBoxColumn Normal;
        protected ITTTextBoxColumn Comments;
        protected ITTTabPage tttabpage4;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTabPage tttabpage5;
        protected ITTGrid UserMaintenances;
        protected ITTListBoxColumn ttlistboxcolumn4;
        protected ITTCheckBoxColumn Checked;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTTabPage tttabpage6;
        protected ITTGrid UnitMaintenances;
        protected ITTListBoxColumn Parameter;
        protected ITTCheckBoxColumn UnitChecked;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBox FixedAssetMaterialAmount;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelFixedAssetMaterialAmount;
        override protected void InitializeControls()
        {
            RequestNO = (ITTTextBox)AddControl(new Guid("0abcbea6-1de3-44f2-9d23-01e6462501c7"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("45a41e36-31b2-4c0b-8607-f9ab9a5c2175"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("e3a358eb-da14-4fe8-a2b4-85b6f87e5705"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("155156d6-fc85-4c30-93c9-102432b2dd65"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("c8718f65-2a04-4067-bad1-41f8925bc380"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("864163cc-5fce-4257-ad5e-122124cce8df"));
            RepairPlace = (ITTEnumComboBox)AddControl(new Guid("abb96617-8260-4f65-815a-f555db239999"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("d90fef5d-be24-42d6-8ba3-77d1806faa4b"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("3d202b8a-04c6-4455-be26-834b21028ca8"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("3616d321-b909-41aa-b040-a3f8da98c5e7"));
            labelFromResource = (ITTLabel)AddControl(new Guid("f85ecaaf-7635-44df-9e3a-d0a087e21b11"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("562e3f25-992c-476d-a1d9-621da8db14b3"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("daedb605-92ba-4fcf-8a6c-bf1e62462ecb"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("bd3b72b8-8ac8-4254-a907-803e91d3073f"));
            labelStartDate = (ITTLabel)AddControl(new Guid("300e993f-96b4-4ca1-81d6-c8067ab7ccba"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("9aeff6a6-a3eb-44aa-89eb-c817bd0ef82f"));
            labelEndDate = (ITTLabel)AddControl(new Guid("fd925dad-7067-4e1e-933d-75f7896f91ed"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("b305be69-5b2b-4dec-980d-93f61fa5e7f2"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("6c3b4fda-35f2-4ac6-954f-147738e091ad"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("40f83d5b-105e-4520-a298-1bf26e9650ec"));
            labelToResource = (ITTLabel)AddControl(new Guid("94e128ee-9e0c-45d1-abc7-d7928820eb18"));
            cmdSIIB = (ITTButton)AddControl(new Guid("2abfbd34-9db9-4fa4-b906-f4b47b314a4b"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("8adb8132-a5e0-42a0-93e4-98b033acab72"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("924993e7-c9e9-4fd9-8eea-569c758481b2"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("8d0fdcf8-a78f-49d9-a30d-94fc3f96440c"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("4a4d7bd2-0853-4f12-b018-39083d2ea5cd"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("aa5962fd-bf15-4fa0-9328-6775971071f9"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("fd909ffe-6767-4772-ac2d-f17c5a2682a5"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("2b485291-b566-4d87-80e3-6cac41194d4e"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("3c155bbc-2361-4b45-aa88-98bbc930c305"));
            FixedAssetMaterialDesc = (ITTTextBox)AddControl(new Guid("30c1c708-2e4f-481d-9f0c-af09d6a8b5a4"));
            labelFixedAssetMaterialDesc = (ITTLabel)AddControl(new Guid("0ab6306d-ca03-4294-827b-0dd2391eba8d"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("9455c08e-fde7-461e-a77d-7560ff0e9d4d"));
            UsedConsumedMaterails = (ITTGrid)AddControl(new Guid("6d28c121-f7f2-4b06-8097-9b8a9748f43f"));
            Material = (ITTListBoxColumn)AddControl(new Guid("7565b57b-cab4-4916-ae56-61ee53d1fb36"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("036df7ef-0493-4181-9c41-5075784e414b"));
            SuppliedAmount = (ITTTextBoxColumn)AddControl(new Guid("e571e182-cf03-406c-be34-565ae847b69a"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("bb17a939-b92c-49cc-9b30-ce5e71ca7877"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("d8db4acc-4fe7-47d7-a680-a86490b496b9"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("a148054d-b4db-462b-b89d-02323bb4479e"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("c3ee5d34-4d7f-4710-8fc5-98eac02d2530"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("a40ec199-3d8b-4e29-998d-786b8aff5085"));
            Amount2 = (ITTTextBoxColumn)AddControl(new Guid("aaf19e7f-a49d-400e-a8e9-1241781fc2ce"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("52753643-330d-4750-a01f-5e1c5ba393e0"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("7594e0da-b16b-437d-8e96-18428d0ce3d1"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("e3a26c76-b5ac-45a3-8168-adc1a0128e70"));
            Normal = (ITTCheckBoxColumn)AddControl(new Guid("683cf9df-38b4-46f3-8309-89329e31d8b7"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("3828ad3f-0cf4-42b8-a918-8249ad934997"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("d7edf4ba-6fbd-4458-9906-41d329395c69"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("328234ea-2207-4008-9ca4-ef18d5e64fc2"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("7a20a31d-b4d9-46a6-bb80-58849bcb847a"));
            UserMaintenances = (ITTGrid)AddControl(new Guid("6729def9-aea9-49f1-a843-717fb0b55a56"));
            ttlistboxcolumn4 = (ITTListBoxColumn)AddControl(new Guid("60c84927-867e-43a1-ae24-4d6027858a1b"));
            Checked = (ITTCheckBoxColumn)AddControl(new Guid("6351cff5-2f63-427c-81cf-22252e9e09df"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("20300e75-cabf-465f-bccb-37ade0f69f12"));
            tttabpage6 = (ITTTabPage)AddControl(new Guid("777d9aeb-444f-4973-bc34-79f7278a3c71"));
            UnitMaintenances = (ITTGrid)AddControl(new Guid("53bc2c3c-76c2-4658-892f-b8a38d8cae94"));
            Parameter = (ITTListBoxColumn)AddControl(new Guid("69c1c5c3-ceba-4853-9d32-a2672c30d473"));
            UnitChecked = (ITTCheckBoxColumn)AddControl(new Guid("99f9fc4d-ef1c-4fdd-81b7-d2646c239b2c"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("62e9bb8d-2aa8-4c76-a3d8-2908841f5cd7"));
            FixedAssetMaterialAmount = (ITTTextBox)AddControl(new Guid("603e6487-eed8-4d89-bb4c-2c7ef3901d35"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("7214e639-c238-4966-86c5-f83657095f85"));
            labelFixedAssetMaterialAmount = (ITTLabel)AddControl(new Guid("27df916d-864d-4fd6-8797-351b29d76ecd"));
            base.InitializeControls();
        }

        public MaterialLastControlForm() : base("MATERIALREPAIR", "MaterialLastControlForm")
        {
        }

        protected MaterialLastControlForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}