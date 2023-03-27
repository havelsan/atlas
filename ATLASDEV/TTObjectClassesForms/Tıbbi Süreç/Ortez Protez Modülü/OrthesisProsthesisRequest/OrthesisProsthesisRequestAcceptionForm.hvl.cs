
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
    /// Ortez Protez
    /// </summary>
    public partial class OrthesisProsthesisRequestAcceptionForm : EpisodeActionForm
    {
    /// <summary>
    /// Ortez Protez  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.OrthesisProsthesisRequest _OrthesisProsthesisRequest
        {
            get { return (TTObjectClasses.OrthesisProsthesisRequest)_ttObject; }
        }

        protected ITTObjectListBox MasterResource;
        protected ITTTabControl NotesTab;
        protected ITTTabPage NoteChief;
        protected ITTTextBox ChiefTechnicianNote;
        protected ITTTabPage NoteFinance;
        protected ITTTextBox FinancialDepartmentNot;
        protected ITTRichTextBoxControl TotalDescription;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage OrtesisProtesis;
        protected ITTGrid OrthesisProsthesisProcedures;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTEnumComboBoxColumn SideO;
        protected ITTTextBoxColumn Amount;
        protected ITTTabPage tttabpageDiagnosis;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTextBox ProtocolNo;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelProcessDate;
        protected ITTGrid ReturnDescriptionGrid;
        protected ITTDateTimePickerColumn EntryDate;
        protected ITTTextBoxColumn ReturnDescription;
        protected ITTTextBoxColumn OwnerUser;
        protected ITTLabel ReturnDescriptionsLabel;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureSpeciality;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTLabel labelProcedureDoctor;
        protected ITTEnumComboBox PatientGroup;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            MasterResource = (ITTObjectListBox)AddControl(new Guid("6ddb0020-2d31-47d5-913a-e3b1e410e417"));
            NotesTab = (ITTTabControl)AddControl(new Guid("100e712c-3560-4562-8e72-794929d55efe"));
            NoteChief = (ITTTabPage)AddControl(new Guid("c40cb96e-fcb5-404a-bdd0-3a28be0eecb1"));
            ChiefTechnicianNote = (ITTTextBox)AddControl(new Guid("bb106a4d-bc04-404e-9c5f-f09b4fe58b4d"));
            NoteFinance = (ITTTabPage)AddControl(new Guid("0f9db53f-0439-47a0-94f6-a450bdf44aff"));
            FinancialDepartmentNot = (ITTTextBox)AddControl(new Guid("8562673b-137e-423e-9940-7a6e5e62b03e"));
            TotalDescription = (ITTRichTextBoxControl)AddControl(new Guid("d113467c-a8fb-4d72-9b00-47ff801f8b4c"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("146d9ae3-b88b-4936-9b1e-1383182b409b"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("ab3f40c8-0288-4d89-b832-7fff4ebd1aeb"));
            OrtesisProtesis = (ITTTabPage)AddControl(new Guid("07c0f926-e52f-4191-b1c5-e18d8b73b5b3"));
            OrthesisProsthesisProcedures = (ITTGrid)AddControl(new Guid("10f3af35-e2e8-45f2-8dfe-23b71c4705ff"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("467ceed0-2217-4dd7-832f-7141481054f1"));
            SideO = (ITTEnumComboBoxColumn)AddControl(new Guid("a0b947c6-778e-42a4-aac7-a3edb5b24f85"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("59621d51-69e6-4011-b335-e9234e0a4004"));
            tttabpageDiagnosis = (ITTTabPage)AddControl(new Guid("b5ff6357-049a-4b44-810a-7f400debb4c5"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("931aeaf4-0319-4892-80fc-fe636a43152e"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("3e7bd3a4-a91b-40cd-aff7-907a32112edb"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("d46a71f2-75bc-45d3-88b3-dee3d8f21273"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("377a8d06-5925-402d-9e9d-acab42515788"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("18b38670-8655-4247-890a-ec946d8c3c5e"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("19a59fcf-e522-42c9-bd36-bd2823f27435"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("82010cd1-cbca-4c3d-9124-7c0d8652ab76"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("ec16c847-fd80-4ae4-a6c1-766f52d9bfde"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("5dfaadf6-34ad-4f71-8732-2121508c5930"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("7ad8035b-c37c-4a01-a4e8-1b482fec13bd"));
            labelProcessDate = (ITTLabel)AddControl(new Guid("5ff1b595-b0e9-40e3-aa98-aced3e736124"));
            ReturnDescriptionGrid = (ITTGrid)AddControl(new Guid("b5351a57-83dd-480b-86e5-c870eef51a55"));
            EntryDate = (ITTDateTimePickerColumn)AddControl(new Guid("911af6c3-3f63-4e62-a78d-a7d04fec3da6"));
            ReturnDescription = (ITTTextBoxColumn)AddControl(new Guid("591ebba0-7e62-49a9-aa59-e5e80260886b"));
            OwnerUser = (ITTTextBoxColumn)AddControl(new Guid("c95156e0-7479-49f2-a3df-4b51053e69f3"));
            ReturnDescriptionsLabel = (ITTLabel)AddControl(new Guid("6ba840ed-5533-4ef8-adf4-7c07b1d6c6bf"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("55e9fb51-1f27-4d32-b6fb-e674164481c3"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("ce9efd5f-2f22-49b6-9999-3c38a4e62e3d"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("8d52d3b5-3399-48cc-8212-09403b11ef7a"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("17de2da3-0598-4658-90a5-713394feddb1"));
            labelProcedureSpeciality = (ITTLabel)AddControl(new Guid("d6314f14-03a5-4bab-9cfc-315e86a37a89"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("1099f178-fd0f-4c55-b456-b81d2cf51652"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("294d47ec-3b13-4528-8776-143e77ca3b74"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("2c551eb8-55a3-4706-ad32-5abd09dfbcb8"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("355b339b-0db1-485e-8498-6bf883f67303"));
            base.InitializeControls();
        }

        public OrthesisProsthesisRequestAcceptionForm() : base("ORTHESISPROSTHESISREQUEST", "OrthesisProsthesisRequestAcceptionForm")
        {
        }

        protected OrthesisProsthesisRequestAcceptionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}