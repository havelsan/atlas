
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
    /// Taşınır Mal İşlemi Giriş (Reçeteler İçin)
    /// </summary>
    public partial class PresChaDocInputWithAccountancyCompletedForm : BasePresChaDocInputWithAccountancyForm
    {
    /// <summary>
    /// Taşınır Mal İşlemi Giriş (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresChaDocInputWithAccountancy _PresChaDocInputWithAccountancy
        {
            get { return (TTObjectClasses.PresChaDocInputWithAccountancy)_ttObject; }
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
        override protected void InitializeControls()
        {
            DocumentRecordLogTabpage = (ITTTabPage)AddControl(new Guid("fa71f13e-487f-4c48-8581-509304d51882"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("6ebb9135-c5e5-4850-a1c8-e2a5b200a900"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("7d6f1f35-a4e8-4966-8190-ccfc67c2036a"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("9941f43a-124f-43ff-9f00-c94d02db1b63"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("af30981b-02c3-4b13-a78e-5121f9eebecd"));
            SubjectDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("fb52b985-4a2e-42c5-bb4d-7f09b028d509"));
            NumberOfRowsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("1b021d74-9c0c-4215-be99-abd88e1dd193"));
            TakenGivenPlaceDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("def819ef-520b-4ae6-a984-80361a9cf960"));
            DescriptionsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("fbdd1544-21f5-45d4-82a5-d60700ba5635"));
            base.InitializeControls();
        }

        public PresChaDocInputWithAccountancyCompletedForm() : base("PRESCHADOCINPUTWITHACCOUNTANCY", "PresChaDocInputWithAccountancyCompletedForm")
        {
        }

        protected PresChaDocInputWithAccountancyCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}