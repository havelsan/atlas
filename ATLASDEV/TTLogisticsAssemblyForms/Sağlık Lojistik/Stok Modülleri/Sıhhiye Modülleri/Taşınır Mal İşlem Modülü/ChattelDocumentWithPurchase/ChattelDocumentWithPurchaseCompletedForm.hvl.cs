
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
    public partial class ChattelDocumentWithPurchaseCompletedForm : BaseChattelDocumentWithPurchaseForm
    {
    /// <summary>
    /// Satınalma Yoluyla
    /// </summary>
        protected TTObjectClasses.ChattelDocumentWithPurchase _ChattelDocumentWithPurchase
        {
            get { return (TTObjectClasses.ChattelDocumentWithPurchase)_ttObject; }
        }

        protected ITTTabPage DocumentRecordLogTab;
        protected ITTGrid DocumentRecordLogs;
        protected ITTTextBoxColumn DocumentRecordLogNumberDocumentRecordLog;
        protected ITTDateTimePickerColumn DocumentDateTimeDocumentRecordLog;
        protected ITTEnumComboBoxColumn DocumentTransactionTypeDocumentRecordLog;
        protected ITTEnumComboBoxColumn BudgeTypeEnum;
        protected ITTTextBoxColumn SubjectDocumentRecordLog;
        protected ITTTextBoxColumn NumberOfRowsDocumentRecordLog;
        protected ITTTextBoxColumn TakenGivenPlaceDocumentRecordLog;
        protected ITTTextBoxColumn ReceiptNumber;
        protected ITTTextBoxColumn DescriptionsDocumentRecordLog;
        protected ITTButton SendToMKYS;
        override protected void InitializeControls()
        {
            DocumentRecordLogTab = (ITTTabPage)AddControl(new Guid("8fd13e0f-86c5-49b0-922d-d9ef6d5e5a16"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("c52c3f07-c50b-422c-87e3-2df79e9b60b7"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("cdedde39-c355-4e69-b7e8-567ea03d1653"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("e63895b8-2066-4a31-bd57-27b9c22f1399"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("821d1ff2-a4fd-4d55-8dd7-a5ef8aeb6cd7"));
            BudgeTypeEnum = (ITTEnumComboBoxColumn)AddControl(new Guid("011288f5-9bdd-4312-8fba-5b3641782739"));
            SubjectDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("9d28c694-31ef-4128-887c-5cb4d5f1637f"));
            NumberOfRowsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("1958b686-eb2f-426e-901c-4beb56925130"));
            TakenGivenPlaceDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("f88a9308-ac75-4c16-aa18-d29ddcd782ec"));
            ReceiptNumber = (ITTTextBoxColumn)AddControl(new Guid("f228b9b5-a691-4e8f-a981-81a6f87c7f35"));
            DescriptionsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("9b3b1303-4262-4469-a6f9-62b7a5de805c"));
            SendToMKYS = (ITTButton)AddControl(new Guid("b7699952-ee46-404b-9197-6b69b8928610"));
            base.InitializeControls();
        }

        public ChattelDocumentWithPurchaseCompletedForm() : base("CHATTELDOCUMENTWITHPURCHASE", "ChattelDocumentWithPurchaseCompletedForm")
        {
        }

        protected ChattelDocumentWithPurchaseCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}