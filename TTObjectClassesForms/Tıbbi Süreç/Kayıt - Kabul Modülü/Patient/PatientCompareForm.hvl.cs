
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
    public partial class PatientCompareForm : TTForm
    {
    /// <summary>
    /// Hasta
    /// </summary>
        protected TTObjectClasses.Patient _Patient
        {
            get { return (TTObjectClasses.Patient)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTObjectListBox SKRSMaritalStatus;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelNationality;
        protected ITTObjectListBox Nationality;
        protected ITTLabel labelExDate;
        protected ITTDateTimePicker ExDate;
        protected ITTLabel labelSex;
        protected ITTObjectListBox Sex;
        protected ITTLabel labelCityOfBirth;
        protected ITTObjectListBox CityOfBirth;
        protected ITTLabel labelSurname;
        protected ITTTextBox Surname;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelMotherName;
        protected ITTTextBox MotherName;
        protected ITTLabel labelFatherName;
        protected ITTTextBox FatherName;
        protected ITTLabel labelBirthDate;
        protected ITTDateTimePicker BirthDate;
        protected ITTGroupBox ttgroupbox2;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel5;
        protected ITTDateTimePicker ttdatetimepicker3;
        protected ITTObjectListBox ttobjectlistbox4;
        protected ITTTextBox tttextbox8;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel10;
        protected ITTTextBox tttextbox7;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTTextBox tttextbox6;
        protected ITTLabel ttlabel8;
        protected ITTTextBox tttextbox5;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel6;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("fc4fdcf9-1511-4a78-89b4-edd9c620798c"));
            SKRSMaritalStatus = (ITTObjectListBox)AddControl(new Guid("b9419f0d-a516-4bd9-8967-ed8371c853db"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("2c352385-c0d3-49e1-81c6-70ff1c7c5582"));
            labelNationality = (ITTLabel)AddControl(new Guid("40561e6d-3bf3-4706-bb38-95249950ca3b"));
            Nationality = (ITTObjectListBox)AddControl(new Guid("66d0e367-26b8-44a8-bb81-f3946a9a5a24"));
            labelExDate = (ITTLabel)AddControl(new Guid("de4f7d15-4388-429b-942c-dcbca8012b1d"));
            ExDate = (ITTDateTimePicker)AddControl(new Guid("e0851daa-c0f3-4b20-ab1d-d8e894024ce1"));
            labelSex = (ITTLabel)AddControl(new Guid("a20caf67-1732-40cb-a590-d62e4de9dd42"));
            Sex = (ITTObjectListBox)AddControl(new Guid("7ea976a8-a347-49e7-b20d-ca6b75260af4"));
            labelCityOfBirth = (ITTLabel)AddControl(new Guid("1eb07a7c-9ef2-41a3-a252-4f2d81a121ff"));
            CityOfBirth = (ITTObjectListBox)AddControl(new Guid("7486a845-0266-478e-84e1-2ad1f25bca02"));
            labelSurname = (ITTLabel)AddControl(new Guid("c995d83a-cf53-41e3-b938-f1318430add0"));
            Surname = (ITTTextBox)AddControl(new Guid("e0279623-2f7b-4cd1-a2fe-1b4385bcc154"));
            labelName = (ITTLabel)AddControl(new Guid("ab299111-5733-42fd-87ff-993b99eeca2f"));
            Name = (ITTTextBox)AddControl(new Guid("089b6e07-ce08-4b2d-a284-175ab475aa6d"));
            labelMotherName = (ITTLabel)AddControl(new Guid("b8bd7bfd-8a53-4f67-ba5a-ede01a8cfc6c"));
            MotherName = (ITTTextBox)AddControl(new Guid("fff1ca72-cca8-435f-9a1b-e333baff6da2"));
            labelFatherName = (ITTLabel)AddControl(new Guid("fed2bcbe-69b8-42d7-9500-d355130e3c4f"));
            FatherName = (ITTTextBox)AddControl(new Guid("94a34f78-0ac6-4961-b17f-c60ad59d4f94"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("08e48e54-27e8-467a-ba6c-318283402436"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("504e788f-4db6-4746-a455-262fc4f458e8"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("ca97eb64-22e9-45b9-8999-bf0b2c40d274"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("fcd16769-d85a-4911-af44-8b22b91af0cb"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("0614f0fd-84bc-413b-9748-dc1c32749877"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("6bf5f340-0a0c-48ab-bba9-107c3fcd62e8"));
            ttdatetimepicker3 = (ITTDateTimePicker)AddControl(new Guid("4b8510c5-fa93-49d2-8a49-a0059bd1717f"));
            ttobjectlistbox4 = (ITTObjectListBox)AddControl(new Guid("b708373a-fa82-4971-a85d-041e7d388b4a"));
            tttextbox8 = (ITTTextBox)AddControl(new Guid("9bdd6993-b6b7-491f-897e-7a1237975dd3"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("51f9b816-6702-47f3-991b-62f4e97ca405"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("0ebe9c16-1b71-41a1-94b2-c9a25ce21775"));
            tttextbox7 = (ITTTextBox)AddControl(new Guid("cb60284f-486e-492a-b21f-c53e69ddb5a9"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("70e5e008-48a2-4308-9dc2-e610e37db540"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("4e808165-396b-4b65-9196-d11fae169e5e"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("de2e6fb2-31fa-45de-8b80-41322f613a0e"));
            tttextbox6 = (ITTTextBox)AddControl(new Guid("588daa0c-1666-4b5a-b42b-0de8e1f66749"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("431e1308-12d0-4041-baf9-a3db92cb9296"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("6adbbe02-5b7a-47c8-9aa1-3eebf48e40cd"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("1ab1d263-2729-4ba1-bb3a-3f05a05dff67"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("a698259b-2c52-4182-9abc-7c5d4d017251"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("3909c816-6df4-4fa9-b9a7-99ad1df8779e"));
            base.InitializeControls();
        }

        public PatientCompareForm() : base("PATIENT", "PatientCompareForm")
        {
        }

        protected PatientCompareForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}