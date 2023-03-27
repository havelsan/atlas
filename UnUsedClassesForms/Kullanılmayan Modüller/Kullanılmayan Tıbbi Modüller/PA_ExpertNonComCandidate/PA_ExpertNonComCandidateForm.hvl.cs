
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
    /// Uzman Erbaş Adayı Kabulü
    /// </summary>
    public partial class PA_ExpertNonComCandidateForm : PatientAdmissionForm
    {
    /// <summary>
    /// Uzman Erbaş Adayı Kabul
    /// </summary>
        protected TTObjectClasses.PA_ExpertNonComCandidate _PA_ExpertNonComCandidate
        {
            get { return (TTObjectClasses.PA_ExpertNonComCandidate)_ttObject; }
        }

        protected ITTLabel labelConscriptionPeriod;
        protected ITTObjectListBox SenderChair;
        protected ITTLabel labelEnteranceTime;
        protected ITTLabel labelMilitaryUnit;
        protected ITTLabel labelSenderChair;
        protected ITTTextBox DocumentNumber;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelMilitaryClass;
        protected ITTTextBox ConscriptionPeriod;
        protected ITTDateTimePicker MilitaryAcceptanceTime;
        protected ITTLabel ttlabel2;
        protected ITTDateTimePicker DocumentDate;
        protected ITTObjectListBox MilitaryClass;
        override protected void InitializeControls()
        {
            labelConscriptionPeriod = (ITTLabel)AddControl(new Guid("7e35924e-d564-40be-bf14-1fa355509e68"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("33c038f4-ce24-4910-9759-60c367da2009"));
            labelEnteranceTime = (ITTLabel)AddControl(new Guid("60126469-4712-4631-a5a5-678fd18636ed"));
            labelMilitaryUnit = (ITTLabel)AddControl(new Guid("58aa409c-af6b-4f9d-8333-7bbd887832dc"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("aa5917d6-b5a8-4d6f-99bc-7ea8b834b1ce"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("ab6c37df-9691-4fea-b369-7f23b51a1cdb"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("65bd1381-b8e5-4b87-ac2a-89b8b9539535"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("abf2fee6-553f-4afa-8d04-8b8acad28b52"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("2d49c59a-15a7-4e44-9bef-a0f71b657332"));
            ConscriptionPeriod = (ITTTextBox)AddControl(new Guid("f176ac26-9d09-43c1-b005-aaff42d94936"));
            MilitaryAcceptanceTime = (ITTDateTimePicker)AddControl(new Guid("7c9ca615-fe3e-40fa-b141-b295de0732eb"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ce201f74-bcc4-4424-8d02-c49c8cbc75fe"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("8fb4fb17-d78a-48d2-a1d1-c5e4573a4ae2"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("c7ab49e3-287c-4a54-a61e-e41de1f49360"));
            base.InitializeControls();
        }

        public PA_ExpertNonComCandidateForm() : base("PA_EXPERTNONCOMCANDIDATE", "PA_ExpertNonComCandidateForm")
        {
        }

        protected PA_ExpertNonComCandidateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}