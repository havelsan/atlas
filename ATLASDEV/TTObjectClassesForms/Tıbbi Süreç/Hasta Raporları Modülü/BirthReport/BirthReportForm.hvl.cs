
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
    /// Doğum Raporu
    /// </summary>
    public partial class BirthReportForm : EpisodeActionForm
    {
    /// <summary>
    /// Doğum Raporunu Yazıldığı Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.BirthReport _BirthReport
        {
            get { return (TTObjectClasses.BirthReport)_ttObject; }
        }

        protected ITTLabel ttlabel4;
        protected ITTTextBox BabyName;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox ReportNo;
        protected ITTTextBox Height;
        protected ITTTextBox Weight;
        protected ITTTextBox PartnerName;
        protected ITTTextBox QuarantineProtocolNo;
        protected ITTLabel ttlabel3;
        protected ITTGrid BirthReportDoctorInfo;
        protected ITTListBoxColumn Doctor;
        protected ITTListBoxColumn Speciality;
        protected ITTButton ttbuttonSelectBaby;
        protected ITTRichTextBoxControl Report;
        protected ITTObjectListBox BornType;
        protected ITTLabel labelReportNo;
        protected ITTLabel labelSex;
        protected ITTLabel labelBornType;
        protected ITTLabel labelWeight;
        protected ITTEnumComboBox Sex;
        protected ITTLabel labelPartnerName;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelHeight;
        protected ITTLabel labelQuarantineProtocolNo;
        protected ITTEnumComboBox Episiotomy;
        protected ITTLabel labelEpisiotomy;
        protected ITTLabel labelBirthTime;
        protected ITTDateTimePicker BirthTime;
        protected ITTLabel labelBabyStatus;
        protected ITTEnumComboBox BabyStatus;
        protected ITTLabel labelBabyBirthDate;
        protected ITTDateTimePicker BabyBirthDate;
        protected ITTLabel labelAestesiaType;
        protected ITTEnumComboBox AestesiaType;
        protected ITTEnumComboBox ReportType;
        protected ITTDateTimePicker ProtocolDate;
        protected ITTLabel labelReportDate;
        protected ITTDateTimePicker ReportDate;
        protected ITTLabel labelReportEndDate;
        protected ITTDateTimePicker ReportEndDate;
        protected ITTLabel labelReportStartDate;
        protected ITTDateTimePicker ReportStartDate;
        protected ITTLabel labelReportType;
        protected ITTLabel labelProtocolDate;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage EpisodeDiagnosisTab;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabPage DiagnosisEntryTab;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTListBoxColumn Diagnose;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTCheckBox ApprovalFormGiven;
        override protected void InitializeControls()
        {
            ttlabel4 = (ITTLabel)AddControl(new Guid("a6a9830b-a6ca-49a9-8380-e9d85cb5e686"));
            BabyName = (ITTTextBox)AddControl(new Guid("9f99f7c5-9c44-4721-815f-bd1ba59d5841"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("3b4ed33e-1b0c-41d9-b517-310b05939145"));
            ReportNo = (ITTTextBox)AddControl(new Guid("891c3364-8ac8-4843-b244-575d689cdec5"));
            Height = (ITTTextBox)AddControl(new Guid("e9201d91-0a31-46e4-8f6b-a182bf06bf18"));
            Weight = (ITTTextBox)AddControl(new Guid("c0960456-2ded-4fab-b279-a2c01f985486"));
            PartnerName = (ITTTextBox)AddControl(new Guid("b39d9554-463f-4c2e-ab54-ab3637d3f4d2"));
            QuarantineProtocolNo = (ITTTextBox)AddControl(new Guid("856ea5be-ed54-442f-9f59-b8b2a47b253a"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("c28d6f31-aec9-46ce-83ac-7cdce04bf73b"));
            BirthReportDoctorInfo = (ITTGrid)AddControl(new Guid("f3fb17af-d427-4047-82c1-8e333c554a63"));
            Doctor = (ITTListBoxColumn)AddControl(new Guid("b1f8f3ab-6d2d-42b2-a263-319f6ed6b98e"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("b137a89c-883d-4139-9ab0-159d54a6f349"));
            ttbuttonSelectBaby = (ITTButton)AddControl(new Guid("563cb828-6c46-44bc-aac4-99515ae9dd0a"));
            Report = (ITTRichTextBoxControl)AddControl(new Guid("1169cbcc-f1f3-45c3-acf5-d713abebfaf1"));
            BornType = (ITTObjectListBox)AddControl(new Guid("b362f981-a3a2-4713-a626-1b7365967d13"));
            labelReportNo = (ITTLabel)AddControl(new Guid("0f72681c-f095-4e41-9cbb-1d55946a2c40"));
            labelSex = (ITTLabel)AddControl(new Guid("168c5a17-6a9a-4df6-8a8d-2fa25e5b4872"));
            labelBornType = (ITTLabel)AddControl(new Guid("3207893f-8be1-47a2-adfe-60bee18d59a4"));
            labelWeight = (ITTLabel)AddControl(new Guid("46b26037-057e-4ff2-b128-760d5ac4a0cd"));
            Sex = (ITTEnumComboBox)AddControl(new Guid("ab78f6cb-dc1f-40c3-8d6b-852f8f140df7"));
            labelPartnerName = (ITTLabel)AddControl(new Guid("889903eb-d045-488f-b21d-9239b16e104f"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("030fb79f-afae-43c0-89c9-9b0a123042d3"));
            labelHeight = (ITTLabel)AddControl(new Guid("dce7e311-1843-4992-a251-e1367378e336"));
            labelQuarantineProtocolNo = (ITTLabel)AddControl(new Guid("548483a8-5db4-4e70-a951-f086309baa79"));
            Episiotomy = (ITTEnumComboBox)AddControl(new Guid("0e08bd89-1947-4105-80c3-703ad3ccc3eb"));
            labelEpisiotomy = (ITTLabel)AddControl(new Guid("d3b77825-4821-4250-974b-24b3941d78fa"));
            labelBirthTime = (ITTLabel)AddControl(new Guid("b4b0c782-d51f-4933-90ba-a5d5c140293a"));
            BirthTime = (ITTDateTimePicker)AddControl(new Guid("5d3ca72c-bc1a-4391-94e3-d1ecefa42a8a"));
            labelBabyStatus = (ITTLabel)AddControl(new Guid("4b7acb97-3470-4eed-a556-405807646de1"));
            BabyStatus = (ITTEnumComboBox)AddControl(new Guid("0db029ef-c1d3-4446-a1a1-0f10494a81cd"));
            labelBabyBirthDate = (ITTLabel)AddControl(new Guid("3f6753c9-ed66-4188-8b43-81c77f99130e"));
            BabyBirthDate = (ITTDateTimePicker)AddControl(new Guid("8b72ede3-3ea0-4630-8ed5-2accc1bd0ef0"));
            labelAestesiaType = (ITTLabel)AddControl(new Guid("30324dda-71b4-475b-b547-c6bd72ae62ca"));
            AestesiaType = (ITTEnumComboBox)AddControl(new Guid("ab14a290-48f8-47ac-9757-691397b47e98"));
            ReportType = (ITTEnumComboBox)AddControl(new Guid("a961e8ed-6e3a-497b-a6c0-2c44b48d09f1"));
            ProtocolDate = (ITTDateTimePicker)AddControl(new Guid("a44f98c5-5192-4e18-a181-5297272aed10"));
            labelReportDate = (ITTLabel)AddControl(new Guid("3eec7678-43a9-4b18-925f-a3191c08cb7d"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("5198909a-1c0a-4d5b-bbe7-19ede3c71b93"));
            labelReportEndDate = (ITTLabel)AddControl(new Guid("203a5d54-dd67-4379-b8be-77b92aa1dd3f"));
            ReportEndDate = (ITTDateTimePicker)AddControl(new Guid("51a53da9-3970-44b2-931d-86aa07ee674f"));
            labelReportStartDate = (ITTLabel)AddControl(new Guid("7509a7e4-488b-4b9a-8da3-1abe002867bf"));
            ReportStartDate = (ITTDateTimePicker)AddControl(new Guid("fb76417d-b2ea-4231-ba43-74f66ed003d1"));
            labelReportType = (ITTLabel)AddControl(new Guid("a03b58b7-f316-4ddb-a1a1-b1f018c74bf1"));
            labelProtocolDate = (ITTLabel)AddControl(new Guid("9cae9433-57ff-43a7-8195-60c506a2f8e8"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("a736be50-bf32-4a3a-979b-31ae0d644dad"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("002b53f0-b837-459e-8dbc-57deaed1237d"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("64b79776-be1a-40df-baea-cd11114e9785"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("65b4ddb5-8128-4448-86fd-9bfa6afc781e"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("ac113afc-ff91-4e42-b7da-4fa987c9fb5b"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("0abf99b1-49ab-48ed-b629-31dec86377f7"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("83d4aca0-87c3-4df2-8890-322ead08ef1c"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("498d4b0b-c204-44b6-8c79-f87dd22bb1ea"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("2f999ab7-3b08-457e-9dec-10db0e35f28a"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("eb13679c-57ef-4b08-b393-7cf6128bba1b"));
            DiagnosisEntryTab = (ITTTabPage)AddControl(new Guid("26dd79e1-0a04-4136-917a-5a771863e596"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("927591e4-ea0c-4382-ad4b-c40f14edc637"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("a2ab688d-1549-44d4-89a2-89be591dee64"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("ed08be1f-17cf-49fa-8252-d1e6052a01f5"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("a5cd4a07-dfff-4c35-a4e8-764b23525aeb"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("fa3761ed-9fe4-475f-b401-beb93aac9213"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("81cbc236-4941-40aa-9a61-76ac8a9d4062"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("28cd6831-59f0-4d05-b09f-9e6d8d586699"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("fa2ae684-af38-4f28-90b7-d30b174045fa"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("a3b20554-1471-40da-a1a1-bcae97e280bd"));
            ApprovalFormGiven = (ITTCheckBox)AddControl(new Guid("6ae10a34-3e1f-42e2-a9cb-7fe00a844c1b"));
            base.InitializeControls();
        }

        public BirthReportForm() : base("BIRTHREPORT", "BirthReportForm")
        {
        }

        protected BirthReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}