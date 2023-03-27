
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
    /// Kafa randevusu formu
    /// </summary>
    public partial class AdmissionAppointmentForm : ActionForm
    {
    /// <summary>
    /// Kafa Randevusu
    /// </summary>
        protected TTObjectClasses.AdmissionAppointment _AdmissionAppointment
        {
            get { return (TTObjectClasses.AdmissionAppointment)_ttObject; }
        }

        protected ITTCheckBox NotRequiredQuota;
        protected ITTTextBox SelectedPatientFiltered;
        protected ITTTextBox PatientSurname;
        protected ITTTextBox PatientName;
        protected ITTButton ClearSelectedPatient;
        protected ITTLabel labelPatientSurname;
        protected ITTLabel labelAppointmentDefinition;
        protected ITTLabel labelSelectedPatient;
        protected ITTObjectListBox SelectedPatient;
        protected ITTLabel labelPatientName;
        protected ITTListDefComboBox AppointmentDefinitionList;
        override protected void InitializeControls()
        {
            NotRequiredQuota = (ITTCheckBox)AddControl(new Guid("13ee602a-f84b-48f9-a209-06d54ae73df2"));
            SelectedPatientFiltered = (ITTTextBox)AddControl(new Guid("951a5056-b60e-40a4-98e4-1c10f15a86c4"));
            PatientSurname = (ITTTextBox)AddControl(new Guid("00cd38b6-9d03-4030-bc14-43153d4282cb"));
            PatientName = (ITTTextBox)AddControl(new Guid("78fc9e3f-ba35-4a3f-89c9-04647f670be6"));
            ClearSelectedPatient = (ITTButton)AddControl(new Guid("aaa1e325-c8e6-4ecc-9ae0-d240c1614888"));
            labelPatientSurname = (ITTLabel)AddControl(new Guid("e5706af7-8548-49f4-81eb-c44662cc0d82"));
            labelAppointmentDefinition = (ITTLabel)AddControl(new Guid("58a6f44e-c0b0-48f9-82d2-cc7085f8b317"));
            labelSelectedPatient = (ITTLabel)AddControl(new Guid("68f11a6a-2df3-4794-834f-1b57607ed8b5"));
            SelectedPatient = (ITTObjectListBox)AddControl(new Guid("90526cf2-22f0-444b-b202-60838ff212f8"));
            labelPatientName = (ITTLabel)AddControl(new Guid("a5682870-9e32-4210-b741-049e36dfcc89"));
            AppointmentDefinitionList = (ITTListDefComboBox)AddControl(new Guid("874f9540-4272-4524-9be3-7935a54926c5"));
            base.InitializeControls();
        }

        public AdmissionAppointmentForm() : base("ADMISSIONAPPOINTMENT", "AdmissionAppointmentForm")
        {
        }

        protected AdmissionAppointmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}