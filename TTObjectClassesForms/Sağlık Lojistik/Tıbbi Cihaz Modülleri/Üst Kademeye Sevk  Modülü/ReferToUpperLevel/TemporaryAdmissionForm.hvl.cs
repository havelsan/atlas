
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
    /// Geçici Kabul
    /// </summary>
    public partial class TemporaryAdmissionForm : TTForm
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
        protected ITTLabel ttlabel4;
        protected ITTLabel labelBreakDown;
        protected ITTLabel labelRequestDate;
        protected ITTObjectListBox FromMilitaryUnit;
        protected ITTLabel ttlabel61;
        protected ITTObjectListBox OwnerMilitaryUnit;
        protected ITTLabel labelToMilitaryUnit1;
        protected ITTLabel labelFromMilitaryUnit1;
        protected ITTObjectListBox ToMilitaryUnit;
        protected ITTEnumComboBox ArrivalType;
        protected ITTLabel labelArrivalType;
        protected ITTDateTimePicker ArrivalDate;
        protected ITTLabel labelArrivalDate;
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
            ttlabel3 = (ITTLabel)AddControl(new Guid("e81fdeb3-52b7-4fd5-bad1-b6977c19315d"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("d9665ef0-1075-4f5d-a4f9-1671efa167f1"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("50e7d306-a07e-4653-97c6-fd60ab490602"));
            RequestNO = (ITTTextBox)AddControl(new Guid("cea1e829-6d83-4c4b-843e-93acff4926c6"));
            BreakDown = (ITTTextBox)AddControl(new Guid("f942b3d1-744a-41dc-9eaa-1a85f8888744"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("3c76d80f-cadc-4caf-bd60-a32a39285f48"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("d0eb8333-5800-45c2-b831-9d3c0b5622f7"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b61a62c0-717e-4695-8a74-8b0e1dce5d25"));
            ReferTypeCombobox = (ITTEnumComboBox)AddControl(new Guid("3e989b66-6e9c-4960-8918-d30a24df001e"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("e64f02f6-9b18-445f-8a4b-b79b7544680c"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("697917de-99a8-4d59-978b-368dcd2a0ac2"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("797a7daf-130c-4c9a-a448-ffa430e964ca"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("bba4ce61-3a5e-4e26-9142-9f428c13cc00"));
            labelBreakDown = (ITTLabel)AddControl(new Guid("17a62515-bd74-43c2-b6c3-0a87ec1edb07"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("107d0c06-4b6d-447d-9e9f-986e898e4f04"));
            FromMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("84cd5fd5-7c9d-4e20-a999-c51df57c4b85"));
            ttlabel61 = (ITTLabel)AddControl(new Guid("1df520a5-04d4-4feb-817e-ab7eb6083323"));
            OwnerMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("a68f58d3-b085-4b00-8a53-05047af2056c"));
            labelToMilitaryUnit1 = (ITTLabel)AddControl(new Guid("68e28cd7-d9bc-4d00-8b98-b0cba5f8eeba"));
            labelFromMilitaryUnit1 = (ITTLabel)AddControl(new Guid("e688770d-9fa7-457f-8eb6-5b5cc2a0154e"));
            ToMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("102680d7-13c6-4e6c-a695-d294c0894757"));
            ArrivalType = (ITTEnumComboBox)AddControl(new Guid("41f266f5-ae8c-4af9-8ec1-1a0f17f713d6"));
            labelArrivalType = (ITTLabel)AddControl(new Guid("5b9c2baa-f35b-48e3-b761-6c689d29f2e7"));
            ArrivalDate = (ITTDateTimePicker)AddControl(new Guid("5daf12bc-c67f-4c7a-bd9d-19a44e4799e0"));
            labelArrivalDate = (ITTLabel)AddControl(new Guid("b3eae1b3-d365-4ceb-bbb7-da344280bcf1"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("9995f29d-c9e6-4503-91ba-6f3a15ceb2df"));
            RUL_ItemEquipments = (ITTGrid)AddControl(new Guid("d65ccb7f-9bf5-410d-8269-dd6c5a3eea8b"));
            ItemNameRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("dba30abd-e876-4b73-a246-4b84851da2f1"));
            AmountRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("a8f45f70-2513-4ebc-a687-b1f5e52151b5"));
            DistributionTypeRUL_ItemEquipment = (ITTListBoxColumn)AddControl(new Guid("958a8bdf-b06f-48e8-a002-8d36ae7b7a97"));
            IsChangedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("1d53544e-963b-425d-9fe4-88cdc6e4b442"));
            IsDamagedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("15af515f-84f5-4e90-a135-ad69564e0fe7"));
            IsMissingRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("3ebbb135-f2cf-478f-a67f-e7d06e87754e"));
            IsNormalRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("32fdbe78-c8e8-4193-b3a9-b13a898f67a8"));
            CommentsRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("bb33ee6f-78ca-4d65-be16-727b8b8e5af5"));
            base.InitializeControls();
        }

        public TemporaryAdmissionForm() : base("REFERTOUPPERLEVEL", "TemporaryAdmissionForm")
        {
        }

        protected TemporaryAdmissionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}