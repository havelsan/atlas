
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
    public partial class ReturningDocumentCompletedForm : BaseReturningDocumentForm
    {
    /// <summary>
    /// İade Belgesi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.ReturningDocument _ReturningDocument
        {
            get { return (TTObjectClasses.ReturningDocument)_ttObject; }
        }

        protected ITTTabPage tttabpage2;
        protected ITTTabPage DocumentRecordLogTab;
        protected ITTGrid DocumentRecordLogs;
        protected ITTDateTimePickerColumn DocumentDateTimeDocumentRecordLog;
        protected ITTTextBoxColumn DocumentRecordLogNumberDocumentRecordLog;
        protected ITTEnumComboBoxColumn DocumentTransactionTypeDocumentRecordLog;
        protected ITTEnumComboBoxColumn BudgeType;
        protected ITTTextBoxColumn SubjectDocumentRecordLog;
        protected ITTTextBoxColumn ReceiptNumber;
        protected ITTTextBoxColumn DescriptionsDocumentRecordLog;
        protected ITTTextBox SequenceNumber;
        protected ITTTextBox RegistrationNumber;
        protected ITTLabel labelRegistrationNumber;
        protected ITTLabel labelSequenceNumber;
        protected ITTButton SendToMKYS;
        override protected void InitializeControls()
        {
            tttabpage2 = (ITTTabPage)AddControl(new Guid("73e960d5-9c9e-4bb1-98de-bbd83086e01f"));
            DocumentRecordLogTab = (ITTTabPage)AddControl(new Guid("66ca389a-0300-4b70-8130-f6f98e7e00b5"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("3a153ed4-75ef-4f95-918c-e105ce7f50f9"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("e5c7daa3-2281-404b-b8fb-e4f390d363ed"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("3ab95024-2143-477a-ac09-4ea28536c1df"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("05f83bf0-bfea-4f9b-bd3f-44ba645fa3e9"));
            BudgeType = (ITTEnumComboBoxColumn)AddControl(new Guid("c537f92a-2e66-4f00-98c5-013b941db8e5"));
            SubjectDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("cf95529e-820b-45dc-99e1-d9b610782849"));
            ReceiptNumber = (ITTTextBoxColumn)AddControl(new Guid("ffe449e2-f024-42e4-aa9c-4f4a0050ee14"));
            DescriptionsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("c09deea5-7812-40eb-8d00-56e378bbb548"));
            SequenceNumber = (ITTTextBox)AddControl(new Guid("1d8331cb-2d4d-49aa-b870-f843525b6b78"));
            RegistrationNumber = (ITTTextBox)AddControl(new Guid("3053272e-c65f-4e0c-b744-3b3e7c533e66"));
            labelRegistrationNumber = (ITTLabel)AddControl(new Guid("3c867440-a211-4334-ad1a-6b4ba150fd69"));
            labelSequenceNumber = (ITTLabel)AddControl(new Guid("6223ce7f-89b9-4adc-a02c-41af2688401c"));
            SendToMKYS = (ITTButton)AddControl(new Guid("8ec01c8a-9273-463b-a138-19e6168021e0"));
            base.InitializeControls();
        }

        public ReturningDocumentCompletedForm() : base("RETURNINGDOCUMENT", "ReturningDocumentCompletedForm")
        {
        }

        protected ReturningDocumentCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}