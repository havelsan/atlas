
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
    /// Birim Fiyat Değiştirme
    /// </summary>
    public  partial class StockTrxUpdateAction : BaseAction, IWorkListBaseAction
    {
        protected void PostTransition_Approval2Completed()
        {
            // From State : Approval   To State : Completed
#region PostTransition_Approval2Completed
            
            
            
            
            
            foreach(StockTrxUpdateActionDetail stockTrxUpdateActionDetail in StockTrxUpdateActionDetails)
            {
                if(stockTrxUpdateActionDetail.StockTransaction.CurrentStateDefID != StockTransaction.States.Cancelled)
                {
                    stockTrxUpdateActionDetail.StockTransaction.UnitPrice = stockTrxUpdateActionDetail.NewUnitPrice;
                    
                    if (stockTrxUpdateActionDetail.StockTransaction.StockActionDetail is ChattelDocumentInputDetailWithAccountancy && ((ChattelDocumentInputDetailWithAccountancy)stockTrxUpdateActionDetail.StockTransaction.StockActionDetail).SentAmount == null)
                        ((ChattelDocumentInputDetailWithAccountancy)stockTrxUpdateActionDetail.StockTransaction.StockActionDetail).SentAmount = 0;
                    
                    if (stockTrxUpdateActionDetail.StockTransaction.StockActionDetail is StockActionDetailIn)
                        ((StockActionDetailIn)stockTrxUpdateActionDetail.StockTransaction.StockActionDetail).UnitPrice = stockTrxUpdateActionDetail.NewUnitPrice;
                }
                
                Dictionary<Guid, StockTransaction> allTrx = new Dictionary<Guid, StockTransaction>();
                allTrx = StockTrxUpdateAction.FindStockTransactionAllTrx(stockTrxUpdateActionDetail.StockTransaction, allTrx);
                foreach (KeyValuePair<Guid, StockTransaction> trx in allTrx)
                {
                    if(trx.Value.CurrentStateDefID != StockTransaction.States.Cancelled)
                    {
                        trx.Value.UnitPrice = stockTrxUpdateActionDetail.NewUnitPrice;
                        TrxStockPriceUpdate(trx.Value, false);
                        TTObjectContext readOnlyContext = new TTObjectContext(true);
                        IList colletedTrxs = ObjectContext.QueryObjects("STOCKCOLLECTEDTRX", "STOCKTRANSACTION =" + ConnectionManager.GuidToString(trx.Value.ObjectID));
                        if (colletedTrxs.Count > 0)
                        {
                            foreach (StockCollectedTrx colletedTrx in colletedTrxs)
                            {
                                foreach (StockTransaction siibTrx in colletedTrx.StockActionDetail.StockTransactions.Select(string.Empty))
                                {
                                    siibTrx.UnitPrice = stockTrxUpdateActionDetail.NewUnitPrice;
                                    TrxStockPriceUpdate(siibTrx, false);
                                }
                            }
                        }
                    }
                }
            }

#endregion PostTransition_Approval2Completed
        }

        protected void PreTransition_Completed2Canceled()
        {
            // From State : Completed   To State : Canceled
#region PreTransition_Completed2Canceled
            
            foreach(StockTrxUpdateActionDetail stockTrxUpdateActionDetail in StockTrxUpdateActionDetails)
            {
                stockTrxUpdateActionDetail.StockTransaction.UnitPrice = stockTrxUpdateActionDetail.OldUnitPrice;
            }
#endregion PreTransition_Completed2Canceled
        }

#region Methods
        public static Dictionary<Guid,StockTransaction> FindAllIntransaction(StockTransaction inTrx, Dictionary<Guid, StockTransaction> intransaction)
        {
            if (intransaction.ContainsKey(inTrx.ObjectID) == false)
            {
                intransaction.Add(inTrx.ObjectID, inTrx);
            }
            if (inTrx.StockTransactionDetails.Count > 0)
            {
                foreach (StockTransactionDetail outTrx in inTrx.StockTransactionDetails.Select(string.Empty))
                {
                    foreach (StockTransaction outInTrx in outTrx.OutStockTransaction.StockActionDetail.StockTransactions.Select("INOUT = 1"))
                    {
                        if (intransaction.ContainsKey(outInTrx.ObjectID) == false)
                            intransaction.Add(outInTrx.ObjectID, outInTrx);
                        if (outInTrx.StockTransactionDetails.Count > 0)
                        {
                            Dictionary<Guid, StockTransaction> findTrxs = FindAllIntransaction(outInTrx, intransaction);
                            foreach (KeyValuePair<Guid,StockTransaction>  ftrx in findTrxs)
                            {
                                if (intransaction.ContainsKey(ftrx.Key) == false)
                                    intransaction.Add(ftrx.Key, ftrx.Value);
                            }
                        }
                    }
                }
            }
            return intransaction;
        }

        public static Dictionary<Guid, StockTransaction> FindStockTransactionAllTrx (StockTransaction inTrx, Dictionary<Guid, StockTransaction> intransaction)
        {
            if(intransaction.ContainsKey(inTrx.ObjectID) == false)
                intransaction.Add(inTrx.ObjectID,inTrx);
            foreach (StockTransactionDetail trxDetail in inTrx.StockTransactionDetails)
            {
                if (intransaction.ContainsKey(trxDetail.OutStockTransaction.ObjectID) == false)
                    intransaction.Add(trxDetail.OutStockTransaction.ObjectID, trxDetail.OutStockTransaction);
            }
            return intransaction;
        }
        
        public void TrxStockPriceUpdate(StockTransaction stockTransaction, bool cancelled)
        {
            if (stockTransaction.Amount.HasValue == false || stockTransaction.Amount.Value == 0)
                throw new TTException(TTUtils.CultureService.GetText("M26947", "Stok değerleri 0 ile güncellenemez."));

            switch (stockTransaction.MaintainLevelCode)
            {
                case MaintainLevelCodeEnum.IncreaseInheld:
                    if (cancelled)
                    {
                        stockTransaction.Stock.TotalInPrice -= (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    else
                    {
                        stockTransaction.Stock.TotalInPrice += (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    break;
                case MaintainLevelCodeEnum.DecreaseInheld:
                    if (cancelled)
                    {
                        stockTransaction.Stock.TotalOutPrice -= (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    else
                    {
                        stockTransaction.Stock.TotalOutPrice += (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    break;
                case MaintainLevelCodeEnum.IncreaseConsigned:
                    if (cancelled)
                    {
                        stockTransaction.Stock.TotalInPrice -= (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    else
                    {
                        stockTransaction.Stock.TotalInPrice += (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    break;
                case MaintainLevelCodeEnum.DecreaseConsigned:
                    if (cancelled)
                    {
                        stockTransaction.Stock.TotalOutPrice -= (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    else
                    {
                        stockTransaction.Stock.TotalOutPrice += (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    break;
                case MaintainLevelCodeEnum.IncreaseInheld__DecreaseConsigned:
                    break;
                case MaintainLevelCodeEnum.DecreaseInheld__IncreaseConsigned:
                    break;
                case MaintainLevelCodeEnum.ReturnInheld:
                    if (cancelled)
                    {
                        stockTransaction.Stock.TotalInPrice += (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    else
                    {
                        stockTransaction.Stock.TotalInPrice -= (BigCurrency)stockTransaction.Amount * stockTransaction.UnitPrice;
                    }
                    break;
                default:
                    throw new TTException(TTUtils.CultureService.GetText("M25902", "Hatalı işlem kodu!"));
            }
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(StockTrxUpdateAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == StockTrxUpdateAction.States.Completed && toState == StockTrxUpdateAction.States.Canceled)
                PreTransition_Completed2Canceled();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(StockTrxUpdateAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == StockTrxUpdateAction.States.Approval && toState == StockTrxUpdateAction.States.Completed)
                PostTransition_Approval2Completed();
        }

    }
}