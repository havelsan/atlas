
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
    /// Sağlık Kurulu
    /// </summary>
    public partial class HCCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Sağlık Kurulu İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.HealthCommittee _HealthCommittee
        {
            get { return (TTObjectClasses.HealthCommittee)_ttObject; }
        }

        protected ITTTabControl tttabcontrolMain;
        protected ITTTabPage tttabpageHC;
        protected ITTLabel ttlabel12;
        protected ITTTextBox FunctionRatio;
        protected ITTTextBox ReasonOfCancel;
        protected ITTLabel ttlabel10;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox Height;
        protected ITTEnumComboBox PatientStatus;
        protected ITTLabel ttlabel8;
        protected ITTTextBox Weight;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel7;
        protected ITTLabel labelStartDate;
        protected ITTLabel ttlabel3;
        protected ITTDateTimePicker RequestDate;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel LabelMasterResource;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTObjectListBox MasterResource;
        protected ITTLabel ttlabel9;
        protected ITTDateTimePicker HCStartDate;
        protected ITTLabel labelProtocolNo;
        protected ITTEnumComboBox PatientGroup;
        protected ITTLabel labelDocumentDate;
        protected ITTDateTimePicker DocumentDate;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel labelNumberOfProcedure;
        protected ITTLabel labelNumberOfDocumnets;
        protected ITTTextBox NumberOfProcedure;
        protected ITTTabPage tttabpagePI;
        protected ITTGroupBox ttgroupbox2;
        protected ITTObjectListBox MilitaryOffice;
        protected ITTLabel ttlabel11;
        protected ITTDateTimePicker BirthDate;
        protected ITTLabel labelBirthDate;
        protected ITTTextBox Adres;
        protected ITTLabel ttlabel1;
        protected ITTTextBox HeadOfFamilyName;
        protected ITTLabel labelFatherName;
        protected ITTLabel labelHeadOfFamilyName;
        protected ITTTextBox FatherName;
        protected ITTObjectListBox Relationship;
        protected ITTObjectListBox TownOfRegistry;
        protected ITTObjectListBox CityOfRegistry;
        protected ITTLabel labelRelationship;
        protected ITTObjectListBox TownOfBirth;
        protected ITTLabel labelCityOfBirth;
        protected ITTTextBox VillageOfRegistry;
        protected ITTLabel labelVillageOfRegistry;
        protected ITTLabel labelTownOfRegistry;
        protected ITTObjectListBox CityOfBirth;
        protected ITTLabel labelBirthPlaceCountry;
        protected ITTLabel labelTownOfBirth;
        protected ITTObjectListBox CountryOfBirth;
        protected ITTTextBox tttextboxTCNo;
        protected ITTLabel ttlabel6;
        protected ITTLabel labelCityOfRegistry;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel labelBirlik;
        protected ITTObjectListBox MilitaryClass;
        protected ITTLabel labelMilitaryClass;
        protected ITTObjectListBox Rank;
        protected ITTLabel labelRank;
        protected ITTTextBox EmploymentRecordID;
        protected ITTLabel labelRegistryNo;
        override protected void InitializeControls()
        {
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("6cb150d6-ea8f-4dca-b7bb-e42602478fc3"));
            tttabpageHC = (ITTTabPage)AddControl(new Guid("b1a36300-9b93-410d-8b17-8d97f43ba0f5"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("abfda315-1a9a-4b67-9322-40310aa798f7"));
            FunctionRatio = (ITTTextBox)AddControl(new Guid("a24fef83-5bb3-47e5-9df6-54e04d9bd926"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("aceb4f89-90e7-42cb-bd29-2a9d041671c1"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("fca77201-0fc0-4420-8ff0-5ce30a909833"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("6dbb8af9-7f1c-40d8-bdb6-688dec93ff0c"));
            Height = (ITTTextBox)AddControl(new Guid("b7cde878-2348-4112-9010-ee89660f65cf"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("0874a3da-3a4c-4b39-b096-98539ad6d3fb"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("a9ce88d7-9a16-4649-a4c7-88adb4f26c55"));
            Weight = (ITTTextBox)AddControl(new Guid("51bc61d5-c50b-4020-baa8-e77847bc0b35"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("64e48cd4-99f6-428f-9c23-390cf902d009"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("bb7a0d74-2568-4fcd-837d-755ffa74d05a"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("f0a2218d-554e-4a7e-9ea4-d6849c41b986"));
            labelStartDate = (ITTLabel)AddControl(new Guid("7541db0a-ec4f-41d0-879a-39cda544f8ef"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("bed41b17-22e4-4912-959e-bef048fbfc38"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("66760666-ab67-4650-b466-3a55f95d8f3e"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("b40d91d4-6da0-4ebd-a111-6d131986e506"));
            LabelMasterResource = (ITTLabel)AddControl(new Guid("fa162087-3f97-48db-a54f-9d5da4d29dd3"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("a49c9a50-5745-44ea-80aa-377063e80bf4"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("545a48be-6dc0-46a0-9c24-397d3b262711"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("d1620838-bbbb-425e-9535-35bf18b38100"));
            HCStartDate = (ITTDateTimePicker)AddControl(new Guid("2150e279-7291-4438-8e67-03cadc788d08"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("b7cf043a-5754-4fcc-943e-3fcf9bdd6632"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("6322499c-d13d-4afd-94b4-edeccbd680c6"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("f84a5ac5-e854-4382-8ba5-b1f23c5878ce"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("5fa735f4-d83a-46c5-a291-ac3ee97879f4"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("b065ec7d-7b53-4471-a223-ac398440a149"));
            labelNumberOfProcedure = (ITTLabel)AddControl(new Guid("1217c4e0-5b24-4db5-b040-9a66f5d71ba0"));
            labelNumberOfDocumnets = (ITTLabel)AddControl(new Guid("ce8fceae-bf98-4e88-bf2c-0c269ded14f0"));
            NumberOfProcedure = (ITTTextBox)AddControl(new Guid("2ed8d7f4-5d05-4c39-be2b-0eab11419482"));
            tttabpagePI = (ITTTabPage)AddControl(new Guid("8d202d26-6108-41b5-9f2c-e225454eefa6"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("42818960-93a2-49b2-98e0-596934ed3eb3"));
            MilitaryOffice = (ITTObjectListBox)AddControl(new Guid("a90ae5f9-f901-4150-8129-3932efbcee45"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("52a9f179-973c-49be-8014-c0f0fe3c30f3"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("02075e7a-2233-4518-80ac-828b73b8898c"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("273f256d-88d1-4e35-b7f9-734960132f86"));
            Adres = (ITTTextBox)AddControl(new Guid("50c2d537-9540-45ff-b391-547c28d29991"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0fd69c71-6977-46a8-95f7-6d8d179d5f13"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("25bfaed7-1c2b-44cb-9768-e42bd0fad35f"));
            labelFatherName = (ITTLabel)AddControl(new Guid("f2b6899a-980a-414d-9301-db1b15ba300b"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("031376dc-e935-474f-80e7-1c7d4976c9bd"));
            FatherName = (ITTTextBox)AddControl(new Guid("54a569fa-befc-4204-b601-d19fd679f4c5"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("7d4eca4a-1cf2-469d-a285-ec5ae5595324"));
            TownOfRegistry = (ITTObjectListBox)AddControl(new Guid("b1d4ad78-4273-462e-97ac-dc4ef113e159"));
            CityOfRegistry = (ITTObjectListBox)AddControl(new Guid("51af3de6-1630-4d1e-9a96-4787ef0a3e4e"));
            labelRelationship = (ITTLabel)AddControl(new Guid("713a68a8-14a4-40de-8bca-1c5f62fe3f12"));
            TownOfBirth = (ITTObjectListBox)AddControl(new Guid("3fde046c-5e4a-44a4-9e4e-6a969d13d14a"));
            labelCityOfBirth = (ITTLabel)AddControl(new Guid("c2c2b3d7-d053-4ff5-b0f1-14b0853fe469"));
            VillageOfRegistry = (ITTTextBox)AddControl(new Guid("53182257-d87b-4942-9afe-e623a67a6a5a"));
            labelVillageOfRegistry = (ITTLabel)AddControl(new Guid("d875e011-58cd-40e1-832b-90208fe4da8f"));
            labelTownOfRegistry = (ITTLabel)AddControl(new Guid("39130fe8-1108-4ba3-9c21-7dd32c2e821e"));
            CityOfBirth = (ITTObjectListBox)AddControl(new Guid("f90a4f0f-85b1-47cb-a51b-e391a625a1c8"));
            labelBirthPlaceCountry = (ITTLabel)AddControl(new Guid("c0f04432-e8c7-4fcd-be57-378adf155377"));
            labelTownOfBirth = (ITTLabel)AddControl(new Guid("f76028b3-7c7b-441d-9fdc-3826893a10f3"));
            CountryOfBirth = (ITTObjectListBox)AddControl(new Guid("24b48485-ef01-44ae-92b3-e377845107be"));
            tttextboxTCNo = (ITTTextBox)AddControl(new Guid("80bb0ea9-9296-4475-98f5-43b7f3c11c0d"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("ba943a29-e26a-40ee-8974-a3094286a2d2"));
            labelCityOfRegistry = (ITTLabel)AddControl(new Guid("cd801baa-32f1-4ec9-8093-c0a8ef1846be"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("9cbc0444-956f-4d22-9315-a0befef9771d"));
            labelBirlik = (ITTLabel)AddControl(new Guid("a4657f48-f0f9-4e91-bfe4-0ff40fd457b6"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("9f9b28a3-f02c-4655-b7a2-b5587087e225"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("ea8d6bcc-062a-4b12-9a2a-fdad82cf882f"));
            Rank = (ITTObjectListBox)AddControl(new Guid("3208647d-f690-46a2-82d2-146cfaf10392"));
            labelRank = (ITTLabel)AddControl(new Guid("0de98fc3-70af-4fda-88bf-4bc6f94211b4"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("289e0de6-7fba-45e4-b8c7-f5464a929744"));
            labelRegistryNo = (ITTLabel)AddControl(new Guid("79272fd1-af68-4da5-aadd-2b4b44416c7d"));
            base.InitializeControls();
        }

        public HCCancelledForm() : base("HEALTHCOMMITTEE", "HCCancelledForm")
        {
        }

        protected HCCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}