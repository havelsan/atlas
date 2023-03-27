
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
    /// İlaç Ambalaj Tipi Ekleme
    /// </summary>
    public partial class DrugBarcodeLevelAddForm : TTForm
    {
    /// <summary>
    /// İlaç Ambalaj Tipi Ekleme
    /// </summary>
        protected TTObjectClasses.DrugBarcodeLevelAdd _DrugBarcodeLevelAdd
        {
            get { return (TTObjectClasses.DrugBarcodeLevelAdd)_ttObject; }
        }

        protected ITTGrid MaterialBarcodeLevelsMaterialBarcodeLevel;
        protected ITTTextBoxColumn BarcodeMaterialBarcodeLevel;
        protected ITTTextBoxColumn NameMaterialBarcodeLevel;
        protected ITTTextBoxColumn PackageAmountMaterialBarcodeLevel;
        protected ITTTextBoxColumn CurrentPriceMaterialBarcodeLevel;
        protected ITTDateTimePickerColumn LicenceDateMaterialBarcodeLevel;
        protected ITTTextBoxColumn LicenceNOMaterialBarcodeLevel;
        protected ITTEnumComboBoxColumn LicencingOrganizationMaterialBarcodeLevel;
        protected ITTTextBoxColumn ProductNumberMaterialBarcodeLevel;
        protected ITTTextBoxColumn SPTSDrugIDMaterialBarcodeLevel;
        protected ITTTextBoxColumn SPTSLicencingOrganizationIDMaterialBarcodeLevel;
        protected ITTObjectListBox Material;
        protected ITTLabel labelDrugDefinition;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            MaterialBarcodeLevelsMaterialBarcodeLevel = (ITTGrid)AddControl(new Guid("8fd661c9-9b04-452a-b4e8-c0b7dafa168e"));
            BarcodeMaterialBarcodeLevel = (ITTTextBoxColumn)AddControl(new Guid("2e1d9dc3-7b42-4496-b34b-7f8d99c1ebab"));
            NameMaterialBarcodeLevel = (ITTTextBoxColumn)AddControl(new Guid("2be5cdea-e78a-42fe-8b45-df2965bbb0da"));
            PackageAmountMaterialBarcodeLevel = (ITTTextBoxColumn)AddControl(new Guid("fb5684d0-f573-41b6-aa39-10d2fb07942d"));
            CurrentPriceMaterialBarcodeLevel = (ITTTextBoxColumn)AddControl(new Guid("eef3f39c-92b2-4291-9e6f-71d6796456d8"));
            LicenceDateMaterialBarcodeLevel = (ITTDateTimePickerColumn)AddControl(new Guid("dc92cb32-2b0e-4ab1-a94b-41b43e147ff2"));
            LicenceNOMaterialBarcodeLevel = (ITTTextBoxColumn)AddControl(new Guid("51f7437f-9cf5-4fc3-8a28-83504b490a61"));
            LicencingOrganizationMaterialBarcodeLevel = (ITTEnumComboBoxColumn)AddControl(new Guid("0bcfa03c-ca89-49b9-a695-54c2d21d0dd6"));
            ProductNumberMaterialBarcodeLevel = (ITTTextBoxColumn)AddControl(new Guid("5dabf7c7-b3ac-4a0e-9a20-66b1023a45bc"));
            SPTSDrugIDMaterialBarcodeLevel = (ITTTextBoxColumn)AddControl(new Guid("7227717a-7209-46c1-8c50-e6780ab38f8b"));
            SPTSLicencingOrganizationIDMaterialBarcodeLevel = (ITTTextBoxColumn)AddControl(new Guid("4f851837-a7b6-451d-9097-12e24b2c31c6"));
            Material = (ITTObjectListBox)AddControl(new Guid("6b1096cf-c524-4eee-8368-24fbad02c969"));
            labelDrugDefinition = (ITTLabel)AddControl(new Guid("5f2390b5-2fb9-4ec9-b5d5-1fcea15f9e05"));
            labelID = (ITTLabel)AddControl(new Guid("e5e46416-2fdd-4048-9cf6-9bcdf218a120"));
            ID = (ITTTextBox)AddControl(new Guid("4d8803b0-bcb3-433d-892f-142933d4f901"));
            labelActionDate = (ITTLabel)AddControl(new Guid("9e9f0c5d-0601-4fb6-8273-e717f8934a08"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("c52999a2-237f-4f09-baf4-6f5f62bd40eb"));
            base.InitializeControls();
        }

        public DrugBarcodeLevelAddForm() : base("DRUGBARCODELEVELADD", "DrugBarcodeLevelAddForm")
        {
        }

        protected DrugBarcodeLevelAddForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}