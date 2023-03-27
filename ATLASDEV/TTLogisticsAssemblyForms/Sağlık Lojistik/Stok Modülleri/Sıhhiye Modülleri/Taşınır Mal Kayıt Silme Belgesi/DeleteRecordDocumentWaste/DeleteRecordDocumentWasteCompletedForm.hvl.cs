
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
    public partial class DeleteRecordDocumentWasteCompletedForm : BaseDeleteRecordDocumentWasteForm
    {
    /// <summary>
    /// Kayıt Silme Belgesi - Hek Edilen için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.DeleteRecordDocumentWaste _DeleteRecordDocumentWaste
        {
            get { return (TTObjectClasses.DeleteRecordDocumentWaste)_ttObject; }
        }

        protected ITTTabPage tttabpage2;
        protected ITTGrid DocumentRecordLogs;
        protected ITTDateTimePickerColumn DocumentDateTimeDocumentRecordLog;
        protected ITTTextBoxColumn DocumentRecordLogNumberDocumentRecordLog;
        protected ITTEnumComboBoxColumn DocumentTransactionTypeDocumentRecordLog;
        protected ITTTextBoxColumn DescriptionsDocumentRecordLog;
        protected ITTTextBox MKYS_AyniyatMakbuzID;
        protected ITTLabel labelMKYS_AyniyatMakbuzID;
        protected ITTButton SendToMKYS;
        override protected void InitializeControls()
        {
            tttabpage2 = (ITTTabPage)AddControl(new Guid("bcb49366-fab9-4f11-845a-a1055f8c7c6c"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("99ac33a1-ea6f-4d34-a72b-6fa5d88362e2"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("a77a71fd-9b1a-4d01-8ee5-7daa1c4c8f0b"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("ab545ca4-c447-4500-8033-9f36a457ddf7"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("e7ac8c0d-515f-43ac-a471-0bb7060e3ea3"));
            DescriptionsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("bea7cb58-5558-4653-9ea4-cdad9a9156ff"));
            MKYS_AyniyatMakbuzID = (ITTTextBox)AddControl(new Guid("d855523f-3463-4c1c-b997-0f5c53800f52"));
            labelMKYS_AyniyatMakbuzID = (ITTLabel)AddControl(new Guid("eb0be492-0f75-4ef4-9dd0-7028aef11b7e"));
            SendToMKYS = (ITTButton)AddControl(new Guid("83180824-270d-4530-af49-215d8ade12b6"));
            base.InitializeControls();
        }

        public DeleteRecordDocumentWasteCompletedForm() : base("DELETERECORDDOCUMENTWASTE", "DeleteRecordDocumentWasteCompletedForm")
        {
        }

        protected DeleteRecordDocumentWasteCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}