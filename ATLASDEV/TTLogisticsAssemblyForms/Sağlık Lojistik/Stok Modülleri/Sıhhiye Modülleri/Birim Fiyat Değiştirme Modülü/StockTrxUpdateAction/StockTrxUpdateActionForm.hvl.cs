
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
    /// Birim Fiyat Değiştirme
    /// </summary>
    public partial class StockTrxUpdateActionForm : TTForm
    {
    /// <summary>
    /// Birim Fiyat Değiştirme
    /// </summary>
        protected TTObjectClasses.StockTrxUpdateAction _StockTrxUpdateAction
        {
            get { return (TTObjectClasses.StockTrxUpdateAction)_ttObject; }
        }

        protected ITTButton cmdUpdatePrice;
        protected ITTLabel labelNewUnitPrice;
        protected ITTTextBox NewUnitPrice;
        protected ITTTextBox ID;
        protected ITTButton cmdGetInTrx;
        protected ITTLabel labelStockCard;
        protected ITTObjectListBox StockCard;
        protected ITTLabel labelMainStoreDefinition;
        protected ITTObjectListBox MainStoreDefinition;
        protected ITTGrid StockTrxUpdateActionDetails;
        protected ITTDateTimePickerColumn StockTrxDate;
        protected ITTTextBoxColumn MaterialName;
        protected ITTTextBoxColumn StockActionDescription;
        protected ITTTextBoxColumn OldUnitPriceStockTrxUpdateActionDetail;
        protected ITTTextBoxColumn NewUnitPriceStockTrxUpdateActionDetail;
        protected ITTLabel labelID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            cmdUpdatePrice = (ITTButton)AddControl(new Guid("29bb50d7-2777-4495-8579-eedff950c8e6"));
            labelNewUnitPrice = (ITTLabel)AddControl(new Guid("6793c09e-2516-4ecf-8ac4-d2b6d60c9b63"));
            NewUnitPrice = (ITTTextBox)AddControl(new Guid("f4926210-2d09-4ae5-977c-4f4a56490cda"));
            ID = (ITTTextBox)AddControl(new Guid("2f1128c2-8cf0-4473-9a58-162c3fbf8a19"));
            cmdGetInTrx = (ITTButton)AddControl(new Guid("fc7c5347-bfba-485e-846b-4372d2951e35"));
            labelStockCard = (ITTLabel)AddControl(new Guid("81b9c908-4070-439c-a284-fdb381e6a71c"));
            StockCard = (ITTObjectListBox)AddControl(new Guid("8e8dfb33-ed9c-4a25-9981-e1fba6f4e9ba"));
            labelMainStoreDefinition = (ITTLabel)AddControl(new Guid("11ef96a8-b99f-4f53-aa7e-32145cbe9d98"));
            MainStoreDefinition = (ITTObjectListBox)AddControl(new Guid("abfbecc2-5416-442e-ad29-db577bf6664c"));
            StockTrxUpdateActionDetails = (ITTGrid)AddControl(new Guid("530e12c3-704b-4641-bad0-c3952321f724"));
            StockTrxDate = (ITTDateTimePickerColumn)AddControl(new Guid("8d4a5255-4085-4b43-988c-2987b268ff5e"));
            MaterialName = (ITTTextBoxColumn)AddControl(new Guid("c13e2f38-a681-491d-82b0-2ef2aa58971a"));
            StockActionDescription = (ITTTextBoxColumn)AddControl(new Guid("59656060-5efe-4620-8b4a-5b5bc9a1386e"));
            OldUnitPriceStockTrxUpdateActionDetail = (ITTTextBoxColumn)AddControl(new Guid("cfade851-bf39-4367-868a-c073051b4b27"));
            NewUnitPriceStockTrxUpdateActionDetail = (ITTTextBoxColumn)AddControl(new Guid("8ebd2da5-7a38-41ec-9890-fd5d66c4929f"));
            labelID = (ITTLabel)AddControl(new Guid("2096444a-fed3-4707-b2fe-71ba81879082"));
            labelActionDate = (ITTLabel)AddControl(new Guid("730f5be5-f0b1-4f78-93bc-7bd0dfabe09c"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("1307c132-ebf2-47b2-a44a-2b7ef0a9fa7d"));
            base.InitializeControls();
        }

        public StockTrxUpdateActionForm() : base("STOCKTRXUPDATEACTION", "StockTrxUpdateActionForm")
        {
        }

        protected StockTrxUpdateActionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}