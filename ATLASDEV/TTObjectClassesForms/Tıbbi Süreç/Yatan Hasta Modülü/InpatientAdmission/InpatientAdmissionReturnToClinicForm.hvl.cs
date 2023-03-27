
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
    public partial class InpatientAdmissionReturnToClinic : InPatientAdmissionBaseForm
    {
    /// <summary>
    /// Hasta Yatış  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.InpatientAdmission _InpatientAdmission
        {
            get { return (TTObjectClasses.InpatientAdmission)_ttObject; }
        }

        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel1;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage TratmentClinicTab;
        protected ITTGrid TratmentClinicsGrid;
        protected ITTListBoxColumn TreatmentClinic;
        protected ITTDateTimePickerColumn ClinicInpatientDate;
        protected ITTDateTimePickerColumn ClinicDischargeDate;
        protected ITTListBoxColumn ResponsibleDoctor;
        protected ITTTabPage DiagnosisTab;
        protected ITTGrid EpisodeDiagnosis;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTListBoxColumn Diagnose;
        protected ITTEnumComboBoxColumn DiagnosisType;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabPage BedsTab;
        protected ITTGrid BedsGrid;
        protected ITTDateTimePickerColumn BedInPatientDate;
        protected ITTDateTimePickerColumn BedDischargeDate;
        protected ITTListBoxColumn RoomGroup;
        protected ITTListBoxColumn Room;
        protected ITTListBoxColumn Bed;
        protected ITTTextBoxColumn BedAmount;
        protected ITTEnumComboBoxColumn UsedStatus;
        override protected void InitializeControls()
        {
            tttextbox1 = (ITTTextBox)AddControl(new Guid("9436f5b3-adc3-43eb-9536-496240ffc178"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d95a728e-cfcd-4764-8dee-b63251c6e807"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("6eb81ac9-7b26-4e21-b1ca-1dbbaadde5fb"));
            TratmentClinicTab = (ITTTabPage)AddControl(new Guid("7b38f969-b1b0-4b21-b1eb-58399fdf62e3"));
            TratmentClinicsGrid = (ITTGrid)AddControl(new Guid("8fe917f2-7739-4d88-915f-86b3f3be4c37"));
            TreatmentClinic = (ITTListBoxColumn)AddControl(new Guid("54a3a09e-f3b3-42fa-82cc-8d9f79bf6c64"));
            ClinicInpatientDate = (ITTDateTimePickerColumn)AddControl(new Guid("199d6395-182e-436f-98fe-817590c067ff"));
            ClinicDischargeDate = (ITTDateTimePickerColumn)AddControl(new Guid("3b386d86-8597-4bb8-9d61-2ff3c5d6184f"));
            ResponsibleDoctor = (ITTListBoxColumn)AddControl(new Guid("5241cfad-f2df-4299-8a1c-1f2ec4738131"));
            DiagnosisTab = (ITTTabPage)AddControl(new Guid("05321455-90fd-43bd-aacb-5f69ea36b1f1"));
            EpisodeDiagnosis = (ITTGrid)AddControl(new Guid("e4bbc8d7-1eee-4b6e-8fd0-3cfd14ce6b73"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("eb352c8d-2e45-4a86-a7f5-c64b4733e6b5"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("086e2ea7-e039-43a9-8be5-2fa206316b12"));
            DiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("caefd038-ce3e-4e77-a6d6-5b877b1dd736"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("8f4dad59-9488-4d43-aa5f-168cbd7808ee"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("8690f1d9-6677-4031-a796-21790553b0db"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("1b4fe97a-f8d7-448e-8def-47315c61673c"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("33fcd4b7-819d-48a1-9a2a-973e8b0249bf"));
            BedsTab = (ITTTabPage)AddControl(new Guid("5aba1610-d165-4403-bcbc-7365a7c202fc"));
            BedsGrid = (ITTGrid)AddControl(new Guid("67c59952-445a-41ec-bfe6-923984ae15d0"));
            BedInPatientDate = (ITTDateTimePickerColumn)AddControl(new Guid("ddab19fa-066d-4a94-8de8-917053895809"));
            BedDischargeDate = (ITTDateTimePickerColumn)AddControl(new Guid("c0d55a1f-1972-43bf-8bc8-0376f8a34f08"));
            RoomGroup = (ITTListBoxColumn)AddControl(new Guid("46ea480c-95c1-4386-8272-205538f1e01b"));
            Room = (ITTListBoxColumn)AddControl(new Guid("3970be4c-3913-4367-9070-9fa041ab198e"));
            Bed = (ITTListBoxColumn)AddControl(new Guid("487611e2-46ca-42b7-a194-7de58ad636a9"));
            BedAmount = (ITTTextBoxColumn)AddControl(new Guid("7e281578-1b0b-4904-81d8-9f87c396bb14"));
            UsedStatus = (ITTEnumComboBoxColumn)AddControl(new Guid("1bd33153-ee5f-42af-981b-edd93dffb6c5"));
            base.InitializeControls();
        }

        public InpatientAdmissionReturnToClinic() : base("INPATIENTADMISSION", "InpatientAdmissionReturnToClinic")
        {
        }

        protected InpatientAdmissionReturnToClinic(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}