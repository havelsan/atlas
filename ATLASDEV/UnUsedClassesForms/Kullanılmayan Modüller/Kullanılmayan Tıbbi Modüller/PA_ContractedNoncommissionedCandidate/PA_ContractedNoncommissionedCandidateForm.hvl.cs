
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
    /// Sözleşmeli Astsubay Adayı
    /// </summary>
    public partial class PA_ContractedNoncommissionedCandidateForm : PatientAdmissionForm
    {
    /// <summary>
    /// Sözleşmeli Astsubay Adayı
    /// </summary>
        protected TTObjectClasses.PA_ContractedNoncommissionedCandidate _PA_ContractedNoncommissionedCandidate
        {
            get { return (TTObjectClasses.PA_ContractedNoncommissionedCandidate)_ttObject; }
        }

        protected ITTLabel labelDocumentNumber;
        protected ITTLabel labelSenderChair;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel labelDocumentDate;
        protected ITTTextBox DocumentNumber;
        protected ITTObjectListBox SenderChair;
        override protected void InitializeControls()
        {
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("6cef918d-1d2d-40cc-b77b-5c25081a3558"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("e5fedbfe-d585-4da1-bfeb-6e996b6f4979"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("4c145e4d-ca23-40f9-af0a-4db56a479d31"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("fd356d4f-01e6-45de-b8b3-cf93c009a9bf"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("d6238899-b579-460b-a4a4-9d1fe71e5add"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("7e3b5e02-4726-4c68-931c-44fe18e2c1b3"));
            base.InitializeControls();
        }

        public PA_ContractedNoncommissionedCandidateForm() : base("PA_CONTRACTEDNONCOMMISSIONEDCANDIDATE", "PA_ContractedNoncommissionedCandidateForm")
        {
        }

        protected PA_ContractedNoncommissionedCandidateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}