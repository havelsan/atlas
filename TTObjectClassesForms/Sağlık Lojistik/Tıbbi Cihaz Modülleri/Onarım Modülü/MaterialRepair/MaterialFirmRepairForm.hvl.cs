
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
    /// Firma Onarım[Stok Numaralı]
    /// </summary>
    public partial class MaterialFirmRepairForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım [Stok Numaralı]
    /// </summary>
        protected TTObjectClasses.MaterialRepair _MaterialRepair
        {
            get { return (TTObjectClasses.MaterialRepair)_ttObject; }
        }

        protected ITTTextBox tttextbox1;
        protected ITTTextBox txtDemandNo;
        protected ITTTextBox txtDemand;
        protected ITTTextBox txtProject;
        protected ITTTextBox txtLast;
        protected ITTTextBox Description;
        protected ITTTextBox RequestNO;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox FixedAssetMaterialAmount;
        protected ITTLabel labelRequestNO;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelFromResource;
        protected ITTEnumComboBox RepairPlace;
        protected ITTLabel ttlabel5;
        protected ITTLabel labelFixedAsset;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel10;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTLabel ttlabel8;
        protected ITTDateTimePicker ttdatetimepicker3;
        protected ITTLabel ttlabel9;
        protected ITTButton cmdSupplierDef;
        protected ITTObjectListBox PurchaseItem;
        protected ITTLabel ttlabel19;
        protected ITTButton cmdForkDemand;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel14;
        protected ITTLabel labelDescription;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel7;
        protected ITTGrid ItemEquipmentsGrid;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount2;
        protected ITTListBoxColumn DistType;
        protected ITTCheckBoxColumn IsMissing;
        protected ITTCheckBoxColumn IsChanged;
        protected ITTCheckBoxColumn IsDamaged;
        protected ITTCheckBoxColumn Normal;
        protected ITTTextBoxColumn Comments;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelFixedAssetMaterialAmount;
        override protected void InitializeControls()
        {
            tttextbox1 = (ITTTextBox)AddControl(new Guid("20eaa4da-a53c-406b-95c3-10b292d15923"));
            txtDemandNo = (ITTTextBox)AddControl(new Guid("9f7b8651-16d3-4116-890c-f22be61acec0"));
            txtDemand = (ITTTextBox)AddControl(new Guid("3d4ad099-7806-4a40-9021-e9ee1ff1ba4f"));
            txtProject = (ITTTextBox)AddControl(new Guid("21239f2c-58ca-4953-a886-3fca4c652ce0"));
            txtLast = (ITTTextBox)AddControl(new Guid("531db9b5-d3c3-4229-ad9d-590366d6f49b"));
            Description = (ITTTextBox)AddControl(new Guid("7ace3085-25f1-4124-abdb-36ca4ff7e131"));
            RequestNO = (ITTTextBox)AddControl(new Guid("90c73f18-7d86-4014-a42b-cc52b1009f06"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("ee6c5122-7e8c-4326-a34b-d8eb3bdabbdc"));
            FixedAssetMaterialAmount = (ITTTextBox)AddControl(new Guid("ebd17620-6134-4626-8b45-4a72bf840553"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("1b863ab0-5049-4145-a43f-0cd4d29bbcf2"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("b81527eb-1749-45a5-a945-3a297debdae6"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("178fbac3-5e6e-4861-974e-a3a5c6664413"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("5d3f2c7d-6831-4499-b560-3b582982afc4"));
            labelFromResource = (ITTLabel)AddControl(new Guid("7ce3fb57-2e43-41bf-aa34-60aaf2b1ebee"));
            RepairPlace = (ITTEnumComboBox)AddControl(new Guid("80637f51-c134-4ce5-a31d-a5117d8b7caf"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("b9dc0e00-5395-4ad4-998b-ea69e0d79faa"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("1b2f5cc9-fc72-4cbc-a035-51ab182df3a3"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("110a0487-a119-4e8b-8c1a-6f21c7c95b2a"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("1723a51b-fe46-474a-a7e8-7b0c3d06c5ac"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("8ecb2234-1111-4a52-bad3-de3e07c47474"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("ba8feea1-4e97-4ee8-bbd6-0e15ae7bab51"));
            ttdatetimepicker3 = (ITTDateTimePicker)AddControl(new Guid("b91c9de8-5907-443e-aba8-7d31eb28444d"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("b9d2cbfb-c385-4add-99cd-0d73390ccdd5"));
            cmdSupplierDef = (ITTButton)AddControl(new Guid("c93462b0-745e-4eb1-9af1-03d440c5632f"));
            PurchaseItem = (ITTObjectListBox)AddControl(new Guid("1211e48a-5e7a-4934-bed7-0076d5c52156"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("0a192869-5d04-4797-96e0-e317294e21f7"));
            cmdForkDemand = (ITTButton)AddControl(new Guid("9f8054df-2e2b-49b8-95de-7249d10b9959"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("6e2b4f3c-f834-402b-960f-07768b827e41"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("a4991960-9b25-4511-abfa-ae68e9b7cc4c"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("a27e750b-7c0c-4bd8-8c0a-2a72e2ba767f"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("aaa7b85a-f3fb-443c-96a5-ef67cf95c96d"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("148c7b7e-b8b4-4403-bfab-fee1de4ba1e8"));
            labelDescription = (ITTLabel)AddControl(new Guid("9231ca54-bc46-4089-9287-33d03ffb0563"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("fbcbb248-4e8a-461a-a201-f11c998fe487"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("2553a9e4-0452-42f8-ac30-1af6757dd0e0"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("1d81c147-d12a-472f-8cf6-95a48e44e3ea"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("c6bdbfa4-2385-4620-b54b-27eb4ae33e3b"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("31adfa68-2643-448c-bf82-c826b09ee001"));
            Amount2 = (ITTTextBoxColumn)AddControl(new Guid("1fc1e363-2c14-46fe-96a7-edfe5942133e"));
            DistType = (ITTListBoxColumn)AddControl(new Guid("7829b7d5-37f1-479e-9c31-c29a004aa896"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("aa37b431-e0d1-4e74-af48-9985342e5fdc"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("48b4c4b9-9d83-4d6a-814f-bedc800596af"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("10ceffe3-d06e-4910-b5b6-cf27548ccc3f"));
            Normal = (ITTCheckBoxColumn)AddControl(new Guid("74ea1127-2bf9-4f7a-8037-2f853648c448"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("d4d46109-36c0-4315-9f12-f34fb83846f0"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("df42c611-bf5f-4d12-afd8-ce6347502723"));
            labelFixedAssetMaterialAmount = (ITTLabel)AddControl(new Guid("4a0c2f53-c1d8-407a-b6aa-f64124190fed"));
            base.InitializeControls();
        }

        public MaterialFirmRepairForm() : base("MATERIALREPAIR", "MaterialFirmRepairForm")
        {
        }

        protected MaterialFirmRepairForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}