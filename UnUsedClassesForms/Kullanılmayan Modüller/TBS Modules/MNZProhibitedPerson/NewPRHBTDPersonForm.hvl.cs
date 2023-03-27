
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
    /// Yeni Yasaklı Kişi
    /// </summary>
    public partial class NewPRHBTDPersonForm : TTForm
    {
    /// <summary>
    /// Yasaklı Ziyaretçi
    /// </summary>
        protected TTObjectClasses.MNZProhibitedPerson _MNZProhibitedPerson
        {
            get { return (TTObjectClasses.MNZProhibitedPerson)_ttObject; }
        }

        protected ITTLabel labelDescription;
        protected ITTLabel labelName;
        protected ITTLabel labelNationalIdentity;
        protected ITTDateTimePicker BirthDate;
        protected ITTTextBox Surname;
        protected ITTTextBox HomePhone;
        protected ITTTextBox FatherName;
        protected ITTLabel labelCellPhone;
        protected ITTLabel labelBirthDate;
        protected ITTTextBox MotherName;
        protected ITTLabel labelSurname;
        protected ITTTextBox NationalIdentity;
        protected ITTTextBox CellPhone;
        protected ITTTextBox Name;
        protected ITTLabel labelHomePhone;
        protected ITTTextBox Description;
        protected ITTLabel labelFatherName;
        protected ITTLabel labelBannedDate;
        protected ITTLabel labelMotherName;
        protected ITTDateTimePicker dateTimePickerBannedDate;
        override protected void InitializeControls()
        {
            labelDescription = (ITTLabel)AddControl(new Guid("4170b39b-e526-4e3c-8549-0b6bbecad6d2"));
            labelName = (ITTLabel)AddControl(new Guid("ef65eb23-ed6a-40fd-be7c-cdc0df85a435"));
            labelNationalIdentity = (ITTLabel)AddControl(new Guid("8d5e3f48-06e6-4ca0-920f-c1c47d124253"));
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("76c17cc2-4af6-49f5-b3e7-edf88ac1230a"));
            Surname = (ITTTextBox)AddControl(new Guid("82f66c7a-c528-4a93-812d-c54a4f66848c"));
            HomePhone = (ITTTextBox)AddControl(new Guid("14e69394-10b3-4f76-9e74-9bd61e65fa1c"));
            FatherName = (ITTTextBox)AddControl(new Guid("32ce9bbc-0aad-4dea-8f14-8fd5e9107d72"));
            labelCellPhone = (ITTLabel)AddControl(new Guid("b0a28d91-df6c-47b8-8097-64de743905f3"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("4cff0c01-f6a0-4be8-a339-826c42e1d196"));
            MotherName = (ITTTextBox)AddControl(new Guid("68f0e0e2-1afd-419b-ae4d-4464b51b5b31"));
            labelSurname = (ITTLabel)AddControl(new Guid("27897c4a-120a-474c-8161-755481a35daa"));
            NationalIdentity = (ITTTextBox)AddControl(new Guid("42f4a94c-c99b-4f9b-b409-59a0d6b212dc"));
            CellPhone = (ITTTextBox)AddControl(new Guid("565b2c90-5e72-42e5-a988-31b24b58ab37"));
            Name = (ITTTextBox)AddControl(new Guid("ef689af0-e57e-49e5-ba45-386f4e560626"));
            labelHomePhone = (ITTLabel)AddControl(new Guid("e2abfcf8-b7ad-4dca-a383-226578c2b139"));
            Description = (ITTTextBox)AddControl(new Guid("5cc9f89c-5215-445e-b720-2841ba96bbfa"));
            labelFatherName = (ITTLabel)AddControl(new Guid("4d6a93f0-3bf3-480c-b3c7-3c1314798dcc"));
            labelBannedDate = (ITTLabel)AddControl(new Guid("c698e39d-ceb1-4f35-b54c-40b54d3f5ea2"));
            labelMotherName = (ITTLabel)AddControl(new Guid("1225e7ee-69a4-4141-9ce3-e3813fb4b076"));
            dateTimePickerBannedDate = (ITTDateTimePicker)AddControl(new Guid("6a5eb5e9-edd2-4b05-9b30-fb1667da0abc"));
            base.InitializeControls();
        }

        public NewPRHBTDPersonForm() : base("MNZPROHIBITEDPERSON", "NewPRHBTDPersonForm")
        {
        }

        protected NewPRHBTDPersonForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}