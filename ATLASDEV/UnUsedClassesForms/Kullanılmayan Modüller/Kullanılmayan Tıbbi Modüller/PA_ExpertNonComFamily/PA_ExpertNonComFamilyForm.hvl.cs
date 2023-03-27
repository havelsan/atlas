
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
    /// Uzman Erbaş Ailesi Kabulü
    /// </summary>
    public partial class PA_ExpertNonComFamilyForm : PatientAdmissionForm
    {
    /// <summary>
    /// Uzman Erbaş Ailesi Kabul 
    /// </summary>
        protected TTObjectClasses.PA_ExpertNonComFamily _PA_ExpertNonComFamily
        {
            get { return (TTObjectClasses.PA_ExpertNonComFamily)_ttObject; }
        }

        protected ITTTextBox tttextbox1;
        protected ITTLabel labelDocumentNumber;
        protected ITTLabel ttlabel3;
        protected ITTDateTimePicker DocumentDate;
        protected ITTGroupBox FamilyInfo;
        protected ITTLabel labelHeadOfFamilyName;
        protected ITTTextBox HeadOfFamilyName;
        protected ITTObjectListBox ForcesCommand;
        protected ITTLabel ttlabel5;
        protected ITTLabel labelForcesCommand;
        protected ITTLabel labelEmploymentRecordID;
        protected ITTTextBox EmploymentRecordID;
        protected ITTMaskedTextBox HeadOfFamtxt;
        protected ITTObjectListBox ttobjectlistbox3;
        protected ITTObjectListBox salaryPayLst;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel133;
        protected ITTLabel ttlabel833;
        protected ITTLabel labelRank;
        protected ITTObjectListBox assasmntDeptlst;
        protected ITTObjectListBox Rank;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel labelMilitaryUnit;
        protected ITTLabel labelRetirementFundID;
        protected ITTTextBox RetirementFundID;
        protected ITTObjectListBox Relationship;
        protected ITTLabel labelRelationship;
        protected ITTLabel labelHealtSlipNumber;
        protected ITTTextBox HealtSlipNumber;
        override protected void InitializeControls()
        {
            tttextbox1 = (ITTTextBox)AddControl(new Guid("5dd62caf-33fd-4f31-aaec-450a4c2fe03e"));
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("96e47f0c-e319-45e5-b532-eac40183b299"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("3cd88027-2953-4d28-b879-2cca79eb8b99"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("2b114a02-b9be-42e8-98e4-4ea4d44a29ef"));
            FamilyInfo = (ITTGroupBox)AddControl(new Guid("d3fa80df-7938-4fd7-bb41-057633a313bd"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("fd9924dd-7f81-4a45-9329-49bf32059449"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("c0159e6d-e239-444e-b5e7-7a964a2fb22f"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("923c8140-ffbb-4f79-b317-0473adf7505c"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("ea93bbad-5054-4a96-a1f7-975c217ac631"));
            labelForcesCommand = (ITTLabel)AddControl(new Guid("6236b81d-0c6f-4869-b1cc-5e5cf9f984a4"));
            labelEmploymentRecordID = (ITTLabel)AddControl(new Guid("215a6964-799f-47d8-8c17-a0a341b252da"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("3e596d39-8cac-443f-a344-ae0885f3a55f"));
            HeadOfFamtxt = (ITTMaskedTextBox)AddControl(new Guid("daeadfaa-045f-45de-b020-5df88ac7d8b6"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("4acaed11-64af-4cdf-b110-efe721ea5c83"));
            salaryPayLst = (ITTObjectListBox)AddControl(new Guid("4dde44e8-b39e-4ed3-ade2-2ea070824bb9"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("473e1aaf-6063-46a8-b4fe-bfd41722f90f"));
            ttlabel133 = (ITTLabel)AddControl(new Guid("9775cf2c-b0cf-4724-bd80-ca20adcd0e11"));
            ttlabel833 = (ITTLabel)AddControl(new Guid("bb8a772e-7646-4222-963b-688ab4dbd26b"));
            labelRank = (ITTLabel)AddControl(new Guid("7aa5e8dd-69ca-49f6-ad51-859a7e02e483"));
            assasmntDeptlst = (ITTObjectListBox)AddControl(new Guid("5c6a0f2e-439c-4999-b46e-71846e6e2be1"));
            Rank = (ITTObjectListBox)AddControl(new Guid("d73d5c3c-8645-48f1-be4a-2d648da447e3"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("41d3a061-fd93-4909-90f0-808ee9b3af4e"));
            labelMilitaryUnit = (ITTLabel)AddControl(new Guid("79fefac9-c0c1-448c-aff2-5a19c8d9e9fe"));
            labelRetirementFundID = (ITTLabel)AddControl(new Guid("bde0371a-ffa7-4493-9765-9ba3864b24d6"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("9b02fbb0-0185-4665-bffc-6e448af45263"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("25490876-c15a-4ea7-8323-239f260f9abd"));
            labelRelationship = (ITTLabel)AddControl(new Guid("47167569-467a-40a5-8312-f9d56fa0f086"));
            labelHealtSlipNumber = (ITTLabel)AddControl(new Guid("cdcf6b7a-da2c-4a53-bc49-46c7402c1c32"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("03cde549-d5c1-4fa6-9a8e-b5ff7267ba21"));
            base.InitializeControls();
        }

        public PA_ExpertNonComFamilyForm() : base("PA_EXPERTNONCOMFAMILY", "PA_ExpertNonComFamilyForm")
        {
        }

        protected PA_ExpertNonComFamilyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}