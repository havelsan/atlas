
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
    /// Hasta Kabul Düzeltme
    /// </summary>
    public partial class PatientAdmissionCorrectionForm : EpisodeActionForm
    {
    /// <summary>
    /// Hasta Kabul Düzeltme
    /// </summary>
        protected TTObjectClasses.PatientAdmissionCorrection _PatientAdmissionCorrection
        {
            get { return (TTObjectClasses.PatientAdmissionCorrection)_ttObject; }
        }

        protected ITTLabel labelID;
        protected ITTButton NewPatientAdmission;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelActionDate;
        protected ITTButton OldPatientAdmission;
        protected ITTTextBox ID;
        override protected void InitializeControls()
        {
            labelID = (ITTLabel)AddControl(new Guid("e4bdcc01-8cb4-4f0e-bc9b-00f943cd09d8"));
            NewPatientAdmission = (ITTButton)AddControl(new Guid("1c00321e-307a-4218-a449-5719c840b6e8"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("fda15431-55c3-4ee8-8d09-5dbc4f53550d"));
            labelActionDate = (ITTLabel)AddControl(new Guid("c249d8c0-30f6-428f-8aec-a2f356e27c32"));
            OldPatientAdmission = (ITTButton)AddControl(new Guid("9174a850-4601-4415-a3a8-cff98dc5d31a"));
            ID = (ITTTextBox)AddControl(new Guid("a02694d3-cf8d-40ac-9ebc-deb8d1b2c957"));
            base.InitializeControls();
        }

        public PatientAdmissionCorrectionForm() : base("PATIENTADMISSIONCORRECTION", "PatientAdmissionCorrectionForm")
        {
        }

        protected PatientAdmissionCorrectionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}