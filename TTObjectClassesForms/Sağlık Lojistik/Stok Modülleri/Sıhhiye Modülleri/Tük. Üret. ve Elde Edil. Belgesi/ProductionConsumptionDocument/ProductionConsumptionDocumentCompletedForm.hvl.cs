
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
    public partial class ProductionConsumptionDocumentCompletedForm : BaseProductionConsumptionDocumentForm
    {
    /// <summary>
    /// Tüketim, Üretim ve Elde Edilenler Belgesi  için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.ProductionConsumptionDocument _ProductionConsumptionDocument
        {
            get { return (TTObjectClasses.ProductionConsumptionDocument)_ttObject; }
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
        protected ITTTextBox SequenceNumber;
        protected ITTTextBox RegistrationNumber;
        protected ITTLabel labelRegistrationNumber;
        protected ITTLabel labelSequenceNumber;
        override protected void InitializeControls()
        {
            DocumentRecordLogTabpage = (ITTTabPage)AddControl(new Guid("ada3f201-fe06-438c-a0e5-8076ecc3ba99"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("bbd0e1fc-c0f8-4df2-9d0f-6277562d14c3"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("c26d80eb-d621-4db7-8828-4f5f354cd58d"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("f9f27173-f659-4a98-b7bf-a7a2cee4a194"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("463d5849-ec53-4521-9dce-28fc391c108d"));
            SubjectDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("3ce77a89-cfe8-43cf-b151-c996b5c135de"));
            NumberOfRowsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("b4c17de3-1399-4cfc-ac67-31d4af645dc4"));
            TakenGivenPlaceDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("0e618046-bc1a-4c6e-959b-d7aa26cd1834"));
            DescriptionsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("7a836d81-e9c2-4137-b5f5-cd94382b96d3"));
            SequenceNumber = (ITTTextBox)AddControl(new Guid("c19f6f21-ff89-444f-8aa1-67ea802facd5"));
            RegistrationNumber = (ITTTextBox)AddControl(new Guid("8fa7908f-11bc-4806-825e-2252f4f1d246"));
            labelRegistrationNumber = (ITTLabel)AddControl(new Guid("097f5bf2-a0ea-4077-a386-052debe4345c"));
            labelSequenceNumber = (ITTLabel)AddControl(new Guid("6d81f0f8-31e1-4db9-9df5-d8111b669ba3"));
            base.InitializeControls();
        }

        public ProductionConsumptionDocumentCompletedForm() : base("PRODUCTIONCONSUMPTIONDOCUMENT", "ProductionConsumptionDocumentCompletedForm")
        {
        }

        protected ProductionConsumptionDocumentCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}