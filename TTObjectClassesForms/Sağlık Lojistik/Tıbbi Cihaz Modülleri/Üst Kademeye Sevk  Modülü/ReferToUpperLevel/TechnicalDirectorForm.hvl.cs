
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
    /// Teknik Müdür Onay
    /// </summary>
    public partial class TechnicalDirectorForm : TTForm
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
        override protected void InitializeControls()
        {
            ttlabel3 = (ITTLabel)AddControl(new Guid("a2e6a59d-e10d-4009-8703-db944b142d13"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("64924e8a-a0da-4cf7-b999-bc39cc95f456"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("6128c7fb-ea97-43d1-8842-4e344c8949cc"));
            RequestNO = (ITTTextBox)AddControl(new Guid("8d4a965d-55e1-4905-8c81-a232ebcce3fd"));
            BreakDown = (ITTTextBox)AddControl(new Guid("e8ae1d03-f243-4e0a-b4c9-b22809a38dfe"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("8b214f09-92fd-4703-b348-49d925ea5a45"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("daa04d37-f42d-43c7-b764-73dea966846c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("2edbbdd6-9eeb-4bd2-840d-67ea8e376785"));
            ReferTypeCombobox = (ITTEnumComboBox)AddControl(new Guid("7a5e70bf-1e43-4cdf-b8a5-a408dcd8c860"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("7ec9002a-6719-4d9b-bca2-ed1ed738b538"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("ba6ccb27-4a48-42e9-9fbd-1ec66c91d430"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("fbce1f6e-9e41-4bd1-bc17-bdcfa38678ff"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("dce2b5e5-3d55-4e2f-8c13-3a6e12c7907a"));
            labelBreakDown = (ITTLabel)AddControl(new Guid("22063ad8-ebf8-461a-a8d0-085a88ffe7ce"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("9292065a-002d-4dc5-8404-6f636ddf5977"));
            FromMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("b44a869d-45e0-4773-b9a9-c7d6ef3f6026"));
            ttlabel61 = (ITTLabel)AddControl(new Guid("35856f6c-253c-48da-9964-08a4ccfca218"));
            OwnerMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("2f491bf6-cf47-43e7-b307-d405acbc32dc"));
            labelToMilitaryUnit1 = (ITTLabel)AddControl(new Guid("e624140c-9c8e-4119-88ad-188a43a8d0da"));
            labelFromMilitaryUnit1 = (ITTLabel)AddControl(new Guid("dd2f672c-347f-4eca-8212-cdd9aae73ef9"));
            ToMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("7c33de8a-d7bd-4582-987c-65b78d79dece"));
            RUL_ItemEquipments = (ITTGrid)AddControl(new Guid("ed7c603a-e972-4229-b001-47036adf761e"));
            ItemNameRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("6c3e497b-c75d-478b-bede-49778459bfce"));
            AmountRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("9dcd2ae9-0512-4f35-8e2b-0b68f1f332d0"));
            DistributionTypeRUL_ItemEquipment = (ITTListBoxColumn)AddControl(new Guid("1e692caf-b62b-4918-9fa9-2273f22c963f"));
            IsChangedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("ef94f599-01ca-4f88-9a4d-c09b34a23998"));
            IsDamagedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("9cc6a0cb-e8c3-47ac-b405-f7aaa7e7bf21"));
            IsMissingRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("5bf2c524-7381-4173-8cfb-8284f757199f"));
            IsNormalRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("1c2d4d39-046f-4797-8095-622797587f20"));
            CommentsRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("24a4ee50-643d-45fe-a1b8-458c228755c5"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("2c2e3e2a-a603-4e4b-b4c6-0e4808a78be4"));
            base.InitializeControls();
        }

        public TechnicalDirectorForm() : base("REFERTOUPPERLEVEL", "TechnicalDirectorForm")
        {
        }

        protected TechnicalDirectorForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}