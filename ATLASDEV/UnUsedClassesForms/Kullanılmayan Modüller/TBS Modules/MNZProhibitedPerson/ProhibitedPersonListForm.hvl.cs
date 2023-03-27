
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
    /// Yasaklı Kişi Listesi
    /// </summary>
    public partial class ProhibitedPersonList : TTForm
    {
    /// <summary>
    /// Yasaklı Ziyaretçi
    /// </summary>
        protected TTObjectClasses.MNZProhibitedPerson _MNZProhibitedPerson
        {
            get { return (TTObjectClasses.MNZProhibitedPerson)_ttObject; }
        }

        protected ITTDateTimePicker BirthDate;
        protected ITTLabel labelNationalIdentity;
        protected ITTLabel labelFatherName;
        protected ITTGrid ttgrid1;
        protected ITTTextBox Name;
        protected ITTTextBox FatherName;
        protected ITTLabel labelSurname;
        protected ITTLabel labelMotherName;
        protected ITTLabel labelName;
        protected ITTLabel labelBirthDate;
        protected ITTTextBox Surname;
        protected ITTTextBox NationalIdentity;
        protected ITTTextBox MotherName;
        override protected void InitializeControls()
        {
            BirthDate = (ITTDateTimePicker)AddControl(new Guid("61dd58a5-fbc4-42ad-802c-2ba42f5df9d0"));
            labelNationalIdentity = (ITTLabel)AddControl(new Guid("3f40e4de-2154-4671-a349-1f6a395918d5"));
            labelFatherName = (ITTLabel)AddControl(new Guid("f9ee47ce-8d10-4853-90bc-1bffaa18272a"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("7307630c-cb82-44c7-b5dd-6492fb323ab7"));
            Name = (ITTTextBox)AddControl(new Guid("10015ff3-a70f-4105-ab64-6991d8517715"));
            FatherName = (ITTTextBox)AddControl(new Guid("a3c3b976-b289-4b5f-b746-9c7ad146e3e1"));
            labelSurname = (ITTLabel)AddControl(new Guid("5d180686-7107-41a8-b61c-8e0793977fd0"));
            labelMotherName = (ITTLabel)AddControl(new Guid("d4b6a7ab-7957-4988-8532-b946199697ee"));
            labelName = (ITTLabel)AddControl(new Guid("997f8def-1aec-4cc5-801f-ba58f729b85b"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("3cc50dfc-d2be-483e-bd1e-aefb6271de11"));
            Surname = (ITTTextBox)AddControl(new Guid("3a9f8246-189f-4bad-b67d-d25cddb866d8"));
            NationalIdentity = (ITTTextBox)AddControl(new Guid("536417c1-b290-4827-b735-f02769eb5fd1"));
            MotherName = (ITTTextBox)AddControl(new Guid("8620fb1c-d29a-45ae-89b8-f04d21531a60"));
            base.InitializeControls();
        }

        public ProhibitedPersonList() : base("MNZPROHIBITEDPERSON", "ProhibitedPersonList")
        {
        }

        protected ProhibitedPersonList(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}