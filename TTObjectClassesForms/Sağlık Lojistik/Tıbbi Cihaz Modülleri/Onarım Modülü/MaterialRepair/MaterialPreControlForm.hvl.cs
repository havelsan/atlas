
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
    /// Ön Kontrol[Stok Numaralı]
    /// </summary>
    public partial class MaterialPreControlForm : RepairBaseForm
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
        protected ITTLabel ttlabel7;
        protected ITTLabel labelFixedAsset;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelFromResource;
        protected ITTObjectListBox ToResource;
        protected ITTLabel labelToResource;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox ResponsibleResource;
        protected ITTLabel labelResponsibleResource;
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
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox FixedAssetMaterialAmount;
        protected ITTTextBox FixedAssetMaterialDesc;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelFixedAssetMaterialAmount;
        protected ITTLabel labelFixedAssetMaterialDesc;
        override protected void InitializeControls()
        {
            RequestNO = (ITTTextBox)AddControl(new Guid("2f214dbd-6abd-41c5-99c9-3a1861837570"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("c4bb9b9f-b137-4334-b805-3d7a44bc0255"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("7273dff4-ef11-42ab-9b59-ff2189f79a58"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("92905a6f-9b25-4747-aea3-b5b00c890bff"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("ffb08d4d-9eed-4cdf-b471-cf145228c365"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("1fb51e47-c836-4db7-af90-da8853b40b57"));
            RepairPlace = (ITTEnumComboBox)AddControl(new Guid("46423610-1e59-4f97-b161-17e3eb4c9042"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("cd7ff083-fb23-449a-8360-9b03913b4827"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("482d4344-71fb-4593-a74a-36da65e757b7"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("0412a395-f7d1-4ab5-a4c6-98db7f44413a"));
            labelFromResource = (ITTLabel)AddControl(new Guid("5e2106e6-713f-4730-8ba7-42acd712e0b1"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("928e8d70-9ac4-4e1c-b240-b653f714c6d4"));
            labelToResource = (ITTLabel)AddControl(new Guid("3d1986ff-80ed-4d86-b3e5-3d27b5d5c28a"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("7367ddfd-f9e2-4d75-94d8-be950e01abd4"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("0672b4f0-54ce-4eff-81e3-4b68ad8e0a4a"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("1599dbd1-8844-4fcb-a0c0-0d9b384b2fe0"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("4917ac18-f280-44df-a0e5-e6775c643883"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("a23ddf43-c87f-433c-bec0-638f066dca6b"));
            UserMaintenanceTabPage = (ITTTabPage)AddControl(new Guid("97b47b6b-c54d-46b6-ac40-0c61c7082775"));
            UserMaintenances = (ITTGrid)AddControl(new Guid("f755afd8-811c-4491-be06-ac9bd84bb439"));
            UserParameter = (ITTListBoxColumn)AddControl(new Guid("873d9f53-8422-4b8e-b4d6-648ba081726b"));
            Checked = (ITTCheckBoxColumn)AddControl(new Guid("4f9a9bda-78f7-4180-a27e-67a41dd65950"));
            UserDescription = (ITTTextBoxColumn)AddControl(new Guid("079e6343-86e3-4b73-ad53-addd796330fa"));
            UnitMaintenanceTabPage = (ITTTabPage)AddControl(new Guid("8ff63893-e8f7-45ab-9f33-d527f386bdcc"));
            UnitMaintenances = (ITTGrid)AddControl(new Guid("6cabb5c1-e085-4446-8f29-ddc3387c6d29"));
            UnitParameter = (ITTListBoxColumn)AddControl(new Guid("6034a2f7-d634-46f8-9c70-6c96faab816d"));
            UnitChecked = (ITTCheckBoxColumn)AddControl(new Guid("ca1bf81c-8828-470d-b629-7bd5b452967d"));
            UnitDescription = (ITTTextBoxColumn)AddControl(new Guid("6e02f7cd-02c5-411f-9025-fa785ce867b4"));
            ContensTabPage = (ITTTabPage)AddControl(new Guid("e4213816-d591-4d2a-995e-412c4fe1854e"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("656715e9-bcbc-4c21-90d7-dfe98d532d7b"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("fe175c8f-f372-41ac-9e36-8ab9d7c29d61"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("69dfb39f-4612-47fe-94a9-758d80feea97"));
            DistType = (ITTListBoxColumn)AddControl(new Guid("2908bab9-8637-4b27-9ac5-dd13b83293b9"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("dbe88622-a6cb-4ab1-9380-baad49ccd14a"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("65fd295f-584b-4961-8b9d-8bdfeffe5ffe"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("631a2958-3af0-42d7-9dd2-8c04de8b34c4"));
            Normal = (ITTCheckBoxColumn)AddControl(new Guid("32623e54-222b-4352-87a2-355f1997fca8"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("c7680d8d-2c75-41c2-b75d-6953169681d6"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("5eee8970-f02f-4270-a886-ba7d7aecf741"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("54ac8be6-7d0a-46e2-90f2-8166a75b281a"));
            FixedAssetMaterialAmount = (ITTTextBox)AddControl(new Guid("69287679-acc4-46e7-b326-8d3774b97f90"));
            FixedAssetMaterialDesc = (ITTTextBox)AddControl(new Guid("718c7a5f-6c02-43a4-a43c-5f7d5d5a909e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("4ce8c7ec-63f5-4328-b7b6-89076c38d5f7"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("edb73d57-f698-41aa-9789-1227d77d067b"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("7c7b7631-a11c-43d4-b9a6-a063c76aeea3"));
            labelFixedAssetMaterialAmount = (ITTLabel)AddControl(new Guid("cca1c837-cf23-4285-bd27-f3c06137adac"));
            labelFixedAssetMaterialDesc = (ITTLabel)AddControl(new Guid("dad1227c-d5e4-497d-ab96-61cb6e248c0d"));
            base.InitializeControls();
        }

        public MaterialPreControlForm() : base("MATERIALREPAIR", "MaterialPreControlForm")
        {
        }

        protected MaterialPreControlForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}