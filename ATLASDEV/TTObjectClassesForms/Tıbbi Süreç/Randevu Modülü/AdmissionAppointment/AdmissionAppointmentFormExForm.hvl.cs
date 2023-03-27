
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
    /// Randevu
    /// </summary>
    public partial class AdmissionAppointmentFormEx : ActionForm
    {
    /// <summary>
    /// Kafa Randevusu
    /// </summary>
        protected TTObjectClasses.AdmissionAppointment _AdmissionAppointment
        {
            get { return (TTObjectClasses.AdmissionAppointment)_ttObject; }
        }

        protected ITTCheckBox NotRequiredQuota;
        protected ITTListDefComboBox AppointmentDefinitionList;
        protected ITTTextBox SelectedPatientFiltered;
        protected ITTTextBox PatientSurname;
        protected ITTTextBox PatientName;
        protected ITTTextBox AppointmentInformation;
        protected ITTObjectListBox SelectedPatient;
        protected ITTLabel labelPatientSurname;
        protected ITTLabel labelAppointmentInformation;
        protected ITTLabel labelAppointmentDefinition;
        protected ITTLabel labelSelectedPatient;
        protected ITTLabel labelPatientName;
        override protected void InitializeControls()
        {
            NotRequiredQuota = (ITTCheckBox)AddControl(new Guid("6f805218-fc01-4b95-af19-8a12036f6c3a"));
            AppointmentDefinitionList = (ITTListDefComboBox)AddControl(new Guid("b3135f32-7e4a-44fe-9f1d-16e438418738"));
            SelectedPatientFiltered = (ITTTextBox)AddControl(new Guid("f77a2a57-d3e7-4346-a2dd-e5ace57f890a"));
            PatientSurname = (ITTTextBox)AddControl(new Guid("1a1eba3d-c9fc-4b9b-b935-8c07e5d0fb22"));
            PatientName = (ITTTextBox)AddControl(new Guid("f26fac0a-cf2b-4629-945f-3af47cab124c"));
            AppointmentInformation = (ITTTextBox)AddControl(new Guid("2b28f01e-28ea-4687-9667-be72be1562c4"));
            SelectedPatient = (ITTObjectListBox)AddControl(new Guid("6f832685-179b-47d0-8ec3-16f571cc98b0"));
            labelPatientSurname = (ITTLabel)AddControl(new Guid("51364122-d67c-4429-a2a3-bb6cb49988f6"));
            labelAppointmentInformation = (ITTLabel)AddControl(new Guid("a3639528-9ca1-4528-a500-412dd1f60426"));
            labelAppointmentDefinition = (ITTLabel)AddControl(new Guid("ae85e48e-8ada-4133-aeb5-e3d428fc3414"));
            labelSelectedPatient = (ITTLabel)AddControl(new Guid("f4cd42a1-233c-4677-8a1e-fbdd690bdbc2"));
            labelPatientName = (ITTLabel)AddControl(new Guid("a8a90ba2-aae2-49eb-b96b-77f82ff5d178"));
            base.InitializeControls();
        }

        public AdmissionAppointmentFormEx() : base("ADMISSIONAPPOINTMENT", "AdmissionAppointmentFormEx")
        {
        }

        protected AdmissionAppointmentFormEx(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}