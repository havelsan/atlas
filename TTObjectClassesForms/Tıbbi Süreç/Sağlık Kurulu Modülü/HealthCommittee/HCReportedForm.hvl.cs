
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
    public partial class HCReportedForm : EpisodeActionForm
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
        protected ITTLabel labelBodyMassIndex;
        protected ITTTextBox BodyMassIndex;
        protected ITTObjectListBox HCDutyType;
        protected ITTLabel lblHCDutyType;
        protected ITTTextBox FunctionRatio;
        protected ITTLabel ttlabel13;
        protected ITTTabControl tttabcontrolDiagnosis;
        protected ITTTabPage tttabpageEpisodeDiagnosis;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTTextBoxColumn EpisodeFreeDiagnose;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabPage tttabpagePreDiagnosis;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTListBoxColumn Diagnose;
        protected ITTTextBoxColumn FreeDiagnosis;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTTextBox tttextboxClinicWeight;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel6;
        protected ITTTextBox RationWeight;
        protected ITTTextBox tttextboxClinicHeight;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel1;
        protected ITTTextBox RationHeight;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProtocolNo;
        protected ITTTextBox tttextboxBookCategory;
        protected ITTDateTimePicker HCStartDate;
        protected ITTLabel ttlabel9;
        protected ITTDateTimePicker ReportDate;
        protected ITTLabel labelStartDate;
        protected ITTLabel labelReportDate;
        protected ITTLabel labelReportNo;
        protected ITTLabel labelNumberOfProcedure;
        protected ITTTextBox BookNumber;
        protected ITTLabel ttlabel8;
        protected ITTObjectListBox MasterResource;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel LabelMasterResource;
        protected ITTTextBox NumberOfProcedure;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel labelNumberOfDocumnets;
        protected ITTLabel labelDocumentDate;
        protected ITTLabel labelBookNumber;
        protected ITTTextBox ReportNo;
        protected ITTTabPage tttabpageDecision;
        protected ITTTabPage tttabpagePI;
        protected ITTTabPage tttabpagePRV;
        override protected void InitializeControls()
        {
            tttabcontrolMain = (ITTTabControl)AddControl(new Guid("129b0a72-2fa5-499b-863b-3c777ce028c6"));
            tttabpageHC = (ITTTabPage)AddControl(new Guid("bd40983e-ab0a-4848-bcea-d4e211321071"));
            labelBodyMassIndex = (ITTLabel)AddControl(new Guid("8c9b1509-07b3-4227-bdf2-7f9628a8baa8"));
            BodyMassIndex = (ITTTextBox)AddControl(new Guid("16353673-21b1-48f7-bca5-ec997843a626"));
            HCDutyType = (ITTObjectListBox)AddControl(new Guid("1bd9b429-2685-48d8-8586-a3530f857cc7"));
            lblHCDutyType = (ITTLabel)AddControl(new Guid("6ebf093f-9421-4677-8c58-03b25a94ee8a"));
            FunctionRatio = (ITTTextBox)AddControl(new Guid("e48171cd-f7c5-4674-85bb-937ff91108d5"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("2dc8775f-9ee2-4de4-bda5-1124fa174010"));
            tttabcontrolDiagnosis = (ITTTabControl)AddControl(new Guid("ef889aca-4300-4852-b16d-1f6a701227f0"));
            tttabpageEpisodeDiagnosis = (ITTTabPage)AddControl(new Guid("2de2b8e0-6b32-467f-af97-afb1fc019e13"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("b0d1da51-e3d5-467d-844c-c2889e4cc2db"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("5c88197a-9942-4ba2-ba8e-2410e7bbd8eb"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("ac852663-c085-40ef-b62b-7ff82cbbd3cb"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("f525bc99-fb19-446b-a7fd-0f9df1b9a23c"));
            EpisodeFreeDiagnose = (ITTTextBoxColumn)AddControl(new Guid("6fe9a8e7-938b-4491-825f-d7a7fb280719"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("61efb18c-ebff-4365-be56-037d445534a8"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("ad55618f-cba0-4637-b1c1-792418abc7e6"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("3fe223a7-97a0-45cb-b388-54fb5908f306"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("446547ec-943e-4547-8ebf-9b7ab64a6d29"));
            tttabpagePreDiagnosis = (ITTTabPage)AddControl(new Guid("0b583875-1848-4925-855e-7650098f922a"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("2b263abe-d2c4-43d4-93aa-7f8f514f27f9"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("45e68176-1749-4bf5-9f6c-55c5bbf310b3"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("cdb39a78-0879-4f3e-9060-db3ba80a31f1"));
            FreeDiagnosis = (ITTTextBoxColumn)AddControl(new Guid("e75b0d65-1a71-4fb5-a463-7f74cb6de354"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("0db93cd0-1410-4c64-9735-d705efdcae6b"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("6cfb6b43-eb4b-4775-9889-01669eeaa8cc"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("e28d3a77-40c7-460a-b745-9b706f77c0ea"));
            tttextboxClinicWeight = (ITTTextBox)AddControl(new Guid("7301d123-0894-4b60-98d7-5cdea8e45b4e"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("d17d4b75-e614-483b-be95-7b868c98aaab"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("27ce7f47-2229-4ede-b19f-7e30a7820fa1"));
            RationWeight = (ITTTextBox)AddControl(new Guid("a6e3db9d-d0f4-4500-b09a-080e48a7bd0a"));
            tttextboxClinicHeight = (ITTTextBox)AddControl(new Guid("27148b4d-a05b-4f53-92a1-d66394b52dcb"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("31f9ab92-72c2-4c67-a93d-67b2b19f89b9"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("cff7e709-9f82-41c8-96f3-3890290bb61a"));
            RationHeight = (ITTTextBox)AddControl(new Guid("17e9e872-bc3c-461c-bce9-d6efc2b97d8a"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("93b34ff6-812c-4d31-b0f3-3f9228012d39"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("4a96da7b-971a-4e96-976f-f18609812b54"));
            tttextboxBookCategory = (ITTTextBox)AddControl(new Guid("2b2a7b6c-76fe-4116-b6f1-ee29b3197bb3"));
            HCStartDate = (ITTDateTimePicker)AddControl(new Guid("8e9c1aea-fae1-4d8d-80ae-f90081d0ddf2"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("f65e0b4c-ac19-4850-af91-7a00103ba39e"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("a684f71d-4bee-4963-8751-658a68580af4"));
            labelStartDate = (ITTLabel)AddControl(new Guid("2b7d7494-77e4-476e-9132-4310307d5d6e"));
            labelReportDate = (ITTLabel)AddControl(new Guid("6f951457-6686-4148-aed4-09011764e2bc"));
            labelReportNo = (ITTLabel)AddControl(new Guid("a65f05af-9581-4a91-bff0-9b8124234675"));
            labelNumberOfProcedure = (ITTLabel)AddControl(new Guid("421615c5-bf69-4fcc-b312-5679f3838276"));
            BookNumber = (ITTTextBox)AddControl(new Guid("6c0f2652-7fc8-40af-a12b-c64de44ed9e6"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("1546708e-fac4-4b7a-88ff-ddaa54e78fec"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("1f19c995-4383-4bb1-936f-bd7f0ad95821"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("c76bc074-1fe8-4838-91b5-aac78f8b58c2"));
            LabelMasterResource = (ITTLabel)AddControl(new Guid("6675fca8-0174-45ec-90c2-617ed52f0513"));
            NumberOfProcedure = (ITTTextBox)AddControl(new Guid("b45c57a2-0f9b-4d3d-baf8-4956735ed91c"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("bb67763e-a060-4369-815a-8546e27fbfe1"));
            labelNumberOfDocumnets = (ITTLabel)AddControl(new Guid("9eaf3ac4-ed55-4dad-811a-55b4918eaa6a"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("46474889-ec1e-42aa-883b-f3d13eabaf27"));
            labelBookNumber = (ITTLabel)AddControl(new Guid("70715d9b-4cec-422f-a717-2aa2dc188e44"));
            ReportNo = (ITTTextBox)AddControl(new Guid("c94face6-c5ee-4d01-aca1-0100dffdb9f4"));
            tttabpageDecision = (ITTTabPage)AddControl(new Guid("9b62d347-7293-488f-850e-463cbe97efaa"));
            tttabpagePI = (ITTTabPage)AddControl(new Guid("402b9ef9-6ae6-4b8a-9f12-b5d319aae8ca"));
            tttabpagePRV = (ITTTabPage)AddControl(new Guid("87427e50-0659-4e4c-8f71-3039ab759c3a"));
            base.InitializeControls();
        }

        public HCReportedForm() : base("HEALTHCOMMITTEE", "HCReportedForm")
        {
        }

        protected HCReportedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}