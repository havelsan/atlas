
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
    /// Astsubay Kabulü
    /// </summary>
    public partial class PA_NoncommissionedOfficerForm : PatientAdmissionForm
    {
    /// <summary>
    /// Astsubay Kabul
    /// </summary>
        protected TTObjectClasses.PA_NoncommissionedOfficer _PA_NoncommissionedOfficer
        {
            get { return (TTObjectClasses.PA_NoncommissionedOfficer)_ttObject; }
        }

        protected ITTObjectListBox assasmntDeptlst;
        protected ITTObjectListBox salaryPayLst;
        protected ITTLabel ttlabel833;
        protected ITTLabel ttlabel133;
        protected ITTTextBox RetirementFundID;
        protected ITTLabel labelRetirementFundID;
        protected ITTLabel ttlabel7;
        protected ITTDateTimePicker DocumentDate;
        protected ITTObjectListBox ForcesCommand;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel6;
        protected ITTTextBox EmploymentRecordID;
        protected ITTObjectListBox Rank;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTTextBox HealtSlipNumber;
        protected ITTObjectListBox MilitaryClass;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox SenderChair;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel ttlabel10;
        override protected void InitializeControls()
        {
            assasmntDeptlst = (ITTObjectListBox)AddControl(new Guid("3ede626d-5dda-4b6b-8659-378be47a7b9f"));
            salaryPayLst = (ITTObjectListBox)AddControl(new Guid("bac2a972-0b90-47c1-8d7b-cb6de8841e97"));
            ttlabel833 = (ITTLabel)AddControl(new Guid("5fef1e24-8e7c-406f-b0dc-54c63fb6dde3"));
            ttlabel133 = (ITTLabel)AddControl(new Guid("346b81bb-fd63-4aaa-9247-151f535e040b"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("92ecdc01-0c70-4ae5-b125-30481d0d53a6"));
            labelRetirementFundID = (ITTLabel)AddControl(new Guid("0f1d8ac2-b29a-4d21-ac39-f11c945140fb"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("c162b0b0-cd0a-4998-bfa6-00f167e2b7f0"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("d89b9615-3722-470d-ae3e-31dc6cf775b9"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("a2d1b1ec-53f8-4562-9c4c-38370cd66857"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("1d9c7801-9713-494f-9fc6-561a0d98303f"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("74b87fbc-a992-4921-9d1a-69a8f4337a01"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("4813da42-8fed-405a-a9a4-76f74e427b35"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("ef906809-dee9-4a79-93e2-7b925dcd6307"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ce6669b6-2f2b-4eec-a9cf-83e6b24f605c"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("b22c645e-16cb-4ba6-94c2-8434fabdcb7b"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("fdd6e80e-be88-4b75-9863-8bb2ba70bb41"));
            Rank = (ITTObjectListBox)AddControl(new Guid("b6629563-31ff-4b44-926d-9d0b562db268"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("6cdcf674-895e-4c77-82ee-9ec820fa96cd"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("77e1b765-1568-4cf5-b208-9f7f33593080"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("fd6abe6d-c667-40e7-8419-a2b79c25ae55"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("19db1ee7-3a6f-4c64-a7c6-b0d1984f8299"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("3f79a636-5d50-4780-9741-c26bf672c730"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("0fcf7ce1-329b-42ef-a545-e94f0e2eac95"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("0f03d5bb-bf91-4dd3-9e65-ee966d2bed2c"));
            base.InitializeControls();
        }

        public PA_NoncommissionedOfficerForm() : base("PA_NONCOMMISSIONEDOFFICER", "PA_NoncommissionedOfficerForm")
        {
        }

        protected PA_NoncommissionedOfficerForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}