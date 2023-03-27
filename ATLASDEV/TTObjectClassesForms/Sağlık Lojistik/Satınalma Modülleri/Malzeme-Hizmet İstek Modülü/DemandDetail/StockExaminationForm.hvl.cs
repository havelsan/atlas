
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
    /// Stok Detayları
    /// </summary>
    public partial class StockExaminationForm : TTForm
    {
    /// <summary>
    /// Malzeme/Hizmet İstek modülünde her istek kalemi için detayların ana sınıfıdır
    /// </summary>
        protected TTObjectClasses.DemandDetail _DemandDetail
        {
            get { return (TTObjectClasses.DemandDetail)_ttObject; }
        }

        protected ITTGrid MaterialsGrid;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn MaterialAmount;
        protected ITTTextBoxColumn TransferAmount;
        protected ITTGrid StoreStocksGrid;
        protected ITTListBoxColumn Store;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn TotalTransferAmount;
        protected ITTLabel labelPurchaseItemDef;
        protected ITTObjectListBox PurchaseItemDef;
        protected ITTLabel labelStoreStocks;
        protected ITTTextBox StoreStocks;
        protected ITTTextBox DetailDescription;
        protected ITTTextBox ClinicApprovedAmount;
        protected ITTLabel labelRequestAmount;
        protected ITTLabel labelDetailDescription;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            MaterialsGrid = (ITTGrid)AddControl(new Guid("e17ce735-c491-437a-86d9-22ad8baf45f0"));
            Material = (ITTListBoxColumn)AddControl(new Guid("6b17191e-e3a9-4d49-a442-7ff628360c3a"));
            MaterialAmount = (ITTTextBoxColumn)AddControl(new Guid("cd556e30-21f2-45f9-8fb0-b2f4015c3a86"));
            TransferAmount = (ITTTextBoxColumn)AddControl(new Guid("b8d9dce3-c652-45b0-819b-888d7885a4fc"));
            StoreStocksGrid = (ITTGrid)AddControl(new Guid("c7e6364c-9bbd-48cd-b9c5-68ca7c8f5d52"));
            Store = (ITTListBoxColumn)AddControl(new Guid("2927ff5a-57ac-49ac-aca1-39ba01d56c7a"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("d0a1a172-6119-4459-8890-351a21cf66d3"));
            TotalTransferAmount = (ITTTextBoxColumn)AddControl(new Guid("e8c65a9d-1950-41d4-8dd6-4168bc374a4c"));
            labelPurchaseItemDef = (ITTLabel)AddControl(new Guid("6650a33c-850f-4ceb-a0fd-af03d2cf0a51"));
            PurchaseItemDef = (ITTObjectListBox)AddControl(new Guid("4cd7f63a-d906-4ce8-b5b0-bb682abf00a8"));
            labelStoreStocks = (ITTLabel)AddControl(new Guid("d3cf6936-d623-4bef-bbd4-55eda89ac61c"));
            StoreStocks = (ITTTextBox)AddControl(new Guid("600e558a-3baf-4f3e-bf7b-20226c9186de"));
            DetailDescription = (ITTTextBox)AddControl(new Guid("f7c4f55c-a343-4dd9-9271-3debb4fcc182"));
            ClinicApprovedAmount = (ITTTextBox)AddControl(new Guid("e026a753-cd87-4760-81d5-cb88ea7929df"));
            labelRequestAmount = (ITTLabel)AddControl(new Guid("983b52ed-153f-4b01-b858-984137634885"));
            labelDetailDescription = (ITTLabel)AddControl(new Guid("8e405c79-4079-4e37-9f44-5fbfb5fb3dd6"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b91f6d29-b935-4b5e-a598-f828a9928225"));
            base.InitializeControls();
        }

        public StockExaminationForm() : base("DEMANDDETAIL", "StockExaminationForm")
        {
        }

        protected StockExaminationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}