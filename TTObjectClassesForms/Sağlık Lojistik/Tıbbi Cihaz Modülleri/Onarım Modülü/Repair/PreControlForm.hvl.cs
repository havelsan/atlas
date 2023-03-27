
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
    /// Ön Kontrol / Onay
    /// </summary>
    public partial class PreControlForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım
    /// </summary>
        protected TTObjectClasses.Repair _Repair
        {
            get { return (TTObjectClasses.Repair)_ttObject; }
        }

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
        protected ITTTextBox RequestNO;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox Description;
        protected ITTTextBox tttextbox4;
        protected ITTToolStrip tttoolstrip2;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel7;
        protected ITTEnumComboBox RepairPlace;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel GuaranyStatuslabel;
        protected ITTLabel labelDescription;
        protected ITTLabel labelFromResource;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelRequestNO;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelResponsibleResource;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox ToResource;
        protected ITTLabel labelRequestDate;
        protected ITTLabel labelToResource;
        protected ITTObjectListBox ResponsibleResource;
        protected ITTObjectListBox FixedAsset;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("1890187a-ab21-4a6d-86e3-1e89d7fbe1ad"));
            UserMaintenanceTabPage = (ITTTabPage)AddControl(new Guid("4cfb6ef9-e931-4be5-aa80-bbf07f9a3cba"));
            UserMaintenances = (ITTGrid)AddControl(new Guid("f0de8ce2-3d1c-4371-a955-f6c644a6df0d"));
            UserParameter = (ITTListBoxColumn)AddControl(new Guid("a4bdb3a2-3786-4374-9231-64244011b829"));
            Checked = (ITTCheckBoxColumn)AddControl(new Guid("340d3a8d-22b0-4e0b-8c48-2f8e7626c56a"));
            UserDescription = (ITTTextBoxColumn)AddControl(new Guid("c3be732f-49a2-4e7b-a183-4c04438a82e3"));
            UnitMaintenanceTabPage = (ITTTabPage)AddControl(new Guid("234e85a6-a97d-4b79-b3c4-f4efdacfadca"));
            UnitMaintenances = (ITTGrid)AddControl(new Guid("ffccb428-be1c-4df7-9526-1412a1b69c04"));
            UnitParameter = (ITTListBoxColumn)AddControl(new Guid("b53d749b-d104-42c4-8418-926ead40fcc6"));
            UnitChecked = (ITTCheckBoxColumn)AddControl(new Guid("9cf47758-b853-4987-81e8-9e9eb685cbdd"));
            UnitDescription = (ITTTextBoxColumn)AddControl(new Guid("649499ae-170c-4929-b91f-d73d357ebcfe"));
            ContensTabPage = (ITTTabPage)AddControl(new Guid("42fbc978-f850-44aa-b87e-a82bc8cb22bd"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("002a97ac-4a6d-4914-a937-0d1854823f1a"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("61acf331-23ed-4431-a8ab-86434ff16a54"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("1ab75912-6583-473d-8d37-e1c6f7730695"));
            DistType = (ITTListBoxColumn)AddControl(new Guid("89849527-5f6b-4043-9c91-475df705d205"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("c22ccab4-9b6d-4530-b28a-99a5a18ef0be"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("64b46109-cd2b-4d19-bd42-b052f523661d"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("a2dbb17b-42f5-40d5-8644-61e1871dd762"));
            Normal = (ITTCheckBoxColumn)AddControl(new Guid("a8b49868-d9d7-47ab-ac40-55c09dd89e49"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("358e3587-27ae-4a3c-8d43-e78a74a4e708"));
            RequestNO = (ITTTextBox)AddControl(new Guid("ab06720c-0579-434f-9f34-2a06f12fe72e"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("6169eb8e-47c0-4cc2-b200-391f63983faa"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("4b9a9958-ef53-406e-842b-3f54a2764250"));
            Description = (ITTTextBox)AddControl(new Guid("5eba2c9a-546b-4a35-a852-85c6bf3c34b6"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("ba16fb9f-3392-4424-a3ea-928917814967"));
            tttoolstrip2 = (ITTToolStrip)AddControl(new Guid("c5443669-e03b-460c-9be6-cd6f6ccb9826"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("6b923e1e-b453-4af1-8471-7cbc047dcd90"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("c75cb021-973b-4f01-90cc-c13dd79da3e4"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("8850bbae-72b4-4d56-b7d3-7aa25de3e28f"));
            RepairPlace = (ITTEnumComboBox)AddControl(new Guid("8e0de4c3-df8d-44bb-8324-830778aa5e19"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("20114bd7-11a0-40c4-9aab-4978ae499947"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("b35822b2-4f88-48d5-bca6-680d2aebebb4"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("c295f545-9fc2-41a4-b933-2c12650bc7e8"));
            GuaranyStatuslabel = (ITTLabel)AddControl(new Guid("1a12fd39-608d-4633-8aa1-e83d85141256"));
            labelDescription = (ITTLabel)AddControl(new Guid("30a3d2f8-40a5-44c7-84e2-03f9b224daec"));
            labelFromResource = (ITTLabel)AddControl(new Guid("a93efc98-bd57-4f2f-aecb-05b169a97e5c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3b655e8b-86f1-4be3-bc74-1a99108fc349"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("0e372008-d91d-4f60-bf03-39b8de664518"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("e2b3dcfb-a4c5-43e4-900a-4c055cfb61bd"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("67df6109-30c7-445b-a6df-5099f0148e6a"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("7be27d08-82fa-42b7-b2c2-55271d30b466"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("0344ee14-ce01-4bff-9376-59652259292c"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("b533f74e-e914-404f-9425-66fe12bca27e"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("0e449d46-3c59-491d-94c8-72f61667b999"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("24b44ab7-a0d0-48c9-bb23-7b144a307346"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("aa3f09b4-c8dc-44ba-aacf-7b58fd2491e0"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("37ad931e-d95f-49c5-a44e-a9bddff1061d"));
            labelToResource = (ITTLabel)AddControl(new Guid("54026e05-82f4-4d8d-81c2-ec4155f66ef6"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("e8f52503-8ce4-413b-8e4d-fa302b12bf88"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("54fd17bc-c322-4770-a716-ffe59253ce72"));
            base.InitializeControls();
        }

        public PreControlForm() : base("REPAIR", "PreControlForm")
        {
        }

        protected PreControlForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}