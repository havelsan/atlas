
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
    public partial class PlannedMedicalActionRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Planlı Tıbbi İşlem İstek
    /// </summary>
        protected TTObjectClasses.PlannedMedicalActionRequest _PlannedMedicalActionRequest
        {
            get { return (TTObjectClasses.PlannedMedicalActionRequest)_ttObject; }
        }

        protected ITTCheckBox chkInPatientBed;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel lblEpisodeDiagnosis;
        protected ITTDateTimePicker RequestDate;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage PlannedMedicalActionOrder;
        protected ITTGrid PlannedMedicalActions;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTListBoxColumn TreatmentUnit;
        protected ITTTextBoxColumn ApplicationArea;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn Duration;
        protected ITTTextBoxColumn TreatmentProperties;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox Note;
        protected ITTTabPage ClinicInfo;
        protected ITTTextBox ClinicFindings;
        protected ITTTabPage TabClinicInformation;
        protected ITTRichTextBoxControl ClinicInfoRTF;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelRequestDate;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox Bed;
        protected ITTObjectListBox RoomGroup;
        protected ITTLabel labelRoomGroup;
        protected ITTObjectListBox Room;
        protected ITTLabel labelRoom;
        protected ITTLabel labelBed;
        protected ITTObjectListBox PhysicalStateClinic;
        protected ITTLabel labelPhysicalStateClinic;
        override protected void InitializeControls()
        {
            chkInPatientBed = (ITTCheckBox)AddControl(new Guid("a213457b-247d-432c-bb6b-6e0e1ef92d4b"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("395dd7ea-721b-40a7-9109-7cbeb1d7a12a"));
            lblEpisodeDiagnosis = (ITTLabel)AddControl(new Guid("5da75622-1759-4c01-8b81-33ca759f63e0"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("7891d94d-1a48-49fb-9581-78fa54baf898"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("28e50bf7-d53e-412b-bdd2-9dd6405b79ef"));
            PlannedMedicalActionOrder = (ITTTabPage)AddControl(new Guid("c6a0d46f-c46d-40cd-b64d-40f3ecb4a1ab"));
            PlannedMedicalActions = (ITTGrid)AddControl(new Guid("da88199f-17ad-4c37-8d55-d39bf89f0f72"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("c897c97b-91f6-4c47-bc7e-604bb63c8884"));
            TreatmentUnit = (ITTListBoxColumn)AddControl(new Guid("e7b76681-40fb-40a6-8747-910a92878059"));
            ApplicationArea = (ITTTextBoxColumn)AddControl(new Guid("beca8579-21f7-486c-85c0-b272a4b30ab1"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("6527a3a2-c54f-4c77-9cbc-1611fb748c6e"));
            Duration = (ITTTextBoxColumn)AddControl(new Guid("e829e513-4b3c-40e7-9527-f0edd5dfab9e"));
            TreatmentProperties = (ITTTextBoxColumn)AddControl(new Guid("fd3570b1-5dcd-4d89-b9c7-2df455e7c418"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("d1d0953d-2926-4e0a-b3c6-ff2cd635de45"));
            Note = (ITTTextBox)AddControl(new Guid("6f0fec29-fd0c-40f6-8b44-f5fe77ff4255"));
            ClinicInfo = (ITTTabPage)AddControl(new Guid("13cd384d-df24-477e-b7a4-a7c79cdd9af6"));
            ClinicFindings = (ITTTextBox)AddControl(new Guid("d8696a54-8387-4552-ac22-8f9837c09607"));
            TabClinicInformation = (ITTTabPage)AddControl(new Guid("e9b16508-38ca-4ef1-b65b-d67bf60b5f09"));
            ClinicInfoRTF = (ITTRichTextBoxControl)AddControl(new Guid("aeb2dbe8-05a2-4a3a-a3fc-fb282a13bd3d"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("6257a12a-2dad-47a2-b794-a1c4c0f14356"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("ae43663b-aabe-4bd1-b73b-b2220cc7e2a6"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("843fe379-2d8e-4ccd-b163-a2aebec34e29"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("e858a359-c5d4-4faa-b0ee-0d4ab86f7543"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("9e546cb1-8b4c-4ee9-9a1f-ba3478606323"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("b4ca64ad-8d97-42c9-8082-15f9df5a1f8b"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("c61de6fe-bd68-4357-a764-557b75beb535"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("94dd6e48-f1bd-4250-8978-db6d6ee309d0"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("000a600f-b7b6-4719-ae02-ee3b2395d448"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("29c6d1ab-f98f-4628-aa35-f1ba979e566a"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("a46a16a1-51a6-4963-bf95-4c8dad7b4e6f"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("dbcd64d5-3643-4178-b53c-3a3eb3489db7"));
            Bed = (ITTObjectListBox)AddControl(new Guid("897b2d56-da65-46c1-9355-b8c8c4fc8244"));
            RoomGroup = (ITTObjectListBox)AddControl(new Guid("5a5552da-6943-4af1-aeff-d3cf82ed1b71"));
            labelRoomGroup = (ITTLabel)AddControl(new Guid("647693d8-08eb-4fca-8770-33e6ecc935ed"));
            Room = (ITTObjectListBox)AddControl(new Guid("247afebe-8f0b-4861-868c-10e812f6faec"));
            labelRoom = (ITTLabel)AddControl(new Guid("e734eae1-5a10-4107-9ef0-28d438fc8425"));
            labelBed = (ITTLabel)AddControl(new Guid("09b5e2d4-1925-452b-894e-c0dfa0977625"));
            PhysicalStateClinic = (ITTObjectListBox)AddControl(new Guid("91e21be4-b0ae-4bd6-ab56-f68b44d79beb"));
            labelPhysicalStateClinic = (ITTLabel)AddControl(new Guid("bcfc5bb8-67e9-4ba3-bcf2-d3c7a35751ea"));
            base.InitializeControls();
        }

        public PlannedMedicalActionRequestForm() : base("PLANNEDMEDICALACTIONREQUEST", "PlannedMedicalActionRequestForm")
        {
        }

        protected PlannedMedicalActionRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}