
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
    /// Ayrılmış Sözleşmeli Subay
    /// </summary>
    public partial class DischargedContractedOfficerForm : PatientAdmissionForm
    {
    /// <summary>
    /// Ayrılmış Sözleşmeli Subay
    /// </summary>
        protected TTObjectClasses.PA_DischargedContractedOfficer _PA_DischargedContractedOfficer
        {
            get { return (TTObjectClasses.PA_DischargedContractedOfficer)_ttObject; }
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
        protected ITTLabel labelHealtSlipNumber;
        protected ITTTextBox RetirementFundID;
        protected ITTObjectListBox Rank;
        protected ITTLabel labelRetirementFundID;
        protected ITTLabel labelMilitaryClass;
        protected ITTLabel labelRank;
        protected ITTLabel labelEmploymentRecordID;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel labelSenderChair;
        protected ITTTextBox EmploymentRecordID;
        override protected void InitializeControls()
        {
            ttobjectlistboxForcesCommand = (ITTObjectListBox)AddControl(new Guid("cc6fb30a-27df-44e2-8d48-8096862170fb"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("abfd506c-0aca-4d11-abde-b85608e2aa0b"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("31e33f56-b0e8-49cf-8a10-1bd7844f464f"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("2e683466-a696-4af2-8287-c1f491659b57"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("94fe17c9-39f3-42f7-8595-411eef6f3c3d"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("ff689e07-dc89-4f29-bed5-0d051c5ab83c"));
            labelMilitaryUnit = (ITTLabel)AddControl(new Guid("ddaca2aa-e4b0-4d27-b47c-1cfb4591f80c"));
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("33f4be38-347c-4385-a75c-b5a7d8d57627"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("d153e113-c239-44d6-8eb7-a3473edba940"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("bfad17d8-c1d6-4366-ab70-5f7d207bf6e4"));
            labelHealtSlipNumber = (ITTLabel)AddControl(new Guid("ec59c458-ade1-4751-9c2a-92b20e5e48ed"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("2801f19d-d4d4-43c0-a66b-cc1f4d0da804"));
            Rank = (ITTObjectListBox)AddControl(new Guid("55be7637-2856-490e-9881-1e1e118546f1"));
            labelRetirementFundID = (ITTLabel)AddControl(new Guid("293c9855-2aca-4a82-9ba9-9c4ee26c47ea"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("a45cfc1b-1034-4941-ad77-b8670d4f6989"));
            labelRank = (ITTLabel)AddControl(new Guid("7b8603e8-a4ba-4f49-87b8-7b22f2f46119"));
            labelEmploymentRecordID = (ITTLabel)AddControl(new Guid("121d3c5d-1b0b-4fee-8948-891e2aa9b352"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("e6d0017e-3d77-4238-990e-a2e975608a00"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("ac76bab7-97d1-460a-bd82-e6ca9ce3b8eb"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("c228f1e6-1031-41b7-a080-afb0e8da6610"));
            base.InitializeControls();
        }

        public DischargedContractedOfficerForm() : base("PA_DISCHARGEDCONTRACTEDOFFICER", "DischargedContractedOfficerForm")
        {
        }

        protected DischargedContractedOfficerForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}