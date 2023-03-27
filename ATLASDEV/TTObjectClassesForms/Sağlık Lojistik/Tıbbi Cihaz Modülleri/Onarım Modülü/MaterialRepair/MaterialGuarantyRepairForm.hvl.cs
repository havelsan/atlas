
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
    /// Garanti Onarım[Stok Numaralı]
    /// </summary>
    public partial class MaterialGuarantyRepairForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım [Stok Numaralı]
    /// </summary>
        protected TTObjectClasses.MaterialRepair _MaterialRepair
        {
            get { return (TTObjectClasses.MaterialRepair)_ttObject; }
        }

        protected ITTGrid ItemEquipmentsGrid;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount2;
        protected ITTListBoxColumn DistType;
        protected ITTCheckBoxColumn IsMissing;
        protected ITTCheckBoxColumn IsChanged;
        protected ITTCheckBoxColumn IsDamaged;
        protected ITTCheckBoxColumn Normal;
        protected ITTTextBoxColumn Comments;
        protected ITTLabel labelRequestNO;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelFromResource;
        protected ITTEnumComboBox RepairPlace;
        protected ITTLabel ttlabel5;
        protected ITTLabel labelFixedAsset;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox RequestNO;
        protected ITTTextBox FixedAssetMaterialAmount;
        protected ITTTextBox FixedAssetMaterialDesc;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel10;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTLabel ttlabel8;
        protected ITTDateTimePicker ttdatetimepicker3;
        protected ITTLabel ttlabel9;
        protected ITTButton cmdSupplierDef;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelFixedAssetMaterialAmount;
        protected ITTLabel labelFixedAssetMaterialDesc;
        override protected void InitializeControls()
        {
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("72559a4a-3516-4610-9226-2221fd71548f"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("b2a1b23a-c555-4d35-a129-8360d37c51c4"));
            Amount2 = (ITTTextBoxColumn)AddControl(new Guid("c3cfec9e-35eb-451e-8567-c442973ac619"));
            DistType = (ITTListBoxColumn)AddControl(new Guid("1a6d9723-c9ab-4cae-968e-75b4e03b2156"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("f12e2a9f-b62c-47f0-b0f5-50d4e978a1ce"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("c4f4bca9-33de-4529-84d0-df3e12d136b6"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("d91263e1-dc3b-48a8-827d-d9ec76a0e7f5"));
            Normal = (ITTCheckBoxColumn)AddControl(new Guid("2ca51001-1f14-40e0-834a-6755b25521c2"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("14407013-a7c1-4a7e-b5a8-bcd003ca86b9"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("9b067fbe-0f31-4002-ad39-efa403c8b8e0"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("57ccd497-3937-447d-a707-27244ae945aa"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("eb3223c7-d861-49dc-bf9b-705849b02169"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("c43c08b2-a1c2-4add-a826-8e83c983f07d"));
            labelFromResource = (ITTLabel)AddControl(new Guid("8e64b4a0-e2f3-4e0e-8cca-6923db98f900"));
            RepairPlace = (ITTEnumComboBox)AddControl(new Guid("a7b673a1-bd17-411a-8c81-fb564e1f1338"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("f5799525-5b61-4894-95e2-5ac5655af1d4"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("b63b30ac-7264-4f18-8d42-efe3ce541029"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("4d79afa4-28ae-4a82-9876-21390fe945dc"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("873c5a83-d1ac-4082-9bf5-e571a333206f"));
            RequestNO = (ITTTextBox)AddControl(new Guid("750ef8ea-3387-4356-a013-30bbf3f36645"));
            FixedAssetMaterialAmount = (ITTTextBox)AddControl(new Guid("90125d67-da6b-4574-81c8-0407653aa71a"));
            FixedAssetMaterialDesc = (ITTTextBox)AddControl(new Guid("5a85b9c9-d1df-4b91-a127-d8e6134398ca"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("045cde5c-be2e-4b18-9370-ccf204d48055"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("00274c8c-b8a6-48bc-99f2-0bb94958a69f"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("4c8bcbe9-f4fe-4dd7-80ea-53b1ba32ff3b"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("95332c81-b47d-4897-9961-e3c0ce0f681c"));
            ttdatetimepicker3 = (ITTDateTimePicker)AddControl(new Guid("61588ca7-b46e-4017-a132-c77c5a2fdab3"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("8bfc3bc3-1378-47d3-b9f7-64b586abedc8"));
            cmdSupplierDef = (ITTButton)AddControl(new Guid("c6196bd0-12a7-4afd-826e-084777f1cbf5"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("5b80be20-f1d5-4873-8d88-d6d67e2e0f6a"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("c229867d-7244-4ea1-afb3-d080ce310133"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("21c8413d-5551-4dc6-95ff-f825fcb38466"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("3fc78470-e7bb-4e2e-ad36-a31182406962"));
            labelFixedAssetMaterialAmount = (ITTLabel)AddControl(new Guid("f5630dee-55cf-427d-bdf6-92b2aedf4bf7"));
            labelFixedAssetMaterialDesc = (ITTLabel)AddControl(new Guid("764badda-31b3-4277-b537-cfe6bf09b5f3"));
            base.InitializeControls();
        }

        public MaterialGuarantyRepairForm() : base("MATERIALREPAIR", "MaterialGuarantyRepairForm")
        {
        }

        protected MaterialGuarantyRepairForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}