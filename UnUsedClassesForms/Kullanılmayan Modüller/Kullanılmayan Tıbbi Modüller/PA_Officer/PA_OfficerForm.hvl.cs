
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
    /// Subay Kabulü
    /// </summary>
    public partial class PA_OfficerForm : PatientAdmissionForm
    {
    /// <summary>
    /// Subay Kabul 
    /// </summary>
        protected TTObjectClasses.PA_Officer _PA_Officer
        {
            get { return (TTObjectClasses.PA_Officer)_ttObject; }
        }

        protected ITTObjectListBox assasmntDeptlst;
        protected ITTObjectListBox salaryPayLst;
        protected ITTLabel ttlabel833;
        protected ITTLabel ttlabel133;
        protected ITTObjectListBox Rank;
        protected ITTTextBox DocumentNumber;
        protected ITTDateTimePicker DocumentDate;
        protected ITTObjectListBox SenderChair;
        protected ITTObjectListBox MilitaryClass;
        protected ITTLabel labelSenderChair;
        protected ITTLabel labelDocumentDate;
        protected ITTObjectListBox ForcesCommand;
        protected ITTLabel lableMilitaryUnit;
        protected ITTLabel labelRetirementFundID;
        protected ITTLabel labelRank;
        protected ITTTextBox RetirementFundID;
        protected ITTLabel labelForcesCommand;
        protected ITTLabel labelMilitaryClass;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel labelEmploymentRecordID;
        protected ITTTextBox EmploymentRecordID;
        protected ITTLabel labelDocumentNumber;
        protected ITTLabel labelHealtSlipNumber;
        protected ITTTextBox HealtSlipNumber;
        override protected void InitializeControls()
        {
            assasmntDeptlst = (ITTObjectListBox)AddControl(new Guid("da92b90e-169b-41b8-b69a-80a013b1a4a1"));
            salaryPayLst = (ITTObjectListBox)AddControl(new Guid("8ff378b1-7ce8-40be-abee-c09c9604f630"));
            ttlabel833 = (ITTLabel)AddControl(new Guid("4d792626-db00-4c61-9542-9b20ed11fa6e"));
            ttlabel133 = (ITTLabel)AddControl(new Guid("379a1282-2913-4995-8e91-e5f8cfb1dc59"));
            Rank = (ITTObjectListBox)AddControl(new Guid("4a212dc4-f540-4775-b985-04be6d69b005"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("c0fda749-2ba6-41c4-b0d7-0a3863d92535"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("94c0c02c-3182-4a84-989d-326af20a5665"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("8acee1ac-eaa5-4954-88f8-3ad0231a894f"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("916d3427-575f-4fcd-9b65-4582b1589755"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("148858a2-0df3-4e33-b657-4b06b20751a8"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("5c581142-d8c2-4bb3-8d46-5b9791a40390"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("bea70852-4d42-4079-9a22-5c57179a0cd3"));
            lableMilitaryUnit = (ITTLabel)AddControl(new Guid("fdce111c-f16d-4e5f-b4bf-7412acf9b518"));
            labelRetirementFundID = (ITTLabel)AddControl(new Guid("10c84e6a-36d9-4457-b591-757fd32bfc72"));
            labelRank = (ITTLabel)AddControl(new Guid("111fbfc0-4a89-4e3a-a177-7a05586a63b7"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("8c3681fa-c5a4-40cc-9a23-84d242739b54"));
            labelForcesCommand = (ITTLabel)AddControl(new Guid("430e6130-f401-4ea0-a99c-86794bb23d54"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("9411b01b-5921-4085-89b6-87d60f0b4aad"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("f880c55d-c867-461f-8f20-8fddcceb7474"));
            labelEmploymentRecordID = (ITTLabel)AddControl(new Guid("7c4d274d-c851-4533-8891-8fed16c62214"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("e5b55f9a-36f1-44b6-b51a-afd126e1b035"));
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("9867e634-5187-4c0a-a523-c8e37a8d14fb"));
            labelHealtSlipNumber = (ITTLabel)AddControl(new Guid("f4f52bb4-f62b-4261-b305-ecdd911871b4"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("8b08ac89-e88d-45ee-8a08-f91a1a9288b4"));
            base.InitializeControls();
        }

        public PA_OfficerForm() : base("PA_OFFICER", "PA_OfficerForm")
        {
        }

        protected PA_OfficerForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}