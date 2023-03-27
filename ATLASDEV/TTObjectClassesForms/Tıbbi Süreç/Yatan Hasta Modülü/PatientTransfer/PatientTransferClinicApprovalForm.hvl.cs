
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
    /// Birimlerarası Nakil 
    /// </summary>
    public partial class PatientTransferClinicApprovalForm : EpisodeActionForm
    {
    /// <summary>
    /// Birimlerarası Nakil
    /// </summary>
        protected TTObjectClasses.PatientTransfer _PatientTransfer
        {
            get { return (TTObjectClasses.PatientTransfer)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTTextBox ReasonForTransfer;
        protected ITTTextBox QuarantineProtocolNo;
        protected ITTTextBox ReasonForInpatientAdmission;
        protected ITTTextBox Description;
        protected ITTTextBox NumberOfEmptyBeds;
        protected ITTLabel LabelDateTime;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelReasonForInpatientAdmission;
        protected ITTLabel labeOldlRoomGroup;
        protected ITTLabel labelHospitalInpatientDate;
        protected ITTObjectListBox OldRoom;
        protected ITTLabel labelOldRoom;
        protected ITTObjectListBox OldRoomGroup;
        protected ITTDateTimePicker HospitalInpatientDate;
        protected ITTObjectListBox OldBed;
        protected ITTLabel labelQuarantineProtocolNo;
        protected ITTLabel labelDescription;
        protected ITTObjectListBox TreatmentClinic;
        protected ITTLabel labelTreatmentClinic;
        protected ITTLabel labelOldBed;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox PhysicalStateClinic;
        protected ITTLabel labelPhysicalStateClinic;
        protected ITTLabel labelTransferredRoom;
        protected ITTLabel labelTransferredClinic;
        protected ITTObjectListBox RoomGroup;
        protected ITTObjectListBox Bed;
        protected ITTLabel labelNumberOfEmptyBeds;
        protected ITTObjectListBox Room;
        protected ITTLabel labelTransferredBed;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("aa9c599d-a87d-4160-ad0c-4d54353ab910"));
            ReasonForTransfer = (ITTTextBox)AddControl(new Guid("008fdce6-c8f5-4658-9973-a9fd3fb4c3f8"));
            QuarantineProtocolNo = (ITTTextBox)AddControl(new Guid("4022ee73-0807-4454-b9b9-6f5f310ba2df"));
            ReasonForInpatientAdmission = (ITTTextBox)AddControl(new Guid("d7e7d6b6-8224-4b9e-b44f-95282ab9bf39"));
            Description = (ITTTextBox)AddControl(new Guid("4822b8f2-8860-46ff-a355-8a3283c40435"));
            NumberOfEmptyBeds = (ITTTextBox)AddControl(new Guid("40f26162-c74c-4b51-85e3-0c01dc7af613"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("6ae8465b-1bc7-4e97-b3a4-caedbcab020c"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("318c7f32-70b2-4704-a84f-adcd0b9cdcb3"));
            labelReasonForInpatientAdmission = (ITTLabel)AddControl(new Guid("c5e93e85-ed5e-4a3b-8b10-bcbf7a705c41"));
            labeOldlRoomGroup = (ITTLabel)AddControl(new Guid("c7009abf-caea-40a2-8640-0278ef2e761d"));
            labelHospitalInpatientDate = (ITTLabel)AddControl(new Guid("6d6d2166-7b8d-4da9-8c44-7b227d6dd831"));
            OldRoom = (ITTObjectListBox)AddControl(new Guid("06277003-6c3c-41ed-bbc8-d78881cba3e1"));
            labelOldRoom = (ITTLabel)AddControl(new Guid("a5e5391f-d3eb-41b0-92ff-6a593bf5796c"));
            OldRoomGroup = (ITTObjectListBox)AddControl(new Guid("56bc7682-a1de-4f1e-8774-8fd26933f0f3"));
            HospitalInpatientDate = (ITTDateTimePicker)AddControl(new Guid("ac0e3a5d-3216-4511-96b3-22f1d05c73fe"));
            OldBed = (ITTObjectListBox)AddControl(new Guid("ccc1c1c7-d08a-4139-93c3-b95d7612cdc4"));
            labelQuarantineProtocolNo = (ITTLabel)AddControl(new Guid("e7b1520a-d7a0-4155-aece-da5d3d6f6f11"));
            labelDescription = (ITTLabel)AddControl(new Guid("e1edf259-8e4a-464c-93e4-cd7d3e62d0a4"));
            TreatmentClinic = (ITTObjectListBox)AddControl(new Guid("afed8f09-1013-4d23-a39b-b3b023ab6e71"));
            labelTreatmentClinic = (ITTLabel)AddControl(new Guid("79356f2b-ad73-45f6-a486-0a7a16647122"));
            labelOldBed = (ITTLabel)AddControl(new Guid("1ce6fd59-3412-43e5-b453-05bccf0c51c7"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("b6ee80e6-cb31-46b2-ad8d-ed8273f73994"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("019a1349-0972-4e8d-8e49-27a41df78d60"));
            PhysicalStateClinic = (ITTObjectListBox)AddControl(new Guid("3626626b-5e2e-434c-b8fb-7a99d11a01f8"));
            labelPhysicalStateClinic = (ITTLabel)AddControl(new Guid("7f476386-3000-4391-acea-e01af050b569"));
            labelTransferredRoom = (ITTLabel)AddControl(new Guid("50ee57ea-db5d-41b7-9816-64c208b091d7"));
            labelTransferredClinic = (ITTLabel)AddControl(new Guid("ddb3ca04-8d48-45dc-be6c-19062a94a87a"));
            RoomGroup = (ITTObjectListBox)AddControl(new Guid("2322b440-08ba-44f3-9e11-a8d2f6e50999"));
            Bed = (ITTObjectListBox)AddControl(new Guid("364ea987-a691-4ef2-a52a-69627aaa08a9"));
            labelNumberOfEmptyBeds = (ITTLabel)AddControl(new Guid("82216873-e8c4-4e18-9765-e84201ecab3a"));
            Room = (ITTObjectListBox)AddControl(new Guid("3f30998a-887e-492c-a831-2d7387403730"));
            labelTransferredBed = (ITTLabel)AddControl(new Guid("8bbaa52f-91a2-4755-ad59-a7789eac0999"));
            base.InitializeControls();
        }

        public PatientTransferClinicApprovalForm() : base("PATIENTTRANSFER", "PatientTransferClinicApprovalForm")
        {
        }

        protected PatientTransferClinicApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}