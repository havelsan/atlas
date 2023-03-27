
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
    /// Malzeme Temin
    /// </summary>
    public partial class MaterialSupplyOfMaterialForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım [Stok Numaralı]
    /// </summary>
        protected TTObjectClasses.MaterialRepair _MaterialRepair
        {
            get { return (TTObjectClasses.MaterialRepair)_ttObject; }
        }

        protected ITTButton cmdUsedStore;
        protected ITTGrid RepairConsumedMaterials;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn SparePartMaterialDescription;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTTextBoxColumn SuppliedAmount;
        protected ITTTextBoxColumn StoreInheld;
        protected ITTTextBoxColumn Desc;
        protected ITTLabel labelRequestNO;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelStartDate;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelFromResource;
        protected ITTLabel labelFixedAsset;
        protected ITTObjectListBox ToResource;
        protected ITTLabel labelToResource;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel9;
        protected ITTTextBox RequestNO;
        protected ITTTextBox FixedAssetMaterialAmount;
        protected ITTTextBox FixedAssetMaterialDesc;
        protected ITTObjectListBox ResponsibleResource;
        protected ITTLabel labelResponsibleResource;
        protected ITTButton cmdSectionRequirement;
        protected ITTLabel ttlabel13;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelFixedAssetMaterialAmount;
        protected ITTLabel labelFixedAssetMaterialDesc;
        override protected void InitializeControls()
        {
            cmdUsedStore = (ITTButton)AddControl(new Guid("6174ef53-bd4c-4ce6-a680-cedbc3cf989a"));
            RepairConsumedMaterials = (ITTGrid)AddControl(new Guid("22d5608a-c31d-4755-818c-7a8a630c05ba"));
            Material = (ITTListBoxColumn)AddControl(new Guid("8d1467b1-a104-48ac-9f7e-4499d2ad24c2"));
            SparePartMaterialDescription = (ITTTextBoxColumn)AddControl(new Guid("26b3e99c-986a-4f3d-bfba-5c61ead2a5ab"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("f9f3b206-75a9-4f44-92e6-63b1ad9652f7"));
            SuppliedAmount = (ITTTextBoxColumn)AddControl(new Guid("05f65408-1a41-44c1-b672-48a6bc513dfa"));
            StoreInheld = (ITTTextBoxColumn)AddControl(new Guid("ce378a19-3c0e-4c2a-8bc9-0b72794a0d31"));
            Desc = (ITTTextBoxColumn)AddControl(new Guid("73c0489c-2e56-4ab5-86d0-68fd9e8e2fec"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("f0b02dd1-b894-4619-91a3-bf578ad1358f"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("f2fc7985-8cbb-42d9-ae01-8ca165cf1273"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("a85233a9-923f-4cf6-8642-156e32aa4838"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("e6985581-37f3-47c8-bbaf-b03a163853b0"));
            labelStartDate = (ITTLabel)AddControl(new Guid("4399369d-aae6-4952-9e02-b7d7dd4224df"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("5b377e1b-4ad1-4a56-a15c-1babc9ea8d3a"));
            labelFromResource = (ITTLabel)AddControl(new Guid("1be9a5c6-1800-425e-b487-c727bb095101"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("ee691567-23cf-4bfd-b3e3-09c7daa62e51"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("ce496a8c-20f7-4152-aa37-7fd678e750ff"));
            labelToResource = (ITTLabel)AddControl(new Guid("d426276b-cf86-4c72-9d0d-f086ebedf900"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("b011a0e9-e3a1-4812-a42e-3f2256e279fd"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("6cdb7ab8-b95b-4030-8bc6-26fbeeda3d15"));
            RequestNO = (ITTTextBox)AddControl(new Guid("8aee284d-6a14-4c21-a2c5-6ef80215350f"));
            FixedAssetMaterialAmount = (ITTTextBox)AddControl(new Guid("f3341bd1-965d-4863-b20a-2155c1e55044"));
            FixedAssetMaterialDesc = (ITTTextBox)AddControl(new Guid("b70f8ebf-b549-4188-8c6e-2922ccdb92e9"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("1ae56c19-a253-4436-9c21-1be8fb8045e0"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("1d02cccf-76db-4b63-9eb0-1dcbe64a158a"));
            cmdSectionRequirement = (ITTButton)AddControl(new Guid("67197642-6c91-4be0-a12d-83d4a970c2d0"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("a6e8a404-eca8-452d-9e4b-b4a96e82b049"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("edb74223-762e-49f6-aed3-1cf9a9ea8d71"));
            labelFixedAssetMaterialAmount = (ITTLabel)AddControl(new Guid("8b7559f5-8f74-44e2-b79a-d75d2d2c06f6"));
            labelFixedAssetMaterialDesc = (ITTLabel)AddControl(new Guid("bd1c1055-3f61-4e7e-9252-f7719d4e7106"));
            base.InitializeControls();
        }

        public MaterialSupplyOfMaterialForm() : base("MATERIALREPAIR", "MaterialSupplyOfMaterialForm")
        {
        }

        protected MaterialSupplyOfMaterialForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}