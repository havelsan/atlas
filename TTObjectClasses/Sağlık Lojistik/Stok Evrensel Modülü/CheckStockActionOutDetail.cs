
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
    public partial class CheckStockActionOutDetail : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
            #region Body
            string exception = "";
            foreach (StockActionDetailOut item in Interface.GetStockActionOutDetails())
            {
                if (item.StockAction is IBasePrescriptionTransaction)
                {
                    if (item.PrescriptionPaperOutDetails.Count != item.Amount)
                    {
                        if (exception != "")
                            exception += Environment.NewLine + item.Material.Name + " isimli malzemenin reçete detayları girilmemiş veya eksik girilmiştir.";
                        else
                            exception += item.Material.Name + " isimli malzemenin reçete detayları girilmemiş veya eksik girilmiştir.";
                    }
                }
                else
                {
                    if (item.UserSelectedOutableTrx != true)
                    {
                        //********* ERDAL 04.10.2013 *********
                        TTObjectContext context = new TTObjectContext(false);
                        BindingList<StockTransaction.LOTOutableStockTransactions_Class> outableStockTransactions = null;
                        BindingList<StockTransaction.LOTOutableStockTransactionsBudgetType_Class> outableStockTransactionsByBudgetType = null;
                        Stock stock = item.StockAction.Store.GetStock(item.Material);
                        if (item.StockAction.Store is MainStoreDefinition)
                        {
                            if (((MainStoreDefinition)(item.StockAction.Store)).MKYS_ButceTuru != null)
                            {
                                Guid budgetGuid = Guid.Empty;

                                if (((MainStoreDefinition)item.StockAction.Store).MKYS_ButceTuru != null)
                                {
                                    List<BudgetTypeDefinition> budgetTypeDefList = context.QueryObjects<BudgetTypeDefinition>("MKYS_BUTCE = " + Common.GetEnumValueDefOfEnumValue(((MainStoreDefinition)(item.StockAction.Store)).MKYS_ButceTuru.Value).Value).ToList();
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


                                outableStockTransactionsByBudgetType = StockTransaction.LOTOutableStockTransactionsBudgetType(stock.ObjectID, budgetGuid);
                            }
                            else
                            {
                                outableStockTransactions = StockTransaction.LOTOutableStockTransactions(stock.ObjectID);
                            }
                        }
                        else
                        {
                            outableStockTransactions = StockTransaction.LOTOutableStockTransactions(stock.ObjectID);
                        }

                        if (SystemParameter.GetParameterValue("USELOTANDEXPIREDATE", "FALSE") == "FALSE")
                        {
                            if (outableStockTransactions != null)
                            {
                                foreach (StockTransaction.LOTOutableStockTransactions_Class lot in outableStockTransactions)
                                {
                                    OuttableLot outtableLot = new OuttableLot(ObjectContext);
                                    outtableLot.LotNo = lot.LotNo;
                                    if (lot.ExpirationDate == null)
                                        outtableLot.ExpirationDate = DateTime.MinValue;
                                    else
                                        outtableLot.ExpirationDate = lot.ExpirationDate;
                                    outtableLot.RestAmount = CurrencyType.ConvertFrom(lot.Restamount);
                                    outtableLot.Amount = CurrencyType.ConvertFrom(lot.Restamount);
                                    outtableLot.isUse = true;
                                    outtableLot.StockActionDetailOut = item;
                                }
                            }
                            if (outableStockTransactionsByBudgetType != null)
                            {
                                foreach (StockTransaction.LOTOutableStockTransactionsBudgetType_Class lot in outableStockTransactionsByBudgetType)
                                {
                                    OuttableLot outtableLot = new OuttableLot(ObjectContext);
                                    outtableLot.LotNo = lot.LotNo;
                                    if (lot.ExpirationDate == null)
                                        outtableLot.ExpirationDate = DateTime.MinValue;
                                    else
                                        outtableLot.ExpirationDate = lot.ExpirationDate;
                                    outtableLot.RestAmount = CurrencyType.ConvertFrom(lot.Restamount);
                                    outtableLot.Amount = CurrencyType.ConvertFrom(lot.Restamount);
                                    outtableLot.isUse = true;
                                    outtableLot.StockActionDetailOut = item;
                                }
                            }
                        }
                        else
                        {
                            if (outableStockTransactions.Count == 1)
                            {

                                OuttableLot outtableLot = new OuttableLot(ObjectContext);
                                outtableLot.LotNo = outableStockTransactions[0].LotNo;
                                if (outableStockTransactions[0].ExpirationDate == null)
                                    outtableLot.ExpirationDate = DateTime.MinValue;
                                else
                                    outtableLot.ExpirationDate = outableStockTransactions[0].ExpirationDate;
                                outtableLot.RestAmount = CurrencyType.ConvertFrom(outableStockTransactions[0].Restamount);
                                outtableLot.Amount = CurrencyType.ConvertFrom(outableStockTransactions[0].Restamount);
                                outtableLot.isUse = true;
                                outtableLot.StockActionDetailOut = item;
                            }
                        }
                        /* BindingList<StockTransaction.LOTOutableStockTransactions_Class> outableStockTransactions = StockTransaction.LOTOutableStockTransactions(stock.ObjectID);
                         if (SystemParameter.GetParameterValue("USELOTANDEXPIREDATE", "FALSE") == "FALSE")
                         {
                             foreach (StockTransaction.LOTOutableStockTransactions_Class lot in outableStockTransactions)
                             {
                                 OuttableLot outtableLot = new OuttableLot(item.ObjectContext);
                                 outtableLot.LotNo = lot.LotNo;
                                 if (lot.ExpirationDate == null)
                                     outtableLot.ExpirationDate = DateTime.MinValue;
                                 else
                                     outtableLot.ExpirationDate = lot.ExpirationDate;
                                 outtableLot.RestAmount = CurrencyType.ConvertFrom(lot.Restamount);
                                 outtableLot.Amount = CurrencyType.ConvertFrom(lot.Restamount);
                                 outtableLot.isUse = true;
                                 outtableLot.StockActionDetailOut = item;
                             }
                         }
                         else
                         {
                             if (outableStockTransactions.Count == 1)
                             {

                                 OuttableLot outtableLot = new OuttableLot(item.ObjectContext);
                                 outtableLot.LotNo = outableStockTransactions[0].LotNo;
                                 if (outableStockTransactions[0].ExpirationDate == null)
                                     outtableLot.ExpirationDate = DateTime.MinValue;
                                 else
                                     outtableLot.ExpirationDate = outableStockTransactions[0].ExpirationDate;
                                 outtableLot.RestAmount = CurrencyType.ConvertFrom(outableStockTransactions[0].Restamount);
                                 outtableLot.Amount = CurrencyType.ConvertFrom(outableStockTransactions[0].Restamount);
                                 outtableLot.isUse = true;
                                 outtableLot.StockActionDetailOut = item;
                             }
                         }*/

                        //*************************************

                        switch ((StockMethodEnum)item.Material.StockCard.StockMethod)
                        {
                            case StockMethodEnum.ExpirationDated:
                            case StockMethodEnum.LotUsed:
                                Currency restAmount = 0;

                                foreach (OuttableLot lot in item.OuttableLots)
                                {
                                    if (lot.isUse == true)
                                    {
                                        restAmount += (Currency)lot.RestAmount;
                                    }
                                }

                                if (item.Amount > restAmount)
                                {
                                    if (exception != "")
                                        exception += Environment.NewLine + item.Material.Name + " isimli malzemenin çıkılabilir girişlerinde yeterli mevcut yoktur. Tekrar Seçiniz.";
                                    else
                                        exception += item.Material.Name + " isimli malzemenin çıkılabilir girişlerinde yeterli mevcut yoktur. Tekrar Seçiniz.";
                                }

                                break;
                            case StockMethodEnum.QRCodeUsed:
                                double packageAmount = (double)item.Material.PackageAmount;
                                Currency availAmount = (Currency)item.Amount % packageAmount;
                                double qrCodeCount = Math.Floor((double)item.Amount / packageAmount);
                                if (availAmount > 0)
                                {
                                    double stockInheld = item.Material.StockInheld(item.StockAction.Store, item.StockLevelType);
                                    if (stockInheld % packageAmount == 0)
                                        qrCodeCount = qrCodeCount + 1;
                                }

                                if (qrCodeCount != item.QRCodeOutDetails.Count)
                                {
                                    if (exception != "")
                                        exception += Environment.NewLine + item.Material.Name + " isimli malzemenin kare kod detayları eksik girilmiş veya girilmemiştir. Tekrar Seçiniz.";
                                    else
                                        exception += item.Material.Name + " isimli malzemenin kare kod detayları eksik girilmiş veya girilmemiştir. Tekrar Seçiniz.";
                                }
                                break;
                            case StockMethodEnum.SerialNumbered:
                                if (item.Amount > item.FixedAssetOutDetails.Count || item.FixedAssetOutDetails.Count == 0)
                                {
                                    if (exception != "")
                                        exception += Environment.NewLine + item.Material.Name + " isimli malzemenin demirbaş detayları eksik girilmiş veya girilmemiştir. Tekrar Seçiniz.";
                                    else
                                        exception += item.Material.Name + " isimli malzemenin demirbaş detayları eksik girilmiş veya girilmemiştir. Tekrar Seçiniz.";
                                }
                                break;
                            case StockMethodEnum.StockNumbered:
                            default:
                                break;
                        }
                    }
                }
            }


            if (!string.IsNullOrEmpty(exception))
                throw new TTException(exception);
            #endregion Body
        }

        public override void Check(TTAttribute attribute)
        {
            #region CheckBody

            #endregion CheckBody
        }
    }
}