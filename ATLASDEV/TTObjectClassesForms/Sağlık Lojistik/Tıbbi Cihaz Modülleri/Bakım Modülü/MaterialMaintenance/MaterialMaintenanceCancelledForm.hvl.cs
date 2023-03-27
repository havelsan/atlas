
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
    /// İptal[Stok Numaralı]
    /// </summary>
    public partial class MaterialMaintenanceCancelledForm : MaintenanceBaseForm
    {
    /// <summary>
    /// Bakım[Stok Numaralı]
    /// </summary>
        protected TTObjectClasses.MaterialMaintenance _MaterialMaintenance
        {
            get { return (TTObjectClasses.MaterialMaintenance)_ttObject; }
        }

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
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelFixedAssetMaterialDesc;
        protected ITTLabel labelFixedAssetMaterialAmount;
        override protected void InitializeControls()
        {
            RequestNO = (ITTTextBox)AddControl(new Guid("a8718abc-0f6c-4e69-8930-664141eeaefd"));
            FixedAssetMaterialDesc = (ITTTextBox)AddControl(new Guid("c1696175-94a2-478a-9c53-bc1e3bbbbd0e"));
            FixedAssetMaterialAmount = (ITTTextBox)AddControl(new Guid("a24e1555-784d-4e1e-89b6-94608dad02da"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("b61ec9fa-22d8-4d8f-8c3a-70895972c6f3"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("c6de2958-a22a-43dd-9598-523d0e057b53"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("a6c76bf3-9bc9-471d-9f2c-006f6de65758"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("8f325ef3-455c-4983-a5d5-74a30658b8a6"));
            labelFromResource = (ITTLabel)AddControl(new Guid("1a8fa9aa-6238-43f5-8d26-bb551af7089e"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("01aa9976-c9e5-4079-9b0b-87133ec83cd4"));
            labelToResource = (ITTLabel)AddControl(new Guid("df173170-ea52-4877-8199-0d8a8cdba2cb"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("187978d0-ec90-49c0-a7b4-9ea69a91c1d1"));
            labelStartDate = (ITTLabel)AddControl(new Guid("d758b216-c011-4196-9778-8e392ae5e936"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("b7d474a9-2e0a-47a9-9632-5e8103710cd6"));
            labelEndDate = (ITTLabel)AddControl(new Guid("2730918f-446c-4996-a473-7b4c0f062e41"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("b02f6310-b125-4644-8802-eccaef831c03"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("11a0485c-ad84-43e8-85f8-17ea6e12f8c8"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("b6b00cf8-b5c3-4c24-8ed5-12a579f13a14"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("399b8a82-c6bc-4bc1-b3a7-f1ca2fe19db9"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("ec4319f1-e848-43d9-8401-ba2f400d369e"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("8f65606f-c79a-44ef-8a76-f6fb348e9bd8"));
            labelFixedAssetMaterialDesc = (ITTLabel)AddControl(new Guid("ae32e699-cacd-4049-a7fe-2e4467693a29"));
            labelFixedAssetMaterialAmount = (ITTLabel)AddControl(new Guid("a63ed457-ff6e-4756-8537-6b7e9e6aa624"));
            base.InitializeControls();
        }

        public MaterialMaintenanceCancelledForm() : base("MATERIALMAINTENANCE", "MaterialMaintenanceCancelledForm")
        {
        }

        protected MaterialMaintenanceCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}