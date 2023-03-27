
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
    public partial class RepairForm_MaintenanceO : TTForm
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
        protected ITTGroupBox ttgroupbox1;
        protected ITTButton cmdForkWorkStep;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox SenderSection;
        protected ITTLabel ttlabel5;
        protected ITTTextBox RequestNO;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTLabel labelActionDate;
        protected ITTLabel ttlabel11;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTextBox RepairWorkLoad;
        protected ITTLabel labelRepairWorkLoad;
        protected ITTDateTimePicker RequestDate;
        protected ITTTextBox tttextbox4;
        protected ITTLabel labelOrderName;
        protected ITTLabel ttlabel10;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTTextBox OrderNO;
        protected ITTLabel labelFromResource;
        protected ITTDateTimePicker ActionDate;
        protected ITTObjectListBox FixedAsset;
        protected ITTObjectListBox OrderTypeList;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTTextBox tttextbox1;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelID;
        protected ITTLabel labelRequestDate;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel9;
        protected ITTLabel labelOrderNO;
        protected ITTLabel ttlabel1;
        protected ITTTabPage tttabpage2;
        protected ITTButton cmdAddSignDetail;
        protected ITTGrid ServiceProcurementSignDetails;
        protected ITTEnumComboBoxColumn SignUserTypeCMRActionSignDetail;
        protected ITTListBoxColumn SignUserCMRActionSignDetail;
        protected ITTCheckBoxColumn IsDeputyCMRActionSignDetail;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel6;
        protected ITTButton cmdForkDemand;
        protected ITTRichTextBoxControl DetailDescription;
        protected ITTLabel ttlabel13;
        protected ITTObjectListBox PurchaseItem;
        protected ITTTabPage tttabpage6;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel4;
        protected ITTGrid UserMaintenances;
        protected ITTListBoxColumn UserParameter;
        protected ITTCheckBoxColumn UserChecked;
        protected ITTTextBoxColumn UserDescription;
        protected ITTGrid UnitMaintenances;
        protected ITTListBoxColumn UnitParameter;
        protected ITTCheckBoxColumn UnitChecked;
        protected ITTTextBoxColumn UnitDescription;
        protected ITTTabPage tttabpage7;
        protected ITTTextBox Agenda;
        protected ITTLabel labelPreventiveTreatmentWorkLoad;
        protected ITTLabel labelErrorReason;
        protected ITTLabel labelPreventiveTreatment;
        protected ITTTextBox PreventiveTreatment;
        protected ITTLabel labelAgenda;
        protected ITTTextBox PreventiveTreatmentWorkLoad;
        protected ITTTextBox ErrorReason;
        protected ITTGrid WorkStepsGrid;
        protected ITTListBoxColumn WorkShop;
        protected ITTListBoxColumn Personel;
        protected ITTTextBoxColumn Workload;
        protected ITTTextBoxColumn Comments;
        protected ITTCheckBox chkOrderCompleted;
        protected ITTLabel ttlabel8;
        override protected void InitializeControls()
        {
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("5de17f65-df47-42aa-b633-bbcc593d7d63"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("fed8fe09-11b9-4d9a-bca8-b9ffe50f5294"));
            RepairConsumedMaterials = (ITTGrid)AddControl(new Guid("15ac32e1-b07e-4118-a8bd-336eb6964395"));
            Material = (ITTListBoxColumn)AddControl(new Guid("fdbda0d9-84ab-4e97-981f-85fc611d47fe"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("860f3611-824c-45f2-b556-4cbeff678289"));
            SparePartMaterialDescription = (ITTTextBoxColumn)AddControl(new Guid("9b068a77-875b-4b4d-977a-d63156220ec5"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("e283a540-99cc-420e-b956-ea27444c6a82"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("d8c2b3ef-6656-4867-a978-0c240d083e0b"));
            UsedConsumedMaterails = (ITTGrid)AddControl(new Guid("a8df1230-f41e-434f-b782-e1a9452be84a"));
            UsedMaterial = (ITTListBoxColumn)AddControl(new Guid("b1b470d2-9095-4b7f-889c-fb115fca0888"));
            UsedMaterialDistType = (ITTListBoxColumn)AddControl(new Guid("4f42be25-3b42-4fe2-b2e6-71525e31ddcb"));
            RequestAmountForDepot = (ITTTextBoxColumn)AddControl(new Guid("1bdd7cda-99a2-4f9a-a921-4c29e41f244c"));
            SuppliedAmount = (ITTTextBoxColumn)AddControl(new Guid("f932115a-80df-414b-b3e0-8395bbfc8f47"));
            UsedAmount = (ITTTextBoxColumn)AddControl(new Guid("f3084bdd-59a8-44c3-912b-2a3c29dcfff5"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("1a0b3912-8c4f-4505-aa76-e30df00c48dc"));
            UsedMaterialWorkSteps = (ITTGrid)AddControl(new Guid("0804f762-8257-45eb-86a8-721105265b21"));
            WorkStepUsedMaterial = (ITTListBoxColumn)AddControl(new Guid("59e64a6c-0a79-498d-b030-22e6d9b1487c"));
            WorkStepUsedMaterialDistType = (ITTListBoxColumn)AddControl(new Guid("3211f275-ec2f-4310-95f2-d8fcdeca8154"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("4a667d42-294e-4c54-90f6-e2fa1de95a62"));
            UnitAmout = (ITTTextBoxColumn)AddControl(new Guid("27558258-dac2-4553-a785-01d484f4cde8"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("6a2cb318-64a6-4931-9414-23eecac97b64"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("800948f8-bf99-46d2-ba50-909648142f35"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("d3d0868b-afff-4c4e-a0f8-d35582a049ba"));
            cmdForkWorkStep = (ITTButton)AddControl(new Guid("17cdc4ce-db72-47a5-ae02-876d70ca05cd"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("ceba221a-6234-41da-bdcf-9baaf711e378"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("cfc7f7d1-fb96-473a-a276-409a4856670b"));
            SenderSection = (ITTObjectListBox)AddControl(new Guid("b1473c7f-f7a5-4efc-8278-94206f927d1b"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("e2d9644f-f64e-44ab-a0cb-f8e036749a04"));
            RequestNO = (ITTTextBox)AddControl(new Guid("1406bea2-4691-48d1-831b-317beb76327a"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("88052de9-e135-423f-a0d3-839e0307b6cd"));
            labelActionDate = (ITTLabel)AddControl(new Guid("8a99cc6a-db75-4dc2-801c-d659c30ce9e0"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("d9a2691d-0d1d-43bd-a427-885a87b93dc7"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("d0dc0f2c-d443-422c-9c76-4dd2961899d5"));
            RepairWorkLoad = (ITTTextBox)AddControl(new Guid("8654c41e-51d7-4269-9c5b-b7459f52c026"));
            labelRepairWorkLoad = (ITTLabel)AddControl(new Guid("122cf4ba-a4c0-4684-a78d-8040219e5e25"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("839ba727-46c1-47ca-9e9f-d3bcc7bc4ab5"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("c22db635-842b-4f55-bc1d-3400c5b2a7e2"));
            labelOrderName = (ITTLabel)AddControl(new Guid("abe6c2c7-f6bc-4b3f-ac80-d27a33771969"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("1f9c1f22-957e-426d-8606-6f8660d40294"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("8447589c-6f25-43fc-804b-4a284f6c0d80"));
            OrderNO = (ITTTextBox)AddControl(new Guid("53e44a48-78a8-4ed2-97c3-ce5c57622b86"));
            labelFromResource = (ITTLabel)AddControl(new Guid("33fa69b8-e264-47e3-8760-05eadee9ed75"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("9232d20b-f6ae-4def-a448-be20f2d45c53"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("f9ef4c1c-23e7-43a0-85c6-bcf9b0c786a0"));
            OrderTypeList = (ITTObjectListBox)AddControl(new Guid("5a2f6976-18a3-4a1b-954e-0d885a34ffe5"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("bedf3d6b-60cb-4589-b508-b9ab73b36858"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("1a8ba059-da69-4fec-a712-0ee9ea13c500"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("cac50e26-de08-441a-a242-9c7514fd180c"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("dff7cc03-5f18-46ad-935a-9a48a25a5b4f"));
            labelID = (ITTLabel)AddControl(new Guid("236d97e2-205f-4cfe-9963-87059d86b07b"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("650703b1-ae4a-4781-a4c5-81bb149bccee"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("037ff43a-e266-4d31-9a07-4a4756c9a3e9"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("8d1f9520-5a41-4a08-91b8-67108e867db5"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("883ad919-2800-4997-a13d-5e087b1ef409"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("6466b7a2-399a-49de-9655-5c399813af35"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("902b73e1-bb03-4892-8bbe-e5e329ad3a98"));
            cmdAddSignDetail = (ITTButton)AddControl(new Guid("b7ce012e-b2fc-4d58-9e6b-f9021c7845e6"));
            ServiceProcurementSignDetails = (ITTGrid)AddControl(new Guid("8911f08c-939a-4bdf-9dd1-b7dc48b5b1bc"));
            SignUserTypeCMRActionSignDetail = (ITTEnumComboBoxColumn)AddControl(new Guid("84c91085-7b49-4732-b65b-d6eda1e21ceb"));
            SignUserCMRActionSignDetail = (ITTListBoxColumn)AddControl(new Guid("be2589a6-83dd-49c4-9c09-b7bc03ff2d4d"));
            IsDeputyCMRActionSignDetail = (ITTCheckBoxColumn)AddControl(new Guid("3bbf9946-46e4-4f0e-b524-b7b9e9d66c44"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("63e42747-17b3-4c0f-b216-242d1187521c"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("71ba72d1-c3a2-4e29-93bf-1ab9b1da0f13"));
            cmdForkDemand = (ITTButton)AddControl(new Guid("48133461-e603-4eea-9f03-5fb62f09e54a"));
            DetailDescription = (ITTRichTextBoxControl)AddControl(new Guid("5c6d543a-af17-45d4-8a36-6ee083b9cbd8"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("3fde71cc-c916-49e0-a0b6-5abfb4a51ff9"));
            PurchaseItem = (ITTObjectListBox)AddControl(new Guid("5e761e5f-e133-47de-9579-b5362f2d4e66"));
            tttabpage6 = (ITTTabPage)AddControl(new Guid("5bf79730-4e0b-494f-aa0b-d31b7d3cf779"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("99c9ca8c-70e8-46be-9ce0-5b84c3a1cd44"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("314e8f3f-7fd4-4fb1-9f4e-1e8064cd8783"));
            UserMaintenances = (ITTGrid)AddControl(new Guid("f9e39159-05fa-427f-bff4-68605531d1f4"));
            UserParameter = (ITTListBoxColumn)AddControl(new Guid("761166e8-3fd1-4703-a28a-d7830c9b5693"));
            UserChecked = (ITTCheckBoxColumn)AddControl(new Guid("f70470fa-35c2-483d-a921-8bb6dd0788a9"));
            UserDescription = (ITTTextBoxColumn)AddControl(new Guid("e5aa6c0d-bdd8-4069-a0c8-9dc5ff162631"));
            UnitMaintenances = (ITTGrid)AddControl(new Guid("a09e277e-3d94-4b38-aae7-a54341394983"));
            UnitParameter = (ITTListBoxColumn)AddControl(new Guid("34f24a5a-5d5f-4e53-8508-c49a5cddf42d"));
            UnitChecked = (ITTCheckBoxColumn)AddControl(new Guid("4ebdf5b3-fa45-48c0-b700-2885a82da154"));
            UnitDescription = (ITTTextBoxColumn)AddControl(new Guid("7df12de3-fbec-4003-897c-6a0892bd3682"));
            tttabpage7 = (ITTTabPage)AddControl(new Guid("402c70bc-da6b-4f7b-bb94-a090c942750b"));
            Agenda = (ITTTextBox)AddControl(new Guid("4b8af3a0-5aeb-4c5d-b9a3-e90fa7bc57ab"));
            labelPreventiveTreatmentWorkLoad = (ITTLabel)AddControl(new Guid("a05818e8-0c3d-4985-946f-3a3622c9a377"));
            labelErrorReason = (ITTLabel)AddControl(new Guid("7c676a4c-16b8-434a-8d4d-526ddc9ec894"));
            labelPreventiveTreatment = (ITTLabel)AddControl(new Guid("e567961b-91f9-4554-a382-ff4851a9826d"));
            PreventiveTreatment = (ITTTextBox)AddControl(new Guid("1f67b3ac-84e6-4744-9ff7-8d205d9d7e8d"));
            labelAgenda = (ITTLabel)AddControl(new Guid("20a57b43-6097-4bab-84a8-3ef53db0b453"));
            PreventiveTreatmentWorkLoad = (ITTTextBox)AddControl(new Guid("7c8eb6e3-a97b-41f1-86e8-d1065abc6aec"));
            ErrorReason = (ITTTextBox)AddControl(new Guid("825674e4-0288-4d25-b156-4d2c9b155ea0"));
            WorkStepsGrid = (ITTGrid)AddControl(new Guid("129f4e2d-e82e-4fae-9d30-18163a08558e"));
            WorkShop = (ITTListBoxColumn)AddControl(new Guid("2afd6a25-1e44-4b79-ac5d-67ba781c8402"));
            Personel = (ITTListBoxColumn)AddControl(new Guid("aabd6080-66de-4fa7-9f60-d73163a709e9"));
            Workload = (ITTTextBoxColumn)AddControl(new Guid("fa4dd2b9-a30d-4133-bc4e-ac5e443c87cc"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("ce1e88af-e027-48b5-a30b-f8e265eb58ce"));
            chkOrderCompleted = (ITTCheckBox)AddControl(new Guid("7546e9e6-1de6-4c04-925a-64e5ace53db3"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("07086a8f-32cb-47e3-8ec2-758ccf55c21d"));
            base.InitializeControls();
        }

        public RepairForm_MaintenanceO() : base("MAINTENANCEORDER", "RepairForm_MaintenanceO")
        {
        }

        protected RepairForm_MaintenanceO(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}