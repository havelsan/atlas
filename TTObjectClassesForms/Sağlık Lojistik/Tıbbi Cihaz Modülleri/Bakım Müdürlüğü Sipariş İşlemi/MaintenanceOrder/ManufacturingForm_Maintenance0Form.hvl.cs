
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
    /// Sipariş Genel İşlemleri
    /// </summary>
    public partial class ManufacturingForm_Maintenance0 : TTForm
    {
    /// <summary>
    /// Şipariş İşlemi
    /// </summary>
        protected TTObjectClasses.MaintenanceOrder _MaintenanceOrder
        {
            get { return (TTObjectClasses.MaintenanceOrder)_ttObject; }
        }

        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage tttabpage3;
        protected ITTGrid RepairConsumedMaterials;
        protected ITTListBoxColumn Material;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn SparePartMaterialDescription;
        protected ITTTextBoxColumn RequestAmount;
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
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox RequestNO;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTLabel labelActionDate;
        protected ITTLabel ttlabel11;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTextBox RepairWorkLoad;
        protected ITTLabel labelManufacturingAmount;
        protected ITTTextBox ManufacturingAmount;
        protected ITTLabel labelRepairWorkLoad;
        protected ITTDateTimePicker RequestDate;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelFixedAssetDefinition;
        protected ITTTextBox tttextbox4;
        protected ITTLabel labelOrderName;
        protected ITTLabel ttlabel10;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTTextBox OrderNO;
        protected ITTLabel labelFromResource;
        protected ITTDateTimePicker ActionDate;
        protected ITTObjectListBox OrderTypeList;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTTextBox tttextbox1;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel labelID;
        protected ITTLabel labelRequestDate;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel9;
        protected ITTLabel labelOrderNO;
        protected ITTLabel ttlabel1;
        protected ITTTabPage tttabpage2;
        protected ITTButton cmdForkWorkStep;
        protected ITTObjectListBox SenderSection;
        protected ITTTextBox tttextbox2;
        protected ITTGrid WorkStepsGrid;
        protected ITTListBoxColumn WorkShop;
        protected ITTListBoxColumn Personel;
        protected ITTTextBoxColumn Workload;
        protected ITTTextBoxColumn Comments;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel8;
        protected ITTToolStrip tttoolstrip1;
        protected ITTCheckBox chkOrderCompleted;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel7;
        override protected void InitializeControls()
        {
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("b95a1a43-cebd-4eb5-adbf-9a262b44a908"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("280772bb-024e-4fbe-b7c2-cb3dd2e918e4"));
            RepairConsumedMaterials = (ITTGrid)AddControl(new Guid("dff620be-1186-4e57-b568-784f8f661a5d"));
            Material = (ITTListBoxColumn)AddControl(new Guid("e4c73570-cbfa-4251-960e-ab4bea7ddb67"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("b14efc72-4742-49c2-8a5a-2f9126877982"));
            SparePartMaterialDescription = (ITTTextBoxColumn)AddControl(new Guid("08285b0d-433f-4be4-a030-35b4215ed1f2"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("700c96a3-9ac2-451d-968a-55eaf204b357"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("83acef9f-a2f9-433d-9c32-8e403ab1607a"));
            UsedConsumedMaterails = (ITTGrid)AddControl(new Guid("9a292072-1341-4dc8-a7b7-b0024992d20e"));
            UsedMaterial = (ITTListBoxColumn)AddControl(new Guid("1212c759-4155-4120-8135-2362b6905d12"));
            UsedMaterialDistType = (ITTListBoxColumn)AddControl(new Guid("f9384a2d-b1c6-49d0-be8e-a42cae693659"));
            RequestAmountForDepot = (ITTTextBoxColumn)AddControl(new Guid("87aa08e1-9f0a-410d-9fa0-f7583ceb8ff6"));
            SuppliedAmount = (ITTTextBoxColumn)AddControl(new Guid("d5407717-244a-4fbe-8223-a4c6030c907b"));
            UsedAmount = (ITTTextBoxColumn)AddControl(new Guid("0a3d8730-64df-4f88-a1ec-ccc4d70f9f86"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("30a22c7b-f670-46dc-8504-0daec2adec92"));
            UsedMaterialWorkSteps = (ITTGrid)AddControl(new Guid("5163c1ab-70ef-4a66-812a-b5155f4554c0"));
            WorkStepUsedMaterial = (ITTListBoxColumn)AddControl(new Guid("10be64f1-5d8c-4fc3-946f-ca21ad56868a"));
            WorkStepUsedMaterialDistType = (ITTListBoxColumn)AddControl(new Guid("3804e39f-c2ab-4862-8412-8f0abdba4124"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("8b639077-b87d-4a3c-bdf8-1ca8d3150796"));
            UnitAmout = (ITTTextBoxColumn)AddControl(new Guid("fa0e131e-4cb3-4e83-89f6-f7d8674737c1"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("1ec139f9-c287-4314-89d3-fe1c98a81fef"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("e46b7810-fe86-4c9d-99f4-850280fad504"));
            RequestNO = (ITTTextBox)AddControl(new Guid("bec222bc-fca0-4bd3-b08f-e59dba3fd457"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("6866de1d-8d5e-4ce4-8216-5aafd93c237b"));
            labelActionDate = (ITTLabel)AddControl(new Guid("8d37e4de-157d-4aa4-9321-ea830558be0c"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("b809a5f8-25e1-4a37-b4f4-a9f570016143"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("b5694fa4-0c0a-400e-861a-9fb4c6f6669c"));
            RepairWorkLoad = (ITTTextBox)AddControl(new Guid("30582f1e-c6f4-4938-b4ac-bcf048953d76"));
            labelManufacturingAmount = (ITTLabel)AddControl(new Guid("ad5895ac-725e-4765-8b82-c591a41e3023"));
            ManufacturingAmount = (ITTTextBox)AddControl(new Guid("31489c46-3b40-4dfe-8f8d-055795a8748e"));
            labelRepairWorkLoad = (ITTLabel)AddControl(new Guid("a8b39e10-65d0-4510-9574-adb527f107bb"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("25ff0b2a-cb71-4a3c-853c-cbca80cec047"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("7cb8ac0c-2076-4809-bb73-e8470d1368ba"));
            labelFixedAssetDefinition = (ITTLabel)AddControl(new Guid("0b027c28-04e8-48a6-a461-d4569502953f"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("e16ae6b5-c89d-4eef-9188-b0129159d351"));
            labelOrderName = (ITTLabel)AddControl(new Guid("3892f5f9-3f8d-406f-874b-d386ba69d01a"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("c018bfd0-7ef5-4351-b2ab-761ef82ea5b2"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("7ae6ed95-e77b-4cab-85e4-941d65a01cdf"));
            OrderNO = (ITTTextBox)AddControl(new Guid("1bed2846-7aa7-4a71-b4e8-b5ce16ba3068"));
            labelFromResource = (ITTLabel)AddControl(new Guid("34e8155c-9d49-48cb-8244-2f5b35d6bb29"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("2cad03ed-7820-409a-a258-a85602d31bab"));
            OrderTypeList = (ITTObjectListBox)AddControl(new Guid("2afb7f1d-faff-49ba-94ca-3a7a41f19c25"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("66ea874a-8283-4096-a944-2e3b96d09fa6"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("5dbd727f-4909-4aed-85a0-01f7d82305e2"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("278b7149-4f60-43cc-a541-ad5384ddac39"));
            labelID = (ITTLabel)AddControl(new Guid("2f3788c1-4f3a-465e-a4d2-320acc75547a"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("5c9a48e6-d546-4a99-a5a7-089bda4db726"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("88a1b784-2417-4544-9930-416c64d6e7b7"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("a542a939-69d2-40e5-a8de-415081de4696"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("f21739e4-e176-40d7-a4a8-a842e36cb8a8"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3a42fb2e-b5cc-45db-bcf9-318da1819e30"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("73dc1d93-f39a-4b2f-8078-a1487c30b4d7"));
            cmdForkWorkStep = (ITTButton)AddControl(new Guid("f623f6df-8958-4c7f-96d8-16e823fc40e9"));
            SenderSection = (ITTObjectListBox)AddControl(new Guid("ef8c8bd2-2b1f-43f1-b85d-e583034dc35e"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("5a7c4506-3394-46f4-bb83-bb6915d638d8"));
            WorkStepsGrid = (ITTGrid)AddControl(new Guid("e9d07962-a30b-4326-bf80-c4f7a5db0709"));
            WorkShop = (ITTListBoxColumn)AddControl(new Guid("d41c400a-0bbc-4ae2-bf9e-a663f8cfd939"));
            Personel = (ITTListBoxColumn)AddControl(new Guid("3959b316-e5d9-411f-867a-bdde6f0a0263"));
            Workload = (ITTTextBoxColumn)AddControl(new Guid("d1d4cb8f-cb81-4c8d-ab37-c4dd10f7b83e"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("247ad6f6-a3bc-4ef2-a8f4-960121190493"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("36f93b09-26e3-4424-8fe6-27ec0bb4d30e"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("3532c30e-910b-4211-bc00-ec901eb9578d"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("d14d9732-32a3-4a70-a9fe-579797c70f12"));
            tttoolstrip1 = (ITTToolStrip)AddControl(new Guid("9aaeeed8-e8b4-4b57-966c-7f354809af35"));
            chkOrderCompleted = (ITTCheckBox)AddControl(new Guid("0c66be16-ea82-4e06-a061-736926ef5cff"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("bd5cd596-b44e-4cad-ab46-12f7ec2248f5"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("a418480f-ded5-46d2-bbeb-8134747097ab"));
            base.InitializeControls();
        }

        public ManufacturingForm_Maintenance0() : base("MAINTENANCEORDER", "ManufacturingForm_Maintenance0")
        {
        }

        protected ManufacturingForm_Maintenance0(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}