
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
    /// Fizyoterapi Planlaması Yapılacak Emirler
    /// </summary>
    public partial class PhysiotherapyPlannedOrdersForm : TTForm
    {
    /// <summary>
    /// F.T.R. Emrinin Veridiği Nesnedir
    /// </summary>
        protected TTObjectClasses.PhysiotherapyOrder _PhysiotherapyOrder
        {
            get { return (TTObjectClasses.PhysiotherapyOrder)_ttObject; }
        }

        protected ITTCheckBox IsPaidTreatment;
        protected ITTLabel labelPackageProcedure;
        protected ITTObjectListBox PackageProcedure;
        protected ITTCheckBox IsAdditionalTreatment;
        protected ITTLabel labelTreatmentProperties;
        protected ITTTextBox TreatmentProperties;
        protected ITTTextBox DoseDurationInfo;
        protected ITTTextBox Dose;
        protected ITTTextBox StartSession;
        protected ITTTextBox SeansGunSayisi;
        protected ITTTextBox FinishSession;
        protected ITTTextBox Duration;
        protected ITTTextBox ApplicationArea;
        protected ITTLabel labelDoseDurationInfo;
        protected ITTLabel labelPhysiotherapyStartDate;
        protected ITTDateTimePicker PhysiotherapyStartDate;
        protected ITTPanel ttpanel1;
        protected ITTLabel labelReportNoPhysiotherapyReports;
        protected ITTLabel labelDiagnosisGroupPhysiotherapyReports;
        protected ITTEnumComboBox TreatmentTypePhysiotherapyReports;
        protected ITTLabel labelTreatmentTypePhysiotherapyReports;
        protected ITTObjectListBox FTRApplicationAreaDefPhysiotherapyReports;
        protected ITTTextBox TreatmentProcessTypePhysiotherapyReports;
        protected ITTLabel labelFTRApplicationAreaDefPhysiotherapyReports;
        protected ITTTextBox PackageProcedureInfoPhysiotherapyReports;
        protected ITTLabel labelReportInfoPhysiotherapyReports;
        protected ITTTextBox ReportTimePhysiotherapyReports;
        protected ITTDateTimePicker ReportEndDatePhysiotherapyReports;
        protected ITTTextBox ReportNoPhysiotherapyReports;
        protected ITTLabel labelReportEndDatePhysiotherapyReports;
        protected ITTTextBox ReportInfoPhysiotherapyReports;
        protected ITTDateTimePicker ReportStartDatePhysiotherapyReports;
        protected ITTTextBox DiagnosisGroupPhysiotherapyReports;
        protected ITTLabel labelReportStartDatePhysiotherapyReports;
        protected ITTLabel labelReportTimePhysiotherapyReports;
        protected ITTDateTimePicker ReportDatePhysiotherapyReports;
        protected ITTLabel labelReportDatePhysiotherapyReports;
        protected ITTCheckBox ReportType;
        protected ITTLabel labelPackageProcedureInfoPhysiotherapyReports;
        protected ITTLabel labelTreatmentProcessTypePhysiotherapyReports;
        protected ITTLabel labelDose;
        protected ITTGrid PhysiotherapyOrderDetails;
        protected ITTRichTextBoxControlColumn NotePhysiotherapyOrderDetail;
        protected ITTEnumComboBoxColumn PhysiotherapyStatePhysiotherapyOrderDetail;
        protected ITTDateTimePickerColumn PlannedDatePhysiotherapyOrderDetail;
        protected ITTTextBoxColumn raporTakipNoPhysiotherapyOrderDetail;
        protected ITTTextBoxColumn SessionNumberPhysiotherapyOrderDetail;
        protected ITTLabel labelStartSession;
        protected ITTLabel labelSeansGunSayisi;
        protected ITTCheckBox IncludeFriday;
        protected ITTCheckBox IncludeThursday;
        protected ITTCheckBox IncludeWednesday;
        protected ITTCheckBox IncludeMonday;
        protected ITTCheckBox IncludeTuesday;
        protected ITTCheckBox IncludeSunday;
        protected ITTCheckBox IncludeSaturday;
        protected ITTLabel labelFinishSession;
        protected ITTLabel labelDuration;
        protected ITTLabel labelApplicationArea;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureObject;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel labelFTRApplicationAreaDef;
        protected ITTObjectListBox FTRApplicationAreaDef;
        protected ITTLabel labelTreatmentDiagnosisUnit;
        protected ITTObjectListBox TreatmentDiagnosisUnit;
        override protected void InitializeControls()
        {
            IsPaidTreatment = (ITTCheckBox)AddControl(new Guid("43b4a0db-6dc8-4c8b-88f8-b18a2357aa02"));
            labelPackageProcedure = (ITTLabel)AddControl(new Guid("0800c51a-0376-4e76-a9fb-8d26cc02e7fc"));
            PackageProcedure = (ITTObjectListBox)AddControl(new Guid("418775bc-0215-4d3c-a0ba-e9a58a911a1f"));
            IsAdditionalTreatment = (ITTCheckBox)AddControl(new Guid("3219991c-d2c8-4fd1-8241-5ebc57754b8f"));
            labelTreatmentProperties = (ITTLabel)AddControl(new Guid("5c2c0ca7-6edb-447e-b331-afd92ccbe106"));
            TreatmentProperties = (ITTTextBox)AddControl(new Guid("5522673f-de35-49cf-b83c-f83dbd023d58"));
            DoseDurationInfo = (ITTTextBox)AddControl(new Guid("e5e39c64-4538-4033-9930-253dcea79e0b"));
            Dose = (ITTTextBox)AddControl(new Guid("dec01ffc-02ce-4a72-94d6-c5b35e908efe"));
            StartSession = (ITTTextBox)AddControl(new Guid("0c6ae9b4-946f-451b-81f2-5e6355293118"));
            SeansGunSayisi = (ITTTextBox)AddControl(new Guid("0faafecf-9ed9-416e-8ea6-99c6b0dac698"));
            FinishSession = (ITTTextBox)AddControl(new Guid("45aa9a96-b761-436a-a8bf-d23dcef95bb6"));
            Duration = (ITTTextBox)AddControl(new Guid("672c9644-6836-46e7-8ca8-0c0932d9ca9d"));
            ApplicationArea = (ITTTextBox)AddControl(new Guid("bc6072d3-a9f4-4e3b-93b5-adb13ed6b4a3"));
            labelDoseDurationInfo = (ITTLabel)AddControl(new Guid("6be8469b-ac61-4988-a48e-d9a5fe5c23ce"));
            labelPhysiotherapyStartDate = (ITTLabel)AddControl(new Guid("763e8afe-728d-4ed1-849a-2f1b309d7363"));
            PhysiotherapyStartDate = (ITTDateTimePicker)AddControl(new Guid("3f71be94-86df-4230-92ec-cefcbdea5379"));
            ttpanel1 = (ITTPanel)AddControl(new Guid("22006688-39ce-435c-b638-63e3cd4f9248"));
            labelReportNoPhysiotherapyReports = (ITTLabel)AddControl(new Guid("83a96ac3-4c83-4bff-a2a5-a0428069ca2b"));
            labelDiagnosisGroupPhysiotherapyReports = (ITTLabel)AddControl(new Guid("15e1cfa4-eb11-4f98-85a5-13d92af81856"));
            TreatmentTypePhysiotherapyReports = (ITTEnumComboBox)AddControl(new Guid("194e7c87-694c-4533-a0e1-e58958c2ee2a"));
            labelTreatmentTypePhysiotherapyReports = (ITTLabel)AddControl(new Guid("b67f101a-5e50-4bd0-aa5c-ce1e1ed7bbda"));
            FTRApplicationAreaDefPhysiotherapyReports = (ITTObjectListBox)AddControl(new Guid("a8d2a704-896c-4d58-9d2a-f8451c37d33c"));
            TreatmentProcessTypePhysiotherapyReports = (ITTTextBox)AddControl(new Guid("03e43070-2147-43e5-b642-db1e2cc84c82"));
            labelFTRApplicationAreaDefPhysiotherapyReports = (ITTLabel)AddControl(new Guid("91f2a4f9-58d2-41f7-8efb-2a14b8948ffc"));
            PackageProcedureInfoPhysiotherapyReports = (ITTTextBox)AddControl(new Guid("c3ba06b5-b692-41d2-81b3-9c3cbbfd1a91"));
            labelReportInfoPhysiotherapyReports = (ITTLabel)AddControl(new Guid("d6c9d52c-1d4a-4483-89ac-d813905406a3"));
            ReportTimePhysiotherapyReports = (ITTTextBox)AddControl(new Guid("25f9dbf6-afb9-4e74-bdd3-19fb30c9e6b7"));
            ReportEndDatePhysiotherapyReports = (ITTDateTimePicker)AddControl(new Guid("b448c044-1da1-4dee-ad50-c646531f8ee9"));
            ReportNoPhysiotherapyReports = (ITTTextBox)AddControl(new Guid("c83ee0ad-4914-4814-9dd2-eb5faf42dece"));
            labelReportEndDatePhysiotherapyReports = (ITTLabel)AddControl(new Guid("ae0c1d60-aa8d-4a09-a70a-ef59cabe3731"));
            ReportInfoPhysiotherapyReports = (ITTTextBox)AddControl(new Guid("25a0935e-a792-45ab-abb5-a40ad9e6e9d4"));
            ReportStartDatePhysiotherapyReports = (ITTDateTimePicker)AddControl(new Guid("27137dba-7270-449c-a243-dbd958cb59e1"));
            DiagnosisGroupPhysiotherapyReports = (ITTTextBox)AddControl(new Guid("54e92f11-49a8-4212-b951-fe2ecabd4ae0"));
            labelReportStartDatePhysiotherapyReports = (ITTLabel)AddControl(new Guid("4d44af6f-5728-4ada-b221-7e9b81ad798c"));
            labelReportTimePhysiotherapyReports = (ITTLabel)AddControl(new Guid("ed121504-5ef7-4f90-a2a9-36a1bd765277"));
            ReportDatePhysiotherapyReports = (ITTDateTimePicker)AddControl(new Guid("ed43c999-bb99-4ee0-85ba-6c7a1e01d33e"));
            labelReportDatePhysiotherapyReports = (ITTLabel)AddControl(new Guid("50d5fbf4-2bd7-4256-9ed1-dc00502b4cd8"));
            ReportType = (ITTCheckBox)AddControl(new Guid("d605d2bc-fb1f-4dd1-abff-f7ac1235514b"));
            labelPackageProcedureInfoPhysiotherapyReports = (ITTLabel)AddControl(new Guid("8b316073-a6e6-401e-96e5-10f1ef2a31b9"));
            labelTreatmentProcessTypePhysiotherapyReports = (ITTLabel)AddControl(new Guid("2b44d52b-ee18-4c91-b0a9-65588193ec58"));
            labelDose = (ITTLabel)AddControl(new Guid("d12bcc7f-2093-42c0-a262-318d424f7f3e"));
            PhysiotherapyOrderDetails = (ITTGrid)AddControl(new Guid("08805f75-b79f-4d5c-a84f-2acd6781eddb"));
            NotePhysiotherapyOrderDetail = (ITTRichTextBoxControlColumn)AddControl(new Guid("4900343e-1112-40fa-a31a-1ce59f4c8ebc"));
            PhysiotherapyStatePhysiotherapyOrderDetail = (ITTEnumComboBoxColumn)AddControl(new Guid("a3187f8e-d119-433e-9089-5c8e471ba178"));
            PlannedDatePhysiotherapyOrderDetail = (ITTDateTimePickerColumn)AddControl(new Guid("2ff711a3-695f-40a7-95b5-c30510f54714"));
            raporTakipNoPhysiotherapyOrderDetail = (ITTTextBoxColumn)AddControl(new Guid("4f5ce77e-0834-4451-bd3c-784765c23d4c"));
            SessionNumberPhysiotherapyOrderDetail = (ITTTextBoxColumn)AddControl(new Guid("8574938a-9290-455b-aba0-ab4d884cbacd"));
            labelStartSession = (ITTLabel)AddControl(new Guid("a8341467-0cdd-4fae-9974-6e5952ab4418"));
            labelSeansGunSayisi = (ITTLabel)AddControl(new Guid("3c7a238b-0453-46ec-88e2-33f8fd430efe"));
            IncludeFriday = (ITTCheckBox)AddControl(new Guid("f9c96b15-bece-44b4-83d0-a5b99b581383"));
            IncludeThursday = (ITTCheckBox)AddControl(new Guid("83bac4f0-38f1-43f0-9c67-92518792ddc3"));
            IncludeWednesday = (ITTCheckBox)AddControl(new Guid("99a01c78-f1fc-4d38-9078-b2031d6919f9"));
            IncludeMonday = (ITTCheckBox)AddControl(new Guid("3d81b95e-37a5-441c-aefb-99ce0d35f934"));
            IncludeTuesday = (ITTCheckBox)AddControl(new Guid("8871d7f2-eb74-49ae-9760-be23bace0f52"));
            IncludeSunday = (ITTCheckBox)AddControl(new Guid("3740afc6-85f2-49fb-b1f2-bed1f9378e97"));
            IncludeSaturday = (ITTCheckBox)AddControl(new Guid("be33eb52-fff0-4b97-964c-43b6d6e1e255"));
            labelFinishSession = (ITTLabel)AddControl(new Guid("2b54aadb-ae06-4e7d-afec-835c32ccdc1f"));
            labelDuration = (ITTLabel)AddControl(new Guid("4d28d718-441f-4d10-afb0-bea6a3de4c7c"));
            labelApplicationArea = (ITTLabel)AddControl(new Guid("e7d6ef87-80ca-4047-9db2-103a742b8793"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("69f7c453-37dc-49fd-9a45-6b9b9a1a1fcd"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("e65e7afd-46d8-463f-a294-dcf3eeca8b63"));
            labelProcedureObject = (ITTLabel)AddControl(new Guid("db56bbb9-c325-41ab-b103-b06602f2f6fd"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("0a05cf8d-f9bf-40bb-86d0-82159ed5fb60"));
            labelFTRApplicationAreaDef = (ITTLabel)AddControl(new Guid("d370caa8-f7f5-4bcb-ae96-5e234e5e89ae"));
            FTRApplicationAreaDef = (ITTObjectListBox)AddControl(new Guid("52c22efa-9a64-4c21-a2d6-297162e5c8e8"));
            labelTreatmentDiagnosisUnit = (ITTLabel)AddControl(new Guid("b0d99094-4f89-45c8-a0df-6ede5c69a727"));
            TreatmentDiagnosisUnit = (ITTObjectListBox)AddControl(new Guid("dd097d10-23b7-4653-a94e-8ff3338db38c"));
            base.InitializeControls();
        }

        public PhysiotherapyPlannedOrdersForm() : base("PHYSIOTHERAPYORDER", "PhysiotherapyPlannedOrdersForm")
        {
        }

        protected PhysiotherapyPlannedOrdersForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}