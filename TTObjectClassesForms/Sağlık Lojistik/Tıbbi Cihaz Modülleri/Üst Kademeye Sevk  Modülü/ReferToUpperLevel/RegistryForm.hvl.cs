
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
    public partial class RegistryForm : RUL_BaseForm
    {
    /// <summary>
    /// Üst Kademeye Sevk
    /// </summary>
        protected TTObjectClasses.ReferToUpperLevel _ReferToUpperLevel
        {
            get { return (TTObjectClasses.ReferToUpperLevel)_ttObject; }
        }

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
            ttlabel6 = (ITTLabel)AddControl(new Guid("af701ba7-c4e1-45ca-a995-05ff305567e9"));
            Stage = (ITTObjectListBox)AddControl(new Guid("5cec6a5a-d520-46c8-a5f9-a3fcfe52b5da"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0ac105d0-03f9-4e47-998c-47e4e0f78f09"));
            OwnerMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("96ba1b3d-86ac-42a5-affe-81d5eddda901"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("bc877e4b-1903-40f9-96f5-655710e42b9d"));
            RequestNO = (ITTTextBox)AddControl(new Guid("627f6089-a167-4a86-807c-0407cb9259c2"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("04af2b41-d5a1-40d7-aab2-542aa23b6b9e"));
            BreakDown = (ITTTextBox)AddControl(new Guid("0ea857aa-1022-4257-8884-8d6e75b7c5d8"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("f68db49a-cc67-434e-8f78-2e9098934f26"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("dbb1043c-2cf8-4472-a6b3-2e9a69effb33"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("889877c8-b0ff-4e80-a086-4c7eec28823a"));
            Desc = (ITTRichTextBoxControl)AddControl(new Guid("f87584ab-15d2-41d6-a2a2-5206ee39850d"));
            labelBreakDown = (ITTLabel)AddControl(new Guid("6a35e728-3400-4f06-99f3-6422659db22e"));
            labelToMilitaryUnit = (ITTLabel)AddControl(new Guid("2a74dd50-7b4e-4204-a453-79b809515d1a"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("151df200-462d-41d6-984c-ba4e8fe58d79"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("99772812-dac0-4ffe-babc-c8d805d51805"));
            ReferType = (ITTEnumComboBox)AddControl(new Guid("b3fbb164-3c18-4d25-bf3c-cd312062326d"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("8b5c0183-3dbe-43cc-a3eb-d650e762a491"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("688b8260-ed88-477c-9ce4-d95ceb8d291b"));
            labelFromMilitaryUnit = (ITTLabel)AddControl(new Guid("aa324481-d971-476c-86cb-ee2f159f28b9"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("3bd1d3b7-546e-4a9f-b4ef-f3c39b1268c2"));
            ToMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("044a4907-28b0-4364-94b4-f56911a7aba8"));
            RUL_ItemEquipments = (ITTGrid)AddControl(new Guid("5e8bdb2e-4524-497c-8461-89aef5779d2c"));
            ItemNameRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("c91da5e0-19dd-4901-93fa-206102ac75eb"));
            AmountRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("20dbc0ce-2132-4c91-967c-2caae4473a9e"));
            DistributionTypeRUL_ItemEquipment = (ITTListBoxColumn)AddControl(new Guid("ee22781b-4c40-4ced-a45d-26be97884d73"));
            IsChangedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("c08f910c-9416-4a6e-a9ce-e9fbd1a248b2"));
            IsDamagedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("de85e173-bd26-419a-8c04-03b456046804"));
            IsMissingRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("ef09d8dd-f753-4565-ad12-99ccd5eb3405"));
            IsNormalRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("567d7ca4-74d1-47dd-b72b-4c6a8f1cf892"));
            CommentsRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("14cf93ca-1bc6-4ca6-8dad-116ca4159243"));
            base.InitializeControls();
        }

        public RegistryForm() : base("REFERTOUPPERLEVEL", "RegistryForm")
        {
        }

        protected RegistryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}