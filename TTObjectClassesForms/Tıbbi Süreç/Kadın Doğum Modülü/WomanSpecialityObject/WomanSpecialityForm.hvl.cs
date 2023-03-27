
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
    public partial class WomanSpecialityForm : SpecialityBasedObjectForm
    {
        protected TTObjectClasses.WomanSpecialityObject _WomanSpecialityObject
        {
            get { return (TTObjectClasses.WomanSpecialityObject)_ttObject; }
        }

        protected ITTLabel labelWomanBloodGroup;
        protected ITTEnumComboBox WomanBloodGroup;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tabGynecology;
        protected ITTLabel labelReproductiveAbnormalityGynecology;
        protected ITTObjectListBox ReproductiveAbnormalityGynecology;
        protected ITTLabel labelVulvaVagenGynecology;
        protected ITTTextBox VulvaVagenGynecology;
        protected ITTLabel labelVaginalDischargeInformationGynecology;
        protected ITTTextBox VaginalDischargeInformationGynecology;
        protected ITTCheckBox VaginalDischargeGynecology;
        protected ITTLabel labelUterusGynecology;
        protected ITTTextBox UterusGynecology;
        protected ITTLabel labelTumorMarkersGynecology;
        protected ITTTextBox TumorMarkersGynecology;
        protected ITTLabel labelReproductiveAbnormalitiesInfoGynecology;
        protected ITTTextBox ReproductiveAbnormalitiesInfoGynecology;
        protected ITTLabel labelPreviousBirthControlMethodGynecology;
        protected ITTEnumComboBox PreviousBirthControlMethodGynecology;
        protected ITTLabel labelPelvicExaminationGynecology;
        protected ITTTextBox PelvicExaminationGynecology;
        protected ITTLabel labelMenstrualCycleInformationGynecology;
        protected ITTTextBox MenstrualCycleInformationGynecology;
        protected ITTLabel labelMenstrualCycleAbnormalitiesGynecology;
        protected ITTEnumComboBox MenstrualCycleAbnormalitiesGynecology;
        protected ITTLabel labelLastSmearDateGynecology;
        protected ITTDateTimePicker LastSmearDateGynecology;
        protected ITTLabel labelLastExaminationDateGynecology;
        protected ITTDateTimePicker LastExaminationDateGynecology;
        protected ITTLabel labelHirsutismInformationGynecology;
        protected ITTTextBox HirsutismInformationGynecology;
        protected ITTCheckBox HirsutismGynecology;
        protected ITTLabel labelGynecologicalHistoryGynecology;
        protected ITTTextBox GynecologicalHistoryGynecology;
        protected ITTLabel labelGenitalExaminationGynecology;
        protected ITTTextBox GenitalExaminationGynecology;
        protected ITTLabel labelGenitalAbnormalitiesInfoGynecology;
        protected ITTTextBox GenitalAbnormalitiesInfoGynecology;
        protected ITTLabel labelGenitalAbnormalitiesGynecology;
        protected ITTEnumComboBox GenitalAbnormalitiesGynecology;
        protected ITTLabel labelDysuriaInformationGynecology;
        protected ITTTextBox DysuriaInformationGynecology;
        protected ITTCheckBox DysuriaGynecology;
        protected ITTLabel labelDyspareuniaInformationGynecology;
        protected ITTTextBox DyspareuniaInformationGynecology;
        protected ITTCheckBox DyspareuniaGynecology;
        protected ITTLabel labelCurrentBirthControlMethodGynecology;
        protected ITTEnumComboBox CurrentBirthControlMethodGynecology;
        protected ITTLabel labelCervixGynecology;
        protected ITTTextBox CervixGynecology;
        protected ITTLabel labelBasalUltrasoundGynecology;
        protected ITTTextBox BasalUltrasoundGynecology;
        protected ITTTabPage tabInfertility;
        protected ITTTabPage tabPregnancy;
        protected ITTTabPage tabPregCalendar;
        protected ITTGrid gridPregnancyCalendar;
        protected ITTTextBox Parity;
        protected ITTTextBox NumberOfPregnancy;
        protected ITTTextBox LivingBabies;
        protected ITTTextBox HusbandFullName;
        protected ITTTextBox DC;
        protected ITTTextBox Abortion;
        protected ITTTextBox MarriageDuration;
        protected ITTButton ttbutton1;
        protected ITTMaskedTextBox MarriageDate;
        protected ITTLabel labelMarriageDate;
        protected ITTButton btnPregnancyStart;
        protected ITTLabel labelMarriageDuration;
        protected ITTLabel labelRhIncompatibility;
        protected ITTEnumComboBox RhIncompatibility;
        protected ITTLabel labelParity;
        protected ITTLabel labelNumberOfPregnancy;
        protected ITTLabel labelLivingBabies;
        protected ITTLabel labelHusbandFullName;
        protected ITTLabel labelHusbandBloodGroup;
        protected ITTEnumComboBox HusbandBloodGroup;
        protected ITTLabel labelDegreeOfRelationship;
        protected ITTEnumComboBox DegreeOfRelationship;
        protected ITTLabel labelDC;
        protected ITTLabel labelAbortion;
        override protected void InitializeControls()
        {
            labelWomanBloodGroup = (ITTLabel)AddControl(new Guid("fcf527f6-567e-4c5c-9371-ebb68a01476d"));
            WomanBloodGroup = (ITTEnumComboBox)AddControl(new Guid("93ad9335-d629-4a89-9a21-a24b121d591f"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("86f3c7d5-54c6-4dcc-9345-8b1d866918dd"));
            tabGynecology = (ITTTabPage)AddControl(new Guid("6fe3c163-8849-4810-b703-513fcfc2b200"));
            labelReproductiveAbnormalityGynecology = (ITTLabel)AddControl(new Guid("095257df-f09d-41c3-9d68-118df3bc20fb"));
            ReproductiveAbnormalityGynecology = (ITTObjectListBox)AddControl(new Guid("9488e94b-9aa3-4e5d-aef1-41b75539d021"));
            labelVulvaVagenGynecology = (ITTLabel)AddControl(new Guid("993c9434-96c6-441b-be67-40d2c5e38df5"));
            VulvaVagenGynecology = (ITTTextBox)AddControl(new Guid("3ed92bd5-5e5f-4e5b-b15a-0e6cddaef9ec"));
            labelVaginalDischargeInformationGynecology = (ITTLabel)AddControl(new Guid("9ed15675-ad98-411c-9369-32f90d7194c9"));
            VaginalDischargeInformationGynecology = (ITTTextBox)AddControl(new Guid("8ae2fbcb-0889-443f-9d6a-a15362f8604f"));
            VaginalDischargeGynecology = (ITTCheckBox)AddControl(new Guid("33cf6a8e-25e5-41a5-a9c7-bb37b01f9bd8"));
            labelUterusGynecology = (ITTLabel)AddControl(new Guid("66121660-cfae-47c8-83cf-e5954fb3a602"));
            UterusGynecology = (ITTTextBox)AddControl(new Guid("fb131fe1-ba74-4cc0-92d6-d4eb6e55cf3f"));
            labelTumorMarkersGynecology = (ITTLabel)AddControl(new Guid("e2b23a34-52a3-4dea-b67b-46b8f289a4bf"));
            TumorMarkersGynecology = (ITTTextBox)AddControl(new Guid("7183adb3-6673-49f5-bd23-94b34a6a652c"));
            labelReproductiveAbnormalitiesInfoGynecology = (ITTLabel)AddControl(new Guid("f896404d-605e-4ad9-9cb1-dabd17e4d38f"));
            ReproductiveAbnormalitiesInfoGynecology = (ITTTextBox)AddControl(new Guid("f47ccb6c-761a-4446-b50a-c0c117efe58e"));
            labelPreviousBirthControlMethodGynecology = (ITTLabel)AddControl(new Guid("6b48533c-daee-4b3a-9d13-3a769d4966e0"));
            PreviousBirthControlMethodGynecology = (ITTEnumComboBox)AddControl(new Guid("b4a580b3-9112-4291-a510-26c3695e29d4"));
            labelPelvicExaminationGynecology = (ITTLabel)AddControl(new Guid("55301b8f-8f69-4103-9dcc-196324d5a623"));
            PelvicExaminationGynecology = (ITTTextBox)AddControl(new Guid("9102c465-a1ff-4c96-9bf3-b6a68e1c9ea5"));
            labelMenstrualCycleInformationGynecology = (ITTLabel)AddControl(new Guid("bcd4309b-5a7b-4813-97ea-8a8e29116b32"));
            MenstrualCycleInformationGynecology = (ITTTextBox)AddControl(new Guid("17a7a8a5-5482-4cc5-b6da-cac356f7c4f7"));
            labelMenstrualCycleAbnormalitiesGynecology = (ITTLabel)AddControl(new Guid("db7fbe74-0bbe-4da0-bae6-5a9f116757f7"));
            MenstrualCycleAbnormalitiesGynecology = (ITTEnumComboBox)AddControl(new Guid("275bfa35-07e3-41ff-a12c-0a6c861fe66c"));
            labelLastSmearDateGynecology = (ITTLabel)AddControl(new Guid("e11853b6-5f60-4421-9e52-ab255139585b"));
            LastSmearDateGynecology = (ITTDateTimePicker)AddControl(new Guid("b63d8710-18fe-4dd7-b84f-8929209cb894"));
            labelLastExaminationDateGynecology = (ITTLabel)AddControl(new Guid("999634c5-b70c-4901-b8eb-3640aed7c7b2"));
            LastExaminationDateGynecology = (ITTDateTimePicker)AddControl(new Guid("92ef8f29-3f46-490d-aa3f-ae2a0eba905e"));
            labelHirsutismInformationGynecology = (ITTLabel)AddControl(new Guid("85992b04-2648-40a2-a7d4-81c017fad431"));
            HirsutismInformationGynecology = (ITTTextBox)AddControl(new Guid("35fd6dea-550f-4778-b032-5050a37b918c"));
            HirsutismGynecology = (ITTCheckBox)AddControl(new Guid("23c8bd93-643f-44d9-9b88-413bf21362ac"));
            labelGynecologicalHistoryGynecology = (ITTLabel)AddControl(new Guid("376516a6-3d58-4ca0-a2ce-27fcdbb4cba7"));
            GynecologicalHistoryGynecology = (ITTTextBox)AddControl(new Guid("52fa7143-7a11-4928-8d0b-f0956ed1cdd6"));
            labelGenitalExaminationGynecology = (ITTLabel)AddControl(new Guid("3fac48e3-08e4-4d9b-b257-f2bc7f7f8820"));
            GenitalExaminationGynecology = (ITTTextBox)AddControl(new Guid("f09b1359-b01e-457a-b58e-332cdda9ec48"));
            labelGenitalAbnormalitiesInfoGynecology = (ITTLabel)AddControl(new Guid("6d4fd59e-19c8-472b-acbf-171c2c5255e8"));
            GenitalAbnormalitiesInfoGynecology = (ITTTextBox)AddControl(new Guid("5dbde219-9cd5-4477-9d01-0c57c6165d67"));
            labelGenitalAbnormalitiesGynecology = (ITTLabel)AddControl(new Guid("eb0fe6c9-ddb0-49c5-bb4b-949463582034"));
            GenitalAbnormalitiesGynecology = (ITTEnumComboBox)AddControl(new Guid("59d07b8b-e68b-40af-98ce-e01535eba3c1"));
            labelDysuriaInformationGynecology = (ITTLabel)AddControl(new Guid("2abac036-a7d7-4460-ba62-bb8d5667469b"));
            DysuriaInformationGynecology = (ITTTextBox)AddControl(new Guid("00aa7cd3-06ea-44a3-9087-95bd37b171fa"));
            DysuriaGynecology = (ITTCheckBox)AddControl(new Guid("1f75c414-942b-428d-b3a9-a3ae8dc9e622"));
            labelDyspareuniaInformationGynecology = (ITTLabel)AddControl(new Guid("13bfacdf-38fb-4fe8-b2cb-5acbc60c276d"));
            DyspareuniaInformationGynecology = (ITTTextBox)AddControl(new Guid("8918ffa9-0395-4da5-bf4e-b3e64cba70db"));
            DyspareuniaGynecology = (ITTCheckBox)AddControl(new Guid("c6755949-8966-4db3-9672-3bc16091a79f"));
            labelCurrentBirthControlMethodGynecology = (ITTLabel)AddControl(new Guid("f63c9442-104e-41f2-88e8-a49edf8a04d2"));
            CurrentBirthControlMethodGynecology = (ITTEnumComboBox)AddControl(new Guid("5bbb1a4c-f6f7-427a-9101-df8e4ddc65a2"));
            labelCervixGynecology = (ITTLabel)AddControl(new Guid("647856d4-8ae8-48c7-839e-713aebcc47ab"));
            CervixGynecology = (ITTTextBox)AddControl(new Guid("b6d6892d-fb68-411f-b4f6-caa4a798da9f"));
            labelBasalUltrasoundGynecology = (ITTLabel)AddControl(new Guid("41ae9e58-022f-46d3-a8e6-f9f046fd95d6"));
            BasalUltrasoundGynecology = (ITTTextBox)AddControl(new Guid("f8088005-a7a6-4aeb-a31e-9488863cbd6e"));
            tabInfertility = (ITTTabPage)AddControl(new Guid("4ad630e2-8822-4dad-be15-99cf96222f99"));
            tabPregnancy = (ITTTabPage)AddControl(new Guid("05900583-c19f-4aa0-900a-41ed207a201e"));
            tabPregCalendar = (ITTTabPage)AddControl(new Guid("cba136ab-3335-438f-8f22-0513485f45bc"));
            gridPregnancyCalendar = (ITTGrid)AddControl(new Guid("cfb60a44-bdda-481e-ad39-e39cec0730a7"));
            Parity = (ITTTextBox)AddControl(new Guid("179458f9-103d-4c6a-8fac-3e35f4d48716"));
            NumberOfPregnancy = (ITTTextBox)AddControl(new Guid("caff71f9-db9f-44f5-bd07-a353bd64fa6c"));
            LivingBabies = (ITTTextBox)AddControl(new Guid("3e0f8f9c-874d-4b6d-bac9-9d3f363de62b"));
            HusbandFullName = (ITTTextBox)AddControl(new Guid("2fd3ed9d-9fbe-4b76-ad0d-0ef893b8a9ed"));
            DC = (ITTTextBox)AddControl(new Guid("74ebcd8b-9dbb-4f7d-b3b8-001ea69296d0"));
            Abortion = (ITTTextBox)AddControl(new Guid("822454d8-e47f-4631-a4ff-30a7ef1c858a"));
            MarriageDuration = (ITTTextBox)AddControl(new Guid("f635f5c4-9927-4d3a-b375-4bf5a4b895b6"));
            ttbutton1 = (ITTButton)AddControl(new Guid("94c33cfc-fc8f-45f8-b935-dcfc862f4506"));
            MarriageDate = (ITTMaskedTextBox)AddControl(new Guid("05839ddf-a9b0-4351-a937-456ce549228c"));
            labelMarriageDate = (ITTLabel)AddControl(new Guid("f68d9b12-00c3-414f-88e0-22dfb3330b50"));
            btnPregnancyStart = (ITTButton)AddControl(new Guid("1470fda3-226c-4597-ac1a-5c1d7550188b"));
            labelMarriageDuration = (ITTLabel)AddControl(new Guid("0f35cfa6-adf7-43e4-9d53-dc61ba25b927"));
            labelRhIncompatibility = (ITTLabel)AddControl(new Guid("617a34e4-a26c-4dc6-a612-20c3abdc68b6"));
            RhIncompatibility = (ITTEnumComboBox)AddControl(new Guid("d569c841-8df8-4a4a-95ad-f22fbc1049b3"));
            labelParity = (ITTLabel)AddControl(new Guid("0f29aec0-126a-47e3-aa32-1eeba2e47b06"));
            labelNumberOfPregnancy = (ITTLabel)AddControl(new Guid("f3cab7c0-e7e6-4643-ac72-58ba1672acc3"));
            labelLivingBabies = (ITTLabel)AddControl(new Guid("fcf772ae-a1ff-4ce5-a7f8-e04190456a92"));
            labelHusbandFullName = (ITTLabel)AddControl(new Guid("2cd759a3-e366-4f0c-bfb0-dc97c07474ea"));
            labelHusbandBloodGroup = (ITTLabel)AddControl(new Guid("1ea85161-e97b-4fd3-8d23-34f1ef98b6dc"));
            HusbandBloodGroup = (ITTEnumComboBox)AddControl(new Guid("d09b7c4d-afac-4ff9-b3bd-5b86e230b2c2"));
            labelDegreeOfRelationship = (ITTLabel)AddControl(new Guid("83d0a1b7-c802-48ed-9602-23ae9a551661"));
            DegreeOfRelationship = (ITTEnumComboBox)AddControl(new Guid("f8814b0c-1649-48ef-ac20-051204f5e1ff"));
            labelDC = (ITTLabel)AddControl(new Guid("1be1cd34-3f51-45ab-ad2a-f7eb3c2767cd"));
            labelAbortion = (ITTLabel)AddControl(new Guid("73e714f7-0276-4dca-bdb2-493cb534cfd8"));
            base.InitializeControls();
        }

        public WomanSpecialityForm() : base("WOMANSPECIALITYOBJECT", "WomanSpecialityForm")
        {
        }

        protected WomanSpecialityForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}