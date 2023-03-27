
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
    /// Hemşirelik Uygulamaları - Hasta Yara Değerlendirme Takip Formu
    /// </summary>
    public partial class PatientBruiseAssessmentTracingForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.PatientBruiseAssessmentTracing _PatientBruiseAssessmentTracing
        {
            get { return (TTObjectClasses.PatientBruiseAssessmentTracing)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox Aktif;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("a69462ae-b37f-400c-9d10-860ebccfe07d"));
            Name = (ITTTextBox)AddControl(new Guid("1838f938-7961-4d54-9617-7d0993ae83f4"));
            Aktif = (ITTCheckBox)AddControl(new Guid("da8f9fe9-180a-420b-b6e4-2410f69120d2"));
            base.InitializeControls();
        }

        public PatientBruiseAssessmentTracingForm() : base("PATIENTBRUISEASSESSMENTTRACING", "PatientBruiseAssessmentTracingForm")
        {
        }

        protected PatientBruiseAssessmentTracingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}