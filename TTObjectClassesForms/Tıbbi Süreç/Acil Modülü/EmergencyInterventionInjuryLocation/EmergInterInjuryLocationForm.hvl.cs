
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
    public partial class EmergInterInjuryLocationForm : EpisodeActionForm
    {
    /// <summary>
    /// Acil Hasta Yaralanma Tespit Formu
    /// </summary>
        protected TTObjectClasses.EmergencyInterventionInjuryLocation _EmergencyInterventionInjuryLocation
        {
            get { return (TTObjectClasses.EmergencyInterventionInjuryLocation)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tabYaralanmaTespitBilgileri;
        protected ITTRichTextBoxControl SurgicalInterventions;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelRankEpisode;
        protected ITTObjectListBox RankEpisode;
        protected ITTObjectListBox PayerEpisode;
        protected ITTLabel labelMilitaryUnitEpisode;
        protected ITTObjectListBox MilitaryUnitEpisode;
        protected ITTLabel labelUniqueRefNoPerson;
        protected ITTTextBox UniqueRefNoPerson;
        protected ITTLabel labelSurnamePerson;
        protected ITTTextBox SurnamePerson;
        protected ITTLabel labelNamePerson;
        protected ITTTextBox NamePerson;
        protected ITTLabel labelBirthDatePerson;
        protected ITTDateTimePicker BirthDatePerson;
        protected ITTLabel ttlabel17;
        protected ITTLabel ttlabel16;
        protected ITTLabel ttlabel15;
        protected ITTLabel ttlabel14;
        protected ITTLabel labelHowOldSoldier;
        protected ITTTextBox HowOldSoldier;
        protected ITTLabel labelHowManyDaysInOperation;
        protected ITTTextBox HowManyDaysInOperation;
        protected ITTCheckBox WearingProtectiveHeadgear;
        protected ITTCheckBox WearingProtectiveCloting;
        protected ITTCheckBox WearingGoggles;
        protected ITTCheckBox TypeOfInjuryOTHER;
        protected ITTCheckBox TypeOfInjuryEYP;
        protected ITTCheckBox TypeOfInjuryASY;
        protected ITTCheckBox TourniqueUsedLeg;
        protected ITTCheckBox TourniqueUsedArm;
        protected ITTLabel labelSurgicalInterventions;
        protected ITTLabel labelIsUsedTourniquet;
        protected ITTEnumComboBox IsUsedTourniquet;
        protected ITTLabel labelIsThereBloodReplacement;
        protected ITTEnumComboBox IsThereBloodReplacement;
        protected ITTLabel labelInjuryDate;
        protected ITTDateTimePicker InjuryDate;
        protected ITTLabel labelHowWasInjury;
        protected ITTTextBox HowWasInjury;
        protected ITTLabel labelGlaskowKomaSkoru;
        protected ITTTextBox GlaskowKomaSkoru;
        protected ITTCheckBox FirstRespondersWhoParamedic;
        protected ITTCheckBox FirstRespondersWhoHimself;
        protected ITTCheckBox FirstRespondersWhoFriend;
        protected ITTCheckBox FirstRespondersWhoDoctor;
        protected ITTLabel labelFirstAidDate;
        protected ITTDateTimePicker FirstAidDate;
        protected ITTLabel labelEvacuationTime;
        protected ITTTextBox EvacuationTime;
        protected ITTLabel labelConditionOfInjured;
        protected ITTEnumComboBox ConditionOfInjured;
        protected ITTLabel labelCityOfInjured;
        protected ITTTextBox CityOfInjured;
        protected ITTLabel labelAmountOfBloodReplacement;
        protected ITTTextBox AmountOfBloodReplacement;
        protected ITTTabPage tabYaralanmaBolgesi;
        protected ITTLabel ttlabel2;
        protected ITTPictureBoxControl ImageBox;
        protected ITTGrid InjuryLocationGrid;
        protected ITTEnumComboBoxColumn InjuryDirectionOfLocationEmergencyInterventionInjuryLocationGrid;
        protected ITTEnumComboBoxColumn InjuryLocationEmergencyInterventionInjuryLocationGrid;
        protected ITTTextBoxColumn TypeOfInjuryEmergencyInterventionInjuryLocationGrid;
        protected ITTTextBoxColumn InEmergencyInterventionInjuryLocationGrid;
        protected ITTTextBoxColumn OutEmergencyInterventionInjuryLocationGrid;
        protected ITTRichTextBoxControlColumn DescriptionEmergencyInterventionInjuryLocationGrid;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("2e40afe6-6d0c-4fd5-90b5-e2c8fd96c962"));
            tabYaralanmaTespitBilgileri = (ITTTabPage)AddControl(new Guid("01fbc783-1aa0-4421-92f4-df98a2e7b7e5"));
            SurgicalInterventions = (ITTRichTextBoxControl)AddControl(new Guid("566fba02-5bcc-47b5-81bb-bd216299ee2b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("9f8982b5-4ff8-4682-9c49-e96cbb41be76"));
            labelRankEpisode = (ITTLabel)AddControl(new Guid("ecdc35ff-14a4-415e-b640-f131e8614ab9"));
            RankEpisode = (ITTObjectListBox)AddControl(new Guid("6f4eeff9-9aec-4238-aea1-d7af24000b63"));
            PayerEpisode = (ITTObjectListBox)AddControl(new Guid("e7e7af67-59af-486c-b25c-306e496244f8"));
            labelMilitaryUnitEpisode = (ITTLabel)AddControl(new Guid("aa2fd330-a4bf-4974-8074-75095ce9649b"));
            MilitaryUnitEpisode = (ITTObjectListBox)AddControl(new Guid("7a0bd3d2-2651-4b47-be73-da99d21e5dc7"));
            labelUniqueRefNoPerson = (ITTLabel)AddControl(new Guid("789dfeb1-d93f-4490-b3e9-bbba5688e078"));
            UniqueRefNoPerson = (ITTTextBox)AddControl(new Guid("1d921392-88d3-4079-8557-ea8e5a6a38c2"));
            labelSurnamePerson = (ITTLabel)AddControl(new Guid("ec508b82-5e38-48c7-a144-012eeb4a0d19"));
            SurnamePerson = (ITTTextBox)AddControl(new Guid("18f7eca9-bd2f-4b64-8b08-1fe7685e2ad4"));
            labelNamePerson = (ITTLabel)AddControl(new Guid("e9c03bdb-fa17-41d9-8a24-5031756a6cc4"));
            NamePerson = (ITTTextBox)AddControl(new Guid("3dbd2a5e-1102-4e91-a556-aafba48d7716"));
            labelBirthDatePerson = (ITTLabel)AddControl(new Guid("b78f2022-233f-4cb5-8e90-603b367bf164"));
            BirthDatePerson = (ITTDateTimePicker)AddControl(new Guid("362519c1-4a70-445e-8538-a8623558c2ec"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("79de84fb-28f7-4de8-9573-fd6e4ea5066b"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("6cd5ae17-0b6e-4639-9f57-3580152aa88c"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("14d1066d-ab34-4161-aea3-d2bfba1e33a1"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("591b4bd0-0d54-4082-9197-1ef2901d7cb8"));
            labelHowOldSoldier = (ITTLabel)AddControl(new Guid("970b3d51-c3b1-4876-9ac1-5230eab7d4fd"));
            HowOldSoldier = (ITTTextBox)AddControl(new Guid("887a48b3-9bf4-4fad-9a0b-0fe09b117282"));
            labelHowManyDaysInOperation = (ITTLabel)AddControl(new Guid("93879020-03c4-405f-993d-5e88a7118a3e"));
            HowManyDaysInOperation = (ITTTextBox)AddControl(new Guid("f63e6d10-b377-44f2-a40d-fd299245c921"));
            WearingProtectiveHeadgear = (ITTCheckBox)AddControl(new Guid("b1f6b1ac-b428-419a-846f-907dfbd10bd6"));
            WearingProtectiveCloting = (ITTCheckBox)AddControl(new Guid("b32700d2-3c2b-4a7a-898f-425d3a27a441"));
            WearingGoggles = (ITTCheckBox)AddControl(new Guid("2a0d2749-d9d5-4d93-b1af-397d29e778a6"));
            TypeOfInjuryOTHER = (ITTCheckBox)AddControl(new Guid("4e3fb61e-e01d-46f6-88a0-106da9764b6d"));
            TypeOfInjuryEYP = (ITTCheckBox)AddControl(new Guid("8b2f197d-971d-405f-8e6b-24cb7c748b82"));
            TypeOfInjuryASY = (ITTCheckBox)AddControl(new Guid("c6079fbc-6e9f-47ac-b8af-79a45e59d15f"));
            TourniqueUsedLeg = (ITTCheckBox)AddControl(new Guid("9428412f-65d6-4b43-af69-c2140fdd1ded"));
            TourniqueUsedArm = (ITTCheckBox)AddControl(new Guid("f1021775-5845-4908-86e8-267f6dace82f"));
            labelSurgicalInterventions = (ITTLabel)AddControl(new Guid("423eddbe-a681-4002-9178-d18c3eb56d49"));
            labelIsUsedTourniquet = (ITTLabel)AddControl(new Guid("3114cb56-e217-463a-ab6b-40f373787454"));
            IsUsedTourniquet = (ITTEnumComboBox)AddControl(new Guid("9ca1c586-ec51-470a-b699-82ed58a22a43"));
            labelIsThereBloodReplacement = (ITTLabel)AddControl(new Guid("58167e7e-f767-4379-8094-a110beadbea4"));
            IsThereBloodReplacement = (ITTEnumComboBox)AddControl(new Guid("009b3ae0-2956-4109-bf4f-71cd1d6717ea"));
            labelInjuryDate = (ITTLabel)AddControl(new Guid("6c9cc298-d859-4c07-a202-1629c052620d"));
            InjuryDate = (ITTDateTimePicker)AddControl(new Guid("16f33afe-3f54-4e41-8580-aac199f2022d"));
            labelHowWasInjury = (ITTLabel)AddControl(new Guid("62a4f877-426a-4485-8b1c-5b243861d134"));
            HowWasInjury = (ITTTextBox)AddControl(new Guid("d9db0152-52a0-4bcf-a7ff-804b8633946f"));
            labelGlaskowKomaSkoru = (ITTLabel)AddControl(new Guid("5e63dd1a-b31b-496a-a177-3e45c86f6984"));
            GlaskowKomaSkoru = (ITTTextBox)AddControl(new Guid("ded7422c-52f0-493f-a9cc-9e45601193ca"));
            FirstRespondersWhoParamedic = (ITTCheckBox)AddControl(new Guid("f1e25c4b-16e4-441f-a2c3-9e81badb0277"));
            FirstRespondersWhoHimself = (ITTCheckBox)AddControl(new Guid("b4268165-2e77-41c5-a0c4-d88f55387aa8"));
            FirstRespondersWhoFriend = (ITTCheckBox)AddControl(new Guid("715f4818-51a3-49b5-9d6d-5bf884546858"));
            FirstRespondersWhoDoctor = (ITTCheckBox)AddControl(new Guid("5687dbdb-a999-4a8c-91ed-d67364415909"));
            labelFirstAidDate = (ITTLabel)AddControl(new Guid("269f627e-d56e-40a2-a304-de291ea22809"));
            FirstAidDate = (ITTDateTimePicker)AddControl(new Guid("604e1577-8748-4459-84ff-e2c1823bd27a"));
            labelEvacuationTime = (ITTLabel)AddControl(new Guid("90b5795d-436f-4cbc-b965-683589003238"));
            EvacuationTime = (ITTTextBox)AddControl(new Guid("d3601265-6d45-479e-8ded-80ba51bdedb5"));
            labelConditionOfInjured = (ITTLabel)AddControl(new Guid("e69fa22e-df50-4e8b-9722-07b65d09d0e4"));
            ConditionOfInjured = (ITTEnumComboBox)AddControl(new Guid("fe5f5b89-20c2-4eaf-991a-e6e5214f6465"));
            labelCityOfInjured = (ITTLabel)AddControl(new Guid("596373f2-8c79-415a-98ab-9a263b821b63"));
            CityOfInjured = (ITTTextBox)AddControl(new Guid("d093bd54-3d33-4e3c-8e88-9804a91d7ff2"));
            labelAmountOfBloodReplacement = (ITTLabel)AddControl(new Guid("90ecf7c4-645f-4768-8332-6f989f6944c8"));
            AmountOfBloodReplacement = (ITTTextBox)AddControl(new Guid("5f196809-0969-4557-9b13-674c2cc0c9b6"));
            tabYaralanmaBolgesi = (ITTTabPage)AddControl(new Guid("0b455a48-8335-4986-9af8-c5e833299efd"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("7bbe3c7d-1a31-4329-829f-507b49e4aa32"));
            ImageBox = (ITTPictureBoxControl)AddControl(new Guid("c4e55700-f381-4187-8ec4-027f067442bb"));
            InjuryLocationGrid = (ITTGrid)AddControl(new Guid("63aa474b-733c-487b-bb52-3d3f64c5a93e"));
            InjuryDirectionOfLocationEmergencyInterventionInjuryLocationGrid = (ITTEnumComboBoxColumn)AddControl(new Guid("a5b8cb92-2160-4244-8f0a-902aae6ae3d4"));
            InjuryLocationEmergencyInterventionInjuryLocationGrid = (ITTEnumComboBoxColumn)AddControl(new Guid("6b56f926-9fb2-4cc8-9cf7-a6e8e402adeb"));
            TypeOfInjuryEmergencyInterventionInjuryLocationGrid = (ITTTextBoxColumn)AddControl(new Guid("079994d0-7366-407f-89c4-3246af146c4c"));
            InEmergencyInterventionInjuryLocationGrid = (ITTTextBoxColumn)AddControl(new Guid("c744cad3-d46c-4ced-bf44-3706d9e9d148"));
            OutEmergencyInterventionInjuryLocationGrid = (ITTTextBoxColumn)AddControl(new Guid("622779a8-2caf-43d4-a898-b2d528ac9830"));
            DescriptionEmergencyInterventionInjuryLocationGrid = (ITTRichTextBoxControlColumn)AddControl(new Guid("a1979307-1b0a-42f3-ad99-8f0a86f367d8"));
            base.InitializeControls();
        }

        public EmergInterInjuryLocationForm() : base("EMERGENCYINTERVENTIONINJURYLOCATION", "EmergInterInjuryLocationForm")
        {
        }

        protected EmergInterInjuryLocationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}