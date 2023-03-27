
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
    /// Belge Bekleme
    /// </summary>
    public partial class DocumentWaitingForm : RUL_BaseForm
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
        protected ITTTextBox tttextbox2;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel ttlabel1;
        protected ITTEnumComboBox ReferTypeCombobox;
        protected ITTObjectListBox FixedAsset;
        protected ITTLabel labelRequestNO;
        protected ITTLabel ttlabel5;
        protected ITTGroupBox KomisyonGroupBox;
        protected ITTGrid CommisionGrid;
        protected ITTListBoxColumn Rank;
        protected ITTListBoxColumn Name;
        protected ITTTextBoxColumn NameString;
        protected ITTEnumComboBoxColumn CommMemberDuty;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelBreakDown;
        protected ITTLabel labelRequestDate;
        protected ITTButton ttbutton1;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox FromMilitaryUnit;
        protected ITTLabel ttlabel61;
        protected ITTObjectListBox OwnerMilitaryUnit;
        protected ITTLabel labelToMilitaryUnit1;
        protected ITTLabel labelFromMilitaryUnit1;
        protected ITTObjectListBox ToMilitaryUnit;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTLabel ttlabel2;
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
            ttlabel3 = (ITTLabel)AddControl(new Guid("75831c10-fe7f-42a0-b396-da7c50cc489e"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("36454545-5aae-4f77-aee8-bcbb6a0e7e94"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("81c8d090-167a-412c-b4b6-a6afa2ff117f"));
            RequestNO = (ITTTextBox)AddControl(new Guid("ba8d4307-414f-46f6-87fa-3a2b5e1d6bfc"));
            BreakDown = (ITTTextBox)AddControl(new Guid("a82700cc-15ae-4cac-8cda-bf1fe8a8adb3"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("378d7a0f-fc58-49dc-be29-bf48fe0e3c58"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("19587c70-7351-4329-84fa-d5c4b64e76de"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("f5b4c8aa-807d-4a89-81d0-d167bd65c87d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e0c86bc6-2a9e-42fc-8d83-c4d5404ea18c"));
            ReferTypeCombobox = (ITTEnumComboBox)AddControl(new Guid("69de9e64-ec58-4c4a-9547-f2b540496242"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("423a0433-1453-4279-9b7a-1ae798bc6b0c"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("929b8c22-74d6-4d47-a47a-c1524df0ea7c"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("0c138d17-7131-464f-ae32-8812849ee418"));
            KomisyonGroupBox = (ITTGroupBox)AddControl(new Guid("5fee3cec-a4c7-42b8-b83e-56e358e744d2"));
            CommisionGrid = (ITTGrid)AddControl(new Guid("19a411c0-1a75-41e4-a7f1-c3e169a74150"));
            Rank = (ITTListBoxColumn)AddControl(new Guid("8693372b-f0a2-4882-b68b-39ce9e51ef6b"));
            Name = (ITTListBoxColumn)AddControl(new Guid("0982e4bb-4a8f-4a58-8b6e-248f5f0a2b7c"));
            NameString = (ITTTextBoxColumn)AddControl(new Guid("21e09b60-9011-4cef-a966-91948ca37e97"));
            CommMemberDuty = (ITTEnumComboBoxColumn)AddControl(new Guid("2a198912-051b-4c07-a905-9080fc3c1830"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("d241bd87-773f-4f15-8641-5e6a88684325"));
            labelBreakDown = (ITTLabel)AddControl(new Guid("aad1f4d7-66fb-4e55-9308-4b0008fa7178"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("237b795f-4f97-49d9-99cb-bd48c6e43b97"));
            ttbutton1 = (ITTButton)AddControl(new Guid("919dd7c7-8025-4130-abb6-9050dbdf833b"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("b2e2a82c-5e82-4beb-98b1-eaacec078a43"));
            FromMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("cf413916-c0cf-4f50-b85c-fc6496d8b6e5"));
            ttlabel61 = (ITTLabel)AddControl(new Guid("bf251c67-1242-4bc8-b6cf-19d753252682"));
            OwnerMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("745bee0e-8e3b-4a5b-9364-67bc991bacc9"));
            labelToMilitaryUnit1 = (ITTLabel)AddControl(new Guid("d2d4759c-0338-4ddc-91ab-c510e6b65255"));
            labelFromMilitaryUnit1 = (ITTLabel)AddControl(new Guid("9b6e972b-5a54-4e1c-b68e-66f80b536c3a"));
            ToMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("997d7773-17e9-4366-a616-5a25be7a38dd"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("65615898-e9dd-411e-9fdd-bd5afa990605"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e34cdc43-d84a-42d2-8ce7-c5b68ffef3cb"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("4f745c73-909c-4928-8f1e-ad1ff87475d0"));
            RUL_ItemEquipments = (ITTGrid)AddControl(new Guid("9b27b636-76d3-466d-befc-2aaa9c6ccd4a"));
            ItemNameRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("a40058a2-c254-4a5c-8f6d-00b3334084f8"));
            AmountRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("b5fa7024-a299-441e-a6f4-a0fe7029c26e"));
            DistributionTypeRUL_ItemEquipment = (ITTListBoxColumn)AddControl(new Guid("6f56e00a-1ea8-4c19-b6db-86b59c520ab9"));
            IsChangedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("f9dae371-2ef0-40bd-8101-4f9307ab1825"));
            IsDamagedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("739b5214-88cc-47a8-bb09-2d9943c0fb89"));
            IsMissingRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("7940d01f-7d51-45b2-9375-190394e92da9"));
            IsNormalRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("ad57b59f-82ad-4614-8dbf-750e956bcec1"));
            CommentsRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("b0344036-4b3c-4c8d-afa0-fb263b4dc9b9"));
            base.InitializeControls();
        }

        public DocumentWaitingForm() : base("REFERTOUPPERLEVEL", "DocumentWaitingForm")
        {
        }

        protected DocumentWaitingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}