
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
    public partial class StockActionDateCorrectionForm : BaseDataCorrectionForm
    {
    /// <summary>
    /// Belge Tarihi Güncelleme (Devir için)
    /// </summary>
        protected TTObjectClasses.StockActionDateCorrection _StockActionDateCorrection
        {
            get { return (TTObjectClasses.StockActionDateCorrection)_ttObject; }
        }

        protected ITTTextBox OldStockCensusInheld;
        protected ITTTextBox OldStockCensusConsigned;
        protected ITTButton cmdUpdate;
        protected ITTLabel labelChangeTransactionDate;
        protected ITTDateTimePicker ChangeTransactionDate;
        protected ITTLabel labelOldStockCensusInheld;
        protected ITTLabel labelOldStockCensusConsigned;
        protected ITTButton cmdList;
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
            OldStockCensusInheld = (ITTTextBox)AddControl(new Guid("8f85b70d-b727-435f-a58b-7321f0b94467"));
            OldStockCensusConsigned = (ITTTextBox)AddControl(new Guid("bccd7701-7c00-4e9a-9ca3-6945bfe32358"));
            cmdUpdate = (ITTButton)AddControl(new Guid("4d7a4c2e-d391-4501-bd81-05ab92e68678"));
            labelChangeTransactionDate = (ITTLabel)AddControl(new Guid("a55e84d8-b2ce-4830-b87e-9b23d664090a"));
            ChangeTransactionDate = (ITTDateTimePicker)AddControl(new Guid("dcd184f3-1a65-4f81-81db-059ce10e80ab"));
            labelOldStockCensusInheld = (ITTLabel)AddControl(new Guid("1df8786c-b416-460a-8b6b-df54cb44402b"));
            labelOldStockCensusConsigned = (ITTLabel)AddControl(new Guid("c565b1b2-f531-4eb8-9342-aad8a0d5a5a9"));
            cmdList = (ITTButton)AddControl(new Guid("6e331340-2359-4d3a-b9c4-21de1c08d37e"));
            DateCorrectionDetails = (ITTGrid)AddControl(new Guid("94cb6b1a-2e8d-46a5-a740-4d94b8ba1842"));
            ChangeTransactionDateCorrectionDetail = (ITTCheckBoxColumn)AddControl(new Guid("14895dc2-44dc-4ef1-96a9-2def7f063b93"));
            ChangeStockActionIDDateCorrectionDetail = (ITTTextBoxColumn)AddControl(new Guid("1a44f3f5-12f3-437d-854a-edd8353e7365"));
            ChangeAction = (ITTTextBoxColumn)AddControl(new Guid("bfb4b32f-9717-4b80-880a-cd9f88bd22c2"));
            TransactionDate = (ITTDateTimePickerColumn)AddControl(new Guid("38c7deab-bbfb-49c8-9e4e-551054103d73"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("e5c5eb99-65a0-4159-a857-11d23618d140"));
            ChangeInheldDateCorrectionDetail = (ITTTextBoxColumn)AddControl(new Guid("1740d97c-bd22-4575-8a3c-2ad23dd28855"));
            ChangeConsignedDateCorrectionDetail = (ITTTextBoxColumn)AddControl(new Guid("6dbf5a70-ce54-4470-bdf5-4db0e5510f37"));
            labelMaterial = (ITTLabel)AddControl(new Guid("c175c4f3-7887-4b58-a787-c278b04fe3df"));
            Material = (ITTObjectListBox)AddControl(new Guid("95dbe2d5-2439-4148-90e0-6a394f1358bd"));
            labelAccountingTerm = (ITTLabel)AddControl(new Guid("9f9b8d5c-c65e-46a9-8052-40121baf546a"));
            AccountingTerm = (ITTObjectListBox)AddControl(new Guid("f0954695-7743-43c7-bf06-9dc27aebd8cc"));
            labelMainStoreDefinition = (ITTLabel)AddControl(new Guid("4f9787c9-bcec-4540-887f-d7db43db319f"));
            MainStoreDefinition = (ITTObjectListBox)AddControl(new Guid("e8900791-3973-4264-98e5-f977040a264c"));
            base.InitializeControls();
        }

        public StockActionDateCorrectionForm() : base("STOCKACTIONDATECORRECTION", "StockActionDateCorrectionForm")
        {
        }

        protected StockActionDateCorrectionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}