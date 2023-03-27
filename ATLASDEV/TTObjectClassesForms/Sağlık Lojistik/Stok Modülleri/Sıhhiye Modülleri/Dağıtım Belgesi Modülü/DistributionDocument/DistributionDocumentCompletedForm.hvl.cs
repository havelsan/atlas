
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
    public partial class DistributionDocumentCompletedForm : BaseDistributionDocumentForm
    {
    /// <summary>
    /// Dağıtım Belgesi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.DistributionDocument _DistributionDocument
        {
            get { return (TTObjectClasses.DistributionDocument)_ttObject; }
        }

        protected ITTTabPage DocumentrecordLogTab;
        protected ITTGrid DocumentRecordLogs;
        protected ITTDateTimePickerColumn DocumentDateTimeDocumentRecordLog;
        protected ITTTextBoxColumn DocumentRecordLogNumberDocumentRecordLog;
        protected ITTEnumComboBoxColumn DocumentTransactionTypeDocumentRecordLog;
        protected ITTTextBoxColumn NumberOfRowsDocumentRecordLog;
        protected ITTEnumComboBoxColumn BudgeTypeEnum;
        protected ITTTextBoxColumn SubjectDocumentRecordLog;
        protected ITTTextBoxColumn ReceiptNumber;
        protected ITTTextBoxColumn DescriptionsDocumentRecordLog;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox RegistrationNumber;
        protected ITTTextBox SequenceNumber;
        protected ITTCheckBox IsAutoDistribution;
        protected ITTButton ttMkysSend;
        protected ITTLabel labelSequenceNumber;
        protected ITTLabel labelRegistrationNumber;
        override protected void InitializeControls()
        {
            DocumentrecordLogTab = (ITTTabPage)AddControl(new Guid("fc773c30-3490-4d87-96a3-ce3a360841e9"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("7ea098e0-ef37-4d4d-b690-070c1fea50ac"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("083219a8-fe93-40d2-946c-3e21ff639e5f"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("4da9b044-561c-46f4-ae5a-952dca434556"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("fbe97fa9-eddc-4a47-aec0-a73966f3a1ab"));
            NumberOfRowsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("f5216cc7-efc9-4fac-98d5-0d7703b5d18c"));
            BudgeTypeEnum = (ITTEnumComboBoxColumn)AddControl(new Guid("1967b898-f3cf-4946-93ec-05d629c4c368"));
            SubjectDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("1783fb33-7219-410f-99f4-a80c9b9890eb"));
            ReceiptNumber = (ITTTextBoxColumn)AddControl(new Guid("ab4d8fe4-6381-46d0-af7b-f9830b5947bf"));
            DescriptionsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("a5d41baf-5118-4d08-980a-1fd4003cbe5f"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("b43eed61-e864-46f0-bf68-2185fbff741f"));
            RegistrationNumber = (ITTTextBox)AddControl(new Guid("ea4f39f9-d466-4c15-879a-3e192e09a556"));
            SequenceNumber = (ITTTextBox)AddControl(new Guid("dd62ac61-7f59-4d8d-bcb6-521ab68279ba"));
            IsAutoDistribution = (ITTCheckBox)AddControl(new Guid("19ff343f-5493-4fac-828e-3966d18cdc76"));
            ttMkysSend = (ITTButton)AddControl(new Guid("a04a9eb7-09bc-4678-8d13-1137303ff1c1"));
            labelSequenceNumber = (ITTLabel)AddControl(new Guid("68bf1688-8a38-42e8-8b67-13c7e976b9cc"));
            labelRegistrationNumber = (ITTLabel)AddControl(new Guid("334c3414-a17c-4421-a688-258b7bf62d43"));
            base.InitializeControls();
        }

        public DistributionDocumentCompletedForm() : base("DISTRIBUTIONDOCUMENT", "DistributionDocumentCompletedForm")
        {
        }

        protected DistributionDocumentCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}