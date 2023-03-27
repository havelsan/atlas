
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
    /// Yatan Hasta Klinik İşlemleri
    /// </summary>
    public partial class InPatientTreatmentClinicAcceptionForm : EpisodeActionForm
    {
    /// <summary>
    /// Klinik İşlemleri
    /// </summary>
        protected TTObjectClasses.InPatientTreatmentClinicApplication _InPatientTreatmentClinicApplication
        {
            get { return (TTObjectClasses.InPatientTreatmentClinicApplication)_ttObject; }
        }

        protected ITTPanel ttpanel1;
        protected ITTLabel labelShotInpatientReason;
        protected ITTLabel labelLongInpatientReason;
        protected ITTRichTextBoxControl ShotInpatientReason;
        protected ITTRichTextBoxControl LongInpatientReason;
        protected ITTCheckBox HasAirborneContactIsolationBaseInpatientAdmission;
        protected ITTCheckBox NeedCompanion;
        protected ITTTextBox tttextbox6;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox RequestDoctor;
        protected ITTLabel labelEstimatedInpatientDate;
        protected ITTDateTimePicker EstimatedInpatientDate;
        protected ITTCheckBox HasContactIsolationBaseInpatientAdmission;
        protected ITTLabel labelEstimatedDischargeDate;
        protected ITTCheckBox HasDropletIsolationBaseInpatientAdmission;
        protected ITTLabel ttlabel18;
        protected ITTCheckBox HasFallingRiskBaseInpatientAdmission;
        protected ITTCheckBox HasTightContactIsolationBaseInpatientAdmission;
        protected ITTDateTimePicker EstimatedDischargeDate;
        protected ITTTextBox NumberOfEmptyBeds;
        protected ITTObjectListBox ResponsibleDoctor;
        protected ITTObjectListBox Room;
        protected ITTLabel LabelDateTime;
        protected ITTObjectListBox ResponsibleNurse;
        protected ITTButton TurnReserveToUsed;
        protected ITTLabel labelResponsibleNurse;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelClinicInpatientDate;
        protected ITTObjectListBox PhysicalStateClinic;
        protected ITTLabel labelInpatientProtocolNo;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelQuarantineProtocolNo;
        protected ITTDateTimePicker ClinicInPatientDate;
        protected ITTObjectListBox MasterResource;
        protected ITTTextBox InpatientProtocolNo;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelInpatientDepartment;
        protected ITTLabel ttlabel2;
        protected ITTTextBox QuarantineProtocolNo;
        protected ITTObjectListBox RoomGroup;
        protected ITTLabel labelNumberOfEmptyBeds;
        protected ITTDateTimePicker HospitalInpatientDate;
        protected ITTLabel labelResponsibleDoctor;
        protected ITTLabel labelBed;
        protected ITTLabel labelHospitalInpatientDate;
        protected ITTObjectListBox Bed;
        override protected void InitializeControls()
        {
            ttpanel1 = (ITTPanel)AddControl(new Guid("a0c39028-a72d-4eea-8fbe-f3be88416ed3"));
            labelShotInpatientReason = (ITTLabel)AddControl(new Guid("6e5c39d4-9ccb-4759-8376-69994f794890"));
            labelLongInpatientReason = (ITTLabel)AddControl(new Guid("620493d0-d258-4fbc-bb42-e1a10b0fb807"));
            ShotInpatientReason = (ITTRichTextBoxControl)AddControl(new Guid("65d9f506-b212-4499-9383-6f01bd851e05"));
            LongInpatientReason = (ITTRichTextBoxControl)AddControl(new Guid("0bacefa7-6874-45c2-a581-7c0fc977cf4e"));
            HasAirborneContactIsolationBaseInpatientAdmission = (ITTCheckBox)AddControl(new Guid("0d254b6a-39a4-403e-b5f4-3cf51b48e8e7"));
            NeedCompanion = (ITTCheckBox)AddControl(new Guid("bdb49362-9237-4c99-a383-82bec59238d8"));
            tttextbox6 = (ITTTextBox)AddControl(new Guid("9ebc86bd-9881-40ad-98b6-ba97e8ea116e"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("a0054b38-2825-4048-8305-7d49399ecb60"));
            RequestDoctor = (ITTObjectListBox)AddControl(new Guid("f223fdcc-10ab-48d4-bc26-67dd27b72320"));
            labelEstimatedInpatientDate = (ITTLabel)AddControl(new Guid("d8cc1d58-844f-41c4-b2c1-8fd431b8e866"));
            EstimatedInpatientDate = (ITTDateTimePicker)AddControl(new Guid("d50d46ab-a552-4fd6-a793-a51622379754"));
            HasContactIsolationBaseInpatientAdmission = (ITTCheckBox)AddControl(new Guid("db171330-45e8-4a38-893e-f87e1e49edcf"));
            labelEstimatedDischargeDate = (ITTLabel)AddControl(new Guid("b565c923-af76-431b-bc79-99d77ffd2e8a"));
            HasDropletIsolationBaseInpatientAdmission = (ITTCheckBox)AddControl(new Guid("c61c0aea-9523-41a3-8152-65c2402ee120"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("99f89ddc-d8b4-4119-81f5-e1857d5f5fe2"));
            HasFallingRiskBaseInpatientAdmission = (ITTCheckBox)AddControl(new Guid("69d4da47-9850-473b-99f7-82f5063bae2c"));
            HasTightContactIsolationBaseInpatientAdmission = (ITTCheckBox)AddControl(new Guid("9296e4d7-9a79-4a63-8444-01b2f085598e"));
            EstimatedDischargeDate = (ITTDateTimePicker)AddControl(new Guid("20dcc1af-5ed8-4eca-85b4-8eb8e49baa51"));
            NumberOfEmptyBeds = (ITTTextBox)AddControl(new Guid("f264d1d9-3a1b-4b4b-af38-f5c408b4ad21"));
            ResponsibleDoctor = (ITTObjectListBox)AddControl(new Guid("f3a46403-9c38-4f5a-ba89-19db2a491804"));
            Room = (ITTObjectListBox)AddControl(new Guid("123a6557-4e9d-4466-836b-27b8667a20f1"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("dab1ddae-154d-41e5-a437-fd6256a1de3d"));
            ResponsibleNurse = (ITTObjectListBox)AddControl(new Guid("affc65c0-ebd9-4386-aa64-deadc0f352a4"));
            TurnReserveToUsed = (ITTButton)AddControl(new Guid("6c6f0b64-ef38-4661-b476-a2e7ddbc0f4a"));
            labelResponsibleNurse = (ITTLabel)AddControl(new Guid("2da44448-ffb7-486c-bba9-d8e9aaf535be"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("edad53d6-d57c-4683-aa7e-d98cac7ae9b1"));
            labelClinicInpatientDate = (ITTLabel)AddControl(new Guid("a2ba5597-0660-4e6a-b0ee-baea117b0016"));
            PhysicalStateClinic = (ITTObjectListBox)AddControl(new Guid("f0ca42c1-6d82-47ae-b181-5ed3e107421e"));
            labelInpatientProtocolNo = (ITTLabel)AddControl(new Guid("7c86e8b7-1bc3-4fd2-b90c-659c8acea6e6"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("607e3ca0-5d92-4e6b-99fa-99a893c4d202"));
            labelQuarantineProtocolNo = (ITTLabel)AddControl(new Guid("ff797545-295b-464a-9eb8-f5229975d665"));
            ClinicInPatientDate = (ITTDateTimePicker)AddControl(new Guid("ce897371-e357-4968-9d29-048eb1aa38aa"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("bb665efc-a35d-4fde-85ff-dfb026858604"));
            InpatientProtocolNo = (ITTTextBox)AddControl(new Guid("11e4090d-ecef-4592-a39b-b25a742f16ce"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("ac874a75-1e2b-4de6-9ebd-76e40ea2b4d0"));
            labelInpatientDepartment = (ITTLabel)AddControl(new Guid("78d3df7b-1549-4568-a0b0-8bf71c6d7884"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("772a2bf4-61ad-44a4-a797-94d6a71bf2e0"));
            QuarantineProtocolNo = (ITTTextBox)AddControl(new Guid("3bed72df-f976-4ad9-9a91-ffb2a6c67f5d"));
            RoomGroup = (ITTObjectListBox)AddControl(new Guid("8c55d8aa-4ccf-4c6b-bd90-11f29b3f8e11"));
            labelNumberOfEmptyBeds = (ITTLabel)AddControl(new Guid("9907e7f5-c1ac-4d07-9cff-a5623ad3d835"));
            HospitalInpatientDate = (ITTDateTimePicker)AddControl(new Guid("4586baf4-9c2c-4d88-87c0-ed697a70baa5"));
            labelResponsibleDoctor = (ITTLabel)AddControl(new Guid("2f929d82-2c43-4d19-94c4-3809ed637c0b"));
            labelBed = (ITTLabel)AddControl(new Guid("85e84893-a2a7-49d3-8dbe-c578a9d28dcb"));
            labelHospitalInpatientDate = (ITTLabel)AddControl(new Guid("d3ba98a5-54f7-42a8-b2b7-73dd65f7e521"));
            Bed = (ITTObjectListBox)AddControl(new Guid("e93267b3-846c-46b8-a9bb-a80444dedb47"));
            base.InitializeControls();
        }

        public InPatientTreatmentClinicAcceptionForm() : base("INPATIENTTREATMENTCLINICAPPLICATION", "InPatientTreatmentClinicAcceptionForm")
        {
        }

        protected InPatientTreatmentClinicAcceptionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}