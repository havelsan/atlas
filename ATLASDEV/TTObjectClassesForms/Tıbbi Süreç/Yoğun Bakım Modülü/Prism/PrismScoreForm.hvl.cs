
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
    public partial class PrismScoreForm : BaseMultipleDataEntryForm
    {
    /// <summary>
    /// PRISM Skorlama
    /// </summary>
        protected TTObjectClasses.Prism _Prism
        {
            get { return (TTObjectClasses.Prism)_ttObject; }
        }

        protected ITTLabel labelMortalityRate;
        protected ITTTextBox MortalityRate;
        protected ITTTextBox TotalScore;
        protected ITTLabel labelTotalScore;
        protected ITTLabel labelEntryDate;
        protected ITTDateTimePicker EntryDate;
        protected ITTLabel labelSystolicPressure;
        protected ITTEnumComboBox SystolicPressure;
        protected ITTLabel labelRespirationRate;
        protected ITTEnumComboBox RespirationRate;
        protected ITTLabel labelPupil;
        protected ITTEnumComboBox Pupil;
        protected ITTLabel labelPTT;
        protected ITTEnumComboBox PTT;
        protected ITTLabel labelPotassium;
        protected ITTEnumComboBox Potassium;
        protected ITTLabel labelPaO2FIO2;
        protected ITTEnumComboBox PaO2FIO2;
        protected ITTLabel labelPaCO2;
        protected ITTEnumComboBox PaCO2;
        protected ITTLabel labelHeartRate;
        protected ITTEnumComboBox HeartRate;
        protected ITTLabel labelHCO3;
        protected ITTEnumComboBox HCO3;
        protected ITTLabel labelGlucose;
        protected ITTEnumComboBox Glucose;
        protected ITTLabel labelDiastolicPressure;
        protected ITTEnumComboBox DiastolicPressure;
        protected ITTLabel labelCalcium;
        protected ITTEnumComboBox Calcium;
        protected ITTLabel labelBilirubin;
        protected ITTEnumComboBox Bilirubin;
        override protected void InitializeControls()
        {
            labelMortalityRate = (ITTLabel)AddControl(new Guid("3c1770b6-20cf-4e2a-aa35-3d55de0c4c85"));
            MortalityRate = (ITTTextBox)AddControl(new Guid("317eef1f-b678-48e6-9570-f0c7f0988fce"));
            TotalScore = (ITTTextBox)AddControl(new Guid("2958b16f-bb76-451c-b114-5d28029e0604"));
            labelTotalScore = (ITTLabel)AddControl(new Guid("71f0519a-83c4-4238-9726-6578d052a93a"));
            labelEntryDate = (ITTLabel)AddControl(new Guid("8ab476b0-70e9-4ea3-a94e-44417738bc94"));
            EntryDate = (ITTDateTimePicker)AddControl(new Guid("c987b8e0-3f05-407d-b0ca-56d6171a54ca"));
            labelSystolicPressure = (ITTLabel)AddControl(new Guid("2ae59f79-3e30-4155-95bd-c336795e8cd5"));
            SystolicPressure = (ITTEnumComboBox)AddControl(new Guid("1ea59e77-8268-4289-a8fc-0b484d42b0d6"));
            labelRespirationRate = (ITTLabel)AddControl(new Guid("3ac76951-5a45-4ae7-b9d9-315473b455a0"));
            RespirationRate = (ITTEnumComboBox)AddControl(new Guid("d8e8ead8-d992-4321-a533-ca91fe2dc1f8"));
            labelPupil = (ITTLabel)AddControl(new Guid("0b615d4b-a5cc-4c8b-ab56-ef9c09550c9e"));
            Pupil = (ITTEnumComboBox)AddControl(new Guid("c8680a1c-ed0e-458e-9614-ee4636738ce7"));
            labelPTT = (ITTLabel)AddControl(new Guid("08a47267-7a70-4a0a-b07f-3a67c3f9e2db"));
            PTT = (ITTEnumComboBox)AddControl(new Guid("0e06afbb-fe3f-4604-92b5-6a7292d784c6"));
            labelPotassium = (ITTLabel)AddControl(new Guid("5c923a4d-98a3-4a05-9ac1-fdc60311e93f"));
            Potassium = (ITTEnumComboBox)AddControl(new Guid("4f7645ee-6564-440d-a5af-9911dc323de3"));
            labelPaO2FIO2 = (ITTLabel)AddControl(new Guid("29ba6cf6-9e65-47b6-a8f0-2de3c87c2992"));
            PaO2FIO2 = (ITTEnumComboBox)AddControl(new Guid("1000eebb-621f-47b2-b2bd-ad0eef6714b5"));
            labelPaCO2 = (ITTLabel)AddControl(new Guid("933a8d83-922a-45d1-8b3e-1e34846c2de8"));
            PaCO2 = (ITTEnumComboBox)AddControl(new Guid("b9edee2c-b92a-42f3-928b-e48c41509e7e"));
            labelHeartRate = (ITTLabel)AddControl(new Guid("3acd3043-63d4-422d-b5cc-f77ea065c91e"));
            HeartRate = (ITTEnumComboBox)AddControl(new Guid("31a43924-8837-4b54-b27f-48eb9760d09f"));
            labelHCO3 = (ITTLabel)AddControl(new Guid("82863d1d-6dcc-4cd5-a2de-019d08eac30d"));
            HCO3 = (ITTEnumComboBox)AddControl(new Guid("125271f5-d231-4a6e-ac20-d4f15dabe195"));
            labelGlucose = (ITTLabel)AddControl(new Guid("db3854a5-975e-42f2-aeb8-7e00f9e97825"));
            Glucose = (ITTEnumComboBox)AddControl(new Guid("e99cae80-b3c2-4fe5-8fec-ee00095d9d46"));
            labelDiastolicPressure = (ITTLabel)AddControl(new Guid("d9c4c2ad-9685-4e16-875d-d1ef800f7866"));
            DiastolicPressure = (ITTEnumComboBox)AddControl(new Guid("47fde7d8-1ebe-4e0b-9152-edec70e64318"));
            labelCalcium = (ITTLabel)AddControl(new Guid("89e57ebd-976f-424f-980e-7a7922849c5f"));
            Calcium = (ITTEnumComboBox)AddControl(new Guid("4932fd3e-35e5-4ece-b6ef-d0ad5c1ad5d4"));
            labelBilirubin = (ITTLabel)AddControl(new Guid("6440f6db-a2ae-49f8-9bb5-7a123a8bf3fc"));
            Bilirubin = (ITTEnumComboBox)AddControl(new Guid("2e30dc3b-c3f5-42c1-8c61-cc1d72b2e04d"));
            base.InitializeControls();
        }

        public PrismScoreForm() : base("PRISM", "PrismScoreForm")
        {
        }

        protected PrismScoreForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}