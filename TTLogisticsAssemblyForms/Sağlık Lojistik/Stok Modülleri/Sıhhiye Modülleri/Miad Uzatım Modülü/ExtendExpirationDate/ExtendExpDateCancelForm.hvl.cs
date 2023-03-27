
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
    public partial class ExtendExpDateCancelForm : BaseExtendExpDateForm
    {
    /// <summary>
    /// Miad Güncelleme İşlemi
    /// </summary>
        protected TTObjectClasses.ExtendExpirationDate _ExtendExpirationDate
        {
            get { return (TTObjectClasses.ExtendExpirationDate)_ttObject; }
        }

        protected ITTTabPage DocumentRecordLogTab;
        protected ITTGrid DocumentRecordLogs;
        protected ITTDateTimePickerColumn DocumentDateTimeDocumentRecordLog;
        protected ITTTextBoxColumn DocumentRecordLogNumberDocumentRecordLog;
        protected ITTEnumComboBoxColumn DocumentTransactionTypeDocumentRecordLog;
        protected ITTEnumComboBoxColumn BUDGETYPE;
        protected ITTTextBoxColumn NumberOfRowsDocumentRecordLog;
        protected ITTTextBoxColumn SubjectDocumentRecordLog;
        protected ITTTextBoxColumn DescriptionsDocumentRecordLog;
        protected ITTTextBoxColumn ReceiptNumber;
        protected ITTButton SendToMKYS;
        override protected void InitializeControls()
        {
            DocumentRecordLogTab = (ITTTabPage)AddControl(new Guid("bc7af98c-41ea-4a37-b1fe-96c879dc7576"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("3372776b-4996-4809-91d6-501596ed764f"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("017c19f8-d9d1-41ed-b6e8-f3b7aa486300"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("667f5732-92e8-4dcf-8530-9a821a228e11"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("83bb1e84-ddc3-4056-858b-7615886f6ec4"));
            BUDGETYPE = (ITTEnumComboBoxColumn)AddControl(new Guid("222d3e9f-8d27-46da-a9b8-c46b39229033"));
            NumberOfRowsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("8bfeb772-6789-4a8c-801a-45ae2490e4f2"));
            SubjectDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("3e11d4dd-c967-44e9-be3e-c1d269d88dbb"));
            DescriptionsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("be835425-0d11-4553-97f6-8146d26a1836"));
            ReceiptNumber = (ITTTextBoxColumn)AddControl(new Guid("f73235ed-3ac1-401d-98ba-deaacba65906"));
            SendToMKYS = (ITTButton)AddControl(new Guid("9dc3bc4b-1305-4bb7-9bdb-3613365b0883"));
            base.InitializeControls();
        }

        public ExtendExpDateCancelForm() : base("EXTENDEXPIRATIONDATE", "ExtendExpDateCancelForm")
        {
        }

        protected ExtendExpDateCancelForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}