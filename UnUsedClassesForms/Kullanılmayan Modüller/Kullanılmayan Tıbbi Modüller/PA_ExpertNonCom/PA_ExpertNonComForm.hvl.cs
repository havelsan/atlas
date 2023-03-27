
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
    /// Uzman Erbaş Kabulü
    /// </summary>
    public partial class PA_ExpertNonComForm : PatientAdmissionForm
    {
    /// <summary>
    /// Uzman Erbaş Kabul 
    /// </summary>
        protected TTObjectClasses.PA_ExpertNonCom _PA_ExpertNonCom
        {
            get { return (TTObjectClasses.PA_ExpertNonCom)_ttObject; }
        }

        protected ITTObjectListBox assasmntDeptlst;
        protected ITTObjectListBox salaryPayLst;
        protected ITTLabel ttlabel833;
        protected ITTLabel ttlabel133;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel ttlabel3;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel ttlabel12;
        protected ITTObjectListBox MilitaryClass;
        protected ITTLabel ttlabel7;
        protected ITTLabel lableMilitaryUnit;
        protected ITTTextBox EmploymentRecordID;
        protected ITTLabel ttlabel4;
        protected ITTTextBox RetirementFundID;
        protected ITTTextBox HealtSlipNumber;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox Rank;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel10;
        protected ITTObjectListBox SenderChair;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox ForcesCommand;
        override protected void InitializeControls()
        {
            assasmntDeptlst = (ITTObjectListBox)AddControl(new Guid("cb158d97-1857-48e6-b9e6-a40292028651"));
            salaryPayLst = (ITTObjectListBox)AddControl(new Guid("53c16983-927f-477b-bfd7-c0241527460a"));
            ttlabel833 = (ITTLabel)AddControl(new Guid("75db4a66-aeb8-4925-a7f5-1a79e367e725"));
            ttlabel133 = (ITTLabel)AddControl(new Guid("a740782b-e0bd-46f6-a8d0-4fd1443dea00"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("637f6d66-b887-443e-8bab-0ab5288283cf"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("117b4359-cda3-4211-8b85-1081a24091b7"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("bb57f814-5fe0-4571-89f5-1fb198681267"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("a4901a9f-bebd-4baf-8de8-22c622e1d235"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("2c822ef8-7b5d-4643-9ae6-3676e382961d"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("502d9c63-32f3-42e5-a0ed-41c81fe7601e"));
            lableMilitaryUnit = (ITTLabel)AddControl(new Guid("811bd46a-21e9-4941-bcd9-42ca38c2fb7a"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("d057c54f-e200-426b-ac59-5d96051ae5fa"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("04feaffc-ea39-4226-b277-73638526259f"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("d4a9d180-fee9-41d5-9a5b-75e5b375e281"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("ef8acd07-c11c-46f4-94ed-7e32e7ec27f5"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("2f50b2de-fab7-4ab2-9e26-92efbc6eb66d"));
            Rank = (ITTObjectListBox)AddControl(new Guid("7fdddb60-05a8-400d-b265-92f40d95d44d"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("329f1b27-056f-41df-99f3-9dba58fb2e34"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("629f6204-ae1e-4066-8bd9-aef37ca4fabc"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("d05c3ef2-91ce-40c7-bcdb-b5614237c5ca"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("ca3edbd5-06f6-40b8-a0d8-b7e358e0e545"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("82a795e4-f58e-478f-ad1b-c4554b81b70b"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("3e6efee2-9e8a-441c-a00b-c63efb66e5d3"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("bcf1bc02-5a9b-438c-91d3-f22533d31917"));
            base.InitializeControls();
        }

        public PA_ExpertNonComForm() : base("PA_EXPERTNONCOM", "PA_ExpertNonComForm")
        {
        }

        protected PA_ExpertNonComForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}