
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
    /// Ameliyat
    /// </summary>
    public partial class SurgeryRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Ameliyat  İşlemlerinin Gerçekleştirildiği  Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Surgery _Surgery
        {
            get { return (TTObjectClasses.Surgery)_ttObject; }
        }

        protected ITTLabel labelSurgeryDesk;
        protected ITTObjectListBox SurgeryDesk;
        protected ITTLabel labelPlannedSurgeryDescription;
        protected ITTTextBox PlannedSurgeryDescription;
        protected ITTTextBox NotesToAnesthesia;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox ComplicationDescription;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestDate;
        protected ITTLabel labelNotesToAnesthesia;
        protected ITTRichTextBoxControl DescriptionToPreOp;
        protected ITTLabel ttlabel9;
        protected ITTDateTimePicker PlannedSurgeryDate;
        protected ITTLabel labelProtocolNo;
        protected ITTObjectListBox SurgeryRoom;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox MasterResource;
        protected ITTCheckBox Emergency;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTLabel labelRoom;
        protected ITTGrid GridMainSurgeryProcedures;
        protected ITTListBoxColumn CAProcedureObject;
        protected ITTRichTextBoxControlColumn DescriptionOfProcedureObject;
        protected ITTLabel labelComplicationDescription;
        protected ITTCheckBox IsComplicationSurgery;
        protected ITTCheckBox IsNeedAnesthesia;
        override protected void InitializeControls()
        {
            labelSurgeryDesk = (ITTLabel)AddControl(new Guid("04c12110-21b6-4b32-9812-c113faf0e9d7"));
            SurgeryDesk = (ITTObjectListBox)AddControl(new Guid("621168df-0383-4b9f-bfa5-4c067275bc99"));
            labelPlannedSurgeryDescription = (ITTLabel)AddControl(new Guid("1922000c-e354-4289-86ad-8c2ad5627e34"));
            PlannedSurgeryDescription = (ITTTextBox)AddControl(new Guid("ffbd96d1-dcbb-4c25-a926-48db49efb90a"));
            NotesToAnesthesia = (ITTTextBox)AddControl(new Guid("c59512e6-7c83-4958-9233-15af28ed707c"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("391a6380-0758-4770-850e-cebbb9686ddf"));
            ComplicationDescription = (ITTTextBox)AddControl(new Guid("46eef37d-4e4b-4843-8ed9-a72e84a1cd65"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("8b9ff80e-cf77-41dd-8cf7-bae922880b20"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("5700a5cf-0b77-490f-829f-cb1d954f97d8"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("3a5c896a-32a5-4e18-bc11-4cc2f785d450"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("471d58c6-5eeb-4b36-aba0-968ed8cb2512"));
            labelNotesToAnesthesia = (ITTLabel)AddControl(new Guid("40885962-47f5-4651-9217-616fcbf69713"));
            DescriptionToPreOp = (ITTRichTextBoxControl)AddControl(new Guid("2b0c2b7f-db94-4ba8-9f78-71a731e7f978"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("e2e3129b-58bb-443b-aded-50c107b16cd3"));
            PlannedSurgeryDate = (ITTDateTimePicker)AddControl(new Guid("45234354-2f06-4139-993f-bf9a773636de"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("7fc11fb2-bfc1-4f6f-b54b-154d696fc861"));
            SurgeryRoom = (ITTObjectListBox)AddControl(new Guid("1e08bae2-da86-4c10-b017-19f23ba900cf"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("bd9af673-5164-475e-b36a-223b90b74740"));
            MasterResource = (ITTObjectListBox)AddControl(new Guid("09b31a28-a5fa-47bb-9282-924f6152b519"));
            Emergency = (ITTCheckBox)AddControl(new Guid("8681edee-bf95-4f80-9c08-92fe255c0184"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("6699d975-d0fc-4bc6-b282-b424538da818"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("f36f413e-39a1-4082-adab-26772af82075"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("1db3ad34-d1d1-4376-8a84-958689f035ee"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("a36a5457-8896-4afa-bc01-b8f21097dcf7"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("b479dbc1-19f2-48f6-bef6-628334cfbf27"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("8e1799e4-ff2b-4cb9-942e-6ddc801fdb7f"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("245c39ff-ef2b-47e6-ae34-0bc555915756"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("f0b71f54-eda1-4b8d-b11c-563fe60a99d0"));
            labelRoom = (ITTLabel)AddControl(new Guid("6ee5b030-cb3c-472a-bd48-f17d7bfd9f87"));
            GridMainSurgeryProcedures = (ITTGrid)AddControl(new Guid("b93ed1d9-e44c-4331-af39-db1945b4179d"));
            CAProcedureObject = (ITTListBoxColumn)AddControl(new Guid("0d1a31ac-f474-40ae-8a89-85552b80d13a"));
            DescriptionOfProcedureObject = (ITTRichTextBoxControlColumn)AddControl(new Guid("71463ffe-5a64-488e-8c7f-2a31b59ea376"));
            labelComplicationDescription = (ITTLabel)AddControl(new Guid("3c6901ab-d372-4073-98ee-14a291ca958e"));
            IsComplicationSurgery = (ITTCheckBox)AddControl(new Guid("7285fab9-21e0-42e6-922b-e0adfe8bef07"));
            IsNeedAnesthesia = (ITTCheckBox)AddControl(new Guid("b291b40a-a5ff-4640-ae98-aa78166b1928"));
            base.InitializeControls();
        }

        public SurgeryRequestForm() : base("SURGERY", "SurgeryRequestForm")
        {
        }

        protected SurgeryRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}