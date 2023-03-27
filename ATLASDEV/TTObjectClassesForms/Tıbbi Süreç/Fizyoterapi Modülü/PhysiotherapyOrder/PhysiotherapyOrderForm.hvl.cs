
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
    public partial class PhysiotherapyOrderForm : BasePhysiotherapyOrderForm
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
        protected ITTButton btnContinue;
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
        protected ITTLabel LabelProtocolNo;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelTreatmentDiagnosisUnit;
        protected ITTObjectListBox TreatmentDiagnosisUnit;
        protected ITTRichTextBoxControl ReasonOfAbort;
        protected ITTLabel labelReasonOfAbort;
        protected ITTRichTextBoxControl AbortRequestDescription;
        protected ITTLabel labelAbortRequestDescription;
        protected ITTRichTextBoxControl DoctorReturnDescription;
        protected ITTLabel labelDoctorReturnDescription;
        protected ITTLabel labelPhysiotherapist;
        protected ITTObjectListBox Physiotherapist;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureDoctor;
        protected ITTRichTextBoxControl templateRTF;
        override protected void InitializeControls()
        {
            tttextbox6 = (ITTTextBox)AddControl(new Guid("886fab22-bb3e-49dd-8c6c-03cba67b9a34"));
            ApplicationArea = (ITTTextBox)AddControl(new Guid("65e22ee3-8031-401a-a1e9-590b4894e4a7"));
            Duration = (ITTTextBox)AddControl(new Guid("302c8699-059e-4436-be7a-65ab477ea867"));
            PhysiotherapistOrder = (ITTTextBox)AddControl(new Guid("b79b6614-2e30-4153-b6fd-abf026be36a3"));
            TreatmentProperties = (ITTTextBox)AddControl(new Guid("72003f96-eb92-456f-8591-ec4dcd404272"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("d30718b5-6aaf-4417-ad95-f24553c012d9"));
            btnContinue = (ITTButton)AddControl(new Guid("d7c375f9-f949-4255-a7b9-a1b468a82fce"));
            lblEpisodeDiagnosis = (ITTLabel)AddControl(new Guid("35d03d6d-2015-43df-9f68-bf2afaedade5"));
            labelPhysiotherapistOrder = (ITTLabel)AddControl(new Guid("d04165d0-b2f9-4462-98ec-a8fec2286ad4"));
            labelTreatmentProperties = (ITTLabel)AddControl(new Guid("c7284939-91af-4270-9aac-2a41f118d187"));
            labelApplicationArea = (ITTLabel)AddControl(new Guid("48b8316d-7c26-4333-9af0-520d3b1c786d"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("c72f94db-ac09-4a10-a2ce-57c22b16ed57"));
            labelDuration = (ITTLabel)AddControl(new Guid("6728fe77-d728-4a3c-a699-938d0519a981"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("5c8298f8-8e8d-435d-8e01-9618d427be6f"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("46299ab9-a742-4153-985f-e148ab245841"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("7eb31c69-2a33-48a4-9dfd-4da46c973182"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("b32426f5-c591-478c-8c47-7d8ba7b6533f"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("ab703bc1-58bc-40bb-ac9d-3eff52695c07"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("4dec4794-d2f8-427f-b4b3-b2676cbaa3c7"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("ded7aced-7e3a-4743-bf72-5771be586a93"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("92c85ddb-a299-4301-aacc-674104e57bd9"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("6557b50d-435d-408e-9c51-ecc17c1918ce"));
            labelProcedureObject = (ITTLabel)AddControl(new Guid("da7f8732-6ab3-4f65-a8c8-eed5d1d12d6c"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("c20e0ed5-c7a6-4c71-a553-c3a7d2cb1631"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("68e594f1-571b-4c62-94f2-7f7a433f3b28"));
            LabelProtocolNo = (ITTLabel)AddControl(new Guid("da7a5a1d-015a-486b-89be-12abf1bbf4db"));
            labelActionDate = (ITTLabel)AddControl(new Guid("a6614b7c-8d06-4325-8151-04b46a56a02c"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("ddf77ccf-2fb0-4d99-a790-bf910bfdd96c"));
            labelTreatmentDiagnosisUnit = (ITTLabel)AddControl(new Guid("b812d974-37d0-4e8d-8c22-68a856b77081"));
            TreatmentDiagnosisUnit = (ITTObjectListBox)AddControl(new Guid("15cb6b7c-281e-471e-92f5-dbf49d5ea94a"));
            ReasonOfAbort = (ITTRichTextBoxControl)AddControl(new Guid("a47c33dd-11c3-46a3-8903-c640555e3bf2"));
            labelReasonOfAbort = (ITTLabel)AddControl(new Guid("e51e9bfb-10ef-4715-935e-298749f64830"));
            AbortRequestDescription = (ITTRichTextBoxControl)AddControl(new Guid("ddb12ffd-63d0-458a-9d6d-5da62505754a"));
            labelAbortRequestDescription = (ITTLabel)AddControl(new Guid("4e7edd68-db77-4c05-8be3-158b0017dac3"));
            DoctorReturnDescription = (ITTRichTextBoxControl)AddControl(new Guid("144e693c-063c-439f-b80e-d07238ff29c5"));
            labelDoctorReturnDescription = (ITTLabel)AddControl(new Guid("04204509-5711-4363-a3eb-ff4ff5b6320e"));
            labelPhysiotherapist = (ITTLabel)AddControl(new Guid("29aa7fdd-286f-4008-8397-f3846c57fa04"));
            Physiotherapist = (ITTObjectListBox)AddControl(new Guid("d36c2b92-a6fd-4090-8ef1-64b93a17ebc4"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("ca6e9fde-ca76-4af1-bccd-8b7915e03cc5"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("3a8b604b-1b19-490b-b516-47035fa701d6"));
            templateRTF = (ITTRichTextBoxControl)AddControl(new Guid("c41d850a-620f-44a9-8767-07041cc12bf2"));
            base.InitializeControls();
        }

        public PhysiotherapyOrderForm() : base("PHYSIOTHERAPYORDER", "PhysiotherapyOrderForm")
        {
        }

        protected PhysiotherapyOrderForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}