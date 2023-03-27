
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
    /// Geçici Kabul Kayıt
    /// </summary>
    public partial class TemporaryAdmissionRegistryForm : TTForm
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
            ttlabel3 = (ITTLabel)AddControl(new Guid("3dc53b99-012a-431d-b094-355ad531f400"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("e72f45eb-be2c-4b75-a143-83cc445cebf2"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("7f9f2b8e-a85f-4fa6-866f-d8ac0f95ec47"));
            RequestNO = (ITTTextBox)AddControl(new Guid("02527687-c211-48e2-ae2a-fdd205b9ab93"));
            BreakDown = (ITTTextBox)AddControl(new Guid("eb2733a6-4e3f-4426-be08-6c97da072140"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("34649390-7ccb-4abf-84b0-6bee82540209"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("c924ed7a-7ac2-4fae-9c5b-f4de04f9b479"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("4e294246-b09c-464a-b709-491e16dba684"));
            ReferTypeCombobox = (ITTEnumComboBox)AddControl(new Guid("859675ba-10e1-46dc-8476-819edda07d1f"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("d70f30b3-ee31-4de1-bb17-d9eba403274b"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("129285c5-0f9b-4ed5-9316-a211c47f3973"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("94966232-9c58-4f6b-abea-0c42ad99fea0"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("6fab6ca5-cfab-477d-aa6f-70576f18f677"));
            labelBreakDown = (ITTLabel)AddControl(new Guid("5865b9bd-f1b9-4b06-802d-adbe8443276b"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("3e63a2e1-6703-4799-ad0d-55ff2d45f590"));
            FromMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("1c38ff53-d270-4195-ad18-283718e57aec"));
            ttlabel61 = (ITTLabel)AddControl(new Guid("6cbaddcc-a711-42c4-9f09-60ed9764151d"));
            OwnerMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("ad46ec91-90da-4b01-95eb-5a266453e9f3"));
            labelToMilitaryUnit1 = (ITTLabel)AddControl(new Guid("838fcbbc-10ab-48ce-8c2f-3ad26bc78280"));
            labelFromMilitaryUnit1 = (ITTLabel)AddControl(new Guid("c6cbbd23-f16e-445b-875c-d5b33c6c90c7"));
            ToMilitaryUnit = (ITTObjectListBox)AddControl(new Guid("1268c365-f0d5-4d9e-b27f-45ed727b889b"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("37ae808d-d6eb-4463-81d6-98f41afb6951"));
            RUL_ItemEquipments = (ITTGrid)AddControl(new Guid("d2bbbbfd-4fff-4320-a98c-7678a3354cf5"));
            ItemNameRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("3c7891ed-e84e-4782-920d-572887f8aa41"));
            AmountRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("80a783ee-2269-4ffa-9fd0-751cd1e1b21f"));
            DistributionTypeRUL_ItemEquipment = (ITTListBoxColumn)AddControl(new Guid("b8b82689-7fff-40cc-83e0-7250e56234dd"));
            IsChangedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("b51799e5-3e7f-459f-b03c-e1d68be80325"));
            IsDamagedRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("69b12184-9d56-4acb-92e3-0a5a6b718f9c"));
            IsMissingRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("5a7091d2-e84a-4b5a-8c13-97a7440a9201"));
            IsNormalRUL_ItemEquipment = (ITTCheckBoxColumn)AddControl(new Guid("e0b24c95-f009-4a3c-99b0-6be7306d72a6"));
            CommentsRUL_ItemEquipment = (ITTTextBoxColumn)AddControl(new Guid("00ac4550-6751-41fb-aff9-32af70cf808f"));
            base.InitializeControls();
        }

        public TemporaryAdmissionRegistryForm() : base("REFERTOUPPERLEVEL", "TemporaryAdmissionRegistryForm")
        {
        }

        protected TemporaryAdmissionRegistryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}