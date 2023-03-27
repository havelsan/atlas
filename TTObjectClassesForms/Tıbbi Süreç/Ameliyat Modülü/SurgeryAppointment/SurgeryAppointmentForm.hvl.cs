
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
    /// Ameliyat Randevu Formu
    /// </summary>
    public partial class SurgeryAppointmentForm : TTForm
    {
    /// <summary>
    /// Ameliyat Randevuları Nesnesi
    /// </summary>
        protected TTObjectClasses.SurgeryAppointment _SurgeryAppointment
        {
            get { return (TTObjectClasses.SurgeryAppointment)_ttObject; }
        }

        protected ITTGrid SurgeryAppointmentProcedures;
        protected ITTListBoxColumn ProcedureDefinitionSurgeryAppointmentProc;
        protected ITTLabel labelMasterResource;
        protected ITTObjectListBox MasterResource;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelSurgeryRoom;
        protected ITTObjectListBox SurgeryRoom;
        protected ITTLabel labelSurgeryDesk;
        protected ITTObjectListBox SurgeryDesk;
        protected ITTCheckBox Emergency;
        protected ITTCheckBox IsNeedAnesthesia;
        protected ITTCheckBox IsComplicationSurgery;
        protected ITTLabel labelComplicationDescription;
        protected ITTTextBox ComplicationDescription;
        protected ITTTextBox NotesToAnesthesia;
        protected ITTTextBox PlannedSurgeryDescription;
        protected ITTLabel labelPlannedSurgeryEndDate;
        protected ITTDateTimePicker PlannedSurgeryEndDate;
        protected ITTLabel labelPlannedSurgeryStartDate;
        protected ITTDateTimePicker PlannedSurgeryStartDate;
        protected ITTLabel labelNotesToAnesthesia;
        protected ITTLabel labelDescriptionToPreOp;
        protected ITTRichTextBoxControl DescriptionToPreOp;
        protected ITTLabel labelPlannedSurgeryDescription;
        override protected void InitializeControls()
        {
            SurgeryAppointmentProcedures = (ITTGrid)AddControl(new Guid("50352f05-71a9-4f57-a221-d20c36d5ecad"));
            ProcedureDefinitionSurgeryAppointmentProc = (ITTListBoxColumn)AddControl(new Guid("2efa1716-2ca6-4b8c-900d-d090188be4df"));
            labelMasterResource = (ITTLabel)AddControl(new Guid("8d373359-1c94-4153-9c21-95df7797b751"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("ee32f64c-0ce9-4284-b130-e052dda30e50"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("740cb3c5-8e22-4826-9352-58bf3dbbb262"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("4e75216b-61f7-4a25-8424-f7e13fa41a6e"));
            labelSurgeryRoom = (ITTLabel)AddControl(new Guid("3e81978a-1b39-46aa-afa4-ac7b74b6d516"));
            SurgeryRoom = (ITTObjectListBox)AddControl(new Guid("b58161e1-118e-4749-b1f4-1bc771b1c8f3"));
            labelSurgeryDesk = (ITTLabel)AddControl(new Guid("12ba3349-b5af-47e8-8cea-aeb07e82a6d9"));
            SurgeryDesk = (ITTObjectListBox)AddControl(new Guid("5eeb121a-95f0-4615-82c8-0278e797bc4a"));
            Emergency = (ITTCheckBox)AddControl(new Guid("4c032766-16f2-4a34-aebe-238a7f73a5ab"));
            IsNeedAnesthesia = (ITTCheckBox)AddControl(new Guid("334fc764-73e3-422e-8035-6fa027ba425e"));
            IsComplicationSurgery = (ITTCheckBox)AddControl(new Guid("15be2019-874b-46c6-93f7-f7a85a27c010"));
            labelComplicationDescription = (ITTLabel)AddControl(new Guid("8aaabad4-6ad2-4af6-8454-8b72e32ec3a5"));
            ComplicationDescription = (ITTTextBox)AddControl(new Guid("8d477ed8-42ec-41c5-b688-5fc33da25368"));
            NotesToAnesthesia = (ITTTextBox)AddControl(new Guid("03ec3fb7-1c38-44c1-9b52-f231e006b11a"));
            PlannedSurgeryDescription = (ITTTextBox)AddControl(new Guid("f3408b6f-5076-41c2-a3a4-a9681911c472"));
            labelPlannedSurgeryEndDate = (ITTLabel)AddControl(new Guid("44f4d862-3299-44d7-9569-3fc8893a3f77"));
            PlannedSurgeryEndDate = (ITTDateTimePicker)AddControl(new Guid("df478b11-c2f5-4f2b-b881-09b351f30685"));
            labelPlannedSurgeryStartDate = (ITTLabel)AddControl(new Guid("fb8227dd-09e0-4644-aadb-386c7b8ba727"));
            PlannedSurgeryStartDate = (ITTDateTimePicker)AddControl(new Guid("5e15682a-b8f4-4a12-9d01-051706c9bf69"));
            labelNotesToAnesthesia = (ITTLabel)AddControl(new Guid("00b7399f-523c-4a85-b400-ecaa2195a059"));
            labelDescriptionToPreOp = (ITTLabel)AddControl(new Guid("a63565be-8e26-4726-826b-105b2fa68325"));
            DescriptionToPreOp = (ITTRichTextBoxControl)AddControl(new Guid("c229da73-884f-4fda-8fae-13537d83e1f9"));
            labelPlannedSurgeryDescription = (ITTLabel)AddControl(new Guid("c8170c24-f10a-45ed-b9b7-a65fda16a573"));
            base.InitializeControls();
        }

        public SurgeryAppointmentForm() : base("SURGERYAPPOINTMENT", "SurgeryAppointmentForm")
        {
        }

        protected SurgeryAppointmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}