
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
    /// Profesörler Sağlık Kurulu Onay
    /// </summary>
    public partial class HCPApprovalForm : TTForm
    {
    /// <summary>
    /// Profesörler Sağlık Kurulu Onay İşlemi
    /// </summary>
        protected TTObjectClasses.HealthCommitteeOfProfessorsApproval _HealthCommitteeOfProfessorsApproval
        {
            get { return (TTObjectClasses.HealthCommitteeOfProfessorsApproval)_ttObject; }
        }

        protected ITTTabControl tttabcontrolMain;
        protected ITTTabPage tttabpageHC;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTGrid HospitalsUnits;
        protected ITTListBoxColumn Units;
        protected ITTListBoxColumn RespectiveDoctor;
        protected ITTCheckBoxColumn ApprovalStatus;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelUnitsHospitals;
        protected ITTLabel labelStartDate;
        protected ITTLabel labelProtocolNo;
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
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("253048ca-8ea0-4e7b-b2ba-3e0b3eba5985"));
            tttabpageHC = (ITTTabPage)AddControl(new Guid("b92924b5-cb4f-4794-9335-46587a4f8ac0"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("ee742e88-ae46-4759-a568-e61abbc6584e"));
            HospitalsUnits = (ITTGrid)AddControl(new Guid("713d200c-b2d3-4800-99e9-cbda87e355d2"));
            Units = (ITTListBoxColumn)AddControl(new Guid("c31dbc56-4ba9-4dbc-8927-345041dfe490"));
            RespectiveDoctor = (ITTListBoxColumn)AddControl(new Guid("ed3d8e9c-6320-4ec9-a499-8600c4407f5c"));
            ApprovalStatus = (ITTCheckBoxColumn)AddControl(new Guid("37a38e66-966c-4e2d-834a-5301d05d91ca"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("ab0b3a05-0c18-48f3-98c3-187e3dfd41d5"));
            labelUnitsHospitals = (ITTLabel)AddControl(new Guid("e7724894-5dd3-45e7-96fc-2dd9ccbba55c"));
            labelStartDate = (ITTLabel)AddControl(new Guid("347b4ee8-4989-49da-9be6-b7a88ae4bb80"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("74b2385c-e959-4a39-99a4-0883b7bfccd9"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("a6d30c8a-68e0-4b1a-b324-88743414570d"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("77ef1dcc-9a3c-4a27-a293-f07cd200aba3"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("ae1bd6a3-b392-4dfa-96a7-58f32b2fd443"));
            Weight = (ITTTextBox)AddControl(new Guid("c7246e6c-5d7b-47cd-a79c-1310e762a109"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("abb321ac-0a19-43db-82fe-7f6461f220a6"));
            HCStartDate = (ITTDateTimePicker)AddControl(new Guid("693679b2-7a0d-4284-8473-6c3469afbdc2"));
            Height = (ITTTextBox)AddControl(new Guid("ae73b4e8-7848-4677-a00d-bd742dec4264"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("db706a2f-3fb6-48d3-bfea-288f44b890fd"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("cd60aae8-7ef5-476d-b0e4-fc9f7d8f412a"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("ca0c35d6-e24a-4559-9d5a-4647aa15169d"));
            labelNumberOfDocumnets = (ITTLabel)AddControl(new Guid("c8c3362b-6ae5-4906-8fd5-6e529833014b"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("57289c71-837a-4bf5-9da3-e3ef2b2b32e7"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("d5ddf454-22a8-4239-8752-b4a061e9aff6"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("a3b9bc22-3a90-4ad0-ac56-fb5fd057b347"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("3c2da240-e6e9-4c08-8096-1724312e5094"));
            LabelMasterResource = (ITTLabel)AddControl(new Guid("7eeeea64-41de-46a2-8c39-897d7767e7f1"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("a7d7cb78-49af-47e7-a5cd-4605aadfd010"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("cc778c9f-434b-49d5-bd7f-0436ac8e73d6"));
            tttabpagePI = (ITTTabPage)AddControl(new Guid("6965338c-ac10-4a4e-868e-0d076e4399ea"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("a17bede2-cc7a-4b7a-aae5-537c4e931fb2"));
            labelRegistryNo = (ITTLabel)AddControl(new Guid("4a696508-16cd-40de-9410-dbc23154a9b0"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("2a409d3a-c69d-4496-991f-20b4bdbe67bb"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("b9d3a77c-b215-403f-b4a7-89c18a7d4e8b"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("f510d7b3-55c9-4028-9fd8-8bd282082c68"));
            CityOfRegistry = (ITTObjectListBox)AddControl(new Guid("d579f886-cd5d-4beb-b5ef-f0f005c3146a"));
            labelVillageOfRegistry = (ITTLabel)AddControl(new Guid("4b00036f-20c5-4e7b-8e9b-d5318ae50928"));
            TownOfBirth = (ITTObjectListBox)AddControl(new Guid("19ec467e-5b90-4ac8-b347-fe1adacc4765"));
            labelRank = (ITTLabel)AddControl(new Guid("8100e8ca-4783-4112-a840-b9c2696fc3de"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("e2ec9b31-4998-4ed7-9551-1af6e145f846"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("71ac68dc-592a-457f-a356-e888296a6223"));
            labelFatherName = (ITTLabel)AddControl(new Guid("9c6a4ed6-1612-4005-9247-26d0dff3f07b"));
            labelBirthPlaceCountry = (ITTLabel)AddControl(new Guid("8daa8b7f-e68a-4153-a4b1-238532021aae"));
            labelTownOfRegistry = (ITTLabel)AddControl(new Guid("74fa3320-491d-40a3-bd9c-076caeafa985"));
            Rank = (ITTObjectListBox)AddControl(new Guid("0ef527bd-206f-4384-9a9c-d2cdf772466b"));
            labelBirlik = (ITTLabel)AddControl(new Guid("3a5853f0-fd4a-4d8c-abaf-af3fe6f84e9c"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("0c8c7fce-684f-4830-afde-60e21f51676a"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("0a539b8d-e4b8-478e-8cd3-f0aa1f235eb8"));
            labelRelationship = (ITTLabel)AddControl(new Guid("eff9d017-98fc-4b70-bc1c-d14d45ed2dea"));
            FatherName = (ITTTextBox)AddControl(new Guid("db896dcb-8904-4ff7-9149-b4482715161e"));
            Adres = (ITTTextBox)AddControl(new Guid("3c30db8e-ca20-49bf-8fba-398dc873923f"));
            CityOfBirth = (ITTObjectListBox)AddControl(new Guid("b8998cf3-dc38-4a72-a512-8624a6b594ff"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("4f9c49d9-112a-4ee0-b69b-3d83911abe0a"));
            labelCityOfRegistry = (ITTLabel)AddControl(new Guid("734ba06c-42ec-4985-a35e-eb7d6978f937"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("5ae625c5-45aa-428a-8edf-ab76a21d38fd"));
            labelTownOfBirth = (ITTLabel)AddControl(new Guid("b3a92977-5f31-4ff0-8955-61c8df68f17a"));
            VillageOfRegistry = (ITTTextBox)AddControl(new Guid("bf177675-ea52-48a4-b687-697882ded9de"));
            labelCityOfBirth = (ITTLabel)AddControl(new Guid("4a6789e6-efc6-419d-995b-396c2ec10e34"));
            CountryOfBirth = (ITTObjectListBox)AddControl(new Guid("e1bc8382-13c1-45e1-a56c-d2c618035cf1"));
            TownOfRegistry = (ITTObjectListBox)AddControl(new Guid("8ecbbc72-62f0-41ff-aedc-b8b0c4e7c978"));
            base.InitializeControls();
        }

        public HCPApprovalForm() : base("HEALTHCOMMITTEEOFPROFESSORSAPPROVAL", "HCPApprovalForm")
        {
        }

        protected HCPApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}