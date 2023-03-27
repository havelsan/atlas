
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
    /// E1 Çizelgesi Periyot
    /// </summary>
    public partial class E1DateEntryForm : TTForm
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
#region E1DateEntryForm_PreScript
    base.PreScript();
            TTDateTimePicker startDate = ((TTDateTimePicker)this.StartDate);
            TTDateTimePicker endDate = ((TTDateTimePicker)this.EndDate);
#endregion E1DateEntryForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region E1DateEntryForm_PostScript
    base.PostScript(transDef);
            stockCollectedTrxList = new ArrayList();
            StockTransactionDefinition stockTransactionDefinition = null;
            TTObjectContext objectContext = new TTObjectContext(false);
            stockTransactionDefinition= (StockTransactionDefinition)objectContext.GetObject(new Guid(_E1.ObjectDef.Attributes["STOCKOUTTRANSACTIONATTRIBUTE"].Parameters["stockTransactionDef"].Value.ToString()), "STOCKTRANSACTIONDEFINITION");
            BindingList<StockTransactionCollectedDefinition> stockTransactionCollectedDefinitions = StockTransactionCollectedDefinition.GetStockTransactionCollectedDefinition(_E1.ObjectContext);
            if (stockTransactionCollectedDefinitions != null)
            {
                //foreach (StockTransactionCollectedDefinition stockTransactionCollectedDefinition in stockTransactionCollectedDefinitions)
                //{
                //    if (stockTransactionCollectedDefinition.StockTransactionDefinition.ObjectID == stockTransactionDefinition.ObjectID)
                //    {
                //        BindingList<StockTransaction> stockTransactions = StockTransaction.GetStockTransactionToProductionConsumption(_E1.ObjectContext, stockTransactionCollectedDefinition.CheckedStockTransactionDef.ObjectID.ToString(),(DateTime)_E1.StartDate, (DateTime)_E1.EndDate);
                //        List<string> classesList = new List<string>();
                //        if (stockTransactions.Count > 0)
                //        {
                //            for (int i = 0; i < stockTransactions.Count; i++)
                //            {
                //                classesList.Add (((StockTransaction)stockTransactions[i]).ObjectID.ToString());
                //            }

                //            BindingList<StockCollectedTrx> stockCollectedTrxs = StockCollectedTrx.GetStockCollectedTrx(_E1.ObjectContext, classesList.ToArray());
                //            if (stockCollectedTrxs.Count > 0)
                //            {
                //                foreach (StockCollectedTrx stockCollTrx in stockCollectedTrxs)
                //                {
                //                    if (!stockTransactions.Contains(stockCollTrx.StockTransaction))
                //                    {
                //                        foreach (StockTransaction stockTransaction in stockTransactions)
                //                        {

                //                            StockCollectedTrx stockCollectedTrx = new StockCollectedTrx(_E1.ObjectContext);
                //                            stockCollectedTrx.StockTransaction = stockTransaction;
                //                            stockCollectedTrx.StockActionDetail = stockTransaction.StockActionDetail;
                //                            stockCollectedTrxList.Add(stockCollectedTrx);
                //                        }
                //                    }
                //                }
                //            }
                //            else
                //            {
                //                foreach (StockTransaction stockTransaction in stockTransactions)
                //                {
                //                    StockCollectedTrx stockCollectedTrx = new StockCollectedTrx(_E1.ObjectContext);
                //                    stockCollectedTrx.StockTransaction = stockTransaction;
                //                    stockCollectedTrx.StockActionDetail = stockTransaction.StockActionDetail;
                //                    stockCollectedTrxList.Add(stockCollectedTrx);
                //                }
                //            }
                //        }
                //    }
                //}
            }
#endregion E1DateEntryForm_PostScript

            }
            
#region E1DateEntryForm_Methods
        public  ArrayList stockCollectedTrxList;
        
#endregion E1DateEntryForm_Methods
    }
}