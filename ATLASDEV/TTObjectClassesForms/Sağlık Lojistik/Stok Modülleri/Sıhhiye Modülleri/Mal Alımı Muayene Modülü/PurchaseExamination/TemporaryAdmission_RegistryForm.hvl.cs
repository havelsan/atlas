
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
    /// Geçici Kabul Kayıt
    /// </summary>
    public partial class TemporaryAdmission_RegistryForm : StockActionBaseForm
    {
    /// <summary>
    /// Geçici Kabul ve Mal Alım Muayene için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.PurchaseExamination _PurchaseExamination
        {
            get { return (TTObjectClasses.PurchaseExamination)_ttObject; }
        }

        protected ITTButton cmdAddItem;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTObjectListBox Accountancy;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage MaterialTabPage;
        protected ITTGrid StockActionInDetails;
        protected ITTTextBoxColumn OrderNO;
        protected ITTListBoxColumn PurchaseItemDef;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTDateTimePickerColumn ExpirationDate;
        protected ITTListDefComboBoxColumn StockLevelType;
        protected ITTTextBoxColumn ProductNumber;
        protected ITTEnumComboBoxColumn Status;
        protected ITTTextBox Description;
        protected ITTTextBox DecisionNO;
        protected ITTTextBox StockActionID;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker DecisionDate;
        protected ITTDateTimePicker TemporaryDeliveryDate;
        protected ITTLabel ttlabel10;
        protected ITTObjectListBox Store;
        protected ITTLabel labelDescription;
        protected ITTLabel labelContractDate;
        protected ITTLabel labelStore;
        protected ITTLabel labelDestinationStore;
        protected ITTDateTimePicker ContractDate;
        protected ITTObjectListBox Supplier;
        protected ITTLabel labelStockActionID;
        protected ITTLabel labelTransactionDate;
        protected ITTLabel ttlabel21;
        protected ITTLabel labelDecisionNO;
        override protected void InitializeControls()
        {
            cmdAddItem = (ITTButton)AddControl(new Guid("0f8a4888-fc97-420b-9f0c-d866ab63aab3"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("dd4e67fa-30a3-420d-b884-e1820a95670a"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("bb242ebc-46a7-4a5f-9b20-263ec87c16ee"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("bfe19c76-5155-4aad-a4ec-7ed35b96162b"));
            MaterialTabPage = (ITTTabPage)AddControl(new Guid("ef4125f9-4740-4818-af6e-da379d468f71"));
            StockActionInDetails = (ITTGrid)AddControl(new Guid("3ade9828-7de1-4210-9240-63d74a02d8d3"));
            OrderNO = (ITTTextBoxColumn)AddControl(new Guid("09655e7f-4b01-4a30-b4af-e947b287fcbc"));
            PurchaseItemDef = (ITTListBoxColumn)AddControl(new Guid("35cfedf0-0151-4943-8653-1ae8caf4343f"));
            Material = (ITTListBoxColumn)AddControl(new Guid("8879111a-77c9-4839-9ba3-d77b2a5618c1"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("fd2e8068-80b6-47f2-bc6d-82d0af8c2946"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("b981818a-caa7-4f9e-af95-34ab64eb0547"));
            ExpirationDate = (ITTDateTimePickerColumn)AddControl(new Guid("4ab93a67-026f-4c32-a70d-342e5a49d58e"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("991e65f7-26d8-4470-949d-62c81b2f068e"));
            ProductNumber = (ITTTextBoxColumn)AddControl(new Guid("d5eadf56-57bc-4a62-8f3a-e1f73516e4d2"));
            Status = (ITTEnumComboBoxColumn)AddControl(new Guid("b125d11d-bc1b-4a21-8c3c-ce42dde1d415"));
            Description = (ITTTextBox)AddControl(new Guid("fa839a14-b663-49e1-901d-124905651236"));
            DecisionNO = (ITTTextBox)AddControl(new Guid("baaa62ff-79da-40a1-8c5d-ce1ad09689f9"));
            StockActionID = (ITTTextBox)AddControl(new Guid("352cbf69-ea96-4ea0-be5a-e96d5d5f7763"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("390257f9-8266-4203-9a02-198fad92b385"));
            DecisionDate = (ITTDateTimePicker)AddControl(new Guid("b27d2801-489e-4ef5-8dea-1eb19d818fa2"));
            TemporaryDeliveryDate = (ITTDateTimePicker)AddControl(new Guid("346be11d-d071-4007-a14b-2011417bd9dc"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("e2a19c5b-b660-4c6c-8774-359b9e0ff7d6"));
            Store = (ITTObjectListBox)AddControl(new Guid("040bde98-9c06-45c5-8c8d-3cd6630fa6c9"));
            labelDescription = (ITTLabel)AddControl(new Guid("083765ab-1b40-4351-a07d-4c6d901b85b7"));
            labelContractDate = (ITTLabel)AddControl(new Guid("5da3bfcb-61b6-4124-b8c1-6fa2d699f543"));
            labelStore = (ITTLabel)AddControl(new Guid("c7a4bc8b-9aed-4b70-84a4-88a6bed1de47"));
            labelDestinationStore = (ITTLabel)AddControl(new Guid("b6de5693-c77f-4493-93ad-9bc85bc467f0"));
            ContractDate = (ITTDateTimePicker)AddControl(new Guid("6dd9f8a3-e979-4ea8-9d1f-aba490ef4dbb"));
            Supplier = (ITTObjectListBox)AddControl(new Guid("47924d6e-4827-49d2-8d4f-caff66ccf0e6"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("c55084f8-d196-457d-b9a1-cc14cb3fc414"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("fe248019-d86f-46a4-b103-cd003baba38a"));
            ttlabel21 = (ITTLabel)AddControl(new Guid("8b308978-108f-493a-af0e-e81100ac05be"));
            labelDecisionNO = (ITTLabel)AddControl(new Guid("f406d8c5-fddf-484c-9f0f-f51a98fa4be4"));
            base.InitializeControls();
        }

        public TemporaryAdmission_RegistryForm() : base("PURCHASEEXAMINATION", "TemporaryAdmission_RegistryForm")
        {
        }

        protected TemporaryAdmission_RegistryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}