
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
    /// <summary>
    /// Profesörler Sağlık Kurulu
    /// </summary>
    public partial class HCProfsRequestApprovalForm : EpisodeActionForm
    {
    /// <summary>
    /// Profesörler Sağlık Kurulu İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.HealthCommitteeOfProfessors _HealthCommitteeOfProfessors
        {
            get { return (TTObjectClasses.HealthCommitteeOfProfessors)_ttObject; }
        }

        protected ITTTabControl tttabcontrolMain;
        protected ITTTabPage tttabpageHC;
        protected ITTLabel labelNumberOfProcedure;
        protected ITTTextBox NumberOfProcedure;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTLabel labelUnitsHospitals;
        protected ITTTextBox ReasonForRequest;
        protected ITTLabel labelStartDate;
        protected ITTGrid HospitalsUnits;
        protected ITTListBoxColumn Units;
        protected ITTListBoxColumn RespectiveDoctor;
        protected ITTCheckBoxColumn ApprovalStatus;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox MasterResource;
        protected ITTTextBox Weight;
        protected ITTLabel ttlabel5;
        protected ITTDateTimePicker HCStartDate;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox Height;
        protected ITTLabel ttlabel3;
        protected ITTEnumComboBox PatientGroup;
        protected ITTEnumComboBox PatientStatus;
        protected ITTLabel labelNumberOfDocumnets;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox SenderChair;
        protected ITTLabel labelDocumentDate;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel LabelMasterResource;
        protected ITTLabel ttlabel2;
        protected ITTTextBox DocumentNumber;
        protected ITTTabPage tttabpagePI;
        protected ITTObjectListBox MilitaryClass;
        protected ITTLabel labelRegistryNo;
        protected ITTLabel labelBirthDate;
        protected ITTTextBox EmploymentRecordID;
        protected ITTObjectListBox Relationship;
        protected ITTObjectListBox CityOfRegistry;
        protected ITTLabel labelVillageOfRegistry;
        protected ITTObjectListBox TownOfBirth;
        protected ITTLabel labelRank;
        protected ITTLabel labelMilitaryClass;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel labelFatherName;
        protected ITTLabel labelBirthPlaceCountry;
        protected ITTLabel labelTownOfRegistry;
        protected ITTObjectListBox Rank;
        protected ITTLabel labelBirlik;
        protected ITTTextBox HeadOfFamilyName;
        protected ITTLabel labelHeadOfFamilyName;
        protected ITTLabel labelRelationship;
        protected ITTTextBox FatherName;
        protected ITTTextBox Adres;
        protected ITTObjectListBox CityOfBirth;
        protected ITTDateTimePicker BirthDate;
        protected ITTLabel labelCityOfRegistry;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelTownOfBirth;
        protected ITTTextBox VillageOfRegistry;
        protected ITTLabel labelCityOfBirth;
        protected ITTObjectListBox CountryOfBirth;
        protected ITTObjectListBox TownOfRegistry;
        override protected void InitializeControls()
        {
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("38296024-0fa5-457d-af8f-3b291fc804bb"));
            tttabpageHC = (ITTTabPage)AddControl(new Guid("ca5e6bf7-d0cc-4443-bc01-8942ce7d540b"));
            labelNumberOfProcedure = (ITTLabel)AddControl(new Guid("2e5ad5a8-11dc-4ba7-bc6b-af13b0f5e85f"));
            NumberOfProcedure = (ITTTextBox)AddControl(new Guid("01c4850e-386b-483b-bcd6-4111e8bcac16"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("fbdd2278-d90e-4679-a73b-fa1ee412535c"));
            labelUnitsHospitals = (ITTLabel)AddControl(new Guid("a3288f18-1b28-4ab7-9e10-070847ffb0c2"));
            ReasonForRequest = (ITTTextBox)AddControl(new Guid("94e93b12-351e-4076-aad0-5cc48f5d2e10"));
            labelStartDate = (ITTLabel)AddControl(new Guid("003bc432-f314-498f-a220-001aad94ea27"));
            HospitalsUnits = (ITTGrid)AddControl(new Guid("9150ab25-6b5b-474a-9942-6d33f6202b9b"));
            Units = (ITTListBoxColumn)AddControl(new Guid("1908df0b-db2f-43b7-b8d3-c048cba6e463"));
            RespectiveDoctor = (ITTListBoxColumn)AddControl(new Guid("5114d9dd-6eab-4aff-a19c-81d025531f3c"));
            ApprovalStatus = (ITTCheckBoxColumn)AddControl(new Guid("8b320221-e8b8-431b-b9cc-f09c793e481a"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("816ecc2b-b50d-4c72-a0c6-f4879357db30"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("d62961a2-b959-45e0-9777-9e0e045d4008"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("191bab18-768d-40a1-b123-89a2e0a25267"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("8feda759-6231-47a6-8df9-d40a729f7f84"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("13292a7b-5163-4ec6-94ad-2bf8a0f8ad29"));
            Weight = (ITTTextBox)AddControl(new Guid("9c1e2150-332f-453a-80c7-8d09b831dae0"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("b97cf902-b776-4495-a56a-9627c1c12e69"));
            HCStartDate = (ITTDateTimePicker)AddControl(new Guid("333c7c53-7416-422f-a375-6649cb022808"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("9d18f784-2bca-4078-92af-bfc78f2a347e"));
            Height = (ITTTextBox)AddControl(new Guid("7d4ccea9-5bf5-474b-82ef-ca7e161091b2"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("3dc9a97a-3394-4538-88a9-9f3ba7511c1c"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("6f28d7dc-dc3a-47ce-b4ba-53c9bff0a8bf"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("887c18ca-074e-43af-b032-e57e9c441642"));
            labelNumberOfDocumnets = (ITTLabel)AddControl(new Guid("348c99d4-08dc-4d6b-8795-6b67bf95e3ea"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("39eda932-a45c-452b-b7cf-78a1756aad3b"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("5a61b681-4777-4075-9ad4-caedba8b4665"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("22b0bf8a-2730-4e50-8968-fc6ba09698a0"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("7d56fe44-cf0a-4f59-bc77-dccf8cc21e28"));
            LabelMasterResource = (ITTLabel)AddControl(new Guid("998dd495-200e-4eb0-b8a2-af3c9dccd42c"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("2ae11bcb-94af-4892-a748-d3e2ec656928"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("b25a89fc-2e4e-416c-a6a2-958135d52d13"));
            tttabpagePI = (ITTTabPage)AddControl(new Guid("a945cc11-b38b-4c44-a84c-93bfff3cb19e"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("d2670c13-20f9-4901-9d41-cb067c12a0b3"));
            labelRegistryNo = (ITTLabel)AddControl(new Guid("c4ffd9e1-14d4-4ceb-a6e6-7698c4c0c1d2"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("684b54f0-938c-4cdc-84e7-ce4311652e7c"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("9a90b4d7-6145-43f9-b27f-68abd0d6bcff"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("b2928283-672d-4396-89d8-156cb745b0fa"));
            CityOfRegistry = (ITTObjectListBox)AddControl(new Guid("aa7425bb-5d7f-47eb-916c-360517914f3a"));
            labelVillageOfRegistry = (ITTLabel)AddControl(new Guid("40ae4cf2-d9c4-4a8f-b2d3-c0b4c01777b7"));
            TownOfBirth = (ITTObjectListBox)AddControl(new Guid("c90e46d8-e1fc-4a3c-abbb-ef16ed4114ef"));
            labelRank = (ITTLabel)AddControl(new Guid("76000181-f015-4a77-a8cc-67a28c8f7158"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("3f000cef-7752-4767-b91c-c4dfda5a6062"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("1537e4b2-da41-4fd9-85bd-4fdd2922d666"));
            labelFatherName = (ITTLabel)AddControl(new Guid("1c31ae17-548a-4bfd-bf99-27689ec611f2"));
            labelBirthPlaceCountry = (ITTLabel)AddControl(new Guid("64de2b87-2c4d-4ddd-b4d2-7c678de72557"));
            labelTownOfRegistry = (ITTLabel)AddControl(new Guid("a48754a9-de89-4f81-b6cd-aa19c0f12601"));
            Rank = (ITTObjectListBox)AddControl(new Guid("29e25b4b-41da-440d-81fe-a63e78e7dbf7"));
            labelBirlik = (ITTLabel)AddControl(new Guid("40f30424-c112-49ba-a8b9-0079adfe2640"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("efbd408a-da2a-4230-83c8-53c4b92cd9d1"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("4de9caa5-49bc-453b-aa27-dcd891b12ba1"));
            labelRelationship = (ITTLabel)AddControl(new Guid("4112afc2-fdab-40f6-9928-f37adae35cbc"));
            FatherName = (ITTTextBox)AddControl(new Guid("bc808341-86e1-4d2a-8170-8f737b4c12c9"));
            Adres = (ITTTextBox)AddControl(new Guid("d6bb6391-fb91-4053-8cfa-9c54f683b2af"));
            CityOfBirth = (ITTObjectListBox)AddControl(new Guid("e331af3a-b603-42cc-a326-74766a69f117"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("34b50463-9204-469a-9886-9ae7b45de616"));
            labelCityOfRegistry = (ITTLabel)AddControl(new Guid("732ec435-7711-4c1d-b7d0-4ac8efdc7edb"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f0fcfe24-840a-49ca-b44e-60268c3e083e"));
            labelTownOfBirth = (ITTLabel)AddControl(new Guid("843ed416-a151-44cc-9aed-fea60ad13094"));
            VillageOfRegistry = (ITTTextBox)AddControl(new Guid("9019a27f-5160-4bbb-9bb8-1c7342f4258d"));
            labelCityOfBirth = (ITTLabel)AddControl(new Guid("71cff615-2fff-42d7-a734-6bdd2c087db3"));
            CountryOfBirth = (ITTObjectListBox)AddControl(new Guid("a1a3ab73-88c1-414c-adb5-0e8bd2108585"));
            TownOfRegistry = (ITTObjectListBox)AddControl(new Guid("c4dc4ddc-1af3-4b01-8ab2-bbe524a82a3d"));
            base.InitializeControls();
        }

        public HCProfsRequestApprovalForm() : base("HEALTHCOMMITTEEOFPROFESSORS", "HCProfsRequestApprovalForm")
        {
        }

        protected HCProfsRequestApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}