
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
    public partial class PatientAdmissionCorrectionRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Hasta Kabul Düzeltme
    /// </summary>
        protected TTObjectClasses.PatientAdmissionCorrection _PatientAdmissionCorrection
        {
            get { return (TTObjectClasses.PatientAdmissionCorrection)_ttObject; }
        }

        protected ITTTextBox tttextbox1;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            tttextbox1 = (ITTTextBox)AddControl(new Guid("3180d6f8-138d-4271-b57f-34bf6fb40821"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("085b3525-e40c-4a69-a8bc-487003b9da4d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("de05d148-0983-4be7-85b9-56f7e83168c1"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("908ebbcd-0f4a-43df-8e92-ee9f6604585b"));
            base.InitializeControls();
        }

        public PatientAdmissionCorrectionRequestForm() : base("PATIENTADMISSIONCORRECTION", "PatientAdmissionCorrectionRequestForm")
        {
        }

        protected PatientAdmissionCorrectionRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}