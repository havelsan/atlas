
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
    public partial class UsedConsumeMaterialAttribute : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
#region Body
            if (Interface.GetCurrentStateDef().StateDefID == UsedConsumedMaterail.States.Completed)
            {
                Store store = Interface.GetStore();
                StockOut stockOut = new StockOut(ObjectContext);
                stockOut.CurrentStateDefID = StockOut.States.New;
                stockOut.Store = store;
                StockOutMaterial stockOutMaterial = (StockOutMaterial)stockOut.StockOutMaterials.AddNew();
                stockOutMaterial.Material = Interface.GetMaterial();
                
                Stock stock = store.GetStock(Interface.GetMaterial());
                
                if(stock.Inheld != null)
                {
                    if(stock.Inheld > 0 && stock.Inheld >= Interface.GetAmount())
                    {
                        BindingList<StockTransaction.LOTOutableStockTransactions_Class> outableStockTransactions = StockTransaction.LOTOutableStockTransactions(stock.ObjectID);

                        switch (Interface.GetMaterial().StockCard.StockMethod)
                        {
                            case StockMethodEnum.ExpirationDated:
                                //MultiSelectForm mSelectForm = new MultiSelectForm();
                                //foreach (StockTransaction.LOTOutableStockTransactions_Class outableStockTransaction in outableStockTransactions)
                                //{
                                //    string ExpNo = string.Empty;
                                //    if (outableStockTransaction.LotNo != null)
                                //        ExpNo = outableStockTransaction.LotNo;
                                //    else
                                //        ExpNo = "-";

                                //    if (outableStockTransaction.ExpirationDate != null)
                                //        ExpNo = ExpNo + " - " + ((DateTime)outableStockTransaction.ExpirationDate).Month.ToString() + "/" + ((DateTime)outableStockTransaction.ExpirationDate).Year.ToString();
                                //    else
                                //        ExpNo = ExpNo + " - 01/0001";

                                //    mSelectForm.AddMSItem(ExpNo + "-" + outableStockTransaction.Restamount.ToString(), ExpNo, outableStockTransaction);
                                //}
                                //string mExpKey = mSelectForm.GetMSItem(null, "Son Kullanma Tarihini Seçiniz", true);
                                //if (string.IsNullOrEmpty(mExpKey))
                                //    throw new TTException(SystemMessage.GetMessage(372));
                                //StockTransaction.LOTOutableStockTransactions_Class exp = mSelectForm.MSSelectedItemObject as StockTransaction.LOTOutableStockTransactions_Class;

                                OuttableLot outableExp = new OuttableLot(ObjectContext);
                                outableExp.LotNo = Interface.GetOuttableLot().LotNo;
                                if(Interface.GetOuttableLot().ExpirationDate != null)
                                    outableExp.ExpirationDate = Interface.GetOuttableLot().ExpirationDate;
                                else
                                    outableExp.ExpirationDate = DateTime.MinValue;
                                outableExp.RestAmount = CurrencyType.ConvertFrom(Interface.GetOuttableLot().RestAmount);
                                outableExp.Amount = CurrencyType.ConvertFrom(Interface.GetOuttableLot().RestAmount);
                                outableExp.isUse = true;
                                outableExp.StockActionDetailOut = stockOutMaterial;
                                break;
                            case StockMethodEnum.LotUsed:
                                //MultiSelectForm multiSelectForm = new MultiSelectForm();
                                //foreach (StockTransaction.LOTOutableStockTransactions_Class outableStockTransaction in outableStockTransactions)
                                //{
                                //    string lotNo = string.Empty;
                                //    if (outableStockTransaction.LotNo != null)
                                //        lotNo = outableStockTransaction.LotNo;
                                //    else
                                //        lotNo = "-";

                                //    if (outableStockTransaction.ExpirationDate != null)
                                //        lotNo = lotNo + " - " + ((DateTime)outableStockTransaction.ExpirationDate).Month.ToString() + "/" + ((DateTime)outableStockTransaction.ExpirationDate).Year.ToString();

                                //    multiSelectForm.AddMSItem(lotNo + "-" + outableStockTransaction.Restamount.ToString(), lotNo, outableStockTransaction);
                                //}
                                //string mlotKey = multiSelectForm.GetMSItem(null, "Lot Seçiniz", true);
                                //if (string.IsNullOrEmpty(mlotKey))
                                //    throw new TTException(SystemMessage.GetMessage(372));
                                //StockTransaction.LOTOutableStockTransactions_Class lot = multiSelectForm.MSSelectedItemObject as StockTransaction.LOTOutableStockTransactions_Class;

                                OuttableLot outableLot = new OuttableLot(ObjectContext);
                                outableLot.LotNo = Interface.GetOuttableLot().LotNo;
                                if(Interface.GetOuttableLot().ExpirationDate != null)
                                    outableLot.ExpirationDate = Interface.GetOuttableLot().ExpirationDate;
                                else
                                    outableLot.ExpirationDate = DateTime.MinValue;
                                outableLot.RestAmount = CurrencyType.ConvertFrom(Interface.GetOuttableLot().RestAmount);
                                outableLot.Amount = CurrencyType.ConvertFrom(Interface.GetOuttableLot().RestAmount);
                                outableLot.isUse = true;
                                outableLot.StockActionDetailOut = stockOutMaterial;
                                break;
                            case StockMethodEnum.QRCodeUsed:
                                break;
                            case StockMethodEnum.SerialNumbered:
                                break;
                            case StockMethodEnum.StockNumbered:
                                break;

                        }
                        
                        stockOutMaterial.Amount = Interface.GetAmount();
                        stockOutMaterial.StockLevelType = StockLevelType.NewStockLevel;
                        stockOut.Update();
                        stockOut.CurrentStateDefID = StockOut.States.Completed;
                        Interface.SetStockOut(stockOut);
                    }
                    else
                         throw new TTException(TTUtils.CultureService.GetText("M27254", "Yeterli Mevcut yoktur."));
                }
            }
            if (Interface.GetCurrentStateDef().StateDefID == UsedConsumedMaterail.States.Cancelled)
            {
                StockOut stockOut = Interface.GetStockOut();
                stockOut.CurrentStateDefID = StockOut.States.Cancelled;
            }
#endregion Body
        }

        public override void Check(TTAttribute attribute)
        {
#region CheckBody
        
#endregion CheckBody
        }
    }
}