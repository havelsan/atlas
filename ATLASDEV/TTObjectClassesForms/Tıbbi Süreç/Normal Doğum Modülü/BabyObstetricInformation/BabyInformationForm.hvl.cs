
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
    public partial class BabyInformationForm : TTForm
    {
    /// <summary>
    /// Bebek Bilgileri
    /// </summary>
        protected TTObjectClasses.BabyObstetricInformation _BabyObstetricInformation
        {
            get { return (TTObjectClasses.BabyObstetricInformation)_ttObject; }
        }

        protected ITTCheckBox ShowLCD;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox WristbandNumber;
        protected ITTTextBox BabyProblems;
        protected ITTTextBox Height;
        protected ITTTextBox Surname;
        protected ITTTextBox FatherName;
        protected ITTTextBox Weigth;
        protected ITTTextBox PregnancyWeek;
        protected ITTTextBox HeadCircumference;
        protected ITTGroupBox ttgroupbox2;
        protected ITTLabel labelTotalScoreApgar5;
        protected ITTTextBox TotalScoreApgar5;
        protected ITTLabel labelStimulusResponseApgar5;
        protected ITTEnumComboBox StimulusResponseApgar5;
        protected ITTLabel labelSkinColorApgar5;
        protected ITTEnumComboBox SkinColorApgar5;
        protected ITTLabel labelRespirationApgar5;
        protected ITTEnumComboBox RespirationApgar5;
        protected ITTLabel labelMuscularTonusApgar5;
        protected ITTEnumComboBox MuscularTonusApgar5;
        protected ITTLabel labelHeartRateApgar5;
        protected ITTEnumComboBox HeartRateApgar5;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelTotalScoreApgar1;
        protected ITTTextBox TotalScoreApgar1;
        protected ITTLabel labelStimulusResponseApgar1;
        protected ITTEnumComboBox StimulusResponseApgar1;
        protected ITTLabel labelSkinColorApgar1;
        protected ITTEnumComboBox SkinColorApgar1;
        protected ITTLabel labelRespirationApgar1;
        protected ITTEnumComboBox RespirationApgar1;
        protected ITTLabel labelMuscularTonusApgar1;
        protected ITTEnumComboBox MuscularTonusApgar1;
        protected ITTLabel labelHeartRateApgar1;
        protected ITTEnumComboBox HeartRateApgar1;
        protected ITTLabel labelGender;
        protected ITTObjectListBox Gender;
        protected ITTLabel labelBirthType;
        protected ITTObjectListBox BirthType;
        protected ITTLabel labelBirthOrder;
        protected ITTObjectListBox BirthOrder;
        protected ITTLabel labelBirthLocation;
        protected ITTObjectListBox BirthLocation;
        protected ITTLabel labelCauseOfDeath;
        protected ITTObjectListBox CauseOfDeath;
        protected ITTCheckBox FontanelExamination;
        protected ITTCheckBox TesticleExamination;
        protected ITTCheckBox IronSupplement;
        protected ITTCheckBox VitaminDSupplement;
        protected ITTCheckBox VisionScreening;
        protected ITTCheckBox HearingScreening;
        protected ITTCheckBox HypothyroidisBlood;
        protected ITTCheckBox Asphyxia;
        protected ITTCheckBox PrematureBaby;
        protected ITTCheckBox AbnormalBaby;
        protected ITTCheckBox VitaminKApplied;
        protected ITTCheckBox SuckledTheFirstHalfHour;
        protected ITTCheckBox WithoutBreastMilk;
        protected ITTCheckBox LactationInfo;
        protected ITTCheckBox HepatitisImmunoglobulin;
        protected ITTCheckBox HepatitisB;
        protected ITTCheckBox PhenylketonuriaBlood;
        protected ITTLabel labelWristbandNumber;
        protected ITTLabel labelBabyProblems;
        protected ITTLabel labelHeight;
        protected ITTLabel labelSurname;
        protected ITTLabel labelFatherName;
        protected ITTLabel labelWeigth;
        protected ITTLabel labelPresentationType;
        protected ITTEnumComboBox PresentationType;
        protected ITTLabel labelPregnancyWeek;
        protected ITTLabel labelPlacentaDecollementType;
        protected ITTEnumComboBox PlacentaDecollementType;
        protected ITTLabel labelHeadCircumference;
        protected ITTLabel labelFetalAnomalies;
        protected ITTEnumComboBox FetalAnomalies;
        protected ITTLabel labelDatetimeOfDeath;
        protected ITTDateTimePicker DatetimeOfDeath;
        protected ITTLabel labelBirthDateTime;
        protected ITTDateTimePicker BirthDateTime;
        protected ITTLabel labelBabyStatus;
        protected ITTEnumComboBox BabyStatus;
        protected ITTLabel labelAnesthesiaTechnique;
        protected ITTEnumComboBox AnesthesiaTechnique;
        override protected void InitializeControls()
        {
            ShowLCD = (ITTCheckBox)AddControl(new Guid("700f8419-b5f0-4888-991c-d5d9587a9ca3"));
            labelName = (ITTLabel)AddControl(new Guid("7fd506c8-9df1-4193-93e6-d399705b005b"));
            Name = (ITTTextBox)AddControl(new Guid("25add00d-2f74-412c-abc0-046e60b77ef9"));
            WristbandNumber = (ITTTextBox)AddControl(new Guid("93056b3f-d698-4d8c-b446-3c4420a9e1fd"));
            BabyProblems = (ITTTextBox)AddControl(new Guid("ac8e571f-d601-4786-b5a6-a19460bc0f68"));
            Height = (ITTTextBox)AddControl(new Guid("16d684cb-9779-4787-9166-5788a5e0eb3a"));
            Surname = (ITTTextBox)AddControl(new Guid("48b7ca45-4d4e-40ea-971c-6e226a2bad78"));
            FatherName = (ITTTextBox)AddControl(new Guid("4b4894c0-0fcf-45a9-8fd3-97658b13d32b"));
            Weigth = (ITTTextBox)AddControl(new Guid("471eeadf-fc5d-46f4-8088-31b006c8ab56"));
            PregnancyWeek = (ITTTextBox)AddControl(new Guid("cb76781f-8da3-4f4f-8ab1-50d25ce4506b"));
            HeadCircumference = (ITTTextBox)AddControl(new Guid("af7b0b13-7d4b-41ca-920e-907fa7deb144"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("1380f538-123d-43bb-87a2-905f03aa539a"));
            labelTotalScoreApgar5 = (ITTLabel)AddControl(new Guid("b0d05479-f240-4e05-94dd-eac3f7067112"));
            TotalScoreApgar5 = (ITTTextBox)AddControl(new Guid("054244b8-d631-4aa2-8e3b-abe234ae251e"));
            labelStimulusResponseApgar5 = (ITTLabel)AddControl(new Guid("f872dbe5-e49f-4277-8495-ae3bbd27049a"));
            StimulusResponseApgar5 = (ITTEnumComboBox)AddControl(new Guid("c9fbcf38-ea46-42b2-96d8-39779d51707e"));
            labelSkinColorApgar5 = (ITTLabel)AddControl(new Guid("641fbeeb-345b-40d3-beae-c2c4e01e47aa"));
            SkinColorApgar5 = (ITTEnumComboBox)AddControl(new Guid("1ec0a551-654b-4f64-ac20-7265c2ef74e1"));
            labelRespirationApgar5 = (ITTLabel)AddControl(new Guid("f8be5b24-8a13-4f8b-b67c-b8625dde9abb"));
            RespirationApgar5 = (ITTEnumComboBox)AddControl(new Guid("0586e184-54ca-4cde-8348-fe301cad6cb8"));
            labelMuscularTonusApgar5 = (ITTLabel)AddControl(new Guid("89665d84-cfc2-42c1-be28-18c6e874c3f5"));
            MuscularTonusApgar5 = (ITTEnumComboBox)AddControl(new Guid("143f4d26-9eb8-46ab-9bfa-33dd90742539"));
            labelHeartRateApgar5 = (ITTLabel)AddControl(new Guid("0a6d25e5-2a81-4125-b38c-0e478111d915"));
            HeartRateApgar5 = (ITTEnumComboBox)AddControl(new Guid("2c196234-b2d0-444e-a3cc-05d564eefd13"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("9ecfb286-e953-4775-9290-35145b164ff0"));
            labelTotalScoreApgar1 = (ITTLabel)AddControl(new Guid("2908dcb8-d815-4785-9c40-cbce7d9bafe9"));
            TotalScoreApgar1 = (ITTTextBox)AddControl(new Guid("15e4b7b2-f85d-47d7-b528-f24b72dc255c"));
            labelStimulusResponseApgar1 = (ITTLabel)AddControl(new Guid("bca5c157-62a2-40e2-a9bc-f94cf9b9b586"));
            StimulusResponseApgar1 = (ITTEnumComboBox)AddControl(new Guid("314914e9-a0ce-4440-b429-8460105cb6a3"));
            labelSkinColorApgar1 = (ITTLabel)AddControl(new Guid("2095e553-23fe-4edb-8a90-e351b807c565"));
            SkinColorApgar1 = (ITTEnumComboBox)AddControl(new Guid("00eb4381-c832-4e84-b3ba-640b675d1f65"));
            labelRespirationApgar1 = (ITTLabel)AddControl(new Guid("cc33f34c-7dcb-4163-8dd7-32819b7ad3e2"));
            RespirationApgar1 = (ITTEnumComboBox)AddControl(new Guid("ad79a731-89de-4fca-81f2-abe03d7dcd3d"));
            labelMuscularTonusApgar1 = (ITTLabel)AddControl(new Guid("f018c690-9510-4a74-9aa0-4d64ddd52198"));
            MuscularTonusApgar1 = (ITTEnumComboBox)AddControl(new Guid("b8b9e5e8-fc10-4dfc-87ee-4ba885bfa9ec"));
            labelHeartRateApgar1 = (ITTLabel)AddControl(new Guid("cfc6f146-7b8a-413a-9ed2-587476da742f"));
            HeartRateApgar1 = (ITTEnumComboBox)AddControl(new Guid("cdc29bff-89e7-4165-8f70-c845f9dc5150"));
            labelGender = (ITTLabel)AddControl(new Guid("4caff170-1bf7-43c6-a330-4dfabc1357a3"));
            Gender = (ITTObjectListBox)AddControl(new Guid("bc65c9b5-9591-4a92-8765-e943f74b469d"));
            labelBirthType = (ITTLabel)AddControl(new Guid("75071505-19a3-4de3-80fc-655e09e72d74"));
            BirthType = (ITTObjectListBox)AddControl(new Guid("59e64d1c-401f-4053-a82b-760371725528"));
            labelBirthOrder = (ITTLabel)AddControl(new Guid("7daae615-79fe-4ad4-96ca-abc4f594df71"));
            BirthOrder = (ITTObjectListBox)AddControl(new Guid("cedf7a83-76a3-4ea9-892d-dffdef3c8538"));
            labelBirthLocation = (ITTLabel)AddControl(new Guid("34d4ac08-6c3a-4c8f-9368-a393eaa31933"));
            BirthLocation = (ITTObjectListBox)AddControl(new Guid("4d2670d0-7f4b-4a4c-8813-327d0db7ab59"));
            labelCauseOfDeath = (ITTLabel)AddControl(new Guid("59df3d8c-a8bc-4566-a210-54a5d64e12da"));
            CauseOfDeath = (ITTObjectListBox)AddControl(new Guid("67c745e2-12c1-48f5-9aad-338bc4e6f096"));
            FontanelExamination = (ITTCheckBox)AddControl(new Guid("a06dc8ce-d12e-4b7f-bafa-07af26b88452"));
            TesticleExamination = (ITTCheckBox)AddControl(new Guid("6bfd59c2-ef9d-45ad-8bff-6627896ee635"));
            IronSupplement = (ITTCheckBox)AddControl(new Guid("34f4f3b3-1b04-4c04-a31d-cc5d759e7f6c"));
            VitaminDSupplement = (ITTCheckBox)AddControl(new Guid("a3c6daec-89f0-492a-8139-767a98e06cf6"));
            VisionScreening = (ITTCheckBox)AddControl(new Guid("716e875e-7719-42af-b52c-8b3c470ac354"));
            HearingScreening = (ITTCheckBox)AddControl(new Guid("0c3bee4d-e9a9-4c17-99c4-20fc264215e3"));
            HypothyroidisBlood = (ITTCheckBox)AddControl(new Guid("2ccc8649-e9c4-4c4b-99d9-884a1b6cd42e"));
            Asphyxia = (ITTCheckBox)AddControl(new Guid("7eb5c093-3c36-4d6b-885e-5bd07ba8bc9b"));
            PrematureBaby = (ITTCheckBox)AddControl(new Guid("4c571631-2798-4f2e-bb65-4def1ddadbc0"));
            AbnormalBaby = (ITTCheckBox)AddControl(new Guid("22f4caa1-5117-46b4-b914-f419c1ee57f1"));
            VitaminKApplied = (ITTCheckBox)AddControl(new Guid("eb5d47f5-d5d4-488f-99b9-6ad57446529b"));
            SuckledTheFirstHalfHour = (ITTCheckBox)AddControl(new Guid("ddcc93e2-a059-46f6-8256-e10d3d411954"));
            WithoutBreastMilk = (ITTCheckBox)AddControl(new Guid("483d9e00-54fe-42b4-b596-cdd8b2dfab6f"));
            LactationInfo = (ITTCheckBox)AddControl(new Guid("f778659f-3254-43f6-91fc-75f6da5651c1"));
            HepatitisImmunoglobulin = (ITTCheckBox)AddControl(new Guid("f6e1078a-926e-4233-b6be-c8c1a8e75583"));
            HepatitisB = (ITTCheckBox)AddControl(new Guid("8a787eac-f10e-49ed-80c3-dd400d717ab8"));
            PhenylketonuriaBlood = (ITTCheckBox)AddControl(new Guid("680153f3-e5c1-4564-b736-3a2183d544dd"));
            labelWristbandNumber = (ITTLabel)AddControl(new Guid("6e640441-9978-45b3-9db2-eb2419da696c"));
            labelBabyProblems = (ITTLabel)AddControl(new Guid("10b88609-6dd0-443b-b036-a2c14c7eb30c"));
            labelHeight = (ITTLabel)AddControl(new Guid("87afb2b9-deb3-43ee-9f6b-6b2809c74993"));
            labelSurname = (ITTLabel)AddControl(new Guid("0972282e-529f-426f-88f3-c52356b1ea31"));
            labelFatherName = (ITTLabel)AddControl(new Guid("7a87fcac-0834-4bc0-83b4-c5bab41b7eef"));
            labelWeigth = (ITTLabel)AddControl(new Guid("38139df5-a2cd-4745-b733-6e041ff719d2"));
            labelPresentationType = (ITTLabel)AddControl(new Guid("f6957a96-d5ae-4198-ae87-7cf09e508cb8"));
            PresentationType = (ITTEnumComboBox)AddControl(new Guid("dc972bb7-82a6-44fc-a97f-ec59835db17f"));
            labelPregnancyWeek = (ITTLabel)AddControl(new Guid("a8e3d2d8-7a59-47b2-8a73-12f4592e9ac2"));
            labelPlacentaDecollementType = (ITTLabel)AddControl(new Guid("1cf3968d-653b-408e-94d1-456e245f162b"));
            PlacentaDecollementType = (ITTEnumComboBox)AddControl(new Guid("b7e2b511-9a0a-4c49-a2c4-a6c8b4adbce0"));
            labelHeadCircumference = (ITTLabel)AddControl(new Guid("9c5285c2-13ea-4259-b44f-b12ce7b2d780"));
            labelFetalAnomalies = (ITTLabel)AddControl(new Guid("6e28da69-af72-424f-8e25-4962f97aa699"));
            FetalAnomalies = (ITTEnumComboBox)AddControl(new Guid("77516a64-afc7-4bf7-84ec-2a48b6450882"));
            labelDatetimeOfDeath = (ITTLabel)AddControl(new Guid("4cd22bb1-fea8-43f2-8d2c-751db4e95791"));
            DatetimeOfDeath = (ITTDateTimePicker)AddControl(new Guid("a99d6ba9-f4cd-4c81-bb7e-3516d677f810"));
            labelBirthDateTime = (ITTLabel)AddControl(new Guid("b06397c8-32da-4c09-8346-7544d0a08813"));
            BirthDateTime = (ITTDateTimePicker)AddControl(new Guid("cdb8ec7c-0431-41cd-a905-c6c29a4b58cf"));
            labelBabyStatus = (ITTLabel)AddControl(new Guid("99d2cb6d-1a65-44bd-88cb-18bdab0a4e67"));
            BabyStatus = (ITTEnumComboBox)AddControl(new Guid("fb5a7f5b-39a1-48a6-b586-1fb3d6db879e"));
            labelAnesthesiaTechnique = (ITTLabel)AddControl(new Guid("12682450-6cbf-4e11-b2f4-c5998e5cadf2"));
            AnesthesiaTechnique = (ITTEnumComboBox)AddControl(new Guid("a9bb8bf7-abb2-4ffb-9987-f9d75a6373ae"));
            base.InitializeControls();
        }

        public BabyInformationForm() : base("BABYOBSTETRICINFORMATION", "BabyInformationForm")
        {
        }

        protected BabyInformationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}