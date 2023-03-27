
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
    /// Sonuçlanmış Sipariş
    /// </summary>
    public partial class CompletedForm_MaintenanceO : TTForm
    {
    /// <summary>
    /// Şipariş İşlemi
    /// </summary>
        protected TTObjectClasses.MaintenanceOrder _MaintenanceOrder
        {
            get { return (TTObjectClasses.MaintenanceOrder)_ttObject; }
        }

        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTLabel ttlabel11;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox RequestNo;
        protected ITTTextBox OrderNo;
        protected ITTLabel ttlabel10;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTLabel labelFromResource;
        protected ITTObjectListBox OrderTypeList;
        protected ITTGrid RepairConsumedMaterials;
        protected ITTListBoxColumn UsedMaterial;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTTextBoxColumn SuppliedAmount;
        protected ITTTextBoxColumn UsedAmount;
        protected ITTLabel ttlabel3;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelOrderNO;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel8;
        protected ITTLabel labelRequestDate;
        protected ITTLabel labelID;
        protected ITTLabel labelFixedAsset;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTObjectListBox FixedAsset;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelOrderName;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelActionDate;
        protected ITTLabel ttlabel13;
        protected ITTGrid WorkStepsGrid;
        protected ITTListBoxColumn WorkShop;
        protected ITTListBoxColumn Personel;
        protected ITTTextBoxColumn Workload;
        protected ITTTextBoxColumn Comments;
        override protected void InitializeControls()
        {
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("e8748e92-aea7-4d44-989c-deafa637ce8a"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("6b3c6647-0cf0-4412-bbb8-dea97909a4e6"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("a8adfb36-f330-47f7-936b-7d61bf776324"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("fae567e1-ffed-425b-bd54-5c77c4775fbb"));
            RequestNo = (ITTTextBox)AddControl(new Guid("9184a7ea-82c0-45bc-a21f-123f9ce44214"));
            OrderNo = (ITTTextBox)AddControl(new Guid("795e3371-a055-43af-bffc-a9619d4a0a3c"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("96ad0cd3-a13b-4197-bff8-97caca662359"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("fd5e1794-1975-4908-8a24-d5d98019d69f"));
            labelFromResource = (ITTLabel)AddControl(new Guid("5314207a-3bb7-47de-8b2e-3a00dbc77a74"));
            OrderTypeList = (ITTObjectListBox)AddControl(new Guid("d53a2027-2c85-41a6-937f-1603e7497977"));
            RepairConsumedMaterials = (ITTGrid)AddControl(new Guid("7185841a-2b36-4b36-baa8-2d535d6a2380"));
            UsedMaterial = (ITTListBoxColumn)AddControl(new Guid("a43d2d30-fc96-4a4c-9a74-68c4b4b34016"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("4d092a1a-3676-46dd-9c69-cfb79e5adf37"));
            SuppliedAmount = (ITTTextBoxColumn)AddControl(new Guid("4f61bfe9-ca78-4ed6-9b1a-e87acf8ecf81"));
            UsedAmount = (ITTTextBoxColumn)AddControl(new Guid("498ffcff-b9b1-4270-81e9-adb302bcde7a"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("5420f151-683b-41b0-af07-a206844b82a6"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("0e8046af-c0d0-478e-b869-b281e0b9fdc4"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a9c6544f-b0f0-4626-ae58-3e29d32a8d49"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("a3464b78-05ca-4da7-b1a7-5219d0cf0bcb"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("2132420d-6822-4964-84de-be8a1daa3f0f"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("eb3e5350-9868-4eef-9a67-e692d82f6c0f"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("89fe1b03-6762-4550-a8b1-ce1519864312"));
            labelID = (ITTLabel)AddControl(new Guid("b6a3a1fe-081f-4dde-baa5-4951adbae904"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("dd946193-aa41-4724-9a14-b68817d027d6"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("14f4d964-0bd3-48f9-87c1-b0183d0d2757"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("5c62dd03-d909-4657-a834-f93b224a0e4a"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("7580db4a-a92c-45b4-94de-5071c8adaf71"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("6eba9661-771b-461a-82b6-f9371e30a8c5"));
            labelOrderName = (ITTLabel)AddControl(new Guid("991d45a6-f8ad-4ef5-b2bb-2324ec12cdd4"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("31515444-a7ac-4caa-8a9d-3e9145dc8321"));
            labelActionDate = (ITTLabel)AddControl(new Guid("3a0bd1d4-a8cf-435c-85e0-612fb8979931"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("df88917a-de38-4f22-ada9-08921a598257"));
            WorkStepsGrid = (ITTGrid)AddControl(new Guid("2eb7f605-0101-4b68-9d44-67cff6cc8640"));
            WorkShop = (ITTListBoxColumn)AddControl(new Guid("8acb5169-65d1-4ab3-a806-9bb1e5141622"));
            Personel = (ITTListBoxColumn)AddControl(new Guid("caaf5b87-0751-4da0-a988-e5786b8481a6"));
            Workload = (ITTTextBoxColumn)AddControl(new Guid("8619363b-0e7e-4caa-82ac-efc6b6404a47"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("ded10986-ff71-4628-b436-9acbb6d1c968"));
            base.InitializeControls();
        }

        public CompletedForm_MaintenanceO() : base("MAINTENANCEORDER", "CompletedForm_MaintenanceO")
        {
        }

        protected CompletedForm_MaintenanceO(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}