
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
    public partial class ChattelDocumentInputWithAccountancyCompletedForm : BaseChattelDocumentInputWithAccountancyForm
    {
        protected TTObjectClasses.ChattelDocumentInputWithAccountancy _ChattelDocumentInputWithAccountancy
        {
            get { return (TTObjectClasses.ChattelDocumentInputWithAccountancy)_ttObject; }
        }

        protected ITTTabPage DocumentRecordLogTabpage;
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
            DocumentRecordLogTabpage = (ITTTabPage)AddControl(new Guid("89c68834-aeee-40e3-a46f-20130a5e9d87"));
            DocumentRecordLogTab = (ITTTabPage)AddControl(new Guid("ee488f5c-a0f5-46b4-8860-be9cfeba2d6c"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("9f170930-8c34-449d-82a3-a5542749b4e9"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("0de775ea-fbd6-4139-87dc-d103c0c43c12"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("505196d7-e5eb-44c7-a3d5-40cbab223490"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("eb49174a-54d3-4fc9-b802-5393311afe82"));
            BudgeTypeEnum = (ITTEnumComboBoxColumn)AddControl(new Guid("7793592d-3e0a-41b5-b749-4af26d597d32"));
            SubjectDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("828937a9-6b63-44ab-a741-3b83350fdc9c"));
            NumberOfRowsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("41303eb2-dc18-4054-96d2-85f6bf9fbd07"));
            TakenGivenPlaceDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("4687fb48-ee57-4f81-8f6d-f640241c202e"));
            ReceiptNumber = (ITTTextBoxColumn)AddControl(new Guid("9ba9f3ec-e68d-4c36-aa34-a2bb97020782"));
            DescriptionsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("dcf68904-6f44-4756-ac31-d6b9f420194e"));
            SendToMKYS = (ITTButton)AddControl(new Guid("d82e2b19-5134-4cf3-8a26-ec38e9d4b498"));
            base.InitializeControls();
        }

        public ChattelDocumentInputWithAccountancyCompletedForm() : base("CHATTELDOCUMENTINPUTWITHACCOUNTANCY", "ChattelDocumentInputWithAccountancyCompletedForm")
        {
        }

        protected ChattelDocumentInputWithAccountancyCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}