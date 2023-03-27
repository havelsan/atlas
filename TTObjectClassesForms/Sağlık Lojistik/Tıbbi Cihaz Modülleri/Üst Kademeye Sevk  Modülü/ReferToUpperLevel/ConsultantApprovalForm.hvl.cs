
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
    /// Baş Tabib / Birlik XXXXXXı Onay
    /// </summary>
    public partial class ConsultantApprovalForm : RUL_BaseForm
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
        protected ITTObjectListBox Stage;
        protected ITTLabel ttlabel61;
        protected ITTObjectListBox OwnerMilitaryUnit;
        protected ITTLabel ttlabel66;
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
            ttlabel3 = (ITTLabel)AddControl(new Guid("5801e14e-08ef-42bb-8c02-df9b67471354"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("72342a25-02d1-4e5c-a531-6334ef55ee4e"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("8a21ac51-fa2b-4a48-9dc7-9c8ed25c5dde"));
            RequestNO = (ITTTextBox)AddControl(new Guid("472f0d0d-fa45-42a1-957f-3921787b9ffa"));
            BreakDown = (ITTTextBox)AddControl(new Guid("ef694d31-5815-4c0a-a50a-2eef576f6d70"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("12ef08e2-a2a3-4c51-8d07-04e3f114ee6d"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("610f6f34-32c1-4deb-b3c9-cb0d408e2806"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("db11fd34-0fba-413d-8990-000f78e7cf56"));
            ReferTypeCombobox = (ITTEnumComboBox)AddControl(new Guid("3e5fefdd-36be-448d-a597-07dec8599d8c"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("cc959a5d-5581-4ce8-b6aa-a442602c1314"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("a017655b-944a-443c-84ac-3527d7d301d5"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("80a20eab-2c86-456c-98b5-b259e872c158"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("023ed6c0-fa0e-4d42-8171-6de8d9c24aab"));
            labelBreakDown = (ITTLabel)AddControl(new Guid("9168ae13-14b2-423c-a976-35f9eb53f99b"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("02c3cceb-e20e-4e81-b181-3b3756648a58"));
            FromMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("0c89e20c-6991-43b0-ba99-ca3915aa7b3e"));
            Stage = (ITTObjectListBox)AddControl(new Guid("d9f7a6a2-272d-4f90-a0ce-ce14d8d9aa7e"));
            ttlabel61 = (ITTLabel)AddControl(new Guid("49108059-489e-4a16-8540-83a5c1b7f625"));
            OwnerMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("a1c861e0-39a7-44f2-8945-9a56199e8189"));
            ttlabel66 = (ITTLabel)AddControl(new Guid("6c843142-4475-4250-b6f7-c93b9b26d442"));
            labelToMilitaryUnit1 = (ITTLabel)AddControl(new Guid("16540710-e170-4155-b595-b92c65fe0f47"));
            labelFromMilitaryUnit1 = (ITTLabel)AddControl(new Guid("8d29a801-a427-4c97-8dc8-d628b4c95119"));
            ToMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("e96333f5-70a8-4db4-a402-b2c178adbaf5"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("5b83fc8d-26d1-4c43-b0ee-8849e37d8b74"));
            RUL_ItemEquipments = (ITTGrid)AddControl(new Guid("908ace5d-8dd9-4ee6-9fd3-452feac67630"));
            ItemNameRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("10aef0f5-1e69-42ab-ad57-d613f67c4d1e"));
            AmountRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("c7d3d41e-97f6-454c-ab5f-4d949d332911"));
            DistributionTypeRUL_ItemEquipment = (ITTListBoxColumn)AddControl(new Guid("ded6880a-1001-4f42-a9d2-f786f087c254"));
            IsChangedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("0c061ec3-e40f-407b-b01e-0515a80074c0"));
            IsDamagedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("ae2fa602-d9bd-4d02-a50a-fa84d7de0626"));
            IsMissingRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("ae34ac59-6631-4083-b60d-2a303dd08110"));
            IsNormalRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("7f24c46d-8938-4317-9594-564467949629"));
            CommentsRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("67300a0e-a119-48c6-971b-e02b6284c601"));
            base.InitializeControls();
        }

        public ConsultantApprovalForm() : base("REFERTOUPPERLEVEL", "ConsultantApprovalForm")
        {
        }

        protected ConsultantApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}