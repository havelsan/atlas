
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
    public partial class ProjectDetailingForm : TTForm
    {
    /// <summary>
    /// Mahalli Satınalma Ana Sınıfı
    /// </summary>
        protected TTObjectClasses.PurchaseProject _PurchaseProject
        {
            get { return (TTObjectClasses.PurchaseProject)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage ProjectInfo;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage tttabpage3;
        protected ITTObjectListBox Budget;
        protected ITTObjectListBox TTListBox;
        protected ITTLabel ttlabel23;
        protected ITTLabel labelConfirmNO;
        protected ITTDateTimePicker ConfirmDate;
        protected ITTLabel ttlabel21;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel12;
        protected ITTLabel labelPurchaseProjectNO;
        protected ITTTextBox PurchaseProjectNO;
        protected ITTTextBox InvestmentProjectNO;
        protected ITTLabel ttlabel8;
        protected ITTLabel labelConfirmDate;
        protected ITTTextBox ConfirmNO;
        protected ITTObjectListBox PurchaseType;
        protected ITTLabel ttlabel2;
        protected ITTEnumComboBox PurchaseTypeMatPro;
        protected ITTTextBox SpecificationPrice;
        protected ITTLabel ttlabel20;
        protected ITTEnumComboBox PurchaseMainType;
        protected ITTTextBox ActAttribute;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel1;
        protected ITTEnumComboBox ProcurementType;
        protected ITTTextBox ActCount;
        protected ITTLabel ttlabel11;
        protected ITTEnumComboBox AnnounceTypeandCount;
        protected ITTLabel ttlabel6;
        protected ITTTextBox AnnouncementDesc;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel9;
        protected ITTEnumComboBox EvaluationType;
        protected ITTLabel ttlabel5;
        protected ITTTextBox ActDefine;
        protected ITTLabel ttlabel4;
        protected ITTTabPage tttabpage2;
        protected ITTCheckBox AttachmentList;
        protected ITTObjectListBox PerformerRank;
        protected ITTLabel ttlabel14;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel7;
        protected ITTTextBox tttextbox3;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel25;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel26;
        protected ITTLabel ttlabel24;
        protected ITTCheckBox Advanced;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel22;
        protected ITTLabel ttlabel16;
        protected ITTObjectListBox Expenser;
        protected ITTTextBox ExpenserDuty;
        protected ITTCheckBox ShowApproximatePriceOnReport;
        protected ITTObjectListBox ExpenserRank;
        protected ITTLabel ttlabel19;
        protected ITTDateTimePicker SufficiencyDueDate;
        protected ITTObjectListBox Performer;
        protected ITTTextBox PerformerDuty;
        protected ITTLabel ttlabel15;
        protected ITTCheckBox PriceDifference;
        protected ITTLabel lblSufficiencyDueDate;
        protected ITTLabel ttlabel18;
        protected ITTLabel ttlabel17;
        protected ITTTabPage ApproveFormDesc;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTabPage AdministrativeSpecificationTab;
        protected ITTRichTextBoxControl AdministrativeSpecificationRTF;
        protected ITTToolStrip actionButtonsStrip;
        protected ITTTabControl ProjectDetails;
        protected ITTTabPage ItemsTab;
        protected ITTGrid PurchaseProjectDetails;
        protected ITTTextBoxColumn OrderNO;
        protected ITTListBoxColumn PurchaseItemDef;
        protected ITTTextBoxColumn GMDNNo;
        protected ITTTextBoxColumn NSN;
        protected ITTTextBoxColumn PurchaseItemUnitType;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTRichTextBoxControlColumn Isayf;
        protected ITTRichTextBoxControlColumn FeasibilityEtude;
        protected ITTDateTimePickerColumn ContractStartDate;
        protected ITTTextBoxColumn ContractTime;
        protected ITTDateTimePickerColumn ContractEndDate;
        protected ITTDateTimePickerColumn WorkStartDate;
        protected ITTTextBoxColumn WorkTime;
        protected ITTDateTimePickerColumn WorkEndDate;
        protected ITTDateTimePickerColumn GuarantyStartDate;
        protected ITTTextBoxColumn GuarantyTime;
        protected ITTDateTimePickerColumn GuarantyEndDate;
        protected ITTButtonColumn Details;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("546ecd80-d307-4258-a88a-ea202587ab4c"));
            ProjectInfo = (ITTTabPage)AddControl(new Guid("a6b86ad0-9e71-4274-ba19-22b2ca0c1b26"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("d4533424-c4d7-454d-9f2c-30277fa7ab2f"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("501e9117-c967-4522-a185-1afb02d0c75c"));
            Budget = (ITTObjectListBox)AddControl(new Guid("7d1133b5-eaa7-465c-a128-0adc383013d1"));
            TTListBox = (ITTObjectListBox)AddControl(new Guid("cc76a22f-3552-4d2c-81ab-f677848fafee"));
            ttlabel23 = (ITTLabel)AddControl(new Guid("a907fdd0-dabd-4aa4-ab80-5e1fb6ac4196"));
            labelConfirmNO = (ITTLabel)AddControl(new Guid("121295bb-9edc-4919-bcdd-1704282f1642"));
            ConfirmDate = (ITTDateTimePicker)AddControl(new Guid("d6a75923-d410-4821-b344-60fee727a027"));
            ttlabel21 = (ITTLabel)AddControl(new Guid("4c4e55ab-ed38-426d-ab06-dc9dc381f732"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("4e29de43-2ce4-484f-9b27-c928bef8e076"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("4940d3dc-a207-4f69-9a2d-2d92c4c0a157"));
            labelPurchaseProjectNO = (ITTLabel)AddControl(new Guid("7dbd8a99-9727-44c1-a82b-9840266be1a2"));
            PurchaseProjectNO = (ITTTextBox)AddControl(new Guid("f7cd649c-ad43-4345-8a07-66157ca92994"));
            InvestmentProjectNO = (ITTTextBox)AddControl(new Guid("b2a1c022-154e-40d5-ad54-f835cfade621"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("6610ffdb-adb2-480b-b37f-d429e5f0c23e"));
            labelConfirmDate = (ITTLabel)AddControl(new Guid("a7c7ecfb-50fa-40ff-9ca3-d5d74450ea21"));
            ConfirmNO = (ITTTextBox)AddControl(new Guid("f61905bf-0e73-47fe-b34f-f26c9aba7b31"));
            PurchaseType = (ITTObjectListBox)AddControl(new Guid("cbd733fc-08fa-4119-857a-367cb96a7d0d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("4a9f2cac-bec6-4430-9735-61b924020718"));
            PurchaseTypeMatPro = (ITTEnumComboBox)AddControl(new Guid("765dda38-3b50-4023-9dde-6f7b959a4afd"));
            SpecificationPrice = (ITTTextBox)AddControl(new Guid("796fc535-b618-40e0-86df-01c17a5413b9"));
            ttlabel20 = (ITTLabel)AddControl(new Guid("3dec32ff-5b08-4cf0-a858-604fab0d2691"));
            PurchaseMainType = (ITTEnumComboBox)AddControl(new Guid("920a9bc4-6705-40e6-816f-a4a646096538"));
            ActAttribute = (ITTTextBox)AddControl(new Guid("e1c59ee6-661a-4b08-9c3d-0a2d4a3ba6fd"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("57fb8466-7964-47f2-ab61-bed27ff8ee9f"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("31649bbd-7424-424b-89ac-234e0465214e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3babbb13-aa96-45ce-bc7c-d2891a4df01b"));
            ProcurementType = (ITTEnumComboBox)AddControl(new Guid("3c1f8b2c-9e4a-42b4-ae06-21120bbec1a4"));
            ActCount = (ITTTextBox)AddControl(new Guid("36a3fc89-578e-4f6c-9dc8-e72b363ed17f"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("ef0992dd-c017-440b-b3c9-c6bbeea990dd"));
            AnnounceTypeandCount = (ITTEnumComboBox)AddControl(new Guid("ea4c14ac-cc42-4945-8881-036da2517e66"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("54076ff4-2e98-418d-8018-df55d2add9aa"));
            AnnouncementDesc = (ITTTextBox)AddControl(new Guid("9122992c-1f7f-4958-b687-b6a54c6aac4b"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("5ff46c8f-ad6c-455f-9022-bc785a4eb7a1"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("38a5d2df-14b2-4e18-9d21-4a93896a3b33"));
            EvaluationType = (ITTEnumComboBox)AddControl(new Guid("168d121e-127b-471a-9d73-b87b826b7968"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("1b5117ac-7491-4655-ab85-50f9f81ac516"));
            ActDefine = (ITTTextBox)AddControl(new Guid("03a14bab-f07f-42d2-82af-b3225f3e386d"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("b025de80-95b9-465b-b5ac-54ac75012e5c"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("6b45d406-1e93-4548-8c0b-0e3d557a93b7"));
            AttachmentList = (ITTCheckBox)AddControl(new Guid("fa1f56e6-c4ab-4b29-a39d-7abdec320600"));
            PerformerRank = (ITTObjectListBox)AddControl(new Guid("828b31c0-62a5-4e5f-92b3-a11c043e5b0c"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("7ca77971-3bac-4d69-af2b-a6865fa95520"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("ad774bb7-f659-4c16-9010-f77d2fb12a5c"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("e48f1d73-915b-45e1-9f15-9d29d2cf49c1"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("cb683224-0220-4f21-bd7d-acf19e132c6e"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("e592ca40-d988-49b5-85a4-a1e913cd304d"));
            ttlabel25 = (ITTLabel)AddControl(new Guid("f8f1ba8a-0e0f-46b5-910a-b8e392d816b7"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("477a5e6f-06a5-4b45-9bde-d598cfb46975"));
            ttlabel26 = (ITTLabel)AddControl(new Guid("5fc15d53-a0b2-41ee-8a44-51fa4fc6fe31"));
            ttlabel24 = (ITTLabel)AddControl(new Guid("6d6daf62-f580-4599-9d95-667a06552a5d"));
            Advanced = (ITTCheckBox)AddControl(new Guid("041be8f9-036c-424e-8a57-099c7dd2ae45"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("41c6f8c1-0fdc-4ed3-b434-6b8fbb7529a5"));
            ttlabel22 = (ITTLabel)AddControl(new Guid("ec9d27a6-9570-4b6b-a638-794b9c282cfb"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("54297a22-0ac7-465a-9b5a-f02fb2caf70a"));
            Expenser = (ITTObjectListBox)AddControl(new Guid("a0efa8b6-b755-4bbf-ac9d-128f21f8dce2"));
            ExpenserDuty = (ITTTextBox)AddControl(new Guid("11fb9ccc-fbb0-49b2-8902-842497526296"));
            ShowApproximatePriceOnReport = (ITTCheckBox)AddControl(new Guid("f2828548-67fe-4c86-bd6a-4d092af7d69d"));
            ExpenserRank = (ITTObjectListBox)AddControl(new Guid("76e7edb6-47f1-4c03-ad3d-4220c6fac97d"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("ae619d4d-2f72-48cb-bf76-2949130f3879"));
            SufficiencyDueDate = (ITTDateTimePicker)AddControl(new Guid("ea928ecb-282f-4369-95dd-d911daa4b414"));
            Performer = (ITTObjectListBox)AddControl(new Guid("4831bd97-598c-4a49-a922-32a6a00ca70b"));
            PerformerDuty = (ITTTextBox)AddControl(new Guid("e7afb763-4caf-4454-b3cd-27450b3ad8ce"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("245b7a54-8b48-413d-a566-27d7c3cee9fd"));
            PriceDifference = (ITTCheckBox)AddControl(new Guid("5b41b50a-3c92-4446-81fd-e203ec0501da"));
            lblSufficiencyDueDate = (ITTLabel)AddControl(new Guid("bcb56abf-8d12-4dcf-b5a0-5217030e0fff"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("f0c6a7b5-9439-4ea2-a7c7-0ac5f9625301"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("6cd1ad77-99dd-4bb1-9f98-4e82b641d04f"));
            ApproveFormDesc = (ITTTabPage)AddControl(new Guid("e1ba5886-447b-4571-b837-ed7f46d60828"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("3ae87565-a52f-4a9c-b6be-e2574d505e4e"));
            AdministrativeSpecificationTab = (ITTTabPage)AddControl(new Guid("d54452ec-f80f-44ba-9643-3063dbf490f6"));
            AdministrativeSpecificationRTF = (ITTRichTextBoxControl)AddControl(new Guid("66b8fc3a-df01-4135-9ab5-15d98966ad3e"));
            actionButtonsStrip = (ITTToolStrip)AddControl(new Guid("f18b3875-c2f9-42f7-81fe-00fd2777d147"));
            ProjectDetails = (ITTTabControl)AddControl(new Guid("49ab3064-9871-4dd7-ac3d-ec2e6741e531"));
            ItemsTab = (ITTTabPage)AddControl(new Guid("89933345-7b65-44e3-9707-275160c0b063"));
            PurchaseProjectDetails = (ITTGrid)AddControl(new Guid("28aab078-b4be-44ab-852f-a25f2923dc88"));
            OrderNO = (ITTTextBoxColumn)AddControl(new Guid("63c9511d-40db-4ff9-a2c1-f966af8276a2"));
            PurchaseItemDef = (ITTListBoxColumn)AddControl(new Guid("4c1ac727-2259-4196-bc10-f4f7b9f01aae"));
            GMDNNo = (ITTTextBoxColumn)AddControl(new Guid("23ea7144-485c-4d80-a4ef-0c411ab695ce"));
            NSN = (ITTTextBoxColumn)AddControl(new Guid("9c49957d-cc48-465c-a39a-ee3ee5935f9a"));
            PurchaseItemUnitType = (ITTTextBoxColumn)AddControl(new Guid("4b26df65-b601-4637-87ba-dd4938680021"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("9795f40e-3316-4911-a8ab-203a070f8391"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("c619b85b-9471-442f-8430-9dfe04f6beab"));
            Isayf = (ITTRichTextBoxControlColumn)AddControl(new Guid("b3fce9d1-2139-4298-a48a-2dfc86a7194b"));
            FeasibilityEtude = (ITTRichTextBoxControlColumn)AddControl(new Guid("84a01d63-62ef-4935-a43f-a0f004353098"));
            ContractStartDate = (ITTDateTimePickerColumn)AddControl(new Guid("7f6c564f-172e-42f2-a8c9-c5700e8d949f"));
            ContractTime = (ITTTextBoxColumn)AddControl(new Guid("30367a82-4358-4b28-958c-c2ae7ab316ef"));
            ContractEndDate = (ITTDateTimePickerColumn)AddControl(new Guid("9a4b3aed-912b-4c0d-827e-2a5ed5ef1695"));
            WorkStartDate = (ITTDateTimePickerColumn)AddControl(new Guid("0da46a37-aa96-4b1f-9a8f-2438e56e09c6"));
            WorkTime = (ITTTextBoxColumn)AddControl(new Guid("fe17844b-6de1-4ef9-b314-df99cecf0491"));
            WorkEndDate = (ITTDateTimePickerColumn)AddControl(new Guid("ce0d9c5b-e0b7-46e6-ad91-a19b73a015a3"));
            GuarantyStartDate = (ITTDateTimePickerColumn)AddControl(new Guid("92a32102-a261-4480-ac6b-983daafb4780"));
            GuarantyTime = (ITTTextBoxColumn)AddControl(new Guid("e19b7582-a978-4356-8788-9a0f56eb6caf"));
            GuarantyEndDate = (ITTDateTimePickerColumn)AddControl(new Guid("2ad7d782-f5f8-4600-86f0-b255418a488b"));
            Details = (ITTButtonColumn)AddControl(new Guid("dd6bd2e1-6d48-4a0b-9a41-1c46159e6ac6"));
            base.InitializeControls();
        }

        public ProjectDetailingForm() : base("PURCHASEPROJECT", "ProjectDetailingForm")
        {
        }

        protected ProjectDetailingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}