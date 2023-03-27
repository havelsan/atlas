
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
    /// Kalibrasyon [Stok Numaralı]
    /// </summary>
    public partial class MaterialCalibrationForm : CalibrationBaseForm
    {
    /// <summary>
    /// Kalibrasyon [Stok Numaralı]
    /// </summary>
        protected TTObjectClasses.MaterialCalibration _MaterialCalibration
        {
            get { return (TTObjectClasses.MaterialCalibration)_ttObject; }
        }

        protected ITTLabel labelRequestNO;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGroupBox ttgroupbox2;
        protected ITTCheckBox FullCalibration;
        protected ITTCheckBox LimitedCalibration;
        protected ITTCheckBox NoNeedCalibration;
        protected ITTCheckBox NotCalibration;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTGrid ttgrid2;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount;
        protected ITTLabel ttlabel3;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn Calibrator;
        protected ITTTextBoxColumn Traceability;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel9;
        protected ITTGrid CalibrationTests;
        protected ITTListBoxColumn CalibrationTestDefinition;
        protected ITTTextBoxColumn ApplicableTestCount;
        protected ITTTextBoxColumn ExistingTestCount;
        protected ITTButtonColumn cmdReport;
        protected ITTTabPage tttabpage2;
        protected ITTTextBox tttextbox6;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox HumidityDeviationText;
        protected ITTTextBox TemperatureDeviationText;
        protected ITTTextBox TemperatureText;
        protected ITTLabel ttlabel23;
        protected ITTLabel ttlabel22;
        protected ITTLabel ttlabel16;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel15;
        protected ITTLabel ttlabel18;
        protected ITTLabel ttlabel17;
        protected ITTTextBox RelativeHumidityText;
        protected ITTObjectListBox ttobjectlistbox3;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTTextBox tttextbox5;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel10;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel19;
        protected ITTLabel labelStartDate;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel6;
        protected ITTTabPage tttabpage3;
        protected ITTCheckBox NotCalibreReason1;
        protected ITTCheckBox NotCalibreReason3;
        protected ITTCheckBox NotCalibreReason2;
        protected ITTCheckBox NotCalibreReason4;
        protected ITTCheckBox NotCalibreReason5;
        protected ITTTextBox NotCalibreReasonDesc;
        protected ITTLabel labelNotCalibreReasonDesc;
        protected ITTTabPage tttabpage4;
        protected ITTLabel ttlabel20;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTLabel ttlabel21;
        protected ITTButton cmdForkDemand;
        protected ITTObjectListBox PurchaseItem;
        protected ITTTabPage tttabpage5;
        protected ITTLabel ttlabel25;
        protected ITTLabel ttlabel24;
        protected ITTGrid UsedConsumedMaterails;
        protected ITTListBoxColumn MaterialUsedConsumedMaterail;
        protected ITTTextBoxColumn RequestAmountUsedConsumedMaterail;
        protected ITTTextBoxColumn SuppliedAmountUsedConsumedMaterail;
        protected ITTTextBoxColumn AmountUsedConsumedMaterail;
        protected ITTTextBoxColumn UnitPriceUsedConsumedMaterail;
        protected ITTGrid CalibrationConsumedMaterials;
        protected ITTListBoxColumn MaterialCalibrationConsumedMat;
        protected ITTTextBoxColumn SparePartMaterialDescriptionCalibrationConsumedMat;
        protected ITTTextBoxColumn RequestAmountCalibrationConsumedMat;
        protected ITTTextBoxColumn DescriptionCalibrationConsumedMat;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox RequestNO;
        protected ITTTextBox Description;
        protected ITTLabel CalibrationStatusLabel;
        protected ITTLabel ttlabel5;
        protected ITTLabel labelDescription;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ttobjectlistbox4;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelFixedAsset;
        override protected void InitializeControls()
        {
            labelRequestNO = (ITTLabel)AddControl(new Guid("7d7df2df-0e4a-4396-b8c0-88a8c23fc697"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("4247a8af-8c5d-45ba-a2e2-5ba23470f9e1"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("162079b9-971e-408d-b066-3d536303660b"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("1de171eb-857c-4b53-9f0d-49662e124b78"));
            FullCalibration = (ITTCheckBox)AddControl(new Guid("3c0d63d9-5593-45d9-931b-fb778ab4c65c"));
            LimitedCalibration = (ITTCheckBox)AddControl(new Guid("1dd6df2c-659c-4ae4-bf14-1923895ae3b1"));
            NoNeedCalibration = (ITTCheckBox)AddControl(new Guid("097781e6-07ff-4982-b60c-64ed26b9ec9e"));
            NotCalibration = (ITTCheckBox)AddControl(new Guid("93ea4a6c-4025-4035-b4a9-5049c9a2e4d2"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("21e3387d-7a72-4387-8b78-e21cc9cf8da2"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("8f680410-b220-4a0d-a2e6-c2eef86393de"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("4b6fdd16-f7fd-49f3-bf0e-0d3d4b2bda33"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("92ff164f-449f-4361-858a-f09429d1f7ed"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("e578d8be-36f8-49a5-bc1f-ee36487b7095"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("d8b02af0-d6f6-41fd-9e97-9dc7282a6c34"));
            Calibrator = (ITTListBoxColumn)AddControl(new Guid("8b570e46-2cef-44f8-89f2-79527aebdd35"));
            Traceability = (ITTTextBoxColumn)AddControl(new Guid("7f1fe33c-6b1d-4a63-a47a-79ed4c8e7ed8"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("80cd8b17-cf16-42a6-a444-c2d37966534c"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("e9f09e92-17c7-4f2e-a16e-bd43a7e44085"));
            CalibrationTests = (ITTGrid)AddControl(new Guid("20012b5b-e624-424a-9bad-bbac2c7aec53"));
            CalibrationTestDefinition = (ITTListBoxColumn)AddControl(new Guid("290de76f-3e79-4acd-95d6-88e1e2dadcaa"));
            ApplicableTestCount = (ITTTextBoxColumn)AddControl(new Guid("f5a7de57-d21f-4d6e-b1ba-c29daf2d645b"));
            ExistingTestCount = (ITTTextBoxColumn)AddControl(new Guid("853f275d-99ee-42cc-b0a9-9ec8bf44a63a"));
            cmdReport = (ITTButtonColumn)AddControl(new Guid("57637072-e9a2-419c-a263-5aef336b98f5"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("514fb6f4-e77a-404a-a911-c2b4976ad30e"));
            tttextbox6 = (ITTTextBox)AddControl(new Guid("a70a2e67-fb54-4f21-a105-ad8db58a773f"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("8103d7ba-c9b5-44b6-b31f-f5099d17036e"));
            HumidityDeviationText = (ITTTextBox)AddControl(new Guid("9530ba6c-925d-4747-b14a-851c3a785763"));
            TemperatureDeviationText = (ITTTextBox)AddControl(new Guid("76c0e82d-c509-4248-a308-f791715a4882"));
            TemperatureText = (ITTTextBox)AddControl(new Guid("01bca56b-c549-4bea-a622-17c81fc4c7fa"));
            ttlabel23 = (ITTLabel)AddControl(new Guid("b5c33a86-1c62-45fc-ba2b-9c27933876c8"));
            ttlabel22 = (ITTLabel)AddControl(new Guid("359b3cb5-6212-4c9d-9da1-6d97eb9cc665"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("679b6f8a-9d80-49d4-ab80-63e2dd23779c"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("19841bd2-1137-42c2-8db0-c6dacee06bd9"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("7d6f4da8-7d11-4f41-87c4-37e912624108"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("9eb92b4f-07d4-4d4f-afda-0a1dc307e9f3"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("714a8fe9-b418-4d48-98c0-e898ac537c92"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("67a416db-32dd-42d9-9eb7-61df83769d9a"));
            RelativeHumidityText = (ITTTextBox)AddControl(new Guid("731fb9e2-2210-40e1-8b57-fff7f90c2fc3"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("d05375ee-a2d3-40cf-847a-4844c2332a3d"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("799f7aae-002d-4685-807b-e3deed0892bb"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("391c3894-4902-49a0-92ca-47f328f7813f"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("733b1c0f-520c-447e-a061-5dffeeb71781"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("d23ec9fe-9493-4b57-b56b-a3328300d607"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("53926937-6334-43a8-8b26-9aee6af889af"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("6965b3ae-4c0d-4c37-a3b7-09ffec37d6fe"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("a813df0f-ac2d-4174-a627-85033839eae9"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("f815a287-f19b-466a-b051-7eee3d889bf3"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("7bdefda3-11f2-41bf-9be6-ab5acd501c71"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("e121ace6-e326-46c2-a50a-2618dabfcbd9"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("07126299-96e1-4a05-96b8-78a9d45ad408"));
            labelStartDate = (ITTLabel)AddControl(new Guid("fc912478-990a-4343-a34f-72ac378d1150"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("c6bc35f5-0de3-42fa-bd19-511b978266cc"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("9118ddd8-e884-49df-ad6d-1666c9f90be6"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("d3946fc1-b934-4a22-855a-d05e428a5198"));
            NotCalibreReason1 = (ITTCheckBox)AddControl(new Guid("91246f16-e08b-4974-8484-8b6424ddf014"));
            NotCalibreReason3 = (ITTCheckBox)AddControl(new Guid("8e0cfb47-9a4a-45c7-9f2f-3ccfa88c5649"));
            NotCalibreReason2 = (ITTCheckBox)AddControl(new Guid("aa009795-20bf-4fdc-8b73-03818cb0ae70"));
            NotCalibreReason4 = (ITTCheckBox)AddControl(new Guid("09ffbed6-6b09-43a9-aa65-71c11047815d"));
            NotCalibreReason5 = (ITTCheckBox)AddControl(new Guid("ca015552-74fe-482a-995a-b184e15be11c"));
            NotCalibreReasonDesc = (ITTTextBox)AddControl(new Guid("6099be7c-04b9-4d6c-9bc2-63a5630a694c"));
            labelNotCalibreReasonDesc = (ITTLabel)AddControl(new Guid("ea84d93d-ae24-4ae4-b6e7-b498c8c421e0"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("350a25c1-78c0-4aca-b1fc-7e1fa6235ead"));
            ttlabel20 = (ITTLabel)AddControl(new Guid("603fae03-f6ae-4c7f-b580-2cd56afee6ea"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("f88bd268-ae9f-4269-b7d2-a9105fa5d45f"));
            ttlabel21 = (ITTLabel)AddControl(new Guid("16cb1d7b-d061-49a9-a644-1e4221e19eca"));
            cmdForkDemand = (ITTButton)AddControl(new Guid("5202f187-da22-48a1-b3dc-e5b64854698e"));
            PurchaseItem = (ITTObjectListBox)AddControl(new Guid("df42f4c8-c226-4811-8491-aeb838e1ae70"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("f3029b01-26ab-49f3-a062-3a19f2d1fd27"));
            ttlabel25 = (ITTLabel)AddControl(new Guid("948610ae-2343-4088-b6d5-fb081b0a5f97"));
            ttlabel24 = (ITTLabel)AddControl(new Guid("7853417c-d3fa-4830-9be5-b3d8a853a0d2"));
            UsedConsumedMaterails = (ITTGrid)AddControl(new Guid("aaf8489a-3a42-468e-806a-42db0a1b81ed"));
            MaterialUsedConsumedMaterail = (ITTListBoxColumn)AddControl(new Guid("0b6891a6-94dc-47e1-8250-5a0e17bddb1e"));
            RequestAmountUsedConsumedMaterail = (ITTTextBoxColumn)AddControl(new Guid("71e8935f-a4f7-4a48-9066-57d50c421bfa"));
            SuppliedAmountUsedConsumedMaterail = (ITTTextBoxColumn)AddControl(new Guid("11ebeed4-8cfc-4a59-9c4d-215c9907c9fa"));
            AmountUsedConsumedMaterail = (ITTTextBoxColumn)AddControl(new Guid("4dc9bbf8-9c5b-4b15-8e56-3821b12dae60"));
            UnitPriceUsedConsumedMaterail = (ITTTextBoxColumn)AddControl(new Guid("f350e2e2-2de6-4b2d-a57f-f0d73408bb39"));
            CalibrationConsumedMaterials = (ITTGrid)AddControl(new Guid("6beb13a1-4395-41cc-b882-c5b76e4da05d"));
            MaterialCalibrationConsumedMat = (ITTListBoxColumn)AddControl(new Guid("da84592d-f9f3-4767-81f7-6a548819a733"));
            SparePartMaterialDescriptionCalibrationConsumedMat = (ITTTextBoxColumn)AddControl(new Guid("95a2d2be-6689-44c9-886f-865dec3c6aaa"));
            RequestAmountCalibrationConsumedMat = (ITTTextBoxColumn)AddControl(new Guid("532aaa60-babc-4b74-b879-390759e80e15"));
            DescriptionCalibrationConsumedMat = (ITTTextBoxColumn)AddControl(new Guid("6d608075-88e6-4697-ac17-46a750e2c7e2"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("b112fb9e-638a-4118-9fe2-658759b3668f"));
            RequestNO = (ITTTextBox)AddControl(new Guid("5e2af6f9-ff73-473d-802d-3bd27c70a852"));
            Description = (ITTTextBox)AddControl(new Guid("4a3e1b04-188b-4817-abf7-0decd61d67b4"));
            CalibrationStatusLabel = (ITTLabel)AddControl(new Guid("41c0d6ec-05fa-4ef2-a559-8e7badf25a09"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("03cd297e-7ee0-41a5-a297-3a9ccb842e10"));
            labelDescription = (ITTLabel)AddControl(new Guid("bd364aa8-0f22-4d06-adaf-6a691ff61cb4"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("60ece8f0-938c-4050-ae80-61375a6450de"));
            ttobjectlistbox4 = (ITTObjectListBox)AddControl(new Guid("e887eb7c-1fe1-413c-a2f5-5c4893b9111f"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("4fcac509-00a4-44b9-8982-d537c4d8b0eb"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("fc797d4e-0c5b-4dca-9f51-8bb37cdac260"));
            base.InitializeControls();
        }

        public MaterialCalibrationForm() : base("MATERIALCALIBRATION", "MaterialCalibrationForm")
        {
        }

        protected MaterialCalibrationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}