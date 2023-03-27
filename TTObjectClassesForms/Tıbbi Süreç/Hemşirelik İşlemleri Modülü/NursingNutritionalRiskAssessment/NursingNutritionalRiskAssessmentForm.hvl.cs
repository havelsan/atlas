
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
    public partial class NursingNutritionalRiskAssessmentForm : BaseNursingDataEntryForm
    {
    /// <summary>
    /// Nutrisyonel Risk Skoru Değerlendirme Formu
    /// </summary>
        protected TTObjectClasses.NursingNutritionalRiskAssessment _NursingNutritionalRiskAssessment
        {
            get { return (TTObjectClasses.NursingNutritionalRiskAssessment)_ttObject; }
        }

        protected ITTLabel labelWeight;
        protected ITTTextBox Weight;
        protected ITTTextBox Height;
        protected ITTTextBox TotalScore;
        protected ITTLabel labelHeight;
        protected ITTPanel ttpanel1;
        protected ITTCheckBox DiseaseLevelHigh;
        protected ITTCheckBox DiseaseLevelMedium;
        protected ITTCheckBox DiseaseLevelLow;
        protected ITTCheckBox DiseaseLevelNormal;
        protected ITTLabel labelNutritionIntake;
        protected ITTEnumComboBox NutritionIntake;
        protected ITTLabel labelApplicationDate;
        protected ITTDateTimePicker ApplicationDate;
        protected ITTLabel labelTotalScore;
        protected ITTCheckBox SevereDiseaseInfo;
        protected ITTCheckBox WeeklyIntakeDecrease;
        protected ITTCheckBox ThreeMonthWeightLoss;
        protected ITTCheckBox BMI;
        override protected void InitializeControls()
        {
            labelWeight = (ITTLabel)AddControl(new Guid("2dc9ef9a-ff70-44fd-abf6-1067d2353706"));
            Weight = (ITTTextBox)AddControl(new Guid("e4b087d7-ba3b-42ca-8bb9-2158558ef5c8"));
            Height = (ITTTextBox)AddControl(new Guid("892abfca-132f-4dd5-adff-9188a62f921f"));
            TotalScore = (ITTTextBox)AddControl(new Guid("d509d9af-a903-4078-88d9-6dff5882a3ca"));
            labelHeight = (ITTLabel)AddControl(new Guid("bcdda085-e750-4bd9-a51f-69925747b59b"));
            ttpanel1 = (ITTPanel)AddControl(new Guid("e5f3b6f3-ed06-4a8b-9756-a9397b336e81"));
            DiseaseLevelHigh = (ITTCheckBox)AddControl(new Guid("02070345-e8bf-4956-ba07-9a33cf9bdba2"));
            DiseaseLevelMedium = (ITTCheckBox)AddControl(new Guid("3f2157f9-c9fa-43c2-a667-99415223251f"));
            DiseaseLevelLow = (ITTCheckBox)AddControl(new Guid("4c141bf0-8761-4604-a328-0bd42bb9fcc1"));
            DiseaseLevelNormal = (ITTCheckBox)AddControl(new Guid("644eb421-904f-4b04-8f50-113714954d2f"));
            labelNutritionIntake = (ITTLabel)AddControl(new Guid("0d845d25-6092-4c75-b757-45e5fcf618a6"));
            NutritionIntake = (ITTEnumComboBox)AddControl(new Guid("25584efb-1a3e-41a8-b297-15aba2f887ae"));
            labelApplicationDate = (ITTLabel)AddControl(new Guid("f14a7ac5-c2ac-4244-8327-a1bd47dd0709"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("35a14ef2-8ea4-426d-bfea-e4470ce16e47"));
            labelTotalScore = (ITTLabel)AddControl(new Guid("f777c494-3265-4ef2-9d43-c6d233033cf1"));
            SevereDiseaseInfo = (ITTCheckBox)AddControl(new Guid("8eba8813-81fe-4837-818d-23cab4d11ad6"));
            WeeklyIntakeDecrease = (ITTCheckBox)AddControl(new Guid("27b8061a-fefa-4184-8a50-25bd7404839c"));
            ThreeMonthWeightLoss = (ITTCheckBox)AddControl(new Guid("783ce966-e188-4f7b-8092-8c5c775e43b7"));
            BMI = (ITTCheckBox)AddControl(new Guid("e594812f-6f01-4600-88d4-4103e71f351d"));
            base.InitializeControls();
        }

        public NursingNutritionalRiskAssessmentForm() : base("NURSINGNUTRITIONALRISKASSESSMENT", "NursingNutritionalRiskAssessmentForm")
        {
        }

        protected NursingNutritionalRiskAssessmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}