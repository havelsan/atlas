
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
    /// Tamam[Stok Numaralı]
    /// </summary>
    public partial class MaterialMaintenanceCompletedForm : MaintenanceBaseForm
    {
    /// <summary>
    /// Bakım[Stok Numaralı]
    /// </summary>
        protected TTObjectClasses.MaterialMaintenance _MaterialMaintenance
        {
            get { return (TTObjectClasses.MaterialMaintenance)_ttObject; }
        }

        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTextBox RequestNO;
        protected ITTTextBox FixedAssetMaterialDesc;
        protected ITTTextBox FixedAssetMaterialAmount;
        protected ITTLabel labelRequestNO;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelFromResource;
        protected ITTObjectListBox ToResource;
        protected ITTLabel labelToResource;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelEndDate;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ResponsibleResource;
        protected ITTLabel labelResponsibleResource;
        protected ITTGrid MaintenanceParameter;
        protected ITTListBoxColumn MaintenanceParameterDefinition;
        protected ITTCheckBoxColumn Check;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelFixedAssetMaterialDesc;
        protected ITTLabel labelFixedAssetMaterialAmount;
        override protected void InitializeControls()
        {
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("374e0bba-b7de-44bc-9c9e-272991727321"));
            RequestNO = (ITTTextBox)AddControl(new Guid("56256120-d402-4c0b-a7b1-9b7476e2a993"));
            FixedAssetMaterialDesc = (ITTTextBox)AddControl(new Guid("7f6fc720-3be6-4b34-a6af-085168805ba1"));
            FixedAssetMaterialAmount = (ITTTextBox)AddControl(new Guid("8da43bfa-9fa0-4efd-86de-a85041edfe30"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("802bf370-d320-49be-a422-4d03d4862e20"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("4c88ccbd-96e5-4b4c-b96d-fc2cb4487ef6"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("b8796b7a-c183-4fae-a13c-b5f0580d42f7"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("8997ca01-6cfb-4cc7-8ce5-f609cbda5911"));
            labelFromResource = (ITTLabel)AddControl(new Guid("b2e57a11-ae56-48d6-aab7-8cfad40a1d27"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("bc014ec6-7f6d-437a-a646-6a572110c794"));
            labelToResource = (ITTLabel)AddControl(new Guid("a1edb323-19c7-4919-ab82-7e563e65d022"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("471b0747-7224-481d-9c39-76d1abc6197c"));
            labelStartDate = (ITTLabel)AddControl(new Guid("a75554fb-ddcc-443a-bc76-ccb6b29191f3"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("f509500e-ae05-41c9-84ff-2afe7f7073eb"));
            labelEndDate = (ITTLabel)AddControl(new Guid("85dec5de-6f74-468d-8e63-1ebc0c65785d"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("09182956-3f22-4985-9ed0-4daa126c1c61"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("32bdb0bc-c554-4c9f-8422-5d40e391a21d"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("8d57c0ec-7bd4-4304-8b67-a624c6869698"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("d0e67645-b7d2-4fc0-9d6b-29526251e02e"));
            MaintenanceParameter = (ITTGrid)AddControl(new Guid("1787a9af-d9c4-4c28-bd29-8b48080b00cf"));
            MaintenanceParameterDefinition = (ITTListBoxColumn)AddControl(new Guid("3d23f8a3-a01f-4611-92a8-5ae756f5d7ac"));
            Check = (ITTCheckBoxColumn)AddControl(new Guid("d9c32a58-8c4c-48e7-bbe0-4d6810046364"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("d1fdbb22-1c03-4ad2-b51a-ea740307a88d"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("0b9af2e8-6aa7-4b89-ab04-782bc640be83"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("332b261f-abcf-4f4c-9839-3fd9000184f1"));
            labelFixedAssetMaterialDesc = (ITTLabel)AddControl(new Guid("d44f1686-825f-4c9d-a7cf-44bba2a1dc0c"));
            labelFixedAssetMaterialAmount = (ITTLabel)AddControl(new Guid("9f13e317-1653-4556-806d-197a21a42296"));
            base.InitializeControls();
        }

        public MaterialMaintenanceCompletedForm() : base("MATERIALMAINTENANCE", "MaterialMaintenanceCompletedForm")
        {
        }

        protected MaterialMaintenanceCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}