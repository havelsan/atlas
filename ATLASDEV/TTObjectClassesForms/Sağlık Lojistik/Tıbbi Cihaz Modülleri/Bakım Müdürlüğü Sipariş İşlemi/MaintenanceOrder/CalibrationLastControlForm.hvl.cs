
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
    /// Son Kontrol (Kalibrasyon)
    /// </summary>
    public partial class CalibrationLastControlForm : TTForm
    {
    /// <summary>
    /// Şipariş İşlemi
    /// </summary>
        protected TTObjectClasses.MaintenanceOrder _MaintenanceOrder
        {
            get { return (TTObjectClasses.MaintenanceOrder)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage2;
        protected ITTTextBox RequestNO;
        protected ITTTextBox RepairWorkLoad;
        protected ITTLabel labelRepairWorkLoad;
        protected ITTTextBox SpecialWorkAmount;
        protected ITTLabel labelSpecialWorkAmount;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox ManufacturingAmount;
        protected ITTLabel ttlabel10;
        protected ITTLabel labelManufacturingAmount;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelFromResource;
        protected ITTLabel labelFixedAssetDefinition;
        protected ITTObjectListBox OrderTypeList;
        protected ITTLabel ttlabel2;
        protected ITTTextBox tttextbox1;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel3;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelActionDate;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelOrderNO;
        protected ITTLabel labelOrderName;
        protected ITTLabel ttlabel9;
        protected ITTTextBox OrderNO;
        protected ITTLabel labelRequestDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelID;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTTabPage tttabpage6;
        protected ITTTextBox PackagingDepActionStatus;
        protected ITTButton cmdPackagingDep;
        protected ITTLabel labelPackagingDepReturnDate;
        protected ITTDateTimePicker PackagingDepSendingDate;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker PackagingDepReturnDate;
        protected ITTLabel labelPackagingDepartment;
        protected ITTTextBox PackagingDepartmentDesc;
        protected ITTLabel labelPackagingDepSendingDate;
        protected ITTLabel labelPackagingDepartmentDesc;
        protected ITTObjectListBox PackagingDepartment;
        protected ITTTabPage tttabpage3;
        protected ITTLabel labelPreventiveTreatment;
        protected ITTLabel labelPreventiveTreatmentWorkLoad;
        protected ITTTextBox PreventiveTreatment;
        protected ITTTextBox PreventiveTreatmentWorkLoad;
        protected ITTTextBox Agenda;
        protected ITTLabel labelAgenda;
        protected ITTTextBox ErrorReason;
        protected ITTLabel labelErrorReason;
        protected ITTToolStrip tttoolstrip1;
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
        protected ITTTabPage tttabpage1;
        protected ITTGrid WorkStepsGrid;
        protected ITTListBoxColumn WorkShop;
        protected ITTListBoxColumn Personel;
        protected ITTTextBoxColumn Workload;
        protected ITTTextBoxColumn Comments;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("bbd947a6-094d-4fda-8f98-c54006f1a378"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("3781c5c9-9f88-43e9-90d8-1c22525c3fd8"));
            RequestNO = (ITTTextBox)AddControl(new Guid("48a1979a-abb9-4c7d-8407-0562bf18e519"));
            RepairWorkLoad = (ITTTextBox)AddControl(new Guid("e441649a-2220-427f-9ae6-868d41467d08"));
            labelRepairWorkLoad = (ITTLabel)AddControl(new Guid("da475457-235e-4a9f-8ae1-3db375826aee"));
            SpecialWorkAmount = (ITTTextBox)AddControl(new Guid("27bfab3d-e30c-48f9-b442-b30670d6c2e4"));
            labelSpecialWorkAmount = (ITTLabel)AddControl(new Guid("ba307d64-3871-46d3-928b-203943db1c3b"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("9e718c44-a251-400c-9e3d-deca5560ca62"));
            ManufacturingAmount = (ITTTextBox)AddControl(new Guid("a46e671c-21dc-4cc2-8097-c86e7ea8a5d7"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("db6f311e-4f79-4600-be5f-acae0e924c7b"));
            labelManufacturingAmount = (ITTLabel)AddControl(new Guid("566cdf08-5fed-4c0e-99d6-9c73e1836f5a"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("b047c88a-3fa3-4fd3-a834-5c83928c0793"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("7bfc3319-2b9f-416c-9cff-7acbe10bea97"));
            labelFromResource = (ITTLabel)AddControl(new Guid("f5b48542-91ea-4c74-b907-6e44a92078c6"));
            labelFixedAssetDefinition = (ITTLabel)AddControl(new Guid("9297dc52-3b61-4921-b2a4-94ec0a84a13e"));
            OrderTypeList = (ITTObjectListBox)AddControl(new Guid("ea57a774-47ac-435b-a752-96147f1ca589"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("a0ead92d-b5cc-448c-8096-d80b4df39a74"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("517d67bc-8e90-4145-be82-f7948ed60651"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("e444e4bb-4873-4436-b076-e5c5031560cd"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("48f7ac32-26ae-40a1-a29b-f3ccd0d404b2"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("23f26c92-91f7-401f-8db4-a75e058d8f02"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("7d0bb0ee-c7a1-42d6-afac-1a9f4b799461"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("a55fba6a-2bc3-4ef6-8dcf-c732a9a774db"));
            labelActionDate = (ITTLabel)AddControl(new Guid("20539a0e-93da-44c4-bed1-667686df8887"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e39e1913-6a9d-460d-bfbf-c63f9946c593"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("90772500-de74-440b-ad9d-4b1813a1c2d5"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("a3ab620d-cdbb-4281-aa88-59c2f558733d"));
            labelOrderName = (ITTLabel)AddControl(new Guid("25703ef4-6782-4b0d-94c9-a30193816973"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("3b3772b3-eeff-45f8-94c3-5a9cf65a007e"));
            OrderNO = (ITTTextBox)AddControl(new Guid("9122ca5c-9097-4d99-8d42-328ddfd4c110"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("0a5af7ea-6b41-46ed-bb0a-75de843b29bd"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("3ac9773a-b62b-430a-92a5-c9024c095542"));
            labelID = (ITTLabel)AddControl(new Guid("8dbd3f4a-5d06-48a2-af4d-5ebbf86d88da"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("086e239a-82f7-4c32-acb3-981056faa699"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("309a2785-eb03-4743-953a-2ad2af052897"));
            tttabpage6 = (ITTTabPage)AddControl(new Guid("54101930-4a5d-4726-bdf0-9b83de9e56dd"));
            PackagingDepActionStatus = (ITTTextBox)AddControl(new Guid("39995a12-48a4-44f6-943a-cbd8ac0e6889"));
            cmdPackagingDep = (ITTButton)AddControl(new Guid("341bd7cb-77b5-4b1c-a958-34448f15357b"));
            labelPackagingDepReturnDate = (ITTLabel)AddControl(new Guid("af32a9bd-f7b6-4f18-898a-e67a9649d41e"));
            PackagingDepSendingDate = (ITTDateTimePicker)AddControl(new Guid("061b5389-0954-4622-9a70-ae2cf843e50f"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("5bc7d4b6-6b94-496f-a114-0446d02eab97"));
            PackagingDepReturnDate = (ITTDateTimePicker)AddControl(new Guid("ae798113-9a00-4cc4-96e9-51ec3ff51753"));
            labelPackagingDepartment = (ITTLabel)AddControl(new Guid("2e2c3167-8e36-42c2-9b80-d6a6e82c8de8"));
            PackagingDepartmentDesc = (ITTTextBox)AddControl(new Guid("5dc804e3-d8bd-4ed1-96f5-20a6f4c9cf3a"));
            labelPackagingDepSendingDate = (ITTLabel)AddControl(new Guid("e8e20408-e798-4198-b50c-f32b9273de5b"));
            labelPackagingDepartmentDesc = (ITTLabel)AddControl(new Guid("3f3daade-4327-4b4d-82a5-4a5acfb32b75"));
            PackagingDepartment = (ITTObjectListBox)AddControl(new Guid("5d83f48e-30e6-4c8a-a19a-f14e2d88e239"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("c21dd904-9e91-4a7b-ac39-b1f824c6d6c4"));
            labelPreventiveTreatment = (ITTLabel)AddControl(new Guid("b551493a-a324-478d-ae90-f6b2aa74df96"));
            labelPreventiveTreatmentWorkLoad = (ITTLabel)AddControl(new Guid("b5ebd608-373a-4e5b-a7f2-118ec368fbdb"));
            PreventiveTreatment = (ITTTextBox)AddControl(new Guid("7d677019-5ed1-43d3-bf95-18cc14127056"));
            PreventiveTreatmentWorkLoad = (ITTTextBox)AddControl(new Guid("ef277e0f-16a1-4887-b0d6-739a92ec6baf"));
            Agenda = (ITTTextBox)AddControl(new Guid("f0fbf65b-bb99-4996-b7f3-1e7b7e55284e"));
            labelAgenda = (ITTLabel)AddControl(new Guid("125faa6e-6fc7-43b7-88ea-5571dc9147c7"));
            ErrorReason = (ITTTextBox)AddControl(new Guid("c1b3766b-d1ba-4858-8c2c-646f277087b1"));
            labelErrorReason = (ITTLabel)AddControl(new Guid("47dc035b-b7fc-44f2-84a5-8669f60cad0e"));
            tttoolstrip1 = (ITTToolStrip)AddControl(new Guid("634e1fe4-0886-479f-bf23-452ab970927e"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("8c3070f2-a8f3-4f19-8e1f-1c8dd74b9d0e"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("4793a6d1-fed5-4a75-a4de-1744005a989e"));
            UsedConsumedMaterails = (ITTGrid)AddControl(new Guid("71351002-1b52-47eb-b305-30ffd5955747"));
            UsedMaterial = (ITTListBoxColumn)AddControl(new Guid("f1e580a6-d1b0-42f1-a9ed-a91e2945d28a"));
            UsedMaterialDistType = (ITTListBoxColumn)AddControl(new Guid("f7a92c05-761b-40f0-b1b0-f255423b1098"));
            RequestAmountForDepot = (ITTTextBoxColumn)AddControl(new Guid("7a269a6d-7bc4-4400-a2a5-76137d109bbf"));
            SuppliedAmount = (ITTTextBoxColumn)AddControl(new Guid("cf3b0d89-7490-4b6e-b470-c86745cffefd"));
            UsedAmount = (ITTTextBoxColumn)AddControl(new Guid("8906d3e6-c373-4f64-a820-229bf069367b"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("1e47314e-4056-46b8-a3a6-c6e470b0a449"));
            UsedMaterialWorkSteps = (ITTGrid)AddControl(new Guid("44ddc7f7-0dcf-459d-bfe8-c0f0408329ea"));
            WorkStepUsedMaterial = (ITTListBoxColumn)AddControl(new Guid("0777ddb8-0782-43c3-9c76-fb085d9280ca"));
            WorkStepUsedMaterialDistType = (ITTListBoxColumn)AddControl(new Guid("36f35f8c-b678-448b-8e8f-8d4f866c3fee"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("bb5098ae-2c0c-414f-bd8a-5f66f47348f8"));
            UnitAmout = (ITTTextBoxColumn)AddControl(new Guid("f4dcac38-1cce-4438-951e-c7471f14cd40"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("2e839599-0dad-400c-95f5-723548e09194"));
            WorkStepsGrid = (ITTGrid)AddControl(new Guid("be15f86a-3004-49f5-8266-e0cd9cdca356"));
            WorkShop = (ITTListBoxColumn)AddControl(new Guid("38661fd1-69c7-4964-b563-bbe1cea9b7c6"));
            Personel = (ITTListBoxColumn)AddControl(new Guid("00350eaf-420d-490a-9973-3e0e3e05d868"));
            Workload = (ITTTextBoxColumn)AddControl(new Guid("b94c1912-0b9a-4eb6-8822-ff987863107a"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("924a6737-4544-4e29-876d-a3b9e40c48c6"));
            base.InitializeControls();
        }

        public CalibrationLastControlForm() : base("MAINTENANCEORDER", "CalibrationLastControlForm")
        {
        }

        protected CalibrationLastControlForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}