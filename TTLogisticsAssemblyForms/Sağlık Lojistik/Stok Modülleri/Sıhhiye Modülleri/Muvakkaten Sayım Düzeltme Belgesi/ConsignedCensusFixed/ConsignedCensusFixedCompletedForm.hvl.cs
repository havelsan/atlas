
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
    public partial class ConsignedCensusFixedCompletedForm : BaseConsignedCensusFixed
    {
    /// <summary>
    /// Muvakkaten Sayım Düzeltme Belgesi  için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.ConsignedCensusFixed _ConsignedCensusFixed
        {
            get { return (TTObjectClasses.ConsignedCensusFixed)_ttObject; }
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
            DocumentRecordLogTabpage = (ITTTabPage)AddControl(new Guid("4bc08b90-a134-4b39-89ac-be00368fa6c0"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("3bc65a64-237a-4c46-a5f7-02b4afd91e84"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("fc88c438-75d8-4539-85eb-0015a12ba089"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("6464478f-49b3-4212-a6f8-61db63711237"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("47e072ec-6ffa-4f67-8e1d-fed1d30ded06"));
            SubjectDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("5c4725b9-5560-465a-868a-81036e3e7922"));
            NumberOfRowsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("8c0e4e75-8811-4d93-9b13-d12f7fcb3246"));
            TakenGivenPlaceDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("a8532997-f98a-4dbc-b7fa-7688b1a466b7"));
            DescriptionsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("41cebb7e-ba31-4f50-a9d2-75b5d1b51960"));
            base.InitializeControls();
        }

        public ConsignedCensusFixedCompletedForm() : base("CONSIGNEDCENSUSFIXED", "ConsignedCensusFixedCompletedForm")
        {
        }

        protected ConsignedCensusFixedCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}