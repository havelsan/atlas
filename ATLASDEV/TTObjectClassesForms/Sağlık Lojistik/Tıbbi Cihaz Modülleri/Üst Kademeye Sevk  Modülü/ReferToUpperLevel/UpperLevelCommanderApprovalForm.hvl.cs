
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
    /// Üst Kademe XXXXXX Onayı
    /// </summary>
    public partial class UpperLevelCommanderApprovalForm : TTForm
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
            ttlabel3 = (ITTLabel)AddControl(new Guid("6cae4d86-47b0-438f-9851-fb26edf5b34c"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("d0e3d8b9-d67e-44f7-9755-4e609db6b66d"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("12845793-acbf-4177-8c5e-af2cfe157722"));
            RequestNO = (ITTTextBox)AddControl(new Guid("36ebfb42-40fb-40e7-9c4f-352e2488b759"));
            BreakDown = (ITTTextBox)AddControl(new Guid("f8796748-9363-4abc-8d6a-3b43e38d8e1c"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("94dc9c26-7118-4a99-a1a1-bb7d093a6e9a"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("ee9b4181-237e-44a3-a7d9-7b6ecf0d36a4"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("cd6a645b-c42b-4fdd-88ad-7ccb43c9af99"));
            ReferTypeCombobox = (ITTEnumComboBox)AddControl(new Guid("f2a5ee96-b6cf-46f9-aff3-e02155e52412"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("3303e71e-e150-425e-93a1-659290f03c08"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("82bff844-57a5-46ca-9d21-284a3d64b7d4"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("8e08552d-17dc-4bbb-9ea1-6f3cff283ab3"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("f5f92abd-ecb9-490c-ada1-8bbce23e6606"));
            labelBreakDown = (ITTLabel)AddControl(new Guid("f5b8fe2c-9de5-4e23-a596-312ebdb4a2ab"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("657b940c-5124-4206-a14b-248bbfa30c8a"));
            FromMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("8bd242a5-fedf-404b-ae1b-b967a905d3bd"));
            ttlabel61 = (ITTLabel)AddControl(new Guid("d1865592-b1da-4974-995e-98137cac13da"));
            OwnerMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("908c9191-27e2-4814-95dc-fd1ccad6018f"));
            labelToMilitaryUnit1 = (ITTLabel)AddControl(new Guid("41371359-f614-4b52-9c59-9d2c07b01122"));
            labelFromMilitaryUnit1 = (ITTLabel)AddControl(new Guid("1a82d8f4-4f21-4cd3-99d5-672235932e6f"));
            ToMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("02d0c217-3818-4f48-ad57-952ef219f0f0"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("c7c7cfea-34f3-437e-9c15-51a4846611fd"));
            RUL_ItemEquipments = (ITTGrid)AddControl(new Guid("46ddc4e0-f462-40c2-a922-7e1043a4b5aa"));
            ItemNameRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("bd98558e-b308-474f-a3bc-ecf01914d999"));
            AmountRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("fe317312-8cec-4cea-a40d-146dacc0ecad"));
            DistributionTypeRUL_ItemEquipment = (ITTListBoxColumn)AddControl(new Guid("8ff00daa-cb8f-4ba3-aac9-b5ae7d966bf5"));
            IsChangedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("814fdc0f-13fa-4b70-bd94-088333878660"));
            IsDamagedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("82868870-d754-4aed-8317-d62096574543"));
            IsMissingRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("363f5a64-b77d-495c-b334-e908a50dc640"));
            IsNormalRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("db7f9bd3-0d1a-4ef2-90a3-c70af25830b7"));
            CommentsRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("0b18b43f-2b82-473d-88b6-0cb4a835ab2d"));
            base.InitializeControls();
        }

        public UpperLevelCommanderApprovalForm() : base("REFERTOUPPERLEVEL", "UpperLevelCommanderApprovalForm")
        {
        }

        protected UpperLevelCommanderApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}