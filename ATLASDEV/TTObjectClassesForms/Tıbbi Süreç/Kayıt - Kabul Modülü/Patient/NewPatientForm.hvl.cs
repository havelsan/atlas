
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
    public partial class NewPatientForm : TTForm
    {
    /// <summary>
    /// Hasta
    /// </summary>
        protected TTObjectClasses.Patient _Patient
        {
            get { return (TTObjectClasses.Patient)_ttObject; }
        }

        protected ITTObjectListBox OzurlulukDurumuList;
        protected ITTLabel ttlabel4;
        protected ITTTextBox DonorUniqueRefNo;
        protected ITTTextBox BirthPlace;
        protected ITTTextBox PrivacySurname;
        protected ITTTextBox PrivacyName;
        protected ITTTextBox UniqueRefNo;
        protected ITTTextBox Name;
        protected ITTTextBox MobilePhone;
        protected ITTTextBox Surname;
        protected ITTTextBox FatherName;
        protected ITTTextBox MotherName;
        protected ITTTextBox ForeignUniqueNo;
        protected ITTTextBox HomeAddress;
        protected ITTTextBox PassportNo;
        protected ITTTextBox tttextbox10;
        protected ITTTextBox RelativeHomeAddress;
        protected ITTTextBox WorkAddress;
        protected ITTTextBox WorkPhone;
        protected ITTTextBox RelativeFullName;
        protected ITTTextBox RelativeMobilePhone;
        protected ITTTextBox ImportantPAInfo;
        protected ITTTextBox OtherBirthPlace;
        protected ITTTextBox HakSahibiTC;
        protected ITTTextBox HakSahibiAdSoyad;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox SKRSMaritalStatus;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker PrivacyEndDate;
        protected ITTCheckBox Privacy;
        protected ITTLabel ttlabel25;
        protected ITTLabel ttlabel24;
        protected ITTLabel labelUniqueRefNo;
        protected ITTLabel labelName;
        protected ITTLabel labelBirthDate;
        protected ITTDateTimePicker BirthDate;
        protected ITTLabel ttlabel35;
        protected ITTLabel labelSex;
        protected ITTObjectListBox Sex;
        protected ITTLabel ttlabel26;
        protected ITTLabel labelSurname;
        protected ITTLabel labelFatherName;
        protected ITTLabel ttlabel28;
        protected ITTLabel ttlabel62;
        protected ITTObjectListBox Nationality;
        protected ITTLabel ttlabel17;
        protected ITTLabel lblAdres;
        protected ITTLabel ttlabel66;
        protected ITTLabel ttlabel22;
        protected ITTObjectListBox Occupation;
        protected ITTLabel ttlabel7;
        protected ITTLabel lblRelativeHomeAddress;
        protected ITTLabel ttlabel5;
        protected ITTLabel lblRelativeFullname;
        protected ITTLabel lblRelativeMobilePhone;
        protected ITTLabel ttlabel20;
        protected ITTObjectListBox EducationStatus;
        protected ITTLabel ttlabel12;
        protected ITTObjectListBox SKRSYabanciHastaTuruListBox;
        protected ITTLabel labelBloodGroup;
        protected ITTObjectListBox BloodGroupType;
        override protected void InitializeControls()
        {
            OzurlulukDurumuList = (ITTObjectListBox)AddControl(new Guid("991ea658-a2be-41ca-9993-1ff079ccb442"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("706f460e-3197-480b-9ba3-55671a057c9b"));
            DonorUniqueRefNo = (ITTTextBox)AddControl(new Guid("767e8864-07e4-4cbf-ad69-73ab90b12055"));
            BirthPlace = (ITTTextBox)AddControl(new Guid("83074b2b-7a4a-45fc-b6c2-b75bd56140ae"));
            PrivacySurname = (ITTTextBox)AddControl(new Guid("cd37d09f-1925-4a74-bc3a-9def732fa460"));
            PrivacyName = (ITTTextBox)AddControl(new Guid("5d3ee25c-fbd9-4cbe-91e4-63e253e9e172"));
            UniqueRefNo = (ITTTextBox)AddControl(new Guid("5db46911-e9e3-4a72-b120-32e8e1143f8c"));
            Name = (ITTTextBox)AddControl(new Guid("63428138-8768-4753-9d5c-fd29991859b8"));
            MobilePhone = (ITTTextBox)AddControl(new Guid("b7c1291b-3cd9-4f45-abc0-bc5fc12251c3"));
            Surname = (ITTTextBox)AddControl(new Guid("c60c8a13-5e19-47cf-b90f-d0a9e7f59238"));
            FatherName = (ITTTextBox)AddControl(new Guid("eeab0928-a39f-4bc1-ac4a-1747eb67b5be"));
            MotherName = (ITTTextBox)AddControl(new Guid("f3638c13-2748-4dac-b732-47b7485bf4b7"));
            ForeignUniqueNo = (ITTTextBox)AddControl(new Guid("544189a5-fc33-499f-a957-1dd0e59ad9f2"));
            HomeAddress = (ITTTextBox)AddControl(new Guid("ca792afd-550b-4a50-a5f4-9f0d343f4c99"));
            PassportNo = (ITTTextBox)AddControl(new Guid("5fa73f8d-f4f6-4a88-8625-ad29ca5960c3"));
            tttextbox10 = (ITTTextBox)AddControl(new Guid("f0a5c0a8-3147-4347-9802-d27a3832e702"));
            RelativeHomeAddress = (ITTTextBox)AddControl(new Guid("206d8dff-86e8-4fb5-a178-4fbfdca51af2"));
            WorkAddress = (ITTTextBox)AddControl(new Guid("d238e329-aead-4a8b-a541-a9a48896921f"));
            WorkPhone = (ITTTextBox)AddControl(new Guid("ce8e3231-2369-4e4b-b4f8-a4ca44ba9aab"));
            RelativeFullName = (ITTTextBox)AddControl(new Guid("cb7975ee-60a3-49fb-9312-74083b878785"));
            RelativeMobilePhone = (ITTTextBox)AddControl(new Guid("9d5e3e41-b62e-47e5-8900-e978224a9f6a"));
            ImportantPAInfo = (ITTTextBox)AddControl(new Guid("88328beb-840e-48ce-9acf-00db3bfd0bf4"));
            OtherBirthPlace = (ITTTextBox)AddControl(new Guid("bde1fef9-628d-4de4-9ae6-0e5d3a03811a"));
            HakSahibiTC = (ITTTextBox)AddControl(new Guid("aefbed01-d965-4a03-91ba-222c30bab184"));
            HakSahibiAdSoyad = (ITTTextBox)AddControl(new Guid("de035d59-6632-44e5-a6c9-3c16a6d1e877"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("28c558b8-d9ab-437b-acc6-53d9fc17c78e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6b400717-3e85-4350-8285-2e65b4add1bf"));
            SKRSMaritalStatus = (ITTObjectListBox)AddControl(new Guid("a84da1ae-1902-476c-89dc-d9386aa602c0"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("de7314c4-dfce-4d7f-a3fe-15713b8c16ea"));
            PrivacyEndDate = (ITTDateTimePicker)AddControl(new Guid("61d996aa-23b6-42aa-8721-5d5306a87815"));
            Privacy = (ITTCheckBox)AddControl(new Guid("5e9a54ef-9e56-48b6-b5a8-21816d9c74a3"));
            ttlabel25 = (ITTLabel)AddControl(new Guid("230b2d36-9cf7-4056-889c-8d3ea4190b7e"));
            ttlabel24 = (ITTLabel)AddControl(new Guid("636413af-0362-44c4-9fda-be2fb81c307f"));
            labelUniqueRefNo = (ITTLabel)AddControl(new Guid("57481f96-ea5d-4485-b3fb-2d8a150a76f5"));
            labelName = (ITTLabel)AddControl(new Guid("eac67c99-655f-40b6-94a3-40441537f264"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("9adc9cb0-fb89-49ca-93d7-0be772e0e7b4"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("c73ed71f-4b2c-4464-b003-eb9ead36dc6e"));
            ttlabel35 = (ITTLabel)AddControl(new Guid("a63b7206-2a4e-45b3-9967-3385d9913a8b"));
            labelSex = (ITTLabel)AddControl(new Guid("6272080c-207b-4f88-9108-7c9b8d36fa1e"));
            Sex = (ITTObjectListBox)AddControl(new Guid("9cc947ab-b3e1-4051-8da5-7568c24a69b8"));
            ttlabel26 = (ITTLabel)AddControl(new Guid("5fe4aac7-f1ba-4e49-9bc5-cdccbfd9b16d"));
            labelSurname = (ITTLabel)AddControl(new Guid("d36de80a-ae8c-4592-9fad-b9b58da47344"));
            labelFatherName = (ITTLabel)AddControl(new Guid("06a2530e-2675-4ab5-a910-37fbf7615409"));
            ttlabel28 = (ITTLabel)AddControl(new Guid("856fb52f-f39e-4ef9-957f-f31c96cd6988"));
            ttlabel62 = (ITTLabel)AddControl(new Guid("6f63ac7d-c792-47e7-a4d0-0f14aca85e20"));
            Nationality = (ITTObjectListBox)AddControl(new Guid("03f97666-87b9-46c0-b6dd-55d20170e9f3"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("038f8558-4966-4943-906c-2ea7e06f62a9"));
            lblAdres = (ITTLabel)AddControl(new Guid("f053154a-7211-42db-9e91-6f91bbadf69a"));
            ttlabel66 = (ITTLabel)AddControl(new Guid("a69d3b45-19da-408d-be80-a61874340113"));
            ttlabel22 = (ITTLabel)AddControl(new Guid("993dbef5-5778-4545-9a49-7f936b91889e"));
            Occupation = (ITTObjectListBox)AddControl(new Guid("1e4e5576-f403-4c72-9e90-bdd2d4e4493d"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("3b43ae07-bffa-4b78-8a57-c255dc356f78"));
            lblRelativeHomeAddress = (ITTLabel)AddControl(new Guid("422bc916-df30-4c7e-b4ef-5ba1b826fa5d"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("f98dc805-5870-4a8e-89d5-ce492f3f751f"));
            lblRelativeFullname = (ITTLabel)AddControl(new Guid("d544f432-f720-4dfb-9dec-b2ca3cdc5975"));
            lblRelativeMobilePhone = (ITTLabel)AddControl(new Guid("9184e576-48ef-4f03-a1e5-bd795223e3d9"));
            ttlabel20 = (ITTLabel)AddControl(new Guid("2e672610-5c54-4cd4-bbcd-97ea4de9da7f"));
            EducationStatus = (ITTObjectListBox)AddControl(new Guid("90429bb7-7e12-4f03-a039-951ce23597c0"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("f53cc5cf-61a4-4a62-909f-6525a2e2570a"));
            SKRSYabanciHastaTuruListBox = (ITTObjectListBox)AddControl(new Guid("6e4e2196-a07f-49cb-812c-5370730bd379"));
            labelBloodGroup = (ITTLabel)AddControl(new Guid("5a9fe915-368b-4782-ac40-c1ff3616e232"));
            BloodGroupType = (ITTObjectListBox)AddControl(new Guid("4c326841-609a-4b88-82f1-7d68385296d9"));
            base.InitializeControls();
        }

        public NewPatientForm() : base("PATIENT", "NewPatientForm")
        {
        }

        protected NewPatientForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}