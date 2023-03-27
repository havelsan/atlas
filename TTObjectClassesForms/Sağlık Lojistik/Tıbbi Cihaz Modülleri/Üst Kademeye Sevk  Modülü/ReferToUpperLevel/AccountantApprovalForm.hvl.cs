
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
    /// Sayman Onay
    /// </summary>
    public partial class AccountantApprovalForm : RUL_BaseForm
    {
    /// <summary>
    /// Üst Kademeye Sevk
    /// </summary>
        protected TTObjectClasses.ReferToUpperLevel _ReferToUpperLevel
        {
            get { return (TTObjectClasses.ReferToUpperLevel)_ttObject; }
        }

        protected ITTLabel ttlabel3;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox RequestNO;
        protected ITTTextBox BreakDown;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelFixedAsset;
        protected ITTEnumComboBox ReferTypeCombobox;
        protected ITTObjectListBox FixedAsset;
        protected ITTLabel labelRequestNO;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelBreakDown;
        protected ITTLabel labelRequestDate;
        protected ITTLabel ttlabel66;
        protected ITTObjectListBox Stage;
        protected ITTLabel ttlabel61;
        protected ITTObjectListBox OwnerMilitaryUnit;
        protected ITTObjectListBox FromMilitaryUnit;
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
            ttlabel3 = (ITTLabel)AddControl(new Guid("66447c24-2e32-4686-8668-daabc2ba1144"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("4c1d8d79-d64c-40bb-8752-47f50a5a8c67"));
            RequestNO = (ITTTextBox)AddControl(new Guid("022f8b1a-1657-45e5-8ece-937a0a46c254"));
            BreakDown = (ITTTextBox)AddControl(new Guid("c13a640d-e99b-41db-a6ea-b5e0a0d1caa1"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("cf149e17-6b1f-40d9-a7a3-4bad476dd4c5"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("c702cae0-a103-40e6-abbf-51c7de7b9e9c"));
            ReferTypeCombobox = (ITTEnumComboBox)AddControl(new Guid("0ec34c3d-4784-4386-acc8-7d6fa4765e5b"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("3f91dadd-699e-4609-90fa-87fd44fdd646"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("5e852120-b9b8-40c1-ad4c-b559be2e8e39"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("6feeac99-a477-4119-b10f-c5ee10c073e4"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("64de932a-f622-4f81-baf8-d97997de40cd"));
            labelBreakDown = (ITTLabel)AddControl(new Guid("70c8bf9b-f33d-4761-bb5a-ea417fb62e45"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("642ec7fd-846e-4553-82db-ec32a878768c"));
            ttlabel66 = (ITTLabel)AddControl(new Guid("e89d21b9-b6fd-4a66-bb11-ab70e8f71d49"));
            Stage = (ITTObjectListBox)AddControl(new Guid("c6cefd30-9e3e-45a0-bab6-dc89a27641fc"));
            ttlabel61 = (ITTLabel)AddControl(new Guid("ee85af10-4467-4671-b6cb-1c3e20ee82c3"));
            OwnerMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("bb3c872b-92f7-4dd5-a2dc-5d4f063e3c32"));
            FromMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("391b3d19-6c97-40c4-9a46-e0658972d387"));
            labelToMilitaryUnit1 = (ITTLabel)AddControl(new Guid("3331b84c-68e5-46b7-ac6f-324e45af2672"));
            labelFromMilitaryUnit1 = (ITTLabel)AddControl(new Guid("d5601b72-4cbd-455e-8245-3c3197438571"));
            ToMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("d3bf3cd0-d6f5-4ebc-bb5c-9785018ad3cf"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("3025b303-97a5-481f-9182-9c2ffbc9cd37"));
            RUL_ItemEquipments = (ITTGrid)AddControl(new Guid("c6fc0eab-3af3-46f0-8413-5edd43a86b63"));
            ItemNameRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("d16eabf6-0f88-4407-b30a-56d6e4fb1907"));
            AmountRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("6cb4e1ba-f050-4702-baca-03eea3421211"));
            DistributionTypeRUL_ItemEquipment = (ITTListBoxColumn)AddControl(new Guid("1b5ade0a-ee01-4a76-8fe0-899b9ce6c24f"));
            IsChangedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("66e12990-d65c-4f14-b1f0-1cd74f5c7555"));
            IsDamagedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("60e3a638-edf2-44ee-90ae-4c347bde9bdf"));
            IsMissingRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("8e4c8319-64ed-4961-8372-40d8b332c318"));
            IsNormalRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("685d029d-6130-43fc-ad77-f8cb2d7796b9"));
            CommentsRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("ce7a96b5-2022-4a3e-863a-f612fe5b8662"));
            base.InitializeControls();
        }

        public AccountantApprovalForm() : base("REFERTOUPPERLEVEL", "AccountantApprovalForm")
        {
        }

        protected AccountantApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}