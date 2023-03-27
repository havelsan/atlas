
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
    /// Uzman Jandarma Ailesi Kabulü
    /// </summary>
    public partial class PA_ExpertGendarmeFamilyForm : PatientAdmissionForm
    {
    /// <summary>
    /// Uzman Jandarma Ailesi Kabul 
    /// </summary>
        protected TTObjectClasses.PA_ExpertGendarmeFamily _PA_ExpertGendarmeFamily
        {
            get { return (TTObjectClasses.PA_ExpertGendarmeFamily)_ttObject; }
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
            tttextbox1 = (ITTTextBox)AddControl(new Guid("20da08cf-c348-41e0-a37b-5d158569aa62"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("00a44e1e-9519-43bf-adbe-60ed3b716fe2"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("922edf62-2c20-4234-a60b-dd1734f14b95"));
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("fc0ddb63-691a-44b6-93cb-897980414f3b"));
            FamilyInfo = (ITTGroupBox)AddControl(new Guid("1d0b4136-6f48-4e4e-9c09-e8e824d2edae"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("dec509c0-2286-4ac0-adb6-d13202d17150"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("aef80722-abe2-44c5-a668-218d3ca1157b"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("1b894cb6-c144-4668-afb0-03d19cf6691d"));
            labelEmploymentRecordID = (ITTLabel)AddControl(new Guid("6e0344fb-3ead-4699-912a-dabfebffaa15"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("7441de89-0aae-44fe-a45c-4acb2db624fd"));
            HeadOfFamtxt = (ITTMaskedTextBox)AddControl(new Guid("766900ac-931c-41f7-aeb8-59c9a8d2eb24"));
            labelForcesCommand = (ITTLabel)AddControl(new Guid("aceed5ca-353a-4399-9feb-c9d81732a175"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("e32b6683-0dd2-4e6d-9f4f-158028636469"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("6d72bff4-541e-4d8e-961c-fdf2b037bae8"));
            salaryPayLst = (ITTObjectListBox)AddControl(new Guid("82e66afa-0a3a-42d0-91bd-15902102766a"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("0890f3f6-d767-477f-a3d3-21f22c7b8ffa"));
            ttlabel133 = (ITTLabel)AddControl(new Guid("cc4208a8-8b46-4f53-8ee3-65f546d28c21"));
            ttlabel833 = (ITTLabel)AddControl(new Guid("352b04b6-9a68-4521-9c76-9e65b8527661"));
            labelRank = (ITTLabel)AddControl(new Guid("7daee2dc-812e-499e-9407-401f404d7618"));
            assasmntDeptlst = (ITTObjectListBox)AddControl(new Guid("5641486d-c413-463d-8f86-1635bbf66b35"));
            Rank = (ITTObjectListBox)AddControl(new Guid("1fc23569-3762-4467-bfd9-28d307f15bdd"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("98128f74-29c6-455c-a5a1-569d45178da5"));
            labelMilitaryUnit = (ITTLabel)AddControl(new Guid("71c269f3-1dc0-4313-a6dd-d19f1710618b"));
            labelRetirementFundID = (ITTLabel)AddControl(new Guid("531008ad-5541-4961-8d3a-8b9f9bd0861a"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("902b94b5-e8f7-4429-9bf8-f3385195c199"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("9e072f1b-3b9a-4f0d-840c-09d753d9c08b"));
            labelRelationship = (ITTLabel)AddControl(new Guid("b7aa2773-f3b4-4924-88d1-0f437c13fa64"));
            labelHealtSlipNumber = (ITTLabel)AddControl(new Guid("99d68111-4491-4e38-a261-8446d99b9a8e"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("a09695a4-a91e-49e5-84a2-d93d2b320f93"));
            base.InitializeControls();
        }

        public PA_ExpertGendarmeFamilyForm() : base("PA_EXPERTGENDARMEFAMILY", "PA_ExpertGendarmeFamilyForm")
        {
        }

        protected PA_ExpertGendarmeFamilyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}