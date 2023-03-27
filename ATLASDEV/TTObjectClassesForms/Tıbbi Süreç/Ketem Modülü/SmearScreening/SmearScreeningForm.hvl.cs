
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
    public partial class SmearScreeningForm : TTForm
    {
        protected TTObjectClasses.SmearScreening _SmearScreening
        {
            get { return (TTObjectClasses.SmearScreening)_ttObject; }
        }

        protected ITTGroupBox SmearResultGB;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTLabel labelHPVResult;
        protected ITTEnumComboBox HPVResult;
        protected ITTLabel labelSmearResult;
        protected ITTEnumComboBox SmearResult;
        protected ITTGroupBox SmearCancerGB;
        protected ITTTextBox GynecologicCancerHistoryDesc;
        protected ITTTextBox PersonalCancerHistoryDesc;
        protected ITTTextBox FamilyCancerHistoryDesc;
        protected ITTLabel labelGynecologicCancerHistory;
        protected ITTEnumComboBox GynecologicCancerHistory;
        protected ITTLabel labelPersonalCancerHistory;
        protected ITTEnumComboBox PersonalCancerHistory;
        protected ITTLabel labelFamilyCancerHistory;
        protected ITTEnumComboBox FamilyCancerHistory;
        protected ITTGroupBox SmearAnamnezGB;
        protected ITTLabel labelSKRSAlkolKullanimiAnamnesisInfo;
        protected ITTObjectListBox SKRSAlkolKullanimiAnamnesisInfo;
        protected ITTLabel labelSKRSMaddeKullanimiAnamnesisInfo;
        protected ITTObjectListBox SKRSMaddeKullanimiAnamnesisInfo;
        protected ITTLabel labelSKRSSigaraKullanimiAnamnesisInfo;
        protected ITTObjectListBox SKRSSigaraKullanimiAnamnesisInfo;
        protected ITTGroupBox SmearEducationGB;
        protected ITTLabel labelOccupationPatient;
        protected ITTObjectListBox OccupationPatient;
        protected ITTLabel labelEducationStatusPatient;
        protected ITTObjectListBox EducationStatusPatient;
        protected ITTLabel labelInsuranceTypePatient;
        protected ITTObjectListBox InsuranceTypePatient;
        protected ITTGroupBox SmearScreeningGB;
        protected ITTObjectListBox SKRSMaritalStatus;
        protected ITTLabel labelAilePlanlamasiAPYontemi;
        protected ITTObjectListBox AilePlanlamasiAPYontemi;
        protected ITTLabel labelMenstrualCycle;
        protected ITTTextBox MenstrualCycle;
        protected ITTLabel labelMenopauseAge;
        protected ITTTextBox MenopauseAge;
        protected ITTLabel labelMenarcheAge;
        protected ITTTextBox MenarcheAge;
        protected ITTLabel labelLiveBirthNumber;
        protected ITTTextBox LiveBirthNumber;
        protected ITTLabel labelLastMenstruationDate;
        protected ITTDateTimePicker LastMenstruationDate;
        protected ITTLabel labelGestationalNumber;
        protected ITTTextBox GestationalNumber;
        protected ITTLabel labelFirstMarriageAge;
        protected ITTTextBox FirstMarriageAge;
        protected ITTLabel labelFirstGestationalAge;
        protected ITTTextBox FirstGestationalAge;
        protected ITTLabel labelMaritalStatusPerson;
        protected ITTTextBox PainDuringIntercourseText;
        protected ITTLabel labelBleedingAfterIntercourse;
        protected ITTEnumComboBox BleedingAfterIntercourse;
        protected ITTLabel labelPainDuringIntercourse;
        protected ITTEnumComboBox PainDuringIntercourse;
        override protected void InitializeControls()
        {
            SmearResultGB = (ITTGroupBox)AddControl(new Guid("d5b939ba-5f75-452c-beba-896ab0b612c0"));
            labelDescription = (ITTLabel)AddControl(new Guid("95863084-0763-4560-8bbc-7d31f63c4c97"));
            Description = (ITTTextBox)AddControl(new Guid("79531bef-846e-4d6c-b05a-4978fb2cb7ce"));
            labelHPVResult = (ITTLabel)AddControl(new Guid("f671f55c-e807-4ede-a047-188d1b39a25d"));
            HPVResult = (ITTEnumComboBox)AddControl(new Guid("e4a0bfcb-3324-40ba-9474-e66cb3e6b3b5"));
            labelSmearResult = (ITTLabel)AddControl(new Guid("f2c7318e-b175-4fbb-bfa5-3139dc27a940"));
            SmearResult = (ITTEnumComboBox)AddControl(new Guid("ab5cb4eb-56ad-4c25-b9c7-b6d60484dca8"));
            SmearCancerGB = (ITTGroupBox)AddControl(new Guid("129e50c8-d218-44b9-86be-3cbe41788186"));
            GynecologicCancerHistoryDesc = (ITTTextBox)AddControl(new Guid("e5dee110-d09c-4ab9-bb09-f5ad6be6436c"));
            PersonalCancerHistoryDesc = (ITTTextBox)AddControl(new Guid("a03460b3-714d-4ce7-968f-8fae25b0ba82"));
            FamilyCancerHistoryDesc = (ITTTextBox)AddControl(new Guid("2202c46c-fe45-485b-996b-b59326701706"));
            labelGynecologicCancerHistory = (ITTLabel)AddControl(new Guid("590c2a4b-7eeb-42c4-8974-340e113170b0"));
            GynecologicCancerHistory = (ITTEnumComboBox)AddControl(new Guid("98cb8f26-87b6-40df-a6d3-3eca62a52e2f"));
            labelPersonalCancerHistory = (ITTLabel)AddControl(new Guid("018f6eff-7a17-4901-843b-b8722dc4ea9f"));
            PersonalCancerHistory = (ITTEnumComboBox)AddControl(new Guid("d1d93491-cbb4-4001-9a4e-c07be4078104"));
            labelFamilyCancerHistory = (ITTLabel)AddControl(new Guid("a9d79f33-8446-4a09-984e-e8846b250306"));
            FamilyCancerHistory = (ITTEnumComboBox)AddControl(new Guid("a595b9f5-cffc-4ae0-b78f-0efe2f33896a"));
            SmearAnamnezGB = (ITTGroupBox)AddControl(new Guid("17790070-3676-4612-9445-1f3182d6f189"));
            labelSKRSAlkolKullanimiAnamnesisInfo = (ITTLabel)AddControl(new Guid("abfa46ad-1384-4e4f-a6b9-d426706fe415"));
            SKRSAlkolKullanimiAnamnesisInfo = (ITTObjectListBox)AddControl(new Guid("0fbb5f72-90ea-4441-8faa-baf2d306de6d"));
            labelSKRSMaddeKullanimiAnamnesisInfo = (ITTLabel)AddControl(new Guid("67f85de9-1052-4d41-ab09-753c2e983d68"));
            SKRSMaddeKullanimiAnamnesisInfo = (ITTObjectListBox)AddControl(new Guid("c65897b7-ea0b-4a46-9d85-645c2f1f16a8"));
            labelSKRSSigaraKullanimiAnamnesisInfo = (ITTLabel)AddControl(new Guid("d6a64c41-4665-4b1e-ab0b-7df274102a8e"));
            SKRSSigaraKullanimiAnamnesisInfo = (ITTObjectListBox)AddControl(new Guid("cae04a24-d7f9-41e2-becc-a6b5d8c12e48"));
            SmearEducationGB = (ITTGroupBox)AddControl(new Guid("1e274932-8e7d-4bd9-a2a3-7a593ad3f775"));
            labelOccupationPatient = (ITTLabel)AddControl(new Guid("0b220288-e909-411e-a1ad-6748e698e201"));
            OccupationPatient = (ITTObjectListBox)AddControl(new Guid("7a7994e9-e2b3-4126-8b35-9cc0c6e9524e"));
            labelEducationStatusPatient = (ITTLabel)AddControl(new Guid("31e4ffe9-08f8-477c-a5e7-a00178085cf6"));
            EducationStatusPatient = (ITTObjectListBox)AddControl(new Guid("8fbf4c79-afba-471b-b6ab-5a56324c4db3"));
            labelInsuranceTypePatient = (ITTLabel)AddControl(new Guid("758d394b-433e-420e-b247-93d0f0e539a3"));
            InsuranceTypePatient = (ITTObjectListBox)AddControl(new Guid("9d77d2e8-2c02-4d28-af55-2e2f871807e8"));
            SmearScreeningGB = (ITTGroupBox)AddControl(new Guid("2e4f7e9a-3cd5-4295-9c81-755bc404dc54"));
            SKRSMaritalStatus = (ITTObjectListBox)AddControl(new Guid("88b076e8-91bc-48e6-b9c7-a63d07ad3f1b"));
            labelAilePlanlamasiAPYontemi = (ITTLabel)AddControl(new Guid("3a21d38a-2306-4699-866e-c3b2b0293496"));
            AilePlanlamasiAPYontemi = (ITTObjectListBox)AddControl(new Guid("0f0908ab-5e23-4a9d-85d0-848a40684e19"));
            labelMenstrualCycle = (ITTLabel)AddControl(new Guid("b03d2763-5ac6-4812-b378-2348a1e53d43"));
            MenstrualCycle = (ITTTextBox)AddControl(new Guid("dfe9e934-b22a-4289-9f2e-26f33f2942d8"));
            labelMenopauseAge = (ITTLabel)AddControl(new Guid("10579c75-f576-413c-8dd9-7c674d374538"));
            MenopauseAge = (ITTTextBox)AddControl(new Guid("e83286fd-1f17-4d21-a844-0e08f0806468"));
            labelMenarcheAge = (ITTLabel)AddControl(new Guid("8c86fe26-efe1-4ef7-ad98-44bf8d152f2f"));
            MenarcheAge = (ITTTextBox)AddControl(new Guid("3f77879a-4a64-415a-a29a-44dd2d0d23a9"));
            labelLiveBirthNumber = (ITTLabel)AddControl(new Guid("40c16e5a-59ee-4a67-a36c-21b897031458"));
            LiveBirthNumber = (ITTTextBox)AddControl(new Guid("4533cf82-d2dd-49b9-a0ae-a1195eaeb14a"));
            labelLastMenstruationDate = (ITTLabel)AddControl(new Guid("924b12d5-903b-46f8-9d12-aa5c7fef379d"));
            LastMenstruationDate = (ITTDateTimePicker)AddControl(new Guid("0207b59b-8e77-4b9f-9bca-2986c7847dd9"));
            labelGestationalNumber = (ITTLabel)AddControl(new Guid("b670ec47-fe51-46eb-9789-3e05f0ef2098"));
            GestationalNumber = (ITTTextBox)AddControl(new Guid("74310165-b1a3-4de0-b313-58dff622ea77"));
            labelFirstMarriageAge = (ITTLabel)AddControl(new Guid("532c714f-c656-463a-98b8-0d44b4af1b83"));
            FirstMarriageAge = (ITTTextBox)AddControl(new Guid("5c8fd1e6-777a-4704-ae3d-21f0a846233a"));
            labelFirstGestationalAge = (ITTLabel)AddControl(new Guid("2298aa78-9615-463d-89bf-d2a48f0aed22"));
            FirstGestationalAge = (ITTTextBox)AddControl(new Guid("7cb6f624-fded-49bd-bcc0-e5342ecd9711"));
            labelMaritalStatusPerson = (ITTLabel)AddControl(new Guid("7802be97-84be-4bed-983d-174caf35ef20"));
            PainDuringIntercourseText = (ITTTextBox)AddControl(new Guid("61ca36ea-494c-4cda-96e0-9fae95f2602a"));
            labelBleedingAfterIntercourse = (ITTLabel)AddControl(new Guid("fc61ddd6-382f-4664-845b-b5333eed3027"));
            BleedingAfterIntercourse = (ITTEnumComboBox)AddControl(new Guid("4560b387-bcdd-4dcf-96fd-c711af1c972b"));
            labelPainDuringIntercourse = (ITTLabel)AddControl(new Guid("6d6806ca-d17e-40cf-af73-2419ca03aab3"));
            PainDuringIntercourse = (ITTEnumComboBox)AddControl(new Guid("2f571f18-c3b6-43d2-b007-c5d7e3092fcd"));
            base.InitializeControls();
        }

        public SmearScreeningForm() : base("SMEARSCREENING", "SmearScreeningForm")
        {
        }

        protected SmearScreeningForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}