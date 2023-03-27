
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
    /// Sivil Memur Ailesi Kabulü
    /// </summary>
    public partial class PA_MilitaryCivilOfficialFamilyForm : PatientAdmissionForm
    {
    /// <summary>
    /// Sivil Memur Ailesi Kabul 
    /// </summary>
        protected TTObjectClasses.PA_MilitaryCivilOfficialFamily _PA_MilitaryCivilOfficialFamily
        {
            get { return (TTObjectClasses.PA_MilitaryCivilOfficialFamily)_ttObject; }
        }

        protected ITTTextBox tttextbox1;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel labelDocumentDate;
        protected ITTLabel labelDocumentNumber;
        protected ITTGroupBox FamilyInfo;
        protected ITTLabel labelHeadOfFamilyName;
        protected ITTTextBox HeadOfFamilyName;
        protected ITTLabel labelMilitaryCivilOfficeStatus;
        protected ITTLabel ttlabel5;
        protected ITTEnumComboBox MilitaryCivilOfficeStatus;
        protected ITTLabel labelEmploymentRecordID;
        protected ITTTextBox EmploymentRecordID;
        protected ITTMaskedTextBox HeadOfFamtxt;
        protected ITTLabel labelForcesCommand;
        protected ITTObjectListBox ttobjectlistbox3;
        protected ITTObjectListBox ForcesCommand;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTObjectListBox salaryPayLst;
        protected ITTLabel labelMilitaryUnit;
        protected ITTLabel ttlabel133;
        protected ITTLabel ttlabel833;
        protected ITTLabel labelRetirementFundID;
        protected ITTObjectListBox assasmntDeptlst;
        protected ITTTextBox RetirementFundID;
        protected ITTObjectListBox Relationship;
        protected ITTLabel labelRelationship;
        protected ITTLabel labelHealtSlipNumber;
        protected ITTTextBox HealtSlipNumber;
        override protected void InitializeControls()
        {
            tttextbox1 = (ITTTextBox)AddControl(new Guid("544d628d-42e5-4690-ba58-068c22607a90"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("f8136686-14b4-41fa-893b-e2b12a96c2ee"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("5fc603af-a632-44be-9e53-1e97824065b6"));
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("08e89748-1d7b-4177-909e-5e759c6f6c5d"));
            FamilyInfo = (ITTGroupBox)AddControl(new Guid("7ac625ae-1a23-4deb-a27f-62a667cdb6cc"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("0d538624-d660-435b-9733-943befbe7d6b"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("c7a9a0de-3d89-4e24-a9a6-92ba33f1f9a9"));
            labelMilitaryCivilOfficeStatus = (ITTLabel)AddControl(new Guid("7e53d9cd-c49f-42bc-9fba-93f7156e7f3d"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("4455744c-6d15-40d9-bc4f-585cc75e5944"));
            MilitaryCivilOfficeStatus = (ITTEnumComboBox)AddControl(new Guid("53e14ee7-8325-4b9d-9231-20629494a595"));
            labelEmploymentRecordID = (ITTLabel)AddControl(new Guid("b0327519-bef1-4493-803f-9df094e68201"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("3d3ffd34-fde8-4123-ac69-1b132baaaac2"));
            HeadOfFamtxt = (ITTMaskedTextBox)AddControl(new Guid("fd74a26d-83f6-467c-828e-f3eddce63c95"));
            labelForcesCommand = (ITTLabel)AddControl(new Guid("98cf90cc-7b3c-4e67-bd21-5b67301c29b1"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("1a79d560-302f-423d-85ab-7bc689260768"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("4d5927a9-40f9-4806-a294-8e71c7359245"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("104621f3-bd56-4e1e-b6ad-bd67bdb49fc0"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("ec94f6b5-96d6-4a1e-8b9f-62e468fc9aba"));
            salaryPayLst = (ITTObjectListBox)AddControl(new Guid("b85b247c-a3fe-4d1a-bf47-17ddfb1ad3b5"));
            labelMilitaryUnit = (ITTLabel)AddControl(new Guid("b8b16db9-9b49-4699-9e61-e7a8a4732ea5"));
            ttlabel133 = (ITTLabel)AddControl(new Guid("6d20c882-a5c9-4755-96f5-e9c2d3e75674"));
            ttlabel833 = (ITTLabel)AddControl(new Guid("e2e7596e-75e2-4d52-b587-6c6889fad748"));
            labelRetirementFundID = (ITTLabel)AddControl(new Guid("2f061177-6a84-4b62-8d93-33adce395425"));
            assasmntDeptlst = (ITTObjectListBox)AddControl(new Guid("c4e5b583-bf7a-4df3-91f3-45c3d695fc9d"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("db871988-83fe-446e-b23f-c6dc31eaf59b"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("dffc2159-0d08-47b6-a40c-d5cb548d603f"));
            labelRelationship = (ITTLabel)AddControl(new Guid("b6bc5466-5554-419e-be59-9b5717e5d0ae"));
            labelHealtSlipNumber = (ITTLabel)AddControl(new Guid("cf644fc3-1bfa-4624-92e3-adf6802cfb32"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("d7b5e7c6-6a08-40e2-a47b-48a723ccf739"));
            base.InitializeControls();
        }

        public PA_MilitaryCivilOfficialFamilyForm() : base("PA_MILITARYCIVILOFFICIALFAMILY", "PA_MilitaryCivilOfficialFamilyForm")
        {
        }

        protected PA_MilitaryCivilOfficialFamilyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}