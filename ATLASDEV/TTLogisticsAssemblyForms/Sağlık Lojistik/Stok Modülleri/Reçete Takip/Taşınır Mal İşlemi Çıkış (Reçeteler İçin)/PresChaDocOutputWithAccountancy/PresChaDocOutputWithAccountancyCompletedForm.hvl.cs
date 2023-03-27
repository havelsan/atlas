
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
    /// Taşınır Mal İşlemi Çıkış (Reçeteler İçin)
    /// </summary>
    public partial class PresChaDocOutputWithAccountancyCompletedForm : BasePresChaDocOutputWithAccountancyForm
    {
    /// <summary>
    /// Taşınır Mal İşlemi Çıkış (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresChaDocOutputWithAccountancy _PresChaDocOutputWithAccountancy
        {
            get { return (TTObjectClasses.PresChaDocOutputWithAccountancy)_ttObject; }
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
            DocumentRecordLogTabpage = (ITTTabPage)AddControl(new Guid("6dcf9e0e-807b-4464-bd23-e815fff2fd2e"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("196b68ca-8a0d-445d-9b51-6129cd123426"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("1548b944-41c2-4ba2-bdcc-bbd73c561183"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("6ce57183-feb8-4a4d-9e31-fa9a22e98433"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("79a38adb-1146-45af-b464-a2187e3e63b0"));
            SubjectDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("253a9f41-eb58-4c0a-81dc-84d229e6c482"));
            NumberOfRowsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("3f6bf8f4-e928-4cb6-a693-0e8eb62a5796"));
            TakenGivenPlaceDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("e3a7f7ba-5eb3-47b6-83e0-91dc7afc36cf"));
            DescriptionsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("511539fd-369a-40f1-b2bd-f45a7dc099b1"));
            base.InitializeControls();
        }

        public PresChaDocOutputWithAccountancyCompletedForm() : base("PRESCHADOCOUTPUTWITHACCOUNTANCY", "PresChaDocOutputWithAccountancyCompletedForm")
        {
        }

        protected PresChaDocOutputWithAccountancyCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}