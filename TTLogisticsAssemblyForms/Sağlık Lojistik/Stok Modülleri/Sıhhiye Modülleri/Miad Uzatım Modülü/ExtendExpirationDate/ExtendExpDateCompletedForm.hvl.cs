
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
    public partial class ExtendExpDateCompletedForm : BaseExtendExpDateForm
    {
    /// <summary>
    /// Miad Güncelleme İşlemi
    /// </summary>
        protected TTObjectClasses.ExtendExpirationDate _ExtendExpirationDate
        {
            get { return (TTObjectClasses.ExtendExpirationDate)_ttObject; }
        }

        protected ITTTabPage tttabpage1;
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
            tttabpage1 = (ITTTabPage)AddControl(new Guid("f6a93989-c472-48ac-9e32-79d1991c54fa"));
            DocumentRecordLogTab = (ITTTabPage)AddControl(new Guid("eddb73eb-2c6e-4a38-a796-bc1cf68bf189"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("648f04db-40f7-4331-9e96-12acee7b0ab2"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("134e3d42-e69b-40e6-ae29-9402a39c8e87"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("c6d7eb8d-f0ea-48cc-b621-a15f794fd821"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("52ef1e16-2fdb-4a7d-a7e0-915a7a93cdd7"));
            BUDGETYPE = (ITTEnumComboBoxColumn)AddControl(new Guid("328016a8-ec3d-44df-8887-9ac006b7b30d"));
            NumberOfRowsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("c191d932-9e9e-4f21-afcd-3c07888082d9"));
            SubjectDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("b885bdb5-761b-493d-a8af-ec6f2ddd6f2b"));
            DescriptionsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("2779ae10-0879-4872-bc5c-d0c0f3cd96d9"));
            ReceiptNumber = (ITTTextBoxColumn)AddControl(new Guid("ed38b4f9-644a-40e5-a007-dc524c97b45c"));
            SendToMKYS = (ITTButton)AddControl(new Guid("ca1aad76-4f5a-4d5e-819e-b232d2ec7f9a"));
            base.InitializeControls();
        }

        public ExtendExpDateCompletedForm() : base("EXTENDEXPIRATIONDATE", "ExtendExpDateCompletedForm")
        {
        }

        protected ExtendExpDateCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}