
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
    /// Çift Sıfırlı Kart Devir 
    /// </summary>
    public partial class DoubleZeroCardEpochForm : TTForm
    {
        override protected void BindControlEvents()
        {
            ttbutton2.Click += new TTControlEventDelegate(ttbutton2_Click);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton2.Click -= new TTControlEventDelegate(ttbutton2_Click);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton2_Click()
        {
#region DoubleZeroCardEpochForm_ttbutton2_Click
   Guid stockCardGuid = ((Guid)((TTGrid)DoubleZeroCardEpochMaterials).SelectedRows[0].Cells["DZSTOCKCARD"].Value);
                StockCard stockCard = (StockCard)_DoubleZeroCardEpoch.ObjectContext.GetObject(stockCardGuid, "STOCKCARD");
                Dictionary<Guid, object> epochMaterials = new Dictionary<Guid, object>();
                foreach (DoubleZeroCardEpochMaterial material in _DoubleZeroCardEpoch.DoubleZeroCardEpochMaterials)
                {
                    if (material.StockCard.ObjectID == stockCard.ObjectID & material.AddedManually == true )
                    {
                        epochMaterials.Add(material.ObjectID, material);
                    }
                }
                foreach (KeyValuePair<Guid, object> epochMaterial in epochMaterials)
                {
                    _DoubleZeroCardEpoch.DoubleZeroCardEpochMaterials.Remove((DoubleZeroCardEpochMaterial)epochMaterial.Value);
                }
                StockCardClass cardClass = new StockCardClass(_DoubleZeroCardEpoch.ObjectContext);
                if (stockCard.StockCardClass.ParentStockCardClass != null)
                {
                    cardClass = stockCard.StockCardClass.ParentStockCardClass;
                }
                else
                {
                    cardClass = stockCard.StockCardClass;
                }
                foreach (DoubleZeroCardEpochMainClass mainClass in _DoubleZeroCardEpoch.DoubleZeroCardEpochMainClasses)
                {
                    if (mainClass.StockCardClass.ObjectID == cardClass.ObjectID)
                    {
                        mainClass.CardAmount--;
                        mainClass.CardCount--;
                    }
                }
#endregion DoubleZeroCardEpochForm_ttbutton2_Click
        }

        private void ttbutton1_Click()
        {
#region DoubleZeroCardEpochForm_ttbutton1_Click
   StockCard selectedCard = (StockCard)SelectedStockCard.SelectedObject;
            foreach (Material detailMaterial in selectedCard.Materials)
            {   
                IBindingList detailStock = detailMaterial.Stocks.Select("STORE = " + ConnectionManager.GuidToString(_DoubleZeroCardEpoch.Store.ObjectID));
                DoubleZeroCardEpochMaterial addedDetail = new DoubleZeroCardEpochMaterial(_DoubleZeroCardEpoch.ObjectContext);
                addedDetail.Stock = (Stock)detailStock[0];
                addedDetail.StockCard = detailMaterial.StockCard;
                addedDetail.AddedManually = true;
                _DoubleZeroCardEpoch.DoubleZeroCardEpochMaterials.Add(addedDetail);
            }
            StockCardClass cardClass = new StockCardClass(_DoubleZeroCardEpoch.ObjectContext);
            if (selectedCard.StockCardClass.ParentStockCardClass != null)
            {
                cardClass = selectedCard.StockCardClass.ParentStockCardClass;
            }
            else
            {
                cardClass = selectedCard.StockCardClass;
            }
            DoubleZeroCardEpochMainClass dzeMaterialMainClass = new DoubleZeroCardEpochMainClass(_DoubleZeroCardEpoch.ObjectContext);
            foreach (DoubleZeroCardEpochMainClass mainClass in _DoubleZeroCardEpoch.DoubleZeroCardEpochMainClasses)
            {
                if (mainClass.StockCardClass.ObjectID == cardClass.ObjectID)
                {
                    dzeMaterialMainClass = mainClass;
                }
            }
            if (dzeMaterialMainClass.StockCardClass != null)
            {
                _DoubleZeroCardEpoch.DoubleZeroCardEpochMainClasses.Remove(dzeMaterialMainClass);
                dzeMaterialMainClass.CardAmount++;
                dzeMaterialMainClass.CardCount++;
                _DoubleZeroCardEpoch.DoubleZeroCardEpochMainClasses.Add(dzeMaterialMainClass);
            }
            else
            {
                dzeMaterialMainClass.StockCardClass = cardClass;
                dzeMaterialMainClass.CardAmount = 1;
                dzeMaterialMainClass.CardCount = 1;
                _DoubleZeroCardEpoch.DoubleZeroCardEpochMainClasses.Add(dzeMaterialMainClass);
            }
#endregion DoubleZeroCardEpochForm_ttbutton1_Click
        }

        protected override void ClientSidePreScript()
        {
#region DoubleZeroCardEpochForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            MainStoreDefinition mainStore = null;
            AccountingTerm term = null;
            int totalCardCount = 0;
            if (_DoubleZeroCardEpoch.Store != null)
                mainStore = _DoubleZeroCardEpoch.Store;
            else
                mainStore = CommonForm.SelectResourceDependentMainStoreDefinition(this);

            if (mainStore == null)
                throw new Exception(SystemMessage.GetMessage(713));
            
            if (_DoubleZeroCardEpoch.Term != null)
                term = _DoubleZeroCardEpoch.Term;
            else
                term = mainStore.Accountancy.GetHalfOpenAccountingTerm();
            
            if (term != null)
            {
                string continueStockActionString = "";
                IList stockActions = StockAction.GetStockActionByTerm(_DoubleZeroCardEpoch.ObjectContext, term.ObjectID);
                if(stockActions.Count == 0)
                {
                    _DoubleZeroCardEpoch.Store = mainStore;
                    _DoubleZeroCardEpoch.Term = term;

                    ResCardDrawer resCardDrawer;
                    if (_DoubleZeroCardEpoch.CardDrawer == null)
                    {
                        MultiSelectForm multiSelectForm = new MultiSelectForm();


                        IList cardDrawers = _DoubleZeroCardEpoch.ObjectContext.QueryObjects("RESCARDDRAWER", string.Empty);
                        foreach (ResCardDrawer cardDrawer in cardDrawers)
                        {
                            bool rcd = false;
                            TTObjectContext context = new TTObjectContext(true);
                            IList doubleZeroCardEpochs = DoubleZeroCardEpoch.GetDoubleZeroByStoreAndTerm(context, mainStore.ObjectID, term.ObjectID);
                            for (int s = 0; s < doubleZeroCardEpochs.Count; s++)
                            {
                                if (cardDrawer.ObjectID == ((DoubleZeroCardEpoch)doubleZeroCardEpochs[s]).CardDrawer.ObjectID)
                                    rcd = true;
                            }
                            if (rcd == false)
                            {
                                multiSelectForm.AddMSItem(cardDrawer.Name, cardDrawer.Name, cardDrawer);
                            }
                        }
                        string key = multiSelectForm.GetMSItem(ParentForm, "İşlem yapacağınız masayı seçin");

                        if (!string.IsNullOrEmpty(key))
                        {
                            resCardDrawer = multiSelectForm.MSSelectedItemObject as ResCardDrawer;
                            _DoubleZeroCardEpoch.CardDrawer = resCardDrawer;
                            this.SelectedStockCard.ListFilterExpression = "CARDDRAWER ='" + _DoubleZeroCardEpoch.CardDrawer.ObjectID.ToString() + "'";
                        }
                        else
                        {
                            throw new Exception(SystemMessage.GetMessage(1147));
                        }
                    }
                    else
                        resCardDrawer = _DoubleZeroCardEpoch.CardDrawer;

                    TTObjectContext objectContext = new TTObjectContext(true);
                    IList allZeroStockCards = StockCard.GetStockCardForZeroCensus(objectContext, resCardDrawer.ObjectID.ToString(), mainStore.ObjectID.ToString());
                    
                    //IList allZeroStocks = Stock.GetStockByCardDrawerForZeroCensus(objectContext ,resCardDrawer.ObjectID.ToString(), mainStore.ObjectID.ToString());
                    System.Threading.Thread newThread = new System.Threading.Thread(ProgressFormControl.Show);
                    newThread.Start(resCardDrawer.Name + " masası için çift sıfırlı kart devri yapılıyor...");
                    foreach (StockCard dzStockCard in allZeroStockCards)
                    {
                        IList accountancyStockCard = dzStockCard.AccountancyStockCards.Select("CARDDRAWER = " + ConnectionManager.GuidToString(resCardDrawer.ObjectID));
                        AccountancyStockCard aStockcard = null;
                        if (accountancyStockCard.Count > 0)
                            aStockcard = (AccountancyStockCard)accountancyStockCard[0];
                        else
                            throw new Exception(SystemMessage.GetMessage(1146));

                        if (aStockcard.Status != StockCardStatusEnum.DoubleZeroCard)
                        {
                            bool zeroCard = false;
                            foreach (Material dzMaterial in dzStockCard.Materials)
                            {
                                IList stock =  Stock.GetStockFromStoreAndMaterial(dzMaterial.ObjectID, mainStore.ObjectID);
                                Stock dzStock = null;
                                if (stock.Count == 1)
                                {
                                    Guid stockObjectID = (Guid)((Stock.GetStockFromStoreAndMaterial_Class)stock[0]).ObjectID ;
                                    dzStock = (Stock)objectContext.GetObject(stockObjectID,typeof(Stock));
                                }
                                else if (stock.Count > 1)
                                    throw new TTException(dzMaterial.Name + " isimli malzemenin ana depoda birden fazla stoğu bulunmuştur. Bilgi işleme haber veriniz.");

                                if (dzStock != null)
                                {
                                    if (dzStock.TotalIn == 0 & dzStock.TotalOut == 0)
                                    {
                                        AccountingTerm firstPrevTerm = term.PrevTerm;
                                        if (firstPrevTerm != null)
                                        {
                                            IList fpCensusDetail = StockCensusDetail.GetCensusDetail(_DoubleZeroCardEpoch.ObjectContext, firstPrevTerm.ObjectID, dzStock.ObjectID);
                                            if (fpCensusDetail.Count > 0)
                                            {
                                                StockCensusDetail firstDetail = ((StockCensusDetail)fpCensusDetail[0]);
                                                if (firstDetail.TotalInHeld == 0 & firstDetail.TotalIn == 0 & firstDetail.TotalOut == 0)
                                                {
                                                    AccountingTerm secoundPrevTerm = firstPrevTerm.PrevTerm;
                                                    if (secoundPrevTerm != null)
                                                    {
                                                        IList spCensusDetail = StockCensusDetail.GetCensusDetail(_DoubleZeroCardEpoch.ObjectContext, secoundPrevTerm.ObjectID, dzStock.ObjectID);
                                                        if (spCensusDetail.Count > 0)
                                                        {
                                                            StockCensusDetail secoundDetail = ((StockCensusDetail)spCensusDetail[0]);
                                                            if (secoundDetail.TotalInHeld == 0 & secoundDetail.TotalIn == 0 & secoundDetail.TotalOut == 0)
                                                            {
                                                                ProgressFormControl.FormText = dzStock.Material.Name;
                                                                //Application.DoEvents();
                                                                if (newThread.IsAlive == false)
                                                                    throw new Exception(SystemMessage.GetMessage(969));

                                                                zeroCard = true;

                                                            }
                                                            else
                                                            {
                                                                zeroCard = false;
                                                                break;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            zeroCard = false;
                                                            break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        zeroCard = false;
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    zeroCard = false;
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                zeroCard = false;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            zeroCard = false;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        zeroCard = false;
                                        break;
                                    }
                                }
                            }
                            if (zeroCard)
                            {
                                DoubleZeroCardEpochMaterial dzeMaterial = new DoubleZeroCardEpochMaterial(_DoubleZeroCardEpoch.ObjectContext);
                                dzeMaterial.OrderNo = aStockcard.CardOrderNO;
                                //dzeMaterial.Stock = dzStock;
                                dzeMaterial.StockCard = dzStockCard;
                                dzeMaterial.CardCount = aStockcard.CardAmount;
                                dzeMaterial.OldStockCardStatus = aStockcard.Status;
                                dzeMaterial.AddedManually = false;
                                _DoubleZeroCardEpoch.DoubleZeroCardEpochMaterials.Add(dzeMaterial);
                                totalCardCount = totalCardCount + 1;
                            }
                        }
                    }

                    _DoubleZeroCardEpoch.TotalCardCount = totalCardCount;

                    Dictionary<Guid, double> stockCardClass = new Dictionary<Guid, double>();
                    double newCount = 0;
                    foreach (DoubleZeroCardEpochMaterial classCard in _DoubleZeroCardEpoch.DoubleZeroCardEpochMaterials)
                    {
                        if (stockCardClass.ContainsKey(classCard.StockCard.StockCardClass.ObjectID) == false)
                        {
                            stockCardClass.Add(classCard.StockCard.StockCardClass.ObjectID, 1);
                        }
                        else
                        {
                            newCount = stockCardClass[classCard.StockCard.StockCardClass.ObjectID] + 1;
                            stockCardClass.Remove(classCard.StockCard.StockCardClass.ObjectID);
                            stockCardClass.Add(classCard.StockCard.StockCardClass.ObjectID, newCount);
                        }
                    }
                    newThread.Abort();
                }
                else
                {
                    for (int i = 0; i < stockActions.Count; i++)
                    {
                        if (((StockAction)stockActions[i]).CurrentStateDefID != StockAction.States.Completed || ((StockAction)stockActions[i]).CurrentStateDefID != StockAction.States.Cancelled)
                        {
                            continueStockActionString = continueStockActionString.ToString() + ((StockAction)stockActions[i]).StockActionID.ToString() + ",";
                        }
                    }
                    throw new TTUtils.TTException(SystemMessage.GetMessageV3(1148, new string[] {continueStockActionString.ToString()}));
                }
            }
            else
            {
                throw new TTException(SystemMessage.GetMessage(1149));
            }
#endregion DoubleZeroCardEpochForm_ClientSidePreScript

        }
    }
}