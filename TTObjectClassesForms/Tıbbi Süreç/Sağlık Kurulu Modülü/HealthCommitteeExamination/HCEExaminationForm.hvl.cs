
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
    /// Sağlık Kurulu Muayenesi-İlgili Uzman
    /// </summary>
    public partial class HCEExaminationForm : EpisodeActionForm
    {
    /// <summary>
    /// Sağlık Kurulu Muayenesi İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.HealthCommitteeExamination _HealthCommitteeExamination
        {
            get { return (TTObjectClasses.HealthCommitteeExamination)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tpExamination;
        protected ITTLabel labelDisabledRatio;
        protected ITTTextBox DisabledRatio;
        protected ITTRichTextBoxControl Report;
        protected ITTTextBox OfferOfDecision;
        protected ITTLabel ttlabel5;
        protected ITTTextBox Weight;
        protected ITTLabel labelReportNo;
        protected ITTTextBox Height;
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
        protected ITTTabPage TreatmentMaterialsTab;
        protected ITTGrid TreatmentMaterialsGrid;
        protected ITTDateTimePickerColumn TreatmentMaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn UBBCode;
        protected ITTTextBoxColumn Amount;
        protected ITTLabel labelReportDate;
        protected ITTTextBox ReportNo;
        protected ITTDateTimePicker HealthCommitteeStartDate;
        protected ITTTextBox NumberOfProcess;
        protected ITTLabel labelNumberOfProcedure;
        protected ITTLabel labelStartDate;
        protected ITTLabel WeightLabel;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker ReportDate;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("8a874061-1d6b-4316-8b6d-f2f727c49172"));
            tpExamination = (ITTTabPage)AddControl(new Guid("21fd404b-393d-484e-ab38-9ece25e46a52"));
            labelDisabledRatio = (ITTLabel)AddControl(new Guid("c8bb991d-6322-4cc4-94e9-a7611c9adc95"));
            DisabledRatio = (ITTTextBox)AddControl(new Guid("56844430-fb62-4c45-885f-7db44b8cb011"));
            Report = (ITTRichTextBoxControl)AddControl(new Guid("ca95c220-c579-4cc5-aefa-7474a51af069"));
            OfferOfDecision = (ITTTextBox)AddControl(new Guid("daefc74b-6ff2-4f2a-98ea-19be603a5ba9"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("0cf0e201-ca15-490f-b37d-f57b19188ff2"));
            Weight = (ITTTextBox)AddControl(new Guid("ad2025ff-b0e8-4663-a0ad-328f72efc37a"));
            labelReportNo = (ITTLabel)AddControl(new Guid("84d7c0a2-9b36-4d91-b26a-f76836a86257"));
            Height = (ITTTextBox)AddControl(new Guid("9118314e-8ff5-4ff0-ab8b-f637f2dce520"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("bddc7bac-8729-4275-a92d-ae83ba8485dc"));
            DiagnosisEntryTab = (ITTTabPage)AddControl(new Guid("22e6fd95-3c88-4e3a-8f18-a4bba3bf7fa8"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("fce6674a-8a65-4ae4-9991-c3c4871f29ba"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("f8ff4741-3237-47f2-9401-e736bfb25d23"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("b1024b2f-ed1d-494e-a37d-3980914c4064"));
            SecFreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("9089a1c1-0b0a-4041-812a-309e4bd5d27b"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("9aab04d4-c920-4c11-a403-ca420d40b716"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("a3890bde-a765-4c58-a871-d6ec7dba2e77"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("11a243ff-7bd6-4037-9e51-7f35c3070a69"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("0cb60883-bf61-4ec2-8b7f-8e149a9e9333"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("edefb70d-49d6-4ca3-a95d-00a55ba87944"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("bb2ac10d-c8f9-424a-9cda-667138fccd6a"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("980ec0b2-b4a7-4dd8-a1e1-68130c6f537e"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("090ed565-2d03-4428-8c52-3937de67b152"));
            EpisodeFreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("a136b2f2-fa0b-4ca4-bd15-49c6eb116ef7"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("f634c5f6-d1b3-4cbb-af0e-748d0bb84b62"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("d146061e-83d3-433a-9c3e-6c38b5ecb73f"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("8a7b2878-afd1-4d90-b81c-d77a566fd15f"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("c734a371-1562-4b60-838d-8cf91a7e8458"));
            TreatmentMaterialsTab = (ITTTabPage)AddControl(new Guid("5e4f2e25-983e-4294-abf4-177d09b191ed"));
            TreatmentMaterialsGrid = (ITTGrid)AddControl(new Guid("ed88d062-52fb-4715-842c-a52379f0df35"));
            TreatmentMaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("a0a1b505-6eb7-4142-91a5-13699b7ab296"));
            Material = (ITTListBoxColumn)AddControl(new Guid("6521defc-9ad2-424a-b481-8bab89f48de6"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("bb05fda2-fb79-48d8-8a2c-93d967b593c9"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("4d8598ba-fc66-4052-b0d3-4561d26509d9"));
            UBBCode = (ITTTextBoxColumn)AddControl(new Guid("fbad2a9a-0fda-4349-a8b5-fefe98de8a32"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("577960c3-8db6-4577-b29e-126243532f23"));
            labelReportDate = (ITTLabel)AddControl(new Guid("049a306f-52c4-438b-82c4-e1e12e696b8c"));
            ReportNo = (ITTTextBox)AddControl(new Guid("ecdcb980-f9e7-4c2a-99d1-8eb0a34c19a3"));
            HealthCommitteeStartDate = (ITTDateTimePicker)AddControl(new Guid("5f326042-d8ff-49b7-ad05-7490a690c8fb"));
            NumberOfProcess = (ITTTextBox)AddControl(new Guid("f322b0f7-bff3-4f06-8e0e-341edccd3e26"));
            labelNumberOfProcedure = (ITTLabel)AddControl(new Guid("16f783a5-72de-409b-8f0b-da0d4ec84c8b"));
            labelStartDate = (ITTLabel)AddControl(new Guid("7cce5bbc-4be2-4b71-a204-cf6bac13cb1e"));
            WeightLabel = (ITTLabel)AddControl(new Guid("3b4c2742-6d7d-49cd-91d8-a379bdb53e9a"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("0d26b8fc-c296-4bcb-9234-2c848945b749"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("4acf1332-c7bd-4458-b823-affc8ba55318"));
            base.InitializeControls();
        }

        public HCEExaminationForm() : base("HEALTHCOMMITTEEEXAMINATION", "HCEExaminationForm")
        {
        }

        protected HCEExaminationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}