
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
    public partial class HCProfsSecretaryForm : EpisodeActionForm
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
        protected ITTGrid MemberClinics;
        protected ITTListBoxColumn MemberClinic;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTLabel labelUnitsHospitals;
        protected ITTLabel labelStartDate;
        protected ITTGrid HospitalsUnits;
        protected ITTListBoxColumn Units;
        protected ITTListBoxColumn RespectiveDoctor;
        protected ITTCheckBoxColumn ApprovalStatus;
        protected ITTLabel labelProtocolNo;
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
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("316da64d-25f4-43cf-a78f-32c1d4f49e7f"));
            tttabpageHC = (ITTTabPage)AddControl(new Guid("e5f862ec-f276-4b3d-869c-438ee7ae7e12"));
            labelNumberOfProcedure = (ITTLabel)AddControl(new Guid("236d483e-30d2-42ad-bd52-a290358b095c"));
            NumberOfProcedure = (ITTTextBox)AddControl(new Guid("698ea6de-fd25-41c2-ab36-4a57dcc45c0c"));
            MemberClinics = (ITTGrid)AddControl(new Guid("326cc21b-1f2c-44cb-ab95-a0b1b136b507"));
            MemberClinic = (ITTListBoxColumn)AddControl(new Guid("37daba8b-2841-4c55-9a65-259dad9c1ddd"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("09d451f0-0730-421d-82eb-af26da8347d0"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("9f9023d2-08b8-4480-ac8c-9b1bea05f1b9"));
            labelUnitsHospitals = (ITTLabel)AddControl(new Guid("b9d36411-9f57-464f-a40e-07c51f93efbb"));
            labelStartDate = (ITTLabel)AddControl(new Guid("44f23a7f-2704-4d20-8c1c-ce8f3a87e05e"));
            HospitalsUnits = (ITTGrid)AddControl(new Guid("886b62eb-c173-4d25-aa14-b417eb09f731"));
            Units = (ITTListBoxColumn)AddControl(new Guid("880de498-8bca-4839-b7c4-1baa2edc4221"));
            RespectiveDoctor = (ITTListBoxColumn)AddControl(new Guid("41f2e549-7ce1-4457-a999-676cc3ff18e8"));
            ApprovalStatus = (ITTCheckBoxColumn)AddControl(new Guid("b004f3ac-ed0a-4c8a-bb1e-dd04e70d58d7"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("228a9641-39a6-4802-a468-c9b3afeebff3"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("17c4c826-9905-4dc3-b151-c63e85670700"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("f3979bc8-3d39-4e2e-9c4a-c2f9349e8cfa"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("abff4b73-ad33-4e43-ba11-99dce30a0b56"));
            Weight = (ITTTextBox)AddControl(new Guid("92c360a0-8873-4f13-a7a6-d1e4aee670b5"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("2b5eab88-cb2e-461c-8ae1-83fa442ee4b5"));
            HCStartDate = (ITTDateTimePicker)AddControl(new Guid("bdf9c181-8c92-4ad5-9f00-2d5d6ee55ac8"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("d5474a76-0f39-4473-89cb-3d8ff7ce2eaf"));
            Height = (ITTTextBox)AddControl(new Guid("2ac719f3-a788-4fe5-aaf0-10a434dd1ca3"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("894c2085-1e20-4b85-a4bf-f24dceaf00e5"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("0ddd4287-4d6a-487b-b078-5f0a4c6c7ab2"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("b18c3bfc-9c51-4f47-b2e1-02b88237e607"));
            labelNumberOfDocumnets = (ITTLabel)AddControl(new Guid("80ebccba-5e5d-4a24-a23b-c6ca06030164"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("26218ba3-0c88-4769-acd5-ce8c795bee94"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("cf20d3c5-afa9-4d47-9ef0-2d33f668e088"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("82465ffa-1529-4ea1-ba15-fbbe229d1ec5"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("dfc6ab37-99a3-4a8b-99ce-1325ba82f2a5"));
            LabelMasterResource = (ITTLabel)AddControl(new Guid("061c3911-21bf-4ee4-8a34-135b5eb0a602"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("fbe25fea-c96a-47a5-8268-c15969602d73"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("280ab2a8-b998-43e5-acf8-c956b2571563"));
            tttabpagePI = (ITTTabPage)AddControl(new Guid("a27443bd-9a1c-4d75-bcbe-fffefc5deeeb"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("8894897f-58d5-4480-906a-62fe62bfe121"));
            labelRegistryNo = (ITTLabel)AddControl(new Guid("decef69e-c6b5-4095-b346-cb3696743bf3"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("6534c9f8-b5e7-4bba-b619-db60628c4b8f"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("f4a1d02d-e8af-4c05-ad10-9d152aa11011"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("a32874b7-1c44-44a1-b5fc-b9f9bd2f3b81"));
            CityOfRegistry = (ITTObjectListBox)AddControl(new Guid("d13a91af-14a8-44e2-ac50-9551f3b666f4"));
            labelVillageOfRegistry = (ITTLabel)AddControl(new Guid("5b159a00-1e74-49a6-82d1-05efbf492a46"));
            TownOfBirth = (ITTObjectListBox)AddControl(new Guid("617627c4-8e77-4464-826a-4a8f4bd0285e"));
            labelRank = (ITTLabel)AddControl(new Guid("da6b8c10-f100-422f-87b6-bd95ffa7b4ee"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("b482182f-fdb0-42ac-b25c-015798068a1b"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("96e60bc0-d8ab-4a8b-9a55-ee6ba246b832"));
            labelFatherName = (ITTLabel)AddControl(new Guid("b8290cb5-09ba-4d87-b926-4459f738071a"));
            labelBirthPlaceCountry = (ITTLabel)AddControl(new Guid("da91bde8-881e-4f27-9623-918780c077b3"));
            labelTownOfRegistry = (ITTLabel)AddControl(new Guid("0a97f2e8-2ed3-49df-810f-ef3931a679fc"));
            Rank = (ITTObjectListBox)AddControl(new Guid("ed446cc5-2943-4ce8-8e9f-4410c9a92408"));
            labelBirlik = (ITTLabel)AddControl(new Guid("5b4d2786-dd3e-4979-81f0-2a1690ff046a"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("9840c36d-8987-419b-9593-285eb489bb46"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("a1ef3ba8-855b-4837-b125-1d7bc7b30c8e"));
            labelRelationship = (ITTLabel)AddControl(new Guid("e16a5fc0-aff4-4c9e-bd1e-de8ad5d6ad03"));
            FatherName = (ITTTextBox)AddControl(new Guid("4bb8cbcf-6471-4f33-ac36-3ea50a4f3f59"));
            Adres = (ITTTextBox)AddControl(new Guid("49a06465-f801-49d1-88e8-70a986f75590"));
            CityOfBirth = (ITTObjectListBox)AddControl(new Guid("71020da0-f094-486c-be8f-69dc0148b145"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("017aac07-fd77-4753-84af-a516b7607f77"));
            labelCityOfRegistry = (ITTLabel)AddControl(new Guid("12d95c58-668f-4c7d-aa38-615d4e2a314b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("5e4bd2ba-7194-4c3f-bf52-54137d3af516"));
            labelTownOfBirth = (ITTLabel)AddControl(new Guid("bea19197-b830-4fb2-94e4-54f0288f3844"));
            VillageOfRegistry = (ITTTextBox)AddControl(new Guid("b33bb5d6-e549-476a-b8f6-0bda25b88a65"));
            labelCityOfBirth = (ITTLabel)AddControl(new Guid("e06a8d89-cd72-49b3-aa90-83d140fe5437"));
            CountryOfBirth = (ITTObjectListBox)AddControl(new Guid("c5a386ab-40ee-44fb-a030-f18d4bacbd36"));
            TownOfRegistry = (ITTObjectListBox)AddControl(new Guid("81c9b8a9-2580-4e3f-b7bd-9943e889a196"));
            base.InitializeControls();
        }

        public HCProfsSecretaryForm() : base("HEALTHCOMMITTEEOFPROFESSORS", "HCProfsSecretaryForm")
        {
        }

        protected HCProfsSecretaryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}