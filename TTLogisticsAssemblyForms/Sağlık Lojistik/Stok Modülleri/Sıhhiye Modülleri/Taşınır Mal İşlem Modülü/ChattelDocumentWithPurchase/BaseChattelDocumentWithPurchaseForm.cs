
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class BaseChattelDocumentWithPurchaseForm : BaseChattelDocumentForm
    {
        override protected void BindControlEvents()
        {
            ChattelDocumentDetailsWithPurchase.CellDoubleClick += new TTGridCellEventDelegate(ChattelDocumentDetailsWithPurchase_CellDoubleClick);
            ChattelDocumentDetailsWithPurchase.CellValueChanged += new TTGridCellEventDelegate(ChattelDocumentDetailsWithPurchase_CellValueChanged);
            ChattelDocumentDetailsWithPurchase.CellContentClick += new TTGridCellEventDelegate(ChattelDocumentDetailsWithPurchase_CellContentClick);
            GetWaybill.Click += new TTControlEventDelegate(GetWaybill_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ChattelDocumentDetailsWithPurchase.CellDoubleClick -= new TTGridCellEventDelegate(ChattelDocumentDetailsWithPurchase_CellDoubleClick);
            ChattelDocumentDetailsWithPurchase.CellValueChanged -= new TTGridCellEventDelegate(ChattelDocumentDetailsWithPurchase_CellValueChanged);
            ChattelDocumentDetailsWithPurchase.CellContentClick -= new TTGridCellEventDelegate(ChattelDocumentDetailsWithPurchase_CellContentClick);
            GetWaybill.Click -= new TTControlEventDelegate(GetWaybill_Click);
            base.UnBindControlEvents();
        }

        private void GetWaybill_Click()
        {
            if (this._ChattelDocumentWithPurchase.CurrentStateDefID == ChattelDocumentWithPurchase.States.New)
            {
                if (!string.IsNullOrEmpty(this._ChattelDocumentWithPurchase.Waybill))
                {
                    var exp = this._ChattelDocumentWithPurchase.GetWaybillForInputDocument(this._ChattelDocumentWithPurchase);
                    if (exp != null)
                    {
                        this.ExaminationReportDate.ReadOnly = true;
                        this.ExaminationReportNo.ReadOnly = true;
                        this.MKYS_EAlimYontemi.ReadOnly = true;
                        this.RegistrationAuctionNo.ReadOnly = true;
                        this.AuctionDate.ReadOnly = true;
                        this.BudgetTypeDefinition.ReadOnly = true;
                        this.Waybill.ReadOnly = true;
                        this.GetWaybill.ReadOnly = true;
                        this.WaybillDate.ReadOnly = true;
                        this.ChattelDocumentDetailsWithPurchase.ReadOnly = true;
                        this.ChattelDocumentDetailsWithPurchase.AllowUserToAddRows = false;
                        this.ChattelDocumentDetailsWithPurchase.AllowUserToDeleteRows = true;
                    }
                }
            }
        }

        private void ChattelDocumentDetailsWithPurchase_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region BaseChattelDocumentWithPurchaseForm_ChattelDocumentDetailsWithPurchase_CellDoubleClick
            CheckWhetherTheInventoryOfMaterial(rowIndex, columnIndex, ChattelDocumentDetailsWithPurchase);
            #endregion BaseChattelDocumentWithPurchaseForm_ChattelDocumentDetailsWithPurchase_CellDoubleClick
        }






        private void ChattelDocumentDetailsWithPurchase_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
            #region BaseChattelDocumentWithPurchaseForm_ChattelDocumentDetailsWithPurchase_CellValueChanged
            ChattelDocumentDetailWithPurchase chattelDocumentDetailWithPurchase = (ChattelDocumentDetailWithPurchase)ChattelDocumentDetailsWithPurchase.CurrentCell.OwningRow.TTObject;

            if (ChattelDocumentDetailsWithPurchase.CurrentCell.OwningColumn.Name == "MaterialStockActionDetailIn")
            {
                if (this._ChattelDocumentWithPurchase.TransactionDate != null)
                    chattelDocumentDetailWithPurchase.VatRate = (long)chattelDocumentDetailWithPurchase.Material.GetVatrateFromMaterial(this._ChattelDocumentWithPurchase.TransactionDate);
            }


            if (ChattelDocumentDetailsWithPurchase.CurrentCell.OwningColumn.Name == "UnitPriceStockActionDetailInWithOutVat" ||
                ChattelDocumentDetailsWithPurchase.CurrentCell.OwningColumn.Name == "ValueAddedTax" ||
                ChattelDocumentDetailsWithPurchase.CurrentCell.OwningColumn.Name == "MKYS_IndirimOranı" ||
                ChattelDocumentDetailsWithPurchase.CurrentCell.OwningColumn.Name == "NotDiscountedUnitPrice" ||
                ChattelDocumentDetailsWithPurchase.CurrentCell.OwningColumn.Name == "AmountStockActionDetailIn")

            {
                chattelDocumentDetailWithPurchase.CalculatePricesWithKdv();


                List<double> priceCalc = new List<double>();
                double totalWithoutKDV = 0, totalWithKDV = 0, salesTotal = 0, totalPrice = 0;
                priceCalc.Add(totalWithoutKDV);
                priceCalc.Add(totalWithKDV);
                priceCalc.Add(salesTotal);
                priceCalc.Add(totalPrice);

                priceCalc = CalcFinalPriceWithKDV(priceCalc);

                txtNotKDV.Text = priceCalc[0].ToString("#.00");
                txtWithKDV.Text = priceCalc[1].ToString("#.00");
                txtDiscount.Text = priceCalc[2].ToString("#.00");
                txtTotalPrice.Text = priceCalc[3].ToString("#.00");
            }
            #endregion BaseChattelDocumentWithPurchaseForm_ChattelDocumentDetailsWithPurchase_CellValueChanged
        }

        private void ChattelDocumentDetailsWithPurchase_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region BaseChattelDocumentWithPurchaseForm_ChattelDocumentDetailsWithPurchase_CellContentClick
            if (ChattelDocumentDetailsWithPurchase.CurrentCell.OwningColumn.Name == "Detail")
                this.ShowStockActionDetailForm((StockActionDetail)ChattelDocumentDetailsWithPurchase.CurrentCell.OwningRow.TTObject);
            #endregion BaseChattelDocumentWithPurchaseForm_ChattelDocumentDetailsWithPurchase_CellContentClick
        }

        protected override void PreScript()
        {
            #region BaseChattelDocumentWithPurchaseForm_PreScript
            base.PreScript();
            //   txtTotalPrice.Text = CalculateTotalPrice().ToString();
            //  txtTotalPriceCurrency.Text = CalculateTotalPrice().ToString("#.00") ;
            invoicePictureControl.MaxFileSize = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MAXPICTUREFILESIZE", "153600"));
            #endregion BaseChattelDocumentWithPurchaseForm_PreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            #region BaseChattelDocumentWithPurchaseForm_PostScript
            base.PostScript(transDef);
            #endregion BaseChattelDocumentWithPurchaseForm_PostScript

        }

        #region BaseChattelDocumentWithPurchaseForm_Methods
        public List<double> CalcFinalPriceWithKDV(List<double> prices)
        {

            foreach (ChattelDocumentDetailWithPurchase inDet in this._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase)
            {
                if (inDet.UnitPriceWithInVat == null || inDet.UnitPriceWithOutVat == null || inDet.DiscountAmount == null)
                    continue;
                prices[0] += (Currency)inDet.Amount * Convert.ToDouble(inDet.UnitPriceWithOutVat);
                prices[1] += (Currency)inDet.Amount * Convert.ToDouble(inDet.UnitPriceWithInVat);
                prices[2] += Convert.ToDouble(inDet.DiscountAmount);
            }
            prices[3] = prices[1] - prices[2];
            return prices;
        }

        #endregion BaseChattelDocumentWithPurchaseForm_Methods
    }
}