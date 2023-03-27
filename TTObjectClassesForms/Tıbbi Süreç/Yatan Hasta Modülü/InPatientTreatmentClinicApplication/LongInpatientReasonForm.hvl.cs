
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
    /// Uzun Yatış Nedeni
    /// </summary>
    public partial class LongInpatientReasonForm : TTForm
    {
    /// <summary>
    /// Klinik İşlemleri
    /// </summary>
        protected TTObjectClasses.InPatientTreatmentClinicApplication _InPatientTreatmentClinicApplication
        {
            get { return (TTObjectClasses.InPatientTreatmentClinicApplication)_ttObject; }
        }

        protected ITTLabel labelLongInpatientReason;
        protected ITTTextBox ContagiousDisease;
        override protected void InitializeControls()
        {
            labelLongInpatientReason = (ITTLabel)AddControl(new Guid("9b8a5435-0985-426b-ad28-dc09c08c9d91"));
            ContagiousDisease = (ITTTextBox)AddControl(new Guid("dfa8af77-cd12-4acf-8c15-0d99fe137ec5"));
            base.InitializeControls();
        }

        public LongInpatientReasonForm() : base("INPATIENTTREATMENTCLINICAPPLICATION", "LongInpatientReasonForm")
        {
        }

        protected LongInpatientReasonForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}