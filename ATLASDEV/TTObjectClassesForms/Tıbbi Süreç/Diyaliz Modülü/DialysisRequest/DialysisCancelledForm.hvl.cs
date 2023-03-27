
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
    /// Diyaliz İstek
    /// </summary>
    public partial class DialysisCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Diyaliz İstek  İşlemlerinin Gerçekleştiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.DialysisRequest _DialysisRequest
        {
            get { return (TTObjectClasses.DialysisRequest)_ttObject; }
        }

        protected ITTTextBox Note;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelRequestDate;
        protected ITTGrid EpisodeDiagnosis;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTListBoxColumn Diagnose;
        protected ITTEnumComboBoxColumn DiagnosisType;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTLabel labelNote;
        protected ITTLabel labelProtocolNo;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage DialysisOrder;
        protected ITTGrid DialysisOrders;
        protected ITTListBoxColumn DialysisOrdersProcedureObject;
        protected ITTListBoxColumn TreatmentDiagnosisUnit;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn Duration;
        protected ITTTextBoxColumn OrderNote;
        protected ITTTextBox ReasonOfCancel;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelReasonOfCancel;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureDoctor;
        override protected void InitializeControls()
        {
            Note = (ITTTextBox)AddControl(new Guid("42fbc858-3b19-48c6-9324-ffa33e557a39"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("32c5c96e-9b1c-4c40-a623-cb3e290db759"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("07e6f28f-8036-4730-b34a-5e959c0c53ee"));
            EpisodeDiagnosis = (ITTGrid)AddControl(new Guid("d084fa5b-122b-4c7a-afb0-7587eb1716da"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("7278186e-3d3f-4e57-99f2-9345da678cdb"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("12885fa6-a955-4b35-873f-b814621158ff"));
            DiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("a3c7b86b-26c7-4721-845b-8a9decd9ec96"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("525d8e01-5b8a-4bcf-8b77-be06453976db"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("a155f54d-6ea7-4efa-8bb2-5d12a4a614b9"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("f41a89fd-035f-4a46-9cba-d63fc82781c6"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("a2866518-1f19-40f9-92a8-573b6383a757"));
            labelNote = (ITTLabel)AddControl(new Guid("7b9ab0d4-7d3b-4679-8ab7-5f49917f31c6"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("27d8808f-e3f2-4b52-8408-1f506675ca2c"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("136f7964-13f5-4673-a9b3-7e37debb63a7"));
            DialysisOrder = (ITTTabPage)AddControl(new Guid("b2c559a4-3e79-4d21-93a3-0ead0f085bc5"));
            DialysisOrders = (ITTGrid)AddControl(new Guid("72ebbed8-b077-4031-aba6-c99264260b4d"));
            DialysisOrdersProcedureObject = (ITTListBoxColumn)AddControl(new Guid("4e59365a-6f0a-496d-9921-ee7dc101f7b3"));
            TreatmentDiagnosisUnit = (ITTListBoxColumn)AddControl(new Guid("089ccf07-fb43-4ca3-b303-5881e200fa43"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("b740f68a-a604-4b35-b617-769c68145a92"));
            Duration = (ITTTextBoxColumn)AddControl(new Guid("59744826-6440-45ea-b03a-0879568edb49"));
            OrderNote = (ITTTextBoxColumn)AddControl(new Guid("7b0c6039-28f1-48e2-bc9c-ffb8edaca05e"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("c7c6bac7-937f-4f35-bda7-22991063ef1f"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("ffa7431a-923c-49cb-b704-ad90698762de"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d3195061-f96f-447e-9f0c-bff719aa6853"));
            labelReasonOfCancel = (ITTLabel)AddControl(new Guid("d62226d7-dd6f-4c29-a5a2-3cbb2ad69236"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("193f2636-096b-4347-a0f5-38f06258240b"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("159d4260-94c3-4eeb-bea4-0865a78cfb78"));
            base.InitializeControls();
        }

        public DialysisCancelledForm() : base("DIALYSISREQUEST", "DialysisCancelledForm")
        {
        }

        protected DialysisCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}