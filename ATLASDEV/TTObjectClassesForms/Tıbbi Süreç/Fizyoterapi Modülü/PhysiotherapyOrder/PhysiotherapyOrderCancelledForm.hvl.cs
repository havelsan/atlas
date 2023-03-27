
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
    /// Fizyoterapi
    /// </summary>
    public partial class PhysiotherapyOrderCancelledForm : BasePhysiotherapyOrderForm
    {
    /// <summary>
    /// F.T.R. Emrinin Veridiği Nesnedir
    /// </summary>
        protected TTObjectClasses.PhysiotherapyOrder _PhysiotherapyOrder
        {
            get { return (TTObjectClasses.PhysiotherapyOrder)_ttObject; }
        }

        protected ITTTextBox tttextbox6;
        protected ITTTextBox ApplicationArea;
        protected ITTTextBox Duration;
        protected ITTTextBox PhysiotherapistOrder;
        protected ITTTextBox TreatmentProperties;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox ReasonOfCancel;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel lblEpisodeDiagnosis;
        protected ITTLabel labelPhysiotherapistOrder;
        protected ITTLabel labelTreatmentProperties;
        protected ITTLabel labelApplicationArea;
        protected ITTLabel ttlabel6;
        protected ITTLabel labelDuration;
        protected ITTObjectListBox ProcedureObject;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTLabel labelProcedureObject;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelTreatmentDiagnosisUnit;
        protected ITTObjectListBox TreatmentDiagnosisUnit;
        protected ITTRichTextBoxControl ReasonOfAbort;
        protected ITTLabel labelReasonOfAbort;
        protected ITTLabel ttlabelReasonOfCancel;
        protected ITTLabel labelPhysiotherapist;
        protected ITTObjectListBox Physiotherapist;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureDoctor;
        override protected void InitializeControls()
        {
            tttextbox6 = (ITTTextBox)AddControl(new Guid("40bb3be2-f81f-41b9-b977-c84ee8de1e8c"));
            ApplicationArea = (ITTTextBox)AddControl(new Guid("97280654-818a-441b-a4d3-23c820506de1"));
            Duration = (ITTTextBox)AddControl(new Guid("f5156e03-541c-4d33-bd0e-45e221cd724b"));
            PhysiotherapistOrder = (ITTTextBox)AddControl(new Guid("9e86bb0e-93f9-4154-b517-39ff5885a3ab"));
            TreatmentProperties = (ITTTextBox)AddControl(new Guid("29ccb894-4dc4-443f-bdb3-2084c2b5d1ff"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("999bfa18-89ae-43b9-9a92-84653e8f402f"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("7ea0a5c0-d730-4368-a791-c7a5e00272fe"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("879eeb63-f632-4c13-9c9b-654d29bb5ead"));
            lblEpisodeDiagnosis = (ITTLabel)AddControl(new Guid("8bb12637-b7d8-420e-9f0c-7e3bccccd7c8"));
            labelPhysiotherapistOrder = (ITTLabel)AddControl(new Guid("b9092c6e-9562-4be4-a81a-c73981087493"));
            labelTreatmentProperties = (ITTLabel)AddControl(new Guid("a05c969d-7670-4ef9-9d71-63e9b8864744"));
            labelApplicationArea = (ITTLabel)AddControl(new Guid("ba138030-bfe1-4f8f-94ee-6f7ecebf630a"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("48e558ef-3d80-4bd1-9436-6faae1c91292"));
            labelDuration = (ITTLabel)AddControl(new Guid("86343032-6539-4a29-bca7-3b40793faf34"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("373031a8-0dbe-4629-8f08-66012fb227a8"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("9240f5b7-6908-41a6-887f-72d47b51339d"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("139db17b-5903-4e48-b454-619db69a2e86"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("bc78f402-3c36-4ee8-b9f7-67b21e78414d"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("f2612de6-0f4f-4d1c-8453-bb499a9a0c7d"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("16e3ff03-89dd-4cc9-936f-fba4d920d439"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("8c1831c0-b69f-4440-92b5-98bec3c1b966"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("2505d879-a13a-4c2e-b88b-8db45aec6c1a"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("76eafbd1-839d-4fa6-bead-88928ecbb52c"));
            labelProcedureObject = (ITTLabel)AddControl(new Guid("e4a65754-305e-4b8e-a15f-24317c4e3c96"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("b9649016-0f2e-4229-8b37-f19254f7f22f"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("572c797c-ef33-4108-825d-e3c40aaf2b4a"));
            labelActionDate = (ITTLabel)AddControl(new Guid("d2725c64-1cb0-4088-bb24-b540cc6e3a6d"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("e620171d-cb87-468b-8b4a-658e0df5078b"));
            labelTreatmentDiagnosisUnit = (ITTLabel)AddControl(new Guid("7decf4a6-26c1-4ccd-8823-f17ed7deb891"));
            TreatmentDiagnosisUnit = (ITTObjectListBox)AddControl(new Guid("6e666927-3cad-486a-8c12-4f0304639cc0"));
            ReasonOfAbort = (ITTRichTextBoxControl)AddControl(new Guid("45b20bac-ed7d-4aba-92b6-c1d636508ea9"));
            labelReasonOfAbort = (ITTLabel)AddControl(new Guid("732d51ae-d6c6-4bf8-ac73-f03141e468f6"));
            ttlabelReasonOfCancel = (ITTLabel)AddControl(new Guid("5ae2990a-2717-4b8c-8a1a-54fa73419d58"));
            labelPhysiotherapist = (ITTLabel)AddControl(new Guid("dbff509b-f719-4394-9a95-3957d0d99cf0"));
            Physiotherapist = (ITTObjectListBox)AddControl(new Guid("e47112d4-c8ac-4429-9eea-befa6ce046d9"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("25d4e9d9-a45c-4de7-8a7f-f3bf764c2222"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("1f43d687-d3d1-4763-b245-91dca8e1ce96"));
            base.InitializeControls();
        }

        public PhysiotherapyOrderCancelledForm() : base("PHYSIOTHERAPYORDER", "PhysiotherapyOrderCancelledForm")
        {
        }

        protected PhysiotherapyOrderCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}