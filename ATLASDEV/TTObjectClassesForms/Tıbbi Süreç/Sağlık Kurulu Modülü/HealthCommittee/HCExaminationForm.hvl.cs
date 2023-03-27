
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
    /// Sağlık Kurulu
    /// </summary>
    public partial class HCExaminationForm : EpisodeActionForm
    {
    /// <summary>
    /// Sağlık Kurulu İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.HealthCommittee _HealthCommittee
        {
            get { return (TTObjectClasses.HealthCommittee)_ttObject; }
        }

        protected ITTTabControl tttabcontrolMain;
        protected ITTTabPage tttabpageHC;
        protected ITTGrid Members;
        protected ITTListBoxColumn MemberDoctorMemberOfHealthCommiittee;
        protected ITTListBoxColumn SpecialityMemberOfHealthCommiittee;
        protected ITTCheckBoxColumn ApproveMemberOfHealthCommiittee;
        protected ITTCheckBoxColumn RejectMemberOfHealthCommiittee;
        protected ITTTextBoxColumn DescriptionMemberOfHealthCommiittee;
        protected ITTLabel ExternalDoctorInfo;
        protected ITTGrid ExternalDoctors;
        protected ITTTextBoxColumn ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid;
        protected ITTListBoxColumn SpecialityBaseHealthCommittee_ExtDoctorGrid;
        protected ITTTextBoxColumn ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid;
        protected ITTCheckBoxColumn ApproveBaseHealthCommittee_ExtDoctorGrid;
        protected ITTCheckBoxColumn RejectBaseHealthCommittee_ExtDoctorGrid;
        protected ITTTextBoxColumn DescriptionBaseHealthCommittee_ExtDoctorGrid;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelNameSurnameReceiveReport;
        protected ITTGrid HospitalsUnits;
        protected ITTListBoxColumn DoctorBaseHealthCommittee_HospitalsUnitsGrid;
        protected ITTListBoxColumn UnitBaseHealthCommittee_HospitalsUnitsGrid;
        protected ITTListBoxColumn SpecialityBaseHealthCommittee_HospitalsUnitsGrid;
        protected ITTTextBox NameSurnameReceiveReport;
        protected ITTLabel labelUniqueRefReceiveReport;
        protected ITTTextBox UniqueRefReceiveReport;
        protected ITTLabel labelDegreeOfBloodRelatives;
        protected ITTEnumComboBox DegreeOfBloodRelatives;
        protected ITTLabel labelClinicalFindings;
        protected ITTTextBox ClinicalFindings;
        protected ITTLabel labelBodyMassIndex;
        protected ITTTextBox BodyMassIndex;
        protected ITTGrid SystemForHealthCommitteeGrid;
        protected ITTListBoxColumn SystemForDisabledSystemForHealthCommitteeGrid;
        protected ITTTextBoxColumn DisabledOfferDecisionSystemForHealthCommitteeGrid;
        protected ITTTextBoxColumn DisabledRatio;
        protected ITTRichTextBoxControl HealthCommitteeDecision;
        protected ITTLabel labelSendExamination;
        protected ITTEnumComboBox SendExamination;
        protected ITTCheckBox IsHeavyDisabled;
        protected ITTLabel labelQulityOfUnemployableWorks;
        protected ITTTextBox QulityOfUnemployableWorks;
        protected ITTLabel labelUnanimity;
        protected ITTEnumComboBox Unanimity;
        protected ITTLabel labelRation;
        protected ITTEnumComboBox Ration;
        protected ITTRichTextBoxControl ReportDiagnosis;
        protected ITTLabel labelDefinition;
        protected ITTTextBox Definition;
        protected ITTLabel labelUnworkField;
        protected ITTTextBox UnworkField;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage2;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn ttcheckboxcolumn4;
        protected ITTListBoxColumn ttlistboxcolumn4;
        protected ITTEnumComboBoxColumn ttenumcomboboxcolumn2;
        protected ITTTextBoxColumn VFreeDiagnosis;
        protected ITTCheckBoxColumn ttcheckboxcolumn5;
        protected ITTListBoxColumn ttlistboxcolumn5;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn3;
        protected ITTEnumComboBoxColumn ttenumcomboboxcolumn3;
        protected ITTTabPage tttabpage1;
        protected ITTLabel ttlabel15;
        protected ITTGrid Diagnosis;
        protected ITTCheckBoxColumn HAddToHistory;
        protected ITTListBoxColumn HDiagnose;
        protected ITTTextBoxColumn HFreeDiagnosis;
        protected ITTCheckBoxColumn HIsMainDiagnose;
        protected ITTListBoxColumn HResponsibleUser;
        protected ITTDateTimePickerColumn HDiagnoseDate;
        protected ITTEnumComboBox HCDecisionUnitOfTime;
        protected ITTLabel labelHCDecisionTime;
        protected ITTTextBox HCDecisionTime;
        protected ITTGroupBox ttgroupKullanimAmaci;
        protected ITTLabel labelEducationEvaluationIntendedUseOfDisabledReport;
        protected ITTTextBox OtherExplanationIntendedUseOfDisabledReport;
        protected ITTLabel labelOtherExplanationIntendedUseOfDisabledReport;
        protected ITTLabel labelSocialAidEvaluationIntendedUseOfDisabledReport;
        protected ITTEnumComboBox SocialAidEvaluationIntendedUseOfDisabledReport;
        protected ITTEnumComboBox EducationEvaluationIntendedUseOfDisabledReport;
        protected ITTLabel labelEmploymentEvaluationIntendedUseOfDisabledReport;
        protected ITTEnumComboBox LawNo2022EvaluationIntendedUseOfDisabledReport;
        protected ITTLabel labelLawNo2022EvaluationIntendedUseOfDisabledReport;
        protected ITTEnumComboBox OrtesisProsthesEquEvaluationIntendedUseOfDisabledReport;
        protected ITTLabel labelOrtesisProsthesEquEvaluationIntendedUseOfDisabledReport;
        protected ITTEnumComboBox DisabledIdentityCardEvalutionIntendedUseOfDisabledReport;
        protected ITTLabel labelDisabledIdentityCardEvalutionIntendedUseOfDisabledReport;
        protected ITTEnumComboBox EmploymentEvaluationIntendedUseOfDisabledReport;
        protected ITTLabel labelDisabledChaiEvaluationIntendedUseOfDisabledReport;
        protected ITTEnumComboBox DisabledChaiEvaluationIntendedUseOfDisabledReport;
        protected ITTGroupBox ttgroupEngel;
        protected ITTCheckBox OrthopedicMedicalInfoDisabledGroup;
        protected ITTCheckBox UnclassifiedMedicalInfoDisabledGroup;
        protected ITTCheckBox VisionMedicalInfoDisabledGroup;
        protected ITTCheckBox ChronicMedicalInfoDisabledGroup;
        protected ITTCheckBox PsychicAndEmotionalMedicalInfoDisabledGroup;
        protected ITTCheckBox SpeechAndLanguageMedicalInfoDisabledGroup;
        protected ITTCheckBox MentalMedicalInfoDisabledGroup;
        protected ITTCheckBox HearingMedicalInfoDisabledGroup;
        protected ITTLabel labelReasonForExaminationHCRequestReason;
        protected ITTObjectListBox ReasonForExaminationHCRequestReason;
        protected ITTLabel labelHCRequestReason;
        protected ITTObjectListBox HCRequestReason;
        protected ITTTextBox FunctionRatio;
        protected ITTLabel labelFunctionRatio;
        protected ITTLabel labelProtocolNo;
        protected ITTTextBox ProtocolNo;
        protected ITTDateTimePicker HCStartDate;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker ReportDate;
        protected ITTLabel labelReportDate;
        protected ITTTextBox RationWeight;
        protected ITTLabel ttlabel10;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel labelDocumentDate;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel ttlabel9;
        protected ITTTextBox RationHeight;
        protected ITTLabel labelNumberOfDocumnets;
        protected ITTTextBox BookNumber;
        protected ITTLabel LabelMasterResource;
        protected ITTTextBox ReportNo;
        protected ITTObjectListBox MasterResource;
        protected ITTLabel labelBookNumber;
        protected ITTLabel labelReportNo;
        override protected void InitializeControls()
        {
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("5cd2862e-fee8-41f6-bd03-3cbb04bdc608"));
            tttabpageHC = (ITTTabPage)AddControl(new Guid("9ac44c59-4e97-4e79-8fa1-13b9d61db3d0"));
            Members = (ITTGrid)AddControl(new Guid("a2e8b71f-a423-4154-83e5-6103f4d8cf0b"));
            MemberDoctorMemberOfHealthCommiittee = (ITTListBoxColumn)AddControl(new Guid("8c9dbf4a-eede-4282-ac08-76c8459c4ef4"));
            SpecialityMemberOfHealthCommiittee = (ITTListBoxColumn)AddControl(new Guid("d73ec93a-84bc-48e4-a14f-118d3779bb8d"));
            ApproveMemberOfHealthCommiittee = (ITTCheckBoxColumn)AddControl(new Guid("2e8d2577-9ace-48bb-8f63-034ccc238c4a"));
            RejectMemberOfHealthCommiittee = (ITTCheckBoxColumn)AddControl(new Guid("dd94e68c-2e4e-4112-9972-863326425671"));
            DescriptionMemberOfHealthCommiittee = (ITTTextBoxColumn)AddControl(new Guid("8ac01959-1bf8-49e1-b78f-51b88240a18c"));
            ExternalDoctorInfo = (ITTLabel)AddControl(new Guid("51979b5b-b15d-464a-8fab-7baf79aa506b"));
            ExternalDoctors = (ITTGrid)AddControl(new Guid("11498e03-de9d-46b1-a255-e157ebd47880"));
            ExternalDoctorNameBaseHealthCommittee_ExtDoctorGrid = (ITTTextBoxColumn)AddControl(new Guid("126995bd-52b9-4755-851d-85953e13376b"));
            SpecialityBaseHealthCommittee_ExtDoctorGrid = (ITTListBoxColumn)AddControl(new Guid("cf62ca99-e74a-4872-a75a-f5fc7648b559"));
            ExternalDoctorRegNumberBaseHealthCommittee_ExtDoctorGrid = (ITTTextBoxColumn)AddControl(new Guid("534b7b21-a97b-4820-9586-a70395e6a2ca"));
            ApproveBaseHealthCommittee_ExtDoctorGrid = (ITTCheckBoxColumn)AddControl(new Guid("c007671e-0ab9-4657-a08b-a5e42f0be8c0"));
            RejectBaseHealthCommittee_ExtDoctorGrid = (ITTCheckBoxColumn)AddControl(new Guid("b067fffd-222d-4d83-bbec-ec94c946d7c3"));
            DescriptionBaseHealthCommittee_ExtDoctorGrid = (ITTTextBoxColumn)AddControl(new Guid("165b2e8d-137c-46dc-939f-0fbac770fd29"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("97dc43aa-848e-4c1f-8003-9197abeb4fe2"));
            labelNameSurnameReceiveReport = (ITTLabel)AddControl(new Guid("05490753-3b21-495b-a2a9-d55a395b37ea"));
            HospitalsUnits = (ITTGrid)AddControl(new Guid("f45a2d0d-d26f-4fa6-8bf0-5c171b72ad38"));
            DoctorBaseHealthCommittee_HospitalsUnitsGrid = (ITTListBoxColumn)AddControl(new Guid("e868e623-768a-43e1-8c20-c88597266cf8"));
            UnitBaseHealthCommittee_HospitalsUnitsGrid = (ITTListBoxColumn)AddControl(new Guid("2d8d246e-b6de-46f9-bb2c-e499a565b7df"));
            SpecialityBaseHealthCommittee_HospitalsUnitsGrid = (ITTListBoxColumn)AddControl(new Guid("7b8618a9-492e-412a-a601-b2a39076a9b3"));
            NameSurnameReceiveReport = (ITTTextBox)AddControl(new Guid("7c24096e-bfa8-4278-8b3f-38e66667a5e5"));
            labelUniqueRefReceiveReport = (ITTLabel)AddControl(new Guid("dfe56177-c2f6-434c-9808-5d7b580ac371"));
            UniqueRefReceiveReport = (ITTTextBox)AddControl(new Guid("2896f2c1-fecd-4d06-aff3-d9dd2fdaf599"));
            labelDegreeOfBloodRelatives = (ITTLabel)AddControl(new Guid("51806eb4-407a-48ac-9734-67fed1ff1d00"));
            DegreeOfBloodRelatives = (ITTEnumComboBox)AddControl(new Guid("2ef2396b-dcc0-44d7-9b94-193e5b2e4edc"));
            labelClinicalFindings = (ITTLabel)AddControl(new Guid("319f06b1-7f3d-4d6c-b758-03602a7b2c11"));
            ClinicalFindings = (ITTTextBox)AddControl(new Guid("df222355-14dc-475a-aff0-02568edf1267"));
            labelBodyMassIndex = (ITTLabel)AddControl(new Guid("980015c6-5bad-4641-bc00-3e0485a77b91"));
            BodyMassIndex = (ITTTextBox)AddControl(new Guid("7286a3ab-bc53-42dc-b5a4-f61acb928309"));
            SystemForHealthCommitteeGrid = (ITTGrid)AddControl(new Guid("83f7b7b8-893c-44a1-b3e8-d72a6b9ffde3"));
            SystemForDisabledSystemForHealthCommitteeGrid = (ITTListBoxColumn)AddControl(new Guid("0d87b1a3-c22e-4c93-ba42-e76239d50429"));
            DisabledOfferDecisionSystemForHealthCommitteeGrid = (ITTTextBoxColumn)AddControl(new Guid("bed87dd0-534f-45e5-a5bb-fcdddf26dbc3"));
            DisabledRatio = (ITTTextBoxColumn)AddControl(new Guid("ec458846-a23f-4857-ae75-45b164ef65c3"));
            HealthCommitteeDecision = (ITTRichTextBoxControl)AddControl(new Guid("7b49cae0-2405-43b6-ac06-0c3c103efa98"));
            labelSendExamination = (ITTLabel)AddControl(new Guid("91995377-9d1e-490b-a982-0aa2b8d76cbd"));
            SendExamination = (ITTEnumComboBox)AddControl(new Guid("7c802dd2-42e2-4f50-8a0c-ce2664221560"));
            IsHeavyDisabled = (ITTCheckBox)AddControl(new Guid("8f1fdaf1-0e7c-4f83-b345-b96b7ca1a1e1"));
            labelQulityOfUnemployableWorks = (ITTLabel)AddControl(new Guid("371e590f-3a87-4222-bc5f-65f77dcc6fb2"));
            QulityOfUnemployableWorks = (ITTTextBox)AddControl(new Guid("2db9e9cc-b8f1-4cd7-9abe-b05eeb6a0cc1"));
            labelUnanimity = (ITTLabel)AddControl(new Guid("7784db91-e299-4ba8-93e9-c0f2e262e172"));
            Unanimity = (ITTEnumComboBox)AddControl(new Guid("f42eb4c9-06f4-4d6a-9708-778067087c95"));
            labelRation = (ITTLabel)AddControl(new Guid("770c9fe0-3158-4754-9bf7-1e65da0e1e5a"));
            Ration = (ITTEnumComboBox)AddControl(new Guid("5f9739f3-b0aa-469d-bc48-d3779ab64c15"));
            ReportDiagnosis = (ITTRichTextBoxControl)AddControl(new Guid("0c81ec49-deec-42cf-b7b0-737f6b41fcd8"));
            labelDefinition = (ITTLabel)AddControl(new Guid("b9cddb0b-82c9-426e-8614-fadba5a1d5af"));
            Definition = (ITTTextBox)AddControl(new Guid("ff192a4e-4b5c-4e66-acb0-ce49487814dc"));
            labelUnworkField = (ITTLabel)AddControl(new Guid("4f29aa9c-78bc-40fa-a684-69918b6d1707"));
            UnworkField = (ITTTextBox)AddControl(new Guid("ecbfc9a2-4311-418f-97a7-f2223149ab95"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("260942f2-6084-4b42-8bd3-3bfa590cb18f"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("636e75e7-aa8d-4f19-b434-16532f127df0"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("5d46bb48-ae7b-4250-8dc3-17bc1f720264"));
            ttcheckboxcolumn4 = (ITTCheckBoxColumn)AddControl(new Guid("bb7dd36b-51ad-46f2-974b-324f80d698ab"));
            ttlistboxcolumn4 = (ITTListBoxColumn)AddControl(new Guid("a0c75af5-201c-451b-af34-0cdca3032721"));
            ttenumcomboboxcolumn2 = (ITTEnumComboBoxColumn)AddControl(new Guid("0090539f-7743-4c38-849e-97ecd7a73aae"));
            VFreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("00ba35b3-1000-4aa2-a1f2-95f648f56e27"));
            ttcheckboxcolumn5 = (ITTCheckBoxColumn)AddControl(new Guid("ad5197e1-179f-44a4-9348-55d98843dce9"));
            ttlistboxcolumn5 = (ITTListBoxColumn)AddControl(new Guid("d75f2551-fa56-4c19-bb95-c47dca1a3b1d"));
            ttdatetimepickercolumn3 = (ITTDateTimePickerColumn)AddControl(new Guid("2c6a0488-a6f6-4796-a969-fa2be6468297"));
            ttenumcomboboxcolumn3 = (ITTEnumComboBoxColumn)AddControl(new Guid("46fe6c6a-c03f-4e06-89ca-00937adf72c2"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("49e5d7e9-927c-4452-aff9-64f90c4bca57"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("181ff0f4-e7c5-4c5a-aed0-d9d57c7b73ee"));
            Diagnosis = (ITTGrid)AddControl(new Guid("4cb8658d-092d-4da2-9abf-f4a685dc2e1e"));
            HAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("f576282e-b2e0-4780-9018-93ac21811fa9"));
            HDiagnose = (ITTListBoxColumn)AddControl(new Guid("9602c259-8b96-4725-9b0c-97a257be8245"));
            HFreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("6975e403-1981-421b-ab5e-c7eb8d32547c"));
            HIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("639ac3fc-1ab7-4406-827a-4c55cf9c2b01"));
            HResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("2475a4b5-dace-4587-809b-dd9ffd0b8fdb"));
            HDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("c6bf7e2a-3dfc-4546-9170-99a388fb4d76"));
            HCDecisionUnitOfTime = (ITTEnumComboBox)AddControl(new Guid("14d551c0-d383-40ac-a9e7-a113a20367ff"));
            labelHCDecisionTime = (ITTLabel)AddControl(new Guid("a111cea9-06b9-4c48-b68f-97b6afa79d61"));
            HCDecisionTime = (ITTTextBox)AddControl(new Guid("51ecd6b5-69e7-4f4f-82bc-3576520e1947"));
            ttgroupKullanimAmaci = (ITTGroupBox)AddControl(new Guid("521c0e35-022d-432e-a0c1-cc472b0d93f0"));
            labelEducationEvaluationIntendedUseOfDisabledReport = (ITTLabel)AddControl(new Guid("5b7f0d8a-3de4-42dd-a8ad-325fc42d1e1d"));
            OtherExplanationIntendedUseOfDisabledReport = (ITTTextBox)AddControl(new Guid("be78e9cd-a55e-4689-b989-c258a4c5e970"));
            labelOtherExplanationIntendedUseOfDisabledReport = (ITTLabel)AddControl(new Guid("35310865-9c44-4bed-ba04-cb38647b7514"));
            labelSocialAidEvaluationIntendedUseOfDisabledReport = (ITTLabel)AddControl(new Guid("852616a8-1610-4323-91a0-9c255c31d6db"));
            SocialAidEvaluationIntendedUseOfDisabledReport = (ITTEnumComboBox)AddControl(new Guid("8ec790ef-399f-45a4-8c58-03e01241d708"));
            EducationEvaluationIntendedUseOfDisabledReport = (ITTEnumComboBox)AddControl(new Guid("daa183c0-e9d6-4379-9a65-d85a91b26fbd"));
            labelEmploymentEvaluationIntendedUseOfDisabledReport = (ITTLabel)AddControl(new Guid("ea22269d-759c-49b5-85a9-8a639182c329"));
            LawNo2022EvaluationIntendedUseOfDisabledReport = (ITTEnumComboBox)AddControl(new Guid("bf053a81-bbb5-4ea0-8d09-13ea464e7675"));
            labelLawNo2022EvaluationIntendedUseOfDisabledReport = (ITTLabel)AddControl(new Guid("8c2c1c2f-4d47-4f65-aad0-1c5b2383bf64"));
            OrtesisProsthesEquEvaluationIntendedUseOfDisabledReport = (ITTEnumComboBox)AddControl(new Guid("c6c2f9b1-434b-46b4-9e06-acd0e80d44e3"));
            labelOrtesisProsthesEquEvaluationIntendedUseOfDisabledReport = (ITTLabel)AddControl(new Guid("84a2399e-7d6a-45d8-b60d-5abb392fccc4"));
            DisabledIdentityCardEvalutionIntendedUseOfDisabledReport = (ITTEnumComboBox)AddControl(new Guid("660a385c-9eb4-4e1c-8e87-3e85111dd7e4"));
            labelDisabledIdentityCardEvalutionIntendedUseOfDisabledReport = (ITTLabel)AddControl(new Guid("de7283a0-af2a-4959-ae0d-0d382e36abe8"));
            EmploymentEvaluationIntendedUseOfDisabledReport = (ITTEnumComboBox)AddControl(new Guid("8d5d55da-449d-42b9-8e02-f32ac2fd8aa7"));
            labelDisabledChaiEvaluationIntendedUseOfDisabledReport = (ITTLabel)AddControl(new Guid("3d4f7879-2cf9-463e-981d-42fce92ad84f"));
            DisabledChaiEvaluationIntendedUseOfDisabledReport = (ITTEnumComboBox)AddControl(new Guid("1ff96d07-d2da-4e69-a273-d2ef6140ff87"));
            ttgroupEngel = (ITTGroupBox)AddControl(new Guid("99c8ac34-a4d0-4775-8e82-e76a9feb3c6c"));
            OrthopedicMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("cb5581d8-aef2-403e-978f-08b113669113"));
            UnclassifiedMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("23c67bc8-fa98-4009-9d7c-10a5c793d9c0"));
            VisionMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("c302fd1b-e5b2-4c8a-9e3f-96d024864584"));
            ChronicMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("fc9649f6-217d-4f1e-8ead-06d2b7daca46"));
            PsychicAndEmotionalMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("5df2e0fa-4d3d-40a3-981c-e00754b68c16"));
            SpeechAndLanguageMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("d80c708c-1e04-4bf6-92de-7234b0ec528c"));
            MentalMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("77182d9b-85f6-4fe7-b812-481f8b917127"));
            HearingMedicalInfoDisabledGroup = (ITTCheckBox)AddControl(new Guid("97da5d67-e677-4102-a264-0e49ecac0d7f"));
            labelReasonForExaminationHCRequestReason = (ITTLabel)AddControl(new Guid("89487c33-1392-4410-8037-2395d8ce749a"));
            ReasonForExaminationHCRequestReason = (ITTObjectListBox)AddControl(new Guid("8a82beb8-b65b-4d92-bc5a-70840a291c40"));
            labelHCRequestReason = (ITTLabel)AddControl(new Guid("b5450d51-4371-464b-9297-b7f86eae1721"));
            HCRequestReason = (ITTObjectListBox)AddControl(new Guid("10cccaab-91a6-4767-b3b6-8c407e992a5d"));
            FunctionRatio = (ITTTextBox)AddControl(new Guid("72b164ac-b162-4be8-ae67-6faf29073e31"));
            labelFunctionRatio = (ITTLabel)AddControl(new Guid("b6ba2de8-f7dc-4d35-9884-3cec28d420c8"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("dcc549f8-b279-43ae-9ff2-cb5b3ccee0a1"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("3bbbc3cf-ccf9-4c9b-8c7d-2a9f9df02e8d"));
            HCStartDate = (ITTDateTimePicker)AddControl(new Guid("96c60881-7660-4358-a590-def443e508e6"));
            labelStartDate = (ITTLabel)AddControl(new Guid("7716ade7-5c9f-4527-b60d-6f544d5849ee"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("79b75816-e1fe-45b9-9195-ccfcbc4382b1"));
            labelReportDate = (ITTLabel)AddControl(new Guid("429f89bb-2d2b-4ad1-ae2e-b28d7c2a7dc8"));
            RationWeight = (ITTTextBox)AddControl(new Guid("19c41100-9fbc-4214-afd1-8df82a84fabc"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("7e050cb2-cbd3-4a19-bb09-9a8d17ec722e"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("669f42af-0de8-4376-b546-dfd4c8008427"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("f451ab29-e0c5-40d7-b977-42d681f3ff03"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("076eca61-7010-4312-b201-c2ac5780f689"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("6b216b70-7337-42c0-8a22-c2e3258bc899"));
            RationHeight = (ITTTextBox)AddControl(new Guid("0486e87d-d982-49ae-9619-da262a584018"));
            labelNumberOfDocumnets = (ITTLabel)AddControl(new Guid("46a32be2-a9b4-4589-92c7-26d94770d52c"));
            BookNumber = (ITTTextBox)AddControl(new Guid("488c0762-5482-48df-898d-03b5d4509d6a"));
            LabelMasterResource = (ITTLabel)AddControl(new Guid("0c3593e7-be02-4109-add1-080c5e0ca042"));
            ReportNo = (ITTTextBox)AddControl(new Guid("3414a4e4-8a18-49d3-b66a-6947a4c46bd3"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("44984ed0-c721-46c3-9953-4c4feccea4c8"));
            labelBookNumber = (ITTLabel)AddControl(new Guid("c6b169bc-9122-4ad6-b864-8826d3d5adac"));
            labelReportNo = (ITTLabel)AddControl(new Guid("66ac9291-aa84-4dec-9de9-cee7525924bc"));
            base.InitializeControls();
        }

        public HCExaminationForm() : base("HEALTHCOMMITTEE", "HCExaminationForm")
        {
        }

        protected HCExaminationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}