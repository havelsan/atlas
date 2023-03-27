
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
    public partial class StockMergeCompletedForm : BaseStockMergeForm
    {
        protected TTObjectClasses.StockMerge _StockMerge
        {
            get { return (TTObjectClasses.StockMerge)_ttObject; }
        }

        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTabPage DocumentRecordLogTabpage;
        protected ITTGrid DocumentRecordLogs;
        protected ITTTextBoxColumn DocumentRecordLogNumberDocumentRecordLog;
        protected ITTDateTimePickerColumn DocumentDateTimeDocumentRecordLog;
        protected ITTEnumComboBoxColumn DocumentTransactionTypeDocumentRecordLog;
        protected ITTTextBoxColumn SubjectDocumentRecordLog;
        protected ITTTextBoxColumn NumberOfRowsDocumentRecordLog;
        protected ITTTextBoxColumn TakenGivenPlaceDocumentRecordLog;
        protected ITTTextBoxColumn DescriptionsDocumentRecordLog;
        protected ITTTextBox RegistrationNumber;
        protected ITTTextBox SequenceNumber;
        protected ITTLabel labelRegistrationNumber;
        protected ITTLabel labelSequenceNumber;
        override protected void InitializeControls()
        {
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("8c14e8da-97af-44df-bd60-ae8a1e1cfe31"));
            DocumentRecordLogTabpage = (ITTTabPage)AddControl(new Guid("772a19f4-2ae1-448b-9f40-c3422f440a2d"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("488eb1bb-b872-4996-812e-2754cdae2e0b"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("3dc5ae13-d432-43d8-bff2-b7c401a1b381"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("7ede3cb0-f2a9-4fff-b430-948e9198b18c"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("b49a41a0-30c1-481a-aaf5-89d8039695f9"));
            SubjectDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("d9b963db-fcbe-40e0-8085-1f82d882c4d9"));
            NumberOfRowsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("a209cab4-6c99-46a4-8eef-89b1daff074e"));
            TakenGivenPlaceDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("f13a3c64-69b1-4824-9623-f474e639c865"));
            DescriptionsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("0937ca62-6ee7-4b89-a8d2-a7921739bed7"));
            RegistrationNumber = (ITTTextBox)AddControl(new Guid("ebaf22e8-3002-4fd7-b06f-8cb969508a28"));
            SequenceNumber = (ITTTextBox)AddControl(new Guid("373121e5-e729-4b03-9352-fb45fe7dc681"));
            labelRegistrationNumber = (ITTLabel)AddControl(new Guid("7c3c53f4-d30e-4ae7-87f0-7011c75f03e1"));
            labelSequenceNumber = (ITTLabel)AddControl(new Guid("3d2175cf-f773-44da-bdf0-5e2c7813cc50"));
            base.InitializeControls();
        }

        public StockMergeCompletedForm() : base("STOCKMERGE", "StockMergeCompletedForm")
        {
        }

        protected StockMergeCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}