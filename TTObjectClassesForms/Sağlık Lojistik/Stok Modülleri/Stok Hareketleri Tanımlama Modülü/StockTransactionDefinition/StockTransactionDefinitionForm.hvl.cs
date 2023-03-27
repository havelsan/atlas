
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
    /// Stok Hareket Tipi Tanımı
    /// </summary>
    public partial class StockTransactionDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Stok Hareket Tipi Tanımı
    /// </summary>
        protected TTObjectClasses.StockTransactionDefinition _StockTransactionDefinition
        {
            get { return (TTObjectClasses.StockTransactionDefinition)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTCheckBox IsMinMaxLevelCalc;
        protected ITTLabel labelDescription;
        protected ITTCheckBox IsTotalReport;
        protected ITTLabel labelDestinationMaintainLevelCode;
        protected ITTListDefComboBox ChangedStockLevelType;
        protected ITTLabel labelEndDateTimeFormat;
        protected ITTLabel labelShortDescription;
        protected ITTLabel labelStartDateTimeFormat;
        protected ITTEnumComboBox DestinationMaintainLevelCode;
        protected ITTLabel labelChangedStockLevelType;
        protected ITTTextBox RegistrationPrefix;
        protected ITTCheckBox IsStockDown;
        protected ITTLabel labelMaintainLevelCode;
        protected ITTCheckBox IsFixedAsset;
        protected ITTCheckBox AskForDateTime;
        protected ITTLabel labelTransactionType;
        protected ITTEnumComboBox MaintainLevelCode;
        protected ITTEnumComboBox ReferenceLetter;
        protected ITTTextBox StartDateTimeFormat;
        protected ITTLabel labelReferenceLetter;
        protected ITTTextBox ShortDescription;
        protected ITTTextBox EndDateTimeFormat;
        protected ITTTextBox Description;
        protected ITTEnumComboBox TransactionType;
        protected ITTLabel labelRegistrationPrefix;
        protected ITTTabPage tttabpage2;
        protected ITTCheckBox IsTotalStockInReport;
        protected ITTCheckBox IsTotalStockOutReport;
        protected ITTCheckBox IsMovableTrxOutVoucher;
        protected ITTCheckBox IsConsumedMaterialReport;
        protected ITTGroupBox ttgroupbox2;
        protected ITTListView DocumentListView;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("5aa61ea0-516f-42ce-99a0-459acd823930"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("632d22af-d0ee-464d-8a3a-3e53cf81d041"));
            IsMinMaxLevelCalc = (ITTCheckBox)AddControl(new Guid("83ba1105-054d-4e59-863d-dfb133b58f9c"));
            labelDescription = (ITTLabel)AddControl(new Guid("4c7c1302-de49-481f-886a-d6d6e6d67442"));
            IsTotalReport = (ITTCheckBox)AddControl(new Guid("2db3bca4-42e7-4e5c-a186-f5ff19493cfd"));
            labelDestinationMaintainLevelCode = (ITTLabel)AddControl(new Guid("660cda7b-0765-4563-b701-99de77ed9d5e"));
            ChangedStockLevelType = (ITTListDefComboBox)AddControl(new Guid("4ecff1e5-4c96-42cb-acb5-1e2e9accdd5f"));
            labelEndDateTimeFormat = (ITTLabel)AddControl(new Guid("e62644bd-f58f-4430-9c12-ad6b339639e1"));
            labelShortDescription = (ITTLabel)AddControl(new Guid("aa432bd5-6d7b-4163-a6b0-9989d83ae556"));
            labelStartDateTimeFormat = (ITTLabel)AddControl(new Guid("13a64df7-a490-414f-9f63-045f39fb5448"));
            DestinationMaintainLevelCode = (ITTEnumComboBox)AddControl(new Guid("6459dc08-49a6-44bc-9685-b55e83e4106b"));
            labelChangedStockLevelType = (ITTLabel)AddControl(new Guid("98905f26-b596-4761-84ae-e411cbc481ed"));
            RegistrationPrefix = (ITTTextBox)AddControl(new Guid("70cc07df-ea88-44c9-b74a-82a96d0fb10f"));
            IsStockDown = (ITTCheckBox)AddControl(new Guid("03c0d888-9d80-4988-9326-0488e60109fc"));
            labelMaintainLevelCode = (ITTLabel)AddControl(new Guid("b478cba9-7ba7-4e6d-bc81-cd09950f5673"));
            IsFixedAsset = (ITTCheckBox)AddControl(new Guid("91c6860a-8a63-4a60-9af0-b7134b352277"));
            AskForDateTime = (ITTCheckBox)AddControl(new Guid("2e3a94d7-840b-4cb8-bca7-6c50bc9add90"));
            labelTransactionType = (ITTLabel)AddControl(new Guid("68a4189e-8982-49ad-af5a-f1359b66da5d"));
            MaintainLevelCode = (ITTEnumComboBox)AddControl(new Guid("97142bc5-0609-4388-852f-cecffe2b1dbc"));
            ReferenceLetter = (ITTEnumComboBox)AddControl(new Guid("16403ab6-b163-476e-9f79-2bd33ec89fcc"));
            StartDateTimeFormat = (ITTTextBox)AddControl(new Guid("62662233-07f4-460e-a407-d06defdc88e1"));
            labelReferenceLetter = (ITTLabel)AddControl(new Guid("3460693a-3763-45fd-a705-11ee2dfcfbdb"));
            ShortDescription = (ITTTextBox)AddControl(new Guid("98336736-454a-4625-a55e-48c1a994d132"));
            EndDateTimeFormat = (ITTTextBox)AddControl(new Guid("1b9d85d4-f29a-4fc6-a82a-247b1e509a6a"));
            Description = (ITTTextBox)AddControl(new Guid("f02b37b7-7eed-44a5-928d-e89d3f9a59ed"));
            TransactionType = (ITTEnumComboBox)AddControl(new Guid("33da2559-152b-466a-86b4-ec628e5e17fa"));
            labelRegistrationPrefix = (ITTLabel)AddControl(new Guid("64652033-e226-4581-ad3d-2d372472c2f7"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("abde3244-476f-4abc-b3b7-338087935c9d"));
            IsTotalStockInReport = (ITTCheckBox)AddControl(new Guid("61e8f74f-f676-4976-b7fc-7a293addb0cb"));
            IsTotalStockOutReport = (ITTCheckBox)AddControl(new Guid("b38dcd0a-75c8-4b33-8c49-261c9c1a46a1"));
            IsMovableTrxOutVoucher = (ITTCheckBox)AddControl(new Guid("1be37711-5f6d-4f42-9378-895eb4731618"));
            IsConsumedMaterialReport = (ITTCheckBox)AddControl(new Guid("fbc947d3-64b9-4caa-8f7e-af8d12c194f5"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("f03b828c-ca0b-42d3-b3c3-13094ceb8e95"));
            DocumentListView = (ITTListView)AddControl(new Guid("8b392790-9d35-4c08-864c-7ac05fbb84a3"));
            base.InitializeControls();
        }

        public StockTransactionDefinitionForm() : base("STOCKTRANSACTIONDEFINITION", "StockTransactionDefinitionForm")
        {
        }

        protected StockTransactionDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}