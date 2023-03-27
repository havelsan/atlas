
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
    public partial class CigaretteAssessmentForm : TTForm
    {
        protected TTObjectClasses.CigaretteExamination _CigaretteExamination
        {
            get { return (TTObjectClasses.CigaretteExamination)_ttObject; }
        }

        protected ITTObjectListBox SKRSMaritalStatus;
        protected ITTLabel labelProfessionalSupport;
        protected ITTEnumComboBox ProfessionalSupport;
        protected ITTLabel labelPassiveSmokersAtHome;
        protected ITTTextBox PassiveSmokersAtHome;
        protected ITTTextBox FirstSmokeAfterWakeUp;
        protected ITTTextBox FreeTime;
        protected ITTTextBox SmokingAtWorkPlaceAmount;
        protected ITTTextBox TryingQuitSmokingAmount;
        protected ITTTextBox DailyCigaretteAmount;
        protected ITTTextBox SmokingYearRate;
        protected ITTTextBox SmokingStartAge;
        protected ITTTextBox Job;
        protected ITTTextBox EMailPatient;
        protected ITTLabel labelOtherSmokersAtWorkPlace;
        protected ITTEnumComboBox OtherSmokersAtWorkPlace;
        protected ITTLabel labelOtherSmokersAtHome;
        protected ITTEnumComboBox OtherSmokersAtHome;
        protected ITTLabel labelContinueSmoking;
        protected ITTEnumComboBox ContinueSmoking;
        protected ITTLabel labelGiveUpTime;
        protected ITTEnumComboBox GiveUpTime;
        protected ITTLabel labelPlacesThatBanSmoking;
        protected ITTEnumComboBox PlacesThatBanSmoking;
        protected ITTEnumComboBox FirstsmokeAfterWakeUpType;
        protected ITTLabel labelFirstSmokeAfterWakeUp;
        protected ITTLabel labelUsedAddictiveDrugs;
        protected ITTEnumComboBox UsedAddictiveDrugs;
        protected ITTLabel labelFreeTime;
        protected ITTEnumComboBox SmokingAtWorkPlaceAmountType;
        protected ITTLabel labelSmokingAtWorkPlaceAmount;
        protected ITTLabel labelIncreaseSmokingReasons;
        protected ITTEnumComboBox IncreaseSmokingReasons;
        protected ITTLabel labelQuitSmokingMethod;
        protected ITTEnumComboBox QuitSmokingMethod;
        protected ITTGroupBox gb1;
        protected ITTTextBox Challenges;
        protected ITTCheckBox Other;
        protected ITTCheckBox NoDifficulty;
        protected ITTCheckBox MouthSore;
        protected ITTCheckBox IncreasedAppetite;
        protected ITTCheckBox ExcessiveSmoking;
        protected ITTCheckBox Imbalance;
        protected ITTCheckBox SleepingDisorder;
        protected ITTCheckBox HeadAndFacialNumbness;
        protected ITTCheckBox LossOfConcentration;
        protected ITTCheckBox Irritability;
        protected ITTCheckBox HeadacheAndDizziness;
        protected ITTCheckBox Constipation;
        protected ITTLabel labelTryingQuitSmoking;
        protected ITTEnumComboBox TryingQuitSmoking;
        protected ITTLabel labelThinkingOfQuitSmoking;
        protected ITTEnumComboBox ThinkingOfQuitSmoking;
        protected ITTLabel labelCigaretteType;
        protected ITTEnumComboBox CigaretteType;
        protected ITTLabel labelDailyCigaretteAmount;
        protected ITTLabel labelSmokingAmountChange;
        protected ITTEnumComboBox SmokingAmountChange;
        protected ITTLabel labelQuitSmokingReason;
        protected ITTEnumComboBox QuitSmokingReason;
        protected ITTLabel labelStartSmokingReason;
        protected ITTEnumComboBox StartSmokingReason;
        protected ITTLabel labelSmokingYearRate;
        protected ITTLabel labelSmokingStartAge;
        protected ITTLabel labelJob;
        protected ITTLabel labelEMailPatient;
        protected ITTLabel labelMaritalStatusC;
        protected ITTObjectListBox EducationStatusC;
        protected ITTLabel labelEducationStatusC;
        protected ITTObjectListBox OccupationPatientC;
        protected ITTLabel labelOccupationC;
        override protected void InitializeControls()
        {
            SKRSMaritalStatus = (ITTObjectListBox)AddControl(new Guid("e1349f78-eacd-4f80-bf8c-5afb9237c8e5"));
            labelProfessionalSupport = (ITTLabel)AddControl(new Guid("5de487e9-a7eb-4d28-958f-6b0a1fe25285"));
            ProfessionalSupport = (ITTEnumComboBox)AddControl(new Guid("f57c95c0-9c2a-4e2e-ad91-e72324e4c1ec"));
            labelPassiveSmokersAtHome = (ITTLabel)AddControl(new Guid("91976e95-f65c-42d0-8f93-1a9122c5bb2d"));
            PassiveSmokersAtHome = (ITTTextBox)AddControl(new Guid("f8fe77cb-1110-4214-a1d5-49ceeb5742a9"));
            FirstSmokeAfterWakeUp = (ITTTextBox)AddControl(new Guid("4d1add62-6287-47ba-8401-439b6c3a6a9f"));
            FreeTime = (ITTTextBox)AddControl(new Guid("b51b8de6-82bd-44e4-940d-54498110d6ff"));
            SmokingAtWorkPlaceAmount = (ITTTextBox)AddControl(new Guid("039bbe1b-cce8-41c8-af96-f2e1d6142dc8"));
            TryingQuitSmokingAmount = (ITTTextBox)AddControl(new Guid("56b578fe-99e2-4339-b4f0-bae9798c02ec"));
            DailyCigaretteAmount = (ITTTextBox)AddControl(new Guid("dc629867-7509-43e9-8efc-79af84617cd4"));
            SmokingYearRate = (ITTTextBox)AddControl(new Guid("e935a913-aafd-42a7-9620-2eb044f46701"));
            SmokingStartAge = (ITTTextBox)AddControl(new Guid("80074b9d-437a-44cc-8807-8ec7451003b6"));
            Job = (ITTTextBox)AddControl(new Guid("bb5585f5-0682-4886-bde8-6ba2ed164e2a"));
            EMailPatient = (ITTTextBox)AddControl(new Guid("a5427922-1a9c-47bb-a496-b0edfc115ac5"));
            labelOtherSmokersAtWorkPlace = (ITTLabel)AddControl(new Guid("262b9170-311e-490c-9dfa-c6335d807d4b"));
            OtherSmokersAtWorkPlace = (ITTEnumComboBox)AddControl(new Guid("eaab10ac-b4e5-46f0-a95f-86d0cc640e44"));
            labelOtherSmokersAtHome = (ITTLabel)AddControl(new Guid("113effcf-c740-464e-b04a-a3886af83b76"));
            OtherSmokersAtHome = (ITTEnumComboBox)AddControl(new Guid("62373a38-1ac4-4a8a-813f-d0d20152e673"));
            labelContinueSmoking = (ITTLabel)AddControl(new Guid("06c36ea7-91ff-4b4c-b199-bf7e96d9a7df"));
            ContinueSmoking = (ITTEnumComboBox)AddControl(new Guid("0cdd1da7-a4f1-48a5-b85e-1a08f181dfb9"));
            labelGiveUpTime = (ITTLabel)AddControl(new Guid("42f94a8b-94a9-44b3-88f2-e23d79099fbc"));
            GiveUpTime = (ITTEnumComboBox)AddControl(new Guid("55625009-aa4e-47e1-aa1a-66747f93c52a"));
            labelPlacesThatBanSmoking = (ITTLabel)AddControl(new Guid("d564c812-806c-4cb4-8172-8153f7bcd0fa"));
            PlacesThatBanSmoking = (ITTEnumComboBox)AddControl(new Guid("27631801-603e-490a-8471-d9957380ba90"));
            FirstsmokeAfterWakeUpType = (ITTEnumComboBox)AddControl(new Guid("f7ec6223-bfbb-4ea7-a8a2-b226ea5fad30"));
            labelFirstSmokeAfterWakeUp = (ITTLabel)AddControl(new Guid("734a64a5-1089-440f-a592-b704eefb8bda"));
            labelUsedAddictiveDrugs = (ITTLabel)AddControl(new Guid("9550b053-62e1-41ec-af7b-742a559d730b"));
            UsedAddictiveDrugs = (ITTEnumComboBox)AddControl(new Guid("0da178fd-3684-4cd7-b441-0bbaa72e0ba4"));
            labelFreeTime = (ITTLabel)AddControl(new Guid("ccafb18d-591a-446e-b8db-edf3e4d55517"));
            SmokingAtWorkPlaceAmountType = (ITTEnumComboBox)AddControl(new Guid("430b595f-3808-4f4a-bf1b-540f96013003"));
            labelSmokingAtWorkPlaceAmount = (ITTLabel)AddControl(new Guid("8ab80531-bcfb-422f-876c-ce371e2ce133"));
            labelIncreaseSmokingReasons = (ITTLabel)AddControl(new Guid("936c2d19-8f19-490f-a18a-5b2f24d39b00"));
            IncreaseSmokingReasons = (ITTEnumComboBox)AddControl(new Guid("8c5e300f-9d77-4424-b797-84cefefe6cd5"));
            labelQuitSmokingMethod = (ITTLabel)AddControl(new Guid("854440cb-db50-42d4-9bc5-13f6d58be16c"));
            QuitSmokingMethod = (ITTEnumComboBox)AddControl(new Guid("f520ab2a-2024-4eb6-9a6e-abeb75d73eb1"));
            gb1 = (ITTGroupBox)AddControl(new Guid("fe9a489a-269a-4214-af79-b56c2cf1322e"));
            Challenges = (ITTTextBox)AddControl(new Guid("f42efd4d-c94e-4905-9df9-a563a280d993"));
            Other = (ITTCheckBox)AddControl(new Guid("62ea6d96-6b81-460e-a774-53b1e99bfed3"));
            NoDifficulty = (ITTCheckBox)AddControl(new Guid("4db307bc-7bb8-44c6-afdb-6188820837b5"));
            MouthSore = (ITTCheckBox)AddControl(new Guid("1f34b0bb-274a-4368-8223-3da2c4f0b82d"));
            IncreasedAppetite = (ITTCheckBox)AddControl(new Guid("d1b74ccc-6993-4ec4-9baf-682d6e9ebcf6"));
            ExcessiveSmoking = (ITTCheckBox)AddControl(new Guid("d5f76d57-b590-44bd-8a3c-5f85609400d7"));
            Imbalance = (ITTCheckBox)AddControl(new Guid("c4537fa4-2c8c-440c-b945-5bd6a02db4e9"));
            SleepingDisorder = (ITTCheckBox)AddControl(new Guid("df1c24e7-8ad6-4ed8-b190-203304cd303d"));
            HeadAndFacialNumbness = (ITTCheckBox)AddControl(new Guid("df11c2d3-fede-4d16-b046-218e24ce72f5"));
            LossOfConcentration = (ITTCheckBox)AddControl(new Guid("6137864b-3420-438c-9e95-b22d9a7ed210"));
            Irritability = (ITTCheckBox)AddControl(new Guid("3394affc-3a62-468b-ac9d-317a2168c128"));
            HeadacheAndDizziness = (ITTCheckBox)AddControl(new Guid("0d220aa9-c2e7-4385-a10a-5d411b57a835"));
            Constipation = (ITTCheckBox)AddControl(new Guid("f016cf84-cd64-4117-942d-6467e658835a"));
            labelTryingQuitSmoking = (ITTLabel)AddControl(new Guid("4fdf84da-2fac-40b2-9f40-608792494637"));
            TryingQuitSmoking = (ITTEnumComboBox)AddControl(new Guid("5cbe06a2-6bc6-404b-ae0d-c5af8bc6f0b2"));
            labelThinkingOfQuitSmoking = (ITTLabel)AddControl(new Guid("815a85fc-bbd6-4b92-b452-1d50cc1ba1a6"));
            ThinkingOfQuitSmoking = (ITTEnumComboBox)AddControl(new Guid("d7b7260d-dc40-429f-8754-21e8fb2d4d3a"));
            labelCigaretteType = (ITTLabel)AddControl(new Guid("e5ad879b-0623-45c9-9fed-c6a3986103ea"));
            CigaretteType = (ITTEnumComboBox)AddControl(new Guid("e5a01288-161a-47bb-8052-f036725b596f"));
            labelDailyCigaretteAmount = (ITTLabel)AddControl(new Guid("1013b481-bbfb-4393-a558-cfc3c861a0f3"));
            labelSmokingAmountChange = (ITTLabel)AddControl(new Guid("26261656-fe09-4c93-81ec-53af081e2e80"));
            SmokingAmountChange = (ITTEnumComboBox)AddControl(new Guid("ce03a7a7-49b9-46b3-80f8-9787668dc5bd"));
            labelQuitSmokingReason = (ITTLabel)AddControl(new Guid("9f7fddcd-206b-4ad6-a912-530a5f12e464"));
            QuitSmokingReason = (ITTEnumComboBox)AddControl(new Guid("e3432080-5021-44b8-b17d-2b6bd7daadc5"));
            labelStartSmokingReason = (ITTLabel)AddControl(new Guid("346a00b7-ff25-4185-b9df-86301d296528"));
            StartSmokingReason = (ITTEnumComboBox)AddControl(new Guid("0390ea57-3368-4e4b-97d5-361cd0be7ea8"));
            labelSmokingYearRate = (ITTLabel)AddControl(new Guid("513dc413-2787-4283-88f8-062e91f5f814"));
            labelSmokingStartAge = (ITTLabel)AddControl(new Guid("0d0a5193-5157-410a-ba5a-8c92a4831a0a"));
            labelJob = (ITTLabel)AddControl(new Guid("6ec57941-32e4-404a-ac2d-6b56208c7415"));
            labelEMailPatient = (ITTLabel)AddControl(new Guid("dd88f419-ce1e-42f8-a270-d0c9eca64c0a"));
            labelMaritalStatusC = (ITTLabel)AddControl(new Guid("11af7dd9-6510-462d-8278-b566243bf584"));
            EducationStatusC = (ITTObjectListBox)AddControl(new Guid("e4a836d2-3a0a-416c-8468-72310897a07a"));
            labelEducationStatusC = (ITTLabel)AddControl(new Guid("76df60ad-a6d0-4140-99eb-b198ef382c9e"));
            OccupationPatientC = (ITTObjectListBox)AddControl(new Guid("fea86e28-612a-4901-a65a-94d73f771db0"));
            labelOccupationC = (ITTLabel)AddControl(new Guid("d36984d9-ab08-4e61-bc75-868d8409032a"));
            base.InitializeControls();
        }

        public CigaretteAssessmentForm() : base("CIGARETTEEXAMINATION", "CigaretteAssessmentForm")
        {
        }

        protected CigaretteAssessmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}