
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
    public partial class OrthesisProsthesisCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Ortez Protez  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.OrthesisProsthesisRequest _OrthesisProsthesisRequest
        {
            get { return (TTObjectClasses.OrthesisProsthesisRequest)_ttObject; }
        }

        protected ITTObjectListBox MasterResource;
        protected ITTTextBox ReasonOfCancel;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTabControl tttabcontrolDiagnose;
        protected ITTTabPage tttabpageOrthesis;
        protected ITTGrid OrthesisProsthesisProcedures;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTEnumComboBoxColumn SideO;
        protected ITTTextBoxColumn Amount;
        protected ITTCheckBoxColumn IsPrintReport;
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
        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureSpeciality;
        protected ITTLabel labelProtocolNo;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTLabel labelProcedureDoctor;
        protected ITTEnumComboBox PatientGroup;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            MasterResource = (ITTObjectListBox)AddControl(new Guid("797916d8-2b5a-4e20-be30-02656b94abc7"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("6203e975-203a-459e-aeb9-90dab850f84c"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("227fa797-593b-41c3-9a23-4ae27dffd862"));
            tttabcontrolDiagnose = (ITTTabControl)AddControl(new Guid("7e6d05c2-326d-44cc-ac49-2fcdb7db165d"));
            tttabpageOrthesis = (ITTTabPage)AddControl(new Guid("6caec2b4-d68c-4c5e-bcc4-7b610b665e15"));
            OrthesisProsthesisProcedures = (ITTGrid)AddControl(new Guid("fff36bd5-1114-475a-9452-1cc330ef6dfd"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("dd8bd548-3d26-42b3-af78-50851d6a4f96"));
            SideO = (ITTEnumComboBoxColumn)AddControl(new Guid("de816823-0bfe-408d-abd8-710ff2e39593"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("b8897b3a-be06-4210-b6a2-9d1fd7a68b28"));
            IsPrintReport = (ITTCheckBoxColumn)AddControl(new Guid("8b39c806-ccf0-4006-899a-5c62e0399216"));
            tttabpageDiagnosis = (ITTTabPage)AddControl(new Guid("e5c53ce6-a7b9-427d-8f51-7776daa30a36"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("01f2e82a-d326-45e6-b381-351e45fc879a"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("ece74a35-be3b-4eb4-877e-dbb8c64f5b04"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("f0dd4798-ecb8-4ccd-9555-1ac05f7b3841"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("b8fec5ec-5869-4c27-876d-c8579a6d58cd"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("ca1487f2-9492-491b-84a5-f270573dc2b6"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("d56d588e-7916-475c-a230-abc73f31da93"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("4d4f6eb8-aad8-4665-837b-8beaa4c8388c"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("700d5064-d629-40c6-a871-f0a0b2f8299d"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("7d29baa8-6f6b-45b9-b22e-a2e798126d2f"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("7a2e571d-3ef3-460f-9a36-48610762726e"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("4bcbe673-772d-456d-97bf-1c18c412f28d"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("f1da951c-523f-434b-9a80-e987c9318b03"));
            labelProcedureSpeciality = (ITTLabel)AddControl(new Guid("69830f84-84ff-4022-96d6-c442b2d33539"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("be1c2642-a23a-4003-9517-532f808913cc"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("f0ad594f-cada-419b-8728-4070a75ad8db"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("0fd9965e-5c2b-427d-b24f-aea7868392dd"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("5623c30e-6077-4a56-8d74-7ab3e56074c9"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("64df7741-325a-4b28-9a14-af351b324573"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b4918bd2-b18b-4fb4-9f2f-d525fd65221b"));
            base.InitializeControls();
        }

        public OrthesisProsthesisCancelledForm() : base("ORTHESISPROSTHESISREQUEST", "OrthesisProsthesisCancelledForm")
        {
        }

        protected OrthesisProsthesisCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}