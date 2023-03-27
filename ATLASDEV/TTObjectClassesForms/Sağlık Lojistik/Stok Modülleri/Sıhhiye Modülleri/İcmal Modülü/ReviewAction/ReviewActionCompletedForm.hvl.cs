
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
    public partial class ReviewActionCompletedForm : BaseReviewActionForm
    {
    /// <summary>
    /// İcmal 
    /// </summary>
        protected TTObjectClasses.ReviewAction _ReviewAction
        {
            get { return (TTObjectClasses.ReviewAction)_ttObject; }
        }

        protected ITTTabPage DocumentRecordLogTab;
        protected ITTGrid DocumentRecordLogs;
        protected ITTTextBoxColumn DocumentRecordLogNumberDocumentRecordLog;
        protected ITTDateTimePickerColumn DocumentDateTimeDocumentRecordLog;
        protected ITTEnumComboBoxColumn DocumentTransactionTypeDocumentRecordLog;
        protected ITTTextBoxColumn ReceiptNumberDocumentRecordLog;
        protected ITTEnumComboBoxColumn BudgeTypeDocumentRecordLog;
        protected ITTTextBoxColumn DescriptionsDocumentRecordLog;
        protected ITTButton SendToMKYS;
        override protected void InitializeControls()
        {
            DocumentRecordLogTab = (ITTTabPage)AddControl(new Guid("aae4c89a-ae68-4dca-854d-a7e45ce9a338"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("d9bef098-230d-4fcc-a356-389df5816e22"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("d41e5799-0501-4437-a128-b0f0cc6eca22"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("b3ed391d-79be-4926-bc3c-dd1ddf887a9d"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("027bbcd0-4cf7-45cb-9f1a-ba6171e7e256"));
            ReceiptNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("3b70f6b5-8d3d-4857-bb82-f6412ee8ddff"));
            BudgeTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("e5c5082d-b990-47a6-bd2b-b3a826e1fc93"));
            DescriptionsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("3d4aa251-104b-45ad-ba73-97b8e3dfa018"));
            SendToMKYS = (ITTButton)AddControl(new Guid("62c061ef-c3d0-4057-a0fa-94ec4680feae"));
            base.InitializeControls();
        }

        public ReviewActionCompletedForm() : base("REVIEWACTION", "ReviewActionCompletedForm")
        {
        }

        protected ReviewActionCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}