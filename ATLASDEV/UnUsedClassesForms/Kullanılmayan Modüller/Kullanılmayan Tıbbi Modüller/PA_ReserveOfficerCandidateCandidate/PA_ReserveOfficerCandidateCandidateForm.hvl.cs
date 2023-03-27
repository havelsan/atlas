
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
    public partial class PA_ReserveOfficerCandidateCandidateForm : PatientAdmissionForm
    {
    /// <summary>
    /// Yedek Subay Aday Adayı  Kabul 
    /// </summary>
        protected TTObjectClasses.PA_ReserveOfficerCandidateCandidate _PA_ReserveOfficerCandidateCandidate
        {
            get { return (TTObjectClasses.PA_ReserveOfficerCandidateCandidate)_ttObject; }
        }

        protected ITTLabel labelDocumentNumber;
        protected ITTObjectListBox MilitaryOffice;
        protected ITTLabel labelMilitaryOffice;
        protected ITTLabel labelSenderChair;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel labelDocumentDate;
        protected ITTTextBox DocumentNumber;
        protected ITTObjectListBox SenderChair;
        override protected void InitializeControls()
        {
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("eee1cccf-aaca-4922-bef3-e22947962c3e"));
            MilitaryOffice = (ITTObjectListBox)AddControl(new Guid("1ca47a79-4e10-4227-a508-7f7f57788366"));
            labelMilitaryOffice = (ITTLabel)AddControl(new Guid("f3bd2b26-32b3-4287-b1b9-50e90e0402ca"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("58177496-4b54-4a11-9154-13d72d1373d7"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("015a4bd9-15df-49f6-82ae-a01971fd02fd"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("7e5007f9-38a0-4f35-a4b6-2fa4ca5f13d8"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("65b29bba-d29f-4bb9-a3fd-2da14b1f3480"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("b64cf270-fee6-492d-8baf-2057465f0aac"));
            base.InitializeControls();
        }

        public PA_ReserveOfficerCandidateCandidateForm() : base("PA_RESERVEOFFICERCANDIDATECANDIDATE", "PA_ReserveOfficerCandidateCandidateForm")
        {
        }

        protected PA_ReserveOfficerCandidateCandidateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}