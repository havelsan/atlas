
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
    /// Tüketim, Üretim ve Elde Edilenler Belgesi
    /// </summary>
    public partial class ProductionConsumptionDocumentNewForm : BaseProductionConsumptionDocumentForm
    {
        protected override void PreScript()
        {
#region ProductionConsumptionDocumentNewForm_PreScript
    base.PreScript();

            if(_ProductionConsumptionDocument.Store is IUnitStoreDefinition)
            {
                IList terms = _ProductionConsumptionDocument.ObjectContext.QueryObjects("ACCOUNTINGTERM", "STATUS = 1");
                if (terms.Count > 0)
                {
                    if (terms.Count == 1)
                    {
                        _ProductionConsumptionDocument.AccountingTerm = (AccountingTerm)terms[0];
                    }
                    else
                    {
                        throw new TTException(SystemMessage.GetMessage(1151));
                    }
                }
                else
                {
                    throw new TTException(SystemMessage.GetMessage(1152));
                }
            }
#endregion ProductionConsumptionDocumentNewForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region ProductionConsumptionDocumentNewForm_ClientSidePreScript
    base.ClientSidePreScript();
            if (this._ProductionConsumptionDocument.CurrentStateDefID == ProductionConsumptionDocument.States.New)
            {
                ProductionConsumptionDocumentDateEntryForm productionConsumptionDocumentDateEntryForm = new ProductionConsumptionDocumentDateEntryForm();
                DialogResult dialogResult = productionConsumptionDocumentDateEntryForm.ShowEdit(this, this._ProductionConsumptionDocument, true);

                if (dialogResult == DialogResult.OK)
                {

                    StockTransactionDefinition stockTransactionDefinition = (StockTransactionDefinition)_ProductionConsumptionDocument.ObjectContext.GetObject(new Guid(_ProductionConsumptionDocument.ObjectDef.Attributes["STOCKCONSUMPTIONTRANSACTIONATTRIBUTE"].Parameters["stockTransactionDef"].Value.ToString()), "STOCKTRANSACTIONDEFINITION");
                    int rowCount = 0;
                    bool calcnew = false;
                    List<StockTransaction> stockTransactions = stockTransactionDefinition.CollectStockTransactions((DateTime)_ProductionConsumptionDocument.StartDate, (DateTime)_ProductionConsumptionDocument.EndDate, _ProductionConsumptionDocument.Store);
                    if (stockTransactions != null)
                    {

                        foreach (StockTransaction stockTransaction in stockTransactions)
                        {
                            IList existDetails = this._ProductionConsumptionDocument.ProductionConsumptionDocumentOutMaterials.Select("MATERIAL = " + ConnectionManager.GuidToString(stockTransaction.Stock.Material.ObjectID));
                            ProductionConsumptionDocumentMaterialOut productionConsumptionDocumentMaterialOut = null;
                            if (existDetails.Count > 0)
                            {
                                productionConsumptionDocumentMaterialOut = (ProductionConsumptionDocumentMaterialOut)existDetails[0];
                                productionConsumptionDocumentMaterialOut.Amount += stockTransaction.Amount;

                                StockCollectedTrx stockCollectedTrx = productionConsumptionDocumentMaterialOut.StockCollectedTrxs.AddNew();
                                stockCollectedTrx.StockTransaction = stockTransaction;
                            }
                            else
                            {
                                if (rowCount >= 20)
                                {
                                    calcnew = true;
                                }
                                else
                                {
                                    productionConsumptionDocumentMaterialOut = this._ProductionConsumptionDocument.ProductionConsumptionDocumentOutMaterials.AddNew();
                                    productionConsumptionDocumentMaterialOut.Amount = stockTransaction.Amount;
                                    productionConsumptionDocumentMaterialOut.Material = stockTransaction.Stock.Material;
                                    productionConsumptionDocumentMaterialOut.StockLevelType = stockTransaction.StockLevelType;
                                    productionConsumptionDocumentMaterialOut.Material.StockCard.DistributionType = stockTransaction.Stock.Material.StockCard.DistributionType;

                                    StockCollectedTrx stockCollectedTrx = productionConsumptionDocumentMaterialOut.StockCollectedTrxs.AddNew();
                                    stockCollectedTrx.StockTransaction = stockTransaction;

                                    rowCount++;
                                }

                            }
                        }
                    }
                    if (calcnew)
                    {
                        TTVisual.InfoBox.Show(((DateTime)_ProductionConsumptionDocument.StartDate).ToShortDateString() + " " + ((DateTime)_ProductionConsumptionDocument.EndDate).ToShortDateString() + " tarihleri arasında bu işlemi bir daha çalıştırmanız gerekmektedir.", MessageIconEnum.InformationMessage);
                    }
                }


                if (_ProductionConsumptionDocument.StockActionSignDetails.Count == 0)
                {
                    StockActionSignDetail stockActionSignDetail = _ProductionConsumptionDocument.StockActionSignDetails.AddNew();
                    stockActionSignDetail.SignUserType = SignUserTypeEnum.BirlikXXXXXXi;

                    stockActionSignDetail = _ProductionConsumptionDocument.StockActionSignDetails.AddNew();
                    stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSaymani;
                    if (_ProductionConsumptionDocument.DestinationStore is MainStoreDefinition)
                        stockActionSignDetail.SignUser = ((MainStoreDefinition)_ProductionConsumptionDocument.DestinationStore).GoodsAccountant;

                    stockActionSignDetail = _ProductionConsumptionDocument.StockActionSignDetails.AddNew();
                    stockActionSignDetail.SignUserType = SignUserTypeEnum.HesapSorumlusu;
                    if(_ProductionConsumptionDocument.DestinationStore is MainStoreDefinition)
                    {
                        if(((MainStoreDefinition)_ProductionConsumptionDocument.DestinationStore).AccountManager != null)
                        {
                            stockActionSignDetail.SignUser = ((MainStoreDefinition)_ProductionConsumptionDocument.DestinationStore).AccountManager;
                        }
                        else
                        {
                            ResUser user = TTUser.CurrentUser.UserObject as ResUser;
                            if (user.SelectedSecMasterResource != null && user.SelectedSecMasterResource.ResourceUsers.Count > 0)
                                stockActionSignDetail.SignUser = user.SelectedSecMasterResource.ResourceUsers[0].User;
                        }
                    }
                    
                    //                    if (_ProductionConsumptionDocument.DestinationStore is MainStoreDefinition)
                    //                    {
                    //                        ResUser user = TTUser.CurrentUser.UserObject as ResUser;
                    //                        if (user.SelectedSecMasterResource != null && user.SelectedSecMasterResource.ResourceUsers.Count > 0)
                    //                            stockActionSignDetail.SignUser = user.SelectedSecMasterResource.ResourceUsers[0].User;
                    //                    }

                    stockActionSignDetail = _ProductionConsumptionDocument.StockActionSignDetails.AddNew();
                    stockActionSignDetail.SignUserType = SignUserTypeEnum.BirlikMalSorumlusu;
                    if (_ProductionConsumptionDocument.DestinationStore is MainStoreDefinition)
                        stockActionSignDetail.SignUser = ((MainStoreDefinition)_ProductionConsumptionDocument.DestinationStore).GoodsResponsible;

                    stockActionSignDetail = _ProductionConsumptionDocument.StockActionSignDetails.AddNew();
                    stockActionSignDetail.SignUserType = SignUserTypeEnum.DepoSorumlusu;
                    if (_ProductionConsumptionDocument.Store is SubStoreDefinition)
                        stockActionSignDetail.SignUser = ((SubStoreDefinition)_ProductionConsumptionDocument.Store).StoreResponsible;
                    else if (_ProductionConsumptionDocument.Store is PharmacyStoreDefinition)
                        stockActionSignDetail.SignUser = ((PharmacyStoreDefinition)_ProductionConsumptionDocument.Store).StoreResponsible;
                }
            }
#endregion ProductionConsumptionDocumentNewForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ProductionConsumptionDocumentNewForm_PostScript
    base.PostScript(transDef);

    _ProductionConsumptionDocument.CheckStockCardCardNofCount(20);
#endregion ProductionConsumptionDocumentNewForm_PostScript

            }
                }
}