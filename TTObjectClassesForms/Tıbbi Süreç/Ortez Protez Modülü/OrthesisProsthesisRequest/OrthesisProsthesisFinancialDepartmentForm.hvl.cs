
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
    public partial class OrthesisProsthesisFinancialDepartmentForm : EpisodeActionForm
    {
    /// <summary>
    /// Ortez Protez  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.OrthesisProsthesisRequest _OrthesisProsthesisRequest
        {
            get { return (TTObjectClasses.OrthesisProsthesisRequest)_ttObject; }
        }

        protected ITTTabControl tttabcontrolOrthesis;
        protected ITTTabPage tttabpageOrthesis;
        protected ITTGrid OrthesisProsthesisProcedures;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTEnumComboBoxColumn SideO;
        protected ITTTextBoxColumn Amount;
        protected ITTTabPage tttabpage2;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTextBox FinancialDepartmentNot;
        protected ITTTextBox ProtocolNo;
        protected ITTRichTextBoxControl TotalDescription;
        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelFinancialDepartmentNot;
        protected ITTLabel labelProtocolNo;
        override protected void InitializeControls()
        {
            tttabcontrolOrthesis = (ITTTabControl)AddControl(new Guid("a9f0fae3-c3d9-495f-99c3-7c0225f58f96"));
            tttabpageOrthesis = (ITTTabPage)AddControl(new Guid("90f37a4d-e8e3-46a1-b9c9-7e8425e054ea"));
            OrthesisProsthesisProcedures = (ITTGrid)AddControl(new Guid("aadce57c-c947-4b7b-9b40-7093ae9f5664"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("9db7abb3-2d97-4da1-bb32-d22a70dd612a"));
            SideO = (ITTEnumComboBoxColumn)AddControl(new Guid("e8a12f95-1661-4e40-86bd-21accacabf20"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("723e1b91-4933-4015-ade5-d4e21bc03840"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("a5f1a13c-d987-4130-8706-50d5f0cc34db"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("f0e87ec6-feb5-4c9d-8f66-b64cf4ad6609"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("399bc4cb-ae26-45df-8375-df1434f932a7"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("5d930a53-7b8a-4dbe-a909-31df68fc1dc5"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("6990c99c-e9f3-4ac8-9285-dc13edec05ff"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("00644e13-bf4f-458d-a3fb-fdfbce53876f"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("bc9af39c-d8c9-469a-8b0a-dccda00d65b7"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("5b1ec43b-6c03-4ec2-bff2-e4164a4ebbbe"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("2bca49f8-3100-4ed0-96fa-3fd02d0bc060"));
            FinancialDepartmentNot = (ITTTextBox)AddControl(new Guid("93a8999a-cfbf-4c7c-90ce-8fa04b0885e5"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("13df8608-085e-4949-9c84-c8c47c581e6b"));
            TotalDescription = (ITTRichTextBoxControl)AddControl(new Guid("46133118-6b65-42fe-8ee7-e89361a4f905"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("0e7d6391-8fb1-46ba-aa6c-5a829a17d00f"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("ca8ba212-5dab-4e57-9723-47d764d3f5e9"));
            labelFinancialDepartmentNot = (ITTLabel)AddControl(new Guid("b3ace479-f5e7-4ef8-acb8-79f169ed58a0"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("cec3c697-d3a2-4869-853f-8b56e80e7534"));
            base.InitializeControls();
        }

        public OrthesisProsthesisFinancialDepartmentForm() : base("ORTHESISPROSTHESISREQUEST", "OrthesisProsthesisFinancialDepartmentForm")
        {
        }

        protected OrthesisProsthesisFinancialDepartmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}