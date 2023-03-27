
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
    /// Hasta Yatış
    /// </summary>
    public partial class InpatientAdmissionRequestForm : InPatientAdmissionBaseForm
    {
    /// <summary>
    /// Hasta Yatış  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.InpatientAdmission _InpatientAdmission
        {
            get { return (TTObjectClasses.InpatientAdmission)_ttObject; }
        }

        protected ITTTextBox ReasonForInpatientAdmission;
        protected ITTTextBox EstimatedInpatientDateCount;
        protected ITTCheckBox NeedCompanion;
        protected ITTCheckBox HasAirborneContactIsolation;
        protected ITTCheckBox HasContactIsolation;
        protected ITTCheckBox HasDropletIsolation;
        protected ITTCheckBox HasFallingRisk;
        protected ITTCheckBox HasTightContactIsolation;
        protected ITTLabel labelEstimatedInpatientDate;
        protected ITTDateTimePicker EstimatedInpatientDate;
        protected ITTObjectListBox MasterResource;
        protected ITTButton btnEmptyBedsInClinic;
        protected ITTCheckBox Emergency;
        protected ITTLabel LabelDateTime;
        protected ITTDateTimePicker RequestDate;
        protected ITTObjectListBox TreatmentClinic;
        protected ITTLabel labelBed;
        protected ITTLabel labelRoomGroup;
        protected ITTObjectListBox Bed;
        protected ITTLabel labelTreatmentClinic;
        protected ITTLabel labelRoom;
        protected ITTObjectListBox RoomGroup;
        protected ITTLabel labelReasonForInpatientAdmission;
        protected ITTLabel labelNumberOfEmptyBeds;
        protected ITTObjectListBox Room;
        protected ITTRichTextBoxControl ReturnToRequestReason;
        protected ITTLabel labelReturnToRequestReason;
        protected ITTObjectListBox PhysicalStateClinic;
        protected ITTLabel labelPhysicalStateClinic;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTObjectListBox inpatientReason;
        protected ITTLabel ttlabel1;
        protected ITTLabel lblb;
        protected ITTObjectListBox Building;
        protected ITTLabel labelEstimatedDischargeDate;
        protected ITTDateTimePicker EstimatedDischargeDate;
        protected ITTLabel lableEstimatedInpatientDate;
        override protected void InitializeControls()
        {
            ReasonForInpatientAdmission = (ITTTextBox)AddControl(new Guid("9b346cc1-1754-47ac-b068-0aba32bfaa13"));
            EstimatedInpatientDateCount = (ITTTextBox)AddControl(new Guid("c8f08b36-4bf7-4ec1-a8a1-2de3e90aa371"));
            NeedCompanion = (ITTCheckBox)AddControl(new Guid("f857984e-788b-46c5-8447-34927d1a86eb"));
            HasAirborneContactIsolation = (ITTCheckBox)AddControl(new Guid("2e002533-f79b-4a86-97ca-d2805e36f231"));
            HasContactIsolation = (ITTCheckBox)AddControl(new Guid("16235ad6-a1ed-4d64-bc0f-263c53334c23"));
            HasDropletIsolation = (ITTCheckBox)AddControl(new Guid("d088e6f7-3cb1-4351-be4b-0f5878f336a5"));
            HasFallingRisk = (ITTCheckBox)AddControl(new Guid("ce07bd0b-386e-43ae-855d-d59e14f855b2"));
            HasTightContactIsolation = (ITTCheckBox)AddControl(new Guid("82d2a098-10f6-45fe-be1e-6b0975aac11d"));
            labelEstimatedInpatientDate = (ITTLabel)AddControl(new Guid("f8a7ba2f-bfc8-4997-9d23-d17bf5cee6b9"));
            EstimatedInpatientDate = (ITTDateTimePicker)AddControl(new Guid("b2b0c077-e4d4-43fb-8636-59472e5df9a7"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("e33932df-e4e1-4153-9187-11b23d933d24"));
            btnEmptyBedsInClinic = (ITTButton)AddControl(new Guid("b7ad1c3d-a923-4471-8ffc-f283fcfcd521"));
            Emergency = (ITTCheckBox)AddControl(new Guid("81632742-a7bb-4953-9b5c-36096744d1a6"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("00f74c92-aa51-48f7-907c-0bdbf4c4ac72"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("8f85db84-9f52-4ee6-9726-213073850caa"));
            TreatmentClinic = (ITTObjectListBox)AddControl(new Guid("4abe8a0f-afbf-409b-bb12-185f5dc91f65"));
            labelBed = (ITTLabel)AddControl(new Guid("ecebf853-6051-49f2-b027-228fbad59d0d"));
            labelRoomGroup = (ITTLabel)AddControl(new Guid("e105fedd-6310-4770-9820-302a29b2f62c"));
            Bed = (ITTObjectListBox)AddControl(new Guid("fedfb730-9c37-40d6-9594-4a5b2817d0ef"));
            labelTreatmentClinic = (ITTLabel)AddControl(new Guid("7d5d2a58-8933-4eb6-b175-91fdea6c25d7"));
            labelRoom = (ITTLabel)AddControl(new Guid("f9d32745-4f6c-4221-b800-97f8e6a778a7"));
            RoomGroup = (ITTObjectListBox)AddControl(new Guid("f59be8c7-1ab5-4080-b347-9edfdf9a17fd"));
            labelReasonForInpatientAdmission = (ITTLabel)AddControl(new Guid("42e1e5f6-8426-4758-8539-bcd63f3ae6e8"));
            labelNumberOfEmptyBeds = (ITTLabel)AddControl(new Guid("93adf8a7-067c-48f9-a97e-c0bdb5ac1a40"));
            Room = (ITTObjectListBox)AddControl(new Guid("8d211c47-9642-4027-9c04-c9ecb91a6cef"));
            ReturnToRequestReason = (ITTRichTextBoxControl)AddControl(new Guid("336d54b2-e4a3-4ac6-84ff-ef4bc50b000f"));
            labelReturnToRequestReason = (ITTLabel)AddControl(new Guid("5d834252-96f2-4283-8fdc-89cad60af52d"));
            PhysicalStateClinic = (ITTObjectListBox)AddControl(new Guid("7684ba7d-28da-424d-9b34-a08c99f2d8e3"));
            labelPhysicalStateClinic = (ITTLabel)AddControl(new Guid("8cdb4e99-db07-41fa-b48e-04c7a5b1c37d"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("c1fc3469-7375-414b-a5d1-5d32f6860b58"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("3e624f94-fca7-4dd6-9a88-e6c83200bfca"));
            inpatientReason = (ITTObjectListBox)AddControl(new Guid("1bfbdf65-7f5e-4d2f-8724-78c7ca3f73fc"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("42a5abbc-e0f3-44f3-8e62-ae08e72d9945"));
            lblb = (ITTLabel)AddControl(new Guid("a3823b36-61da-444a-9a3a-0149ec4c711c"));
            Building = (ITTObjectListBox)AddControl(new Guid("76f61cab-d928-4a9c-8188-0d7fc8528c6c"));
            labelEstimatedDischargeDate = (ITTLabel)AddControl(new Guid("47596fe5-f965-4826-87b5-bd33dea66a81"));
            EstimatedDischargeDate = (ITTDateTimePicker)AddControl(new Guid("8325dd9e-4a12-40e1-944d-5bae047fcfec"));
            lableEstimatedInpatientDate = (ITTLabel)AddControl(new Guid("24c8da68-11a9-41d7-b66a-de5d937fcbbe"));
            base.InitializeControls();
        }

        public InpatientAdmissionRequestForm() : base("INPATIENTADMISSION", "InpatientAdmissionRequestForm")
        {
        }

        protected InpatientAdmissionRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}