
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
    /// General/Amiral  Kabulü
    /// </summary>
    public partial class PA_GeneralAdmiralForm : PatientAdmissionForm
    {
    /// <summary>
    /// General/Amiral Kabul
    /// </summary>
        protected TTObjectClasses.PA_GeneralAdmiral _PA_GeneralAdmiral
        {
            get { return (TTObjectClasses.PA_GeneralAdmiral)_ttObject; }
        }

        protected ITTObjectListBox salaryPayLst;
        protected ITTLabel ttlabel266;
        protected ITTLabel ttlabel866;
        protected ITTObjectListBox assasmntDeptlst;
        protected ITTObjectListBox ttobjectlistbox3;
        protected ITTTextBox HealtSlipNumber;
        protected ITTLabel ttlabel5;
        protected ITTTextBox RetirementFundID;
        protected ITTLabel labelMilitaryUnit;
        protected ITTLabel labelRank;
        protected ITTLabel labelHealtSlipNumber;
        protected ITTLabel ttlabel2;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel labelEmploymentRecordID;
        protected ITTObjectListBox SenderChair;
        protected ITTLabel labelForcesCommand;
        protected ITTTextBox EmploymentRecordID;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTTextBox DocumentNumber;
        protected ITTObjectListBox Rank;
        protected ITTLabel labelSenderChair;
        protected ITTObjectListBox ForcesCommand;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelRetirementFundID;
        override protected void InitializeControls()
        {
            salaryPayLst = (ITTObjectListBox)AddControl(new Guid("d42fd8a7-e4f8-496f-8173-085963625cd1"));
            ttlabel266 = (ITTLabel)AddControl(new Guid("c173359b-e199-4020-86cf-1aeba04846ff"));
            ttlabel866 = (ITTLabel)AddControl(new Guid("8b2790f7-5d1a-4fd8-a509-19211747513f"));
            assasmntDeptlst = (ITTObjectListBox)AddControl(new Guid("9dc6a8c7-36a3-4075-a0e3-a08ae85fabb4"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("f7e056fc-928e-49a9-b888-3b560c24b641"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("11a9866b-87ee-4502-9aba-01d7898b3f6e"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("30df1b25-557a-4ab4-995e-1af40b08ced9"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("c5ff682e-94d0-421d-9ed7-03a45e441449"));
            labelMilitaryUnit = (ITTLabel)AddControl(new Guid("a893fb71-72be-4d83-a6cb-1c4924e65b1b"));
            labelRank = (ITTLabel)AddControl(new Guid("75467b46-4f43-4be9-b88d-28b0fef011cd"));
            labelHealtSlipNumber = (ITTLabel)AddControl(new Guid("f924cb33-cbb8-40f5-a7b1-315dd3c3020f"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("4beefe4e-cd4a-4271-95b3-33629404978c"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("840eb003-ea11-42dc-bb66-48fb81078268"));
            labelEmploymentRecordID = (ITTLabel)AddControl(new Guid("4d8a8ced-f34f-4992-af35-5d8ad7500a00"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("0e6f467f-e643-4574-8cc0-716c4c6c81f3"));
            labelForcesCommand = (ITTLabel)AddControl(new Guid("3f5e0b3e-ee5a-4745-984c-750055b0f691"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("c2890a7f-2d11-4918-9dce-86e0bd3080cf"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("552c86d6-8e2a-4f56-b7f0-876508edfbe7"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("16d26ea9-fdfe-4ade-9f4b-97ba3548f8e3"));
            Rank = (ITTObjectListBox)AddControl(new Guid("08a2e950-1729-4901-80ff-a49bdd697728"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("3bc03a61-362e-4b46-9f21-b384b5d95784"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("3f8aba7d-b01c-4f05-be65-c607c6fe7199"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("ce12ef12-17fb-45e6-b399-c81f242f9f3d"));
            labelRetirementFundID = (ITTLabel)AddControl(new Guid("d3b44b4d-c555-4cc9-9a52-ca30c0d1fde6"));
            base.InitializeControls();
        }

        public PA_GeneralAdmiralForm() : base("PA_GENERALADMIRAL", "PA_GeneralAdmiralForm")
        {
        }

        protected PA_GeneralAdmiralForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}