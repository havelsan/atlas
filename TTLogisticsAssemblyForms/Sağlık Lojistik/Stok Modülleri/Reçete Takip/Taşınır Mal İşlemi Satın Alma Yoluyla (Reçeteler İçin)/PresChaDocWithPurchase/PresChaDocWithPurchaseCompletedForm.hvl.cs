
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
    public partial class PresChaDocWithPurchaseCompletedForm : BasePresChaDocWithPurchaseForm
    {
    /// <summary>
    /// Taşınır Mal İşlemi Satın Alma Yoluyla (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresChaDocWithPurchase _PresChaDocWithPurchase
        {
            get { return (TTObjectClasses.PresChaDocWithPurchase)_ttObject; }
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
            DocumentRecordLogTabpage = (ITTTabPage)AddControl(new Guid("18976028-3929-46e3-9f47-4200035db177"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("737ff955-0fab-45d5-a1f9-8809475e0198"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("dbf3dc5c-e43d-4081-9c91-d1a8c1a11989"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("1003bf77-eaf4-418e-89e5-1aa1eab10429"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("78621c67-2460-4136-b0fb-b3a7d151a6e8"));
            SubjectDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("65bca231-237d-4943-aea4-e4223a6d7a5f"));
            NumberOfRowsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("122266bf-b633-4505-aace-72929efe3047"));
            TakenGivenPlaceDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("40048d70-bea5-45c1-971d-5d8b9f0110bf"));
            DescriptionsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("0e6154c4-991b-41d4-af9c-763151954be2"));
            base.InitializeControls();
        }

        public PresChaDocWithPurchaseCompletedForm() : base("PRESCHADOCWITHPURCHASE", "PresChaDocWithPurchaseCompletedForm")
        {
        }

        protected PresChaDocWithPurchaseCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}