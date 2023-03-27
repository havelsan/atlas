
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
    /// Kullanıcı Tanımı
    /// </summary>
    public partial class ResUserForm : TTDefinitionForm
    {
    /// <summary>
    /// Kullanıcı
    /// </summary>
        protected TTObjectClasses.ResUser _ResUser
        {
            get { return (TTObjectClasses.ResUser)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage PatientInfo;
        protected ITTCheckBox IsClinician;
        protected ITTLabel labelKPSPassword;
        protected ITTTextBox KPSPassword;
        protected ITTLabel labelKPSUserName;
        protected ITTTextBox KPSUserName;
        protected ITTTextBox txtLimit;
        protected ITTTextBox txtNameForStart;
        protected ITTLabel lblLimit;
        protected ITTLabel lblNameForStart;
        protected ITTButton btnMultiplyUser;
        protected ITTObjectListBox TownOfRegistryPerson;
        protected ITTObjectListBox SexPerson;
        protected ITTLabel labelBirthPlacePerson;
        protected ITTTextBox BirthPlacePerson;
        protected ITTLabel labelPreDischargeLimit;
        protected ITTTextBox PreDischargeLimit;
        protected ITTLabel labelMkysUserName;
        protected ITTTextBox MkysUserName;
        protected ITTLabel labelMkysPassword;
        protected ITTTextBox MkysPassword;
        protected ITTCheckBox chkTakesPerformanceScore;
        protected ITTCheckBox UsesESignature;
        protected ITTCheckBox SentToMHRS;
        protected ITTLabel labelErecetePassword;
        protected ITTTextBox ErecetePassword;
        protected ITTLabel ttlabel8;
        protected ITTObjectListBox ForcesCommand;
        protected ITTTextBox FatherName;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox TescilNo;
        protected ITTLabel ttlabel7;
        protected ITTLabel lblUserName;
        protected ITTLabel ttlabel2;
        protected ITTTextBox txtUserName;
        protected ITTEnumComboBox UserTitle;
        protected ITTGrid ResourceSpecialities;
        protected ITTCheckBoxColumn MainSpeciality;
        protected ITTListBoxColumn Speciality;
        protected ITTLabel labelMilitaryClass;
        protected ITTObjectListBox Rank;
        protected ITTLabel labelEmploymentRecordID;
        protected ITTLabel labelDateOfJoin;
        protected ITTLabel labelTitle;
        protected ITTLabel labelUserType;
        protected ITTTextBox EmploymentRecordID;
        protected ITTLabel labelDateOfLeave;
        protected ITTObjectListBox MilitaryClass;
        protected ITTLabel labelPhoneNumber;
        protected ITTLabel labelUniqueRefNo;
        protected ITTTextBox DiplomaNo;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelDiplomaNo;
        protected ITTTextBox PhoneNumber;
        protected ITTLabel labelSex;
        protected ITTDateTimePicker DateOfLeave;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelVillageOfRegistry;
        protected ITTEnumComboBox UserType;
        protected ITTDateTimePicker DateOfJoin;
        protected ITTObjectListBox TownOfBirth;
        protected ITTTextBox VillageOfRegistry;
        protected ITTCheckBox Active;
        protected ITTLabel labelDateOfPromotion;
        protected ITTObjectListBox CountryOfBirth;
        protected ITTLabel ttlabel13;
        protected ITTTextBox Name;
        protected ITTLabel labelName;
        protected ITTDateTimePicker DateOfPromotion;
        protected ITTTextBox Surname;
        protected ITTLabel labelBirthDate;
        protected ITTDateTimePicker BirthDate;
        protected ITTLabel labelSurname;
        protected ITTTextBox UniqueRefNo;
        protected ITTObjectListBox CityOfRegistry;
        protected ITTLabel labelFatherName;
        protected ITTLabel labelMotherName;
        protected ITTTextBox MotherName;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel6;
        protected ITTTabPage UserInfo;
        protected ITTGrid ResUserUsableStores;
        protected ITTListBoxColumn StoreResUserUsableStore;
        protected ITTLabel labelWork;
        protected ITTObjectListBox Store;
        protected ITTGrid UserResources;
        protected ITTListBoxColumn SecMasterDepartment;
        protected ITTLabel labelStore;
        protected ITTLabel labelWorkPlace;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox WorkPlace;
        protected ITTTabPage ResUserPatientGroupTab;
        protected ITTLabel lblResUserPatientGroupMatch;
        protected ITTGrid ResUserPatientGroupMatches;
        protected ITTListBoxColumn PatientGroupResUserPatientGroupMatch;
        protected ITTCheckBoxColumn IsAssignableResUserPatientGroupMatch;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("446e1ce7-bba9-4af9-bcb9-7e0a95af863c"));
            PatientInfo = (ITTTabPage)AddControl(new Guid("685b082a-b1b7-4db6-bcec-1ce12cad16fc"));
            IsClinician = (ITTCheckBox)AddControl(new Guid("da403e47-8d2b-472f-a846-a6614315d22d"));
            labelKPSPassword = (ITTLabel)AddControl(new Guid("a307fb4b-8ed9-48ab-80e2-78ec92887f7b"));
            KPSPassword = (ITTTextBox)AddControl(new Guid("5c39d62c-a0e8-49bb-9b75-226ee299ad17"));
            labelKPSUserName = (ITTLabel)AddControl(new Guid("e4529998-27e5-4ecc-8829-c60c9260a60f"));
            KPSUserName = (ITTTextBox)AddControl(new Guid("c2108d99-4ce0-43f3-9898-ab192b802363"));
            txtLimit = (ITTTextBox)AddControl(new Guid("f6b002fc-6147-4d6d-a36a-6f4b136926ee"));
            txtNameForStart = (ITTTextBox)AddControl(new Guid("5e427b27-994a-4571-a48a-c9e576de492f"));
            lblLimit = (ITTLabel)AddControl(new Guid("bf837599-3d50-459a-b425-6bdeb7e823d1"));
            lblNameForStart = (ITTLabel)AddControl(new Guid("980d2795-559f-4a57-9d39-c5ea20c74d8c"));
            btnMultiplyUser = (ITTButton)AddControl(new Guid("d510eda2-c837-41a7-81d4-834eff08fbec"));
            TownOfRegistryPerson = (ITTObjectListBox)AddControl(new Guid("d7ed00b4-96be-4146-8f0f-ae59f537848b"));
            SexPerson = (ITTObjectListBox)AddControl(new Guid("bbb4b48c-83eb-4459-ad4e-15e7bb4e4150"));
            labelBirthPlacePerson = (ITTLabel)AddControl(new Guid("a8899ad9-168e-4d19-93e8-b86dd062643d"));
            BirthPlacePerson = (ITTTextBox)AddControl(new Guid("2e1eb61e-8513-4b56-9664-5c03e33faf8a"));
            labelPreDischargeLimit = (ITTLabel)AddControl(new Guid("31618635-8387-43fa-ab1c-729e13d720b3"));
            PreDischargeLimit = (ITTTextBox)AddControl(new Guid("1eb07294-9966-4a94-a6e4-ede0a6c64ce3"));
            labelMkysUserName = (ITTLabel)AddControl(new Guid("b0dbf4a4-6c86-4531-8b3c-ab5024d6364a"));
            MkysUserName = (ITTTextBox)AddControl(new Guid("06cca908-8477-4abf-a213-b88ed1f90d16"));
            labelMkysPassword = (ITTLabel)AddControl(new Guid("cc1e3ff2-c64f-4c3f-94ca-f7eabe26f54f"));
            MkysPassword = (ITTTextBox)AddControl(new Guid("9a4f9653-b14f-4579-a6fb-f6ab3a462f84"));
            chkTakesPerformanceScore = (ITTCheckBox)AddControl(new Guid("d030182f-704a-4d53-ae2c-e1a55d16a282"));
            UsesESignature = (ITTCheckBox)AddControl(new Guid("9b5dd1f9-74fe-4c80-b825-3ad74e37f544"));
            SentToMHRS = (ITTCheckBox)AddControl(new Guid("cb572450-c309-4263-bb5c-0d9e563b1253"));
            labelErecetePassword = (ITTLabel)AddControl(new Guid("fb717e57-dcad-4824-bd98-6c3756dda7cc"));
            ErecetePassword = (ITTTextBox)AddControl(new Guid("070e014b-18ea-4e49-9915-468f6a881990"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("5f9c0c08-68c5-4a2d-8047-6643acec9b9f"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("c9d1fb2f-ccd9-4a68-85fa-f5e18656ed9c"));
            FatherName = (ITTTextBox)AddControl(new Guid("50c04fba-ac7e-47ca-a870-c255198e7f50"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("30772e07-b865-416a-b10b-ceb6b52c750c"));
            TescilNo = (ITTTextBox)AddControl(new Guid("b3d9c552-6d84-49bd-a8e3-53e0185e4fa9"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("5c9ee882-a3ef-411a-829b-9581e821e15f"));
            lblUserName = (ITTLabel)AddControl(new Guid("b7ca52bf-85c6-4f31-a241-87f8c9feed95"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("320b8253-9926-4719-88e7-84460f903d79"));
            txtUserName = (ITTTextBox)AddControl(new Guid("616b6371-cfed-4acb-96ca-fbf4ae91441e"));
            UserTitle = (ITTEnumComboBox)AddControl(new Guid("37f469d2-ff24-4222-85bb-7985d0de96e2"));
            ResourceSpecialities = (ITTGrid)AddControl(new Guid("95974f5a-1d50-43f1-a1ee-1d6724863358"));
            MainSpeciality = (ITTCheckBoxColumn)AddControl(new Guid("39ccbac9-c7b7-4816-a697-df70a9557519"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("48b0e2fc-abe0-45a1-8e6f-21ef67247e17"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("d0ed3c29-390c-48a8-8f20-6c07c4711511"));
            Rank = (ITTObjectListBox)AddControl(new Guid("a4c2e7cc-5530-4168-aeb9-744530f17c17"));
            labelEmploymentRecordID = (ITTLabel)AddControl(new Guid("a61fc51d-035e-4fef-8ff0-2e279ef4b593"));
            labelDateOfJoin = (ITTLabel)AddControl(new Guid("637751ca-d4f2-4ff8-b5a3-068030c3c212"));
            labelTitle = (ITTLabel)AddControl(new Guid("cd42c7c0-30ce-46b7-ae6d-a073b288cb75"));
            labelUserType = (ITTLabel)AddControl(new Guid("86e9e2f0-2b98-488f-a008-ad58a31fae15"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("0be0a1fe-d2c1-4f75-8adf-1af4679bcf0d"));
            labelDateOfLeave = (ITTLabel)AddControl(new Guid("d2cb1518-2d62-487e-8bf1-e909bedf408c"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("87fcd5e6-7bd7-4968-b69a-4625152a4a5c"));
            labelPhoneNumber = (ITTLabel)AddControl(new Guid("9ccf3bfa-18bd-4fd5-9696-0d1f941f6ed6"));
            labelUniqueRefNo = (ITTLabel)AddControl(new Guid("5bfe0a53-c12d-44f8-abc1-ca8e408e852d"));
            DiplomaNo = (ITTTextBox)AddControl(new Guid("64b0c467-bd53-491c-b583-b423a44b7d74"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("11bcfc38-1da8-4e1a-890d-7a8958331ff5"));
            labelDiplomaNo = (ITTLabel)AddControl(new Guid("52968cde-a3c8-44af-b1d8-bb463d9cad27"));
            PhoneNumber = (ITTTextBox)AddControl(new Guid("8d1a0f9c-7df0-46b6-b3ba-273d0f8ee6d0"));
            labelSex = (ITTLabel)AddControl(new Guid("b34fa188-f6ea-426a-a8af-82508b7175b2"));
            DateOfLeave = (ITTDateTimePicker)AddControl(new Guid("3f7bb790-c1ad-491f-aac4-110fba3a2c3d"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("19512859-c4b6-44bc-b92e-182583ba9d69"));
            labelVillageOfRegistry = (ITTLabel)AddControl(new Guid("a2fea343-c75c-464d-ad40-90e551d23799"));
            UserType = (ITTEnumComboBox)AddControl(new Guid("23888f26-2b92-4569-80f8-3a3963784a78"));
            DateOfJoin = (ITTDateTimePicker)AddControl(new Guid("9b03c22d-dc9d-48eb-a86e-d1adea805147"));
            TownOfBirth = (ITTObjectListBox)AddControl(new Guid("f5991e37-433a-4af6-b067-0c62e92c33c5"));
            VillageOfRegistry = (ITTTextBox)AddControl(new Guid("d32f0e36-bfd3-4e09-82b8-73fbd5039304"));
            Active = (ITTCheckBox)AddControl(new Guid("bbed4a0c-d0c8-4c8d-97c7-b6dc868936e9"));
            labelDateOfPromotion = (ITTLabel)AddControl(new Guid("ba2846c3-8359-45d5-a068-60f85ec24ef2"));
            CountryOfBirth = (ITTObjectListBox)AddControl(new Guid("597ca2ca-4327-4c1b-8838-663da94c7033"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("132b9d59-f05e-4b23-a333-c8733b845ad6"));
            Name = (ITTTextBox)AddControl(new Guid("88ef6bd6-d633-4489-a200-57fa2adb94d2"));
            labelName = (ITTLabel)AddControl(new Guid("1b671251-9d00-49af-808a-258fe3db459d"));
            DateOfPromotion = (ITTDateTimePicker)AddControl(new Guid("b562f34e-c244-4fe6-aef2-536e92f9c489"));
            Surname = (ITTTextBox)AddControl(new Guid("54036806-6061-4744-9dc3-02d277133198"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("9c02dee9-9089-49ab-b024-ee3f27d90196"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("d272414f-2bfb-4ca6-bd43-f24aa873b339"));
            labelSurname = (ITTLabel)AddControl(new Guid("cceee0b0-a311-485b-a89b-44bc257f214c"));
            UniqueRefNo = (ITTTextBox)AddControl(new Guid("f476b2dc-3071-427a-ae30-b3d692934ea9"));
            CityOfRegistry = (ITTObjectListBox)AddControl(new Guid("005717aa-b2fe-4dc3-9509-30818a92d72f"));
            labelFatherName = (ITTLabel)AddControl(new Guid("a58d17a8-2025-43e1-ac6b-9e3a52eaa159"));
            labelMotherName = (ITTLabel)AddControl(new Guid("ddbf1e4a-146b-4dd3-95be-8465162d04cc"));
            MotherName = (ITTTextBox)AddControl(new Guid("89f03d40-018a-481b-ae96-b3433e67532f"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("3a03afa8-4196-428e-850c-edbb153db90f"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("e1946084-4c69-4ae6-8266-4dca65f6de37"));
            UserInfo = (ITTTabPage)AddControl(new Guid("b3fc5ce0-d3a6-4b33-a9e8-0b6a11702abf"));
            ResUserUsableStores = (ITTGrid)AddControl(new Guid("92acb295-4f47-4d4f-b087-7a1757a6646c"));
            StoreResUserUsableStore = (ITTListBoxColumn)AddControl(new Guid("a9efcb82-df31-4375-8c3d-ee48c0edb8af"));
            labelWork = (ITTLabel)AddControl(new Guid("9bbf5835-3b1d-49ba-9e68-2215e28a4645"));
            Store = (ITTObjectListBox)AddControl(new Guid("ecb02f99-b52c-4f77-95ca-27edcb8cffcf"));
            UserResources = (ITTGrid)AddControl(new Guid("c0aea053-908b-49b0-8a98-8d13d83aa251"));
            SecMasterDepartment = (ITTListBoxColumn)AddControl(new Guid("269ed77a-5501-48d0-82c7-973f461af16f"));
            labelStore = (ITTLabel)AddControl(new Guid("14696afd-0984-4890-a1e1-0a472888cb3d"));
            labelWorkPlace = (ITTLabel)AddControl(new Guid("330df0c9-d1e8-40f7-9b97-212e1f979377"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("991a6f43-89a6-4e27-acb0-b69a57fee6c4"));
            WorkPlace = (ITTTextBox)AddControl(new Guid("3abb40ea-c81f-4456-9ea7-34b4f8b7492b"));
            ResUserPatientGroupTab = (ITTTabPage)AddControl(new Guid("1fe8a448-a7b8-4b82-b6a5-483d0dc549dd"));
            lblResUserPatientGroupMatch = (ITTLabel)AddControl(new Guid("cab3eb7d-0d8a-4e0c-a2ed-fb2365983681"));
            ResUserPatientGroupMatches = (ITTGrid)AddControl(new Guid("4858a8a8-2337-4fd4-ac2c-bdbc1ebd3f93"));
            PatientGroupResUserPatientGroupMatch = (ITTListBoxColumn)AddControl(new Guid("a38ceb16-0691-49e0-965b-e19d7e5a3c42"));
            IsAssignableResUserPatientGroupMatch = (ITTCheckBoxColumn)AddControl(new Guid("a49e07a1-f463-406a-aa95-5039267ef01c"));
            base.InitializeControls();
        }

        public ResUserForm() : base("RESUSER", "ResUserForm")
        {
        }

        protected ResUserForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}