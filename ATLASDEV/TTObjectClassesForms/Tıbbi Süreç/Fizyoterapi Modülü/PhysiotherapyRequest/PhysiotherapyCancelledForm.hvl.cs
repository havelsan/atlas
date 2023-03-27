
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
    /// Fizyoterapi İstek
    /// </summary>
    public partial class PhysiotherapyCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// F.T.R. İstek İşlemlerinin Gerçekleştirildiği  Nesnedir
    /// </summary>
        protected TTObjectClasses.PhysiotherapyRequest _PhysiotherapyRequest
        {
            get { return (TTObjectClasses.PhysiotherapyRequest)_ttObject; }
        }

        protected ITTLabel lblEpisodeDiagnosis;
        protected ITTLabel labelNote;
        protected ITTDateTimePicker RequestDate;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage PhysiotherapyOrder;
        protected ITTGrid Physiotherapies;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTListBoxColumn TreatmentDiagnosisUnit;
        protected ITTTextBoxColumn ApplicationArea;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn Duration;
        protected ITTTextBoxColumn TreatmentProperties;
        protected ITTTextBox NoteToPhysiotherapist;
        protected ITTTextBox ReasonOfCancel;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelRequestDate;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTLabel labelReasonOfCancel;
        protected ITTLabel labelProtocolNo;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox SecondProcedureDoctor;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ThirdProcedureDoctor;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            lblEpisodeDiagnosis = (ITTLabel)AddControl(new Guid("04506c63-0724-45d5-988c-fac85029a545"));
            labelNote = (ITTLabel)AddControl(new Guid("16b48720-3824-4ee6-9027-e7ff2b870258"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("2bdad9a4-027b-44f6-be62-316748b64b5e"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("59b23bcf-45e2-46e9-a2c4-8ad876650561"));
            PhysiotherapyOrder = (ITTTabPage)AddControl(new Guid("34825cdd-e06d-4074-bd0e-8f78ee3f684d"));
            Physiotherapies = (ITTGrid)AddControl(new Guid("b5b657c0-3691-490d-8473-cabbc9503c2d"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("49c9fcac-01dc-47a6-815e-bcac28df7230"));
            TreatmentDiagnosisUnit = (ITTListBoxColumn)AddControl(new Guid("003d6131-8943-4854-830f-e7e4487406d3"));
            ApplicationArea = (ITTTextBoxColumn)AddControl(new Guid("8dc2ab66-4dd6-416d-bb24-06a1456a75d7"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("721d4c2b-5500-41a6-b638-4b5cb4de9141"));
            Duration = (ITTTextBoxColumn)AddControl(new Guid("004fda6f-5a35-470d-9d8a-8de8bf698eff"));
            TreatmentProperties = (ITTTextBoxColumn)AddControl(new Guid("765caa32-0f22-4384-95ec-7e4694edbcd6"));
            NoteToPhysiotherapist = (ITTTextBox)AddControl(new Guid("f8f9a82c-88e6-4c43-a04d-2e39f3b52f42"));
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("20dd692f-9a14-4988-a54c-d6dda8eff964"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("0aba0555-5023-46fb-95e9-f1f3fc796aff"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("8d3d8143-09a9-4a09-a78d-1a80b2b31883"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("72c33d82-be39-4817-afef-ef6d2e112016"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("aa176aec-6b9e-4edd-8b65-2752e76583f2"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("d477532e-0e3e-4f68-bf2c-dee7934d6a93"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("1f4dae59-e1c6-4c1f-b649-c94715c3d8ce"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("475b887d-c02f-4eae-af5c-8b1836ebe1af"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("d48ffe7f-2b2d-46e8-9dd7-28d3c2a0f55e"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("7e01e04b-40f9-444d-90ed-e761f104dfce"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("f860b636-6f83-43b1-b492-b36f7e2e1878"));
            labelReasonOfCancel = (ITTLabel)AddControl(new Guid("92c3682e-af7c-4481-84f0-fa273294ec4d"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("fc1cfa42-cd7a-4f71-9ad9-acec5dd3a8fe"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("d43fe982-b2cc-4185-b190-c6870e41fea2"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("49cb285f-080a-45e7-bfef-0772d53be9eb"));
            SecondProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("79ff7343-55d4-48c0-8680-6ca43a7951a4"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("5b3d51b8-4cfa-43cf-b97e-1b7a60d8df1d"));
            ThirdProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("39f81c1d-d2fe-49b5-8616-fb1a175a51bc"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("d59b699d-0575-412b-8e39-46e4b2ed53b3"));
            base.InitializeControls();
        }

        public PhysiotherapyCancelledForm() : base("PHYSIOTHERAPYREQUEST", "PhysiotherapyCancelledForm")
        {
        }

        protected PhysiotherapyCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}