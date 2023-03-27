
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
    /// Hiperbarik Oksijen Tedavi Planlama Formu
    /// </summary>
    public partial class HyperbaricOxygenTreatmentPlanForm : EpisodeActionForm
    {
    /// <summary>
    /// Hiperbarik Oksijen Tedavi Emirinin Verildiği Nesnedir
    /// </summary>
        protected TTObjectClasses.HyperbaricOxygenTreatmentOrder _HyperbaricOxygenTreatmentOrder
        {
            get { return (TTObjectClasses.HyperbaricOxygenTreatmentOrder)_ttObject; }
        }

        protected ITTButton btnMedulayaKaydet;
        protected ITTGrid MedulaReportResults;
        protected ITTTextBoxColumn ReportChasingNoMedulaReportResult;
        protected ITTTextBoxColumn ReportNumberMedulaReportResult;
        protected ITTTextBoxColumn ReportRowNumberMedulaReportResult;
        protected ITTTextBoxColumn ResultCodeMedulaReportResult;
        protected ITTTextBoxColumn ResultExplanationMedulaReportResult;
        protected ITTDateTimePickerColumn SendReportDateMedulaReportResult;
        protected ITTButtonColumn btnMeduladanSil;
        protected ITTLabel labelTreatmentPeriod;
        protected ITTTextBox TreatmentPeriod;
        protected ITTTextBox TreatmentProperties;
        protected ITTTextBox Amount;
        protected ITTTextBox Duration;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox TreatmentDepth;
        protected ITTTextBox Note;
        protected ITTLabel labelTreatmentEquipment;
        protected ITTObjectListBox TreatmentEquipment;
        protected ITTLabel labelTreatmentDiagnosisUnit;
        protected ITTObjectListBox TreatmentDiagnosisUnit;
        protected ITTLabel labelTreatmentStartDateTime;
        protected ITTDateTimePicker TreatmentStartDateTime;
        protected ITTLabel labelTreatmentProperties;
        protected ITTLabel labelProcedureObject;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel labelAmount;
        protected ITTLabel labelDuration;
        protected ITTRichTextBoxControl ReasonOfRejection;
        protected ITTLabel labelReasonOfRejection;
        protected ITTLabel labelRequestDate;
        protected ITTLabel LabelProtocolNo;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelTreatmentDepth;
        protected ITTLabel labelPatientFollowUpForm;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelOperator;
        protected ITTObjectListBox Physiotherapist;
        protected ITTLabel labelNote;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureDoctor;
        override protected void InitializeControls()
        {
            btnMedulayaKaydet = (ITTButton)AddControl(new Guid("97495876-3869-43bd-8f2b-4532cdc58a48"));
            MedulaReportResults = (ITTGrid)AddControl(new Guid("bc3e3a9b-67e4-4f88-a5ce-f4f85249350b"));
            ReportChasingNoMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("87bb64ae-9fc0-4724-9748-52bd3c2e4765"));
            ReportNumberMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("8357baae-1863-4bc2-abde-2418653bd2cd"));
            ReportRowNumberMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("311dcdc3-3b4a-4c83-a488-4d30b1e2864d"));
            ResultCodeMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("28f8c655-5298-4954-9cf3-1b5b5e9282ce"));
            ResultExplanationMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("377ac475-2904-40e0-b8dc-b5b95565607b"));
            SendReportDateMedulaReportResult = (ITTDateTimePickerColumn)AddControl(new Guid("1436cac0-9a22-438f-afa5-d678164e15f0"));
            btnMeduladanSil = (ITTButtonColumn)AddControl(new Guid("37a6f0ab-95ca-4719-8878-84af5721e7a9"));
            labelTreatmentPeriod = (ITTLabel)AddControl(new Guid("252bb07a-e8ba-4347-aaa2-b648c3a31937"));
            TreatmentPeriod = (ITTTextBox)AddControl(new Guid("b3b653c0-0f2a-42aa-911f-d76bc99e1f98"));
            TreatmentProperties = (ITTTextBox)AddControl(new Guid("de454e49-b3c7-4a43-be47-5037183e78d9"));
            Amount = (ITTTextBox)AddControl(new Guid("5763458b-6b85-4f68-954a-ade02cbe4e65"));
            Duration = (ITTTextBox)AddControl(new Guid("b33c53d8-74db-47bf-bcdb-de5c4abb5ede"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("84c65a47-ee12-4dd1-aca5-f8c0d52df83a"));
            TreatmentDepth = (ITTTextBox)AddControl(new Guid("ce49ae4e-661d-4e1a-907d-5c3b459cc5cd"));
            Note = (ITTTextBox)AddControl(new Guid("3b7f605e-5b56-45ea-83e3-cd5eb3b05ff0"));
            labelTreatmentEquipment = (ITTLabel)AddControl(new Guid("42a5e161-8a39-4ba4-81a2-2da159892541"));
            TreatmentEquipment = (ITTObjectListBox)AddControl(new Guid("936f8a74-3a2f-4a42-9300-8dfefe801ffb"));
            labelTreatmentDiagnosisUnit = (ITTLabel)AddControl(new Guid("c5b855cf-7878-45dc-a9da-8c1f4810fffd"));
            TreatmentDiagnosisUnit = (ITTObjectListBox)AddControl(new Guid("b56fe376-2be4-4932-a455-6f6ca6cb4237"));
            labelTreatmentStartDateTime = (ITTLabel)AddControl(new Guid("68dea2c8-acc1-409b-a9cf-65c9dd5c0f93"));
            TreatmentStartDateTime = (ITTDateTimePicker)AddControl(new Guid("9ad01a7c-f2c2-4653-83d3-80fd290fe2de"));
            labelTreatmentProperties = (ITTLabel)AddControl(new Guid("cac14104-09ba-42c9-8904-1287c0639417"));
            labelProcedureObject = (ITTLabel)AddControl(new Guid("fe4b72dc-d710-44ea-b907-23298c25dd74"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("5a0cbd56-8b2d-4f4a-9a48-a610f2187334"));
            labelAmount = (ITTLabel)AddControl(new Guid("0a3d7394-a959-4d99-b6be-a61ec333c97b"));
            labelDuration = (ITTLabel)AddControl(new Guid("9d8f2f35-328c-459e-9125-f7462dea3dde"));
            ReasonOfRejection = (ITTRichTextBoxControl)AddControl(new Guid("a05408b7-9f26-4254-9d31-fbbf1d6a1392"));
            labelReasonOfRejection = (ITTLabel)AddControl(new Guid("f0a2e34a-8a4d-40e6-aef6-d2a58f9398de"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("e02ec74d-8ea7-48c5-b329-a66bddf49928"));
            LabelProtocolNo = (ITTLabel)AddControl(new Guid("6e253741-0e42-4cd8-a8b2-d508bae58419"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("def974b3-328f-4a9b-a687-e249f8d06446"));
            labelTreatmentDepth = (ITTLabel)AddControl(new Guid("af7448f4-b959-4e3c-b59f-279d0bf4f26d"));
            labelPatientFollowUpForm = (ITTLabel)AddControl(new Guid("03652a10-60ae-4e52-a5d1-a7a49a8ccae0"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("df98546e-ceee-4d1f-be78-808b070a7fa8"));
            labelOperator = (ITTLabel)AddControl(new Guid("8fda634d-11cd-4d8b-b30f-0a939001be42"));
            Physiotherapist = (ITTObjectListBox)AddControl(new Guid("d42c86c8-317c-4609-a606-6700b29ea460"));
            labelNote = (ITTLabel)AddControl(new Guid("bd5d4e8e-3198-4fff-a82c-a10b6535f294"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("b95f8fbd-e628-4e28-8c25-4a77fc25107a"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("32962058-7149-4947-a0a4-563e24350c98"));
            base.InitializeControls();
        }

        public HyperbaricOxygenTreatmentPlanForm() : base("HYPERBARICOXYGENTREATMENTORDER", "HyperbaricOxygenTreatmentPlanForm")
        {
        }

        protected HyperbaricOxygenTreatmentPlanForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}