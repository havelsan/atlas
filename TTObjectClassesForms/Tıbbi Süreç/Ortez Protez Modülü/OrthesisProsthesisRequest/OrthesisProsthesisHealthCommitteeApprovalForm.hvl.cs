
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
    public partial class OrthesisProsthesisHealthCommitteeApprovalForm : EpisodeActionForm
    {
    /// <summary>
    /// Ortez Protez  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.OrthesisProsthesisRequest _OrthesisProsthesisRequest
        {
            get { return (TTObjectClasses.OrthesisProsthesisRequest)_ttObject; }
        }

        protected ITTObjectListBox MasterResource;
        protected ITTLabel LabelDateTime;
        protected ITTDateTimePicker RequestDate;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage OrthesisProthesis;
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
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid TreatmentMaterials;
        protected ITTDateTimePickerColumn MActionDate;
        protected ITTListBoxColumn MMaterial;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn MAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProcedureSpeciality;
        protected ITTRichTextBoxControl TotalDescription;
        protected ITTObjectListBox ReasonForExamination;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureDoctor;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelReasonOfExamination;
        protected ITTObjectListBox ProcedureSpeciality;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        override protected void InitializeControls()
        {
            MasterResource = (ITTObjectListBox)AddControl(new Guid("e34f9afd-63bc-4999-9e9e-79b7bba50f15"));
            LabelDateTime = (ITTLabel)AddControl(new Guid("88f8eaed-5619-4da6-b3a1-068647c5ea73"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("0814e458-f232-4fe1-b6e3-00d19b3309fe"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("47251b83-b701-49ba-ba82-dbe562180202"));
            OrthesisProthesis = (ITTTabPage)AddControl(new Guid("12fb23c2-3a6a-40d6-86c4-4b33e36715aa"));
            OrthesisProsthesisProcedures = (ITTGrid)AddControl(new Guid("0f1705f4-5f3a-405e-bbf1-d1e38f5655f4"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("a8085dcf-0a99-4412-b216-e4187582ec86"));
            SideO = (ITTEnumComboBoxColumn)AddControl(new Guid("f14ae1f1-b19a-4bcb-9c3d-de4627f17591"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("efe9ad19-f4e7-4a2c-99da-4f70a0075688"));
            tttabpageDiagnosis = (ITTTabPage)AddControl(new Guid("131113cc-a29d-4b49-bd64-10570fc7f8ee"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("8410a91b-71a9-4963-8f5f-dd9e9cfce7b9"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("588de4fa-f898-48e8-83f3-8391b2211459"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("53036393-dbf2-40d7-a321-372863870eb0"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("fe0f8d53-f230-4dfb-928c-885e5ec736a9"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("10dad49f-216e-4b8c-8903-a8ddb66d44dd"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("42e208dc-bc4b-42ee-8b7e-a7f28687d24b"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("a7914c45-dba9-44ce-b8b5-6d5b077fb806"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("69437e62-8550-4ff5-97c2-15a16e6fcfe6"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("5693fc4b-f37f-402e-9b83-a74643bb206b"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("173d3bdc-5954-4e99-97ae-3c037ede704d"));
            MActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("09a930b1-f8f0-43c9-a937-c1bbd47727ee"));
            MMaterial = (ITTListBoxColumn)AddControl(new Guid("ff9aac4d-5b5d-4626-a158-53d245eb200b"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("9b196a33-a93c-4a84-9844-99671fee5ab5"));
            MAmount = (ITTTextBoxColumn)AddControl(new Guid("cf4803d0-a7a4-4988-9199-40c51872568b"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("8093043e-39e5-467c-8bb0-fbb7397b665c"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("04f76b1b-f103-4b72-a0e6-553868b9bc44"));
            labelProcedureSpeciality = (ITTLabel)AddControl(new Guid("7572c373-917f-4689-b5a3-027e4889ef79"));
            TotalDescription = (ITTRichTextBoxControl)AddControl(new Guid("a69f0e39-0f2b-460b-8bc2-6221f3314f02"));
            ReasonForExamination = (ITTObjectListBox)AddControl(new Guid("5500a74c-4eac-492b-a6ac-1062f1f5902b"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("e62bb474-a654-469e-9a8e-665487d61982"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("be4a0c09-f1f8-46a4-be1d-c606bf94e988"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("352ee4b7-498f-4ea2-89e2-1806acf3574b"));
            labelReasonOfExamination = (ITTLabel)AddControl(new Guid("bd6b2fdb-bcb5-4969-ac9f-56e1dbcc0432"));
            ProcedureSpeciality = (ITTObjectListBox)AddControl(new Guid("f04ec840-c59a-4ac1-99a3-7cb35524f537"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("a09794ed-c714-43ef-acd3-869813dfc6c0"));
            base.InitializeControls();
        }

        public OrthesisProsthesisHealthCommitteeApprovalForm() : base("ORTHESISPROSTHESISREQUEST", "OrthesisProsthesisHealthCommitteeApprovalForm")
        {
        }

        protected OrthesisProsthesisHealthCommitteeApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}