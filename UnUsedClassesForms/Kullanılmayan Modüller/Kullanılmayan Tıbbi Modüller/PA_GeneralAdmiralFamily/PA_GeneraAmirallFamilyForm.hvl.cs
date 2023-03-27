
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
    /// General/Amiral Ailesi Kabulü
    /// </summary>
    public partial class PA_GeneraAmirallFamilyForm : PatientAdmissionForm
    {
    /// <summary>
    /// Amiral/General Ailesi Kabul 
    /// </summary>
        protected TTObjectClasses.PA_GeneralAdmiralFamily _PA_GeneralAdmiralFamily
        {
            get { return (TTObjectClasses.PA_GeneralAdmiralFamily)_ttObject; }
        }

        protected ITTTextBox tttextbox1;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel labelDocumentDate;
        protected ITTLabel labelDocumentNumber;
        protected ITTGroupBox FamilyInfo;
        protected ITTLabel labelHeadOfFamilyName;
        protected ITTTextBox HeadOfFamilyName;
        protected ITTLabel ttlabel5;
        protected ITTLabel labelEmploymentRecordID;
        protected ITTTextBox EmploymentRecordID;
        protected ITTMaskedTextBox HeadOfFamtxt;
        protected ITTLabel labelForcesCommand;
        protected ITTObjectListBox ttobjectlistbox3;
        protected ITTObjectListBox ForcesCommand;
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
            tttextbox1 = (ITTTextBox)AddControl(new Guid("c1de5baa-9c76-4417-bc37-d65342f5ac4d"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("b73e88d0-92bf-49d3-8bc3-f27bfb455efa"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("f0eaa734-c6e8-4fa5-8eae-c512960bf6f0"));
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("26fd9455-7857-4960-8166-4ab0939242ec"));
            FamilyInfo = (ITTGroupBox)AddControl(new Guid("1bb6db42-7186-4cfe-be6c-770ce4119f4c"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("c6c9cc29-b17e-4b13-aee8-4de429d83499"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("3c842f6c-c340-4738-af5c-6ab41af35e81"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("9430f7b3-307a-4e1c-86d8-c5695e84069a"));
            labelEmploymentRecordID = (ITTLabel)AddControl(new Guid("e97a8db1-998a-42a3-8f86-96dd29c0c72b"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("6cbbb2e4-2ac3-4a35-b7c5-89312f3ac587"));
            HeadOfFamtxt = (ITTMaskedTextBox)AddControl(new Guid("49bcbec0-398b-4f94-b893-2d0ccc9ff497"));
            labelForcesCommand = (ITTLabel)AddControl(new Guid("ec469bdc-e8e2-4563-9eb1-6c4cb192fbab"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("a8b67e79-77bd-4763-8d51-d80cd275a823"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("f43b5155-c1eb-459d-8a74-4ab8c141772b"));
            salaryPayLst = (ITTObjectListBox)AddControl(new Guid("0a1a8509-af8c-415b-8d88-5843aeba9c26"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6b7abd05-1dc5-4a04-9370-8bd6790b0adf"));
            ttlabel133 = (ITTLabel)AddControl(new Guid("129dedad-4d83-4388-b77b-dacd6d31c690"));
            ttlabel833 = (ITTLabel)AddControl(new Guid("52c68771-a49d-428d-b00e-d09cef7d7fa6"));
            labelRank = (ITTLabel)AddControl(new Guid("5343a954-2e81-4416-8d98-f12d807ce3b3"));
            assasmntDeptlst = (ITTObjectListBox)AddControl(new Guid("15205ce4-363b-4ba8-b7db-5c712c5ef8bb"));
            Rank = (ITTObjectListBox)AddControl(new Guid("e436c898-5d1f-4bad-8816-9ac828a17e43"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("67227869-c251-4b93-8228-202059ca2f4e"));
            labelMilitaryUnit = (ITTLabel)AddControl(new Guid("73fe28ed-a69f-46f3-984b-0835c7a90c9f"));
            labelRetirementFundID = (ITTLabel)AddControl(new Guid("2fc94f55-ca14-45fa-a6e6-9b646a1beeac"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("ae4df6a5-620f-44a1-83a3-41734dbf8acd"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("b99dec56-e756-4a34-9c33-31374b903840"));
            labelRelationship = (ITTLabel)AddControl(new Guid("1533f94a-12dc-4082-8ba0-6312720e72d9"));
            labelHealtSlipNumber = (ITTLabel)AddControl(new Guid("c09b7505-4119-4289-b4e7-8bc4fc4e1176"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("f2340c2c-478a-4ded-99f8-d7a2012e648a"));
            base.InitializeControls();
        }

        public PA_GeneraAmirallFamilyForm() : base("PA_GENERALADMIRALFAMILY", "PA_GeneraAmirallFamilyForm")
        {
        }

        protected PA_GeneraAmirallFamilyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}