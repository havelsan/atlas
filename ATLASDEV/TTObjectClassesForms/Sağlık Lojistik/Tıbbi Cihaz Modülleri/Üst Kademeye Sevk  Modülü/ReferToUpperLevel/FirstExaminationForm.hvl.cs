
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
    /// İlk Muayene
    /// </summary>
    public partial class FirstExaminationForm : RUL_BaseForm
    {
    /// <summary>
    /// Üst Kademeye Sevk
    /// </summary>
        protected TTObjectClasses.ReferToUpperLevel _ReferToUpperLevel
        {
            get { return (TTObjectClasses.ReferToUpperLevel)_ttObject; }
        }

        protected ITTButton cmdGetHEKDetail;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGroupBox KomisyonGroupBox;
        protected ITTGrid CommisionGrid;
        protected ITTTextBoxColumn Sıra;
        protected ITTListBoxColumn Rank;
        protected ITTListBoxColumn Name;
        protected ITTTextBoxColumn NameString;
        protected ITTEnumComboBoxColumn CommMemberDuty;
        protected ITTGrid RUL_ItemEquipments;
        protected ITTTextBoxColumn ItemNameRUL_ItemEquipment;
        protected ITTTextBoxColumn AmountRUL_ItemEquipment;
        protected ITTListBoxColumn DistributionTypeRUL_ItemEquipment;
        protected ITTCheckBoxColumn IsChangedRUL_ItemEquipment;
        protected ITTCheckBoxColumn IsDamagedRUL_ItemEquipment;
        protected ITTCheckBoxColumn IsMissingRUL_ItemEquipment;
        protected ITTCheckBoxColumn IsNormalRUL_ItemEquipment;
        protected ITTTextBoxColumn CommentsRUL_ItemEquipment;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel ttlabel3;
        protected ITTTabPage tttabpage2;
        protected ITTLabel labelTotalWorkLoadPrice;
        protected ITTLabel labelHEKDescription;
        protected ITTTextBox TotalWorkLoadPrice;
        protected ITTLabel ttlabel7;
        protected ITTLabel labelMaterialPrice;
        protected ITTTextBox HEKDescription;
        protected ITTTextBox MaterialPrice;
        protected ITTLabel ttlabel6;
        protected ITTGrid RULHEKReasons;
        protected ITTListBoxColumn CousesOfTheHekDefinitionRULHEKReason;
        protected ITTCheckBoxColumn CheckRULHEKReason;
        protected ITTGrid RULHekCommisionMembers;
        protected ITTTextBoxColumn CommisionOrderNoRULHekCommisionMember;
        protected ITTListBoxColumn ResUserRULHekCommisionMember;
        protected ITTEnumComboBoxColumn MemberDutyRULHekCommisionMember;
        protected ITTTabPage tttabpage3;
        protected ITTGrid NeededMaterials;
        protected ITTTextBoxColumn MaterialNameNeededMaterials;
        protected ITTTextBoxColumn PartNumberNeededMaterials;
        protected ITTTextBoxColumn MaterialAmountNeededMaterials;
        protected ITTTextBoxColumn MaterialUnitPriceNeededMaterials;
        protected ITTTextBoxColumn MaterialTotalPriceNeededMaterials;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox RequestNO;
        protected ITTTextBox BreakDown;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel ttlabel1;
        protected ITTEnumComboBox ReferTypeCombobox;
        protected ITTObjectListBox FixedAsset;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTLabel labelRequestNO;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelBreakDown;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelRequestDate;
        protected ITTObjectListBox FromMilitaryUnit;
        protected ITTLabel ttlabel61;
        protected ITTObjectListBox OwnerMilitaryUnit;
        protected ITTLabel labelToMilitaryUnit1;
        protected ITTObjectListBox ToMilitaryUnit;
        protected ITTLabel labelFromMilitaryUnit1;
        protected ITTEnumComboBox FirstExamStatus;
        protected ITTLabel labelFirstExamStatus;
        override protected void InitializeControls()
        {
            cmdGetHEKDetail = (ITTButton)AddControl(new Guid("d64da419-03e1-40f9-bf4c-cbe53cda0fbe"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("58936d93-d458-4d1b-b4b8-1b30e7da0ba0"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("c555de86-4723-413d-8204-060e5482106e"));
            KomisyonGroupBox = (ITTGroupBox)AddControl(new Guid("c3c8cf3d-3afc-4e8a-ba9f-a3a1f4ea1595"));
            CommisionGrid = (ITTGrid)AddControl(new Guid("798fa6c0-3544-464d-8ae3-1c87b168d851"));
            Sıra = (ITTTextBoxColumn)AddControl(new Guid("faa8194a-96d1-4e62-87ed-35bfa6db2944"));
            Rank = (ITTListBoxColumn)AddControl(new Guid("7777f1e0-609b-4522-b8a1-6a05be676043"));
            Name = (ITTListBoxColumn)AddControl(new Guid("03b2bcc2-ee38-4f1f-8858-2e08d90fe170"));
            NameString = (ITTTextBoxColumn)AddControl(new Guid("10e4271e-cec9-40b8-bd66-4cb41afca494"));
            CommMemberDuty = (ITTEnumComboBoxColumn)AddControl(new Guid("bd230f3c-bc2c-4b65-af3b-8a6034bb41f5"));
            RUL_ItemEquipments = (ITTGrid)AddControl(new Guid("709cb8f6-1b64-4ede-b2b1-84c3ea04c0bb"));
            ItemNameRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("f88e4f4f-cf03-43d6-975d-43e8566ec4f9"));
            AmountRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("d0706e34-9a4f-4ec3-8483-cef0db77a645"));
            DistributionTypeRUL_ItemEquipment = (ITTListBoxColumn)AddControl(new Guid("e79ebc83-eda1-43ca-b313-ef202f2e45b4"));
            IsChangedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("e37b63d6-2e60-4ce2-b77b-78f1fba4a05e"));
            IsDamagedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("d074c0a5-01d0-4a76-8904-5439af04831d"));
            IsMissingRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("a679611c-7003-449f-b397-50cb72513230"));
            IsNormalRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("d5bdeac7-f007-4141-8274-10cc3fc78600"));
            CommentsRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("1cc4fdc2-03d6-4da9-b7cb-5957b482ac7f"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("26c52822-7d9e-4cd8-b65b-edd7d0c9a2ea"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("9d62e5d5-8f53-4905-8ac5-ab5b678b2cd6"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("3021949c-ead1-4f46-a78b-e44b0f4b5aba"));
            labelTotalWorkLoadPrice = (ITTLabel)AddControl(new Guid("2c4181e3-ed2b-4b58-802f-13887deabab6"));
            labelHEKDescription = (ITTLabel)AddControl(new Guid("ba4c9572-1263-451a-9159-a85d44b18924"));
            TotalWorkLoadPrice = (ITTTextBox)AddControl(new Guid("489dec73-6d80-414d-802b-6dddada5f2c1"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("3a757366-bbc0-47d0-94c2-bef2555ae606"));
            labelMaterialPrice = (ITTLabel)AddControl(new Guid("0632deb6-7fa3-4186-8ab9-112d742a672f"));
            HEKDescription = (ITTTextBox)AddControl(new Guid("be99c271-1545-4946-816d-bc4d50df41af"));
            MaterialPrice = (ITTTextBox)AddControl(new Guid("9310f86f-e21e-4a5d-9d6e-bb294c786220"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("890701fa-fb4e-41cc-8333-13a51b29a392"));
            RULHEKReasons = (ITTGrid)AddControl(new Guid("6af7754f-2b04-44f7-9615-901892fd3c65"));
            CousesOfTheHekDefinitionRULHEKReason = (ITTListBoxColumn)AddControl(new Guid("12eeaeab-d6b9-489e-8294-372042b21eb3"));
            CheckRULHEKReason = (ITTCheckBoxColumn)AddControl(new Guid("c1a8f67d-2a27-488a-ab18-170686c38ad1"));
            RULHekCommisionMembers = (ITTGrid)AddControl(new Guid("e5f05fe6-c82b-405d-9b72-6a39639dd40e"));
            CommisionOrderNoRULHekCommisionMember = (ITTTextBoxColumn)AddControl(new Guid("1bd12580-01e5-49b9-af8a-7ebab5a2fbba"));
            ResUserRULHekCommisionMember = (ITTListBoxColumn)AddControl(new Guid("7e49c913-d298-4735-9c8a-a17659e1f934"));
            MemberDutyRULHekCommisionMember = (ITTEnumComboBoxColumn)AddControl(new Guid("70a086c4-c51b-4a9b-b058-df7d7af3c914"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("b89d36f6-b46a-47a1-a253-de7aeb7c9344"));
            NeededMaterials = (ITTGrid)AddControl(new Guid("3d12e2c4-2c71-44d0-8615-76604ed3bbfd"));
            MaterialNameNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("ac38bcc5-1204-4d4d-a427-fef80ecbbb3a"));
            PartNumberNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("698f633c-381b-4d0d-baaf-4f8380b391b0"));
            MaterialAmountNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("7c3255fc-5885-48de-adfe-0e75e0da0e1e"));
            MaterialUnitPriceNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("b78fde24-811c-40a9-adfe-7355daf0f313"));
            MaterialTotalPriceNeededMaterials = (ITTTextBoxColumn)AddControl(new Guid("d127fa3d-33ba-4edc-a698-40908578ff7a"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("21deee9e-5550-455b-bb72-75c9124fe7e7"));
            RequestNO = (ITTTextBox)AddControl(new Guid("736f6b3c-6063-4f6b-910c-637224826ab5"));
            BreakDown = (ITTTextBox)AddControl(new Guid("b1511571-e600-45f3-b333-f1f7fb707299"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("4fb6f818-e166-4596-957b-faadb6705920"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("ef304d69-e715-4436-8095-05729ed24edb"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("d8ce3985-b9e5-4d5f-a4be-737d9a3b0cc6"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("7e821c22-c840-4fd9-8773-982e29bd4ba2"));
            ReferTypeCombobox = (ITTEnumComboBox)AddControl(new Guid("40f0608b-e9b4-4a2b-8534-aca76dfac70a"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("0bbcc277-1ea3-4ffc-a479-48bb9f2b5c7e"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("04769cf5-e65d-4044-90b7-993ef60a37fd"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("9f7aff74-1347-40ca-8dba-ea64c0a5d422"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("34be9b9b-ea1f-4a09-9d32-b7e486417df4"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("da2d14f0-1038-4a53-a443-75057e598157"));
            labelBreakDown = (ITTLabel)AddControl(new Guid("217639a5-8184-47fd-a0ac-fdb0bf2dbe38"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("7ca5c826-df9b-4c81-bbcd-9d18680c7126"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("b9f370ca-ceae-4d7d-8346-8ea2f78868fe"));
            FromMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("3de5b8f5-d06a-4b1d-ad32-9ef6ffd72c25"));
            ttlabel61 = (ITTLabel)AddControl(new Guid("a22a9199-b04c-4bb6-92a2-fe9445d224a4"));
            OwnerMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("0d759579-3152-48b6-a5dd-ebb01676c7de"));
            labelToMilitaryUnit1 = (ITTLabel)AddControl(new Guid("9277767d-e8e0-42c9-b379-62a1c8d5dfbf"));
            ToMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("c9b0cb73-99c3-4a33-9330-6dde67ec59c7"));
            labelFromMilitaryUnit1 = (ITTLabel)AddControl(new Guid("a874c132-6872-4de1-84fa-16387333aba9"));
            FirstExamStatus = (ITTEnumComboBox)AddControl(new Guid("3ae5bcc5-c6ba-44ec-9a49-ce169c5c5453"));
            labelFirstExamStatus = (ITTLabel)AddControl(new Guid("6dee62bb-97a9-4f11-9ae4-ee9d90d2150c"));
            base.InitializeControls();
        }

        public FirstExaminationForm() : base("REFERTOUPPERLEVEL", "FirstExaminationForm")
        {
        }

        protected FirstExaminationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}