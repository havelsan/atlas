
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
    public partial class MedicalInformationForm : TTForm
    {
    /// <summary>
    /// Tıbbi Bilgiler/Uyarılar/Alarmlar
    /// </summary>
        protected TTObjectClasses.MedicalInformation _MedicalInformation
        {
            get { return (TTObjectClasses.MedicalInformation)_ttObject; }
        }

        protected ITTCheckBox Pandemic;
        protected ITTCheckBox HighRiskPregnancy;
        protected ITTCheckBox Advers;
        protected ITTTextBox ContagiousDisease;
        protected ITTTextBox Transplantation;
        protected ITTTextBox OtherInformation;
        protected ITTTextBox OncologicFollowUp;
        protected ITTTextBox Implant;
        protected ITTTextBox Hemodialysis;
        protected ITTTextBox ChronicDiseases;
        protected ITTLabel labelHasContagiousDisease;
        protected ITTEnumComboBox HasContagiousDisease;
        protected ITTCheckBox CardiacPacemaker;
        protected ITTCheckBox VascularDisorder;
        protected ITTCheckBox Stent;
        protected ITTCheckBox Other;
        protected ITTCheckBox MetalImplant;
        protected ITTCheckBox Malignancy;
        protected ITTCheckBox Infection;
        protected ITTCheckBox HeartFailure;
        protected ITTCheckBox Diabetes;
        protected ITTCheckBox Broken;
        protected ITTGroupBox ttgroupboxDisability;
        protected ITTCheckBox ChronicMedicalInfoDisabledGroup;
        protected ITTCheckBox NonexistenceMedicalInfoDisabledGroup;
        protected ITTCheckBox HearingMedicalInfoDisabledGroup;
        protected ITTCheckBox MentalMedicalInfoDisabledGroup;
        protected ITTCheckBox OrthopedicMedicalInfoDisabledGroup;
        protected ITTCheckBox PsychicAndEmotionalMedicalInfoDisabledGroup;
        protected ITTCheckBox SpeechAndLanguageMedicalInfoDisabledGroup;
        protected ITTCheckBox VisionMedicalInfoDisabledGroup;
        protected ITTCheckBox UnclassifiedMedicalInfoDisabledGroup;
        protected ITTGroupBox ttgroupboxHabits;
        protected ITTCheckBox CigaretteMedicalInfoHabits;
        protected ITTObjectListBox CigaretteUsageFrequencyMedicalInfoHabits;
        protected ITTLabel labelDescriptionMedicalInfoHabits;
        protected ITTCheckBox OtherMedicalInfoHabits;
        protected ITTTextBox DescriptionMedicalInfoHabits;
        protected ITTCheckBox TeaMedicalInfoHabits;
        protected ITTLabel labelAlcoholUsageFrequencyMedicalInfoHabits;
        protected ITTCheckBox AlcoholMedicalInfoHabits;
        protected ITTObjectListBox AlcoholUsageFrequencyMedicalInfoHabits;
        protected ITTLabel labelCigaretteUsageFrequencyMedicalInfoHabits;
        protected ITTCheckBox CoffeeMedicalInfoHabits;
        protected ITTGroupBox ttgroupboxAllergies;
        protected ITTGrid MedicalInfoFoodAllergiesMedicalInfoFoodAllergies;
        protected ITTListBoxColumn DietMaterialMedicalInfoFoodAllergies;
        protected ITTGrid MedicalInfoDrugAllergiesMedicalInfoDrugAllergies;
        protected ITTListBoxColumn ActiveIngredientMedicalInfoDrugAllergies;
        protected ITTTextBox OtherAllergiesMedicalInfoAllergies;
        protected ITTLabel labelOtherAllergiesMedicalInfoAllergies;
        protected ITTLabel labelHasAllergy;
        protected ITTEnumComboBox HasAllergy;
        protected ITTLabel labelTransplantation;
        protected ITTCheckBox Pregnancy;
        protected ITTLabel labelOtherInformation;
        protected ITTLabel labelOncologicFollowUp;
        protected ITTLabel labelImplant;
        protected ITTLabel labelHemodialysis;
        protected ITTLabel labelChronicDiseases;
        override protected void InitializeControls()
        {
            Pandemic = (ITTCheckBox)AddControl(new Guid("5db52f03-e85b-4f04-a6b6-f6baaff444a4"));
            HighRiskPregnancy = (ITTCheckBox)AddControl(new Guid("63e5d819-e67d-4e71-85ab-80957eb53b92"));
            Advers = (ITTCheckBox)AddControl(new Guid("818aac9e-3450-484f-a299-e425824f6e9b"));
            ContagiousDisease = (ITTTextBox)AddControl(new Guid("6133ce5a-56a7-476f-bf20-91230fb88b0a"));
            Transplantation = (ITTTextBox)AddControl(new Guid("9b7b99fb-831b-45a5-99e8-8d0b676338d2"));
            OtherInformation = (ITTTextBox)AddControl(new Guid("3029b058-1084-4d49-b7c4-19713d02a999"));
            OncologicFollowUp = (ITTTextBox)AddControl(new Guid("1f5a8ba5-8312-49a2-9166-1101f23703be"));
            Implant = (ITTTextBox)AddControl(new Guid("51a65d3b-b50b-4b9d-9d35-6e3b148d8b55"));
            Hemodialysis = (ITTTextBox)AddControl(new Guid("e40c494d-2d5d-4891-a345-4d2a78ed31bc"));
            ChronicDiseases = (ITTTextBox)AddControl(new Guid("5990158c-3f26-43be-bcd6-724cb20b4cc9"));
            labelHasContagiousDisease = (ITTLabel)AddControl(new Guid("9831de92-19a2-467b-9341-75b9b20402da"));
            HasContagiousDisease = (ITTEnumComboBox)AddControl(new Guid("fc1b16c9-9b73-4cba-9349-6db2fac2a8e7"));
            CardiacPacemaker = (ITTCheckBox)AddControl(new Guid("2d462762-ff43-487f-8946-0a7305e352f0"));
            VascularDisorder = (ITTCheckBox)AddControl(new Guid("05fef862-1ce2-4fbc-be6d-218c0775c8e2"));
            Stent = (ITTCheckBox)AddControl(new Guid("d1f1b1f0-3679-4131-bfa9-28794c27a006"));
            Other = (ITTCheckBox)AddControl(new Guid("66c2b540-b4db-4c4d-9807-f6f75b0c709d"));
            MetalImplant = (ITTCheckBox)AddControl(new Guid("269740fc-c671-4b72-af0f-27a9f0ba6bf9"));
            Malignancy = (ITTCheckBox)AddControl(new Guid("96947183-7bef-46a7-a291-59333626463a"));
            Infection = (ITTCheckBox)AddControl(new Guid("bfb1a521-3ad3-45fc-ba99-fa9c2510bd0d"));
            HeartFailure = (ITTCheckBox)AddControl(new Guid("cbb65e56-986d-48ac-9365-a72a0b07be49"));
            Diabetes = (ITTCheckBox)AddControl(new Guid("d380e588-a225-4472-b240-530213fb80eb"));
            Broken = (ITTCheckBox)AddControl(new Guid("0470020a-c0d3-4433-a436-ec932a3e14c8"));
            ttgroupboxDisability = (ITTGroupBox)AddControl(new Guid("495e2b06-64fb-47ff-9154-90096af68206"));
            ChronicMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("20b68967-da73-4a3a-8446-ccd53ca2a931"));
            NonexistenceMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("7781bb93-6968-4ddb-b82f-1c424a17aa1d"));
            HearingMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("534e2f2d-54ff-4985-82af-fcae12121e1d"));
            MentalMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("f9832ff6-fb58-4fe0-877c-c5b629064079"));
            OrthopedicMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("400374c3-de8f-463d-bc1a-5708cd08c639"));
            PsychicAndEmotionalMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("de0ee943-0be8-42c3-833c-5468d93ebf44"));
            SpeechAndLanguageMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("d0975674-f1d2-47b2-9754-c1f1fa94dbd3"));
            VisionMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("9a38956b-9240-4920-b8c6-075dae84026d"));
            UnclassifiedMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("e28cf308-0436-49d6-a904-70296ec19bb5"));
            ttgroupboxHabits = (ITTGroupBox)AddControl(new Guid("ab3de040-1874-4f71-a735-d15ce75c0199"));
            CigaretteMedicalInfoHabits = (ITTCheckBox)AddControl(new Guid("005c6039-49cd-4569-9b76-c8e92c1eaf0a"));
            CigaretteUsageFrequencyMedicalInfoHabits = (ITTObjectListBox)AddControl(new Guid("d51c65e3-cc8c-4011-8803-3f36b299396c"));
            labelDescriptionMedicalInfoHabits = (ITTLabel)AddControl(new Guid("30c6b27f-dad9-4770-95bc-82afcf4469bd"));
            OtherMedicalInfoHabits = (ITTCheckBox)AddControl(new Guid("adc5c137-7343-4fa9-9b0c-a44889345a1c"));
            DescriptionMedicalInfoHabits = (ITTTextBox)AddControl(new Guid("79bd6fba-f347-40b7-b5c8-0f4413ffda0a"));
            TeaMedicalInfoHabits = (ITTCheckBox)AddControl(new Guid("8db331a9-8e54-4dbe-be77-5bdb514606b5"));
            labelAlcoholUsageFrequencyMedicalInfoHabits = (ITTLabel)AddControl(new Guid("1cdbbdf5-94d8-4822-b385-796d92bc6ee4"));
            AlcoholMedicalInfoHabits = (ITTCheckBox)AddControl(new Guid("2d95382d-ff55-4aed-a0ac-332854f123d9"));
            AlcoholUsageFrequencyMedicalInfoHabits = (ITTObjectListBox)AddControl(new Guid("4142a2d1-81bd-4d26-8fdf-289ec2ed8c16"));
            labelCigaretteUsageFrequencyMedicalInfoHabits = (ITTLabel)AddControl(new Guid("7ae94675-0a77-4371-b6da-d06b8f4a8b5d"));
            CoffeeMedicalInfoHabits = (ITTCheckBox)AddControl(new Guid("c6f139b7-0967-45b9-84b7-de0383e81a4f"));
            ttgroupboxAllergies = (ITTGroupBox)AddControl(new Guid("209cc3cb-07d4-4cd1-b386-4ba57354d18b"));
            MedicalInfoFoodAllergiesMedicalInfoFoodAllergies = (ITTGrid)AddControl(new Guid("70eb203a-1d66-4cfa-85bd-01dffd0b4079"));
            DietMaterialMedicalInfoFoodAllergies = (ITTListBoxColumn)AddControl(new Guid("ecacab59-4c6b-42bd-a3ab-ea077301c3a7"));
            MedicalInfoDrugAllergiesMedicalInfoDrugAllergies = (ITTGrid)AddControl(new Guid("814a7f78-3198-45fe-b2f8-0a8b89a806ca"));
            ActiveIngredientMedicalInfoDrugAllergies = (ITTListBoxColumn)AddControl(new Guid("774ce4ae-dff5-4d3d-ab2c-bb91a9f238a1"));
            OtherAllergiesMedicalInfoAllergies = (ITTTextBox)AddControl(new Guid("f7636cc0-2ade-47e5-8a57-9d81b7fddcf6"));
            labelOtherAllergiesMedicalInfoAllergies = (ITTLabel)AddControl(new Guid("cb2b2081-594b-4cb2-a944-b2c6751ee6fe"));
            labelHasAllergy = (ITTLabel)AddControl(new Guid("5b243158-a632-4f5a-9c35-8da61a38c762"));
            HasAllergy = (ITTEnumComboBox)AddControl(new Guid("b1297217-0a8e-4a3c-95b5-730930d0a56a"));
            labelTransplantation = (ITTLabel)AddControl(new Guid("6fdf87f1-3ad4-40c5-9961-676ed10805c8"));
            Pregnancy = (ITTCheckBox)AddControl(new Guid("359380cc-3342-4c10-9a01-f38e984a57ad"));
            labelOtherInformation = (ITTLabel)AddControl(new Guid("9d3ab9a7-72bb-4c81-8ede-603279a2153e"));
            labelOncologicFollowUp = (ITTLabel)AddControl(new Guid("27a993f3-f0d0-44c6-95f4-b15f42dbad5f"));
            labelImplant = (ITTLabel)AddControl(new Guid("a5d18144-7f55-4c39-a19d-7ae5baafed50"));
            labelHemodialysis = (ITTLabel)AddControl(new Guid("9ae4d85e-f687-4973-bd62-fdc1d0e464b1"));
            labelChronicDiseases = (ITTLabel)AddControl(new Guid("3cbc2b7c-2041-4c85-a285-74f963063a7b"));
            base.InitializeControls();
        }

        public MedicalInformationForm() : base("MEDICALINFORMATION", "MedicalInformationForm")
        {
        }

        protected MedicalInformationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}