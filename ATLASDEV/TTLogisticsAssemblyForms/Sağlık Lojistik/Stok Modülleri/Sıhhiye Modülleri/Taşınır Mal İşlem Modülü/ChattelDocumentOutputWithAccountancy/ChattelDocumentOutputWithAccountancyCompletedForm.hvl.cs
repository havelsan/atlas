
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
    public partial class ChattelDocumentOutputWithAccountancyCompletedForm : BaseChattelDocumentOutputWithAccountancy
    {
    /// <summary>
    /// Taşınır Mal İşlemi Çıkış
    /// </summary>
        protected TTObjectClasses.ChattelDocumentOutputWithAccountancy _ChattelDocumentOutputWithAccountancy
        {
            get { return (TTObjectClasses.ChattelDocumentOutputWithAccountancy)_ttObject; }
        }

        protected ITTTabPage DocumentRecordLogTabpage;
        protected ITTTabPage DocumentRerocdLogTab;
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
        protected ITTButton cmdSendAgain;
        override protected void InitializeControls()
        {
            DocumentRecordLogTabpage = (ITTTabPage)AddControl(new Guid("193ecd67-14b0-4547-8349-44fe839550dc"));
            DocumentRerocdLogTab = (ITTTabPage)AddControl(new Guid("a0cb4385-51f5-44c5-8f6a-0f605a7271d6"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("928774e3-f87f-4720-a4dc-bf549ee64d4a"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("ab725a4b-94a0-4995-91c1-e19e9ee5b101"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("14674fce-84bf-4f7f-972a-93f400163f2e"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("ec83ffa2-3ef8-4b41-bd95-2e61bbd83486"));
            BudgeTypeEnum = (ITTEnumComboBoxColumn)AddControl(new Guid("80c684d1-6e7c-4480-ae43-41a864f7a331"));
            SubjectDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("7669635e-e4ed-4765-b0c8-95f0b9caaaea"));
            NumberOfRowsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("cee10b50-0485-47aa-8c74-3a309ef201b2"));
            TakenGivenPlaceDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("8ad01157-6398-4337-b588-25d8985a6fdf"));
            ReceiptNumber = (ITTTextBoxColumn)AddControl(new Guid("68f25e4d-27ed-46f0-b78f-cfceb7135efa"));
            DescriptionsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("6d4d23a7-473a-4698-8445-446c56eb94af"));
            SendToMKYS = (ITTButton)AddControl(new Guid("f5e0212f-28a8-464d-aaaf-8f4050dd0e44"));
            cmdSendAgain = (ITTButton)AddControl(new Guid("9715a9b5-21a7-4656-9916-5346269eab23"));
            base.InitializeControls();
        }

        public ChattelDocumentOutputWithAccountancyCompletedForm() : base("CHATTELDOCUMENTOUTPUTWITHACCOUNTANCY", "ChattelDocumentOutputWithAccountancyCompletedForm")
        {
        }

        protected ChattelDocumentOutputWithAccountancyCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}