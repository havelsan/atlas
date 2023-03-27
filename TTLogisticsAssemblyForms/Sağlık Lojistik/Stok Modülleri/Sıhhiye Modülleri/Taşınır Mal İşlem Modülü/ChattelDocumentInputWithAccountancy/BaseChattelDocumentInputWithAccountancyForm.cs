
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
    public partial class BaseChattelDocumentInputWithAccountancyForm : BaseChattelDocumentForm
    {
        override protected void BindControlEvents()
        {
            Accountancy.SelectedObjectChanged += new TTControlEventDelegate(Accountancy_SelectedObjectChanged);
            ChattelDocumentDetailsWithAccountancy.CellDoubleClick += new TTGridCellEventDelegate(ChattelDocumentDetailsWithAccountancy_CellDoubleClick);
            ChattelDocumentDetailsWithAccountancy.CellContentClick += new TTGridCellEventDelegate(ChattelDocumentDetailsWithAccountancy_CellContentClick);
            ChattelDocumentDetailsWithAccountancy.CellValueChanged += new TTGridCellEventDelegate(ChattelDocumentDetailsWithAccountancy_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            Accountancy.SelectedObjectChanged -= new TTControlEventDelegate(Accountancy_SelectedObjectChanged);
            ChattelDocumentDetailsWithAccountancy.CellDoubleClick -= new TTGridCellEventDelegate(ChattelDocumentDetailsWithAccountancy_CellDoubleClick);
            ChattelDocumentDetailsWithAccountancy.CellContentClick -= new TTGridCellEventDelegate(ChattelDocumentDetailsWithAccountancy_CellContentClick);
            ChattelDocumentDetailsWithAccountancy.CellValueChanged -= new TTGridCellEventDelegate(ChattelDocumentDetailsWithAccountancy_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void Accountancy_SelectedObjectChanged()
        {
#region BaseChattelDocumentInputWithAccountancyForm_Accountancy_SelectedObjectChanged
   _ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy.DeleteChildren();
        /*
                    if (((Accountancy)Accountancy.SelectedObject).AccountancyMilitaryUnit == null)
                        MaterialStockActionDetailIn.ListFilterExpression = "STOCKCARD.CREATEDSITE is null OR STOCKCARD.CREATEDSITE =" + ConnectionManager.GuidToString(Sites.SiteMerkezSagKom);
                    else
                    {
                        if (((Accountancy)Accountancy.SelectedObject).AccountancyMilitaryUnit.IsSupported != null)
                        {
                            if (((Accountancy)Accountancy.SelectedObject).AccountancyMilitaryUnit.IsSupported == false)
                                MaterialStockActionDetailIn.ListFilterExpression = "STOCKCARD.CREATEDSITE is null OR STOCKCARD.CREATEDSITE =" + ConnectionManager.GuidToString(Sites.SiteMerkezSagKom);
                        }
                        else
                           MaterialStockActionDetailIn.ListFilterExpression = "STOCKCARD.CREATEDSITE is null OR STOCKCARD.CREATEDSITE =" + ConnectionManager.GuidToString(Sites.SiteMerkezSagKom);
                    }
                    */
#endregion BaseChattelDocumentInputWithAccountancyForm_Accountancy_SelectedObjectChanged
        }

        private void ChattelDocumentDetailsWithAccountancy_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseChattelDocumentInputWithAccountancyForm_ChattelDocumentDetailsWithAccountancy_CellDoubleClick
   CheckWhetherTheInventoryOfMaterial(rowIndex, columnIndex, ChattelDocumentDetailsWithAccountancy);
#endregion BaseChattelDocumentInputWithAccountancyForm_ChattelDocumentDetailsWithAccountancy_CellDoubleClick
        }

        private void ChattelDocumentDetailsWithAccountancy_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseChattelDocumentInputWithAccountancyForm_ChattelDocumentDetailsWithAccountancy_CellContentClick
   if (ChattelDocumentDetailsWithAccountancy.CurrentCell.OwningColumn.Name == "Detail")
            this.ShowStockActionDetailForm((StockActionDetail)ChattelDocumentDetailsWithAccountancy.CurrentCell.OwningRow.TTObject);
#endregion BaseChattelDocumentInputWithAccountancyForm_ChattelDocumentDetailsWithAccountancy_CellContentClick
        }

        private void ChattelDocumentDetailsWithAccountancy_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseChattelDocumentInputWithAccountancyForm_ChattelDocumentDetailsWithAccountancy_CellValueChanged
   ChattelDocumentInputDetailWithAccountancy detail = (ChattelDocumentInputDetailWithAccountancy)ChattelDocumentDetailsWithAccountancy.CurrentCell.OwningRow.TTObject;

            if (_ChattelDocumentInputWithAccountancy.Accountancy == null)
            {
                _ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy.DeleteChildren();
                InfoBox.Show("Önce Saymanlık Seçiniz");
            }
            else
            {
                if (ChattelDocumentDetailsWithAccountancy.CurrentCell.OwningColumn.Name == "AmountStockActionDetailIn" ||
                    ChattelDocumentDetailsWithAccountancy.CurrentCell.OwningColumn.Name == "UnitPriceStockActionDetailIn")
                    txtTotalPrice.Text = CalculateTotalPrice().ToString();
            }


            if (ChattelDocumentDetailsWithAccountancy.CurrentCell.OwningColumn.Name == "MKYS_IndirimOranı" ||
                ChattelDocumentDetailsWithAccountancy.CurrentCell.OwningColumn.Name == "NotDiscountedUnitPrice" ||
                ChattelDocumentDetailsWithAccountancy.CurrentCell.OwningColumn.Name == "AmountStockActionDetailIn")
            {
                detail.CalculatePrices();
                
                List<double> priceCalc = new List<double>();
                double total = 0,salesTotal = 0,totalPrice = 0;
                priceCalc.Add(total);
                priceCalc.Add(salesTotal);
                priceCalc.Add(totalPrice);
                
                priceCalc = CalcFinalPrice(priceCalc);
                
                txtTotalNotDiscount.Text = priceCalc[0].ToString();
                txtSalesTotal.Text = priceCalc[1].ToString();
                txtTotalPrice.Text = priceCalc[2].ToString();
            }
#endregion BaseChattelDocumentInputWithAccountancyForm_ChattelDocumentDetailsWithAccountancy_CellValueChanged
        }

        protected override void PreScript()
        {
#region BaseChattelDocumentInputWithAccountancyForm_PreScript
    base.PreScript();
        txtTotalPrice.Text = CalculateTotalPrice().ToString();
#endregion BaseChattelDocumentInputWithAccountancyForm_PreScript

            }
                }
}