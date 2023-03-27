
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
    /// <summary>
    /// Stok Kartı Sıralama
    /// </summary>
    public partial class StockCardOrderForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region StockCardOrderForm_PreScript
    Dictionary<Guid, object> stockCards = new Dictionary<Guid, object>();
            foreach (StockCensusDetail detail in this._StockCensus.StockCensusDetails)
            {
                if (stockCards.ContainsKey(detail.StockCard.ObjectID) == false)
                {
                    stockCards.Add(detail.StockCard.ObjectID, detail.StockCard);
                }
            }

            foreach (KeyValuePair<Guid, object> card in stockCards)
            {
                ITTGridRow addedRow = this.StockCardOrders.Rows.Add();
                addedRow.Cells["StockCard"].Value = ((StockCard)card.Value).ObjectID;
                addedRow.Cells["OldCardOrderNo"].Value = ((StockCard)card.Value).CardOrderNO.Value;
            }
#endregion StockCardOrderForm_PreScript

            }
                }
}