
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
    /// Kalibrasyon Gecici Kabul ve İlk Muayene
    /// </summary>
    public partial class CalibrationExaminationForm : TTForm
    {
    /// <summary>
    /// Üst Kademeye Sevk
    /// </summary>
        protected TTObjectClasses.ReferToUpperLevel _ReferToUpperLevel
        {
            get { return (TTObjectClasses.ReferToUpperLevel)_ttObject; }
        }

        protected ITTToolStrip tttoolstrip2;
        protected ITTLabel ttlabel3;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox RequestNO;
        protected ITTTextBox BreakDown;
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
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTObjectListBox ToMilitaryUnit;
        protected ITTLabel labelFromMilitaryUnit1;
        protected ITTEnumComboBox FirstExamStatus;
        protected ITTLabel labelFirstExamStatus;
        protected ITTDateTimePicker ArrivalDate;
        protected ITTLabel labelArrivalType;
        protected ITTEnumComboBox ArrivalType;
        protected ITTLabel labelArrivalDate;
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
        override protected void InitializeControls()
        {
            tttoolstrip2 = (ITTToolStrip)AddControl(new Guid("fa621d73-0339-4915-b27a-7527068b13f2"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("477cf95f-a595-4344-852a-b732bf32663e"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("d8185a5a-e6d4-479b-9a73-1947042d14b1"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("9bad7f01-d688-499e-bbf3-a76eb9bc29d7"));
            RequestNO = (ITTTextBox)AddControl(new Guid("76424229-a3a7-49a3-b310-27e64db5c55a"));
            BreakDown = (ITTTextBox)AddControl(new Guid("166a345e-0b5a-4b67-a1c3-2785e499e15a"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("2661521c-85e7-480b-95d0-2ab8864cdfeb"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("323caab2-d89b-4ba8-8787-9d6ffa74e653"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("40b32b42-aafd-49f7-b4a7-437e3c3878f8"));
            ReferTypeCombobox = (ITTEnumComboBox)AddControl(new Guid("47059cc5-072e-4f5c-a028-9e7912e74650"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("9a3722db-4e75-4412-950b-c6fc63f83c46"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("a6820573-c043-424d-a0a8-ece30d0f7fb6"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("f6368d50-0d90-48ff-96f7-9aea979c57df"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("df016336-6d0e-401a-ab65-afc105ae03d7"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("5ac5bc5a-36b7-45ec-afda-c326fd070ec7"));
            labelBreakDown = (ITTLabel)AddControl(new Guid("6005be6f-288d-420d-96d1-760fa9989803"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("5bab4dd2-b4ed-4f0b-8e90-359240e7f2c8"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("6bbdd2c9-0b34-44c8-adf1-10444b2c23e0"));
            FromMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("75768964-27d6-41e8-aef9-03b52858ac9e"));
            ttlabel61 = (ITTLabel)AddControl(new Guid("727c3bf3-8658-4056-98ea-4c200af3ae3b"));
            OwnerMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("88c9312e-ea09-4408-89ec-b5a092f4bc4b"));
            labelToMilitaryUnit1 = (ITTLabel)AddControl(new Guid("65eda7d1-2a32-41e2-9290-b9988a863fdb"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("1bb8868e-437b-4fca-b517-2c9e2a79a8cd"));
            ToMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("01c91de1-f60d-41a1-affc-5bdc28c8dea6"));
            labelFromMilitaryUnit1 = (ITTLabel)AddControl(new Guid("ad721e1d-3503-4397-b63e-306d77b9ffa7"));
            FirstExamStatus = (ITTEnumComboBox)AddControl(new Guid("638b601e-a737-4beb-afc2-ce10b8be5abc"));
            labelFirstExamStatus = (ITTLabel)AddControl(new Guid("d2f05a63-ec0e-4f11-850b-0efc0057f709"));
            ArrivalDate = (ITTDateTimePicker)AddControl(new Guid("d43596c3-c57d-43bd-952a-6752d2de37ad"));
            labelArrivalType = (ITTLabel)AddControl(new Guid("3f884243-b7c7-4280-93e2-be346b62e3c4"));
            ArrivalType = (ITTEnumComboBox)AddControl(new Guid("45e26fd5-8e1e-463e-bd64-dc03bd35a83a"));
            labelArrivalDate = (ITTLabel)AddControl(new Guid("348eab79-e2f1-424c-a8ee-a831922b848c"));
            KomisyonGroupBox = (ITTGroupBox)AddControl(new Guid("e6a3f844-255d-4b4d-acf8-a0439588a9e8"));
            CommisionGrid = (ITTGrid)AddControl(new Guid("974cf6d2-ec43-4193-a4df-17fbb90fb8a8"));
            Sıra = (ITTTextBoxColumn)AddControl(new Guid("dee31558-2a10-4b79-a7fa-4efc39d177e6"));
            Rank = (ITTListBoxColumn)AddControl(new Guid("ebeaaa2e-5d23-43bd-b6e4-ffac29821c33"));
            Name = (ITTListBoxColumn)AddControl(new Guid("164ddb7a-c504-4760-96fa-d2a023cf644a"));
            NameString = (ITTTextBoxColumn)AddControl(new Guid("57277eed-327a-4f39-8588-b92358ba19ab"));
            CommMemberDuty = (ITTEnumComboBoxColumn)AddControl(new Guid("bbb5f98d-f187-43c4-af7d-3b0d64ce469f"));
            RUL_ItemEquipments = (ITTGrid)AddControl(new Guid("b1e14017-2d50-4de0-8c8f-505b2b4ce9b2"));
            ItemNameRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("35c0c932-b7c7-429e-b71d-ea80917ac640"));
            AmountRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("ce27f9cb-89bc-4b04-9e2e-f197d1af3193"));
            DistributionTypeRUL_ItemEquipment = (ITTListBoxColumn)AddControl(new Guid("fd53e57e-d9cf-4298-9a4a-0dbbdfff2b48"));
            IsChangedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("21016c1f-6442-4ce3-813c-48db1353b671"));
            IsDamagedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("5e27dace-946c-4581-9936-cc2d70e66e60"));
            IsMissingRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("7431ff85-4a70-47b2-9a55-7641a2599de4"));
            IsNormalRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("af7ceb8a-f020-4a10-a314-3b9a7a8ab22e"));
            CommentsRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("b480979d-273b-4ddb-9672-3c4c03e3a098"));
            base.InitializeControls();
        }

        public CalibrationExaminationForm() : base("REFERTOUPPERLEVEL", "CalibrationExaminationForm")
        {
        }

        protected CalibrationExaminationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}