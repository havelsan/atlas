
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
    /// Yılsonu Devir İşlemi
    /// </summary>
    public partial class StockCensus : BaseAction, IWorkListBaseAction
    {
        public partial class GetStockCensusSKHReport_Class : TTReportNqlObject
        {
        }

        public partial class GetCensusScheduleReportQuery2_Class : TTReportNqlObject
        {
        }

        public partial class GetCensusScheduleReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetStockCensus_Class : TTReportNqlObject
        {
        }

        protected void PostTransition_Approval2Completed()
        {
            // From State : Approval   To State : Completed
            #region PostTransition_Approval2Completed


            foreach (StockCensusDetail detail in StockCensusDetails)
            {
                Stock stock = detail.Stock;

                if (stock.TotalIn - detail.TotalIn < 0)
                {
                    stock.TotalIn = 0;
                }
                else
                {
                    stock.TotalIn = stock.TotalIn - detail.TotalIn;
                }

                if (stock.TotalInPrice - detail.TotalInPrice < 0)
                {
                    stock.TotalInPrice = 0;
                }
                else
                {
                    stock.TotalInPrice = stock.TotalInPrice - detail.TotalInPrice;
                }

                if (stock.TotalOut - detail.TotalOut < 0)
                {
                    stock.TotalOut = 0;
                }
                else
                {
                    stock.TotalOut = stock.TotalOut - detail.TotalOut;
                }

                if (stock.TotalOutPrice - detail.TotalOutPrice < 0)
                {
                    stock.TotalOutPrice = 0;
                }
                else
                {
                    stock.TotalOutPrice = stock.TotalOutPrice - detail.TotalOutPrice;
                }
            }

            foreach (MkysCensusSyncData syncData in MkysCensusSyncDatas)
            {
                StockTransaction trx = (StockTransaction)ObjectContext.GetObject((Guid)syncData.StockTransactionGuid, typeof(StockTransaction));
                trx.MKYS_StokHareketID = syncData.YeniStokHareketId;
                trx.UnitPrice = syncData.YeniBirimFiyat;
            }

            AccountingTerm term = AccountingTerm;
            term.Status = AccountingTermStatusEnum.Close;


            #endregion PostTransition_Approval2Completed
        }

        protected void PreTransition_Completed2Canceled()
        {
            // From State : Completed   To State : Canceled
            #region PreTransition_Completed2Canceled

            if (AccountingTerm.Status == AccountingTermStatusEnum.Close)
            {
                AccountingTerm term = Store.Accountancy.GetHalfOpenAccountingTerm();
                if (term == null)
                {
                    AccountingTerm.Status = AccountingTermStatusEnum.HalfOpen;
                }
                else
                {
                    throw new TTUtils.TTException(SystemMessage.GetMessage(1216));
                }
            }

            foreach (StockCensusDetail detail in StockCensusDetails)
            {
                Stock stock = detail.Stock;
                stock.TotalIn = stock.TotalIn + detail.TotalIn;
                stock.TotalInPrice = stock.TotalInPrice + detail.TotalInPrice;
                stock.TotalOut = stock.TotalOut + detail.TotalOut;
                stock.TotalOutPrice = stock.TotalOutPrice + detail.TotalOutPrice;
                detail.StockCensusLevels.DeleteChildren();
            }

            foreach (MkysCensusSyncData syncData in MkysCensusSyncDatas)
            {
                StockTransaction trx = (StockTransaction)ObjectContext.GetObject((Guid)syncData.StockTransactionGuid, typeof(StockTransaction));
                trx.MKYS_StokHareketID = syncData.EskiStokHareketId;
                trx.UnitPrice = syncData.EskiBirimFiyat;
            }

            StockCensusDetails.DeleteChildren();





            #endregion PreTransition_Completed2Canceled
        }

        protected void PreTransition_New2Approval()
        {
            // From State : New   To State : Approval
            #region PreTransition_New2Approval


            //AccountingTerm prevTerm = this.AccountingTerm.PrevTerm;
            //StockCensus pStockCensus = null;
            //if (prevTerm != null)
            //{
            //    IList prevStockCensus = this.ObjectContext.QueryObjects("STOCKCENSUS", "STORE = " + ConnectionManager.GuidToString(this.Store.ObjectID) + "AND ACCOUNTINGTERM =" + ConnectionManager.GuidToString(prevTerm.ObjectID) + " AND CARDDRAWER =" + ConnectionManager.GuidToString(this.CardDrawer.ObjectID));
            //    foreach (StockCensus sc in prevStockCensus)
            //    {
            //        if (sc.CurrentStateDefID == StockCensus.States.Completed)
            //            pStockCensus = sc;
            //    }

            //    this.MaterialOldCensus = pStockCensus.MaterialCensus;
            //    this.ZeroOldCensus = pStockCensus.ZeroCensus;
            //}

            #endregion PreTransition_New2Approval
        }

        #region Methods
        /// <summary>
        /// Stokkartın altsınıflarını dönderir.
        /// </summary>
        /// <param name="stockCardClass"></param>
        /// <param name="list"></param>
        /// <returns></returns>

        public static ArrayList GetChildClass(StockCardClass stockCardClass, ArrayList list)
        {
            list.Add(stockCardClass.ObjectID.ToString());
            if (stockCardClass.StockCardClasses.Count > 0)
            {
                foreach (StockCardClass child in stockCardClass.StockCardClasses)
                {
                    if (child.StockCardClasses.Count > 0)
                    {
                        StockCensus.GetChildClass(child, list);
                    }
                    else
                    {
                        list.Add(child.ObjectID.ToString());
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Deponun stok kartı masalarını dönderir.
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public Dictionary<Guid, ResCardDrawer> GetCardDrawers(Store store)
        {
            IList stocks = Stock.GetStockForStoreStockCard(ObjectContext, store.ObjectID.ToString());
            Dictionary<Guid, ResCardDrawer> cardDrawers = new Dictionary<Guid, ResCardDrawer>();
            for (int i = 0; i < stocks.Count; i++)
            {
                IList accountancyStockCard = ((Stock)stocks[i]).Material.StockCard.AccountancyStockCards.Select("ACCOUNTANCY = " + ConnectionManager.GuidToString(((MainStoreDefinition)store).Accountancy.ObjectID));
                ResCardDrawer resCardDrawer = ((AccountancyStockCard)accountancyStockCard[0]).CardDrawer;
                if (!cardDrawers.ContainsKey(resCardDrawer.ObjectID))
                {
                    cardDrawers.Add(resCardDrawer.ObjectID, resCardDrawer);
                }
            }
            return cardDrawers;
        }

        /// <summary>
        /// Çift sıfırlı kartları dönderir.
        /// </summary>
        /// <param name="mainStore"></param>
        /// <param name="term"></param>
        /// <param name="cardDrawer"></param>
        /// <returns></returns>
        public DoubleZeroCardEpoch GetDoubleZeroEpoch(Store mainStore, AccountingTerm term, ResCardDrawer cardDrawer)
        {
            DoubleZeroCardEpoch doubleZeroCardEpoch = null;
            TTObjectContext context = new TTObjectContext(true);
            IList doubleZeroCardEpochList = DoubleZeroCardEpoch.GetDoubleZeroByStoreAndTerm(context, mainStore.ObjectID, term.ObjectID);
            foreach (DoubleZeroCardEpoch dz in doubleZeroCardEpochList)
            {
                if (dz.CardDrawer.ObjectID.Equals(cardDrawer.ObjectID))
                {
                    if (dz.CurrentStateDefID != DoubleZeroCardEpoch.States.Cancelled)
                        doubleZeroCardEpoch = dz;
                }
            }
            return doubleZeroCardEpoch;
        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(StockCensus).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == StockCensus.States.Completed && toState == StockCensus.States.Canceled)
                PreTransition_Completed2Canceled();
            else if (fromState == StockCensus.States.New && toState == StockCensus.States.Approval)
                PreTransition_New2Approval();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(StockCensus).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == StockCensus.States.Approval && toState == StockCensus.States.Completed)
                PostTransition_Approval2Completed();
        }

    }
}