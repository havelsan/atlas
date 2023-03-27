
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
    /// Sipariş Açma
    /// </summary>
    public partial class ProductionForm_MaintenanceO : TTForm
    {
    /// <summary>
    /// Şipariş İşlemi
    /// </summary>
        protected TTObjectClasses.MaintenanceOrder _MaintenanceOrder
        {
            get { return (TTObjectClasses.MaintenanceOrder)_ttObject; }
        }

        protected ITTToolStrip tttoolstrip1;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTLabel ttlabel5;
        protected ITTMaskedTextBox RequestNo;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox OrderNO;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox ManufacturingAmount;
        protected ITTTextBox SpecialWorkAmount;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox FixedAsset;
        protected ITTObjectListBox OrderTypeList;
        protected ITTLabel labelOrderName;
        protected ITTLabel ttlabel3;
        protected ITTDateTimePicker CheckDate;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelOrderNO;
        protected ITTLabel labelID;
        protected ITTLabel labelRequestDate;
        protected ITTLabel labelFromResource;
        protected ITTDateTimePicker OrderDate;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelActionDate;
        protected ITTObjectListBox ResDivision;
        protected ITTLabel labelResDivision;
        protected ITTLabel labelOrderStatus;
        protected ITTEnumComboBox OrderStatus;
        protected ITTLabel labelFixedAssetDefinition;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelManufacturingAmount;
        protected ITTLabel labelSpecialWorkAmount;
        override protected void InitializeControls()
        {
            tttoolstrip1 = (ITTToolStrip)AddControl(new Guid("b952d795-b649-427d-b44b-ca79ec9ebca1"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("b8e2f72c-d840-4672-98ca-623783f4b24c"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("a2206223-7613-447c-aa71-e228f9d7445f"));
            RequestNo = (ITTMaskedTextBox)AddControl(new Guid("77cc316b-8e78-4744-8cda-1fae5eea9257"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("f865da63-af0c-4999-aa62-d009cb4916dc"));
            OrderNO = (ITTTextBox)AddControl(new Guid("28deb557-769c-440a-a63b-e584fa77091a"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("6e76e387-8ca6-42a4-9702-bf5d08047432"));
            ManufacturingAmount = (ITTTextBox)AddControl(new Guid("6e5f2b9e-1401-449b-a459-0d3458abfb39"));
            SpecialWorkAmount = (ITTTextBox)AddControl(new Guid("f650b732-5e9f-40d1-9134-7d79acea1c99"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("8e36f810-dee6-4caf-838f-a9d9bd32483c"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("7f43489c-d5f4-4b37-ba96-6428fd79ad96"));
            OrderTypeList = (ITTObjectListBox)AddControl(new Guid("914ad756-da0c-4c6c-8844-7bce1303fdff"));
            labelOrderName = (ITTLabel)AddControl(new Guid("fbd542d5-fda5-45e2-89e7-4c031bade86b"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("e8837da2-6007-4497-ad0b-2fd436ca5d79"));
            CheckDate = (ITTDateTimePicker)AddControl(new Guid("b05baa12-da59-4adf-99a3-4c8137b53443"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("8ebf3f68-fb4f-4533-a89e-f51068ec8739"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("1e5a33e4-4b55-45e7-bcc4-4345d115a3ee"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("6f3d90c9-8ec0-4e73-91a5-a2f466269079"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("b6ef0faa-e713-418c-b9e4-64460bdc4c8b"));
            labelID = (ITTLabel)AddControl(new Guid("b82d9854-124a-4eba-918b-37126637a160"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("8dd6d914-1df8-4cca-8105-77f99fe851f4"));
            labelFromResource = (ITTLabel)AddControl(new Guid("41d69169-dfc2-42d9-a658-d6f4eb29cd8d"));
            OrderDate = (ITTDateTimePicker)AddControl(new Guid("faca7bc9-a233-4fc4-b9e4-8db9b5330b87"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("88089d28-0e8d-4c4a-944e-67ac66e7f319"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("df6da0ae-a182-45db-844e-5e7743434c6e"));
            labelActionDate = (ITTLabel)AddControl(new Guid("4d93234e-5b64-4263-a0b0-e0c9168e4983"));
            ResDivision = (ITTObjectListBox)AddControl(new Guid("f83daae8-34b7-4faa-b7f9-f62fde0c8720"));
            labelResDivision = (ITTLabel)AddControl(new Guid("4f3bd29e-9896-47b5-aaf4-cdebf49e21f7"));
            labelOrderStatus = (ITTLabel)AddControl(new Guid("050b7e6b-b18c-4abb-928a-4862c47dfae4"));
            OrderStatus = (ITTEnumComboBox)AddControl(new Guid("48a122ad-1a98-4412-830a-f05687e9647c"));
            labelFixedAssetDefinition = (ITTLabel)AddControl(new Guid("8f209322-5360-4c46-bc2a-28bdcf444c4e"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("912e3eac-5e69-4d58-bd81-c91b8094be85"));
            labelManufacturingAmount = (ITTLabel)AddControl(new Guid("b38a8eaa-1235-4cd7-a9db-9942bd2cc9e4"));
            labelSpecialWorkAmount = (ITTLabel)AddControl(new Guid("6e31c9f7-9d4a-44ac-90ce-d646fb128708"));
            base.InitializeControls();
        }

        public ProductionForm_MaintenanceO() : base("MAINTENANCEORDER", "ProductionForm_MaintenanceO")
        {
        }

        protected ProductionForm_MaintenanceO(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}