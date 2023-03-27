
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
    /// Malzeme Temini
    /// </summary>
    public partial class SupplyOfMaterialForm_MaintenanceO : TTForm
    {
    /// <summary>
    /// Şipariş İşlemi
    /// </summary>
        protected TTObjectClasses.MaintenanceOrder _MaintenanceOrder
        {
            get { return (TTObjectClasses.MaintenanceOrder)_ttObject; }
        }

        protected ITTButton cmdUsedStore;
        protected ITTButton cmdSectionRequirement;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox RequestNO;
        protected ITTTextBox OrderNO;
        protected ITTTextBox ManufacturingAmount;
        protected ITTLabel ttlabel10;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTLabel labelFromResource;
        protected ITTObjectListBox OrderTypeList;
        protected ITTGrid RepairConsumedMaterials;
        protected ITTListBoxColumn Material;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn SparePartMaterialDescription;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTTextBoxColumn SuppliedAmount;
        protected ITTTextBoxColumn StoreInheld;
        protected ITTLabel ttlabel3;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelOrderNO;
        protected ITTLabel ttlabel9;
        protected ITTLabel labelRequestDate;
        protected ITTLabel labelID;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelOrderName;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelActionDate;
        protected ITTLabel ttlabel13;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTLabel ttlabel11;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelFixedAssetDefinition;
        protected ITTLabel labelManufacturingAmount;
        protected ITTGrid SectionRequirements;
        protected ITTTextBoxColumn StockActionID;
        protected ITTStateComboBoxColumn State;
        protected ITTLabel ttlabel4;
        override protected void InitializeControls()
        {
            cmdUsedStore = (ITTButton)AddControl(new Guid("31683cbc-ebf9-4ff5-8d91-9ee211ff11aa"));
            cmdSectionRequirement = (ITTButton)AddControl(new Guid("fa2fd859-5e8e-4bb4-97ea-45521b326985"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("36fc8d75-8416-4cca-b0cb-4e0512e335df"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("ea1d0339-253c-433d-b4ba-258881464741"));
            RequestNO = (ITTTextBox)AddControl(new Guid("7a9ac6af-015b-4635-896f-cc4c09ceaae6"));
            OrderNO = (ITTTextBox)AddControl(new Guid("788e2265-665e-4ecc-acf6-79423321abaf"));
            ManufacturingAmount = (ITTTextBox)AddControl(new Guid("fec1fd11-d49b-4a26-aee0-b4837179b279"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("d9e97241-e8a9-4c14-b715-f5d276873931"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("db74ce4e-7ed5-4f41-be96-f9740e45cb67"));
            labelFromResource = (ITTLabel)AddControl(new Guid("eee83a5d-2511-49a5-86dc-4b3f0a1e491b"));
            OrderTypeList = (ITTObjectListBox)AddControl(new Guid("c8b12d56-665d-4c8f-a52d-8f6a42a78a9f"));
            RepairConsumedMaterials = (ITTGrid)AddControl(new Guid("e3494194-8ca4-4930-b25b-6f2da3300b19"));
            Material = (ITTListBoxColumn)AddControl(new Guid("7acd3e1d-1b24-42fa-aa9c-7df7f1b0e754"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("dd6c6159-cab9-4462-839d-09c598deec9e"));
            SparePartMaterialDescription = (ITTTextBoxColumn)AddControl(new Guid("e22d1790-5e06-4a44-b6f2-4f216bd318da"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("a8a70fc5-1a69-46ed-9836-e6991e92b1b7"));
            SuppliedAmount = (ITTTextBoxColumn)AddControl(new Guid("fb82891a-eca8-407b-a82e-9b19c2eb95f7"));
            StoreInheld = (ITTTextBoxColumn)AddControl(new Guid("4bf7c6a1-5968-41e3-9560-cdfdc3637089"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("6956aff9-e667-4938-8d86-8d8977c392e4"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("0b362f27-af11-42f1-8d6f-92ae80ab1261"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d276d87f-643f-464b-8b29-38ccd58bb939"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("d33df394-2744-4cee-b04d-578702daed08"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("c5e53733-17d5-46a8-8eae-4261ddc3d918"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("a49cf9c4-74bf-4e77-9db5-0d1b922cd852"));
            labelID = (ITTLabel)AddControl(new Guid("dc641f42-2991-4575-8903-eea64a42ccef"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("c8f63d9e-2f2a-4879-9c67-3550c520348e"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("ca8a1c02-3339-4239-9c4a-ca925f55b587"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("91639c4a-63b9-4419-8885-43a381b5f0cd"));
            labelOrderName = (ITTLabel)AddControl(new Guid("288054a2-9f41-4197-a213-6e215798d909"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("3addccb7-a13a-494e-a9c0-03c51b7a1d56"));
            labelActionDate = (ITTLabel)AddControl(new Guid("b2631424-0e4f-4c51-b7be-4fca1555ee6a"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("6bab9181-87b2-4f77-9abd-b14173ef41d4"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("5fdaeca2-0e75-4407-bbf1-8ceba57511f1"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("acf625ff-c248-4ff9-9ad8-4c1e045ad0e2"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("3c11ccd2-0569-42ea-84d7-9c6c887787f1"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("17070c1e-937d-403a-8d38-f9e55e282d32"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("1040a411-af03-48a9-a614-98c030f1e8f2"));
            labelFixedAssetDefinition = (ITTLabel)AddControl(new Guid("a234f45f-48a0-4d05-90bb-ac3a17eb6826"));
            labelManufacturingAmount = (ITTLabel)AddControl(new Guid("00db8fb1-95a0-4b8d-87e7-0ee5ab9206ed"));
            SectionRequirements = (ITTGrid)AddControl(new Guid("2534e25f-fcac-4aee-890c-c0c308dea103"));
            StockActionID = (ITTTextBoxColumn)AddControl(new Guid("97d3e994-0496-434e-8005-ae983c7b0d87"));
            State = (ITTStateComboBoxColumn)AddControl(new Guid("75d031e8-e697-451c-8613-49075656ef8e"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("69366b19-760d-443b-9e53-77e3291eed1b"));
            base.InitializeControls();
        }

        public SupplyOfMaterialForm_MaintenanceO() : base("MAINTENANCEORDER", "SupplyOfMaterialForm_MaintenanceO")
        {
        }

        protected SupplyOfMaterialForm_MaintenanceO(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}