
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
    /// Belge Tarihi Güncelleme (Devir için)
    /// </summary>
    public partial class StockActionDateCorrectionCompForm : BaseDataCorrectionForm
    {
    /// <summary>
    /// Belge Tarihi Güncelleme (Devir için)
    /// </summary>
        protected TTObjectClasses.StockActionDateCorrection _StockActionDateCorrection
        {
            get { return (TTObjectClasses.StockActionDateCorrection)_ttObject; }
        }

        protected ITTTextBox UpdateLog;
        protected ITTTextBox OldStockCensusInheld;
        protected ITTTextBox OldStockCensusConsigned;
        protected ITTLabel labelUpdateLog;
        protected ITTLabel labelOldStockCensusInheld;
        protected ITTLabel labelOldStockCensusConsigned;
        protected ITTGrid DateCorrectionDetails;
        protected ITTCheckBoxColumn ChangeTransactionDateCorrectionDetail;
        protected ITTTextBoxColumn ChangeStockActionIDDateCorrectionDetail;
        protected ITTTextBoxColumn ChangeAction;
        protected ITTDateTimePickerColumn TransactionDate;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn ChangeInheldDateCorrectionDetail;
        protected ITTTextBoxColumn ChangeConsignedDateCorrectionDetail;
        protected ITTLabel labelMaterial;
        protected ITTObjectListBox Material;
        protected ITTLabel labelAccountingTerm;
        protected ITTObjectListBox AccountingTerm;
        protected ITTLabel labelMainStoreDefinition;
        protected ITTObjectListBox MainStoreDefinition;
        override protected void InitializeControls()
        {
            UpdateLog = (ITTTextBox)AddControl(new Guid("b559338e-9afc-4548-bc0d-86792d7ccf45"));
            OldStockCensusInheld = (ITTTextBox)AddControl(new Guid("95900b58-6236-42b5-8b5d-b383c09b0a86"));
            OldStockCensusConsigned = (ITTTextBox)AddControl(new Guid("b967dbc9-3ab5-4ee1-ae0d-6ab5eb636ff9"));
            labelUpdateLog = (ITTLabel)AddControl(new Guid("cb6ebf34-6be0-4d75-bf5a-271c938221db"));
            labelOldStockCensusInheld = (ITTLabel)AddControl(new Guid("79d05603-92eb-4d6d-954e-c27b0bb1051b"));
            labelOldStockCensusConsigned = (ITTLabel)AddControl(new Guid("49112fbf-85f8-49fa-acda-68a97be5de86"));
            DateCorrectionDetails = (ITTGrid)AddControl(new Guid("ff8bd35f-97a9-4519-881e-6373700e5409"));
            ChangeTransactionDateCorrectionDetail = (ITTCheckBoxColumn)AddControl(new Guid("125d7420-6571-4def-bf8b-8ff93991b70c"));
            ChangeStockActionIDDateCorrectionDetail = (ITTTextBoxColumn)AddControl(new Guid("229efcc5-80d1-4ba0-bd69-b41f8f8d5f9d"));
            ChangeAction = (ITTTextBoxColumn)AddControl(new Guid("df9f6da1-03b9-4c68-81ff-36ba402d2cc3"));
            TransactionDate = (ITTDateTimePickerColumn)AddControl(new Guid("c5684e40-428d-4584-9c50-4c2afa9ba1bb"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("31732daf-44a9-414e-8469-1400583ea32d"));
            ChangeInheldDateCorrectionDetail = (ITTTextBoxColumn)AddControl(new Guid("51442e5c-5b0f-49ff-b24b-74b4392bb803"));
            ChangeConsignedDateCorrectionDetail = (ITTTextBoxColumn)AddControl(new Guid("730f79c9-f9f6-4b25-8602-8a2f2647be08"));
            labelMaterial = (ITTLabel)AddControl(new Guid("8a87cda6-e21f-495e-8ba7-7544f16ad7d3"));
            Material = (ITTObjectListBox)AddControl(new Guid("d545cf88-92d5-4c26-8dbc-690ab9d8b2a6"));
            labelAccountingTerm = (ITTLabel)AddControl(new Guid("8d62faf2-2d77-4fc9-96d7-8297ebceb472"));
            AccountingTerm = (ITTObjectListBox)AddControl(new Guid("ec39929d-16e1-4380-94c3-643e5004b8be"));
            labelMainStoreDefinition = (ITTLabel)AddControl(new Guid("3caad03c-de05-467b-a620-f9743728394a"));
            MainStoreDefinition = (ITTObjectListBox)AddControl(new Guid("07ba20b5-bf3a-4e3a-ba0a-5079173265ea"));
            base.InitializeControls();
        }

        public StockActionDateCorrectionCompForm() : base("STOCKACTIONDATECORRECTION", "StockActionDateCorrectionCompForm")
        {
        }

        protected StockActionDateCorrectionCompForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}