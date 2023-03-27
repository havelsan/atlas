
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
    /// Sipariş Kapatma
    /// </summary>
    public partial class OrderCloseForm_MaintenanceO : TTForm
    {
    /// <summary>
    /// Şipariş İşlemi
    /// </summary>
        protected TTObjectClasses.MaintenanceOrder _MaintenanceOrder
        {
            get { return (TTObjectClasses.MaintenanceOrder)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid WorkStepsGrid;
        protected ITTListBoxColumn WorkShop;
        protected ITTListBoxColumn Personel;
        protected ITTTextBoxColumn Workload;
        protected ITTTextBoxColumn Comments;
        protected ITTLabel labelTotalWorkLoad;
        protected ITTTextBox TotalWorkLoad;
        protected ITTTabPage tttabpage2;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage tttabpage4;
        protected ITTGrid UsedConsumedMaterails;
        protected ITTListBoxColumn UsedMaterial;
        protected ITTListBoxColumn DistributionType;
        protected ITTTextBoxColumn RequestAmountForDepot;
        protected ITTTextBoxColumn SuppliedAmount;
        protected ITTTextBoxColumn UsedAmount;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTabPage tttabpage5;
        protected ITTGrid UsedMaterialWorkSteps;
        protected ITTListBoxColumn WorkStepUsedMaterial;
        protected ITTListBoxColumn WorkStepUsedMaterialDisType;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn WorkStepUsedMaterialUnitPrice;
        protected ITTLabel labelTotalMaterialPrice;
        protected ITTTextBox TotalMaterialPrice;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox OrderNO;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox RequestNO;
        protected ITTTextBox RepairWorkLoad;
        protected ITTTextBox ManufacturingAmount;
        protected ITTTextBox PreventiveTreatmentWorkLoad;
        protected ITTTextBox SpecialWorkAmount;
        protected ITTLabel ttlabel11;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTGrid MaintenanceOrderCosts;
        protected ITTTextBoxColumn SharpLaborCost;
        protected ITTTextBoxColumn AvarageDirectLaborCost;
        protected ITTTextBoxColumn LaborCost;
        protected ITTTextBoxColumn AverageGeneralProcessingCost;
        protected ITTTextBoxColumn GeneralProcessingCost;
        protected ITTTextBoxColumn AverageDepreciationExpense;
        protected ITTTextBoxColumn DepreciationExpense;
        protected ITTTextBoxColumn DirectMaterialExpense;
        protected ITTLabel labelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelActionDate;
        protected ITTObjectListBox OrderTypeList;
        protected ITTLabel labelOrderNO;
        protected ITTLabel labelFromResource;
        protected ITTLabel ttlabel9;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelID;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel labelOrderName;
        protected ITTDateTimePicker ActionDate;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelRepairWorkLoad;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelFixedAssetDefinition;
        protected ITTLabel labelManufacturingAmount;
        protected ITTLabel labelPreventiveTreatmentWorkLoad;
        protected ITTLabel labelSpecialWorkAmount;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("78078335-d4b2-4e9c-b8a6-e84c3b20d695"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("426daf38-73c0-4136-bce2-bca7edb803b7"));
            WorkStepsGrid = (ITTGrid)AddControl(new Guid("ff4efde0-722b-4f72-96e6-259af2690282"));
            WorkShop = (ITTListBoxColumn)AddControl(new Guid("5c1c9294-2d87-40aa-962c-42f28de71c52"));
            Personel = (ITTListBoxColumn)AddControl(new Guid("cc8bcd1f-5659-4478-ba43-987f4a54d296"));
            Workload = (ITTTextBoxColumn)AddControl(new Guid("4a795311-0c0c-43f6-abf1-35f0425a7868"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("13d6a9c9-204a-4443-9fec-f05c5bfd7922"));
            labelTotalWorkLoad = (ITTLabel)AddControl(new Guid("1219a57c-1335-44c3-890c-4cc22298f811"));
            TotalWorkLoad = (ITTTextBox)AddControl(new Guid("241d38c6-408e-49b7-abcb-3e75445d737c"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("fa3285e1-16a6-40b5-ab04-e051b611aa19"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("d20b2316-833a-4e4b-a7f9-b03a1cfd99f9"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("8c5a71fe-f850-489b-8fdd-d9c6c633aa2b"));
            UsedConsumedMaterails = (ITTGrid)AddControl(new Guid("4a4df348-0cdd-4511-9ffe-c7fb06086156"));
            UsedMaterial = (ITTListBoxColumn)AddControl(new Guid("7288b868-de1f-4db6-a4e3-e08e623b66d6"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("b2bf9e1f-c25c-4c43-8f68-640335d11fab"));
            RequestAmountForDepot = (ITTTextBoxColumn)AddControl(new Guid("69f44011-2df9-4543-a5f8-a0cd8bcb31f0"));
            SuppliedAmount = (ITTTextBoxColumn)AddControl(new Guid("c9aa6bd6-66f4-4421-bbd3-20426f48e6cc"));
            UsedAmount = (ITTTextBoxColumn)AddControl(new Guid("7b51849d-fbf4-4342-9a8b-7ab94c1138d7"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("c8eb7b3e-c9c2-48cb-a65e-d45d6f48ef17"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("60bb948d-c46a-4588-8605-fc981f771ae6"));
            UsedMaterialWorkSteps = (ITTGrid)AddControl(new Guid("99828d89-c4af-4c8a-ab7d-34f8c2f13285"));
            WorkStepUsedMaterial = (ITTListBoxColumn)AddControl(new Guid("f207b260-0971-407f-b03f-f022e5ad6be9"));
            WorkStepUsedMaterialDisType = (ITTListBoxColumn)AddControl(new Guid("d4f123c6-43d0-473a-9c10-71582d84bc2d"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("75973a19-7da0-426c-a5bb-bd46d0aec77c"));
            WorkStepUsedMaterialUnitPrice = (ITTTextBoxColumn)AddControl(new Guid("e756f25c-bdca-4ab2-833c-aff18849b6e2"));
            labelTotalMaterialPrice = (ITTLabel)AddControl(new Guid("422d3c4a-b828-4141-9a00-e318acfd7cca"));
            TotalMaterialPrice = (ITTTextBox)AddControl(new Guid("9cef4e17-be0a-478d-93f8-cf88ff01f231"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("98d5005c-efd5-41a7-ac95-a6db4c5a134c"));
            OrderNO = (ITTTextBox)AddControl(new Guid("30e44848-90bb-4620-818a-48c81037eb4c"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("c701be62-a1f0-483d-b9af-7a280d0fd666"));
            RequestNO = (ITTTextBox)AddControl(new Guid("5d992793-41ac-4e96-8916-bd6f08e6fbe1"));
            RepairWorkLoad = (ITTTextBox)AddControl(new Guid("92ae54e4-cd57-4139-aa91-c395cefaf887"));
            ManufacturingAmount = (ITTTextBox)AddControl(new Guid("602b44bb-a298-4fb4-9d2f-5e10ec8378df"));
            PreventiveTreatmentWorkLoad = (ITTTextBox)AddControl(new Guid("30f0000c-e4df-488e-b43f-1193838fec8d"));
            SpecialWorkAmount = (ITTTextBox)AddControl(new Guid("49a5548f-a031-4f13-8b73-918b675335b7"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("69dc38c1-fe4c-4b6d-8b3d-24f5655ec668"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("d7221c53-7662-4121-9f54-647394490e82"));
            MaintenanceOrderCosts = (ITTGrid)AddControl(new Guid("24628edf-38d9-4d69-a19c-1ba264a07168"));
            SharpLaborCost = (ITTTextBoxColumn)AddControl(new Guid("b7242bb5-84ef-434a-aefb-c829ae1c7b83"));
            AvarageDirectLaborCost = (ITTTextBoxColumn)AddControl(new Guid("32336491-61d7-4211-9d38-2f8df2cdc90c"));
            LaborCost = (ITTTextBoxColumn)AddControl(new Guid("77cc0569-ae99-41c2-ac81-75a7e0571b22"));
            AverageGeneralProcessingCost = (ITTTextBoxColumn)AddControl(new Guid("9ed7b80c-39b3-42e9-99ff-9b22016f4dd9"));
            GeneralProcessingCost = (ITTTextBoxColumn)AddControl(new Guid("e37e8412-8004-4304-8977-a2a587734d79"));
            AverageDepreciationExpense = (ITTTextBoxColumn)AddControl(new Guid("a819e2c1-ebef-47b4-a3b8-5a5ce519d51c"));
            DepreciationExpense = (ITTTextBoxColumn)AddControl(new Guid("0d971c44-3b4a-406e-8a2d-21a80e6405df"));
            DirectMaterialExpense = (ITTTextBoxColumn)AddControl(new Guid("8a1c8622-bdc5-43eb-81ed-fcadf43b43bc"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("8678c887-427c-417f-a8d6-36f482a30c6a"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("06b21e89-7d7d-4129-bbf3-5e8d8ae76398"));
            labelActionDate = (ITTLabel)AddControl(new Guid("71ede2a8-1e52-4077-8d94-71d38841abce"));
            OrderTypeList = (ITTObjectListBox)AddControl(new Guid("f1ecf5d3-17b2-4b99-a274-7432c4426a9b"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("d6c04493-4da3-4523-b74d-9d55e41e6832"));
            labelFromResource = (ITTLabel)AddControl(new Guid("5163207e-d938-45d9-a297-a45d1a80905a"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("2284050b-a1f7-4863-9b4b-b166428ae379"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("93fb11e1-69cd-4902-ae83-b7b4c81bd2d4"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("93000279-dd63-4c03-bd0c-bd103ac727e1"));
            labelID = (ITTLabel)AddControl(new Guid("a7da40f4-f2bf-4e7f-8ca8-bf12deb17cd9"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("519629a5-58eb-4844-8826-c1efaa6f9985"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("4ce8c252-476b-43ad-a132-d09e26e66968"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("688c2b93-e1d8-4fc3-a911-f6be6cecc23e"));
            labelOrderName = (ITTLabel)AddControl(new Guid("e732959a-934d-4c17-abd0-fb3d6b3bd8d7"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("6360998e-ffc3-453f-94e9-fe3365c74b9c"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("fe943f92-2549-463b-af8f-cc7edb04e23b"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("f1143627-feeb-48af-84c1-5609e8850217"));
            labelRepairWorkLoad = (ITTLabel)AddControl(new Guid("f4caa0bd-e1c7-4d06-8482-a7934fb40bd7"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("672b63d9-7380-4e99-8171-f88d1c74e35a"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("79f0a80b-4209-470e-89e5-17dffde178a9"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("8caf5f0d-4c82-4588-a741-f5a27fe9adba"));
            labelFixedAssetDefinition = (ITTLabel)AddControl(new Guid("9b1162e9-d9ab-486c-b113-7599c8d8c1d2"));
            labelManufacturingAmount = (ITTLabel)AddControl(new Guid("d0689f83-e7bb-4b33-86f7-89122e200b79"));
            labelPreventiveTreatmentWorkLoad = (ITTLabel)AddControl(new Guid("4b0fb55d-af0a-4b0b-83d8-e2889b6bb690"));
            labelSpecialWorkAmount = (ITTLabel)AddControl(new Guid("02e9a6ad-5af7-4838-b9d9-5294a301d99b"));
            base.InitializeControls();
        }

        public OrderCloseForm_MaintenanceO() : base("MAINTENANCEORDER", "OrderCloseForm_MaintenanceO")
        {
        }

        protected OrderCloseForm_MaintenanceO(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}