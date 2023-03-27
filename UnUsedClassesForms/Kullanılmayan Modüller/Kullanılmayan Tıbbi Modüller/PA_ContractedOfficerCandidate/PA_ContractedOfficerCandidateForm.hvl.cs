
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
    /// Sözleşmeli Subay Adayı
    /// </summary>
    public partial class PA_ContractedOfficerCandidateForm : PatientAdmissionForm
    {
    /// <summary>
    /// Sözleşmeli Subay Adayı
    /// </summary>
        protected TTObjectClasses.PA_ContractedOfficerCandidate _PA_ContractedOfficerCandidate
        {
            get { return (TTObjectClasses.PA_ContractedOfficerCandidate)_ttObject; }
        }

        protected ITTLabel labelDocumentNumber;
        protected ITTLabel labelSenderChair;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel labelDocumentDate;
        protected ITTTextBox DocumentNumber;
        protected ITTObjectListBox SenderChair;
        override protected void InitializeControls()
        {
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("7056ae75-43fa-4fc9-b1e6-73b1ed3b2daf"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("fbedad28-3f00-4208-8735-f8bb79b20a55"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("b4d8329a-3ae2-4672-9b46-2ee0bc38d5cf"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("1b45acc3-c424-492b-9460-62405f3e974d"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("ef19c1a8-a4fb-417d-8f25-9bc99ffe4c77"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("e9418be2-a779-45e8-9ff9-3594e83bbc68"));
            base.InitializeControls();
        }

        public PA_ContractedOfficerCandidateForm() : base("PA_CONTRACTEDOFFICERCANDIDATE", "PA_ContractedOfficerCandidateForm")
        {
        }

        protected PA_ContractedOfficerCandidateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}