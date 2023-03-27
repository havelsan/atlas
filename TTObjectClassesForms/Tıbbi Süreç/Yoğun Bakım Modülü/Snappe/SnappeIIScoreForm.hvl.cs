
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
    public partial class SnappeIIScoreForm : BaseMultipleDataEntryForm
    {
        protected TTObjectClasses.Snappe _Snappe
        {
            get { return (TTObjectClasses.Snappe)_ttObject; }
        }

        protected ITTLabel labelTotalSnapScore;
        protected ITTTextBox TotalSnapScore;
        protected ITTTextBox TotalScore;
        protected ITTLabel labelEntryDate;
        protected ITTDateTimePicker EntryDate;
        protected ITTLabel labelTotalScore;
        protected ITTLabel labelSGA;
        protected ITTEnumComboBox SGA;
        protected ITTLabel labelSerumPH;
        protected ITTEnumComboBox SerumPH;
        protected ITTLabel labelPo2FiO2;
        protected ITTEnumComboBox Po2FiO2;
        protected ITTLabel labelMultipleConvulsion;
        protected ITTEnumComboBox MultipleConvulsion;
        protected ITTLabel labelMeanBloodPressure;
        protected ITTEnumComboBox MeanBloodPressure;
        protected ITTLabel labelLowestTemperature;
        protected ITTEnumComboBox LowestTemperature;
        protected ITTLabel labelDiuresis;
        protected ITTEnumComboBox Diuresis;
        protected ITTLabel labelBirthWeight;
        protected ITTEnumComboBox BirthWeight;
        protected ITTLabel labelApgar;
        protected ITTEnumComboBox Apgar;
        override protected void InitializeControls()
        {
            labelTotalSnapScore = (ITTLabel)AddControl(new Guid("e2d87a44-d3b8-405b-9fdf-529bf209e715"));
            TotalSnapScore = (ITTTextBox)AddControl(new Guid("88a53d6b-95b8-43f4-9e7e-01433fb7c1c2"));
            TotalScore = (ITTTextBox)AddControl(new Guid("13f6f40f-574a-4321-a94d-e4ffcbf3395c"));
            labelEntryDate = (ITTLabel)AddControl(new Guid("3a40b448-0d05-4154-9625-2feb3a4124cf"));
            EntryDate = (ITTDateTimePicker)AddControl(new Guid("960ff393-9f34-4b6d-b8f4-5c5747303165"));
            labelTotalScore = (ITTLabel)AddControl(new Guid("eb0c9bbb-cfb5-4573-9a4a-5a5e1eb433d8"));
            labelSGA = (ITTLabel)AddControl(new Guid("4bd725e6-6420-4721-af87-9e0a05e9fed7"));
            SGA = (ITTEnumComboBox)AddControl(new Guid("0f55e88b-3e3e-4aea-bbe5-cd9f2e940dac"));
            labelSerumPH = (ITTLabel)AddControl(new Guid("db4485e6-de0b-4843-a854-b6c7811d34c4"));
            SerumPH = (ITTEnumComboBox)AddControl(new Guid("25648243-9a37-4599-a1a0-1ae14e0ec5ad"));
            labelPo2FiO2 = (ITTLabel)AddControl(new Guid("f7681a8e-687a-4045-ac8f-e9aa60933047"));
            Po2FiO2 = (ITTEnumComboBox)AddControl(new Guid("2c6e890d-a336-4e2b-b36d-a8d12430703d"));
            labelMultipleConvulsion = (ITTLabel)AddControl(new Guid("310b2d34-835f-40ab-86e1-b0601e7f1c63"));
            MultipleConvulsion = (ITTEnumComboBox)AddControl(new Guid("13d59205-43bd-4e5e-b7d0-ea17b461ae12"));
            labelMeanBloodPressure = (ITTLabel)AddControl(new Guid("84660dd2-d503-421c-b322-99c9216298e1"));
            MeanBloodPressure = (ITTEnumComboBox)AddControl(new Guid("9a238bfe-cdfb-4869-a364-6c4cb418266e"));
            labelLowestTemperature = (ITTLabel)AddControl(new Guid("44893222-1816-4863-a063-cd9fb5b83a4b"));
            LowestTemperature = (ITTEnumComboBox)AddControl(new Guid("f1e2d733-f363-468a-a39f-17504e95a719"));
            labelDiuresis = (ITTLabel)AddControl(new Guid("c773e5a9-3e19-48e0-aef3-bfd276fad772"));
            Diuresis = (ITTEnumComboBox)AddControl(new Guid("f2c65d17-57f6-4848-88d0-a74a827827c8"));
            labelBirthWeight = (ITTLabel)AddControl(new Guid("2bc48c75-08ed-4be8-9f68-f4f806dc9bfa"));
            BirthWeight = (ITTEnumComboBox)AddControl(new Guid("0cfae5c1-edd6-4660-bf8f-7214b9b8560a"));
            labelApgar = (ITTLabel)AddControl(new Guid("77ce14e9-156a-4ff1-928f-21e465653e66"));
            Apgar = (ITTEnumComboBox)AddControl(new Guid("9c879eb1-fed2-48cf-8890-8adc082b6bd6"));
            base.InitializeControls();
        }

        public SnappeIIScoreForm() : base("SNAPPE", "SnappeIIScoreForm")
        {
        }

        protected SnappeIIScoreForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}