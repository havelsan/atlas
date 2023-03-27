
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
    /// Üst Kademeye Sevk
    /// </summary>
    public partial class UpperStageForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım
    /// </summary>
        protected TTObjectClasses.Repair _Repair
        {
            get { return (TTObjectClasses.Repair)_ttObject; }
        }

        protected ITTTextBox RulStatus;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTEnumComboBox RepairPlace;
        protected ITTLabel labelRequestNO;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox RequestNO;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel3;
        protected ITTTextBox Description;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelRequestDate;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelToResource;
        protected ITTObjectListBox FixedAsset;
        protected ITTLabel GuaranyStatuslabel;
        protected ITTLabel labelDescription;
        protected ITTLabel labelResponsibleResource;
        protected ITTLabel labelFromResource;
        protected ITTObjectListBox FromResource;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox ToResource;
        protected ITTDateTimePicker RequestDate;
        protected ITTTextBox tttextbox3;
        protected ITTObjectListBox ResponsibleResource;
        protected ITTLabel ttlabel5;
        protected ITTTextBox tttextbox4;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTLabel labelFromMilitaryUnit;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel8;
        protected ITTObjectListBox ttobjectlistbox3;
        protected ITTObjectListBox WorkShop;
        protected ITTLabel ttlabel9;
        protected ITTTabControl tttabcontrol1;
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
        protected ITTLabel ttlabel7;
        override protected void InitializeControls()
        {
            RulStatus = (ITTTextBox)AddControl(new Guid("b319ae6b-035e-4492-84f8-368a1b55fcff"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("1c85cbc3-0fc9-4b90-a92a-bbf139eb1e9e"));
            RepairPlace = (ITTEnumComboBox)AddControl(new Guid("e2059d64-ccad-4381-a68e-046ebecc979d"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("d4b64ee0-4d53-4072-af0b-0bf4e6de7ed2"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("5a3cf58e-fbc8-461d-9919-113eb01ac18e"));
            RequestNO = (ITTTextBox)AddControl(new Guid("431f53d5-c76a-4feb-9496-2dcaf007f8eb"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("ae3d0547-d03b-4931-bdfc-4aa874b2357c"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("4a0a0ce3-e0ca-4c3a-b201-4fae66714a13"));
            Description = (ITTTextBox)AddControl(new Guid("f241eb76-80b9-4c7a-ae0b-5ae56aadc253"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("0c9a87e5-f351-4d8a-91d3-640cb8438b1e"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("ee48456f-11f4-43b2-9c13-64b065c00f3c"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("680bc825-8425-4364-84a1-6e4e15741ed5"));
            labelToResource = (ITTLabel)AddControl(new Guid("4728c11b-5597-4603-81ca-73961bab12ae"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("bd49e674-26ab-4d04-8689-8ad03e13bceb"));
            GuaranyStatuslabel = (ITTLabel)AddControl(new Guid("f140adb1-3142-443d-a638-90558fd9f9a3"));
            labelDescription = (ITTLabel)AddControl(new Guid("7e1ed89d-4108-40fe-aa66-90c4fc24e2f2"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("5596582d-bbaf-45ac-85dc-91dffc83796b"));
            labelFromResource = (ITTLabel)AddControl(new Guid("f3de548d-1337-43df-af08-a44be1dfccbc"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("9b83862f-ab6c-44f2-8cc3-af748c9c4ddd"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("d3a2ca1f-2801-4e29-a31a-bdbff16cb401"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("d65e4e03-7bd7-46cc-9905-c1994c1600d1"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("e6bdf9d7-4b08-4c50-93f2-cc8fa992591e"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("5de28639-9c4f-4c4f-8284-d6db3a807039"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("9e99e4c8-ae15-4f2e-845d-d9b36e750a21"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("ec4a5b9c-01f3-4acb-bdee-dd7b20d5b58b"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("9bb65039-60dd-40d8-8857-fb08eda536dc"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("e12e2460-04f6-49c2-a90f-ab0432f5881e"));
            labelFromMilitaryUnit = (ITTLabel)AddControl(new Guid("3bdadd2a-de01-4292-bccd-79876451f8c3"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("ef1c46a2-22fd-42bb-93cc-42184774a66b"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("853f11b9-50cc-46dc-afb5-b9869f71bc81"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("1beef030-5e3e-46d5-9dc7-aded2d16336f"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("a382a272-e3a2-46dc-8e68-46610331f630"));
            WorkShop = (ITTObjectListBox)AddControl(new Guid("1db7fa01-a313-4b58-a8b4-6c8d417f3c9a"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("e8e4ffd5-54b8-4c67-a6c3-2e2da4ef7658"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("51fbfdbb-5f4f-47f9-b8e3-5d27d5e1aec9"));
            UserMaintenanceTabPage = (ITTTabPage)AddControl(new Guid("58d36357-27ef-47fb-afe6-ec11b232cfc8"));
            UserMaintenances = (ITTGrid)AddControl(new Guid("f1447fbe-ebf5-491f-8f20-cc331671df87"));
            UserParameter = (ITTListBoxColumn)AddControl(new Guid("5c68a47c-e988-4f66-8de9-d97add4603a8"));
            Checked = (ITTCheckBoxColumn)AddControl(new Guid("b3a944b2-52e4-4718-86c0-33249f337073"));
            UserDescription = (ITTTextBoxColumn)AddControl(new Guid("d44ec202-c4c4-47aa-a8ed-a8bed5aafe4a"));
            UnitMaintenanceTabPage = (ITTTabPage)AddControl(new Guid("58d9dad9-c56a-4b6a-879d-d7538fc57e2d"));
            UnitMaintenances = (ITTGrid)AddControl(new Guid("1a83d067-ee20-443f-a2f7-3d4d4f954dab"));
            UnitParameter = (ITTListBoxColumn)AddControl(new Guid("c535893c-97f6-45f6-8c3a-cc0a8f1a0dea"));
            UnitChecked = (ITTCheckBoxColumn)AddControl(new Guid("17b4050c-f533-4817-89ab-769862831c10"));
            UnitDescription = (ITTTextBoxColumn)AddControl(new Guid("13233ad2-0295-4fc0-9d66-e975fbadc8e2"));
            ContensTabPage = (ITTTabPage)AddControl(new Guid("283f8804-af38-439b-8712-8ad87df12c6c"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("ac7e9c1c-7977-4b4b-9812-0d6a70ab4a1c"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("2190c404-d6bc-4dff-9e8d-bd787b0f5d0c"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("897b481e-1ea6-43b4-8ea1-dc95e1409e33"));
            DistType = (ITTListBoxColumn)AddControl(new Guid("13193dab-580f-4679-a812-b0e4e186f9d0"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("f8485afd-9541-4e90-aeb1-30967f6d19f9"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("863be646-3c23-4b7a-b1dc-346458dd6037"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("a2245adf-ad3d-4381-8a8c-e95a7de87b34"));
            Normal = (ITTCheckBoxColumn)AddControl(new Guid("29608d7d-d591-4450-9b12-08f92b043ef6"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("17773811-0e16-4deb-9b35-a81fb0d143c0"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("aeb6921e-2118-4c25-81c7-0ba55113da6b"));
            base.InitializeControls();
        }

        public UpperStageForm() : base("REPAIR", "UpperStageForm")
        {
        }

        protected UpperStageForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}