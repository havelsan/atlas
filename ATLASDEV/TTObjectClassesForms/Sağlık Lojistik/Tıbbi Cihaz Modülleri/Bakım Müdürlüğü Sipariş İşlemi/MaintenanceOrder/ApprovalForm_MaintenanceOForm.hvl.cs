
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
    /// Sipariş Onay
    /// </summary>
    public partial class ApprovalForm_MaintenanceO : TTForm
    {
    /// <summary>
    /// Şipariş İşlemi
    /// </summary>
        protected TTObjectClasses.MaintenanceOrder _MaintenanceOrder
        {
            get { return (TTObjectClasses.MaintenanceOrder)_ttObject; }
        }

        protected ITTTextBox tttextbox2;
        protected ITTTextBox OrderNo;
        protected ITTTextBox RequestNo;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox ManufacturingAmount;
        protected ITTTextBox SpecialWorkAmount;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelOrderName;
        protected ITTLabel ttlabel3;
        protected ITTDateTimePicker CheckDate;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelOrderNO;
        protected ITTLabel labelID;
        protected ITTLabel labelRequestDate;
        protected ITTLabel labelFromResource;
        protected ITTDateTimePicker OrderDate;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelActionDate;
        protected ITTObjectListBox OrderTypeList;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox ResDivision;
        protected ITTLabel labelResDivision;
        protected ITTEnumComboBox OrderStatus;
        protected ITTLabel labelOrderStatus;
        protected ITTObjectListBox FixedAsset;
        protected ITTLabel labelManufacturingAmount;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelFixedAssetDefinition;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelSpecialWorkAmount;
        override protected void InitializeControls()
        {
            tttextbox2 = (ITTTextBox)AddControl(new Guid("70ae9b2d-fb84-4a2f-9649-c5ec8ec1ef65"));
            OrderNo = (ITTTextBox)AddControl(new Guid("519b5cc5-dfe9-456c-93cc-cc64566ad2e4"));
            RequestNo = (ITTTextBox)AddControl(new Guid("628e7a6e-b7d1-4b87-82af-0c206a5725f2"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("db7a02cb-8129-4c15-9d75-5a64d12cbbe6"));
            ManufacturingAmount = (ITTTextBox)AddControl(new Guid("dc8cab5c-d424-422b-9a30-955facdd2ed8"));
            SpecialWorkAmount = (ITTTextBox)AddControl(new Guid("cd632b77-ea73-45c5-9867-fe372a9f5ec1"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("bf623816-43f0-40b8-b3db-98918d448d23"));
            labelOrderName = (ITTLabel)AddControl(new Guid("bb406402-3168-4a67-9787-5dc4a0eb85a9"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("c6e7c04e-5dd9-496b-8f17-e918f0fa9055"));
            CheckDate = (ITTDateTimePicker)AddControl(new Guid("fcb08041-bb9d-486c-99a6-4e03ef531bd1"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("c940350f-a70f-4638-9a5b-85eaa11d0d61"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("3c161dbe-e543-48c0-83df-3aeac7f79001"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("2d3b0967-ab62-43d7-a97c-c4d0b22dc3ea"));
            labelID = (ITTLabel)AddControl(new Guid("9867e97e-ea80-438d-a21b-6b72a1b1dcb5"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("9a7f18ef-0493-4f05-9030-89224fd443bd"));
            labelFromResource = (ITTLabel)AddControl(new Guid("f9ff22e5-956d-4b8e-bc84-393067423b1d"));
            OrderDate = (ITTDateTimePicker)AddControl(new Guid("442616a7-903b-4bdd-bb80-ee5ffa7d404d"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("0bf80432-60dc-4a3e-9d3f-e69d054eb20e"));
            labelActionDate = (ITTLabel)AddControl(new Guid("89daa332-070b-495a-95d6-1398baf500be"));
            OrderTypeList = (ITTObjectListBox)AddControl(new Guid("d5fd2672-2940-4e7c-8744-18082d9ad145"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("1254d2fc-1234-4747-9d88-e698879e11de"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("539d0d84-c909-4498-961f-836bd965c1c1"));
            ResDivision = (ITTObjectListBox)AddControl(new Guid("c0f996d2-f7b0-4f79-b70c-ec41905c0c62"));
            labelResDivision = (ITTLabel)AddControl(new Guid("f615f1d8-b491-4129-bae6-5c4534eb7b50"));
            OrderStatus = (ITTEnumComboBox)AddControl(new Guid("2551c3d1-58ae-4d94-ae3e-7019c74397cf"));
            labelOrderStatus = (ITTLabel)AddControl(new Guid("47ccef0b-e0ed-4465-92fd-45b5c170566f"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("c98d8b54-94c9-41ee-84b9-fafdfcf3f2c9"));
            labelManufacturingAmount = (ITTLabel)AddControl(new Guid("0c73379e-974f-418b-b0af-a0e6e133ff47"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("1e8232b7-68c0-4d4a-96f3-8a74644356b2"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("0ea85667-74de-4cdf-82f4-b8b41bbdea42"));
            labelFixedAssetDefinition = (ITTLabel)AddControl(new Guid("2abc4598-6b36-4eca-b64b-59ef2705e2b8"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("66e0490d-6820-4197-bc1a-2699c2f61d2e"));
            labelSpecialWorkAmount = (ITTLabel)AddControl(new Guid("60a7fbe2-877f-46af-8d7f-aa5a94b7b8bd"));
            base.InitializeControls();
        }

        public ApprovalForm_MaintenanceO() : base("MAINTENANCEORDER", "ApprovalForm_MaintenanceO")
        {
        }

        protected ApprovalForm_MaintenanceO(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}