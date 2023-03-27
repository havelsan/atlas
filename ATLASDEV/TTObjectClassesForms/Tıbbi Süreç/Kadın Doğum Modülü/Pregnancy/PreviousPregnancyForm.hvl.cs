
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
    public partial class PreviousPregnancyForm : TTForm
    {
        protected TTObjectClasses.Pregnancy _Pregnancy
        {
            get { return (TTObjectClasses.Pregnancy)_ttObject; }
        }

        protected ITTGrid IndicationReasons;
        protected ITTListBoxColumn IndicationsIndicationReason;
        protected ITTLabel labelCesareanIndication;
        protected ITTObjectListBox CesareanIndication;
        protected ITTLabel labelBirthType;
        protected ITTObjectListBox BirthType;
        protected ITTLabel labelBirthLocation;
        protected ITTObjectListBox BirthLocation;
        protected ITTLabel labelBirthHelper;
        protected ITTObjectListBox BirthHelper;
        protected ITTLabel ttlabel1;
        protected ITTGrid PregnancyComplications;
        protected ITTListBoxColumn ComplicationPregnancyComplications;
        protected ITTTextBoxColumn ComplicationsDescriptionPregnancyComplications;
        protected ITTLabel labelPregnancyPhysiologyInfo;
        protected ITTTextBox PregnancyPhysiologyInfo;
        protected ITTTextBox PregnancyHistory;
        protected ITTLabel labelPregnancyPhysiology;
        protected ITTEnumComboBox PregnancyPhysiology;
        protected ITTLabel labelPregnancyHistory;
        protected ITTLabel labelBirthTerminationDate;
        protected ITTDateTimePicker BirthTerminationDate;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            IndicationReasons = (ITTGrid)AddControl(new Guid("55e70f15-1722-4523-9c50-0ec565d8c789"));
            IndicationsIndicationReason = (ITTListBoxColumn)AddControl(new Guid("e1fb1004-a360-4e14-b18f-d745f53edcb1"));
            labelCesareanIndication = (ITTLabel)AddControl(new Guid("50ecb434-c34d-4422-a891-bae7f574f64a"));
            CesareanIndication = (ITTObjectListBox)AddControl(new Guid("9a06852b-6d76-4750-bcfa-0871e715e1e5"));
            labelBirthType = (ITTLabel)AddControl(new Guid("0299f87e-93f2-49fb-9059-b70dc03fa15f"));
            BirthType = (ITTObjectListBox)AddControl(new Guid("07e2fb7d-2ba0-4ca5-a8b1-62fff8ab1b3a"));
            labelBirthLocation = (ITTLabel)AddControl(new Guid("f015557e-c0d5-48bf-87d7-528c7b91db7b"));
            BirthLocation = (ITTObjectListBox)AddControl(new Guid("08827e31-a1f3-43d1-8b83-379de35cceeb"));
            labelBirthHelper = (ITTLabel)AddControl(new Guid("8c188086-a36f-4678-a337-b92b72d6b20f"));
            BirthHelper = (ITTObjectListBox)AddControl(new Guid("ade31ff4-c177-4633-a4f2-8c3c1a9a8522"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8f0f6a16-1f10-4a46-acb5-2358eec42fc3"));
            PregnancyComplications = (ITTGrid)AddControl(new Guid("ae16824d-1361-4a13-9097-71889ee7ba79"));
            ComplicationPregnancyComplications = (ITTListBoxColumn)AddControl(new Guid("8023ac98-fbba-470f-a33e-80064f47d6de"));
            ComplicationsDescriptionPregnancyComplications = (ITTTextBoxColumn)AddControl(new Guid("e141d56c-affc-4552-a551-9428195efcbb"));
            labelPregnancyPhysiologyInfo = (ITTLabel)AddControl(new Guid("9c319d8d-645f-4756-8b60-f6b54b3c62e8"));
            PregnancyPhysiologyInfo = (ITTTextBox)AddControl(new Guid("8ea540a0-68b0-489a-b318-41600e69cbbb"));
            PregnancyHistory = (ITTTextBox)AddControl(new Guid("9e018ddc-a143-4608-a2ff-3c355beca134"));
            labelPregnancyPhysiology = (ITTLabel)AddControl(new Guid("c5f57503-c399-4867-be30-77ae0153323c"));
            PregnancyPhysiology = (ITTEnumComboBox)AddControl(new Guid("8bbccb60-4aca-4f82-a7c8-1fcdb4e0dd48"));
            labelPregnancyHistory = (ITTLabel)AddControl(new Guid("65d3c967-2ee9-43d4-ba95-f11572dfcd93"));
            labelBirthTerminationDate = (ITTLabel)AddControl(new Guid("61bf0dd3-7ba5-478c-b011-48afc4564ef4"));
            BirthTerminationDate = (ITTDateTimePicker)AddControl(new Guid("52995b16-b819-4621-82b9-c24b8a60c947"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("73c9384e-fec2-4b20-8f27-71afb3487d9b"));
            base.InitializeControls();
        }

        public PreviousPregnancyForm() : base("PREGNANCY", "PreviousPregnancyForm")
        {
        }

        protected PreviousPregnancyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}