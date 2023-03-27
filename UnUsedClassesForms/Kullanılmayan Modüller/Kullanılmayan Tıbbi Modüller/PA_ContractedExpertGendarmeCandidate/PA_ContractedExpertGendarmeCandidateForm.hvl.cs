
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
    /// Uzman Jandarma  Adayı(XXXXXX Ögrenci) Kabulü
    /// </summary>
    public partial class PA_ContractedExpertGendarmeCandidateForm : PatientAdmissionForm
    {
    /// <summary>
    /// Uzman Jandarma  Adayı(XXXXXX Ögrenci)
    /// </summary>
        protected TTObjectClasses.PA_ContractedExpertGendarmeCandidate _PA_ContractedExpertGendarmeCandidate
        {
            get { return (TTObjectClasses.PA_ContractedExpertGendarmeCandidate)_ttObject; }
        }

        protected ITTLabel labelDocumentNumber;
        protected ITTLabel labelSenderChair;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel labelDocumentDate;
        protected ITTTextBox DocumentNumber;
        protected ITTObjectListBox SenderChair;
        override protected void InitializeControls()
        {
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("a03176fb-36f5-47b1-b4b4-536a4a5f2196"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("78679147-5dad-4457-958b-960374dd6703"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("30c6c7dc-3d34-401f-b7f9-4f92643a0941"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("6b827f5e-441a-43ad-8a7d-36430b2f991f"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("94142cb0-fd82-4353-a290-40c40be8f4b6"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("34817347-8724-48a9-bd8b-ee1f8518b528"));
            base.InitializeControls();
        }

        public PA_ContractedExpertGendarmeCandidateForm() : base("PA_CONTRACTEDEXPERTGENDARMECANDIDATE", "PA_ContractedExpertGendarmeCandidateForm")
        {
        }

        protected PA_ContractedExpertGendarmeCandidateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}