
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
    public partial class PatientTransferRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Birimlerarası Nakil
    /// </summary>
        protected TTObjectClasses.PatientTransfer _PatientTransfer
        {
            get { return (TTObjectClasses.PatientTransfer)_ttObject; }
        }

        protected ITTLabel labelReturnToRequestReason;
        protected ITTTextBox ReturnToRequestReason;
        protected ITTTextBox ReasonForTransfer;
        protected ITTTextBox QuarantineProtocolNo;
        protected ITTTextBox ReasonForInpatientAdmission;
        protected ITTTextBox ReturnToRequestClinicReason;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox RequestClinic;
        protected ITTLabel ttlabel1;
        protected ITTLabel LabelDateTime;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelQuarantineProtocolNo;
        protected ITTDateTimePicker HospitalInpatientDate;
        protected ITTLabel labelReasonForInpatientAdmission;
        protected ITTLabel labelTreatmentClinic;
        protected ITTLabel labelHospitalInpatientDate;
        protected ITTObjectListBox TreatmentClinic;
        protected ITTLabel labelReturnToRequestClinicReason;
        protected ITTObjectListBox RoomGroup;
        protected ITTObjectListBox Room;
        protected ITTObjectListBox Bed;
        override protected void InitializeControls()
        {
            labelReturnToRequestReason = (ITTLabel)AddControl(new Guid("b2b49bec-e966-4d47-a27a-274d041c5270"));
            ReturnToRequestReason = (ITTTextBox)AddControl(new Guid("365bd396-6857-45cd-b82c-d2080f7acd9e"));
            ReasonForTransfer = (ITTTextBox)AddControl(new Guid("8e0254dd-254b-4987-a14d-008b70ade134"));
            QuarantineProtocolNo = (ITTTextBox)AddControl(new Guid("59f78b8a-0f4d-4cad-9a39-c7a3aa535b82"));
            ReasonForInpatientAdmission = (ITTTextBox)AddControl(new Guid("f59ccc6a-2b09-4a06-807b-fff2242883e2"));
            ReturnToRequestClinicReason = (ITTTextBox)AddControl(new Guid("c281f883-22b1-4980-a14a-4da2c07268c6"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("4130accb-cb99-4bf0-b4ac-84c24f2f8918"));
            RequestClinic = (ITTObjectListBox)AddControl(new Guid("6443ac35-3b0d-4508-bd94-814ec8028dde"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e46eec3e-5a5c-4669-aaaa-9be92d540360"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("034f5c28-023f-4182-8cdc-399b641e4a97"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("116d1ffe-897e-4edc-95c4-df702db8d913"));
            labelQuarantineProtocolNo = (ITTLabel)AddControl(new Guid("ce835991-4959-4a3c-9f35-06e73752774f"));
            HospitalInpatientDate = (ITTDateTimePicker)AddControl(new Guid("700f5bf0-b586-45a2-bfe7-3beff910ac45"));
            labelReasonForInpatientAdmission = (ITTLabel)AddControl(new Guid("27ce70b7-156c-42eb-ba95-69e961c42f6c"));
            labelTreatmentClinic = (ITTLabel)AddControl(new Guid("56e9f208-caf5-44fe-a221-8720eb3ac14c"));
            labelHospitalInpatientDate = (ITTLabel)AddControl(new Guid("85674ab6-bbb2-446b-82ad-f2e45560683e"));
            TreatmentClinic = (ITTObjectListBox)AddControl(new Guid("a94cfe59-e7a1-47ed-ab49-fecaef3a970d"));
            labelReturnToRequestClinicReason = (ITTLabel)AddControl(new Guid("b442e2b6-97ce-485f-8be5-2415029e386e"));
            RoomGroup = (ITTObjectListBox)AddControl(new Guid("8cc44733-d186-44e1-9e09-bedbb718068b"));
            Room = (ITTObjectListBox)AddControl(new Guid("73e61576-d173-4d96-9766-cd79fb06277f"));
            Bed = (ITTObjectListBox)AddControl(new Guid("7249b63f-66bf-4f74-9067-b50bce88b36a"));
            base.InitializeControls();
        }

        public PatientTransferRequestForm() : base("PATIENTTRANSFER", "PatientTransferRequestForm")
        {
        }

        protected PatientTransferRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}