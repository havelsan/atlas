
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
    public partial class PregnancyStartForm : TTForm
    {
        protected TTObjectClasses.Pregnancy _Pregnancy
        {
            get { return (TTObjectClasses.Pregnancy)_ttObject; }
        }

        protected ITTLabel labelRiskOfGestationalAge;
        protected ITTEnumComboBox RiskOfGestationalAge;
        protected ITTLabel labelPregnancyType;
        protected ITTEnumComboBox PregnancyType;
        protected ITTLabel labelPregnancyInformation;
        protected ITTTextBox PregnancyInformation;
        protected ITTTextBox MeasuredPregnancyWeek;
        protected ITTTextBox MeasuredPregnancyDay;
        protected ITTLabel labelMeasuredPregnancyWeek;
        protected ITTLabel labelMeasuredPregnancyDay;
        protected ITTLabel labelMeasuredPregnancyDate;
        protected ITTDateTimePicker MeasuredPregnancyDate;
        protected ITTLabel labelLastMenstrualPeriod;
        protected ITTDateTimePicker LastMenstrualPeriod;
        protected ITTLabel labelEstimatedBirthDate;
        protected ITTDateTimePicker EstimatedBirthDate;
        protected ITTLabel labelEmbryoTransferDate;
        protected ITTDateTimePicker EmbryoTransferDate;
        protected ITTLabel labelEggCollectionDate;
        protected ITTDateTimePicker EggCollectionDate;
        protected ITTLabel labelBlastocystTransferDate;
        protected ITTDateTimePicker BlastocystTransferDate;
        protected ITTGrid PregnancyNotification;
        protected ITTListBoxColumn NotificationPregnancyNotification;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            labelRiskOfGestationalAge = (ITTLabel)AddControl(new Guid("9a9f5982-f133-489f-a673-b02ba927139c"));
            RiskOfGestationalAge = (ITTEnumComboBox)AddControl(new Guid("84483d1c-04b8-46c3-a87d-edb5b3420368"));
            labelPregnancyType = (ITTLabel)AddControl(new Guid("273aa401-5ac4-4f32-a22e-cd0ccc08506a"));
            PregnancyType = (ITTEnumComboBox)AddControl(new Guid("29684777-0b4f-40e7-b274-ec5a7791f016"));
            labelPregnancyInformation = (ITTLabel)AddControl(new Guid("ef65c25b-4aae-478f-b44d-8c3eff21ddd8"));
            PregnancyInformation = (ITTTextBox)AddControl(new Guid("b82db802-84f3-4eba-b51f-e5ac593abf30"));
            MeasuredPregnancyWeek = (ITTTextBox)AddControl(new Guid("ed4ab90f-a112-4d81-b3f2-d5a3a045cb67"));
            MeasuredPregnancyDay = (ITTTextBox)AddControl(new Guid("3126a1a0-4982-459d-af84-c7461a6ce9e9"));
            labelMeasuredPregnancyWeek = (ITTLabel)AddControl(new Guid("761930b5-bd24-426f-92f3-1f16c422d064"));
            labelMeasuredPregnancyDay = (ITTLabel)AddControl(new Guid("f5fbd2a8-61d4-4fcc-93a8-5ba68b9c1a2c"));
            labelMeasuredPregnancyDate = (ITTLabel)AddControl(new Guid("59a19a5b-38af-4ced-b635-0a5027e545ab"));
            MeasuredPregnancyDate = (ITTDateTimePicker)AddControl(new Guid("ad4b2c8a-b3fb-4149-a6bd-6a3de1750ec4"));
            labelLastMenstrualPeriod = (ITTLabel)AddControl(new Guid("b6a8beff-2eb0-4dc9-8d7a-79eb10ce9309"));
            LastMenstrualPeriod = (ITTDateTimePicker)AddControl(new Guid("0e5164a0-fc28-4842-8d8d-4b956341e25b"));
            labelEstimatedBirthDate = (ITTLabel)AddControl(new Guid("3a390a5f-503b-4987-9c6f-369d32a2a4ed"));
            EstimatedBirthDate = (ITTDateTimePicker)AddControl(new Guid("bd55d011-95c9-489f-90fd-66880f90c83a"));
            labelEmbryoTransferDate = (ITTLabel)AddControl(new Guid("94bdc39b-2745-4c2b-a74f-ba17d541ebbd"));
            EmbryoTransferDate = (ITTDateTimePicker)AddControl(new Guid("3ec4548e-c480-4b7a-afc3-1b0efc257ad1"));
            labelEggCollectionDate = (ITTLabel)AddControl(new Guid("348e9cc1-dc64-45c6-bef0-5dee41ff517f"));
            EggCollectionDate = (ITTDateTimePicker)AddControl(new Guid("a7f0d68a-2716-4789-addf-ce3b66859b70"));
            labelBlastocystTransferDate = (ITTLabel)AddControl(new Guid("2c7a545a-1ffe-474b-872d-4e850d9b3960"));
            BlastocystTransferDate = (ITTDateTimePicker)AddControl(new Guid("a58e7956-8fa4-4152-9209-2a114070fc01"));
            PregnancyNotification = (ITTGrid)AddControl(new Guid("27cdb255-0a58-47e1-b28e-ce91e610f083"));
            NotificationPregnancyNotification = (ITTListBoxColumn)AddControl(new Guid("543eb2d6-03a4-4868-a227-58a25bd9b245"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e93dd043-3813-42e8-9c4c-d42533193b9f"));
            base.InitializeControls();
        }

        public PregnancyStartForm() : base("PREGNANCY", "PregnancyStartForm")
        {
        }

        protected PregnancyStartForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}