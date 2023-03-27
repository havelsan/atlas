
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
    public partial class MaterialMaintenanceApprovalForm : MaintenanceBaseForm
    {
    /// <summary>
    /// Bakım[Stok Numaralı]
    /// </summary>
        protected TTObjectClasses.MaterialMaintenance _MaterialMaintenance
        {
            get { return (TTObjectClasses.MaterialMaintenance)_ttObject; }
        }

        protected ITTLabel labelFixedAssetMaterialDesc;
        protected ITTTextBox FixedAssetMaterialDesc;
        protected ITTTextBox FixedAssetMaterialAmount;
        protected ITTTextBox RequestNO;
        protected ITTLabel labelFixedAssetMaterialAmount;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelRequestNO;
        protected ITTObjectListBox ToResource;
        protected ITTLabel labelToResource;
        protected ITTObjectListBox WorkShop;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelResponsibleResource;
        protected ITTObjectListBox ResponsibleResource;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelFromResource;
        override protected void InitializeControls()
        {
            labelFixedAssetMaterialDesc = (ITTLabel)AddControl(new Guid("fc8fa3d5-e575-42d8-95c6-cb3022149617"));
            FixedAssetMaterialDesc = (ITTTextBox)AddControl(new Guid("88cd6237-d1bb-4080-a425-9a14934aa49e"));
            FixedAssetMaterialAmount = (ITTTextBox)AddControl(new Guid("079a8f8a-792b-410f-9419-fe9fe7102bc7"));
            RequestNO = (ITTTextBox)AddControl(new Guid("012980f9-07fd-466f-8fdd-254c74a0bebf"));
            labelFixedAssetMaterialAmount = (ITTLabel)AddControl(new Guid("b8c31b32-3092-4d28-b923-35e65e780ac4"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("f85c66a7-5d3e-444b-9299-ec0e8fabd0f5"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("4b297e73-6a17-4ae0-9766-fa9a01b5eb61"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("3452c7be-dd46-44d8-b44f-f2910856de84"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("a2ca07ce-065c-41fb-9267-1137bbef958e"));
            labelToResource = (ITTLabel)AddControl(new Guid("73fc0cd5-d3b8-4473-b1aa-21b6ce9746b3"));
            WorkShop = (ITTObjectListBox)AddControl(new Guid("f128541c-20c3-43f7-b9b9-592ade489e10"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("59e22e20-564f-4f70-a1b5-e1820007a83e"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("5910cb6d-c83a-438f-8539-26b58f257cfa"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("c5d60718-5a80-4c00-ad88-b21eda826a0d"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("e3c860f6-5079-410d-97f6-912c34d29f98"));
            labelFromResource = (ITTLabel)AddControl(new Guid("f717a2fc-fb76-4570-bf81-b9da8a616c4a"));
            base.InitializeControls();
        }

        public MaterialMaintenanceApprovalForm() : base("MATERIALMAINTENANCE", "MaterialMaintenanceApprovalForm")
        {
        }

        protected MaterialMaintenanceApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}