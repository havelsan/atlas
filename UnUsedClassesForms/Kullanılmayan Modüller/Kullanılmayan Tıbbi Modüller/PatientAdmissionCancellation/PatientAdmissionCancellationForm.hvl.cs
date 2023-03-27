
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
    public partial class PatientAdmissionCancellationForm : EpisodeActionForm
    {
    /// <summary>
    /// Hasta Kabul Iptal
    /// </summary>
        protected TTObjectClasses.PatientAdmissionCancellation _PatientAdmissionCancellation
        {
            get { return (TTObjectClasses.PatientAdmissionCancellation)_ttObject; }
        }

        protected ITTLabel lblSilmeNedeni;
        protected ITTTextBox txtboxSilmeNedeni;
        override protected void InitializeControls()
        {
            lblSilmeNedeni = (ITTLabel)AddControl(new Guid("192622a0-f743-408c-a126-e535b89313e5"));
            txtboxSilmeNedeni = (ITTTextBox)AddControl(new Guid("ce0a6f00-e49a-4cba-b7d5-280cf6227710"));
            base.InitializeControls();
        }

        public PatientAdmissionCancellationForm() : base("PATIENTADMISSIONCANCELLATION", "PatientAdmissionCancellationForm")
        {
        }

        protected PatientAdmissionCancellationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}