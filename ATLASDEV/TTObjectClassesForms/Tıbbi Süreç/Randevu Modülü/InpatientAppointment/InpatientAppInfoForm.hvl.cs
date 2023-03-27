
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
    /// Yatak Rezerve Ajanda Randevu Bilgileri
    /// </summary>
    public partial class InpatientAppInfoForm : TTForm
    {
        protected TTObjectClasses.InpatientAppointment _InpatientAppointment
        {
            get { return (TTObjectClasses.InpatientAppointment)_ttObject; }
        }

        protected ITTLabel labelMasterResource;
        protected ITTObjectListBox MasterResource;
        protected ITTLabel labelBed;
        protected ITTObjectListBox Bed;
        protected ITTLabel labelRoom;
        protected ITTObjectListBox Room;
        protected ITTLabel labelPhysicalStateClinic;
        protected ITTObjectListBox PhysicalStateClinic;
        protected ITTLabel labelResponsibleDoctor;
        protected ITTObjectListBox ResponsibleDoctor;
        protected ITTCheckBox IsQueue;
        protected ITTLabel labelInpatientDay;
        protected ITTTextBox InpatientDay;
        protected ITTLabel labelAppointmentDate;
        protected ITTDateTimePicker AppointmentDate;
        override protected void InitializeControls()
        {
            labelMasterResource = (ITTLabel)AddControl(new Guid("216909d0-0ab1-4424-b0cc-4858e186614f"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("df220f2d-aabd-4ea6-a82b-589dcd812b57"));
            labelBed = (ITTLabel)AddControl(new Guid("e82a50f9-f096-4fe9-a8b3-d1efe5658c96"));
            Bed = (ITTObjectListBox)AddControl(new Guid("49407599-469f-4b5a-a497-d85e85869afe"));
            labelRoom = (ITTLabel)AddControl(new Guid("065622e9-3e0f-4b25-9989-84f2fa394c20"));
            Room = (ITTObjectListBox)AddControl(new Guid("b4508df5-a4fc-4b8e-b83f-01ecc32f47c1"));
            labelPhysicalStateClinic = (ITTLabel)AddControl(new Guid("b13dc942-db3b-4cc2-8efd-f600f4c443ad"));
            PhysicalStateClinic = (ITTObjectListBox)AddControl(new Guid("f21157b3-aba2-46ac-abb4-e98aa6dda36f"));
            labelResponsibleDoctor = (ITTLabel)AddControl(new Guid("830d0876-7f3f-49cb-8845-c97858ef0ce4"));
            ResponsibleDoctor = (ITTObjectListBox)AddControl(new Guid("75e10f7e-28ac-49b7-8943-ccb4d5421489"));
            IsQueue = (ITTCheckBox)AddControl(new Guid("7b20dd5a-18e9-4c31-9dd9-1a84cad36736"));
            labelInpatientDay = (ITTLabel)AddControl(new Guid("ec5c0cd3-5b9a-4463-baca-594ea0421ced"));
            InpatientDay = (ITTTextBox)AddControl(new Guid("8eeb6cdd-54f9-41bc-9a0f-d364a4208073"));
            labelAppointmentDate = (ITTLabel)AddControl(new Guid("b4ff866b-e4a3-40e9-8091-d18464bd5987"));
            AppointmentDate = (ITTDateTimePicker)AddControl(new Guid("da3ad474-eb04-436c-91b8-acb14fadc1cc"));
            base.InitializeControls();
        }

        public InpatientAppInfoForm() : base("INPATIENTAPPOINTMENT", "InpatientAppInfoForm")
        {
        }

        protected InpatientAppInfoForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}