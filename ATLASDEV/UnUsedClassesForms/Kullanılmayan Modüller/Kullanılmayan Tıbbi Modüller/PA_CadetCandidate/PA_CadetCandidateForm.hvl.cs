
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
    /// XXXXXX Öğrenci Adayı Kabulü
    /// </summary>
    public partial class PA_CadetCandidateForm : PatientAdmissionForm
    {
    /// <summary>
    /// XXXXXX Öğrenci Adayı  Kabul
    /// </summary>
        protected TTObjectClasses.PA_CadetCandidate _PA_CadetCandidate
        {
            get { return (TTObjectClasses.PA_CadetCandidate)_ttObject; }
        }

        protected ITTLabel labelDocumentNumber;
        protected ITTObjectListBox SenderChair;
        protected ITTLabel labelDocumentDate;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel labelSenderChair;
        protected ITTDateTimePicker DocumentDate;
        override protected void InitializeControls()
        {
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("cd83dfee-1c5e-487a-b57d-4a671aa89ae0"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("cf7bf3da-6b35-455e-8cca-4e6fd8874b29"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("5383e8f1-e872-43e5-9d5c-6d7af7d78da2"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("bb85b5cf-66a7-4b88-a2e3-a527a06617da"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("6c1f2cba-b53c-4769-ac4d-afeb942ae144"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("80d7ba97-9ed7-4500-a8f8-f96e9fb8df4b"));
            base.InitializeControls();
        }

        public PA_CadetCandidateForm() : base("PA_CADETCANDIDATE", "PA_CadetCandidateForm")
        {
        }

        protected PA_CadetCandidateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}