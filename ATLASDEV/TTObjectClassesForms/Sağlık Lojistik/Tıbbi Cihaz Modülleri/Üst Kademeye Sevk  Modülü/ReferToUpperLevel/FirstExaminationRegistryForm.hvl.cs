
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
    /// İlk Muayene Kayıt
    /// </summary>
    public partial class FirstExaminationRegistryForm : RUL_BaseForm
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
        protected ITTLabel labelRequestNO;
        protected ITTLabel ttlabel5;
        protected ITTGroupBox KomisyonGroupBox;
        protected ITTGrid CommisionGrid;
        protected ITTTextBoxColumn Sıra;
        protected ITTListBoxColumn Rank;
        protected ITTListBoxColumn Name;
        protected ITTTextBoxColumn NameString;
        protected ITTEnumComboBoxColumn CommMemberDuty;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelBreakDown;
        protected ITTLabel labelRequestDate;
        protected ITTObjectListBox FromMilitaryUnit;
        protected ITTLabel ttlabel61;
        protected ITTObjectListBox OwnerMilitaryUnit;
        protected ITTLabel labelToMilitaryUnit1;
        protected ITTLabel labelFromMilitaryUnit1;
        protected ITTObjectListBox ToMilitaryUnit;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
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
            ttlabel3 = (ITTLabel)AddControl(new Guid("22c6336c-a7dd-4be9-b95e-23164f554604"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("bee770a8-8e81-4f77-9463-10e8965a434e"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("eb709d1a-6d5b-46c4-8725-3f831756a74e"));
            RequestNO = (ITTTextBox)AddControl(new Guid("173ff0b7-8e8a-41a8-8fe4-eda948b0a9ef"));
            BreakDown = (ITTTextBox)AddControl(new Guid("2d22dddd-7ba5-44f4-b1fe-2a0663f341bb"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("99e1d71a-5f84-42a9-8def-12280785ba6e"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("1bed5ffb-7dc1-407d-8c17-4cf8ec8d2645"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("79d6fe47-f225-4707-bf9d-40fa40f5c136"));
            ReferTypeCombobox = (ITTEnumComboBox)AddControl(new Guid("10f0a6e3-08ff-494d-98f4-543ea64fac67"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("a9eecbf2-e30f-41ef-92c0-0c4ffe8dc185"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("66750c59-8640-4ba5-8d6e-f4eb39c3fb83"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("617da524-1469-4d35-895e-bd7ea976ab58"));
            KomisyonGroupBox = (ITTGroupBox)AddControl(new Guid("a402ff13-c090-4fb0-be4f-ee58450a13d0"));
            CommisionGrid = (ITTGrid)AddControl(new Guid("5fd5be0e-aa5e-44cf-b6bf-9d3cbda85755"));
            Sıra = (ITTTextBoxColumn)AddControl(new Guid("ead1bfd5-16a7-40d5-803e-5246dc6f8111"));
            Rank = (ITTListBoxColumn)AddControl(new Guid("ca0713fe-6027-4d91-b979-c9d99450f762"));
            Name = (ITTListBoxColumn)AddControl(new Guid("268f00f8-8e0c-4dd0-b002-d0ba52d8dffd"));
            NameString = (ITTTextBoxColumn)AddControl(new Guid("04a698af-57a3-48a3-9cac-4dbd4349e743"));
            CommMemberDuty = (ITTEnumComboBoxColumn)AddControl(new Guid("0c927f58-a56b-48a5-a9c7-92c62d765f16"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("4137bafd-30e9-4691-a256-27688d585594"));
            labelBreakDown = (ITTLabel)AddControl(new Guid("8f01d301-4fdc-4287-8633-5d91aa9d132f"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("ead19591-1be4-47a6-b1ff-3d6e84052120"));
            FromMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("718419a9-5f67-4485-8e0f-ab958eb39070"));
            ttlabel61 = (ITTLabel)AddControl(new Guid("4bf64411-4d24-4f6c-987d-a55e63b66115"));
            OwnerMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("62bd76f7-b822-4e6e-90de-8f620d772a22"));
            labelToMilitaryUnit1 = (ITTLabel)AddControl(new Guid("30363831-adf4-4214-8cc3-b98b86acac5e"));
            labelFromMilitaryUnit1 = (ITTLabel)AddControl(new Guid("0a7ecf0f-24ec-4704-a0ad-066530791ae9"));
            ToMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("3c48708f-3afc-4903-93f8-19a9c51000b4"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("4e35e267-97c3-4aa8-a425-4b776d47bd3e"));
            RUL_ItemEquipments = (ITTGrid)AddControl(new Guid("129ff742-ee00-439e-9b53-ab8e5b60730c"));
            ItemNameRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("d7a6d6c4-1850-4973-8a16-58f062efcf82"));
            AmountRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("6ca875a7-2233-4b42-889e-9763bfee1683"));
            DistributionTypeRUL_ItemEquipment = (ITTListBoxColumn)AddControl(new Guid("55cc823c-8406-4580-8d86-b44eea2968cd"));
            IsChangedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("63b1f96b-d6b9-4d63-9eca-2be652adb522"));
            IsDamagedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("be4e6283-6ac1-4d0b-92bb-cf128fd1dca1"));
            IsMissingRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("12f0d88f-693f-49d1-8986-1418b47cd4e2"));
            IsNormalRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("99438652-5e93-4e99-96f6-a5793472cffe"));
            CommentsRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("bd433546-9760-4024-97e9-9c7a6d5b29fc"));
            base.InitializeControls();
        }

        public FirstExaminationRegistryForm() : base("REFERTOUPPERLEVEL", "FirstExaminationRegistryForm")
        {
        }

        protected FirstExaminationRegistryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}