
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
    /// Set Sistem Ünite Tanımlama Talep Forumu
    /// </summary>
    public partial class SetSystemUnitRequestDefForm : TTForm
    {
    /// <summary>
    /// Set Sistem Ünite Tanımlama
    /// </summary>
        protected TTObjectClasses.SetSystemUnitRequestDef _SetSystemUnitRequestDef
        {
            get { return (TTObjectClasses.SetSystemUnitRequestDef)_ttObject; }
        }

        protected ITTTextBox Desciption;
        protected ITTLabel label_Desciption;
        protected ITTGroupBox ttgroupbox2;
        protected ITTTextBox UsePlaces;
        protected ITTLabel labelUsePlaces;
        protected ITTTextBox LifePeriod;
        protected ITTLabel labelCalibrationPeriod;
        protected ITTTextBox UseGoal;
        protected ITTEnumComboBox CalibrationPeriod;
        protected ITTLabel labelUseGoal;
        protected ITTLabel labelMaintenancePeriod;
        protected ITTEnumComboBox IsAdvancedTechnology;
        protected ITTEnumComboBox MaintenancePeriod;
        protected ITTLabel labelIsAdvancedTechnology;
        protected ITTCheckBox NeedMaintenance;
        protected ITTCheckBox NeedCalibration;
        protected ITTLabel labelLifePeriod;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelMarkModelStatus;
        protected ITTEnumComboBox MarkModelStatus;
        protected ITTEnumComboBox DetailSetUnitType;
        protected ITTLabel labelProducer;
        protected ITTLabel labelReferansNo;
        protected ITTTextBox ReferansNo;
        protected ITTTextBox GuarantiePeriod;
        protected ITTObjectListBox Producer;
        protected ITTTextBox TechnicalSpecificationsNo;
        protected ITTTextBox MaterialCategory;
        protected ITTLabel labelTechnicalSpecificationsNo;
        protected ITTLabel labelIsSetSystemUnitFixedAssetMaterialDefinitionDetail;
        protected ITTEnumComboBox BarcodeStatus;
        protected ITTLabel labelGuarantiePeriod;
        protected ITTLabel labelMaterialCategory;
        protected ITTLabel labelGuarantyStatus;
        protected ITTLabel labelBarcodeStatus;
        protected ITTEnumComboBox GuarantyStatus;
        protected ITTTextBox Barcode;
        protected ITTLabel labelGuarantyStartDate;
        protected ITTTextBox Detail;
        protected ITTDateTimePicker GuarantyStartDate;
        protected ITTLabel labelBarcode;
        protected ITTLabel labelDetail;
        protected ITTObjectListBox FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelFixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelFixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail;
        protected ITTObjectListBox FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelDesciption;
        protected ITTObjectListBox FromSite;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelFromSite;
        override protected void InitializeControls()
        {
            Desciption = (ITTTextBox)AddControl(new Guid("30bdd340-43bc-493a-9760-11f8607d21bd"));
            label_Desciption = (ITTLabel)AddControl(new Guid("02473f7b-aac1-41b3-a595-cdf67491f624"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("33d9775f-7f00-4066-bbd7-e7df68bd5d78"));
            UsePlaces = (ITTTextBox)AddControl(new Guid("6e056cc6-1143-4bd2-a267-164db7cda800"));
            labelUsePlaces = (ITTLabel)AddControl(new Guid("c9946f63-3c63-414b-a83d-d234982aba62"));
            LifePeriod = (ITTTextBox)AddControl(new Guid("3012ff01-3121-4ec5-9422-7da430602605"));
            labelCalibrationPeriod = (ITTLabel)AddControl(new Guid("1fcf3dcb-79a9-42ab-95a5-911f92678ec5"));
            UseGoal = (ITTTextBox)AddControl(new Guid("59d4e1d2-a6d8-4a4c-855f-3ad5487a7676"));
            CalibrationPeriod = (ITTEnumComboBox)AddControl(new Guid("80b402e1-1875-4348-9910-d7d1549e0b05"));
            labelUseGoal = (ITTLabel)AddControl(new Guid("abf497e2-315f-4afb-9f2a-f1218fabea99"));
            labelMaintenancePeriod = (ITTLabel)AddControl(new Guid("94b4ae95-6e4d-4e88-a3f2-1ca7e511288e"));
            IsAdvancedTechnology = (ITTEnumComboBox)AddControl(new Guid("c40184bf-1550-44f3-92b3-1c06d5579671"));
            MaintenancePeriod = (ITTEnumComboBox)AddControl(new Guid("06faa1ff-be27-4d0a-b33a-80e67b50107d"));
            labelIsAdvancedTechnology = (ITTLabel)AddControl(new Guid("664c300a-5fe0-4fd5-9fd9-7afad8d9517f"));
            NeedMaintenance = (ITTCheckBox)AddControl(new Guid("3742ebb9-ff70-4d83-8929-5373f4ed8bb6"));
            NeedCalibration = (ITTCheckBox)AddControl(new Guid("f5c58dd3-6d54-4c4f-9a30-468272502f32"));
            labelLifePeriod = (ITTLabel)AddControl(new Guid("290f90d1-83f4-40e1-872c-d43adbb11b3d"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("610f069c-8ae4-410f-89a7-5c8ccc994f11"));
            labelMarkModelStatus = (ITTLabel)AddControl(new Guid("b4647d59-9893-4c4a-9d41-e110ac2f5ee7"));
            MarkModelStatus = (ITTEnumComboBox)AddControl(new Guid("b5ffd63d-1518-4316-98a3-8bb3c7f69a71"));
            DetailSetUnitType = (ITTEnumComboBox)AddControl(new Guid("3815df1a-ed33-4a94-a386-a14b2bdb59c2"));
            labelProducer = (ITTLabel)AddControl(new Guid("769d87c6-0837-4569-a25a-743c11db970b"));
            labelReferansNo = (ITTLabel)AddControl(new Guid("1e84a4c8-2687-461b-87ec-739038d2c8a6"));
            ReferansNo = (ITTTextBox)AddControl(new Guid("23c58983-490f-491d-81d4-f049c656ef23"));
            GuarantiePeriod = (ITTTextBox)AddControl(new Guid("3ccd8f35-d942-496c-997b-f8578950c3df"));
            Producer = (ITTObjectListBox)AddControl(new Guid("982471d8-ba9b-4fa7-ac6f-5082b910d3c5"));
            TechnicalSpecificationsNo = (ITTTextBox)AddControl(new Guid("b15086ee-96e3-4db3-8829-510f40cce0fb"));
            MaterialCategory = (ITTTextBox)AddControl(new Guid("51b15071-f803-4325-8c71-9901c45b2ba3"));
            labelTechnicalSpecificationsNo = (ITTLabel)AddControl(new Guid("71d2f961-4c4b-445e-a3c3-161c384a0bff"));
            labelIsSetSystemUnitFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("fe174e8d-f363-4c1e-8714-a985bebb3e40"));
            BarcodeStatus = (ITTEnumComboBox)AddControl(new Guid("d3e8dda9-9302-458e-b80c-c1495d1e53a8"));
            labelGuarantiePeriod = (ITTLabel)AddControl(new Guid("19bf6d93-1690-47e2-84ce-dd190d07bea1"));
            labelMaterialCategory = (ITTLabel)AddControl(new Guid("cdacbf5f-5485-45f6-8467-90531a210b41"));
            labelGuarantyStatus = (ITTLabel)AddControl(new Guid("89dff05a-a3da-4fe2-9f45-0f635fa51de6"));
            labelBarcodeStatus = (ITTLabel)AddControl(new Guid("d63e9fcf-043b-4725-8891-da9660972b99"));
            GuarantyStatus = (ITTEnumComboBox)AddControl(new Guid("b9fc8471-7dc4-410e-9a38-30ba186b1efd"));
            Barcode = (ITTTextBox)AddControl(new Guid("68906a7b-9bc5-4029-82a0-b99b0fd57351"));
            labelGuarantyStartDate = (ITTLabel)AddControl(new Guid("dc921362-d95f-4f37-bae3-4c5bca7e12c6"));
            Detail = (ITTTextBox)AddControl(new Guid("714412a7-1d32-4822-8c9e-6ea9c95b3ba2"));
            GuarantyStartDate = (ITTDateTimePicker)AddControl(new Guid("b9525a37-cfc6-459f-98be-92e2a9a62397"));
            labelBarcode = (ITTLabel)AddControl(new Guid("565a2893-8374-483e-8b5e-6c8238153fdf"));
            labelDetail = (ITTLabel)AddControl(new Guid("e48d8c30-da03-4096-88ea-b04a147cf01a"));
            FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail = (ITTObjectListBox)AddControl(new Guid("442cd607-5715-42b4-8c46-7843607648a8"));
            labelFixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("4495befd-9137-4190-bc36-bd66db51b675"));
            labelFixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("36929f97-cab7-4e4f-b51d-766ca6e62dce"));
            FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail = (ITTObjectListBox)AddControl(new Guid("56284c2a-0f6d-43ec-99ae-44a58a69b2e1"));
            labelDesciption = (ITTLabel)AddControl(new Guid("41df58d6-5702-4ffc-8504-e9155d2c5015"));
            FromSite = (ITTObjectListBox)AddControl(new Guid("406bd6a3-0e07-4c8d-9b64-fc7ef323e7b5"));
            labelActionDate = (ITTLabel)AddControl(new Guid("915459fc-496b-425f-852e-3ca961098577"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("726cd9cb-a886-4038-bcbe-b6f3f3e479d7"));
            labelFromSite = (ITTLabel)AddControl(new Guid("13afe893-446f-4c45-a564-85a8bf7310a7"));
            base.InitializeControls();
        }

        public SetSystemUnitRequestDefForm() : base("SETSYSTEMUNITREQUESTDEF", "SetSystemUnitRequestDefForm")
        {
        }

        protected SetSystemUnitRequestDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}