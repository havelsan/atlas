
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
    public partial class HCPApprovalRequestForm : TTForm
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
        protected ITTGrid ReturnDescriptions;
        protected ITTDateTimePickerColumn EntryDate;
        protected ITTTextBoxColumn ReturnDescription;
        protected ITTTextBoxColumn OwnerUser;
        protected ITTGrid HospitalsUnits;
        protected ITTListBoxColumn Units;
        protected ITTListBoxColumn RespectiveDoctor;
        protected ITTCheckBoxColumn ApprovalStatus;
        protected ITTLabel ttlabel7;
        protected ITTLabel labelUnitsHospitals;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTLabel labelStartDate;
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
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("2ca5ae01-2d60-42cb-aa6f-11bb2dbcf4b1"));
            tttabpageHC = (ITTTabPage)AddControl(new Guid("c0fa5906-bb0b-48a7-abb3-930e3a795b1f"));
            ReturnDescriptions = (ITTGrid)AddControl(new Guid("799d5be2-eb3f-484a-951e-5f78084f3d1e"));
            EntryDate = (ITTDateTimePickerColumn)AddControl(new Guid("4dabb4c1-d110-46f8-bdb2-e53bc1a33258"));
            ReturnDescription = (ITTTextBoxColumn)AddControl(new Guid("1c62ba58-58ff-435b-8326-0a81728e6ec9"));
            OwnerUser = (ITTTextBoxColumn)AddControl(new Guid("0472fefa-5ead-47ec-8b75-3f4c0cb6571d"));
            HospitalsUnits = (ITTGrid)AddControl(new Guid("eab3ec19-4ad1-4f85-87f4-a61f4e4b642c"));
            Units = (ITTListBoxColumn)AddControl(new Guid("78814381-74b8-45ff-b374-d691faf5921c"));
            RespectiveDoctor = (ITTListBoxColumn)AddControl(new Guid("3b9cc416-3ca9-4975-ad1f-8b51ebaa5fdd"));
            ApprovalStatus = (ITTCheckBoxColumn)AddControl(new Guid("22548899-8e50-4b13-885f-f98782a883d0"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("64ca63ec-c56b-4b75-bc99-6d7b1cc691e0"));
            labelUnitsHospitals = (ITTLabel)AddControl(new Guid("2839759f-baf9-49d6-ac68-2e303ae8fb9f"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("9d957a07-481c-4810-8101-0e6d022f7494"));
            labelStartDate = (ITTLabel)AddControl(new Guid("17566427-1ce9-48a0-b64e-48a620bcd0f2"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("d9ff0d7d-cc90-4cd4-be55-04d383150c72"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("eb51f317-24ec-4f51-8481-363ccddab9d2"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("e3aa6043-eb50-427e-ab1f-fe05ff15af78"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("a7fb04ea-81d9-4eea-b6cd-9928da086667"));
            Weight = (ITTTextBox)AddControl(new Guid("86522e52-c7c4-41c0-8c1d-211c96efb167"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("3d3596e4-f265-4aa0-84fc-3cd346b47d96"));
            HCStartDate = (ITTDateTimePicker)AddControl(new Guid("c22a84af-5400-4690-9ce6-5047df9504bb"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("23e63cd2-1cba-4502-a2d7-90fc46eeb9e5"));
            Height = (ITTTextBox)AddControl(new Guid("9b4f731e-d6d9-4eb3-a18c-29c5ba2e8b93"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("b049f814-3c24-4a50-bb03-cffcf203fbbf"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("e98dcf48-ce1e-4c95-b389-ce0c352c9651"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("6448edfc-06d1-45d2-b775-d5bcbe8965b2"));
            labelNumberOfDocumnets = (ITTLabel)AddControl(new Guid("e1d0950d-f782-417d-ad36-f01b9a287092"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("e61fe8eb-26c2-4ded-a390-30e64c5eaac6"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("2f0e9a6a-7414-4e8b-af79-29bc2974b90b"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("a57d3763-61f1-499e-bd98-38cab47f3cbc"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("e2bd992f-2d06-4c3b-95a9-ce27e75fee3c"));
            LabelMasterResource = (ITTLabel)AddControl(new Guid("33da517c-a5f9-4573-8b23-a139515f48fd"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ebb2c57a-104a-4311-bacf-c401aa5972c8"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("b23eabd9-aa70-421c-987c-fd9684d0885c"));
            tttabpagePI = (ITTTabPage)AddControl(new Guid("af575890-285f-4d77-8eaf-0e9a5d2f358e"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("2a0d593b-9c70-404b-b130-09b34aba1754"));
            labelRegistryNo = (ITTLabel)AddControl(new Guid("c5956fac-a6b8-47bb-9869-a82c1c3a145e"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("b117cc38-2154-4989-a696-09c8fd28218e"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("31a2d495-cef8-4450-8104-515ab818d715"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("98f68e98-3eb4-4305-862c-363ea54bd1da"));
            CityOfRegistry = (ITTObjectListBox)AddControl(new Guid("48fb8382-422e-4170-a376-7cd9e4e6ffd7"));
            labelVillageOfRegistry = (ITTLabel)AddControl(new Guid("f34e3ed4-af79-4d4c-b35c-ba25c780eb65"));
            TownOfBirth = (ITTObjectListBox)AddControl(new Guid("0a58dd8c-7c3b-4425-8db6-14f850677a09"));
            labelRank = (ITTLabel)AddControl(new Guid("c3c40296-3a18-4248-84af-c9d866e825e9"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("39b6e8a2-fdf1-46e9-951e-c5929cbbae5d"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("c1193da3-e42a-468f-95a8-2b3b16c04969"));
            labelFatherName = (ITTLabel)AddControl(new Guid("f124b29b-f89b-47a8-b16c-1416ce42fc25"));
            labelBirthPlaceCountry = (ITTLabel)AddControl(new Guid("06ea43b8-013d-4d15-8914-420ed3241d14"));
            labelTownOfRegistry = (ITTLabel)AddControl(new Guid("d26806de-7e57-430b-9160-4e785c247187"));
            Rank = (ITTObjectListBox)AddControl(new Guid("7cbbe3da-fd09-43db-889b-0949b81e754a"));
            labelBirlik = (ITTLabel)AddControl(new Guid("0e0f7931-9257-46ac-a4fd-7e4cdcf483e3"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("02ee92bd-f011-49e2-8115-ba49b1f27a0f"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("120c6f69-0539-4474-972f-8f185b045715"));
            labelRelationship = (ITTLabel)AddControl(new Guid("3d52c907-21c4-46fd-9699-3cebb284e504"));
            FatherName = (ITTTextBox)AddControl(new Guid("05096727-f322-4d8a-9e81-74cc20764ac5"));
            Adres = (ITTTextBox)AddControl(new Guid("2b721933-d3fa-4d62-9b68-37b4ab3af2db"));
            CityOfBirth = (ITTObjectListBox)AddControl(new Guid("b416b6b4-aab6-42b9-a4d3-c55bf571a39c"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("27bb5dde-3ae9-4b9f-897f-42518c92ff5e"));
            labelCityOfRegistry = (ITTLabel)AddControl(new Guid("d4626169-2624-4e1d-9f3a-8b04a960b372"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3933ce63-b0e6-4d54-acde-bfd35d737499"));
            labelTownOfBirth = (ITTLabel)AddControl(new Guid("1b28019e-a5f9-4d22-81c5-ac1a7abaacf6"));
            VillageOfRegistry = (ITTTextBox)AddControl(new Guid("a0615ae7-1f2a-4c1b-b80e-ebef8f991c40"));
            labelCityOfBirth = (ITTLabel)AddControl(new Guid("703dd726-2578-40f7-8ada-70cac5663dda"));
            CountryOfBirth = (ITTObjectListBox)AddControl(new Guid("32460e5d-e853-4d97-9987-81e5fe630205"));
            TownOfRegistry = (ITTObjectListBox)AddControl(new Guid("ec9fcf7e-aedb-4773-9554-b094a8a01d76"));
            base.InitializeControls();
        }

        public HCPApprovalRequestForm() : base("HEALTHCOMMITTEEOFPROFESSORSAPPROVAL", "HCPApprovalRequestForm")
        {
        }

        protected HCPApprovalRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}