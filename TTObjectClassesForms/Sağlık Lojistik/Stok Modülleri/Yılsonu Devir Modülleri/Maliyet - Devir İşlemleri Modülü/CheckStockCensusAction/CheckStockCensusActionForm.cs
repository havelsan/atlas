
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
    /// Yılsonu / Çift Sıfırlı Kart Devir İşlemi
    /// </summary>
    public partial class CheckStockCensusActionForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdUpdateCreationDate.Click += new TTControlEventDelegate(cmdUpdateCreationDate_Click);
            cmdDoubleZeroCensus.Click += new TTControlEventDelegate(cmdDoubleZeroCensus_Click);
            cmdStockCensus.Click += new TTControlEventDelegate(cmdStockCensus_Click);
            cmdCheckErrors.Click += new TTControlEventDelegate(cmdCheckErrors_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdUpdateCreationDate.Click -= new TTControlEventDelegate(cmdUpdateCreationDate_Click);
            cmdDoubleZeroCensus.Click -= new TTControlEventDelegate(cmdDoubleZeroCensus_Click);
            cmdStockCensus.Click -= new TTControlEventDelegate(cmdStockCensus_Click);
            cmdCheckErrors.Click -= new TTControlEventDelegate(cmdCheckErrors_Click);
            base.UnBindControlEvents();
        }

        private void cmdUpdateCreationDate_Click()
        {
#region CheckStockCensusActionForm_cmdUpdateCreationDate_Click
   System.Threading.Thread newThread = new System.Threading.Thread(ProgressFormControl.Show);
            newThread.Start("Güncellemeler yapılıyor...");

            foreach (WrongStock wrongStock in _CheckStockCensusAction.WrongStock)
            {
                ProgressFormControl.FormText = wrongStock.Stock.Material.Name;
                //Application.DoEvents();

                if (newThread.IsAlive == false)
                    throw new Exception(SystemMessage.GetMessage(969));

                TTObjectContext context = new TTObjectContext(false);
                Stock updateStock = (Stock)context.GetObject(wrongStock.Stock.ObjectID, typeof(Stock));
                updateStock.CreationDate = wrongStock.CreationDate;
                context.Save();
                context.Dispose();
            }

            newThread.Abort();
#endregion CheckStockCensusActionForm_cmdUpdateCreationDate_Click
        }

        private void cmdDoubleZeroCensus_Click()
        {
#region CheckStockCensusActionForm_cmdDoubleZeroCensus_Click
   foreach (StockCensusCardDrawer stockCensusCardDrawer in _CheckStockCensusAction.StockCensusCardDrawers)
            {
                if (stockCensusCardDrawer.IsDoubleZeroCompleted == false)
                {
                    TTObjectContext contex = new TTObjectContext(false);
                    DoubleZeroCardEpoch doubleZeroCardEpoch = new DoubleZeroCardEpoch(contex);
                    doubleZeroCardEpoch.Store = _CheckStockCensusAction.MainStoreDefinition;
                    doubleZeroCardEpoch.Term = _CheckStockCensusAction.AccountingTerm;
                    doubleZeroCardEpoch.CardDrawer = stockCensusCardDrawer.CardDrawer;
                    doubleZeroCardEpoch.CurrentStateDefID = DoubleZeroCardEpoch.States.New;
                    TTForm doubleZeroCardEpochForm = TTForm.GetEditForm(doubleZeroCardEpoch);
                    this.PrapareFormToShow(doubleZeroCardEpochForm);
                    if (doubleZeroCardEpochForm.ShowEdit(this.FindForm(), doubleZeroCardEpoch) == DialogResult.OK)
                        contex.Save();
                }
            }
#endregion CheckStockCensusActionForm_cmdDoubleZeroCensus_Click
        }

        private void cmdStockCensus_Click()
        {
#region CheckStockCensusActionForm_cmdStockCensus_Click
   foreach (StockCensusCardDrawer stockCensusCardDrawer in _CheckStockCensusAction.StockCensusCardDrawers)
            {
                if (stockCensusCardDrawer.IsStockCensusCompleted == false)
                {
                    TTObjectContext contex = new TTObjectContext(false);
                    StockCensus stockCensus = new StockCensus(contex);
                    stockCensus.Store = _CheckStockCensusAction.MainStoreDefinition;
                    stockCensus.AccountingTerm = _CheckStockCensusAction.AccountingTerm;
                    stockCensus.CardDrawer = stockCensusCardDrawer.CardDrawer;
                    stockCensus.CurrentStateDefID = StockCensus.States.New;
                    TTForm stockCensusForm = TTForm.GetEditForm(stockCensus);
                    this.PrapareFormToShow(stockCensusForm);
                    if (stockCensusForm.ShowEdit(this.FindForm(), stockCensus) == DialogResult.OK)
                        contex.Save();
                }
            }
#endregion CheckStockCensusActionForm_cmdStockCensus_Click
        }

        private void cmdCheckErrors_Click()
        {
#region CheckStockCensusActionForm_cmdCheckErrors_Click
   bool error = false;
            List<Material> errorCardDrawers = new List<Material>();
            List<Material> errorStockCards = new List<Material>();
            List<Material> errorCreationDates = new List<Material>();
            Dictionary<Guid,StockCard> errorDoubleCarddrawer = new Dictionary<Guid,StockCard>();
            IList stocks = _CheckStockCensusAction.ObjectContext.QueryObjects("STOCK","STORE ="+ConnectionManager.GuidToString(_CheckStockCensusAction.MainStoreDefinition.ObjectID));
            
            System.Threading.Thread newThread = new System.Threading.Thread(ProgressFormControl.Show);
            newThread.Start("Kontrol yapılıyor...");
            
            foreach (Stock stock in stocks)
            {
                ProgressFormControl.FormText = stock.Material.Name;
                //Application.DoEvents();

                if (newThread.IsAlive == false)
                    throw new Exception(SystemMessage.GetMessage(969));

                if (stock.Material.StockCard == null)
                {
                    errorStockCards.Add(stock.Material);
                }
                else
                {
                    if (stock.Material.StockCard.AccountancyStockCards.Select("ACCOUNTANCY =" + ConnectionManager.GuidToString(_CheckStockCensusAction.MainStoreDefinition.Accountancy.ObjectID)).Count == 0)
                        errorCardDrawers.Add(stock.Material);
                    else if (stock.Material.StockCard.AccountancyStockCards.Select("ACCOUNTANCY =" + ConnectionManager.GuidToString(_CheckStockCensusAction.MainStoreDefinition.Accountancy.ObjectID)).Count > 1)
                    {
                        if(errorDoubleCarddrawer.ContainsKey(stock.Material.StockCard.ObjectID) == false)
                            errorDoubleCarddrawer.Add(stock.Material.StockCard.ObjectID,stock.Material.StockCard);
                    }
                }

                IList minStockTransactionDate = StockTransaction.GetMinTransactionDate(stock.ObjectID);
                if (minStockTransactionDate.Count > 0)
                {
                    StockTransaction.GetMinTransactionDate_Class minTrxDate = (StockTransaction.GetMinTransactionDate_Class)minStockTransactionDate[0];
                    if (minTrxDate.Nqlcolumn != null)
                    {
                        DateTime minDate = ((DateTime)minTrxDate.Nqlcolumn);
                        if (minDate < stock.CreationDate)
                        {
                            WrongStock wrongStock = new WrongStock(_CheckStockCensusAction.ObjectContext);
                            wrongStock.Stock = stock;
                            wrongStock.CreationDate = minDate;
                            wrongStock.CheckStockCensusAction = _CheckStockCensusAction;
                            errorCreationDates.Add(stock.Material);
                        }
                    }
                }
            }

            if (errorCardDrawers.Count > 0)
            {
                error = true;
                string errorDrawersTxt = string.Empty;
                foreach (Material material in errorCardDrawers)
                {
                    if (errorDrawersTxt == string.Empty)
                        errorDrawersTxt = material.StockCard.NATOStockNO + " - " + material.StockCard.Name + "\r\n";
                    else
                        errorDrawersTxt = errorDrawersTxt + material.StockCard.NATOStockNO + " - " + material.StockCard.Name + "\r\n" ;
                }
                this.errorDrawersTxt.Text = errorDrawersTxt;
            }

            if (errorStockCards.Count > 0)
            {
                error = true;
                string errorStockCardTxt = string.Empty;
                foreach (Material material in errorStockCards)
                {
                    if (errorStockCardTxt == string.Empty)
                        errorStockCardTxt = material.Name + "\r\n";
                    else
                        errorStockCardTxt = errorStockCardTxt + material.Name + "\r\n";
                }
                this.errorStockCardTxt.Text = errorStockCardTxt;
            }

            if (errorCreationDates.Count > 0)
            {
                error = true;
                string errorCreationDate = string.Empty;
                foreach (Material material in errorCreationDates)
                {
                    if (errorCreationDate == string.Empty)
                        errorCreationDate = material.Name + "\r\n";
                    else
                        errorCreationDate = errorCreationDate + material.Name + "\r\n";
                }
                this.errorCreationDateTxt.Text = errorCreationDate;
            }
            
            if (errorDoubleCarddrawer.Count > 0)
            {
                error = true;
                string errorCarddrawer = string.Empty;
                foreach (KeyValuePair<Guid, StockCard> sCard in errorDoubleCarddrawer)
                {
                    if (errorCarddrawer == string.Empty)
                        errorCarddrawer = sCard.Value.NATOStockNO + " - " + sCard.Value.Name + "\r\n";
                    else
                        errorCarddrawer = errorCarddrawer + sCard.Value.NATOStockNO + " - " + sCard.Value.Name + "\r\n";
                }
                this.errorDoubleCarddrawer.Text = errorCarddrawer;
            }

            newThread.Abort();

            if (error == false)
            {
                cmdDoubleZeroCensus.ReadOnly = false;
                cmdStockCensus.ReadOnly = false;
                _CheckStockCensusAction.IsChecked = true;
            }
#endregion CheckStockCensusActionForm_cmdCheckErrors_Click
        }

        protected override void ClientSidePreScript()
        {
#region CheckStockCensusActionForm_ClientSidePreScript
    base.ClientSidePreScript();
            if(_CheckStockCensusAction.IsChecked.HasValue &&(bool) _CheckStockCensusAction.IsChecked)
            {
                this.cmdCheckErrors.Enabled = false;
                this.cmdUpdateCreationDate.Enabled = false;
                this.cmdDoubleZeroCensus.ReadOnly = false;
                this.cmdStockCensus.ReadOnly = false;
            }
            else
                _CheckStockCensusAction.WrongStock.DeleteChildren();
            
            if(_CheckStockCensusAction.WrongStock.Count > 0)
                this.cmdUpdateCreationDate.ReadOnly = false;
            
            //_CheckStockCensusAction.StockCensusCardDrawers.DeleteChildren();

            MainStoreDefinition mainStore = CommonForm.SelectResourceDependentMainStoreDefinition(this);
            if (mainStore == null)
                throw new Exception(SystemMessage.GetMessage(713));
            else
                _CheckStockCensusAction.MainStoreDefinition = mainStore;
            
            AccountingTerm term = mainStore.Accountancy.GetHalfOpenAccountingTerm();
            if (term == null)
                throw new TTException(SystemMessage.GetMessage(1149));
            else
                _CheckStockCensusAction.AccountingTerm = term;
            
            IList anotherCheckAction = _CheckStockCensusAction.ObjectContext.QueryObjects("CHECKSTOCKCENSUSACTION", "MAINSTOREDEFINITION =" + ConnectionManager.GuidToString(_CheckStockCensusAction.MainStoreDefinition.ObjectID) + " AND ACCOUNTINGTERM =" + ConnectionManager.GuidToString(_CheckStockCensusAction.AccountingTerm.ObjectID));
            if (anotherCheckAction.Count == 1)
            {
                if (((CheckStockCensusAction)anotherCheckAction[0]).ObjectID != _CheckStockCensusAction.ObjectID)
                    throw new TTException("Daha önce başlatımmış devir işlemi bulunmaktadır. İşlem No : " + ((CheckStockCensusAction)anotherCheckAction[0]).ID.ToString());
            }
            else if(anotherCheckAction.Count > 1)
                throw new TTException("Birden fazla devir işlemi bulumuştur. Bilgi işleme haber veriniz");
            
            if (_CheckStockCensusAction.StockCensusCardDrawers.Count == 0)
            {
                IList cardDrawers = _CheckStockCensusAction.ObjectContext.QueryObjects("RESCARDDRAWER", "STORE =" + ConnectionManager.GuidToString(_CheckStockCensusAction.MainStoreDefinition.ObjectID));
                foreach (ResCardDrawer cardDrawer in cardDrawers)
                {
                    StockCensusCardDrawer stockCensusCardDrawer = new StockCensusCardDrawer(_CheckStockCensusAction.ObjectContext);
                    stockCensusCardDrawer.CardDrawer = cardDrawer;
                    stockCensusCardDrawer.IsDoubleZeroCompleted = false;
                    stockCensusCardDrawer.DoubleZeroObjectID = null;
                    stockCensusCardDrawer.IsStockCensusCompleted = false;
                    stockCensusCardDrawer.StockCensusObjectID = null;
                    stockCensusCardDrawer.CheckStockCensusAction = _CheckStockCensusAction;
                    if (_CheckStockCensusAction.MainStoreDefinition.AccountManager != null)
                    {
                        stockCensusCardDrawer.ResUser = _CheckStockCensusAction.MainStoreDefinition.AccountManager;
                    }

                }
            }

            foreach (StockCensusCardDrawer stockCensusCardDrawer in _CheckStockCensusAction.StockCensusCardDrawers)
            {
                stockCensusCardDrawer.IsDoubleZeroCompleted = false;
                stockCensusCardDrawer.IsStockCensusCompleted = false;
                stockCensusCardDrawer.StockCensusObjectID = null;
                stockCensusCardDrawer.DoubleZeroObjectID = null;

                //Çift Sıfırlı Kart Devri
                IList doubleZeroCensus = _CheckStockCensusAction.ObjectContext.QueryObjects("DOUBLEZEROCARDEPOCH", "TERM =" + ConnectionManager.GuidToString(term.ObjectID) + " AND CARDDRAWER = " + ConnectionManager.GuidToString(stockCensusCardDrawer.CardDrawer.ObjectID));
                if (doubleZeroCensus.Count > 0)
                {
                    stockCensusCardDrawer.IsDoubleZeroCompleted = false;
                    foreach (DoubleZeroCardEpoch doubleZeroCardEpoch in doubleZeroCensus)
                    {
                        if (doubleZeroCardEpoch.CurrentStateDefID != DoubleZeroCardEpoch.States.Cancelled)
                        {
                            stockCensusCardDrawer.IsDoubleZeroCompleted = true;
                            stockCensusCardDrawer.DoubleZeroObjectID = ((DoubleZeroCardEpoch)doubleZeroCensus[0]).ObjectID;
                        }
                    }
                }


                // Yılsonu Devri
                IList stockCensus = _CheckStockCensusAction.ObjectContext.QueryObjects("STOCKCENSUS", "ACCOUNTINGTERM =" + ConnectionManager.GuidToString(term.ObjectID) + " AND CARDDRAWER = " + ConnectionManager.GuidToString(stockCensusCardDrawer.CardDrawer.ObjectID));
                if (stockCensus.Count > 0)
                {
                    stockCensusCardDrawer.IsStockCensusCompleted = false;
                    foreach (StockCensus sCensus in stockCensus)
                    {
                        if (sCensus.CurrentStateDefID != StockCensus.States.Canceled)
                        {
                            stockCensusCardDrawer.IsStockCensusCompleted = true;
                            stockCensusCardDrawer.StockCensusObjectID = sCensus.ObjectID;
                        }
                    }
                }
            }

            if (_CheckStockCensusAction.CensusSignUserDetails.Count == 0)
            {
                CensusSignUser censusSignUser = _CheckStockCensusAction.CensusSignUserDetails.AddNew();
                censusSignUser.InspectionUserType = SignUserTypeEnum.Baskan;
                
                censusSignUser = _CheckStockCensusAction.CensusSignUserDetails.AddNew();
                censusSignUser.InspectionUserType = SignUserTypeEnum.BirlikXXXXXXi;
                

                
                censusSignUser = _CheckStockCensusAction.CensusSignUserDetails.AddNew();
                censusSignUser.InspectionUserType = SignUserTypeEnum.TeftisKuruluBaskani;
                
                censusSignUser = _CheckStockCensusAction.CensusSignUserDetails.AddNew();
                censusSignUser.InspectionUserType = SignUserTypeEnum.TeftisKuruluMufettisi;
                
                censusSignUser = _CheckStockCensusAction.CensusSignUserDetails.AddNew();
                censusSignUser.InspectionUserType = SignUserTypeEnum.MalSaymani;
                
               if (_CheckStockCensusAction.MainStoreDefinition.GoodsAccountant != null)
                {
                    censusSignUser.CensusSignUsers = _CheckStockCensusAction.MainStoreDefinition.GoodsAccountant;
                }
                
                
                censusSignUser = _CheckStockCensusAction.CensusSignUserDetails.AddNew();
                censusSignUser.InspectionUserType = SignUserTypeEnum.MalSorumlusu ;
                
                if (_CheckStockCensusAction.MainStoreDefinition.GoodsResponsible != null)
                {
                    censusSignUser.CensusSignUsers = _CheckStockCensusAction.MainStoreDefinition.GoodsResponsible;
                }
                
            }
#endregion CheckStockCensusActionForm_ClientSidePreScript

        }

#region CheckStockCensusActionForm_Methods
        protected virtual void ShowAction_ObjectUpdated(TTObject ttObject, ref bool contextSaved)
        {
            ttObject.ObjectContext.Save();
            contextSaved = true;
        }

        protected void PrapareFormToShow(TTForm frm)
        {
            frm.ObjectUpdated += new ObjectUpdatedDelegate(ShowAction_ObjectUpdated);
            frm.GetTemplates = this.GetTemplates;
            frm.SaveTemplate = this.SaveTemplate;
            frm.TemplateSelected = this.TemplateSelected;
        }
        
#endregion CheckStockCensusActionForm_Methods
    }
}