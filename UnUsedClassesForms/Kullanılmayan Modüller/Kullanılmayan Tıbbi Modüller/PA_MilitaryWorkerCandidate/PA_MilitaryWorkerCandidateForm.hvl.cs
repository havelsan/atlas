
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
    /// XXXXXX İşçi Adayı Kabulü
    /// </summary>
    public partial class PA_MilitaryWorkerCandidateForm : PatientAdmissionForm
    {
    /// <summary>
    /// XXXXXX İşçi Adayı Kabul 
    /// </summary>
        protected TTObjectClasses.PA_MilitaryWorkerCandidate _PA_MilitaryWorkerCandidate
        {
            get { return (TTObjectClasses.PA_MilitaryWorkerCandidate)_ttObject; }
        }

        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel5;
        protected ITTDateTimePicker DocumentDate;
        protected ITTTextBox DocumentNumber;
        protected ITTObjectListBox ForcesCommand;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox SenderChair;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelMilitaryClass;
        protected ITTObjectListBox MilitaryClass;
        override protected void InitializeControls()
        {
            ttlabel3 = (ITTLabel)AddControl(new Guid("0954b891-1e3c-4462-adc8-db30b48c6c03"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("eb24036e-032f-4b69-a508-dd8891a47e4c"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("3e4b3ca8-503c-499d-abd0-a4a4d41cd6a0"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("f855cabc-4173-4848-b749-95312c76a49a"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("c7467412-fcb9-4642-ba6e-f45136b430ad"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("0ea7f0d3-58c6-4584-8d52-85875d513ab6"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("ed83f645-f521-4ee1-9343-0e6a01f160ed"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("700935e4-1fcb-4e1d-8e48-534757cf036d"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("a4af2334-dab0-4d09-bc35-a5dc04cf4a1c"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("36c52bb3-1761-4d88-a439-c68c2475a308"));
            base.InitializeControls();
        }

        public PA_MilitaryWorkerCandidateForm() : base("PA_MILITARYWORKERCANDIDATE", "PA_MilitaryWorkerCandidateForm")
        {
        }

        protected PA_MilitaryWorkerCandidateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}