
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
    public partial class BreastScreeningForm : TTForm
    {
        protected TTObjectClasses.BreastScreening _BreastScreening
        {
            get { return (TTObjectClasses.BreastScreening)_ttObject; }
        }

        protected ITTGroupBox EducationInfoGB;
        protected ITTLabel labelOccupationPatient;
        protected ITTObjectListBox OccupationPatient;
        protected ITTLabel labelEducationStatusPatient;
        protected ITTObjectListBox EducationStatusPatient;
        protected ITTLabel labelInsuranceTypePatientAdmission;
        protected ITTObjectListBox InsuranceTypePatientAdmission;
        protected ITTGroupBox ResultGB;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTCheckBox SuspiciousAnomaly;
        protected ITTCheckBox InsufficientResult;
        protected ITTCheckBox Informed;
        protected ITTCheckBox AssessmentCompleted;
        protected ITTCheckBox Malignite;
        protected ITTCheckBox BiopsySuggestion;
        protected ITTCheckBox Mammography;
        protected ITTCheckBox PossibleBening;
        protected ITTCheckBox Bening;
        protected ITTCheckBox BreastExamination;
        protected ITTGroupBox CancerInfoGB;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelLactation;
        protected ITTEnumComboBox Lactation;
        protected ITTTextBox MastectomyText;
        protected ITTLabel labelMastectomy;
        protected ITTEnumComboBox Mastectomy;
        protected ITTLabel labelPersonalBreastCA;
        protected ITTEnumComboBox PersonalBreastCA;
        protected ITTLabel labelFamilyBreastCA;
        protected ITTEnumComboBox FamilyBreastCA;
        protected ITTGroupBox AnamnesisGB;
        protected ITTLabel labelSKRSAlkolKullanimiAnamnesisInfo;
        protected ITTObjectListBox SKRSAlkolKullanimiAnamnesisInfo;
        protected ITTLabel labelSKRSMaddeKullanimiAnamnesisInfo;
        protected ITTObjectListBox SKRSMaddeKullanimiAnamnesisInfo;
        protected ITTLabel labelSKRSSigaraKullanimiAnamnesisInfo;
        protected ITTObjectListBox SKRSSigaraKullanimiAnamnesisInfo;
        protected ITTGroupBox TaramaBilgileriGB;
        protected ITTObjectListBox TTListBox;
        protected ITTLabel labelAilePlanlamasiAPYontemi;
        protected ITTObjectListBox AilePlanlamasiAPYontemi;
        protected ITTLabel labelLiveBirthNumber;
        protected ITTTextBox LiveBirthNumber;
        protected ITTLabel labelGestationalNumber;
        protected ITTTextBox GestationalNumber;
        protected ITTLabel labelFirstGestationalAge;
        protected ITTTextBox FirstGestationalAge;
        protected ITTLabel labelFirstMarriageAge;
        protected ITTTextBox FirstMarriageAge;
        protected ITTLabel labelLastMenstruationDate;
        protected ITTDateTimePicker LastMenstruationDate;
        protected ITTLabel labelMenopauseAge;
        protected ITTTextBox MenopauseAge;
        protected ITTLabel labelMenarcheAge;
        protected ITTTextBox MenarcheAge;
        protected ITTLabel labelMenstrualCycle;
        protected ITTTextBox MenstrualCycle;
        protected ITTLabel labelMaritalStatusPerson;
        override protected void InitializeControls()
        {
            EducationInfoGB = (ITTGroupBox)AddControl(new Guid("82f57b66-c747-4a0d-b72f-b3df9d60bef4"));
            labelOccupationPatient = (ITTLabel)AddControl(new Guid("0fbc66f1-79dc-40af-a999-74b10966782a"));
            OccupationPatient = (ITTObjectListBox)AddControl(new Guid("a3c667ab-bbfc-44d6-869b-0fc8b2e35442"));
            labelEducationStatusPatient = (ITTLabel)AddControl(new Guid("54e7bca1-f637-4706-8598-c8d81758b83c"));
            EducationStatusPatient = (ITTObjectListBox)AddControl(new Guid("b7880fdc-461d-40df-a30b-b1c245c8b9a8"));
            labelInsuranceTypePatientAdmission = (ITTLabel)AddControl(new Guid("ccf970cf-343a-4245-a898-fa78a30f2751"));
            InsuranceTypePatientAdmission = (ITTObjectListBox)AddControl(new Guid("f417c5cc-5af1-4104-b906-c77a94f8f1ad"));
            ResultGB = (ITTGroupBox)AddControl(new Guid("61e15ff0-8669-4a62-ac86-6afe31b07021"));
            labelDescription = (ITTLabel)AddControl(new Guid("06d34319-f15d-40b2-9c8c-98e445e8abce"));
            Description = (ITTTextBox)AddControl(new Guid("9032a961-e52d-4b4a-bdfb-7e6f9fbbf38f"));
            SuspiciousAnomaly = (ITTCheckBox)AddControl(new Guid("b4b72860-3c72-4d41-bb19-ccbde40d1481"));
            InsufficientResult = (ITTCheckBox)AddControl(new Guid("f9a3a69e-536a-450b-92f8-36bb799c946f"));
            Informed = (ITTCheckBox)AddControl(new Guid("31332fc8-6e86-4bc7-ac82-dfb127b99744"));
            AssessmentCompleted = (ITTCheckBox)AddControl(new Guid("053acb88-0151-436f-859a-55e3997288f3"));
            Malignite = (ITTCheckBox)AddControl(new Guid("355eea3e-6d88-453d-afe9-185059a4ac24"));
            BiopsySuggestion = (ITTCheckBox)AddControl(new Guid("e46eaf0c-507e-49da-83d6-a8a66183ba8c"));
            Mammography = (ITTCheckBox)AddControl(new Guid("6d6611ef-7a1e-4e95-a965-59bd1ad839e7"));
            PossibleBening = (ITTCheckBox)AddControl(new Guid("24eb228e-93eb-45fc-b8a5-db06cae4b874"));
            Bening = (ITTCheckBox)AddControl(new Guid("2e9a79af-7192-4792-92b7-90c0c9f1fc15"));
            BreastExamination = (ITTCheckBox)AddControl(new Guid("a029204f-5bc5-4592-aeaf-3cd8625edd5f"));
            CancerInfoGB = (ITTGroupBox)AddControl(new Guid("dd22fd6c-b4bc-4aa2-919f-87709e245d30"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("911bce56-297e-4405-936b-bee59f330f78"));
            labelLactation = (ITTLabel)AddControl(new Guid("65a68996-6a92-4c1b-be33-b9351b86cf93"));
            Lactation = (ITTEnumComboBox)AddControl(new Guid("1f42d29a-f6a3-403b-948c-0cb0aee51e46"));
            MastectomyText = (ITTTextBox)AddControl(new Guid("0a076fb2-fbb2-4270-8fcc-2c3aae31a175"));
            labelMastectomy = (ITTLabel)AddControl(new Guid("936551cf-c2e1-4d80-a444-b5bc10c2b8df"));
            Mastectomy = (ITTEnumComboBox)AddControl(new Guid("f788aacb-0807-4753-9492-3ca97b7bd30e"));
            labelPersonalBreastCA = (ITTLabel)AddControl(new Guid("2622c0e1-50f7-4bab-8a13-4741ee0a44a9"));
            PersonalBreastCA = (ITTEnumComboBox)AddControl(new Guid("1d557090-6d6c-4de9-992d-3a9e3bff3117"));
            labelFamilyBreastCA = (ITTLabel)AddControl(new Guid("389b99aa-7e6b-4d83-b65f-3e8541fc1e6d"));
            FamilyBreastCA = (ITTEnumComboBox)AddControl(new Guid("b94dd66b-220b-494e-9160-01c849cb1322"));
            AnamnesisGB = (ITTGroupBox)AddControl(new Guid("c2334c6d-9503-41b1-b076-4c335c215cc5"));
            labelSKRSAlkolKullanimiAnamnesisInfo = (ITTLabel)AddControl(new Guid("916981a9-f2f1-422b-a9b3-e51082e6e6ec"));
            SKRSAlkolKullanimiAnamnesisInfo = (ITTObjectListBox)AddControl(new Guid("76c80a46-7728-456f-844a-c6ffa2ae1ca3"));
            labelSKRSMaddeKullanimiAnamnesisInfo = (ITTLabel)AddControl(new Guid("568eff75-5bbf-4920-b28b-ddaeeae5a82e"));
            SKRSMaddeKullanimiAnamnesisInfo = (ITTObjectListBox)AddControl(new Guid("b4628f6b-6368-466d-b8e1-f9c2fd4fd1bb"));
            labelSKRSSigaraKullanimiAnamnesisInfo = (ITTLabel)AddControl(new Guid("9cdd4d40-42f4-44cf-a615-d66db482a83a"));
            SKRSSigaraKullanimiAnamnesisInfo = (ITTObjectListBox)AddControl(new Guid("11abac7d-1f91-4d71-88eb-fea8ee922a5c"));
            TaramaBilgileriGB = (ITTGroupBox)AddControl(new Guid("6d5eaa48-8665-4c77-8d3f-93f66db1e70a"));
            TTListBox = (ITTObjectListBox)AddControl(new Guid("8f19b8a4-0cf6-497e-b987-bf6659699552"));
            labelAilePlanlamasiAPYontemi = (ITTLabel)AddControl(new Guid("cc1dbf23-7b9b-4427-86c6-e7ab168ca904"));
            AilePlanlamasiAPYontemi = (ITTObjectListBox)AddControl(new Guid("3bb3bd60-738b-4315-9211-385725885aef"));
            labelLiveBirthNumber = (ITTLabel)AddControl(new Guid("6ff575bf-9b7c-43a2-b09b-6232da62e3fb"));
            LiveBirthNumber = (ITTTextBox)AddControl(new Guid("ac21e968-ab6d-4f9b-aaeb-082456f838e4"));
            labelGestationalNumber = (ITTLabel)AddControl(new Guid("93111c14-f021-4e4f-a8e0-9cf2ec5d23db"));
            GestationalNumber = (ITTTextBox)AddControl(new Guid("36768331-a67e-467e-ad07-53b9ef4aa5b1"));
            labelFirstGestationalAge = (ITTLabel)AddControl(new Guid("4d767afe-df70-4227-80a9-e8ef272fdefa"));
            FirstGestationalAge = (ITTTextBox)AddControl(new Guid("40b9cf41-db8e-4d7b-aa9c-ac0351edbed8"));
            labelFirstMarriageAge = (ITTLabel)AddControl(new Guid("e990f314-0479-40dc-af18-292e5cc720b8"));
            FirstMarriageAge = (ITTTextBox)AddControl(new Guid("cd86b94f-db9a-4e80-90fd-f54a99f5cd50"));
            labelLastMenstruationDate = (ITTLabel)AddControl(new Guid("b044bb51-a9d9-4de2-80b4-d4559c9c31a5"));
            LastMenstruationDate = (ITTDateTimePicker)AddControl(new Guid("4899eab8-5be5-43ca-8863-7776f48c6eea"));
            labelMenopauseAge = (ITTLabel)AddControl(new Guid("f00d86f1-97f7-441f-bf08-e40bbab4e9ec"));
            MenopauseAge = (ITTTextBox)AddControl(new Guid("10d775f5-baea-42d2-9d99-72f4af31806a"));
            labelMenarcheAge = (ITTLabel)AddControl(new Guid("1a3ff938-b10e-4352-bc3a-973369848bf3"));
            MenarcheAge = (ITTTextBox)AddControl(new Guid("44e535a5-a6a4-41ab-94fc-348f4cda9dec"));
            labelMenstrualCycle = (ITTLabel)AddControl(new Guid("dbc26b0b-0b9f-4dea-b658-e8057545a2f0"));
            MenstrualCycle = (ITTTextBox)AddControl(new Guid("b25c50e4-9fe2-46a2-a5fd-69832149d665"));
            labelMaritalStatusPerson = (ITTLabel)AddControl(new Guid("07ea91a9-07e7-42f2-ab92-8b8c84e21c83"));
            base.InitializeControls();
        }

        public BreastScreeningForm() : base("BREASTSCREENING", "BreastScreeningForm")
        {
        }

        protected BreastScreeningForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}