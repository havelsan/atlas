
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
    /// Sivil Memur Kabulü
    /// </summary>
    public partial class PA_MilitaryCivilOfficialForm : PatientAdmissionForm
    {
    /// <summary>
    /// Sivil Memur Kabulü
    /// </summary>
        protected TTObjectClasses.PA_MilitaryCivilOfficial _PA_MilitaryCivilOfficial
        {
            get { return (TTObjectClasses.PA_MilitaryCivilOfficial)_ttObject; }
        }

        protected ITTLabel labelMilitaryCivilOfficeStatus;
        protected ITTEnumComboBox MilitaryCivilOfficeStatus;
        protected ITTObjectListBox salaryPayLst;
        protected ITTLabel ttlabel833;
        protected ITTLabel ttlabel133;
        protected ITTObjectListBox assasmntDeptlst;
        protected ITTLabel ttlabel5;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel labelForcesCommand;
        protected ITTObjectListBox ForcesCommand;
        protected ITTLabel labelMilitaryUnit;
        protected ITTTextBox EmploymentRecordID;
        protected ITTDateTimePicker DocumentDate;
        protected ITTObjectListBox SenderChair;
        protected ITTTextBox HealtSlipNumber;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox MilitaryClass;
        protected ITTLabel ttlabel6;
        protected ITTLabel labelSenderChair;
        protected ITTLabel labelMilitaryClass;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        protected ITTTextBox RetirementFundID;
        override protected void InitializeControls()
        {
            labelMilitaryCivilOfficeStatus = (ITTLabel)AddControl(new Guid("fac8c317-1258-4b5f-821a-e3f5802d0104"));
            MilitaryCivilOfficeStatus = (ITTEnumComboBox)AddControl(new Guid("b24fbb09-2f80-4d2d-a35a-b5e2d081fb98"));
            salaryPayLst = (ITTObjectListBox)AddControl(new Guid("dd4cfd52-593a-40ab-9229-596bbb45a520"));
            ttlabel833 = (ITTLabel)AddControl(new Guid("47933020-c17d-4026-9c24-cf1deae3abee"));
            ttlabel133 = (ITTLabel)AddControl(new Guid("898bd20d-5324-4b12-b9be-45747de48814"));
            assasmntDeptlst = (ITTObjectListBox)AddControl(new Guid("e418850d-f418-42ff-b626-9c766f88cb26"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("7d6ff8cc-07e6-4d4f-a0d7-180761b6900e"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("f8c0f54f-278b-4b40-95e4-2433119a7916"));
            labelForcesCommand = (ITTLabel)AddControl(new Guid("fbbdc72f-f36d-46b6-9b2c-40cf0709b25d"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("430d94c2-ea8e-41fa-a642-89b6fff829ff"));
            labelMilitaryUnit = (ITTLabel)AddControl(new Guid("fc3317aa-03db-4e61-b551-2a78f0f4202b"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("a6140d10-1732-458a-833e-326ec2dab125"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("680d7c47-3af1-45b5-a094-3bd265669a4c"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("e388a5cf-d2f8-41e2-b4a5-49f7c043544d"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("71c8d284-cce6-4579-8ac2-5b606aead1f2"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("fd3b7669-e7ba-44f7-8a5e-6686a6ccc6bb"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("a4e27e88-1df2-483a-8ac3-69a9bf4c5c1b"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("57df73fe-c47c-40ce-af07-7f778ba61d98"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("f73ee34b-f1d4-4606-ae46-8bb199972566"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("603b5ae0-488f-4720-993d-b20bffa9eb09"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("ac7f34d2-e587-4a64-87cc-c26af8900b5e"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("172a07aa-d48b-460b-bc9a-ce6138149877"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("4f5d15c2-5eef-49e7-813c-e8d2d742f404"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("bc3401c0-b453-4239-b505-f84331329825"));
            base.InitializeControls();
        }

        public PA_MilitaryCivilOfficialForm() : base("PA_MILITARYCIVILOFFICIAL", "PA_MilitaryCivilOfficialForm")
        {
        }

        protected PA_MilitaryCivilOfficialForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}