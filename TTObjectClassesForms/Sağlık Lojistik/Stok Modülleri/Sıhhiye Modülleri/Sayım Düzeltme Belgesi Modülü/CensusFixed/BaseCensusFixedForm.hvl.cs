
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
    /// Sayım Düzeltme Belgesi
    /// </summary>
    public partial class BaseCensusFixedForm : StockActionBaseForm
    {
    /// <summary>
    /// Sayım Düzeltme Belgesi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.CensusFixed _CensusFixed
        {
            get { return (TTObjectClasses.CensusFixed)_ttObject; }
        }

        protected ITTLabel labelBudgetTypeDefinition;
        protected ITTObjectListBox BudgetTypeDefinition;
        protected ITTTextBox Description;
        protected ITTLabel labelMKYS_EMalzemeGrup;
        protected ITTEnumComboBox MKYS_EMalzemeGrup;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTGroupBox InMaterialsGroupBox;
        protected ITTGrid StockActionInDetails;
        protected ITTButtonColumn Detail;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn BarcodeA;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn StoreStock;
        protected ITTTextBoxColumn OrderSequenceNumber;
        protected ITTTextBoxColumn CardAmount;
        protected ITTTextBoxColumn CensusAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn Unitprice;
        protected ITTTextBoxColumn LotNo;
        protected ITTDateTimePickerColumn ExpirationDate;
        protected ITTListDefComboBoxColumn StockLevelType;
        protected ITTTabControl DescriptionAndSignTabControl;
        protected ITTTabPage SignTabpage;
        protected ITTGrid StockActionSignDetails;
        protected ITTEnumComboBoxColumn SignUserType;
        protected ITTListBoxColumn SignUser;
        protected ITTCheckBoxColumn IsDeputy;
        protected ITTTabPage DescriptionTabpage;
        protected ITTTextBox StockActionID;
        protected ITTTextBox MKYS_TeslimAlan;
        protected ITTTextBox MKYS_TeslimEden;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelStockActionID;
        protected ITTLabel labelTransactionDate;
        protected ITTGroupBox OutMaterialsGroupBox;
        protected ITTGrid StockActionOutDetails;
        protected ITTButtonColumn DetailOut;
        protected ITTListBoxColumn MaterialOut;
        protected ITTTextBoxColumn BarcodeE;
        protected ITTTextBoxColumn DistributionTypeOut;
        protected ITTTextBoxColumn StoreStockOut;
        protected ITTTextBoxColumn OrderSequenceNumberOut;
        protected ITTTextBoxColumn CardAmountOut;
        protected ITTTextBoxColumn CensusAmountOut;
        protected ITTTextBoxColumn AmountOut;
        protected ITTTextBoxColumn AproximateUnitPriceOut;
        protected ITTListDefComboBoxColumn StockLevelTypeOut;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelMKYS_TeslimEden;
        protected ITTLabel labelMKYS_TeslimAlan;
        protected ITTButton TTTeslimAlanButon;
        protected ITTButton TTTeslimEdenButon;
        override protected void InitializeControls()
        {
            labelBudgetTypeDefinition = (ITTLabel)AddControl(new Guid("55d31b8e-04bc-4bae-9993-10ee7e489d53"));
            BudgetTypeDefinition = (ITTObjectListBox)AddControl(new Guid("f7b11a53-965f-42ac-a800-2a2e1363c5f8"));
            Description = (ITTTextBox)AddControl(new Guid("6543cfc2-bf24-4a43-8a10-278c2f30e04c"));
            labelMKYS_EMalzemeGrup = (ITTLabel)AddControl(new Guid("6d66f271-205b-426e-8487-f4521ba04159"));
            MKYS_EMalzemeGrup = (ITTEnumComboBox)AddControl(new Guid("54466c6b-d105-45bb-87b1-5977da94a2cc"));
            labelStore = (ITTLabel)AddControl(new Guid("2f46ac2d-8ac2-44e3-a8bf-d956ed0ce2f1"));
            Store = (ITTObjectListBox)AddControl(new Guid("38b62801-3478-4c33-980a-da1a9943e20f"));
            InMaterialsGroupBox = (ITTGroupBox)AddControl(new Guid("231db859-1ffb-43f3-9491-7ec4a968849a"));
            StockActionInDetails = (ITTGrid)AddControl(new Guid("df8e817c-269f-4956-8657-033ece7d2765"));
            Detail = (ITTButtonColumn)AddControl(new Guid("c695ccb7-92a4-465e-90f6-d8f990645fdf"));
            Material = (ITTListBoxColumn)AddControl(new Guid("8870e5c8-be67-46d7-a402-dd515f1029bd"));
            BarcodeA = (ITTTextBoxColumn)AddControl(new Guid("d661f770-5eab-4d49-9a2d-881d6dc6ad7f"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("201256a0-5f9d-4ce0-b33a-69a27fe17aa8"));
            StoreStock = (ITTTextBoxColumn)AddControl(new Guid("db7826f5-95f3-4f4c-9570-55d122a30167"));
            OrderSequenceNumber = (ITTTextBoxColumn)AddControl(new Guid("dc48e964-d599-4b1a-9234-b887b75c434b"));
            CardAmount = (ITTTextBoxColumn)AddControl(new Guid("93a06109-f379-4906-b8de-6836afdaf510"));
            CensusAmount = (ITTTextBoxColumn)AddControl(new Guid("248bf8be-7a8d-403d-b899-d7a9aabd1224"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("6fc3c71f-ac36-40de-8d52-da54feabdf62"));
            Unitprice = (ITTTextBoxColumn)AddControl(new Guid("60b1d301-4dac-4288-82db-130f6dcffef9"));
            LotNo = (ITTTextBoxColumn)AddControl(new Guid("f42e4156-8558-445a-9fd3-e031075bd8ae"));
            ExpirationDate = (ITTDateTimePickerColumn)AddControl(new Guid("6ee2d46f-7ad9-463c-85e5-5098743865dd"));
            StockLevelType = (ITTListDefComboBoxColumn)AddControl(new Guid("96682f1f-6cf8-4259-81f8-2a8361641f97"));
            DescriptionAndSignTabControl = (ITTTabControl)AddControl(new Guid("f7e41cd9-34c0-4c36-a805-a645be0cdf4e"));
            SignTabpage = (ITTTabPage)AddControl(new Guid("191ba307-69ff-4f24-94fd-7693f326c4e5"));
            StockActionSignDetails = (ITTGrid)AddControl(new Guid("96d388a8-36ba-46ce-89be-6c0e81f233af"));
            SignUserType = (ITTEnumComboBoxColumn)AddControl(new Guid("4a1c6590-0a16-44a7-b70c-9fa01048058e"));
            SignUser = (ITTListBoxColumn)AddControl(new Guid("f9afd536-e5a4-41a5-a578-918517ff9d98"));
            IsDeputy = (ITTCheckBoxColumn)AddControl(new Guid("58447250-2280-4d2e-b24b-cefbb294eeaa"));
            DescriptionTabpage = (ITTTabPage)AddControl(new Guid("a896f420-b52d-4cea-9be5-d6724fa4228d"));
            StockActionID = (ITTTextBox)AddControl(new Guid("59587798-d619-4f88-988a-c5d0c8728b6a"));
            MKYS_TeslimAlan = (ITTTextBox)AddControl(new Guid("6b033632-635d-446f-a79c-9ef20683030b"));
            MKYS_TeslimEden = (ITTTextBox)AddControl(new Guid("7b11f309-510a-4281-aa37-f7f75fadba2f"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("fb91722b-11c7-4588-a381-7ca89d48f809"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("d7c21f2c-dc92-41e4-98a3-404eb4a107da"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("2880428b-df69-4841-8a49-22cec8250033"));
            OutMaterialsGroupBox = (ITTGroupBox)AddControl(new Guid("b35d7dbd-b86b-416f-bfc5-eecbaeb4e2b9"));
            StockActionOutDetails = (ITTGrid)AddControl(new Guid("d22610ba-0ac6-452d-a447-ef66d11c5af1"));
            DetailOut = (ITTButtonColumn)AddControl(new Guid("121deca1-86a0-4f8f-90a1-4e697138b986"));
            MaterialOut = (ITTListBoxColumn)AddControl(new Guid("d7ed49ad-c53d-40d9-a616-4e82a6d5ce3c"));
            BarcodeE = (ITTTextBoxColumn)AddControl(new Guid("1b2054ff-192e-4867-b92f-9d6d9a119b87"));
            DistributionTypeOut = (ITTTextBoxColumn)AddControl(new Guid("f93cf9e6-7c38-4348-a0e1-d212b384d631"));
            StoreStockOut = (ITTTextBoxColumn)AddControl(new Guid("b6e2e09d-fbe9-4aae-96b2-47dc3a2ba2f0"));
            OrderSequenceNumberOut = (ITTTextBoxColumn)AddControl(new Guid("9888a9bb-dbe5-4e97-acaa-f6581215ebe1"));
            CardAmountOut = (ITTTextBoxColumn)AddControl(new Guid("5c82d28d-b743-482e-bdfa-57b1120ab56a"));
            CensusAmountOut = (ITTTextBoxColumn)AddControl(new Guid("0b203827-bce3-48cb-9643-a900fa399a06"));
            AmountOut = (ITTTextBoxColumn)AddControl(new Guid("37b37068-e634-4f75-a026-8616990d01c6"));
            AproximateUnitPriceOut = (ITTTextBoxColumn)AddControl(new Guid("d4e8d5c7-3c4a-4b12-b45e-8d4d7ea50b6c"));
            StockLevelTypeOut = (ITTListDefComboBoxColumn)AddControl(new Guid("d2e3b0dc-fb30-48a4-9751-629da8a56e73"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("75975ad8-6d45-44e6-9b04-e7792afa3add"));
            labelMKYS_TeslimEden = (ITTLabel)AddControl(new Guid("c3dc660e-df88-416a-8813-474288026066"));
            labelMKYS_TeslimAlan = (ITTLabel)AddControl(new Guid("e8492d69-4a08-4b93-b4fc-f12517b0e10b"));
            TTTeslimAlanButon = (ITTButton)AddControl(new Guid("893b97c4-cc4d-4402-a685-876691867532"));
            TTTeslimEdenButon = (ITTButton)AddControl(new Guid("fbe0eb6a-49f6-4a87-899b-e73c3cc52a16"));
            base.InitializeControls();
        }

        public BaseCensusFixedForm() : base("CENSUSFIXED", "BaseCensusFixedForm")
        {
        }

        protected BaseCensusFixedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}