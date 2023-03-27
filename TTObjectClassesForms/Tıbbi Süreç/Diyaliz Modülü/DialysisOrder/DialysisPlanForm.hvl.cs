
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
    /// Diyaliz Planlama Formu
    /// </summary>
    public partial class DialysisPlanForm : BaseDialysisOrderForm
    {
    /// <summary>
    /// Diyaliz Emrinin Verildiği Nesnedir.
    /// </summary>
        protected TTObjectClasses.DialysisOrder _DialysisOrder
        {
            get { return (TTObjectClasses.DialysisOrder)_ttObject; }
        }

        protected ITTButton btnRaporuMedulayaGonder;
        protected ITTGrid MedulaReportResults;
        protected ITTTextBoxColumn ReportChasingNoMedulaReportResult;
        protected ITTTextBoxColumn ReportNumberMedulaReportResult;
        protected ITTTextBoxColumn ReportRowNumberMedulaReportResult;
        protected ITTTextBoxColumn ResultCodeMedulaReportResult;
        protected ITTTextBoxColumn ResultExplanationMedulaReportResult;
        protected ITTDateTimePickerColumn SendReportDateMedulaReportResult;
        protected ITTButtonColumn btnMeduladanSil;
        protected ITTLabel labelTreatmentEquipment;
        protected ITTObjectListBox TreatmentEquipment;
        protected ITTLabel labelTreatmentDiagnosisUnit;
        protected ITTObjectListBox TreatmentDiagnosisUnit;
        protected ITTLabel labelTreatmentStartDateTime;
        protected ITTDateTimePicker TreatmentStartDateTime;
        protected ITTRichTextBoxControl ReasonOfRejection;
        protected ITTLabel labelReasonOfRejection;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox Amount;
        protected ITTTextBox OrderNote;
        protected ITTTextBox Duration;
        protected ITTLabel labelRequestDate;
        protected ITTLabel LabelProtocolNo;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelProcedureObject;
        protected ITTLabel labelOrderNote;
        protected ITTLabel labelAmount;
        protected ITTLabel labelDuration;
        protected ITTObjectListBox ProcedureObject;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            btnRaporuMedulayaGonder = (ITTButton)AddControl(new Guid("b60c1640-1541-4972-880f-3f8d1a6d112e"));
            MedulaReportResults = (ITTGrid)AddControl(new Guid("aa3cbedf-69a0-486e-856d-1ec2e01bbeb7"));
            ReportChasingNoMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("7e412af7-2e78-49b0-b76d-5dfbb30ffca7"));
            ReportNumberMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("c131f08e-43a2-4e09-a389-d05cd4160725"));
            ReportRowNumberMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("a21669b3-efd8-4e27-854d-5c0b328f3906"));
            ResultCodeMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("ea2480f6-e16d-4d29-813b-4d7fed33aa6d"));
            ResultExplanationMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("eeced125-9aac-458a-a445-3114ff77de8e"));
            SendReportDateMedulaReportResult = (ITTDateTimePickerColumn)AddControl(new Guid("c5eb59c8-fcb8-4e0e-ace0-21a02a306437"));
            btnMeduladanSil = (ITTButtonColumn)AddControl(new Guid("f5f77092-b417-462d-856d-0c7e9e754c21"));
            labelTreatmentEquipment = (ITTLabel)AddControl(new Guid("9b51a31c-6746-45d5-a8e2-410dba81e5fa"));
            TreatmentEquipment = (ITTObjectListBox)AddControl(new Guid("1a6826ae-84bd-40f1-825e-cd9f60998184"));
            labelTreatmentDiagnosisUnit = (ITTLabel)AddControl(new Guid("39a49ff8-b9c4-4d8e-a8c4-d61121de6b53"));
            TreatmentDiagnosisUnit = (ITTObjectListBox)AddControl(new Guid("deb7b95c-4150-4878-a2a6-79fc3149ff44"));
            labelTreatmentStartDateTime = (ITTLabel)AddControl(new Guid("e2f258dd-9b03-40ef-a1a6-b1ef043c9ac9"));
            TreatmentStartDateTime = (ITTDateTimePicker)AddControl(new Guid("9ccc7718-de9c-4662-b0d1-a210f7627189"));
            ReasonOfRejection = (ITTRichTextBoxControl)AddControl(new Guid("c5ac1fbc-cf67-4a41-9363-95b1af264f02"));
            labelReasonOfRejection = (ITTLabel)AddControl(new Guid("a8a125ac-84b4-4833-8176-e365dc36e99d"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("bc7fc0c5-0823-4bfa-aabd-dc13d708c62d"));
            Amount = (ITTTextBox)AddControl(new Guid("44b8f576-ba9b-4a14-929f-3c7e1ef0018d"));
            OrderNote = (ITTTextBox)AddControl(new Guid("e622859c-d708-4b57-bcf7-ce75b62cda74"));
            Duration = (ITTTextBox)AddControl(new Guid("de0b2c32-b2ac-41d8-8473-d881e372d473"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("9e827f3a-5f58-4080-be85-027ba6e155c8"));
            LabelProtocolNo = (ITTLabel)AddControl(new Guid("2323a7d4-9b48-4062-98dc-6b5da48f2668"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("5c816f85-f866-40b9-9b1d-edfda100bdaa"));
            labelProcedureObject = (ITTLabel)AddControl(new Guid("8813e14a-ab73-44af-8494-1c14a93b697d"));
            labelOrderNote = (ITTLabel)AddControl(new Guid("5f50eb6c-dce0-4175-9021-3b8640b34682"));
            labelAmount = (ITTLabel)AddControl(new Guid("a340e0fe-f5de-46ce-b411-4a6f98756483"));
            labelDuration = (ITTLabel)AddControl(new Guid("c835272f-c1c2-46ee-ade9-aaed02fd0a45"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("2e517be2-9e4c-480e-9b3d-f7507d6d5631"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("c874715f-e021-4ec8-882b-ebed3f779484"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("e49bacc7-92f8-4245-83ec-36e188198782"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("15ebe64b-ae54-4495-b410-d05191efc8aa"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("8eda82de-88c5-43ac-a252-cc0695f1f6ff"));
            base.InitializeControls();
        }

        public DialysisPlanForm() : base("DIALYSISORDER", "DialysisPlanForm")
        {
        }

        protected DialysisPlanForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}