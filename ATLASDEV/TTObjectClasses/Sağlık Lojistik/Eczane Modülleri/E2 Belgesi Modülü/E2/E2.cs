
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


namespace TTObjectClasses
{
    /// <summary>
    /// E2 Belgesi
    /// </summary>
    public  partial class E2 : StockAction, IStockConsumptionTransaction, IAutoDocumentNumber
    {
        public partial class GetE2ReportQuery_Class : TTReportNqlObject 
        {
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PreTransition_Completed2Cancelled
            
            foreach (StockActionDetail stockActionDetail in StockActionDetails)
                stockActionDetail.Status = StockActionDetailStatusEnum.Cancelled;

#endregion PreTransition_Completed2Cancelled
        }

#region Methods
        public void FillE2Material()
        {
            StockTransactionDefinition stockTransactionDefinition = (StockTransactionDefinition)ObjectContext.GetObject(new Guid(ObjectDef.Attributes["STOCKCONSUMPTIONTRANSACTIONATTRIBUTE"].Parameters["stockTransactionDef"].Value.ToString()), "STOCKTRANSACTIONDEFINITION");
            List<StockTransaction> stockTransactions = stockTransactionDefinition.CollectStockTransactions((DateTime)StartDate, (DateTime)EndDate, Store);
            if (stockTransactions != null)
            {
                foreach (StockTransaction stockTransaction in stockTransactions)
                {
                    IList existDetails = E2Materials.Select("MATERIAL = " + ConnectionManager.GuidToString(stockTransaction.Stock.Material.ObjectID));
                    E2Material e2Material;
                    if (existDetails.Count > 0)
                    {
                        e2Material = (E2Material)existDetails[0];
                        e2Material.Amount += stockTransaction.Amount;
                    }
                    else
                    {
                        e2Material = E2Materials.AddNew();
                        e2Material.Amount = stockTransaction.Amount;
                        e2Material.Material = stockTransaction.Stock.Material;
                        e2Material.StockLevelType = stockTransaction.StockLevelType;
                        e2Material.Material.StockCard.DistributionType = stockTransaction.Stock.Material.StockCard.DistributionType;
                    }
                    if (e2Material == null)
                    {
                        string message = SystemMessage.GetMessage(128);
                        throw new TTException(message);
                    }
                    StockCollectedTrx stockCollectedTrx = e2Material.StockCollectedTrxs.AddNew();
                    stockCollectedTrx.StockTransaction = stockTransaction;
                }
            }
        }
        #region IStockConsumptionTransaction Members
        public StockActionDetailOut.ChildStockActionDetailOutCollection GetStockActionOutDetails()
        {
            return StockActionOutDetails;
        }
        #endregion

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(E2).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == E2.States.Completed && toState == E2.States.Cancelled)
                PreTransition_Completed2Cancelled();
        }


    }
}