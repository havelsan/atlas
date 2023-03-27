
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
    public partial class DeleteRecordDocumentDestroyableCompletedForm : BaseDeleteRecordDocumentDestroyableForm
    {
    /// <summary>
    /// Kayıt Silme Belgesi - Yok Edilen için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.DeleteRecordDocumentDestroyable _DeleteRecordDocumentDestroyable
        {
            get { return (TTObjectClasses.DeleteRecordDocumentDestroyable)_ttObject; }
        }

        protected ITTTabPage DocumentRecordLogTab;
        protected ITTGrid DocumentRecordLogs;
        protected ITTTextBoxColumn DocumentRecordLogNumberDocumentRecordLog;
        protected ITTDateTimePickerColumn DocumentDateTimeDocumentRecordLog;
        protected ITTEnumComboBoxColumn DocumentTransactionTypeDocumentRecordLog;
        protected ITTTextBoxColumn SubjectDocumentRecordLog;
        protected ITTTextBoxColumn TakenGivenPlaceDocumentRecordLog;
        protected ITTTextBoxColumn DucumentRecordLogReceiptNO;
        protected ITTTextBoxColumn DescriptionsDocumentRecordLog;
        protected ITTButton SendToMKYS;
        override protected void InitializeControls()
        {
            DocumentRecordLogTab = (ITTTabPage)AddControl(new Guid("22934fb5-433c-44fc-9cb1-018a4fe98f01"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("e3c8cb6e-ea90-4900-853d-1cee2bd67029"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("823177d8-0445-4c92-b72b-f9414aaf265d"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("41a28c31-2690-4584-82a2-78ca83f58398"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("1e360001-3527-4328-b75a-256487a73bac"));
            SubjectDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("b94f7c2f-8478-4e07-bf14-01158586846c"));
            TakenGivenPlaceDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("5d580f9b-cf6f-40a6-9d25-56220a3f613a"));
            DucumentRecordLogReceiptNO = (ITTTextBoxColumn)AddControl(new Guid("d3c9c342-225b-4a86-8ee8-95088c193c25"));
            DescriptionsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("22437a2f-c1b9-46d0-a8ab-41652723d5e7"));
            SendToMKYS = (ITTButton)AddControl(new Guid("a29699d3-1f72-4b7a-8fb0-df39627896ea"));
            base.InitializeControls();
        }

        public DeleteRecordDocumentDestroyableCompletedForm() : base("DELETERECORDDOCUMENTDESTROYABLE", "DeleteRecordDocumentDestroyableCompletedForm")
        {
        }

        protected DeleteRecordDocumentDestroyableCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}