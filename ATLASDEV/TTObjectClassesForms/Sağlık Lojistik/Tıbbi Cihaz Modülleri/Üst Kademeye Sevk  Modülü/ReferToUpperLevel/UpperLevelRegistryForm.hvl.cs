
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
    /// Kayıt
    /// </summary>
    public partial class UpperLevelRegistryForm : TTForm
    {
    /// <summary>
    /// Üst Kademeye Sevk
    /// </summary>
        protected TTObjectClasses.ReferToUpperLevel _ReferToUpperLevel
        {
            get { return (TTObjectClasses.ReferToUpperLevel)_ttObject; }
        }

        protected ITTGrid RUL_ItemEquipments;
        protected ITTTextBoxColumn ItemNameRUL_ItemEquipment;
        protected ITTTextBoxColumn AmountRUL_ItemEquipment;
        protected ITTListBoxColumn DistributionTypeRUL_ItemEquipment;
        protected ITTCheckBoxColumn IsChangedRUL_ItemEquipment;
        protected ITTCheckBoxColumn IsDamagedRUL_ItemEquipment;
        protected ITTCheckBoxColumn IsMissingRUL_ItemEquipment;
        protected ITTCheckBoxColumn IsNormalRUL_ItemEquipment;
        protected ITTTextBoxColumn CommentsRUL_ItemEquipment;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox Stage;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox OwnerMilitaryUnit;
        protected ITTLabel ttlabel3;
        protected ITTTextBox RequestNO;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox BreakDown;
        protected ITTLabel labelFixedAsset;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTDateTimePicker RequestDate;
        protected ITTRichTextBoxControl Desc;
        protected ITTLabel labelBreakDown;
        protected ITTLabel labelToMilitaryUnit;
        protected ITTLabel ttlabel5;
        protected ITTLabel labelRequestDate;
        protected ITTEnumComboBox ReferType;
        protected ITTLabel labelRequestNO;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelFromMilitaryUnit;
        protected ITTObjectListBox FixedAsset;
        protected ITTObjectListBox ToMilitaryUnit;
        override protected void InitializeControls()
        {
            RUL_ItemEquipments = (ITTGrid)AddControl(new Guid("fd32a02d-bd7c-4648-89d4-eb53819f3158"));
            ItemNameRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("18a22245-9538-448c-b3b7-3f0489394a3b"));
            AmountRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("6851d3a3-f79f-4006-b335-6d9c41979109"));
            DistributionTypeRUL_ItemEquipment = (ITTListBoxColumn)AddControl(new Guid("cf81ac1f-5885-4f25-8bed-0d4d2c7d8888"));
            IsChangedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("fc969945-0478-49d1-bcab-651d9ccbd8b1"));
            IsDamagedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("72193484-9d39-48aa-80e0-c29e68aaa191"));
            IsMissingRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("9cebcd5d-eab8-428a-a4c6-52676d0a8849"));
            IsNormalRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("390b9bff-0bc5-4714-a329-da664265f6ab"));
            CommentsRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("832e3ec8-ca95-43d4-a8b2-5ef4b10458df"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("29e620ec-d87a-4a3b-94f3-b358dbfa65e2"));
            Stage = (ITTObjectListBox)AddControl(new Guid("d33e14dc-7dd1-4a33-99fa-d5ba21af8951"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("828891e3-af8b-468f-8428-67f82800e540"));
            OwnerMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("173524fd-12b2-4bcf-bae1-4d9769164b77"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("e5d52757-ffb0-4024-b661-ae484df56d06"));
            RequestNO = (ITTTextBox)AddControl(new Guid("ea644644-eeae-4102-ab45-55170a86186d"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("cdf4d932-d468-4edf-b572-589b4604063d"));
            BreakDown = (ITTTextBox)AddControl(new Guid("a7c220ce-50c2-4a4c-8820-3bf174df187b"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("4e60d6af-b7ab-4d6b-bf7f-3fd2429b1e11"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("9aedca3c-cacf-4683-8b83-792c28a4cc30"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("904b0284-43ff-4297-bb72-66eb96ee1aa0"));
            Desc = (ITTRichTextBoxControl)AddControl(new Guid("171b669f-ae92-48ac-b038-a64e05522ee7"));
            labelBreakDown = (ITTLabel)AddControl(new Guid("e517b887-2dbb-4797-a3f3-405f3585a490"));
            labelToMilitaryUnit = (ITTLabel)AddControl(new Guid("e644990f-2ed5-4b6f-8640-37282b1d57aa"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("0cf22d8a-caf8-4885-883c-3de5529a5ef0"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("062f558d-746e-4013-b45e-dab8ec3d386d"));
            ReferType = (ITTEnumComboBox)AddControl(new Guid("d488ad7e-9ba6-4e04-9c2b-b6953cd3b126"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("920ef21c-4cce-46b2-9d20-c5b22d120f0d"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("73032539-6f6f-4539-9742-0148a670a01e"));
            labelFromMilitaryUnit = (ITTLabel)AddControl(new Guid("901c5dcf-cb3a-48ae-aa7a-0a99c78bd738"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("9e4023ca-d2ce-4086-ad8e-e0d6fa703b7a"));
            ToMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("45360908-b910-426c-add8-eaf565e5fc46"));
            base.InitializeControls();
        }

        public UpperLevelRegistryForm() : base("REFERTOUPPERLEVEL", "UpperLevelRegistryForm")
        {
        }

        protected UpperLevelRegistryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}