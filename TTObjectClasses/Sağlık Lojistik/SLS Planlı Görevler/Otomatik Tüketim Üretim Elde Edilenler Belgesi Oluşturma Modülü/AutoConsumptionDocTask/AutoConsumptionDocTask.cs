
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
    /// Otomatik Tüketim Üretim Elde Edilenler Belgesi Oluşturma
    /// </summary>
    public  partial class AutoConsumptionDocTask : BaseScheduledTask
    {
#region Methods
        public override void TaskScript()
        {

            DateTime beforeMount = Common.RecTime().AddMonths(- 1);
            DateTime startDate = Convert.ToDateTime("1." + beforeMount.Month.ToString()+"." + beforeMount.Year.ToString() + " " + "00:00:00");
            DateTime endDate = Convert.ToDateTime(Common.GetLastDayOfMounth(beforeMount).ToShortDateString() + " " + "23:59:59");
            
            TTObjectContext readOnlyContex = new TTObjectContext(true);
            IList storeList = readOnlyContex.QueryObjects("STORE","OBJECTDEFID IN('5132326b-d01f-4086-897f-7daf0f3dce5a','009d82e7-40a9-444f-b8c6-a3ca69eca81c') AND STATUS = 1 AND ISACTIVE = 1");
            StockTransactionDefinition stockTransactionDefinition = (StockTransactionDefinition)readOnlyContex.GetObject(new Guid("cb308c2a-3ebf-426b-aabc-754367cec92b"), "STOCKTRANSACTIONDEFINITION");
            foreach (Store store in storeList)
            {
                TTObjectContext context = new TTObjectContext(false);
                Dictionary<Material, ProductionConsumptionDocumentMaterialOut> consumptionMaterial = new Dictionary<Material, ProductionConsumptionDocumentMaterialOut>();
                List<StockTransaction> stockTransactions = stockTransactionDefinition.CollectStockTransactions(startDate, endDate, store);
                if (stockTransactions != null)
                {
                    foreach (StockTransaction stockTransaction in stockTransactions)
                    {
                        if (consumptionMaterial.ContainsKey(stockTransaction.Stock.Material))
                        {
                            consumptionMaterial[stockTransaction.Stock.Material].Amount = consumptionMaterial[stockTransaction.Stock.Material].Amount + (Currency)stockTransaction.Amount;
                            
                            StockCollectedTrx stockCollectedTrx = consumptionMaterial[stockTransaction.Stock.Material].StockCollectedTrxs.AddNew();
                            stockCollectedTrx.StockTransaction = stockTransaction;
                        }
                        else
                        {
                            ProductionConsumptionDocumentMaterialOut productionConsumptionDocumentMaterialOut = new ProductionConsumptionDocumentMaterialOut(context);
                            productionConsumptionDocumentMaterialOut.Amount = stockTransaction.Amount;
                            productionConsumptionDocumentMaterialOut.Material = stockTransaction.Stock.Material;
                            productionConsumptionDocumentMaterialOut.StockLevelType = stockTransaction.StockLevelType;
                            productionConsumptionDocumentMaterialOut.Material.StockCard.DistributionType = stockTransaction.Stock.Material.StockCard.DistributionType;

                            StockCollectedTrx stockCollectedTrx = productionConsumptionDocumentMaterialOut.StockCollectedTrxs.AddNew();
                            stockCollectedTrx.StockTransaction = stockTransaction;

                            consumptionMaterial.Add(stockTransaction.Stock.Material, productionConsumptionDocumentMaterialOut);
                        }
                    }
                }

                if (consumptionMaterial.Count > 0)
                {
                    int count = 0;
                    ProductionConsumptionDocument productionConsumptionDocument = null;
                    foreach (KeyValuePair<Material, ProductionConsumptionDocumentMaterialOut> matOut in consumptionMaterial)
                    {
                        if (count == 0)
                        {
                            productionConsumptionDocument = new ProductionConsumptionDocument(context);
                            productionConsumptionDocument.CurrentStateDefID = ProductionConsumptionDocument.States.AutoCreate;
                            productionConsumptionDocument.Store = store;
                            productionConsumptionDocument.StartDate = startDate ;
                            productionConsumptionDocument.EndDate = endDate ;

                            IList mainStores = MainStoreDefinition.GetAllMainStores(context);
                            if (mainStores.Count == 0)
                                throw new TTException(TTUtils.CultureService.GetText("M26805", "Saymanlık deposu bulunamadı."));
                            if (mainStores.Count == 1)
                            {
                                productionConsumptionDocument.DestinationStore = (MainStoreDefinition)mainStores[0];
                            }
                            else
                            {
                                throw new TTException(TTUtils.CultureService.GetText("M25279", "Birden fazla saymanlık deposu bulundu."));
                            }
                            productionConsumptionDocument.Update();
                        }
                        ProductionConsumptionDocumentMaterialOut productionConsumptionDocumentMaterialOut = matOut.Value;
                        productionConsumptionDocumentMaterialOut.StockAction = productionConsumptionDocument;
                        count++;
                        if (count == 20)
                            count = 0;
                    }

                    List<ResUser> toUsers = new List<ResUser>();
                    if (productionConsumptionDocument.DestinationStore is MainStoreDefinition)
                    {
                        if (((MainStoreDefinition)productionConsumptionDocument.DestinationStore).GoodsResponsible != null)
                        {
                            toUsers.Add(((MainStoreDefinition)productionConsumptionDocument.DestinationStore).GoodsResponsible);
                        }
                    }
                    if (productionConsumptionDocument.Store is SubStoreDefinition)
                    {
                        if(((SubStoreDefinition)productionConsumptionDocument.Store).StoreResponsible != null)
                            toUsers.Add(((SubStoreDefinition)productionConsumptionDocument.Store).StoreResponsible);
                    }
                    else if(productionConsumptionDocument.Store is PharmacyStoreDefinition)
                    {
                        if(((PharmacyStoreDefinition)productionConsumptionDocument.Store).StoreResponsible != null)
                            toUsers.Add(((PharmacyStoreDefinition)productionConsumptionDocument.Store).StoreResponsible);
                    }

                    string msg = productionConsumptionDocument.StartDate.ToString() + " - " + productionConsumptionDocument.EndDate.ToString() + " tarihleri arasında "+ productionConsumptionDocument.Store.Name + " deposu için Tüketim Üretim Elde Edilenler Belgesi oluşturulmuştur." ;
                    UserMessage.SendMessageInternalWithResUser(context, toUsers, TTUtils.CultureService.GetText("M26645", "Otomatik Oluşturulan Tüketim Üretim Elde Edilenler Belgesi"), Globals.StringToRTF(msg));
                    AddLog(msg);
                    context.Save();
                }
                context.Dispose();
            }
        }
        
        public override void AddLog(string log)
        {
            base.AddLog(log);
        }
        
#endregion Methods

    }
}