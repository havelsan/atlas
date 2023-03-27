
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
    /// Person
    /// </summary>
    public partial class PersonForm : TTForm
    {
    /// <summary>
    /// KULLANILMIYOR
    /// </summary>
        protected TTObjectClasses.Person _Person
        {
            get { return (TTObjectClasses.Person)_ttObject; }
        }

        protected ITTObjectListBox TTListBox;
        protected ITTObjectListBox ULKE;
        protected ITTCheckBox BDYearOnly;
        protected ITTLabel labelName;
        protected ITTLabel labelSurname;
        protected ITTTextBox FatherName;
        protected ITTTextBox Name;
        protected ITTTextBox MotherName;
        protected ITTTextBox UniqueRefNo;
        protected ITTTextBox Surname;
        protected ITTLabel labelSex;
        protected ITTLabel labelMaritalStatus;
        protected ITTDateTimePicker BirthDate;
        protected ITTLabel labelUniqueRefNo;
        protected ITTLabel labelBirthDate;
        protected ITTLabel labelFatherName;
        protected ITTLabel labelMotherName;
        protected ITTEnumComboBox Sex;
        protected ITTLabel ttlabel10;
        override protected void InitializeControls()
        {
            TTListBox = (ITTObjectListBox)AddControl(new Guid("232b6e88-8dab-4ee3-9b7a-65c1f685e9f0"));
            ULKE = (ITTObjectListBox)AddControl(new Guid("6c9bb449-f6b4-4428-8bb6-006e4c2bb166"));
            BDYearOnly = (ITTCheckBox)AddControl(new Guid("236bc98f-e1e9-4548-8bca-09c5fa69cc9a"));
            labelName = (ITTLabel)AddControl(new Guid("71b0e07f-2d02-4cd1-9812-4c9b3d19d7bb"));
            labelSurname = (ITTLabel)AddControl(new Guid("27787677-207c-474a-a5f0-55f95290c684"));
            FatherName = (ITTTextBox)AddControl(new Guid("36f14fc4-e8c0-462f-b300-6a6ef86802f1"));
            Name = (ITTTextBox)AddControl(new Guid("da55ac98-ec27-4ad6-8865-8fe825a86b1c"));
            MotherName = (ITTTextBox)AddControl(new Guid("2fe701d0-3f33-4f4e-9d20-9814d06586e3"));
            UniqueRefNo = (ITTTextBox)AddControl(new Guid("b0d00994-7d55-4caa-b0b3-d6817cfbab6d"));
            Surname = (ITTTextBox)AddControl(new Guid("701dc372-cf7f-46eb-ba02-f0ce89312c8d"));
            labelSex = (ITTLabel)AddControl(new Guid("dd7ce731-ed13-402c-a4ec-6e4f3cc2c5ea"));
            labelMaritalStatus = (ITTLabel)AddControl(new Guid("72a6307e-4f56-4018-8063-7ac7fe1466cb"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("78833de2-a545-4d07-abb3-7c8656267d29"));
            labelUniqueRefNo = (ITTLabel)AddControl(new Guid("30666401-bc86-4ce8-a787-abd11de3c2c8"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("f63d2464-b3bb-4c79-af47-bd6afc34eab8"));
            labelFatherName = (ITTLabel)AddControl(new Guid("36430e10-63b9-42f5-9133-be5148575f55"));
            labelMotherName = (ITTLabel)AddControl(new Guid("068f13b2-cd13-48b7-a4d1-d76526986d38"));
            Sex = (ITTEnumComboBox)AddControl(new Guid("fb7b2273-204d-4e40-b762-dbf2a7033739"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("9df0b1a7-3cd6-4675-a421-ef24e2b9ab57"));
            base.InitializeControls();
        }

        public PersonForm() : base("PERSON", "PersonForm")
        {
        }

        protected PersonForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}