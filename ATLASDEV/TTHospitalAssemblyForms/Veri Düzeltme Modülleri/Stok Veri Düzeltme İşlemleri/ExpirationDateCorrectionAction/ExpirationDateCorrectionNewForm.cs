
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
    /// Son Kullanma Tarihi Güncelleme
    /// </summary>
    public partial class ExpirationDateCorrectionNewForm : BaseDataCorrectionForm
    {
        override protected void BindControlEvents()
        {
            cmdGetRestAmountTrx.Click += new TTControlEventDelegate(cmdGetRestAmountTrx_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdGetRestAmountTrx.Click -= new TTControlEventDelegate(cmdGetRestAmountTrx_Click);
            base.UnBindControlEvents();
        }

        private void cmdGetRestAmountTrx_Click()
        {
#region ExpirationDateCorrectionNewForm_cmdGetRestAmountTrx_Click
   IList<StockTransaction> restInTrx = new List<StockTransaction>();
            Dictionary<StockTransaction, IList<StockTransaction> > restTrx = new Dictionary<StockTransaction,IList<StockTransaction>>();
            foreach (Stock stock in _ExpirationDateCorrectionAction.Material.Stocks.Select(string.Empty))
            {

                foreach (StockTransaction.RestFIFOStockTransactionsRQ_Class inTrx in StockTransaction.RestFIFOStockTransactionsRQ(stock.ObjectID))
                {
                    StockTransaction trx = (StockTransaction)_ExpirationDateCorrectionAction.ObjectContext.GetObject((Guid)inTrx.ObjectID, typeof(StockTransaction));
                    
                    if (this.expirationDate_ttcheckbox.Value == true)
                    {
                        restInTrx.Add(trx);
                    }
                    else
                    {
                        if (trx.ExpirationDate != null)
                            restInTrx.Add(trx);
                    }
                }
            }

            foreach (StockTransaction findTrx in restInTrx)
            {
                StockTransaction firstInTrx = null;
                if (findTrx.StockTransactionDefinition.TransactionType == TransactionTypeEnum.Transfer)
                {
                    if (findTrx.StockActionDetail.StockTransactions.Select("INOUT = 2").Count == 1)
                    {
                        firstInTrx = findTrx.StockActionDetail.StockTransactions.Select("INOUT = 2")[0].GetFirstInTransaction();
                    }
                }
                else
                {
                    firstInTrx = findTrx;
                }
                
                if (firstInTrx != null)
                {
                    if (restTrx.ContainsKey(firstInTrx))
                    {
                        restTrx[firstInTrx].Add(findTrx);
                    }
                    else
                    {
                        IList<StockTransaction> t = new List<StockTransaction>();
                        if (findTrx.StockTransactionDefinition.TransactionType == TransactionTypeEnum.Transfer)
                            t.Add(findTrx);
                        restTrx.Add(firstInTrx, t);
                    }
                }
            }

            foreach(KeyValuePair<StockTransaction,IList<StockTransaction>> transaction in restTrx)
            {
                FirstInStockAction firstInStockAction = new FirstInStockAction(_ExpirationDateCorrectionAction.ObjectContext);
                firstInStockAction.SelectedStockAction = false;
                firstInStockAction.StockAction = transaction.Key.StockActionDetail.StockAction;
                firstInStockAction.StockActionDescription = transaction.Key.StockActionDetail.StockAction.ObjectDef.DisplayText;
                firstInStockAction.StockTransactionObjectID = transaction.Key.ObjectID;
                firstInStockAction.ExpirationDate = transaction.Key.ExpirationDate ;
                firstInStockAction.ExpireDateCorrectionAction = _ExpirationDateCorrectionAction;
                foreach(StockTransaction inTransaction in transaction.Value)
                {
                    InStockAction inStockAction = new InStockAction(_ExpirationDateCorrectionAction.ObjectContext);
                    inStockAction.StockTransactionObjectID = inTransaction.ObjectID;
                    inStockAction.StockAction = inTransaction.StockActionDetail.StockAction;
                    inStockAction.StockActionDescription = inTransaction.StockActionDetail.StockAction.ObjectDef.DisplayText;
                    inStockAction.FirstInStockAction = firstInStockAction;
                }
            }
            this.Material.ReadOnly = true;
            this.cmdGetRestAmountTrx.ReadOnly = true;
#endregion ExpirationDateCorrectionNewForm_cmdGetRestAmountTrx_Click
        }
    }
}