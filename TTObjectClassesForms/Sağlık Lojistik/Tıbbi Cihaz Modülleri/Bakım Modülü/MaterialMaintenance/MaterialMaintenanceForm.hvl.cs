
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
    /// Bakım[Stok Numaralı]
    /// </summary>
    public partial class MaterialMaintenanceForm : MaintenanceBaseForm
    {
    /// <summary>
    /// Bakım[Stok Numaralı]
    /// </summary>
        protected TTObjectClasses.MaterialMaintenance _MaterialMaintenance
        {
            get { return (TTObjectClasses.MaterialMaintenance)_ttObject; }
        }

        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelRequestNO;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelFromResource;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelStartDate;
        protected ITTObjectListBox ToResource;
        protected ITTLabel labelToResource;
        protected ITTObjectListBox WorkShop;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ResponsibleResource;
        protected ITTLabel labelResponsibleResource;
        protected ITTTextBox RequestNO;
        protected ITTTextBox FixedAssetMaterialDesc;
        protected ITTTextBox FixedAssetMaterialAmount;
        protected ITTLabel ttlabel9;
        protected ITTGrid MaintenanceParameter;
        protected ITTListBoxColumn MaintenanceParameterDefinition;
        protected ITTCheckBoxColumn Check;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelFixedAssetMaterialDesc;
        protected ITTLabel labelFixedAssetMaterialAmount;
        override protected void InitializeControls()
        {
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("31aee394-5fc4-43c8-b58a-c37f527780aa"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("8ea296c4-4a9a-4bf6-8213-eb05af7c664c"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("3013a58c-e59e-4c9f-8234-6646ee6adeb3"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("301c4442-3620-4e23-ab7f-9922ccbcc279"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("86a4523f-e41d-4220-8c37-4ffa2edfe877"));
            labelFromResource = (ITTLabel)AddControl(new Guid("dd24e4ce-d983-4ea2-b920-6e43f48a58c7"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("745d825a-f611-4b55-b29f-ae3a469b6b67"));
            labelStartDate = (ITTLabel)AddControl(new Guid("352c14e5-95b7-4cc1-96dd-8af0366fb0c9"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("b704b01e-4c93-48d5-936d-93dd88c0e3f5"));
            labelToResource = (ITTLabel)AddControl(new Guid("9fe8fc4b-474b-4cfc-9248-0cf79759d691"));
            WorkShop = (ITTObjectListBox)AddControl(new Guid("72b3c3c7-e89a-4ee7-88eb-e34bb816002e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("71938e76-0c25-4d21-a426-595f61eaaef8"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("bf7eea7d-5c66-40b2-86d4-f4cda93c8306"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("279cecc8-1658-4b15-b999-3ce0b3e18e4c"));
            RequestNO = (ITTTextBox)AddControl(new Guid("ccaa1828-94a9-4abb-8da0-c6420c0eff44"));
            FixedAssetMaterialDesc = (ITTTextBox)AddControl(new Guid("8c1d3edc-3556-43e7-8f08-3281e4a3e604"));
            FixedAssetMaterialAmount = (ITTTextBox)AddControl(new Guid("dd135fd4-a5c4-4427-affd-0fd3a04f21a2"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("16387047-2a04-4259-a19f-f798df460b98"));
            MaintenanceParameter = (ITTGrid)AddControl(new Guid("2aac9d8b-aaf9-462f-843d-b9724c710bf4"));
            MaintenanceParameterDefinition = (ITTListBoxColumn)AddControl(new Guid("bca4fa3d-a808-45bb-8b15-81239cf8dce7"));
            Check = (ITTCheckBoxColumn)AddControl(new Guid("8b049889-f76d-4944-a834-ed609e795a26"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("58a5e708-a2f1-42d5-b910-239f682010dc"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("6936d86d-5d02-481d-8c41-39a844b8103e"));
            labelFixedAssetMaterialDesc = (ITTLabel)AddControl(new Guid("bd617df8-84fa-4ae2-b6a3-0a4357cc1df3"));
            labelFixedAssetMaterialAmount = (ITTLabel)AddControl(new Guid("c7e9ece2-6c04-4e23-bfb7-0fe24bcfe707"));
            base.InitializeControls();
        }

        public MaterialMaintenanceForm() : base("MATERIALMAINTENANCE", "MaterialMaintenanceForm")
        {
        }

        protected MaterialMaintenanceForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}