
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
    public partial class HCProfsRequestForm : EpisodeActionForm
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
        protected ITTGrid ReturnDescriptions;
        protected ITTDateTimePickerColumn EntryDate;
        protected ITTTextBoxColumn ReturnDescription;
        protected ITTTextBoxColumn UserOwner;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTLabel labelUnitsHospitals;
        protected ITTTextBox ReasonForRequest;
        protected ITTLabel labelStartDate;
        protected ITTGrid HospitalsUnits;
        protected ITTListBoxColumn Units;
        protected ITTListBoxColumn RespectiveDoctor;
        protected ITTCheckBoxColumn ApprovalStatus;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox MasterResource;
        protected ITTTextBox Weight;
        protected ITTLabel ttlabel5;
        protected ITTDateTimePicker HCStartDate;
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
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("05883763-d832-4872-9cd9-793d96f4fcc4"));
            tttabpageHC = (ITTTabPage)AddControl(new Guid("867373e5-812f-4ac1-8a78-5205226418ba"));
            labelNumberOfProcedure = (ITTLabel)AddControl(new Guid("afd0c1a2-bf1b-488d-b07a-d948eafa343e"));
            NumberOfProcedure = (ITTTextBox)AddControl(new Guid("4a9e3a35-9781-41c4-9acb-cf6216440be1"));
            ReturnDescriptions = (ITTGrid)AddControl(new Guid("26a160ac-b02e-4aa6-a961-27b68623fab3"));
            EntryDate = (ITTDateTimePickerColumn)AddControl(new Guid("bfbfa81e-4aa2-4032-8e97-d702c0e4fce8"));
            ReturnDescription = (ITTTextBoxColumn)AddControl(new Guid("80792457-b141-4466-a526-55056ba20066"));
            UserOwner = (ITTTextBoxColumn)AddControl(new Guid("e6fab9c0-10f8-4d05-a037-fa8cc370aa97"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("790d4a19-d665-4ac3-b32b-fe201a46a996"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("6646a3c4-705d-4f44-8261-bd84b88cdcd7"));
            labelUnitsHospitals = (ITTLabel)AddControl(new Guid("d63d0f99-229f-4703-8a01-3bb5671ae430"));
            ReasonForRequest = (ITTTextBox)AddControl(new Guid("ac60d24c-95f3-46b9-bad5-5a9727a2452e"));
            labelStartDate = (ITTLabel)AddControl(new Guid("85cbeafa-dc05-41f4-ae77-71a2eee16396"));
            HospitalsUnits = (ITTGrid)AddControl(new Guid("b003689d-303b-4611-b37c-3bc96a578306"));
            Units = (ITTListBoxColumn)AddControl(new Guid("2981447f-5b90-420d-bbe8-fe709b99bea1"));
            RespectiveDoctor = (ITTListBoxColumn)AddControl(new Guid("ab98697c-0af2-4883-9a21-5d45b1b41419"));
            ApprovalStatus = (ITTCheckBoxColumn)AddControl(new Guid("9adc3d17-4e43-4fbb-bc10-cd29533b9fd1"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("b18faa8e-f3be-4d8b-a1be-9087ba9f916c"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("7bc2cd28-6130-4f9e-bed6-405c1fa0b5a7"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("261e1382-80f1-4673-a3ee-072be4554ebd"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("68bb2f7c-0e5e-48ac-be48-c89891c6adfa"));
            Weight = (ITTTextBox)AddControl(new Guid("42188e81-0a53-4104-b883-a6fcdb2516d5"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("4e85889e-8ace-42a9-9ce0-bb30118dba2b"));
            HCStartDate = (ITTDateTimePicker)AddControl(new Guid("84ad002a-b56d-446b-a2ba-286627f2e8ba"));
            Height = (ITTTextBox)AddControl(new Guid("93aa67c6-3aca-463a-ab3c-31b63beb60a1"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("1125e029-cef8-496b-8da7-50ab7c9a94ec"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("9ddffe38-21b3-4e11-b87d-793860da2241"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("0ea67218-e591-4b96-8110-fc5a517d0d01"));
            labelNumberOfDocumnets = (ITTLabel)AddControl(new Guid("292f8cd2-8321-49dd-8afe-e28a7d3c9c81"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("0f9400f6-f9e5-49eb-a70e-7ccc2188516c"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("ecc1ce26-ed8d-4dd2-aba0-1dc292e79203"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("30b036f3-0b4d-4923-a8f5-49e423309192"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("03285724-acc7-435e-a327-0e9b7f9224c1"));
            LabelMasterResource = (ITTLabel)AddControl(new Guid("7c5623e5-72d4-4578-8134-9ebad9e9c1fe"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("719a1614-6f21-4e29-9325-84d1f9ca2bc0"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("ba6ed0e0-dc60-4021-a922-35ead7aa57f6"));
            tttabpagePI = (ITTTabPage)AddControl(new Guid("40197379-3785-4037-9a5c-f9ae7a77e4ed"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("27e00e15-84f8-46b5-a2fb-e18175d0fa86"));
            labelRegistryNo = (ITTLabel)AddControl(new Guid("3f4a63a9-d5d0-4eb4-8ce1-69c86a661108"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("1fa43b25-25fe-4da1-8d63-4ae57b44f3ca"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("82d5736a-d5af-4c09-9999-b31cbe7f0547"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("a9df9316-6cf5-4f0d-83ea-a03be517a476"));
            CityOfRegistry = (ITTObjectListBox)AddControl(new Guid("905e4027-75d1-4287-9674-e6a80464c576"));
            labelVillageOfRegistry = (ITTLabel)AddControl(new Guid("93bc80f5-3154-4ca1-bca1-06ec8b19e8bc"));
            TownOfBirth = (ITTObjectListBox)AddControl(new Guid("26362ed4-85b2-40ff-abbd-ba9af8c35069"));
            labelRank = (ITTLabel)AddControl(new Guid("8be15346-8ce5-4d18-bd0b-63521c6ae7ad"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("e92b5dd2-0cfe-47bb-b4b9-5984e6ca578e"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("d30e2e1c-2c67-460d-b6a1-118d7534ed94"));
            labelFatherName = (ITTLabel)AddControl(new Guid("a1c2a8c1-9f25-4361-a92d-3b9ea141093b"));
            labelBirthPlaceCountry = (ITTLabel)AddControl(new Guid("24902d0a-5ff8-42a7-b4e4-3e4652588fc6"));
            labelTownOfRegistry = (ITTLabel)AddControl(new Guid("6e060954-84c2-4a57-8342-f38da6be069e"));
            Rank = (ITTObjectListBox)AddControl(new Guid("f825ac1b-537f-4d30-a054-c765ef013df3"));
            labelBirlik = (ITTLabel)AddControl(new Guid("673fc61b-a74a-44bb-a8f3-f95bd57d5485"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("9f9decf5-ac4b-491c-9783-21295db2da7c"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("5b1adf87-1b74-4bac-b7b8-72a97b3d4e7b"));
            labelRelationship = (ITTLabel)AddControl(new Guid("79a636be-eb14-434f-84b4-bc4f6132323d"));
            FatherName = (ITTTextBox)AddControl(new Guid("181d1a20-e499-43e8-a30c-1271d1e90851"));
            Adres = (ITTTextBox)AddControl(new Guid("3bcbce4d-6c30-425e-b716-0b0f731052a4"));
            CityOfBirth = (ITTObjectListBox)AddControl(new Guid("89728931-54e3-4e21-b2e1-aa3722460f88"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("323d2c59-ca37-4501-a44b-288bd9c64472"));
            labelCityOfRegistry = (ITTLabel)AddControl(new Guid("c90a55a4-fbb2-4ced-a70e-fa90c1e13227"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("aa7f5e99-ab47-4af0-972f-c58c2396264c"));
            labelTownOfBirth = (ITTLabel)AddControl(new Guid("791a1615-5ca1-4f71-9674-8021bbaf9310"));
            VillageOfRegistry = (ITTTextBox)AddControl(new Guid("d2b49688-be61-4503-a1b4-5adcd6569e18"));
            labelCityOfBirth = (ITTLabel)AddControl(new Guid("67a4ce41-8214-445d-b88a-158a0e9fbd97"));
            CountryOfBirth = (ITTObjectListBox)AddControl(new Guid("175f651c-39b1-498b-bcef-69ef3dd7c921"));
            TownOfRegistry = (ITTObjectListBox)AddControl(new Guid("2aaa8c68-4aff-4cba-8e3b-bf2f036133d9"));
            base.InitializeControls();
        }

        public HCProfsRequestForm() : base("HEALTHCOMMITTEEOFPROFESSORS", "HCProfsRequestForm")
        {
        }

        protected HCProfsRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}