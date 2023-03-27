
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
    public partial class InfertilityPatientInformationForm : TTForm
    {
        protected TTObjectClasses.InfertilityPatientInformation _InfertilityPatientInformation
        {
            get { return (TTObjectClasses.InfertilityPatientInformation)_ttObject; }
        }

        protected ITTTextBox PatientsSurgeries;
        protected ITTTextBox OFISHSInformation;
        protected ITTTextBox LaparoscopyInformation;
        protected ITTTextBox HysteroscopyInformation;
        protected ITTTextBox HusbandsSurgeries;
        protected ITTTextBox HistoryOfTreatment;
        protected ITTPanel ttpanel1;
        protected ITTLabel labelHysterosalpingographyDate;
        protected ITTLabel labelTubalRight;
        protected ITTLabel labelUterineCavity;
        protected ITTTextBox TubalRight;
        protected ITTTextBox UterineCavity;
        protected ITTLabel labelTubalLeft;
        protected ITTTextBox TubalLeft;
        protected ITTDateTimePicker HysterosalpingographyDate;
        protected ITTTextBox Lipiodolography;
        protected ITTLabel labelLipiodolography;
        protected ITTTextBox SuSoluble;
        protected ITTLabel labelSuSoluble;
        protected ITTTextBox AbdominalDistribution;
        protected ITTLabel labelAbdominalDistribution;
        protected ITTLabel labelPatientsSurgeries;
        protected ITTLabel labelOFISHSInformation;
        protected ITTLabel labelOFISHSDate;
        protected ITTDateTimePicker OFISHSDate;
        protected ITTLabel labelLaparoscopyInformation;
        protected ITTLabel labelLaparoscopyDate;
        protected ITTDateTimePicker LaparoscopyDate;
        protected ITTLabel labelHysteroscopyInformation;
        protected ITTLabel labelHysteroscopyDate;
        protected ITTDateTimePicker HysteroscopyDate;
        protected ITTLabel labelHusbandsSurgeries;
        protected ITTLabel labelHistoryOfTreatment;
        override protected void InitializeControls()
        {
            PatientsSurgeries = (ITTTextBox)AddControl(new Guid("01f37f03-437c-4e64-b586-1727ca7debf7"));
            OFISHSInformation = (ITTTextBox)AddControl(new Guid("077a9533-99b8-40a9-bbe8-aeaff5e3d6ae"));
            LaparoscopyInformation = (ITTTextBox)AddControl(new Guid("e55ef0f7-7f16-449d-b10f-ac37c0b9c2a0"));
            HysteroscopyInformation = (ITTTextBox)AddControl(new Guid("0741b1a2-23b9-4eee-bebb-8233bdcb2447"));
            HusbandsSurgeries = (ITTTextBox)AddControl(new Guid("7915cb16-0878-4ecf-bdea-c7bb08805882"));
            HistoryOfTreatment = (ITTTextBox)AddControl(new Guid("0afe46e9-3054-48f0-bea7-4eae546a7349"));
            ttpanel1 = (ITTPanel)AddControl(new Guid("48eba51e-1cbe-49f9-94be-aa844b8c5928"));
            labelHysterosalpingographyDate = (ITTLabel)AddControl(new Guid("d5bec211-adca-4604-9d05-4eb437b40d8a"));
            labelTubalRight = (ITTLabel)AddControl(new Guid("d0a4ebe2-9c30-4e43-8bf4-f20bd9cbad4b"));
            labelUterineCavity = (ITTLabel)AddControl(new Guid("1bf2fdf7-0f60-406d-81e9-fd61e23abcd5"));
            TubalRight = (ITTTextBox)AddControl(new Guid("4798e0ef-26e9-4440-8b0d-b3b2f4b2b4ca"));
            UterineCavity = (ITTTextBox)AddControl(new Guid("ebe468f4-857d-4c24-8aaa-c8c7583cc2b3"));
            labelTubalLeft = (ITTLabel)AddControl(new Guid("7add0d42-7ce8-4296-913b-e7a3bc089f9b"));
            TubalLeft = (ITTTextBox)AddControl(new Guid("6ec29cf6-eca5-4701-ab7b-b8600c4f71bd"));
            HysterosalpingographyDate = (ITTDateTimePicker)AddControl(new Guid("a6fb6a73-411d-44b2-9818-a73ba1936343"));
            Lipiodolography = (ITTTextBox)AddControl(new Guid("f85497d3-4efe-483d-9ad2-f1197450daea"));
            labelLipiodolography = (ITTLabel)AddControl(new Guid("c7e402e5-4a6d-4910-bf4f-b2ac0d07fe14"));
            SuSoluble = (ITTTextBox)AddControl(new Guid("41ecf2d2-2449-447d-9881-9a70cde15c94"));
            labelSuSoluble = (ITTLabel)AddControl(new Guid("72456b61-bb14-4a40-b272-c5f5e4715f34"));
            AbdominalDistribution = (ITTTextBox)AddControl(new Guid("a6e1a49b-ebc1-47af-a043-96b46f8038ed"));
            labelAbdominalDistribution = (ITTLabel)AddControl(new Guid("fb3a4e94-e686-43d5-99c7-b8e13d2d70cb"));
            labelPatientsSurgeries = (ITTLabel)AddControl(new Guid("de19bb31-6209-49fa-bec4-09a8a222cb0e"));
            labelOFISHSInformation = (ITTLabel)AddControl(new Guid("3d230072-5148-4e79-a739-21ad566e45cd"));
            labelOFISHSDate = (ITTLabel)AddControl(new Guid("4af4c041-02e6-48db-b253-76260be4c04a"));
            OFISHSDate = (ITTDateTimePicker)AddControl(new Guid("c9ec62a0-ce40-4227-bab0-3c3a763bc8b1"));
            labelLaparoscopyInformation = (ITTLabel)AddControl(new Guid("97ebbfb2-a406-471a-8539-d93d54045e73"));
            labelLaparoscopyDate = (ITTLabel)AddControl(new Guid("6c437b86-11e4-491a-b90c-54b7ab1f27aa"));
            LaparoscopyDate = (ITTDateTimePicker)AddControl(new Guid("be5471ee-f5d9-47b5-88b3-514bf496600c"));
            labelHysteroscopyInformation = (ITTLabel)AddControl(new Guid("243b2220-c152-4fed-8b8d-2d641b89ea14"));
            labelHysteroscopyDate = (ITTLabel)AddControl(new Guid("a2c16c83-b9d2-4c64-8410-11819f16bf23"));
            HysteroscopyDate = (ITTDateTimePicker)AddControl(new Guid("04d1de26-d287-4b56-abba-1cbf2130b98d"));
            labelHusbandsSurgeries = (ITTLabel)AddControl(new Guid("cb59fe3d-b6b7-474d-8954-4d92bb7ee9e1"));
            labelHistoryOfTreatment = (ITTLabel)AddControl(new Guid("cbdcc364-7c26-4e07-b6aa-0c949f5c354b"));
            base.InitializeControls();
        }

        public InfertilityPatientInformationForm() : base("INFERTILITYPATIENTINFORMATION", "InfertilityPatientInformationForm")
        {
        }

        protected InfertilityPatientInformationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}