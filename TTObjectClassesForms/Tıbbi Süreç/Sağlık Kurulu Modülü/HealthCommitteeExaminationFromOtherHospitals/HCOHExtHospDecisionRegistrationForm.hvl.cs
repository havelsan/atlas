
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
    /// Diğer XXXXXXlerden Sağlık Kurulu Muayenesi
    /// </summary>
    public partial class HCOHExtHospDecisionRegistrationForm : EpisodeActionForm
    {
    /// <summary>
    /// Diğer XXXXXX(ler)den Sağlık Kurulu Muayenesi
    /// </summary>
        protected TTObjectClasses.HealthCommitteeExaminationFromOtherHospitals _HealthCommitteeExaminationFromOtherHospitals
        {
            get { return (TTObjectClasses.HealthCommitteeExaminationFromOtherHospitals)_ttObject; }
        }

        protected ITTTabControl tttabcontrolMain;
        protected ITTTabPage tttabpageHC;
        protected ITTCheckBox IsHealthy;
        protected ITTTextBox DrEmploymentRecordID;
        protected ITTObjectListBox DrSpeciality;
        protected ITTLabel labelReportNo;
        protected ITTTextBox ReportNoText;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel6;
        protected ITTTextBox DrTitle;
        protected ITTTextBox DrName;
        protected ITTGrid HCTSMatterSliceAnectode;
        protected ITTTextBoxColumn Matter12;
        protected ITTEnumComboBoxColumn Slice12;
        protected ITTTextBoxColumn Anectode12;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker HealthCommitteeStartDate;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage DiagnosisEntryTab;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn SecAddToHistory;
        protected ITTListBoxColumn SecDiagnose;
        protected ITTTextBoxColumn SecFreeDiagnose;
        protected ITTCheckBoxColumn SecIsMainDiagnose;
        protected ITTListBoxColumn SecResponsibleUser;
        protected ITTDateTimePickerColumn SecDiagnoseDate;
        protected ITTTabPage EpisodeDiagnosisTab;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTTextBoxColumn EpisodeFreeDiagnose;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTLabel ttlabel3;
        protected ITTTextBox OfferofDecision;
        protected ITTEnumComboBox PatientGroup;
        protected ITTObjectListBox Unit;
        protected ITTEnumComboBox PatientStatus;
        protected ITTLabel labelReasonForAdmission;
        protected ITTTextBox NumberOfProcess;
        protected ITTLabel labelExplanationOfRequest;
        protected ITTTextBox ExplanationOfRequest;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelOfferofDecision;
        protected ITTLabel labelUnit;
        protected ITTObjectListBox Hospital;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel15;
        protected ITTLabel labelReportDate;
        protected ITTLabel ttlabel7;
        protected ITTLabel labelHospital;
        protected ITTLabel labelNumberOfProcedure;
        protected ITTObjectListBox Speciality;
        protected ITTLabel ttlabel19;
        protected ITTDateTimePicker ReportDate;
        protected ITTLabel labelDoctor;
        protected ITTObjectListBox ReasonForExamination;
        protected ITTTabPage tttabpageReport;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        override protected void InitializeControls()
        {
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("884760ce-2248-48b3-9059-b596b7f8c0d8"));
            tttabpageHC = (ITTTabPage)AddControl(new Guid("541e12a2-9026-41b2-9061-eb664f257987"));
            IsHealthy = (ITTCheckBox)AddControl(new Guid("4a382b57-9115-4c21-8edc-db70c0222580"));
            DrEmploymentRecordID = (ITTTextBox)AddControl(new Guid("62d16497-c10c-44d7-b34b-5ddb8fe3a53a"));
            DrSpeciality = (ITTObjectListBox)AddControl(new Guid("3f29bcfa-fed3-4b89-bcf0-1d9b34a11207"));
            labelReportNo = (ITTLabel)AddControl(new Guid("3870c5ad-4f0f-45a6-86be-02d1a3c9b608"));
            ReportNoText = (ITTTextBox)AddControl(new Guid("fa7a0efa-8680-4f8c-babe-ff62bc6a2fec"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("68d1776f-7867-456a-99f8-763872abd689"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("f0ef6013-37cf-4c1d-ad88-9994688be3ba"));
            DrTitle = (ITTTextBox)AddControl(new Guid("f0a343c3-bbbe-4451-9bad-adc780e9bc6c"));
            DrName = (ITTTextBox)AddControl(new Guid("78d17c01-bebd-467a-8366-e472ab967a41"));
            HCTSMatterSliceAnectode = (ITTGrid)AddControl(new Guid("b7e80fa2-269f-4d5f-a562-d0012fab00c0"));
            Matter12 = (ITTTextBoxColumn)AddControl(new Guid("2c8bdd8c-a7c1-4a44-9825-c31357b00a53"));
            Slice12 = (ITTEnumComboBoxColumn)AddControl(new Guid("73a62e01-cb9b-402b-97e7-468294cfe558"));
            Anectode12 = (ITTTextBoxColumn)AddControl(new Guid("4cee1697-d5c7-4af7-944b-9ebcba0a6189"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ae43f82e-5052-4fc4-80d2-7d6aa0ee0cb2"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("64349e4c-0cb5-47e7-8de7-d5d6bde75c93"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("fade032b-fc94-48e3-a79e-4141d0939f34"));
            HealthCommitteeStartDate = (ITTDateTimePicker)AddControl(new Guid("34df6cae-c252-4bde-97c0-6305c604e271"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("977fcad2-ab23-4b29-a17f-e6d3cfc7b7b1"));
            DiagnosisEntryTab = (ITTTabPage)AddControl(new Guid("f3103a7f-046f-4843-8e3b-40b766e13e66"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("2acc75a8-86d4-4d6c-b3e6-f6c4afb53a73"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("b3facb0e-94cb-4131-92fd-f5680ccc0ab5"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("b3ab41fd-a050-417f-a77a-af53ef37822d"));
            SecFreeDiagnose = (ITTTextBoxColumn)AddControl(new Guid("2c7d38de-a24c-4f1e-b8c9-6d5fa70a6315"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("dc4a93de-a3ab-43db-a299-b95653a2c63a"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("ff94efa9-5db9-4305-a160-4ccbf212d9ef"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("96d53bf5-2f37-4ec1-8de2-20c9456f8fa2"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("16c48828-c3a5-4855-9c89-cb7aeb8d5088"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("15233837-fce6-4bf6-803d-70d5105322c2"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("b7782e40-638f-44d1-a658-13b34508e787"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("fe070315-e550-40a2-a1e6-8f96d8855114"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("72992df9-6430-4dfe-af65-d91d67a82ae9"));
            EpisodeFreeDiagnose = (ITTTextBoxColumn)AddControl(new Guid("31ad4f35-e30a-4516-92af-08d3b3843a92"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("54914508-da8a-4b0f-8228-43738745e294"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("853710de-382b-42fb-91d0-312f332a8004"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("8dff8a51-f13b-4305-97cf-49c263ce740b"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("ca5c16e5-fcba-4fc4-a932-c63a7066b0ff"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("a53e7790-5b65-4902-9873-899fee6f6add"));
            OfferofDecision = (ITTTextBox)AddControl(new Guid("bc9a4cf7-c847-443a-83e5-6a741259a3b3"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("96263f78-57cf-4f3f-9451-534fbf3e30e5"));
            Unit = (ITTObjectListBox)AddControl(new Guid("4122dbcd-c777-47e2-8a58-0fca4212c9c7"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("be4da255-aef9-4179-a0ee-5eb1eb7f421c"));
            labelReasonForAdmission = (ITTLabel)AddControl(new Guid("52bef78f-2564-40ea-83cd-bbd7181b4407"));
            NumberOfProcess = (ITTTextBox)AddControl(new Guid("13d6cf4f-77d6-4a13-b04a-1b214a9c3951"));
            labelExplanationOfRequest = (ITTLabel)AddControl(new Guid("51e3077b-cf8d-4632-b561-fc1ffaee877c"));
            ExplanationOfRequest = (ITTTextBox)AddControl(new Guid("31936784-105c-4cc3-a18a-b317f69d2935"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("4f3710cd-b286-4b36-a46f-bb33527615f0"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("dbbef3d3-eb46-405b-8989-fc836d720088"));
            labelOfferofDecision = (ITTLabel)AddControl(new Guid("48f46229-351f-4267-a69d-e546f5b4c7c7"));
            labelUnit = (ITTLabel)AddControl(new Guid("328d7e60-e2f0-4b9f-86f5-ee69e6622746"));
            Hospital = (ITTObjectListBox)AddControl(new Guid("74061a17-bd9c-45e6-b986-dd8cea19b777"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("81158dad-2659-4c9b-a793-0727755c69a3"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("50ad98ab-4740-4e24-91a3-dd35a04d0592"));
            labelReportDate = (ITTLabel)AddControl(new Guid("3cec8319-acd6-4220-9e47-67e5b9af52d4"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("dae827ba-9714-49e7-9624-f19ff79ef438"));
            labelHospital = (ITTLabel)AddControl(new Guid("2f46406f-0a1a-4ef5-9632-07d5d2a64a09"));
            labelNumberOfProcedure = (ITTLabel)AddControl(new Guid("c0357e29-e3e4-4eef-96bd-9c4e3812f0cc"));
            Speciality = (ITTObjectListBox)AddControl(new Guid("87d05428-ca88-4778-8766-ca7891f81ef8"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("4464abd8-c7da-41c5-9398-d36499d1241a"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("cb27a412-9a8f-4e4c-8c63-2a2afcde2ec2"));
            labelDoctor = (ITTLabel)AddControl(new Guid("da2bc57f-169a-4da6-aaa2-635189955d27"));
            ReasonForExamination = (ITTObjectListBox)AddControl(new Guid("a1f4f754-3cc8-496d-a8c7-c88d710d9bbe"));
            tttabpageReport = (ITTTabPage)AddControl(new Guid("5794e3ad-8998-431c-8c3c-baeee859f04f"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("0e115e5c-dfdd-49d0-8cb9-38b8b2963d43"));
            base.InitializeControls();
        }

        public HCOHExtHospDecisionRegistrationForm() : base("HEALTHCOMMITTEEEXAMINATIONFROMOTHERHOSPITALS", "HCOHExtHospDecisionRegistrationForm")
        {
        }

        protected HCOHExtHospDecisionRegistrationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}