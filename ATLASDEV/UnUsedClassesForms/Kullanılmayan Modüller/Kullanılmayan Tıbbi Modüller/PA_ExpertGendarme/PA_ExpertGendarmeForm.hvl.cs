
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
    /// Uzman Jandarma Kabulü
    /// </summary>
    public partial class PA_ExpertGendarmeForm : PatientAdmissionForm
    {
    /// <summary>
    /// Uzman Jandarma Kabul 
    /// </summary>
        protected TTObjectClasses.PA_ExpertGendarme _PA_ExpertGendarme
        {
            get { return (TTObjectClasses.PA_ExpertGendarme)_ttObject; }
        }

        protected ITTLabel ttlabel9;
        protected ITTObjectListBox ForcesCommand;
        protected ITTObjectListBox assasmntDeptlst;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel7;
        protected ITTObjectListBox salaryPayLst;
        protected ITTTextBox HealtSlipNumber;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox SenderChair;
        protected ITTTextBox EmploymentRecordID;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel labelDocumentNumber;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTObjectListBox Rank;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox MilitaryClass;
        protected ITTTextBox RetirementFundID;
        protected ITTLabel ttlabel10;
        protected ITTLabel labelDocumentDate;
        protected ITTLabel lableMilitaryUnit;
        protected ITTLabel ttlabel5;
        override protected void InitializeControls()
        {
            ttlabel9 = (ITTLabel)AddControl(new Guid("4424bdbc-e722-4dc1-86a0-856f3dd17d0e"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("ea9a8df5-7254-4420-bb72-ab2fc2cd6ca5"));
            assasmntDeptlst = (ITTObjectListBox)AddControl(new Guid("353f0421-2f23-47f1-96f3-eaabc69547a4"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("3bc01631-e39d-4f1b-9831-89d87ad0b680"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("024d82dc-d315-42f5-8632-7f9a66b53847"));
            salaryPayLst = (ITTObjectListBox)AddControl(new Guid("c4f8b183-b002-42f4-ab7d-129c21aa1cc8"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("8ff2b2d7-4067-47b2-a2df-1288ba2f6475"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("a496d5eb-1ca7-40ae-9cfa-20b75ae90b1f"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("33622375-e7ed-4ae3-a253-27a844781ab3"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("cfbb7dc3-85f7-4cec-af77-2d8efc88d941"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("ff196b3d-3e80-4d46-a358-38d602ae00b5"));
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("9a60ac82-6367-43c4-b6ba-3b0071a411d2"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("49470b1c-4d9c-4a62-8017-4d22ed4fa32e"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("03ff2d61-960b-41d4-ab1e-55cd9277aef4"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("2e9bf3b6-d29f-498f-9f43-5fa3f11cb00f"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("bc474b76-d956-4fac-b9b8-8999bec0e354"));
            Rank = (ITTObjectListBox)AddControl(new Guid("87365921-15fa-4a42-a5fd-8e1aa40f8694"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("923b547c-6f41-4230-b0e6-9bc95e1c114f"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("7ff49540-28a1-4e4b-84ae-9f0b5f0120c8"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("cab1a7ca-819f-4098-b778-c7ef4f7eb34b"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("e55332b8-d778-48d8-855a-cc7b2e9dee57"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("b6af98dc-4ad4-4145-85c5-ccc432e2a314"));
            lableMilitaryUnit = (ITTLabel)AddControl(new Guid("3369ed64-9fca-43a8-bdc6-e2ffaabd03f8"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("22d31c85-db46-4ae0-bd76-ef7c370fa0b0"));
            base.InitializeControls();
        }

        public PA_ExpertGendarmeForm() : base("PA_EXPERTGENDARME", "PA_ExpertGendarmeForm")
        {
        }

        protected PA_ExpertGendarmeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}