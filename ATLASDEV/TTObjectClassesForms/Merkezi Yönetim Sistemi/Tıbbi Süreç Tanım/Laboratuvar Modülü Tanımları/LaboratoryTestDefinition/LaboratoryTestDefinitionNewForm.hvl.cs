
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
    /// Laboratuvar Tetkik Tanımları
    /// </summary>
    public partial class LaboratoryTestDefinitionNewForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Laboratuvar Tetkik Tanımları
    /// </summary>
        protected TTObjectClasses.LaboratoryTestDefinition _LaboratoryTestDefinition
        {
            get { return (TTObjectClasses.LaboratoryTestDefinition)_ttObject; }
        }

        protected ITTObjectListBox TTListBox;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox TestName;
        protected ITTLabel ttlabel10;
        protected ITTCheckBox chkPassiveNow;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelName;
        protected ITTTabControl TabControlInfos;
        protected ITTTabPage TabPageGeneralInfo;
        protected ITTLabel lblDefaultTab;
        protected ITTObjectListBox DefaultTab;
        protected ITTCheckBox chkPrintInOneReport;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTCheckBox IsPrintEveryPage;
        protected ITTCheckBox IsSexControl;
        protected ITTCheckBox IsRestrictedTest;
        protected ITTLabel ttlabel7;
        protected ITTTextBox TabDescription;
        protected ITTCheckBox IsDurationControl;
        protected ITTCheckBox chkNotLISTest;
        protected ITTCheckBox IsBoundedTest;
        protected ITTTextBox PriceCoefficient;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel6;
        protected ITTCheckBox IsSAT;
        protected ITTCheckBox IsGroup;
        protected ITTCheckBox IsSubTest;
        protected ITTObjectListBox sexListBox;
        protected ITTCheckBox IsPanel;
        protected ITTTextBox DurationValue;
        protected ITTLabel ttlabel23;
        protected ITTObjectListBox ProcedureTree;
        protected ITTLabel ttlabel4;
        protected ITTTextBox EnglishName;
        protected ITTLabel labelQref;
        protected ITTLabel labelEnglishName;
        protected ITTTextBox Qref;
        protected ITTLabel ttlabel8;
        protected ITTTextBox Description;
        protected ITTObjectListBox TestType;
        protected ITTLabel labelDescription;
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid TabNameGrid;
        protected ITTListBoxColumn TabNames;
        protected ITTTextBoxColumn TabOrder;
        protected ITTTabPage TabPagePanel;
        protected ITTLabel ttlabel12;
        protected ITTGrid GridPanelTests;
        protected ITTListBoxColumn PanelTest;
        protected ITTTextBoxColumn SequenceNo;
        protected ITTTabPage TabPageResource;
        protected ITTLabel ttlabel1;
        protected ITTGrid GridDepartments;
        protected ITTListBoxColumn Department;
        protected ITTTabPage TabPageBoundRestrictedTests;
        protected ITTLabel ttlabel11;
        protected ITTGrid GridRestrictedTests;
        protected ITTListBoxColumn RestrictedTestName;
        protected ITTLabel ttlabel2;
        protected ITTGrid GridBoundedTests;
        protected ITTListBoxColumn BoundedTestName;
        protected ITTTabPage TabPageMaterial;
        protected ITTLabel ttlabel9;
        protected ITTGrid GridMaterials;
        protected ITTListBoxColumn Material;
        protected ITTTabPage TabPageMedula;
        protected ITTObjectListBox Branch;
        protected ITTCheckBox RequiresDiabetesForm;
        protected ITTObjectListBox TahlilTipi;
        protected ITTLabel labelTahlilTipi;
        protected ITTCheckBox chkSendOtherResults;
        protected ITTLabel labelBranch;
        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTTabPage TabPagePrerequisiteForms;
        protected ITTCheckBox ttRequiresUreaBreathTestReport;
        protected ITTCheckBox ttReqiresTripleTestForm;
        protected ITTCheckBox ttRequiresBinaryScanForm;
        protected ITTTextBox tttextbox4;
        protected ITTLabel ttlabel17;
        protected ITTTabPage TabTestBranchRelation;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn ttlistboxcolumn2;
        protected ITTLabel ttlabel19;
        protected ITTTabPage TabPageTestAlert;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage TabPageAdult;
        protected ITTCheckBox AdultNegative;
        protected ITTCheckBox AdultPositive;
        protected ITTLabel labelAdultAlert;
        protected ITTTextBox AdultAlert;
        protected ITTTabPage TabPageNewBorn;
        protected ITTCheckBox NewBornPositive;
        protected ITTCheckBox NewBornNegative;
        protected ITTLabel labelNewBornAlert;
        protected ITTTextBox NewBornAlert;
        protected ITTTextBox Code;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox tttextbox5;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel15;
        protected ITTLabel ttlabel16;
        protected ITTLabel ttlabel18;
        protected ITTCheckBox ttcheckbox2;
        override protected void InitializeControls()
        {
            TTListBox = (ITTObjectListBox)AddControl(new Guid("df857651-ac65-40f8-91a3-125eed5efedb"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("709fd8d5-1c5f-45d6-bbdf-576654a24289"));
            TestName = (ITTTextBox)AddControl(new Guid("72208d6f-9c66-4800-8361-a91b0a5368d9"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("57fe2468-f51a-4318-82af-615e4cf18a74"));
            chkPassiveNow = (ITTCheckBox)AddControl(new Guid("54bd78b2-b361-4165-8467-b1a74e896dc9"));
            IsActive = (ITTCheckBox)AddControl(new Guid("4e7e88f9-5ac3-49ad-ada8-53c2f86a5b7a"));
            labelName = (ITTLabel)AddControl(new Guid("961650c0-4fe1-4dfd-8424-1423e234697b"));
            TabControlInfos = (ITTTabControl)AddControl(new Guid("194e0677-8b39-4056-bea6-5609214158a2"));
            TabPageGeneralInfo = (ITTTabPage)AddControl(new Guid("6d741c8e-fea1-4d46-a981-83682471b1f8"));
            lblDefaultTab = (ITTLabel)AddControl(new Guid("2ff87b56-968f-4dc2-8bf1-174b86e9d769"));
            DefaultTab = (ITTObjectListBox)AddControl(new Guid("c5cd1999-743d-4161-8c08-7cee4985b927"));
            chkPrintInOneReport = (ITTCheckBox)AddControl(new Guid("8f6bc798-695f-44aa-85c9-a8463eadc681"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("0a62ec0c-642d-4cd6-a88d-d4c3803783bf"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("95166a9b-21cd-428b-a6a7-d995904fd368"));
            IsPrintEveryPage = (ITTCheckBox)AddControl(new Guid("126dbb72-dc27-41be-9a0f-e9b68b52eb25"));
            IsSexControl = (ITTCheckBox)AddControl(new Guid("49f4dac8-f53e-404a-b07e-17be9f2fbfea"));
            IsRestrictedTest = (ITTCheckBox)AddControl(new Guid("1e836417-4122-4c15-8043-1f1063e735e2"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("9e9fd429-3dd5-4f5a-9745-974527084ef1"));
            TabDescription = (ITTTextBox)AddControl(new Guid("dbe83c1f-b257-4bb6-8155-673f61c0adfc"));
            IsDurationControl = (ITTCheckBox)AddControl(new Guid("b6189d22-f367-4bd8-b351-56b4f4acd7dd"));
            chkNotLISTest = (ITTCheckBox)AddControl(new Guid("2b7b753c-0752-4dec-83fe-2ab8651aa2ba"));
            IsBoundedTest = (ITTCheckBox)AddControl(new Guid("1bcb57b0-cfc7-45d4-be40-d827d3e50ff5"));
            PriceCoefficient = (ITTTextBox)AddControl(new Guid("88a5936b-0e9d-4477-b394-72ebbe5e0615"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("88417c40-8745-40bf-941f-1be1a452b53f"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("2742b863-e0e9-46fb-a629-dc4fc3025a96"));
            IsSAT = (ITTCheckBox)AddControl(new Guid("a7164cd4-1fc8-437c-8ccb-b8660bdc88fd"));
            IsGroup = (ITTCheckBox)AddControl(new Guid("ae134685-907d-44e9-85ef-647895530283"));
            IsSubTest = (ITTCheckBox)AddControl(new Guid("b55b3a03-8d4f-48c6-9648-e64b7cc3a400"));
            sexListBox = (ITTObjectListBox)AddControl(new Guid("31f48150-a81b-4fa6-8eec-66f92dfd1441"));
            IsPanel = (ITTCheckBox)AddControl(new Guid("2134b6dd-a1f6-495f-9d81-0388e81d2b42"));
            DurationValue = (ITTTextBox)AddControl(new Guid("b1b78ccf-021d-42fc-98eb-5914d8cf151f"));
            ttlabel23 = (ITTLabel)AddControl(new Guid("8c4fd392-6d68-43c6-816f-07e314309fd4"));
            ProcedureTree = (ITTObjectListBox)AddControl(new Guid("c690d7e1-5d93-408c-a86f-e22e1f7b50be"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("78311492-de6d-44cd-a7ac-fbfde126f1b6"));
            EnglishName = (ITTTextBox)AddControl(new Guid("37f9e21e-ac14-48e5-9cbe-52c2c6f32989"));
            labelQref = (ITTLabel)AddControl(new Guid("659a915e-46c1-4494-a814-f29642a674c0"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("d689c756-70b5-4397-b63c-2644806332b2"));
            Qref = (ITTTextBox)AddControl(new Guid("ec26873e-2dd6-4d01-af9d-e3ecaa694d77"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("25ff5b5f-9b7f-49c3-9093-4d8cdd7f7998"));
            Description = (ITTTextBox)AddControl(new Guid("caff3658-3e9f-40b1-b991-b87e8de02525"));
            TestType = (ITTObjectListBox)AddControl(new Guid("71797289-7728-4050-8330-699d6791839c"));
            labelDescription = (ITTLabel)AddControl(new Guid("84274777-25b6-4034-9553-d85e82148218"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("dd622f68-f769-4f8f-a321-25a0a3f020da"));
            TabNameGrid = (ITTGrid)AddControl(new Guid("87938279-e72b-49c8-b756-0d6543c3deaf"));
            TabNames = (ITTListBoxColumn)AddControl(new Guid("cf96ffd1-0152-4e8e-8640-16473da4b852"));
            TabOrder = (ITTTextBoxColumn)AddControl(new Guid("1050293e-7afd-4155-8dc8-b988ab7f30eb"));
            TabPagePanel = (ITTTabPage)AddControl(new Guid("554edb42-9fe0-4936-9bbc-40297e29731b"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("c3118329-d2d0-4742-9101-e1aa920134b6"));
            GridPanelTests = (ITTGrid)AddControl(new Guid("bba83abe-bc18-4625-81a1-996c0da8f3a8"));
            PanelTest = (ITTListBoxColumn)AddControl(new Guid("44eb91de-4de8-4b52-bd21-0ca2eb52fdf5"));
            SequenceNo = (ITTTextBoxColumn)AddControl(new Guid("b78c0284-a15d-4cfb-810e-a7950069496a"));
            TabPageResource = (ITTTabPage)AddControl(new Guid("ec7f7fbe-fa1a-45ba-a51b-a9e0c0f102d9"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("35526909-f243-48e2-aefa-156d57ea4c86"));
            GridDepartments = (ITTGrid)AddControl(new Guid("2da95e16-d9be-4619-ac4f-da987592b622"));
            Department = (ITTListBoxColumn)AddControl(new Guid("83b7842d-737c-4abb-aa14-9219ff6aee18"));
            TabPageBoundRestrictedTests = (ITTTabPage)AddControl(new Guid("de32e883-9ca7-41ea-986e-a8463e67e67b"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("483d2519-216e-4f01-b4c7-d42eedf1985d"));
            GridRestrictedTests = (ITTGrid)AddControl(new Guid("29be1513-d17b-40e4-a8f1-b1e4826ee13f"));
            RestrictedTestName = (ITTListBoxColumn)AddControl(new Guid("90e12e2d-2802-4c82-aab9-7ddcf9e51424"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("5a752603-8d30-486c-ab80-143abb87bbe5"));
            GridBoundedTests = (ITTGrid)AddControl(new Guid("017b8033-6abb-4cac-a457-83e09a8678e3"));
            BoundedTestName = (ITTListBoxColumn)AddControl(new Guid("a8fd6f1c-6d3c-4e7e-8713-8d7c8a946681"));
            TabPageMaterial = (ITTTabPage)AddControl(new Guid("c449d593-a269-4b5d-8c64-1f3426144e5a"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("a097fc7e-198c-4b05-a85c-f696c521b4bc"));
            GridMaterials = (ITTGrid)AddControl(new Guid("0620cd2f-4ba3-4e18-a2a3-bd5bc71623c5"));
            Material = (ITTListBoxColumn)AddControl(new Guid("5cd3c2e7-e94b-4054-80e1-d5d9a4613a4f"));
            TabPageMedula = (ITTTabPage)AddControl(new Guid("2090fbce-7ac6-4b3c-9c46-da782ab53b02"));
            Branch = (ITTObjectListBox)AddControl(new Guid("ee748cfc-223c-4ffd-8e9e-6a3b6130dbe7"));
            RequiresDiabetesForm = (ITTCheckBox)AddControl(new Guid("e876f314-716c-4753-8fe9-ca9e1c790d79"));
            TahlilTipi = (ITTObjectListBox)AddControl(new Guid("dabbf57c-3541-4e04-b213-cf266d1774aa"));
            labelTahlilTipi = (ITTLabel)AddControl(new Guid("577d0169-b640-4d77-b05f-25b6dbbaaeb0"));
            chkSendOtherResults = (ITTCheckBox)AddControl(new Guid("1d56e904-39f8-4062-b1f0-f3e0c779cc91"));
            labelBranch = (ITTLabel)AddControl(new Guid("9a4da38a-630d-481d-a086-30fa61aeb53f"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("4f9b4f57-5e09-415e-b0b7-7eb9d20c197e"));
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("5d8256ac-7555-44a6-a914-5024fae0a286"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("77d44fbe-6b27-490e-a484-c024d5f81134"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("b476fcff-3e56-402a-802e-69a97498e2a9"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("bfacbaa5-6eff-4499-a9c7-88940ed7fd5a"));
            TabPagePrerequisiteForms = (ITTTabPage)AddControl(new Guid("3219aee3-652b-4c8b-a0b0-dfc8df50ea7a"));
            ttRequiresUreaBreathTestReport = (ITTCheckBox)AddControl(new Guid("153b3326-ee2f-485f-aba8-b319e5ee1aeb"));
            ttReqiresTripleTestForm = (ITTCheckBox)AddControl(new Guid("39f79eed-e0fb-43f3-95f2-574335196d5d"));
            ttRequiresBinaryScanForm = (ITTCheckBox)AddControl(new Guid("098378bd-5098-4691-80c6-25ca4180cfc6"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("ca3081f3-58de-4381-8418-1aa4b5bc6afb"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("789140c2-000a-4b04-8799-2cbfe3f0adc6"));
            TabTestBranchRelation = (ITTTabPage)AddControl(new Guid("98ea4567-290d-4e4f-849e-36a760096252"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("2d89a4c2-c912-4336-b005-0b2ee1405fc0"));
            ttlistboxcolumn2 = (ITTListBoxColumn)AddControl(new Guid("c4d1ef2e-9b65-4e7f-8e9d-7963cd092e0a"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("2cffb567-8a71-4a32-bab4-f45b7b890d2f"));
            TabPageTestAlert = (ITTTabPage)AddControl(new Guid("d3081495-ac87-4786-8063-27078e993ea0"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("810ae08a-ba84-43e5-a35f-a7afcc9318a3"));
            TabPageAdult = (ITTTabPage)AddControl(new Guid("ef98b6a0-f1a6-4dd9-b59a-1b11c8b0a39d"));
            AdultNegative = (ITTCheckBox)AddControl(new Guid("52dc4407-a0e4-44df-b801-a9768714037f"));
            AdultPositive = (ITTCheckBox)AddControl(new Guid("ab005f7c-055d-4c3e-a526-b9728988f59b"));
            labelAdultAlert = (ITTLabel)AddControl(new Guid("156956ba-cabb-48ec-a156-933730e12747"));
            AdultAlert = (ITTTextBox)AddControl(new Guid("86127613-b88f-4ca8-8685-78a4e21697dc"));
            TabPageNewBorn = (ITTTabPage)AddControl(new Guid("8169fe35-3bae-4597-bb85-002a3098f414"));
            NewBornPositive = (ITTCheckBox)AddControl(new Guid("28ac43fa-6b70-4169-986d-9b2c3816dc5b"));
            NewBornNegative = (ITTCheckBox)AddControl(new Guid("036c595c-6045-40b0-9beb-f9aeb680b652"));
            labelNewBornAlert = (ITTLabel)AddControl(new Guid("e8628d09-98fb-4aa0-a72d-d586c703f9a4"));
            NewBornAlert = (ITTTextBox)AddControl(new Guid("be2cf1ac-1e7f-4c63-9564-383c52434f18"));
            Code = (ITTTextBox)AddControl(new Guid("30921588-a0c7-4519-97dd-b9ae97dd4730"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("a42ee800-e273-4094-a79f-cb44078d4475"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("e0f94e7f-db8c-478c-b388-84a4a7d4dd14"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("3830ba92-b83c-48e8-97a9-64b62d711d73"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("0d896a90-05bc-42ff-b098-461930d6168a"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("5082f901-8c03-4375-bc87-21f6612a5e7e"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("07166bfd-42ba-4161-9003-4d49e1460225"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("b8142753-fef6-4f8a-af78-f681c44f9e91"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("0b36cbc8-a14c-4215-b0be-1337cd16b34f"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("576a296f-8e39-4640-b91f-ad1ab519361a"));
            base.InitializeControls();
        }

        public LaboratoryTestDefinitionNewForm() : base("LABORATORYTESTDEFINITION", "LaboratoryTestDefinitionNewForm")
        {
        }

        protected LaboratoryTestDefinitionNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}