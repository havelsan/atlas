
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
    /// Kalibrasyon [Stok Numaralı]
    /// </summary>
    public partial class MaterialCalibrationSupplyMaterialForm : CalibrationBaseForm
    {
    /// <summary>
    /// Kalibrasyon [Stok Numaralı]
    /// </summary>
        protected TTObjectClasses.MaterialCalibration _MaterialCalibration
        {
            get { return (TTObjectClasses.MaterialCalibration)_ttObject; }
        }

        protected ITTTextBox RequestNO;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel labelResponsibleResource;
        protected ITTLabel labelFixedAsset;
        protected ITTObjectListBox objFixedAssetMaterial;
        protected ITTGrid CalibrationConsumedMaterials;
        protected ITTListBoxColumn MaterialCalibrationConsumedMat;
        protected ITTTextBoxColumn SparePartMaterialDescriptionCalibrationConsumedMat;
        protected ITTTextBoxColumn RequestAmountCalibrationConsumedMat;
        protected ITTTextBoxColumn SuppliedAmountCalibrationConsumedMat;
        protected ITTTextBoxColumn StoreInheldCalibrationConsumedMat;
        protected ITTTextBoxColumn DescriptionCalibrationConsumedMat;
        protected ITTLabel labelRequestNO;
        protected ITTObjectListBox WorkShop;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox ToResource;
        protected ITTLabel labelToResource;
        protected ITTLabel ttlabel13;
        protected ITTButton cmdUsedStore;
        override protected void InitializeControls()
        {
            RequestNO = (ITTTextBox)AddControl(new Guid("f384d9ea-ba8c-47b3-8ec5-9fef8b2c4d33"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("f384a4b6-2faa-4781-a9bf-2f69e3f7ad45"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("fdac781f-60e8-4e19-9de5-37d277c01d8c"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("d1073022-2ae4-4e26-ab87-88fd799b17bb"));
            objFixedAssetMaterial = (ITTObjectListBox)AddControl(new Guid("6ae2d62e-3c72-4046-8461-e0f4bc1822e2"));
            CalibrationConsumedMaterials = (ITTGrid)AddControl(new Guid("7e54be32-48f2-444a-9889-cf173c51c86f"));
            MaterialCalibrationConsumedMat = (ITTListBoxColumn)AddControl(new Guid("e6ccdf24-059a-45c1-9be1-c82cf4517dea"));
            SparePartMaterialDescriptionCalibrationConsumedMat = (ITTTextBoxColumn)AddControl(new Guid("5524a2c3-8902-4db0-ae50-46056378234c"));
            RequestAmountCalibrationConsumedMat = (ITTTextBoxColumn)AddControl(new Guid("87b0a924-8e2a-402b-bbb3-68098389d145"));
            SuppliedAmountCalibrationConsumedMat = (ITTTextBoxColumn)AddControl(new Guid("a873e304-ed66-4b1e-8be9-bd27be2ea8c5"));
            StoreInheldCalibrationConsumedMat = (ITTTextBoxColumn)AddControl(new Guid("319b3a2b-d9c2-4491-8bd8-35b14e21d509"));
            DescriptionCalibrationConsumedMat = (ITTTextBoxColumn)AddControl(new Guid("f9691768-52bb-46ac-8e16-29b4b8326bf5"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("3c7550a6-175a-4b2f-acd7-a88f68635d6a"));
            WorkShop = (ITTObjectListBox)AddControl(new Guid("8f8909a8-cf71-4a2d-a72e-b2cb6a2d7510"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0848ae38-449d-4feb-a4c8-1c9a390948a2"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("ae6a7b81-68dc-4977-afd7-7a616dc1b42e"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("57be0a8e-9d9d-4395-af90-23eeb47d13d6"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("e755c5dc-a118-4f6b-ac12-c89735b654f1"));
            labelToResource = (ITTLabel)AddControl(new Guid("aebc5087-b5cf-408d-90ec-213b9d900085"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("7a9a4de8-46b6-475b-9e74-90c7d8377f45"));
            cmdUsedStore = (ITTButton)AddControl(new Guid("80cb7628-f9c8-4067-b037-a5f6c2577d2f"));
            base.InitializeControls();
        }

        public MaterialCalibrationSupplyMaterialForm() : base("MATERIALCALIBRATION", "MaterialCalibrationSupplyMaterialForm")
        {
        }

        protected MaterialCalibrationSupplyMaterialForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}