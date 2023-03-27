
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
    public partial class MainStoreStockTransferCompletedForm : BaseMainStoreStockTransferForm
    {
    /// <summary>
    /// Ana Depolar Arası Transfer
    /// </summary>
        protected TTObjectClasses.MainStoreStockTransfer _MainStoreStockTransfer
        {
            get { return (TTObjectClasses.MainStoreStockTransfer)_ttObject; }
        }

        protected ITTTabPage DocumentRecordLog;
        protected ITTTabPage DocumentRecordLogTab;
        protected ITTGrid DocumentRecordLogs;
        protected ITTDateTimePickerColumn DocumentDateTimeDocumentRecordLog;
        protected ITTTextBoxColumn DocumentRecordLogNumberDocumentRecordLog;
        protected ITTEnumComboBoxColumn DocumentTransactionTypeDocumentRecordLog;
        protected ITTEnumComboBoxColumn BUDGETYPE;
        protected ITTTextBoxColumn NumberOfRowsDocumentRecordLog;
        protected ITTTextBoxColumn SubjectDocumentRecordLog;
        protected ITTTextBoxColumn TakenGivenPlaceDocumentRecordLog;
        protected ITTTextBoxColumn ReceiptNumber;
        protected ITTButton SendToMKYS;
        override protected void InitializeControls()
        {
            DocumentRecordLog = (ITTTabPage)AddControl(new Guid("61e3c731-7bf2-429e-aa27-0ece7ce236a6"));
            DocumentRecordLogTab = (ITTTabPage)AddControl(new Guid("aca6db5d-0ddb-4aa8-a9ab-a0195aa50b54"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("d622b156-3b84-4219-94e6-3c953517de28"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("4083cef6-d964-4962-8db8-5d1c44d900b1"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("38e1cc39-f2b6-4e03-8b9f-3981d3a5812a"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("678ae662-ac3f-417e-9bec-6a8ab4191e1a"));
            BUDGETYPE = (ITTEnumComboBoxColumn)AddControl(new Guid("d4b94eae-e7a3-4602-8e12-f7c2781b9df5"));
            NumberOfRowsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("5d88a060-1d36-450d-9f5c-b4fa1ac4b692"));
            SubjectDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("fd56627f-37b9-44a6-9765-2b5af8289fad"));
            TakenGivenPlaceDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("91c17099-7f72-4c6b-be85-794ac45faac2"));
            ReceiptNumber = (ITTTextBoxColumn)AddControl(new Guid("2d7b9c72-3bed-4a5e-82fc-0aafa13a2954"));
            SendToMKYS = (ITTButton)AddControl(new Guid("9f4d0059-c87f-489b-a390-c34f2e864b2b"));
            base.InitializeControls();
        }

        public MainStoreStockTransferCompletedForm() : base("MAINSTORESTOCKTRANSFER", "MainStoreStockTransferCompletedForm")
        {
        }

        protected MainStoreStockTransferCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}