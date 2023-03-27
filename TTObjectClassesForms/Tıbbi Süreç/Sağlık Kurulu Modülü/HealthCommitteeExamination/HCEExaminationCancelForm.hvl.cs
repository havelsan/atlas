
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
    /// Sağlık Kurulu Muayenesi
    /// </summary>
    public partial class HCEExaminationCancelForm : EpisodeActionForm
    {
    /// <summary>
    /// Sağlık Kurulu Muayenesi İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.HealthCommitteeExamination _HealthCommitteeExamination
        {
            get { return (TTObjectClasses.HealthCommitteeExamination)_ttObject; }
        }

        protected ITTRichTextBoxControl Report;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage DiagnosisEntryTab;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn SecAddToHistory;
        protected ITTListBoxColumn SecDiagnose;
        protected ITTTextBoxColumn SecFreeDiagnosis;
        protected ITTCheckBoxColumn SecIsMainDiagnose;
        protected ITTListBoxColumn SecResponsibleUser;
        protected ITTDateTimePickerColumn SecDiagnoseDate;
        protected ITTTabPage EpisodeDiagnosisTab;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTTextBoxColumn EpisodeFreeDiagnosis;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabPage MalzemeSarf;
        protected ITTGrid TreatmentMaterialsGrid;
        protected ITTDateTimePickerColumn TreatmentMaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn UBBCode;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBox NumberOfProcess;
        protected ITTTextBox ReportNo;
        protected ITTLabel ttlabel4;
        protected ITTEnumComboBox PatientStatus;
        protected ITTObjectListBox ReasonForExamination;
        protected ITTDateTimePicker ReportDate;
        protected ITTLabel labelReportNo;
        protected ITTEnumComboBox PatientGroup;
        protected ITTLabel labelReasonForAdmission;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelStartDate;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTLabel labelNumberOfProcedure;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker HealtCommitteeStartDate;
        protected ITTLabel labelReportDate;
        override protected void InitializeControls()
        {
            Report = (ITTRichTextBoxControl)AddControl(new Guid("f1f5fda6-8899-47a6-9cac-e131bd03405b"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("ef42d1cf-b67c-4785-b853-e03ecd74eb3d"));
            DiagnosisEntryTab = (ITTTabPage)AddControl(new Guid("1ffff16d-40f1-40e6-80ef-0b9616e3c7ce"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("e8ab6cc2-ce7e-4e31-955a-1d4a3c7b4199"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("f96747f8-0ce9-4f15-80c9-ce1b0247b988"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("a4bbd383-3235-4b11-8360-706003bc25b8"));
            SecFreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("d95c6564-9d80-4931-8ae2-aa90a7dcecb6"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("0e3670c0-387f-4cac-ad39-6d015edafcf4"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("6f3901b1-9e15-40a9-8f6d-890a4f3af01c"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("671949ae-30dc-431b-b678-a8d1e6d65ab5"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("03ab7f09-33de-4da1-a389-526ea3ce8e54"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("ed04e735-9c01-4300-af33-782da13404b6"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("daea19cd-32df-4382-9d3a-a73bdf8527c9"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("8971561f-f00c-4e44-868f-80c334cf87e2"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("4e918de0-5c49-4647-be2c-6ed8bd916439"));
            EpisodeFreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("9f1cd767-a77c-4031-abcf-f88ef435063c"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("909d4a47-6661-4bf1-ab3f-588add66b889"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("2e5d506a-5220-4704-90c6-57ddfbc58bbb"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("4fbc04e7-bc0d-4b03-a639-a3ceaa75c953"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("1a948c34-2f29-4a7d-8259-a835ef204483"));
            MalzemeSarf = (ITTTabPage)AddControl(new Guid("e30b1d7c-31b9-4a6d-aa02-4ae6e61c692e"));
            TreatmentMaterialsGrid = (ITTGrid)AddControl(new Guid("52f80dba-8563-4cd2-b5ef-3a33ac3fe6cc"));
            TreatmentMaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("db63ae3a-d155-4e9a-8831-b0b9b6a63cec"));
            Material = (ITTListBoxColumn)AddControl(new Guid("51993f21-5b83-428a-a5a3-a51ddc7be6b5"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("1dcba441-f738-4e83-9a1a-57cc4b6f37f2"));
            UBBCode = (ITTTextBoxColumn)AddControl(new Guid("b1cb943c-f0aa-468e-b1e5-05761ea553a0"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("c009e005-71f9-446b-b921-08ac189e7eb5"));
            NumberOfProcess = (ITTTextBox)AddControl(new Guid("538ef372-4ba5-4c7f-8043-c4ba64827ab1"));
            ReportNo = (ITTTextBox)AddControl(new Guid("80b94bd1-e4ca-4496-ad6e-332b6ed7468f"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("d3c37db0-c6fb-4493-a709-ee1aad9acd4e"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("ea57bd88-bcc5-432d-a5a4-c1975c07d873"));
            ReasonForExamination = (ITTObjectListBox)AddControl(new Guid("a0384941-24cb-4aca-ac05-8711bad11873"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("0e42ca4c-9a4c-4753-b64f-c3c7a44106a5"));
            labelReportNo = (ITTLabel)AddControl(new Guid("5ffd8b56-43b1-4f05-8635-a9595ce17e7b"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("1e1ec9fe-1ea3-481c-a157-0ac90a0c0eef"));
            labelReasonForAdmission = (ITTLabel)AddControl(new Guid("ac183008-2717-444e-9c55-9883a8e902ae"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("f0414b99-e97f-4e70-8b92-eaa268bda1b4"));
            labelStartDate = (ITTLabel)AddControl(new Guid("9423cd2e-69dd-43be-b076-adab1b3df6d9"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("9be8b962-767b-4156-b2a6-72d2fea77d0f"));
            labelNumberOfProcedure = (ITTLabel)AddControl(new Guid("3e2d2490-f4e4-47eb-96be-d4ec6a2d6107"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("47a85b8a-7d4c-47d6-b9ce-8a3cf198a63e"));
            HealtCommitteeStartDate = (ITTDateTimePicker)AddControl(new Guid("a7c69dda-0ac2-48b0-9c4d-b851835e3211"));
            labelReportDate = (ITTLabel)AddControl(new Guid("68dbc818-50fd-4cda-893e-eb8364d28278"));
            base.InitializeControls();
        }

        public HCEExaminationCancelForm() : base("HEALTHCOMMITTEEEXAMINATION", "HCEExaminationCancelForm")
        {
        }

        protected HCEExaminationCancelForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}