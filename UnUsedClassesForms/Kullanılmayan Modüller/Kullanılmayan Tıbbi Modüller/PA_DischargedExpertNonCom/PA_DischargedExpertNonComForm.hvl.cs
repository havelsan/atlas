
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
    /// Ayrılmış Uzman Erbaş Kabul
    /// </summary>
    public partial class PA_DischargedExpertNonComForm : PatientAdmissionForm
    {
    /// <summary>
    /// Ayrılmış Uzman Erbaş Kabul 
    /// </summary>
        protected TTObjectClasses.PA_DischargedExpertNonCom _PA_DischargedExpertNonCom
        {
            get { return (TTObjectClasses.PA_DischargedExpertNonCom)_ttObject; }
        }

        protected ITTObjectListBox ttobjectlistboxForcesCommand;
        protected ITTLabel ttlabel2;
        protected ITTTextBox HealtSlipNumber;
        protected ITTDateTimePicker DocumentDate;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel labelDocumentDate;
        protected ITTLabel labelMilitaryUnit;
        protected ITTLabel labelDocumentNumber;
        protected ITTObjectListBox SenderChair;
        protected ITTObjectListBox MilitaryClass;
        protected ITTTextBox RetirementFundID;
        protected ITTLabel labelRetirementFundID;
        protected ITTLabel labelRank;
        protected ITTTextBox DocumentNumber;
        protected ITTTextBox EmploymentRecordID;
        protected ITTLabel labelSenderChair;
        protected ITTLabel labelEmploymentRecordID;
        protected ITTLabel labelMilitaryClass;
        protected ITTObjectListBox Rank;
        protected ITTLabel labelHealtSlipNumber;
        override protected void InitializeControls()
        {
            ttobjectlistboxForcesCommand = (ITTObjectListBox)AddControl(new Guid("a8769eec-2420-4796-9edf-4a6d16505812"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("29d37339-8228-47f4-96d0-e7a29b8841b1"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("78c17aac-0c81-43f3-b92f-02e812f4cba5"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("51d5bb37-43a3-4612-8ac4-0b8573fce300"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("43e7cf57-597c-4a8a-8943-191a82ec7d2a"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("b557c25d-eaa5-4663-bdad-45c21afc3b5b"));
            labelMilitaryUnit = (ITTLabel)AddControl(new Guid("b2b2f3bc-67cc-46cf-97ef-4daf278f8f1a"));
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("099482f4-2bbd-4a69-8ac3-553179d41dd1"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("acb5a5ca-96c3-4f58-8a54-58d40e78c88e"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("e8d6571a-16ea-4df7-a4f8-61cd32d2b3bb"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("67203a1d-e637-4181-a307-825ecc41f78d"));
            labelRetirementFundID = (ITTLabel)AddControl(new Guid("c02573fb-dd3d-48d7-a7b7-83dc56b2a464"));
            labelRank = (ITTLabel)AddControl(new Guid("7989311c-66b2-42b7-b3f1-8a0b3b3fc254"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("395d5cb7-f21a-4847-a927-8a0ea536c460"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("c529ea9e-3556-4236-aac8-a4411b2d1e53"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("09512edf-62f3-425a-996a-abbe7e451c62"));
            labelEmploymentRecordID = (ITTLabel)AddControl(new Guid("852da7a7-8792-4deb-8ef0-aeb8c56021f2"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("8bcfafdc-6af2-467b-ac68-b6ffac0bd1b6"));
            Rank = (ITTObjectListBox)AddControl(new Guid("e192c22d-72a9-4828-a676-e59247e6df2f"));
            labelHealtSlipNumber = (ITTLabel)AddControl(new Guid("bc620b08-068b-43b3-813b-f881a2ca8982"));
            base.InitializeControls();
        }

        public PA_DischargedExpertNonComForm() : base("PA_DISCHARGEDEXPERTNONCOM", "PA_DischargedExpertNonComForm")
        {
        }

        protected PA_DischargedExpertNonComForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}