
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
    /// Tamam
    /// </summary>
    public partial class CompletedForm_RUL : RUL_BaseForm
    {
    /// <summary>
    /// Üst Kademeye Sevk
    /// </summary>
        protected TTObjectClasses.ReferToUpperLevel _ReferToUpperLevel
        {
            get { return (TTObjectClasses.ReferToUpperLevel)_ttObject; }
        }

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
        protected ITTGroupBox KomisyonGroupBox;
        protected ITTGrid CommisionGrid;
        protected ITTListBoxColumn Rank;
        protected ITTTextBoxColumn NameString;
        protected ITTEnumComboBoxColumn CommMemberDuty;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelBreakDown;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelRequestDate;
        protected ITTObjectListBox FromMilitaryUnit;
        protected ITTObjectListBox Stage;
        protected ITTLabel ttlabel61;
        protected ITTObjectListBox OwnerMilitaryUnit;
        protected ITTLabel ttlabel66;
        protected ITTLabel labelToMilitaryUnit1;
        protected ITTLabel labelFromMilitaryUnit1;
        protected ITTObjectListBox ToMilitaryUnit;
        protected ITTDateTimePicker ttdatetimepicker3;
        protected ITTLabel ttlabel6;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTEnumComboBox OrderStatus;
        protected ITTLabel ttlabel11;
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
            ttlabel3 = (ITTLabel)AddControl(new Guid("12207512-1148-4693-8d31-0c2642eab6d0"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("88025c73-35b2-4cc5-8b82-040a381df123"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("005f4fc8-fc15-42d5-b5bf-29b1bbc5aaec"));
            RequestNO = (ITTTextBox)AddControl(new Guid("65ad08a2-05ee-4d9d-abae-7d9baec1c2b9"));
            BreakDown = (ITTTextBox)AddControl(new Guid("ea9fdcde-e23d-4c1c-a218-60cfd239d885"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("7b06150b-c4c8-446e-b679-a99fe45958a3"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("9a2d82fe-64ef-4c47-9ecb-2dd4b7118cc6"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("2577518a-cf8b-44ee-9d4f-21ab4a68d527"));
            ReferTypeCombobox = (ITTEnumComboBox)AddControl(new Guid("4817d550-031e-47a3-9700-b67d47ff6f83"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("c105494d-af62-4787-8aee-803e8419f832"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("99a345e2-42d6-4826-99b1-27123f4eddd0"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("8eb93ac8-b97d-4e13-9a7f-52d8c16428f4"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("6e2e35e0-ef4b-4eea-bc5a-8b415b28bd47"));
            KomisyonGroupBox = (ITTGroupBox)AddControl(new Guid("e8140346-7c25-404d-b39c-9925c312c074"));
            CommisionGrid = (ITTGrid)AddControl(new Guid("ef41e5ea-fd07-4093-ac71-8129ed4eee34"));
            Rank = (ITTListBoxColumn)AddControl(new Guid("3449d536-7298-4af5-84c5-1d3b2b522d81"));
            NameString = (ITTTextBoxColumn)AddControl(new Guid("2b276c58-33d8-4036-9162-07de988c3a1f"));
            CommMemberDuty = (ITTEnumComboBoxColumn)AddControl(new Guid("35a278ad-b4e0-4078-a1bd-42cf76e7a92d"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("de9586aa-391b-41ad-86ba-4bc19165a9ce"));
            labelBreakDown = (ITTLabel)AddControl(new Guid("b24f0dc6-7999-4f9b-ba1c-8a3001941001"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("a8ee8189-65ea-4d46-9b53-3c30d0ef5341"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("53e3b869-3d42-4a76-896b-90251db14f45"));
            FromMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("be278b6c-8b35-4be8-b05e-8684528e09f5"));
            Stage = (ITTObjectListBox)AddControl(new Guid("35475ad1-480d-4887-b241-f45aae2890fe"));
            ttlabel61 = (ITTLabel)AddControl(new Guid("026c5526-3761-4b88-b32f-b3c1a930ff54"));
            OwnerMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("7a983f96-95b7-4883-ab64-94152ff2da4c"));
            ttlabel66 = (ITTLabel)AddControl(new Guid("b1d8deb5-1c1c-4aff-a742-9f21b24e7be0"));
            labelToMilitaryUnit1 = (ITTLabel)AddControl(new Guid("6a041b7b-6494-4a77-84d5-e81933bf671e"));
            labelFromMilitaryUnit1 = (ITTLabel)AddControl(new Guid("764e96b4-4347-4f07-ba5c-dcccad6f9bcb"));
            ToMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("6be7c8dd-aeb2-48f6-987a-25989b030c57"));
            ttdatetimepicker3 = (ITTDateTimePicker)AddControl(new Guid("7968acf7-06ea-452f-ac42-439a1508ca01"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("0e3cd44b-1b3e-4af0-b72b-4189f8b56d37"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("c60b7771-1c11-40db-bfed-aa62cd1c98c0"));
            OrderStatus = (ITTEnumComboBox)AddControl(new Guid("a9292a27-9e34-44ca-8b42-99254abc5a5f"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("4e7cd571-ce10-4093-9e41-442bb4ee0456"));
            RUL_ItemEquipments = (ITTGrid)AddControl(new Guid("c357e9de-8615-465b-995c-84504d247eab"));
            ItemNameRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("5991b43e-84bc-4f3a-9901-83ad1b6652b5"));
            AmountRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("fffa94ba-f1aa-4ed0-863c-3d72f8b10f15"));
            DistributionTypeRUL_ItemEquipment = (ITTListBoxColumn)AddControl(new Guid("ac4ecd53-eb07-4711-8b1f-135fdad1deec"));
            IsChangedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("e8840c91-28bc-42de-8eff-528e124d5107"));
            IsDamagedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("45abc488-9e94-4c43-8186-c5f8037344cb"));
            IsMissingRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("1af5d1ab-29b4-46bf-8017-1c4580a2076f"));
            IsNormalRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("fa5faec8-31d0-4ada-95bd-c87b12f8f73b"));
            CommentsRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("7e0132a2-669c-4554-b7b7-d5dfe37b54ba"));
            base.InitializeControls();
        }

        public CompletedForm_RUL() : base("REFERTOUPPERLEVEL", "CompletedForm_RUL")
        {
        }

        protected CompletedForm_RUL(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}