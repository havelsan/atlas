
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
    /// Fizyoterapi Emirleri
    /// </summary>
    public partial class PhysiotherapyOrderRequestForm : TTForm
    {
    /// <summary>
    /// F.T.R. Emrinin Veridiği Nesnedir
    /// </summary>
        protected TTObjectClasses.PhysiotherapyOrder _PhysiotherapyOrder
        {
            get { return (TTObjectClasses.PhysiotherapyOrder)_ttObject; }
        }

        protected ITTLabel labelPhysiotherapyRequestDatePhysiotherapyRequest;
        protected ITTDateTimePicker PhysiotherapyRequestDatePhysiotherapyRequest;
        protected ITTLabel labelSessionCount;
        protected ITTTextBox SessionCount;
        protected ITTTextBox ApplicationArea;
        protected ITTTextBox Duration;
        protected ITTTextBox Dose;
        protected ITTTextBox TreatmentProperties;
        protected ITTLabel labelProcedureObject;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel labelTreatmentDiagnosisUnit;
        protected ITTObjectListBox TreatmentDiagnosisUnit;
        protected ITTLabel labelFTRApplicationAreaDef;
        protected ITTObjectListBox FTRApplicationAreaDef;
        protected ITTLabel labelApplicationArea;
        protected ITTLabel labelDose;
        protected ITTLabel labelDuration;
        protected ITTLabel labelTreatmentProperties;
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
        override protected void InitializeControls()
        {
            labelPhysiotherapyRequestDatePhysiotherapyRequest = (ITTLabel)AddControl(new Guid("61da2dce-6fb4-471f-826a-39f99074dc77"));
            PhysiotherapyRequestDatePhysiotherapyRequest = (ITTDateTimePicker)AddControl(new Guid("8a1e24f2-69d4-4fac-8250-679b43f7363e"));
            labelSessionCount = (ITTLabel)AddControl(new Guid("01bea5df-1caf-4f91-b47b-12a259dd8ce0"));
            SessionCount = (ITTTextBox)AddControl(new Guid("1e2c01a3-109a-4fbc-8bad-db03f902ae95"));
            ApplicationArea = (ITTTextBox)AddControl(new Guid("06363807-ba83-4199-8f6e-97fcc1fbb8dd"));
            Duration = (ITTTextBox)AddControl(new Guid("dbbbc9b2-1bd3-4b11-b5f3-b07530c0ee2a"));
            Dose = (ITTTextBox)AddControl(new Guid("4913638a-0cda-41c1-94b8-f4486024d62d"));
            TreatmentProperties = (ITTTextBox)AddControl(new Guid("5a8c1a2b-506f-4832-b381-c9a2daf72037"));
            labelProcedureObject = (ITTLabel)AddControl(new Guid("6e6bf470-2999-4b07-b965-66fec37336a7"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("2d78124c-2954-4993-a1af-eb2536cd1754"));
            labelTreatmentDiagnosisUnit = (ITTLabel)AddControl(new Guid("86111115-e851-49b7-933d-b4f698dcb6fe"));
            TreatmentDiagnosisUnit = (ITTObjectListBox)AddControl(new Guid("a6049229-2e0d-43e7-8332-74348d8e1488"));
            labelFTRApplicationAreaDef = (ITTLabel)AddControl(new Guid("a7d12069-28f9-4d62-8b58-1599f7a4854e"));
            FTRApplicationAreaDef = (ITTObjectListBox)AddControl(new Guid("64d2f6b6-a118-445d-82ac-ed52976f96b2"));
            labelApplicationArea = (ITTLabel)AddControl(new Guid("0bdcdea7-a62a-4411-a52b-6a4bc3fad7e7"));
            labelDose = (ITTLabel)AddControl(new Guid("513984df-eff3-4d46-9789-35e98a6074f7"));
            labelDuration = (ITTLabel)AddControl(new Guid("626f031b-c754-44de-83ba-2e23656c6f0a"));
            labelTreatmentProperties = (ITTLabel)AddControl(new Guid("f50ec22c-8e21-464b-a616-dc888e241354"));
            ttpanel1 = (ITTPanel)AddControl(new Guid("839a6124-2ddd-46d1-a7a7-76c4d840a09c"));
            labelReportNoPhysiotherapyReports = (ITTLabel)AddControl(new Guid("f325d144-ee4a-49dd-a334-c2a816c18819"));
            labelDiagnosisGroupPhysiotherapyReports = (ITTLabel)AddControl(new Guid("30e35310-69dc-48c2-b1db-6430f4c8414d"));
            TreatmentTypePhysiotherapyReports = (ITTEnumComboBox)AddControl(new Guid("50ebb73d-83a3-48d6-aecb-f08829a0bc6e"));
            labelTreatmentTypePhysiotherapyReports = (ITTLabel)AddControl(new Guid("70f0da50-6711-465b-a9fb-a4655a410116"));
            FTRApplicationAreaDefPhysiotherapyReports = (ITTObjectListBox)AddControl(new Guid("f56ec914-9455-4630-be65-a30d05175d82"));
            TreatmentProcessTypePhysiotherapyReports = (ITTTextBox)AddControl(new Guid("a9a15e29-f039-41b6-90b2-3add965e4d2c"));
            labelFTRApplicationAreaDefPhysiotherapyReports = (ITTLabel)AddControl(new Guid("e8e86168-3857-48fc-8d22-3db1e8dadf63"));
            PackageProcedureInfoPhysiotherapyReports = (ITTTextBox)AddControl(new Guid("345b7fa0-5448-4b68-b6f2-b22b25eb6d49"));
            labelReportInfoPhysiotherapyReports = (ITTLabel)AddControl(new Guid("4b07d99e-17a7-4afe-b641-c56d7ae0c609"));
            ReportTimePhysiotherapyReports = (ITTTextBox)AddControl(new Guid("4d33b47d-5eac-4815-a832-61e4b897823c"));
            ReportEndDatePhysiotherapyReports = (ITTDateTimePicker)AddControl(new Guid("e39e3691-090e-47a8-adec-41634a2bd3ee"));
            ReportNoPhysiotherapyReports = (ITTTextBox)AddControl(new Guid("b760aade-6c3d-47de-84b0-c29152516ce9"));
            labelReportEndDatePhysiotherapyReports = (ITTLabel)AddControl(new Guid("c4bfa6b1-0caf-40bb-81a3-4be07824c0d6"));
            ReportInfoPhysiotherapyReports = (ITTTextBox)AddControl(new Guid("44053374-b62d-4a55-ba1a-e11910b5f2f2"));
            ReportStartDatePhysiotherapyReports = (ITTDateTimePicker)AddControl(new Guid("e3c5f3bb-f91a-4099-9041-98d27b272a7f"));
            DiagnosisGroupPhysiotherapyReports = (ITTTextBox)AddControl(new Guid("cfeba1ac-b858-45f6-85f4-369f8543f8d1"));
            labelReportStartDatePhysiotherapyReports = (ITTLabel)AddControl(new Guid("8820e6f6-520d-4cff-99b9-3bb1fefe07e9"));
            labelReportTimePhysiotherapyReports = (ITTLabel)AddControl(new Guid("ea5f16c1-a89a-4373-8fb9-661a879a1b75"));
            ReportDatePhysiotherapyReports = (ITTDateTimePicker)AddControl(new Guid("5596c1bd-94bd-4f19-96d2-d6e8b647c3da"));
            labelReportDatePhysiotherapyReports = (ITTLabel)AddControl(new Guid("512d8c63-fc12-48a4-b130-73efc716781b"));
            ReportType = (ITTCheckBox)AddControl(new Guid("8a8981e3-8925-47ed-a391-f83a140e3ba9"));
            labelPackageProcedureInfoPhysiotherapyReports = (ITTLabel)AddControl(new Guid("009e7f46-633f-4586-a3ca-db1dfdf59d30"));
            labelTreatmentProcessTypePhysiotherapyReports = (ITTLabel)AddControl(new Guid("7f2c0106-0fab-4cd8-aeec-f666fdb818fb"));
            base.InitializeControls();
        }

        public PhysiotherapyOrderRequestForm() : base("PHYSIOTHERAPYORDER", "PhysiotherapyOrderRequestForm")
        {
        }

        protected PhysiotherapyOrderRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}