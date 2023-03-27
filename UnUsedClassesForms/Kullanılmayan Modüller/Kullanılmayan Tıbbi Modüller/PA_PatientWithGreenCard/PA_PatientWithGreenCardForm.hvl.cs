
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
    /// Yeşil Kartlı Hasta Kabulü
    /// </summary>
    public partial class PA_PatientWithGreenCardForm : PatientAdmissionForm
    {
    /// <summary>
    /// Yeşil Kartlı Hasta Kabul 
    /// </summary>
        protected TTObjectClasses.PA_PatientWithGreenCard _PA_PatientWithGreenCard
        {
            get { return (TTObjectClasses.PA_PatientWithGreenCard)_ttObject; }
        }

        protected ITTTextBox DocumentNumber;
        protected ITTLabel labelDocumentNumber;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel labelDocumentDate;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox PayerCity;
        protected ITTLabel labelFoundation;
        protected ITTTextBox RetirementFundID;
        protected ITTObjectListBox Payer;
        protected ITTLabel labelCity;
        protected ITTObjectListBox Protocol;
        override protected void InitializeControls()
        {
            DocumentNumber = (ITTTextBox)AddControl(new Guid("d013d2ee-9e67-4157-ad88-13e8e7a7484d"));
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("3a1b355a-4e84-4ad4-9a97-c8713ecad6da"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("ce22213b-c6b6-4944-a31a-1b720392171f"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("539c11b3-9247-4eeb-ab66-a82baf77c862"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("1cd9551a-a574-4618-826f-6d52ff75055d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6de945fe-ab7f-4828-a3a4-89e1d51eded4"));
            PayerCity = (ITTObjectListBox)AddControl(new Guid("e8994146-2445-483f-ba09-ab80d1b633f2"));
            labelFoundation = (ITTLabel)AddControl(new Guid("ec931335-b075-4a55-8918-b917c550e1c1"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("71819a18-d1f9-45fc-81d1-b992a2f66c0f"));
            Payer = (ITTObjectListBox)AddControl(new Guid("dc4182fa-0483-47a7-979d-c51aa6c002b2"));
            labelCity = (ITTLabel)AddControl(new Guid("8618e714-26e3-4a16-b536-d8deefbc2663"));
            Protocol = (ITTObjectListBox)AddControl(new Guid("b5841166-838b-4e2d-81f4-de084caeb3a4"));
            base.InitializeControls();
        }

        public PA_PatientWithGreenCardForm() : base("PA_PATIENTWITHGREENCARD", "PA_PatientWithGreenCardForm")
        {
        }

        protected PA_PatientWithGreenCardForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}