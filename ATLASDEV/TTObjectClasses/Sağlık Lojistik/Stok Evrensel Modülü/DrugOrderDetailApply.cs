
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
    public partial class DrugOrderDetailApply : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
            #region Body
            TTObjectContext context = ObjectContext;
            DrugOrderDetail drugOrderDetail = Interface.GetOwnDrugOrderDetail();
            //context.AddObject(drugOrderDetail);
            BindingList<DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class> outtableTransactions = DrugOrderTransaction.GetOuttableDrugOrderTransactions(drugOrderDetail.Episode.ObjectID.ToString(), drugOrderDetail.Material.ObjectID.ToString());

            bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrderDetail.Material);
            double totalAmount = 0;

            if (drugType)
                totalAmount = (double)drugOrderDetail.Amount;
            else
                totalAmount = (double)drugOrderDetail.DoseAmount;

            if (totalAmount == 0)
                throw new TTException(TTUtils.CultureService.GetText("M27108", "Toplam uygulanacak miktar 0 olamaz."));

            List<DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class> selectedTrx = new List<DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class>();

            IBindingList ownTrx = context.QueryObjects("DRUGORDERTRANSACTION", "DRUGORDER = " + ConnectionManager.GuidToString(drugOrderDetail.DrugOrder.ObjectID));
            if (ownTrx.Count > 0)
            {
                DrugOrderTransaction drugOrderTransaction = (DrugOrderTransaction)ownTrx[0];
                DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class selectedOwnTrx = outtableTransactions.Where(t => t.ObjectID == drugOrderTransaction.ObjectID).FirstOrDefault();
                if (selectedOwnTrx != null)
                {
                    if (Convert.ToDouble(selectedOwnTrx.Restamount) >= totalAmount)
                    {
                        selectedTrx.Add(selectedOwnTrx);
                        totalAmount = 0;
                    }
                    else
                    {
                        totalAmount = totalAmount - Convert.ToDouble(selectedOwnTrx.Restamount);
                        selectedTrx.Add(selectedOwnTrx);
                        outtableTransactions.Remove(selectedOwnTrx);
                    }
                }
            }


            if (totalAmount > 0)
            {
                foreach (DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class inTrx in outtableTransactions)
                {
                    if (Convert.ToDouble(inTrx.Restamount) >= totalAmount)
                    {
                        selectedTrx.Add(inTrx);
                        break;
                    }
                    else
                    {
                        totalAmount = totalAmount - Convert.ToDouble(inTrx.Restamount);
                        selectedTrx.Add(inTrx);
                    }
                }
            }

            double transactionAmount = 0;
            if (drugType)
                transactionAmount = (double)drugOrderDetail.Amount;
            else
                transactionAmount = (double)drugOrderDetail.DoseAmount;

            if (transactionAmount == 0)
                throw new TTException(TTUtils.CultureService.GetText("M27108", "Toplam uygulanacak miktar 0 olamaz."));
            foreach (DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class orderTransaction in selectedTrx)
            {
                if (transactionAmount == 0)
                    break;

                double trxRestAmount = Convert.ToDouble(orderTransaction.Restamount);
                DrugOrderTransaction trx = (DrugOrderTransaction)context.GetObject((Guid)orderTransaction.ObjectID, typeof(DrugOrderTransaction));
                if (transactionAmount >= trxRestAmount)
                {
                    DrugOrderTransactionDetail drugOrderTransactionDetail = new DrugOrderTransactionDetail(context);
                    drugOrderTransactionDetail.DrugOrderDetail = drugOrderDetail;
                    drugOrderTransactionDetail.Amount = trxRestAmount;
                    drugOrderTransactionDetail.StockTransaction = trx.KScheduleMaterial.StockTransactions.Select(string.Empty).FirstOrDefault();
                    drugOrderTransactionDetail.DrugOrderTransaction = trx;
                    drugOrderTransactionDetail.CurrentStateDefID = DrugOrderTransactionDetail.States.Completed;
                    if (drugType)
                    {
                        if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.ReturnPharmacy)
                            drugOrderTransactionDetail.IsStockOperation = false;
                        else
                            drugOrderTransactionDetail.IsStockOperation = true;
                    }
                    else
                    {
                        double drugVolume = (double)((DrugDefinition)trx.KScheduleMaterial.Material).Volume;
                        if (trxRestAmount >= drugVolume)
                        {
                            double kalan = trxRestAmount % drugVolume;
                            if (kalan == 0)
                            {
                                if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.ReturnPharmacy)
                                    drugOrderTransactionDetail.IsStockOperation = false;
                                else
                                    drugOrderTransactionDetail.IsStockOperation = true;
                            }
                            else
                                drugOrderTransactionDetail.IsStockOperation = false;
                        }
                        else
                            drugOrderTransactionDetail.IsStockOperation = false;
                    }
                    transactionAmount = transactionAmount - trxRestAmount;
                }
                else
                {
                    DrugOrderTransactionDetail drugOrderTransactionDetail = new DrugOrderTransactionDetail(context);
                    drugOrderTransactionDetail.DrugOrderDetail = drugOrderDetail;
                    drugOrderTransactionDetail.Amount = transactionAmount;
                    drugOrderTransactionDetail.StockTransaction = trx.KScheduleMaterial.StockTransactions.Select(string.Empty).FirstOrDefault();
                    drugOrderTransactionDetail.DrugOrderTransaction = trx;
                    drugOrderTransactionDetail.CurrentStateDefID = DrugOrderTransactionDetail.States.Completed;
                    if (drugType)
                    {
                        if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.ReturnPharmacy)
                            drugOrderTransactionDetail.IsStockOperation = false;
                        else
                            drugOrderTransactionDetail.IsStockOperation = true;
                    }
                    else
                    {
                        double drugVolume = (double)((DrugDefinition)trx.KScheduleMaterial.Material).Volume;
                        if (transactionAmount > drugVolume)
                        {
                            double kalan = transactionAmount % drugVolume;
                            if (kalan == 0)
                            {
                                if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.ReturnPharmacy)
                                    drugOrderTransactionDetail.IsStockOperation = false;
                                else
                                    drugOrderTransactionDetail.IsStockOperation = true;
                            }
                            else
                                drugOrderTransactionDetail.IsStockOperation = false;
                        }
                        else
                            drugOrderTransactionDetail.IsStockOperation = false;
                    }
                    transactionAmount = 0;
                }
            }

            /*double transactionAmount = 0;
            if (drugType)
                transactionAmount = (double)drugOrderDetail.Amount;
            else
                transactionAmount = (double)drugOrderDetail.DoseAmount;

            if (transactionAmount == 0)
                throw new TTException(TTUtils.CultureService.GetText("M27108", "Toplam uygulanacak miktar 0 olamaz."));

            foreach (DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class orderTransaction in selectedTrx)
            {
                DrugOrderTransaction trx = (DrugOrderTransaction)context.GetObject((Guid)orderTransaction.ObjectID, typeof(DrugOrderTransaction));
                List<StockTransaction> transactionList = trx.KScheduleMaterial.StockTransactions.Select(string.Empty, "TRANSACTIONDATE").ToList();
                Dictionary<StockTransaction, double> restStockTransaction = new Dictionary<StockTransaction, double>();
                foreach (StockTransaction stockTransaction in transactionList)
                {
                    double returnAmount = (double)trx.DrugOrderTransactionDetails.Where(t => t.StockTransaction.ObjectID == stockTransaction.ObjectID).Where(a => a.CurrentStateDefID == DrugOrderTransactionDetail.States.Completed).Where(s => s.DrugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.ReturnPharmacy).Sum(z => z.Amount);
                    double trxAmount = 0;
                    if (drugType)
                        trxAmount = (double)stockTransaction.Amount;
                    else
                        trxAmount = (double)stockTransaction.Amount * (double)((DrugDefinition)stockTransaction.Stock.Material).Volume;

                    trxAmount = trxAmount + returnAmount;
                    double trxUseAmount = (double)trx.DrugOrderTransactionDetails.Where(t => t.StockTransaction.ObjectID == stockTransaction.ObjectID).Where(a => a.CurrentStateDefID == DrugOrderTransactionDetail.States.Completed).Sum(z => z.Amount);
                    double trxRestAmount = trxAmount - trxUseAmount;
                    if (trxRestAmount > 0)
                        restStockTransaction.Add(stockTransaction, trxRestAmount);
                }

                foreach (KeyValuePair<StockTransaction, double> rTrx in restStockTransaction)
                {
                    if (rTrx.Value >= transactionAmount)
                    {
                        DrugOrderTransactionDetail drugOrderTransactionDetail = new DrugOrderTransactionDetail(context);
                        drugOrderTransactionDetail.DrugOrderDetail = drugOrderDetail;
                        drugOrderTransactionDetail.Amount = transactionAmount;
                        drugOrderTransactionDetail.StockTransaction = rTrx.Key;
                        drugOrderTransactionDetail.DrugOrderTransaction = trx;
                        drugOrderTransactionDetail.CurrentStateDefID = DrugOrderTransactionDetail.States.Completed;
                        if (drugType)
                        {
                            if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.ReturnPharmacy)
                                drugOrderTransactionDetail.IsStockOperation = false;
                            else
                                drugOrderTransactionDetail.IsStockOperation = true;
                        }
                        else
                        {
                            double drugVolume = (double)((DrugDefinition)rTrx.Key.Stock.Material).Volume;
                            if (rTrx.Value >= drugVolume)
                            {
                                double kalan = rTrx.Value % drugVolume;
                                if (kalan == 0)
                                {
                                    if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.ReturnPharmacy)
                                        drugOrderTransactionDetail.IsStockOperation = false;
                                    else
                                        drugOrderTransactionDetail.IsStockOperation = true;
                                }
                                else
                                    drugOrderTransactionDetail.IsStockOperation = false;
                            }
                            else
                                drugOrderTransactionDetail.IsStockOperation = false;
                        }
                        transactionAmount = 0;
                        break;
                    }
                    else
                    {
                        transactionAmount = transactionAmount - rTrx.Value;
                        DrugOrderTransactionDetail drugOrderTransactionDetail = new DrugOrderTransactionDetail(context);
                        drugOrderTransactionDetail.DrugOrderDetail = drugOrderDetail;
                        drugOrderTransactionDetail.Amount = transactionAmount;
                        drugOrderTransactionDetail.StockTransaction = rTrx.Key;
                        drugOrderTransactionDetail.DrugOrderTransaction = trx;
                        drugOrderTransactionDetail.CurrentStateDefID = DrugOrderTransactionDetail.States.Completed;
                        if (drugType)
                        {
                            if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.ReturnPharmacy)
                                drugOrderTransactionDetail.IsStockOperation = false;
                            else
                                drugOrderTransactionDetail.IsStockOperation = true;
                        }
                        else
                        {
                            double drugVolume = (double)((DrugDefinition)rTrx.Key.Stock.Material).Volume;
                            if (rTrx.Value > drugVolume)
                            {
                                double kalan = rTrx.Value % drugVolume;
                                if (kalan == 0)
                                {
                                    if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.ReturnPharmacy)
                                        drugOrderTransactionDetail.IsStockOperation = false;
                                    else
                                        drugOrderTransactionDetail.IsStockOperation = true;
                                }
                                else
                                    drugOrderTransactionDetail.IsStockOperation = false;
                            }
                            else
                                drugOrderTransactionDetail.IsStockOperation = false;
                        }
                    }
                }

                if (transactionAmount == 0)
                    break;
            }*/

            bool isCompletedOrder = true;
            foreach (DrugOrderDetail anotherDetail in drugOrderDetail.DrugOrder.DrugOrderDetails)
            {
                if (anotherDetail.ObjectID != drugOrderDetail.ObjectID)
                {
                    if (anotherDetail.CurrentStateDefID != DrugOrderDetail.States.Apply || anotherDetail.CurrentStateDefID != DrugOrderDetail.States.Cancel || anotherDetail.CurrentStateDefID != DrugOrderDetail.States.PatientDelivery ||
                        anotherDetail.CurrentStateDefID != DrugOrderDetail.States.ReturnPharmacy || anotherDetail.CurrentStateDefID != DrugOrderDetail.States.Stop)
                    {
                        isCompletedOrder = false;
                    }
                }
            }

            if (isCompletedOrder)
            {
                DrugOrder order = (DrugOrder)context.GetObject(drugOrderDetail.DrugOrder.ObjectID, typeof(DrugOrder));
                if (order.CurrentStateDefID != DrugOrder.States.Stopped)
                    order.CurrentStateDefID = DrugOrder.States.Completed;
            }
            if (drugType == false && drugOrderDetail.Eligible == false)
            {
                if (drugOrderDetail.DrugOrder.DrugOrderTransactions.Any())
                {
                    List<DrugOrderDetail> detList = drugOrderDetail.DrugOrder.DrugOrderDetails.Where(x => x.Eligible == true && x.CurrentStateDef.Status != StateStatusEnum.CompletedSuccessfully).ToList();
                    if (detList.Count > 0)
                    {
                        foreach (DrugOrderDetail item in detList)
                        {
                            if (item.CurrentStateDefID != DrugOrderDetail.States.Cancel)
                                item.Eligible = false;
                        }

                        if (drugOrderDetail.DrugOrder.DrugOrderDetails.Where(x => x.Eligible == true && x.CurrentStateDef.Status == StateStatusEnum.CompletedSuccessfully).Any() == false)
                            drugOrderDetail.Eligible = true;
                    }
                }
                
            }

            if (drugOrderDetail.CurrentStateDefID != DrugOrderDetail.States.PatientDelivery && drugOrderDetail.CurrentStateDefID != DrugOrderDetail.States.ReturnPharmacy)
            {
                if (drugOrderDetail.Eligible == false || drugOrderDetail.Material.Chargable == false)
                {
                    double amount = drugOrderDetail.Amount.Value;
                    if (drugType == false)
                        amount = 1;

                    for (int i = 0; i < amount; i++)
                    {
                        ENabizMaterial eNabizMaterial = new ENabizMaterial(context);
                        eNabizMaterial.RequestDate = drugOrderDetail.CreationDate;
                        eNabizMaterial.ApplicationDate = drugOrderDetail.CreationDate;
                        eNabizMaterial.PayerPrice = 0;
                        eNabizMaterial.PatientPrice = 0;
                        eNabizMaterial.SubActionMaterial = drugOrderDetail;
                        eNabizMaterial.CurrentStateDefID = ENabizMaterial.States.Completed;
                    }
                }
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