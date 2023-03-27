
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
    /// Sipariş Sürecinde
    /// </summary>
    public partial class InOrderProgressForm : RUL_BaseForm
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
        protected ITTLabel ttlabel4;
        protected ITTLabel labelBreakDown;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelRequestDate;
        protected ITTObjectListBox FromMilitaryUnit;
        protected ITTLabel ttlabel61;
        protected ITTObjectListBox OwnerMilitaryUnit;
        protected ITTLabel labelToMilitaryUnit1;
        protected ITTLabel labelFromMilitaryUnit1;
        protected ITTObjectListBox ToMilitaryUnit;
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
            ttlabel3 = (ITTLabel)AddControl(new Guid("7acacf03-3a79-41b6-9e84-4b855acef1fb"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("9edd3ea8-fbd5-4483-a7b8-1bb424c93ca3"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("9cedc4c8-4591-4df3-9a64-40009ec27243"));
            RequestNO = (ITTTextBox)AddControl(new Guid("3ec1e1d0-8eb4-4cc3-a61e-8f48ef0e5f2d"));
            BreakDown = (ITTTextBox)AddControl(new Guid("4eab4308-7da9-4cfa-ac33-b608ed363694"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("e398d845-2cee-41d5-886b-3612d1acb8fd"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("7ba1e663-4e7e-4b82-aef2-a9bfe461db5b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("be5cd265-c6c5-41d0-8bd1-e740afe0a383"));
            ReferTypeCombobox = (ITTEnumComboBox)AddControl(new Guid("a48b530c-812f-4482-be2f-e2121acb037b"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("480c9477-7f78-4838-93b6-8f64d5f6f2fa"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("6e9a126d-c235-46a5-a5c0-4223bf680562"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("ff8e0a68-5dbc-464e-8cc9-d353f5eeb0e9"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("725f1f28-c459-4f1b-b0d8-f980bf75e6ac"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("14286567-2158-40e9-8a32-f77f6e0e7bda"));
            labelBreakDown = (ITTLabel)AddControl(new Guid("dfff7917-32c5-4966-ba58-d7b990719632"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("8f088c16-6074-4fe5-90c5-301176483795"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("b2d87a73-5ea5-4863-a823-2a444b632341"));
            FromMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("b1ec0507-412d-426e-89dc-9160de2a408c"));
            ttlabel61 = (ITTLabel)AddControl(new Guid("de56456c-3976-4e50-89bd-944b4878fa3b"));
            OwnerMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("b25fc300-2fb9-4876-9b08-5ef24f49a217"));
            labelToMilitaryUnit1 = (ITTLabel)AddControl(new Guid("9426e1a1-bda5-4edd-86cc-6a27394d3893"));
            labelFromMilitaryUnit1 = (ITTLabel)AddControl(new Guid("014ff872-b3ef-4117-8e60-22ade16ecfd0"));
            ToMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("45cbcca8-6ce4-4d55-b7b1-aea1b9c50ecc"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("58d72132-5261-438d-85ed-64760d8f5d79"));
            OrderStatus = (ITTEnumComboBox)AddControl(new Guid("fa5fe03b-2e13-4dd1-9f78-4be66280b5da"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("c6a86c2b-80ef-41f5-b936-c15200dddbff"));
            RUL_ItemEquipments = (ITTGrid)AddControl(new Guid("f2d1fbb8-0c2a-44e0-8d07-78b09cc91e03"));
            ItemNameRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("07e3b8d3-4180-44d2-b834-bc56bbc56d8c"));
            AmountRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("864c7406-bdbf-47f8-b960-a3a1f17d01e2"));
            DistributionTypeRUL_ItemEquipment = (ITTListBoxColumn)AddControl(new Guid("c8bcbfbd-d1a0-41b7-8890-4f61c436e709"));
            IsChangedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("3e631eff-155e-4a17-ad16-b7b3d3358802"));
            IsDamagedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("1bea4a69-be0a-4715-bf91-202a04dc4045"));
            IsMissingRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("9aac855b-0864-470e-a87a-1ab0e15d6c39"));
            IsNormalRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("55015c4c-91aa-4019-8b21-03dc20ff6fe9"));
            CommentsRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("4c3ee990-ddda-4dfa-b61d-dcf797c03654"));
            base.InitializeControls();
        }

        public InOrderProgressForm() : base("REFERTOUPPERLEVEL", "InOrderProgressForm")
        {
        }

        protected InOrderProgressForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}