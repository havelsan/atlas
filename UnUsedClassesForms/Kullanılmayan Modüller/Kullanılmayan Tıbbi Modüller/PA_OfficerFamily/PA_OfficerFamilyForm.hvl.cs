
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
    /// Subay Ailesi Kabulü
    /// </summary>
    public partial class PA_OfficerFamilyForm : PatientAdmissionForm
    {
    /// <summary>
    /// Subay Ailesi Kabul 
    /// </summary>
        protected TTObjectClasses.PA_OfficerFamily _PA_OfficerFamily
        {
            get { return (TTObjectClasses.PA_OfficerFamily)_ttObject; }
        }

        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel9;
        protected ITTTextBox DocumentNumber;
        protected ITTDateTimePicker DocumentDate;
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
        protected ITTLabel ttlabel3;
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
            ttlabel2 = (ITTLabel)AddControl(new Guid("61a5abac-cba8-4ff1-9aaa-600595993c2d"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("94e562f4-4d9a-4b58-91a2-76b1a48689b3"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("dbb6b12e-bea8-4e4f-a8ab-df3ba9294a9a"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("afa98a3c-fa9b-481d-8808-b436a4f904b6"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("2d79e474-3f2b-40ec-a796-701cfd9c1d14"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("46a95fda-d829-4603-892a-7ff4f7480fbf"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("486b9c0d-aa2d-4e31-9f2a-cd9b7da18e3c"));
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("77936096-06ca-4544-a972-383f78ef132e"));
            FamilyInfo = (ITTGroupBox)AddControl(new Guid("00971fd4-2077-457e-9878-ff833b640a7f"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("5f880d70-f665-43e2-b9cd-fb5cc7651b9e"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("c3d94577-7674-4cd9-b1dc-ff86f357ff51"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("c7baa67a-f99c-46d3-be24-fbb80db6e4ad"));
            labelEmploymentRecordID = (ITTLabel)AddControl(new Guid("76cfcf3d-3b05-4911-b16b-89b573b011be"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("716296a0-4c9d-4065-a06d-d03efe482ae8"));
            HeadOfFamtxt = (ITTMaskedTextBox)AddControl(new Guid("716cf87c-5418-4425-8e94-014133174bac"));
            labelForcesCommand = (ITTLabel)AddControl(new Guid("325d8548-46f4-418f-a0d3-d3931ea1983f"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("ec303ea1-be20-41f4-bfec-3d033904e290"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("08afd939-fb12-4bf6-be66-a34b7c579513"));
            salaryPayLst = (ITTObjectListBox)AddControl(new Guid("c6354388-b399-4185-8d76-9e98fd24aa24"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("04132f66-a20e-4710-9d60-817b042b6a9d"));
            ttlabel133 = (ITTLabel)AddControl(new Guid("504989b5-b1f1-49d2-86a6-be2baa1fa834"));
            ttlabel833 = (ITTLabel)AddControl(new Guid("67b70e9e-4f88-4241-bb3b-d74bbac460e3"));
            labelRank = (ITTLabel)AddControl(new Guid("66376bd5-bb91-4c86-bc7b-bcbf4d488320"));
            assasmntDeptlst = (ITTObjectListBox)AddControl(new Guid("c483dff6-f133-424b-ab83-80654f23ecbd"));
            Rank = (ITTObjectListBox)AddControl(new Guid("10b4a853-e416-4fe0-9982-5e199f9f5bae"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("51eb9e7d-8d8f-4eca-bba5-2ebc8044b09f"));
            labelMilitaryUnit = (ITTLabel)AddControl(new Guid("aa322a7e-c764-4b1b-bbbc-ec4a98d49913"));
            labelRetirementFundID = (ITTLabel)AddControl(new Guid("102d7d14-1a10-4292-b73d-3673d9b80d0c"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("a7cef462-cb7a-4bc5-8162-34918a0d9d23"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("1beb66df-d828-4e8d-ae8e-52aa13225e6e"));
            labelRelationship = (ITTLabel)AddControl(new Guid("745ab97b-6331-4a9e-a6b4-f561d2727549"));
            labelHealtSlipNumber = (ITTLabel)AddControl(new Guid("b4b3d993-4640-460f-89e2-8f38d5b36374"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("afec1a43-433f-442c-b33a-dc4083d58d37"));
            base.InitializeControls();
        }

        public PA_OfficerFamilyForm() : base("PA_OFFICERFAMILY", "PA_OfficerFamilyForm")
        {
        }

        protected PA_OfficerFamilyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}