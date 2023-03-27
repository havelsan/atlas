
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
    public partial class PatientExaminationAppForm : TTForm
    {
    /// <summary>
    /// Randevu
    /// </summary>
        protected TTObjectClasses.Appointment _Appointment
        {
            get { return (TTObjectClasses.Appointment)_ttObject; }
        }

        protected ITTLabel labelResource;
        protected ITTObjectListBox Resource;
        protected ITTLabel labelMasterResource;
        protected ITTObjectListBox MasterResource;
        protected ITTLabel labelAppointmentDefinition;
        protected ITTObjectListBox AppointmentDefinition;
        protected ITTLabel labelStartTime;
        protected ITTDateTimePicker StartTime;
        protected ITTLabel labelNotes;
        protected ITTTextBox Notes;
        protected ITTLabel labelMHRSRandevuHrn;
        protected ITTTextBox MHRSRandevuHrn;
        protected ITTLabel labelEndTime;
        protected ITTDateTimePicker EndTime;
        protected ITTLabel labelAppointmentType;
        protected ITTEnumComboBox AppointmentType;
        protected ITTLabel labelAppointmentID;
        protected ITTTextBox AppointmentID;
        protected ITTLabel labelAppDate;
        protected ITTDateTimePicker AppDate;
        override protected void InitializeControls()
        {
            labelResource = (ITTLabel)AddControl(new Guid("50c0956b-7b5c-425b-bbc8-19e17914344e"));
            Resource = (ITTObjectListBox)AddControl(new Guid("b1bb1a68-ae4d-43f5-972a-898651018762"));
            labelMasterResource = (ITTLabel)AddControl(new Guid("523a6696-4664-4e79-aba5-3121b313ee4b"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("2ff424b4-9361-4cc7-9f24-93ac633217b4"));
            labelAppointmentDefinition = (ITTLabel)AddControl(new Guid("9f449e61-2d19-4b58-938f-5cfeaddb98db"));
            AppointmentDefinition = (ITTObjectListBox)AddControl(new Guid("6388d858-79ed-4f1d-969d-d342b92d79fa"));
            labelStartTime = (ITTLabel)AddControl(new Guid("a345ab6c-0796-4378-a4bf-00983ded58cc"));
            StartTime = (ITTDateTimePicker)AddControl(new Guid("a4222a65-b138-4519-a963-794dc5254d01"));
            labelNotes = (ITTLabel)AddControl(new Guid("b93dcb4f-f8a3-4e7c-b67e-aac75e5da734"));
            Notes = (ITTTextBox)AddControl(new Guid("8f4d2445-d3ca-4f0e-b045-dc8880972eb0"));
            labelMHRSRandevuHrn = (ITTLabel)AddControl(new Guid("c6df62f2-9430-47b8-b5d2-afc390a61feb"));
            MHRSRandevuHrn = (ITTTextBox)AddControl(new Guid("02e58e55-bf55-40d6-ba85-992eecdf247c"));
            labelEndTime = (ITTLabel)AddControl(new Guid("0801a0ba-128d-4f4a-8e47-c0effefe8f30"));
            EndTime = (ITTDateTimePicker)AddControl(new Guid("8db4b6b6-ff44-453c-b7ab-5485525d9088"));
            labelAppointmentType = (ITTLabel)AddControl(new Guid("cf2f76c6-cc26-4f10-a00b-63e3412b7269"));
            AppointmentType = (ITTEnumComboBox)AddControl(new Guid("21af38a9-a5ca-4405-aa5f-f59b2d575207"));
            labelAppointmentID = (ITTLabel)AddControl(new Guid("7c482f1e-0fd8-4034-897b-8e12937c8a91"));
            AppointmentID = (ITTTextBox)AddControl(new Guid("122c93b1-d748-4604-ba6f-636eacc4f8ed"));
            labelAppDate = (ITTLabel)AddControl(new Guid("7cd65bd1-8808-4131-b2d9-20778bfec0e4"));
            AppDate = (ITTDateTimePicker)AddControl(new Guid("0e624f4b-0701-4789-a65e-502fbefde4fb"));
            base.InitializeControls();
        }

        public PatientExaminationAppForm() : base("APPOINTMENT", "PatientExaminationAppForm")
        {
        }

        protected PatientExaminationAppForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}