
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
    /// Zeyil(Ek Rapor)
    /// </summary>
    public partial class RedecisionAcceptanceForm : EpisodeActionForm
    {
    /// <summary>
    /// Zeyil(İptal Edildi)
    /// </summary>
        protected TTObjectClasses.Redecision _Redecision
        {
            get { return (TTObjectClasses.Redecision)_ttObject; }
        }

        protected ITTRichTextBoxControl Report;
        protected ITTLabel labelReport;
        protected ITTLabel labelReportNo;
        protected ITTLabel labelBookNo;
        protected ITTLabel labelReasonForExamination;
        protected ITTDateTimePicker ReportDate;
        protected ITTTextBox BookNo;
        protected ITTTextBox PreDiagnosis;
        protected ITTTextBox ReportNo;
        protected ITTLabel labelPreDiagnosis;
        protected ITTGrid MatterSliceAnectodes;
        protected ITTTextBoxColumn Slice2;
        protected ITTTextBoxColumn Matter2;
        protected ITTTextBoxColumn Anectode2;
        protected ITTLabel labelReportDate;
        protected ITTLabel ttlabel1;
        protected ITTGrid OldReports;
        protected ITTListBoxColumn Diagnoses;
        protected ITTTextBoxColumn Explanation;
        protected ITTTextBoxColumn Decision;
        protected ITTTextBoxColumn Matter;
        protected ITTTextBoxColumn Slice;
        protected ITTTextBoxColumn Anectode;
        protected ITTEnumComboBox PatientGroup;
        protected ITTObjectListBox ReasonForExamination;
        protected ITTLabel ttlabel4;
        protected ITTGrid Diagnosis;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTListBoxColumn Diagnose;
        protected ITTEnumComboBoxColumn DiagnosisType;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        override protected void InitializeControls()
        {
            Report = (ITTRichTextBoxControl)AddControl(new Guid("d73ea8d6-49ab-45fd-a208-eb1dcebed154"));
            labelReport = (ITTLabel)AddControl(new Guid("3d2798ac-17ca-4dc8-8e93-07f4d2e2370b"));
            labelReportNo = (ITTLabel)AddControl(new Guid("89798fe4-5f7c-43ca-a5ab-16111f1b52ce"));
            labelBookNo = (ITTLabel)AddControl(new Guid("1aa144cf-7b98-4d96-bc3c-1dfcbcded708"));
            labelReasonForExamination = (ITTLabel)AddControl(new Guid("d93b78de-efc4-4ba0-8a23-208ca7fb8c59"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("3ee36404-86b4-42ae-959f-2a63611a3d22"));
            BookNo = (ITTTextBox)AddControl(new Guid("335156fb-10cf-452d-b052-2d292b91ed7b"));
            PreDiagnosis = (ITTTextBox)AddControl(new Guid("294b452e-cb59-471d-bc08-91b0529c0fa5"));
            ReportNo = (ITTTextBox)AddControl(new Guid("46bcb07e-c2d2-45e3-95c7-cc9be4432b29"));
            labelPreDiagnosis = (ITTLabel)AddControl(new Guid("6829ae8b-400e-4d3e-96b9-3641f40d3feb"));
            MatterSliceAnectodes = (ITTGrid)AddControl(new Guid("106901d2-ad5b-4fc8-b6a9-43d74415c2f0"));
            Slice2 = (ITTTextBoxColumn)AddControl(new Guid("0d1c7b82-b7d1-4318-ab95-1dd97e8809f2"));
            Matter2 = (ITTTextBoxColumn)AddControl(new Guid("ad326ebc-397c-458d-9741-0ed5d44a0357"));
            Anectode2 = (ITTTextBoxColumn)AddControl(new Guid("c51f01e8-0ef1-4660-88e7-6690b43c93fa"));
            labelReportDate = (ITTLabel)AddControl(new Guid("7964ab25-31ec-467b-8afe-51b9b8844b60"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("fcf7b411-f7f8-449e-8a92-6473a8aac90c"));
            OldReports = (ITTGrid)AddControl(new Guid("70fc112c-efcd-4cc5-a349-83787d86cfba"));
            Diagnoses = (ITTListBoxColumn)AddControl(new Guid("c7fb6f55-657d-427d-bc0c-0f308bd35fee"));
            Explanation = (ITTTextBoxColumn)AddControl(new Guid("ee426f7e-30c2-4c37-98d6-3875fdebc9ca"));
            Decision = (ITTTextBoxColumn)AddControl(new Guid("d16d9c8f-df94-4933-a1f1-0d654e1ddc0d"));
            Matter = (ITTTextBoxColumn)AddControl(new Guid("75ae88c7-6ad4-4e3c-a45c-9f61d6d2e4d0"));
            Slice = (ITTTextBoxColumn)AddControl(new Guid("12adc1b9-6c6a-4e0f-8455-1143842e5bc9"));
            Anectode = (ITTTextBoxColumn)AddControl(new Guid("2efa4d5b-2b6c-4bc2-b0df-7331c1c625eb"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("1812c6fc-3c55-4366-ab87-8cf358108b53"));
            ReasonForExamination = (ITTObjectListBox)AddControl(new Guid("4d037c86-86e1-4752-87d1-9b4c3a294181"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("9b2b09be-36d6-4e06-99c3-c755f8ef84fe"));
            Diagnosis = (ITTGrid)AddControl(new Guid("fad80c66-3c03-4727-840a-e564f414d310"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("9e0caebc-12a6-46fa-a3a7-2c7a6b04b699"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("11e9aedd-b428-442c-a174-6056cb134b59"));
            DiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("f6752288-c9bd-497a-83c5-b302f418372c"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("ce55f7f8-0146-4b88-aac3-c5a950e59b7b"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("b0f3e696-afb0-4d2b-a6e5-4498abf2c592"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("c76980a1-bf74-490f-bf97-970e9a65a7b5"));
            base.InitializeControls();
        }

        public RedecisionAcceptanceForm() : base("REDECISION", "RedecisionAcceptanceForm")
        {
        }

        protected RedecisionAcceptanceForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}