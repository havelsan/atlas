
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
    public partial class InPatientAdmissionClinicProcedure : InPatientAdmissionBaseForm
    {
    /// <summary>
    /// Hasta Yatış  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.InpatientAdmission _InpatientAdmission
        {
            get { return (TTObjectClasses.InpatientAdmission)_ttObject; }
        }

        protected ITTTabControl MainTab;
        protected ITTTabPage InpatientProcedureInfo;
        protected ITTLabel labelReasonForInpatientAdmission;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage TratmentClinicTab;
        protected ITTGrid TratmentClinicsGrid;
        protected ITTListBoxColumn TreatmentClinic;
        protected ITTDateTimePickerColumn ClinicInpatientDate;
        protected ITTDateTimePickerColumn ClinicDischargeDate;
        protected ITTListBoxColumn ResponsibleDoctor;
        protected ITTTabPage BedsTab;
        protected ITTGrid BedsGrid;
        protected ITTDateTimePickerColumn BedInPatientDate;
        protected ITTDateTimePickerColumn BedDischargeDate;
        protected ITTListBoxColumn RoomGroup;
        protected ITTListBoxColumn Room;
        protected ITTListBoxColumn Bed;
        protected ITTTextBoxColumn BedAmount;
        protected ITTEnumComboBoxColumn UsedStatus;
        protected ITTTextBox ReasonForInpatientAdmission;
        protected ITTTextBox QuarantineProtocolNo;
        protected ITTLabel labelRoomGroup;
        protected ITTObjectListBox ActiveRoomGroup;
        protected ITTLabel labelNumberOfEmptyBeds;
        protected ITTObjectListBox ActiveRoom;
        protected ITTObjectListBox ActiveBed;
        protected ITTLabel labelQuarantineProtocolNo;
        protected ITTLabel labelRoom;
        protected ITTLabel labelBed;
        protected ITTDateTimePicker HospitalInpatientDate;
        protected ITTLabel labelHospitalInpatientDate;
        protected ITTObjectListBox PhysicalStateClinic;
        protected ITTLabel ttlabel4;
        override protected void InitializeControls()
        {
            MainTab = (ITTTabControl)AddControl(new Guid("591be170-7497-46f9-8b6e-1edb74d8b67e"));
            InpatientProcedureInfo = (ITTTabPage)AddControl(new Guid("44c229ca-87e1-4271-a79b-0aaf8602cd7d"));
            labelReasonForInpatientAdmission = (ITTLabel)AddControl(new Guid("4c8c4b0f-e55c-40d5-bbc1-c38e2d2f4a9d"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("48274e67-949b-4907-9eb0-5f60d36ed19a"));
            TratmentClinicTab = (ITTTabPage)AddControl(new Guid("2a4f3c4a-d15f-4e01-8ea6-e53c65e30166"));
            TratmentClinicsGrid = (ITTGrid)AddControl(new Guid("45fe4265-0f46-4587-872f-f76414f0d2f7"));
            TreatmentClinic = (ITTListBoxColumn)AddControl(new Guid("e397de82-1cea-4454-9109-a20a7759e2c8"));
            ClinicInpatientDate = (ITTDateTimePickerColumn)AddControl(new Guid("8fab617f-1d2b-419c-a0ad-1061f847d67d"));
            ClinicDischargeDate = (ITTDateTimePickerColumn)AddControl(new Guid("f3578170-6f11-455a-8957-81998ac7bc72"));
            ResponsibleDoctor = (ITTListBoxColumn)AddControl(new Guid("e7554c4d-7f66-40f3-8929-cc4f0ae7e6ad"));
            BedsTab = (ITTTabPage)AddControl(new Guid("88dedff1-c4bd-4ed5-adae-f169c7d64ff4"));
            BedsGrid = (ITTGrid)AddControl(new Guid("75c94dd3-7be9-4c9c-a077-52a8621b6f92"));
            BedInPatientDate = (ITTDateTimePickerColumn)AddControl(new Guid("e9858907-a626-419e-94a5-70623b4f021e"));
            BedDischargeDate = (ITTDateTimePickerColumn)AddControl(new Guid("3617b725-3894-4a8a-97a4-8deea902345d"));
            RoomGroup = (ITTListBoxColumn)AddControl(new Guid("1d6ee5f7-d627-4fa6-99bf-7f7805863bee"));
            Room = (ITTListBoxColumn)AddControl(new Guid("01709fef-465b-4ccd-b9bb-a8b662e05117"));
            Bed = (ITTListBoxColumn)AddControl(new Guid("e3422471-2b58-4693-b6bb-e3377a3f1ed9"));
            BedAmount = (ITTTextBoxColumn)AddControl(new Guid("d8364027-d4d3-4f12-9288-5d5ab0e3b042"));
            UsedStatus = (ITTEnumComboBoxColumn)AddControl(new Guid("1a84097d-7a05-4b9a-b49a-bc348b89069a"));
            ReasonForInpatientAdmission = (ITTTextBox)AddControl(new Guid("3e80ce08-ab1b-4988-a2b1-b6ff6fb91272"));
            QuarantineProtocolNo = (ITTTextBox)AddControl(new Guid("e90f6f9b-dc8f-4d49-9363-a5280dd01fd1"));
            labelRoomGroup = (ITTLabel)AddControl(new Guid("91bad413-f42e-453e-b8d1-4ecf3abef9e6"));
            ActiveRoomGroup = (ITTObjectListBox)AddControl(new Guid("bc4854a8-ba9a-4929-b339-4d2401dd3777"));
            labelNumberOfEmptyBeds = (ITTLabel)AddControl(new Guid("b58a586a-9e96-485f-8923-027506f5ed71"));
            ActiveRoom = (ITTObjectListBox)AddControl(new Guid("8c0ab415-425e-402d-87a4-c796ed42386c"));
            ActiveBed = (ITTObjectListBox)AddControl(new Guid("50a01909-9b7c-47c0-8ffb-4343290a0917"));
            labelQuarantineProtocolNo = (ITTLabel)AddControl(new Guid("93a0c3ef-0611-4a28-91c7-11e79144d658"));
            labelRoom = (ITTLabel)AddControl(new Guid("66e28b37-e484-42a2-9fd1-4848a21a26bc"));
            labelBed = (ITTLabel)AddControl(new Guid("5819693d-5cb1-4572-b837-443db37bb810"));
            HospitalInpatientDate = (ITTDateTimePicker)AddControl(new Guid("e609af94-8d8e-499b-9832-1113344daa45"));
            labelHospitalInpatientDate = (ITTLabel)AddControl(new Guid("ff3d0c59-fd72-4482-ab67-77b10b27a30d"));
            PhysicalStateClinic = (ITTObjectListBox)AddControl(new Guid("956d90ec-1de0-40fc-9c6a-c581c5c10153"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("e413b4ea-bf45-4f86-a182-d432e4728e38"));
            base.InitializeControls();
        }

        public InPatientAdmissionClinicProcedure() : base("INPATIENTADMISSION", "InPatientAdmissionClinicProcedure")
        {
        }

        protected InPatientAdmissionClinicProcedure(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}