
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
    /// Depoya Göre Sayım Emri Belgesi
    /// </summary>
    public partial class CensusOrderByStoreNewForm : BaseCensusOrderByStoreForm
    {
        protected override void PreScript()
        {
#region CensusOrderByStoreNewForm_PreScript
    base.PreScript();

            if (((ITTObject)_CensusOrderByStore).IsNew)
            {
                if (_StockAction.StockActionSignDetails.Count == 0)
                {
                    StockActionSignDetail stockActionSignDetail = _StockAction.StockActionSignDetails.AddNew();
                    stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSaymani;
                    if (_StockAction.Store is MainStoreDefinition)
                        stockActionSignDetail.SignUser = ((MainStoreDefinition)_StockAction.Store).GoodsAccountant;

                    stockActionSignDetail = _StockAction.StockActionSignDetails.AddNew();
                    stockActionSignDetail.SignUserType = SignUserTypeEnum.HesapSorumlusu;
                    if (_StockAction.Store is MainStoreDefinition)
                    {
                        ResUser user = TTUser.CurrentUser.UserObject as ResUser;
                        if (user.SelectedSecMasterResource.ResourceUsers.Count > 0)
                            stockActionSignDetail.SignUser = user.SelectedSecMasterResource.ResourceUsers[0].User;
                    }

                    stockActionSignDetail = _StockAction.StockActionSignDetails.AddNew();
                    stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSorumlusu;
                    if (_StockAction.Store is MainStoreDefinition)
                        stockActionSignDetail.SignUser = ((MainStoreDefinition)_StockAction.Store).GoodsResponsible;

                    stockActionSignDetail = _StockAction.StockActionSignDetails.AddNew();
                    stockActionSignDetail.SignUserType = SignUserTypeEnum.Baskan;
                    stockActionSignDetail.SignUser = null;

                    stockActionSignDetail = _StockAction.StockActionSignDetails.AddNew();
                    stockActionSignDetail.SignUserType = SignUserTypeEnum.Uye;
                    stockActionSignDetail.SignUser = null;

                    stockActionSignDetail = _StockAction.StockActionSignDetails.AddNew();
                    stockActionSignDetail.SignUserType = SignUserTypeEnum.Uye;
                    stockActionSignDetail.SignUser = null;
                }
            }
#endregion CensusOrderByStoreNewForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region CensusOrderByStoreNewForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            if (((ITTObject)_CensusOrderByStore).IsNew)
            {
                SelectCensusOrderByStoreTypeForm selectCensusOrderByStoreTypeForm = new SelectCensusOrderByStoreTypeForm();
                //selectCensusOrderByStoreTypeForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                DialogResult dialogResult = selectCensusOrderByStoreTypeForm.ShowEdit(this, _CensusOrderByStore, true);
                if (dialogResult == DialogResult.Cancel)
                    throw new Exception("Sayım Emri İşlemi İptal Edildi.");
                GetCensusOrderDetails();
            }
#endregion CensusOrderByStoreNewForm_ClientSidePreScript

        }

#region CensusOrderByStoreNewForm_Methods
        private void GetCensusOrderDetails()
        {

            int totalCardCount = 0;
            string filterExpression = string.Empty;

            if (this._CensusOrderByStore.CensusOrderType == CensusOrderTypeEnum.HaveInheld)
                filterExpression = "AND INHELD > 0";
            else if (this._CensusOrderByStore.CensusOrderType == CensusOrderTypeEnum.HaveInheldAndOldInheld)
                filterExpression = "AND INHELD > 0 AND CONSIGNED > 0";
            else if(this._CensusOrderByStore.CensusOrderType == CensusOrderTypeEnum.HaveInheldOrConsigned)
                filterExpression = "AND (INHELD > 0 OR CONSIGNED > 0)";
            
            

            TTObjectContext objectContext = new TTObjectContext(false);

            IList stocks = Stock.GetCensusOrderStocksByStore(objectContext, this._CensusOrderByStore.Store.ObjectID, filterExpression);
            if (stocks.Count > 0)
            {
                Dictionary<Guid, CensusOrderMainClass> mainClasses = new Dictionary<Guid, CensusOrderMainClass>();
                int orderSequenceNumber = 1;
                foreach (Stock stock in stocks)
                {
                    if(stock.Material.StockCard != null)
                    {
                        CensusOrderMainClass censusOrderMainClasses = null;
                        if (mainClasses.TryGetValue(stock.Material.StockCard.StockCardClass.RootStockCardClass.ObjectID, out censusOrderMainClasses))
                        {
                            censusOrderMainClasses.CardCount++;
                        }
                        else
                        {
                            censusOrderMainClasses = new CensusOrderMainClass(_CensusOrderByStore.ObjectContext);
                            censusOrderMainClasses.StockCardClass = stock.Material.StockCard.StockCardClass.RootStockCardClass;
                            censusOrderMainClasses.CardCount = 1;
                            this._CensusOrderByStore.CensusOrderMainClasses.Add(censusOrderMainClasses);
                            mainClasses.Add(stock.Material.StockCard.StockCardClass.RootStockCardClass.ObjectID, censusOrderMainClasses);
                        }
                        totalCardCount++;
                        CensusOrderDetail censusOrderDetail = new CensusOrderDetail(_CensusOrderByStore.ObjectContext);
                        censusOrderDetail.OrderSequenceNumber = orderSequenceNumber;
                        censusOrderDetail.Material = stock.Material;
                        censusOrderDetail.Consigned = stock.Consigned;
                        censusOrderDetail.NewInheld = 0;
                        
                        censusOrderDetail.CensusNewInheld = 0;
                        censusOrderDetail.CensusUsedInheld = 0;
                        
                        orderSequenceNumber++;
                        foreach (StockLevel stockLevel in stock.StockLevels)
                        {
                            if (stockLevel.StockLevelType.ObjectID.Equals(StockLevelType.NewStockLevel.ObjectID))
                            {
                                censusOrderDetail.NewInheld = Convert.ToDouble(stockLevel.Amount);
                                censusOrderDetail.CensusNewInheld = Convert.ToDouble(stockLevel.Amount);
                            }
                            else if (stockLevel.StockLevelType.ObjectID.Equals(StockLevelType.UsedStockLevel.ObjectID))
                            {
                                censusOrderDetail.UsedInheld = Convert.ToDouble(stockLevel.Amount);
                                censusOrderDetail.CensusUsedInheld = Convert.ToDouble(stockLevel.Amount);
                            }
                        }
                        if (censusOrderDetail.UsedInheld.HasValue == false)
                        {
                            censusOrderDetail.UsedInheld = 0;
                            censusOrderDetail.CensusUsedInheld = 0;
                        }
                        _CensusOrderByStore.CensusOrderDetails.Add(censusOrderDetail);
                    }
                }
            }
        }
        
#endregion CensusOrderByStoreNewForm_Methods
    }
}