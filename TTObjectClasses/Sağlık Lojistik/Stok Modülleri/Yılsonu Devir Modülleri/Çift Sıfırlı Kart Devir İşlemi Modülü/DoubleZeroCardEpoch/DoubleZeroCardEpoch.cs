
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
    /// Çift Sıfırlı Kartlar Devir Belgesi
    /// </summary>
    public  partial class DoubleZeroCardEpoch : BaseAction, IWorkListBaseAction
    {
        public partial class GetDoubleZeroCardCensusReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetOldOrderNoQuery_Class : TTReportNqlObject 
        {
        }

        protected void PostTransition_Approval2Completed()
        {
            // From State : Approval   To State : Completed
#region PostTransition_Approval2Completed
            
            
            
            
            Dictionary<Guid , object> stockCards = new Dictionary<Guid , object>();
            foreach (DoubleZeroCardEpochMaterial card in DoubleZeroCardEpochMaterials)
            {
                if (stockCards.ContainsKey(card.StockCard.ObjectID) == false)
                {
                    stockCards.Add(card.StockCard.ObjectID, card.StockCard);
                }
            }

            foreach (KeyValuePair<Guid, object> zeroCard in stockCards)
            {
                IList accountancyStockCard = ((StockCard)zeroCard.Value).AccountancyStockCards.Select("CARDDRAWER = " + ConnectionManager.GuidToString(CardDrawer.ObjectID));
                AccountancyStockCard aStockcard = null;
                if (accountancyStockCard.Count == 1)
                {
                    aStockcard = (AccountancyStockCard)accountancyStockCard[0];
                }
                else
                {
                    throw new Exception(SystemMessage.GetMessage(1146));
                }
                if (aStockcard.Status != StockCardStatusEnum.DoubleZeroCard)
                {
                    aStockcard.Status = StockCardStatusEnum.DoubleZeroCard;
                }
            }

#endregion PostTransition_Approval2Completed
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PreTransition_Completed2Cancelled
            

            bool cancelled = true;
            IList stockCensus = ObjectContext.QueryObjects("STOCKCENSUS", "ACCOUNTINGTERM =" + ConnectionManager.GuidToString(Term.ObjectID) + " AND CARDDRAWER =" + ConnectionManager.GuidToString(CardDrawer.ObjectID));
            foreach (StockCensus census in stockCensus)
            {
                if (census.CurrentStateDefID != StockCensus.States.Canceled)
                    cancelled = false;
            }

            if (cancelled)
            {
                Dictionary<StockCard, StockCardStatusEnum> stockCards = new Dictionary<StockCard, StockCardStatusEnum>();
                foreach (DoubleZeroCardEpochMaterial doubleZeroCardEpochMaterial in DoubleZeroCardEpochMaterials)
                {
                    if (stockCards.ContainsKey(doubleZeroCardEpochMaterial.StockCard) == false)
                    {
                        stockCards.Add(doubleZeroCardEpochMaterial.StockCard, (StockCardStatusEnum)doubleZeroCardEpochMaterial.OldStockCardStatus);
                    }
                }

                foreach (KeyValuePair<StockCard, StockCardStatusEnum> zeroCard in stockCards)
                {
                    IList accountancyStockCard = ((StockCard)zeroCard.Key).AccountancyStockCards.Select("CARDDRAWER = " + ConnectionManager.GuidToString(CardDrawer.ObjectID));
                    AccountancyStockCard aStockcard = null;
                    if (accountancyStockCard.Count == 1)
                    {
                        aStockcard = (AccountancyStockCard)accountancyStockCard[0];
                    }
                    else
                    {
                        throw new Exception(SystemMessage.GetMessage(1146));
                    }
                    if (aStockcard.Status == StockCardStatusEnum.DoubleZeroCard)
                    {
                        aStockcard.Status = zeroCard.Value;
                    }
                }
            }
            else
                throw new TTException(TTUtils.CultureService.GetText("M25383", "Çift sıfırlı kart devrini iptal edebilmeniz için önce yılsonu devrini iptal etmeniz gerekir.")); 

#endregion PreTransition_Completed2Cancelled
        }

#region Methods
        public Dictionary<Guid, ResCardDrawer> GetCardDrawers(Store store)
        {
            IList stocks = Stock.GetStockForStoreStockCard(ObjectContext, store.ObjectID.ToString());
            Dictionary<Guid, ResCardDrawer> cardDrawers = new Dictionary<Guid, ResCardDrawer>();
            for (int i = 0; i < stocks.Count; i++)
            {
                IList accountancyStockCard = ((Stock)stocks[i]).Material.StockCard.AccountancyStockCards.Select ("ACCOUNTANCY = " + ConnectionManager.GuidToString(((MainStoreDefinition)store).Accountancy.ObjectID));
                ResCardDrawer resCardDrawer = ((AccountancyStockCard)accountancyStockCard[0]).CardDrawer;
                if (!cardDrawers.ContainsKey(resCardDrawer.ObjectID))
                {
                    cardDrawers.Add(resCardDrawer.ObjectID, resCardDrawer);
                }
            }
            return cardDrawers;
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DoubleZeroCardEpoch).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DoubleZeroCardEpoch.States.Completed && toState == DoubleZeroCardEpoch.States.Cancelled)
                PreTransition_Completed2Cancelled();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DoubleZeroCardEpoch).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DoubleZeroCardEpoch.States.Approval && toState == DoubleZeroCardEpoch.States.Completed)
                PostTransition_Approval2Completed();
        }

    }
}