
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
    public partial class BasePresChaDocWithPurchaseForm : BaseChattelDocumentWithPurchaseForm
    {
        override protected void BindControlEvents()
        {
            PresChaDocDetailsWithPurchase.CellValueChanged += new TTGridCellEventDelegate(PresChaDocDetailsWithPurchase_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            PresChaDocDetailsWithPurchase.CellValueChanged -= new TTGridCellEventDelegate(PresChaDocDetailsWithPurchase_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void PresChaDocDetailsWithPurchase_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region BasePresChaDocWithPurchaseForm_PresChaDocDetailsWithPurchase_CellValueChanged
   PresChaDocDetWithPurchase presChaDocDetWithPurchase = (PresChaDocDetWithPurchase)PresChaDocDetailsWithPurchase.CurrentCell.OwningRow.TTObject;
            
            if (PresChaDocDetailsWithPurchase.CurrentCell.OwningColumn.Name == "AmountPresChaDocDetWithPurchase" ||
                PresChaDocDetailsWithPurchase.CurrentCell.OwningColumn.Name == "UnitPricePresChaDocDetWithPurchase")
            {
                if (presChaDocDetWithPurchase.UnitPrice != null && presChaDocDetWithPurchase.Amount !=null )
                {
                    BigCurrency price = (BigCurrency)presChaDocDetWithPurchase.UnitPrice;
                    BigCurrency miktar = (BigCurrency)presChaDocDetWithPurchase.Amount;
                    if (price != 0)
                    {
                        double kdvOran = 1 ;
                        BigCurrency totalPrice = price * miktar;
                        presChaDocDetWithPurchase.UnitPrice = price;
                        presChaDocDetWithPurchase.UnitPriceWithInVat = price;
                        presChaDocDetWithPurchase.UnitPriceWithOutVat = price ;
                        txtTotalPrice.Text = CalculateTotalPrice().ToString();
                        
                    }
                }
            }
            
            if(PresChaDocDetailsWithPurchase.CurrentCell.OwningColumn.Name == "AmountPresChaDocDetWithPurchase" ||
               PresChaDocDetailsWithPurchase.CurrentCell.OwningColumn.Name == "UnitPricePresChaDocDetWithPurchase")
                txtTotalPrice.Text = CalculateTotalPrice().ToString();
#endregion BasePresChaDocWithPurchaseForm_PresChaDocDetailsWithPurchase_CellValueChanged
        }

        protected override void PreScript()
        {
#region BasePresChaDocWithPurchaseForm_PreScript
    base.PreScript();
            ChattelDocumentTabcontrol.HideTabPage(DistributionsTab);
            ChattelDocumentTabcontrol.HideTabPage(ChattelDocumentDetailTabpage);
#endregion BasePresChaDocWithPurchaseForm_PreScript

            }
                }
}