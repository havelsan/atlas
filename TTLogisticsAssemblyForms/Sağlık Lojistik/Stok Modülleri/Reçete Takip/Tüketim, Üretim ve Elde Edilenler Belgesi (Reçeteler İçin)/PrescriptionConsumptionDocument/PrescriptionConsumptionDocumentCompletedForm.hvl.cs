
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
    /// Tüketim, Üretim ve Elde Edilenler Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class PrescriptionConsumptionDocumentCompletedForm : BasePrescriptionConsumptionDocumentForm
    {
    /// <summary>
    /// Tüketim, Üretim ve Elde Edilenler Belgesi (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PrescriptionConsumptionDocument _PrescriptionConsumptionDocument
        {
            get { return (TTObjectClasses.PrescriptionConsumptionDocument)_ttObject; }
        }

        protected ITTTabPage DocumentRecordLogTabpage;
        protected ITTGrid DocumentRecordLogs;
        protected ITTTextBoxColumn DocumentRecordLogNumberDocumentRecordLog;
        protected ITTDateTimePickerColumn DocumentDateTimeDocumentRecordLog;
        protected ITTEnumComboBoxColumn DocumentTransactionTypeDocumentRecordLog;
        protected ITTTextBoxColumn SubjectDocumentRecordLog;
        protected ITTTextBoxColumn NumberOfRowsDocumentRecordLog;
        protected ITTTextBoxColumn TakenGivenPlaceDocumentRecordLog;
        protected ITTTextBoxColumn DescriptionsDocumentRecordLog;
        protected ITTTextBox SequenceNumber;
        protected ITTTextBox RegistrationNumber;
        protected ITTLabel labelRegistrationNumber;
        protected ITTLabel labelSequenceNumber;
        override protected void InitializeControls()
        {
            DocumentRecordLogTabpage = (ITTTabPage)AddControl(new Guid("8bebaf68-3f47-4486-8a29-dadf1f5c8035"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("a580e861-cefe-4e91-8c8d-e416318ee2ba"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("aceb9ddf-fe9d-4264-8295-a65743d654e0"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("3f749066-bd87-4665-a973-99d0c4386658"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("963cd4c3-f234-4ea9-8c08-5273626a364a"));
            SubjectDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("646153ab-b9c9-492c-b50e-5b9fe7560611"));
            NumberOfRowsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("6b45006e-a6ee-4556-9902-6e890509ad34"));
            TakenGivenPlaceDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("aa4b44d5-c187-4242-91de-662d8528b5ed"));
            DescriptionsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("ba182508-586d-4a33-8d22-d0991fc32208"));
            SequenceNumber = (ITTTextBox)AddControl(new Guid("c2337e92-63ce-48ae-bb17-31bc774f7947"));
            RegistrationNumber = (ITTTextBox)AddControl(new Guid("9f0d66b2-4684-42a4-bfa7-3050f362c3e3"));
            labelRegistrationNumber = (ITTLabel)AddControl(new Guid("c7be8977-8d3a-4387-899a-82db08d1bd26"));
            labelSequenceNumber = (ITTLabel)AddControl(new Guid("f41f48c0-4cc5-4522-854c-b6ff65f854fb"));
            base.InitializeControls();
        }

        public PrescriptionConsumptionDocumentCompletedForm() : base("PRESCRIPTIONCONSUMPTIONDOCUMENT", "PrescriptionConsumptionDocumentCompletedForm")
        {
        }

        protected PrescriptionConsumptionDocumentCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}