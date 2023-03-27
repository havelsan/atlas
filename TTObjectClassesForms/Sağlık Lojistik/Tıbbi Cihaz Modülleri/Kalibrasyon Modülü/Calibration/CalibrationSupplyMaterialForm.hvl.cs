
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
    /// Kalibrasyon
    /// </summary>
    public partial class CalibrationSupplyMaterialForm : CalibrationBaseForm
    {
    /// <summary>
    /// Kalibrasyon
    /// </summary>
        protected TTObjectClasses.Calibration _Calibration
        {
            get { return (TTObjectClasses.Calibration)_ttObject; }
        }

        protected ITTGrid CalibrationConsumedMaterials;
        protected ITTListBoxColumn MaterialCalibrationConsumedMat;
        protected ITTTextBoxColumn SparePartMaterialDescriptionCalibrationConsumedMat;
        protected ITTTextBoxColumn RequestAmountCalibrationConsumedMat;
        protected ITTTextBoxColumn SuppliedAmountCalibrationConsumedMat;
        protected ITTTextBoxColumn StoreInheldCalibrationConsumedMat;
        protected ITTTextBoxColumn DescriptionCalibrationConsumedMat;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel labelResponsibleResource;
        protected ITTLabel labelFixedAsset;
        protected ITTObjectListBox objFixedAssetMaterial;
        protected ITTTextBox RequestNO;
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
            CalibrationConsumedMaterials = (ITTGrid)AddControl(new Guid("80aebb80-4ca8-447d-9d80-c1d567d8e6c4"));
            MaterialCalibrationConsumedMat = (ITTListBoxColumn)AddControl(new Guid("72d10dd6-8002-4b63-92b2-467308987313"));
            SparePartMaterialDescriptionCalibrationConsumedMat = (ITTTextBoxColumn)AddControl(new Guid("8be9613c-4540-41b2-ac5c-fc16d846a6e1"));
            RequestAmountCalibrationConsumedMat = (ITTTextBoxColumn)AddControl(new Guid("bb688b1f-e879-464e-b33e-1cea0d886f19"));
            SuppliedAmountCalibrationConsumedMat = (ITTTextBoxColumn)AddControl(new Guid("ee36f465-8c08-490e-833d-bca6782bb07b"));
            StoreInheldCalibrationConsumedMat = (ITTTextBoxColumn)AddControl(new Guid("8af897e8-1334-4a20-8cf8-05d022a08fed"));
            DescriptionCalibrationConsumedMat = (ITTTextBoxColumn)AddControl(new Guid("25c932c3-6f0d-47bc-a1d1-ffbb96d8169e"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("f171a8a1-6774-4774-b462-e9ec44c92734"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("7f105518-46df-4477-8a7f-8d2efab8ba85"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("6ea7f95c-eb5f-4846-9649-d96a5bcf08f3"));
            objFixedAssetMaterial = (ITTObjectListBox)AddControl(new Guid("59a25a87-4a89-42e5-a47d-5d4f9804947b"));
            RequestNO = (ITTTextBox)AddControl(new Guid("7d28e21d-d46c-4def-ad02-7ff8aa9b2d68"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("8f1bdd21-9e60-42fc-abc6-7f54a3a7de24"));
            WorkShop = (ITTObjectListBox)AddControl(new Guid("672b53e5-1af2-4fa0-8461-b68b9fe57372"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("543d052f-3fd1-44ec-8218-2947c19b8eed"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("32f42dbc-1b0e-4b87-a3b0-bd3c4464fbc5"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("ba4ad689-17f9-4cb0-b4c9-728a118c45bd"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("55d18204-16fa-4bbd-aa99-d7ed090f1c36"));
            labelToResource = (ITTLabel)AddControl(new Guid("ada96b91-0625-4bc7-9769-8a1dc748fc67"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("411c5bda-ac4c-400d-a795-f169eabf6b5c"));
            cmdUsedStore = (ITTButton)AddControl(new Guid("4a68ef76-4563-4182-bbc0-4350cccb94db"));
            base.InitializeControls();
        }

        public CalibrationSupplyMaterialForm() : base("CALIBRATION", "CalibrationSupplyMaterialForm")
        {
        }

        protected CalibrationSupplyMaterialForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}