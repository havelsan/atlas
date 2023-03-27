
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
    /// İkmal Onay
    /// </summary>
    public partial class SupplyApprovalForm_MaintenanceO : TTForm
    {
    /// <summary>
    /// Şipariş İşlemi
    /// </summary>
        protected TTObjectClasses.MaintenanceOrder _MaintenanceOrder
        {
            get { return (TTObjectClasses.MaintenanceOrder)_ttObject; }
        }

        protected ITTButton cmdSIIB;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox RequestNO;
        protected ITTTextBox OrderNO;
        protected ITTLabel ttlabel10;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTLabel labelFromResource;
        protected ITTObjectListBox OrderTypeList;
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
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTLabel ttlabel11;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage tttabpage4;
        protected ITTGrid UsedConsumedMaterails;
        protected ITTListBoxColumn UsedMaterial;
        protected ITTListBoxColumn UsedMaterialDistType;
        protected ITTTextBoxColumn RequestAmountForDepot;
        protected ITTTextBoxColumn SuppliedAmount;
        protected ITTTextBoxColumn UsedAmount;
        protected ITTTabPage tttabpage5;
        protected ITTGrid UsedMaterialWorkSteps;
        protected ITTListBoxColumn WorkStepUsedMaterial;
        protected ITTListBoxColumn WorkStepUsedMaterialDistType;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UnitAmout;
        protected ITTTextBox ManufacturingAmount;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel labelFixedAssetDefinition;
        protected ITTLabel labelManufacturingAmount;
        override protected void InitializeControls()
        {
            cmdSIIB = (ITTButton)AddControl(new Guid("b947347c-7ac5-4e80-aea8-84ebad84c21c"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("afde03cc-92de-4b35-bc58-0df75b85a4a4"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("bd6087e5-dbe7-4b39-b737-79222344781e"));
            RequestNO = (ITTTextBox)AddControl(new Guid("45e7e6b2-98f0-4de8-b718-669028a4fcc7"));
            OrderNO = (ITTTextBox)AddControl(new Guid("baf82b13-a709-4cbd-b545-5518c919bb97"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("428fc975-b83b-434b-afa2-833d8e34c865"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("387e5d33-0968-4f5f-8b7b-da210573c599"));
            labelFromResource = (ITTLabel)AddControl(new Guid("a609da36-92f6-4251-af73-4582c5c3d7e2"));
            OrderTypeList = (ITTObjectListBox)AddControl(new Guid("47f72a4e-a4d4-4ecc-8d52-14de38ab54d9"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("150ea7aa-7320-4a98-be93-e6179c99a138"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("3f1f4f11-a9b2-4a35-b2ed-85e418ad79c8"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("aa6feb08-6059-4d1b-b92d-5503483853e7"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("5e2a0323-6eb0-4cb1-9efb-5e540edfb157"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("219393ef-3cc4-4bf9-8e1b-4743dac0ca2a"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("b2f1d68e-6118-4c55-b7e9-8f1f79fa6611"));
            labelID = (ITTLabel)AddControl(new Guid("588b7e2a-2d62-4084-9e51-fa583379b062"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("55b15e21-4106-4c2a-ad41-c63c79240879"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("c027368e-1d60-401f-8c20-db0da0525304"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("91ac8630-5723-409a-be8b-ff9efaac80c3"));
            labelOrderName = (ITTLabel)AddControl(new Guid("767dd0cc-42ed-4bd6-9e07-a1ecf56f326c"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("f888dd86-2e31-4e41-95a1-6ab847baa68e"));
            labelActionDate = (ITTLabel)AddControl(new Guid("3adbed10-3386-4629-8e41-444eb76b4f57"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("f8cd9fc3-cc9d-4192-9fc0-5a99705f095c"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("4992529f-fae0-4a9b-bc1b-82b790752a70"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("0b88ea3a-9f90-43d0-bcd6-f90af52f92a2"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("d8454c52-21b5-4987-8034-01968e488618"));
            UsedConsumedMaterails = (ITTGrid)AddControl(new Guid("80771626-b311-49b8-9333-ee28b593031b"));
            UsedMaterial = (ITTListBoxColumn)AddControl(new Guid("b015fb34-68ae-437d-b5cf-5ff1b0990bcc"));
            UsedMaterialDistType = (ITTListBoxColumn)AddControl(new Guid("ba1e4e18-3f4f-4f4d-b345-63ee79768563"));
            RequestAmountForDepot = (ITTTextBoxColumn)AddControl(new Guid("005ffbf6-e153-45c1-92bd-08feb8c27d26"));
            SuppliedAmount = (ITTTextBoxColumn)AddControl(new Guid("655e5285-2505-4183-9150-0c1a6f558ae8"));
            UsedAmount = (ITTTextBoxColumn)AddControl(new Guid("c4e3b60f-1007-4012-992c-0213b1234822"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("85a68eab-601c-4b08-bcd7-0646922d7fa2"));
            UsedMaterialWorkSteps = (ITTGrid)AddControl(new Guid("3eebc5ee-b185-4702-aae2-c3a8e4a3dd32"));
            WorkStepUsedMaterial = (ITTListBoxColumn)AddControl(new Guid("ae9dafd0-49b8-4d4e-a8da-86bdf728af03"));
            WorkStepUsedMaterialDistType = (ITTListBoxColumn)AddControl(new Guid("97983d80-3b7f-4a79-9020-7aad365cff68"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("d9a979f6-cd03-4d80-aed1-f26da4e5ca16"));
            UnitAmout = (ITTTextBoxColumn)AddControl(new Guid("052236a8-8c34-4090-af3d-4798dc7fc489"));
            ManufacturingAmount = (ITTTextBox)AddControl(new Guid("1600c60b-77fe-4878-8c89-c1c2b114b202"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("494effbe-ea71-4c52-b6a8-d504c748b2b5"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("4b9f1851-3b7d-4a08-8310-530bf550c1f2"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("6813a13f-69ef-4fb2-8555-417575b2bf20"));
            labelFixedAssetDefinition = (ITTLabel)AddControl(new Guid("d71aec21-821d-40f6-b5d8-41f6a928ab88"));
            labelManufacturingAmount = (ITTLabel)AddControl(new Guid("e042bb7a-cb5d-4607-ab03-2f143bbd1776"));
            base.InitializeControls();
        }

        public SupplyApprovalForm_MaintenanceO() : base("MAINTENANCEORDER", "SupplyApprovalForm_MaintenanceO")
        {
        }

        protected SupplyApprovalForm_MaintenanceO(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}