
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
    public partial class SupplyOfMaterialsForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım
    /// </summary>
        protected TTObjectClasses.Repair _Repair
        {
            get { return (TTObjectClasses.Repair)_ttObject; }
        }

        protected ITTButton cmdSectionRequirement;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel labelRequestDate;
        protected ITTObjectListBox ResponsibleResource;
        protected ITTObjectListBox FromResource;
        protected ITTTextBox Description;
        protected ITTTextBox RequestNO;
        protected ITTLabel ttlabel13;
        protected ITTObjectListBox ToResource;
        protected ITTLabel labelFromResource;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelDescription;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelResponsibleResource;
        protected ITTLabel labelToResource;
        protected ITTObjectListBox FixedAsset;
        protected ITTGrid RepairConsumedMaterials;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn SparePartMaterialDescription;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTTextBoxColumn SuppliedAmount;
        protected ITTTextBoxColumn StoreInheld;
        protected ITTTextBoxColumn Desc;
        protected ITTLabel labelRequestNO;
        protected ITTDateTimePicker RequestDate;
        protected ITTButton cmdUsedStore;
        override protected void InitializeControls()
        {
            cmdSectionRequirement = (ITTButton)AddControl(new Guid("b874a9b8-d1f8-4782-bcee-4521456a2ffb"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("bf77f484-a0b1-422c-a9c2-c526be8c5049"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("0fc22ab0-31d8-46b5-9fd8-bff03a42a2ba"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("40eccf1a-8a00-4418-8f74-1e2920b12bee"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("95896b32-d648-44fb-89e9-260033594ee1"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("63d974f5-cf74-4cc9-bad9-28bc81bb9a3b"));
            Description = (ITTTextBox)AddControl(new Guid("a831d3ee-adba-4a08-84b6-4097beaad331"));
            RequestNO = (ITTTextBox)AddControl(new Guid("01a0088f-f004-44e2-8ee9-40a335ad22a2"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("4ae50d27-61f7-4c08-968e-4a66dc373903"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("b39ffbff-2470-4fd1-8b26-4daf5af883e5"));
            labelFromResource = (ITTLabel)AddControl(new Guid("63250157-aba0-4c3f-8bce-53492913b98b"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("7163e7c6-8b0e-4369-bf69-5ee5a7ce3130"));
            labelDescription = (ITTLabel)AddControl(new Guid("724658a1-7eb1-4b87-8d50-6884ad5f5c7c"));
            labelStartDate = (ITTLabel)AddControl(new Guid("f1d86081-b28e-4013-9d07-6a61c97635c5"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("7f9301c8-12aa-44d8-8651-7a0339bc9d71"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("1695fd1f-f70e-4015-90f5-9dbebbc8f30c"));
            labelToResource = (ITTLabel)AddControl(new Guid("4dd9e201-0231-4ad6-91be-a0e0f7461480"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("cf7ba256-0e60-4658-ab6e-a2f73be479d1"));
            RepairConsumedMaterials = (ITTGrid)AddControl(new Guid("34bcf79f-7fbc-4f4a-891f-beb38a37ffdd"));
            Material = (ITTListBoxColumn)AddControl(new Guid("a262b96c-5a94-4d14-98ed-145aa5fd9dde"));
            SparePartMaterialDescription = (ITTTextBoxColumn)AddControl(new Guid("94319579-97cf-4d6e-baa7-8e6a2896946d"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("d2aafc8b-9749-4c62-b476-af54e9e0e0d9"));
            SuppliedAmount = (ITTTextBoxColumn)AddControl(new Guid("faa665fb-fca3-4f1f-949a-269a26bbea87"));
            StoreInheld = (ITTTextBoxColumn)AddControl(new Guid("96a634fc-eace-4545-88f1-017f7950f4d0"));
            Desc = (ITTTextBoxColumn)AddControl(new Guid("eec5c13a-0090-4a6c-97a8-03543a1cf394"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("cb52a8ba-44bb-484b-8d83-d001efbd9c84"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("f235af8d-aa38-4877-a4c6-ff628080bc54"));
            cmdUsedStore = (ITTButton)AddControl(new Guid("2d8cee46-2e1e-42bf-8b8c-9a00356d7717"));
            base.InitializeControls();
        }

        public SupplyOfMaterialsForm() : base("REPAIR", "SupplyOfMaterialsForm")
        {
        }

        protected SupplyOfMaterialsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}