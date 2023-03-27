
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
    public partial class BaseChattelDocumentInputWithAccountancyForm : BaseChattelDocumentForm
    {
        protected TTObjectClasses.ChattelDocumentInputWithAccountancy _ChattelDocumentInputWithAccountancy
        {
            get { return (TTObjectClasses.ChattelDocumentInputWithAccountancy)_ttObject; }
        }

        protected ITTTextBox Waybill;
        protected ITTTextBox txtTotalPrice;
        protected ITTLabel labelWaybillDate;
        protected ITTDateTimePicker WaybillDate;
        protected ITTLabel labelWaybill;
        protected ITTLabel labelinputWithAccountancyType;
        protected ITTEnumComboBox inputWithAccountancyType;
        protected ITTLabel labelBudgetTypeDefinition;
        protected ITTObjectListBox BudgetTypeDefinition;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelAccountancy;
        protected ITTObjectListBox Accountancy;
        protected ITTTabControl ChattelDocumentTabcontrol;
        protected ITTTabPage ChattelDocumentDetailTabpage;
        protected ITTGrid ChattelDocumentDetailsWithAccountancy;
        protected ITTButtonColumn Detail;
        protected ITTListBoxColumn MaterialStockActionDetailIn;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn SentAmountChattelDocumentInputDetailWithAccountancy;
        protected ITTTextBoxColumn AmountStockActionDetailIn;
        protected ITTTextBoxColumn NotDiscountedUnitPrice;
        protected ITTTextBoxColumn UnitPriceStockActionDetailIn;
        protected ITTTextBoxColumn MKYS_IndirimOranı;
        protected ITTTextBoxColumn MKYS_IndirimTutari;
        protected ITTTextBoxColumn TotalPriceNotDiscount;
        protected ITTTextBoxColumn TotalDiscountAmount;
        protected ITTTextBoxColumn TotalPrice;
        protected ITTTextBoxColumn LotNo;
        protected ITTDateTimePickerColumn ExpirationDateStockActionDetailIn;
        protected ITTListDefComboBoxColumn StockLevelTypeStockActionDetailIn;
        protected ITTTextBoxColumn ConflictSubjectChattelDocumentInputDetailWithAccountancy;
        protected ITTEnumComboBoxColumn StatusStockActionDetailIn;
        protected ITTTextBoxColumn MKYS_EdinimYili;
        protected ITTDateTimePickerColumn MKYS_UretimTarihi;
        protected ITTTextBoxColumn ConflictAmountChattelDocumentInputDetailWithAccountancy;
        protected ITTTextBox txtSalesTotal;
        protected ITTTextBox txtTotalNotDiscount;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelMKYS_ETedarikTuru;
        protected ITTEnumComboBox MKYS_ETedarikTuru;
        protected ITTEnumComboBox MKYS_EMalzemeGrup;
        protected ITTLabel labelMKYS_EMalzemeGrup;
        protected ITTEnumComboBox MKYS_EAlimYontemi;
        protected ITTLabel labelMKYS_EAlimYontemi;
        protected ITTButton GetWaybill;
        override protected void InitializeControls()
        {
            Waybill = (ITTTextBox)AddControl(new Guid("ef45df60-3518-45f5-8c1d-8286742c2d3b"));
            txtTotalPrice = (ITTTextBox)AddControl(new Guid("b98a7092-787d-459a-ad19-4bd5eeeeb42b"));
            labelWaybillDate = (ITTLabel)AddControl(new Guid("45501fbe-7bc0-477c-9468-63d3c4f1b9f4"));
            WaybillDate = (ITTDateTimePicker)AddControl(new Guid("9b438fa0-38c6-480e-adf5-b1f90f15a013"));
            labelWaybill = (ITTLabel)AddControl(new Guid("2906697d-cb1e-480b-b63c-86483266ffbe"));
            labelinputWithAccountancyType = (ITTLabel)AddControl(new Guid("2d8262de-8494-4f52-8283-b4a1f889fda9"));
            inputWithAccountancyType = (ITTEnumComboBox)AddControl(new Guid("062c6426-84b3-490a-ab6d-ab0e9378e529"));
            labelBudgetTypeDefinition = (ITTLabel)AddControl(new Guid("956d2fac-5ea9-4de8-8c88-4be9b19a2e14"));
            BudgetTypeDefinition = (ITTObjectListBox)AddControl(new Guid("75de2ad4-58ca-47d9-8f71-9b6c15a335d2"));
            labelStore = (ITTLabel)AddControl(new Guid("e6ae2293-2bd7-4450-8ea3-b98c9c79876d"));
            Store = (ITTObjectListBox)AddControl(new Guid("e8b39b9b-e323-4ae4-8a30-bdd38c4df534"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("81fda554-a7b9-41d8-b626-c2b1ee3e7bdb"));
            labelAccountancy = (ITTLabel)AddControl(new Guid("d1a9bd31-d7d8-4643-bbf8-20f7c6315cfa"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("b4278ecf-7605-4daf-bcf1-85293e2e6bd3"));
            ChattelDocumentTabcontrol = (ITTTabControl)AddControl(new Guid("1d4d59a7-f31e-4707-856b-3d4dc8990f60"));
            ChattelDocumentDetailTabpage = (ITTTabPage)AddControl(new Guid("c6c24e9b-3d29-430c-ab83-e3eb97e60ae6"));
            ChattelDocumentDetailsWithAccountancy = (ITTGrid)AddControl(new Guid("5c5ce3a5-bf3e-481a-8103-92710c8464e7"));
            Detail = (ITTButtonColumn)AddControl(new Guid("bd0b7bf8-85a3-411b-adc6-4d9b0a3cfa6a"));
            MaterialStockActionDetailIn = (ITTListBoxColumn)AddControl(new Guid("977f900f-7d23-41d7-a1ff-6a315d7aa9b8"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("4998155a-6d49-4956-b363-bbc707b42b7b"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("ddd77b42-7f26-4f2b-9ef4-3f33e76a26ab"));
            SentAmountChattelDocumentInputDetailWithAccountancy = (ITTTextBoxColumn)AddControl(new Guid("3241ee94-7f43-4994-a643-4b70b2eb03a1"));
            AmountStockActionDetailIn = (ITTTextBoxColumn)AddControl(new Guid("2050aaee-d716-498e-8877-4659df510d10"));
            NotDiscountedUnitPrice = (ITTTextBoxColumn)AddControl(new Guid("9d9856ee-061c-4b6c-b65c-8d6e9fc95724"));
            UnitPriceStockActionDetailIn = (ITTTextBoxColumn)AddControl(new Guid("cca6a92d-1787-4dc0-bae1-ab0233a31ec7"));
            MKYS_IndirimOranı = (ITTTextBoxColumn)AddControl(new Guid("645e6da8-526d-4c2e-bcfc-5d197d4df18f"));
            MKYS_IndirimTutari = (ITTTextBoxColumn)AddControl(new Guid("e1c61a83-1f10-4dca-9507-33094e8f297a"));
            TotalPriceNotDiscount = (ITTTextBoxColumn)AddControl(new Guid("1cd78460-4154-45e8-9ae6-801d4a2bf449"));
            TotalDiscountAmount = (ITTTextBoxColumn)AddControl(new Guid("734a8605-bc88-4ce4-8f11-7909168998f7"));
            TotalPrice = (ITTTextBoxColumn)AddControl(new Guid("c4e7eb78-7e6a-4fef-b660-7376e9ee14a0"));
            LotNo = (ITTTextBoxColumn)AddControl(new Guid("afb189b0-403f-4840-bb90-0b38e21823e2"));
            ExpirationDateStockActionDetailIn = (ITTDateTimePickerColumn)AddControl(new Guid("40b4952e-f54e-449d-b0c6-027ee584a558"));
            StockLevelTypeStockActionDetailIn = (ITTListDefComboBoxColumn)AddControl(new Guid("42491533-8c59-4a29-80f9-532000938350"));
            ConflictSubjectChattelDocumentInputDetailWithAccountancy = (ITTTextBoxColumn)AddControl(new Guid("6b792a77-fc2a-47f1-9ca1-7b8620444971"));
            StatusStockActionDetailIn = (ITTEnumComboBoxColumn)AddControl(new Guid("73d69772-7f95-47e8-8004-f162673811e8"));
            MKYS_EdinimYili = (ITTTextBoxColumn)AddControl(new Guid("cf9fa1ad-6f4d-48c2-b652-b21359e45ca8"));
            MKYS_UretimTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("151b6f52-77dc-4bb6-b266-4334e1630a34"));
            ConflictAmountChattelDocumentInputDetailWithAccountancy = (ITTTextBoxColumn)AddControl(new Guid("0bc5f80b-a9a9-4ba1-a75f-19466950c8ba"));
            txtSalesTotal = (ITTTextBox)AddControl(new Guid("6334ccc2-f725-426c-8f85-6ac72a799956"));
            txtTotalNotDiscount = (ITTTextBox)AddControl(new Guid("89464569-35be-4124-a659-9ae9becce521"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("d4152628-cee3-4784-8ac4-a89458efdb6f"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("3789c6cc-c95c-4b56-8b23-28c5c425da79"));
            labelMKYS_ETedarikTuru = (ITTLabel)AddControl(new Guid("f1418579-b984-49e9-824c-40bf08ea18ab"));
            MKYS_ETedarikTuru = (ITTEnumComboBox)AddControl(new Guid("3e9cb50e-99e4-4f7e-acdd-d991f4cd73e2"));
            MKYS_EMalzemeGrup = (ITTEnumComboBox)AddControl(new Guid("6d943633-3db3-47fe-8bbb-2dbcaaf221ae"));
            labelMKYS_EMalzemeGrup = (ITTLabel)AddControl(new Guid("f4bc877f-e9bf-4621-9514-27c503066a4d"));
            MKYS_EAlimYontemi = (ITTEnumComboBox)AddControl(new Guid("6caddb0f-100d-47d6-a85e-7c163b63e18c"));
            labelMKYS_EAlimYontemi = (ITTLabel)AddControl(new Guid("acc862a1-ab23-4708-93e3-7dc21d6465e0"));
            GetWaybill = (ITTButton)AddControl(new Guid("6bb16b41-6814-474f-9474-62abf4998864"));
            base.InitializeControls();
        }

        public BaseChattelDocumentInputWithAccountancyForm() : base("CHATTELDOCUMENTINPUTWITHACCOUNTANCY", "BaseChattelDocumentInputWithAccountancyForm")
        {
        }

        protected BaseChattelDocumentInputWithAccountancyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}