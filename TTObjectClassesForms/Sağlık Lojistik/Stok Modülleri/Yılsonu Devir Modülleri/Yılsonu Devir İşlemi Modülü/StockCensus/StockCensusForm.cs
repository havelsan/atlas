
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
    /// Yılsonu Devir İşlemi
    /// </summary>
    public partial class StockCensusForm : TTForm
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
#region StockCensusForm_PreScript
    base.PreScript();
#endregion StockCensusForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region StockCensusForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            MainStoreDefinition mainStore = null;
            AccountingTerm term = null;
            
            if (_StockCensus.Store != null)
                mainStore = _StockCensus.Store;
            else
                mainStore = CommonForm.SelectResourceDependentMainStoreDefinition(this);
            
            if (mainStore == null)
                throw new Exception(SystemMessage.GetMessage(713));

            if (_StockCensus.AccountingTerm != null)
                term = _StockCensus.AccountingTerm;
            else
                term = mainStore.Accountancy.GetHalfOpenAccountingTerm();

            if (term == null)
                throw new TTException(SystemMessage.GetMessage(1149));

            AccountingTerm previousTerm = term.PrevTerm ;

            string continueStockActionString = "";
            IList unCompletedStockActions = StockAction.GetStockActionByTerm(_StockCensus.ObjectContext, term.ObjectID);
            if (unCompletedStockActions.Count == 0)
            {
                _StockCensus.Store = mainStore;
                _StockCensus.AccountingTerm = term;
                ResCardDrawer resCardDrawer;
                if (_StockCensus.CardDrawer == null)
                {
                    MultiSelectForm multiSelectForm = new MultiSelectForm();

                    IList cardDrawers = _StockCensus.ObjectContext.QueryObjects("RESCARDDRAWER", string.Empty);
                    foreach (ResCardDrawer cardDrawer in cardDrawers)
                    {
                        bool rcd = false;
                        TTObjectContext context = new TTObjectContext(true);
                        IList stockCensuses = StockCensus.GetStockCencusByStoreAndTerm(context, mainStore.ObjectID, term.ObjectID);

                        foreach (StockCensus stockCensus in stockCensuses)
                        {
                            if (stockCensus.CurrentStateDefID != StockCensus.States.Canceled)
                                if (cardDrawer.ObjectID == stockCensus.CardDrawer.ObjectID)
                                rcd = true;
                        }

                        if (rcd == false)
                            multiSelectForm.AddMSItem(cardDrawer.Name, cardDrawer.Name, cardDrawer);
                    }
                    string key = multiSelectForm.GetMSItem(ParentForm, "İşlem yapacağınız masayı seçin");

                    if (string.IsNullOrEmpty(key))
                        throw new Exception(SystemMessage.GetMessage(1147));

                    resCardDrawer = multiSelectForm.MSSelectedItemObject as ResCardDrawer;
                    _StockCensus.CardDrawer = resCardDrawer;
                }
                else
                    resCardDrawer = _StockCensus.CardDrawer;

                DoubleZeroCardEpoch doubleZeroCardEpoch = (DoubleZeroCardEpoch)_StockCensus.GetDoubleZeroEpoch(mainStore, term, resCardDrawer);
                if (doubleZeroCardEpoch == null)
                    throw new Exception(SystemMessage.GetMessageV3(1217, new string[] { mainStore.Name.ToString(), resCardDrawer.Name.ToString()}));


                if (doubleZeroCardEpoch.CurrentStateDefID != DoubleZeroCardEpoch.States.Completed)
                    throw new Exception(SystemMessage.GetMessageV3(1218, new string[] { doubleZeroCardEpoch.ID.ToString(), doubleZeroCardEpoch.CurrentStateDef.DisplayText.ToString() }));

                TTObjectContext objectContext = new TTObjectContext(true);
                IList stocks = TTObjectClasses.Stock.GetStockByCardDrawer(objectContext, mainStore.ObjectID.ToString(), resCardDrawer.ObjectID.ToString());
                Dictionary<Guid, object> stockCards = new Dictionary<Guid, object>();

                System.Threading.Thread newThread = new System.Threading.Thread(ProgressFormControl.Show);
                newThread.Start(resCardDrawer.Name + " masası için yıl sonu devri yapılıyor...");
                List<System.Threading.Thread> ThreadList = new List<System.Threading.Thread>();
                List<StockCensusDetail> censusDetails = new List<StockCensusDetail>();
                long newOrderNo = 0;
                bool err = false;
                string errmsg = string.Empty;

                foreach (Stock cencusStock in stocks)
                {
                    if (cencusStock.CreationDate < ((DateTime)term.EndDate).AddDays(1))
                    {
                        ProgressFormControl.FormText = cencusStock.Material.Name;
                        //Application.DoEvents();
                        if (newThread.IsAlive == false)
                            throw new Exception(SystemMessage.GetMessage(969));

                        double prevYearCensus = 0;
                        IList accountancyStockCard = cencusStock.Material.StockCard.AccountancyStockCards.Select("CARDDRAWER = " + ConnectionManager.GuidToString(resCardDrawer.ObjectID));
                        AccountancyStockCard aStockcard = null;
                        if (accountancyStockCard.Count > 0)
                        {
                            aStockcard = (AccountancyStockCard)accountancyStockCard[0];
                        }
                        else
                        {
                            throw new Exception(SystemMessage.GetMessage(1146));
                        }
                        if (aStockcard.Status != StockCardStatusEnum.AccordionCard && aStockcard.Status != StockCardStatusEnum.DoubleZeroCard && aStockcard.Status != StockCardStatusEnum.CancelledCard)
                        {
                            if (stockCards.ContainsKey(cencusStock.Material.StockCard.ObjectID) == false)
                            {
                                stockCards.Add(cencusStock.Material.StockCard.ObjectID, cencusStock.Material.StockCard);
                                newOrderNo++;
                            }

                            StockCensusDetail stockCensusDetail = new StockCensusDetail(_StockCensus.ObjectContext);
                            stockCensusDetail.AccountingTerm = _StockCensus.AccountingTerm;
                            stockCensusDetail.StockCard = cencusStock.Material.StockCard;
                            stockCensusDetail.OldStockCardStatus = aStockcard.Status;
                            stockCensusDetail.OldCardOrderNo = aStockcard.CardOrderNO;

                            TTObjectContext stockcenObjectContextReadOnly = new TTObjectContext(true);
                            TTObjectContext stockcenObjectContex = new TTObjectContext(false);

                            Stock stockcen = new Stock(stockcenObjectContex, cencusStock.Store, cencusStock.Material);

                            Currency prevTotalIn = 0;
                            Currency prevTotalInPrice = 0;
                            Currency prevTotalOut = 0;
                            Currency prevTotalOutPrice = 0;
                            if (previousTerm != null)
                            {
                                IBindingList prevCensusDetail = StockCensusDetail.GetCensusDetail(stockcenObjectContextReadOnly, previousTerm.ObjectID, cencusStock.ObjectID);
                                if (prevCensusDetail.Count > 0)
                                {
                                    prevYearCensus = (double)((StockCensusDetail)prevCensusDetail[0]).TotalInHeld;
                                    stockcen.Inheld = ((StockCensusDetail)prevCensusDetail[0]).Inheld;
                                    stockcen.Consigned = ((StockCensusDetail)prevCensusDetail[0]).Consigned;
                                    stockcen.TotalIn = ((StockCensusDetail)prevCensusDetail[0]).TotalIn;
                                    stockcen.TotalInPrice = ((StockCensusDetail)prevCensusDetail[0]).TotalInPrice;
                                    stockcen.TotalOut = ((StockCensusDetail)prevCensusDetail[0]).TotalOut;
                                    stockcen.TotalOutPrice = ((StockCensusDetail)prevCensusDetail[0]).TotalOutPrice;
                                    foreach (StockCensusLevel cLevel in ((StockCensusDetail)prevCensusDetail[0]).StockCensusLevels)
                                    {
                                        StockLevel level = new StockLevel(stockcenObjectContex);
                                        level.Amount = cLevel.Amount;
                                        level.StockLevelType = cLevel.StockLevelType;
                                        level.Stock = stockcen;
                                    }
                                    prevTotalIn = (Currency)((StockCensusDetail)prevCensusDetail[0]).TotalIn;
                                    prevTotalInPrice = (Currency)((StockCensusDetail)prevCensusDetail[0]).TotalInPrice;
                                    prevTotalOut = (Currency)((StockCensusDetail)prevCensusDetail[0]).TotalOut;
                                    prevTotalOutPrice = (Currency)((StockCensusDetail)prevCensusDetail[0]).TotalOutPrice;
                                }
                            }

                            IList stockTransactions = StockTransaction.GetStockTransactionsByStockAccountingTerm(stockcenObjectContextReadOnly, cencusStock.ObjectID, term.ObjectID);
                            foreach (StockTransaction stockTransaction in stockTransactions)
                            {
                                try
                                {
                                    stockcen.StockFieldsUpdate(stockTransaction, false, true);
                                }
                                catch (Exception ex)
                                {
                                    err = true;
                                    errmsg = errmsg + stockcen.Material.StockCard.NATOStockNO + " " + stockcen.Material.Name + " " + ex.ToString() + "\r\n";
                                }

                            }


                            stockCensusDetail.Stock = cencusStock;
                            stockCensusDetail.Consigned = stockcen.Consigned;
                            stockCensusDetail.CardOrderNo = newOrderNo;
                            stockCensusDetail.TotalIn = stockcen.TotalIn - prevTotalIn;
                            stockCensusDetail.TotalOut = stockcen.TotalOut - prevTotalOut;
                            stockCensusDetail.TotalInPrice = stockcen.TotalInPrice - prevTotalInPrice;
                            stockCensusDetail.TotalOutPrice = stockcen.TotalOutPrice - prevTotalOutPrice;
                            stockCensusDetail.Inheld = stockcen.Inheld;
                            stockCensusDetail.TotalInHeld = stockcen.Inheld + stockcen.Consigned;
                            stockCensusDetail.YearCensus = prevYearCensus;
                            stockCensusDetail.Used = 0;
                            foreach (StockLevel levels in stockcen.StockLevels)
                            {
                                if (levels.StockLevelType.StockLevelTypeStatus == StockLevelTypeEnum.New)
                                {
                                    StockCensusLevel censusLevel = null;
                                    censusLevel = new StockCensusLevel(_StockCensus.ObjectContext);
                                    censusLevel.Amount = levels.Amount;
                                    censusLevel.StockLevelType = StockLevelType.NewStockLevel;
                                    censusLevel.StockCensusDetail = stockCensusDetail;
                                }
                                if (levels.StockLevelType.StockLevelTypeStatus == StockLevelTypeEnum.Used)
                                {
                                    StockCensusLevel censusLevel = null;
                                    censusLevel = new StockCensusLevel(_StockCensus.ObjectContext);
                                    censusLevel.Amount = levels.Amount;
                                    censusLevel.StockLevelType = StockLevelType.UsedStockLevel;
                                    censusLevel.StockCensusDetail = stockCensusDetail;
                                    stockCensusDetail.Used = levels.Amount;
                                }
                                if (levels.StockLevelType.StockLevelTypeStatus == StockLevelTypeEnum.Hek)
                                {
                                    StockCensusLevel censusLevel = null;
                                    censusLevel = new StockCensusLevel(_StockCensus.ObjectContext);
                                    censusLevel.Amount = levels.Amount;
                                    censusLevel.StockLevelType = StockLevelType.HekStockLevel;
                                    censusLevel.StockCensusDetail = stockCensusDetail;
                                }
                            }
                            censusDetails.Add(stockCensusDetail);
                            stockcenObjectContextReadOnly.Dispose();
                            stockcenObjectContex.Dispose();
                        }
                    }
                }
                if (err)
                {
                    throw new TTException(errmsg);
                }

                newThread.Abort();

                foreach (StockCensusDetail censusDetail in censusDetails)
                    _StockCensus.StockCensusDetails.Add(censusDetail);


                double newCard = 0;
                double normalCard = 0;

                foreach (KeyValuePair<Guid, object> card in stockCards)
                {
                    IList accountancySCard = ((StockCard)card.Value).AccountancyStockCards.Select("CARDDRAWER = " + ConnectionManager.GuidToString(resCardDrawer.ObjectID));
                    AccountancyStockCard accStockcard = null;
                    if (accountancySCard.Count > 0)
                    {
                        accStockcard = (AccountancyStockCard)accountancySCard[0];
                    }
                    else
                    {
                        throw new Exception(SystemMessage.GetMessage(1146));
                    }
                    if (accStockcard.Status == StockCardStatusEnum.NewCard)
                        newCard++;
                    if (accStockcard.Status == StockCardStatusEnum.NormalCard)
                        normalCard++;
                }
                _StockCensus.TotalCardAmount = stockCards.Count;
                _StockCensus.NewCardAmount = (long)newCard;
                _StockCensus.NormalCardAmount = (long)normalCard;


                Dictionary<Guid, double> stockCardsAmount = new Dictionary<Guid, double>();

                double materialCencus = 0;
                double zeroCencus = 0;
                double newMaterialCencus = 0;
                double oldMaterialCencus = 0;
                double newZeroCencus = 0;
                double oldZeroCencus = 0;


                foreach (StockCensusDetail stockCensusDetail in _StockCensus.StockCensusDetails)
                {
                    if (stockCardsAmount.ContainsKey(stockCensusDetail.StockCard.ObjectID))
                    {
                        double amount = stockCardsAmount[stockCensusDetail.StockCard.ObjectID] + (double)stockCensusDetail.TotalInHeld;
                        stockCardsAmount.Remove(stockCensusDetail.StockCard.ObjectID);
                        stockCardsAmount.Add(stockCensusDetail.StockCard.ObjectID, amount);
                    }
                    else
                    {
                        stockCardsAmount.Add(stockCensusDetail.StockCard.ObjectID, (double)stockCensusDetail.TotalInHeld);
                    }
                }
                foreach (KeyValuePair<Guid, double> card in stockCardsAmount)
                {
                    TTObjectClasses.StockCard stockCardWithAmount = (StockCard)_StockCensus.ObjectContext.GetObject((Guid)card.Key, "STOCKCARD");
                    IList accSCard = stockCardWithAmount.AccountancyStockCards.Select("CARDDRAWER = " + ConnectionManager.GuidToString(resCardDrawer.ObjectID));
                    AccountancyStockCard stockCardWithAmountAcc = null;
                    if (accSCard.Count > 0)
                    {
                        stockCardWithAmountAcc = (AccountancyStockCard)accSCard[0];
                    }
                    else
                    {
                        throw new Exception(SystemMessage.GetMessage(1146));
                    }
                    if (card.Value > 0)
                    {
                        if (stockCardWithAmountAcc.Status == StockCardStatusEnum.NewCard)
                            newMaterialCencus++;
                        else if (stockCardWithAmountAcc.Status == StockCardStatusEnum.NormalCard)
                            oldMaterialCencus++;
                    }
                    else if (card.Value == 0)
                    {
                        if (stockCardWithAmountAcc.Status == StockCardStatusEnum.NewCard)
                            newZeroCencus++;
                        else if (stockCardWithAmountAcc.Status == StockCardStatusEnum.NormalCard)
                            oldZeroCencus++;
                    }
                }
                materialCencus = newMaterialCencus + oldMaterialCencus;
                zeroCencus = newZeroCencus + oldZeroCencus;
                _StockCensus.MaterialCensus = (long)materialCencus;
                _StockCensus.ZeroCensus = (long)zeroCencus;
                _StockCensus.NewMaterialCensus = (long)newMaterialCencus;
                _StockCensus.OldMaterialCensus = (long)oldMaterialCencus;
                _StockCensus.NewZeroCensus = (long)newZeroCencus;
                _StockCensus.OldZeroCensus = (long)oldZeroCencus;
            }
            else
            {
                for (int i = 0; i < unCompletedStockActions.Count; i++)
                    if (((StockAction)unCompletedStockActions[i]).CurrentStateDefID != StockAction.States.Completed || ((StockAction)unCompletedStockActions[i]).CurrentStateDefID != StockAction.States.Cancelled)
                    continueStockActionString = continueStockActionString.ToString() + ((StockAction)unCompletedStockActions[i]).StockActionID.ToString() + ",";
                throw new TTUtils.TTException(SystemMessage.GetMessageV3(1148, new string[] {continueStockActionString.ToString()}));
            }
#endregion StockCensusForm_ClientSidePreScript

        }
    }
}