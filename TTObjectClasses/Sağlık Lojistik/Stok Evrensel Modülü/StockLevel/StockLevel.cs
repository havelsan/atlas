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
    /// Stok işlemlerinde malzemenin stok seviyesini tutar. yeni/kullanılmış/heke ayrılmış
    /// </summary>
    public partial class StockLevel : TTObject
    {
#region Methods
        public StockLevel(TTObjectContext ctx, StockTransaction stockTransaction): this (ctx)
        {
            StockLevelType = stockTransaction.StockLevelType;
            Amount = stockTransaction.Amount;
        }

        public static double StockInheld(Guid materialID, Guid storeID)
        {
            //Bir malzemenin verilen parametredeki depodaki mevcudunu bulur
            TTObjectContext context = new TTObjectContext(false);
            Material material = (Material)context.GetObject(materialID, typeof (Material));
            BindingList<Stock> stocks = material.Stocks.Select("STORE = " + ConnectionManager.GuidToString(storeID));
            if (stocks.Count == 1 && stocks[0].Inheld.HasValue)
                return stocks[0].Inheld.Value;
            return 0;
        }

        public static double StockMaxLevel(Guid materialID, Guid storeID)
        {
            //Bir malzemenin verilen parametredeki depodaki mevcudunu bulur
            TTObjectContext context = new TTObjectContext(false);
            Material material = (Material)context.GetObject(materialID, typeof(Material));
            BindingList<Stock> stocks = material.Stocks.Select("STORE = " + ConnectionManager.GuidToString(storeID));
            if (stocks.Count == 1 && stocks[0].MaximumLevel.HasValue)
                return stocks[0].MaximumLevel.Value;
            return 0;
        }

        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.ChangeStockLevelType_Kayit)]
        public static double StockInheldWithStockLevel(Guid materialID, Guid storeID, Guid stockLevelTypeID)
        {
            //Bir malzemenin verilen parametredeki depodaki mevcudunu stok seviyesine göre bulur
            TTObjectContext context = new TTObjectContext(false);
            Guid budgetGuid = Guid.Empty;
            Material material = (Material)context.GetObject(materialID, typeof (Material));
            Store store = (Store)context.GetObject(storeID, typeof (Store));
            if (store is MainStoreDefinition)
            {
                if (((MainStoreDefinition)store).MKYS_ButceTuru != null)
                {
                    List<BudgetTypeDefinition> budgetTypeDefList = context.QueryObjects<BudgetTypeDefinition>("MKYS_BUTCE = " + Common.GetEnumValueDefOfEnumValue(((MainStoreDefinition)(store)).MKYS_ButceTuru.Value).Value).ToList();
                    if (budgetTypeDefList.Count == 1)
                    {
                        budgetGuid = ((BudgetTypeDefinition)budgetTypeDefList[0]).ObjectID;
                    }
                    else if (budgetTypeDefList.Count > 1)
                    {
                        TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M25075", "1 den fazla bütçe tipi tanımlanmıştır. Bilgi işleme haber veriniz.!"));
                    }
                    else
                    {
                        TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M27039", "Tanımlı bütçe tipi bulunamamıştır. Bilgi işleme haber veriniz.!"));
                    }
                }
            }

            Currency Amount = 0;
            BindingList<Stock> stocks = material.Stocks.Select("STORE = " + ConnectionManager.GuidToString(storeID));
            if (budgetGuid != Guid.Empty)
            {
                if (stocks.Count == 1)
                {
                    BindingList<StockTransaction> transactionsIn = stocks[0].StockTransactions.Select(" INOUT = 1 AND BUDGETTYPEDEFINITION = " + ConnectionManager.GuidToString(budgetGuid) + " AND STOCKLEVELTYPE = " + ConnectionManager.GuidToString(stockLevelTypeID) + " AND CURRENTSTATEDEFID <> '41ef11f6-f61b-4292-a982-3eb2acd1dbb8'");
                    foreach (StockTransaction st in transactionsIn)
                    {
                        Amount += (Currency)st.Amount;
                    }

                    BindingList<StockTransaction> transactionsOut = stocks[0].StockTransactions.Select(" INOUT = 2 AND BUDGETTYPEDEFINITION = " + ConnectionManager.GuidToString(budgetGuid) + " AND STOCKLEVELTYPE = " + ConnectionManager.GuidToString(stockLevelTypeID) + " AND CURRENTSTATEDEFID <> '41ef11f6-f61b-4292-a982-3eb2acd1dbb8'");
                    foreach (StockTransaction st in transactionsOut)
                    {
                        Amount -= (Currency)st.Amount;
                    }

                    return Amount;
                }
            }
            else
            {
                if (stocks.Count == 1 && stocks[0].Inheld.HasValue)
                {
                    BindingList<StockLevel> stockLevels = stocks[0].StockLevels.Select("STOCKLEVELTYPE = " + ConnectionManager.GuidToString(stockLevelTypeID));
                    if (stockLevels.Count == 1 && stockLevels[0].Amount.HasValue)
                        return stockLevels[0].Amount.Value;
                }
            }

            return 0;
        }

        public static double StockInheldWithStockLevelByBudgetType(Guid materialID, Guid storeID, Guid stockLevelTypeID, Guid destinationStoreID)
        {
            //Bir malzemenin verilen parametredeki depodaki mevcudunu stok seviyesine göre bulur
            TTObjectContext context = new TTObjectContext(false);
            Guid budgetGuid = Guid.Empty;
            Material material = (Material)context.GetObject(materialID, typeof (Material));
            Store destinationStore = (Store)context.GetObject(destinationStoreID, typeof (Store));
            if (destinationStore is MainStoreDefinition)
            {
                if (((MainStoreDefinition)destinationStore).MKYS_ButceTuru != null)
                {
                    List<BudgetTypeDefinition> budgetTypeDefList = context.QueryObjects<BudgetTypeDefinition>("MKYS_BUTCE = " + Common.GetEnumValueDefOfEnumValue(((MainStoreDefinition)(destinationStore)).MKYS_ButceTuru.Value).Value).ToList();
                    if (budgetTypeDefList.Count == 1)
                    {
                        budgetGuid = ((BudgetTypeDefinition)budgetTypeDefList[0]).ObjectID;
                    }
                    else if (budgetTypeDefList.Count > 1)
                    {
                        TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M25075", "1 den fazla bütçe tipi tanımlanmıştır. Bilgi işleme haber veriniz.!"));
                    }
                    else
                    {
                        TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M27039", "Tanımlı bütçe tipi bulunamamıştır. Bilgi işleme haber veriniz.!"));
                    }
                }
            }

            Currency Amount = 0;
            BindingList<Stock> stocks = material.Stocks.Select("STORE = " + ConnectionManager.GuidToString(storeID));
            if (budgetGuid != Guid.Empty)
            {
                if (stocks.Count == 1)
                {
                    BindingList<StockTransaction> transactionsIn = stocks[0].StockTransactions.Select(" INOUT = 1 AND BUDGETTYPEDEFINITION = " + ConnectionManager.GuidToString(budgetGuid) + " AND STOCKLEVELTYPE = " + ConnectionManager.GuidToString(stockLevelTypeID) + " AND CURRENTSTATEDEFID <> '41ef11f6-f61b-4292-a982-3eb2acd1dbb8'");
                    foreach (StockTransaction st in transactionsIn)
                    {
                        Amount += (Currency)st.Amount;
                    }

                    BindingList<StockTransaction> transactionsOut = stocks[0].StockTransactions.Select(" INOUT = 2 AND BUDGETTYPEDEFINITION = " + ConnectionManager.GuidToString(budgetGuid) + " AND STOCKLEVELTYPE = " + ConnectionManager.GuidToString(stockLevelTypeID) + " AND CURRENTSTATEDEFID <> '41ef11f6-f61b-4292-a982-3eb2acd1dbb8'");
                    foreach (StockTransaction st in transactionsOut)
                    {
                        Amount -= (Currency)st.Amount;
                    }

                    return Amount;
                }
            }
            else
            {
                if (stocks.Count == 1 && stocks[0].Inheld.HasValue)
                {
                    BindingList<StockLevel> stockLevels = stocks[0].StockLevels.Select("STOCKLEVELTYPE = " + ConnectionManager.GuidToString(stockLevelTypeID));
                    if (stockLevels.Count == 1 && stockLevels[0].Amount.HasValue)
                        return stockLevels[0].Amount.Value;
                }
            }

            return 0;
        }
#endregion Methods
    }
}