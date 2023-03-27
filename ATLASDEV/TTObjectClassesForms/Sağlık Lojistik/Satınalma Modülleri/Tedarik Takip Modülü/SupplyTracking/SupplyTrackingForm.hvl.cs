
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
    /// Tedarik Takip Modülü
    /// </summary>
    public partial class SupplyTrackingForm : TTForm
    {
    /// <summary>
    /// Tedarik Takip Modülü temel sınıfıdır
    /// </summary>
        protected TTObjectClasses.SupplyTracking _SupplyTracking
        {
            get { return (TTObjectClasses.SupplyTracking)_ttObject; }
        }

        protected ITTButton cmdFirePurchaseOrder;
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid ProjectsGrid;
        protected ITTTextBoxColumn clmProjectNo;
        protected ITTTextBoxColumn clmConfirmNo;
        protected ITTTextBoxColumn clmState;
        protected ITTTextBoxColumn clmGUID;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage ProjectSearchTab;
        protected ITTButton cmdListExternals;
        protected ITTButton cmdSeachByProject;
        protected ITTLabel ttlabel8;
        protected ITTTextBox txt1ProjectNo;
        protected ITTLabel ttlabel2;
        protected ITTTextBox txt1ConfirmNo;
        protected ITTCheckBox chkCompleteds;
        protected ITTCheckBox chkActives;
        protected ITTTabPage PurchaseItemSearchTab;
        protected ITTButton cmdSearchByState;
        protected ITTObjectListBox txt2PIClass;
        protected ITTObjectListBox txt2PItem;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        protected ITTButton cmdSeachByItem;
        protected ITTTabPage ContractSearchTab;
        protected ITTObjectListBox txt3Supplier;
        protected ITTLabel ttlabel5;
        protected ITTTextBox txt3ContractNo;
        protected ITTLabel ttlabel6;
        protected ITTButton cmdSeachByContract;
        protected ITTTextBox txt3DecisionNo;
        protected ITTLabel ttlabel10;
        protected ITTTabPage PurchaseOrderSearchTab;
        protected ITTObjectListBox txt4Supplier;
        protected ITTDateTimePicker txt4DeliveryStartDate;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel7;
        protected ITTTextBox txt4OrderNo;
        protected ITTLabel ttlabel11;
        protected ITTButton cmdSeachByOrder;
        protected ITTDateTimePicker txt4OrderEndDate;
        protected ITTDateTimePicker txt4DeliveryEndDate;
        protected ITTLabel ttlabel9;
        protected ITTDateTimePicker txt4OrderStartDate;
        protected ITTTabPage MasterResourceSearchTab;
        protected ITTLabel ttlabel12;
        protected ITTObjectListBox txt5MasterResource;
        protected ITTButton cmdSearchByMasterResource;
        protected ITTGroupBox ttgroupbox2;
        protected ITTGrid PurchaseItemsGrid;
        protected ITTListBoxColumn clm2PurchaseItem;
        protected ITTTextBoxColumn clm2Amount;
        protected ITTTextBoxColumn clm2DecisionNo;
        protected ITTGroupBox ttgroupbox3;
        protected ITTGrid OrdersGrid;
        protected ITTTextBoxColumn clm4PurchaseOrderNo;
        protected ITTDateTimePickerColumn clm4OrderDate;
        protected ITTDateTimePickerColumn clm4DueDate;
        protected ITTButtonColumn clm4cmdShowOrder;
        protected ITTGroupBox ttgroupbox4;
        protected ITTGrid ContractsGrid;
        protected ITTTextBoxColumn clm3ContractNo;
        protected ITTListBoxColumn clm3Supplier;
        protected ITTButtonColumn cml3cmdShowContract;
        protected ITTGroupBox ttgroupbox5;
        protected ITTButton cmdCheckAll1;
        protected ITTGrid ContractDetailsGrid;
        protected ITTCheckBoxColumn clm5Check;
        protected ITTListBoxColumn clm5PurchaseItem;
        protected ITTTextBoxColumn clm5Amount;
        protected ITTButton cmdUncheckAll1;
        protected ITTGroupBox ttgroupbox6;
        protected ITTGrid OrderDetailsGrid;
        protected ITTCheckBoxColumn clm6Check;
        protected ITTListBoxColumn clm6PurchaseItem;
        protected ITTTextBoxColumn clm6Amount;
        protected ITTTextBoxColumn clm6RestAmount;
        protected ITTEnumComboBoxColumn clm6Status;
        protected ITTButton cmdCheckAll2;
        protected ITTButton cmdUncheckAll2;
        protected ITTButton cmdFireExamination;
        protected ITTButton cmdFireCheque;
        override protected void InitializeControls()
        {
            cmdFirePurchaseOrder = (ITTButton)AddControl(new Guid("82726b55-1edc-4ff9-9625-5180a739bac7"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("1e025805-07a4-4a70-8da8-8e5b9a59dad4"));
            ProjectsGrid = (ITTGrid)AddControl(new Guid("fe6d1507-0074-4a7b-a876-23ac88240223"));
            clmProjectNo = (ITTTextBoxColumn)AddControl(new Guid("4dd412a2-20ed-4421-995d-8ffbc4ddadbc"));
            clmConfirmNo = (ITTTextBoxColumn)AddControl(new Guid("d720a76f-9034-49fd-b1db-2ea56442560d"));
            clmState = (ITTTextBoxColumn)AddControl(new Guid("e6ca7309-9d34-4fc3-883b-0350b2ee099b"));
            clmGUID = (ITTTextBoxColumn)AddControl(new Guid("d8fca1dd-c264-40ed-bb4e-acd6a14d29b6"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("f39d0cea-e94f-4a06-89bc-bc5510eeeadb"));
            ProjectSearchTab = (ITTTabPage)AddControl(new Guid("21c979f6-0998-4262-9882-cc03a434750b"));
            cmdListExternals = (ITTButton)AddControl(new Guid("643e9d04-b378-4c93-9044-7765e6516379"));
            cmdSeachByProject = (ITTButton)AddControl(new Guid("6994aca3-83b2-40f9-92f8-dd5f069e3b47"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("847e93fb-ada8-4b51-883f-22fb711a0e02"));
            txt1ProjectNo = (ITTTextBox)AddControl(new Guid("ff5c4256-b468-433c-b657-d0c4b04840f4"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("74d9a5da-297c-491e-b100-26664d821f89"));
            txt1ConfirmNo = (ITTTextBox)AddControl(new Guid("e6d139e5-b99e-4c4e-9f4e-d3981ff57bb4"));
            chkCompleteds = (ITTCheckBox)AddControl(new Guid("7c96f759-0f77-48b4-b433-318abb69e277"));
            chkActives = (ITTCheckBox)AddControl(new Guid("36b38ffd-715d-4f78-b55c-e57735954204"));
            PurchaseItemSearchTab = (ITTTabPage)AddControl(new Guid("3993f66d-ae9c-4420-9213-ca559509f9a7"));
            cmdSearchByState = (ITTButton)AddControl(new Guid("6134721a-0eed-4136-859f-f3c74d108067"));
            txt2PIClass = (ITTObjectListBox)AddControl(new Guid("b8939793-bd97-4691-a645-8ac1e3aa9b30"));
            txt2PItem = (ITTObjectListBox)AddControl(new Guid("c177c05b-b10f-4960-a479-57d296ab41e8"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("aa6c27b4-1946-43f6-b340-0ba20766e7b6"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("d6abb906-a01f-4d95-95d2-283dd0d15a6f"));
            cmdSeachByItem = (ITTButton)AddControl(new Guid("bc397fea-4674-4ab4-a446-ee9d0663f4e4"));
            ContractSearchTab = (ITTTabPage)AddControl(new Guid("e4495e27-29e3-4e2d-801b-c948064fa9f2"));
            txt3Supplier = (ITTObjectListBox)AddControl(new Guid("e672bc97-5ccc-446b-a742-0417da421176"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("493dedc8-cc32-4348-b068-511a8de1279f"));
            txt3ContractNo = (ITTTextBox)AddControl(new Guid("30418246-7a72-4c91-9f47-b3bc2c2290ef"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("17081fce-25b2-491c-93fd-58d42dbe9926"));
            cmdSeachByContract = (ITTButton)AddControl(new Guid("055d4cd6-22fc-443a-9c27-35467392e8bd"));
            txt3DecisionNo = (ITTTextBox)AddControl(new Guid("c5d1b245-ed9d-48f8-b260-003de8f9afe1"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("67777289-f8a9-43d2-9bf4-2d948445c753"));
            PurchaseOrderSearchTab = (ITTTabPage)AddControl(new Guid("8bffbac2-fe86-4923-8b4e-4ba6ddaf279a"));
            txt4Supplier = (ITTObjectListBox)AddControl(new Guid("90c00af2-4dae-43be-bd14-6ab823007d7c"));
            txt4DeliveryStartDate = (ITTDateTimePicker)AddControl(new Guid("8bfd474f-52c9-4215-b137-99d8c855df57"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c0a8cca4-c22b-40f9-8961-afc368c2d4a4"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("66524c69-62aa-451f-bf9a-28f0155f1dbf"));
            txt4OrderNo = (ITTTextBox)AddControl(new Guid("78b44535-aa18-47ca-9d88-bb76b2f6b815"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("c995341f-8236-45c0-b06d-f69f11e0f4b0"));
            cmdSeachByOrder = (ITTButton)AddControl(new Guid("aed2f702-f412-417a-802e-e859084f593c"));
            txt4OrderEndDate = (ITTDateTimePicker)AddControl(new Guid("d5a53f14-06c1-4795-bdd4-981a772e747a"));
            txt4DeliveryEndDate = (ITTDateTimePicker)AddControl(new Guid("edcbbbc4-0799-4472-a294-71448d35f9e1"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("864351dd-3ab1-4a51-9adb-0c723990f751"));
            txt4OrderStartDate = (ITTDateTimePicker)AddControl(new Guid("0b45e381-42a0-45ae-9518-de9095052f8b"));
            MasterResourceSearchTab = (ITTTabPage)AddControl(new Guid("de3514ff-f656-4dbf-8214-8c0fcd1e3f0b"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("22fbe0e8-b6f8-4eb9-88d0-5ac19a118e2d"));
            txt5MasterResource = (ITTObjectListBox)AddControl(new Guid("e1625485-f03a-494e-9130-786773ec6e41"));
            cmdSearchByMasterResource = (ITTButton)AddControl(new Guid("47534a6a-3cea-4962-90a9-9f5d41a14738"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("8dfe450b-8bd9-45ee-90bf-0d65c3228bd6"));
            PurchaseItemsGrid = (ITTGrid)AddControl(new Guid("b6e924f0-0e39-40df-a9ec-490544fe4cc6"));
            clm2PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("25e7b8a0-7710-45fd-bffd-d685758dcde3"));
            clm2Amount = (ITTTextBoxColumn)AddControl(new Guid("f76770ae-ac0a-4c1a-b87f-2a289bdfe1d8"));
            clm2DecisionNo = (ITTTextBoxColumn)AddControl(new Guid("acb3c3d3-038b-4d06-92d2-80e79c0eea7e"));
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("b3be7536-9a3a-4468-b428-8ca498ba1a36"));
            OrdersGrid = (ITTGrid)AddControl(new Guid("949f4a91-ada3-4094-9967-e98ac2d077bb"));
            clm4PurchaseOrderNo = (ITTTextBoxColumn)AddControl(new Guid("c6ab6b8c-993e-4556-8b91-c89a6df2aad2"));
            clm4OrderDate = (ITTDateTimePickerColumn)AddControl(new Guid("3676b7c3-e780-422a-94b6-f984304f262e"));
            clm4DueDate = (ITTDateTimePickerColumn)AddControl(new Guid("d5dc7fa4-78e7-4c08-b2f9-fd5e4dbb9bd5"));
            clm4cmdShowOrder = (ITTButtonColumn)AddControl(new Guid("7e4da262-89a9-4eea-a6ca-0ab6c2814aea"));
            ttgroupbox4 = (ITTGroupBox)AddControl(new Guid("d7e1e3a2-b4f5-4fbf-ae41-b965128c16ec"));
            ContractsGrid = (ITTGrid)AddControl(new Guid("b69446cf-36f2-4984-b0e2-eca794dffbab"));
            clm3ContractNo = (ITTTextBoxColumn)AddControl(new Guid("25938697-137c-4fe6-94bd-1e29ab749d25"));
            clm3Supplier = (ITTListBoxColumn)AddControl(new Guid("a7e388f0-56c1-4fa8-850d-dca0126d5df4"));
            cml3cmdShowContract = (ITTButtonColumn)AddControl(new Guid("efe96ca2-e176-4a5a-ad3d-836f8b16878e"));
            ttgroupbox5 = (ITTGroupBox)AddControl(new Guid("4c1446f9-d952-4a57-93a0-6963d5689dce"));
            cmdCheckAll1 = (ITTButton)AddControl(new Guid("a9fcfe02-05d1-4277-8bd0-4d4338c66fcd"));
            ContractDetailsGrid = (ITTGrid)AddControl(new Guid("09bcf1f2-a89d-4955-8160-c85f6dcca0dd"));
            clm5Check = (ITTCheckBoxColumn)AddControl(new Guid("bf75e304-761a-4c5a-9039-938df3704bc4"));
            clm5PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("f3a0e105-c4b5-465a-8fe2-8e764b360aac"));
            clm5Amount = (ITTTextBoxColumn)AddControl(new Guid("9eec3e4b-81e0-4cce-b0b8-839b1626eaf3"));
            cmdUncheckAll1 = (ITTButton)AddControl(new Guid("d89aa0e6-e030-492f-bfcd-6412fad58e7f"));
            ttgroupbox6 = (ITTGroupBox)AddControl(new Guid("7862a72b-72dc-42d8-8cdf-4c2faf24e3fc"));
            OrderDetailsGrid = (ITTGrid)AddControl(new Guid("068a14a7-b365-43b8-ac81-692a1ceac0cf"));
            clm6Check = (ITTCheckBoxColumn)AddControl(new Guid("275ab2e9-393c-4ed9-be32-6f04e874dad1"));
            clm6PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("322550d1-4665-4029-b13d-cd428bfb85b2"));
            clm6Amount = (ITTTextBoxColumn)AddControl(new Guid("5a301929-32c7-45b5-b2bd-40c56b040eef"));
            clm6RestAmount = (ITTTextBoxColumn)AddControl(new Guid("facb7ffc-5a6e-4f16-9a17-13d248d10aa7"));
            clm6Status = (ITTEnumComboBoxColumn)AddControl(new Guid("4352a5e3-706f-4c47-89ef-45b6ff49a1b1"));
            cmdCheckAll2 = (ITTButton)AddControl(new Guid("e6446612-d29e-4c98-bcf6-11c27aff136e"));
            cmdUncheckAll2 = (ITTButton)AddControl(new Guid("5ff2baff-04ab-4680-9e5f-5bdb2acad8c3"));
            cmdFireExamination = (ITTButton)AddControl(new Guid("d2e7f8e6-dabb-4410-b357-1f90cb0d7aa1"));
            cmdFireCheque = (ITTButton)AddControl(new Guid("78282a16-0916-4a2d-afd3-2876488fc5f9"));
            base.InitializeControls();
        }

        public SupplyTrackingForm() : base("SUPPLYTRACKING", "SupplyTrackingForm")
        {
        }

        protected SupplyTrackingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}