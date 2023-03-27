
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
    public partial class BaseChattelDocumentWithPurchaseForm : BaseChattelDocumentForm
    {
    /// <summary>
    /// Satınalma Yoluyla
    /// </summary>
        protected TTObjectClasses.ChattelDocumentWithPurchase _ChattelDocumentWithPurchase
        {
            get { return (TTObjectClasses.ChattelDocumentWithPurchase)_ttObject; }
        }

        protected ITTTabPage PictureTabpage;
        protected ITTPictureBoxControl invoicePictureControl;
        protected ITTTextBox Waybill;
        protected ITTTextBox RegistrationAuctionNo;
        protected ITTTextBox txtTotalPrice;
        protected ITTTextBox ExaminationReportNo;
        protected ITTTextBox ConclusionNumber;
        protected ITTLabel labelWaybillDate;
        protected ITTDateTimePicker WaybillDate;
        protected ITTButton GetWaybill;
        protected ITTLabel labelWaybill;
        protected ITTLabel labelBudgetTypeDefinition;
        protected ITTObjectListBox BudgetTypeDefinition;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelRegistrationAuctionNo;
        protected ITTLabel labelAuctionDate;
        protected ITTDateTimePicker AuctionDate;
        protected ITTLabel labelExaminationReportNo;
        protected ITTLabel labelExaminationReportDate;
        protected ITTDateTimePicker ExaminationReportDate;
        protected ITTLabel labelConclusionNumber;
        protected ITTLabel labelConclusionDateTime;
        protected ITTDateTimePicker ConclusionDateTime;
        protected ITTLabel labelSupplier;
        protected ITTObjectListBox Supplier;
        protected ITTTabControl ChattelDocumentTabcontrol;
        protected ITTTabPage ChattelDocumentDetailTabpage;
        protected ITTGrid ChattelDocumentDetailsWithPurchase;
        protected ITTButtonColumn Detail;
        protected ITTListBoxColumn MaterialStockActionDetailIn;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn AmountStockActionDetailIn;
        protected ITTTextBoxColumn UnitPriceStockActionDetailInWithOutVat;
        protected ITTTextBoxColumn ValueAddedTax;
        protected ITTTextBoxColumn UnitePriceWithVatNoDiscount;
        protected ITTTextBoxColumn MKYS_IndirimOranı;
        protected ITTTextBoxColumn UnitPriceStockActionDetailIn;
        protected ITTTextBoxColumn MKYS_IndirimTutari;
        protected ITTTextBoxColumn TotalPrice;
        protected ITTTextBoxColumn LotNo;
        protected ITTDateTimePickerColumn ExpirationDateStockActionDetailIn;
        protected ITTListDefComboBoxColumn StockLevelTypeStockActionDetailIn;
        protected ITTEnumComboBoxColumn StatusStockActionDetailIn;
        protected ITTTextBoxColumn MKYS_EdinimYili;
        protected ITTDateTimePickerColumn MKYS_UretimTarihi;
        protected ITTTabPage DistributionsTab;
        protected ITTGrid DemandAmountsGrid;
        protected ITTListBoxColumn DA_Material;
        protected ITTListBoxColumn DA_MasterResource;
        protected ITTTextBoxColumn DA_DemandAmount;
        protected ITTTextBoxColumn DA_DistributionAmount;
        protected ITTTextBox txtDiscount;
        protected ITTTextBox txtWithKDV;
        protected ITTTextBox txtNotKDV;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        protected ITTEnumComboBox MKYS_EAlimYontemi;
        protected ITTLabel labelMKYS_EMalzemeGrup;
        protected ITTEnumComboBox MKYS_ETedarikTuru;
        protected ITTLabel labelMKYS_ETedarikTuru;
        protected ITTEnumComboBox MKYS_EMalzemeGrup;
        protected ITTLabel labelMKYS_EAlimYontemi;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel5;
        override protected void InitializeControls()
        {
            PictureTabpage = (ITTTabPage)AddControl(new Guid("82a1fd82-efc4-4d99-addd-3a6e5fc75fd1"));
            invoicePictureControl = (ITTPictureBoxControl)AddControl(new Guid("815d543a-ecd1-4ef7-adff-b034893fe129"));
            Waybill = (ITTTextBox)AddControl(new Guid("62f9ff4f-6898-4162-9eb7-a8d2eecc69c5"));
            RegistrationAuctionNo = (ITTTextBox)AddControl(new Guid("711a052c-bc0e-4b0d-94e5-525a0f4aded4"));
            txtTotalPrice = (ITTTextBox)AddControl(new Guid("062beb8f-664a-4b97-b0ee-8cb78e8cac37"));
            ExaminationReportNo = (ITTTextBox)AddControl(new Guid("33c67459-c618-46a2-b7d4-42ea9d4e87eb"));
            ConclusionNumber = (ITTTextBox)AddControl(new Guid("2d49ee45-75b7-4753-8b72-adb0347fc59c"));
            labelWaybillDate = (ITTLabel)AddControl(new Guid("30d62919-4962-433c-81fb-60fe8b461182"));
            WaybillDate = (ITTDateTimePicker)AddControl(new Guid("0255efc6-f5af-4f8f-9780-dd23f61dd907"));
            GetWaybill = (ITTButton)AddControl(new Guid("58d1093f-0f47-40ea-b6ef-f773ebb55278"));
            labelWaybill = (ITTLabel)AddControl(new Guid("f9d98209-3915-4a2a-9da2-663c6e2ead53"));
            labelBudgetTypeDefinition = (ITTLabel)AddControl(new Guid("b73497eb-be92-40fe-a09d-f59a99b11d29"));
            BudgetTypeDefinition = (ITTObjectListBox)AddControl(new Guid("b52954db-5a55-4200-aedd-ab2221da8454"));
            labelStore = (ITTLabel)AddControl(new Guid("dee58e93-9225-4feb-97c4-313f011c76bf"));
            Store = (ITTObjectListBox)AddControl(new Guid("acd222c1-4f7f-47fd-9ff1-469e4b953bc6"));
            labelRegistrationAuctionNo = (ITTLabel)AddControl(new Guid("347e997d-e351-4fa4-b687-075f365d729c"));
            labelAuctionDate = (ITTLabel)AddControl(new Guid("487056c8-be2d-4bd7-abab-53ab161a08d1"));
            AuctionDate = (ITTDateTimePicker)AddControl(new Guid("836e2531-15bf-4119-ac94-48e0d4cfbd68"));
            labelExaminationReportNo = (ITTLabel)AddControl(new Guid("c0cc8be8-35d3-41c8-84e6-7feb24ad4396"));
            labelExaminationReportDate = (ITTLabel)AddControl(new Guid("f18de0d5-f851-4f00-ac59-bdac597d672b"));
            ExaminationReportDate = (ITTDateTimePicker)AddControl(new Guid("5d07104a-8ed9-4616-847f-c25ebcf59d51"));
            labelConclusionNumber = (ITTLabel)AddControl(new Guid("564939ac-cd33-438e-b762-0b0cf93bbd61"));
            labelConclusionDateTime = (ITTLabel)AddControl(new Guid("0b3aa99e-6ce9-4a80-88c6-947b46dbe0a7"));
            ConclusionDateTime = (ITTDateTimePicker)AddControl(new Guid("e7d32961-ea00-4a47-a7a3-1f66b644bd52"));
            labelSupplier = (ITTLabel)AddControl(new Guid("aee24b21-902c-4070-8683-c15a5c69d614"));
            Supplier = (ITTObjectListBox)AddControl(new Guid("72b6bb08-9092-4546-805f-8dcd9e637c27"));
            ChattelDocumentTabcontrol = (ITTTabControl)AddControl(new Guid("b769af5e-8296-42a9-b1cf-90aa68651720"));
            ChattelDocumentDetailTabpage = (ITTTabPage)AddControl(new Guid("3cb70d28-29a5-4863-b56b-6667535d8596"));
            ChattelDocumentDetailsWithPurchase = (ITTGrid)AddControl(new Guid("e2992c56-92db-448a-a3a6-d15be8ccdfec"));
            Detail = (ITTButtonColumn)AddControl(new Guid("5348cf78-27bd-43b7-aa87-d36ab216b90f"));
            MaterialStockActionDetailIn = (ITTListBoxColumn)AddControl(new Guid("414e5e6c-ec1e-4dd1-acb4-8026ade18f84"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("f5439b61-17d1-4a7d-8da0-75b910d03008"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("d63d0e02-b018-404a-88f7-083ab5a5d72d"));
            AmountStockActionDetailIn = (ITTTextBoxColumn)AddControl(new Guid("0f0e6417-e923-4ff6-9abc-5232c9419141"));
            UnitPriceStockActionDetailInWithOutVat = (ITTTextBoxColumn)AddControl(new Guid("a924b31c-7852-4633-a810-cd6608e35a47"));
            ValueAddedTax = (ITTTextBoxColumn)AddControl(new Guid("d3f1ca24-53e8-4dec-8fee-871e6d522978"));
            UnitePriceWithVatNoDiscount = (ITTTextBoxColumn)AddControl(new Guid("1d9a6500-ec17-4744-a276-582bbe3e90cc"));
            MKYS_IndirimOranı = (ITTTextBoxColumn)AddControl(new Guid("db4e80d1-6908-408d-ac75-2ac1cfbf8269"));
            UnitPriceStockActionDetailIn = (ITTTextBoxColumn)AddControl(new Guid("4fbc9302-fa43-41f4-8058-9827f084b358"));
            MKYS_IndirimTutari = (ITTTextBoxColumn)AddControl(new Guid("546bf270-763e-4d26-9db4-c3a117707e1d"));
            TotalPrice = (ITTTextBoxColumn)AddControl(new Guid("839c1062-d740-4d83-8eb0-f61b9586d86d"));
            LotNo = (ITTTextBoxColumn)AddControl(new Guid("34afaf0c-9635-451d-adbb-fb0d58dbee56"));
            ExpirationDateStockActionDetailIn = (ITTDateTimePickerColumn)AddControl(new Guid("53f544bb-a444-4df0-86c9-b5171349c4d3"));
            StockLevelTypeStockActionDetailIn = (ITTListDefComboBoxColumn)AddControl(new Guid("1257b468-dea4-428a-a828-ce9f0d6f3eb3"));
            StatusStockActionDetailIn = (ITTEnumComboBoxColumn)AddControl(new Guid("1e790768-b25f-475b-bb7c-1ea2ce703c0b"));
            MKYS_EdinimYili = (ITTTextBoxColumn)AddControl(new Guid("dd1b2f1b-e074-46ec-ad38-762ecc3ad76c"));
            MKYS_UretimTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("eb89069d-e03f-4a9e-92c1-cb6d86c87bb5"));
            DistributionsTab = (ITTTabPage)AddControl(new Guid("5552a244-0eff-4708-8092-9b92d9563674"));
            DemandAmountsGrid = (ITTGrid)AddControl(new Guid("99fab6d5-30dd-4960-a246-c5ffc2596d47"));
            DA_Material = (ITTListBoxColumn)AddControl(new Guid("5d067a70-3ba7-4894-a156-73dee187719c"));
            DA_MasterResource = (ITTListBoxColumn)AddControl(new Guid("974dda9c-c014-4345-a302-8b7ea42ff6bc"));
            DA_DemandAmount = (ITTTextBoxColumn)AddControl(new Guid("bc0ad0c0-3ec5-4a0f-a5a8-529902f1256f"));
            DA_DistributionAmount = (ITTTextBoxColumn)AddControl(new Guid("a3bee220-0b10-4724-948d-b84f812ac2de"));
            txtDiscount = (ITTTextBox)AddControl(new Guid("9db67e46-8bb1-40fe-9fd2-cce8c667e540"));
            txtWithKDV = (ITTTextBox)AddControl(new Guid("20b82c16-a788-4930-8c62-7ce5b755e381"));
            txtNotKDV = (ITTTextBox)AddControl(new Guid("ebb50ed7-a42c-480f-94e0-b0d90626e9fb"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6bb0ffb3-f03d-45c1-9db0-ba8ad7498b20"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("963877b3-25d5-4079-bb20-ed589a8d8be3"));
            MKYS_EAlimYontemi = (ITTEnumComboBox)AddControl(new Guid("bbeee4b1-0798-4344-b0bb-77a754d71eec"));
            labelMKYS_EMalzemeGrup = (ITTLabel)AddControl(new Guid("14b0fec6-a79c-4e13-9608-1dfeb5847e78"));
            MKYS_ETedarikTuru = (ITTEnumComboBox)AddControl(new Guid("62f70f57-752b-423b-b17e-7fe4c186ec8d"));
            labelMKYS_ETedarikTuru = (ITTLabel)AddControl(new Guid("68a7a12e-bb42-4777-a26f-dadf7e167aca"));
            MKYS_EMalzemeGrup = (ITTEnumComboBox)AddControl(new Guid("b887d108-bf54-4461-bf3d-c7ba8dbf7976"));
            labelMKYS_EAlimYontemi = (ITTLabel)AddControl(new Guid("100e5aa0-a9cc-4a0d-8354-2ed2b68a4ef5"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("07bd0da7-2558-4d54-8356-da94226c0416"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("8050ae96-8350-4293-b599-fd7b97ee9f7b"));
            base.InitializeControls();
        }

        public BaseChattelDocumentWithPurchaseForm() : base("CHATTELDOCUMENTWITHPURCHASE", "BaseChattelDocumentWithPurchaseForm")
        {
        }

        protected BaseChattelDocumentWithPurchaseForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}