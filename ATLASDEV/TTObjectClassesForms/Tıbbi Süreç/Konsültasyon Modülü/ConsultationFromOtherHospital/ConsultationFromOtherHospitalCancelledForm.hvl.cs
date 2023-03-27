
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
    /// Diğer XXXXXXlerden Konsültasyon 
    /// </summary>
    public partial class ConsultationFromOtherHospitalCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Dış XXXXXXlerden Konsültasyon
    /// </summary>
        protected TTObjectClasses.ConsultationFromOtherHospital _ConsultationFromOtherHospital
        {
            get { return (TTObjectClasses.ConsultationFromOtherHospital)_ttObject; }
        }

        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage GridDiagnosisEntry;
        protected ITTGrid SecDiagnosisGrid;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTListBoxColumn Diagnose;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTTabPage EpisodeDiagnosis;
        protected ITTGrid DiagnosisGrid;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTextBox Symptom;
        protected ITTTextBox ConsultationResultAndOffers;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox RequestDescription;
        protected ITTTextBox ReasonOfCancel;
        protected ITTTextBox RequesterResourceName;
        protected ITTLabel labelActionDate;
        protected ITTLabel labelRequestDescription;
        protected ITTLabel ttlabel10;
        protected ITTObjectListBox RequesterHospital;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel11;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelSymptom;
        protected ITTLabel ttlabel13;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelConsultationResultAndOffers;
        protected ITTLabel labelReasonOfCancel;
        protected ITTLabel ttlabel8;
        protected ITTObjectListBox RequesterDoctor;
        protected ITTObjectListBox RequestedDepartment;
        protected ITTObjectListBox RequestedHospital;
        protected ITTLabel labelRequestedExternalDepartment;
        protected ITTObjectListBox RequestedExternalHospital;
        protected ITTLabel labelRequestedExternalHospital;
        protected ITTObjectListBox RequestedExternalDepartment;
        override protected void InitializeControls()
        {
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("5ca47f99-b458-48f4-b6fd-ef270d3dfd10"));
            GridDiagnosisEntry = (ITTTabPage)AddControl(new Guid("21070e60-07e6-4164-8a42-31950568989c"));
            SecDiagnosisGrid = (ITTGrid)AddControl(new Guid("28111a4b-b907-4749-8885-addcc217c959"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("76cabe49-6463-47e6-b718-b1530cb81d03"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("3a2b2a64-ab9e-4264-832d-f8e02d0d8d48"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("9806f796-e803-4340-a472-28ae94b9fdf9"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("0b7298cf-15c7-4240-a44e-854d738a711d"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("e3de4edf-b9e0-419d-8c07-502501a7b60f"));
            EpisodeDiagnosis = (ITTTabPage)AddControl(new Guid("5c633351-e276-4f97-bb10-d10ae77baf3d"));
            DiagnosisGrid = (ITTGrid)AddControl(new Guid("b8a8c58c-7bb8-4cdb-b434-c436f5bf8722"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("d4830a86-64aa-4aba-9628-96ef7364797e"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("c33c8e6d-1be2-4b05-8540-5a0693f843b2"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("b9c3ab78-9171-42f6-94e1-abed348a9868"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("456acb8b-2321-48aa-9702-9aef45e0178e"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("7adc9841-2edd-4701-82d1-05be9fe5be76"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("5c5db278-8231-4d4d-b558-696881c8f696"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("639e7940-fb0e-4228-93f1-2817013dbcc8"));
            Symptom = (ITTTextBox)AddControl(new Guid("7a0b20f8-f3ce-438e-baec-91116f61957f"));
            ConsultationResultAndOffers = (ITTTextBox)AddControl(new Guid("591b589c-d8e7-4c41-8d08-d8527d499617"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("18bded35-7484-44cb-b5e3-2abdddc13c2e"));
            RequestDescription = (ITTTextBox)AddControl(new Guid("9b089240-fead-4997-a9aa-407529737791"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("4852bfa4-935c-4787-9b7c-360067c50e69"));
            RequesterResourceName = (ITTTextBox)AddControl(new Guid("2b25f94e-3b87-4c4a-85a2-86711734476e"));
            labelActionDate = (ITTLabel)AddControl(new Guid("5892cc4a-1aa3-4f8e-9b9f-63157663d852"));
            labelRequestDescription = (ITTLabel)AddControl(new Guid("2257e513-4d96-463f-9d7b-9e3f5f8d8260"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("218a98da-49e7-4e61-8e5b-e6e578939f89"));
            RequesterHospital = (ITTObjectListBox)AddControl(new Guid("0043f7bb-20cf-4be9-88d7-7911d3bccb24"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("1a140ac4-10d9-4cd9-a2a0-728ee79485d1"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("804d82d6-c25d-49a5-8efe-20e514f8c81f"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("ea6633a2-643a-42f9-9436-2928f3230029"));
            labelSymptom = (ITTLabel)AddControl(new Guid("32063fe1-2568-451b-9ddf-e464c75e91ae"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("61bc7463-38a0-411a-9919-08ea95a65c08"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("305465f3-3a17-473e-9961-96ddc3d0821d"));
            labelConsultationResultAndOffers = (ITTLabel)AddControl(new Guid("008c3ae3-0b28-4b43-94ba-42b3feaf4dfb"));
            labelReasonOfCancel = (ITTLabel)AddControl(new Guid("a9958262-604d-4926-8951-bf9cd9fa0d92"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("41953b49-bc49-4f11-96e8-08784fa967cd"));
            RequesterDoctor = (ITTObjectListBox)AddControl(new Guid("6ce8b290-0f7e-4317-8eb2-da8887d6ed42"));
            RequestedDepartment = (ITTObjectListBox)AddControl(new Guid("c49ea587-9f60-42a4-9807-485e4fba840d"));
            RequestedHospital = (ITTObjectListBox)AddControl(new Guid("076a108d-9f74-45d4-b1a0-92d9be80de0a"));
            labelRequestedExternalDepartment = (ITTLabel)AddControl(new Guid("914ad8d1-1a5f-443a-a6e4-40efe32261e3"));
            RequestedExternalHospital = (ITTObjectListBox)AddControl(new Guid("a821899c-a1f6-4359-b1e9-d420f4e537d2"));
            labelRequestedExternalHospital = (ITTLabel)AddControl(new Guid("6ee63379-95c8-42b4-bea5-8fafe14047a6"));
            RequestedExternalDepartment = (ITTObjectListBox)AddControl(new Guid("0b02e41d-a0fb-4c0e-a02f-66ded00b4439"));
            base.InitializeControls();
        }

        public ConsultationFromOtherHospitalCancelledForm() : base("CONSULTATIONFROMOTHERHOSPITAL", "ConsultationFromOtherHospitalCancelledForm")
        {
        }

        protected ConsultationFromOtherHospitalCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}