
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
    public partial class HCProfsCancelledForm : EpisodeActionForm
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
        protected ITTTextBox ReasonOfCancel;
        protected ITTLabel labelNumberOfProcedure;
        protected ITTTextBox NumberOfProcedure;
        protected ITTLabel ttlabel9;
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
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("68ad9e41-4b06-426b-9e33-ed66b1dac5e1"));
            tttabpageHC = (ITTTabPage)AddControl(new Guid("bb5a62c1-7857-4be4-b5ef-c84ba706b211"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("2f7b74b1-510d-456d-8213-f8f873ba3912"));
            labelNumberOfProcedure = (ITTLabel)AddControl(new Guid("14eef302-e87b-4173-9eb2-869afdcc1bbb"));
            NumberOfProcedure = (ITTTextBox)AddControl(new Guid("672f6cbf-0127-41cc-b9e0-236ba27e906d"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("d51f1726-a76c-44e8-8c02-6a511aab7cb6"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("0625d470-d086-4f4c-85fb-f39db8117b26"));
            labelUnitsHospitals = (ITTLabel)AddControl(new Guid("37fabf7c-7b2e-427b-b870-431acf6e2cd0"));
            ReasonForRequest = (ITTTextBox)AddControl(new Guid("e6a4cee9-5797-4e21-ad71-948bd183af96"));
            labelStartDate = (ITTLabel)AddControl(new Guid("a60f5329-21c6-443d-81c0-cece88e39e87"));
            HospitalsUnits = (ITTGrid)AddControl(new Guid("50e91a29-4269-4c03-85df-b4d1e2f8aa3c"));
            Units = (ITTListBoxColumn)AddControl(new Guid("509fb915-b330-4aad-bd81-0a0fff48e312"));
            RespectiveDoctor = (ITTListBoxColumn)AddControl(new Guid("2b05110f-291b-4054-abdc-5b6f88ae2374"));
            ApprovalStatus = (ITTCheckBoxColumn)AddControl(new Guid("acc49db4-dfbc-4d46-af98-ca4a666016b3"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("4e5cef17-b7e9-4b64-aa22-a3501905c80a"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("905cf25b-9daa-49d5-9c0c-f8136f6d1abd"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("02635257-9f58-4412-bdd1-a35a72276755"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("349edc31-c03b-4f1c-81a4-4dacef0e9ac1"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("73586fc3-fccf-49ae-9fec-d8553f6d225f"));
            Weight = (ITTTextBox)AddControl(new Guid("d9dfea7f-25a3-4819-a9d1-3ae4bc3c53ca"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("77fc1190-a788-4a27-b7ee-58846494f2a7"));
            HCStartDate = (ITTDateTimePicker)AddControl(new Guid("7c2b84ed-a55a-4f5b-ae6b-9c63bc15ac03"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("d767b2ad-951e-4602-8c90-c2b33d33867d"));
            Height = (ITTTextBox)AddControl(new Guid("8dec7461-0ab8-473f-b211-876eb6c012c6"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("09185dcc-809d-450a-b1fa-eb36f3a78179"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("37d8706f-aacd-4879-ae30-1b5e4885c8c2"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("d53a73ec-08c7-4bb5-b70c-cc85954d5cda"));
            labelNumberOfDocumnets = (ITTLabel)AddControl(new Guid("89931934-6726-43c8-9234-5e3cbbe62f9a"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("d1e4273d-ce3b-43ef-b6bb-baf59855034f"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("c747b55f-a366-4003-a473-b8e78875f297"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("3ef24fe9-67b1-4aa9-a41e-e0e8098a8a03"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("ba472792-665b-4fc6-8f62-3da7d930a49a"));
            LabelMasterResource = (ITTLabel)AddControl(new Guid("a63d15a1-f184-439e-b40d-e31f73937511"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e11df123-8890-4e38-85de-9033c5c1eb80"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("f7de5a7f-5d15-4be1-9fd8-8e6c2c5d5530"));
            tttabpagePI = (ITTTabPage)AddControl(new Guid("26aa232c-f28d-46d3-b5ca-ca99e7304295"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("fcd6e67f-683b-47ff-98d5-e9993b6cfe23"));
            labelRegistryNo = (ITTLabel)AddControl(new Guid("7226f6f8-fedf-40a0-8524-48c505975131"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("3a6a7a15-522a-4a7a-a88d-796735008323"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("9ac93f0f-8156-41a9-9481-61eeaef70725"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("6fe1b872-7e6b-498b-9c48-6a8878dd2f46"));
            CityOfRegistry = (ITTObjectListBox)AddControl(new Guid("ca72cc7a-eb8e-4fd7-9113-10caf3a603f6"));
            labelVillageOfRegistry = (ITTLabel)AddControl(new Guid("353c3417-b71d-42ea-aac0-7b839521b8af"));
            TownOfBirth = (ITTObjectListBox)AddControl(new Guid("d9d8ebaa-9413-4d37-b979-2e1cfa0105cf"));
            labelRank = (ITTLabel)AddControl(new Guid("a2c9529c-a290-4559-a57d-61ef6e919a57"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("ec16319d-01bc-4bbf-a216-32743112efec"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("9e7c74de-025d-44af-8fac-009b73ba6ad8"));
            labelFatherName = (ITTLabel)AddControl(new Guid("9c884dc8-faae-427e-b3f0-5b379c1802ac"));
            labelBirthPlaceCountry = (ITTLabel)AddControl(new Guid("5d454c7c-cd08-4b17-bda8-fb977aa28b98"));
            labelTownOfRegistry = (ITTLabel)AddControl(new Guid("8b212019-c7f5-451c-88f1-e024a739cc09"));
            Rank = (ITTObjectListBox)AddControl(new Guid("6bb1d4a2-1c92-4ba0-a5e6-0d547127e78d"));
            labelBirlik = (ITTLabel)AddControl(new Guid("858457cf-18a9-4888-a0b3-f8451ca4bc2b"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("b71dcae7-75ea-4e14-9543-1e609702e04a"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("83003ab1-c360-4b01-a497-7b2fb58b6aeb"));
            labelRelationship = (ITTLabel)AddControl(new Guid("c30f70d6-9047-44ac-978d-fdb5a479f38d"));
            FatherName = (ITTTextBox)AddControl(new Guid("735df4b9-8f77-49a7-82ef-3f399d2bdb75"));
            Adres = (ITTTextBox)AddControl(new Guid("573fd17b-2bf8-4a75-b05f-df273b9353a9"));
            CityOfBirth = (ITTObjectListBox)AddControl(new Guid("ff6e3f8a-0c1c-4f1b-a2fd-b4507cb276b7"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("2dd97615-41ea-4156-b087-157ad7a475aa"));
            labelCityOfRegistry = (ITTLabel)AddControl(new Guid("332c22b6-8203-403d-82a0-5ea4c48e85d5"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("7e1d4471-9d23-49b2-930d-cecdc1164234"));
            labelTownOfBirth = (ITTLabel)AddControl(new Guid("ee863a43-d955-4855-9cf9-f120c65754bd"));
            VillageOfRegistry = (ITTTextBox)AddControl(new Guid("1c53504e-d424-48f8-a006-873d76b28d37"));
            labelCityOfBirth = (ITTLabel)AddControl(new Guid("be709735-6954-44ad-b74b-495be3199d51"));
            CountryOfBirth = (ITTObjectListBox)AddControl(new Guid("9bc05075-bfaa-429c-a386-a63dc238a299"));
            TownOfRegistry = (ITTObjectListBox)AddControl(new Guid("a0bff3d3-9564-4063-a93e-429d856d74b7"));
            base.InitializeControls();
        }

        public HCProfsCancelledForm() : base("HEALTHCOMMITTEEOFPROFESSORS", "HCProfsCancelledForm")
        {
        }

        protected HCProfsCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}